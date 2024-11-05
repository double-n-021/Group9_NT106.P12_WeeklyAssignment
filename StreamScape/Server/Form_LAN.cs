using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.IO.Compression;

namespace Server
{
    public partial class Form_LAN : Form
    {
        private TcpListener server;
        private string dbPath = "DBSS.db"; // Đường dẫn file database
        
        private List<Room> roomList = new List<Room>();
        private List<User> userList = new List<User>();
        private Manager ManagerOBJ;

        public Form_LAN()
        {
            InitializeComponent();
            ManagerOBJ = new Manager(listView_log, tbAvailableRoom, tbExistingUser);//khởi tạo để cập nhật thông tin phía SV
        }

        private void Form_LAN_Load(object sender, EventArgs e)
        {
            cbUserandAdd.SelectedIndex = 0;
        }

        #region Đổ dữ liệu User Accounts và Movies N Musics từ DB vào Datagridview và cập nhật DG khi có thay đổi
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
                query = "SELECT ID, Title, Description, Tag, Poster FROM MoviesNMusics"; // Truy vấn từ bảng MoviesNMusics
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

        //User Accounts
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

        //MoviesNMusics
        private void LoadFileData()
        {
            var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            var dap = new SQLiteDataAdapter("SELECT ID, Title, Description, Tag, Poster FROM MoviesNMusics", connection);
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
        #endregion

        #region Chức năng Start(), Stop() và Listen() của SV
        private void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                server = new TcpListener(IPAddress.Any, 5000);
                server.Start();

                Thread clientListener = new Thread(Listen);
                clientListener.IsBackground = true;
                clientListener.Start();

                ManagerOBJ.WriteToLog("Start listening for incoming requests...");

                btStart.Enabled = false;
                btStop.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động server: " + ex.Message);
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerOBJ.WriteToLog("Stop listening for incoming requests");
                foreach (User user in userList)
                {
                    user.Client.Close();
                }
                server.Stop();

                btStop.Enabled = false;
                btStart.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi dừng server: " + ex.Message);
            }
        }

