using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using SMART.DATA.V1;

namespace CanteenDaily
{
    internal class ta_operations
    {
        List<string> department1 = new List<string>();
        List<string> department2 = new List<string>();
        List<string> department3 = new List<string>();
        List<string> department4 = new List<string>();

        public void getdeps(ComboBox cboempdept)
        {
            DataTable depts_dt = DataBaseOperations.ExecuteDataTable_My("select distinct Dept_Name as 'Department',Dept_Manager as 'Manager',entry_date as 'Entry Date',Dept_Id from ta_department order by Dept_Name asc");
            cboempdept.DataSource = depts_dt;
            cboempdept.DisplayMember = "Department";
            cboempdept.ValueMember = "Department";
            cboempdept.SelectedIndex = -1;
        }

        public void getdeps(ComboBox cboempdept, DataGridView dgviewdeps)
        {
            DataTable depts_dt = new DataTable();
            depts_dt = DataBaseOperations.ExecuteDataTable_My("select distinct Dept_Name as 'Department',Dept_Manager as 'Manager',entry_date as 'Entry Date',Dept_Id from ta_department order by Dept_Name asc");
            cboempdept.DataSource = depts_dt;
            cboempdept.DisplayMember = "Department";
            cboempdept.ValueMember = "Department";
            cboempdept.SelectedIndex = -1;

            if (depts_dt.Rows.Count > 0)
            {

                int mxid = Convert.ToInt32((depts_dt.Compute("max(Dept_Id)", null)));
                Globalparams.newdeptid = mxid + 1;
            }
            else
            {
                Globalparams.newdeptid = 1;
            }

            dgviewdeps.DataSource = depts_dt;
            dgviewdeps.Columns["dept_id"].Visible = false;
        }

        public void getusers(DataGridView userdgview)
        {
            DataTable users_dt = new DataTable();
            users_dt = DataBaseOperations.ExecuteDataTable_My("select real_names as 'Real Names',user_name as 'User Name' ,Group_Desc as 'User Group',tu.entry_date as 'Entry Date',username_id from ta_users tu left join ta_user_group on fk_userg_id=Group_Id where user_state=1");

            if (users_dt.Rows.Count > 0)
            {
                int mxid = Convert.ToInt32((users_dt.Compute("max(username_id)", null)));
                Globalparams.newuserid = mxid + 1;
            }
            else
            {
                Globalparams.newuserid = 1;
            }

            userdgview.DataSource = users_dt;
            userdgview.Columns["username_id"].Visible = false;
        }

        public void get_user_groups(ComboBox cbo_user_g)
        {
            DataTable userg = DataBaseOperations.ExecuteDataTable_My("select distinct Group_Desc from ta_user_group");
            cbo_user_g.DataSource = userg;
            cbo_user_g.DisplayMember = "Group_Desc";
            cbo_user_g.ValueMember = "Group_Desc";
            cbo_user_g.SelectedIndex = -1;
        }

        public void get_user_groups(DataGridView dgview)
        {
            DataTable userg = new DataTable();

            userg = DataBaseOperations.ExecuteDataTable_My("select Group_Desc as 'Group Description',Insert_Date as 'Entry Date',Group_Id from ta_user_group");

            if (userg.Rows.Count > 0)
            {
                int mxid = Convert.ToInt32((userg.Compute("max(Group_Id)", null)));
                Globalparams.newusergroup_id = mxid + 1;
            }
            else
            {
                Globalparams.newusergroup_id = 1;
            }

            userg.Columns.Remove("Group_Id");
            userg.Columns["Group Description"].SetOrdinal(0);
            userg.Columns["Entry Date"].SetOrdinal(1);
            //userg.Columns.Remove("No.");

            dgview.DataSource = userg;
        }

        public void get_modules(DataGridView dgview)
        {
            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn("Select");
            dc.DataType = typeof(Boolean);
            dc.DefaultValue = false;

            dt = DataBaseOperations.ExecuteDataTable_My("select Module_Name, Module_Description from ta_module");
            dt.Columns.Add(dc);

            dt.Columns["Select"].SetOrdinal(0);
            dt.Columns["Module_Name"].SetOrdinal(1);
            dt.Columns["Module_Description"].SetOrdinal(2);
            // dt.Columns.Remove("No.");

            dgview.DataSource = dt;


        }

