namespace WFclientAppEx
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSecondName = new System.Windows.Forms.TextBox();
            this.textBoxSchool = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.textBoxServerMsg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Отправить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSecondName
            // 
            this.textBoxSecondName.Location = new System.Drawing.Point(12, 34);
            this.textBoxSecondName.Name = "textBoxSecondName";
            this.textBoxSecondName.Size = new System.Drawing.Size(165, 20);
            this.textBoxSecondName.TabIndex = 1;
            // 
            // textBoxSchool
            // 
            this.textBoxSchool.Location = new System.Drawing.Point(12, 88);
            this.textBoxSchool.Name = "textBoxSchool";
            this.textBoxSchool.Size = new System.Drawing.Size(165, 20);
            this.textBoxSchool.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Школа";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Оценки";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Задача 1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(69, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Задача 2";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(126, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Задача 3";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Задача 4";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(69, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Задача 5";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(126, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Задача 6";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "0", "1/3", "2/3", "1" });
            this.comboBox1.Location = new System.Drawing.Point(12, 177);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(51, 21);
            this.comboBox1.TabIndex = 18;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] { "0", "1/3", "2/3", "1" });
            this.comboBox2.Location = new System.Drawing.Point(69, 177);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(51, 21);
            this.comboBox2.TabIndex = 19;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] { "0", "1/3", "2/3", "1" });
            this.comboBox3.Location = new System.Drawing.Point(126, 177);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(51, 21);
            this.comboBox3.TabIndex = 20;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] { "0", "1/3", "2/3", "1" });
            this.comboBox4.Location = new System.Drawing.Point(12, 233);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(51, 21);
            this.comboBox4.TabIndex = 21;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] { "0", "1/3", "2/3", "1" });
            this.comboBox5.Location = new System.Drawing.Point(69, 233);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(51, 21);
            this.comboBox5.TabIndex = 22;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] { "0", "1/3", "2/3", "1" });
            this.comboBox6.Location = new System.Drawing.Point(126, 234);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(51, 21);
            this.comboBox6.TabIndex = 23;
            // 
            // textBoxServerMsg
            // 
            this.textBoxServerMsg.Location = new System.Drawing.Point(12, 350);
            this.textBoxServerMsg.Name = "textBoxServerMsg";
            this.textBoxServerMsg.Size = new System.Drawing.Size(165, 20);
            this.textBoxServerMsg.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 324);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 23);
            this.label10.TabIndex = 25;
            this.label10.Text = "Категория";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(214, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 464);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxServerMsg);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSchool);
            this.Controls.Add(this.textBoxSecondName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.TextBox textBoxServerMsg;
        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;

        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox textBoxSchool;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSecondName;

        #endregion
    }
}