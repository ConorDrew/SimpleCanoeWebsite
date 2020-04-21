using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM.Entity
{
    namespace Accounts
    {
        public class SSC
        {
            public Payload Payload { get; set; } = null;

            public bool SaveToXml()
            {
                try
                {
                    var x = new System.Xml.Serialization.XmlSerializer(GetType());
                    // processing file location
                    var folderToSaveTo = new FolderBrowserDialog();
                    folderToSaveTo.ShowDialog();
                    if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                        return default;
                    string pFilePath = folderToSaveTo.SelectedPath + @"\" + "S_Legder_Export_" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + "_" + DateAndTime.Now.ToString("HHmmss") + ".xml";
                    var fileStream = new FileStream(pFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fileStream.Close();
                    var writer = new StreamWriter(pFilePath);
                    x.Serialize(writer, this);
                    writer.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Error converting to xml: " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                }
            }
        }

        public class Payload
        {
            public List<Line> Ledger { get; set; } = new List<Line>();
        }

        [Serializable()]
        public class Line : ICloneable
        {
            public string AccountCode { get; set; } = null;
            public string AccountingPeriod { get; set; } = null;
            public string AnalysisCode1 { get; set; } = "NRS001"; // T1 Georgraphy
            public string AnalysisCode2 { get; set; } = null; // T2 Department
            public string AnalysisCode3 { get; set; } = null; // T3 Not used
            public string AnalysisCode4 { get; set; } = null; // T4 Work Type
            public string AnalysisCode5 { get; set; } = null; // T5 VAT
            public string AnalysisCode6 { get; set; } = null; // T6 Debit Type
            public string AnalysisCode7 { get; set; } = null; // T7 Supplier/Customer Code
            public string AnalysisCode8 { get; set; } = null; // T8 Not Used
            public string AnalysisCode9 { get; set; } = null; // T9 Purchase Order No
            public string DebitCredit { get; set; } = null;
            public string Description { get; set; } = null;
            public string EntryDate { get; set; } = null;
            public string JournalType { get; set; } = null;
            public double TransactionAmount { get; set; } = default;
            public int TransactionAmountDecimalPlaces { get; set; } = default;
            public string TransactionDate { get; set; } = null;
            public string TransactionReference { get; set; } = null;

            public object Clone()
            {
                var m = new MemoryStream();
                var f = new BinaryFormatter();
                f.Serialize(m, this);
                m.Seek(0, SeekOrigin.Begin);
                return f.Deserialize(m);
            }
        }
    }
}