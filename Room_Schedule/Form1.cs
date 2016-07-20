﻿using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing.Printing;

namespace Room_Schedule
{

    public partial class Form1 : Form
    {
        DataTable schedule_nice = new DataTable();
        DataTable schedule_print = new DataTable();

        public Form1()
        {
            InitializeComponent();
            CheckDB();
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
            int count = 0;
            int rowToInsert = schedule_nice.Rows.Count;
            foreach (DataRow newData in schedule_nice.Rows)
            {
                
                string sDate = newData["Date"].ToString();
                string sRoom = newData["Room"].ToString();
                string sTime = newData["Time"].ToString();
                int insert_UNIX; 
         
                try
                {
                    DateTime dt = Convert.ToDateTime(sDate);
                    DateTimeOffset insertDateTime = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, TimeSpan.Zero);
                    insert_UNIX = (int)insertDateTime.ToUnixTimeSeconds();
                }
                catch
                {
                    MessageBox.Show("Please enter a Valid Date in the form of MM/DD/YY Please check the following record Date:" + sDate + " Room:" + sRoom + " Time:" + sTime);
                    dataGridView1.DataSource = schedule_nice;
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns["Index"].Visible = false;
                    break;
                }
                
                string indexValue = newData["Index"].ToString();
                int indexLength = indexValue.Length;
                if (indexLength.Equals(0))
                {
                    
                    dataInsert.CommandText = "Insert INTO Room_Schedule (ScheduleDate,ScheduleTime,Room,Description1,Description2,Description3) VALUES ('" + insert_UNIX + "','" + newData["Time"] + "','" + newData["Room"] + "','" + newData["Description1"] + "','" + newData["Description2"] + "','" + newData["Description3"] + "');";
                    dataInsert.ExecuteNonQuery();
                    MessageBox.Show("Schedule Has Been Saved");

                }
                else if (indexLength > 0 )
                {
                    int indexNumber = Convert.ToInt32(newData["Index"]);
                    dataInsert.CommandText = "Update Room_Schedule Set ScheduleDate ='" + insert_UNIX + "', ScheduleTime='" + newData["Time"] + "',Room='" + newData["Room"] + "', Description1='" + newData["Description1"] + "',Description2='" + newData["Description2"] + "',Description3='" + newData["Description3"] + "' Where ScheduleDate = '" + insert_UNIX + "' and ScheduleTime ='" + newData["Time"] + "' and Room ='" + newData["Room"] + "';";
                    dataInsert.ExecuteNonQuery();
                    MessageBox.Show("Schedule Has Been Saved");

                }
                else if (count == rowToInsert)
                {
                    DateTimeOffset selectedDateTime = new DateTimeOffset(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0, TimeSpan.Zero);
                    int Today_UNIX = (int)selectedDateTime.ToUnixTimeSeconds();
                    refreshDataDisplay(Today_UNIX);
                }
                count = count++;



            }

           
            

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

        public void initializeDataTable()
        {
            schedule_nice.Columns.Add("Index");
            schedule_nice.Columns.Add("Date");
            schedule_nice.Columns.Add("Time");
            schedule_nice.Columns.Add("Room");
            schedule_nice.Columns.Add("Description1");
            schedule_nice.Columns.Add("Description2");
            schedule_nice.Columns.Add("Description3");
        }

        public void refreshDataDisplay(int Date)
        {
            //Clear Data table for new data
            
            schedule_nice.Clear();
          
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
                //int unix_time = Convert.ToInt32(data["ScheduleTime"]);
                //DateTimeOffset standard_time = DateTimeOffset.FromUnixTimeSeconds(unix_time);
                //DateTime standard_12_hour = standard_time; 

                //Convert datetime to string
                //DateTime Local_Time = standard_time.DateTime;
                String display_date = standard_date.Month + "/" + standard_date.Day + "/" + standard_date.Year;
                //String display_time = Local_Time.ToString("hh" + ":" + "mm" + "tt");

                //Add data to nice data table
                DataRow Human_data = schedule_nice.NewRow();
                Human_data["Index"] = data["Index"];
                Human_data["Date"] = display_date;
                Human_data["Time"] = data["ScheduleTime"];
                Human_data["Room"] = data["Room"];
                Human_data["Description1"] = data["Description1"];
                Human_data["Description2"] = data["Description2"];
                Human_data["Description3"] = data["Description3"];
                schedule_nice.Rows.Add(Human_data);
                //MessageBox.Show("The row data is " + data) ;

            }

