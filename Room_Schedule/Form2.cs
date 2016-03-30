using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room_Schedule
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The selected date is " + dateTimePicker1.Value.Month + dateTimePicker1.Value.Day);
            MessageBox.Show("The slected time is " + dateTimePicker2.Value.Hour + dateTimePicker2.Value.Minute);
            MessageBox.Show("The Selected Room is " + checkedListBox1.SelectedValue);
            MessageBox.Show("The Value of Box 1 is " + this.textBox1.Text);
            MessageBox.Show("The Value of Box 2 is " + this.textBox2.Text);
            MessageBox.Show("The Value of Box 3 is " + this.textBox3.Text);
        }


    }
}
