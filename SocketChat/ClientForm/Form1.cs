using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        [STAThread]
        private void ClientRecv()
        {
            NetworkStream networkStream = tcpClient.GetStream();
            byte[] buffer = new byte[BufferSize];
            MemoryStream currentFileStream = null;
            string currentFileName = null;

            try
            {
                while (!stopTcpClient && tcpClient.Connected)
                {
                    int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
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

        private delegate void SaveFileConfirmDialogDelegate(DialogResult result);

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
                this.sWriter = new StreamWriter(tcpClient.GetStream())
                {
                    AutoFlush = true
                };

                sWriter.WriteLine(this.tb1.Text);

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


        private void btnSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "All files (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        NetworkStream ns = tcpClient.GetStream();
                        string receiverUsername = tb3.Text;

                        using (FileStream fs = File.OpenRead(ofd.FileName))
                        {
                            byte[] buffer = new byte[FileBufferSize];
                            int bytesRead;

                            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                byte[] actualData = new byte[bytesRead];
                                Array.Copy(buffer, actualData, bytesRead);

                                string base64Data = Convert.ToBase64String(actualData);
                                string message = $"{receiverUsername};{MessageType.FilePart};{base64Data}";

                                byte[] sendBuffer = Encoding.UTF8.GetBytes(message);
                                ns.Write(sendBuffer, 0, sendBuffer.Length);
                                ns.Flush();

                                Thread.Sleep(10);
                            }

                            string eofMessage = $"{receiverUsername};{MessageType.FileEof};";
                            byte[] eofBuffer = Encoding.UTF8.GetBytes(eofMessage);
                            ns.Write(eofBuffer, 0, eofBuffer.Length);
                            ns.Flush();
                        }

                        UpdateChatHistoryThreadSafe($"Đã gửi file: {Path.GetFileName(ofd.FileName)}\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi file: {ex.Message}");
            }
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkStream ns = tcpClient.GetStream();
                string allInOneMsg = $"{tb3.Text};{MessageType.Text.ToString()};{sendMsgTextBox.Text}";
                byte[] sendingBytes = Encoding.UTF8.GetBytes(allInOneMsg);
                ns.Write(sendingBytes, 0, sendingBytes.Length);
                sendMsgTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
