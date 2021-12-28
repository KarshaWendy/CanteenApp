using System;
using System.Data;
using System.Windows.Forms;
//using AxMEDISMARTLib;
using SMART.DATA.V1;

namespace CanteenDaily
{
    //public class cardreader
    //{
    //    // AxMedismart readcard = new AxMedismart();
    //    public string state, cardserial;
    //    public cardreader() { }
    //    public List<string> needed = new List<string>();

    //    CardReader cardread = new CardReader();

    //    public List<string> getcardserial(short nPort, int IBaud, int appState)
    //    {
    //        try
    //        {
    //            cardread.Initialize(nPort, IBaud);


    //            if (appState == 1)
    //            {
    //                state = "Card Reader is Not Connected :";
    //            }
    //            else
    //            {
    //                state = "Card Reader is Not Connected :";
    //                MessageBox.Show("The card reader is not connected.\r\nPlease connect the reader first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //            }

    //            readcard.ReadBioCard();
    //            cardserial = readcard.GetCardSerialNumber();

    //            readcard.ReadFileA1();
    //            int retCounter = readcard.RevisionCount;

    //            needed.Add(cardserial);
    //            needed.Add(state);
    //            needed.Add(retCounter.ToString());

    //        }
    //        catch (Exception ex)
    //        {
    //            state = "Card Reader Connected :";
    //            MessageBox.Show(ex.Message + ex.InnerException + ex.StackTrace.ToString());
    //        }

    //        return needed;

    //    }

    //}

    internal sealed class Globalparams
    {
        public static string user_name = "";
        public static int log_state;
        public static int _applicationState;
        public static int newuserid;
        public static int newdeptid;
        public static int newusergroup_id;
        public static int user_id;
        public static int rights_states;
        public static string hold_p;

        public static void assignMDI(ref Object hrmops)
        {
            Form frmchange = new Form();
            frmchange = (Form)hrmops;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.IsMdiContainer)
                {
                    frmchange.MdiParent = frm;
                }
            }
        }

        
        public static DataTable GetDataTable(string _query)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = DataBaseOperations.ExecuteDataTable_My(_query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return dt;
        }
    }

}