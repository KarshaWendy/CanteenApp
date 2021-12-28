using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CanteenDaily
{
    internal sealed class globalparams
    {
        public static string user_name = "";
        public static MySqlConnection Localconn;
        public static DataTable Rights_formTable, meal_prices, department_rigths, departments;
        public static int log_state;
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

        public static string EncryptString(string Message, string Passphrase)
        {
            if (Message != "")
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5   
                // We use the MD5 hash generator as the result is a 128 bit byte array   
                // which is a valid length for the TripleDES encoder we use below   

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

                // Step 2. Create a new TripleDESCryptoServiceProvider object   
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the encoder   
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[]   
                byte[] DataToEncrypt = UTF8.GetBytes(Message);

                // Step 5. Attempt to encrypt the string   
                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information   
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Step 6. Return the encrypted string as a base64 encoded string   
                return Convert.ToBase64String(Results);
            }
            return "";
        }

        public static string DecryptString(string Message, string Passphrase)
        {
            if (Message != "")
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5   
                // We use the MD5 hash generator as the result is a 128 bit byte array   
                // which is a valid length for the TripleDES encoder we use below   

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

                // Step 2. Create a new TripleDESCryptoServiceProvider object   
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the decoder   
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[]   
                byte[] DataToDecrypt = Convert.FromBase64String(Message);

                // Step 5. Attempt to decrypt the string   
                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information   
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Step 6. Return the decrypted string in UTF8 format   
                return UTF8.GetString(Results);
            }
            return "";
        }

        public static Boolean AccessForm(string str)
        {
            if (Rights_formTable.Rows.Count > 0)
            {
                DataRow[] DataAccess = Rights_formTable.Select("Module_Name='" + str + "'");
                if (DataAccess.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {

                return false;
            }
        }


        public static DataTable GetDataTable(string _query)
        {
            DataTable dt = new DataTable();

            try
            {
                if (Localconn.State == ConnectionState.Closed)
                {
                    Localconn.Open();
                }

                using (MySqlDataAdapter adap = new MySqlDataAdapter(_query, Localconn))
                {
                    adap.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Localconn.Close();
            }

            return dt;
        }

    }

}
