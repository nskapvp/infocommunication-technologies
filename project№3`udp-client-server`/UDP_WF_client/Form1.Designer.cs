namespace UDP_WF_client
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
            this.cbSeason = new System.Windows.Forms.ComboBox();
            this.button_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSeason
            // 
            this.cbSeason.FormattingEnabled = true;
            this.cbSeason.Location = new System.Drawing.Point(16, 12);
            this.cbSeason.Name = "cbSeason";
            this.cbSeason.Size = new System.Drawing.Size(121, 21);
            this.cbSeason.TabIndex = 5;
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(143, 12);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(70, 23);
            this.button_send.TabIndex = 4;
            this.button_send.Text = "Отправить";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 77);
            this.Controls.Add(this.cbSeason);
            this.Controls.Add(this.button_send);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cbSeason;
        private System.Windows.Forms.Button button_send;

        #endregion
    }
}