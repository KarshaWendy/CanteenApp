using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMART.DATA.V1;

namespace CanteenDaily
{
    public partial class frmrights_issue : Form
    {
        public frmrights_issue()
        {
            InitializeComponent();
        }

        ta_operations rt = new ta_operations();
        public string gname = "";
        List<string> assign_rights_string = new List<string>();
        public string depart_key;
        public bool state = false;

        DepartmentRightBLL departmentbll = new DepartmentRightBLL();

        private void cmd_user_add_Click(object sender, EventArgs e)
        {
            if (txt_user_rname.Text == "")
            {
                MessageBox.Show("The Name cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txt_username.Text == "")
            {
                MessageBox.Show("The User Name be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cbo_user_group.Text == "")
            {
                MessageBox.Show("The User Group cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cbo_user_group.Text != "" && txt_username.Text != "" && txt_user_rname.Text != "")
            {
                string inst_col_vals = "insert into ta_users(Real_Names,user_name,Password,fk_userg_id,username_id,user_state) values";
                string inst_vals = "('" + txt_user_rname.Text + "','" + txt_username.Text + "','" + ParametersGlobal.EncryptString("password", "funguo") + "' ,(select Group_Id from ta_user_group where Group_Desc='" + cbo_user_group.Text + "'),"
                    + globalparams.newuserid + ",(select State from ta_states where Description ='" + cbo_user_state.Text + "'))";
                
                DataBaseOperations.ExecuteComm_My(inst_col_vals + inst_vals);
                
                rt.getusers(dgview_users);                
            }
        }

        private void frmrights_issue_Load(object sender, EventArgs e)
        {
            try
            {
                rt.get_states(cbo_user_state, " where State < 4");
                rt.getusers(dgview_users);
                rt.get_user_groups(cbo_user_group);
                rt.get_user_groups(dataGridView3);
                rt.get_modules(dgview_available_rights);
                panel1.Enabled = false;

                Jaza_Grid();
                getPriceList();
                GetMealTypes();
            }
            catch (Exception ex)
            {
                ParametersGlobal.ShowMessageBox(ex);
            }
        }

        PriceListBLL pricelist = new PriceListBLL();

        private void getPriceList()
        {
            ParametersGlobal.PriceList = pricelist.All();

            dgview_priceList.DataSource = ParametersGlobal.PriceList;
            //dgview_priceList.Columns[0].Visible = false;
        }

        private void Jaza_Grid()
        {
            string query = "select name as 'Department Name', sum(if(fc.food_type_id = 1,1,0)) as 'FOOD', sum(if(fc.food_type_id = 2, 1,0)) as 'TEA', dep_key as 'DepartmentKey' from department_rights dr inner join department d on d.dep_key = dr.department_id  inner join food_category fc on fc.food_type_id = dr.food_type_id inner join price_list pl on pl.category = fc.food_type_id  where status = 1 group by name";

            DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

            List<Department> list = new List<Department>();

            foreach(DataRow r in dt.Rows)
            {
                list.Add(new Department()
                {
                     Name = r["Department Name"].ToString(), 
							FoodType = r["FOOD"].ToString(), 
							TeaType = r["TEA"].ToString(), 
							DepartmentKey = r["DepartmentKey"].ToString()
                     
                });
            }

            dgview_deps.DataSource = list;
            dgview_deps.Columns["DepartmentKey"].Visible = false;

            int k = -1;

            foreach (DataGridViewRow d_row in dgview_deps.Rows)
            {
                k++;

                if (d_row.Cells["TeaType"].Value.ToString() == "0")
                {
                    dgview_deps.Rows[k].Cells["TeaType"].Value = "NOT ALLOWED";
                }
                else
                {
                    dgview_deps.Rows[k].Cells["TeaType"].Value = "ALLOWED";
                }

                if (d_row.Cells["FoodType"].Value.ToString() == "1")
                {
                    dgview_deps.Rows[k].Cells["FoodType"].Value = "ALLOWED";
                }
                else
                {
                    dgview_deps.Rows[k].Cells["FoodType"].Value = "NOT ALLOWED";
                }
            }
        }

        private void GetMealTypes()
        {
            const string query = "select food_type as 'Meal Type', food_type_id as 'Meal ID' from food_category";

            cbo_mealType.DataSource = DataBaseOperations.ExecuteDataTable_My(query);
            cbo_mealType.DisplayMember = "Meal Type";
            cbo_mealType.ValueMember = "Meal ID";
            cbo_mealType.SelectedIndex = -1;
        }

        private void chk_new_user_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_new_user.Checked)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void chk_new_user_group_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_new_user.Checked)
            {
                pnl_new_user_g.Enabled = true;
            }
            else
            {
                pnl_new_user_g.Enabled = false;
            }
        }

        private void cmd_rights_remove_Click(object sender, EventArgs e)
        {
            assign_rights_string.Clear();

            int count = dgview_available_rights.Rows.Count - 1;
            int to_check = 0;

            for (int i = 0; i < count; i++)
            {
                if ((bool?)dgview_available_rights.Rows[i].Cells[0].Value ?? true)
                {
                    to_check++;
                }
            }

            if (to_check < 1)
            {
                MessageBox.Show("No rights have been selected for Removal", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string inst_val = "";
                string module_name = "";

                int row_count = dgview_group_rights.RowCount - 1;

                for (int i = 0; i < row_count; i++)
                {
                    if ((bool?)dgview_group_rights.Rows[i].Cells[0].Value ?? true)
                    {
                        module_name = dgview_group_rights.Rows[i].Cells["Right"].Value.ToString();
                        inst_val = "delete from ta_module_permissions where Group_ID=(select Group_Id from ta_user_group  where Group_Desc='" + gname + "') and module_id=(select Module_ID from ta_module where Module_Name='" + module_name + "')";
                        assign_rights_string.Add(inst_val);
                    }
                }

                if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (var s in assign_rights_string)
                    {
                        DataBaseOperations.ExecuteComm_My(s);
                    }

                    MessageBox.Show("User De-Assignment Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User De-Assignment Cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                rt.get_assigned_group_rights(gname, dgview_group_rights);
            }
        }
          
        private void cmd_rights_add_Click(object sender, EventArgs e)
        {
            assign_rights_string.Clear();

            int count = dgview_available_rights.Rows.Count - 1;
            int to_check = 0;

            for (int i = 0; i < count; i++)
            {
                if ((bool?)dgview_available_rights.Rows[i].Cells[0].Value ?? true)
                {
                    to_check++;                    
                }
            }

            if (to_check < 1)
            {
                MessageBox.Show("No rights have been selected for assigning", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (gname == "")
                {
                    MessageBox.Show("No group Selected for rights assignment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (gname != "")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if ((bool?)dgview_available_rights.Rows[i].Cells[0].Value ?? true)
                        {
                            string right_name = dgview_available_rights.Rows[i].Cells["Module_Name"].Value.ToString();
                            string inst_val = "((select Module_ID from ta_module where module_name='" + right_name + "'),(select Group_ID from ta_user_group where Group_Desc='" + gname + "'))";
                            assign_rights_string.Add(inst_val);
                        }
                    }
                }

                if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (var s in assign_rights_string)
                    {
                        string inst_vals_cols = "INSERT IGNORE into ta_module_permissions(Module_ID,Group_ID) values";

                        DataBaseOperations.ExecuteComm_My(inst_vals_cols + s);
                    }

                    MessageBox.Show("User assignment Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    rt.get_assigned_group_rights(gname, dgview_group_rights);
                }
                else
                {
                    MessageBox.Show("User assignment cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }            
        }

        private void cmd_userg_add_Click(object sender, EventArgs e)
        {
            if (txt_user_g_name.Text == "")
            {
                MessageBox.Show("The User Group Name cannot be empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (txt_user_g_name.Text != "")
            {
                string inst_vals = "Insert into ta_user_group(Group_Desc,Group_Id) values('" + txt_user_g_name.Text + "'," + globalparams.newusergroup_id + ")";
                
                DataBaseOperations.ExecuteComm_My(inst_vals);

                rt.get_user_groups(dataGridView3);
            }
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows[e.RowIndex].Selected = true;
            gname = dataGridView3.Rows[e.RowIndex].Cells["Group Description"].Value.ToString();
            rt.get_assigned_group_rights(gname, dgview_group_rights);
        }
                
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows[e.RowIndex].Selected = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_department.Text == "")
            {
                MessageBox.Show("The department Name cannot be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if ((chk_food.Checked == false) && (chk_tea.Checked == false))
                {
                    MessageBox.Show("Please select at least one \r\nmeal Access for the department", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    /*
                     *The department name and a meal type is selected. 
                     * Save the details of the values selected.
                     */

                    if (cmd_saveDep.Text == "Save")
                    {
                        state = true;
                    }
                    else
                    {
                        state = false;
                    }

                    beforeSave();
                    Jaza_Grid();

                    const string query = @"select name, food_type, amount from department_rights dr inner join department d on d.dep_key = dr.department_id " 
                        + " inner join food_category fc on fc.food_type_id = dr.food_type_id inner join price_list pl on pl.category = fc.food_type_id where status = 1";

                    ParametersGlobal.DepartmentRightList = departmentbll.All();

                    txt_department.Clear();
                    chk_food.Checked = false;
                    chk_tea.Checked = false;
                    dgview_deps.CurrentRow.Selected = false;
                    cmd_saveDep.Text = "Save";
                }
            }
        }

        public void beforeSave()
        {
            if (state == true)
            {
                List<int> f_types = new List<int>();

                if (chk_tea.Checked)
                {
                    f_types.Add(2);
                }
                if (chk_food.Checked)
                {
                    f_types.Add(1);
                }

                /* Add the new department with the new key
                 * 1. Get the last key used by the last department
                 * 2. Add one to the last key to create the new key
                 * 3. Insert the new department with the new key
                 * */

                int dp_key = Convert.ToInt16(DataBaseOperations.ExecuteDataTable_My("select replace(dep_key, 'dp_', '') as 'LastNumber' from department order by abs(replace(dep_key, 'dp_', '')) desc limit 1").Rows[0]["LastNumber"].ToString());
                int new_key = dp_key + 1;

                string dep_ins = "insert into department (name, dep_key) values ('" + txt_department.Text.Replace("'", " ").Trim() + "', 'dp_" + new_key + "')";

                DataBaseOperations.ExecuteComm_My(dep_ins);
                
                List<string> sts = new List<string>();

                /* Set the meals rights the department is supposed to access
                 * */

                foreach (int y in f_types)
                {
                    string insert_state = "insert into `department_rights` (`department_id`, `food_type_id`) VALUES "
                    + " ('dp_" + new_key + "', " + y + "); ";

                    DataBaseOperations.ExecuteComm_My(insert_state);
                }
            }
            if (state == false)
            {
                /* Edit the rights the department the department is supposed to access.
                 * 1. Delete the rights currently assigned
                 * 2. Check what rights are being assigned
                 * 3. Reload the grid after updating the rights
                 * */

                if ((chk_food.Checked != e_f) || (chk_tea.Checked != e_t))
                {

                    string del = "delete from department_rights where department_id = '" + depart_key + "'";

                    DataBaseOperations.ExecuteComm_My(del);
                    
                    List<int> f_types = new List<int>();

                    if (chk_tea.Checked)
                    {
                        f_types.Add(2);
                    }
                    if (chk_food.Checked)
                    {
                        f_types.Add(1);
                    }

                    List<string> sts = new List<string>();

                    foreach (int y in f_types)
                    {
                        string insert_state = "insert ignore into `department_rights` (`department_id`, `food_type_id`) VALUES "
                        + " ('" + depart_key + "', " + y + "); ";
                       
                        DataBaseOperations.ExecuteComm_My(insert_state);                       
                    }

                }
            }

        }

        private void edit_department()
        {
            //vxcmvxv

            if (chk_food.Checked != e_f)
            {
                //Update or delete
            }
            else
            {
                MessageBox.Show("Records are the same", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (chk_tea.Checked != e_t)
            {
                //delete from department_rights where department_id = depart_key;
            }
            else
            {
                MessageBox.Show("Records are the same", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool e_f=false;
        bool e_t = false;

        private void dgview_deps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            state = false;

            chk_tea.Checked = false;
            chk_food.Checked = false;
            cmd_saveDep.Text = "Edit";
            depart_key = dgview_deps.Rows[e.RowIndex].Cells["DepartmentKey"].Value.ToString();

            txt_department.Text = dgview_deps.Rows[e.RowIndex].Cells["Name"].Value.ToString();

            if (dgview_deps.Rows[e.RowIndex].Cells["TeaType"].Value.ToString() == "ALLOWED")
            {
                e_f = true;
                chk_tea.Checked = true;                
            }
            else
            {
                e_f = false;
                chk_tea.Checked = false;
            }

            if (dgview_deps.Rows[e.RowIndex].Cells["FoodType"].Value.ToString() == "ALLOWED")
            {
                e_t = true;
                chk_food.Checked = true;
            }
            else
            {
                e_t = false;
                chk_food.Checked = false;
            }            
        }

        private void cmd_addPrice_Click(object sender, EventArgs e)
        {
            if ((cbo_mealType.SelectedIndex != -1) || (cbo_mealType.Text != ""))
            {
                if (txt_amount.Text != "")
                {
                    double n;
                    bool isDouble = double.TryParse(txt_amount.Text, out n);

                    if (isDouble)
                    {
                        if (MessageBox.Show("Are you sure?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            DataBaseOperations.ExecuteComm_My("update price_list set status = 0 where status = 1 and category =" + cbo_mealType.SelectedValue + "");

                            string query = "Insert into price_list (entry_date, category, status, amount) values "
                                + "('" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + cbo_mealType.SelectedValue + ", 1, " + n + ")";

                            DataBaseOperations.ExecuteComm_My(query);
                        }

                        cbo_mealType.SelectedIndex = -1;
                        txt_amount.Clear();

                        getPriceList();
                    }
                    else
                    {
                        MessageBox.Show("Please type in a correct price amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("The amount cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("The meal type cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
