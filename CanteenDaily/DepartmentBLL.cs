using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SMART.DATA.V1;

namespace CanteenDaily
{
    public class DepartmentBLL
    {
        public List<Department> All()
        {
            List<Department> listya = new List<Department>();

            try
            {
                string query = "select * from department order by name asc";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                foreach (DataRow r in dt.Rows)
                {
                    listya.Add(new Department()
                    {
                        DepartmentKey = r["dep_key"].ToString(),
                        Name = r["name"].ToString(),
                        Override = Convert.ToInt16(r["override"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listya;
        }
    }
}
