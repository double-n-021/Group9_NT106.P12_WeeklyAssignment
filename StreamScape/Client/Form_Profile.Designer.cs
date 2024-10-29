namespace Client
{
    partial class Form_Profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Profile));
            this.pbBackgroundProfile = new System.Windows.Forms.PictureBox();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btMinimized = new Guna.UI2.WinForms.Guna2Button();
            this.btMaximized = new Guna.UI2.WinForms.Guna2Button();
            this.btExit = new Guna.UI2.WinForms.Guna2Button();
            this.btSetting = new Guna.UI2.WinForms.Guna2Button();
            this.btJoin = new Guna.UI2.WinForms.Guna2Button();
            this.btCreate = new Guna.UI2.WinForms.Guna2Button();
            this.btProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btHome = new Guna.UI2.WinForms.Guna2Button();
            this.pbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btEditProfile = new Guna.UI2.WinForms.Guna2Button();
            this.lbUsername = new System.Windows.Forms.Label();
            this.pbBackgroundProfiledetails = new System.Windows.Forms.PictureBox();
            this.pbAvatarofDetails = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.tbUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbChangepassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.btAccept = new Guna.UI2.WinForms.Guna2Button();
            this.lbUsernameofDetails = new System.Windows.Forms.Label();
            this.btEditavatar = new Guna.UI2.WinForms.Guna2CircleButton();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundProfiledetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatarofDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackgroundProfile
            // 
            this.pbBackgroundProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBackgroundProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackgroundProfile.Image = ((System.Drawing.Image)(resources.GetObject("pbBackgroundProfile.Image")));
            this.pbBackgroundProfile.Location = new System.Drawing.Point(0, 0);
            this.pbBackgroundProfile.Name = "pbBackgroundProfile";
            this.pbBackgroundProfile.Size = new System.Drawing.Size(1030, 550);
            this.pbBackgroundProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackgroundProfile.TabIndex = 0;
            this.pbBackgroundProfile.TabStop = false;
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnHeader.Location = new System.Drawing.Point(60, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(798, 38);
            this.pnHeader.TabIndex = 17;
            // 
            // btMinimized
            // 
            this.btMinimized.BackColor = System.Drawing.Color.Transparent;
            this.btMinimized.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMinimized.BackgroundImage")));
            this.btMinimized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMinimized.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btMinimized.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btMinimized.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btMinimized.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btMinimized.FillColor = System.Drawing.Color.Transparent;
            this.btMinimized.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btMinimized.ForeColor = System.Drawing.Color.White;
            this.btMinimized.Location = new System.Drawing.Point(864, 10);
            this.btMinimized.Name = "btMinimized";
            this.btMinimized.Size = new System.Drawing.Size(25, 25);
            this.btMinimized.TabIndex = 16;
            this.btMinimized.Text = "guna2Button1";
            this.btMinimized.Click += new System.EventHandler(this.btMinimized_Click);
            // 
            // btMaximized
            // 
            this.btMaximized.BackColor = System.Drawing.Color.Transparent;
            this.btMaximized.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMaximized.BackgroundImage")));
            this.btMaximized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMaximized.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btMaximized.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btMaximized.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btMaximized.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btMaximized.FillColor = System.Drawing.Color.Transparent;
            this.btMaximized.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btMaximized.ForeColor = System.Drawing.Color.White;
            this.btMaximized.Location = new System.Drawing.Point(932, 15);
            this.btMaximized.Name = "btMaximized";
            this.btMaximized.Size = new System.Drawing.Size(15, 15);
            this.btMaximized.TabIndex = 14;
            this.btMaximized.Text = "guna2Button1";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.Transparent;
            this.btExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExit.BackgroundImage")));
            this.btExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btExit.FillColor = System.Drawing.Color.Transparent;
            this.btExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btExit.ForeColor = System.Drawing.Color.White;
            this.btExit.Location = new System.Drawing.Point(986, 12);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(20, 20);
            this.btExit.TabIndex = 13;
            this.btExit.Text = "guna2Button1";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSetting
            // 
            this.btSetting.BackColor = System.Drawing.Color.Transparent;
            this.btSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSetting.BackgroundImage")));
            this.btSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSetting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSetting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSetting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSetting.FillColor = System.Drawing.Color.Transparent;
            this.btSetting.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btSetting.ForeColor = System.Drawing.Color.White;
            this.btSetting.Location = new System.Drawing.Point(19, 6);
            this.btSetting.Name = "btSetting";
            this.btSetting.Size = new System.Drawing.Size(31, 28);
            this.btSetting.TabIndex = 15;
            this.btSetting.Click += new System.EventHandler(this.btSetting_Click);
            // 
            // btJoin
            // 
            this.btJoin.AutoRoundedCorners = true;
            this.btJoin.BackColor = System.Drawing.Color.Transparent;
            this.btJoin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btJoin.BorderRadius = 21;
            this.btJoin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btJoin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btJoin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btJoin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btJoin.FillColor = System.Drawing.Color.Transparent;
            this.btJoin.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btJoin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btJoin.Location = new System.Drawing.Point(15, 415);
            this.btJoin.Name = "btJoin";
            this.btJoin.PressedColor = System.Drawing.Color.White;
            this.btJoin.Size = new System.Drawing.Size(260, 45);
            this.btJoin.TabIndex = 21;
            this.btJoin.Text = "Join room";
            this.btJoin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btJoin.TextOffset = new System.Drawing.Point(37, 0);
            this.btJoin.UseTransparentBackground = true;
            this.btJoin.Click += new System.EventHandler(this.btJoin_Click);
            // 
            // btCreate
            // 
            this.btCreate.AutoRoundedCorners = true;
            this.btCreate.BackColor = System.Drawing.Color.Transparent;
            this.btCreate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btCreate.BorderRadius = 21;
            this.btCreate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btCreate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btCreate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCreate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btCreate.FillColor = System.Drawing.Color.Transparent;
            this.btCreate.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btCreate.Location = new System.Drawing.Point(15, 365);
            this.btCreate.Name = "btCreate";
            this.btCreate.PressedColor = System.Drawing.Color.White;
            this.btCreate.Size = new System.Drawing.Size(260, 45);
            this.btCreate.TabIndex = 20;
            this.btCreate.Text = "Create new room";
            this.btCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btCreate.TextOffset = new System.Drawing.Point(37, 0);
            this.btCreate.UseTransparentBackground = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btProfile
            // 
            this.btProfile.AutoRoundedCorners = true;
            this.btProfile.BackColor = System.Drawing.Color.Transparent;
            this.btProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btProfile.BorderRadius = 21;
            this.btProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btProfile.FillColor = System.Drawing.Color.Transparent;
            this.btProfile.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btProfile.Location = new System.Drawing.Point(15, 313);
            this.btProfile.Name = "btProfile";
            this.btProfile.PressedColor = System.Drawing.Color.White;
            this.btProfile.Size = new System.Drawing.Size(260, 45);
            this.btProfile.TabIndex = 19;
            this.btProfile.Text = "Profile";
            this.btProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btProfile.TextOffset = new System.Drawing.Point(37, 0);
            this.btProfile.UseTransparentBackground = true;
            // 
            // btHome
            // 
            this.btHome.AutoRoundedCorners = true;
            this.btHome.BackColor = System.Drawing.Color.Transparent;
            this.btHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btHome.BorderRadius = 21;
            this.btHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btHome.FillColor = System.Drawing.Color.Transparent;
            this.btHome.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.btHome.Location = new System.Drawing.Point(15, 267);
            this.btHome.Name = "btHome";
            this.btHome.PressedColor = System.Drawing.Color.White;
            this.btHome.Size = new System.Drawing.Size(260, 45);
            this.btHome.TabIndex = 18;
            this.btHome.Text = "Home";
            this.btHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btHome.TextOffset = new System.Drawing.Point(37, 0);
            this.btHome.UseTransparentBackground = true;
            this.btHome.Click += new System.EventHandler(this.btHome_Click);
            // 
            // pbAvatar
            // 
            this.pbAvatar.BackColor = System.Drawing.Color.Transparent;
            this.pbAvatar.Image = ((System.Drawing.Image)(resources.GetObject("pbAvatar.Image")));
            this.pbAvatar.ImageRotate = 0F;
            this.pbAvatar.InitialImage = null;
            this.pbAvatar.Location = new System.Drawing.Point(597, 117);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAvatar.Size = new System.Drawing.Size(107, 96);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAvatar.TabIndex = 22;
            this.pbAvatar.TabStop = false;
            this.pbAvatar.UseTransparentBackground = true;
            // 
            // btEditProfile
            // 
            this.btEditProfile.AutoRoundedCorners = true;
            this.btEditProfile.BackColor = System.Drawing.Color.Transparent;
            this.btEditProfile.BorderRadius = 21;
            this.btEditProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btEditProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btEditProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btEditProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btEditProfile.FillColor = System.Drawing.Color.White;
            this.btEditProfile.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.btEditProfile.ForeColor = System.Drawing.Color.Black;
            this.btEditProfile.Location = new System.Drawing.Point(585, 230);
            this.btEditProfile.Name = "btEditProfile";
            this.btEditProfile.Size = new System.Drawing.Size(139, 45);
            this.btEditProfile.TabIndex = 23;
            this.btEditProfile.Text = " Edit Profile";
            this.btEditProfile.UseTransparentBackground = true;
            this.btEditProfile.Click += new System.EventHandler(this.btEditProfile_Click);
            // 
            // lbUsername
            // 
            this.lbUsername.BackColor = System.Drawing.Color.Transparent;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lbUsername.ForeColor = System.Drawing.Color.White;
            this.lbUsername.Location = new System.Drawing.Point(513, 63);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(276, 37);
            this.lbUsername.TabIndex = 24;
            this.lbUsername.Text = "user_name12345";
            this.lbUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbBackgroundProfiledetails
            // 
            this.pbBackgroundProfiledetails.Image = ((System.Drawing.Image)(resources.GetObject("pbBackgroundProfiledetails.Image")));
            this.pbBackgroundProfiledetails.Location = new System.Drawing.Point(279, 36);
            this.pbBackgroundProfiledetails.Name = "pbBackgroundProfiledetails";
            this.pbBackgroundProfiledetails.Size = new System.Drawing.Size(751, 514);
            this.pbBackgroundProfiledetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackgroundProfiledetails.TabIndex = 29;
            this.pbBackgroundProfiledetails.TabStop = false;
            this.pbBackgroundProfiledetails.Visible = false;
            // 
            // pbAvatarofDetails
            // 
            this.pbAvatarofDetails.BackColor = System.Drawing.Color.Transparent;
            this.pbAvatarofDetails.Image = ((System.Drawing.Image)(resources.GetObject("pbAvatarofDetails.Image")));
            this.pbAvatarofDetails.ImageRotate = 0F;
            this.pbAvatarofDetails.InitialImage = null;
            this.pbAvatarofDetails.Location = new System.Drawing.Point(359, 209);
            this.pbAvatarofDetails.Name = "pbAvatarofDetails";
            this.pbAvatarofDetails.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAvatarofDetails.Size = new System.Drawing.Size(132, 122);
            this.pbAvatarofDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAvatarofDetails.TabIndex = 30;
            this.pbAvatarofDetails.TabStop = false;
            this.pbAvatarofDetails.UseTransparentBackground = true;
            this.pbAvatarofDetails.Visible = false;
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.Color.Transparent;
            this.tbUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.tbUsername.BorderRadius = 10;
            this.tbUsername.BorderThickness = 0;
            this.tbUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUsername.DefaultText = "";
            this.tbUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbUsername.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.tbUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbUsername.ForeColor = System.Drawing.Color.White;
            this.tbUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbUsername.Location = new System.Drawing.Point(258, 176);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.PasswordChar = '\0';
            this.tbUsername.PlaceholderForeColor = System.Drawing.Color.White;
            this.tbUsername.PlaceholderText = "Username";
            this.tbUsername.SelectedText = "";
            this.tbUsername.Size = new System.Drawing.Size(314, 55);
            this.tbUsername.TabIndex = 31;
            this.tbUsername.Visible = false;
            // 
            // tbChangepassword
            // 
            this.tbChangepassword.BackColor = System.Drawing.Color.Transparent;
            this.tbChangepassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(33)))));
            this.tbChangepassword.BorderRadius = 10;
            this.tbChangepassword.BorderThickness = 0;
            this.tbChangepassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbChangepassword.DefaultText = "";
            this.tbChangepassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbChangepassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbChangepassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbChangepassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbChangepassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.tbChangepassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbChangepassword.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.tbChangepassword.ForeColor = System.Drawing.Color.White;
            this.tbChangepassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbChangepassword.Location = new System.Drawing.Point(258, 265);
            this.tbChangepassword.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbChangepassword.Name = "tbChangepassword";
            this.tbChangepassword.PasswordChar = '\0';
            this.tbChangepassword.PlaceholderForeColor = System.Drawing.Color.White;
            this.tbChangepassword.PlaceholderText = "";
            this.tbChangepassword.SelectedText = "";
            this.tbChangepassword.Size = new System.Drawing.Size(314, 55);
            this.tbChangepassword.TabIndex = 32;
            this.tbChangepassword.Visible = false;
            // 
            // btSave
            // 
            this.btSave.AutoRoundedCorners = true;
            this.btSave.BackColor = System.Drawing.Color.Transparent;
            this.btSave.BorderRadius = 21;
            this.btSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSave.FillColor = System.Drawing.Color.White;
            this.btSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btSave.ForeColor = System.Drawing.Color.Black;
            this.btSave.Location = new System.Drawing.Point(864, 219);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(97, 45);
            this.btSave.TabIndex = 33;
            this.btSave.Text = "Save";
            this.btSave.UseTransparentBackground = true;
            this.btSave.Visible = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btAccept
            // 
            this.btAccept.AutoRoundedCorners = true;
            this.btAccept.BackColor = System.Drawing.Color.Transparent;
            this.btAccept.BorderRadius = 21;
            this.btAccept.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btAccept.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btAccept.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btAccept.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btAccept.FillColor = System.Drawing.Color.White;
            this.btAccept.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btAccept.ForeColor = System.Drawing.Color.Black;
            this.btAccept.Location = new System.Drawing.Point(863, 304);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(97, 45);
            this.btAccept.TabIndex = 34;
            this.btAccept.Text = "Accept";
            this.btAccept.UseTransparentBackground = true;
            this.btAccept.Visible = false;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // lbUsernameofDetails
            // 
            this.lbUsernameofDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbUsernameofDetails.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbUsernameofDetails.ForeColor = System.Drawing.Color.White;
            this.lbUsernameofDetails.Location = new System.Drawing.Point(314, 350);
            this.lbUsernameofDetails.Name = "lbUsernameofDetails";
            this.lbUsernameofDetails.Size = new System.Drawing.Size(220, 32);
            this.lbUsernameofDetails.TabIndex = 35;
            this.lbUsernameofDetails.Text = "user_name12345";
            this.lbUsernameofDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUsernameofDetails.Visible = false;
            // 
            // btEditavatar
            // 
            this.btEditavatar.BackColor = System.Drawing.Color.Transparent;
            this.btEditavatar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btEditavatar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btEditavatar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btEditavatar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btEditavatar.FillColor = System.Drawing.Color.White;
            this.btEditavatar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btEditavatar.ForeColor = System.Drawing.Color.White;
            this.btEditavatar.Image = ((System.Drawing.Image)(resources.GetObject("btEditavatar.Image")));
            this.btEditavatar.Location = new System.Drawing.Point(406, 313);
            this.btEditavatar.Name = "btEditavatar";
            this.btEditavatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btEditavatar.Size = new System.Drawing.Size(40, 40);
            this.btEditavatar.TabIndex = 36;
            this.btEditavatar.UseTransparentBackground = true;
            this.btEditavatar.Visible = false;
            this.btEditavatar.Click += new System.EventHandler(this.btEditavatar_Click);
            // 
            // OFD
            // 
            this.OFD.FileName = "Open Pictures";
            // 
            // Form_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 550);
            this.Controls.Add(this.lbUsernameofDetails);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btMaximized);
            this.Controls.Add(this.btMinimized);
            this.Controls.Add(this.btEditavatar);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbChangepassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.pbAvatarofDetails);
            this.Controls.Add(this.btEditProfile);
            this.Controls.Add(this.pbAvatar);
            this.Controls.Add(this.btJoin);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.btProfile);
            this.Controls.Add(this.btHome);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.btSetting);
            this.Controls.Add(this.pbBackgroundProfiledetails);
            this.Controls.Add(this.pbBackgroundProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Profile";
            this.Text = "Form_Profile";
            this.Load += new System.EventHandler(this.Form_Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundProfiledetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatarofDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackgroundProfile;
        private System.Windows.Forms.Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btMinimized;
        private Guna.UI2.WinForms.Guna2Button btMaximized;
        private Guna.UI2.WinForms.Guna2Button btExit;
        private Guna.UI2.WinForms.Guna2Button btSetting;
        private Guna.UI2.WinForms.Guna2Button btJoin;
        private Guna.UI2.WinForms.Guna2Button btCreate;
        private Guna.UI2.WinForms.Guna2Button btProfile;
        private Guna.UI2.WinForms.Guna2Button btHome;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAvatar;
        private Guna.UI2.WinForms.Guna2Button btEditProfile;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.PictureBox pbBackgroundProfiledetails;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAvatarofDetails;
        private Guna.UI2.WinForms.Guna2TextBox tbUsername;
        private Guna.UI2.WinForms.Guna2TextBox tbChangepassword;
        private Guna.UI2.WinForms.Guna2Button btSave;
        private Guna.UI2.WinForms.Guna2Button btAccept;
        private System.Windows.Forms.Label lbUsernameofDetails;
        private Guna.UI2.WinForms.Guna2CircleButton btEditavatar;
        private System.Windows.Forms.OpenFileDialog OFD;
    }
}