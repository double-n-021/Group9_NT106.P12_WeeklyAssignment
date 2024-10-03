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
            try
            {
                while (!stopTcpClient && tcpClient.Connected)
                {
                    Application.DoEvents();
                    byte[] readBuffers = new byte[BufferSize];
                    while (networkStream.DataAvailable)
                    {
                        networkStream.Read(readBuffers, 0, BufferSize);
                    }
                    string headerAndMessage = Encoding.UTF8.GetString(readBuffers).Replace("\0", string.Empty); ;
                    string[] arrPayload = headerAndMessage.Split(';');
                    if (arrPayload.Length >= 3)
                    {
                        string senderUsername = arrPayload[0];
                        MessageType msgType = (MessageType)Enum.Parse(typeof(MessageType), arrPayload[1], true);
                        if (msgType == MessageType.Text)
                        {
                            string content = arrPayload[2].Replace("\0", string.Empty);
                            string formattedMsg = $"{senderUsername}: {content} \n";
                            UpdateChatHistoryThreadSafe(formattedMsg);
                        }
                        else if (msgType == MessageType.FilePart)
                        {

                            if (string.IsNullOrEmpty(SaveFileName))
                            {
                                string message = "Receive incoming file ";
                                string caption = "File sent request";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;
                                result = MessageBox.Show(message, caption, buttons);
                                if (result == DialogResult.Yes)
                                {
                                    SaveFileDialog DialogSave = new SaveFileDialog();
                                    DialogSave.Filter = "All files (*.*)|*.*";
                                    DialogSave.RestoreDirectory = true;
                                    DialogSave.Title = "Where do you want to save the file?";
                                    DialogSave.InitialDirectory = @"C:/";
                                    if (DialogSave.ShowDialog() == DialogResult.OK)
                                    {
                                        SaveFileName = DialogSave.FileName;
                                        fileSaveMemoryStream = new MemoryStream();
                                    }

                                }
                            }

                            byte[] filePart = Encoding.UTF8.GetBytes(arrPayload[2].Replace("\0", string.Empty));

                            fileSaveMemoryStream?.Write(filePart, 0, filePart.Length);
                        }
                        else if (msgType == MessageType.FileEof)
                        {
                            if (string.IsNullOrEmpty(SaveFileName))
                            {
                                string message = "Receive incoming file ";
                                string caption = "File sent request";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;
                                result = MessageBox.Show(message, caption, buttons);
                                if (result == DialogResult.Yes)
                                {
                                    SaveFileDialog DialogSave = new SaveFileDialog();
                                    DialogSave.Filter = "All files (*.*)|*.*";
                                    DialogSave.RestoreDirectory = true;
                                    DialogSave.Title = "Where do you want to save the file?";
                                    DialogSave.InitialDirectory = @"C:/";

                                    Invoke((Action)(() => {
                                        if (DialogSave.ShowDialog() == DialogResult.OK)
                                        {
                                            SaveFileName = DialogSave.FileName;
                                        }
                                    }));


                                }
                            }
                            byte[] finalFilePart = Encoding.UTF8.GetBytes(arrPayload[2].Replace("\0", string.Empty));

                            if (fileSaveMemoryStream != null)
                            {
                                fileSaveMemoryStream.Write(finalFilePart, 0, finalFilePart.Length);
                                using (FileStream fs = File.OpenWrite(SaveFileName))
                                {
                                    fileSaveMemoryStream.WriteTo(fs);
                                }
                            }
                            else
                            {
                                using (FileStream fs = File.OpenWrite(SaveFileName))
                                {
                                    fs.Write(finalFilePart, 0, finalFilePart.Length);
                                }

                            }

                            fileSaveMemoryStream = null;
                            SaveFileName = null;

                        }
                    }

                }
            }
            catch (SocketException sockEx)
            {
                tcpClient.Close();
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
                MessageBox.Show("Connected");
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
            string fileContent = string.Empty;
            string filePath = string.Empty;
            byte[] sendingBuffer = null;
            try
            {
                NetworkStream networkStream = tcpClient.GetStream();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] headerBytes = Encoding.UTF8.GetBytes($"{tb3.Text};{MessageType.FilePart};");
                        using (Stream fileStream = openFileDialog.OpenFile())
                        {
                            int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(fileStream.Length) / Convert.ToDouble(FileBufferSize)));
                            progressBar1.Maximum = NoOfPackets;
                            int TotalLength = (int)fileStream.Length, CurrentPacketLength, counter = 0;
                            for (int i = 0; i < NoOfPackets; i++)
                            {
                                if (TotalLength > FileBufferSize)
                                {
                                    CurrentPacketLength = FileBufferSize;
                                    TotalLength -= CurrentPacketLength;
                                }
                                else
                                {
                                    CurrentPacketLength = TotalLength;
                                    headerBytes = Encoding.UTF8.GetBytes($"{tb3.Text};{MessageType.FileEof};");
                                }

                                sendingBuffer = new byte[CurrentPacketLength];
                                fileStream.Read(sendingBuffer, 0, CurrentPacketLength);

                                byte[] sendingBytes = headerBytes.Concat(sendingBuffer).ToArray();
                                networkStream.Write(sendingBytes, 0, (int)sendingBytes.Length);
                                progressBar1.PerformStep();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
