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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable schedule = new DataTable();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=room_schedule.db;Version=3;");
            m_dbConnection.Open();
            var dataRetrieve = new SQLiteCommand(m_dbConnection);
            dataRetrieve.CommandText = "Select * from Room_Schedule;";
            SQLiteDataAdapter scheduleData = new SQLiteDataAdapter(dataRetrieve);
            scheduleData.Fill(schedule);
                        foreach (DataRow data in schedule.Rows)
            {
                DataTable schedule_nice = new DataTable();
                schedule_nice.Clear();
                schedule_nice.Columns.Add("Date");
                schedule_nice.Columns.Add("Time");
                schedule_nice.Columns.Add("Room");
                schedule_nice.Columns.Add("Discription1");
                schedule_nice.Columns.Add("Discription2");
                schedule_nice.Columns.Add("Discription3");
                
                int unix_time = Convert.ToInt32(data["ScheduleDate"]);
                DateTimeOffset standard_time = DateTimeOffset.FromUnixTimeSeconds(unix_time);
                //MessageBox.Show("The date is " + standard_time.Month + "/" + standard_time.Day + "/" + standard_time.Year );
                String display_time = standard_time.Month + "/" + standard_time.Day + "/" + standard_time.Year;
                DataRow Human_data = schedule_nice.NewRow();
                Human_data["Date"] = display_time;
                Human_data["Time"] = data["ScheduleTime"];
                Human_data["Room"] = data["Room"];
                Human_data["Discription1"] = data["Discription1"];
                Human_data["Discription2"] = data["Discription2"];
                Human_data["Discription3"] = data["Discription3"];
                schedule_nice.Rows.Add(Human_data);
                //MessageBox.Show("The row data is " + data) ;
              
            }
            dataGridView1.DataSource = schedule_nice;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable schedule = new DataTable();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=room_schedule.db;Version=3;");
            m_dbConnection.Open();
            var dataRetrieve = new SQLiteCommand(m_dbConnection);
            dataRetrieve.CommandText = "Select * from Room_Schedule;";
            SQLiteDataAdapter scheduleData = new SQLiteDataAdapter(dataRetrieve);
            scheduleData.Fill(schedule);
            dataGridView1.DataSource = schedule;
     
        }


    }
}
