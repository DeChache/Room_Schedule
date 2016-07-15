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
            //Initialize Data table to be displayed
            DataTable schedule_nice = new DataTable();
            schedule_nice.Clear();
            schedule_nice.Columns.Add("Date");
            schedule_nice.Columns.Add("Time");
            schedule_nice.Columns.Add("Room");
            schedule_nice.Columns.Add("Description1");
            schedule_nice.Columns.Add("Description2");
            schedule_nice.Columns.Add("Description3");
            //Data table for raw data from database
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
                //Convert date from Unix time to human readable time
                int unix_date = Convert.ToInt32(data["ScheduleDate"]);
                DateTimeOffset standard_date = DateTimeOffset.FromUnixTimeSeconds(unix_date);

                //Convert time from Unix time to human readable time
                int unix_time = Convert.ToInt32(data["ScheduleTime"]);
                DateTimeOffset standard_time = DateTimeOffset.FromUnixTimeSeconds(unix_time);
                //DateTime standard_12_hour = standard_time; 

                //Convert datetime to string
                DateTime Local_Time = standard_time.DateTime;
                String display_date = standard_date.Month + "/" + standard_date.Day + "/" + standard_date.Year;
                String display_time = Local_Time.ToString("hh"+":"+"mm"+"tt") ;

                DataRow Human_data = schedule_nice.NewRow();
                Human_data["Date"] = display_date;
                Human_data["Time"] = display_time;
                Human_data["Room"] = data["Room"];
                Human_data["Description1"] = data["Description1"];
                Human_data["Description2"] = data["Description2"];
                Human_data["Description3"] = data["Description3"];
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