            dataGridView1.DataSource = schedule_nice;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["Index"].Visible = false;


        }

        public void initializePrintTable()
        {
            schedule_print.Columns.Add("Description3");
            schedule_print.Columns.Add("Description2");
            schedule_print.Columns.Add("Description1");
            schedule_print.Columns.Add("Room");
            schedule_print.Columns.Add("Time");
            schedule_print.Columns.Add("Date");
                       
        }

        public void printDataDisplay(int Date)
        {
            //Clear Data table for new data

            schedule_print.Clear();

            //Data table for raw data from database
            DataTable schedule = new DataTable();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=room_schedule.db;Version=3;");
            m_dbConnection.Open();
            var dataRetrieve = new SQLiteCommand(m_dbConnection);
            dataRetrieve.CommandText = "Select * from Room_Schedule where ScheduleDate=" + Date + ";";
            SQLiteDataAdapter scheduleData = new SQLiteDataAdapter(dataRetrieve);
            scheduleData.Fill(schedule);
            foreach (DataRow data in schedule.Rows)
            {
                //Convert date from Unix time to human readable time
                int unix_date = Convert.ToInt32(data["ScheduleDate"]);
                DateTimeOffset standard_date = DateTimeOffset.FromUnixTimeSeconds(unix_date);

                //Convert time from Unix time to human readable time
                //int unix_time = Convert.ToInt32(data["ScheduleTime"]);
                //DateTimeOffset standard_time = DateTimeOffset.FromUnixTimeSeconds(unix_time);
                //DateTime standard_12_hour = standard_time; 

                //Convert datetime to string
                //DateTime Local_Time = standard_time.DateTime;
                String display_date = standard_date.Month + "/" + standard_date.Day + "/" + standard_date.Year;
                //String display_time = Local_Time.ToString("hh" + ":" + "mm" + "tt");

                //Add data to nice data table
                DataRow Print_data = schedule_print.NewRow();
                Print_data["Date"] = display_date;
                Print_data["Time"] = data["ScheduleTime"];
                Print_data["Room"] = data["Room"];
                Print_data["Description1"] = data["Description1"];
                Print_data["Description2"] = data["Description2"];
                Print_data["Description3"] = data["Description3"];
                schedule_print.Rows.Add(Print_data);
                //MessageBox.Show("The row data is " + data) ;

            }
        
            dataGridView2.DataSource = schedule_print;
        }

