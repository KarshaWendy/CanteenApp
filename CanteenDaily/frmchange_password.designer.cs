namespace CanteenDaily
{
    partial class frmchange_password
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pass_change_oldpass = new System.Windows.Forms.TextBox();
            this.txt_pass_change_newpass = new System.Windows.Forms.TextBox();
            this.txt_pass_change_confirmpass = new System.Windows.Forms.TextBox();
            this.cmd_passwordchange_ok = new System.Windows.Forms.Button();
            this.cmd_passwordchange_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Pasword";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm New Password";
            // 
            // txt_pass_change_oldpass
            // 
            this.txt_pass_change_oldpass.Location = new System.Drawing.Point(154, 21);
            this.txt_pass_change_oldpass.Name = "txt_pass_change_oldpass";
            this.txt_pass_change_oldpass.PasswordChar = '*';
            this.txt_pass_change_oldpass.Size = new System.Drawing.Size(133, 20);
            this.txt_pass_change_oldpass.TabIndex = 3;
            this.txt_pass_change_oldpass.Leave += new System.EventHandler(this.txt_pass_change_oldpass_Leave);
            // 
            // txt_pass_change_newpass
            // 
            this.txt_pass_change_newpass.Location = new System.Drawing.Point(154, 69);
            this.txt_pass_change_newpass.Name = "txt_pass_change_newpass";
            this.txt_pass_change_newpass.PasswordChar = '*';
            this.txt_pass_change_newpass.Size = new System.Drawing.Size(133, 20);
            this.txt_pass_change_newpass.TabIndex = 4;
            this.txt_pass_change_newpass.Leave += new System.EventHandler(this.txt_pass_change_newpass_Leave);
            // 
            // txt_pass_change_confirmpass
            // 
            this.txt_pass_change_confirmpass.Location = new System.Drawing.Point(154, 114);
            this.txt_pass_change_confirmpass.Name = "txt_pass_change_confirmpass";
            this.txt_pass_change_confirmpass.PasswordChar = '*';
            this.txt_pass_change_confirmpass.Size = new System.Drawing.Size(133, 20);
            this.txt_pass_change_confirmpass.TabIndex = 5;
            this.txt_pass_change_confirmpass.TextChanged += new System.EventHandler(this.txt_pass_change_confirmpass_TextChanged);
            // 
            // cmd_passwordchange_ok
            // 
            this.cmd_passwordchange_ok.Location = new System.Drawing.Point(61, 158);
            this.cmd_passwordchange_ok.Name = "cmd_passwordchange_ok";
            this.cmd_passwordchange_ok.Size = new System.Drawing.Size(75, 28);
            this.cmd_passwordchange_ok.TabIndex = 6;
            this.cmd_passwordchange_ok.Text = "OK";
            this.cmd_passwordchange_ok.UseVisualStyleBackColor = true;
            this.cmd_passwordchange_ok.Click += new System.EventHandler(this.cmd_passwordchange_ok_Click);
            // 
            // cmd_passwordchange_cancel
            // 
            this.cmd_passwordchange_cancel.Location = new System.Drawing.Point(212, 158);
            this.cmd_passwordchange_cancel.Name = "cmd_passwordchange_cancel";
            this.cmd_passwordchange_cancel.Size = new System.Drawing.Size(75, 28);
            this.cmd_passwordchange_cancel.TabIndex = 7;
            this.cmd_passwordchange_cancel.Text = "Cancel";
            this.cmd_passwordchange_cancel.UseVisualStyleBackColor = true;
            this.cmd_passwordchange_cancel.Click += new System.EventHandler(this.cmd_passwordchange_cancel_Click);
            // 
            // frmchange_password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 198);
            this.Controls.Add(this.cmd_passwordchange_cancel);
            this.Controls.Add(this.cmd_passwordchange_ok);
            this.Controls.Add(this.txt_pass_change_confirmpass);
            this.Controls.Add(this.txt_pass_change_newpass);
            this.Controls.Add(this.txt_pass_change_oldpass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmchange_password";
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmchange_password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_pass_change_oldpass;
        private System.Windows.Forms.TextBox txt_pass_change_newpass;
        private System.Windows.Forms.TextBox txt_pass_change_confirmpass;
        private System.Windows.Forms.Button cmd_passwordchange_ok;
        private System.Windows.Forms.Button cmd_passwordchange_cancel;
    }
}