using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.CommonFunctions
{
    public class WriteException
    {

        public static void WriteLine(string asPatientNumber, string asEncounterId, string asElementName, string asDBColumn, string asAuditTrailName, string asDatabaseName)
        {
            const string DEBUG_FILE_NAME = "FICAuditTrailDebug.txt";
            //bool bWriteDebugLine = false;
            try
            {
                System.IO.StreamWriter oStreamWriter = System.IO.File.AppendText(("C:\\" + DEBUG_FILE_NAME));
                //oStreamWriter.WriteLine("{0} {1}${2}{3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16} {17} {18} {19}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), ", ", "PatientNumber:", asPatientNumber, ",", "EncounterId:", asEncounterId, ",", "ElementName:", asElementName, ",", "DBColumn:", asDBColumn, ",", "AuditTrailValue:", asAuditTrailName, ",", "DatabaseValue:", asDatabaseName);

                oStreamWriter.WriteLine("{0} {1}${2} {3} {4} {5}",
                                        DateTime.Now.ToShortDateString(),
                                        DateTime.Now.ToLongTimeString(),
                                        " ",
                                        "PatientNumber:",
                                        asPatientNumber,
                                        ",",
                                        "EncounterId:",
                                        asEncounterId,
                                        ",",
                                        "ElementName:",
                                        asElementName,
                                        ",",
                                        "DBColumn:",
                                        asDBColumn,
                                        ",",
                                        "AuditTrailValue:",
                                        asAuditTrailName,
                                        ",",
                                        "DatabaseValue:",
                                        asDatabaseName);

                oStreamWriter.Flush();
                oStreamWriter.Close();
            }
            catch (Exception ex)
            {
                // WriteDebugMessage("Exception:WriteLine function ", ex.ToString);
            }
        }
    }
}