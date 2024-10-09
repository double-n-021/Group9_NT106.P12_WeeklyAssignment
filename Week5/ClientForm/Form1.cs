using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Xml.Linq;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        private Socket _clientSocket;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = "text:" + txtUsername.Text + ": " + tb1.Text;
            SendMessage(message);
        }

        private void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            _clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), _clientSocket);
        }

        private void SendCallback(IAsyncResult ar)
        {
            _clientSocket.EndSend(ar);
            
            // Sử dụng Invoke để chạy trên UI thread
            Invoke((Action)delegate
            {
                AppendMessage("Bạn: " + tb1.Text);
                tb1.Clear();
            });
        }


        private void ReceiveCallback(IAsyncResult ar)
        {
            byte[] buffer = (byte[])ar.AsyncState;
            int receivedBytes = _clientSocket.EndReceive(ar);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

            if (receivedMessage.StartsWith("text:"))
            {
                AppendMessage(receivedMessage.Substring(5));
            }
            else if (receivedMessage.StartsWith("file:"))
            {
                SaveFile(receivedMessage.Substring(5));
                AppendMessage("File đã nhận.");
            }

            byte[] newBuffer = new byte[1024];
            _clientSocket.BeginReceive(newBuffer, 0, newBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), newBuffer);
        }

        private static string ServerCertificateName =
            "MySslSocketCertificate";

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _clientSocket.BeginConnect(txtServerIp.Text, 5000, new AsyncCallback(ConnectCallback), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối tới server: " + ex.Message);
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            _clientSocket.EndConnect(ar);
            AppendMessage("Đã kết nối tới server!");

            byte[] buffer = new byte[1024];
            _clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), buffer);
        }


        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                fileBytes = File.ReadAllBytes(filePath); // Đọc file vào biến fileBytes

                if (fileBytes == null || fileBytes.Length == 0)
                {
                    MessageBox.Show("Lỗi: Không thể đọc file.");
                    return;
                }

                // Gửi file với tên file
                SendFile("file:" + Path.GetFileName(filePath) + ":" + Convert.ToBase64String(fileBytes), fileBytes.Length);
            }
        }

        private byte[] fileBytes;

        private void SendFile(string message, int fileSize)
        {
            // Khởi động ProgressBar
            progressBar.Minimum = 0;
            progressBar.Maximum = fileSize;
            progressBar.Value = 0;

            // Chia file thành các phần nhỏ hơn để gửi
            int chunkSize = 1024; // Kích thước của mỗi chunk (1 KB)
            int offset = 0;

            // Gửi mỗi chunk
            SendFileChunk(message, offset, chunkSize, fileSize);
        }

        private void SendFileChunk(string message, int offset, int chunkSize, int fileSize)
        {
            if (offset < fileSize)
            {
                int size = Math.Min(chunkSize, fileSize - offset);
                byte[] chunk = new byte[size];
                Array.Copy(fileBytes, offset, chunk, 0, size);

                // Gửi chunk
                _clientSocket.BeginSend(chunk, 0, size, SocketFlags.None, new AsyncCallback(SendFileChunkCallback), new { offset = offset + size, fileSize });
            }
        }

        private void SendFileChunkCallback(IAsyncResult ar)
        {
            var state = (dynamic)ar.AsyncState;
            int offset = state.offset;
            int fileSize = state.fileSize;

            _clientSocket.EndSend(ar);

            // Cập nhật ProgressBar trên UI thread
            Invoke((Action)delegate
            {
                progressBar.Value = offset; // Cập nhật giá trị
            });

            // Gửi chunk tiếp theo
            SendFileChunk("file:", offset, 1024, fileSize);
        }


        private void SaveFile(string fileBase64)
        {
            byte[] fileBytes = Convert.FromBase64String(fileBase64);
            File.WriteAllBytes("received_file.dat", fileBytes);
        }

        private void AppendMessage(string message)
        {
            Invoke((Action)delegate
            {
                rtbMessages.AppendText(message + Environment.NewLine);
            });
        }
    }
}
