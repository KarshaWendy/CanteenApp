using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using CanteenDaily;
using System.Threading;
using System.Reflection;
using SMART.DATA.V1;

namespace SmartCanteen
{
    public partial class FrmReports : Form
    {      
        public FrmReports()
        {
            InitializeComponent();
        }

        System.Data.DataTable dt = new System.Data.DataTable();
        DateTime startDate = DateTime.Now;
        public string totalsums,sum,gsum;
        public int total,col_location;
        
        private System.Data.DataTable feeds()
        {
            string query = " distinct department,sum(amount),time ";
            string cons = " time >= '" + startdate.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00" + "'" + " and time <=' " + enddate.Value.Date.ToString("yyyy-MM-dd") + " 23:59:00" + "'";
            string grp = " group by department";
            string cond = "";
            string depart = "";

            List<string> vf = new List<string>();

            if (chkdep.Checked)
            {
                chkdep.Invoke(new MethodInvoker(delegate { depart = cbodepart.Text; }));
                vf.Add(" department='" + depart + "'");
            }
            if (chkdates.Checked)
            {
                vf.Add(cons);
            }
            if (chk_mealtime.Checked)
            {
                string wakati = "";
                string wak = "";

                cbo_mealtime.Invoke(new MethodInvoker(delegate { wak = cbo_mealtime.Text; }));

                wakati = " usage_instance ='" + wak + "'";

                vf.Add(wakati);
            }
            if (chk_mealtype.Checked)
            {
                string mm = "";

                cbo_mealtype.Invoke(new MethodInvoker(delegate { mm = cbo_mealtype.Text; }));

                vf.Add(" meal_type ='" + mm + "'");
            }

            if (vf.Count > 0)
            {
                int lo = 1;
                string dr = "";

                foreach (string s in vf)
                {
                    if (lo == 1)
                    {
                        dr = s;
                    }
                    else
                    {
                        dr = dr + " and " + s;
                    }

                    lo++;
                }
                cond = dr;
            }

            try
            {
                DataColumn dcnew = new DataColumn();
                dcnew.AutoIncrement = true;
                dcnew.AutoIncrementSeed = 1;
                dcnew.AutoIncrementStep = 1;
                dt.Columns.Add(dcnew);

                if (chk_groupReport.Checked)
                {
                    string query1 = "select " + query + " from smartcafet.dailyfeeds where " + cond + grp;
                   
                    dt = DataBaseOperations.ExecuteDataTable_My(query1);
                }
                if (!chk_groupReport.Checked)
                {
                    string qy = "select date(time) as 'Date',time(time) as 'Time',staffnumber as 'Staff Number',UCASE(card_name) as 'Staff Name',UCASE(Department) as Department,"
                        + " usage_instance as 'Meal Time',meal_type as 'Meal Type', serialnumber, Amount from smartcafet.dailyfeeds where " + cond;

                    dt = DataBaseOperations.ExecuteDataTable_My(qy);
                }

                if (dt.Rows.Count > 0)
                {
                    sum = dt.Compute("sum(amount)", "").ToString();
                    col_location = dt.Columns.Count - 2;

                    DataRow row1 = dt.NewRow();
                    row1["Staff number"] = "-";
                    row1["serialnumber"] = "-";
                    row1["department"] = "-";
                    row1["amount"] = 0;
                    dt.Rows.Add(row1);

                    DataRow row2 = dt.NewRow();
                    row2["Staff number"] = "-";
                    row2["serialnumber"] = "-";
                    row2["department"] = "-";
                    row2[col_location] = "Grand Total";
                    row2[dt.Columns.Count - 1] = sum;
                    dt.Rows.Add(row2);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return dt;
        }       
               
        private void FrmReports_Load(object sender, EventArgs e)
        {
            string query = "select name from smartcafet.department order by name asc";

            DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

            cbodepart.DataSource = dt;
            cbodepart.DisplayMember = "name";
            cbodepart.ValueMember = "name";
            cbodepart.SelectedIndex = -1;

            startdate.Enabled = false;
            enddate.Enabled = false;
            cbodepart.Enabled = false;            
            cmbgtype.Enabled = false;
            cmdsave.Enabled = false;
            cbo_mealtime.Enabled = false;
            cbo_mealtype.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgview.DataSource = null;
            dgview.Columns.Clear();
            txttotal.Text = "";

            if (chk_groupReport.Checked)
            {
                if (cmbgtype.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a grouping option");
                    cmbgtype.Focus();
                }
                else
                {
                    backgroundWorker2.RunWorkerAsync();
                    timer1.Start();
                }
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
                timer1.Start();
            }

        }

        private void chkdates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdates.Checked)
            {
                startdate.Enabled = true;
                enddate.Enabled = true;
            }
            else
            {
                startdate.Enabled = false;
                enddate.Enabled = false;
            }
        }

