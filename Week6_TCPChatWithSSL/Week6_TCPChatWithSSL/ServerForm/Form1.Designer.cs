namespace ServerForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(144, 21);
            this.tb1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(536, 38);
            this.tb1.TabIndex = 1;
            this.tb1.Text = "127.0.0.1";
            // 
            // rtb1
            // 
            this.rtb1.BackColor = System.Drawing.Color.MistyRose;
            this.rtb1.Location = new System.Drawing.Point(34, 85);
            this.rtb1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(926, 566);
            this.rtb1.TabIndex = 2;
            this.rtb1.Text = "";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(700, 6);
            this.btnListen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(204, 54);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(994, 680);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.rtb1);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.Button btnListen;
    }
}

