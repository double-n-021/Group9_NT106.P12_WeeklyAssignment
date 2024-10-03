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
            this.label1.Location = new System.Drawing.Point(85, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(145, 22);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(535, 38);
            this.tb1.TabIndex = 1;
            this.tb1.Text = "127.0.0.1";
            // 
            // rtb1
            // 
            this.rtb1.Location = new System.Drawing.Point(34, 85);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(926, 566);
            this.rtb1.TabIndex = 2;
            this.rtb1.Text = "";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(700, 6);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(205, 54);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 681);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.rtb1);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "tex";
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

