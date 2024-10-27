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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Form_Profile : Form
    {
        //3 biến này sử dụng cho chức năng panelHeader
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        private string textconnect;//biến này dùng để truyền dữ liệu tên người dùng từ form hiện tại đến các form khác
        private byte[] Avatarconnect;//biến này dùng để truyền dữ liệu ảnh từ form hiện tại đến các form khác
        public Form_Profile(string username, byte[] avatarconnect)
        {
            InitializeComponent();
            Avatarconnect = avatarconnect;
            lbUsername.Text = username; //gán dữ liệu vừa được truyền từ form signin cho label của form home
            lbUsernameofDetails.Text = username; //gán dữ liệu vừa được truyền từ form signin cho label của form home
            textconnect = lbUsername.Text;//gán dữ liệu bắc cầu form signin -> form home -> form profile -> form tiếp theo
            if (avatarconnect != null && avatarconnect.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(avatarconnect))
                {
                    pbAvatarofDetails.Image = Image.FromStream(ms);
                    pbAvatar.Image = Image.FromStream(ms); //load avatar vừa được truyền lên giao diện
                }
            }
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Profile_Load(object sender, EventArgs e)
        {
            //tạo background trong suốt
            btExit.Parent = pbBackgroundProfile;
            btMaximized.Parent = pbBackgroundProfile;
            btMinimized.Parent = pbBackgroundProfile;
            pnHeader.Parent = pbBackgroundProfile;
            btSetting.Parent = pbBackgroundProfile;
            lbUsername.Parent = pbBackgroundProfile;
            tbUsername.Parent = pbBackgroundProfiledetails;
            tbChangepassword.Parent = pbBackgroundProfiledetails;
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

        private void btSetting_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Setting formSetting = new Form_Setting(textconnect, Avatarconnect);
            formSetting.Show();
            formSetting.Location = new Point(this.Location.X, this.Location.Y);
        }

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

        //Đổi giao diện khi nhất edit profile
        private void btEditProfile_Click(object sender, EventArgs e)
        {
            //Hide
            lbUsername.Visible = false;
            pbAvatar.Visible = false;
            btShowall.Visible = false;
            btEditProfile.Visible = false;

            //Show
            pbBackgroundProfiledetails.Visible = true;
            tbChangepassword.Visible = true;
            tbUsername.Visible = true;
            btEditavatar.Visible = true;
            pbAvatarofDetails.Visible = true;
            btAccept.Visible = true;
            btSave.Visible = true;
            lbUsernameofDetails.Visible = true;
        }

        //Cập nhật username
        private void btSave_Click(object sender, EventArgs e)
        {
            string newusername = tbUsername.Text;
            string oldusername = lbUsername.Text;
            // Kiểm tra tính đúng đắn của dữ liệu nhập
            if (string.IsNullOrWhiteSpace(newusername))
            {
                ShowNHide();
                return;
            }

            try
            {
                // Tạo kết nối TCP đến server
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Sửa địa chỉ IP và port nếu cần
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Gửi yêu cầu đổi tên người dùng đến server
                    writer.Write("changeusername"); // Gửi yêu cầu "changeusername"
                    writer.Write(newusername);      // Gửi tên người dùng mới
                    writer.Write(oldusername);      // Gửi tên người dùng cũ

                    // Đọc phản hồi từ server
                    string response = reader.ReadString();
                    MessageBox.Show(response);

                    if (response == "Đổi tên thành công!")
                    {
                        //Tải username mới lên giao diện
                        lbUsername.Text = newusername;
                        lbUsernameofDetails.Text = newusername;
                        textconnect = newusername; //Cập nhật tên mới cho biến truyền
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

            ShowNHide();//Đổi về giao diện ban đầu của form profile
        }

        private void ShowNHide()
        {
            //Hide
            pbBackgroundProfiledetails.Visible = false;
            tbChangepassword.Visible = false;
            tbUsername.Visible = false;
            btEditavatar.Visible = false;
            pbAvatarofDetails.Visible = false;
            btAccept.Visible = false;
            btSave.Visible = false;
            lbUsernameofDetails.Visible = false;

            //Show
            lbUsername.Visible = true;
            pbAvatar.Visible = true;
            btShowall.Visible = true;
            btEditProfile.Visible = true;

            //Reset text trong 2 textbox changepass vs changeusername sau khi đã nhập thông tin vào
            tbChangepassword.Text = "";
            tbUsername.Text = "";
        }

        //Cập nhật password
        private void btAccept_Click(object sender, EventArgs e)
        {
            string password = tbChangepassword.Text;
            string username = lbUsername.Text;
            // Kiểm tra tính đúng đắn của dữ liệu nhập
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Sửa địa chỉ IP và port nếu cần
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                // Gửi yêu cầu đổi mật khẩu đến server
                writer.Write("changepassword"); // Gửi yêu cầu "changepassword"
                writer.Write(username);         // Gửi tên người dùng
                writer.Write(password);         // Gửi mật khẩu mới

                // Đọc phản hồi từ server
                string response = reader.ReadString();
                MessageBox.Show(response);
            }
        }

        private void btEditavatar_Click(object sender, EventArgs e)
        {
            OFD.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";

            DialogResult ofd = OFD.ShowDialog();
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thay đổi ảnh đại diện?", "Đồng Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //Tải avatar mới lên giao diện
                    pbAvatarofDetails.Image = Image.FromFile(OFD.FileName);
                    pbAvatar.Image = Image.FromFile(OFD.FileName);
                }
                catch (Exception ex) { }

                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    Image avatar = Image.FromFile(OFD.FileName);
                    avatar.Save(ms, avatar.RawFormat); // Lưu ảnh vào MemoryStream
                    imageData = ms.ToArray(); // Chuyển MemoryStream thành mảng byte
                }

                string username = textconnect; // Biến username phải được khai báo và gán đúng giá trị
                try
                {
                    // Tạo kết nối TCP đến server
                    using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // Đảm bảo IP và port của máy chủ chính xác
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream)) // Reader để đọc phản hồi
                    {
                        // Gửi yêu cầu "changeavatar"
                        writer.Write("changeavatar");
                        writer.Write(username); // Gửi tên người dùng

                        // Gửi kích thước và dữ liệu ảnh
                        writer.Write(imageData.Length);
                        writer.Write(imageData);

                        // Đọc phản hồi từ server
                        string response = reader.ReadString();
                        MessageBox.Show(response);
                        Avatarconnect = imageData;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to server: " + ex.Message);
                }
            }
        }
    }
}
