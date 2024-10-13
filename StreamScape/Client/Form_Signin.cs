using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_Signin : Form
    {
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        //Thêm Socket để kết nối và gửi đi thông tin từ Client
        private Socket clientSocket = null;
        private int _buff_size = 2048;
        private byte[] _buffer = new byte[2048];
        private delegate void SafeCallDelegate(string text);

        public Form_Signin()
        {
            InitializeComponent();
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
            clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

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
            try
            {
                // Kết nối đến server
                if (!clientSocket.Connected)
                {
                    clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 11000); // Localhost và cổng 11000
                }

                if (clientSocket.Connected)
                {
                    // Lấy thông tin username và password
                    string username = tbUsername.Text;
                    string password = tbPassword.Text;

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Lỗi xác thực");
                        return;
                    }

                    // Định dạng chuỗi đăng nhập
                    string loginMessage = $"LOGIN|{username}|{password}";

                    // Gửi chuỗi đăng nhập đến server
                    byte[] messageBytes = Encoding.UTF8.GetBytes("TEXT" + loginMessage);
                    clientSocket.Send(messageBytes);

                    // Hiển thị thông báo đăng nhập
                    MessageBox.Show("Đang thử đăng nhập với tên người dùng: " + username);

                    // Chuyển sang giao diện chính
                    this.Close();
                    Form_Home formHome = new Form_Home();
                    formHome.Show();
                    formHome.Location = new Point(this.Location.X, this.Location.Y);
                }
                else
                {
                    MessageBox.Show("Không thể kết nối đến server.", "Lỗi kết nối");
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Lỗi kết nối socket: " + ex.Message, "Lỗi kết nối");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi");
            }
        }
    }
}
