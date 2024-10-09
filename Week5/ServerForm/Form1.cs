using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ServerForm
{
    public partial class Form1 : Form
    {
        private Socket _serverSocket;
        private Socket _clientSocket;

        public Form1()
        {
            InitializeComponent();
        }

        // Khi nhấn nút "Listen", bắt đầu lắng nghe kết nối
        private void btnListen_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void StartServer()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(txtIpAddrress.Text); // Lấy địa chỉ IP từ TextBox
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(ipAddress, 5000)); // Lắng nghe tại cổng 5000
                _serverSocket.Listen(1);

                AppendMessage("Server đang lắng nghe tại " + txtIpAddrress.Text);
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động server: " + ex.Message);
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            _clientSocket = _serverSocket.EndAccept(ar);
            AppendMessage("Client đã kết nối!");

            byte[] buffer = new byte[1024];
            _clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), buffer);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            byte[] buffer = (byte[])ar.AsyncState;
            int receivedBytes = _clientSocket.EndReceive(ar);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, receivedBytes);

            if (receivedMessage.StartsWith("text:"))
            {
                // Xử lý tin nhắn văn bản
                string messageContent = receivedMessage.Substring(5); // Bỏ qua "text:"
                AppendMessage(messageContent); // Hiển thị tin nhắn trên Server
            }
            else if (receivedMessage.StartsWith("file:"))
            {
                // Xử lý file
                string[] parts = receivedMessage.Substring(5).Split(':');
                if (parts.Length == 2)
                {
                    string fileName = parts[0]; // Tên file
                    string fileData = parts[1]; // Dữ liệu file
                    SaveFile(fileName, fileData); // Lưu file
                    AppendMessage("File đã nhận: " + fileName); // Hiển thị thông báo file đã nhận
                }
            }

            // Tiếp tục lắng nghe tin nhắn tiếp theo
            byte[] newBuffer = new byte[1024];
            _clientSocket.BeginReceive(newBuffer, 0, newBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), newBuffer);
        }

        private void SaveFile(string fileName, string fileBase64)
        {
            string directoryPath = "ReceivedFiles";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath); // Tạo thư mục nếu không tồn tại
            }

            byte[] fileBytes = Convert.FromBase64String(fileBase64);
            File.WriteAllBytes(Path.Combine(directoryPath, fileName), fileBytes); // Lưu file vào thư mục ReceivedFiles
        }


        private void AppendMessage(string message)
        {
            Invoke((Action)delegate
            {
                rtbMessages.AppendText(message + Environment.NewLine);
                Console.WriteLine(message); // Ghi log vào Console để kiểm tra
            });
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem != null)
            {
                string fileName = listBoxFiles.SelectedItem.ToString();
                string sourcePath = Path.Combine("ReceivedFiles", fileName);

                if (File.Exists(sourcePath))
                {
                    // Tải file về (mở file để tải về hoặc thực hiện hành động khác)
                    System.Diagnostics.Process.Start(sourcePath); // Mở file với ứng dụng mặc định
                }
                else
                {
                    MessageBox.Show("File không tồn tại.");
                }
            }
        }
    }
}
