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
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbAvailableRoom = new System.Windows.Forms.TextBox();
            this.tbExistingUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUserAccount = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btStart.ForeColor = System.Drawing.Color.White;
            this.btStart.Location = new System.Drawing.Point(54, 12);
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
            this.btStop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btStop.ForeColor = System.Drawing.Color.White;
            this.btStop.Location = new System.Drawing.Point(54, 95);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(180, 45);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(54, 260);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 92);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Get Server\'s IP Address";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(54, 382);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 22);
            this.textBox2.TabIndex = 4;
            // 
            // tbAvailableRoom
            // 
            this.tbAvailableRoom.Location = new System.Drawing.Point(423, 459);
            this.tbAvailableRoom.Name = "tbAvailableRoom";
            this.tbAvailableRoom.Size = new System.Drawing.Size(100, 22);
            this.tbAvailableRoom.TabIndex = 5;
            // 
            // tbExistingUser
            // 
            this.tbExistingUser.Location = new System.Drawing.Point(759, 459);
            this.tbExistingUser.Name = "tbExistingUser";
            this.tbExistingUser.Size = new System.Drawing.Size(100, 22);
            this.tbExistingUser.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Available Rooms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Existing Users";
            // 
            // cbUserAccount
            // 
            this.cbUserAccount.BackColor = System.Drawing.Color.Transparent;
            this.cbUserAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUserAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserAccount.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbUserAccount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbUserAccount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbUserAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbUserAccount.ItemHeight = 30;
            this.cbUserAccount.Location = new System.Drawing.Point(257, 12);
            this.cbUserAccount.Name = "cbUserAccount";
            this.cbUserAccount.Size = new System.Drawing.Size(743, 36);
            this.cbUserAccount.TabIndex = 9;
            this.cbUserAccount.SelectedIndexChanged += new System.EventHandler(this.cbUserAccount_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(257, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(743, 174);
            this.dataGridView1.TabIndex = 10;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(257, 256);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(743, 180);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // Form_LAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 503);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbUserAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbExistingUser);
            this.Controls.Add(this.tbAvailableRoom);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Name = "Form_LAN";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form_LAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btStart;
        private Guna.UI2.WinForms.Guna2Button btStop;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tbAvailableRoom;
        private System.Windows.Forms.TextBox tbExistingUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbUserAccount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}