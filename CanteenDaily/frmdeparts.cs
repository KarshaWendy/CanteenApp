using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Smart.Data.Xml;
//using SmartCanteen;
using System.IO;
using CanteenDaily;
using SMART.DATA.V1;

namespace CanteenDaily
{
    public partial class frmdeparts : Form
    {
        public frmdeparts()
        {
            InitializeComponent();
        }

        public string receive_name,receive_dept;

        private void frmdeparts_Load(object sender, EventArgs e)
        {
            //fill combobox with departments.

            DataTable dt = DataBaseOperations.ExecuteDataTable_My("select name from department order by name asc");

            cbodepart.DataSource = ParametersGlobal.DepartmentList;
            cbodepart.DisplayMember = "Name";
            cbodepart.ValueMember = "Name";
            cbodepart.SelectedIndex = -1;

            frmemployees emp = new frmemployees();
            label1.Text = "Change the costing of Staffnumber  " + receive_name;

            label3.Enabled = false;
            dtst.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label3.Visible = true;               
                dtst.Visible = true;
                dtst.Enabled = true;
            }
            else
            {
                label3.Visible = false;                
                dtst.Visible = false;
            }
        }

        private void cmdupdate_Click(object sender, EventArgs e)
        {
            string updt_comm = "update employees set department='" + cbodepart.Text.Trim() + "' where staffnumber = '" + receive_name + "'";

            try
            {
                //mconn.Open();
                //mconn.ChangeDatabase(Cards.CardDatabase);

                if (MessageBox.Show("Are you sure you want to change costing for card number " + receive_name + "'", "Change Costing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //update employees table with the new deartment.
                    DataBaseOperations.ExecuteComm_My(updt_comm);
                    
                    //update dailyfeeds with the new department.
                    if (!checkBox1.Checked)
                    {                       
                        //update the whole of the record of the staff member in dailyfeeds with the new department
                        DataBaseOperations.ExecuteComm_My("update dailyfeeds set department='" + cbodepart.Text.Trim() + "' where staffnumber='" + receive_name + "'");
                    }
                    else
                    {      
                        //update dailyfeeds with the new department as from the date indicated.
                        DataBaseOperations.ExecuteComm_My("update dailyfeeds set department='" + cbodepart.Text.Trim() + "' where staffnumber='" + receive_name + "' and date(time) >='" + dtst.Value.Date.ToString("yyyy-MM-dd") + "'");
                    }



                    string mesg = "The costings for card belonging to Staff number " + receive_name + " \n has been changed from " + receive_dept + " to " + cbodepart.Text + " \n as from the " + dtst.Value.ToString("yyyy-MM-dd");

                    //write a log of the change of department.
                    //writetxt.andikatxt(mesg, "\\logging.txt");                    
                    MessageBox.Show(mesg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                updt_comm = "update employees";
                this.Close();
            }
        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
