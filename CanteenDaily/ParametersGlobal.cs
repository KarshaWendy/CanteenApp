using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using SMART.DATA.V1;
using OfficeOpenXml;

namespace CanteenDaily
{
    public static class ParametersGlobal
    {
        public static List<DepartmentRight> DepartmentRightList;
        public static List<Department> DepartmentList;
        public static List<PriceList> PriceList;

        public static void RepairDB()
        {
            string repair = "repair table smartcafet.dailyfeeds";

            DataBaseOperations.ExecuteComm_My(repair);
        }

        public static void ExportToExcel(DataTable listyavitu, ExportReportModel exreportModel)
        {
            try
            {
                if (listyavitu != null)
                {
                    using (ExcelPackage p = new ExcelPackage())
                    {
                        p.Workbook.Properties.Author = exreportModel.DocumentAuthor;
                        p.Workbook.Properties.Title = exreportModel.DocumentTitle;

                        ExcelWorksheet ws = p.Workbook.Worksheets.Add(exreportModel.SheetName);
                        ws.Name = exreportModel.SheetName;
                        ws.Cells.Style.Font.Name = exreportModel.DocumentFontName;

                        int colIndex = 1;
                        int rowindex = 1;

                        foreach (DataColumn pi in listyavitu.Columns)
                        {
                            var cell = ws.Cells[rowindex, colIndex];

                            var fill = cell.Style.Fill;
                            fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(Color.Gray);
                            cell.Style.Font.Size = 10;

                            cell.Value = pi.ColumnName;
                            cell.AutoFitColumns();

                            colIndex++;
                        }

                        foreach (DataRow _item in listyavitu.Rows)
                        {
                            colIndex = 1;
                            rowindex++;

                            foreach (DataColumn pi in listyavitu.Columns)
                            {
                                var cell = ws.Cells[rowindex, colIndex];
                                cell.Style.Font.Size = 9;

                                if (pi.DataType == typeof(double) || pi.DataType == typeof(decimal))
                                {
                                    if (!string.IsNullOrEmpty(_item[pi].ToString()))
                                    {
                                        cell.Value = Convert.ToDecimal(_item[pi].ToString());

                                        if (pi.ColumnName == "Amount")
                                        {
                                            cell.Style.Numberformat.Format = "#,##0.00";
                                        }
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                }
                                else if (pi.DataType == typeof(DateTime))
                                {
                                    if (!string.IsNullOrEmpty(_item[pi].ToString()))
                                    {
                                        cell.Value = Convert.ToDateTime(_item[pi].ToString()).ToString("yyyy-MM-dd");
                                    }
                                    else
                                    {
                                        cell.Value = "";
                                    }
                                }
                                else
                                {
                                    cell.Value = _item[pi].ToString();
                                }

                                cell.AutoFitColumns();
                                colIndex++;
                            }
                        }

                        var Newfile = new FileInfo(exreportModel.SavePathReport);

                        p.SaveAs(Newfile);
                    }
                }
                else
                {
                    throw new Exception("Cannot export a null item");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string SaveFileLocation()
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Title = "Export Data To Excel";
            SaveFile.Filter = "Excel Files(.xls)|*.xls";

            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                return SaveFile.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        public static DataTable Rights_formTable;

        public static void ShowMessageBox(Exception ex)
        {
            MessageBox.Show(ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static bool CheckDepartmentStatus(string deparmentName, string mealType)
        {
            var departright = ParametersGlobal.DepartmentRightList.FirstOrDefault(c => c.DepartmentName == deparmentName && c.MealType == mealType);

            if (departright != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
                
        public static int Dbport;
        public static short portNumber;
        public static int baudRate;
        public static string CardDatabase;
        public static string UserName;

        public static bool LoadParameters()
        {
            try
            {
                string FilePath = Application.StartupPath + "\\Application\\smisconfigSmart.xml";

                if (File.Exists(FilePath))
                {
                    DataSet configs_ds = new DataSet();
                    configs_ds.ReadXml(FilePath);

                    string HostServer = configs_ds.Tables[0].Rows[0]["Server"].ToString();
                    int.TryParse(configs_ds.Tables[0].Rows[0]["port"].ToString(), out Dbport);
                    short.TryParse(configs_ds.Tables[0].Rows[0]["readerPort"].ToString(), out portNumber);
                    int.TryParse(configs_ds.Tables[0].Rows[0]["readerBaud"].ToString(), out baudRate);
                    CardDatabase = configs_ds.Tables[0].Rows[0]["db"].ToString();

                    //loaddetails();

                    GlobalValues._MySqlConnection = "server=" + HostServer + ";user id=root; password=smart123; database=smartcafet; port=" + Dbport + ";"; ;

                    if (DataBaseOperations.CanConnect_My())
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
                    MessageBox.Show("Configuration Load Error.\r\nConfiguration file missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
