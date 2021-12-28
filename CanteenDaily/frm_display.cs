using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenDaily
{
    public partial class frm_display : Form
    {
        public string displayMessage = string.Empty;

        public frm_display()
        {
            InitializeComponent();
        }

        private void TimerDisplay_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Start(string message)
        {
            Task.Factory.StartNew(() =>
             {
                 this.ShowDialog();
             });
        }

        public void Stop()
        {
            BeginInvoke((Action)delegate { this.Close(); });
        }

        private void frm_display_Shown(object sender, EventArgs e)
        {
            lbl_status.Invoke(new MethodInvoker(delegate { lbl_status.Text = displayMessage; }));
        }
    }
}