        public void get_assigned_group_rights(string group_name, DataGridView dgview)
        {
            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn("Select");
            dc.DataType = typeof(Boolean);
            dc.DefaultValue = false;

            dt = DataBaseOperations.ExecuteDataTable_My("select Module_name as 'Right',module_description  as 'Description' from ta_user_group tug inner join ta_module_permissions tmp on tmp.Group_ID = tug.Group_Id inner join ta_module tm on tm.Module_ID = tmp.Module_ID where Group_Desc='" + group_name + "'");

            dt.Columns.Add(dc);

            dt.Columns["Select"].SetOrdinal(0);
            dt.Columns["Right"].SetOrdinal(1);
            dt.Columns["Description"].SetOrdinal(2);

            dgview.DataSource = dt;
        }

        public void get_states(ComboBox cbostates)
        {
            DataTable states_dt = DataBaseOperations.ExecuteDataTable_My("select Description from ta_states order by Description asc");
            cbostates.DataSource = states_dt;
            cbostates.DisplayMember = "Description";
            cbostates.ValueMember = "Description";
            cbostates.SelectedIndex = -1;
        }

        public void get_states(ComboBox cbostates, string cond)
        {
            DataTable states_dt = new DataTable();
            states_dt = DataBaseOperations.ExecuteDataTable_My("select Description from ta_states " + cond + " order by Description asc");
            cbostates.DataSource = states_dt;
            cbostates.DisplayMember = "Description";
            cbostates.ValueMember = "Description";
            cbostates.SelectedIndex = -1;
        }

        public void insert_department(TextBox deptname, TextBox deptman)
        {
            string cols = "insert into ta_department (Dept_Name,Dept_Manager,fk_user_id,Dept_Id) values";
            string vals = "('" + deptname.Text + "','" + deptman.Text + "'," + Globalparams.user_id + "," + Globalparams.newdeptid + ")";

            DataBaseOperations.ExecuteComm_My(cols + vals);
        }

        public void get_emp_type(ComboBox cboempstates)
        {
            DataTable emptypes = DataBaseOperations.ExecuteDataTable_My("select Description from ta_emp_types order by description asc");
            cboempstates.DataSource = emptypes;
            cboempstates.DisplayMember = "Description";
            cboempstates.ValueMember = "Description";
            cboempstates.SelectedIndex = -1;

        }

        public void generate_timetable(DataGridView dgview)
        {
            Random random = new Random();

            DataTable combined_dt = new DataTable("Test_Shifts");
            combined_dt.Columns.Add("Department", typeof(string));
            combined_dt.Columns.Add("Morning", typeof(string));
            combined_dt.Columns.Add("Afternoon", typeof(string));
            combined_dt.Columns.Add("Evening", typeof(string));

            DataTable p = DataBaseOperations.ExecuteDataTable_My("select distinct dept_name,dept_id from ta_department");

            foreach (DataRow r in p.Rows)
            {
                DataRow d_row = combined_dt.NewRow();
                string dpt_name = r["dept_name"].ToString();
                d_row["Department"] = dpt_name;
                int dept_id = Convert.ToInt16(r["dept_id"].ToString());

                DataTable members = DataBaseOperations.ExecuteDataTable_My("select concat(f_name,' ',l_name) as 'Employee Name', emp_number as 'Employee Number' from ta_employee te "
                + " inner join ta_department td on td.Dept_Id = te.Department_id "
                + " where dept_name='" + dpt_name + "' and Emp_State=1");

                List<string> l_mems = new List<string>();

                foreach (DataRow r2 in members.Rows)
                {
                    l_mems.Add(r2["Employee Name"].ToString());
                }

                DataTable dtr = DataBaseOperations.ExecuteDataTable_My("select distinct name,s_id from ta_shift");
                int t = 0;

                foreach (DataRow shift_row in dtr.Rows)
                {
                    t++;
                    string emps_list = "";
                    int shiftid = Convert.ToInt16(shift_row["s_id"].ToString());

                    DataTable emp_count_per_shift = DataBaseOperations.ExecuteDataTable_My("select emp_count from shift_emp_count where shift_id=" + shiftid
                        + " and dept_id=" + dept_id);

                    int max_no = Convert.ToInt16(emp_count_per_shift.Rows[0]["emp_count"].ToString());

                    for (int y = 0; y < max_no; y++)
                    {
                        string to_remove = l_mems[random.Next(0, l_mems.Count)];

                        emps_list = emps_list + "," + to_remove;
                        d_row[t] = emps_list;
                        l_mems.Remove(to_remove);
                    }
                }

                combined_dt.Rows.Add(d_row);
            }

            dgview.DataSource = combined_dt;

        }

        private DataTable get_deps()
        {
            DataTable dt = DataBaseOperations.ExecuteDataTable_My("select distinct dept_name,dept_id from ta_department");

            return dt;
        }

