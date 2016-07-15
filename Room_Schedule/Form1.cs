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
        DataTable schedule_nice = new DataTable();
        public Form1()
        {
            
            DateTime Today = DateTime.Today;
            DateTimeOffset Today_DTO = new DateTimeOffset (Today.Year, Today.Month, Today.Day, 0, 0, 0, TimeSpan.Zero);
            int Today_UNIX = (int)Today_DTO.ToUnixTimeSeconds();

            InitializeComponent();
            refreshDataDisplay(Today_UNIX);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=room_schedule.db;Version=3;");
            m_dbConnection.Open();
            var dataInsert = new SQLiteCommand(m_dbConnection);
            MessageBox.Show("Trying to Before Loop");
            foreach (DataRow newData in schedule_nice.Rows)
                try
            {

                    dataInsert.CommandText = "Update Room_Schedule Set ScheduleDate =" + newData["Date"] + "',' SchedulteTime=" + newData["Time"] + "','Room="+ newData["Room"] + "','Description1=" + newData["Description1"] + "','Description2=" + newData["Description2"] + "','Description3=" + newData["Description3"] + "Where ScheduleData = " + newData["Date"] + "and ScheduleTime =" + newData["Time"] + "and Room =" + newData["Room"] + ";";
                dataInsert.ExecuteNonQuery();
                
            }
            catch
            {
                    dataInsert.CommandText = "Insert INTO Room_Schedule VALUES ('" + newData["Date"] + "','" + newData["Time"] + "','" + newData["Room"] + "','" + newData["Description1"] + "','" + newData["Description2"] + "','" + newData["Description3"] + "');";
                    dataInsert.ExecuteNonQuery();
                    MessageBox.Show("Trying to Insert");

                }

            DateTimeOffset selectedDateTime = new DateTimeOffset(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0, TimeSpan.Zero);
            int Today_UNIX = (int)selectedDateTime.ToUnixTimeSeconds();
            refreshDataDisplay(Today_UNIX);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DateTimeOffset selectedDateTime = new DateTimeOffset(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0, TimeSpan.Zero);
            int Today_UNIX = (int)selectedDateTime.ToUnixTimeSeconds();
            refreshDataDisplay(Today_UNIX);


        }

        public void refreshDataDisplay(int Date)
        {
            //Initialize Data table to be displayed
            
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
            dataRetrieve.CommandText = "Select * from Room_Schedule where ScheduleDate="+Date+";";
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
                //DateTime Local_Time = standard_time.DateTime;
                String display_date = standard_date.Month + "/" + standard_date.Day + "/" + standard_date.Year;
                //String display_time = Local_Time.ToString("hh" + ":" + "mm" + "tt");

                //Add data to nice data table
                DataRow Human_data = schedule_nice.NewRow();
                Human_data["Date"] = display_date;
                Human_data["Time"] = data["SchedulteTime"];
                Human_data["Room"] = data["Room"];
                Human_data["Description1"] = data["Description1"];
                Human_data["Description2"] = data["Description2"];
                Human_data["Description3"] = data["Description3"];
                schedule_nice.Rows.Add(Human_data);
                //MessageBox.Show("The row data is " + data) ;

            }
            dataGridView1.DataSource = schedule_nice;

        }


    }
}
