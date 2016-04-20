using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=room_schedule.db;Version=3;");
            m_dbConnection.Open();
            var dataInsert = new SQLiteCommand(m_dbConnection);
            var checkedButton = groupBox1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            var roomName = checkedButton.Name.ToString();
            var appointmentDate = dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year;
            var appointmentTime = dateTimePicker2.Value.Hour + ":" + dateTimePicker2.Value.Minute;

            dataInsert.CommandText = "INSERT INTO Room_Schedule VALUES ('" + appointmentDate + "','" + roomName + "','" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text +"');";
            dataInsert.ExecuteNonQuery();

            //            MessageBox.Show("The selected date is " + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" 
            //            + dateTimePicker1.Value.Year +
            //            " The selcted time is " + dateTimePicker2.Value.Hour + ":" + dateTimePicker2.Value.Minute +
            //            " The selected room is " + checkedButton.Name +
            //            " The Value of Box 1 is " + this.textBox1.Text +
            //            " The Value of Box 2 is " + this.textBox2.Text +
            //            " The Value of Box 3 is " + this.textBox3.Text);
        }

        private object ToString(string name)
        {
            throw new NotImplementedException();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void room2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Scheduling_Load(object sender, EventArgs e)
        {

        }
    }
}