        public void CheckDB()
        {
            if (File.Exists("room_schedule.db"))
            {
                initializeDataTable();
                refreshDataDisplay(getUnixTime());
            }

            else
            {

                SQLiteConnection.CreateFile("room_schedule.db");

                SQLiteConnection m_dbConnection;
                m_dbConnection = new SQLiteConnection("Data Source=room_schedule.db;Version=3;");
                m_dbConnection.Open();

                string createTables = "CREATE TABLE \"Room_Schedule\" ('Index'INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,'ScheduleDate'INTEGER NOT NULL,'ScheduleTime'	TEXT,'Room'	TEXT,'Description1'	TEXT,'Description2'	TEXT,'Description3'	TEXT)";

                SQLiteCommand command = new SQLiteCommand(createTables, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();

                initializeDataTable();
                refreshDataDisplay(getUnixTime());


            }

        }

        public int getUnixTime()
        {
            DateTime Today = DateTime.Today;
            DateTimeOffset Today_DTO = new DateTimeOffset(Today.Year, Today.Month, Today.Day, 0, 0, 0, TimeSpan.Zero);
            int Today_UNIX = (int)Today_DTO.ToUnixTimeSeconds();

            return Today_UNIX;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //printDocument1.Print();
            initializePrintTable();
            printDataDisplay(getUnixTime());
            ClsPrint _ClsPrint = new ClsPrint(dataGridView2, "Schedule");
            _ClsPrint.PrintForm();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            initializePrintTable();           
            printDataDisplay(getUnixTime());
            ClsPrint _ClsPrint = new ClsPrint(dataGridView2, "Schedule");
            _ClsPrint.PrintForm();
        }

        // From http://stackoverflow.com/questions/15853746/how-to-print-values-from-a-datagridview-control 
        class ClsPrint
        {
            #region Variables

            int iCellHeight = 0; //Used to get/set the datagridview cell height
            int iTotalWidth = 0; //
            int iRow = 0;//Used as counter
            bool bFirstPage = false; //Used to check whether we are printing first page
            bool bNewPage = false;// Used to check whether we are printing a new page
            int iHeaderHeight = 0; //Used for the header height
            StringFormat strFormat; //Used to format the grid rows.
            ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
            ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
            private PrintDocument _printDocument = new PrintDocument();
            private DataGridView gw = new DataGridView();
            private string _ReportHeader;

            #endregion

            public ClsPrint(DataGridView gridview, string ReportHeader)
            {
                _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
                _printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
                gw = gridview;
                _ReportHeader = ReportHeader;
            }

            public void PrintForm()
            {
                ////Open the print dialog
                //PrintDialog printDialog = new PrintDialog();
                //printDialog.Document = _printDocument;
                //printDialog.UseEXDialog = true;

                ////Get the document
                //if (DialogResult.OK == printDialog.ShowDialog())
                //{
                //    _printDocument.DocumentName = "Test Page Print";
                //    _printDocument.Print();
                //}

                //Open the print preview dialog
                PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
                objPPdialog.Document = _printDocument;
                objPPdialog.ShowDialog();
            }

            private void _printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
                //try
                //{
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in gw.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= gw.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = gw.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {

                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString(_ReportHeader,
                                new Font(gw.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader,
                                new Font(gw.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = "";
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(gw.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(gw.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString(_ReportHeader,
                                new Font(new Font(gw.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            DataGridViewColumn[] _GridCol = new DataGridViewColumn[gw.Columns.Count];
                            int colcount = 0;
                            //Convert ltr to rtl
                            foreach (DataGridViewColumn GridCol in gw.Columns)
                            {
                                _GridCol[colcount++] = GridCol;
                            }
                            for (int i = (_GridCol.Count() - 1); i >= 0; i--)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(_GridCol[i].HeaderText,
                                    _GridCol[i].InheritedStyle.Font,
                                    new SolidBrush(_GridCol[i].InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                            
                        }
                        iCount = 0;
                        DataGridViewCell[] _GridCell = new DataGridViewCell[GridRow.Cells.Count];
                        int cellcount = 0;
                        //Convert ltr to rtl
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            _GridCell[cellcount++] = Cel;
                        }
                        //Draw Columns Contents                
                        for (int i = (_GridCell.Count() - 1); i >= 0; i--)
                        {
                            if (_GridCell[i].Value != null)
                            {
                                e.Graphics.DrawString(_GridCell[i].FormattedValue.ToString(),
                                    _GridCell[i].InheritedStyle.Font,
                                    new SolidBrush(_GridCell[i].InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
                //}
                //catch (Exception exc)
                //{
                //    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                //       MessageBoxIcon.Error);
                //}
            }

            private void _printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
            {
                try
                {
                    strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Center;
                    strFormat.LineAlignment = StringAlignment.Center;
                    strFormat.Trimming = StringTrimming.EllipsisCharacter;

                    arrColumnLefts.Clear();
                    arrColumnWidths.Clear();
                    iCellHeight = 0;
                    iRow = 0;
                    bFirstPage = true;
                    bNewPage = true;

                    // Calculating Total Widths
                    iTotalWidth = 0;
                    foreach (DataGridViewColumn dgvGridCol in gw.Columns)
                    {
                        iTotalWidth += dgvGridCol.Width;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


    }


}
