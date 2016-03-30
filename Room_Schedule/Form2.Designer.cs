namespace Room_Schedule
{
    partial class Form2
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Room1 = new System.Windows.Forms.RadioButton();
            this.s = new System.Windows.Forms.RadioButton();
            this.Room3 = new System.Windows.Forms.RadioButton();
            this.Room4 = new System.Windows.Forms.RadioButton();
            this.Room5 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(75, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(75, 73);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 258);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Line 1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(75, 284);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Line 2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(75, 310);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "Line 3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(352, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Room1
            // 
            this.Room1.AutoSize = true;
            this.Room1.Location = new System.Drawing.Point(3, 19);
            this.Room1.Name = "Room1";
            this.Room1.Size = new System.Drawing.Size(62, 17);
            this.Room1.TabIndex = 8;
            this.Room1.TabStop = true;
            this.Room1.Text = "Room 1";
            this.Room1.UseVisualStyleBackColor = true;
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Location = new System.Drawing.Point(3, 42);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(62, 17);
            this.s.TabIndex = 9;
            this.s.TabStop = true;
            this.s.Text = "Room 2";
            this.s.UseVisualStyleBackColor = true;
            this.s.CheckedChanged += new System.EventHandler(this.room2_CheckedChanged);
            // 
            // Room3
            // 
            this.Room3.AutoSize = true;
            this.Room3.Location = new System.Drawing.Point(3, 65);
            this.Room3.Name = "Room3";
            this.Room3.Size = new System.Drawing.Size(62, 17);
            this.Room3.TabIndex = 10;
            this.Room3.TabStop = true;
            this.Room3.Text = "Room 3";
            this.Room3.UseVisualStyleBackColor = true;
            // 
            // Room4
            // 
            this.Room4.AutoSize = true;
            this.Room4.Location = new System.Drawing.Point(3, 88);
            this.Room4.Name = "Room4";
            this.Room4.Size = new System.Drawing.Size(62, 17);
            this.Room4.TabIndex = 11;
            this.Room4.TabStop = true;
            this.Room4.Text = "Room 4";
            this.Room4.UseVisualStyleBackColor = true;
            // 
            // Room5
            // 
            this.Room5.AutoSize = true;
            this.Room5.Location = new System.Drawing.Point(3, 111);
            this.Room5.Name = "Room5";
            this.Room5.Size = new System.Drawing.Size(62, 17);
            this.Room5.TabIndex = 12;
            this.Room5.TabStop = true;
            this.Room5.Text = "Room 5";
            this.Room5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Room1);
            this.groupBox1.Controls.Add(this.Room5);
            this.groupBox1.Controls.Add(this.s);
            this.groupBox1.Controls.Add(this.Room4);
            this.groupBox1.Controls.Add(this.Room3);
            this.groupBox1.Location = new System.Drawing.Point(75, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 139);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(352, 529);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.RadioButton Room1;
        private System.Windows.Forms.RadioButton s;
        private System.Windows.Forms.RadioButton Room3;
        private System.Windows.Forms.RadioButton Room4;
        private System.Windows.Forms.RadioButton Room5;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}