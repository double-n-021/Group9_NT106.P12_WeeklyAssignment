using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Data.SQLite; // Cần thư viện SQLite
using System.Security.Cryptography;

namespace Server
{
    public partial class Form_LAN : Form
    {
        private TcpListener server;
        private Thread listenerThread;
        private bool isRunning;
        private string dbPath = "DBSS.db"; // Đường dẫn file database
        public Form_LAN()
        {
            InitializeComponent();
        }

        private void Form_LAN_Load(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            var dap = new SQLiteDataAdapter("SELECT Username, Emailphone, Password FROM Users", connection);
            var table = new DataTable();
            dap.Fill(table);
            cbUserAccount.DataSource = table;
        }

        private void cbUserAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            var dap = new SQLiteDataAdapter("SELECT Username, Emailphone, Password FROM Users", connection);
            var table = new DataTable();
            dap.Fill(table);
            dataGridView1.DataSource = table;
        }


        private void StartServer()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, 5000); 
                server.Start();
                isRunning = true;
                while (isRunning)
                {
                    // Chấp nhận kết nối từ client
                    TcpClient client = server.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động server: " + ex.Message);
            }
        }

        private void StopServer()
        {
            try
            {
                isRunning = false;
                if (server != null)
                {
                    server.Stop();
                }
                if (listenerThread != null && listenerThread.IsAlive)
                {
                    listenerThread.Join(); // Dừng thread server
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dừng server: " + ex.Message);
            }
        }

        private void HandleClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
            {
                try
                {
                    string requestType = reader.ReadLine();
                    if (requestType == "signup")
                    {
                        string username = reader.ReadLine();
                        string password = reader.ReadLine();
                        string emailphone = reader.ReadLine();

                        bool registerSuccess = RegisterUser(username, password, emailphone);
                        writer.WriteLine(registerSuccess ? "Đăng ký thành công!" : "Đăng ký thất bại. Tài khoản đã tồn tại.");
                        if (registerSuccess == true) { UpdateDataGridView(); }
                    }
                }
                catch (IOException ex)
                {
                    // Xử lý lỗi IO, có thể là kết nối bị ngắt
                    MessageBox.Show($"Lỗi IO: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi tổng quát
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private bool RegisterUser(string username, string password, string emailphone)
        {

            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, Emailphone, Password) VALUES (@username, @emailphone, @password)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@emailphone", emailphone);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SQLiteException ex) { }
                    return false;
                }
            }
        }

        private void LoadUserData()
        {
            var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            var dap = new SQLiteDataAdapter("SELECT Username, Emailphone, Password FROM Users", connection);
            var table = new DataTable();
            dap.Fill(table); // Đổ dữ liệu vào table

            // Tạm thời lưu dữ liệu trong biến để cập nhật vào DataGridView thông qua UI thread
            Action updateAction = () =>
            {
                dataGridView1.DataSource = table;
                dataGridView1.Columns["Username"].HeaderText = "Username";
                dataGridView1.Columns["Emailphone"].HeaderText = "EmailPhone";
                dataGridView1.Columns["Password"].HeaderText = "Mật khẩu";
            };

            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(updateAction);
            }
            else
            {
                updateAction();
            }
        }


        private void UpdateDataGridView()
        {
            // Kiểm tra nếu cần gọi Invoke để cập nhật từ UI thread
            if (dataGridView1.InvokeRequired)
            {
                // Sử dụng Invoke để gọi lại từ UI thread
                dataGridView1.Invoke(new Action(UpdateDataGridView));
            }
            else
            {
                // Hàm cập nhật dữ liệu DataGridView
                LoadUserData();
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                // Khởi động server
                listenerThread = new Thread(StartServer);
                listenerThread.IsBackground = true;
                listenerThread.Start();
                isRunning = true;
                MessageBox.Show("Server đã khởi động.");
            }
            else
            {
                MessageBox.Show("Server đang chạy.");
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                // Dừng server
                StopServer();
                MessageBox.Show("Server đã dừng.");
            }
            else
            {
                MessageBox.Show("Server không hoạt động.");
            }
        }
    }
}
