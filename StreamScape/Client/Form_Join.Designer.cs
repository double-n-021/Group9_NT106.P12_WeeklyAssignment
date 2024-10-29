namespace Client
{
    partial class Form_Join
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Join));
            this.pbBackgroundJoin = new System.Windows.Forms.PictureBox();
            this.btBack = new Guna.UI2.WinForms.Guna2Button();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btMinimized = new Guna.UI2.WinForms.Guna2Button();
            this.btMaximized = new Guna.UI2.WinForms.Guna2Button();
            this.btExit = new Guna.UI2.WinForms.Guna2Button();
            this.tbIDofRoom = new Guna.UI2.WinForms.Guna2TextBox();
            this.btJoin = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundJoin)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackgroundJoin
            // 
            this.pbBackgroundJoin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackgroundJoin.Image = ((System.Drawing.Image)(resources.GetObject("pbBackgroundJoin.Image")));
            this.pbBackgroundJoin.Location = new System.Drawing.Point(0, 0);
            this.pbBackgroundJoin.Name = "pbBackgroundJoin";
            this.pbBackgroundJoin.Size = new System.Drawing.Size(1030, 550);
            this.pbBackgroundJoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackgroundJoin.TabIndex = 0;
            this.pbBackgroundJoin.TabStop = false;
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
            this.btBack.TabIndex = 24;
            this.btBack.Text = "guna2Button1";
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnHeader.Location = new System.Drawing.Point(56, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(798, 45);
            this.pnHeader.TabIndex = 23;
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
            this.btMinimized.TabIndex = 22;
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
            this.btMaximized.TabIndex = 21;
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
            this.btExit.TabIndex = 20;
            this.btExit.Text = "guna2Button1";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // tbIDofRoom
            // 
            this.tbIDofRoom.BackColor = System.Drawing.Color.Black;
            this.tbIDofRoom.BorderColor = System.Drawing.Color.White;
            this.tbIDofRoom.BorderRadius = 10;
            this.tbIDofRoom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbIDofRoom.DefaultText = "";
            this.tbIDofRoom.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbIDofRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbIDofRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbIDofRoom.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbIDofRoom.FillColor = System.Drawing.Color.Transparent;
            this.tbIDofRoom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbIDofRoom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbIDofRoom.ForeColor = System.Drawing.Color.White;
            this.tbIDofRoom.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbIDofRoom.Location = new System.Drawing.Point(413, 244);
            this.tbIDofRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbIDofRoom.Name = "tbIDofRoom";
            this.tbIDofRoom.PasswordChar = '\0';
            this.tbIDofRoom.PlaceholderText = "";
            this.tbIDofRoom.SelectedText = "";
            this.tbIDofRoom.Size = new System.Drawing.Size(229, 48);
            this.tbIDofRoom.TabIndex = 25;
            // 
            // btJoin
            // 
            this.btJoin.AutoRoundedCorners = true;
            this.btJoin.BackColor = System.Drawing.Color.Transparent;
            this.btJoin.BorderRadius = 21;
            this.btJoin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btJoin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btJoin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btJoin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btJoin.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btJoin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btJoin.ForeColor = System.Drawing.Color.Black;
            this.btJoin.Location = new System.Drawing.Point(455, 313);
            this.btJoin.Name = "btJoin";
            this.btJoin.Size = new System.Drawing.Size(128, 45);
            this.btJoin.TabIndex = 26;
            this.btJoin.Text = "Join";
            this.btJoin.UseTransparentBackground = true;
            this.btJoin.Click += new System.EventHandler(this.btJoin_Click);
            // 
            // Form_Join
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 550);
            this.Controls.Add(this.btJoin);
            this.Controls.Add(this.tbIDofRoom);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.btMinimized);
            this.Controls.Add(this.btMaximized);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.pbBackgroundJoin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Join";
            this.Text = "Form_Join";
            this.Load += new System.EventHandler(this.Form_Join_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundJoin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackgroundJoin;
        private Guna.UI2.WinForms.Guna2Button btBack;
        private System.Windows.Forms.Panel pnHeader;
        private Guna.UI2.WinForms.Guna2Button btMinimized;
        private Guna.UI2.WinForms.Guna2Button btMaximized;
        private Guna.UI2.WinForms.Guna2Button btExit;
        private Guna.UI2.WinForms.Guna2TextBox tbIDofRoom;
        private Guna.UI2.WinForms.Guna2Button btJoin;
    }
}