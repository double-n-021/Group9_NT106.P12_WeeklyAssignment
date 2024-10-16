using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Authentication;


namespace ServerForm
{
    public partial class Form1 : Form
    {
        private Thread listenThread;
        private TcpListener tcpListener;
        private bool stopChatServer = true;
        private readonly int _serverPort = 8000;
        private Dictionary<string, SslStream> dict = new Dictionary<string, SslStream>();
        public const int BufferSize = 4096;
        private X509Certificate serverCertificate;

        public enum MessageType
        {
            Text,
            FileEof,
            FilePart,
        }

        public Form1()
        {
            InitializeComponent();
            serverCertificate = new X509Certificate2("C:\\MySslSocketCertificate.cer", ""); // Nếu không có password, để trống ""
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
                    Thread clientThread = new Thread(() => this.HandleClient(_client));
                    clientThread.Start();
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HandleClient(TcpClient _client)
        {
            SslStream sslStream = new SslStream(_client.GetStream(), false);

            try
            {
                sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired: false, SslProtocols.Tls12, checkCertificateRevocation: false);
                StreamReader sr = new StreamReader(sslStream);
                StreamWriter sw = new StreamWriter(sslStream);
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
                        dict.Add(username, sslStream);
                        Thread clientThread = new Thread(() => this.ClientRecv(username, sslStream));
                        clientThread.Start();
                    }
                    else
                    {
                        sw.WriteLine("Username already exists, pick another one");
                        _client.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SSL Error: {ex.Message}");
                _client.Close();
            }
        }

        public void ClientRecv(string username, SslStream sslStream)
        {
            byte[] buffer = new byte[BufferSize];

            try
            {
                while (!stopChatServer)
                {
                    if (!sslStream.CanRead) break;

                    int bytesRead = sslStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) continue;

                    string headerAndMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] arrPayload = headerAndMessage.Split(';');

                    if (arrPayload.Length >= 3)
                    {
                        string friendUsername = arrPayload[0];
                        MessageType msgType = (MessageType)Enum.Parse(typeof(MessageType), arrPayload[1], true);

                        if (dict.TryGetValue(friendUsername, out SslStream friendStream))
                        {
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
                sslStream.Close();
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
                MessageBox.Show("Start listening for incoming connections");
                btnListen.Text = "Stop";
            }
            else
            {
                stopChatServer = true;
                tcpListener.Stop();

                foreach (var sslStream in dict.Values)
                {
                    sslStream.Close();
                }

                dict.Clear();
                btnListen.Text = "Start listening";
            }
        }
    }
}