        private void Listen()
        {
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            }
            catch
            {
                server = new TcpListener(IPAddress.Any, 5000);
                server.Start();
            }
        }
        #endregion

        string tag = ""; //biến này có liên quan đến form home

        #region Đọc request của client và response Send Specific
        private void HandleClient(object obj)
        {
            TcpClient client = obj as TcpClient;
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
                    else if (requestType == "getdata")
                    {
                        List<MovieNMusic> movieandmusic = GetMoviesNMusicsFromDB();
                        byte[] data = SerializeMovieNMusic(movieandmusic);
                        stream.Write(data, 0, data.Length);
                    }
                    else if (requestType == "getfile")
                    {
                        string titleofFile = reader.ReadString();
                        byte[] sendFile = GetFileFromDB(titleofFile);
                        if (sendFile != null)
                        {
                            if (tag == "Movie")
                                writer.Write(".mp3");
                            else
                                writer.Write(".mp4");
                            writer.Write(sendFile.Length);
                            writer.Write(sendFile);
                        }
                        else
                        {
                            writer.Write(0); // Nếu không tìm thấy tệp, gửi độ dài là 0
                        }
                    }
                    else if (requestType == "onlineroom")
                    {
                        User user = new User(client);
                        userList.Add(user);

                        try
                        {
                            string requestInJson = string.Empty; //Tạo chuỗi requestInJson là kí tự trống
                            while (true)
                            {
                                requestInJson = user.Reader.ReadString();

                                Packet request = JsonConvert.DeserializeObject<Packet>(requestInJson);

                                switch (request.Code)
                                {
                                    case 0:
                                        generate_room_handler(user, request);
                                        break;
                                    case 1:
                                        join_room_handler(user, request);
                                        break;
                                    case 2:
                                        send_message_handler(user, request);
                                        break;
                                    case 3:
                                        send_icon_handler(user, request);
                                        break;
                                    case 4:
                                        send_video_handler(user, request);
                                        break;
                                    case 5:
                                        stop_video_handler(user, request);
                                        break;
                                    case 6:
                                        continue_video_handler(user, request);
                                        break;
                                    case 7:
                                        rewind_video_handler(user, request);
                                        break;
                                    case 8:
                                        next_video_handler(user, request);
                                        break;
                                    case 9:
                                        send_file_handler(user, request);
                                        break;
                                }
                            }
                        }
                        catch
                        {
                            close_client(user);
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

        private void sendSpecific(User user, Object message)
        {
            if (user.Client.Connected)
            {
                string messageInJson = JsonConvert.SerializeObject(message);
                try
                {
                    user.Writer.Write(messageInJson);
                    user.Writer.Flush();
                }
                catch (Exception ex)
                {
                    ManagerOBJ.ShowError($"Cannot send data to user: {user.Username}\nError: {ex.Message}");
                }
            }
            else
            {
                ManagerOBJ.ShowError("Connection is closed.");
            }
        }
        #endregion

        //Của Form_Onlineroom
        #region Đóng kết nối của client
        private void close_client(User user)
        {
            Room requestingRoom = new Room();

            // xoá client khỏi cách list client và close client
            foreach (Room room in roomList)
            {
                if (room.userList.Contains(user))
                {
                    requestingRoom = room;
                    room.userList.Remove(user);
                    break;
                }
            }
            userList.Remove(user);
            user.Client.Close();

            if (user.Username != string.Empty)
            {
                ManagerOBJ.WriteToLog(user.Username + " disconnected.");
            }

            // gửi thông báo về client vừa ngắt kết nối đến client khác trong phòng
            Packet message = new Packet()
            {
                Code = 1,
                Username = "!" + user.Username,
                Avatar = user.Avatar
            };

            if (requestingRoom.userList.Count == 0)
            {
                if (roomList.Contains(requestingRoom))
                {
                    roomList.Remove(requestingRoom);
                    ManagerOBJ.WriteToLog("Deleted room: " + requestingRoom.roomID + " - No user here.");
                }
            }
            else
            {
                foreach (User _user in requestingRoom.userList)
                {
                    sendSpecific(_user, message);
                }
            }
            ManagerOBJ.UpdateRoomCount(roomList.Count);
            ManagerOBJ.UpdateUserCount(userList.Count);
        }
        #endregion

        #region Xử lý tính năng chat
        private void send_icon_handler(User user, Packet request)
        {
            // Tìm phòng mà user đang tham gia
            Room userRoom = roomList.FirstOrDefault(r => r.roomID == int.Parse(request.RoomID));
            if (userRoom == null) return;

            // Chuẩn bị gói tin chứa icon để gửi cho các user trong phòng
            Packet iconPacket = new Packet
            {
                Code = 3, // Mã dành riêng cho icon (giả sử Code 3 là code dành cho icon)
                Username = user.Username,
                Icon = request.Icon // IconData chứa dữ liệu icon (có thể là đường dẫn hoặc mã byte)
            };

            // Gửi icon tới tất cả các người dùng trong phòng
            foreach (User roomUser in userRoom.userList)
            {
                if (roomUser != user) // Không gửi lại cho chính người gửi
                {
                    sendSpecific(roomUser, iconPacket);
                }
            }

            ManagerOBJ.WriteToLog($"Room {userRoom.roomID}: {user.Username} sent an icon.");
        }

        private void send_message_handler(User user, Packet request)
        {
            // Find the room that the user is in
            Room userRoom = roomList.FirstOrDefault(r => r.roomID == int.Parse(request.RoomID));
            if (userRoom == null) return;

            // Prepare the message packet to be sent to all users in the room
            Packet messagePacket = new Packet
            {
                Code = 2, // Code for a chat message
                Username = user.Username,
                Message = request.Message // Assuming `Message` property holds the text content
            };

            // Send the message to each user in the room
            foreach (User roomUser in userRoom.userList)
            {
                if (roomUser != user) // Bỏ qua người gửi
                {
                    sendSpecific(roomUser, messagePacket);
                }
            }

            ManagerOBJ.WriteToLog($"Room {userRoom.roomID}: {user.Username} sent a message.");
        }
        #endregion

        #region Của host
        private void generate_room_handler(User user, Packet request)
        {
            user.Username = request.Username;
            user.isHost = 1;
            user.Avatar = request.Avatar;

            //Tạo ID phòng ngẫu nhiên trong khoảng [1000,9999]
            Random r = new Random();
            int roomID = r.Next(1000, 9999);
            Room newRoom = new Room(); //Tạo phòng mới thuộc lớp Room
            newRoom.roomID = roomID; //Gán ID ngẫu nhiên vừa tạo cho thuộc tính roomID của đối tượng newRoom 

            newRoom.roomName = request.RoomName;

            newRoom.userList.Add(user); //Thêm user vào thuộc tính userList có kiểu List
            roomList.Add(newRoom); //Thêm đối tượng newRoom vào List roomList

            //Hiển thị ở listview của Form_LAN thông báo phòng mới vừa được tạo kèm với ID của phòng đó
            ManagerOBJ.WriteToLog(user.Username + " created new room. Room code: " + newRoom.roomID);

            //Cập nhật số phòng hiện tại
            ManagerOBJ.UpdateRoomCount(roomList.Count);

            //Cập nhật số user đang tham gia ở chế độ phòng online
            ManagerOBJ.UpdateUserCount(userList.Count);

            Packet message = new Packet
            {
                Code = 0,
                Username = request.Username,
                Avatar = request.Avatar,
                RoomID = roomID.ToString(),
                isHost = 1
            };

            sendSpecific(user, message);
        }
        #endregion

        #region Xử lý khi host chọn file từ công cụ tìm kiếm
        private void send_file_handler(User user, Packet request)
        {
            byte[] sendFile = GetFileFromDB(request.Message);
            if (sendFile != null)
            {
                Room userRoom = roomList.FirstOrDefault(r => r.roomID == int.Parse(request.RoomID));
                if (userRoom == null) return;

                // VideoData đã được nén
                byte[] videoData = CompressVideo(sendFile);
                userRoom.CurrentVideoData = videoData;

                // Gửi video nén tới tất cả các user trong phòng
                foreach (User roomUser in userRoom.userList)
                {
                    Packet videoPacket = new Packet
                    {
                        Code = 4,
                        Username = user.Username,
                        VideoData = videoData, // Gửi video nén
                    };
                    sendSpecific(roomUser, videoPacket);
                }
            }
        }

        private byte[] CompressVideo(byte[] videoData) //Nén video
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    gzipStream.Write(videoData, 0, videoData.Length);
                }
                return outputStream.ToArray();
            }
        }
        #endregion

        #region Xử lý khi host upload file
        private void send_video_handler(User user, Packet request)
        {
            Room userRoom = roomList.FirstOrDefault(r => r.roomID == int.Parse(request.RoomID));
            if (userRoom == null) return;

            // VideoData đã được nén
            byte[] videoData = request.VideoData;
            userRoom.CurrentVideoData = videoData;

            // Gửi video nén tới tất cả các user trong phòng
            foreach (User roomUser in userRoom.userList)
            {
                if (roomUser != user) // Không gửi lại cho chính người gửi
                {
                    Packet videoPacket = new Packet
                    {
                        Code = 4,
                        Username = user.Username,
                        VideoData = videoData, // Gửi video nén
                    };
                    sendSpecific(roomUser, videoPacket);
                }
            }
            ManagerOBJ.WriteToLog($"Room {userRoom.roomID}: {user.Username} uploaded a video.");
        }
        #endregion

        #region Xử lý khi host tua ngược file
        private void rewind_video_handler(User user, Packet request)
        {
            Room userRoom = roomList.FirstOrDefault(r => r.roomID == int.Parse(request.RoomID));
            if (userRoom == null) return;

            foreach (User roomUser in userRoom.userList)
            {
                if (roomUser != user) // Không gửi lại cho chính người gửi
                {
                    Packet videoPacket = new Packet
                    {
                        Code = 7,
                        Username = user.Username,
                        CurrentPosition = request.CurrentPosition
                    };
                    sendSpecific(roomUser, videoPacket);
                }
            }
        }
        #endregion

        #region Xử lý khi host tua nhanh file
        private void next_video_handler(User user, Packet request)
        {
            Room userRoom = roomList.FirstOrDefault(r => r.roomID == int.Parse(request.RoomID));
            if (userRoom == null) return;

            foreach (User roomUser in userRoom.userList)
            {
                if (roomUser != user) // Không gửi lại cho chính người gửi
                {
                    Packet videoPacket = new Packet
                    {
                        Code = 8,
                        Username = user.Username,
                        CurrentPosition = request.CurrentPosition
                    };
                    sendSpecific(roomUser, videoPacket);
                }
            }
        }
        #endregion

        #region Xử lý khi host bấm tiếp tục phát file và khi muốn đồng bộ
        private void continue_video_handler(User user, Packet request)
        {
            Room userRoom = roomList.FirstOrDefault(r => r.roomID == int.Parse(request.RoomID));
            if (userRoom == null) return;

            foreach (User roomUser in userRoom.userList)
            {
                if (roomUser != user) // Không gửi lại cho chính người gửi
                {
                    Packet videoPacket = new Packet
                    {
                        Code = 6,
                        Username = user.Username,
                        CurrentPosition = request.CurrentPosition,
                    };
                    sendSpecific(roomUser, videoPacket);
                }
            }
        }
        #endregion

        #region Xử lý khi host bấm dừng file
        private void stop_video_handler(User user, Packet request)
        {
            Room userRoom = roomList.FirstOrDefault(r => r.roomID == int.Parse(request.RoomID));
            if (userRoom == null) return;

            foreach (User roomUser in userRoom.userList)
            {
                if (roomUser != user) // Không gửi lại cho chính người gửi
                {
                    Packet videoPacket = new Packet
                    {
                        Code = 5,
                        Username = user.Username,
                        CurrentPosition = request.CurrentPosition
                    };
                    sendSpecific(roomUser, videoPacket);
                }
            }
        }
        #endregion

        #region Của người tham gia
        private void join_room_handler(User user, Packet request)
        {
            bool roomExist = false;

            int id = int.Parse(request.RoomID.ToString());
            Room requestingRoom = new Room();
            foreach (Room room in roomList)
            {
                if (room.roomID == id) //Kiểm tra xem phòng mà client tham gia có tồn tại không
                {
                    requestingRoom = room;
                    request.RoomName = room.roomName;
                    roomExist = true;
                    break;
                }
            }
            if (!roomExist)
            {
                request.Username = "err:thisroomdoesnotexist";
                sendSpecific(user, request);
                return;
            }

            //Nếu có tồn tại thì...
            user.Username = request.Username;
            user.Avatar = request.Avatar;
            requestingRoom.userList.Add(user); //thêm user vào userList của phòng tương ứng

            // gửi danh sách user sau khi thêm user mới cho các user cũ trong phòng tương ứng
            request.Username = requestingRoom.GetUsernameListInString();
            request.Avatar = requestingRoom.GetAvatarList();

            foreach (User _user in requestingRoom.userList)
            {
                sendSpecific(_user, request);
            }

            if (requestingRoom.CurrentVideoData != null && requestingRoom.CurrentVideoData.Length > 0)
            {
                // Gửi thông tin video cho user mới
                Packet videoInfoPacket = new Packet
                {
                    Code = 4, // Gửi video thông tin
                    RoomID = requestingRoom.roomID.ToString(),
                    isHost = 0,
                    VideoData = requestingRoom.CurrentVideoData, // Gửi dữ liệu video
                };
                sendSpecific(user, videoInfoPacket); // Gửi cho user mới
            }

            ManagerOBJ.WriteToLog("Room " + request.RoomID + ": " + user.Username + " joined");
            ManagerOBJ.UpdateUserCount(userList.Count);
        }
        #endregion

        //Của Form_Signup
        #region Xử lý yêu cầu đăng kí
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
        #endregion

        //Của Form_Signin
        #region Xử lý yêu cầu đăng nhập
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
        #endregion

        //Của Form_Profile
        #region Xử lý yêu cầu đổi MK
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
        #endregion

        #region Xử lý yêu cầu đổi tên TK
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
        #endregion

        #region Xử lý yêu cầu cập nhật Avatar
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
        #endregion

        //Của Form_Home
        #region Xử lý yêu cầu lấy ảnh đại diện trả về cho client sau khi đăng nhập
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
        #endregion

        #region Gửi thông tin của các file cho form home sau khi client đăng nhập
        private List<MovieNMusic> GetMoviesNMusicsFromDB()
        {
            // Lấy dữ liệu từ DataGridView và chuyển thành danh sách MovieNMusic
            List<MovieNMusic> movieandmusic = new List<MovieNMusic>();
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();
                string query = "SELECT Title, Description, Tag, Poster FROM MoviesNMusics";

                using (var command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movieandmusic.Add(new MovieNMusic
                        {
                            // Lấy dữ liệu từ cơ sở dữ liệu
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            Tag = reader["Tag"].ToString(),
                            Poster = reader["Poster"] as byte[]
                        });
                    }
                }
            }
            return movieandmusic;
        }

        public byte[] SerializeMovieNMusic(List<MovieNMusic> movieandmusic)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(ms))
                {
                    writer.Write(movieandmusic.Count);
                    foreach (var movie in movieandmusic)
                    {
                        writer.Write(movie.Title);
                        writer.Write(movie.Description);
                        writer.Write(movie.Tag);
                        writer.Write(movie.Poster.Length);
                        writer.Write(movie.Poster); // ghi byte array
                    }
                }
                return ms.ToArray();
            }
        }
        #endregion

        #region Xử lý gửi file tương ứng với title từ công cụ tìm kiếm
        private byte[] GetFileFromDB(string titleofFile)
        {
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                connection.Open();
                string query = "SELECT FileData FROM MoviesNMusics WHERE Title = @title";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", titleofFile);

                    object result = command.ExecuteScalar();
                    // Kiểm tra kết quả và chuyển đổi sang mảng byte
                    if (result != DBNull.Value && result != null)
                    {
                        return (byte[])result;
                    }
                }
                query = "SELECT Tag FROM MoviesNMusics WHERE Title = @title";
                using (var command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    command.Parameters.AddWithValue("@title", titleofFile);
                    tag = reader["Tag"].ToString();
                }
            }
            return null;
        }
        #endregion

        //Của Server
        #region Chức năng Add File vào DB
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
            OFD.Filter = "Media Files (*.mp3;*.mp4)|*.mp3;*.mp4";
            DialogResult ofd = OFD.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                try
                {
                    // Chuyển đổi file mp3 và mp4 và wav thành mảng byte
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
                tbTitle.Clear();
                tbDescription.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message); }
        }
        #endregion

        public class MovieNMusic
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Tag { get; set; }
            public byte[] Poster { get; set; }
        }
    }
}
