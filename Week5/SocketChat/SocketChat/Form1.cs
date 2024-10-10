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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketChat
{
    public partial class Form1 : Form
    {
        private Socket serverSocket = null;
        private bool started = false;
        private int _port = 11000;
        private static int _buff_size = 2048;
        private byte[] _buffer = new byte[_buff_size];
        private Dictionary<Socket, string> connectedClients = new Dictionary<Socket, string>(); // Client sockets and their names
        private delegate void SafeCallDelegate(string text);

        public Form1()
        {
            InitializeComponent();
            serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }


        private void listen()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(textBox1.Text), _port));
            serverSocket.Listen(10);
            started = true;
            UpdateChatHistoryThreadSafe("Server started, listening on port " + _port);
            serverSocket.BeginAccept(new AsyncCallback(onAccepting), serverSocket);
        }

        public void onAccepting(IAsyncResult ar)
        {
            Socket serverSocket = (Socket)ar.AsyncState;
            Socket clientSocket = serverSocket.EndAccept(ar);

            connectedClients.Add(clientSocket, clientSocket.RemoteEndPoint.ToString()); // Add new client

            UpdateChatHistoryThreadSafe("Accepted connection from " + clientSocket.RemoteEndPoint.ToString());
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(onReceive), clientSocket);
            serverSocket.BeginAccept(new AsyncCallback(onAccepting), serverSocket); // Continue accepting new clients
        }

        public void onReceive(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            int readbytes = clientSocket.EndReceive(ar);

            if (readbytes > 0)
            {
                string header = Encoding.UTF8.GetString(_buffer, 0, 4); // Read the first 4 bytes to determine the message type

                if (header == "TEXT")
                {
                    string message = Encoding.UTF8.GetString(_buffer, 4, readbytes - 4);
                    UpdateChatHistoryThreadSafe("Client: " + message);
                }
                else if (header == "FILE")
                {
                    ReceiveFile(clientSocket, readbytes);
                }
            }
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(onReceive), clientSocket);
        }
        private void ReceiveFile(Socket clientSocket, int bytesRead)
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
        private void BroadcastMessage(Socket fromClient, string message)
        {
            foreach (var client in connectedClients)
            {
                if (client.Key != fromClient) // Skip the sender
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    client.Key.Send(data);
                }
            }
        }


        void readFromSocket(Socket clientSocket)
        {
            while (started && clientSocket != null)
            {
                int readbytes = clientSocket.Receive(_buffer);
                string s = Encoding.UTF8.GetString(_buffer);
                UpdateChatHistoryThreadSafe(s + "\n");
            }
        }
        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (richTextBoxChat.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                richTextBoxChat.Invoke(d, new object[] { text });
            }
            else
            {
                richTextBoxChat.AppendText(text + "\n");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                if (started)
                {
                    started = false;
                    btnListen.Text = "Listen on port 11000";
                    serverSocket.Close();
                }
                else
                {
                    btnListen.Text = "Listening on port 11000";
                    listen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
