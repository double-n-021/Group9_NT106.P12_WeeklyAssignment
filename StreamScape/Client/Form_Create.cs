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
    public partial class Form_Create : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        private string textconnect;//biến này dùng để truyền dữ liệu tên người dùng từ form hiện tại đến các form khác
        private byte[] Avatarconnect;//biến này dùng để truyền dữ liệu ảnh từ form hiện tại đến các form khác
        private string nameroomconnect;
        public Form_Create(string username, byte[] avatarconnect)
        {
            InitializeComponent();
            textconnect = username;//gán dữ liệu vừa được truyền từ form home cho form create
            Avatarconnect = avatarconnect;//gán dữ liệu vừa được truyền từ form home cho form create
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Create_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundCreate;
            btMaximized.Parent = pbBackgroundCreate;
            btMinimized.Parent = pbBackgroundCreate;
            pnHeader.Parent = pbBackgroundCreate;
            btBack.Parent = pbBackgroundCreate;
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

        //Mở form onlineroom và đóng form hiện tại
        private void btCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNameofRoom.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng trước khi khởi tạo");
                return;
            }   
            else
            {
                nameroomconnect = tbNameofRoom.Text;
                this.Close();
                Form_Onlineroom formOnlineroom = new Form_Onlineroom(textconnect, Avatarconnect, 0, nameroomconnect, "");//0 là code create room
                formOnlineroom.Show();
                formOnlineroom.Location = new Point(this.Location.X, this.Location.Y);
            }
        }
    }
}
