using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_Signup : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        
        private string serverIP;
        public Form_Signup(string _serverIP)
        {
            InitializeComponent();
            serverIP = _serverIP;
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Signup_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundSignup;
            btMaximized.Parent = pbBackgroundSignup;
            btMinimized.Parent = pbBackgroundSignup;
            pnHeader.Parent = pbBackgroundSignup;
            btBack.Parent = pbBackgroundSignup;
            tbUsername.Parent = pbBackgroundSignup;
            tbEmailphone.Parent = pbBackgroundSignup;
            tbCreatepassword.Parent = pbBackgroundSignup;
            btSignup.Parent = pbBackgroundSignup;
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
        private void btSignup_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string emailphone = tbEmailphone.Text;
            string password = tbCreatepassword.Text;

            // Kiểm tra tính đúng đắn của dữ liệu nhập
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(emailphone))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (tbCreatepassword.Text.Length < 8 || tbEmailphone.Text.Length < 10)
            {
                MessageBox.Show("Mật khẩu phải từ 8 kí tự trở lên. Email/Phone phải từ 10 kí tự trở lên");
            }

            try
                {
                // Tạo kết nối TCP đến server
                using (TcpClient client = new TcpClient(serverIP, 5000)) // Đảm bảo server đang chạy
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Gửi yêu cầu đăng ký đến server
                    writer.Write("signup");           // Gửi yêu cầu "signup"
                    writer.Write(username);         // Gửi tên người dùng
                    writer.Write(password);         // Gửi mật khẩu
                    writer.Write(emailphone);       // Gửi email/điện thoại

                    // Đọc phản hồi từ server
                    string response = reader.ReadString();
                    MessageBox.Show(response);

                    // Nếu đăng ký thành công, hiển thị form Login
                    if (response == "Đăng ký thành công!") // Kiểm tra phản hồi
                    {
                        OpenFormLogin();
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Không thể kết nối đến server: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        //Mở form login và đóng form hiện tại
        private void OpenFormLogin()
        {
            this.Close();
            Form_Login formLogin = new Form_Login();
            formLogin.Show();
            formLogin.Location = new Point(this.Location.X, this.Location.Y);
        }
    }
}
