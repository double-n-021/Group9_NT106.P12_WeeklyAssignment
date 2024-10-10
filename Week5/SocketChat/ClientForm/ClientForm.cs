using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class ClientForm : Form
    {
        private Socket clientSocket = null;
        private int _buff_size = 2048;
        private byte[] _buffer = new byte[2048];
        private delegate void SafeCallDelegate(string text);
        public ClientForm()
        {
            InitializeComponent();
            clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }


        public void onConnecting(IAsyncResult asyncResult)
        {
            
            Socket _client = (Socket)asyncResult.AsyncState;   

        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect(IPAddress.Parse(textBoxServerIP.Text), 11000);
                UpdateChatHistoryThreadSafe("Connected to server.");
                clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void SendFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileInfo.Name.PadRight(100, '\0')); // File name in 100 bytes
            byte[] fileSizeBytes = BitConverter.GetBytes((int)fileInfo.Length); // 4 bytes for file size
            byte[] fileHeader = Encoding.UTF8.GetBytes("FILE"); // FILE header

            byte[] header = new byte[fileHeader.Length + fileNameBytes.Length + fileSizeBytes.Length];
            Array.Copy(fileHeader, 0, header, 0, fileHeader.Length);
            Array.Copy(fileNameBytes, 0, header, fileHeader.Length, fileNameBytes.Length);
            Array.Copy(fileSizeBytes, 0, header, fileHeader.Length + fileNameBytes.Length, fileSizeBytes.Length);

            clientSocket.Send(header); // Send file header

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] fileBuffer = new byte[_buff_size];
                int bytesRead;

                while ((bytesRead = fs.Read(fileBuffer, 0, fileBuffer.Length)) > 0)
                {
                    clientSocket.Send(fileBuffer, 0, bytesRead, SocketFlags.None); // Use SocketFlags.None
                }
            }

            UpdateChatHistoryThreadSafe("File sent: " + fileInfo.Name);
        }

        private void OnReceive(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            int readBytes = client.EndReceive(ar);

            if (readBytes > 0)
            {
                string header = Encoding.UTF8.GetString(_buffer, 0, 4); // Read the first 4 bytes to determine the message type

                if (header == "TEXT")
                {
                    string message = Encoding.UTF8.GetString(_buffer, 4, readBytes - 4);
                    UpdateChatHistoryThreadSafe("Server: " + message);
                }
                else if (header == "FILE")
                {
                    ReceiveFile(readBytes);
                }
            }

            client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
        }

        private void ReceiveFile(int bytesRead)
        {
            string fileName = Encoding.UTF8.GetString(_buffer, 4, 100).TrimEnd('\0'); // Read file name (100 bytes)
            int fileSize = BitConverter.ToInt32(_buffer, 104); // Read file size (4 bytes)

            UpdateChatHistoryThreadSafe("Receiving file: " + fileName);

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                int totalBytesReceived = 0;
                while (totalBytesReceived < fileSize)
                {
                    int bytesReceived = clientSocket.Receive(_buffer, 0, Math.Min(_buffer.Length, fileSize - totalBytesReceived), SocketFlags.None);
                    fileStream.Write(_buffer, 0, bytesReceived);
                    totalBytesReceived += bytesReceived;
                }
            }

            UpdateChatHistoryThreadSafe("File received: " + fileName);
        }

        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (richTextBoxMessages.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                richTextBoxMessages.Invoke(d, new object[] { text });
            }
            else
            {
                richTextBoxMessages.AppendText(text + "\n");
            }
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (clientSocket.Connected)
            {
                string message = textBoxMessage.Text;
                byte[] messageBytes = Encoding.UTF8.GetBytes("TEXT" + message); // Prepend TEXT header
                clientSocket.Send(messageBytes);
                UpdateChatHistoryThreadSafe("You: " + message);
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {

            if (clientSocket.Connected)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    SendFile(filePath);
                }
            }
        }
    }
}
