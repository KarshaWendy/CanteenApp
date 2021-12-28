namespace CanteenDaily
{
    partial class Form1
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
            this.mnuCanteen = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueMealCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueTeaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintananceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mealVoucherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grplogger = new System.Windows.Forms.GroupBox();
            this.lbluser = new System.Windows.Forms.Label();
            this.Panellogin = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.cmd_login = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.DateStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DateEnd = new System.Windows.Forms.DateTimePicker();
            this.grpBoxreports = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpIssuer = new System.Windows.Forms.GroupBox();
            this.endtime = new System.Windows.Forms.DateTimePicker();
            this.starttime = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbodepart = new System.Windows.Forms.ComboBox();
            this.txtstaffnumber = new System.Windows.Forms.TextBox();
            this.txtcardserial = new System.Windows.Forms.TextBox();
            this.txtcard_name = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ReadCard = new System.Windows.Forms.Button();
            this.cmd_save = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StatusCanteen = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bg_dowork = new System.ComponentModel.BackgroundWorker();
            this.cmd_startRun = new System.Windows.Forms.Button();
            this.cmd_teaRun = new System.Windows.Forms.Button();
            this.mnuCanteen.SuspendLayout();
            this.grplogger.SuspendLayout();
            this.Panellogin.SuspendLayout();
            this.grpBoxreports.SuspendLayout();
            this.grpIssuer.SuspendLayout();
            this.StatusCanteen.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuCanteen
            // 
            this.mnuCanteen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.cardToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.mnuCanteen.Location = new System.Drawing.Point(0, 0);
            this.mnuCanteen.Name = "mnuCanteen";
            this.mnuCanteen.Size = new System.Drawing.Size(832, 24);
            this.mnuCanteen.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrationToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.applicationsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.changToolStripMenuItem});
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.administrationToolStripMenuItem.Text = "&Administration";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.adminToolStripMenuItem.Text = "A&dministrator";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // changToolStripMenuItem
            // 
            this.changToolStripMenuItem.Name = "changToolStripMenuItem";
            this.changToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changToolStripMenuItem.Text = "&Change Password";
            this.changToolStripMenuItem.Click += new System.EventHandler(this.changToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.logOutToolStripMenuItem.Text = "&Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.applicationsToolStripMenuItem.Text = "&Restart";
            this.applicationsToolStripMenuItem.Click += new System.EventHandler(this.applicationsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cardToolStripMenuItem
            // 
            this.cardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issueCardsToolStripMenuItem,
            this.issueMealCardsToolStripMenuItem,
            this.issueTeaToolStripMenuItem,
            this.deactivateCardsToolStripMenuItem,
            this.maintananceToolStripMenuItem,
            this.mealVoucherToolStripMenuItem});
            this.cardToolStripMenuItem.Name = "cardToolStripMenuItem";
            this.cardToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.cardToolStripMenuItem.Text = "&Operations";
            // 
            // issueCardsToolStripMenuItem
            // 
            this.issueCardsToolStripMenuItem.Name = "issueCardsToolStripMenuItem";
            this.issueCardsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.issueCardsToolStripMenuItem.Text = "&Issue cards";
            this.issueCardsToolStripMenuItem.Click += new System.EventHandler(this.issueCardsToolStripMenuItem_Click);
            // 
            // issueMealCardsToolStripMenuItem
            // 
            this.issueMealCardsToolStripMenuItem.Name = "issueMealCardsToolStripMenuItem";
            this.issueMealCardsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.issueMealCardsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.issueMealCardsToolStripMenuItem.Text = "Issue &Meal Voucher";
            this.issueMealCardsToolStripMenuItem.Click += new System.EventHandler(this.issueMealCardsToolStripMenuItem_Click);
            // 
            // issueTeaToolStripMenuItem
            // 
            this.issueTeaToolStripMenuItem.Name = "issueTeaToolStripMenuItem";
            this.issueTeaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.issueTeaToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.issueTeaToolStripMenuItem.Text = "Issue &Tea Voucher";
            this.issueTeaToolStripMenuItem.Click += new System.EventHandler(this.issueTeaToolStripMenuItem_Click);
            // 
            // deactivateCardsToolStripMenuItem
            // 
            this.deactivateCardsToolStripMenuItem.Name = "deactivateCardsToolStripMenuItem";
            this.deactivateCardsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.deactivateCardsToolStripMenuItem.Text = "&Student Management";
            this.deactivateCardsToolStripMenuItem.Click += new System.EventHandler(this.deactivateCardsToolStripMenuItem_Click);
            // 
            // maintananceToolStripMenuItem
            // 
            this.maintananceToolStripMenuItem.Name = "maintananceToolStripMenuItem";
            this.maintananceToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.maintananceToolStripMenuItem.Text = "Mainta&nance";
            this.maintananceToolStripMenuItem.Click += new System.EventHandler(this.maintananceToolStripMenuItem_Click);
            // 
            // mealVoucherToolStripMenuItem
            // 
            this.mealVoucherToolStripMenuItem.Name = "mealVoucherToolStripMenuItem";
            this.mealVoucherToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.mealVoucherToolStripMenuItem.Text = "Meal Voucher";
            this.mealVoucherToolStripMenuItem.Visible = false;
            this.mealVoucherToolStripMenuItem.Click += new System.EventHandler(this.mealVoucherToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // generalReportToolStripMenuItem
            // 
            this.generalReportToolStripMenuItem.Name = "generalReportToolStripMenuItem";
            this.generalReportToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.generalReportToolStripMenuItem.Text = "&Meals Report";
            this.generalReportToolStripMenuItem.Click += new System.EventHandler(this.generalReportToolStripMenuItem_Click);
            // 
            // grplogger
            // 
            this.grplogger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grplogger.Controls.Add(this.lbluser);
            this.grplogger.Location = new System.Drawing.Point(605, 31);
            this.grplogger.Name = "grplogger";
            this.grplogger.Size = new System.Drawing.Size(182, 35);
            this.grplogger.TabIndex = 2;
            this.grplogger.TabStop = false;
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Location = new System.Drawing.Point(19, 18);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(0, 13);
            this.lbluser.TabIndex = 0;
            // 
            // Panellogin
            // 
            this.Panellogin.Controls.Add(this.txtPass);
            this.Panellogin.Controls.Add(this.cmd_login);
            this.Panellogin.Controls.Add(this.button1);
            this.Panellogin.Controls.Add(this.label2);
            this.Panellogin.Controls.Add(this.label1);
            this.Panellogin.Controls.Add(this.txtusername);
            this.Panellogin.Location = new System.Drawing.Point(6, 35);
            this.Panellogin.Name = "Panellogin";
            this.Panellogin.Size = new System.Drawing.Size(304, 137);
            this.Panellogin.TabIndex = 3;
            this.Panellogin.TabStop = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(131, 56);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(162, 20);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // cmd_login
            // 
            this.cmd_login.Location = new System.Drawing.Point(34, 91);
            this.cmd_login.Name = "cmd_login";
            this.cmd_login.Size = new System.Drawing.Size(100, 28);
            this.cmd_login.TabIndex = 2;
            this.cmd_login.Text = "&Login";
            this.cmd_login.UseVisualStyleBackColor = true;
            this.cmd_login.Click += new System.EventHandler(this.cmd_login_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Use Name";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(131, 19);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(162, 20);
            this.txtusername.TabIndex = 0;
            // 
            // DateStart
            // 
            this.DateStart.Location = new System.Drawing.Point(112, 21);
            this.DateStart.Name = "DateStart";
            this.DateStart.Size = new System.Drawing.Size(187, 20);
            this.DateStart.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Start Date";
            // 
            // cboDepartment
            // 
            this.cboDepartment.AllowDrop = true;
            this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Items.AddRange(new object[] {
            "Production",
            "Cold Drinks",
            "Production"});
            this.cboDepartment.Location = new System.Drawing.Point(112, 92);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(187, 21);
            this.cboDepartment.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Department";
            // 
            // DateEnd
            // 
            this.DateEnd.Location = new System.Drawing.Point(112, 55);
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.Size = new System.Drawing.Size(187, 20);
            this.DateEnd.TabIndex = 4;
            // 
            // grpBoxreports
            // 
            this.grpBoxreports.Controls.Add(this.label13);
            this.grpBoxreports.Controls.Add(this.label6);
            this.grpBoxreports.Controls.Add(this.DateEnd);
            this.grpBoxreports.Controls.Add(this.label5);
            this.grpBoxreports.Controls.Add(this.cboDepartment);
            this.grpBoxreports.Controls.Add(this.label4);
            this.grpBoxreports.Controls.Add(this.DateStart);
            this.grpBoxreports.Enabled = false;
            this.grpBoxreports.Location = new System.Drawing.Point(0, 27);
            this.grpBoxreports.Name = "grpBoxreports";
            this.grpBoxreports.Size = new System.Drawing.Size(310, 358);
            this.grpBoxreports.TabIndex = 4;
            this.grpBoxreports.TabStop = false;
            this.grpBoxreports.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 331);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "label13";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "End Date";
            // 
            // grpIssuer
            // 
            this.grpIssuer.Controls.Add(this.endtime);
            this.grpIssuer.Controls.Add(this.starttime);
            this.grpIssuer.Controls.Add(this.label12);
            this.grpIssuer.Controls.Add(this.label11);
            this.grpIssuer.Controls.Add(this.cbodepart);
            this.grpIssuer.Controls.Add(this.txtstaffnumber);
            this.grpIssuer.Controls.Add(this.txtcardserial);
            this.grpIssuer.Controls.Add(this.txtcard_name);
            this.grpIssuer.Controls.Add(this.label10);
            this.grpIssuer.Controls.Add(this.label9);
            this.grpIssuer.Controls.Add(this.label8);
            this.grpIssuer.Controls.Add(this.label7);
            this.grpIssuer.Controls.Add(this.ReadCard);
            this.grpIssuer.Controls.Add(this.cmd_save);
            this.grpIssuer.Controls.Add(this.button4);
            this.grpIssuer.Location = new System.Drawing.Point(492, 65);
            this.grpIssuer.Name = "grpIssuer";
            this.grpIssuer.Size = new System.Drawing.Size(328, 320);
            this.grpIssuer.TabIndex = 5;
            this.grpIssuer.TabStop = false;
            this.grpIssuer.Visible = false;
            // 
            // endtime
            // 
            this.endtime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endtime.Location = new System.Drawing.Point(112, 231);
            this.endtime.Name = "endtime";
            this.endtime.ShowCheckBox = true;
            this.endtime.ShowUpDown = true;
            this.endtime.Size = new System.Drawing.Size(183, 20);
            this.endtime.TabIndex = 14;
            // 
            // starttime
            // 
            this.starttime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.starttime.Location = new System.Drawing.Point(112, 203);
            this.starttime.Name = "starttime";
            this.starttime.ShowCheckBox = true;
            this.starttime.ShowUpDown = true;
            this.starttime.Size = new System.Drawing.Size(183, 20);
            this.starttime.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Eat End Time";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Eat Start Time";
            // 
            // cbodepart
            // 
            this.cbodepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodepart.FormattingEnabled = true;
            this.cbodepart.Location = new System.Drawing.Point(112, 153);
            this.cbodepart.Name = "cbodepart";
            this.cbodepart.Size = new System.Drawing.Size(182, 21);
            this.cbodepart.Sorted = true;
            this.cbodepart.TabIndex = 10;
            // 
            // txtstaffnumber
            // 
            this.txtstaffnumber.Location = new System.Drawing.Point(112, 43);
            this.txtstaffnumber.Name = "txtstaffnumber";
            this.txtstaffnumber.Size = new System.Drawing.Size(182, 20);
            this.txtstaffnumber.TabIndex = 9;
            this.txtstaffnumber.Leave += new System.EventHandler(this.txtstaffnumber_Leave);
            // 
            // txtcardserial
            // 
            this.txtcardserial.Location = new System.Drawing.Point(113, 118);
            this.txtcardserial.Name = "txtcardserial";
            this.txtcardserial.ReadOnly = true;
            this.txtcardserial.Size = new System.Drawing.Size(182, 20);
            this.txtcardserial.TabIndex = 8;
            this.txtcardserial.TextChanged += new System.EventHandler(this.txtcardserial_TextChanged);
            // 
            // txtcard_name
            // 
            this.txtcard_name.Location = new System.Drawing.Point(113, 83);
            this.txtcard_name.Name = "txtcard_name";
            this.txtcard_name.Size = new System.Drawing.Size(182, 20);
            this.txtcard_name.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Department";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Student Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Card Serial number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Card holder Name";
            // 
            // ReadCard
            // 
            this.ReadCard.Location = new System.Drawing.Point(14, 276);
            this.ReadCard.Name = "ReadCard";
            this.ReadCard.Size = new System.Drawing.Size(75, 28);
            this.ReadCard.TabIndex = 2;
            this.ReadCard.Text = "&ReadCard";
            this.ReadCard.UseVisualStyleBackColor = true;
            this.ReadCard.Click += new System.EventHandler(this.ReadCard_Click);
            // 
            // cmd_save
            // 
            this.cmd_save.Enabled = false;
            this.cmd_save.Location = new System.Drawing.Point(116, 276);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(75, 28);
            this.cmd_save.TabIndex = 1;
            this.cmd_save.Text = "&Save";
            this.cmd_save.UseVisualStyleBackColor = true;
            this.cmd_save.Click += new System.EventHandler(this.cmd_save_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(218, 276);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 28);
            this.button4.TabIndex = 0;
            this.button4.Text = "&Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // StatusCanteen
            // 
            this.StatusCanteen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.StatusCanteen.Location = new System.Drawing.Point(0, 400);
            this.StatusCanteen.Name = "StatusCanteen";
            this.StatusCanteen.Size = new System.Drawing.Size(832, 22);
            this.StatusCanteen.TabIndex = 9;
            this.StatusCanteen.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // bg_dowork
            // 
            this.bg_dowork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_dowork_DoWork);
            this.bg_dowork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_dowork_RunWorkerCompleted);
            // 
            // cmd_startRun
            // 
            this.cmd_startRun.Location = new System.Drawing.Point(317, 41);
            this.cmd_startRun.Name = "cmd_startRun";
            this.cmd_startRun.Size = new System.Drawing.Size(105, 25);
            this.cmd_startRun.TabIndex = 10;
            this.cmd_startRun.Text = "Start Food Run";
            this.cmd_startRun.UseVisualStyleBackColor = true;
            this.cmd_startRun.Visible = false;
            this.cmd_startRun.Click += new System.EventHandler(this.cmd_startRun_Click);
            // 
            // cmd_teaRun
            // 
            this.cmd_teaRun.Location = new System.Drawing.Point(317, 114);
            this.cmd_teaRun.Name = "cmd_teaRun";
            this.cmd_teaRun.Size = new System.Drawing.Size(105, 28);
            this.cmd_teaRun.TabIndex = 11;
            this.cmd_teaRun.Text = "Start Tea Run";
            this.cmd_teaRun.UseVisualStyleBackColor = true;
            this.cmd_teaRun.Visible = false;
            this.cmd_teaRun.Click += new System.EventHandler(this.cmd_teaRun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 422);
            this.Controls.Add(this.cmd_teaRun);
            this.Controls.Add(this.cmd_startRun);
            this.Controls.Add(this.StatusCanteen);
            this.Controls.Add(this.grpIssuer);
            this.Controls.Add(this.grplogger);
            this.Controls.Add(this.mnuCanteen);
            this.Controls.Add(this.Panellogin);
            this.Controls.Add(this.grpBoxreports);
            this.MainMenuStrip = this.mnuCanteen;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mnuCanteen.ResumeLayout(false);
            this.mnuCanteen.PerformLayout();
            this.grplogger.ResumeLayout(false);
            this.grplogger.PerformLayout();
            this.Panellogin.ResumeLayout(false);
            this.Panellogin.PerformLayout();
            this.grpBoxreports.ResumeLayout(false);
            this.grpBoxreports.PerformLayout();
            this.grpIssuer.ResumeLayout(false);
            this.grpIssuer.PerformLayout();
            this.StatusCanteen.ResumeLayout(false);
            this.StatusCanteen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuCanteen;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueMealCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalReportToolStripMenuItem;
        private System.Windows.Forms.GroupBox grplogger;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.GroupBox Panellogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button cmd_login;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.DateTimePicker DateStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DateEnd;
        private System.Windows.Forms.GroupBox grpBoxreports;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpIssuer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ReadCard;
        private System.Windows.Forms.Button cmd_save;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbodepart;
        private System.Windows.Forms.TextBox txtstaffnumber;
        private System.Windows.Forms.TextBox txtcardserial;
        private System.Windows.Forms.TextBox txtcard_name;
        private System.Windows.Forms.DateTimePicker endtime;
        private System.Windows.Forms.DateTimePicker starttime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusCanteen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintananceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueTeaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bg_dowork;
        private System.Windows.Forms.ToolStripMenuItem mealVoucherToolStripMenuItem;
        private System.Windows.Forms.Button cmd_startRun;
        private System.Windows.Forms.Button cmd_teaRun;
    }
}

