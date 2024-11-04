namespace Client
{
    partial class Form_Onlineroom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Onlineroom));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbBackgroundONLR = new System.Windows.Forms.PictureBox();
            this.btBack = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btMinimized = new Guna.UI2.WinForms.Guna2Button();
            this.btMaximized = new Guna.UI2.WinForms.Guna2Button();
            this.btExit = new Guna.UI2.WinForms.Guna2Button();
            this.btMenu = new Guna.UI2.WinForms.Guna2Button();
            this.tbEnterchat = new Guna.UI2.WinForms.Guna2TextBox();
            this.btReaction = new Guna.UI2.WinForms.Guna2Button();
            this.btUpload = new Guna.UI2.WinForms.Guna2Button();
            this.pbAV1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pbAV2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbUS1 = new System.Windows.Forms.Label();
            this.pnVideo = new System.Windows.Forms.Panel();
            this.searchResult = new System.Windows.Forms.DataGridView();
            this.btSearch = new Guna.UI2.WinForms.Guna2Button();
            this.pnTool = new System.Windows.Forms.Panel();
            this.csVideo = new ColorSlider.ColorSlider();
            this.btPause = new Guna.UI2.WinForms.Guna2Button();
            this.btMute = new Guna.UI2.WinForms.Guna2Button();
            this.csSound = new ColorSlider.ColorSlider();
            this.btPlaying = new Guna.UI2.WinForms.Guna2Button();
            this.lbMaxTime = new System.Windows.Forms.Label();
            this.lbTiming = new System.Windows.Forms.Label();
            this.btUnmute = new Guna.UI2.WinForms.Guna2Button();
            this.btBackTime = new Guna.UI2.WinForms.Guna2Button();
            this.btFowardTime = new Guna.UI2.WinForms.Guna2Button();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.Videoplayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbUS2 = new System.Windows.Forms.Label();
            this.lbUS3 = new System.Windows.Forms.Label();
            this.pbAV3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbUS4 = new System.Windows.Forms.Label();
            this.pbAV4 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbUS5 = new System.Windows.Forms.Label();
            this.pbAV5 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.tbRoomID = new System.Windows.Forms.TextBox();
            this.listView_room_users = new System.Windows.Forms.ListView();
            this.btSendMessage = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSync = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundONLR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV2)).BeginInit();
            this.pnVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchResult)).BeginInit();
            this.pnTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Videoplayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV5)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackgroundONLR
            // 
            this.pbBackgroundONLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackgroundONLR.Image = ((System.Drawing.Image)(resources.GetObject("pbBackgroundONLR.Image")));
            this.pbBackgroundONLR.Location = new System.Drawing.Point(0, 0);
            this.pbBackgroundONLR.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbBackgroundONLR.Name = "pbBackgroundONLR";
            this.pbBackgroundONLR.Size = new System.Drawing.Size(2060, 1066);
            this.pbBackgroundONLR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackgroundONLR.TabIndex = 0;
            this.pbBackgroundONLR.TabStop = false;
            this.pbBackgroundONLR.MouseEnter += new System.EventHandler(this.pbBackgroundONLR_MouseEnter);
            this.pbBackgroundONLR.MouseLeave += new System.EventHandler(this.pbBackgroundONLR_MouseLeave);
            // 
            // btBack
            // 
            this.btBack.BackColor = System.Drawing.Color.Transparent;
            this.btBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btBack.BackgroundImage")));
            this.btBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btBack.FillColor = System.Drawing.Color.Transparent;
            this.btBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btBack.ForeColor = System.Drawing.Color.White;
            this.btBack.Location = new System.Drawing.Point(42, 10);
            this.btBack.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(64, 62);
            this.btBack.TabIndex = 14;
            this.btBack.Text = "guna2Button1";
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnHeader.Location = new System.Drawing.Point(112, 0);
            this.pnHeader.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1596, 87);
            this.pnHeader.TabIndex = 13;
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
            this.btMinimized.Location = new System.Drawing.Point(1720, 19);
            this.btMinimized.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btMinimized.Name = "btMinimized";
            this.btMinimized.Size = new System.Drawing.Size(50, 48);
            this.btMinimized.TabIndex = 12;
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
            this.btMaximized.Location = new System.Drawing.Point(1856, 29);
            this.btMaximized.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btMaximized.Name = "btMaximized";
            this.btMaximized.Size = new System.Drawing.Size(30, 29);
            this.btMaximized.TabIndex = 11;
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
            this.btExit.Location = new System.Drawing.Point(1964, 23);
            this.btExit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(40, 39);
            this.btExit.TabIndex = 10;
            this.btExit.Text = "guna2Button1";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btMenu
            // 
            this.btMenu.BackColor = System.Drawing.Color.Transparent;
            this.btMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMenu.BackgroundImage")));
            this.btMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btMenu.FillColor = System.Drawing.Color.Transparent;
            this.btMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btMenu.ForeColor = System.Drawing.Color.White;
            this.btMenu.Location = new System.Drawing.Point(112, 907);
            this.btMenu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(64, 62);
            this.btMenu.TabIndex = 15;
            this.btMenu.Text = "guna2Button1";
            this.btMenu.Click += new System.EventHandler(this.btMenu_Click);
            // 
            // tbEnterchat
            // 
            this.tbEnterchat.BackColor = System.Drawing.Color.Transparent;
            this.tbEnterchat.BorderColor = System.Drawing.Color.White;
            this.tbEnterchat.BorderRadius = 10;
            this.tbEnterchat.BorderThickness = 2;
            this.tbEnterchat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbEnterchat.DefaultText = "";
            this.tbEnterchat.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbEnterchat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbEnterchat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEnterchat.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbEnterchat.FillColor = System.Drawing.Color.Transparent;
            this.tbEnterchat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEnterchat.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.tbEnterchat.ForeColor = System.Drawing.Color.White;
            this.tbEnterchat.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbEnterchat.Location = new System.Drawing.Point(1620, 922);
            this.tbEnterchat.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tbEnterchat.Name = "tbEnterchat";
            this.tbEnterchat.PasswordChar = '\0';
            this.tbEnterchat.PlaceholderForeColor = System.Drawing.Color.White;
            this.tbEnterchat.PlaceholderText = "Enter chat ...";
            this.tbEnterchat.SelectedText = "";
            this.tbEnterchat.Size = new System.Drawing.Size(384, 83);
            this.tbEnterchat.TabIndex = 16;
            this.tbEnterchat.TextOffset = new System.Drawing.Point(23, 0);
            // 
            // btReaction
            // 
            this.btReaction.BackColor = System.Drawing.Color.Black;
            this.btReaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btReaction.BackgroundImage")));
            this.btReaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btReaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btReaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btReaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btReaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btReaction.FillColor = System.Drawing.Color.Transparent;
            this.btReaction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btReaction.ForeColor = System.Drawing.Color.White;
            this.btReaction.Location = new System.Drawing.Point(1634, 934);
            this.btReaction.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btReaction.Name = "btReaction";
            this.btReaction.Size = new System.Drawing.Size(72, 62);
            this.btReaction.TabIndex = 17;
            this.btReaction.Click += new System.EventHandler(this.btReaction_Click);
            // 
            // btUpload
            // 
            this.btUpload.AutoRoundedCorners = true;
            this.btUpload.BackColor = System.Drawing.Color.Transparent;
            this.btUpload.BorderRadius = 42;
            this.btUpload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btUpload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btUpload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btUpload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btUpload.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btUpload.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btUpload.ForeColor = System.Drawing.Color.Black;
            this.btUpload.Location = new System.Drawing.Point(1276, 899);
            this.btUpload.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(256, 87);
            this.btUpload.TabIndex = 22;
            this.btUpload.Text = "Upload";
            this.btUpload.UseTransparentBackground = true;
            this.btUpload.Visible = false;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // pbAV1
            // 
            this.pbAV1.BackColor = System.Drawing.Color.Transparent;
            this.pbAV1.Image = ((System.Drawing.Image)(resources.GetObject("pbAV1.Image")));
            this.pbAV1.ImageRotate = 0F;
            this.pbAV1.InitialImage = null;
            this.pbAV1.Location = new System.Drawing.Point(246, 868);
            this.pbAV1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbAV1.Name = "pbAV1";
            this.pbAV1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAV1.Size = new System.Drawing.Size(122, 108);
            this.pbAV1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAV1.TabIndex = 23;
            this.pbAV1.TabStop = false;
            this.pbAV1.UseTransparentBackground = true;
            this.pbAV1.Visible = false;
            // 
            // pbAV2
            // 
            this.pbAV2.BackColor = System.Drawing.Color.Transparent;
            this.pbAV2.Image = ((System.Drawing.Image)(resources.GetObject("pbAV2.Image")));
            this.pbAV2.ImageRotate = 0F;
            this.pbAV2.InitialImage = null;
            this.pbAV2.Location = new System.Drawing.Point(450, 868);
            this.pbAV2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbAV2.Name = "pbAV2";
            this.pbAV2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAV2.Size = new System.Drawing.Size(122, 108);
            this.pbAV2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAV2.TabIndex = 24;
            this.pbAV2.TabStop = false;
            this.pbAV2.UseTransparentBackground = true;
            this.pbAV2.Visible = false;
            // 
            // lbUS1
            // 
            this.lbUS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbUS1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lbUS1.ForeColor = System.Drawing.Color.White;
            this.lbUS1.Location = new System.Drawing.Point(226, 984);
            this.lbUS1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbUS1.Name = "lbUS1";
            this.lbUS1.Size = new System.Drawing.Size(160, 37);
            this.lbUS1.TabIndex = 25;
            this.lbUS1.Text = "user_name12345";
            this.lbUS1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbUS1.Visible = false;
            // 
            // pnVideo
            // 
            this.pnVideo.BackColor = System.Drawing.Color.Black;
            this.pnVideo.Controls.Add(this.searchResult);
            this.pnVideo.Controls.Add(this.btSearch);
            this.pnVideo.Controls.Add(this.pnTool);
            this.pnVideo.Controls.Add(this.tbSearch);
            this.pnVideo.Controls.Add(this.Videoplayer);
            this.pnVideo.Location = new System.Drawing.Point(24, 83);
            this.pnVideo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnVideo.Name = "pnVideo";
            this.pnVideo.Size = new System.Drawing.Size(1556, 760);
            this.pnVideo.TabIndex = 36;
            // 
            // searchResult
            // 
            this.searchResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.searchResult.BackgroundColor = System.Drawing.Color.Black;
            this.searchResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.searchResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.searchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResult.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.searchResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.searchResult.Location = new System.Drawing.Point(314, 107);
            this.searchResult.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.searchResult.Name = "searchResult";
            this.searchResult.RowHeadersVisible = false;
            this.searchResult.RowHeadersWidth = 51;
            this.searchResult.RowTemplate.Height = 40;
            this.searchResult.Size = new System.Drawing.Size(904, 140);
            this.searchResult.TabIndex = 48;
            this.searchResult.Visible = false;
            this.searchResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchResult_CellClick);
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.Black;
            this.btSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSearch.BackgroundImage")));
            this.btSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSearch.FillColor = System.Drawing.Color.Transparent;
            this.btSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btSearch.ForeColor = System.Drawing.Color.White;
            this.btSearch.Location = new System.Drawing.Point(332, 27);
            this.btSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(78, 68);
            this.btSearch.TabIndex = 37;
            this.btSearch.Visible = false;
            // 
            // pnTool
            // 
            this.pnTool.BackColor = System.Drawing.Color.Black;
            this.pnTool.Controls.Add(this.btnSync);
            this.pnTool.Controls.Add(this.csVideo);
            this.pnTool.Controls.Add(this.btPause);
            this.pnTool.Controls.Add(this.btMute);
            this.pnTool.Controls.Add(this.csSound);
            this.pnTool.Controls.Add(this.btPlaying);
            this.pnTool.Controls.Add(this.lbMaxTime);
            this.pnTool.Controls.Add(this.lbTiming);
            this.pnTool.Controls.Add(this.btUnmute);
            this.pnTool.Controls.Add(this.btBackTime);
            this.pnTool.Controls.Add(this.btFowardTime);
            this.pnTool.Location = new System.Drawing.Point(0, 641);
            this.pnTool.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnTool.Name = "pnTool";
            this.pnTool.Size = new System.Drawing.Size(1556, 124);
            this.pnTool.TabIndex = 31;
            this.pnTool.Visible = false;
            // 
            // csVideo
            // 
            this.csVideo.BackColor = System.Drawing.Color.Transparent;
            this.csVideo.BarInnerColor = System.Drawing.Color.White;
            this.csVideo.BarPenColorBottom = System.Drawing.Color.White;
            this.csVideo.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.csVideo.BorderRoundRectSize = new System.Drawing.Size(12, 12);
            this.csVideo.CausesValidation = false;
            this.csVideo.DrawSemitransparentThumb = false;
            this.csVideo.ElapsedInnerColor = System.Drawing.Color.DeepSkyBlue;
            this.csVideo.ElapsedPenColorBottom = System.Drawing.Color.DeepSkyBlue;
            this.csVideo.ElapsedPenColorTop = System.Drawing.Color.DeepSkyBlue;
            this.csVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.csVideo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.csVideo.LargeChange = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.csVideo.Location = new System.Drawing.Point(314, 78);
            this.csVideo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.csVideo.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.csVideo.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.csVideo.Name = "csVideo";
            this.csVideo.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.csVideo.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.csVideo.ShowDivisionsText = true;
            this.csVideo.ShowSmallScale = false;
            this.csVideo.Size = new System.Drawing.Size(942, 54);
            this.csVideo.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.csVideo.TabIndex = 39;
            this.csVideo.Text = "colorSlider2";
            this.csVideo.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.csVideo.ThumbPenColor = System.Drawing.Color.Transparent;
            this.csVideo.ThumbRoundRectSize = new System.Drawing.Size(1, 1);
            this.csVideo.ThumbSize = new System.Drawing.Size(1, 1);
            this.csVideo.TickAdd = 0F;
            this.csVideo.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.csVideo.TickDivide = 0F;
            this.csVideo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.csVideo.Scroll += new System.Windows.Forms.ScrollEventHandler(this.csVideo_Scroll);
            this.csVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.csVideo_MouseDown);
            this.csVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.csVideo_MouseUp);
            // 
            // btPause
            // 
            this.btPause.BackColor = System.Drawing.Color.Transparent;
            this.btPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btPause.BackgroundImage")));
            this.btPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPause.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btPause.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btPause.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btPause.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btPause.FillColor = System.Drawing.Color.Transparent;
            this.btPause.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btPause.ForeColor = System.Drawing.Color.White;
            this.btPause.Location = new System.Drawing.Point(742, 10);
            this.btPause.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(66, 64);
            this.btPause.TabIndex = 41;
            this.btPause.Visible = false;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btMute
            // 
            this.btMute.BackColor = System.Drawing.Color.Transparent;
            this.btMute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMute.BackgroundImage")));
            this.btMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMute.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btMute.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btMute.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btMute.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btMute.FillColor = System.Drawing.Color.Transparent;
            this.btMute.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btMute.ForeColor = System.Drawing.Color.White;
            this.btMute.Location = new System.Drawing.Point(362, 17);
            this.btMute.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btMute.Name = "btMute";
            this.btMute.Size = new System.Drawing.Size(50, 48);
            this.btMute.TabIndex = 40;
            this.btMute.Visible = false;
            this.btMute.Click += new System.EventHandler(this.btMute_Click);
            // 
            // csSound
            // 
            this.csSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.csSound.BarInnerColor = System.Drawing.Color.DeepSkyBlue;
            this.csSound.BarPenColorBottom = System.Drawing.Color.DeepSkyBlue;
            this.csSound.BarPenColorTop = System.Drawing.Color.DeepSkyBlue;
            this.csSound.BorderRoundRectSize = new System.Drawing.Size(12, 12);
            this.csSound.CausesValidation = false;
            this.csSound.DrawSemitransparentThumb = false;
            this.csSound.ElapsedInnerColor = System.Drawing.Color.DeepSkyBlue;
            this.csSound.ElapsedPenColorBottom = System.Drawing.Color.DeepSkyBlue;
            this.csSound.ElapsedPenColorTop = System.Drawing.Color.DeepSkyBlue;
            this.csSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.csSound.ForeColor = System.Drawing.Color.White;
            this.csSound.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.csSound.Location = new System.Drawing.Point(422, 14);
            this.csSound.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.csSound.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.csSound.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.csSound.Name = "csSound";
            this.csSound.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.csSound.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.csSound.ShowDivisionsText = true;
            this.csSound.ShowSmallScale = false;
            this.csSound.Size = new System.Drawing.Size(180, 56);
            this.csSound.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.csSound.TabIndex = 43;
            this.csSound.Text = "colorSlider1";
            this.csSound.ThumbInnerColor = System.Drawing.Color.White;
            this.csSound.ThumbPenColor = System.Drawing.Color.Transparent;
            this.csSound.ThumbRoundRectSize = new System.Drawing.Size(12, 12);
            this.csSound.ThumbSize = new System.Drawing.Size(12, 12);
            this.csSound.TickAdd = 0F;
            this.csSound.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.csSound.TickDivide = 0F;
            this.csSound.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.csSound.ValueChanged += new System.EventHandler(this.csSound_ValueChanged);
            this.csSound.Scroll += new System.Windows.Forms.ScrollEventHandler(this.csSound_Scroll);
            // 
            // btPlaying
            // 
            this.btPlaying.BackColor = System.Drawing.Color.Transparent;
            this.btPlaying.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btPlaying.BackgroundImage")));
            this.btPlaying.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPlaying.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btPlaying.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btPlaying.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btPlaying.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btPlaying.FillColor = System.Drawing.Color.Transparent;
            this.btPlaying.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btPlaying.ForeColor = System.Drawing.Color.White;
            this.btPlaying.Location = new System.Drawing.Point(742, 10);
            this.btPlaying.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btPlaying.Name = "btPlaying";
            this.btPlaying.Size = new System.Drawing.Size(66, 64);
            this.btPlaying.TabIndex = 41;
            this.btPlaying.Visible = false;
            this.btPlaying.Click += new System.EventHandler(this.btPlaying_Click);
            // 
            // lbMaxTime
            // 
            this.lbMaxTime.AutoSize = true;
            this.lbMaxTime.ForeColor = System.Drawing.Color.White;
            this.lbMaxTime.Location = new System.Drawing.Point(1268, 85);
            this.lbMaxTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbMaxTime.Name = "lbMaxTime";
            this.lbMaxTime.Size = new System.Drawing.Size(86, 32);
            this.lbMaxTime.TabIndex = 1;
            this.lbMaxTime.Text = "00:00";
            // 
            // lbTiming
            // 
            this.lbTiming.AutoSize = true;
            this.lbTiming.ForeColor = System.Drawing.Color.White;
            this.lbTiming.Location = new System.Drawing.Point(192, 85);
            this.lbTiming.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTiming.Name = "lbTiming";
            this.lbTiming.Size = new System.Drawing.Size(86, 32);
            this.lbTiming.TabIndex = 0;
            this.lbTiming.Text = "00:00";
            this.lbTiming.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btUnmute
            // 
            this.btUnmute.BackColor = System.Drawing.Color.Transparent;
            this.btUnmute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btUnmute.BackgroundImage")));
            this.btUnmute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btUnmute.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btUnmute.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btUnmute.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btUnmute.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btUnmute.FillColor = System.Drawing.Color.Transparent;
            this.btUnmute.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btUnmute.ForeColor = System.Drawing.Color.White;
            this.btUnmute.Location = new System.Drawing.Point(362, 17);
            this.btUnmute.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btUnmute.Name = "btUnmute";
            this.btUnmute.Size = new System.Drawing.Size(50, 48);
            this.btUnmute.TabIndex = 35;
            this.btUnmute.Click += new System.EventHandler(this.btUnmute_Click);
            // 
            // btBackTime
            // 
            this.btBackTime.BackColor = System.Drawing.Color.Transparent;
            this.btBackTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btBackTime.BackgroundImage")));
            this.btBackTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btBackTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btBackTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btBackTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btBackTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btBackTime.FillColor = System.Drawing.Color.Transparent;
            this.btBackTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btBackTime.ForeColor = System.Drawing.Color.White;
            this.btBackTime.Location = new System.Drawing.Point(658, 14);
            this.btBackTime.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btBackTime.Name = "btBackTime";
            this.btBackTime.Size = new System.Drawing.Size(60, 58);
            this.btBackTime.TabIndex = 2;
            this.btBackTime.UseTransparentBackground = true;
            this.btBackTime.Visible = false;
            this.btBackTime.Click += new System.EventHandler(this.btBackTime_Click);
            // 
            // btFowardTime
            // 
            this.btFowardTime.BackColor = System.Drawing.Color.Transparent;
            this.btFowardTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btFowardTime.BackgroundImage")));
            this.btFowardTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btFowardTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btFowardTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btFowardTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btFowardTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btFowardTime.FillColor = System.Drawing.Color.Transparent;
            this.btFowardTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btFowardTime.ForeColor = System.Drawing.Color.White;
            this.btFowardTime.Location = new System.Drawing.Point(828, 14);
            this.btFowardTime.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btFowardTime.Name = "btFowardTime";
            this.btFowardTime.Size = new System.Drawing.Size(60, 58);
            this.btFowardTime.TabIndex = 1;
            this.btFowardTime.UseTransparentBackground = true;
            this.btFowardTime.Visible = false;
            this.btFowardTime.Click += new System.EventHandler(this.btFowardTime_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.AutoRoundedCorners = true;
            this.tbSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.tbSearch.BorderRadius = 40;
            this.tbSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearch.DefaultText = "";
            this.tbSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.FillColor = System.Drawing.Color.Black;
            this.tbSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.tbSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearch.Location = new System.Drawing.Point(314, 17);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PasswordChar = '\0';
            this.tbSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.tbSearch.PlaceholderText = "What do you want to play?";
            this.tbSearch.SelectedText = "";
            this.tbSearch.Size = new System.Drawing.Size(912, 83);
            this.tbSearch.TabIndex = 38;
            this.tbSearch.TextOffset = new System.Drawing.Point(25, 0);
            this.tbSearch.Visible = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // Videoplayer
            // 
            this.Videoplayer.Enabled = true;
            this.Videoplayer.Location = new System.Drawing.Point(-13, 0);
            this.Videoplayer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Videoplayer.Name = "Videoplayer";
            this.Videoplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Videoplayer.OcxState")));
            this.Videoplayer.Size = new System.Drawing.Size(616, 395);
            this.Videoplayer.TabIndex = 32;
            // 
            // OFD
            // 
            this.OFD.FileName = "Open File";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbUS2
            // 
            this.lbUS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbUS2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lbUS2.ForeColor = System.Drawing.Color.White;
            this.lbUS2.Location = new System.Drawing.Point(432, 984);
            this.lbUS2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbUS2.Name = "lbUS2";
            this.lbUS2.Size = new System.Drawing.Size(160, 37);
            this.lbUS2.TabIndex = 37;
            this.lbUS2.Text = "user_name12345";
            this.lbUS2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbUS2.Visible = false;
            // 
            // lbUS3
            // 
            this.lbUS3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbUS3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lbUS3.ForeColor = System.Drawing.Color.White;
            this.lbUS3.Location = new System.Drawing.Point(638, 984);
            this.lbUS3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbUS3.Name = "lbUS3";
            this.lbUS3.Size = new System.Drawing.Size(160, 37);
            this.lbUS3.TabIndex = 39;
            this.lbUS3.Text = "user_name12345";
            this.lbUS3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbUS3.Visible = false;
            // 
            // pbAV3
            // 
            this.pbAV3.BackColor = System.Drawing.Color.Transparent;
            this.pbAV3.Image = ((System.Drawing.Image)(resources.GetObject("pbAV3.Image")));
            this.pbAV3.ImageRotate = 0F;
            this.pbAV3.InitialImage = null;
            this.pbAV3.Location = new System.Drawing.Point(656, 868);
            this.pbAV3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbAV3.Name = "pbAV3";
            this.pbAV3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAV3.Size = new System.Drawing.Size(122, 108);
            this.pbAV3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAV3.TabIndex = 38;
            this.pbAV3.TabStop = false;
            this.pbAV3.UseTransparentBackground = true;
            this.pbAV3.Visible = false;
            // 
            // lbUS4
            // 
            this.lbUS4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbUS4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lbUS4.ForeColor = System.Drawing.Color.White;
            this.lbUS4.Location = new System.Drawing.Point(840, 984);
            this.lbUS4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbUS4.Name = "lbUS4";
            this.lbUS4.Size = new System.Drawing.Size(160, 37);
            this.lbUS4.TabIndex = 41;
            this.lbUS4.Text = "user_name12345";
            this.lbUS4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbUS4.Visible = false;
            // 
            // pbAV4
            // 
            this.pbAV4.BackColor = System.Drawing.Color.Transparent;
            this.pbAV4.Image = ((System.Drawing.Image)(resources.GetObject("pbAV4.Image")));
            this.pbAV4.ImageRotate = 0F;
            this.pbAV4.InitialImage = null;
            this.pbAV4.Location = new System.Drawing.Point(858, 868);
            this.pbAV4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbAV4.Name = "pbAV4";
            this.pbAV4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAV4.Size = new System.Drawing.Size(122, 108);
            this.pbAV4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAV4.TabIndex = 40;
            this.pbAV4.TabStop = false;
            this.pbAV4.UseTransparentBackground = true;
            this.pbAV4.Visible = false;
            // 
            // lbUS5
            // 
            this.lbUS5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbUS5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lbUS5.ForeColor = System.Drawing.Color.White;
            this.lbUS5.Location = new System.Drawing.Point(1044, 984);
            this.lbUS5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbUS5.Name = "lbUS5";
            this.lbUS5.Size = new System.Drawing.Size(160, 37);
            this.lbUS5.TabIndex = 43;
            this.lbUS5.Text = "user_name12345";
            this.lbUS5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbUS5.Visible = false;
            // 
            // pbAV5
            // 
            this.pbAV5.BackColor = System.Drawing.Color.Transparent;
            this.pbAV5.Image = ((System.Drawing.Image)(resources.GetObject("pbAV5.Image")));
            this.pbAV5.ImageRotate = 0F;
            this.pbAV5.InitialImage = null;
            this.pbAV5.Location = new System.Drawing.Point(1062, 868);
            this.pbAV5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pbAV5.Name = "pbAV5";
            this.pbAV5.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbAV5.Size = new System.Drawing.Size(122, 108);
            this.pbAV5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAV5.TabIndex = 42;
            this.pbAV5.TabStop = false;
            this.pbAV5.UseTransparentBackground = true;
            this.pbAV5.Visible = false;
            // 
            // tbRoomName
            // 
            this.tbRoomName.BackColor = System.Drawing.Color.Black;
            this.tbRoomName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRoomName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRoomName.ForeColor = System.Drawing.Color.White;
            this.tbRoomName.Location = new System.Drawing.Point(646, 8);
            this.tbRoomName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbRoomName.Multiline = true;
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.ReadOnly = true;
            this.tbRoomName.Size = new System.Drawing.Size(292, 62);
            this.tbRoomName.TabIndex = 53;
            this.tbRoomName.Text = "Room_name";
            this.tbRoomName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRoomID
            // 
            this.tbRoomID.BackColor = System.Drawing.Color.Black;
            this.tbRoomID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRoomID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRoomID.ForeColor = System.Drawing.Color.White;
            this.tbRoomID.Location = new System.Drawing.Point(1044, 27);
            this.tbRoomID.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbRoomID.Name = "tbRoomID";
            this.tbRoomID.ReadOnly = true;
            this.tbRoomID.Size = new System.Drawing.Size(98, 40);
            this.tbRoomID.TabIndex = 52;
            this.tbRoomID.Text = "1234";
            this.tbRoomID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listView_room_users
            // 
            this.listView_room_users.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.listView_room_users.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_room_users.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_room_users.ForeColor = System.Drawing.Color.Black;
            this.listView_room_users.HideSelection = false;
            this.listView_room_users.Location = new System.Drawing.Point(210, 725);
            this.listView_room_users.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listView_room_users.Name = "listView_room_users";
            this.listView_room_users.Size = new System.Drawing.Size(242, 296);
            this.listView_room_users.TabIndex = 51;
            this.listView_room_users.UseCompatibleStateImageBehavior = false;
            this.listView_room_users.View = System.Windows.Forms.View.List;
            this.listView_room_users.Visible = false;
            // 
            // btSendMessage
            // 
            this.btSendMessage.BackColor = System.Drawing.Color.Black;
            this.btSendMessage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btSendMessage.BackgroundImage")));
            this.btSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSendMessage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSendMessage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSendMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSendMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSendMessage.FillColor = System.Drawing.Color.Transparent;
            this.btSendMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btSendMessage.ForeColor = System.Drawing.Color.White;
            this.btSendMessage.Location = new System.Drawing.Point(1932, 942);
            this.btSendMessage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btSendMessage.Name = "btSendMessage";
            this.btSendMessage.Size = new System.Drawing.Size(52, 43);
            this.btSendMessage.TabIndex = 54;
            this.btSendMessage.Click += new System.EventHandler(this.btSendMessage_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(1604, 161);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel.Size = new System.Drawing.Size(406, 738);
            this.flowLayoutPanel.TabIndex = 55;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // btnSync
            // 
            this.btnSync.BackColor = System.Drawing.Color.Transparent;
            this.btnSync.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSync.BackgroundImage")));
            this.btnSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSync.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSync.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSync.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSync.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSync.FillColor = System.Drawing.Color.Transparent;
            this.btnSync.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSync.ForeColor = System.Drawing.Color.White;
            this.btnSync.Location = new System.Drawing.Point(900, 8);
            this.btnSync.Margin = new System.Windows.Forms.Padding(6);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(66, 64);
            this.btnSync.TabIndex = 44;
            this.btnSync.Visible = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // Form_Onlineroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2060, 1066);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.btSendMessage);
            this.Controls.Add(this.listView_room_users);
            this.Controls.Add(this.tbRoomName);
            this.Controls.Add(this.lbUS5);
            this.Controls.Add(this.tbRoomID);
            this.Controls.Add(this.pbAV5);
            this.Controls.Add(this.lbUS4);
            this.Controls.Add(this.pbAV4);
            this.Controls.Add(this.lbUS3);
            this.Controls.Add(this.pbAV3);
            this.Controls.Add(this.lbUS2);
            this.Controls.Add(this.pnVideo);
            this.Controls.Add(this.lbUS1);
            this.Controls.Add(this.pbAV2);
            this.Controls.Add(this.pbAV1);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.btReaction);
            this.Controls.Add(this.tbEnterchat);
            this.Controls.Add(this.btMenu);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btMinimized);
            this.Controls.Add(this.btMaximized);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.pbBackgroundONLR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form_Onlineroom";
            this.Text = "Form_Onlineroom";
            this.Load += new System.EventHandler(this.Form_Onlineroom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundONLR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV2)).EndInit();
            this.pnVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchResult)).EndInit();
            this.pnTool.ResumeLayout(false);
            this.pnTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Videoplayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAV5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackgroundONLR;
        private Guna.UI2.WinForms.Guna2Button btBack;
        private System.Windows.Forms.Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btMinimized;
        private Guna.UI2.WinForms.Guna2Button btMaximized;
        private Guna.UI2.WinForms.Guna2Button btExit;
        private Guna.UI2.WinForms.Guna2Button btMenu;
        private Guna.UI2.WinForms.Guna2TextBox tbEnterchat;
        private Guna.UI2.WinForms.Guna2Button btReaction;
        private Guna.UI2.WinForms.Guna2Button btUpload;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAV1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAV2;
        private System.Windows.Forms.Label lbUS1;
        private System.Windows.Forms.Panel pnVideo;
        private System.Windows.Forms.Panel pnTool;
        private ColorSlider.ColorSlider csVideo;
        private Guna.UI2.WinForms.Guna2Button btPause;
        private Guna.UI2.WinForms.Guna2Button btMute;
        private ColorSlider.ColorSlider csSound;
        private Guna.UI2.WinForms.Guna2Button btPlaying;
        private System.Windows.Forms.Label lbMaxTime;
        private System.Windows.Forms.Label lbTiming;
        private Guna.UI2.WinForms.Guna2Button btUnmute;
        private Guna.UI2.WinForms.Guna2Button btBackTime;
        private Guna.UI2.WinForms.Guna2Button btFowardTime;
        private AxWMPLib.AxWindowsMediaPlayer Videoplayer;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button btSearch;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private System.Windows.Forms.DataGridView searchResult;
        private System.Windows.Forms.Label lbUS2;
        private System.Windows.Forms.Label lbUS3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAV3;
        private System.Windows.Forms.Label lbUS4;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAV4;
        private System.Windows.Forms.Label lbUS5;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbAV5;
        private System.Windows.Forms.TextBox tbRoomName;
        private System.Windows.Forms.TextBox tbRoomID;
        private System.Windows.Forms.ListView listView_room_users;
        private Guna.UI2.WinForms.Guna2Button btSendMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private Guna.UI2.WinForms.Guna2Button btnSync;
    }
}