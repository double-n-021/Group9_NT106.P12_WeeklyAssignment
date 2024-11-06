using AxWMPLib;
using ColorSlider;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Form_room : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        
        private string textconnect;//biến này dùng để truyền dữ liệu tên người dùng từ form hiện tại đến các form khác
        private byte[] Avatarconnect;//biến này dùng để truyền dữ liệu ảnh từ form hiện tại đến các form khác
        private string serverIP;

        public Form_room(string _serverIP, string username, byte[] avatarconnect, string titleofFile)
        {
            InitializeComponent();
            serverIP = _serverIP;
            PlayFile(titleofFile);//phát file tương ứng với title được truyền vào
            textconnect = username;//gán dữ liệu vừa được truyền từ form home cho form create
            Avatarconnect = avatarconnect;//gán dữ liệu vừa được truyền từ form home cho form create
            
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void PlayFile(string titleofFile)
        {
            try
            {
                // Tạo kết nối TCP đến server
                using (TcpClient client = new TcpClient(serverIP, 5000)) // Sửa địa chỉ IP và port nếu cần
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

        private void Form_Offlineroom_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundOFFR;
            btMaximized.Parent = pbBackgroundOFFR;
            btMinimized.Parent = pbBackgroundOFFR;
            pnHeader.Parent = pbBackgroundOFFR;
            btBack.Parent = pbBackgroundOFFR;
        }

        #region Chức năng có thể di chuyển cửa sổ...
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
        #endregion

        #region 3 button công cụ...
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
            Form_Home formHome = new Form_Home(serverIP, textconnect, Avatarconnect);
            formHome.Show();
            formHome.Location = new Point(this.Location.X, this.Location.Y);
        }
        #endregion

        #region Công cụ điều chỉnh âm thanh...
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

        private void csSound_ValueChanged(object sender, EventArgs e)
        {
            Videoplayer.settings.volume = (int)csSound.Value;
        }

        private void csSound_Scroll(object sender, ScrollEventArgs e)
        {
            Videoplayer.settings.volume = (int)csSound.Value;
            btMute.Visible = false;
            btUnmute.Visible = true;
        }
        #endregion

        #region Công cụ điều chỉnh video..
        private bool isUserDragging = false;

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

        private void csVideo_Scroll(object sender, ScrollEventArgs e)
        {
            Videoplayer.Ctlcontrols.currentPosition = (int)csVideo.Value;
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
        #endregion

        #region Ẩn vs hiện toolpanel...
        private void pbBackgroundOFFR_MouseEnter(object sender, EventArgs e)
        {
            pnTool.Visible = false;
        }

        private void pbBackgroundOFFR_MouseLeave(object sender, EventArgs e)
        {
            pnTool.Visible = true;
        }
        #endregion

        //Trong lúc tính giờ
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isUserDragging && Videoplayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                btPause.Visible = false;
                csSound.Value = (int)Videoplayer.settings.volume;
                csVideo.Maximum = (int)Videoplayer.Ctlcontrols.currentItem.duration;
                csVideo.Value = (int)Videoplayer.Ctlcontrols.currentPosition;
            }

            if (Videoplayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                btPause.Visible = true;
                csVideo.Value = csVideo.Maximum;
            }

            lbTiming.Text = Videoplayer.Ctlcontrols.currentPositionString;
            lbMaxTime.Text = Videoplayer.Ctlcontrols.currentItem.durationString.ToString();
        }

        //Chức năng up file mp3 và mp4 từ máy lên
        private void btUpload_Click(object sender, EventArgs e)
        {
            btPlaying.Visible = true;
            OFD.Filter = "Media Files (*.mp3;*.mp4)|*.mp3;*.mp4";
            DialogResult ofd = OFD.ShowDialog();
            if (ofd == DialogResult.OK)
            {
                timer1.Start();
                try { Videoplayer.URL = OFD.FileName; }
                catch (Exception) { }
            }
        }
    }
}
