using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_Login : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;

        public Form_Login()
        {
            InitializeComponent();
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundlogin;
            btMaximized.Parent = pbBackgroundlogin;
            btMinimized.Parent = pbBackgroundlogin;
            pnHeader.Parent = pbBackgroundlogin;
            btLogin.Parent = pbBackgroundlogin;
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

        //Chức năng chuyển đến form đăng nhập
        private void btLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Signin formSignin = new Form_Signin();
            formSignin.Show();
            formSignin.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Chức năng chuyển đến form đăng ký
        private void Signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Signup formSignup = new Form_Signup();
            formSignup.Show();
            formSignup.Location = new Point(this.Location.X, this.Location.Y);
        }
    }
}
