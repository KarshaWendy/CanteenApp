using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
//using SmartCanteen;
using OTI.SmartLink.RETMsgMaker;
using SMART.DATA.V1;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace CanteenDaily
{
    public partial class Form1 : Form
    {
        //public XmlReaderWriterc Xml_reader = new XmlReaderWriterc();
        //public string CardDatabase = "";
        //public string HostServer = "";
        //public string gadmin = "";
        //public string guest = "";
        //public int Dbport = 3306;
        string type_meal = "";
        //public string UserName;
        DataSet ds = new DataSet();
        public DataTable price_dt;
        //int baudRate;
        //short portNumber;

        CardReader cardread = new CardReader();
        //AxMedismart readcard = new AxMedismart();

        public Form1()
        {
            InitializeComponent();
            //string FilePath = Application.StartupPath + "\\Application\\smisconfigSmart.xml";

            //if (File.Exists(FilePath))
            //{
                //DataSet configs_ds = new DataSet();
                //configs_ds.ReadXml(FilePath);

                //HostServer = configs_ds.Tables[0].Rows[0]["Server"].ToString();
                //int.TryParse(configs_ds.Tables[0].Rows[0]["port"].ToString(), out Dbport);
                //short.TryParse(configs_ds.Tables[0].Rows[0]["readerPort"].ToString(), out portNumber);
                //int.TryParse(configs_ds.Tables[0].Rows[0]["readerBaud"].ToString(), out baudRate);
                //CardDatabase = configs_ds.Tables[0].Rows[0]["db"].ToString();

                loaddetails();
            //}
            //else
            //{
            //    MessageBox.Show("Configuration Load Error.\r\nConfiguration file missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Smart Canteen.... Version [ " + Application.ProductVersion + " ]";
            this.cbodepart.AllowDrop = true;
            //Panellogin.Enabled = false;
            //Panellogin.Visible = false;
            this.mnuCanteen.Enabled = false;
            grplogger.Enabled = false;
            grplogger.Visible = false;
            ReadCard.Enabled = false;
            //UserName = "";
        }        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void loaddetails()
        {
            //gadmin = "";
            //guest = "";
            // read xml then proceed login
            toolStripStatusLabel3.Text = "    ";

            //try
            //{
            //string connstring = "server=" + HostServer + ";user id=root; password=smart123; database=smartcafet; port=" + Dbport + ";";

            // GlobalValues._MySqlConnection = connstring;

            //if (DataBaseOperations.CanConnect_My())
            //{
           
           
            //UserName = guest;
            //globalparams.user_name = UserName;
            grplogger.Enabled = true;
            grplogger.Visible = true;
            mnuCanteen.Enabled = true;
            mnuCanteen.Visible = true;
           
            Panellogin.Enabled = true;
            Panellogin.Visible = true;

            Globalparams.log_state = 1;

            ParametersGlobal.DepartmentRightList = deprightbll.All();
            ParametersGlobal.DepartmentList = departmentbll.All();
            ParametersGlobal.PriceList = pricelist.All();

            try
            {
                cardread = new CardReader();

                cardread.Initialize(ParametersGlobal.portNumber, ParametersGlobal.baudRate);

                toolStripStatusLabel1.Text = "Card Reader : Connected";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Card Reader : Not Connected";
                MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
            //else
            //{
            //    Application.Exit();                   
            //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //this.Close();
            //    Application.Exit();
            //}
        }

        void Login()
        {
            if (txtPass.Text == "")
            {
                MessageBox.Show("The Password cannot be empty!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
            }
            if (txtusername.Text == "")
            {
                MessageBox.Show("The user Name cannot be empty!", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusername.Focus();
            }
            if (txtusername.Text != "" && txtPass.Text != "")
            {
                DataTable dt = DataBaseOperations.ExecuteDataTable_My("select * from smartcafet.ta_users where user_name='" + txtusername.Text.Trim()
                    + "' and password='" + ParametersGlobal.EncryptString(txtPass.Text, "funguo") + "'");

                if (dt.Rows.Count > 0)
                {
                    Panellogin.Enabled = false;
                    Panellogin.Visible = false;

                    int group_id = Convert.ToInt16(dt.Rows[0]["fk_userg_id"].ToString());
                    Globalparams.hold_p = dt.Rows[0]["password"].ToString();
                    //globalparams.hold_p = dt.Rows[0]["password"].ToString();

                    ParametersGlobal.Rights_formTable = DataBaseOperations.ExecuteDataTable_My("select Module_Name,tm.Module_ID,Module_Description from ta_module_permissions tmp inner join ta_module tm on tmp.Module_ID = tm.Module_ID where Group_ID=" + group_id);
                    
                    if (ParametersGlobal.AccessForm("MDI HOME"))
                    {
                        Globalparams.rights_states = 1;
                        mnuCanteen.Enabled = true;

                        cmd_teaRun.Visible = true;
                        cmd_startRun.Visible = true;

                        ParametersGlobal.UserName = txtusername.Text.Trim();

                        lbluser.Text = "logged in as : " + dt.Rows[0]["Real_Names"].ToString();
                        toolStripStatusLabel3.Text = "Database Connected,   logged in as : " + dt.Rows[0]["Real_Names"].ToString();
                        //Load the departmental details i.e department food privileges and prices
                        bg_dowork.RunWorkerAsync();
                    }
                    else
                    {
                        mnuCanteen.Enabled = false;
                        Globalparams.rights_states = 0;
                        MessageBox.Show("You dont have enough Rights assigned to you. \r\n Consult"
                            + " your Supervisor for the neccessary rights.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please confirm your user name and password!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpBoxreports.Enabled = false;
            grpBoxreports.Visible = false;
            lbluser.Text = "";
            grplogger.Enabled = false;
            grplogger.Visible = false;
            Panellogin.Enabled = true;
            Panellogin.Visible = true;
            mnuCanteen.Enabled = false;
            mnuCanteen.Visible = false;
            txtPass.Text = " ";
            txtusername.Text = " ";
        }

        EmployeeBLL empbll = new EmployeeBLL();
        DailyFeedBLL feedbll = new DailyFeedBLL();
        DepartmentRightBLL deprightbll = new DepartmentRightBLL();
        PriceListBLL pricelist = new PriceListBLL();
        DepartmentBLL departmentbll = new DepartmentBLL();

        public void punch_cards(string ml_type)
        {
            string cardserial = cardread.GetCardSerial();

            if (cardserial != "")
            {
                Employee employeeDetail = empbll.FetchMember_BySerial(cardserial);

                // this checks if the membercard had been issued
                if (employeeDetail != null)
                {
                    string dep = employeeDetail.Department;

                    string dater = System.DateTime.Now.ToString();
                    //string CardConn = CardDatabase + ".dailyfeeds";

                    //Confirm whether the department is allowed to access meals/teal

                    if (ParametersGlobal.CheckDepartmentStatus(dep, type_meal))
                    {
                        var pricelist = ParametersGlobal.PriceList.FirstOrDefault(c => c.Name == type_meal);

                        DailyFeed feed = new DailyFeed()
                        {
                            Amount = pricelist.Amount,
                            CardName = employeeDetail.StaffName,
                            Department = employeeDetail.Department,
                            MealType = type_meal,
                            SerialNumber = employeeDetail.SerialNumber,
                            StaffNumber = employeeDetail.StaffNumber
                        };

                        if (type_meal == "TEA")
                        {
                            feedbll.TeaMeal(feed);
                        }
                        if (type_meal == "FOOD")
                        {
                            if (feedbll.CheckIFAlreadyFed(feed))
                            {
                                MessageBox.Show("The owner of this card has already \naccesed a meal", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cardserial = "";
                            }
                            else
                            {
                                // check if the person is meant to eat now

                                if (feedbll.AllowedToEatNow(employeeDetail))
                                {
                                    feedbll.AddFeed(feed);

                                    MessageBox.Show("Give a Meal Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("This card is not allowed to eat now come later", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The member belongs to the " + dep + " department \r\nwhich is not allowed to access " + type_meal, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    cardserial = "";
                }
                else
                {
                    //MessageBox.Show("This card has not been issued to the system");
                    MessageBox.Show("This card is not allowed to access meals", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cardserial = "";
                }
            }
            else
            {
                MessageBox.Show("Place card on reader and press F1");
            }
            cardserial = "";
        }

        public void punch_cards(string ml_type, bool unAttended)
        {
            try
            {
                string cardserial = cardread.GetCardSerial();

                if (!string.IsNullOrEmpty(cardserial))
                {
                    Employee employeeDetail = empbll.FetchMember_BySerial(cardserial);

                    // this checks if the membercard had been issued
                    if (employeeDetail != null)
                    {
                        string dep = employeeDetail.Department;

                        string dater = System.DateTime.Now.ToString();
                        //string CardConn = CardDatabase + ".dailyfeeds";

                        //Confirm whether the department is allowed to access meals/teal

                        if (ParametersGlobal.CheckDepartmentStatus(dep, type_meal))
                        {
                            var pricelist = ParametersGlobal.PriceList.FirstOrDefault(c => c.Name == type_meal);

                            DailyFeed feed = new DailyFeed()
                            {
                                Amount = pricelist.Amount,
                                CardName = employeeDetail.StaffName,
                                Department = employeeDetail.Department,
                                MealType = type_meal,
                                SerialNumber = employeeDetail.SerialNumber,
                                StaffNumber = employeeDetail.StaffNumber
                            };

                            if (type_meal == "TEA")
                            {
                                //feedbll.TeaMeal(feed);
                                TeaMeal(feed, unAttended);
                            }
                            if (type_meal == "FOOD")
                            {
                                if (feedbll.CheckIFAlreadyFed(feed))
                                {
                                    if (unAttended)
                                    {
                                        DisplayMessage("The owner of this card has already \naccesed a meal");
                                    }
                                    else
                                    {
                                        MessageBox.Show("The owner of this card has already \naccesed a meal", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    // check if the person is meant to eat now

                                    if (feedbll.AllowedToEatNow(employeeDetail))
                                    {
                                        feedbll.AddFeed(feed);

                                        if (unAttended)
                                        {
                                            DisplayMessage("Give a Meal Voucher");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Give a Meal Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        if (unAttended)
                                        {
                                            DisplayMessage("This card is not allowed to eat now come later");
                                        }
                                        else
                                        {
                                            MessageBox.Show("This card is not allowed to eat now come later", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (unAttended)
                            {
                                DisplayMessage("The member belongs to the " + dep + " department \r\nwhich is not allowed to access " + type_meal);
                            }
                            else
                            {
                                MessageBox.Show("The member belongs to the " + dep + " department \r\nwhich is not allowed to access " + type_meal, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        if (unAttended)
                        {
                            DisplayMessage("This card is not allowed to access meals");
                        }
                        else
                        {
                            MessageBox.Show("This card is not allowed to access meals", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                cardserial = string.Empty;
            }
            catch
            {

            }
        }

        private void DisplayMessage(string message)
        {
            frm_display display = new frm_display();
            display.displayMessage = message;
            display.Start(message);
            System.Threading.Thread.Sleep((int)TimeSpan.FromSeconds(2).TotalMilliseconds);
            display.Stop();
        }

        private void issueMealCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Food Vouchers"))
            {
                type_meal = "FOOD";

                try
                {
                    punch_cards(type_meal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void generalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Report"))
            {
                try
                {
                    //frm_feedReport CardRep = new frm_feedReport();
                    //CardRep.ShowDialog();

                    frm_report report = new frm_report();
                    report.ShowDialog();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grpIssuer.Visible = false;
            txtcardserial.Text = "";
            txtcard_name.Text = "";
            txtcard_name.Text = "";
            cbodepart.Text = "";
        }

        private void issueCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("ISSUE Cards"))
            {
                cbodepart.DataSource = ParametersGlobal.DepartmentList;
                cbodepart.DisplayMember = "name";
                cbodepart.ValueMember = "name";
                cbodepart.SelectedIndex = -1;

                grpIssuer.Visible = true;
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                ReadCardDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        void ReadCardDetails()
        {
            string cardserial = cardread.GetCardSerial();

            toolStripStatusLabel1.Text = "Card Reader Status : Connected";

            if (cardserial != "")
            {
                string staff = txtstaffnumber.Text;
                DateTime daters = System.DateTime.Now;
                string conds = "";

                txtcardserial.Text = cardserial;
                //string Cardsdata = CardDatabase + ".employees";

                Boolean Exists = false;

                conds = "serialnumber='" + txtcardserial.Text + "' or staffnumber='" + txtstaffnumber.Text + "';";
                //CanteenConnect.TableValues(Cardsdata, "*", conds);

                string _cardCheck = "select * from employees where " + conds;

                DataTable _cardCheck_dt = Globalparams.GetDataTable(_cardCheck);

                if (_cardCheck_dt.Rows.Count > 0)
                {
                    Exists = true;
                }

                if (Exists)
                {
                    if ((MessageBox.Show("the card already exists in the system, remove it first ?", "remove from system", MessageBoxButtons.YesNo)) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string card_serial = "";

                        card_serial = "serialnumber='" + txtcardserial.Text + "' or staffnumber='" + txtstaffnumber.Text.Trim() + "'";

                        empbll.DeleteEmployee(txtcardserial.Text, txtstaffnumber.Text.Trim());

                        //readcard.ReadBioCard();
                        //readcard.ReadFileA1();

                        //int retCounter = readcard.RevisionCount;

                        //empbll.FingerPrintReset(cardserial, Convert.ToInt32(retCounter));

                        MessageBox.Show("Close the Application and Open Smartlink to Register Fingerprints for the new user of the card.\r\n Go ahead and issue the cards.");
                    }
                    else
                    {
                        MessageBox.Show("Card Removal Cancelled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please confirm that the card is present, card reader is connected and the card is not damaged");
            }
        }

        void SaveEmployee()
        {
            // saving 

            if (txtcard_name.Text == "")
            {
                MessageBox.Show("the name of the card holder cannot be blank");
                txtcard_name.Focus();
            }
            else if (txtstaffnumber.Text == "")
            {
                MessageBox.Show("The staff number has got to have some value");
                txtstaffnumber.Focus();
            }
            else if (cbodepart.Text == "")
            {
                MessageBox.Show("The card cannot save without a value");
                cbodepart.Focus();
                cbodepart.DroppedDown = true;
            }
            else if (txtcardserial.Text == "")
            {
                MessageBox.Show("Read the card first");
            }
            else
            {
                DateTime dat = DateTime.Now.Date;
                TimeSpan tmp = DateTime.Now.TimeOfDay;
                DateTime newdat = dat + tmp;

                string starttime_str = string.Empty;

                if (starttime.Value.TimeOfDay.ToString().IndexOf(".") > 0)
                {
                    starttime_str = starttime.Value.TimeOfDay.ToString().Remove(starttime.Value.TimeOfDay.ToString().IndexOf("."));
                }
                else
                {
                    starttime_str = starttime.Value.TimeOfDay.ToString();
                }

                string entimestr = string.Empty;

                if (starttime.Value.TimeOfDay.ToString().IndexOf(".") > 0)
                {
                    entimestr = endtime.Value.TimeOfDay.ToString();//.Remove(starttime.Value.TimeOfDay.ToString().IndexOf("."));
                }
                else
                {
                    entimestr = endtime.Value.TimeOfDay.ToString();
                }

                Employee employee = new Employee()
                {
                    StaffNumber = txtstaffnumber.Text.Trim(),
                    StaffName = txtcard_name.Text.Trim(),
                    SerialNumber = txtcardserial.Text,
                    Department = cbodepart.Text.Trim(),
                    StartTime = Convert.ToDateTime(starttime_str),
                    Status = 1,
                    EndTime = Convert.ToDateTime(entimestr),
                    Issuer = ParametersGlobal.UserName
                };

                if (employee.StartTime == employee.EndTime)
                {
                    MessageBox.Show("Eating times must have a time difference");
                    endtime.Focus();
                }
                else
                {
                    empbll.AddEmployee(employee);

                    MessageBox.Show("Employee Details Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtcardserial_TextChanged(object sender, EventArgs e)
        {
            if (txtcardserial.Text != "")
            {
                cmd_save.Enabled = true;
            }
            else
            {
                cmd_save.Enabled = false;
            }
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void txtstaffnumber_Leave(object sender, EventArgs e)
        {
            if (txtstaffnumber.Text == "")
            {
                ReadCard.Enabled = false;
            }
            else
            {
                ReadCard.Enabled = true;
            }
        }

        private void deactivateCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Staff Management"))
            {
                frmemployees emps = new frmemployees();
                emps.Show();
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Admin"))
            {
                frmrights_issue issue = new frmrights_issue();
                issue.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maintananceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Maintanance"))
            {
                try
                {
                    ParametersGlobal.RepairDB();

                    MessageBox.Show("Maintanance complete");
                }
                catch (Exception ex)
                {
                    ParametersGlobal.ShowMessageBox(ex);
                }
            }
        }

        private void issueTeaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Tea Vouchers"))
            {
                type_meal = "TEA";
                
                try
                {
                    punch_cards(type_meal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.InnerException, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string timechecker(DateTime tnow)
        {
            string qut = "";

            string day_time_tea_st = DateTime.Now.ToShortDateString() + " 06:00:00";
            string day_time_tea_en = DateTime.Now.ToShortDateString() + " 18:00:00";

            string night_time_tea_st = DateTime.Now.ToShortDateString() + " 19:00:00";
            string night_time_tea_en = DateTime.Now.ToShortDateString() + " 05:00:00";

            DateTime day_time_st = Convert.ToDateTime(day_time_tea_st);
            DateTime day_time_en = Convert.ToDateTime(day_time_tea_en);

            DateTime night_st = new DateTime();
            DateTime night_en = Convert.ToDateTime(night_time_tea_en).AddDays(1);

            if (tnow.Hour < 6)
            {
                night_st = Convert.ToDateTime(night_time_tea_st).AddDays(-1);
            }
            else
            {
                night_st = Convert.ToDateTime(night_time_tea_st);
            }

            if (((tnow > day_time_st) && (tnow < day_time_en)))
            {
                qut = "Day Time";
            }
            if (((tnow > night_st) && (tnow < night_en)))
            {
                qut = "Night Time";
            }

            return qut;
        }

        private void changToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Change Password"))
            {
                frmchange_password pass_c = new frmchange_password();
                pass_c.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bg_dowork_DoWork(object sender, DoWorkEventArgs e)
        {
            // GetDepartments();
        }

        private void bg_dowork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void mealVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Main main = new frm_Main();
            main.ShowDialog();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }

        private void cmd_login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void cmd_save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveEmployee();
            }
            catch (Exception ex)
            {
                ParametersGlobal.ShowMessageBox(ex);
            }
        }

        private void cmd_startRun_Click(object sender, EventArgs e)
        {
            cmd_teaRun.Enabled = false;
            mnuCanteen.Enabled = false;
            KeepCheckingForCard = !KeepCheckingForCard;

            if (KeepCheckingForCard == true)
            {
                cmd_startRun.Text = "Stop Food Run";
            }
            else
            {
                cmd_teaRun.Enabled = true;
                mnuCanteen.Enabled = true;

                cmd_startRun.Text = "Start Food Run";
            }

            Task.Factory.StartNew(() =>
             {
                 while (KeepCheckingForCard)
                 {
                     RunFood();

                     Thread.Sleep((int)TimeSpan.FromMilliseconds(100).TotalMilliseconds);
                 }
             });
        }

        void RunFood()
        {
            type_meal = "FOOD";

            punch_cards(type_meal, true);
        }

        void RunTea()
        {
            type_meal = "TEA";

            punch_cards(type_meal, true);
        }

        private void cmd_teaRun_Click(object sender, EventArgs e)
        {
            cmd_startRun.Enabled = false;
            mnuCanteen.Enabled = false;

            KeepCheckingForCard = !KeepCheckingForCard;

            if (KeepCheckingForCard == true)
            {
                cmd_teaRun.Text = "Stop Tea Run";
            }
            else
            {
                cmd_startRun.Enabled = true;
                mnuCanteen.Enabled = true;

                cmd_teaRun.Text = "Start Tea Run";
            }

            Task.Factory.StartNew(() =>
            {
                while (KeepCheckingForCard)
                {
                    RunTea();

                    Thread.Sleep((int)TimeSpan.FromMilliseconds(100).TotalMilliseconds);
                }
            });
        }

        public bool KeepCheckingForCard { get; set; }

        public void TeaMeal(DailyFeed feed, bool unAttended)
        {
            string day_time_tea_st = DateTime.Now.ToShortDateString() + " 06:00:00";
            string day_time_tea_en = DateTime.Now.ToShortDateString() + " 18:00:00";

            string night_time_tea_st = DateTime.Now.ToShortDateString() + " 19:00:00";
            string night_time_tea_en = DateTime.Now.ToShortDateString() + " 05:00:00";

            DateTime day_time_en = Convert.ToDateTime(day_time_tea_en);
            DateTime day_time_st = Convert.ToDateTime(day_time_tea_st);

            DateTime night_st = new DateTime();
            DateTime night_en = Convert.ToDateTime(night_time_tea_en).AddDays(1);

            DateTime tnow = DateTime.Now;

            if (tnow.Hour < 6)
            {
                night_st = Convert.ToDateTime(night_time_tea_st).AddDays(-1);
            }
            else
            {
                night_st = Convert.ToDateTime(night_time_tea_st);
            }

            if (((tnow > day_time_st) && (tnow < day_time_en)))
            {
                // Day time;
                int teacount = feedbll.CheckFedCount(feed);

                if (teacount < 1)
                {
                    //MessageBox.Show("Not taken tea yet!");

                    feedbll.AddFeed(feed);

                    if (unAttended)
                    {
                        DisplayMessage("Give a Tea Voucher");
                    }
                    else
                    {
                        MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (((teacount == 1) || (teacount > 1)))
                {
                    if (unAttended)
                    {
                        DisplayMessage("Please note that the employee has already used the card today \r\n for TEA !");
                    }
                    else
                    {
                        MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (((tnow > night_st) && (tnow < night_en)))
            {
                //MessageBox.Show("Night Time");
                try
                {
                    //int teacount = CanteenConnect.eatissue_3(CardDatabase + ".dailyfeeds", serialno, "TEA");

                    //string cons = "SerialNumber='" + serialno + "' and time between '" + night_st.ToString("yyyy-MM-dd HH:mm:ss")
                    //  + "' and '" + night_en.ToString("yyyy-MM-dd HH:mm:ss") + "' and meal_type like '%tea%'";

                    DataTable dft = feedbll.CheckNightFedCount(feed, night_st, night_en);

                    int howmay = dft.Rows.Count;

                    if (dft.Rows.Count > 0)
                    {
                        //MessageBox.Show("Has Used the card before for tea");

                        bool IsItUsed = false;

                        foreach (DataRow dr_row in dft.Rows)
                        {
                            //MessageBox.Show("Checking the Rows");

                            string mtype = dr_row["meal_type"].ToString();
                            string usgaet = dr_row["usage_instance"].ToString();

                            //MessageBox.Show("Meal type is " + mtype + " and Usage is  " + usgaet);

                            if (((usgaet == "Night Time") && (mtype == "TEA")))
                            {
                                //MessageBox.Show("Has qualified");

                                if ((howmay == 0) || (howmay == 1))
                                {
                                    //MessageBox.Show("After Qualification");

                                    feedbll.AddFeed(feed);

                                    if (unAttended)
                                    {
                                        DisplayMessage("Give a Tea Voucher");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                if (howmay == 2)
                                {
                                    IsItUsed = true;
                                }
                            }
                            if (((usgaet == "Night Time") && (mtype != "TEA")))
                            {
                                //MessageBox.Show("Has qualified");

                                if ((howmay == 0) || (howmay == 1))
                                {
                                    //MessageBox.Show("After Qualification");

                                    feedbll.AddFeed(feed);

                                    if (unAttended)
                                    {
                                        DisplayMessage("Give a Tea Voucher");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                if (howmay == 2)
                                {
                                    IsItUsed = true;
                                }
                            }
                            if (((usgaet == "Day Time") && (mtype != "TEA")))
                            {
                                if ((howmay == 0) || (howmay == 1))
                                {
                                    feedbll.AddFeed(feed);

                                    if (unAttended)
                                    {
                                        DisplayMessage("Give a Tea Voucher");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                if (howmay == 2)
                                {
                                    if (unAttended)
                                    {
                                        DisplayMessage("Please note that the employee has already used the card today \r\n for TEA !");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            if ((usgaet == "Day Time") && (mtype == "TEA"))
                            {
                                if (unAttended)
                                {
                                    DisplayMessage("Please note that the employee has already used the card \r\n today for TEA during the day!");
                                }
                                else
                                {
                                    MessageBox.Show("Please note that the employee has already used the card \r\n "
                                        + " today for TEA during the day!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            }
                        }
                        if (IsItUsed == true)
                        {
                            if (unAttended)
                            {
                                DisplayMessage("Please note that the employee has already used the card today \r\n for TEA !");
                            }
                            else
                            {
                                MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        feedbll.AddFeed(feed);

                        if (unAttended)
                        {
                            DisplayMessage("Give a Tea Voucher");
                        }
                        else
                        {
                            MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (unAttended)
                {
                    DisplayMessage("This card is not allowed to eat now come later");
                }
                else
                {
                    MessageBox.Show("This card is not allowed to eat now come later", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            DateTime gtd = DateTime.Now;
        }



    }

}