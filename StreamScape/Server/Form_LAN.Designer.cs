namespace Server
{
    partial class Form_LAN
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
            this.btStart = new Guna.UI2.WinForms.Guna2Button();
            this.btStop = new Guna.UI2.WinForms.Guna2Button();
            this.btnGetLocalIP = new Guna.UI2.WinForms.Guna2Button();
            this.tbLocalIP = new System.Windows.Forms.TextBox();
            this.tbAvailableRoom = new System.Windows.Forms.TextBox();
            this.tbExistingUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUserandAdd = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btAdd = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.btUploadFile = new System.Windows.Forms.Button();
            this.btPoster = new System.Windows.Forms.Button();
            this.cbTag = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.listView_log = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btStart.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btStart.ForeColor = System.Drawing.Color.Black;
            this.btStart.Location = new System.Drawing.Point(11, 15);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(180, 45);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btStop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btStop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btStop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btStop.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btStop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btStop.ForeColor = System.Drawing.Color.Black;
            this.btStop.Location = new System.Drawing.Point(11, 68);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(180, 45);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btnGetLocalIP
            // 
            this.btnGetLocalIP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGetLocalIP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGetLocalIP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGetLocalIP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGetLocalIP.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnGetLocalIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGetLocalIP.ForeColor = System.Drawing.Color.Black;
            this.btnGetLocalIP.Location = new System.Drawing.Point(11, 308);
            this.btnGetLocalIP.Name = "btnGetLocalIP";
            this.btnGetLocalIP.Size = new System.Drawing.Size(180, 47);
            this.btnGetLocalIP.TabIndex = 3;
            this.btnGetLocalIP.Text = "Get Server\'s IP Address";
            this.btnGetLocalIP.Click += new System.EventHandler(this.btnGetLocalIP_Click);
            // 
            // tbLocalIP
            // 
            this.tbLocalIP.Location = new System.Drawing.Point(11, 361);
            this.tbLocalIP.Name = "tbLocalIP";
            this.tbLocalIP.Size = new System.Drawing.Size(180, 22);
            this.tbLocalIP.TabIndex = 4;
            // 
            // tbAvailableRoom
            // 
            this.tbAvailableRoom.Location = new System.Drawing.Point(380, 462);
            this.tbAvailableRoom.Name = "tbAvailableRoom";
            this.tbAvailableRoom.Size = new System.Drawing.Size(100, 22);
            this.tbAvailableRoom.TabIndex = 5;
            // 
            // tbExistingUser
            // 
            this.tbExistingUser.Location = new System.Drawing.Point(716, 462);
            this.tbExistingUser.Name = "tbExistingUser";
            this.tbExistingUser.Size = new System.Drawing.Size(100, 22);
            this.tbExistingUser.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Available Rooms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(587, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Existing Users";
            // 
            // cbUserandAdd
            // 
            this.cbUserandAdd.BackColor = System.Drawing.Color.Transparent;
            this.cbUserandAdd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUserandAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserandAdd.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbUserandAdd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbUserandAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbUserandAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbUserandAdd.ItemHeight = 30;
            this.cbUserandAdd.Items.AddRange(new object[] {
            "User Accounts",
            "Movies and Musics"});
            this.cbUserandAdd.Location = new System.Drawing.Point(219, 15);
            this.cbUserandAdd.Name = "cbUserandAdd";
            this.cbUserandAdd.Size = new System.Drawing.Size(738, 36);
            this.cbUserandAdd.TabIndex = 9;
            this.cbUserandAdd.SelectedIndexChanged += new System.EventHandler(this.cbUserAccount_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(219, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(738, 164);
            this.dataGridView1.TabIndex = 10;
            // 
            // btAdd
            // 
            this.btAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btAdd.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btAdd.ForeColor = System.Drawing.Color.Black;
            this.btAdd.Location = new System.Drawing.Point(9, 397);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(84, 45);
            this.btAdd.TabIndex = 12;
            this.btAdd.Text = "Add";
            this.btAdd.Visible = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Title:";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(46, 19);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(133, 22);
            this.tbTitle.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Description:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(269, 20);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(131, 22);
            this.tbDescription.TabIndex = 16;
            // 
            // gbAdd
            // 
            this.gbAdd.Controls.Add(this.btUploadFile);
            this.gbAdd.Controls.Add(this.btPoster);
            this.gbAdd.Controls.Add(this.cbTag);
            this.gbAdd.Controls.Add(this.label5);
            this.gbAdd.Controls.Add(this.tbTitle);
            this.gbAdd.Controls.Add(this.tbDescription);
            this.gbAdd.Controls.Add(this.label3);
            this.gbAdd.Controls.Add(this.label4);
            this.gbAdd.Location = new System.Drawing.Point(99, 389);
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.Size = new System.Drawing.Size(858, 53);
            this.gbAdd.TabIndex = 17;
            this.gbAdd.TabStop = false;
            this.gbAdd.Text = "Add Movies and Music";
            this.gbAdd.Visible = false;
            // 
            // btUploadFile
            // 
            this.btUploadFile.Location = new System.Drawing.Point(743, 15);
            this.btUploadFile.Name = "btUploadFile";
            this.btUploadFile.Size = new System.Drawing.Size(107, 29);
            this.btUploadFile.TabIndex = 20;
            this.btUploadFile.Text = "Upload File";
            this.btUploadFile.UseVisualStyleBackColor = true;
            this.btUploadFile.Click += new System.EventHandler(this.btUploadFile_Click);
            // 
            // btPoster
            // 
            this.btPoster.Location = new System.Drawing.Point(573, 15);
            this.btPoster.Name = "btPoster";
            this.btPoster.Size = new System.Drawing.Size(164, 29);
            this.btPoster.TabIndex = 19;
            this.btPoster.Text = "Upload Poster";
            this.btPoster.UseVisualStyleBackColor = true;
            this.btPoster.Click += new System.EventHandler(this.btPoster_Click);
            // 
            // cbTag
            // 
            this.cbTag.FormattingEnabled = true;
            this.cbTag.Items.AddRange(new object[] {
            "Movie",
            "Music"});
            this.cbTag.Location = new System.Drawing.Point(446, 18);
            this.cbTag.Name = "cbTag";
            this.cbTag.Size = new System.Drawing.Size(121, 24);
            this.cbTag.TabIndex = 18;
            this.cbTag.SelectedIndexChanged += new System.EventHandler(this.cbTag_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tag:";
            // 
            // OFD
            // 
            this.OFD.FileName = "Open File";
            // 
            // listView_log
            // 
            this.listView_log.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_log.HideSelection = false;
            this.listView_log.Location = new System.Drawing.Point(219, 239);
            this.listView_log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView_log.Name = "listView_log";
            this.listView_log.Size = new System.Drawing.Size(738, 138);
            this.listView_log.TabIndex = 21;
            this.listView_log.UseCompatibleStateImageBehavior = false;
            this.listView_log.View = System.Windows.Forms.View.List;
            // 
            // Form_LAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(962, 503);
            this.Controls.Add(this.listView_log);
            this.Controls.Add(this.gbAdd);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbUserandAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbExistingUser);
            this.Controls.Add(this.tbAvailableRoom);
            this.Controls.Add(this.tbLocalIP);
            this.Controls.Add(this.btnGetLocalIP);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form_LAN";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form_LAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbAdd.ResumeLayout(false);
            this.gbAdd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btStart;
        private Guna.UI2.WinForms.Guna2Button btStop;
        private Guna.UI2.WinForms.Guna2Button btnGetLocalIP;
        private System.Windows.Forms.TextBox tbLocalIP;
        private System.Windows.Forms.TextBox tbAvailableRoom;
        private System.Windows.Forms.TextBox tbExistingUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbUserandAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button btAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.ComboBox cbTag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btPoster;
        private System.Windows.Forms.Button btUploadFile;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.ListView listView_log;
    }
}