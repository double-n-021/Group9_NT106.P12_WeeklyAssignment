using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO.Compression;

namespace Client
{
    public partial class Form_Onlineroom : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;

        private string textconnect;//biến này dùng để truyền dữ liệu tên người dùng từ form hiện tại đến các form khác
        private byte[] Avatarconnect;//biến này dùng để truyền dữ liệu ảnh từ form hiện tại đến các form khác

        private Packet this_client_info;
        private Manager Manager;
        private bool isNew;
        private int isHost;
        private string serverIP;

        public Form_Onlineroom(string _serverIP, int isHost, string username, byte[] avatarconnect, int code, string nameconnect, string idconnect)
        {
            InitializeComponent();
            serverIP = _serverIP;
            LoadDataFromServer();
            textconnect = username;//gán dữ liệu vừa được truyền từ form home cho form create
            Avatarconnect = avatarconnect;//gán dữ liệu vừa được truyền từ form home cho form create

            //Chức năng panel_header
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);

            isNew = true;

            //Lưu thông tin user vừa click vào nút create hoặc join vào class Packet để gửi đến server
            this_client_info = new Packet()
            {
                Username = username,
                Avatar = avatarconnect,
                Code = code,
                RoomName = nameconnect,
                RoomID = idconnect,
            };

            //Khởi tạo class manager để cập nhật list người tham gia phòng và mã id của phòng ở phía user
            Manager = new Manager(listView_room_users, tbRoomID, tbRoomName);
        }

        TcpClient client;
        private BinaryReader reader;
        private BinaryWriter writer;

        private void Form_Onlineroom_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundONLR;
            btMaximized.Parent = pbBackgroundONLR;
            btMinimized.Parent = pbBackgroundONLR;
            pnHeader.Parent = pbBackgroundONLR;
            btBack.Parent = pbBackgroundONLR;
            btMenu.Parent = pbBackgroundONLR;
            tbEnterchat.Parent = pbBackgroundONLR;

            try
            {
                client = new TcpClient(serverIP, 5000); // Sửa địa chỉ IP và port nếu cần
                NetworkStream stream = client.GetStream();
                writer = new BinaryWriter(stream);
                reader = new BinaryReader(stream); // Reader để đọc phản hồi
                {
                    writer.Write("onlineroom");
                    sendToServer(this_client_info); //gửi gói tin chứa thông tin của you cho server
                    Manager.UpdateRoomIDNRoomName(this_client_info.RoomID, this_client_info.RoomName);
                    Manager.AddToUserListView(this_client_info.Username, this_client_info.Avatar, this); //cập nhật tên của you vào listview
                    Thread listen = new Thread(Receive);
                    listen.IsBackground = true;
                    listen.Start();
                }
            }
            catch
            {
                Manager.ShowError("Can not connect to the server!");
                this.Close();
                return;
            }
        }

        //Gửi cho server gói tin
        private void sendToServer(Packet message)
        {
            string messageInJson = JsonConvert.SerializeObject(message);
            try
            {
                writer.Write(messageInJson);
                writer.Flush();
            }
            catch
            {
                Manager.ShowError("Failed to send data to server!");
            }
        }

        private void Receive()
        {
            try
            {
                string responseInJson = string.Empty;
                while (true)
                {
                    responseInJson = reader.ReadString();

                    Packet response = JsonConvert.DeserializeObject<Packet>(responseInJson);

                    switch (response.Code)
                    {
                        case 0:
                            generate_room_status(response);
                            break;
                        case 1:
                            join_room_status(response);
                            break;
                        case 2:
                            displayChatMessage(response.Username, response.Message);
                            break;
                        case 3:
                            displayIcon(response.Username, response.Icon);
                            break;
                        case 4:
                            displayVideo(response.Username, response.VideoData);
                            break;
                        case 5:
                            stop_video(response);
                            break;
                        case 6:
                            continue_video(response);
                            break;
                        case 7:
                            rewind_video(response);
                            break;
                        case 8:
                            next_video(response);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                client.Close();
            }
        }

        void generate_room_status(Packet response)
        {
            this_client_info.RoomID = response.RoomID;
            Manager.UpdateRoomIDNRoomName(this_client_info.RoomID, this_client_info.RoomName);
            isNew = false;
            isHost = 1;

            
            if (response.isHost == 1)
            {
                //Gọi lại phương thức này trên luồng UI
                btUpload.Invoke(new MethodInvoker(() => btUpload.Visible = true));
                btFowardTime.Invoke(new MethodInvoker(() => btFowardTime.Visible = true));
                btBackTime.Invoke(new MethodInvoker(() => btBackTime.Visible = true));
                btPlaying.Invoke(new MethodInvoker(() => btPlaying.Visible = true));
                btPause.Invoke(new MethodInvoker(() => btPause.Visible = true));
            }
        }
        
        void join_room_status(Packet response)
        {
            if (isNew)
            {
                sendToServer(new Packet
                {
                    Code = 10, //Không thực hiện thêm hành động khác
                    RoomID = response.RoomID,
                });
                isNew = false;
                tbRoomName.Text = response.RoomName;
            }

            if (response.Username == "err:thisroomdoesnotexist")
            {
                Manager.ShowError("The room you requested does not exist");
                client.Close();
                return;
            }

            if (response.Username.Contains('!'))
            {
                Manager.RemoveFromUserListView(response.Username.Substring(1), this);
            }
            else
            {
                List<string> listusername = response.Username.Split(',').ToList();
                List<byte[]> listavatar = SplitAvatars(response.Avatar);

                int seq = 0;
                foreach (string username in listusername)
                {
                    if (username == this_client_info.Username)
                    {
                        listusername.Remove(username);
                        break;
                    }
                    seq++;
                }

                listavatar.Remove(listavatar[seq]);

                Manager.ClearUserListView(this);

                seq = 0;
                foreach (string username in listusername)
                {
                    Manager.AddToUserListView(username, listavatar[seq], this);
                    seq++;
                }
            }
        }

        private void displayChatMessage(string username, string message)
        {
            flowLayoutPanel.Invoke((MethodInvoker)delegate
            {
                FlowLayoutPanel frame = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown, // Đặt chiều hướng từ trên xuống dưới
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 0) // Giảm khoảng cách bên ngoài nếu cần
                };
                Label lbu = new Label
                {
                    Text = username,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold), // Phông chữ "Segoe UI", cỡ 10, in đậm
                    Margin = new Padding(0, 0, 5, -1),
                };
                RounderLabel messageLabel = new RounderLabel
                {
                    Text = message,
                    AutoSize = true,
                    Padding = new Padding(10),
                    Margin = new Padding(0),
                    BackColor = System.Drawing.Color.White, // Rõ ràng là Color từ System.Drawing
                    ForeColor = System.Drawing.Color.Black,  // Rõ ràng là Color từ System.Drawing
                };

                frame.Controls.Add(lbu);                 // Thêm Label vào Frame
                frame.Controls.Add(messageLabel);       //Thêm messageLabel vào Frame

                flowLayoutPanel.Controls.Add(frame);
                flowLayoutPanel.ScrollControlIntoView(frame);
            });
        }

        private void displayIcon(string username, string icon)
        {
            string iconPath = Path.Combine("Icons", icon);

            if (File.Exists(iconPath))
            {
                flowLayoutPanel.Invoke((MethodInvoker)delegate
                {
                    FlowLayoutPanel Frame = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.TopDown, // Đặt chiều hướng từ trên xuống dưới
                        AutoSize = true, // Tự động điều chỉnh kích thước
                        Margin = new Padding(0), // Khoảng cách bên ngoài
                        WrapContents = false // Không bọc nội dung
                    };

                    PictureBox iconPictureBox = new PictureBox
                    {
                        Image = Image.FromFile(iconPath),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 50,
                        Height = 50,
                        Margin = new Padding(0, 0, 0, 0),
                    };

                    Label usernameLabel = new Label
                    {
                        Text = username,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        AutoSize = true,
                        Padding = new Padding(1),
                        Margin = new Padding(5, 0, 0, 0),
                    };

                    // Thêm PictureBox và Label vào Frame
                    Frame.Controls.Add(usernameLabel);
                    Frame.Controls.Add(iconPictureBox);

                    // Thêm Frame chứa PictureBox và Label vào FlowLayoutPanel chính
                    flowLayoutPanel.Controls.Add(Frame);
                    // Cuộn xuống cuối cùng của FlowLayoutPanel
                    flowLayoutPanel.ScrollControlIntoView(Frame);// Cuộn xuống cuối cùng của FlowLayoutPanel
                });
            }
            else
            {
                displayChatMessage(username, "[Icon not found]");
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

        private byte[] DecompressVideo(byte[] compressedData) //Giải nén
        {
            using (var inputStream = new MemoryStream(compressedData))
            using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            using (var outputStream = new MemoryStream())
            {
                gzipStream.CopyTo(outputStream);
                return outputStream.ToArray();
            }
        }

        private void displayVideo(string username, byte[] videoData)
        {
            // Giải nén dữ liệu video
            byte[] compressedData = DecompressVideo(videoData);

            // Lưu video vào file tạm
            string tempFilePath = Path.Combine(Path.GetTempPath(), $"{username}_video_{Guid.NewGuid()}.mp4");
            File.WriteAllBytes(tempFilePath, compressedData);


            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    // Phát video trong Windows Media Player
                    Videoplayer.URL = tempFilePath;
                    Videoplayer.Ctlcontrols.play();
                    timer1.Start();
                    btPause.Visible = false;
                }));
            }
            else
            {
                // Phát video trong Windows Media Player
                Videoplayer.URL = tempFilePath;
                Videoplayer.Ctlcontrols.play();
                timer1.Start();
                btPause.Visible = false;
            }
        }

        public List<byte[]> SplitAvatars(byte[] listAvatar)
        {
            List<byte[]> avatars = new List<byte[]>();
            int index = 0;

            while (index < listAvatar.Length)
            {
                // Lấy kích thước ảnh
                int avatarSize = BitConverter.ToInt32(listAvatar, index);
                index += 4;

                // Tạo mảng byte cho ảnh và sao chép nội dung từ listAvatar
                byte[] avatar = new byte[avatarSize];
                Array.Copy(listAvatar, index, avatar, 0, avatarSize);
                avatars.Add(avatar);

                // Di chuyển index tới vị trí ảnh kế tiếp
                index += avatarSize;
            }

            return avatars;
        }

        public class MovieNMusic
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Tag { get; set; }
            public byte[] Poster { get; set; }
        }

        List<MovieNMusic> movieandmusic;
        public void LoadDataFromServer()
        {
            try
            {
                using (TcpClient client = new TcpClient(serverIP, 5000)) // Sửa địa chỉ IP và port nếu cần
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getdata");
                    // Đọc dữ liệu từ server
                    movieandmusic = ReceiveMoviesFromServer(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private List<MovieNMusic> ReceiveMoviesFromServer(NetworkStream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytesRead);
                }

                return DeserializeMovieNMusic(ms.ToArray());
            }
        }

        public List<MovieNMusic> DeserializeMovieNMusic(byte[] data)
        {
            List<MovieNMusic> movieandmusic = new List<MovieNMusic>();
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(ms))
                {
                    int count = reader.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        MovieNMusic mandm = new MovieNMusic
                        {
                            Title = reader.ReadString(),
                            Description = reader.ReadString(),
                            Tag = reader.ReadString(),
                            Poster = reader.ReadBytes(reader.ReadInt32())
                        };
                        movieandmusic.Add(mandm);
                    }
                }
            }
            return movieandmusic;
        }

        //Chức năng có thể di chuyển cửa sổ: Bắt đầu từ đây
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point delta = new Point(Cursor.Position.X - dragCursor.X, Cursor.Position.Y - dragCursor.Y);
                this.Location = new Point(dragForm.X + delta.X, dragForm.Y + delta.Y);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        //Kết thúc ở đây

        //Đóng app
        private void btExit_Click(object sender, EventArgs e)
        {
            var formsToClose = Application.OpenForms.Cast<Form>().ToList();
            foreach (var form in formsToClose)
            {
                form.Close();
            }
        }

        //Chức năng thu nhỏ cửa sổ xuống tab
        private void btMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Quay lại form home và đóng form hiện tại (Rời phòng)
        private void btBack_Click(object sender, EventArgs e)
        {
            client.Close();
            this.Close();
            Form_Home formHome = new Form_Home(serverIP, textconnect, Avatarconnect);
            formHome.Show();
            formHome.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void pbAvatar_Click(object sender, EventArgs e)
        {

        }

        private bool isUserDragging = false;

        //Chức năng up file mp3 và mp4 từ máy lên
        private void btUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Media Files (*.mp3;*.mp4)|*.mp3;*.mp4";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        timer1.Start();
                        // Đọc dữ liệu video từ file
                        byte[] videoData = File.ReadAllBytes(openFileDialog.FileName);

                        // Nén dữ liệu video
                        byte[] compressedData = CompressVideo(videoData);

                        // Tạo gói tin video để gửi lên server
                        Packet videoPacket = new Packet
                        {
                            Code = 4, // Mã cho video
                            RoomID = this_client_info.RoomID,
                            Username = this_client_info.Username,
                            VideoData = compressedData,
                        };

                        // Gửi dữ liệu nén tới server
                        sendToServer(videoPacket);

                        // Hiển thị video
                        displayVideo(this_client_info.Username, compressedData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error uploading video: " + ex.Message);
                    }
                }
            }
        }

        private double lastPosition = 0; // Khởi tạo biến lưu vị trí cuối cùng

        private void btUnmute_Click(object sender, EventArgs e)
        {
            btMute.Visible = true;
            btUnmute.Visible = false;
            Videoplayer.settings.volume = 0;
        }

        private void btMute_Click(object sender, EventArgs e)
        {
            btMute.Visible = false;
            btUnmute.Visible = true;
            Videoplayer.settings.volume = (int)csSound.Value;
        }

        private void btPlaying_Click(object sender, EventArgs e)
        {
            btPause.Visible = true;
            btPlaying.Visible = false;

            Videoplayer.Ctlcontrols.pause();
            lastPosition = Videoplayer.Ctlcontrols.currentPosition; // Lưu vị trí hiện tại
            Packet stopPacket = new Packet
            {
                Code = 5,
                Username = this_client_info.Username,
                RoomID = this_client_info.RoomID,
                CurrentPosition = lastPosition // Gửi vị trí đã dừng
            };
            sendToServer(stopPacket);
        }

        private void continue_video(Packet continuePacket)
        {
            Videoplayer.Ctlcontrols.currentPosition = continuePacket.CurrentPosition; // Đặt vị trí
            Videoplayer.Ctlcontrols.play();
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            btPlaying.Visible = true;
            btPause.Visible = false;
            Videoplayer.Ctlcontrols.currentPosition = lastPosition; // Đặt lại vị trí
            Videoplayer.Ctlcontrols.play();
            Packet continuePacket = new Packet
            {
                Code = 6,
                Username = this_client_info.Username,
                RoomID = this_client_info.RoomID,
                CurrentPosition = lastPosition // Gửi vị trí để phát tiếp
            };
            sendToServer(continuePacket);
        }

        private void stop_video(Packet stopPacket)
        {
            Videoplayer.Ctlcontrols.pause();
        }

        private void btFowardTime_Click(object sender, EventArgs e)
        {
            double currentTime = Videoplayer.Ctlcontrols.currentPosition;
            double newTime = Math.Max(currentTime + 10, 0); // Tua ngược 10 giây
            Videoplayer.Ctlcontrols.currentPosition = newTime; // Cập nhật vị trí local

            Packet _nextPacket = new Packet
            {
                Code = 8, // Mã cho việc cập nhật video
                Username = this_client_info.Username,
                RoomID = this_client_info.RoomID,
                CurrentPosition = newTime // Vị trí video sau khi tua
            };
            sendToServer(_nextPacket);
        }
        private void rewind_video(Packet rewindPacket)
        {
            Videoplayer.Ctlcontrols.currentPosition = rewindPacket.CurrentPosition;
        }

        private void btBackTime_Click(object sender, EventArgs e)
        {
            double currentTime = Videoplayer.Ctlcontrols.currentPosition;
            double newTime = currentTime - 10; 
            Videoplayer.Ctlcontrols.currentPosition = newTime; // Cập nhật vị trí local
            Packet _nextPacket = new Packet
            {
                Code = 8, // Mã cho việc cập nhật video
                Username = this_client_info.Username,
                RoomID = this_client_info.RoomID,
                CurrentPosition = newTime // Vị trí video sau khi tua
            };
            sendToServer(_nextPacket);
        }
        private void next_video(Packet nextPacket)
        {
            Videoplayer.Ctlcontrols.currentPosition = nextPacket.CurrentPosition;
        }

        private void csSound_Scroll(object sender, ScrollEventArgs e)
        {
            Videoplayer.settings.volume = (int)csSound.Value;
            btMute.Visible = false;
            btUnmute.Visible = true;
        }

        private void csSound_ValueChanged(object sender, EventArgs e)
        {
            Videoplayer.settings.volume = (int)csSound.Value;
        }

        private void csVideo_Scroll(object sender, ScrollEventArgs e)
        {
            if (isHost == 1)
            {
                Videoplayer.Ctlcontrols.currentPosition = (int)csVideo.Value;
                double newTime = Videoplayer.Ctlcontrols.currentPosition;
                Packet _nextPacket = new Packet
                {
                    Code = 8, // Mã cho việc cập nhật video
                    Username = this_client_info.Username,
                    RoomID = this_client_info.RoomID,
                    CurrentPosition = newTime // Vị trí video sau khi tua
                };
                sendToServer(_nextPacket);
            }
            else csVideo.Value = (int)Videoplayer.Ctlcontrols.currentPosition;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isUserDragging && Videoplayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                this.Invoke((MethodInvoker)delegate {
                    csSound.Value = (int)Videoplayer.settings.volume;
                    csVideo.Maximum = (int)Videoplayer.Ctlcontrols.currentItem.duration;
                    csVideo.Value = (int)Videoplayer.Ctlcontrols.currentPosition;
                });
            }

            if (Videoplayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Invoke((MethodInvoker)delegate {
                        if (isHost == 1) btPause.Visible = true;
                        csVideo.Value = csVideo.Maximum;
                });
            }

            this.Invoke((MethodInvoker)delegate {
                lbTiming.Text = Videoplayer.Ctlcontrols.currentPositionString;
                lbMaxTime.Text = Videoplayer.Ctlcontrols.currentItem.durationString.ToString();
            });
        }

        private void csVideo_MouseUp(object sender, MouseEventArgs e)
        {
            isUserDragging = false;
            Videoplayer.Ctlcontrols.currentPosition = (int)csVideo.Value;
        }

        private void csVideo_MouseDown(object sender, MouseEventArgs e)
        {
            isUserDragging = true;
        }

        private void pbBackgroundONLR_MouseEnter(object sender, EventArgs e)
        {
            pnTool.Visible = false;
            if(isHost == 1)
            {
                btSearch.Visible = false;
                tbSearch.Visible = false;
            }
        }

        private void pbBackgroundONLR_MouseLeave(object sender, EventArgs e)
        {
            pnTool.Visible = true;
            if (isHost == 1)
            {
                btSearch.Visible = true;
                tbSearch.Visible = true;
                searchResult.Visible = false;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
             searchResult.Visible = true;
            // Kiểm tra từ khóa tìm kiếm có trống hay không
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                return;
            }
            else
            {
                // Lọc danh sách dựa trên từ khóa tìm kiếm (không phân biệt chữ hoa chữ thường)
                var filteredList = movieandmusic
                    .Where(m => m.Title.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .Select(m => new { Title = m.Title })
                    .ToList();

                // Cập nhật DataSource của DataGridView với danh sách đã lọc
                searchResult.DataSource = filteredList;
            }
        }

        int count = 0;
        private void btMenu_Click(object sender, EventArgs e)
        {
            count++;
            if (count%2==0)
                listView_room_users.Visible = false;
            else
                listView_room_users.Visible = true;
        }

        private void searchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng có hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = searchResult.Rows[e.RowIndex];

                // Lấy giá trị của cột "Title" từ hàng được chọn
                string title = selectedRow.Cells["Title"].Value.ToString();
                Packet playFile = new Packet
                {
                    Code = 9, // Mã cho playfile
                    RoomID = this_client_info.RoomID,
                    Username = this_client_info.Username,
                    Message = title
                };
                sendToServer(playFile);
                searchResult.Visible = false;
            }
        }


        private void btSendMessage_Click(object sender, EventArgs e)
        {
            string message = tbEnterchat.Text;

            string roomId = this_client_info.RoomID;
            string username = this_client_info.Username;

            if (!string.IsNullOrEmpty(message))
            {
                Label usernameLabel = new Label
                {
                    Text = "You",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    AutoSize = true,
                    Padding = new Padding(1),
                    Margin = new Padding(5, 0, 0, 0),
                };

                flowLayoutPanel.Controls.Add(usernameLabel);


                // Tạo một Label mới cho tin nhắn
                RounderLabel lblMessage = new RounderLabel
                {
                    Text = message, // Nội dung của Label
                    AutoSize = true, // Tự động điều chỉnh kích thước
                    Padding = new Padding(10), // Khoảng cách bên trong
                    Margin = new Padding(0, 3, 5, 5), // Khoảng cách bên ngoài
                    BackColor = System.Drawing.Color.Black, // Rõ ràng là Color từ System.Drawing
                    ForeColor = System.Drawing.Color.Azure,  // Rõ ràng là Color từ System.Drawing
                    BorderRadius = 20, // Độ bo góc của Label
                };

                // Thêm Label vào FlowLayoutPanel
                flowLayoutPanel.Controls.Add(lblMessage);

                // Cuộn xuống cuối cùng của FlowLayoutPanel
                flowLayoutPanel.ScrollControlIntoView(lblMessage);

                // Tạo gói tin nhắn Packet để gửi tới server
                Packet chatPacket = new Packet
                {
                    Code = 2,
                    RoomID = roomId,
                    Username = username,
                    Message = message
                };

                // Gửi tin nhắn đến server
                sendToServer(chatPacket);
                tbEnterchat.Clear();
            }
        }

        private void btReaction_Click(object sender, EventArgs e)
        {
            Form iconPicker = new Form();
            iconPicker.Size = new Size(200, 200);
            iconPicker.Text = "Icons"; // Đặt tên form là "Icons"
            iconPicker.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            iconPicker.StartPosition = FormStartPosition.Manual;
            iconPicker.Location = this.PointToScreen(new Point(btUpload.Left, btUpload.Top));

            // Tạo bảng 3x3 icon
            TableLayoutPanel iconTable = new TableLayoutPanel();
            iconTable.RowCount = 3;
            iconTable.ColumnCount = 3;
            iconTable.Dock = DockStyle.Fill;
            iconPicker.Controls.Add(iconTable);

            // Thiết lập kích thước cột và hàng cho đều
            for (int i = 0; i < 3; i++)
            {
                iconTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
                iconTable.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            }

            string[] icons = { "icon1.png", "icon2.png", "icon3.png", "icon4.png", "icon5.png", "icon6.png", "icon7.png", "icon8.png", "icon9.png" };
            foreach (string icon in icons)
            {
                Button iconButton = new Button();
                iconButton.Dock = DockStyle.Fill;
                iconButton.BackgroundImage = Image.FromFile(Path.Combine("Icons", icon));
                iconButton.BackgroundImageLayout = ImageLayout.Stretch;
                iconButton.Click += (s, args) => IconButton_Click(s, args, iconPicker, icon);
                iconTable.Controls.Add(iconButton);
            }
            iconPicker.ShowDialog();
        }

        private void IconButton_Click(object sender, EventArgs e, Form iconPicker, string icon)
        {
            iconPicker.Close();

            // Đường dẫn tới icon
            string iconPath = Path.Combine("Icons", icon);

            // Kiểm tra nếu icon tồn tại
            if (File.Exists(iconPath))
            {
                // Thông tin phòng và tên người dùng
                string roomId = this_client_info.RoomID;
                string username = this_client_info.Username;

                Label usernameLabel = new Label
                {
                    Text = "You",
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    AutoSize = true,
                    Padding = new Padding(1),
                    Margin = new Padding(5, 0, 0, 0),
                };

                flowLayoutPanel.Controls.Add(usernameLabel);

                // Tạo PictureBox để hiển thị icon
                using (Image img = Image.FromFile(iconPath))
                {
                    // Kích thước icon mong muốn
                    int iconWidth = 50; // Chiều rộng
                    int iconHeight = 50; // Chiều cao

                    // Lấy hình ảnh thu nhỏ
                    Image thumbnailImg = img.GetThumbnailImage(iconWidth, iconHeight, null, IntPtr.Zero);
                    PictureBox iconPictureBox = new PictureBox
                    {
                        Image = thumbnailImg,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = iconWidth,
                        Height = iconHeight,
                        Margin = new Padding(0, 0, 0, 3),
                    };

                    flowLayoutPanel.Controls.Add(iconPictureBox);
                    // Cuộn xuống cuối cùng của FlowLayoutPanel
                    flowLayoutPanel.ScrollControlIntoView(iconPictureBox);

                    // Tạo gói tin nhắn Packet để gửi tới server
                    Packet iconPacket = new Packet
                    {
                        Code = 3, // Mã cho icon
                        RoomID = roomId,
                        Username = username,
                        Icon = icon // Thêm icon vào gói tin
                    };

                    // Gửi icon tới server
                    sendToServer(iconPacket);
                }
            }
        }
    }
}
