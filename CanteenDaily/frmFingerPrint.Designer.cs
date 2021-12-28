namespace CanteenDaily
{
    partial class frmFingerPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFingerPrint));
            this.lbl_printToUse = new System.Windows.Forms.Label();
            this.Start = new AxPENTACOMBIOMETRICFINGERPRINTLib.AxPentacomBiometricFingerprint();
            ((System.ComponentModel.ISupportInitialize)(this.Start)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_printToUse
            // 
            this.lbl_printToUse.BackColor = System.Drawing.Color.MistyRose;
            this.lbl_printToUse.Location = new System.Drawing.Point(10, 13);
            this.lbl_printToUse.Name = "lbl_printToUse";
            this.lbl_printToUse.Size = new System.Drawing.Size(222, 58);
            this.lbl_printToUse.TabIndex = 1;
            // 
            // Start
            // 
            this.Start.Enabled = true;
            this.Start.Location = new System.Drawing.Point(13, 84);
            this.Start.Name = "Start";
            this.Start.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Start.OcxState")));
            this.Start.Size = new System.Drawing.Size(135, 150);
            this.Start.TabIndex = 2;
            // 
            // frmFingerPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 311);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.lbl_printToUse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFingerPrint";
            this.Text = "FingerPrint";
            ((System.ComponentModel.ISupportInitialize)(this.Start)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_printToUse;
        private AxPENTACOMBIOMETRICFINGERPRINTLib.AxPentacomBiometricFingerprint Start;
    }
}