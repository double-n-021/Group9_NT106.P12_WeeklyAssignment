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

namespace Client
{
    public partial class Form_Setting : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        private string textconnect;//biến này dùng để truyền dữ liệu tên người dùng từ form hiện tại đến các form khác
        private byte[] Avatarconnect;//biến này dùng để truyền dữ liệu ảnh từ form hiện tại đến các form khác
        public Form_Setting(string username, byte[] avatarconnect)
        {
            InitializeComponent();
            Avatarconnect = avatarconnect;
            lbUsername.Text = username;//gán dữ liệu vừa được truyền từ form home cho label của form setting
            textconnect = username; //gán dữ liệu bắc cầu form signin -> form home -> form setting -> form tiếp theo
            if (avatarconnect != null && avatarconnect.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(avatarconnect))
                {
                    btAvatar.Image = Image.FromStream(ms);//load avatar vừa được truyền lên giao diện
                }
            }
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Setting_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundSetting;
            btMaximized.Parent = pbBackgroundSetting;
            btMinimized.Parent = pbBackgroundSetting;
            pnHeader.Parent = pbBackgroundSetting;
            btSetting.Parent = pbBackgroundSetting;
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

        //Mở form home và đóng form hiện tại
        private void btHome_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Home formHome = new Form_Home(textconnect, Avatarconnect);
            formHome.Show();
            formHome.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Mở form profile và đóng form hiện tại
        private void btProfile_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Profile formProfile = new Form_Profile(textconnect, Avatarconnect);
            formProfile.Show();
            formProfile.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Mở form create và đóng form hiện tại
        private void btCreate_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Create formCreate = new Form_Create(textconnect, Avatarconnect);
            formCreate.Show();
            formCreate.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Mở form join và đóng form hiện tại
        private void btJoin_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Join formJoin = new Form_Join(textconnect, Avatarconnect);
            formJoin.Show();
            formJoin.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Đăng xuất tài khoản và trở về form login
        private void btLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Login formLogin = new Form_Login();
            formLogin.Show();
            formLogin.Location = new Point(this.Location.X, this.Location.Y);
        }
    }
}
