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
    public partial class Form_Join : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        private string textconnect;//biến này dùng để truyền dữ liệu tên người dùng từ form hiện tại đến các form khác
        private byte[] Avatarconnect;//biến này dùng để truyền dữ liệu ảnh từ form hiện tại đến các form khác
        private string idroomconnect;
        public Form_Join(string username, byte[] avatarconnect)
        {
            InitializeComponent();
            textconnect = username;//gán dữ liệu vừa được truyền từ form home cho form create
            Avatarconnect = avatarconnect;//gán dữ liệu vừa được truyền từ form home cho form create
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Join_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundJoin;
            btMaximized.Parent = pbBackgroundJoin;
            btMinimized.Parent = pbBackgroundJoin;
            pnHeader.Parent = pbBackgroundJoin;
            btBack.Parent = pbBackgroundJoin;
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

        //Quay lại form home và đóng form hiện tại
        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Home formHome = new Form_Home(textconnect, Avatarconnect);
            formHome.Show();
            formHome.Location = new Point(this.Location.X, this.Location.Y);
        }

        //Mở form join và đóng form hiện tại
        private void btJoin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbIDofRoom.Text))
            {
                MessageBox.Show("Vui lòng nhập ID phòng trước khi tham gia");
                return;
            }
            else
            {
                idroomconnect = tbIDofRoom.Text;
                this.Close();
                Form_Onlineroom formOnlineroom = new Form_Onlineroom(textconnect, Avatarconnect, "", idroomconnect);
                formOnlineroom.Show();
                formOnlineroom.Location = new Point(this.Location.X, this.Location.Y);
            }
        }
    }
}
