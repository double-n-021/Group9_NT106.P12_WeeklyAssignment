using AxWMPLib;
using ColorSlider;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public Form_room(string username, byte[] avatarconnect)
        {
            InitializeComponent();
            textconnect = username;//gán dữ liệu vừa được truyền từ form home cho form create
            Avatarconnect = avatarconnect;//gán dữ liệu vừa được truyền từ form home cho form create
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
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


        private bool isUserDragging = false;

        public void PlayVideo(string videoPath)
        {
            Videoplayer.URL = videoPath;
            Videoplayer.Ctlcontrols.play();
            timer1.Start();
        }

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
                btPause.Visible = true;

            lbTiming.Text = Videoplayer.Ctlcontrols.currentPositionString;
            lbMaxTime.Text = Videoplayer.Ctlcontrols.currentItem.durationString.ToString();
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

        private void pbBackgroundOFFR_MouseEnter(object sender, EventArgs e)
        {
            pnTool.Visible = false;
        }

        private void pbBackgroundOFFR_MouseLeave(object sender, EventArgs e)
        {
            pnTool.Visible = true;
        }
    }
}
