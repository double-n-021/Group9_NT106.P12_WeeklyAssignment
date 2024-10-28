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
using Azure.Core;
using System.Runtime.InteropServices.ComTypes;

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
            cbUserandAdd.SelectedIndex = 0;
        }

        private void cbUserAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbUserandAdd.SelectedItem.ToString();
            string query = "";

            // Kiểm tra lựa chọn và xác định truy vấn SQL tương ứng
            if (selected == "User Accounts")
            {
                btAdd.Visible = false;
                gbAdd.Visible = false;
                query = "SELECT Username, Emailphone, Password, Avatar FROM Users"; // Truy vấn từ bảng Account
            }
            else if (selected == "Movies and Musics")
            {
                btAdd.Visible = true;
                gbAdd.Visible = true;
                query = "SELECT ID, Title, Description, Tag FROM MoviesNMusics"; // Truy vấn từ bảng MoviesNMusics
            }

            // Thực hiện truy vấn SQL và đổ dữ liệu vào DataGridView
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    connection.Open();
                    SQLiteDataAdapter dap = new SQLiteDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    dap.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                try
                {
                    string requestType = reader.ReadString(); // Đọc loại yêu cầu ("login",....v.v)

                    if (requestType == "signup")
                    {
                        string username = reader.ReadString();
                        string password = reader.ReadString();
                        string emailphone = reader.ReadString();

                        bool registerSuccess = RegisterUser(username, password, emailphone);
                        writer.Write(registerSuccess ? "Đăng ký thành công!" : "Đăng ký thất bại. Tài khoản đã tồn tại.");
                        if (registerSuccess) { LoadUserData(); }
                    }
                    else if (requestType == "login")
                    {
                        string username = reader.ReadString();
                        string password = reader.ReadString();

                        bool loginSuccess = CheckUserLogin(username, password);
                        writer.Write(loginSuccess ? "Đăng nhập thành công!" : "Tên tài khoản hoặc mật khẩu không đúng.");
                    }
                    else if (requestType == "changeusername")
                    {
                        string newusername = reader.ReadString();
                        string oldusername = reader.ReadString();

                        bool changeUsernameSuccess = ChangeUsername(newusername, oldusername);
                        writer.Write(changeUsernameSuccess ? "Đổi tên thành công!" : "Đổi tên thất bại.");
                        if (changeUsernameSuccess) { LoadUserData(); }
                    }
                    else if (requestType == "changepassword")
                    {
                        string username = reader.ReadString();
                        string password = reader.ReadString();

                        bool changePasswordSuccess = ChangePassword(username, password);
                        writer.Write(changePasswordSuccess ? "Đổi mật khẩu thành công!" : "Đổi mật khẩu thất bại.");
                        if (changePasswordSuccess) { LoadUserData(); }
                    }
                    else if (requestType == "changeavatar")
                    {
                        string username = reader.ReadString(); // Đọc tên người dùng
                        int imageSize = reader.ReadInt32();     // Đọc kích thước ảnh
                        byte[] imageData = reader.ReadBytes(imageSize); // Đọc dữ liệu ảnh

                        bool changeAvatarSuccess = UpdateAvatar(username, imageData);
                        writer.Write(changeAvatarSuccess ? "Cập nhật ảnh đại diện thành công!" : "Đổi ảnh đại diện thất bại.");
                    }
                    else if (requestType == "getavatar")
                    {
                        string username = reader.ReadString();
                        byte[] sendAvatar = GetAvatarFromDB(username);
                        if (sendAvatar == null)
                            writer.Write("Không có dữ liệu ảnh");

                        else
                        {
                            writer.Write("Có dữ liệu ảnh");
                            writer.Write(sendAvatar.Length);
                            writer.Write(sendAvatar);
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi IO: {ex.Message}");
                }
                catch (Exception ex)
                {
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
        private bool CheckUserLogin(string username, string password)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();
                string query = "SELECT Password FROM Users WHERE Username = @username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string storedHash = result.ToString();

                        // So sánh mật khẩu người dùng nhập với mật khẩu đã lưu
                        if (storedHash == password) // Ở đây bạn có thể thay đổi logic so sánh nếu cần
                        {
                            return true; // Đăng nhập thành công
                        }
                    }
                }
            }
            return false; // Đăng nhập thất bại
        }

        private bool ChangePassword(string username, string password)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                // Câu truy vấn SQL để cập nhật mật khẩu người dùng
                string query = "UPDATE Users SET Password = @password WHERE Username = @username";

                using (var command = new SQLiteCommand(query, connection))
                {
                    // Thêm tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SQLiteException ex)
                    {
                        return false;
                    }
                }
            }
        }

        private bool ChangeUsername(string newusername, string oldusername)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();

                // Câu truy vấn SQL để cập nhật tên người dùng
                string query = "UPDATE Users SET Username = @newusername WHERE Username = @oldusername";

                using (var command = new SQLiteCommand(query, connection))
                {
                    // Thêm tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@newusername", newusername);
                    command.Parameters.AddWithValue("@oldusername", oldusername);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SQLiteException ex)
                    {
                        return false;
                    }
                }
            }
        }

        private bool UpdateAvatar(string username, byte[] imageData)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();
                    string query = "UPDATE Users SET Avatar = @avatar WHERE Username = @username";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@avatar", imageData);
                        command.Parameters.AddWithValue("@username", username);

                        int rowsAffected = command.ExecuteNonQuery();
                        LoadUserData();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Truy vấn ảnh đại diện từ DB
        private byte[] GetAvatarFromDB(string username)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();
                string query = "SELECT Avatar FROM Users WHERE Username = @username";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    object result = command.ExecuteScalar();
                    int rowsAffected = command.ExecuteNonQuery();
                    // Kiểm tra kết quả và chuyển đổi sang mảng byte
                    if (result != DBNull.Value && result != null)
                    {
                        return (byte[])result;
                    }
                }
            }
            return null;
        }


        private void LoadUserData()
        {
            var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            var dap = new SQLiteDataAdapter("SELECT Username, Emailphone, Password, Avatar FROM Users", connection);
            var table = new DataTable();
            dap.Fill(table); // Đổ dữ liệu vào table

            // Tạm thời lưu dữ liệu trong biến để cập nhật vào DataGridView thông qua UI thread
            Action updateAction = () =>
            {
                dataGridView1.DataSource = table;
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

        byte[] posterBytes;
        private void btPoster_Click(object sender, EventArgs e)
        {
            OFD.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
            DialogResult ofd = OFD.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                try
                {
                    // Chuyển đổi ảnh thành mảng byte
                    using (FileStream fs = new FileStream(OFD.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            posterBytes = br.ReadBytes((int)fs.Length);
                        }
                    }
                    MessageBox.Show("Đã upload poster thành công");
                }
                catch (Exception ex) { }

            }
        }

        byte[] fileBytes;
        private void btUploadFile_Click(object sender, EventArgs e)
        {
            OFD.Filter = "Media Files (*.mp3;*.mp4;*.wav)|*.mp3;*.mp4;*.wav";
            DialogResult ofd = OFD.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                try
                {
                    // Chuyển đổi ảnh thành mảng byte
                    using (FileStream fs = new FileStream(OFD.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            fileBytes = br.ReadBytes((int)fs.Length);
                        }
                    }
                    MessageBox.Show("Đã upload file đính kèm thành công");
                }
                catch (Exception ex) { }
            }
        }

        string tagname = "";
        private void cbTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbTag.SelectedItem.ToString();
            if (selected == "Movie")
                tagname = "Movie";
            else if (selected == "Music")
                tagname = "Music";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text) || string.IsNullOrEmpty(tbDescription.Text) || string.IsNullOrEmpty(tagname) || posterBytes == null || fileBytes == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của file cần thêm");
                return;
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();
                    string query = "INSERT INTO MoviesNMusics (Title, Description, Tag, Poster, FileData) VALUES (@Title, @Description, @Tag, @Poster, @FileData)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", tbTitle.Text);
                        command.Parameters.AddWithValue("@Description", tbDescription.Text);
                        command.Parameters.AddWithValue("@Tag", tagname);
                        command.Parameters.AddWithValue("@Poster", posterBytes);
                        command.Parameters.AddWithValue("@FileData", fileBytes);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã thêm thành công!");
                LoadFileData();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message); }
        }

        private void LoadFileData()
        {
            var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            var dap = new SQLiteDataAdapter("SELECT ID, Title, Description, Tag FROM MoviesNMusics", connection);
            var table = new DataTable();
            dap.Fill(table); // Đổ dữ liệu vào table
            Action updateAction = () =>
            {
                dataGridView1.DataSource = table;
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
    }
}