        public void N(DataGridView dgview, DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2)
        {
            Random random = new Random();

            DataTable combined_dt = new DataTable("Test_Shifts");
            combined_dt.Columns.Add("Shift", typeof(string));

            foreach (DataRow dt_row in get_deps().Rows)
            {
                string dept_name_s = dt_row["dept_name"].ToString();
                combined_dt.Columns.Add(dept_name_s);
            }

            TimeSpan ts = dateTimePicker2.Value - dateTimePicker1.Value;
            int t_days = ts.Days + 1;

            double test = 0;

            for (int days = 1; days <= t_days; days++)
            {
                test++;

                mems(get_deps());

                DateTime start = dateTimePicker1.Value.Date.AddDays(test - 1);

                DataTable shift_dt = DataBaseOperations.ExecuteDataTable_My("select distinct s_id,name from ta_shift order by s_id");

                foreach (DataRow shidt_row in shift_dt.Rows)
                {
                    DataRow d_row = combined_dt.NewRow();

                    int s_id = Convert.ToInt32(shidt_row["s_id"].ToString());
                    string s_name = shidt_row["name"].ToString();
                    d_row[0] = start.ToString("yyyy-MM-dd") + " " + s_name;

                    int t = 0;

                    foreach (DataRow dept_row in get_deps().Rows)
                    {
                        t++;

                        string dpt_name = dept_row["Dept_name"].ToString();
                        int dept_id = Convert.ToInt32(dept_row["dept_id"].ToString());

                        DataTable dt_emp_count = DataBaseOperations.ExecuteDataTable_My("select emp_count from shift_emp_count "
                            + " where shift_id=" + s_id + " and dept_id=" + dept_id);

                        int emp_count = Convert.ToInt32(dt_emp_count.Rows[0]["emp_count"].ToString());

                        string to_remove = "";
                        string emps_list = "";

                        for (int y = 0; y < emp_count; y++)
                        {
                            if (dpt_name == "Cashiers")
                            {
                                to_remove = department1[random.Next(0, department1.Count)];
                                emps_list = emps_list + to_remove + ",";
                                department1.Remove(to_remove);
                            }
                            if (dpt_name == "finance")
                            {
                                to_remove = department2[random.Next(0, department2.Count)];
                                emps_list = emps_list + to_remove + ",";
                                department2.Remove(to_remove);
                            }
                            if (dpt_name == "Bus Dev")
                            {
                                to_remove = department3[random.Next(0, department3.Count)];
                                emps_list = emps_list + to_remove + ","; ;
                                department3.Remove(to_remove);
                            }
                            if (dpt_name == "Support")
                            {
                                to_remove = department4[random.Next(0, department4.Count)];
                                emps_list = emps_list + to_remove + ",";
                                department4.Remove(to_remove);
                            }
                            d_row[t] = emps_list;
                        }
                    }

                    combined_dt.Rows.Add(d_row);
                }
            }

            dgview.DataSource = combined_dt;           
        }

        private DataTable add_mems(string dept_name)
        {
            DataTable members = DataBaseOperations.ExecuteDataTable_My("select concat(f_name,' ',l_name) as 'Employee Name', emp_number as 'Employee Number' from ta_employee te "
                + " inner join ta_department td on td.Dept_Id = te.Department_id "
                + " where dept_name='" + dept_name + "' and Emp_State=1");

            return members;
        }

        private List<string> mems(DataTable dt)
        {
            department1.Clear();
            department2.Clear();
            department3.Clear();
            department4.Clear();

            DataTable ft = new DataTable();

            List<string> hold_vals = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["dept_name"].ToString() == "Cashiers")
                {
                    ft = add_mems("Cashiers");

                    foreach (DataRow p in ft.Rows)
                    {
                        department1.Add(p["Employee Name"].ToString());
                    }
                }
                if (dr["dept_name"].ToString() == "finance")
                {
                    ft = add_mems("finance");

                    foreach (DataRow p2 in ft.Rows)
                    {
                        department2.Add(p2["Employee Name"].ToString());
                    }

                }
                if (dr["dept_name"].ToString() == "Bus Dev")
                {
                    ft = add_mems("Bus Dev");

                    foreach (DataRow p3 in ft.Rows)
                    {
                        department3.Add(p3["Employee Name"].ToString());
                    }
                }
                if (dr["dept_name"].ToString() == "Support")
                {
                    ft = add_mems("Support");

                    foreach (DataRow p4 in ft.Rows)
                    {
                        department4.Add(p4["Employee Name"].ToString());
                    }
                }
            }

            return hold_vals;
        }

    }

}