        private void chkdep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdep.Checked)
            {
                cbodepart.Enabled = true;
            }
            else
            {
                cbodepart.Enabled = false;
            }
        }

        private System.Data.DataTable membercount()
        {
            System.Data.DataTable count = new System.Data.DataTable("count");

            DataColumn c = new DataColumn("No.", typeof(int));
            c.AutoIncrement = true;
            c.AutoIncrementSeed = 1;
            c.AutoIncrementStep = 1;
            count.Columns.Add(c);

            string sec_query = " date(time) as 'Date',time(time) as 'Time',staffnumber as 'Staff Number',UCASE(card_name) as 'Staff Name',UCASE(Department) as Department,serialnumber,count(*) as 'Meal Count', count(*) * Amount as 'Amount'";
            string cons = " time >= '" + startdate.Value.Date.ToString("yyyy-MM-dd") + " 00:00:00" + "'" + " and time <=' " + enddate.Value.Date.ToString("yyyy-MM-dd") + " 23:59:00" + "'";
            string grp = "";
            string gname = "";
            List<string> vf = new List<string>();

            cmbgtype.Invoke(new MethodInvoker(delegate { gname = cmbgtype.Text; }));
            grp = " group by " + gname + "";
            
            string cond = "";
            string depart = "";

            if (chkdep.Checked)
            {
                chkdep.Invoke(new MethodInvoker(delegate { depart = cbodepart.Text; }));
                vf.Add("department='" + depart + "'");
            }
            if (chkdates.Checked)
            {
                vf.Add(cons);
            }
            if (chk_mealtime.Checked)
            {
                string wakati = "";
                string wak = "";

                cbo_mealtime.Invoke(new MethodInvoker(delegate { wak = cbo_mealtime.Text; }));

                wakati = " usage_instance ='" + wak + "'";

                vf.Add(wakati);
            }
            if (chk_mealtype.Checked)
            {
                string mm = "";

                cbo_mealtype.Invoke(new MethodInvoker(delegate { mm = cbo_mealtype.Text; }));

                vf.Add(" meal_type ='" + mm + "'");
            }

            if (vf.Count > 0)
            {
                int lo = 1;
                string dr = "";

                foreach (string s in vf)
                {
                    if (lo == 1)
                    {
                        dr = s;
                    }
                    else
                    {
                        dr = dr + " and " + s;
                    }

                    lo++;
                }
                cond = " where " + dr;
            }

            try
            {
                count = DataBaseOperations.ExecuteDataTable_My("select " + sec_query + " from dailyfeeds " + cond + " " + grp + " ");

                sum = count.Compute("sum(amount)", "").ToString();

                if (count.Rows.Count > 0)
                {
                    if (gname == "department")
                    {
                        count.Columns.Remove("Date");
                        count.Columns.Remove("time");
                        count.Columns.Remove("Staff Number");
                        count.Columns.Remove("Staff Name");
                        count.Columns.Remove("serialnumber");

                        col_location = count.Columns.Count - 3;

                        DataRow row3 = count.NewRow();
                        row3["department"] = "-";
                        row3["Amount"] = 0;
                        count.Rows.Add(row3);

                        DataRow row4 = count.NewRow();
                        row4["department"] = "-";
                        row4[col_location] = "Grand Total";
                        row4[count.Columns.Count - 1] = sum;
                        count.Rows.Add(row4);
                    }
                    else
                    {
                        count.Columns.Remove("Date");
                        count.Columns.Remove("time");
                        col_location = count.Columns.Count - 3;

                        DataRow row3 = count.NewRow();
                        row3["Staff number"] = "-";
                        row3["serialnumber"] = "-";
                        row3["Amount"] = 0;
                        count.Rows.Add(row3);

                        DataRow row4 = count.NewRow();
                        row4["Staff number"] = "-";
                        row4["serialnumber"] = "-";
                        row4[col_location] = "Grand Total";
                        row4[count.Columns.Count - 1] = sum;
                        count.Rows.Add(row4);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return count;
        }
               
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            toolStripStatusLabel1.Text = "Loading..........   Thanks for your patience";

            dt = feeds();
            
            e.Result = dt;
            toolStripStatusLabel1.Text = "Please Wait.....";
        }        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 100;
            dgview.DataSource = dt;            
            writetxt.modifydgview(dgview, col_location);
            dgview.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgview.Columns["Amount"].DefaultCellStyle.Format = "c";

            for (int i = 0; i < dgview.Columns.Count - 1; i++)
            {
                dgview.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            try
            {
                if (dt.Rows.Count > 0)
                {
                    int count = dt.Rows.Count - 2;

                    label4.Text = "Count : " + count.ToString();
                    //string sum = dt.Compute("sum(amount)", "").ToString();
                    double totals = (double)dt.Compute("sum(Amount)", "");
                    string tots = string.Format("{0:KSHS  #,##0.00}", sum);
                    txttotal.ForeColor = Color.Red;
                    txttotal.Text = tots;

                    cmdsave.Enabled = true;
                }
                else
                {
                    cmdsave.Enabled = false;
                    label4.Text = "Count :=0";
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            toolStripStatusLabel1.Text = "";
            toolStripProgressBar1.Value = 0;
            timer1.Stop();
            toolStripStatusLabel2.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now.Subtract(startDate);

            string stime = "....." + DateTime.Now.ToString("00") + ":" + ts.Seconds.ToString("00") +
                ":" + ts.Milliseconds.ToString("000");

            toolStripStatusLabel2.Text = stime;

            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
            {
                toolStripProgressBar1.Value = 0;
            }
            toolStripProgressBar1.PerformStep();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            toolStripStatusLabel1.Text = "Loading..........Thanks for your patience";

            dt = membercount();        
                       
            e.Result = dt;
            toolStripStatusLabel1.Text = "Please Wait.....";
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 100;
                     
            dgview.DataSource = dt;
            //modifydgview(dgview);
            writetxt.modifydgview(dgview, col_location);
            dgview.Columns["Amount"].DefaultCellStyle.Format = "c";
            dgview.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            try
            {
                if (dt.Rows.Count > 0)
                {
                    int count = dt.Rows.Count - 2;

                    double totals = (double)dt.Compute("sum(Amount)", "");
                    string tots = string.Format("{0:KSHS  #,##0.00}", sum);
                    txttotal.ForeColor = Color.Red;
                    txttotal.Text = tots;
                    label4.Text = "Count : " + count.ToString();
                    cmdsave.Enabled = true;
                }
                else
                {
                    cmdsave.Enabled = false;
                    label4.Text = "Count :=0";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            toolStripStatusLabel1.Text = "";
            toolStripProgressBar1.Value = 0;
            timer1.Stop();
            toolStripStatusLabel2.Text = "";
        }

        private void chkmem_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        void ExportToExcel()
        {
            try
            {
                DataTable reportdt = (DataTable)dgview.DataSource;
                
                if (reportdt.Rows.Count > 0)
                {
                    string savefilepath = ParametersGlobal.SaveFileLocation();

                    if (!string.IsNullOrEmpty(savefilepath))
                    {
                        ExportReportModel exportmodel = new ExportReportModel()
                        {
                            DocumentAuthor = "SMART",
                            DocumentFontName = "Trebuchet MS",
                            SavePathReport = savefilepath,
                            SheetName = "FEED_" + DateTime.Now.ToString("yyyy-MM-dd"),
                            DocumentTitle = "Feed List Report"
                        };

                        ParametersGlobal.ExportToExcel(reportdt, exportmodel);
                        
                        MessageBox.Show("Report Successfully saved", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                ParametersGlobal.ShowMessageBox(ex);
            }
        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void chk_mealtime_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mealtime.Checked)
            {
                cbo_mealtime.Enabled = true;
            }
            else
            {
                cbo_mealtime.Enabled = false;
            }
        }

        private void chk_mealtype_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_mealtype.Checked)
            {
                cbo_mealtype.Enabled = true;
            }
            else
            {
                cbo_mealtype.Enabled = false;
            }
        }

        private void chk_groupReport_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_groupReport.Checked)
            {
                cmbgtype.Enabled = true;
            }
            else
            {
                cmbgtype.Enabled = false;
            }
        }
                                          
    }

}

