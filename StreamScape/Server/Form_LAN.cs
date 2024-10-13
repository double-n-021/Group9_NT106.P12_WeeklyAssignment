using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form_LAN : Form
    {
        private Socket serverSocket = null;
        private bool started = false;
        private int _port = 11000;
        private static int _buff_size = 2048;
        private byte[] _buffer = new byte[_buff_size];
        private Dictionary<Socket, string> connectedClients = new Dictionary<Socket, string>(); // Client sockets and their names
        private delegate void SafeCallDelegate(string text);

        public Form_LAN()
        {
            InitializeComponent();
            serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            this.Load += new EventHandler(Form_LAN_Load);

        }

        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (textBoxMessage.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                textBoxMessage.Invoke(d, new object[] { text });
            }
            else
            {
                textBoxMessage.AppendText(text + "\n");
            }
        }
        private void Form_LAN_Load(object sender, EventArgs e)
        {
            try
            {
                // Tự động bắt đầu lắng nghe khi form được tải
                listen();
                btStart.Text = "Listening on port " + _port;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void listen()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(textBox2.Text), _port));
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
                string header = Encoding.UTF8.GetString(_buffer, 0, 4); // Đọc tiền tố 4 byte

                if (header == "TEXT")
                {
                    string message = Encoding.UTF8.GetString(_buffer, 4, readbytes - 4);

                    UpdateChatHistoryThreadSafe("Client: " + message);


                }
                clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(onReceive), clientSocket);
            }

        }

        //Check thông tin từ database, tạm thời chưa dùng tới
        private bool ValidateLogin(string username, string password)
        {
            string connectionString = "Data Source=server_name;Initial Catalog=database_name;User ID=db_user;Password=db_password;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0; // Trả về true nếu tìm thấy người dùng
                }
            }
        }
    }
}
