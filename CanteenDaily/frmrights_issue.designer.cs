namespace CanteenDaily
{
    partial class frmrights_issue
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.user_create = new System.Windows.Forms.TabPage();
            this.chk_new_user = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgview_users = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo_user_state = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmd_user_add = new System.Windows.Forms.Button();
            this.cbo_user_group = new System.Windows.Forms.ComboBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_user_rname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.group_create = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.cmd_rights_remove = new System.Windows.Forms.Button();
            this.cmd_rights_add = new System.Windows.Forms.Button();
            this.pnl_available_rights = new System.Windows.Forms.Panel();
            this.dgview_available_rights = new System.Windows.Forms.DataGridView();
            this.pnl_userg_rights = new System.Windows.Forms.Panel();
            this.dgview_group_rights = new System.Windows.Forms.DataGridView();
            this.pnl_new_user_g = new System.Windows.Forms.Panel();
            this.cmd_userg_add = new System.Windows.Forms.Button();
            this.txt_user_g_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chk_new_user_group = new System.Windows.Forms.CheckBox();
            this.dep_tab = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgview_deps = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmd_saveDep = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_food = new System.Windows.Forms.CheckBox();
            this.chk_tea = new System.Windows.Forms.CheckBox();
            this.txt_department = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_price = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgview_priceList = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmd_priceCancel = new System.Windows.Forms.Button();
            this.cmd_addPrice = new System.Windows.Forms.Button();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbo_mealType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.user_create.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview_users)).BeginInit();
            this.panel1.SuspendLayout();
            this.group_create.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.pnl_available_rights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview_available_rights)).BeginInit();
            this.pnl_userg_rights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview_group_rights)).BeginInit();
            this.pnl_new_user_g.SuspendLayout();
            this.dep_tab.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview_deps)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tb_price.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview_priceList)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.user_create);
            this.tabControl1.Controls.Add(this.group_create);
            this.tabControl1.Controls.Add(this.dep_tab);
            this.tabControl1.Controls.Add(this.tb_price);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1237, 489);
            this.tabControl1.TabIndex = 0;
            // 
            // user_create
            // 
            this.user_create.Controls.Add(this.chk_new_user);
            this.user_create.Controls.Add(this.panel2);
            this.user_create.Controls.Add(this.panel1);
            this.user_create.Location = new System.Drawing.Point(4, 22);
            this.user_create.Name = "user_create";
            this.user_create.Padding = new System.Windows.Forms.Padding(3);
            this.user_create.Size = new System.Drawing.Size(1229, 463);
            this.user_create.TabIndex = 0;
            this.user_create.Text = "User Creation";
            this.user_create.UseVisualStyleBackColor = true;
            // 
            // chk_new_user
            // 
            this.chk_new_user.AutoSize = true;
            this.chk_new_user.Location = new System.Drawing.Point(31, 20);
            this.chk_new_user.Name = "chk_new_user";
            this.chk_new_user.Size = new System.Drawing.Size(73, 17);
            this.chk_new_user.TabIndex = 2;
            this.chk_new_user.Text = "New User";
            this.chk_new_user.UseVisualStyleBackColor = true;
            this.chk_new_user.CheckedChanged += new System.EventHandler(this.chk_new_user_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.dgview_users);
            this.panel2.Location = new System.Drawing.Point(270, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 407);
            this.panel2.TabIndex = 1;
            // 
            // dgview_users
            // 
            this.dgview_users.AllowUserToAddRows = false;
            this.dgview_users.AllowUserToDeleteRows = false;
            this.dgview_users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgview_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview_users.Location = new System.Drawing.Point(3, 3);
            this.dgview_users.Name = "dgview_users";
            this.dgview_users.Size = new System.Drawing.Size(947, 401);
            this.dgview_users.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.cbo_user_state);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmd_user_add);
            this.panel1.Controls.Add(this.cbo_user_group);
            this.panel1.Controls.Add(this.txt_username);
            this.panel1.Controls.Add(this.txt_user_rname);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 406);
            this.panel1.TabIndex = 0;
            // 
            // cbo_user_state
            // 
            this.cbo_user_state.FormattingEnabled = true;
            this.cbo_user_state.Location = new System.Drawing.Point(96, 164);
            this.cbo_user_state.Name = "cbo_user_state";
            this.cbo_user_state.Size = new System.Drawing.Size(138, 21);
            this.cbo_user_state.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "User State";
            // 
            // cmd_user_add
            // 
            this.cmd_user_add.Location = new System.Drawing.Point(159, 212);
            this.cmd_user_add.Name = "cmd_user_add";
            this.cmd_user_add.Size = new System.Drawing.Size(75, 23);
            this.cmd_user_add.TabIndex = 6;
            this.cmd_user_add.Text = "Add User";
            this.cmd_user_add.UseVisualStyleBackColor = true;
            this.cmd_user_add.Click += new System.EventHandler(this.cmd_user_add_Click);
            // 
            // cbo_user_group
            // 
            this.cbo_user_group.FormattingEnabled = true;
            this.cbo_user_group.Location = new System.Drawing.Point(96, 119);
            this.cbo_user_group.Name = "cbo_user_group";
            this.cbo_user_group.Size = new System.Drawing.Size(138, 21);
            this.cbo_user_group.TabIndex = 5;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(96, 71);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(138, 20);
            this.txt_username.TabIndex = 4;
            // 
            // txt_user_rname
            // 
            this.txt_user_rname.Location = new System.Drawing.Point(96, 25);
            this.txt_user_rname.Name = "txt_user_rname";
            this.txt_user_rname.Size = new System.Drawing.Size(138, 20);
            this.txt_user_rname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Names";
            // 
            // group_create
            // 
            this.group_create.Controls.Add(this.label7);
            this.group_create.Controls.Add(this.label6);
            this.group_create.Controls.Add(this.panel3);
            this.group_create.Controls.Add(this.cmd_rights_remove);
            this.group_create.Controls.Add(this.cmd_rights_add);
            this.group_create.Controls.Add(this.pnl_available_rights);
            this.group_create.Controls.Add(this.pnl_userg_rights);
            this.group_create.Controls.Add(this.pnl_new_user_g);
            this.group_create.Controls.Add(this.chk_new_user_group);
            this.group_create.Location = new System.Drawing.Point(4, 22);
            this.group_create.Name = "group_create";
            this.group_create.Padding = new System.Windows.Forms.Padding(3);
            this.group_create.Size = new System.Drawing.Size(1229, 463);
            this.group_create.TabIndex = 1;
            this.group_create.Text = "User Group Creation";
            this.group_create.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(984, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Available Rights";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(378, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Group Rights";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.Controls.Add(this.dataGridView3);
            this.panel3.Location = new System.Drawing.Point(22, 266);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 191);
            this.panel3.TabIndex = 7;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(248, 185);
            this.dataGridView3.TabIndex = 7;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            this.dataGridView3.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentDoubleClick);
            // 
            // cmd_rights_remove
            // 
            this.cmd_rights_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_rights_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_rights_remove.Location = new System.Drawing.Point(648, 24);
            this.cmd_rights_remove.Name = "cmd_rights_remove";
            this.cmd_rights_remove.Size = new System.Drawing.Size(89, 29);
            this.cmd_rights_remove.TabIndex = 6;
            this.cmd_rights_remove.Text = "Remove Rights";
            this.cmd_rights_remove.UseVisualStyleBackColor = true;
            this.cmd_rights_remove.Click += new System.EventHandler(this.cmd_rights_remove_Click);
            // 
            // cmd_rights_add
            // 
            this.cmd_rights_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_rights_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_rights_add.Location = new System.Drawing.Point(573, 24);
            this.cmd_rights_add.Name = "cmd_rights_add";
            this.cmd_rights_add.Size = new System.Drawing.Size(69, 29);
            this.cmd_rights_add.TabIndex = 5;
            this.cmd_rights_add.Text = "Add Rights";
            this.cmd_rights_add.UseVisualStyleBackColor = true;
            this.cmd_rights_add.Click += new System.EventHandler(this.cmd_rights_add_Click);
            // 
            // pnl_available_rights
            // 
            this.pnl_available_rights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_available_rights.BackColor = System.Drawing.Color.Tan;
            this.pnl_available_rights.Controls.Add(this.dgview_available_rights);
            this.pnl_available_rights.Location = new System.Drawing.Point(733, 56);
            this.pnl_available_rights.Name = "pnl_available_rights";
            this.pnl_available_rights.Size = new System.Drawing.Size(490, 401);
            this.pnl_available_rights.TabIndex = 4;
            // 
            // dgview_available_rights
            // 
            this.dgview_available_rights.AllowUserToAddRows = false;
            this.dgview_available_rights.AllowUserToDeleteRows = false;
            this.dgview_available_rights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgview_available_rights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview_available_rights.Location = new System.Drawing.Point(3, 3);
            this.dgview_available_rights.Name = "dgview_available_rights";
            this.dgview_available_rights.Size = new System.Drawing.Size(484, 395);
            this.dgview_available_rights.TabIndex = 1;
            // 
            // pnl_userg_rights
            // 
            this.pnl_userg_rights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_userg_rights.BackColor = System.Drawing.Color.Tan;
            this.pnl_userg_rights.Controls.Add(this.dgview_group_rights);
            this.pnl_userg_rights.Location = new System.Drawing.Point(282, 56);
            this.pnl_userg_rights.Name = "pnl_userg_rights";
            this.pnl_userg_rights.Size = new System.Drawing.Size(445, 401);
            this.pnl_userg_rights.TabIndex = 3;
            // 
            // dgview_group_rights
            // 
            this.dgview_group_rights.AllowUserToAddRows = false;
            this.dgview_group_rights.AllowUserToDeleteRows = false;
            this.dgview_group_rights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgview_group_rights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview_group_rights.Location = new System.Drawing.Point(3, 3);
            this.dgview_group_rights.Name = "dgview_group_rights";
            this.dgview_group_rights.Size = new System.Drawing.Size(439, 395);
            this.dgview_group_rights.TabIndex = 0;
            // 
            // pnl_new_user_g
            // 
            this.pnl_new_user_g.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_new_user_g.BackColor = System.Drawing.Color.Tan;
            this.pnl_new_user_g.Controls.Add(this.cmd_userg_add);
            this.pnl_new_user_g.Controls.Add(this.txt_user_g_name);
            this.pnl_new_user_g.Controls.Add(this.label5);
            this.pnl_new_user_g.Location = new System.Drawing.Point(22, 56);
            this.pnl_new_user_g.Name = "pnl_new_user_g";
            this.pnl_new_user_g.Size = new System.Drawing.Size(254, 179);
            this.pnl_new_user_g.TabIndex = 1;
            // 
            // cmd_userg_add
            // 
            this.cmd_userg_add.Location = new System.Drawing.Point(154, 71);
            this.cmd_userg_add.Name = "cmd_userg_add";
            this.cmd_userg_add.Size = new System.Drawing.Size(75, 23);
            this.cmd_userg_add.TabIndex = 2;
            this.cmd_userg_add.Text = "Add Group";
            this.cmd_userg_add.UseVisualStyleBackColor = true;
            this.cmd_userg_add.Click += new System.EventHandler(this.cmd_userg_add_Click);
            // 
            // txt_user_g_name
            // 
            this.txt_user_g_name.Location = new System.Drawing.Point(92, 25);
            this.txt_user_g_name.Name = "txt_user_g_name";
            this.txt_user_g_name.Size = new System.Drawing.Size(137, 20);
            this.txt_user_g_name.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Group Name";
            // 
            // chk_new_user_group
            // 
            this.chk_new_user_group.AutoSize = true;
            this.chk_new_user_group.Location = new System.Drawing.Point(22, 33);
            this.chk_new_user_group.Name = "chk_new_user_group";
            this.chk_new_user_group.Size = new System.Drawing.Size(80, 17);
            this.chk_new_user_group.TabIndex = 0;
            this.chk_new_user_group.Text = "User Group";
            this.chk_new_user_group.UseVisualStyleBackColor = true;
            this.chk_new_user_group.CheckedChanged += new System.EventHandler(this.chk_new_user_group_CheckedChanged);
            // 
            // dep_tab
            // 
            this.dep_tab.Controls.Add(this.panel5);
            this.dep_tab.Controls.Add(this.panel4);
            this.dep_tab.Location = new System.Drawing.Point(4, 22);
            this.dep_tab.Name = "dep_tab";
            this.dep_tab.Size = new System.Drawing.Size(1229, 463);
            this.dep_tab.TabIndex = 2;
            this.dep_tab.Text = "Departments";
            this.dep_tab.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Tan;
            this.panel5.Controls.Add(this.dgview_deps);
            this.panel5.Location = new System.Drawing.Point(336, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(577, 457);
            this.panel5.TabIndex = 1;
            // 
            // dgview_deps
            // 
            this.dgview_deps.AllowUserToAddRows = false;
            this.dgview_deps.AllowUserToDeleteRows = false;
            this.dgview_deps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview_deps.Location = new System.Drawing.Point(3, 3);
            this.dgview_deps.MultiSelect = false;
            this.dgview_deps.Name = "dgview_deps";
            this.dgview_deps.ReadOnly = true;
            this.dgview_deps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview_deps.Size = new System.Drawing.Size(561, 451);
            this.dgview_deps.TabIndex = 0;
            this.dgview_deps.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgview_deps_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Tan;
            this.panel4.Controls.Add(this.cmd_saveDep);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.txt_department);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(318, 457);
            this.panel4.TabIndex = 0;
            // 
            // cmd_saveDep
            // 
            this.cmd_saveDep.Location = new System.Drawing.Point(15, 207);
            this.cmd_saveDep.Name = "cmd_saveDep";
            this.cmd_saveDep.Size = new System.Drawing.Size(98, 32);
            this.cmd_saveDep.TabIndex = 5;
            this.cmd_saveDep.Text = "Save";
            this.cmd_saveDep.UseVisualStyleBackColor = true;
            this.cmd_saveDep.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_food);
            this.groupBox1.Controls.Add(this.chk_tea);
            this.groupBox1.Location = new System.Drawing.Point(15, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meal Access";
            // 
            // chk_food
            // 
            this.chk_food.AutoSize = true;
            this.chk_food.Location = new System.Drawing.Point(40, 29);
            this.chk_food.Name = "chk_food";
            this.chk_food.Size = new System.Drawing.Size(50, 17);
            this.chk_food.TabIndex = 2;
            this.chk_food.Text = "Food";
            this.chk_food.UseVisualStyleBackColor = true;
            // 
            // chk_tea
            // 
            this.chk_tea.AutoSize = true;
            this.chk_tea.Location = new System.Drawing.Point(171, 29);
            this.chk_tea.Name = "chk_tea";
            this.chk_tea.Size = new System.Drawing.Size(45, 17);
            this.chk_tea.TabIndex = 3;
            this.chk_tea.Text = "Tea";
            this.chk_tea.UseVisualStyleBackColor = true;
            // 
            // txt_department
            // 
            this.txt_department.Location = new System.Drawing.Point(129, 37);
            this.txt_department.Name = "txt_department";
            this.txt_department.Size = new System.Drawing.Size(174, 20);
            this.txt_department.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Department Name";
            // 
            // tb_price
            // 
            this.tb_price.Controls.Add(this.panel7);
            this.tb_price.Controls.Add(this.panel6);
            this.tb_price.Location = new System.Drawing.Point(4, 22);
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(1229, 463);
            this.tb_price.TabIndex = 3;
            this.tb_price.Text = "Meal Pricing";
            this.tb_price.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.dgview_priceList);
            this.panel7.Location = new System.Drawing.Point(323, 12);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(592, 336);
            this.panel7.TabIndex = 1;
            // 
            // dgview_priceList
            // 
            this.dgview_priceList.AllowUserToAddRows = false;
            this.dgview_priceList.AllowUserToDeleteRows = false;
            this.dgview_priceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview_priceList.Location = new System.Drawing.Point(3, 3);
            this.dgview_priceList.Name = "dgview_priceList";
            this.dgview_priceList.Size = new System.Drawing.Size(573, 315);
            this.dgview_priceList.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmd_priceCancel);
            this.panel6.Controls.Add(this.cmd_addPrice);
            this.panel6.Controls.Add(this.txt_amount);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.cbo_mealType);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(16, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(298, 156);
            this.panel6.TabIndex = 0;
            // 
            // cmd_priceCancel
            // 
            this.cmd_priceCancel.Location = new System.Drawing.Point(189, 105);
            this.cmd_priceCancel.Name = "cmd_priceCancel";
            this.cmd_priceCancel.Size = new System.Drawing.Size(98, 29);
            this.cmd_priceCancel.TabIndex = 5;
            this.cmd_priceCancel.Text = "Cancel";
            this.cmd_priceCancel.UseVisualStyleBackColor = true;
            // 
            // cmd_addPrice
            // 
            this.cmd_addPrice.Location = new System.Drawing.Point(74, 105);
            this.cmd_addPrice.Name = "cmd_addPrice";
            this.cmd_addPrice.Size = new System.Drawing.Size(81, 29);
            this.cmd_addPrice.TabIndex = 4;
            this.cmd_addPrice.Text = "Add Price";
            this.cmd_addPrice.UseVisualStyleBackColor = true;
            this.cmd_addPrice.Click += new System.EventHandler(this.cmd_addPrice_Click);
            // 
            // txt_amount
            // 
            this.txt_amount.Location = new System.Drawing.Point(118, 59);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(169, 20);
            this.txt_amount.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Amount";
            // 
            // cbo_mealType
            // 
            this.cbo_mealType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mealType.FormattingEnabled = true;
            this.cbo_mealType.Location = new System.Drawing.Point(118, 11);
            this.cbo_mealType.Name = "cbo_mealType";
            this.cbo_mealType.Size = new System.Drawing.Size(169, 21);
            this.cbo_mealType.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Meal Type";
            // 
            // frmrights_issue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 513);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmrights_issue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rights Assignement";
            this.Load += new System.EventHandler(this.frmrights_issue_Load);
            this.tabControl1.ResumeLayout(false);
            this.user_create.ResumeLayout(false);
            this.user_create.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgview_users)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.group_create.ResumeLayout(false);
            this.group_create.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.pnl_available_rights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgview_available_rights)).EndInit();
            this.pnl_userg_rights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgview_group_rights)).EndInit();
            this.pnl_new_user_g.ResumeLayout(false);
            this.pnl_new_user_g.PerformLayout();
            this.dep_tab.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgview_deps)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tb_price.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgview_priceList)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage user_create;
        private System.Windows.Forms.TabPage group_create;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbo_user_group;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_user_rname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgview_users;
        private System.Windows.Forms.Button cmd_user_add;
        private System.Windows.Forms.ComboBox cbo_user_state;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_new_user;
        private System.Windows.Forms.CheckBox chk_new_user_group;
        private System.Windows.Forms.Button cmd_rights_remove;
        private System.Windows.Forms.Button cmd_rights_add;
        private System.Windows.Forms.Panel pnl_available_rights;
        private System.Windows.Forms.Panel pnl_userg_rights;
        private System.Windows.Forms.Panel pnl_new_user_g;
        private System.Windows.Forms.Button cmd_userg_add;
        private System.Windows.Forms.TextBox txt_user_g_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgview_available_rights;
        private System.Windows.Forms.DataGridView dgview_group_rights;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage dep_tab;
        private System.Windows.Forms.TabPage tb_price;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chk_tea;
        private System.Windows.Forms.CheckBox chk_food;
        private System.Windows.Forms.TextBox txt_department;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmd_saveDep;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgview_deps;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgview_priceList;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button cmd_priceCancel;
        private System.Windows.Forms.Button cmd_addPrice;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbo_mealType;
        private System.Windows.Forms.Label label9;
    }
}