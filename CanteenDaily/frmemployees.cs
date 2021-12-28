using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Smart.Data.Xml;
using SmartCanteen;
using System.IO;
using CanteenDaily;
using Microsoft.VisualBasic;
using SMART.DATA.V1;

namespace CanteenDaily
{
    public partial class frmemployees : Form
    {        
        frmSearch _frmsearch = null;
        private string _textFilters, formerdept;
        public string _update_dep, get_user_name;

        public frmemployees()
        {
            InitializeComponent();
            filldatagrid();
        }

        private void filldatagrid()
        {
            try
            {
                DataTable dt = DataBaseOperations.ExecuteDataTable_My("select UCASE(staffname) as Staff_Name,staffnumber,serialnumber,department from smartcafet.employees").Copy();

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                dgview.DataSource = ds.Tables[0].DefaultView;
                //dgview.Columns["Staff_Name"].HeaderText = "Employee Name";
                //dgview.Columns["staffnumber"].HeaderText = "Employee Number";
                dgview.Columns["Staff_Name"].HeaderText = "Student Name";
                dgview.Columns["staffnumber"].HeaderText = "Student Number";
                dgview.Columns["serialnumber"].HeaderText = "Card serial Number";
                dgview.Columns["department"].HeaderText = "Department";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException);
            }
        }

        private void searchgrid_TextChanged(List<field> fields)
        {
            System.Data.DataView dv = ((System.Data.DataView)dgview.DataSource); //
            _textFilters = ""; //reset filters
            bool first = true; //to handle the " and "
            foreach (field f in fields)
            {
                if (f.Value.Length > 0) //only if there is a value to filter for
                {
                    if (!first) _textFilters += " and ";
                    _textFilters += f.Field + " like '%" + f.Value + "%'";
                    first = false;
                }
            }
            dv.RowFilter = _textFilters;
            //this.labelFilter.Text = _textFilters;
        }

        private void deactivateCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgview.SelectedRows[0];
                string staffnumber = row.Cells["staffnumber"].Value.ToString();
                string memname = row.Cells["staff_name"].Value.ToString();
                string serial = row.Cells["serialnumber"].Value.ToString();
                string depart = row.Cells["department"].Value.ToString();
                //string user_name = globalparams.user_name;

                if (MessageBox.Show("Are you sure you want to deactivate card number " + staffnumber + "  belonging to \n " + memname + " ", "Card Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //remove the record from the datagridview.
                    //dgview.Rows.Remove(row);

                    //remove the employee record from the database.

                    DataBaseOperations.ExecuteComm_My("delete from smartcafet.employees where staffnumber='" + staffnumber + "'");
                    MessageBox.Show("Card Number " + staffnumber + ", belonging to \n" + memname + " deactivated.", "Card Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    filldatagrid();
                }
                else
                {
                    MessageBox.Show("Card number :" + staffnumber + " was not deactivated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //mconn.Close();                
            }
        }

        private void changeCostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgview.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row which you want to update costing!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataGridViewRow row = dgview.SelectedRows[0];
                string staffnumber = row.Cells["staffnumber"].Value.ToString();
                formerdept = row.Cells["department"].Value.ToString();

                frmdeparts deps = new frmdeparts();
                deps.receive_name = staffnumber;
                deps.receive_dept = formerdept;
                deps.ShowDialog();
                this.Close();
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmsearch == null)
            {
                //let's add a couple of columns
                List<field> fields = new List<field>();
                //List<
                field f = new field();
                //f.FrielndlyName = "Staff Number";
                //f.Field = "staffnumber";
                f.FrielndlyName = "Student Number";
                f.Field = "staffnumber";
                fields.Add(f);

                f = new field();
                f.FrielndlyName = "Card Serial Number";
                f.Field = "serialnumber";
                fields.Add(f);

                f = new field();
                //f.FrielndlyName = "Staff Name";
                //f.Field = "Staff_Name";
                f.FrielndlyName = "Student Name";
                f.Field = "Staff_Name";
                fields.Add(f);

                _frmsearch = new frmSearch(fields);
                _frmsearch.TextChanged += new SearchContextChangedHandler(searchgrid_TextChanged);
            }

            _frmsearch.ShowDialog();
        }

    }
}
