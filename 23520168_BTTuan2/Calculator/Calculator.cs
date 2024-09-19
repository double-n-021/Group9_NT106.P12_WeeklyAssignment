using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private decimal firstvalue = 0.0m;
        private decimal secondvalue = 0.0m;
        private decimal result = 0.0m;
        private string operators = "+";
   
        public Calculator()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "0";
            }
            else
            {
                kq.Text += "0";
            }
        }

        private void buttonDauCham_Click(object sender, EventArgs e)
        {
            if(!(kq.Text.Contains(".")))
            {
                kq.Text += ".";
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "1";
            }
            else
            {
                kq.Text += "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "2";
            }
            else
            {
                kq.Text += "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "3";
            }
            else
            {
                kq.Text += "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "4";
            }
            else
            {
                kq.Text += "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "5";
            }
            else
            {
                kq.Text += "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "6";
            }
            else
            {
                kq.Text += "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "7";
            }
            else
            {
                kq.Text += "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "8";
            }
            else
            {
                kq.Text += "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (kq.Text == "0")
            {
                kq.Text = "9";
            }
            else
            {
                kq.Text += "9";
            }
        }

        private void buttondauam_Click(object sender, EventArgs e)
        {
            if(kq.Text.Contains("-"))
            {
                kq.Text = kq.Text.Trim('-'); //Nếu số đang hiển thị là số âm thì khi ấn nút thêm dấu âm sẽ trở thành số dương -> cần loại bỏ dấu âm
            }
            else if(kq.Text == "0")
            {
                kq.Text = "0";
            }    
            else
            {
                kq.Text = "-" + kq.Text;
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            kq.Text = "0";
        }

        private void buttonCong_Click(object sender, EventArgs e)
        {
            firstvalue = decimal.Parse(kq.Text); //Ép kiểu sang dạng thập phân
            kq.Text = string.Empty;
            operators = "+";
        }

        private void buttonTru_Click(object sender, EventArgs e)
        {
            firstvalue = decimal.Parse(kq.Text);
            kq.Text = string.Empty;
            operators = "-";
        }

        private void buttonNhan_Click(object sender, EventArgs e)
        {
            firstvalue = decimal.Parse(kq.Text);
            kq.Text = string.Empty;
            operators = "*";
        }

        private void buttonChia_Click(object sender, EventArgs e)
        {
            firstvalue = decimal.Parse(kq.Text);
            kq.Text = string.Empty;
            operators = "/";
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            firstvalue = decimal.Parse(kq.Text);
            kq.Text = string.Empty;
            operators = "%";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            secondvalue = decimal.Parse(kq.Text);
            try
            {
                switch (operators)
                {
                    case "+":
                        result = firstvalue + secondvalue;
                        break;
                    case "-":
                        result = firstvalue - secondvalue;
                        break;
                    case "*":
                        result = firstvalue * secondvalue;
                        break;
                    case "/":
                        if (secondvalue == 0)
                        {
                            MessageBox.Show("Math Error!!! Khong duoc chia cho 0!!!", "Warning");
                            return;
                        }
                        else
                            result = firstvalue / secondvalue;
                        break;
                    case "%":
                        result = firstvalue % secondvalue;
                        break;
                    default:
                        return;
                }
                kq.Text = result.ToString(); //Chuyển kiểu result từ dạng decimal sang chuỗi
                operators = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            if (kq.Text.Length > 0)
            {
                kq.Text = kq.Text.Remove(kq.Text.Length - 1);
                if (kq.Text.Length == 0)
                {
                    kq.Text = "0";
                }
            }
        }
    }
}
