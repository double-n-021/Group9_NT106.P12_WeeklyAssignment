namespace Client
{
    partial class Form_room
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_room));
            this.pbBackgroundOFFR = new System.Windows.Forms.PictureBox();
            this.btBack = new Guna.UI2.WinForms.Guna2Button();
            this.btMinimized = new Guna.UI2.WinForms.Guna2Button();
            this.btMaximized = new Guna.UI2.WinForms.Guna2Button();
            this.btExit = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btUpload = new Guna.UI2.WinForms.Guna2Button();
            this.pnVideo = new System.Windows.Forms.Panel();
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
            this.Videoplayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundOFFR)).BeginInit();
            this.pnVideo.SuspendLayout();
            this.pnTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Videoplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackgroundOFFR
            // 
            this.pbBackgroundOFFR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackgroundOFFR.Image = ((System.Drawing.Image)(resources.GetObject("pbBackgroundOFFR.Image")));
            this.pbBackgroundOFFR.Location = new System.Drawing.Point(0, 0);
            this.pbBackgroundOFFR.Name = "pbBackgroundOFFR";
            this.pbBackgroundOFFR.Size = new System.Drawing.Size(1030, 550);
            this.pbBackgroundOFFR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackgroundOFFR.TabIndex = 0;
            this.pbBackgroundOFFR.TabStop = false;
            this.pbBackgroundOFFR.MouseEnter += new System.EventHandler(this.pbBackgroundOFFR_MouseEnter);
            this.pbBackgroundOFFR.MouseLeave += new System.EventHandler(this.pbBackgroundOFFR_MouseLeave);
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
            this.btBack.Location = new System.Drawing.Point(21, 5);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(32, 32);
            this.btBack.TabIndex = 19;
            this.btBack.Text = "guna2Button1";
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
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
            this.btMinimized.Location = new System.Drawing.Point(860, 10);
            this.btMinimized.Name = "btMinimized";
            this.btMinimized.Size = new System.Drawing.Size(25, 25);
            this.btMinimized.TabIndex = 17;
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
            this.btMaximized.Location = new System.Drawing.Point(928, 15);
            this.btMaximized.Name = "btMaximized";
            this.btMaximized.Size = new System.Drawing.Size(15, 15);
            this.btMaximized.TabIndex = 16;
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
            this.btExit.Location = new System.Drawing.Point(982, 12);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(20, 20);
            this.btExit.TabIndex = 15;
            this.btExit.Text = "guna2Button1";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnHeader.Location = new System.Drawing.Point(56, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(798, 45);
            this.pnHeader.TabIndex = 18;
            // 
            // btUpload
            // 
            this.btUpload.AutoRoundedCorners = true;
            this.btUpload.BackColor = System.Drawing.Color.Transparent;
            this.btUpload.BorderRadius = 21;
            this.btUpload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btUpload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btUpload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btUpload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btUpload.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btUpload.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btUpload.ForeColor = System.Drawing.Color.Black;
            this.btUpload.Location = new System.Drawing.Point(638, 464);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(128, 45);
            this.btUpload.TabIndex = 33;
            this.btUpload.Text = "Upload";
            this.btUpload.UseTransparentBackground = true;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // pnVideo
            // 
            this.pnVideo.BackColor = System.Drawing.Color.Black;
            this.pnVideo.Controls.Add(this.pnTool);
            this.pnVideo.Controls.Add(this.Videoplayer);
            this.pnVideo.Location = new System.Drawing.Point(12, 43);
            this.pnVideo.Name = "pnVideo";
            this.pnVideo.Size = new System.Drawing.Size(778, 392);
            this.pnVideo.TabIndex = 35;
            // 
            // pnTool
            // 
            this.pnTool.BackColor = System.Drawing.Color.Black;
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
            this.pnTool.Location = new System.Drawing.Point(0, 331);
            this.pnTool.Name = "pnTool";
            this.pnTool.Size = new System.Drawing.Size(778, 64);
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
            this.csVideo.Location = new System.Drawing.Point(157, 40);
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
            this.csVideo.Size = new System.Drawing.Size(471, 28);
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
            this.btPause.Location = new System.Drawing.Point(371, 5);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(33, 33);
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
            this.btMute.Location = new System.Drawing.Point(181, 9);
            this.btMute.Name = "btMute";
            this.btMute.Size = new System.Drawing.Size(25, 25);
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
            this.csSound.Location = new System.Drawing.Point(211, 7);
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
            this.csSound.Size = new System.Drawing.Size(90, 29);
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
            this.btPlaying.Location = new System.Drawing.Point(371, 5);
            this.btPlaying.Name = "btPlaying";
            this.btPlaying.Size = new System.Drawing.Size(33, 33);
            this.btPlaying.TabIndex = 41;
            this.btPlaying.Click += new System.EventHandler(this.btPlaying_Click);
            // 
            // lbMaxTime
            // 
            this.lbMaxTime.AutoSize = true;
            this.lbMaxTime.ForeColor = System.Drawing.Color.White;
            this.lbMaxTime.Location = new System.Drawing.Point(634, 44);
            this.lbMaxTime.Name = "lbMaxTime";
            this.lbMaxTime.Size = new System.Drawing.Size(38, 16);
            this.lbMaxTime.TabIndex = 1;
            this.lbMaxTime.Text = "00:00";
            // 
            // lbTiming
            // 
            this.lbTiming.AutoSize = true;
            this.lbTiming.ForeColor = System.Drawing.Color.White;
            this.lbTiming.Location = new System.Drawing.Point(96, 44);
            this.lbTiming.Name = "lbTiming";
            this.lbTiming.Size = new System.Drawing.Size(38, 16);
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
            this.btUnmute.Location = new System.Drawing.Point(181, 9);
            this.btUnmute.Name = "btUnmute";
            this.btUnmute.Size = new System.Drawing.Size(25, 25);
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
            this.btBackTime.Location = new System.Drawing.Point(329, 7);
            this.btBackTime.Name = "btBackTime";
            this.btBackTime.Size = new System.Drawing.Size(30, 30);
            this.btBackTime.TabIndex = 2;
            this.btBackTime.UseTransparentBackground = true;
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
            this.btFowardTime.Location = new System.Drawing.Point(414, 7);
            this.btFowardTime.Name = "btFowardTime";
            this.btFowardTime.Size = new System.Drawing.Size(30, 30);
            this.btFowardTime.TabIndex = 1;
            this.btFowardTime.UseTransparentBackground = true;
            this.btFowardTime.Click += new System.EventHandler(this.btFowardTime_Click);
            // 
            // Videoplayer
            // 
            this.Videoplayer.Enabled = true;
            this.Videoplayer.Location = new System.Drawing.Point(-13, 0);
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
            // Form_room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 550);
            this.Controls.Add(this.pnVideo);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btMinimized);
            this.Controls.Add(this.btMaximized);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.pbBackgroundOFFR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_room";
            this.Text = "Form_Offlineroom";
            this.Load += new System.EventHandler(this.Form_Offlineroom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundOFFR)).EndInit();
            this.pnVideo.ResumeLayout(false);
            this.pnTool.ResumeLayout(false);
            this.pnTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Videoplayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackgroundOFFR;
        private Guna.UI2.WinForms.Guna2Button btBack;
        private Guna.UI2.WinForms.Guna2Button btMinimized;
        private Guna.UI2.WinForms.Guna2Button btMaximized;
        private Guna.UI2.WinForms.Guna2Button btExit;
        private System.Windows.Forms.Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btUpload;
        private System.Windows.Forms.Panel pnVideo;
        private System.Windows.Forms.Panel pnTool;
        private Guna.UI2.WinForms.Guna2Button btPause;
        private Guna.UI2.WinForms.Guna2Button btPlaying;
        private Guna.UI2.WinForms.Guna2Button btMute;
        private System.Windows.Forms.Label lbMaxTime;
        private System.Windows.Forms.Label lbTiming;
        private Guna.UI2.WinForms.Guna2Button btUnmute;
        private Guna.UI2.WinForms.Guna2Button btBackTime;
        private Guna.UI2.WinForms.Guna2Button btFowardTime;
        private ColorSlider.ColorSlider csSound;
        private ColorSlider.ColorSlider csVideo;
        private AxWMPLib.AxWindowsMediaPlayer Videoplayer;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.Timer timer1;
    }
}