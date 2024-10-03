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

namespace ServerForm
{
    public partial class Form1 : Form
    {
        private Thread listenThread;
        private TcpListener tcpListener;
        private bool stopChatServer = true;
        private readonly int _serverPort = 8000;
        private Dictionary<string, TcpClient> dict = new Dictionary<string, TcpClient>();
        public const int BufferSize = 4096;

        public enum MessageType
        {
            Text,
            FileEof,
            FilePart,
        }
        public Form1()
        {
            InitializeComponent();
        }

        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(new IPEndPoint(IPAddress.Parse(tb1.Text), _serverPort));
                tcpListener.Start();
                stopChatServer = false;

                while (!stopChatServer)
                {
                    TcpClient _client = tcpListener.AcceptTcpClient();

                    StreamReader sr = new StreamReader(_client.GetStream());
                    StreamWriter sw = new StreamWriter(_client.GetStream());
                    sw.AutoFlush = true;

                    string username = sr.ReadLine();
                    if (string.IsNullOrEmpty(username))
                    {
                        sw.WriteLine("Please pick a username");
                        _client.Close();
                    }
                    else
                    {
                        if (!dict.ContainsKey(username))
                        {
                            dict.Add(username, _client);
                            Thread clientThread = new Thread(() => this.ClientRecv(username, _client));
                            clientThread.Start();
                        }
                        else
                        {
                            sw.WriteLine("Username already exist, pick another one");
                            _client.Close();
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClientRecv(string username, TcpClient tcpClient)
        {
            NetworkStream thisUserNetworkStream = tcpClient.GetStream();
            byte[] buffer = new byte[BufferSize];

            try
            {
                while (!stopChatServer)
                {
                    if (!tcpClient.Connected) break;

                    int bytesRead = thisUserNetworkStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) continue;

                    string headerAndMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] arrPayload = headerAndMessage.Split(';');

                    if (arrPayload.Length >= 3)
                    {
                        string friendUsername = arrPayload[0];
                        MessageType msgType = (MessageType)Enum.Parse(typeof(MessageType), arrPayload[1], true);

                        if (dict.TryGetValue(friendUsername, out TcpClient friendTcpClient))
                        {
                            NetworkStream friendStream = friendTcpClient.GetStream();

                            if (msgType == MessageType.Text)
                            {
                                string content = arrPayload[2];
                                string forwardMessage = $"{username};{MessageType.Text};{content}";
                                byte[] forwardBytes = Encoding.UTF8.GetBytes(forwardMessage);
                                friendStream.Write(forwardBytes, 0, forwardBytes.Length);

                                UpdateChatHistoryThreadSafe($"{username} to {friendUsername}: {content}\n");
                            }
                            else if (msgType == MessageType.FilePart || msgType == MessageType.FileEof)
                            {
                                string forwardMessage = $"{username};{msgType};{arrPayload[2]}";
                                byte[] forwardBytes = Encoding.UTF8.GetBytes(forwardMessage);
                                friendStream.Write(forwardBytes, 0, forwardBytes.Length);
                                friendStream.Flush();

                                if (msgType == MessageType.FileEof)
                                {
                                    UpdateChatHistoryThreadSafe($"{username} sent a file to {friendUsername}\n");
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error in ClientRecv: {ex.Message}");
                if (dict.ContainsKey(username))
                {
                    dict.Remove(username);
                }
                tcpClient.Close();
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
                rtb1.Text += text + "\n";
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (stopChatServer)
            {
                stopChatServer = false;
                listenThread = new Thread(this.Listen);
                listenThread.Start();
                MessageBox.Show(@"Start listening for incoming connections");
                btnListen.Text = @"Stop";
            }
            else
            {
                stopChatServer = true;
                btnListen.Text = @"Start listening";
                tcpListener.Stop();
                listenThread = null;
            }
        }
    }
}
