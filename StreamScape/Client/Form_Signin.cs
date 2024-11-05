using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_Signin : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        private byte[] avatarconnect;//biến này dùng để truyền dữ liệu ảnh từ form hiện tại đến các form khác
        private string serverIP;
        public Form_Signin(string _serverIP)
        {
            InitializeComponent();
            serverIP = _serverIP;
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Signin_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundSignin;
            btMaximized.Parent = pbBackgroundSignin;
            btMinimized.Parent = pbBackgroundSignin;
            pnHeader.Parent = pbBackgroundSignin;
            btBack.Parent = pbBackgroundSignin; 
            tbUsername.Parent = pbBackgroundSignin;
            tbPassword.Parent = pbBackgroundSignin;
            btSignin.Parent = pbBackgroundSignin;
            btShowPassword.Parent = pbBackgroundSignin;

            tbPassword.UseSystemPasswordChar = true;
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

        //Chức năng quay lại form login và đóng form hiện tại
        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Login formLogin = new Form_Login();
            formLogin.Show();
            formLogin.Location = new Point(this.Location.X, this.Location.Y);
        }
        #endregion

        //Chức năng gửi thông tin username, emailphone, password đến server để server lưu vào DB
        private void btSignin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            // Kiểm tra tính đúng đắn của dữ liệu nhập
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            try
            {
                // Tạo kết nối TCP đến server
                using (TcpClient client = new TcpClient(serverIP, 5000)) // Sửa địa chỉ IP và port nếu cần
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Gửi yêu cầu đăng nhập đến server
                    writer.Write("login");       // Gửi yêu cầu "login"
                    writer.Write(username);       // Gửi tên người dùng
                    writer.Write(password);       // Gửi mật khẩu

                    // Đọc phản hồi từ server
                    string response = reader.ReadString();
                    MessageBox.Show(response);

                    // Nếu đăng nhập thành công, hiển thị form Home
                    if (response == "Đăng nhập thành công!") // Kiểm tra phản hồi
                    {
                        avatarconnect = GetAvatar(username);//Lấy avatar từ database
                        OpenFormHome(username);//Mở form home
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }

        }

        #region Hàm con có liên quan đến Sigin_Click
        private byte[] GetAvatar(string username)
        {
            try
            {
                // Tạo kết nối TCP đến server
                using (TcpClient client = new TcpClient(serverIP, 5000)) // Đảm bảo IP và port của máy chủ chính xác
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Gửi yêu cầu "getavatar"
                    writer.Write("getavatar");
                    writer.Write(username); // Gửi tên người dùng

                    // Đọc phản hồi từ server
                    string response = reader.ReadString();
                    if (response != "Không có dữ liệu ảnh")//Nếu tồn tại dữ liệu ảnh thì thực hiện đọc file binary của ảnh
                    {
                        int imageSize = reader.ReadInt32();     // Đọc kích thước ảnh
                        byte[] imageData = reader.ReadBytes(imageSize); // Đọc dữ liệu ảnh
                        return imageData;//trả về file binary tương ứng cho phương thức GetAvatar
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
            return null;
        }

        //Mở form home và đóng form hiện tại
        private void OpenFormHome(string username)
        {
            this.Close();
            Form_Home formHome = new Form_Home(serverIP, username, avatarconnect);
            formHome.Show();
            formHome.Location = new Point(this.Location.X, this.Location.Y);
        }
        #endregion

        //Chức năng ẩn mật khẩu
        int count = 0;
        private void btShowPassword_Click(object sender, EventArgs e)
        {
            if (count%2==0)
                tbPassword.UseSystemPasswordChar = false;
            else
                tbPassword.UseSystemPasswordChar = true;
            count++;
        }
    }
}
