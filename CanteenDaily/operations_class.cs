using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace CanteenDaily
{   
    public class writetxt
    {
        private writetxt()
        {

        }

        static public void andikatxt(string wrt,string path)
        {
            StreamWriter sw = File.AppendText(Application.StartupPath + path);
            sw.WriteLine("=================================");
            sw.WriteLine(DateTime.Now.ToString("MM-dd-yyyy hh:mm ss tt"));
            sw.WriteLine("=================================");
            sw.WriteLine(wrt);
            sw.WriteLine("=================================");
            sw.Close();
        }

        static public void modifydgview(DataGridView dv, int col_location)
        {
            try
            {
                foreach (DataGridViewRow dr in dv.Rows)
                {
                    if (dr.Cells[col_location].Value.ToString().Equals("Grand Total"))
                    {
                        dr.DefaultCellStyle.ForeColor = Color.Red;
                        dr.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                        dr.DefaultCellStyle.BackColor = Color.Silver;
                    }
                }
            }
            catch
            {

            }
        }
    }

   
}
