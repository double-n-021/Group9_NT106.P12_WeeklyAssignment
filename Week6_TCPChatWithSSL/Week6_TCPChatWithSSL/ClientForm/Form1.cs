using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;


namespace ClientForm
{
    public partial class Form1 : Form
    {
        private TcpClient tcpClient;
        private StreamReader sReader;
        private StreamWriter sWriter;
        private Thread clientThread;
        private int serverPort = 8000;
        private bool stopTcpClient = true;
        public const int BufferSize = 4096;
        public const int FileBufferSize = 3072;
        private string SaveFileName = string.Empty;
        private MemoryStream fileSaveMemoryStream;
        private SslStream sslStream; // Thay đổi thành thuộc tính sslStream

        public enum 
            MessageType
        {
            Text,
            FileEof,
            FilePart,
        }
        public Form1()
        {
            InitializeComponent();

        }

        private static X509Certificate2 GetClientCertificate()
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 cert in store.Certificates)
            {
                if (cert.Subject.Contains("CN=MySslSocketCertificate"))
                {
                    return cert;
                }
            }

            store.Close();
            throw new Exception("Không tìm thấy chứng chỉ phù hợp.");
        }

        [STAThread]
        private void ClientRecv()
        {
            byte[] buffer = new byte[BufferSize];
            MemoryStream currentFileStream = null;
            string currentFileName = null;

            try
            {
                while (!stopTcpClient && tcpClient.Connected)
                {
                    // Sử dụng sslStream thay vì networkStream
                    int bytesRead = sslStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) continue;

                    string headerAndMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] arrPayload = headerAndMessage.Split(';');

                    if (arrPayload.Length >= 3)
                    {
                        string senderUsername = arrPayload[0];
                        MessageType msgType = (MessageType)Enum.Parse(typeof(MessageType), arrPayload[1], true);
                        string content = arrPayload[2];

                        if (msgType == MessageType.Text)
                        {
                            UpdateChatHistoryThreadSafe($"{senderUsername}: {content}\n");
                        }
                        else if (msgType == MessageType.FilePart)
                        {
                            if (currentFileStream == null)
                            {
                                Invoke((Action)(() =>
                                {
                                    if (MessageBox.Show("Nhận file mới từ " + senderUsername + "?",
                                        "Nhận file", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        SaveFileDialog sfd = new SaveFileDialog();
                                        sfd.Filter = "All files (*.*)|*.*";
                                        if (sfd.ShowDialog() == DialogResult.OK)
                                        {
                                            currentFileName = sfd.FileName;
                                            currentFileStream = new MemoryStream();
                                        }
                                    }
                                }));
                            }

                            if (currentFileStream != null)
                            {
                                byte[] fileData = Convert.FromBase64String(content);
                                currentFileStream.Write(fileData, 0, fileData.Length);
                            }
                        }
                        else if (msgType == MessageType.FileEof)
                        {
                            if (currentFileStream != null && currentFileName != null)
                            {
                                if (content.Length > 0)
                                {
                                    byte[] finalData = Convert.FromBase64String(content);
                                    currentFileStream.Write(finalData, 0, finalData.Length);
                                }

                                currentFileStream.Position = 0;
                                using (FileStream fs = File.Create(currentFileName))
                                {
                                    currentFileStream.CopyTo(fs);
                                }

                                UpdateChatHistoryThreadSafe($"File đã được lưu tại: {currentFileName}\n");

                                currentFileStream.Dispose();
                                currentFileStream = null;
                                currentFileName = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nhận dữ liệu: {ex.Message}");
            }
        }

        private delegate void SafeCallDelegate(string text);

        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (rtb1.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                rtb1.Invoke(d, new object[] { text });
            }
            else
            {
                rtb1.Text += text;
            }
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                stopTcpClient = false;
                this.tcpClient = new TcpClient();
                this.tcpClient.Connect(new IPEndPoint(IPAddress.Parse(tb2.Text), serverPort));

                sslStream = new SslStream(tcpClient.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                sslStream.AuthenticateAsClient("MySslSocketCertificate", null, SslProtocols.Tls12, false);

                this.sWriter = new StreamWriter(sslStream) { AutoFlush = true };
                this.sWriter.WriteLine(this.tb1.Text);

                clientThread = new Thread(this.ClientRecv);
                clientThread.Start();

                MessageBox.Show("Connected to server");
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message, "Network error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true; // Không có lỗi, chứng chỉ hợp lệ
            }

            // Ghi log lỗi hoặc hiển thị thông báo để biết có vấn đề gì xảy ra
            MessageBox.Show($"SSL Certificate Error: {sslPolicyErrors}");
            return false; // Nếu có lỗi, từ chối kết nối
        }




        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sendMsgTextBox.Text))
                {
                    MessageBox.Show("Please enter a message before sending.");
                    return;
                }

                rtb1.Text += "You: " + sendMsgTextBox.Text + "\n";
                string allInOneMsg = $"{tb3.Text};{MessageType.Text};{sendMsgTextBox.Text}";
                byte[] sendingBytes = Encoding.UTF8.GetBytes(allInOneMsg);
                sslStream.Write(sendingBytes, 0, sendingBytes.Length);
                sslStream.Flush(); // Đảm bảo rằng dữ liệu đã được gửi
                sendMsgTextBox.Text = ""; // Xóa hộp văn bản sau khi gửi
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }

        
    }
}
