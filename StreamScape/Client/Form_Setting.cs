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
    public partial class Form_Setting : Form
    {
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        public Form_Setting()
        {
            InitializeComponent();
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Setting_Load(object sender, EventArgs e)
        {
            btExit.Parent = pbBackgroundSetting;
            btMaximized.Parent = pbBackgroundSetting;
            btMinimized.Parent = pbBackgroundSetting;
            pnHeader.Parent = pbBackgroundSetting;
            btSetting.Parent = pbBackgroundSetting;
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

        private void btHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Home formHome = new Form_Home();
            formHome.Show();
            formHome.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void btProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Profile formProfile = new Form_Profile();
            formProfile.Show();
            formProfile.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Create formCreate = new Form_Create();
            formCreate.Show();
            formCreate.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void btJoin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Join formJoin = new Form_Join();
            formJoin.Show();
            formJoin.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login formLogin = new Form_Login();
            formLogin.Show();
            formLogin.Location = new Point(this.Location.X, this.Location.Y);
        }
    }
}
