using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;

namespace CanteenDaily
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
               
                if(ParametersGlobal.LoadParameters())
                {
                    Application.Run(new Form1());
                }
                else
                {
                    MessageBox.Show("Something went wrong.\nUnable to start the application", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "\n" + ex.TypeName.ToString() + "\n" + ex.StackTrace + "\n" + ex.InnerException);
                MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
