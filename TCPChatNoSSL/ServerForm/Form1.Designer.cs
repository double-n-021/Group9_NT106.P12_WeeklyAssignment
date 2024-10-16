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
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(72, 11);
            this.tb1.Margin = new System.Windows.Forms.Padding(2);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(270, 22);
            this.tb1.TabIndex = 1;
            this.tb1.Text = "127.0.0.1";
            // 
            // rtb1
            // 
            this.rtb1.Location = new System.Drawing.Point(17, 44);
            this.rtb1.Margin = new System.Windows.Forms.Padding(2);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(465, 294);
            this.rtb1.TabIndex = 2;
            this.rtb1.Text = "";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(350, 3);
            this.btnListen.Margin = new System.Windows.Forms.Padding(2);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(102, 28);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 351);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.rtb1);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
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

