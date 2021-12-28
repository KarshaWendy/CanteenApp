using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SMART.DATA.V1;
using System.Windows.Forms;

namespace CanteenDaily
{
    public class DailyFeedBLL
    {
        public void CheckMemberHasFeed()
        {

        }

        public DailyFeed GetFeed(string serial)
        {
            DailyFeed feed = new DailyFeed();

            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return feed;
        }

        public bool CheckIFAlreadyFed(DailyFeed feed)
        {
            bool result = false;
            
            try
            {
                string query = "select staffnumber,card_name,department,serialnumber,time from dailyfeeds where serialnumber= '" + feed.SerialNumber 
                    + "' and date(time)=curdate() and meal_type= '" + feed.MealType + "' ";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public int CheckFedCount(DailyFeed feed)
        {
            int result = 0;

            try
            {
                string query = "select staffnumber,card_name,department,serialnumber,time from dailyfeeds where serialnumber= '" + feed.SerialNumber
                    + "' and date(time)=curdate() and meal_type= '" + feed.MealType + "' ";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                if (dt.Rows.Count > 0)
                {
                    result = dt.Rows.Count;
                }
                else
                {
                    result = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public DataTable CheckNightFedCount(DailyFeed feed, DateTime starttime, DateTime endtime)
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "select staffnumber,card_name,department,serialnumber,time, meal_type, usage_instance from dailyfeeds where serialnumber= '" + feed.SerialNumber
                    + "' and date(time)=curdate() and meal_type = '" + feed.MealType + "' and time between '" + starttime.ToString("yyyy-MM-dd HH:mm:ss")
                    + "' and '" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                dt = DataBaseOperations.ExecuteDataTable_My(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public bool AllowedToEatNow(Employee employee)
        {
            bool result = false;

            try
            {
                string query = "select serialnumber from employees where serialnumber= '" + employee.SerialNumber + "' and ('" + DateTime.Now.TimeOfDay + "' between times and lasttimes)";

                DataTable dt = DataBaseOperations.ExecuteDataTable_My(query);

                if (dt.Rows.Count > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void AddFeed(DailyFeed feed)
        {
            string query = "insert into dailyfeeds (staffnumber,card_name,department,serialnumber, meal_type, usage_instance, Amount) values"
                + " ('" + feed.StaffNumber + "', '" + feed.CardName + "', '" + feed.Department + "', '" + feed.SerialNumber + "', '" + feed.MealType + "', '" + timechecker() + "', " + feed.Amount + ")";

            DataBaseOperations.ExecuteComm_My(query);
        }

        private string timechecker()
        {
            DateTime tnow = DateTime.Now;

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

        public void TeaMeal(DailyFeed feed)
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
                int teacount = CheckFedCount(feed);

                if (teacount < 1)
                {
                    //MessageBox.Show("Not taken tea yet!");
                                        
                    AddFeed(feed);

                    MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (((teacount == 1) || (teacount > 1)))
                {
                    MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    DataTable dft = CheckNightFedCount(feed, night_st, night_en);

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

                                    AddFeed(feed);

                                    MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                                    AddFeed(feed);

                                    MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    AddFeed(feed);

                                    MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                if (howmay == 2)
                                {
                                    MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            if ((usgaet == "Day Time") && (mtype == "TEA"))
                            {
                                MessageBox.Show("Please note that the employee has already used the card \r\n "
                                    + " today for TEA during the day!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;
                            }
                        }
                        if (IsItUsed == true)
                        {
                            MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Qualified");

                        AddFeed(feed);

                        MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            DateTime gtd = DateTime.Now;
        }

        public void CanTakeTeaMeal(DailyFeed feed, bool unAttended)
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
                int teacount = CheckFedCount(feed);

                if (teacount < 1)
                {
                    //MessageBox.Show("Not taken tea yet!");

                    AddFeed(feed);

                    MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (((teacount == 1) || (teacount > 1)))
                {
                    MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    DataTable dft = CheckNightFedCount(feed, night_st, night_en);

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

                                    AddFeed(feed);

                                    MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                                    AddFeed(feed);

                                    MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    AddFeed(feed);

                                    MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                if (howmay == 2)
                                {
                                    MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            if ((usgaet == "Day Time") && (mtype == "TEA"))
                            {
                                MessageBox.Show("Please note that the employee has already used the card \r\n "
                                    + " today for TEA during the day!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;
                            }
                        }
                        if (IsItUsed == true)
                        {
                            MessageBox.Show("Please note that the employee has already used the card today \r\n for TEA !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Qualified");

                        AddFeed(feed);

                        MessageBox.Show("Give a Tea Voucher", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            DateTime gtd = DateTime.Now;
        }



    }
}
