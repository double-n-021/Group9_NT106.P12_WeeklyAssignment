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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Form_Signin : Form
    {
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        public Form_Signin()
        {
            InitializeComponent();
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Signin_Load(object sender, EventArgs e)
        {
            btExit.Parent = pbBackgroundSignin;
            btMaximized.Parent = pbBackgroundSignin;
            btMinimized.Parent = pbBackgroundSignin;
            pnHeader.Parent = pbBackgroundSignin;
            btBack.Parent = pbBackgroundSignin; 
            tbUsername.Parent = pbBackgroundSignin;
            tbPassword.Parent = pbBackgroundSignin;
            btSignin.Parent = pbBackgroundSignin;
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

        private void btSignin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Tạo kết nối TCP đến server
            using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Sửa địa chỉ IP và port nếu cần
            using (NetworkStream stream = client.GetStream())
            using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true }) // Đặt AutoFlush
            {
                // Gửi yêu cầu đăng nhập đến server
                writer.WriteLine("login");
                writer.WriteLine(username);
                writer.WriteLine(password);

                // Đọc phản hồi từ server
                using (StreamReader reader = new StreamReader(stream))
                {
                    string response = reader.ReadLine();
                    MessageBox.Show(response);

                    // Nếu đăng nhập thành công, hiển thị form Home
                    if (response == "Đăng nhập thành công!") // Kiểm tra phản hồi
                    {
                        OpenFormHome(username);
                    }
                }
            }

        }
        private void OpenFormHome(string username)
        {
            this.Close();
            Form_Home formHome = new Form_Home(username);
            formHome.Show();
            formHome.Location = new Point(this.Location.X, this.Location.Y);
        }
    }
}
