using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_Profile : Form
    {
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        public Form_Profile()
        {
            InitializeComponent();
            this.pnHeader.MouseDown += new MouseEventHandler(panelHeader_MouseDown);
            this.pnHeader.MouseMove += new MouseEventHandler(panelHeader_MouseMove);
            this.pnHeader.MouseUp += new MouseEventHandler(panelHeader_MouseUp);
        }

        private void Form_Profile_Load(object sender, EventArgs e)
        {
            btExit.Parent = pbBackgroundProfile;
            btMaximized.Parent = pbBackgroundProfile;
            btMinimized.Parent = pbBackgroundProfile;
            pnHeader.Parent = pbBackgroundProfile;
            btSetting.Parent = pbBackgroundProfile;
            lbUsername.Parent = pbBackgroundProfile;
            tbUsername.Parent = pbBackgroundProfiledetails;
            tbChangepassword.Parent = pbBackgroundProfiledetails;
        }

        private void btSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Setting formSetting = new Form_Setting();
            formSetting.Show();
            formSetting.Location = new Point(this.Location.X, this.Location.Y);
        }

        private void btMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            var formsToClose = Application.OpenForms.Cast<Form>().ToList();
            foreach (var form in formsToClose)
            {
                form.Close();
            }
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

        private void btSave_Click(object sender, EventArgs e)
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
        }
    }
}
