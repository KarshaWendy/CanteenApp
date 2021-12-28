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
    public partial class frmchange_password : Form
    {
        public frmchange_password()
        {
            InitializeComponent();
        }

        ta_operations rt = new ta_operations();

        private void cmd_passwordchange_ok_Click(object sender, EventArgs e)
        {
            if (txt_pass_change_newpass.Text != txt_pass_change_confirmpass.Text)
            {
                MessageBox.Show("Passwords Do Not Match!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_pass_change_newpass.Focus();
                txt_pass_change_newpass.Select(0, txt_pass_change_newpass.Text.Length);
            }
            else
            {

                string updt_comm = "update ta_users set password='" + ParametersGlobal.EncryptString(txt_pass_change_confirmpass.Text, "funguo") + "' where username_id=" + globalparams.user_id;
                
                DataBaseOperations.ExecuteComm_My(updt_comm);

                MessageBox.Show("Password change successful", "Information", MessageBoxButtons.OK);

                MessageBox.Show("The application will now restart to effect the changes!", "Information", MessageBoxButtons.OK);
                Application.Restart();
            }
        }

        private void txt_pass_change_oldpass_Leave(object sender, EventArgs e)
        {
            if (ParametersGlobal.EncryptString(txt_pass_change_oldpass.Text, "funguo") != globalparams.hold_p)
            {
                MessageBox.Show("The old Password Does not match your password!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_pass_change_oldpass.Focus();
                txt_pass_change_oldpass.Select(0, txt_pass_change_oldpass.Text.Length);
            }
        }

        private void frmchange_password_Load(object sender, EventArgs e)
        {
            cmd_passwordchange_ok.Enabled = false;
        }

        private void txt_pass_change_confirmpass_TextChanged(object sender, EventArgs e)
        {
            cmd_passwordchange_ok.Enabled = false;

            if (txt_pass_change_newpass.Text == txt_pass_change_confirmpass.Text)
            {
                cmd_passwordchange_ok.Enabled = true;
            }            
        }

        private void txt_pass_change_newpass_Leave(object sender, EventArgs e)
        {
            if (txt_pass_change_newpass.Text.Length < 5)
            {
                MessageBox.Show("The Password cannot be less than 5 characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_pass_change_newpass.Focus();
                txt_pass_change_newpass.Select(0, txt_pass_change_newpass.Text.Length);
            }
        }

        private void cmd_passwordchange_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
