using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxMEDISMARTLib;

namespace CanteenDaily
{

    public class cardreader
    {
        AxMedismart readcard = new AxMedismart();
        public string state, cardserial;
        public cardreader() { }
        public List<string> needed = new List<string>();

        public List<string> getcardserial(short nPort, int IBaud, int appState)
        {
            try
            {
                readcard.CreateControl();

                //if (readcard.InitialiseReader(1, 38400))
                if (readcard.InitialiseReader(nPort, IBaud))
                {
                    state = "Card Reader Connected :";
                }
                else
                {
                    if (appState == 1)
                    {
                        state = "Card Reader is Not Connected :";
                    }
                    else
                    {
                        state = "Card Reader is Not Connected :";
                        MessageBox.Show("The card reader is not connected.\r\nPlease connect the reader first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                readcard.ReadBioCard();
                
                cardserial = readcard.GetCardSerialNumber();
                
                needed.Add(cardserial);
                needed.Add(state);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException + ex.StackTrace.ToString());
            }

            readcard.Dispose();
            return needed;

        }

    }

}
