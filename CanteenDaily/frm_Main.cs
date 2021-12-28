using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CanteenDaily;
// using OTI.SmartLink.RETMsgMaker;

namespace CanteenDaily
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }
        
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
        //    {
        //        ShowWindow();
        //    }
        //    base.WndProc(ref m);
        //}

        //public void ShowWindow()
        //{
        //    WinApi.ShowToFront(this.Handle);
        //}

        int baudRate;
        short portNumber;

        string type_meal = "";
        public string CardDatabase = "";
        public string HostServer = "";
        public int Dbport;

        // public static Databasespeciality CanteenConnect = new Databasespeciality();

        protected override void OnClosing(CancelEventArgs e)
        {
            globalparams._applicationState = 1;
            DialogResult result = MessageBox.Show("Are you sure you want to close?", "Please Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = (result == DialogResult.No);
            }
        }

        void LoadDetails()
        {
            string FilePath = Application.StartupPath + "\\Application\\smisconfigSmart.xml";

            if (File.Exists(FilePath))
            {
                DataSet configs_ds = new DataSet();
                configs_ds.ReadXml(FilePath);

                HostServer = configs_ds.Tables[0].Rows[0]["Server"].ToString();
                int.TryParse(configs_ds.Tables[0].Rows[0]["port"].ToString(), out Dbport);
                short.TryParse(configs_ds.Tables[0].Rows[0]["readerPort"].ToString(), out portNumber);
                int.TryParse(configs_ds.Tables[0].Rows[0]["readerBaud"].ToString(), out baudRate);
                CardDatabase = configs_ds.Tables[0].Rows[0]["db"].ToString();

                if (globalparams.log_state == 1)
                {
                    menuStrip1.Enabled = true;
                    groupBox1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Configuration Load Error.\r\nConfiguration file missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void frm_Main_Shown(object sender, EventArgs e)
        {
            LoadDetails();
        }

        //CardReader reader = new CardReader();

        //public void punch_cards_v2()
        //{
        //    //start.SetTableDirectory(@"C:\Program Files\OTI Africa\MediSmart\SmartLinkCodes");
                        
        //    globalparams._applicationState = 0;

        //    reader.Initialize(38400, 3);
            
        //        start.InitialiseBiometricReader();
               
        //        string cardserial = "";

        //        if (start.IsCardDetected())
        //        {
        //            if (start.ReadUserCardData())
        //            {
        //                cardserial = start.GetCardSerialNumber();
                       
        //                //tssl_reader.Invoke((MethodInvoker)delegate { tssl_reader.Text = "Card Reader Status : " + cardserial + ""; });

        //                DateTime daters = System.DateTime.Now;
        //                string Cardsdata = CardDatabase + ".employees";

        //                if (CanteenConnect.eatissue(Cardsdata, cardserial)) // this checks if the membercard had been issuerd
        //                {
        //                    DataTable mem_dt = globalparams.GetDataTable("select * from employees where Serialnumber = '" + cardserial + "'");
        //                    string dep = mem_dt.Rows[0]["department"].ToString();

        //                    string dater = System.DateTime.Now.ToString();
        //                    string CardConn = CardDatabase + ".dailyfeeds";

        //                    System.DateTime daterSteve = DateTime.Now;

        //                    //Confirm whether the department is allowed to access meals/teal

        //                    if (checkDepartmentStatus(dep, type_meal))
        //                    {
        //                        if (type_meal == "TEA")
        //                        {
        //                            DateTime tnow = DateTime.Now;

        //                            checktimes(tnow, cardserial, Cardsdata, CardConn);
        //                        }
        //                        if (type_meal == "FOOD")
        //                        {
        //                            if (CanteenConnect.eatissue(CardConn, cardserial, "FOOD"))
        //                            {
        //                                MessageBox.Show("The owner of this card has already feed");
        //                                cardserial = "";
        //                            }
        //                            else
        //                            {
        //                                 //check if the person is meant to eat now

        //                                if (CanteenConnect.eatissue(Cardsdata, cardserial, daterSteve))
        //                                {
        //                                    /* Here is where the new funtionality for the fingerpring goes.
        //                                     * Check if the card has fingerprints registered, If not, then first 
        //                                     * 
        //                                     * */


        //                                    //if (start.InitialiseCardReader(4, 38400))
        //                                    //{
        //                                        bool f = true; //start.InitialiseBiometricReader();

        //                                        if (f)
        //                                        {
        //                                            if (start.PrintsRegisteredFlag > 0)
        //                                            {
        //                                                string _fp_to_use = "";

        //                                                lbl_fp.Invoke((MethodInvoker)delegate { lbl_fp.Text = "Card Reader Status : " + cardserial + ""; });
                                                        
        //                                                if (start.PrintsRegisteredFlag == 1)
        //                                                {
        //                                                    _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString();
        //                                                }
        //                                                if (start.PrintsRegisteredFlag == 2)
        //                                                {
        //                                                    _fp_to_use = " Use " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString();
        //                                                }
        //                                                if (start.PrintsRegisteredFlag == 3)
        //                                                {
        //                                                    _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString() + " \n or " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString() + "'";
        //                                                }

        //                                                lbl_fp.Invoke((MethodInvoker)delegate { lbl_fp.Text = _fp_to_use; });

        //                                            mylabel:

        //                                                if (Convert.ToBoolean(start.GetUserVerificationPrint(0)) == true)//(start.GetUserVerificationPrint(0))
        //                                                {
        //                                                    DataRow[] p_row = globalparams.meal_prices.Select("food_type='" + type_meal + "'");
        //                                                    double p_amount = Convert.ToDouble(p_row[0]["amount"].ToString());

        //                                                    ops_inserts(cardserial, Cardsdata, CardConn, " Give a Meal Voucher", p_amount);

        //                                                    start.Refresh();
        //                                                    start.Update();

        //                                                    lbl_fp.Text = "";
        //                                                }
        //                                                else
        //                                                {
        //                                                    if (globalparams._applicationState != 1)
        //                                                    {
        //                                                        MessageBox.Show("Fingerprints Do not Match. \r\nPlease Try Again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                                                        start.Refresh();
        //                                                        start.Update();
        //                                                        goto mylabel;
        //                                                    }
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                MessageBox.Show("No fingerprints have been registered.\r\n Kindly register FingerPrints before proceeding", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                                            }

        //                                        }
        //                                        else
        //                                        {
        //                                            MessageBox.Show("Cannot Initialise the Fingerprint Reader", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                                        }
        //                                    //}
        //                                }
        //                                else
        //                                {
        //                                    MessageBox.Show("This card is not allowed to eat now come later");
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("The member belongs to the " + dep + " department \r\nwhich is not allowed to access " + type_meal, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }

        //                    cardserial = "";
        //                }
        //                else
        //                {
        //                    MessageBox.Show("This card has not been issued to the system");
        //                    cardserial = "";
        //                }

        //                cardserial = "";
        //            }
        //            else
        //            {

        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Cannot Detect the card. Kindly place the card on the card Reader", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
            
        //}

        //private bool checkDepartmentStatus(string deparmentName, string mealType)
        //{
        //    DataRow[] d_r = globalparams.department_rigths.Select("name = '" + deparmentName + "' and food_type = '" + mealType + "'");

        //    if (d_r.Length > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private void ops_inserts(string serialno, string Cardsdata, string CardConn, string MessageDisplay, double amount)
        //{
        //    //ops_inserts(cardserial, Cardsdata, CardConn, " Give a Meal Voucher");
        //    //MessageBox.Show("Getting the values to be inserted");

        //    // issue meal voucher now we need to load into db the details.
        //    string[] cardsinsert = new string[7];
        //    string[] cardsinf = new string[7];
        //    string cond = "serialnumber ='" + serialno + "'";

        //    CanteenConnect.TableValues(Cardsdata, "staffnumber,staffname,department,serialnumber", cond);
        //    cardsinf[0] = "staffnumber";
        //    cardsinf[1] = "card_name";
        //    cardsinf[2] = "Department";
        //    cardsinf[3] = "Serialnumber";
        //    cardsinf[4] = "meal_type";
        //    cardsinf[5] = "usage_instance";
        //    cardsinf[6] = "Amount";
        //    //cardsinf[4] = "time";
        //    cardsinsert[0] = CanteenConnect.Fields[0, 0];
        //    cardsinsert[1] = CanteenConnect.Fields[0, 1];
        //    cardsinsert[2] = CanteenConnect.Fields[0, 2];
        //    cardsinsert[3] = CanteenConnect.Fields[0, 3];
        //    cardsinsert[4] = type_meal;
        //    cardsinsert[5] = timechecker(DateTime.Now);
        //    cardsinsert[6] = Convert.ToString(amount);

        //    if (CanteenConnect.insertRecords(cardsinf, cardsinsert, CardConn))
        //    {
        //        MessageBox.Show(MessageDisplay);
        //        serialno = "";
        //    }
        //}

        //private void checktimes(DateTime tnow, string serialno, string Cardsdata, string CardConn)
        //{
        //    string day_time_tea_st = DateTime.Now.ToShortDateString() + " 06:00:00";
        //    string day_time_tea_en = DateTime.Now.ToShortDateString() + " 18:00:00";

        //    string night_time_tea_st = DateTime.Now.ToShortDateString() + " 19:00:00";
        //    string night_time_tea_en = DateTime.Now.ToShortDateString() + " 05:00:00";

        //    DateTime day_time_en = Convert.ToDateTime(day_time_tea_en);
        //    DateTime day_time_st = Convert.ToDateTime(day_time_tea_st);

        //    DateTime night_st = new DateTime();
        //    DateTime night_en = Convert.ToDateTime(night_time_tea_en).AddDays(1);

        //    DataRow[] p_row = globalparams.meal_prices.Select("food_type='" + type_meal + "'");
        //    double p_amount = Convert.ToDouble(p_row[0]["amount"].ToString());

        //    //MessageBox.Show(tnow.Hour.ToString());

        //    if (tnow.Hour < 6)
        //    {
        //        //MessageBox.Show("Less than 6");
        //        night_st = Convert.ToDateTime(night_time_tea_st).AddDays(-1);
        //    }
        //    else
        //    {
        //        //MessageBox.Show("Greater than 6");
        //        night_st = Convert.ToDateTime(night_time_tea_st);

        //        //MessageBox.Show(night_st.ToLongDateString() + " : " + night_st.ToShortTimeString());
        //    }

        //    if (((tnow > day_time_st) && (tnow < day_time_en)))
        //    {
        //        //MessageBox.Show("Day time ");
        //        int teacount = CanteenConnect.eatissue_3(CardDatabase + ".dailyfeeds", serialno, "TEA");

        //        if (teacount < 1)
        //        {
        //            //MessageBox.Show("Not taken tea yet!");
        //            //ops_inserts(serialno, Cardsdata, CardConn, "Give a Tea Voucher", p_amount);

        //            if (start.PrintsRegisteredFlag > 0)
        //            {
        //                string _fp_to_use = "";

        //                if (start.PrintsRegisteredFlag == 1)
        //                {
        //                    _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString();
        //                }
        //                if (start.PrintsRegisteredFlag == 2)
        //                {
        //                    _fp_to_use = " Use " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString();
        //                }
        //                if (start.PrintsRegisteredFlag == 3)
        //                {
        //                    _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString() + " \n or " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString() + "'";
        //                }

        //                lbl_fp.Invoke((MethodInvoker)delegate { lbl_fp.Text = _fp_to_use; });

        //            mylabel:

        //                if (Convert.ToBoolean(start.GetUserVerificationPrint(0)) == true)//(start.GetUserVerificationPrint(0))
        //                {
        //                    //DataRow[] p_row = globalparams.meal_prices.Select("food_type='" + type_meal + "'");
        //                    //double p_amount = Convert.ToDouble(p_row[0]["amount"].ToString());

        //                    //ops_inserts(cardserial, Cardsdata, CardConn, " Give a Meal Voucher", p_amount);

        //                    ops_inserts(serialno, Cardsdata, CardConn, "Give a Tea Voucher", p_amount);

        //                    start.Refresh();
        //                    start.Update();

        //                    lbl_fp.Text = "";
        //                }
        //                else
        //                {
        //                    if (globalparams._applicationState != 1)
        //                    {
        //                        MessageBox.Show("Fingerprints Do not Match. \r\nPlease Try Again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        start.Refresh();
        //                        start.Update();
        //                        goto mylabel;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("No fingerprints have been registered.\r\n Kindly register FingerPrints before proceeding", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }

        //        if (((teacount == 1) || (teacount > 1)))
        //        {
        //            MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    if (((tnow > night_st) && (tnow < night_en)))
        //    {
        //        //MessageBox.Show("Night Time");
        //        try
        //        {
        //            //int teacount = CanteenConnect.eatissue_3(CardDatabase + ".dailyfeeds", serialno, "TEA");
        //            string cons = "SerialNumber='" + serialno + "' and time between '" + night_st.ToString("yyyy-MM-dd HH:mm:ss")
        //                + "' and '" + night_en.ToString("yyyy-MM-dd HH:mm:ss") + "' and meal_type like '%tea%'";

        //            DataTable dft = CanteenConnect.TableValues(CardDatabase + ".dailyfeeds", "*", cons, " order by meal_type desc");

        //            int howmay = dft.Rows.Count;
        //            //MessageBox.Show("Count is  :  " + howmay.ToString());

        //            if (dft.Rows.Count > 0)
        //            {
        //                //MessageBox.Show("Has Used the card before for tea");

        //                bool IsItUsed = false;

        //                foreach (DataRow dr_row in dft.Rows)
        //                {
        //                    //MessageBox.Show("Checking the Rows");

        //                    string mtype = dr_row["meal_type"].ToString();
        //                    string usgaet = dr_row["usage_instance"].ToString();

        //                    //MessageBox.Show("Meal type is " + mtype + " and Usage is  " + usgaet);

        //                    if (((usgaet == "Night Time") && (mtype == "TEA")))
        //                    {
        //                        //MessageBox.Show("Has qualified");

        //                        if ((howmay == 0) || (howmay == 1))
        //                        {
        //                            //MessageBox.Show("After Qualification");

        //                            //ops_inserts(serialno, Cardsdata, CardConn, "Give a TEA voucher", p_amount);

        //                            if (start.PrintsRegisteredFlag > 0)
        //                            {
        //                                string _fp_to_use = "";

        //                                if (start.PrintsRegisteredFlag == 1)
        //                                {
        //                                    _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString();
        //                                }
        //                                if (start.PrintsRegisteredFlag == 2)
        //                                {
        //                                    _fp_to_use = " Use " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString();
        //                                }
        //                                if (start.PrintsRegisteredFlag == 3)
        //                                {
        //                                    _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString() + " \n or " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString() + "'";
        //                                }

        //                                lbl_fp.Invoke((MethodInvoker)delegate { lbl_fp.Text = _fp_to_use; });

        //                            mylabel:

        //                                if (Convert.ToBoolean(start.GetUserVerificationPrint(0)) == true)//(start.GetUserVerificationPrint(0))
        //                                {
        //                                    //DataRow[] p_row = globalparams.meal_prices.Select("food_type='" + type_meal + "'");
        //                                    //double p_amount = Convert.ToDouble(p_row[0]["amount"].ToString());

        //                                    //ops_inserts(cardserial, Cardsdata, CardConn, " Give a Meal Voucher", p_amount);

        //                                    ops_inserts(serialno, Cardsdata, CardConn, "Give a Tea Voucher", p_amount);

        //                                    start.Refresh();
        //                                    start.Update();

        //                                    lbl_fp.Text = "";
        //                                }
        //                                else
        //                                {
        //                                    if (globalparams._applicationState != 1)
        //                                    {
        //                                        MessageBox.Show("Fingerprints Do not Match. \r\nPlease Try Again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                                        start.Refresh();
        //                                        start.Update();
        //                                        goto mylabel;
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                MessageBox.Show("No fingerprints have been registered.\r\n Kindly register FingerPrints before proceeding", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            }
        //                        }
        //                        if (howmay == 2)
        //                        {
        //                            IsItUsed = true;
        //                        }
        //                    }
        //                    if (((usgaet == "Night Time") && (mtype != "TEA")))
        //                    {
        //                        //MessageBox.Show("Has qualified");

        //                        if ((howmay == 0) || (howmay == 1))
        //                        {
        //                            //MessageBox.Show("After Qualification");

        //                            ops_inserts(serialno, Cardsdata, CardConn, "Give a TEA voucher", p_amount);
        //                        }
        //                        if (howmay == 2)
        //                        {
        //                            IsItUsed = true;
        //                        }
        //                    }
        //                    if (((usgaet == "Day Time") && (mtype != "TEA")))
        //                    {
        //                        if ((howmay == 0) || (howmay == 1))
        //                        {
        //                            //ops_inserts(serialno, Cardsdata, CardConn, "Give a TEA voucher", p_amount);

        //                            if (start.PrintsRegisteredFlag > 0)
        //                            {
        //                                string _fp_to_use = "";

        //                                if (start.PrintsRegisteredFlag == 1)
        //                                {
        //                                    _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString();
        //                                }
        //                                if (start.PrintsRegisteredFlag == 2)
        //                                {
        //                                    _fp_to_use = " Use " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString();
        //                                }
        //                                if (start.PrintsRegisteredFlag == 3)
        //                                {
        //                                    _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString() + " \n or " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString() + "'";
        //                                }

        //                                lbl_fp.Invoke((MethodInvoker)delegate { lbl_fp.Text = _fp_to_use; });

        //                            mylabel:

        //                                if (Convert.ToBoolean(start.GetUserVerificationPrint(0)) == true)//(start.GetUserVerificationPrint(0))
        //                                {
        //                                    //DataRow[] p_row = globalparams.meal_prices.Select("food_type='" + type_meal + "'");
        //                                    //double p_amount = Convert.ToDouble(p_row[0]["amount"].ToString());

        //                                    //ops_inserts(cardserial, Cardsdata, CardConn, " Give a Meal Voucher", p_amount);

        //                                    ops_inserts(serialno, Cardsdata, CardConn, "Give a Tea Voucher", p_amount);

        //                                    start.Refresh();
        //                                    start.Update();

        //                                    lbl_fp.Text = "";
        //                                }
        //                                else
        //                                {
        //                                    if (globalparams._applicationState != 1)
        //                                    {
        //                                        MessageBox.Show("Fingerprints Do not Match. \r\nPlease Try Again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                                        start.Refresh();
        //                                        start.Update();
        //                                        goto mylabel;
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                MessageBox.Show("No fingerprints have been registered.\r\n Kindly register FingerPrints before proceeding", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            }
        //                        }
        //                        if (howmay == 2)
        //                        {
        //                            MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        }
        //                    }
        //                    if ((usgaet == "Day Time") && (mtype == "TEA"))
        //                    {
        //                        MessageBox.Show("Please note that the employee has already used the card \r\n "
        //                            + " today for TEA during the day!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        goto Finish;
        //                    }
        //                }
        //                if (IsItUsed == true)
        //                {
        //                    MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //            }
        //            else
        //            {
        //                //MessageBox.Show("Qualified");
        //                //ops_inserts(serialno, Cardsdata, CardConn, "Give a Tea Voucher", p_amount);

        //                bool f = true; //start.InitialiseBiometricReader();

        //                if (f)
        //                {
        //                    if (start.PrintsRegisteredFlag > 0)
        //                    {
        //                        string _fp_to_use = "";

        //                        if (start.PrintsRegisteredFlag == 1)
        //                        {
        //                            _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString();
        //                        }
        //                        if (start.PrintsRegisteredFlag == 2)
        //                        {
        //                            _fp_to_use = " Use " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString();
        //                        }
        //                        if (start.PrintsRegisteredFlag == 3)
        //                        {
        //                            _fp_to_use = "Use " + start.UserHandID1.ToString() + " " + start.UserFingerID1.ToString() + " \n or " + start.UserHandID2.ToString() + " " + start.UserFingerID2.ToString() + "'";
        //                        }

        //                        lbl_fp.Invoke((MethodInvoker)delegate { lbl_fp.Text = _fp_to_use; });

        //                    mylabel:

        //                        if (Convert.ToBoolean(start.GetUserVerificationPrint(0)) == true)//(start.GetUserVerificationPrint(0))
        //                        {
        //                            //DataRow[] p_row = globalparams.meal_prices.Select("food_type='" + type_meal + "'");
        //                            //double p_amount = Convert.ToDouble(p_row[0]["amount"].ToString());

        //                            //ops_inserts(cardserial, Cardsdata, CardConn, " Give a Meal Voucher", p_amount);

        //                            ops_inserts(serialno, Cardsdata, CardConn, "Give a Tea Voucher", p_amount);

        //                            start.Refresh();
        //                            start.Update();

        //                            lbl_fp.Text = "";
        //                        }
        //                        else
        //                        {
        //                            if (globalparams._applicationState != 1)
        //                            {
        //                                MessageBox.Show("Fingerprints Do not Match. \r\nPlease Try Again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                                start.Refresh();
        //                                start.Update();
        //                                goto mylabel;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("No fingerprints have been registered.\r\n Kindly register FingerPrints before proceeding", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    }

        //                }
        //                else
        //                {
        //                    MessageBox.Show("Cannot Initialise the Fingerprint Reader", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }

        //Finish:

        //    DateTime gtd = DateTime.Now;
        //}
        
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
        
        private void issueMealVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Food Vouchers"))
            {
                //GetDepartments();
                type_meal = "FOOD";
                // punch_cards_v2();
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights to issue Meal Vouchers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void issueTeaVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParametersGlobal.AccessForm("Tea Vouchers"))
            {
                type_meal = "TEA";
                //punch_cards_v2();
            }
            else
            {
                MessageBox.Show("Acces Denied! \r\n You don't have enough rights to issue Tea Vouchers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    
    }
}
