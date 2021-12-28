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
                Application.Run(new Form1());
            }
            catch (TypeInitializationException ex)
            {
                MessageBox.Show(ex.Message + "\n" +
                    ex.TypeName.ToString() + "\n" + ex.StackTrace +
                    "\n" + ex.InnerException);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace + ex.InnerException);
            }

        }
    }
}
