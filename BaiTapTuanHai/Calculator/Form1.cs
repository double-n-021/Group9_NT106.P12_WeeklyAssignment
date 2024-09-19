using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string operationshow = "";
        Double result = 0;
        bool buttonnow = false;
        float point = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void click_button(Object sender, EventArgs e)
        {
            //Phat hien dau cham
            if ((Button)sender == button11)
                point++;
            else
                point = 0;

            if (point>1)
                textshow.Text = textshow.Text.Substring(0, textshow.Text.Length - 1);
            if (!buttonnow)
                textshow.Clear();
            Button button = (Button)sender;
            textshow.Text = textshow.Text + button.Text; //hien thi tren textbox
            buttonnow = true;
        }

        private void click_operator(Object sender, EventArgs e)
        {
            buttonnow = false;
            Button button = (Button)(sender);
            operationshow = button.Text;
            result = Double.Parse(textshow.Text); //chuyen chuoi thanh so trc operator
            label1.Text = result + " " + operationshow;
            textshow.Clear();
        }

        private void clear_operator(Object sender, EventArgs e)
        {
            Button button = (Button)(sender);
            textshow.Clear(); 
        }

        private void click_equal(Object sender, EventArgs e)
        {
            buttonnow = false;
            switch (operationshow)
            {
                case "+":
                    textshow.Text = (result + Double.Parse(textshow.Text)).ToString();
                    break;
                case "-":
                    textshow.Text = (result - Double.Parse(textshow.Text)).ToString();
                    break;
                case "*":
                    textshow.Text = (result * Double.Parse(textshow.Text)).ToString();
                    break;
                case "/":
                    if (textshow.Text == "0")
                    {
                        textshow.Text = "Math ERROR";
                        
                        break;
                    }
                    else
                        textshow.Text = (result / Double.Parse(textshow.Text)).ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
