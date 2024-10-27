using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Form_Home : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        private string textconnect;//biến này dùng để truyền dữ liệu tên người dùng từ form hiện tại đến các form khác
        private byte[] Avatarconnect;//biến này dùng để truyền dữ liệu ảnh từ form hiện tại đến các form khác
        public Form_Home(string username, byte[] avatarconnect)
        {
            InitializeComponent();
            Avatarconnect = avatarconnect;
            lbUsername.Text = username; //gán dữ liệu vừa được truyền từ form signin cho label của form home
            textconnect = username; //gán dữ liệu bắc cầu form signin -> form home -> form tiếp theo
            if (avatarconnect != null && avatarconnect.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(avatarconnect))
                {
                    btAvatar.Image = Image.FromStream(ms); //load avatar vừa được truyền lên giao diện
                }
            }
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Home_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundHome;
            btMaximized.Parent = pbBackgroundHome;
            btMinimized.Parent = pbBackgroundHome;
            pnHeader.Parent = pbBackgroundHome;
            btSetting.Parent = pbBackgroundHome;
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

        //Mở form setting và đóng form hiện tại
        private void btSetting_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Setting formSetting = new Form_Setting(textconnect, Avatarconnect);//truyền cho form setting username và avatar
            formSetting.Show();
            formSetting.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Mở form profile và đóng form hiện tại
        private void btProfile_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Profile formProfile = new Form_Profile(textconnect, Avatarconnect);//truyền cho form profile username và avatar
            formProfile.Show();
            formProfile.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Mở form create và đóng form hiện tại
        private void btCreate_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Create formCreate = new Form_Create(textconnect, Avatarconnect);//truyền cho form create username và avatar
            formCreate.Show();
            formCreate.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Mở form join và đóng form hiện tại
        private void btJoin_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Join formJoin = new Form_Join(textconnect, Avatarconnect);//truyền cho form join username và avatar
            formJoin.Show();
            formJoin.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Phần dưới này liên quan tới bấm vào bt ở form home để xem phim và nghe nhạc
        bool FlagNextMV = false, FlagNextMC = false;

        private void btBackofVideo_Click(object sender, EventArgs e)
        {
            pbBackgroundNextMV.Visible = false;
            FlagNextMV = false;
        }

        private void btNextofVideo_Click(object sender, EventArgs e)
        {
            pbBackgroundNextMV.Visible = !pbBackgroundNextMV.Visible;
            FlagNextMV = true;
        }

        private void btBackofSong_Click(object sender, EventArgs e)
        {
            pbBackgroundNS.Visible = false;
            FlagNextMC = false;
        }

        private void btNextofSong_Click(object sender, EventArgs e)
        {
            pbBackgroundNS.Visible = !pbBackgroundNS.Visible;
            FlagNextMC = true;
        }

        private void btFirstMovie_Click(object sender, EventArgs e)
        {
            string videoPath = "";
            if (FlagNextMV)
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "TraintoBusan.mp4");
            }
            else
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "Conan.mp4");
            }
            this.Close();
            Form_room formOfflineroom = new Form_room(textconnect, Avatarconnect);
            formOfflineroom.Show();
            formOfflineroom.PlayVideo(videoPath);
            formOfflineroom.Location = new Point(this.Location.X, this.Location.Y);
        }
        /*
        private void btFirstsong_Click(object sender, EventArgs e)
        {
            string videoPath = "";
            if (FlagNextMC)
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "Regret.mp3");
            }
            else
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "SimpGai808.mp3");
            }
            this.Close();
            Form_Offlineroom formOfflineroom = new Form_Offlineroom();
            formOfflineroom.Show();
            formOfflineroom.PlayVideo(videoPath);
            formOfflineroom.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void btSecondsong_Click(object sender, EventArgs e)
        {
            string videoPath = "";
            if (FlagNextMC)
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "HaNoi.mp3");
            }
            else
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "DieWithASmile.mp3");
            }
            this.Close();
            Form_Offlineroom formOfflineroom = new Form_Offlineroom();
            formOfflineroom.Show();
            formOfflineroom.PlayVideo(videoPath);
            formOfflineroom.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void btThirdsong_Click(object sender, EventArgs e)
        {
            string videoPath = "";
            if (FlagNextMC)
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "TheSpectre.mp3");
            }
            else
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "KhongTheSay.mp3");
            }
            this.Close();
            Form_Offlineroom formOfflineroom = new Form_Offlineroom();
            formOfflineroom.Show();
            formOfflineroom.PlayVideo(videoPath);
            formOfflineroom.Location = new Point(this.Location.X, this.Location.Y);

        }

        private void btFouthsong_Click(object sender, EventArgs e)
        {
            string videoPath = "";
            if (FlagNextMC)
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "Position.mp3");
            }
            else
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "Love Story.mp3");
            }
            this.Close();
            Form_Offlineroom formOfflineroom = new Form_Offlineroom();
            formOfflineroom.Show();
            formOfflineroom.PlayVideo(videoPath);
            formOfflineroom.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void btSecondMovie_Click(object sender, EventArgs e)
        {
            string videoPath = "";
            if (FlagNextMV)
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "MoDomDom.mp4");
            }
            else
            {
                videoPath = System.IO.Path.Combine(Application.StartupPath, "VideoNMusic", "101.mp4");
            }
            this.Close();
            Form_Offlineroom formOfflineroom = new Form_Offlineroom();
            formOfflineroom.Show();
            formOfflineroom.PlayVideo(videoPath);
            formOfflineroom.Location = new Point(this.Location.X, this.Location.Y);
        }*/
    }
}
