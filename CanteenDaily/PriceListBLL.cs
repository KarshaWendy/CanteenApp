using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SMART.DATA.V1;

namespace CanteenDaily
{
    public class PriceListBLL
    {
        public List<PriceList> All()
        {
            List<PriceList> listya = new List<PriceList>();

            try
            {
                string query = "select food_type, status, amount, pl.entry_date from price_list pl "
                            + " inner join food_category fc on fc.food_type_id = category where status = 1 order by status desc";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                foreach (DataRow r in dt.Rows)
                {
                    listya.Add(new PriceList() 
                    {
                        Amount = Convert.ToDouble(r["amount"].ToString()),
                        InsertDate = Convert.ToDateTime(r["entry_date"].ToString()),
                        Name = r["food_type"].ToString(),
                        Status = Convert.ToInt16(r["status"].ToString()) 
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
