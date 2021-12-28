using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SMART.DATA.V1;

namespace CanteenDaily
{
    public class DepartmentRightBLL
    {
        public List<DepartmentRight> All()
        {
            List<DepartmentRight> listya = new List<DepartmentRight>();

            try
            {
                string query = "select name, food_type, amount from department_rights dr inner join department d on d.dep_key = dr.department_id" 
                    + " inner join food_category fc on fc.food_type_id = dr.food_type_id"
                    + " inner join price_list pl on pl.category = fc.food_type_id where status = 1 order by name asc, food_type asc";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                foreach (DataRow r in dt.Rows)
                {
                    listya.Add(new DepartmentRight()
                    {
                        Amount = Convert.ToDouble(r["amount"].ToString()),
                        DepartmentName = r["name"].ToString(),
                        MealType = r["food_type"].ToString()
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
