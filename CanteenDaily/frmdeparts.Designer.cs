namespace CanteenDaily
{
    partial class frmdeparts
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
            this.cbodepart = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dtst = new System.Windows.Forms.DateTimePicker();
            this.cmdupdate = new System.Windows.Forms.Button();
            this.cmdclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start Date";
            // 
            // cbodepart
            // 
            this.cbodepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodepart.FormattingEnabled = true;
            this.cbodepart.Location = new System.Drawing.Point(102, 81);
            this.cbodepart.Name = "cbodepart";
            this.cbodepart.Size = new System.Drawing.Size(139, 21);
            this.cbodepart.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 127);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Update previous days costings";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dtst
            // 
            this.dtst.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtst.Location = new System.Drawing.Point(102, 163);
            this.dtst.Name = "dtst";
            this.dtst.Size = new System.Drawing.Size(136, 20);
            this.dtst.TabIndex = 5;
            // 
            // cmdupdate
            // 
            this.cmdupdate.Location = new System.Drawing.Point(32, 215);
            this.cmdupdate.Name = "cmdupdate";
            this.cmdupdate.Size = new System.Drawing.Size(75, 32);
            this.cmdupdate.TabIndex = 7;
            this.cmdupdate.Text = "Update";
            this.cmdupdate.UseVisualStyleBackColor = true;
            this.cmdupdate.Click += new System.EventHandler(this.cmdupdate_Click);
            // 
            // cmdclose
            // 
            this.cmdclose.Location = new System.Drawing.Point(163, 215);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(75, 32);
            this.cmdclose.TabIndex = 8;
            this.cmdclose.Text = "Cancel";
            this.cmdclose.UseVisualStyleBackColor = true;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // frmdeparts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 256);
            this.Controls.Add(this.cmdclose);
            this.Controls.Add(this.cmdupdate);
            this.Controls.Add(this.dtst);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbodepart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmdeparts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmdeparts";
            this.Load += new System.EventHandler(this.frmdeparts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbodepart;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dtst;
        private System.Windows.Forms.Button cmdupdate;
        private System.Windows.Forms.Button cmdclose;
    }
}