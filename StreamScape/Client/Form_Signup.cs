using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_Signup : Form
    {
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        public Form_Signup()
        {
            InitializeComponent();
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Signup_Load(object sender, EventArgs e)
        {
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

        private void btExit_Click(object sender, EventArgs e)
        {
            var formsToClose = Application.OpenForms.Cast<Form>().ToList();
            foreach (var form in formsToClose)
            {
                form.Close();
            }
        }

        private void btMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Login formLogin = new Form_Login();
            formLogin.Show();
            formLogin.Location = new Point(this.Location.X, this.Location.Y);
        }

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

        private void btSignup_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string emailphone = tbEmailphone.Text;
            string password = tbCreatepassword.Text;

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(emailphone))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            //Khởi tạo đối tượng A thuộc lớp user với 3 thuộc tính
            User A = new User(username, emailphone, password);

            try
            {
                // Tạo kết nối TCP đến server
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Đảm bảo server đang chạy
                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true }) // Đặt AutoFlush
                {
                    // Gửi yêu cầu đăng ký đến server
                    writer.WriteLine("signup");
                    writer.WriteLine(A.Username);
                    writer.WriteLine(A.Password);
                    writer.WriteLine(A.EmailPhone);

                    // Đọc phản hồi từ server
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string response = reader.ReadLine();
                        MessageBox.Show(response);

                        // Nếu đăng ký thành công, hiển thị form Home
                        if (response == "Đăng ký thành công!") // Kiểm tra phản hồi
                        {
                            OpenFormLogin();
                        }
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

        private void OpenFormLogin()
        {
            this.Close();
            Form_Login formLogin = new Form_Login();
            formLogin.Show();
            formLogin.Location = new Point(this.Location.X, this.Location.Y);
        }
    }

    [Serializable]
    class User
    {
        public string Username { get; set; }
        public string EmailPhone { get; set; }
        public string Password { get; set; }

        //Phương thức khởi tạo thông tin cho user
        public User(string username, string emailPhone, string password)
        {
            Username = username;
            EmailPhone = emailPhone;
            Password = password;
        }
    }
}
