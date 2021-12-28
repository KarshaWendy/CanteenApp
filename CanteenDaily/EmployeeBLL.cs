using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SMART.DATA.V1;
using System.Globalization;

namespace CanteenDaily
{
    public class EmployeeBLL
    {
        public List<Employee> AllEmployees()
        {
            List<Employee> listya = new List<Employee>();

            try
            {
                string query = "select * from employees order by staffname asc";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                foreach (DataRow r in dt.Rows)
                {
                    listya.Add(new Employee()
                    {
                        CardIssueDate = Convert.ToDateTime(r["Date_card_issued"].ToString()),
                        DateDeactivated = Convert.ToDateTime(r["Date_deactivated"].ToString()),
                        DateReinstate = Convert.ToDateTime(r["Date_reinstate"].ToString()),
                        Dates = Convert.ToDateTime(r["STATUS"].ToString()),
                        Deactivator = r["Deactivator"].ToString(),
                        Department = r["department"].ToString(),
                        Issuer = r["Issuer"].ToString(),
                        EndTime = Convert.ToDateTime(r["lasttimes"].ToString()),
                        Reinstater = r["reinstater"].ToString(),
                        SerialNumber = r["Serialnumber"].ToString(),
                        StaffName = r["staffname"].ToString(),
                        StaffNumber = r["staffNumber"].ToString(),
                        Status = Convert.ToInt16(r["STATUS"].ToString()),
                        StartTime = Convert.ToDateTime(r["times"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {

            }
            
            return listya;
        }

        public Employee FetchMember(string serialnumber)
        {
            Employee employee = new Employee();

            try
            {
                string query = "select * from employees where Serialnumber = '" + serialnumber + "' order by staffname asc";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                foreach (DataRow r in dt.Rows)
                {
                    employee = new Employee()
                    {
                        CardIssueDate = Convert.ToDateTime(r["Date_card_issued"].ToString()),
                        DateDeactivated = Convert.ToDateTime(r["Date_deactivated"].ToString()),
                        DateReinstate = Convert.ToDateTime(r["Date_reinstate"].ToString()),
                        Dates = Convert.ToDateTime(r["STATUS"].ToString()),
                        Deactivator = r["Deactivator"].ToString(),
                        Department = r["department"].ToString(),
                        Issuer = r["Issuer"].ToString(),
                        EndTime = Convert.ToDateTime(r["lasttimes"].ToString()),
                         Reinstater = r["reinstater"].ToString(),
                        SerialNumber = r["Serialnumber"].ToString(),
                        StaffName = r["staffname"].ToString(),
                        StaffNumber = r["staffNumber"].ToString(),
                        Status = Convert.ToInt16(r["STATUS"].ToString()),
                        StartTime = Convert.ToDateTime(r["times"].ToString()) 
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employee;
        }

        public Employee FetchMember_BySerial(string serial)
        {
            Employee employee = null;

            try
            {
                string query = "select * from employees where Serialnumber = '" + serial + "'";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                foreach (DataRow r in dt.Rows)
                {
                    employee = new Employee()
                    {
                        Dates = Convert.ToDateTime(r["Dates"].ToString()),
                        Deactivator = r["Deactivator"].ToString(),
                        Department = r["department"].ToString(),
                        Issuer = r["Issuer"].ToString(),
                        EndTime = Convert.ToDateTime(r["lasttimes"].ToString()),
                        Reinstater = r["reinstater"].ToString(),
                        SerialNumber = r["Serialnumber"].ToString(),
                        StaffName = r["staffname"].ToString(),
                        StaffNumber = r["staffNumber"].ToString(),
                        Status = Convert.ToInt16(r["STATUS"].ToString()),
                        StartTime = Convert.ToDateTime(r["times"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                employee = null;
                throw ex;
            }

            return employee;
        }

        public void DeleteEmployee(string serialnumber, string employeenumber)
        {
            string query = "delete from employees where serialnumber='" + serialnumber + "' or staffnumber='" + employeenumber + "'";

            DataBaseOperations.ExecuteComm_My(query);
        }

        public void FingerPrintReset(string serialNumber, Int32 retCounter)
        {
            /* Connect to the Smartlink db and get the maximum ret counter on the ret requests 
             * based on the serial number. 
             * Then insert a fingerprint removal instruction with the max ret counter + 1
             * 
             * */

            //Connect to the smartlink db and get

            string _retQuery = "select max(update_count) as MaxCounter from smartlink.ret_requests where lookup = '" + serialNumber + "';";

            DataTable _retDt = DataBaseOperations.ExecuteDataTable_My(_retQuery);


            if (_retDt.Rows.Count > 0)
            {
                string _c = _retDt.Rows[0]["MaxCounter"].ToString();

                if (_c == "" || _c == string.Empty)
                {
                    //Get The next counter
                    Int32 _NextRetCounter = retCounter + 1;

                    //Insert into the ret_requests tbl

                    string insert = "INSERT INTO `smartlink`.`ret_requests` (`IP_address`, `Update_Count`, `Lookup_Type`, `Lookup`, `IKey`, `Updates`, `Insert_Date`, `Funder_ID`, `Processed_Date`) VALUES";
                    string inv = "('', " + _NextRetCounter + ", 1, '" + serialNumber + "', '510675F9FF2C78DA', 'F9F80BE6B7EE8C932E0C1182340472E0C757D6F4E9B2099C', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'cardissue', NULL)";

                    DataBaseOperations.ExecuteComm_My(insert + inv);
                }
                else
                {
                    Int32 _maxRetCounter = Convert.ToInt32(_retDt.Rows[0]["MaxCounter"].ToString());
                    Int32 k = 0;
                    Int32 _NextRetCounter;

                    List<string> ins = new List<string>();

                    if (retCounter > _maxRetCounter)
                    {
                        for (int y = _maxRetCounter; y < retCounter; y++)
                        {
                            _NextRetCounter = _maxRetCounter + 1;

                            string insert = "INSERT INTO `smartlink`.`ret_requests` (`IP_address`, `Update_Count`, `Lookup_Type`, `Lookup`, `IKey`, `Updates`, `Insert_Date`, `Funder_ID`, `Processed_Date`) VALUES";
                            string inv = "('', " + _NextRetCounter + ", 1, '" + serialNumber + "', '510675F9FF2C78DA', 'F9F80BE6B7EE8C932E0C1182340472E0C757D6F4E9B2099C', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'cardissue', NULL);";

                            ins.Add(insert + inv);
                        }
                    }
                    else
                    {
                        //Get The next counter
                        _NextRetCounter = _maxRetCounter + 1;

                        //Insert into the ret_requests tbl

                        string insert = "INSERT INTO `smartlink`.`ret_requests` (`IP_address`, `Update_Count`, `Lookup_Type`, `Lookup`, `IKey`, `Updates`, `Insert_Date`, `Funder_ID`, `Processed_Date`) VALUES";
                        string inv = "('', " + _NextRetCounter + ", 1, '" + serialNumber + "', '510675F9FF2C78DA', 'F9F80BE6B7EE8C932E0C1182340472E0C757D6F4E9B2099C', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'cardissue', NULL);";

                        ins.Add(insert + inv);
                    }

                    foreach (string s in ins)
                        DataBaseOperations.ExecuteComm_My(s);
                }
            }
            else
            {
                //Get The next counter
                Int32 _NextRetCounter = retCounter + 1;

                string insert = "INSERT INTO `smartlink`.`ret_requests` (`IP_address`, `Update_Count`, `Lookup_Type`, `Lookup`, `IKey`, `Updates`, `Insert_Date`, `Funder_ID`, `Processed_Date`) VALUES";
                string inv = "('', " + _NextRetCounter + ", 1, '" + serialNumber + "', '510675F9FF2C78DA', 'F9F80BE6B7EE8C932E0C1182340472E0C757D6F4E9B2099C', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'cardissue', NULL)";

                DataBaseOperations.ExecuteComm_My(insert + inv);
            }
        }

        public void AddEmployee(Employee employee)
        {
            string query = "insert into employees (staffNumber, staffname, department, times, lasttimes, Serialnumber, Issuer) values"
                + " ('" + employee.StaffNumber + "', '" + employee.StaffName + "', '" + employee.Department + "', '" + employee.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + employee.EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + employee.SerialNumber + "', '" + employee.SerialNumber + "')";

            DataBaseOperations.ExecuteComm_My(query);
        }

    }
}
