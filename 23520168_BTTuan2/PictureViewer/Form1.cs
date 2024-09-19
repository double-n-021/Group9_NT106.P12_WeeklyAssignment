using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        private String[] imageFiles;
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void OpenFilebutton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if(folderDialog.ShowDialog()==DialogResult.OK) // ShowDialog là 1 phương thức của FolderBrowserDialog dùng để
                                                               // hiển thị hộp thoại để user chọn thư mục
                {
                    string folderPath = folderDialog.SelectedPath; //Lấy đường dẫn thư mục user đã chọn
                                                                   //từ thuộc tính SelectedPath lưu vào
                                                                   //biến string folderpPath
                    LoadImages(folderPath);
                }
            }    
        }

        public void LoadImages(string folderPath)
        {
            imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
             .Where(File => File.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    File.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                    File.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
             .ToArray();
            //Lấy tất cả tệp hình ảnh từ thư mục đã chọn các tệp kết thúc = đuôi .jpg, .png và .bmp
            //Ở hđh Windows thì tệp .txt và .TXT là giống nhau nên chọn so sánh chuỗi không phân biệt
            //chữ hoa và chữ thường StringComparison.OrdinalIgnoreCase

            flowLayoutPanelThumbnails.Controls.Clear();

            foreach(var imageFile in imageFiles) //Cho mỗi file ảnh trong các file ảnh ở thư mục
                                                   //đều tạo 1 thumbnail
            {
                var Anh = Image.FromFile(imageFile);
                var thumnail = new PictureBox
                {
                    Image = new Bitmap(Anh, new Size(200, 140)), //Tạo thumbnails
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(5), //Đặt lề để giữ khoảng cách giữa các thumbnails
                    Tag = imageFile,
                };
                thumnail.Click += Thumbnail_Click;
                flowLayoutPanelThumbnails.Controls.Add(thumnail);
            }

            if(imageFiles.Length > 0)
                ShowImage(imageFiles[0]);
            flowLayoutPanelThumbnails.Controls[0].Focus();
        }

        public void ShowImage(string imageFilePath)
        {
            mainPictureBox.Image = Image.FromFile(imageFilePath);    //              (imageFilePath)
            currentIndex = Array.IndexOf(imageFiles, imageFilePath); //Tìm chỉ số của ảnh htai trong các ảnh 
                                                                    //tìm được (imageFiles)
            //Array.IndexOf trả về chỉ số của phần tử đầu tiên trong mảng có gtri = imageFilePath
        }

        public void Thumbnail_Click(object sender, EventArgs e)
        {
            var thumbnaildaclick = sender as PictureBox;
            if (thumbnaildaclick != null)
            {
                string filePath = thumbnaildaclick.Tag.ToString();
                ShowImage(filePath);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (imageFiles != null && imageFiles.Length == 0)
                return;

            if (e.KeyCode == Keys.Left)
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                }
                else if(currentIndex == 0)
                {
                    currentIndex = imageFiles.Length - 1;
                }
                ShowImage(imageFiles[currentIndex]);
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (currentIndex < imageFiles.Length - 1)
                {
                    currentIndex++;
                }
                else if(currentIndex == imageFiles.Length -1)
                {
                    currentIndex = 0;
                }
                ShowImage(imageFiles[currentIndex]);
            }
        }
    }
}
