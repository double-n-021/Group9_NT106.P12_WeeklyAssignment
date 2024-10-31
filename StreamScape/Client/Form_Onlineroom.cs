using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json;

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

        public Form_Onlineroom(string username, byte[] avatarconnect, int code, string nameconnect, string idconnect)
        {
            InitializeComponent();
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
                Code = code,
                RoomID = idconnect,
            };

            //Khởi tạo class manager để cập nhật list người tham gia phòng và mã id của phòng ở phía user
            Manager = new Manager(listView_room_users, tbRoomID);
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
                client = new TcpClient("127.0.0.1", 5000); // Sửa địa chỉ IP và port nếu cần
                NetworkStream stream = client.GetStream();
                writer = new BinaryWriter(stream);
                reader = new BinaryReader(stream); // Reader để đọc phản hồi
                {
                    writer.Write("onlineroom");
                    sendToServer(this_client_info); //gửi được rồi
                    Manager.UpdateRoomID(this_client_info.RoomID);
                    Manager.AddToUserListView(this_client_info.Username + " (you)");
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
                    }
                }
            }
            catch
            {
                client.Close();
            }
        }

        void generate_room_status(Packet response)
        {
            this_client_info.RoomID = response.RoomID;
            Manager.UpdateRoomID(this_client_info.RoomID);
            isNew = false;
        }

        void join_room_status(Packet response)
        {
            if (isNew)
            {
                sendToServer(new Packet
                {
                    Code = 1,
                    RoomID = response.RoomID,
                });
                isNew = false;
            }

            if (response.Username == "err:thisroomdoesnotexist")
            {
                Manager.ShowError("The room you requested does not exist");
                client.Close();
                this.Close();
                return;
            }

            if (response.Username.Contains('!'))
            {
                Manager.RemoveFromUserListView(response.Username.Substring(1));
            }
            else
            {
                List<string> list = response.Username.Split(',').ToList();
                foreach (string username in list)
                {
                    if (username == this_client_info.Username)
                    {
                        list.Remove(username);
                        break;
                    }
                }
                Manager.ClearUserListView();
                foreach (string username in list)
                {
                    Manager.AddToUserListView(username);
                }
            }
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
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Sửa địa chỉ IP và port nếu cần
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
            this.Close();
            Form_Home formHome = new Form_Home(textconnect, Avatarconnect);
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
            OFD.Filter = "Media Files (*.mp3;*.mp4;*.wav)|*.mp3;*.mp4;*.wav";
            DialogResult ofd = OFD.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                timer1.Start();
                try { Videoplayer.URL = OFD.FileName; }
                catch (Exception) { }
            }
        }

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
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            btPlaying.Visible = true;
            btPause.Visible = false;
            Videoplayer.Ctlcontrols.play();
        }

        private void btFowardTime_Click(object sender, EventArgs e)
        {
            Videoplayer.Ctlcontrols.currentPosition += 10;
        }

        private void btBackTime_Click(object sender, EventArgs e)
        {
            Videoplayer.Ctlcontrols.currentPosition -= 10;
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
            Videoplayer.Ctlcontrols.currentPosition = (int)csVideo.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isUserDragging && Videoplayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                csSound.Value = (int)Videoplayer.settings.volume;
                csVideo.Maximum = (int)Videoplayer.Ctlcontrols.currentItem.duration;
                csVideo.Value = (int)Videoplayer.Ctlcontrols.currentPosition;
            }

            if (Videoplayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                btPause.Visible = true;

            lbTiming.Text = Videoplayer.Ctlcontrols.currentPositionString;
            lbMaxTime.Text = Videoplayer.Ctlcontrols.currentItem.durationString.ToString();
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
            btSearch.Visible = false;
            tbSearch.Visible = false;
        }

        private void pbBackgroundONLR_MouseLeave(object sender, EventArgs e)
        {
            pnTool.Visible = true;
            btSearch.Visible = true;
            tbSearch.Visible = true;
            searchResult.Visible = false;
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

        private void searchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng có hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = searchResult.Rows[e.RowIndex];

                // Lấy giá trị của cột "Title" từ hàng được chọn
                string title = selectedRow.Cells["Title"].Value.ToString();
                PlayFile(title);
                searchResult.Visible = false;
            }
        }

        private void PlayFile(string titleofFile)
        {
            try
            {
                // Tạo kết nối TCP đến server
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Sửa địa chỉ IP và port nếu cần
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Gửi yêu cầu lấy file mp3 và mp4 đến server
                    writer.Write("getfile");       // Gửi yêu cầu "getfile"
                    writer.Write(titleofFile);       // Gửi tên file

                    // Đọc phản hồi từ server
                    string tag = reader.ReadString();
                    int fileSize = reader.ReadInt32();     // Đọc kích thước file
                    if (fileSize > 0)
                    {
                        byte[] fileData = reader.ReadBytes(fileSize); // Đọc dữ liệu file

                        // Đường dẫn tạm thời để lưu tệp
                        string tempFilePath = Path.Combine(Path.GetTempPath(), titleofFile + tag);

                        // Ghi dữ liệu vào tệp
                        File.WriteAllBytes(tempFilePath, fileData);

                        // Phát tệp bằng Videoplayer hoặc Audio player tùy thuộc vào loại tệp
                        Videoplayer.URL = tempFilePath;
                        timer1.Start();
                        Videoplayer.Ctlcontrols.play();
                    }
                    else
                    {
                        MessageBox.Show("File not found on server." + titleofFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }
    }
}
