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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Onlineroom));
            this.pbBackgroundORoom = new System.Windows.Forms.PictureBox();
            this.btBack = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lbID = new System.Windows.Forms.Label();
            this.btMinimized = new Guna.UI2.WinForms.Guna2Button();
            this.btMaximized = new Guna.UI2.WinForms.Guna2Button();
            this.btExit = new Guna.UI2.WinForms.Guna2Button();
            this.btMenu = new Guna.UI2.WinForms.Guna2Button();
            this.tbEnterchat = new Guna.UI2.WinForms.Guna2TextBox();
            this.btReaction = new Guna.UI2.WinForms.Guna2Button();
            this.btSearch = new Guna.UI2.WinForms.Guna2Button();
            this.tbSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btUpload = new Guna.UI2.WinForms.Guna2Button();
            this.pbFirstavatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btSecondavatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbFirstusername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRoomname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundORoom)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstavatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSecondavatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackgroundORoom
            // 
            this.pbBackgroundORoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackgroundORoom.Image = ((System.Drawing.Image)(resources.GetObject("pbBackgroundORoom.Image")));
            this.pbBackgroundORoom.Location = new System.Drawing.Point(0, 0);
            this.pbBackgroundORoom.Name = "pbBackgroundORoom";
            this.pbBackgroundORoom.Size = new System.Drawing.Size(1030, 550);
            this.pbBackgroundORoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackgroundORoom.TabIndex = 0;
            this.pbBackgroundORoom.TabStop = false;
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
            this.btBack.TabIndex = 14;
            this.btBack.Text = "guna2Button1";
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnHeader.Controls.Add(this.lbRoomname);
            this.pnHeader.Controls.Add(this.lbID);
            this.pnHeader.Location = new System.Drawing.Point(56, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(798, 45);
            this.pnHeader.TabIndex = 13;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbID.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.lbID.ForeColor = System.Drawing.Color.White;
            this.lbID.Location = new System.Drawing.Point(465, 14);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(49, 15);
            this.lbID.TabIndex = 27;
            this.lbID.Text = "123456";
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
            this.btMaximized.Location = new System.Drawing.Point(928, 15);
            this.btMaximized.Name = "btMaximized";
            this.btMaximized.Size = new System.Drawing.Size(15, 15);
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
            this.btExit.Location = new System.Drawing.Point(982, 12);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(20, 20);
            this.btExit.TabIndex = 10;
            this.btExit.Text = "guna2Button1";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btMenu
            // 
            this.btMenu.BackColor = System.Drawing.Color.Transparent;
            this.btMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMenu.BackgroundImage")));
            this.btMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btMenu.FillColor = System.Drawing.Color.Transparent;
            this.btMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btMenu.ForeColor = System.Drawing.Color.White;
            this.btMenu.Location = new System.Drawing.Point(56, 461);
            this.btMenu.Name = "btMenu";
            this.btMenu.Size = new System.Drawing.Size(32, 32);
            this.btMenu.TabIndex = 15;
            this.btMenu.Text = "guna2Button1";
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
            this.tbEnterchat.Location = new System.Drawing.Point(810, 461);
            this.tbEnterchat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbEnterchat.Name = "tbEnterchat";
            this.tbEnterchat.PasswordChar = '\0';
            this.tbEnterchat.PlaceholderForeColor = System.Drawing.Color.White;
            this.tbEnterchat.PlaceholderText = "Enter chat ...";
            this.tbEnterchat.SelectedText = "";
            this.tbEnterchat.Size = new System.Drawing.Size(192, 43);
            this.tbEnterchat.TabIndex = 16;
            this.tbEnterchat.TextOffset = new System.Drawing.Point(23, 0);
            // 
            // btReaction
            // 
            this.btReaction.BackColor = System.Drawing.Color.Black;
            this.btReaction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btReaction.BackgroundImage")));
            this.btReaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btReaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btReaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btReaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btReaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btReaction.FillColor = System.Drawing.Color.Transparent;
            this.btReaction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btReaction.ForeColor = System.Drawing.Color.White;
            this.btReaction.Location = new System.Drawing.Point(816, 466);
            this.btReaction.Name = "btReaction";
            this.btReaction.Size = new System.Drawing.Size(36, 32);
            this.btReaction.TabIndex = 17;
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
            this.btSearch.Location = new System.Drawing.Point(106, 60);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(31, 28);
            this.btSearch.TabIndex = 18;
            // 
            // tbSearch
            // 
            this.tbSearch.AutoRoundedCorners = true;
            this.tbSearch.BackColor = System.Drawing.Color.Transparent;
            this.tbSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.tbSearch.BorderRadius = 21;
            this.tbSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearch.DefaultText = "";
            this.tbSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearch.FillColor = System.Drawing.Color.Black;
            this.tbSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.tbSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearch.Location = new System.Drawing.Point(96, 50);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PasswordChar = '\0';
            this.tbSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.tbSearch.PlaceholderText = "What do you want to play?";
            this.tbSearch.SelectedText = "";
            this.tbSearch.Size = new System.Drawing.Size(497, 45);
            this.tbSearch.TabIndex = 19;
            this.tbSearch.TextOffset = new System.Drawing.Point(30, 0);
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
            this.btUpload.Location = new System.Drawing.Point(596, 52);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(128, 45);
            this.btUpload.TabIndex = 22;
            this.btUpload.Text = "Upload";
            this.btUpload.UseTransparentBackground = true;
            // 
            // pbFirstavatar
            // 
            this.pbFirstavatar.BackColor = System.Drawing.Color.Transparent;
            this.pbFirstavatar.Image = ((System.Drawing.Image)(resources.GetObject("pbFirstavatar.Image")));
            this.pbFirstavatar.ImageRotate = 0F;
            this.pbFirstavatar.InitialImage = null;
            this.pbFirstavatar.Location = new System.Drawing.Point(123, 448);
            this.pbFirstavatar.Name = "pbFirstavatar";
            this.pbFirstavatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbFirstavatar.Size = new System.Drawing.Size(61, 56);
            this.pbFirstavatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFirstavatar.TabIndex = 23;
            this.pbFirstavatar.TabStop = false;
            this.pbFirstavatar.UseTransparentBackground = true;
            this.pbFirstavatar.Click += new System.EventHandler(this.pbAvatar_Click);
            // 
            // btSecondavatar
            // 
            this.btSecondavatar.BackColor = System.Drawing.Color.Transparent;
            this.btSecondavatar.Image = ((System.Drawing.Image)(resources.GetObject("btSecondavatar.Image")));
            this.btSecondavatar.ImageRotate = 0F;
            this.btSecondavatar.InitialImage = null;
            this.btSecondavatar.Location = new System.Drawing.Point(225, 448);
            this.btSecondavatar.Name = "btSecondavatar";
            this.btSecondavatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btSecondavatar.Size = new System.Drawing.Size(61, 56);
            this.btSecondavatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btSecondavatar.TabIndex = 24;
            this.btSecondavatar.TabStop = false;
            this.btSecondavatar.UseTransparentBackground = true;
            // 
            // lbFirstusername
            // 
            this.lbFirstusername.AutoSize = true;
            this.lbFirstusername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbFirstusername.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lbFirstusername.ForeColor = System.Drawing.Color.White;
            this.lbFirstusername.Location = new System.Drawing.Point(128, 508);
            this.lbFirstusername.Name = "lbFirstusername";
            this.lbFirstusername.Size = new System.Drawing.Size(51, 19);
            this.lbFirstusername.TabIndex = 25;
            this.lbFirstusername.Text = "ovapil";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(224, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "miranee";
            // 
            // lbRoomname
            // 
            this.lbRoomname.AutoSize = true;
            this.lbRoomname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lbRoomname.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbRoomname.ForeColor = System.Drawing.Color.White;
            this.lbRoomname.Location = new System.Drawing.Point(249, 6);
            this.lbRoomname.Name = "lbRoomname";
            this.lbRoomname.Size = new System.Drawing.Size(154, 32);
            this.lbRoomname.TabIndex = 28;
            this.lbRoomname.Text = "Room_name";
            // 
            // Form_Onlineroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFirstusername);
            this.Controls.Add(this.btSecondavatar);
            this.Controls.Add(this.pbFirstavatar);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btReaction);
            this.Controls.Add(this.tbEnterchat);
            this.Controls.Add(this.btMenu);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btMinimized);
            this.Controls.Add(this.btMaximized);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.pbBackgroundORoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Onlineroom";
            this.Text = "Form_Onlineroom";
            this.Load += new System.EventHandler(this.Form_Onlineroom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundORoom)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstavatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSecondavatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackgroundORoom;
        private Guna.UI2.WinForms.Guna2Button btBack;
        private System.Windows.Forms.Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btMinimized;
        private Guna.UI2.WinForms.Guna2Button btMaximized;
        private Guna.UI2.WinForms.Guna2Button btExit;
        private Guna.UI2.WinForms.Guna2Button btMenu;
        private Guna.UI2.WinForms.Guna2TextBox tbEnterchat;
        private Guna.UI2.WinForms.Guna2Button btReaction;
        private Guna.UI2.WinForms.Guna2Button btSearch;
        private Guna.UI2.WinForms.Guna2TextBox tbSearch;
        private Guna.UI2.WinForms.Guna2Button btUpload;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbFirstavatar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btSecondavatar;
        private System.Windows.Forms.Label lbFirstusername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbRoomname;
    }
}