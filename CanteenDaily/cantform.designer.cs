namespace SmartCanteen
{
    partial class FrmReports
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.startdate = new System.Windows.Forms.DateTimePicker();
            this.enddate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbodepart = new System.Windows.Forms.ComboBox();
            this.chk_groupReport = new System.Windows.Forms.CheckBox();
            this.chkdep = new System.Windows.Forms.CheckBox();
            this.chkdates = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.cmbgtype = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdsave = new System.Windows.Forms.Button();
            this.chk_mealtime = new System.Windows.Forms.CheckBox();
            this.cbo_mealtime = new System.Windows.Forms.ComboBox();
            this.chk_mealtype = new System.Windows.Forms.CheckBox();
            this.cbo_mealtype = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            this.SuspendLayout();
            // 
            // startdate
            // 
            this.startdate.Location = new System.Drawing.Point(126, 51);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(184, 20);
            this.startdate.TabIndex = 0;
            // 
            // enddate
            // 
            this.enddate.Location = new System.Drawing.Point(126, 91);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(184, 20);
            this.enddate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // cbodepart
            // 
            this.cbodepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodepart.FormattingEnabled = true;
            this.cbodepart.Location = new System.Drawing.Point(470, 43);
            this.cbodepart.Name = "cbodepart";
            this.cbodepart.Size = new System.Drawing.Size(162, 21);
            this.cbodepart.TabIndex = 4;
            // 
            // chk_groupReport
            // 
            this.chk_groupReport.AutoSize = true;
            this.chk_groupReport.Location = new System.Drawing.Point(351, 87);
            this.chk_groupReport.Name = "chk_groupReport";
            this.chk_groupReport.Size = new System.Drawing.Size(90, 17);
            this.chk_groupReport.TabIndex = 8;
            this.chk_groupReport.Text = "Group Report\r\n";
            this.chk_groupReport.UseVisualStyleBackColor = true;
            this.chk_groupReport.CheckedChanged += new System.EventHandler(this.chk_groupReport_CheckedChanged);
            // 
            // chkdep
            // 
            this.chkdep.AutoSize = true;
            this.chkdep.Location = new System.Drawing.Point(351, 43);
            this.chkdep.Name = "chkdep";
            this.chkdep.Size = new System.Drawing.Size(81, 17);
            this.chkdep.TabIndex = 9;
            this.chkdep.Text = "Department";
            this.chkdep.UseVisualStyleBackColor = true;
            this.chkdep.CheckedChanged += new System.EventHandler(this.chkdep_CheckedChanged);
            // 
            // chkdates
            // 
            this.chkdates.AutoSize = true;
            this.chkdates.Location = new System.Drawing.Point(15, 18);
            this.chkdates.Name = "chkdates";
            this.chkdates.Size = new System.Drawing.Size(93, 17);
            this.chkdates.TabIndex = 10;
            this.chkdates.Text = "Choose Dates";
            this.chkdates.UseVisualStyleBackColor = true;
            this.chkdates.CheckedChanged += new System.EventHandler(this.chkdates_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(895, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "View report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(997, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(50, 17);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Location = new System.Drawing.Point(15, 137);
            this.dgview.Name = "dgview";
            this.dgview.ReadOnly = true;
            this.dgview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgview.RowHeadersVisible = false;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.Size = new System.Drawing.Size(849, 294);
            this.dgview.TabIndex = 15;
            // 
            // cmbgtype
            // 
            this.cmbgtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgtype.FormattingEnabled = true;
            this.cmbgtype.Items.AddRange(new object[] {
            "Staffnumber",
            "department"});
            this.cmbgtype.Location = new System.Drawing.Point(459, 87);
            this.cmbgtype.Name = "cmbgtype";
            this.cmbgtype.Size = new System.Drawing.Size(162, 21);
            this.cmbgtype.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(892, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Grand Total";
            // 
            // txttotal
            // 
            this.txttotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotal.ForeColor = System.Drawing.Color.Red;
            this.txttotal.Location = new System.Drawing.Point(877, 414);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(120, 20);
            this.txttotal.TabIndex = 20;
            this.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(892, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "label4";
            // 
            // cmdsave
            // 
            this.cmdsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdsave.Location = new System.Drawing.Point(895, 213);
            this.cmdsave.Name = "cmdsave";
            this.cmdsave.Size = new System.Drawing.Size(87, 29);
            this.cmdsave.TabIndex = 22;
            this.cmdsave.Text = "Save to Excel";
            this.cmdsave.UseVisualStyleBackColor = true;
            this.cmdsave.Click += new System.EventHandler(this.cmdsave_Click);
            // 
            // chk_mealtime
            // 
            this.chk_mealtime.AutoSize = true;
            this.chk_mealtime.Location = new System.Drawing.Point(662, 38);
            this.chk_mealtime.Name = "chk_mealtime";
            this.chk_mealtime.Size = new System.Drawing.Size(75, 17);
            this.chk_mealtime.TabIndex = 23;
            this.chk_mealtime.Text = "Meal Time";
            this.chk_mealtime.UseVisualStyleBackColor = true;
            this.chk_mealtime.CheckedChanged += new System.EventHandler(this.chk_mealtime_CheckedChanged);
            // 
            // cbo_mealtime
            // 
            this.cbo_mealtime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mealtime.FormattingEnabled = true;
            this.cbo_mealtime.Items.AddRange(new object[] {
            "Day Time",
            "Night Time"});
            this.cbo_mealtime.Location = new System.Drawing.Point(781, 39);
            this.cbo_mealtime.Name = "cbo_mealtime";
            this.cbo_mealtime.Size = new System.Drawing.Size(162, 21);
            this.cbo_mealtime.TabIndex = 24;
            // 
            // chk_mealtype
            // 
            this.chk_mealtype.AutoSize = true;
            this.chk_mealtype.Location = new System.Drawing.Point(662, 87);
            this.chk_mealtype.Name = "chk_mealtype";
            this.chk_mealtype.Size = new System.Drawing.Size(76, 17);
            this.chk_mealtype.TabIndex = 25;
            this.chk_mealtype.Text = "Meal Type";
            this.chk_mealtype.UseVisualStyleBackColor = true;
            this.chk_mealtype.CheckedChanged += new System.EventHandler(this.chk_mealtype_CheckedChanged);
            // 
            // cbo_mealtype
            // 
            this.cbo_mealtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mealtype.FormattingEnabled = true;
            this.cbo_mealtype.Items.AddRange(new object[] {
            "FOOD",
            "TEA"});
            this.cbo_mealtype.Location = new System.Drawing.Point(781, 85);
            this.cbo_mealtype.Name = "cbo_mealtype";
            this.cbo_mealtype.Size = new System.Drawing.Size(162, 21);
            this.cbo_mealtype.TabIndex = 26;
            // 
            // FrmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 468);
            this.Controls.Add(this.cbo_mealtype);
            this.Controls.Add(this.chk_mealtype);
            this.Controls.Add(this.cbo_mealtime);
            this.Controls.Add(this.chk_mealtime);
            this.Controls.Add(this.cmdsave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbgtype);
            this.Controls.Add(this.dgview);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkdates);
            this.Controls.Add(this.chkdep);
            this.Controls.Add(this.chk_groupReport);
            this.Controls.Add(this.cbodepart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enddate);
            this.Controls.Add(this.startdate);
            this.Name = "FrmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canteen Reports";
            this.Load += new System.EventHandler(this.FrmReports_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker startdate;
        private System.Windows.Forms.DateTimePicker enddate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbodepart;
        private System.Windows.Forms.CheckBox chk_groupReport;
        private System.Windows.Forms.CheckBox chkdep;
        private System.Windows.Forms.CheckBox chkdates;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.DataGridView dgview;
        private System.Windows.Forms.ComboBox cmbgtype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdsave;
        private System.Windows.Forms.CheckBox chk_mealtime;
        private System.Windows.Forms.ComboBox cbo_mealtime;
        private System.Windows.Forms.CheckBox chk_mealtype;
        private System.Windows.Forms.ComboBox cbo_mealtype;
    }
}

