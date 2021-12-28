namespace CanteenDaily
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_connection = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tssl_reader = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_fp = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueMealVoucherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueTeaVoucherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_connection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 242);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(353, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_connection
            // 
            this.tssl_connection.AutoSize = false;
            this.tssl_connection.Name = "tssl_connection";
            this.tssl_connection.Size = new System.Drawing.Size(118, 17);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_reader});
            this.statusStrip2.Location = new System.Drawing.Point(0, 24);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(353, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tssl_reader
            // 
            this.tssl_reader.AutoSize = false;
            this.tssl_reader.Name = "tssl_reader";
            this.tssl_reader.Size = new System.Drawing.Size(0, 17);
            // 
            // lbl_fp
            // 
            this.lbl_fp.AutoSize = true;
            this.lbl_fp.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fp.ForeColor = System.Drawing.Color.Red;
            this.lbl_fp.Location = new System.Drawing.Point(6, 25);
            this.lbl_fp.Name = "lbl_fp";
            this.lbl_fp.Size = new System.Drawing.Size(0, 22);
            this.lbl_fp.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(353, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issueMealVoucherToolStripMenuItem,
            this.issueTeaVoucherToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // issueMealVoucherToolStripMenuItem
            // 
            this.issueMealVoucherToolStripMenuItem.Name = "issueMealVoucherToolStripMenuItem";
            this.issueMealVoucherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.issueMealVoucherToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.issueMealVoucherToolStripMenuItem.Text = "Issue &Meal  Voucher";
            this.issueMealVoucherToolStripMenuItem.Click += new System.EventHandler(this.issueMealVoucherToolStripMenuItem_Click);
            // 
            // issueTeaVoucherToolStripMenuItem
            // 
            this.issueTeaVoucherToolStripMenuItem.Name = "issueTeaVoucherToolStripMenuItem";
            this.issueTeaVoucherToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.issueTeaVoucherToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.issueTeaVoucherToolStripMenuItem.Text = "Issue &Tea    Voucher";
            this.issueTeaVoucherToolStripMenuItem.Click += new System.EventHandler(this.issueTeaVoucherToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_fp);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 190);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 264);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.frm_Main_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_connection;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tssl_reader;
        private System.Windows.Forms.Label lbl_fp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueMealVoucherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueTeaVoucherToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        //private AxbiosmartLib.Axbiosmart start;
    }
}