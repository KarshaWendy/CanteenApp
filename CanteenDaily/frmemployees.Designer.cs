namespace CanteenDaily
{
    partial class frmemployees
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
            this.dgview = new System.Windows.Forms.DataGridView();
            this.cms_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deactivateCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCostingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            this.cms_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgview
            // 
            this.dgview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.ContextMenuStrip = this.cms_menu;
            this.dgview.Location = new System.Drawing.Point(12, 24);
            this.dgview.Name = "dgview";
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.Size = new System.Drawing.Size(788, 460);
            this.dgview.TabIndex = 0;
            // 
            // cms_menu
            // 
            this.cms_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deactivateCardToolStripMenuItem,
            this.changeCostingToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.cms_menu.Name = "cms_menu";
            this.cms_menu.Size = new System.Drawing.Size(160, 70);
            // 
            // deactivateCardToolStripMenuItem
            // 
            this.deactivateCardToolStripMenuItem.Name = "deactivateCardToolStripMenuItem";
            this.deactivateCardToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.deactivateCardToolStripMenuItem.Text = "Deactivate Card";
            this.deactivateCardToolStripMenuItem.Click += new System.EventHandler(this.deactivateCardToolStripMenuItem_Click);
            // 
            // changeCostingToolStripMenuItem
            // 
            this.changeCostingToolStripMenuItem.Name = "changeCostingToolStripMenuItem";
            this.changeCostingToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.changeCostingToolStripMenuItem.Text = "Change Costing";
            this.changeCostingToolStripMenuItem.Click += new System.EventHandler(this.changeCostingToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // frmemployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 496);
            this.Controls.Add(this.dgview);
            this.Name = "frmemployees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employees Roster";
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            this.cms_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgview;
        private System.Windows.Forms.ContextMenuStrip cms_menu;
        private System.Windows.Forms.ToolStripMenuItem deactivateCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCostingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
    }
}