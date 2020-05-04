using DocumentFormat.OpenXml.Packaging;
using FSM.Entity.ContactAttempts;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using text = iTextSharp.text;
using WD = Microsoft.Office.Interop.Word;
using WP = DocumentFormat.OpenXml.Wordprocessing;

namespace FSM.Entity
{
    namespace Sys
    {
        public class Printing
        {
            private string details1 = "";
            private string details2 = "";
            private int tableCnt = 1;
            private DialogResult answer = DialogResult.No;
            private bool InsertDocument = true;
            private WD.Application _wordApp = null;

            public WD.Application MsWordApp
            {
                get
                {
                    return _wordApp;
                }

                set
                {
                    _wordApp = value;
                }
            }

            private WD.Document _wordDoc = null;

            private WD.Document WordDoc
            {
                get
                {
                    return _wordDoc;
                }

                set
                {
                    _wordDoc = value;
                }
            }

            private object _detailsToPrint = null;

            private object DetailsToPrint
            {
                get
                {
                    return _detailsToPrint;
                }

                set
                {
                    _detailsToPrint = value;
                }
            }

            private string _documentName = string.Empty;

            private string DocumentName
            {
                get
                {
                    return _documentName;
                }

                set
                {
                    _documentName = value.Replace("/", "").Replace(@"\", "");
                }
            }

            private Enums.SystemDocumentType _printType;

            private Enums.SystemDocumentType PrintType
            {
                get
                {
                    return _printType;
                }

                set
                {
                    _printType = value;
                }
            }

            private int _orderID;

            public int OrderID
            {
                get
                {
                    return _orderID;
                }

                set
                {
                    _orderID = value;
                }
            }

            private int _siteID;

            public int SiteID
            {
                get
                {
                    return _siteID;
                }

                set
                {
                    _siteID = value;
                }
            }

            private DataTable _ContractsDT;

            public DataTable ContractsDT
            {
                get
                {
                    return _ContractsDT;
                }

                set
                {
                    _ContractsDT = value;
                }
            }

            private List<LSR.LSRError> _lsrErrors = new List<LSR.LSRError>();

            private List<LSR.LSRError> LSRErrors
            {
                get
                {
                    return _lsrErrors;
                }

                set
                {
                    _lsrErrors = value;
                }
            }

            private bool missedfirst = false;
            private string ddsort = "";
            private string ddAcc = "";
            private string wpFilePath = "";
            private string p = "Gasway100";

            public Printing(object detailsToPrintIn, string documentNameIn, Enums.SystemDocumentType printTypeIn, bool multipleDocs = false, int OrderID = 0, bool isEmail = false, int ApptsPerDay = 13, int CustomerID = default, DateTime LetterCreationDate = default, DataTable dt = null)
            {
                ContractsDT = dt;
                DetailsToPrint = detailsToPrintIn;
                DocumentName = documentNameIn;
                PrintType = printTypeIn;
                this.OrderID = OrderID;
                if (!(isEmail == true))
                {
                    if (multipleDocs == true)
                    {
                        PrintMultiDocs(ApptsPerDay, CustomerID, LetterCreationDate);
                    }
                    else
                    {
                        Print();
                    }
                }
            }

            public ArrayList MultiEmail()
            {
                string DetailsToPrint = "";
                bool success = false;
                string filePath = "";
                var returnStuff = new ArrayList();
                Cursor.Current = Cursors.WaitCursor;
                var switchExpr = PrintType;
                switch (switchExpr)
                {
                    case Enums.SystemDocumentType.ContractBatch:
                        {
                            try
                            {
                                GenerateDDMS(ContractsDT.Select());
                                filePath = GenerateRenewalLetters(ContractsDT.Select());
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (success)
                                {
                                    returnStuff.Add(filePath);
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            return returnStuff;
                        }

                    case Enums.SystemDocumentType.ContractExpiry:
                        {
                            try
                            {
                                filePath = GenerateAnnualExpiryLetters(ContractsDT.Select("InvoiceFrequencyID = 6" + " OR ContractTypeID = 69420"));
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (success)
                                {
                                    returnStuff.Add(filePath);
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            return returnStuff;
                        }

                    default:
                        {
                            return returnStuff;
                        }
                }
            }

            public string EmailWP() // wordprocessing
            {
                bool success = false;
                wpFilePath = "";
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var switchExpr = PrintType;
                    switch (switchExpr)
                    {
                        case Enums.SystemDocumentType.JobImportLetters:
                            {
                                DataTable dt = (DataTable)((ArrayList)DetailsToPrint)[0];
                                EngineerVisits.EngineerVisit engineerVisit = null;
                                if (((ArrayList)DetailsToPrint).Count > 1)
                                {
                                    engineerVisit = (EngineerVisits.EngineerVisit)((ArrayList)DetailsToPrint)[1];
                                }

                                var r = dt.Rows[0];
                                var job = new Jobs.Job();
                                job = App.DB.Job.Job_Get(Conversions.ToInteger(r["JobID"]));
                                int visitAmount = App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(Conversions.ToInteger(r["JobID"])).Count;
                                bool letter1 = Conversions.ToBoolean(Interaction.IIf(visitAmount > 1, false, true));
                                success = GenerateJobLetter(dt.Rows[0], job, letter1, null, engineerVisit);
                                if (!success)
                                    throw new Exception();
                                // mark letter as completed in dbf
                                if (letter1)
                                {
                                    success = App.DB.JobImports.JobImport_Update_Letter1(r, job);
                                }
                                else
                                {
                                    success = App.DB.JobImports.JobImport_Update_Letter2(r, job);
                                }

                                if (!success)
                                    throw new Exception();
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    success = false;
                    App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }

                return wpFilePath;
            }

            private void PrintMultiDocs(int MinsPerDayIn = 550, int CustomerID = default, DateTime LetterCreationDate = default)
            {
                // Dim DetailsToPrint As String = ""
                bool success = false;
                string filePath = "";
                var switchExpr = PrintType;
                switch (switchExpr)
                {
                    case Enums.SystemDocumentType.GSRBatch:
                        {
                            try
                            {
                                LSRErrors.Clear();
                                var folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                                }

                                var fullDocument = new List<byte[]>();
                                DataRow[] dr = (DataRow[])((ArrayList)DetailsToPrint)[0];
                                foreach (DataRow r in dr)
                                {
                                    int engineerVisitId = Helper.MakeIntegerValid(r["EngineerVisitID"]);
                                    string jobNumber = Helper.MakeStringValid(r["JobNumber"]);
                                    success = PrintGSR(engineerVisitId, fullDocument, jobNumber);
                                }

                                if (success)
                                {
                                    if (fullDocument.Count > 0)
                                    {
                                        File.WriteAllBytes(filePath, PrintHelper.CombineDocs(fullDocument));
                                        PrintHelper.RemoveSpacingInDoc(filePath);
                                        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
                                            filePath = PrintHelper.LockFile(filePath, true);
                                    }
                                }

                                if (LSRErrors.Count > 0)
                                {
                                    var errors = new List<string>();
                                    foreach (LSR.LSRError lsrError in LSRErrors)
                                        errors.Add("Job Number: " + lsrError.JobNumber + " | Visit Date: " + lsrError.VisitDate + " | Engineer:  " + lsrError.Engineer + " | EngineerVisitID:  " + lsrError.EngineerVisitID);
                                    App.ShowMessageWithDetails("Blank LSRs", "The following jobs have blank LSRs!", errors);
                                }
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (success)
                                {
                                    Process.Start(filePath);
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.ServiceLetters:
                        {
                            string folderName = @"C:\";
                            try
                            {
                                object obj;
                                Type t;

                                // Get the ProgID for Word
                                t = Type.GetTypeFromProgID("Word.Application", true);
                                obj = Activator.CreateInstance(t, true);
                                MsWordApp = (WD.Application)obj;

                                // WordApp = New Word.Application
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                folderName = App.TheSystem.Configuration.DocumentsLocation + @"ServiceLetters\ServiceLetters" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + @"\";
                                if (Directory.Exists(folderName) == false)
                                {
                                    Directory.CreateDirectory(folderName);
                                }

                                filePath = folderName + "ServiceLetters1_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                object argTemplate = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot";
                                var Letter1Doc = MsWordApp.Documents.Add(ref argTemplate);
                                object argTemplate1 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot";
                                var Letter2Doc = MsWordApp.Documents.Add(ref argTemplate1);
                                object argTemplate2 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot";
                                var Letter2HandLetters = MsWordApp.Documents.Add(ref argTemplate2);
                                // WordDoc = WordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetter.dot")
                                object argTemplate3 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot";
                                var Letter3Doc = MsWordApp.Documents.Add(ref argTemplate3);
                                object argTemplate4 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot";
                                var Letter3HandLetters = MsWordApp.Documents.Add(ref argTemplate4);
                                Letter1Doc.GrammarChecked = true;
                                Letter1Doc.SpellingChecked = true;
                                Letter2Doc.GrammarChecked = true;
                                Letter2Doc.SpellingChecked = true;
                                Letter2HandLetters.GrammarChecked = true;
                                Letter2HandLetters.SpellingChecked = true;
                                Letter3Doc.GrammarChecked = true;
                                Letter3Doc.SpellingChecked = true;
                                Letter3HandLetters.GrammarChecked = true;
                                Letter3HandLetters.SpellingChecked = true;
                                DataRow[] dr = (DataRow[])((ArrayList)DetailsToPrint)[0];

                                // Dim AMsToDo As Integer = 0
                                // Dim AMsAssigned As Integer = 0
                                // AMsToDo = dr.Length / 2

                                int servicePriority = 0;
                                DataRow[] rows = App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'Service'");
                                if (rows.Length == 0)
                                {
                                    var oPickList = new PickLists.PickList();
                                    oPickList.SetName = "Service";
                                    oPickList.SetEnumTypeID = Conversions.ToInteger(Enums.PickListTypes.JOWPriority);
                                    servicePriority = App.DB.Picklists.Insert(oPickList);
                                }
                                else
                                {
                                    servicePriority = Conversions.ToInteger(((DataRow)rows[0])["ManagerID"]);
                                }

                                StreamWriter oWriteSolidFuels;
                                oWriteSolidFuels = File.CreateText(folderName + "SolidFuels.txt");
                                oWriteSolidFuels.WriteLine("Solid Fuels Properties : ");
                                StreamWriter oWriteWA;
                                oWriteWA = File.CreateText(folderName + "WarningsAdvice.txt");
                                oWriteWA.WriteLine("Properties with Warnings/Advice : ");
                                StreamWriter oWriteVoids;
                                oWriteVoids = File.CreateText(folderName + "Voids.txt");
                                oWriteVoids.WriteLine("Voids Properties : ");
                                StreamWriter oWriteSiteFuel;
                                oWriteSiteFuel = File.CreateText(folderName + "NonGasSiteFuels.txt");
                                oWriteSiteFuel.WriteLine("Non Gas Site Fuel Properties : ");
                                int HighestLoops = 0;
                                try
                                {
                                    string AMPM = "";
                                    string Fuel = "";
                                    var dtDays = new DataTable();
                                    dtDays.Columns.Add("MondayDate", typeof(DateTime));
                                    dtDays.Columns.Add("TheDate", typeof(DateTime));
                                    dtDays.Columns.Add("Count");
                                    dtDays.Columns.Add("AM");
                                    dtDays.Columns.Add("PM");
                                    dtDays.Columns.Add("ApptsMinsTally");
                                    dtDays.Columns.Add("Loops");
                                    var dtLetter2AMPM = new DataTable();
                                    dtLetter2AMPM.Columns.Add("Date", typeof(DateTime));
                                    dtLetter2AMPM.Columns.Add("Count");
                                    dtLetter2AMPM.Columns.Add("AMAssigned");
                                    var dtLetter3AMPM = new DataTable();
                                    dtLetter3AMPM.Columns.Add("Date", typeof(DateTime));
                                    dtLetter3AMPM.Columns.Add("Count");
                                    dtLetter3AMPM.Columns.Add("AMAssigned");
                                    App.DB.LetterManager.Clear_LetterDays_Table();

                                    // LETS DO DATES FIRST
                                    foreach (DataRow d in dr)
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(d["type"], "Letter 1", false)))
                                        {
                                            var oSite = App.DB.Sites.Get(d["SiteID"]);
                                            DataRow[] sorRows;
                                            if (oSite.CommercialDistrict == true)
                                            {
                                                sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7008'");
                                            }
                                            else if (oSite.SolidFuel == true)
                                            {
                                                sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7001'");
                                            }
                                            else
                                            {
                                                sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7007'");
                                            }

                                            var TimeInMins = default(int);
                                            if (sorRows.Length > 0)
                                            {
                                                var sorRow = sorRows[0];
                                                var customerSors = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(sorRow["ScheduleOfRatesCategoryID"]), Conversions.ToString(sorRow["Description"]), Conversions.ToString(sorRow["Code"]), CustomerID);
                                                int customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                                                if (customerSorId > 0)
                                                {
                                                    var customerSor = App.DB.CustomerScheduleOfRate.Get(customerSorId);
                                                    if (customerSor is null)
                                                        customerSor = new CustomerScheduleOfRates.CustomerScheduleOfRate();
                                                    // Use Site SOR
                                                    TimeInMins = customerSor.TimeInMins;
                                                }
                                                else
                                                {
                                                    // Use System SOR
                                                    TimeInMins = Conversions.ToInteger(sorRow["TimeInMins"]);
                                                }
                                            }

                                            d["NextVisitDate"] = DateHelper.CheckBankHolidaySatOrSun(Conversions.ToDate(d["NextVisitDate"]));

                                            int MaxLoops = 1;
                                            bool ApptFound = false;
                                            while (ApptFound == false)
                                            {
                                                for (int lps = 1, loopTo = MaxLoops; lps <= loopTo; lps++)
                                                {
                                                    if (lps > HighestLoops)
                                                        HighestLoops = lps;
                                                    for (int dow = 1; dow <= 4; dow++)
                                                    {
                                                        var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
                                                        if (dvBankHolidays.Table.Select("BankHolidayDate='" + DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow) + "'").Length == 0)
                                                        {
                                                            var theRow = dtDays.Select("MondayDate='" + DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])) + "' AND TheDate='" + DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow) + "' AND Loops='" + lps + "'");
                                                            if (theRow.Length == 0)
                                                            {
                                                                dtDays.Rows.Add(new object[] { DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])), DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow), 1, 1, 0, TimeInMins, lps });
                                                                App.DB.LetterManager.Insert_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])), DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow), TimeInMins, lps);
                                                                ApptFound = true;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                int ApptsMinsTally = Conversions.ToInteger(theRow[0]["ApptsMinsTally"]);
                                                                if (ApptsMinsTally <= MinsPerDayIn / (double)2)
                                                                {
                                                                    theRow[0]["count"] = Convert.ToInt32(theRow[0]["count"]) + 1;
                                                                    theRow[0]["AM"] = Convert.ToInt32(theRow[0]["AM"]) + 1;
                                                                    theRow[0]["ApptsMinsTally"] = Convert.ToInt32(theRow[0]["ApptsMinsTally"]) + TimeInMins;
                                                                    App.DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])), DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow), Conversions.ToInteger(theRow[0]["count"]), Conversions.ToInteger(theRow[0]["AM"]), default, Conversions.ToInteger(theRow[0]["ApptsMinsTally"]), lps);
                                                                    ApptFound = true;
                                                                    break;
                                                                }
                                                                else if (ApptsMinsTally > MinsPerDayIn / (double)2 & ApptsMinsTally <= MinsPerDayIn)
                                                                {
                                                                    theRow[0]["count"] = Convert.ToInt32(theRow[0]["count"]) + 1 + 1;
                                                                    theRow[0]["PM"] = Convert.ToInt32(theRow[0]["PM"]) + 1;
                                                                    theRow[0]["ApptsMinsTally"] = Convert.ToInt32(theRow[0]["ApptsMinsTally"]) + TimeInMins;
                                                                    App.DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])), DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow), Conversions.ToInteger(theRow[0]["count"]), default, Conversions.ToInteger(theRow[0]["PM"]), Conversions.ToInteger(theRow[0]["ApptsMinsTally"]), lps);
                                                                    ApptFound = true;
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    ApptFound = false;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ApptFound = false;
                                                        }
                                                    }

                                                    if (ApptFound == false)
                                                    {
                                                        var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
                                                        int dow = 0;
                                                        bool ResetApptMins = false;
                                                        if (dvBankHolidays.Table.Select("BankHolidayDate='" + DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow) + "'").Length == 0)
                                                        {
                                                            var theRow = dtDays.Select("MondayDate='" + DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])) + "' AND TheDate='" + DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow) + "' AND Loops='" + lps + "'");
                                                            if (theRow.Length == 0)
                                                            {
                                                                dtDays.Rows.Add(new object[] { DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])), DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow), 1, 1, 0, TimeInMins, lps });
                                                                App.DB.LetterManager.Insert_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])), DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow), TimeInMins, lps);
                                                                ApptFound = true;
                                                            }
                                                            else
                                                            {
                                                                int ApptsMinsTally = Conversions.ToInteger(theRow[0]["ApptsMinsTally"]);
                                                                if (ApptsMinsTally <= MinsPerDayIn / (double)2)
                                                                {
                                                                    theRow[0]["count"] = Convert.ToInt32(theRow[0]["count"]) + 1;
                                                                    theRow[0]["AM"] = Convert.ToInt32(theRow[0]["AM"]) + 1;
                                                                    theRow[0]["ApptsMinsTally"] = Convert.ToInt32(theRow[0]["ApptsMinsTally"]) + TimeInMins;
                                                                    App.DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])), DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow), Conversions.ToInteger(theRow[0]["count"]), Conversions.ToInteger(theRow[0]["AM"]), default, Conversions.ToInteger(theRow[0]["ApptsMinsTally"]), lps);
                                                                    ApptFound = true;
                                                                }
                                                                else if (ApptsMinsTally > MinsPerDayIn / (double)2 & ApptsMinsTally <= MinsPerDayIn)
                                                                {
                                                                    theRow[0]["count"] = Convert.ToInt32(theRow[0]["count"]) + 1;
                                                                    theRow[0]["AM"] = Convert.ToInt32(theRow[0]["PM"]) + 1;
                                                                    theRow[0]["ApptsMinsTally"] = Convert.ToInt32(theRow[0]["ApptsMinsTally"]) + TimeInMins;
                                                                    App.DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])), DateHelper.GetTheMonday(Conversions.ToDate(d["NextVisitDate"])).AddDays(dow), Conversions.ToInteger(theRow[0]["count"]), default, Conversions.ToInteger(theRow[0]["PM"]), Conversions.ToInteger(theRow[0]["ApptsMinsTally"]), lps);
                                                                    ApptFound = true;
                                                                }
                                                                else
                                                                {
                                                                    // theRow(0).Item("ApptsMinsTally") = 0
                                                                    MaxLoops += 1;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MaxLoops += 1;
                                                        }
                                                    }

                                                    if (ApptFound)
                                                        break;
                                                }
                                            }
                                        }
                                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(d["Type"], "Letter 2", false)))
                                        {
                                            var theRow = dtLetter2AMPM.Select(Conversions.ToString("Date='" + d["NextVisitDate"] + "'"));
                                            if (theRow.Length == 0)
                                            {
                                                dtLetter2AMPM.Rows.Add(new object[] { d["NextVisitDate"], 1, 0 });
                                            }
                                            else
                                            {
                                                theRow[0]["count"] = Convert.ToInt32(theRow[0]["count"]) + 1;
                                            }
                                        }
                                        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(d["Type"], "Letter 3", false)))
                                        {
                                            var theRow = dtLetter3AMPM.Select(Conversions.ToString("Date='" + d["NextVisitDate"] + "'"));
                                            if (theRow.Length == 0)
                                            {
                                                dtLetter3AMPM.Rows.Add(new object[] { d["NextVisitDate"], 1, 0 });
                                            }
                                            else
                                            {
                                                theRow[0]["count"] = Convert.ToInt32(theRow[0]["count"]) + 1;
                                            }
                                        }
                                        else
                                        {
                                        }
                                    }

                                    object argTemplate5 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection.dot";
                                    var WordDocCopy = MsWordApp.Documents.Add(ref argTemplate5);
                                    object argTemplate6 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection2.dot";
                                    var WordDoc2Copy = MsWordApp.Documents.Add(ref argTemplate6);
                                    object argTemplate7 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection2HandLetter.dot";
                                    var WordDoc2HandCopy = MsWordApp.Documents.Add(ref argTemplate7);
                                    object argTemplate8 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3.dot";
                                    var WordDoc3Copy = MsWordApp.Documents.Add(ref argTemplate8);
                                    object argTemplate9 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3HandLetter.dot";
                                    var WordDoc3HandCopy = MsWordApp.Documents.Add(ref argTemplate9);
                                    object argTemplate10 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3HandLetterDistrict.dot";
                                    var WordDoc3HandCopyCommercial = MsWordApp.Documents.Add(ref argTemplate10);
                                    WordDoc2Copy.GrammarChecked = true;
                                    WordDoc2Copy.SpellingChecked = true;
                                    WordDoc2HandCopy.GrammarChecked = true;
                                    WordDoc2HandCopy.SpellingChecked = true;
                                    WordDoc3Copy.GrammarChecked = true;
                                    WordDoc3Copy.SpellingChecked = true;
                                    WordDoc3HandCopy.GrammarChecked = true;
                                    WordDoc3HandCopy.SpellingChecked = true;
                                    WordDoc3HandCopyCommercial.GrammarChecked = true;
                                    WordDoc3HandCopyCommercial.SpellingChecked = true;
                                    Jobs.Job _currentJob;
                                    var theVisitDate = default(DateTime);
                                    System.Data.SqlClient.SqlTransaction trans = null;
                                    System.Data.SqlClient.SqlConnection con = null;
                                    int Letter1_CurrentApptDay = 1; // Zero based day of week (1 = Tuesday)
                                    int Letter1_TodaysApptsLength = 0;

                                    // MAIN LOOP
                                    foreach (DataRow r in dr)
                                    {
                                        try
                                        {
                                            con = new System.Data.SqlClient.SqlConnection(App.DB.ServerConnectionString);
                                            con.Open();
                                            trans = con.BeginTransaction(IsolationLevel.ReadUncommitted);
                                            var JobNumber = new JobNumber();
                                            switch (CustomerID)
                                            {
                                                case (int)Enums.Customer.NCC: // Norwich City Council
                                                    {
                                                        JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.SERVICE_LETTER_JOB, trans);
                                                        break;
                                                    }

                                                default:
                                                    {
                                                        JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout, trans);
                                                        break;
                                                    }
                                            }

                                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["type"], "Letter 1", false)))
                                            {
                                                WordDoc = Letter1Doc;
                                                WordDoc.GrammarChecked = true;
                                                WordDoc.SpellingChecked = true;
                                                WordDocCopy.Select();
                                                MsWordApp.Selection.WholeStory();
                                                MsWordApp.Selection.Copy();
                                                WordDoc.Activate();
                                                object argUnit = WD.WdUnits.wdStory;
                                                MsWordApp.Selection.EndKey(Unit: ref argUnit);
                                                MsWordApp.Selection.Paste();
                                                DateTime VisitDateHolder = Conversions.ToDate(r["NextVisitDate"]);
                                                string PostCodeHolder = Helper.FormatPostcode(r["Postcode"]);
                                                foreach (DataRow dDay in dtDays.Rows)
                                                {
                                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dDay["MondayDate"], DateHelper.GetTheMonday(Conversions.ToDate(r["NextVisitDate"])), false) & !Operators.ConditionalCompareObjectEqual(dDay["Count"], 0, false)))
                                                    {
                                                        theVisitDate = Conversions.ToDate(dDay["TheDate"]);
                                                        dDay["Count"] = Convert.ToInt32(dDay["Count"]) - 1;
                                                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dDay["AM"], 0, false)))
                                                        {
                                                            AMPM = "AM";
                                                            dDay["AM"] = Convert.ToInt32(dDay["AM"]) - 1;
                                                            App.DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(r["NextVisitDate"])), Conversions.ToDate(dDay["TheDate"]), Conversions.ToInteger(dDay["Count"]), Conversions.ToInteger(dDay["AM"]), default, Conversions.ToInteger(dDay["ApptsMinsTally"]), Conversions.ToInteger(dDay["Loops"]));
                                                        }
                                                        else
                                                        {
                                                            AMPM = "PM";
                                                            dDay["PM"] = Convert.ToInt32(dDay["PM"]) - 1;
                                                            App.DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(r["NextVisitDate"])), Conversions.ToDate(dDay["TheDate"]), Conversions.ToInteger(dDay["Count"]), default, Conversions.ToInteger(dDay["PM"]), Conversions.ToInteger(dDay["ApptsMinsTally"]), Conversions.ToInteger(dDay["Loops"]));
                                                        }

                                                        break;
                                                    }
                                                }
                                            }
                                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 2", false)))
                                            {
                                                WordDoc = Letter2Doc;
                                                WordDoc.GrammarChecked = true;
                                                WordDoc.SpellingChecked = true;
                                                WordDoc2Copy.Select();
                                                MsWordApp.Selection.WholeStory();
                                                MsWordApp.Selection.Copy();
                                                WordDoc.Activate();
                                                object argUnit2 = WD.WdUnits.wdStory;
                                                MsWordApp.Selection.EndKey(Unit: ref argUnit2);
                                                MsWordApp.Selection.Paste();
                                                theVisitDate = DateHelper.CheckBankHolidaySatOrSun(Conversions.ToDate(r["NextVisitDate"]));
                                                var theRow = dtLetter2AMPM.Select(Conversions.ToString("Date='" + r["NextVisitDate"] + "'"));
                                                if (theRow.Length > 0)
                                                {
                                                    if (Convert.ToInt32(theRow[0]["AMAssigned"]) >= (Convert.ToInt32(theRow[0]["Count"])) / 2)
                                                    {
                                                        AMPM = "PM";
                                                    }
                                                    else
                                                    {
                                                        AMPM = "AM";
                                                        theRow[0]["AMAssigned"] = Convert.ToInt32(theRow[0]["AMAssigned"]) + 1;
                                                    }
                                                }

                                                MsWordApp.Selection.InsertBreak();
                                            }
                                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 3", false)))
                                            {
                                                WordDoc = Letter3Doc;
                                                WordDoc.GrammarChecked = true;
                                                WordDoc.SpellingChecked = true;
                                                WordDoc3Copy.Select();
                                                MsWordApp.Selection.WholeStory();
                                                MsWordApp.Selection.Copy();
                                                WordDoc.Activate();
                                                object argUnit1 = WD.WdUnits.wdStory;
                                                MsWordApp.Selection.EndKey(Unit: ref argUnit1);
                                                MsWordApp.Selection.Paste();
                                                theVisitDate = DateHelper.CheckBankHolidaySatOrSun(Conversions.ToDate(r["NextVisitDate"]));
                                                var theRow = dtLetter3AMPM.Select(Conversions.ToString("Date='" + r["NextVisitDate"] + "'"));
                                                if (theRow.Length > 0)
                                                {
                                                    if (Convert.ToInt32(theRow[0]["AMAssigned"]) >= (Convert.ToInt32(theRow[0]["Count"])) / 2)
                                                    {
                                                        AMPM = "PM";
                                                    }
                                                    else
                                                    {
                                                        AMPM = "AM";
                                                        theRow[0]["AMAssigned"] = Convert.ToInt32(theRow[0]["AMAssigned"]) + 1;
                                                    }
                                                }
                                            }

                                            success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix + JobNumber.Number, DateAndTime.Now);
                                            if (success == true)
                                            {
                                                object argType = WD.WdBreakType.wdPageBreak;
                                                MsWordApp.Selection.InsertBreak(Type: ref argType);

                                                var oSite = App.DB.Sites.Get(r["SiteID"]);
                                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["type"], "Letter 1", false)))
                                                {
                                                    Letter1Doc = WordDoc;
                                                }
                                                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 2", false)))
                                                {
                                                    Letter2Doc = WordDoc;

                                                    // HAND DELIVER LETTER
                                                    WordDoc = Letter2HandLetters;
                                                    WordDoc.GrammarChecked = true;
                                                    WordDoc.SpellingChecked = true;
                                                    WordDoc2HandCopy.Select();
                                                    MsWordApp.Selection.WholeStory();
                                                    MsWordApp.Selection.Copy();
                                                    WordDoc.Activate();
                                                    object argUnit4 = WD.WdUnits.wdStory;
                                                    MsWordApp.Selection.EndKey(Unit: ref argUnit4);
                                                    MsWordApp.Selection.Paste();
                                                    success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix + JobNumber.Number, DateAndTime.Now);
                                                    Letter2HandLetters = WordDoc;
                                                }
                                                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 3", false)))
                                                {
                                                    Letter3Doc = WordDoc;
                                                    // HAND DELIVER LETTER
                                                    WordDoc = Letter3HandLetters;
                                                    WordDoc.GrammarChecked = true;
                                                    WordDoc.SpellingChecked = true;
                                                    if (oSite.CommercialDistrict == true)
                                                    {
                                                        WordDoc3HandCopyCommercial.Select();
                                                    }
                                                    else
                                                    {
                                                        WordDoc3HandCopy.Select();
                                                    }

                                                    MsWordApp.Selection.WholeStory();
                                                    MsWordApp.Selection.Copy();
                                                    WordDoc.Activate();
                                                    object argUnit3 = WD.WdUnits.wdStory;
                                                    MsWordApp.Selection.EndKey(Unit: ref argUnit3);
                                                    MsWordApp.Selection.Paste();
                                                    success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix + JobNumber.Number, DateAndTime.Now);
                                                    Letter3HandLetters = WordDoc;
                                                }

                                                if (success == true)
                                                {
                                                    // CREATE JOB
                                                    _currentJob = new Jobs.Job();
                                                    _currentJob.SetPropertyID = r["SiteID"];
                                                    _currentJob.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Callout);
                                                    _currentJob.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")[0]["ManagerID"];
                                                    _currentJob.SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open);
                                                    _currentJob.SetCreatedByUserID = App.loggedInUser.UserID;
                                                    _currentJob.SetFOC = true;
                                                    _currentJob.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                                                    _currentJob.SetPONumber = "";
                                                    _currentJob.SetQuoteID = 0;
                                                    _currentJob.SetContractID = 0;

                                                    // INSERT JOB ITEM
                                                    var jobOfWork = new JobOfWorks.JobOfWork();
                                                    jobOfWork.SetPONumber = "";
                                                    jobOfWork.SetPriority = servicePriority;
                                                    if (!(jobOfWork.Priority == 0))
                                                    {
                                                        jobOfWork.PriorityDateSet = DateAndTime.Now;
                                                    }

                                                    jobOfWork.IgnoreExceptionsOnSetMethods = true;
                                                    DataRow[] sorRows = null;
                                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 1", false)))
                                                    {
                                                        if (oSite.CommercialDistrict == true)
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7008'");
                                                        }
                                                        else if (oSite.SolidFuel == true)
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7001'");
                                                        }
                                                        else
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7007'");
                                                        }
                                                    }
                                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 2", false)))
                                                    {
                                                        if (oSite.CommercialDistrict == true)
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7008*'");
                                                        }
                                                        else if (oSite.SolidFuel == true)
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7001*'");
                                                        }
                                                        else
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7007*'");
                                                        }
                                                    }
                                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 3", false)))
                                                    {
                                                        if (oSite.CommercialDistrict == true)
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7008^'");
                                                        }
                                                        else if (oSite.SolidFuel == true)
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7001^'");
                                                        }
                                                        else
                                                        {
                                                            sorRows = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7007^'");
                                                        }
                                                    }

                                                    if (sorRows.Length > 0)
                                                    {
                                                        var sorRow = sorRows[0];
                                                        var customerSors = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(sorRow["ScheduleOfRatesCategoryID"]), Conversions.ToString(sorRow["Description"]), Conversions.ToString(sorRow["Code"]), CustomerID);
                                                        int customerSorId = 0;
                                                        if (customerSors.Rows.Count > 0)
                                                            customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                                                        if (!(customerSorId > 0))
                                                        {
                                                            var customerSor = new CustomerScheduleOfRates.CustomerScheduleOfRate()
                                                            {
                                                                SetCode = sorRow["Code"],
                                                                SetDescription = sorRow["Description"],
                                                                SetPrice = sorRow["Price"],
                                                                SetScheduleOfRatesCategoryID = sorRow["ScheduleOfRatesCategoryID"],
                                                                SetTimeInMins = sorRow["TimeInMins"],
                                                                SetCustomerID = CustomerID
                                                            };
                                                            customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                                                            App.DB.CustomerScheduleOfRate.Delete(customerSorId);
                                                        }

                                                        var jobItem = new JobItems.JobItem();
                                                        jobItem.IgnoreExceptionsOnSetMethods = true;
                                                        jobItem.SetSummary = sorRow["Description"];
                                                        jobItem.SetQty = 1;
                                                        jobItem.SetRateID = customerSorId;
                                                        jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                                                        jobOfWork.JobItems.Add(jobItem);
                                                    }

                                                    var engineerVisit = new EngineerVisits.EngineerVisit();
                                                    engineerVisit.IgnoreExceptionsOnSetMethods = true;
                                                    engineerVisit.SetEngineerID = 0;

                                                    // set site fuel in visit notes
                                                    if (r["SiteFuel"] == DBNull.Value)
                                                    {
                                                        Fuel = "";
                                                    }
                                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["SiteFuel"], "Gas", false) | Operators.ConditionalCompareObjectEqual(r["siteFuel"], "0", false)))
                                                    {
                                                        Fuel = "";
                                                    }
                                                    else
                                                    {
                                                        Fuel = Conversions.ToString(r["siteFuel"]);
                                                    }

                                                    engineerVisit.SetNotesToEngineer = "(" + AMPM + ") - " + Fuel + " - Carry out safety inspection";
                                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 2", false)))
                                                    {
                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Take hand delivered letter and red sticker. ";
                                                    }
                                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 3", false)))
                                                    {
                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                                                    }

                                                    if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 1", false)))
                                                    {
                                                        engineerVisit.SetPartsToFit = true;
                                                    }

                                                    engineerVisit.StartDateTime = DateTime.MinValue;
                                                    engineerVisit.EndDateTime = DateTime.MinValue;
                                                    engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                                                    engineerVisit.DueDate = theVisitDate;
                                                    engineerVisit.SetAMPM = AMPM;
                                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 1", false)))
                                                    {
                                                        engineerVisit.SetVisitNumber = 1;
                                                    }
                                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 2", false)))
                                                    {
                                                        engineerVisit.SetVisitNumber = 2;
                                                    }
                                                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 3", false)))
                                                    {
                                                        engineerVisit.SetVisitNumber = 3;
                                                    }

                                                    jobOfWork.EngineerVisits.Add(engineerVisit);
                                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Type"], "Letter 3", false) & CustomerID != (int)Enums.Customer.NCC))
                                                    {
                                                        jobOfWork.EngineerVisits.Add(engineerVisit);
                                                    }

                                                    _currentJob.JobOfWorks.Add(jobOfWork);
                                                    _currentJob = App.DB.Job.Insert(_currentJob, trans);

                                                    // RECORD JOB/LETTER CREATION
                                                    App.DB.LetterManager.LetterGenerated(Conversions.ToInteger(r["SiteID"]), Conversions.ToString(r["Type"]), Conversions.ToDate(r["LastServiceDate"]), _currentJob.JobID, folderName, trans);

                                                    // RECORD SOLID FUELS
                                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["SolidFuel"], true, false)))
                                                    {
                                                        oWriteSolidFuels.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", ") + r["Address4"] + ", ") + r["Address5"] + ", " + Helper.FormatPostcode(r["Postcode"]));
                                                    }

                                                    // RECORD WARNINGS OR ADVICE
                                                    if (r["Notes"].ToString().Contains("T1WARN") | r["Notes"].ToString().Contains("T1ADVI") | r["Notes"].ToString().Contains("T2WARN") | r["Notes"].ToString().Contains("T2ADVI"))
                                                    {
                                                        oWriteWA.WriteLine(" ");
                                                        oWriteWA.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", ") + r["Address4"] + ", ") + r["Address5"] + ", " + Helper.FormatPostcode(r["Postcode"]) + " NOTES : ") + r["Notes"]);
                                                    }

                                                    // RECORD VOID PROPERTIES
                                                    if (Helper.MakeBooleanValid(r["PropertyVoid"]) == true)
                                                    {
                                                        oWriteVoids.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", ") + r["Address4"] + ", ") + r["Address5"] + ", " + Helper.FormatPostcode(r["Postcode"]));
                                                    }

                                                    // RECORD NON GAS SITE FUELS
                                                    if (!(r["SiteFuel"] == DBNull.Value))
                                                    {
                                                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["SiteFuel"], "Gas", false)))
                                                        {
                                                            oWriteSiteFuel.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", ") + r["Address4"] + ", ") + r["Address5"] + ", " + Helper.FormatPostcode(r["Postcode"]) + ", ") + r["SiteFuel"]);
                                                        }
                                                    }
                                                }
                                            }

                                            trans.Commit();
                                        }
                                        catch (Exception ex)
                                        {
                                            App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            if (trans is object)
                                            {
                                                trans.Rollback();
                                            }

                                            if (con is object)
                                            {
                                                con.Close();
                                            }
                                        }
                                    }

                                    oWriteSolidFuels.Close();
                                    oWriteWA.Close();
                                    oWriteVoids.Close();
                                    oWriteSiteFuel.Close();
                                    WordDoc = Letter1Doc;
                                    WordDoc.GrammarChecked = true;
                                    WordDoc.SpellingChecked = true;
                                    Letter2Doc.Activate();
                                    MsWordApp.Selection.WholeStory();
                                    MsWordApp.Selection.Font.Name = "Arial";
                                    object argFileName = folderName + "ServiceLetters2_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                    Letter2Doc.SaveAs(ref argFileName);
                                    Letter3Doc.Activate();
                                    MsWordApp.Selection.WholeStory();
                                    MsWordApp.Selection.Font.Name = "Arial";
                                    object argFileName1 = folderName + "ServiceLetters3_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                    Letter3Doc.SaveAs(ref argFileName1);
                                    Letter2HandLetters.Activate();
                                    MsWordApp.Selection.WholeStory();
                                    MsWordApp.Selection.Font.Name = "Arial";
                                    object argFileName2 = folderName + "ServiceLetters2HandDeliver_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                    Letter2HandLetters.SaveAs(ref argFileName2);
                                    Letter3HandLetters.Activate();
                                    MsWordApp.Selection.WholeStory();
                                    MsWordApp.Selection.Font.Name = "Arial";
                                    object argFileName3 = folderName + "ServiceLetters3HandDeliver_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                    Letter3HandLetters.SaveAs(ref argFileName3);
                                    Marshal.ReleaseComObject(Letter2Doc);
                                    Letter2Doc = null;
                                    Marshal.ReleaseComObject(WordDocCopy);
                                    WordDocCopy = null;
                                    Marshal.ReleaseComObject(WordDoc2Copy);
                                    WordDoc2Copy = null;
                                    Marshal.ReleaseComObject(WordDoc2HandCopy);
                                    WordDoc2HandCopy = null;
                                    Marshal.ReleaseComObject(Letter3Doc);
                                    Letter3Doc = null;
                                    Marshal.ReleaseComObject(WordDoc3Copy);
                                    WordDoc3Copy = null;
                                    Marshal.ReleaseComObject(WordDoc3HandCopy);
                                    WordDoc3HandCopy = null;
                                    Marshal.ReleaseComObject(WordDoc3HandCopyCommercial);
                                    WordDoc3HandCopyCommercial = null;
                                    WordDoc.Activate();
                                }
                                catch (Exception ex)
                                {
                                    App.ShowMessage("Letter Generation Failed : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                // GENERATE EXCEL REPORT
                                // GET ALL TOMORROWS LETTER 3 VISITS
                                // IS TOMORROW SAT OR SUN - THEN GET MONDAY
                                DateTime tomorrow = Conversions.ToDate(Strings.Format(DateAndTime.Now.AddDays(1), "dd-MMM-yyyy") + " 00:00:00");
                                if (DateAndTime.Now.DayOfWeek == DayOfWeek.Friday)
                                {
                                    tomorrow = Conversions.ToDate(Strings.Format(DateAndTime.Now.AddDays(3), "dd-MMM-yyyy") + " 00:00:00");
                                }
                                else if (DateAndTime.Now.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    tomorrow = Conversions.ToDate(Strings.Format(DateAndTime.Now.AddDays(2), "dd-MMM-yyyy") + " 00:00:00");
                                }

                                var dt3rdVisitReport = App.DB.LetterManager.Letter3_TomorrowsVisit(tomorrow);
                                ExportHelper.Export(dt3rdVisitReport, "3rd Visits", Enums.ExportType.XLS, false);
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                MsWordApp.Selection.WholeStory();
                                MsWordApp.Selection.Font.Name = "Arial";
                                Finalise(filePath, success);
                                if (success)
                                {
                                    Process.Start(folderName);
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.ServiceLettersMK2:
                        {
                            string folderName = @"C:\";
                            try
                            {
                                folderName = App.TheSystem.Configuration.DocumentsLocation + @"ServiceLetters\ServiceLetters" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + @"\";
                                Directory.CreateDirectory(folderName);
                                DataTable dt = ((DataView)((ArrayList)DetailsToPrint)[0]).ToTable();
                                StreamWriter oWriteSolidFuels;
                                oWriteSolidFuels = File.CreateText(folderName + "SolidFuels.txt");
                                oWriteSolidFuels.WriteLine("Solid Fuels Properties : ");
                                StreamWriter oWriteWA;
                                oWriteWA = File.CreateText(folderName + "WarningsAdvice.txt");
                                oWriteWA.WriteLine("Properties with Warnings/Advice : ");
                                StreamWriter oWriteVoids;
                                oWriteVoids = File.CreateText(folderName + "Voids.txt");
                                oWriteVoids.WriteLine("Voids Properties : ");
                                StreamWriter oWriteSiteFuel;
                                oWriteSiteFuel = File.CreateText(folderName + "NonGasSiteFuels.txt");
                                oWriteSiteFuel.WriteLine("Non Gas Site Fuel Properties : ");
                                try
                                {
                                    try
                                    {
                                        DateTime theVisitDate;
                                        int Letter1_CurrentApptDay = 1; // Zero based day of week (1 = Tuesday)
                                        int Letter1_TodaysApptsLength = 0;

                                        // MAIN LOOP
                                        bool JustLetters = false;
                                        if (dt.Columns.Contains("JobNumber"))
                                        {
                                            JustLetters = true;
                                        }
                                        else
                                        {
                                            dt.Columns.Add("JobNumber");
                                            dt.Columns.Add("JobID");
                                        }

                                        int VisitTime = 0;
                                        if (dt.Select("Type = 'Letter 1' AND SendLetterTick = 1").Length > 0)
                                        {
                                            filePath = folderName + "ServiceLetters1_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".docx";
                                            var document = new List<byte[]>();
                                            var dr = (from row in dt.AsEnumerable()
                                                      where (row.Field<string>("Type") ?? "") == "Letter 1" & row.Field<bool>("SendLetterTick") == true
                                                      select row).ToArray();
                                            foreach (DataRow r in dr)
                                            {
                                                if (Helper.MakeDateTimeValid(r["BookedDateTime"]) == default)
                                                    continue;
                                                DateTime VisitDateHolder = Conversions.ToDate(r["BookedDateTime"]);
                                                theVisitDate = Conversions.ToDate(r["BookedDateTime"]);
                                                string fuel = "";
                                                string AMPM = Helper.MakeStringValid(r["AMPM"]);
                                                int fuelId = 0;
                                                if (r.Table.Columns.Contains("FuelID") && !Information.IsDBNull(r["FuelID"]))
                                                    fuelId = Helper.MakeIntegerValid(r["FuelID"]);
                                                var jobnumbers = new Jobs.Job();
                                                if (JustLetters == false)
                                                {
                                                    jobnumbers = App.DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId);
                                                }
                                                else
                                                {
                                                    jobnumbers.SetJobID = r["JobID"];
                                                    jobnumbers.SetJobNumber = r["JobNumber"];
                                                }

                                                if (!r["SiteFuel"].ToString().StartsWith("&"))
                                                {
                                                    success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, DateAndTime.Now, document, jobnumbers.JobID, JustLetters);
                                                    if (success == true)
                                                    {
                                                        // RECORD JOB/LETTER CREATION
                                                        if (JustLetters == false)
                                                        {
                                                            App.DB.LetterManager.LetterGeneratedMK2(Conversions.ToInteger(r["SiteID"]), Conversions.ToString(r["Type"]), Conversions.ToDate(r["LastServiceDate"]), jobnumbers.JobID, folderName, fuelId);
                                                        }

                                                        // RECORD SOLID FUELS
                                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["SolidFuel"], true, false)))
                                                        {
                                                            oWriteSolidFuels.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]));
                                                        }
                                                        // RECORD WARNINGS OR ADVICE
                                                        if (r["Notes"].ToString().Contains("T1WARN") | r["Notes"].ToString().Contains("T1ADVI") | r["Notes"].ToString().Contains("T2WARN") | r["Notes"].ToString().Contains("T2ADVI"))
                                                        {
                                                            oWriteWA.WriteLine(" ");
                                                            oWriteWA.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]) + ", " + " NOTES : ") + r["Notes"]);
                                                        }
                                                        // RECORD VOID PROPERTIES
                                                        if (Helper.MakeBooleanValid(r["PropertyVoid"]) == true)
                                                        {
                                                            oWriteVoids.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]));
                                                        }
                                                        // RECORD NON GAS SITE FUELS
                                                        if (!(r["SiteFuel"] == DBNull.Value))
                                                        {
                                                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["SiteFuel"], "Gas", false)))
                                                            {
                                                                oWriteSiteFuel.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]) + ", ") + r["SiteFuel"]);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            if (document.Count > 0)
                                            {
                                                File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document));
                                            }
                                        }

                                        if (dt.Select("Type = 'Letter 2' AND SendLetterTick = 1").Length > 0)
                                        {
                                            filePath = folderName + "ServiceLetters2_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmmss") + ".docx";
                                            var document = new List<byte[]>();
                                            var dr = (from row in dt.AsEnumerable()
                                                      where (row.Field<string>("Type") ?? "") == "Letter 2" & row.Field<bool>("SendLetterTick") == true
                                                      select row).ToArray();
                                            foreach (DataRow r in dr)
                                            {
                                                if (Helper.MakeDateTimeValid(r["BookedDateTime"]) == default)
                                                    continue;
                                                DateTime VisitDateHolder = Conversions.ToDate(r["BookedDateTime"]);
                                                theVisitDate = Conversions.ToDate(r["BookedDateTime"]);
                                                string fuel = "";
                                                string AMPM = Conversions.ToString(r["AMPM"]);
                                                int fuelId = 0;
                                                if (r.Table.Columns.Contains("FuelID") && !Information.IsDBNull(r["FuelID"]))
                                                    fuelId = Helper.MakeIntegerValid(r["FuelID"]);
                                                var jobnumbers = new Jobs.Job();
                                                if (JustLetters == false)
                                                {
                                                    jobnumbers = App.DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId);
                                                    r["JobNumber"] = jobnumbers.JobNumber;
                                                    r["JobID"] = jobnumbers.JobID;
                                                }
                                                else
                                                {
                                                    jobnumbers.SetJobID = r["JobID"];
                                                    jobnumbers.SetJobNumber = r["JobNumber"];
                                                }

                                                if (!r["SiteFuel"].ToString().StartsWith("&"))
                                                {
                                                    success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, DateAndTime.Now, document, jobnumbers.JobID, JustLetters);
                                                    if (success == true)
                                                    {
                                                        // RECORD JOB/LETTER CREATION
                                                        if (JustLetters == false)
                                                        {
                                                            App.DB.LetterManager.LetterGeneratedMK2(Conversions.ToInteger(r["SiteID"]), Conversions.ToString(r["Type"]), Conversions.ToDate(r["LastServiceDate"]), jobnumbers.JobID, folderName, fuelId);
                                                        }

                                                        // RECORD SOLID FUELS
                                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["SolidFuel"], true, false)))
                                                        {
                                                            oWriteSolidFuels.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]));
                                                        }
                                                        // RECORD WARNINGS OR ADVICE
                                                        if (r["Notes"].ToString().Contains("T1WARN") | r["Notes"].ToString().Contains("T1ADVI") | r["Notes"].ToString().Contains("T2WARN") | r["Notes"].ToString().Contains("T2ADVI"))
                                                        {
                                                            oWriteWA.WriteLine(" ");
                                                            oWriteWA.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]) + ", " + " NOTES : ") + r["Notes"]);
                                                        }
                                                        // RECORD VOID PROPERTIES
                                                        if (Helper.MakeBooleanValid(r["PropertyVoid"]) == true)
                                                        {
                                                            oWriteVoids.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]));
                                                        }
                                                        // RECORD NON GAS SITE FUELS
                                                        if (!(r["SiteFuel"] == DBNull.Value))
                                                        {
                                                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["SiteFuel"], "Gas", false)))
                                                            {
                                                                oWriteSiteFuel.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]) + ", ") + r["SiteFuel"]);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            if (document.Count > 0)
                                            {
                                                File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document));
                                            }
                                        }

                                        if (dt.Select("Type = 'Letter 3' AND SendLetterTick = 1").Length > 0)
                                        {
                                            filePath = folderName + "ServiceLetters3_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".docx";
                                            var document = new List<byte[]>();
                                            var dr = (from row in dt.AsEnumerable()
                                                      where (row.Field<string>("Type") ?? "") == "Letter 3" & row.Field<bool>("SendLetterTick") == true
                                                      select row).ToArray();
                                            foreach (DataRow r in dr)
                                            {
                                                if (Helper.MakeDateTimeValid(r["BookedDateTime"]) == default)
                                                    continue;
                                                DateTime VisitDateHolder = Conversions.ToDate(r["BookedDateTime"]);
                                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["CustomerID"], Enums.Customer.NCC, false)))
                                                {
                                                    theVisitDate = Conversions.ToDate(r["BookedDateTime"]);
                                                }
                                                else
                                                {
                                                    theVisitDate = Conversions.ToDate(r["BookedDateTime"]);
                                                }

                                                string fuel = "";
                                                int fuelId = 0;
                                                if (r.Table.Columns.Contains("FuelID") && !Information.IsDBNull(r["FuelID"]))
                                                    fuelId = Helper.MakeIntegerValid(r["FuelID"]);
                                                string AMPM = Conversions.ToString(r["AMPM"]);
                                                var jobnumbers = new Jobs.Job();
                                                if (JustLetters == false)
                                                {
                                                    jobnumbers = App.DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId);
                                                    r["JobNumber"] = jobnumbers.JobNumber;
                                                    r["JobID"] = jobnumbers.JobID;
                                                }
                                                else
                                                {
                                                    jobnumbers.SetJobID = r["JobID"];
                                                    jobnumbers.SetJobNumber = r["JobNumber"];
                                                }

                                                if (!r["SiteFuel"].ToString().StartsWith("&"))
                                                {
                                                    success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, DateAndTime.Now, document, jobnumbers.JobID, JustLetters);
                                                    if (success == true)
                                                    {
                                                        // RECORD JOB/LETTER CREATION
                                                        if (JustLetters == false)
                                                        {
                                                            App.DB.LetterManager.LetterGeneratedMK2(Conversions.ToInteger(r["SiteID"]), Conversions.ToString(r["Type"]), Conversions.ToDate(r["LastServiceDate"]), jobnumbers.JobID, folderName, fuelId);
                                                        }

                                                        // RECORD SOLID FUELS
                                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["SolidFuel"], true, false)))
                                                        {
                                                            oWriteSolidFuels.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]));
                                                        }
                                                        // RECORD WARNINGS OR ADVICE
                                                        if (r["Notes"].ToString().Contains("T1WARN") | r["Notes"].ToString().Contains("T1ADVI") | r["Notes"].ToString().Contains("T2WARN") | r["Notes"].ToString().Contains("T2ADVI"))
                                                        {
                                                            oWriteWA.WriteLine(" ");
                                                            oWriteWA.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]) + " NOTES : ") + r["Notes"]);
                                                        }
                                                        // RECORD VOID PROPERTIES
                                                        if (Helper.MakeBooleanValid(r["PropertyVoid"]) == true)
                                                        {
                                                            oWriteVoids.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]));
                                                        }
                                                        // RECORD NON GAS SITE FUELS
                                                        if (!(r["SiteFuel"] == DBNull.Value))
                                                        {
                                                            if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(r["SiteFuel"], "Gas", false)))
                                                            {
                                                                oWriteSiteFuel.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(r["Name"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", ") + r["Address3"] + ", " + Helper.FormatPostcode(r["Postcode"]) + ", ") + r["SiteFuel"]);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            if (document.Count > 0)
                                            {
                                                File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document));
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    oWriteSolidFuels.Close();
                                    oWriteWA.Close();
                                    oWriteVoids.Close();
                                    oWriteSiteFuel.Close();
                                }
                                catch (Exception ex)
                                {
                                    App.ShowMessage("Letter Generation Failed : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                // GENERATE EXCEL REPORT
                                // GET ALL TOMORROWS LETTER 3 VISITS
                                // IS TOMORROW SAT OR SUN - THEN GET MONDAY
                                DateTime tomorrow = Conversions.ToDate(Strings.Format(DateAndTime.Now.AddDays(1), "dd-MMM-yyyy") + " 00:00:00");
                                if (DateAndTime.Now.DayOfWeek == DayOfWeek.Friday)
                                {
                                    tomorrow = Conversions.ToDate(Strings.Format(DateAndTime.Now.AddDays(3), "dd-MMM-yyyy") + " 00:00:00");
                                }
                                else if (DateAndTime.Now.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    tomorrow = Conversions.ToDate(Strings.Format(DateAndTime.Now.AddDays(2), "dd-MMM-yyyy") + " 00:00:00");
                                }

                                var dt3rdVisitReport = App.DB.LetterManager.Letter3_TomorrowsVisit(tomorrow);
                                ExportHelper.Export(dt3rdVisitReport, "3rd Visits", Enums.ExportType.XLS, false);
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);
                                if (success)
                                {
                                    Process.Start(folderName);
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.ServiceLetterReport:
                        {
                            string folderName = @"C:\";
                            try
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                DataTable dt = (DataTable)((ArrayList)DetailsToPrint)[0];
                                folderName = App.TheSystem.Configuration.DocumentsLocation + @"ServiceLetters\ServiceLetters" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + @"\";
                                if (Directory.Exists(folderName) == false)
                                {
                                    Directory.CreateDirectory(folderName);
                                }

                                string SiteName = Conversions.ToString(dt.Rows[0]["Name"]);
                                filePath = folderName + SiteName + "ServiceLetters_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                DataRow[] dr;
                                DataRow r;

                                // Print Letter 1
                                dr = dt.Select("LetterType ='Letter 1'");
                                if (dr.Length > 0)
                                {
                                    r = dr[0];
                                    switch (CustomerID)
                                    {
                                        case 2846: // NCC
                                            {
                                                object argTemplate11 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate11);
                                                break;
                                            }

                                        case 5155: // Waveney
                                            {
                                                object argTemplate12 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\WDCAnnualSafetyInspection.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate12);
                                                break;
                                            }

                                        case 4703: // Suffolk Housing
                                            {
                                                object argTemplate13 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\SuffolkAnnualSafetyInspection.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate13);
                                                break;
                                            }

                                        case 5545: // Cambridge Housing Society
                                            {
                                                object argTemplate14 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\CHS_AnnualSafetyInspection.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate14);
                                                break;
                                            }

                                        case 5385: // Kier
                                            {
                                                object argTemplate15 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\KierAnnualSafetyInspection.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate15);
                                                break;
                                            }

                                        case 5853: // Hastoe
                                            {
                                                object argTemplate16 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate16);
                                                break;
                                            }

                                        case 6341: // Hastoe 2
                                            {
                                                object argTemplate17 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspectionGBS.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate17);
                                                break;
                                            }

                                        case 5872: // Victory
                                            {
                                                object argTemplate18 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\VHTAnnualSafetyInspection.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate18);
                                                break;
                                            }

                                        case 6526: // TEN
                                            {
                                                object argTemplate19 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\TENAnnualSafetyInspection1.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate19);
                                                break;
                                            }

                                        case 6561: // TEN
                                            {
                                                object argTemplate20 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\SAFAnnualSafetyInspection1.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate20);
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    if (GenerateServiceLetter(r, Conversions.ToString(r["AMPM"]), Conversions.ToDate(r["DueDate"]), Conversions.ToString(r["JobNumber"]), Conversions.ToDate(r["DateCreated"])))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        object argFileName4 = folderName + "ServiceLetter1_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                        WordDoc.SaveAs(ref argFileName4);
                                    }
                                }

                                // Print Letter 2
                                dr = dt.Select("LetterType ='Letter 2'");
                                if (dr.Length > 0)
                                {
                                    r = dr[0];
                                    switch (CustomerID)
                                    {
                                        case 2846: // NCC
                                            {
                                                object argTemplate21 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate21);
                                                break;
                                            }

                                        case 5155: // Waveney
                                            {
                                                object argTemplate22 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\WDCAnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate22);
                                                break;
                                            }

                                        case 4703: // Suffolk Housing
                                            {
                                                object argTemplate23 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\SuffolkAnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate23);
                                                break;
                                            }

                                        case 5545: // Cambridge Housing Society
                                            {
                                                object argTemplate24 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\CHS_AnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate24);
                                                break;
                                            }

                                        case 5385: // Kier
                                            {
                                                object argTemplate25 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\KierAnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate25);
                                                break;
                                            }

                                        case 5853: // Hastoe
                                            {
                                                object argTemplate26 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate26);
                                                break;
                                            }

                                        case 6341: // Hastoe
                                            {
                                                object argTemplate27 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection2GBS.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate27);
                                                break;
                                            }

                                        case 5872: // Victory
                                            {
                                                object argTemplate28 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\VHTAnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate28);
                                                break;
                                            }

                                        case 6526: // TEN
                                            {
                                                object argTemplate29 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\TENAnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate29);
                                                break;
                                            }

                                        case 6561: // SAF
                                            {
                                                object argTemplate30 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\SAFAnnualSafetyInspection2.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate30);
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    if (GenerateServiceLetter(r, Conversions.ToString(r["AMPM"]), Conversions.ToDate(r["DueDate"]), Conversions.ToString(r["JobNumber"]), Conversions.ToDate(r["DateCreated"])))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        object argFileName5 = folderName + "ServiceLetter2_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                        WordDoc.SaveAs(ref argFileName5);
                                    }

                                    switch (CustomerID)
                                    {
                                        case 2846: // NCC
                                            {
                                                object argTemplate31 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection2HandLetter.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate31);
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    if (GenerateServiceLetter(r, Conversions.ToString(r["AMPM"]), Conversions.ToDate(r["DueDate"]), Conversions.ToString(r["JobNumber"]), Conversions.ToDate(r["DateCreated"])))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        object argFileName6 = folderName + "ServiceLetter2Hand_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                        WordDoc.SaveAs(ref argFileName6);
                                    }
                                }

                                // Print Letter 3
                                dr = dt.Select("LetterType ='Letter 3'");
                                if (dr.Length > 0)
                                {
                                    r = dr[0];
                                    switch (CustomerID)
                                    {
                                        case 2846: // NCC
                                            {
                                                object argTemplate32 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate32);
                                                break;
                                            }

                                        case 5155: // Waveney
                                            {
                                                object argTemplate33 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\WDCAnnualSafetyInspection3.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate33);
                                                break;
                                            }

                                        case 5385: // Kier
                                            {
                                                object argTemplate34 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\KierAnnualSafetyInspection3.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate34);
                                                break;
                                            }

                                        case 5853: // Hastoe
                                            {
                                                object argTemplate35 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection3.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate35);
                                                break;
                                            }

                                        case 6341: // Hastoe
                                            {
                                                object argTemplate36 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection3.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate36);
                                                break;
                                            }

                                        case 5872: // Victory
                                            {
                                                object argTemplate37 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\VHTAnnualSafetyInspection3.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate37);
                                                break;
                                            }

                                        case 6526: // TEN
                                            {
                                                object argTemplate38 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\TENAnnualSafetyInspection3.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate38);
                                                break;
                                            }

                                        case 6561: // SAF
                                            {
                                                object argTemplate39 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\SAFAnnualSafetyInspection3.dot";
                                                WordDoc = MsWordApp.Documents.Add(ref argTemplate39);
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    if (GenerateServiceLetter(r, Conversions.ToString(r["AMPM"]), Conversions.ToDate(r["DueDate"]), Conversions.ToString(r["JobNumber"]), Conversions.ToDate(r["DateCreated"])))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        object argFileName7 = folderName + "ServiceLetter3_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                        WordDoc.SaveAs(ref argFileName7);
                                    }

                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["CommercialDistrict"], true, false)))
                                    {
                                        switch (CustomerID)
                                        {
                                            case 2846: // NCC
                                                {
                                                    object argTemplate40 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3HandLetterDistrict.dot";
                                                    WordDoc = MsWordApp.Documents.Add(ref argTemplate40);
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                    {
                                        switch (CustomerID)
                                        {
                                            case 2846: // NCC
                                                {
                                                    object argTemplate41 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3HandLetter.dot";
                                                    WordDoc = MsWordApp.Documents.Add(ref argTemplate41);
                                                    break;
                                                }

                                            default:
                                                {
                                                    break;
                                                }
                                        }
                                    }

                                    if (GenerateServiceLetter(r, Conversions.ToString(r["AMPM"]), Conversions.ToDate(r["DueDate"]), Conversions.ToString(r["JobNumber"]), Conversions.ToDate(r["DateCreated"])))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        object argFileName8 = folderName + "ServiceLetter3Hand_" + Strings.Format(DateAndTime.Now, "ddMMyyHHmm") + ".doc";
                                        WordDoc.SaveAs(ref argFileName8);
                                    }
                                }

                                StreamWriter oWriteSolidFuels;
                                oWriteSolidFuels = File.CreateText(folderName + "Summary.txt");
                                oWriteSolidFuels.WriteLine("Letter Type" + Constants.vbTab + Constants.vbTab + "Letter Created" + Constants.vbTab + Constants.vbTab + Constants.vbTab + "Due Date" + Constants.vbTab + Constants.vbTab + "AM/PM" + Constants.vbTab + Constants.vbTab + "Job Number");
                                foreach (DataRow drS in dt.Rows)
                                    oWriteSolidFuels.WriteLine(Conversions.ToString(Conversions.ToString(Conversions.ToString(Conversions.ToString(drS["LetterType"] + Constants.vbTab + Constants.vbTab) + drS["DateCreated"] + Constants.vbTab + Constants.vbTab) + drS["DueDate"] + Constants.vbTab + Constants.vbTab) + drS["AMPM"] + Constants.vbTab + Constants.vbTab) + drS["JobNumber"]);
                                oWriteSolidFuels.Close();
                                success = true;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                DestroyWord(true);
                                if (success)
                                {
                                    Process.Start(folderName);
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.GSRDue:
                        {
                            try
                            {
                                var dtPrinted = new DataTable();
                                dtPrinted.Columns.Add("AssetID");
                                dtPrinted.Columns.Add("DateDue");
                                FRMLastGSRReport fLastGSRReport = (FRMLastGSRReport)((ArrayList)DetailsToPrint)[1];
                                fLastGSRReport.MoveProgressOn();
                                DataView dv = (DataView)((ArrayList)DetailsToPrint)[0];
                                filePath = App.TheSystem.Configuration.DocumentsLocation + "GSRDueLettersCreated" + Strings.Format(DateAndTime.Now, "ddMMyyHHmmff") + ".docx";
                                File.Copy(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\BlankNp.docx", filePath);
                                var batch = WordprocessingDocument.Open(filePath, true);
                                using (batch)
                                {
                                    var domesticSitesAdded = new DataTable();
                                    domesticSitesAdded.Columns.Add("SiteID", Type.GetType("System.Int32"));
                                    domesticSitesAdded.Columns.Add("DueDate", Type.GetType("System.DateTime"));
                                    var nonDomesticCustomersAdded = new DataTable();
                                    nonDomesticCustomersAdded.Columns.Add("CustomerID");
                                    foreach (DataRowView dr in dv)
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["CustomerID"], Enums.Customer.Domestic, false)))
                                        {
                                            var domSel = domesticSitesAdded.Select("DueDate='" + Helper.MakeDateTimeValid(dr["DueDate"]) + "' AND SiteID =" + Helper.MakeIntegerValid(dr["siteID"]));
                                            if (domSel.Length == 0)
                                            {
                                                DataRow[] selSites;
                                                selSites = dv.Table.Select(Conversions.ToString(Conversions.ToString("SiteID =" + dr["siteID"] + " AND DueDate='") + dr["DueDate"] + "'"));
                                                string tFilePath = Conversions.ToString(App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblSite) + @"\" + dr["SiteID"] + @"\ServiceReminders");
                                                Directory.CreateDirectory(tFilePath);
                                                tFilePath += @"\ServiceReminder_" + Helper.MakeDateTimeValid(dr["DueDate"]).ToLongDateString() + ".docx";
                                                success = GenerateDomesticGSRDue(selSites, dtPrinted, tFilePath, batch);
                                                if (success == true)
                                                {
                                                    if (Helper.MakeBooleanValid(dr["Email"]) & Helper.IsEmailValid(Helper.MakeStringValid(dr["EmailAddress"])))
                                                    {
                                                        var email = new Emails();
                                                        email.To = Conversions.ToString(dr["EmailAddress"]);
                                                        email.BCC = EmailAddress.Coverplan;
                                                        email.From = EmailAddress.Enquiries;
                                                        email.Subject = "Appliance Service Reminder";
                                                        email.Body = "Dear Tenant, <br/><br/>" + Constants.vbCrLf + Constants.vbCrLf;
                                                        email.Body += "Please find your service reminder attached.<br/><br/>" + Constants.vbCrLf + Constants.vbCrLf;
                                                        email.Body += "Kind regards," + "<br/><br/>";
                                                        email.Body += App.TheSystem.Configuration.CompanyName;
                                                        email.Attachments.Add(tFilePath);
                                                        email.SendMe = true;
                                                        email.Send();
                                                    }
                                                }

                                                DataRow domr = null;
                                                domr = domesticSitesAdded.NewRow();
                                                domr["SiteID"] = dr["siteID"];
                                                domr["DueDate"] = Helper.MakeDateTimeValid(dr["DueDate"]);
                                                domesticSitesAdded.Rows.Add(domr);
                                                domesticSitesAdded.AcceptChanges();
                                            }

                                            fLastGSRReport.MoveProgressOn();
                                        }
                                    }

                                    foreach (DataRowView dr in dv)
                                    {
                                        if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(dr["CustomerID"], Enums.Customer.Domestic, false)))
                                        {
                                            if (nonDomesticCustomersAdded.Select(Conversions.ToString("CustomerID=" + dr["CustomerID"])).Length == 0)
                                            {
                                                DataRow[] selCust;
                                                selCust = dv.Table.Select(Conversions.ToString("CustomerID=" + dr["CustomerID"]));
                                                string tFilePath = Conversions.ToString(App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblSite) + @"\" + dr["SiteID"] + @"\ServiceReminders");
                                                Directory.CreateDirectory(tFilePath);
                                                tFilePath += @"\ServiceReminder.docx";
                                                success = GenerateLLGSRDue(selCust, dtPrinted, tFilePath, batch);
                                                if (success == true)
                                                {
                                                    if (Helper.MakeBooleanValid(dr["Email"]) & Helper.IsEmailValid(Helper.MakeStringValid(dr["EmailAddress"])))
                                                    {
                                                        var email = new Emails();
                                                        email.To = Conversions.ToString(dr["EmailAddress"]);
                                                        email.BCC = EmailAddress.Coverplan;
                                                        email.From = EmailAddress.Enquiries;
                                                        email.Subject = "Appliance Service Reminder";
                                                        email.Body = "Dear Tenant, <br/><br/>" + Constants.vbCrLf + Constants.vbCrLf;
                                                        email.Body += "Please find your service reminder attached.<br/><br/>" + Constants.vbCrLf + Constants.vbCrLf;
                                                        email.Body += "Kind regards," + "<br/><br/>";
                                                        email.Body += App.TheSystem.Configuration.CompanyName;
                                                        email.Attachments.Add(tFilePath);
                                                        email.SendMe = true;
                                                        email.Send();
                                                    }
                                                }

                                                DataRow r;
                                                r = nonDomesticCustomersAdded.NewRow();
                                                r["CustomerID"] = dr["CustomerID"];
                                                nonDomesticCustomersAdded.Rows.Add(r);
                                            }

                                            fLastGSRReport.MoveProgressOn();
                                        }
                                    }

                                    foreach (DataRow pr in dtPrinted.Rows)
                                        App.DB.EngineerVisitAssetWorkSheet.PrintedGSRLettersInsert(Conversions.ToInteger(pr["AssetID"]), Conversions.ToDate(pr["DateDue"]));
                                }
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);
                                if (success)
                                {
                                    Process.Start(filePath);
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.ContractExpiry:
                        {
                            try
                            {
                                FRMContractManager fCMngr = (FRMContractManager)((ArrayList)DetailsToPrint)[1];
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                fCMngr.MoveProgressOn();
                                DataTable dt = (DataTable)((ArrayList)DetailsToPrint)[0];
                                if (Directory.Exists(App.TheSystem.Configuration.DocumentsLocation + "ContractExpiryLetters") == false)
                                {
                                    Directory.CreateDirectory(App.TheSystem.Configuration.DocumentsLocation + "ContractExpiryLetters");
                                }

                                fCMngr.MoveProgressOn();
                                filePath = App.TheSystem.Configuration.DocumentsLocation + @"ContractExpiryLetters\" + DocumentName + Strings.Format(DateAndTime.Now, "dd-MM-yyyy HHmm") + ".doc"; // "_" & dr("ContractReference") & ".doc"
                                object argTemplate42 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\Contracts" + @"\AnnualContractExpiry.docx";
                                WordDoc = MsWordApp.Documents.Add(ref argTemplate42);
                                MsWordApp.Selection.WholeStory();
                                MsWordApp.Selection.Copy();
                                int i = 1;
                                int tblIndex = 2;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    success = GenerateContractExpiry(dr, tblIndex);
                                    i += 1;
                                    tblIndex += 2;
                                    if (i <= dt.Rows.Count)
                                    {
                                        object argUnit5 = WD.WdUnits.wdStory;
                                        MsWordApp.Selection.EndKey(Unit: ref argUnit5);
                                        object argType = WD.WdBreakType.wdPageBreak;
                                        MsWordApp.Selection.InsertBreak(Type: ref argType);
                                        MsWordApp.Selection.Paste();
                                    }

                                    fCMngr.MoveProgressOn();
                                }

                                object argFileName9 = filePath;
                                WordDoc.SaveAs(ref argFileName9);
                                Marshal.ReleaseComObject(WordDoc);
                                WordDoc = null;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);
                                if (success)
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    Process.Start(filePath);
                                    Cursor.Current = Cursors.Default;
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.Invoice:
                        {
                            var details = new ArrayList();
                            details = (ArrayList)DetailsToPrint;
                            var arLst = new ArrayList();
                            arLst = (ArrayList)details[0];
                            if (details.Count > 1)
                            {
                                details1 = Conversions.ToString(details[1]);
                                details2 = Conversions.ToString(details[2]);
                            }

                            var invoices = new ArrayList();
                            foreach (ArrayList InvoiceID in arLst)
                            {
                                try
                                {
                                    var oInvoice = App.DB.Invoiced.Invoiced_Get(Conversions.ToInteger(InvoiceID[0]));
                                    if (oInvoice.PaidByID > 0)
                                        details2 = App.DB.Picklists.Get_One_As_Object(oInvoice.PaidByID)?.Name;
                                    if (!string.IsNullOrEmpty(oInvoice.AdhocInvoiceType))
                                        details1 = oInvoice.AdhocInvoiceType;
                                    filePath = App.TheSystem.Configuration.DocumentsLocation + DocumentName + "_" + oInvoice.InvoiceNumber + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                                    File.Copy(Application.StartupPath + @"\Templates\Blank.docx", filePath);
                                    Cursor.Current = Cursors.WaitCursor;
                                    var batch = WordprocessingDocument.Open(filePath, true);
                                    using (batch)
                                    {
                                        var dtInvoicedLines = App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(Conversions.ToInteger(InvoiceID[0])).Table;
                                        var ContractsDT = App.DB.ContractOriginal.Get_NotProcessed(Conversions.ToInteger(dtInvoicedLines.Rows[0]["ContractID"])).Table;
                                        ContractsDT.Columns.Add("InvoiceNumber");
                                        if (ContractsDT.Rows.Count > 0 && ContractsDT.Rows[0]["InitialPaymentType"].ToString().Length > 1)
                                        {
                                            ContractsDT.Rows[0]["InvoiceNumber"] = oInvoice.InvoiceNumber;
                                            if (!Information.IsDBNull(ContractsDT.Rows[0]["InvoiceNumber"]))
                                            {
                                                if (Information.IsDBNull(ContractsDT.Rows[0]["InitialPaymentType"]) || Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(ContractsDT.Rows[0]["InitialPaymentType"], "Invoice", false)) || (details1 ?? "") == "DDRECEIPT")
                                                {
                                                    success = GenerateReceipt(ContractsDT.Rows[0], batch, Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ContractsDT.Rows[0]["RegionID"], Enums.Region.GaswayCommercial, false)), false);
                                                }
                                                else
                                                {
                                                    success = GenerateContractInvoice(ContractsDT.Rows[0], batch, Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ContractsDT.Rows[0]["RegionID"], Enums.Region.GaswayCommercial, false)), false);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            success = GenerateSalesInvoice(oInvoice, batch, Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(InvoiceID[1], Enums.Region.GaswayCommercial, false)));
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    success = false;
                                    App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    Finalise(filePath, success, true, false);
                                    invoices.Add(filePath);
                                    Cursor.Current = Cursors.Default;
                                }
                            }

                            Finalise("", false, false, true);
                            foreach (string i in invoices)
                                Process.Start(i);
                            break;
                        }

                    case Enums.SystemDocumentType.SupplierPurchaseOrder:
                        {
                            ArrayList details = (ArrayList)DetailsToPrint;
                            Sites.Site oSite = null;
                            Warehouses.Warehouse oWarehouse = null;
                            Users.User oUser = (Users.User)details[4];
                            DataView oAdditionalCharges = (DataView)details[7];
                            bool isPdf = (DialogResult)Conversions.ToInteger(details[8]) == DialogResult.Yes ? true : false;
                            DataSet ds = (DataSet)details[0];
                            if (details[3] is object)
                            {
                                oWarehouse = (Warehouses.Warehouse)details[3];
                            }

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(details[1], "Site", false)))
                            {
                                oSite = (Sites.Site)details[2];
                                oWarehouse = null;
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(details[1], "Warehouse", false)))
                            {
                                oSite = null;
                                oWarehouse = (Warehouses.Warehouse)details[2];
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(details[1], "Van", false)))
                            {
                                oSite = null;
                                if (details[2] is null)
                                {
                                    oWarehouse = null;
                                }
                                else
                                {
                                    oWarehouse = (Warehouses.Warehouse)details[2];
                                }
                            }

                            foreach (DataTable dt in ds.Tables)
                            {
                                try
                                {
                                    var oSupplier = App.DB.Supplier.Supplier_Get(Conversions.ToInteger(dt.Rows[0]["SupplierID"]));
                                    filePath = App.TheSystem.Configuration.DocumentsLocation + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + Helper.MakeFileNameValid(oSupplier.Name) + ".docx";
                                    Cursor.Current = Cursors.WaitCursor;
                                    success = GeneratePurchaseOrder(oSite, oWarehouse, dt, oSupplier, oUser, Helper.MakeStringValid(details[5]), Helper.MakeDateTimeValid(details[6]), oAdditionalCharges, filePath, isPdf);
                                }
                                catch (Exception ex)
                                {
                                    success = false;
                                    App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    if (success)
                                    {
                                        if (isPdf)
                                            filePath = Path.ChangeExtension(filePath, ".pdf");
                                        Cursor.Current = Cursors.WaitCursor;
                                        Process.Start(filePath);
                                        Cursor.Current = Cursors.Default;
                                    }

                                    Cursor.Current = Cursors.Default;
                                }
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.ContractOption1:
                        {
                            try
                            {
                                var folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                                {
                                    return;
                                }

                                Cursor.Current = Cursors.WaitCursor;
                                filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                                File.Copy(Application.StartupPath + @"\Templates\Blank.docx", filePath);
                                var batch = WordprocessingDocument.Open(filePath, true);
                                using (batch)
                                    foreach (int contractId in (List<int>)DetailsToPrint)
                                    {
                                        var dtContracts = App.DB.ContractOriginal.ProcessContract(contractId);
                                        if (dtContracts is null)
                                            continue;
                                        var dr = dtContracts.Rows[0];
                                        success = GenerateContractLetter(dr, batch);
                                    }
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (success)
                                {
                                    Process.Start(filePath);
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.PartCredit:
                        {
                            try
                            {
                                var details = new ArrayList();
                                details = (ArrayList)DetailsToPrint;
                                var folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".doc";
                                }

                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                object argTemplate43 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\CREDIT.dot";
                                WordDoc = MsWordApp.Documents.Add(ref argTemplate43);
                                MsWordApp.Selection.WholeStory();
                                MsWordApp.Selection.Copy();
                                int i = 1;
                                int tblIndex = 0;
                                var dt = new DataTable();
                                var detailsdt = new DataTable();
                                for (int h = 0, loopTo1 = details.Count - 1; h <= loopTo1; h++)
                                {
                                    // Dim ds As New DataSet
                                    if (h == 0)
                                    {
                                        dt = (DataTable)details[0];
                                    }
                                    else
                                    {
                                        detailsdt = (DataTable)details[h];
                                        dt.ImportRow(detailsdt.Rows[0]);
                                    }
                                }

                                DetailsToPrint = dt; // ds.Tables(0)
                                success = Credit();
                                object argFileName10 = filePath;
                                WordDoc.SaveAs(ref argFileName10);
                                Marshal.ReleaseComObject(WordDoc);
                                WordDoc = null;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);
                                if (success)
                                {
                                    // Process.Start(TheSystem.Configuration.DocumentsLocation & "ContractExpiryLetters")
                                    Cursor.Current = Cursors.WaitCursor;
                                    Process.Start(filePath);
                                    Cursor.Current = Cursors.Default;
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.ProForma:
                        {
                            var details = new ArrayList();
                            details = (ArrayList)DetailsToPrint;
                            var job = new Jobs.Job();
                            ContractsOriginal.ContractOriginal Contract;
                            var cos = new ContractOriginalSites.ContractOriginalSite();
                            var invoices = new ArrayList();
                            MsWordApp = new WD.Application();
                            MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                            MsWordApp.Visible = false;
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(details[0], "JOB", false)))
                            {
                                job = (Jobs.Job)details[1];
                                details1 = Conversions.ToString(details[2]);
                                details2 = Conversions.ToString(details[3]);
                                filePath = App.TheSystem.Configuration.DocumentsLocation + DocumentName + "_" + job.JobNumber + ".doc";
                                Cursor.Current = Cursors.WaitCursor;
                                var Customer = App.DB.Customer.Customer_Get_ForSiteID(job.PropertyID); // get the customer to check region
                                if (Customer.RegionID == (int)Enums.Region.GaswayCommercial)
                                {
                                    object argTemplate44 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\InvoiceGC.dot";
                                    WordDoc = MsWordApp.Documents.Add(ref argTemplate44); // use Standard GC Invoice Template
                                }
                                else
                                {
                                    object argTemplate45 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\Invoice.dot";
                                    WordDoc = MsWordApp.Documents.Add(ref argTemplate45);
                                } // use Standard Invoice Template
                            }
                            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(details[0], "CONTRACT", false)))
                            {
                                cos = (ContractOriginalSites.ContractOriginalSite)details[1];
                                Contract = App.DB.ContractOriginal.Get(cos.ContractID);
                                details1 = Conversions.ToString(details[2]);
                                details2 = Conversions.ToString(details[3]);
                                filePath = App.TheSystem.Configuration.DocumentsLocation + DocumentName + "_" + Contract.ContractReference + ".doc";
                                object argTemplate46 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\Invoice.dot";
                                WordDoc = MsWordApp.Documents.Add(ref argTemplate46); // use Standard Invoice Template
                            }

                            try
                            {
                                success = GenerateProforma(job, cos);
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success, true, false);
                                invoices.Add(filePath);
                                Cursor.Current = Cursors.Default;
                            }

                            Finalise("", false, false, true);
                            foreach (string i in invoices)
                                Process.Start(i);
                            break;
                        }

                    case Enums.SystemDocumentType.ProFormaFromVisit:
                        {
                            var details = new ArrayList();
                            details = (ArrayList)DetailsToPrint;
                            var job = new Jobs.Job();
                            var invoices = new ArrayList();
                            MsWordApp = new WD.Application();
                            MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                            MsWordApp.Visible = false;
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(details[0], "JOB", false)))
                            {
                                job = (Jobs.Job)details[1];      // Job Entity
                                details1 = Conversions.ToString(details[2]);   // Money
                                details2 = Conversions.ToString(details[3]);   // VAT
                                filePath = App.TheSystem.Configuration.DocumentsLocation + DocumentName + "_" + job.JobNumber + ".doc"; // name doc
                                var Customer = App.DB.Customer.Customer_Get_ForSiteID(job.PropertyID); // get the customer to check region
                                if (Customer.RegionID == (int)Enums.Region.GaswayCommercial)
                                {
                                    object argTemplate47 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\InvoiceGC.dot";
                                    WordDoc = MsWordApp.Documents.Add(ref argTemplate47); // use Standard GC Invoice Template
                                }
                                else
                                {
                                    object argTemplate48 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\Invoice.dot";
                                    WordDoc = MsWordApp.Documents.Add(ref argTemplate48);
                                } // use Standard Invoice Template
                            }

                            try
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                success = GenerateProformaFromVisit(job); // Use FromVisit Function
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success, true, false);
                                invoices.Add(filePath);
                                Cursor.Current = Cursors.Default;
                            }

                            Finalise("", false, false, true);
                            foreach (string i in invoices)
                                Process.Start(i); // open Word
                            break;
                        }

                    case Enums.SystemDocumentType.AlphaPartCredit:
                        {
                            try
                            {
                                var details = new ArrayList();
                                details = (ArrayList)DetailsToPrint;
                                var folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".doc";
                                }

                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                object argTemplate49 = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\AlphaReturnsForm.dot";
                                WordDoc = MsWordApp.Documents.Add(ref argTemplate49);
                                MsWordApp.Selection.WholeStory();
                                MsWordApp.Selection.Copy();
                                int i = 1;
                                int tblIndex = 0;
                                var dt = new DataTable();
                                var detailsdt = new DataTable();
                                for (int h = 0, loopTo2 = details.Count - 1; h <= loopTo2; h++)
                                {
                                    // Dim ds As New DataSet
                                    if (h == 0)
                                    {
                                        dt = (DataTable)details[0];
                                    }
                                    else
                                    {
                                        detailsdt = (DataTable)details[h];
                                        dt.ImportRow(detailsdt.Rows[0]);
                                    }
                                }

                                DetailsToPrint = dt; // ds.Tables(0)
                                success = AlphaCredit();
                                object argFileName11 = filePath;
                                WordDoc.SaveAs(ref argFileName11);
                                Marshal.ReleaseComObject(WordDoc);
                                WordDoc = null;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);
                                if (success)
                                {
                                    // Process.Start(TheSystem.Configuration.DocumentsLocation & "ContractExpiryLetters")
                                    Cursor.Current = Cursors.WaitCursor;
                                    Process.Start(filePath);
                                    Cursor.Current = Cursors.Default;
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.JobImportLetters:
                        {
                            try
                            {
                                var folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                                {
                                    return;
                                }

                                filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                                File.Copy(Application.StartupPath + @"\Templates\BlankNp.docx", filePath);
                                DataTable dt = (DataTable)((ArrayList)DetailsToPrint)[0];
                                bool scheduleJobs = Conversions.ToBoolean(((ArrayList)DetailsToPrint)[1]);
                                var batch = WordprocessingDocument.Open(filePath, true);
                                using (batch)
                                {
                                    foreach (DataRow r in dt.Select("Letter1 Is Null AND Tick = 1"))
                                    {
                                        if (Information.IsDBNull(r["AMPM"]) & scheduleJobs)
                                            continue;
                                        var job = new Jobs.Job();
                                        job = App.DB.Job.CreateJobImportAdHocVisit(r, scheduleJobs);
                                        if (!scheduleJobs)
                                            continue;
                                        if (job is null)
                                            throw new Exception();
                                        success = GenerateJobLetter(r, job, true, batch);
                                        if (!success)
                                            throw new Exception();
                                        // mark letter as completed in db
                                        success = App.DB.JobImports.JobImport_Update_Letter1(r, job);
                                    }

                                    foreach (DataRow r in dt.Select("Letter1 Is Not Null AND Letter2 Is Null AND Tick = 1"))
                                    {
                                        if (Information.IsDBNull(r["AMPM"]) & scheduleJobs)
                                            continue;
                                        var job = new Jobs.Job();
                                        job = App.DB.Job.CreateJobImportAdHocVisit(r, scheduleJobs);
                                        if (!scheduleJobs)
                                            continue;
                                        if (job is null)
                                            throw new Exception();
                                        success = GenerateJobLetter(r, job, false, batch);
                                        if (!success)
                                            throw new Exception();
                                        success = App.DB.JobImports.JobImport_Update_Letter2(r, job);
                                    }
                                }

                                string batchFilePath = App.TheSystem.Configuration.DocumentsLocation + @"JobImports\BatchLetters\" + DocumentName + "_GEN_" + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                                File.Copy(filePath, batchFilePath);
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);
                                if (success)
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    Process.Start(filePath);
                                    Cursor.Current = Cursors.Default;
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case Enums.SystemDocumentType.SalesCredit:
                        {
                            try
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                filePath = App.TheSystem.Configuration.DocumentsLocation + @"\Sales Credits\" + DocumentName + "_" + ((DataTable)DetailsToPrint).Rows[0]["InvoiceNumber"].ToString() + ".docx";
                                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                                filePath = FileCheck(filePath);
                                success = GenerateCredit((DataTable)DetailsToPrint, filePath);
                                PrintHelper.RemoveSpacingInDoc(filePath);
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);
                                if (success)
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    Process.Start(filePath);
                                    Cursor.Current = Cursors.Default;
                                }

                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }
                }
            }

            private void Print()
            {
                bool success = false;
                string filePath = "";
                try
                {
                    var switchExpr = PrintType;
                    switch (switchExpr)
                    {
                        case Enums.SystemDocumentType.DomGSR:
                        case Enums.SystemDocumentType.GSR:
                        case Enums.SystemDocumentType.ASHP:
                        case Enums.SystemDocumentType.SaffUnv:
                        case Enums.SystemDocumentType.PropMaint:
                        case Enums.SystemDocumentType.ComCat:
                        case Enums.SystemDocumentType.ComGSR:
                        case Enums.SystemDocumentType.ServiceLetters:
                        case Enums.SystemDocumentType.Analyser:
                        case Enums.SystemDocumentType.SalesCredit:
                        case Enums.SystemDocumentType.SiteLetter:
                        case Enums.SystemDocumentType.ContractOption1:
                        case Enums.SystemDocumentType.SVR:
                            {
                                break;
                            }

                        default:
                            {
                                if (OrderID > 0)
                                {
                                    filePath = App.TheSystem.Configuration.DocumentsLocation + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".doc";
                                }
                                else
                                {
                                    var folderToSaveTo = new FolderBrowserDialog();
                                    folderToSaveTo.ShowDialog();
                                    if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".doc";
                                    }
                                }

                                break;
                            }
                    }

                    Cursor.Current = Cursors.WaitCursor;
                    var switchExpr1 = PrintType;
                    switch (switchExpr1)
                    {
                        case Enums.SystemDocumentType.DomGSR:
                        case Enums.SystemDocumentType.GSR:
                        case Enums.SystemDocumentType.ASHP:
                        case Enums.SystemDocumentType.SaffUnv:
                        case Enums.SystemDocumentType.PropMaint:
                        case Enums.SystemDocumentType.ComCat:
                        case Enums.SystemDocumentType.ComGSR:
                            {
                                int engineerVisitId = (((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit)?.EngineerVisitID ?? (int)((ArrayList)DetailsToPrint)[0];
                                string savePath = string.Empty;
                                var folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    savePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                                }

                                var fullDocument = new List<byte[]>();
                                success = this.PrintGSR(engineerVisitId, fullDocument);
                                if (success)
                                {
                                    if (fullDocument.Count > 0)
                                    {
                                        File.WriteAllBytes(savePath, PrintHelper.CombineDocs(fullDocument));
                                        PrintHelper.RemoveSpacingInDoc(savePath);
                                        if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
                                            savePath = PrintHelper.LockFile(savePath, true);
                                        Process.Start(savePath);
                                    }
                                }

                                if (PrintType == Enums.SystemDocumentType.GSR)
                                {
                                    var engineerVisit = ((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit;
                                    var MinorElectrical = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(engineerVisitId, (int)Enums.AdditionalChecksTypes.MinorWorksSingleCircuitElecCert);
                                    if (MinorElectrical is object)
                                    {
                                        this.ElecCertPDF(engineerVisit, MinorElectrical, "Minor Works Cert");
                                    };

                                    if (engineerVisit != null)
                                    {
                                        var dvEngineerVisitDefects = ((ArrayList)DetailsToPrint)[2] as DataView;
                                        var drWarningNotices = (from x in dvEngineerVisitDefects.Table.AsEnumerable()
                                                                where Helper.MakeBooleanValid(x["WarningNoticeIssued"]) == true
                                                                select x).ToArray();
                                        foreach (DataRow drWarningNotice in drWarningNotices)
                                            this.WarningNoticePDF(engineerVisit, drWarningNotice, "GasWarningNotice");
                                    }
                                }

                                Cursor.Current = Cursors.Default;
                                break;
                            }

                        case Enums.SystemDocumentType.ServiceLetters:
                            {
                                var dr = ((ArrayList)DetailsToPrint)[0] as DataRow;
                                success = this.GenerateServiceLetterMK2(dr, Conversions.ToString(dr["AMPM"]), Conversions.ToDate(dr["StartDateTime"]), Conversions.ToString(dr["JobNUmber"]), DateAndTime.Today, null, Conversions.ToInteger(dr["jobid"]), true);
                                success = false;
                                break;
                            }

                        case Enums.SystemDocumentType.ContractOption1:
                            {
                                var dr = (((ArrayList)DetailsToPrint)[0] as DataTable).Rows[0];
                                success = this.GenerateContractLetter(dr);
                                break;
                            }

                        case Enums.SystemDocumentType.JobSheet:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                object argTemplate = (object)(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\WorkSheet.dot");
                                WordDoc = MsWordApp.Documents.Add(ref argTemplate);
                                var engineerVisit = ((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit;
                                success = this.GenerateJobSheet(engineerVisit);
                                break;
                            }

                        case Enums.SystemDocumentType.QCPrint:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                success = QCPrint();
                                break;
                            }

                        case Enums.SystemDocumentType.Install:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                object argTemplate1 = (object)(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\Install.dot");
                                WordDoc = MsWordApp.Documents.Add(ref argTemplate1);

                                var engineerVisit = ((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit;
                                success = this.Install(engineerVisit);
                                break;
                            }

                        case Enums.SystemDocumentType.ElecMinor:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                ;
                                // new PDF method
                                Cursor.Current = Cursors.WaitCursor;
                                var engineerVisit = ((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit;
                                var MinorElectrical = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(engineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.MinorWorksSingleCircuitElecCert);
                                this.ElecCertPDF(engineerVisit, MinorElectrical, "Minor Works Cert");
                                break;
                            }

                        case Enums.SystemDocumentType.CommissioningChecklist:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                Cursor.Current = Cursors.WaitCursor;
                                var engineerVisit = ((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit;
                                success = this.ComChecklist(engineerVisit);
                                break;
                            }

                        case Enums.SystemDocumentType.HotWorksPermit:
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                var engineerVisit = ((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit;
                                success = this.GenerateHotWorksPermit(engineerVisit);
                                break;
                            }

                        case Enums.SystemDocumentType.SVR:
                            {
                                string savePath = string.Empty;
                                var folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                                {
                                    return;
                                }
                                else
                                {
                                    savePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + DateAndTime.Now.ToString("ddMMMyyyyHHmmss") + ".docx";
                                }

                                Cursor.Current = Cursors.WaitCursor;
                                var engineerVisit = ((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit;
                                success = this.SiteVisitReport(engineerVisit, savePath);
                                filePath = savePath;
                                break;
                            }

                        case Enums.SystemDocumentType.JobContactLetter:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                object argTemplate2 = (object)(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\JobContactLetter.dot");
                                WordDoc = MsWordApp.Documents.Add(ref argTemplate2);
                                var job = ((ArrayList)DetailsToPrint)[0] as Jobs.Job;
                                success = this.JobContactLetter(job);
                                break;
                            }

                        case Enums.SystemDocumentType.SiteLetter:
                            {
                                SiteID = Convert.ToInt32(((ArrayList)DetailsToPrint)[1]);
                                FRMSiteLetterList fSelectTemplate = (FRMSiteLetterList)App.ShowForm(typeof(FRMSiteLetterList), true, null);
                                if (fSelectTemplate.SelectedTemplate.Length > 0)
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    string savePath = App.TheSystem.Configuration.DocumentsLocation + @"SiteLetters\" + SiteID + @"\" + fSelectTemplate.SelectedTemplate;
                                    string fileName = Path.GetFileNameWithoutExtension(savePath);
                                    savePath = savePath.Replace(fileName, fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss"));
                                    string template = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\SiteLetters\" + fSelectTemplate.SelectedTemplate;
                                    success = SiteLetter(template, savePath);
                                    filePath = savePath;
                                }

                                break;
                            }

                        case Enums.SystemDocumentType.PartCredit:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = WD.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                object argTemplate3 = (object)(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\CREDIT.dot");
                                WordDoc = MsWordApp.Documents.Add(ref argTemplate3);
                                success = Credit();
                                break;
                            }

                        case Enums.SystemDocumentType.SalesCredit:
                            {
                                filePath = App.TheSystem.Configuration.DocumentsLocation + @"\Sales Credits\" + DocumentName + "_" + ((DataTable)DetailsToPrint).Rows[0]["CreditReference"].ToString() + ".docx";
                                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                                filePath = FileCheck(filePath);
                                success = GenerateCredit((DataTable)DetailsToPrint, filePath);
                                Process.Start(filePath);
                                break;
                            }

                        case Enums.SystemDocumentType.Analyser:
                            {
                                DataTable dt = (DataTable)DetailsToPrint;
                                success = GenerateAnalyserLetter(dt);
                                break;
                            }

                        case Enums.SystemDocumentType.PaymentReceipt:
                            {
                                int invoiceId = 0;
                                invoiceId = Conversions.ToInteger(DetailsToPrint);
                                try
                                {
                                    var oInvoice = App.DB.Invoiced.Invoiced_Get(invoiceId);
                                    success = GenerateSalesInvoice(oInvoice, null, false);
                                }
                                catch (Exception ex)
                                {
                                    success = false;
                                    App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }

                        case Enums.SystemDocumentType.Warn:
                            {
                                var engineerVisit = ((ArrayList)DetailsToPrint)[0] as EngineerVisits.EngineerVisit;
                                if (engineerVisit != null)
                                {
                                    var dvEngineerVisitDefects = ((ArrayList)DetailsToPrint)[1] as DataView;
                                    var drWarningNotices = (from x in dvEngineerVisitDefects.Table.AsEnumerable()
                                                            where Helper.MakeBooleanValid(x["WarningNoticeIssued"]) == true
                                                            select x).ToArray();
                                    foreach (DataRow drWarningNotice in drWarningNotices)
                                        this.WarningNoticePDF(engineerVisit, drWarningNotice, "GasWarningNotice");
                                }

                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    success = false;
                    App.ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    var switchExpr = PrintType;
                    switch (switchExpr)
                    {
                        case Enums.SystemDocumentType.DomGSR:
                        case Enums.SystemDocumentType.GSR:
                        case Enums.SystemDocumentType.ASHP:
                        case Enums.SystemDocumentType.SaffUnv:
                        case Enums.SystemDocumentType.PropMaint:
                        case Enums.SystemDocumentType.ComCat:
                        case Enums.SystemDocumentType.ComGSR:
                        case Enums.SystemDocumentType.ServiceLetters:
                        case Enums.SystemDocumentType.Analyser:
                        case Enums.SystemDocumentType.ContractOption1:
                        case Enums.SystemDocumentType.CommissioningChecklist:
                        case Enums.SystemDocumentType.SalesCredit:
                        case Enums.SystemDocumentType.HotWorksPermit:
                        case Enums.SystemDocumentType.PaymentReceipt:
                            {
                                break;
                            }

                        default:
                            {
                                if (success)
                                {
                                    filePath = Finalise(filePath, success);
                                    Cursor.Current = Cursors.WaitCursor;
                                    Process.Start(filePath);
                                    Cursor.Current = Cursors.Default;
                                }

                                break;
                            }
                    }

                    Cursor.Current = Cursors.Default;
                }
            }

            private bool PrintGSR(int engineerVisitId, List<byte[]> fullDocument, string jobNumber = "", bool isSvr = false)
            {
                try
                {
                    bool batch = string.IsNullOrEmpty(jobNumber) ? false : true;
                    bool success = false;
                    bool isBlank = false;
                    string goldenRule = string.Empty;
                    bool hasLsrHeaderLetter = false;
                    var oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId);
                    var oSite = App.DB.Sites.Get(oEngineerVisit.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId);
                    EngineerVisitAdditionals.EngineerVisitAdditional ASHP = null;
                    EngineerVisitAdditionals.EngineerVisitAdditional PM = null;
                    EngineerVisitAdditionals.EngineerVisitAdditional SaffUnv = null;
                    EngineerVisitAdditionals.EngineerVisitAdditional ComCatAdd = null;
                    DataView dvAdditionalWorksheet = null;
                    var comLsrList = new List<int>() { (int)Enums.AdditionalChecksTypes.CommercialStrengthTestCP16, (int)Enums.AdditionalChecksTypes.CommercialPurgingTestCP16, (int)Enums.AdditionalChecksTypes.CommercialSiteChecksCP17, (int)Enums.AdditionalChecksTypes.CommercialTightnessTestCP16 };
                    var dvFaults = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(engineerVisitId);
                    string template = "";
                    string saveDir = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblEngineerVisit) + @"\" + oEngineerVisit.EngineerVisitID;
                    Directory.CreateDirectory(saveDir);
                    if (PrintType == Enums.SystemDocumentType.GSR | PrintType == Enums.SystemDocumentType.GSRBatch)
                    {
                        ASHP = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet);
                        PM = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist);
                        SaffUnv = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.SaffronUnventedReport);
                        ComCatAdd = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.CommercialCateringCP42);
                        dvAdditionalWorksheet = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(oEngineerVisit.EngineerVisitID);
                        var comWorkSheets = (from x in dvAdditionalWorksheet.Table.AsEnumerable()
                                             where comLsrList.Contains(Helper.MakeIntegerValid(x["TestType"]))
                                             select x).ToArray();
                        if (comWorkSheets.Length > 0)
                        {
                            dvAdditionalWorksheet = new DataView(comWorkSheets.CopyToDataTable());
                        }
                        else
                        {
                            dvAdditionalWorksheet = null;
                        }
                    }
                    else if (PrintType == Enums.SystemDocumentType.ASHP)
                    {
                        ASHP = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet);
                    }
                    else if (PrintType == Enums.SystemDocumentType.PropMaint)
                    {
                        PM = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist);
                        goto ProptMain;
                    }
                    else if (PrintType == Enums.SystemDocumentType.ComCat)
                    {
                        ComCatAdd = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.CommercialCateringCP42);
                    }
                    else if (PrintType == Enums.SystemDocumentType.COMSR | PrintType == Enums.SystemDocumentType.ComGSR)
                    {
                        dvAdditionalWorksheet = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(oEngineerVisit.EngineerVisitID);
                        var comWorkSheets = (from x in dvAdditionalWorksheet.Table.AsEnumerable()
                                             where comLsrList.Contains(Helper.MakeIntegerValid(x["TestType"]))
                                             select x).ToArray();
                        if (comWorkSheets.Length > 0)
                        {
                            dvAdditionalWorksheet = new DataView(comWorkSheets.CopyToDataTable());
                        }
                        else
                        {
                            dvAdditionalWorksheet = null;
                        }
                    }
                    else if (PrintType == Enums.SystemDocumentType.SaffUnv)
                    {
                        SaffUnv = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.SaffronUnventedReport);
                        goto SaffUnv;
                    }

                    if ((dvAdditionalWorksheet is null || dvAdditionalWorksheet.Count == 0) & ASHP is null | PrintType == Enums.SystemDocumentType.DomGSR)
                    {
                        var gasLsrs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.Gas);
                        var oilLsrs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.Oil);
                        var unventedLsrs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.Unvented);
                        var hpLsrs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.ASHP);
                        hpLsrs.Table.Merge(App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.GSHP).Table);
                        var comCatLsrs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.ComCat);
                        var hiuLsrs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.HIU);
                        var otherLsrs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.Other);
                        otherLsrs.Table.Merge(App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.Solar).Table);
                        var solidFuelLsrs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, (int)Enums.WorksheetFuelTypes.SolidFuel);
                        if (PrintType == Enums.SystemDocumentType.ComCat)
                        {
                            gasLsrs = new DataView();
                            oilLsrs = new DataView();
                            otherLsrs = new DataView();
                            unventedLsrs = new DataView();
                            hpLsrs = new DataView();
                            hiuLsrs = new DataView();
                            solidFuelLsrs = new DataView();
                        }

                        if (gasLsrs.Table.Rows.Count == 0 & oilLsrs.Table.Rows.Count == 0 & solidFuelLsrs.Table.Rows.Count == 0 & otherLsrs.Table.Rows.Count == 0 & hpLsrs.Table.Rows.Count == 0 & hiuLsrs.Table.Rows.Count == 0 & comCatLsrs.Table.Rows.Count == 0 & unventedLsrs.Table.Rows.Count == 0 & dvFaults.Table.Rows.Count == 0 & (dvAdditionalWorksheet is null || dvAdditionalWorksheet.Count == 0) & ASHP is null & PM is null & SaffUnv is null & ComCatAdd is null)
                        {
                            isBlank = true;
                            success = true;
                            goto NextLSR;
                        }

                        bool hasOnlyDefects = gasLsrs.Table.Rows.Count == 0 && oilLsrs.Table.Rows.Count == 0 && otherLsrs.Table.Rows.Count == 0 && hpLsrs.Table.Rows.Count == 0 && hiuLsrs.Table.Rows.Count == 0 && comCatLsrs.Table.Rows.Count == 0 && dvFaults.Table.Rows.Count > 0;
                        if (gasLsrs.Table.Rows.Count > 0)
                        {
                            if (oSite.CustomerID == (int)Enums.Customer.NCC)
                            {
                                template = Application.StartupPath + @"\Templates\GSR\GSR_NCC.docx";
                            }
                            else if (oSite.CustomerID == (int)Enums.Customer.WDC)
                            {
                                template = Application.StartupPath + @"\Templates\GSR\GSR_WDC.docx";
                            }
                            else
                            {
                                template = Application.StartupPath + @"\Templates\GSR\GSR.docx";
                            }

                            string savePath = saveDir + @"\GSR" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, gasLsrs, template, savePath, Enums.WorksheetFuelTypes.Gas, goldenRule, fullDocument, oSite.CustomerID == (int)Enums.Customer.NCC);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_GAS");
                            }
                        }

                        if (oilLsrs.Table.Rows.Count > 0)
                        {
                            string savePath = saveDir + @"\GSROil" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSROil.docx";
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, oilLsrs, template, savePath, Enums.WorksheetFuelTypes.Oil, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OIL");
                            }
                        }

                        if (otherLsrs.Table.Rows.Count > 0 | hasOnlyDefects)
                        {
                            string savePath = saveDir + @"\GSROther" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSROther.docx";
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, otherLsrs, template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER");
                            }
                        }

                        if (solidFuelLsrs.Table.Rows.Count > 0)
                        {
                            string savePath = saveDir + @"\GSRSolidFuel" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRSolidFuel.docx";
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, solidFuelLsrs, template, savePath, Enums.WorksheetFuelTypes.SolidFuel, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_SOLIDFUEL");
                            }
                        }

                        if (hpLsrs.Table.Rows.Count > 0)
                        {
                            string savePath = saveDir + @"\GSRASHPGSHP" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRASHPGSHP.docx";
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, hpLsrs, template, savePath, Enums.WorksheetFuelTypes.ASHP, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_ASHPGSHP");
                            }
                        }

                        if (hiuLsrs.Table.Rows.Count > 0)
                        {
                            string savePath = saveDir + @"\GSRHIU" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRHIU.docx";
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, hiuLsrs, template, savePath, Enums.WorksheetFuelTypes.HIU, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_HIU");
                            }
                        }

                        if (unventedLsrs.Table.Rows.Count > 0)
                        {
                            string savePath = saveDir + @"\GSRUnvented" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRUnvented.docx";
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = Unvented(oEngineerVisit, oSite, template, savePath, unventedLsrs, goldenRule, ref fullDocument, printerHeader);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_GSRUnvented");
                            }
                        }

                        if (comCatLsrs.Table.Rows.Count > 0)
                        {
                            string savePath = saveDir + @"\GSRCOMCAT2" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRCOMCAT2.docx";
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, comCatLsrs, template, savePath, Enums.WorksheetFuelTypes.Unvented, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_COMCAT2");
                            }
                        }

                        if (ComCatAdd is object)
                        {
                            string savePath = saveDir + @"\GSRCOMCAT" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRCOMCAT.docx";
                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : oSite.CustomerID == (int)Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = COMCAT(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument, printerHeader);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_COMCAT");
                            }
                        }
                    }
                    else if (ASHP is object)
                    {
                        string savePath = saveDir + @"\ASHPM" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                        savePath = FileCheck(savePath);
                        template = Application.StartupPath + @"\Templates\GSR\GSRASHPM.docx";
                        bool printerHeader = false;
                        if (!isSvr)
                        {
                            if (!hasLsrHeaderLetter)
                                printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : false;
                            if (!hasLsrHeaderLetter)
                                hasLsrHeaderLetter = printerHeader;
                        }

                        goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                        success = ASHPM(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument, printerHeader);
                        if (success & !batch)
                        {
                            savePath = PrintHelper.LockFile(savePath, true);
                            GSRSave(savePath, oEngineerVisit, oSite, "LSR_ASHPM");
                        }

                        if (dvFaults.Count > 0)
                        {
                            savePath = saveDir + @"\GSROther" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSROther.docx";
                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, false, new DataView(new DataTable()), template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER");
                            }
                        }
                    }
                    else
                    {
                        string savePath = saveDir + @"\COMSR" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                        savePath = FileCheck(savePath);
                        template = Application.StartupPath + @"\Templates\GSR\GSRCOMSR.docx";
                        bool printerHeader = false;
                        if (!isSvr)
                        {
                            if (!hasLsrHeaderLetter)
                                printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : false;
                            if (!hasLsrHeaderLetter)
                                hasLsrHeaderLetter = printerHeader;
                        }

                        goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                        success = COMSR(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument, printerHeader);
                        if (success & !batch)
                        {
                            savePath = PrintHelper.LockFile(savePath, true);
                            GSRSave(savePath, oEngineerVisit, oSite, "LSR_COMSR");
                        }

                        if (dvAdditionalWorksheet is object && dvAdditionalWorksheet.Count > 0)
                        {
                            savePath = saveDir + @"\COMTANDP" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRCOMTANDP.docx";
                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = COMTANDP(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_COMTANDP");
                            }
                        }

                        if (dvFaults.Count > 0)
                        {
                            savePath = saveDir + @"\GSROther" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSROther.docx";
                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, false, new DataView(new DataTable()), template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER");
                            }
                        }
                    }

                ProptMain:
                    ;
                    if (PM is object)
                    {
                        string savePath = saveDir + @"\PropMain" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                        savePath = FileCheck(savePath);
                        template = Application.StartupPath + @"\Templates\GSR\GSRPropMain.docx";
                        bool printerHeader = false;
                        if (!isSvr)
                        {
                            if (!hasLsrHeaderLetter)
                                printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : false;
                            if (!hasLsrHeaderLetter)
                                hasLsrHeaderLetter = printerHeader;
                        }

                        goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                        success = ProptMain(oEngineerVisit, oSite, template, savePath, goldenRule, fullDocument, printerHeader);
                        if (success & !batch)
                        {
                            savePath = PrintHelper.LockFile(savePath, true);
                            GSRSave(savePath, oEngineerVisit, oSite, "LSR_PropMain");
                        }

                        if (dvFaults.Count > 0)
                        {
                            savePath = saveDir + @"\GSROther" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSROther.docx";
                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, false, new DataView(new DataTable()), template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER");
                            }
                        }
                    }

                SaffUnv:
                    ;
                    if (SaffUnv is object)
                    {
                        string savePath = saveDir + @"\SAFUnvASHP" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                        savePath = FileCheck(savePath);
                        template = Application.StartupPath + @"\Templates\GSR\GSRUnvASHP.docx";
                        bool printerHeader = false;
                        if (!isSvr)
                        {
                            if (!hasLsrHeaderLetter)
                                printerHeader = batch ? Helper.MakeBooleanValid(((ArrayList)DetailsToPrint)[1]) : false;
                            if (!hasLsrHeaderLetter)
                                hasLsrHeaderLetter = printerHeader;
                        }

                        goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                        success = SAFUnvented(oEngineerVisit, oSite, SaffUnv, template, savePath, goldenRule, ref fullDocument, printerHeader);
                        if (success & !batch)
                        {
                            savePath = PrintHelper.LockFile(savePath, true);
                            GSRSave(savePath, oEngineerVisit, oSite, "LSR_SAFUnvASHP");
                        }

                        if (dvFaults.Count > 0)
                        {
                            savePath = saveDir + @"\GSROther" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSROther.docx";
                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);
                            success = GSR(oEngineerVisit, oSite, dvFaults, false, new DataView(new DataTable()), template, savePath, Enums.WorksheetFuelTypes.Other, goldenRule, fullDocument);
                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_OTHER");
                            }
                        }
                    }

                NextLSR:
                    ;
                    if (isBlank)
                    {
                        var lsrError = new LSR.LSRError();
                        lsrError.EngineerVisitID = oEngineerVisit.EngineerVisitID;
                        var eng = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                        lsrError.Engineer = eng is object ? eng.Name : "Unknown";
                        lsrError.VisitDate = oEngineerVisit.StartDateTime;
                        lsrError.JobNumber = jobNumber;
                        LSRErrors.Add(lsrError);
                    }

                    return success;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            private bool GenerateServiceLetter(DataRow dr, string AMPM, DateTime VisitDate, string JobNumber, DateTime TheDate)
            {
                string dd = WordDoc.Content.Text;
                try
                {
                    foreach (Match wordField in Printing.GetTemplateFields(WordDoc.Content.Text))
                    {
                        var switchExpr = wordField.Value.ToLower();
                        switch (switchExpr)
                        {
                            case var @case when @case == "[Address1]".ToLower():
                                {
                                    var argmsWordDoc = WordDoc;
                                    ReplaceText(ref argmsWordDoc, wordField.Value, Helper.MakeStringValid(dr["Address1"]));
                                    break;
                                }

                            case var case1 when case1 == "[Address2]".ToLower():
                                {
                                    var argmsWordDoc1 = WordDoc;
                                    ReplaceText(ref argmsWordDoc1, wordField.Value, Helper.MakeStringValid(dr["Address2"]));
                                    break;
                                }

                            case var case2 when case2 == "[Address3]".ToLower():
                                {
                                    var argmsWordDoc2 = WordDoc;
                                    ReplaceText(ref argmsWordDoc2, wordField.Value, Helper.MakeStringValid(dr["Address3"]));
                                    break;
                                }

                            case var case3 when case3 == "[Address4]".ToLower():
                                {
                                    var argmsWordDoc3 = WordDoc;
                                    ReplaceText(ref argmsWordDoc3, wordField.Value, Helper.MakeStringValid(dr["Address4"]));
                                    break;
                                }

                            case var case4 when case4 == "[Address5]".ToLower():
                                {
                                    var argmsWordDoc4 = WordDoc;
                                    ReplaceText(ref argmsWordDoc4, wordField.Value, Helper.MakeStringValid(dr["Address5"]));
                                    break;
                                }

                            case var case5 when case5 == "[Postcode]".ToLower():
                                {
                                    var argmsWordDoc5 = WordDoc;
                                    ReplaceText(ref argmsWordDoc5, wordField.Value, Helper.MakeStringValid(Helper.FormatPostcode(dr["Postcode"])));
                                    break;
                                }

                            case var case6 when case6 == "[theDate]".ToLower():
                                {
                                    var argmsWordDoc6 = WordDoc;
                                    ReplaceText(ref argmsWordDoc6, wordField.Value, Strings.Format(TheDate, "dd/MM/yyyy"));
                                    break;
                                }

                            case var case7 when case7 == "[Date]".ToLower():
                                {
                                    var argmsWordDoc7 = WordDoc;
                                    ReplaceText(ref argmsWordDoc7, wordField.Value, Strings.Format(VisitDate, "dd/MM/yyyy"));
                                    break;
                                }
                            // ReplaceText(WordDoc, wordField.Value, Strings.format(Sys.Helper.MakeDateTimeValid(dr(0)("VisitDate")).AddYears(1), "dd/MM/yyyy"))
                            case var case8 when case8 == "[Name]".ToLower():
                                {
                                    string name = Helper.MakeStringValid(dr["Name"]);
                                    if (name.Contains("T2"))
                                    {
                                        name = name.Substring(0, Strings.InStr(name, "T2") - 1);
                                    }

                                    name = name.Replace("T1 ", "");
                                    name = name.Trim();
                                    var argmsWordDoc8 = WordDoc;
                                    ReplaceText(ref argmsWordDoc8, wordField.Value, name);
                                    break;
                                }

                            case var case9 when case9 == "[AMPM]".ToLower():
                                {
                                    if ((AMPM ?? "") == "AM")
                                    {
                                        var argmsWordDoc9 = WordDoc;
                                        ReplaceText(ref argmsWordDoc9, wordField.Value, "8:00am - 1:00pm");
                                    }
                                    else
                                    {
                                        var argmsWordDoc10 = WordDoc;
                                        ReplaceText(ref argmsWordDoc10, wordField.Value, "12:00pm - 5:30pm");
                                    }

                                    break;
                                }

                            case var case10 when case10 == "[JobRef]".ToLower():
                                {
                                    var argmsWordDoc11 = WordDoc;
                                    ReplaceText(ref argmsWordDoc11, wordField.Value, Helper.MakeStringValid(JobNumber));
                                    break;
                                }

                            case var case11 when case11 == "[gascharge]".ToLower():
                                {
                                    var thecutoff = new DateTime(2017, 3, 31);
                                    if (DateAndTime.DateDiff(DateInterval.Day, VisitDate, thecutoff) < 0)
                                    {
                                        var argmsWordDoc12 = WordDoc;
                                        ReplaceText(ref argmsWordDoc12, wordField.Value, "£41.37");
                                    }
                                    else
                                    {
                                        var argmsWordDoc13 = WordDoc;
                                        ReplaceText(ref argmsWordDoc13, wordField.Value, "£37.00");
                                    }

                                    break;
                                }

                            case var case12 when case12 == "[carpcharge]".ToLower():
                                {
                                    if (DateAndTime.DateDiff(DateInterval.Day, VisitDate, new DateTime(2017, 3, 31)) < 0)
                                    {
                                        var argmsWordDoc14 = WordDoc;
                                        ReplaceText(ref argmsWordDoc14, wordField.Value, "£97.76");
                                    }
                                    else
                                    {
                                        var argmsWordDoc15 = WordDoc;
                                        ReplaceText(ref argmsWordDoc15, wordField.Value, "£88.03");
                                    }

                                    break;
                                }
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateAnalyserLetter(DataTable dt)
            {
                try
                {
                    string usingdoc = Application.StartupPath + @"\Templates\FGATempAnton.docx";
                    var dr = dt.Rows[0];
                    var byteArray = File.ReadAllBytes(usingdoc);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            string docText = null;
                            var sr = new StreamReader(wordDoc.MainDocumentPart.GetStream());
                            using (sr)
                                docText = sr.ReadToEnd();
                            docText = docText.Replace("[Date]", DateAndTime.Now.ToLongDateString());
                            docText = docText.Replace("[Serial]", Conversions.ToString(dr["SerialNumber"]));
                            docText = docText.Replace("[Faults]", Conversions.ToString(dr["Faults"]));
                            docText = docText.Replace("[Username]", App.loggedInUser.Fullname);
                            docText = docText.Replace("[Email]", App.loggedInUser.EmailAddress);
                            var sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create));
                            using (sw)
                                sw.Write(docText);
                        }

                        var linkedDoc = new Documentss.Documents();
                        linkedDoc.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblEquipment);
                        linkedDoc.SetRecordID = Conversions.ToInteger(dr["EquipmentID"]);
                        linkedDoc.SetDocumentTypeID = 205;
                        string filePath = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblEquipment) + @"\" + Conversions.ToInteger(dr["EquipmentID"]);
                        Directory.CreateDirectory(filePath);
                        string newfile = Conversions.ToString(Conversions.ToString(filePath + @"\AnalyserSerialNumber" + dr["SerialNumber"] + "_") + DateTime.Now.ToFileTime() + ".docx");
                        var fileStream = new FileStream(newfile, FileMode.CreateNew);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                        fileStream.Close();
                        bool openFile = false;
                        if (!Helper.MakeBooleanValid(dr["SendEmail"]))
                            openFile = true;
                        newfile = PrintHelper.LockFile(newfile, true);
                        linkedDoc.SetNotes = "";
                        linkedDoc.SetLocation = filePath;
                        linkedDoc.SetName = "Anton Sprint eVo2, Serial Number " + dr["SerialNumber"];
                        linkedDoc = App.DB.Documents.Insert(linkedDoc, false);
                        if (Conversions.ToBoolean(dr["SendEmail"]))
                        {
                            var email = new Emails();
                            email.To = Conversions.ToString(dr["EmailAddress"]);
                            email.From = App.loggedInUser.EmailAddress;
                            email.Subject = Conversions.ToString("Anton Sprint eVo2, Serial Number " + dr["SerialNumber"]);
                            email.Body = "Please see letter attached";
                            email.Attachments.Add(newfile);
                            email.SendMe = true;
                            email.Send();
                        }
                        else
                        {
                            Process.Start(newfile);
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateServiceLetterMK2(DataRow dr, string AMPM, DateTime VisitDate, string JobNumber, DateTime TheDate, List<byte[]> batch = null, int jobid = 0, bool justLetters = false)
            {
                int customerId = Helper.MakeIntegerValid(dr["CustomerID"]);
                bool patchCheck = dr.Table.Columns.Contains("PatchCheck") && Helper.MakeBooleanValid(dr["PatchCheck"]);
                var serviceProcess = App.DB.Customer.CustomerServiceProcess_Get_ForCustomer(customerId);
                string letter = Helper.MakeStringValid(dr["Type"]).ToLower();
                byte[] template = TemplateHelper.ReadWordDoc(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ServiceLetters\AnnualSafetyInspection.docx");
                string fileName = dr.Table.Columns.Contains("FileName") && !string.IsNullOrEmpty(Helper.MakeStringValid(dr["FileName"])) ? Helper.MakeStringValid(dr["FileName"]) : string.Empty;
                var contacts = App.DB.Contact.Contacts_GetAll_ForLink(Conversions.ToInteger(Enums.TableNames.tblSite), Helper.MakeIntegerValid(dr["SiteID"]));
                DataRow drPOC = null;
                if (!string.IsNullOrEmpty(fileName))
                {
                    template = TemplateHelper.ReadWordDoc(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + fileName);
                }
                else if (Helper.MakeIntegerValid(serviceProcess?.CustomerServiceProcessID) == 0)
                {
                    if (patchCheck)
                    {
                        template = TemplateHelper.ReadWordDoc(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ServiceLetters\PatchCheck.docx");
                    }
                }
                else if (patchCheck)
                {
                    template = serviceProcess.PatchCheckTemplate;
                }
                else
                {
                    switch (letter)
                    {
                        case "letter 1":
                            {
                                template = serviceProcess.Template1;
                                break;
                            }

                        case "letter 2":
                            {
                                template = serviceProcess.Template2;
                                break;
                            }

                        case "letter 3":
                            {
                                template = serviceProcess.Template3;
                                break;
                            }
                    }
                }

                if (template is null)
                {
                    throw new Exception("Unable to locate template!");
                }

                foreach (DataRowView contact in contacts)
                {
                    if (Helper.MakeBooleanValid(contact["POC"]) == true)
                    {
                        drPOC = contact.Row;
                    }
                }

                try
                {
                    int count = drPOC is object ? 2 : 1;
                    for (int i = 0, loopTo = count - 1; i <= loopTo; i += 1)
                    {
                        string goldenRule = GetDocumentGoldenRule("AnnualSafetyInspection", Helper.MakeIntegerValid(dr["SiteID"]));
                        var byteArray = template;
                        var mm = new MemoryStream();
                        using (mm)
                        {
                            mm.Write(byteArray, 0, byteArray.Length);
                            var wordDoc = WordprocessingDocument.Open(mm, true);
                            using (wordDoc)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                                AddCompanyDetails(wordDoc, true);
                                var customer = App.DB.Customer.Customer_Get_ForSiteID(Helper.MakeIntegerValid(dr["SiteID"]));
                                if (customer is object)
                                    PrintHelper.ReplaceText(wordDoc, "$Customer", customer.Name);
                                PrintHelper.ReplaceText(wordDoc, "$Address1", Conversions.ToString(drPOC is object && !Information.IsDBNull(drPOC["Address1"]) ? drPOC["Address1"] : dr["Address1"]));
                                PrintHelper.ReplaceText(wordDoc, "$Address2", Conversions.ToString(drPOC is object && !Information.IsDBNull(drPOC["Address2"]) ? drPOC["Address2"] : dr["Address2"]));
                                PrintHelper.ReplaceText(wordDoc, "$Address3", Conversions.ToString(drPOC is object && !Information.IsDBNull(drPOC["Address3"]) ? drPOC["Address3"] : dr["Address3"]));
                                PrintHelper.ReplaceText(wordDoc, "$Address4", string.Empty);
                                PrintHelper.ReplaceText(wordDoc, "$Address5", string.Empty);
                                PrintHelper.ReplaceText(wordDoc, "$Postcode", drPOC is object && !Information.IsDBNull(drPOC["Postcode"]) ? Helper.FormatPostcode(drPOC["Postcode"]) : Helper.FormatPostcode(dr["Postcode"]));
                                PrintHelper.ReplaceText(wordDoc, "$TheDate", Strings.Format(TheDate, "dd/MM/yyyy"));
                                PrintHelper.ReplaceText(wordDoc, "$Date", VisitDate.ToString("dddd, dd/MM/yyyy"));
                                PrintHelper.ReplaceText(wordDoc, "$Expiry", Strings.Format(Conversions.ToDate(dr["LastServiceDate"]).AddDays(366), "dd/MM/yyyy"));
                                string name = string.Empty;
                                if (drPOC is object && !Information.IsDBNull(drPOC["FirstName"]))
                                {
                                    name = Helper.MakeStringValid(drPOC["Title"]) + " " + Helper.MakeStringValid(drPOC["FirstName"]) + " " + Helper.MakeStringValid(drPOC["LastName"]);
                                }

                                if (name.Length > 0)
                                    name += " on behalf of ";
                                name += Helper.MakeStringValid(dr["Name"]);
                                if (name.Contains("T2"))
                                {
                                    name = name.Replace("T2 ", "");
                                }

                                name = name.Replace("T1 ", "");
                                name = name.Trim();
                                PrintHelper.ReplaceText(wordDoc, "$Name", Strings.StrConv(name, VbStrConv.ProperCase).Replace("&", "&amp;"));
                                if (string.IsNullOrEmpty(AMPM))
                                {
                                    AMPM = VisitDate.Hour < 12 ? "AM" : "PM";
                                }

                                if ((AMPM ?? "") == "AM")
                                {
                                    PrintHelper.ReplaceText(wordDoc, "$AMPM", "between 8:00am and 1:00pm");
                                }
                                else
                                {
                                    PrintHelper.ReplaceText(wordDoc, "$AMPM", "between 12:00pm and 5:30pm");
                                }

                                PrintHelper.ReplaceText(wordDoc, "$GasCharge", "£41.37");
                                PrintHelper.ReplaceText(wordDoc, "$CarpCharge", "£97.76");
                                PrintHelper.ReplaceText(wordDoc, "$JobRef", Helper.MakeStringValid(JobNumber));
                                wordDoc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), wordDoc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            }

                            var linkedDoc = new Documentss.Documents();
                            linkedDoc.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblJob);
                            linkedDoc.SetRecordID = jobid;
                            linkedDoc.SetDocumentTypeID = 205;
                            string filePath = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblJob) + @"\" + jobid;
                            Directory.CreateDirectory(filePath);
                            string newfile = Conversions.ToString(filePath + @"\" + dr["Type"] + DateTime.Now.ToString("HHmmssfff") + ".docx");
                            var fileStream = new FileStream(newfile, FileMode.CreateNew);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                            linkedDoc.SetNotes = "";
                            linkedDoc.SetLocation = filePath;
                            linkedDoc = App.DB.Documents.Insert(linkedDoc, false);
                            if (!justLetters & App.DB.LetterManager.LetterGenerated_CheckToday(Conversions.ToString(dr["Type"]), jobid, TheDate).Rows.Count > 0)
                            {
                                return true;
                            }

                            if (batch is object)
                            {
                                batch.Add(mm.ToArray());
                            }
                            else
                            {
                                Process.Start(newfile);
                            }

                            drPOC = null;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            public bool GenerateJobLetter(DataRow dr, Jobs.Job job, bool letter1, WordprocessingDocument batch = null, EngineerVisits.EngineerVisit engineervisit = null)
            {
                var oSite = App.DB.Sites.Get(Helper.MakeIntegerValid(dr["SiteID"]));
                JobOfWorks.JobOfWork oJobOfWork = (JobOfWorks.JobOfWork)job.JobOfWorks[0];
                int letter = 0;
                if (!letter1)
                    letter = 1;
                EngineerVisits.EngineerVisit oEngineerVisit;
                if (engineervisit is null)
                {
                    oEngineerVisit = (EngineerVisits.EngineerVisit)oJobOfWork.EngineerVisits[letter];
                }
                else
                {
                    oEngineerVisit = engineervisit;
                }

                string doc = string.Empty;
                string workStream = Helper.MakeStringValid(dr["Type"]).ToLower();
                string templateLocation = Application.StartupPath + @"\Templates\Electrical\";
                string template = string.Empty;
                switch (true)
                {
                    case object _ when (workStream ?? "") == ("NCC-EICR".ToLower() ?? ""):  // eicr job
                        {
                            template = letter1 ? "NCCTestingLetter1.docx" : "NCCTestingLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }

                    case object _ when (workStream ?? "") == ("NCC-SURVEY-UPGRADE".ToLower() ?? ""):
                    case object _ when (workStream ?? "") == ("NCC-SURVEY-REWIRE".ToLower() ?? ""): // rewire/upgrade job
                        {
                            template = letter1 ? "NCCElecMainLetter1.docx" : "NCCElecMainLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }

                    case object _ when (workStream ?? "") == ("VHT-SMOKE".ToLower() ?? ""):
                        {
                            doc = templateLocation + "VHTSMOKE.docx";
                            break;
                        }

                    case object _ when (workStream ?? "") == ("VHT-REMEDIAL".ToLower() ?? ""):
                        {
                            doc = templateLocation + "VHTRemedial.docx";
                            break;
                        }

                    case object _ when (workStream ?? "") == ("SHS-REMEDIAL".ToLower() ?? ""):
                        {
                            doc = templateLocation + "SHSRemedial.docx";
                            break;
                        }

                    case object _ when (workStream ?? "") == ("FHG-REMEDIAL".ToLower() ?? ""):
                        {
                            doc = templateLocation + "FHGRemedial.docx";
                            break;
                        }

                    case object _ when (workStream ?? "") == ("NCC-REMEDIAL".ToLower() ?? ""):
                        {
                            doc = templateLocation + "NCCRemedial.docx";
                            break;
                        }

                    case object _ when (workStream ?? "") == ("VHT-EICR".ToLower() ?? ""):
                        {
                            template = letter1 ? "VHTTestingLetter1.docx" : "VHTTestingLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }

                    case object _ when (workStream ?? "") == ("SHS-EICR".ToLower() ?? ""):
                        {
                            template = letter1 ? "SHSEicrLetter1.docx" : "SHSEicrLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }

                    case object _ when (workStream ?? "") == ("FHG-EICR".ToLower() ?? ""):
                        {
                            template = letter1 ? "FHGTestingLetter1.docx" : "FHGTestingLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }
                }

                if (string.IsNullOrEmpty(doc))
                {
                    template = letter1 ? "NCCTestingLetter1.docx" : "NCCTestingLetter2.docx";
                    doc = templateLocation + template;
                }

                try
                {
                    string goldenRule = GetDocumentGoldenRule(doc, Helper.MakeIntegerValid(dr["SiteID"]));
                    var byteArray = File.ReadAllBytes(doc);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            string name = Strings.StrConv(Helper.MakeStringValid(dr["Name"]), VbStrConv.ProperCase).Replace("&", "&amp;").Trim();
                            if (name.Length == 0)
                            {
                                name = "The Occupier";
                            }

                            PrintHelper.ReplaceText(wordDoc, "[Name]", name);
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSite.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSite.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSite.Address3);
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[Letter]", DateAndTime.Now.ToLongDateString());
                            var visitDate = oEngineerVisit.StartDateTime != default ? oEngineerVisit.StartDateTime : job.DateCreated;
                            PrintHelper.ReplaceText(wordDoc, "[Date]", visitDate.ToString("dd MMM yyyy"));
                            dr["BookedVisit"] = visitDate;
                            string timePeriod = string.Empty;
                            timePeriod = visitDate.Hour < 12 ? "8:00am - 1:00pm" : "12:00pm - 5:30pm";
                            if (visitDate.Hour < 12)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[Time]", timePeriod);
                            }
                            else // cant tell so all day
                            {
                                PrintHelper.ReplaceText(wordDoc, "[Time]", timePeriod);
                            }

                            PrintHelper.ReplaceText(wordDoc, "[User]", App.loggedInUser.Fullname);
                            if (Helper.MakeStringValid(dr["Type"]).Contains("Rewire")) // eicr job
                            {
                                PrintHelper.ReplaceText(wordDoc, "[Type]", "electrical rewiring");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[Type]", "electrical upgrades");
                            }

                            if (batch is object)
                            {
                                wordDoc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), wordDoc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            }
                        }

                        var linkedDoc = new Documentss.Documents();
                        linkedDoc.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblJob);
                        linkedDoc.SetRecordID = job.JobID;
                        linkedDoc.SetDocumentTypeID = 205;
                        string filePath = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblJob) + @"\" + job.JobID;
                        Directory.CreateDirectory(filePath);
                        string newfile = filePath + @"\" + Helper.MakeStringValid(dr["Type"]);
                        newfile += letter1 ? "_L1" : "_L2";
                        newfile += "_" + oSite.Address1.Replace(@"\", "").Replace("/", "") + ".docx";
                        newfile = FileCheck(newfile);
                        var fileStream = new FileStream(newfile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                        linkedDoc.SetNotes = "";
                        linkedDoc.SetLocation = filePath;
                        linkedDoc.SetName = letter1 ? "Letter1" : "Letter2";
                        linkedDoc = App.DB.Documents.Insert(linkedDoc, false);
                        var contactAttempt = new ContactAttempt();
                        {
                            var withBlock = contactAttempt;
                            withBlock.ContactMethedID = 3;
                            withBlock.LinkID = Conversions.ToInteger(Enums.TableNames.tblJob);
                            withBlock.LinkRef = job.JobID;
                            withBlock.ContactMade = DateAndTime.Now;
                            withBlock.Notes = (letter1 ? "Letter 1" : "Letter 2") + " Generated";
                            withBlock.ContactMadeByUserId = App.loggedInUser.UserID;
                        }

                        contactAttempt = App.DB.ContactAttempts.Insert(contactAttempt);
                        if (batch is object)
                        {
                            var mainPart = batch.MainDocumentPart;
                            string altChunkId = "AltId" + Helper.MakeIntegerValid(dr["SiteID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                            var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            mm.Position = 0;
                            using (mm)
                                chunk.FeedData(mm);
                            var altChunk = new WP.AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                            mainPart.Document.Save();
                        }
                        else
                        {
                            wpFilePath = newfile;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GeneratePurchaseOrder(Sites.Site oSite, Warehouses.Warehouse oWarehouse, DataTable dt, Suppliers.Supplier oSupplier, Users.User oUser, string poNumber, DateTime deadline, DataView dvCharges, string savePath, bool toPdf)
            {
                string template = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\Invoice\SupplierPurchaseOrder.docx";
                try
                {
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            AddCompanyDetails(wordDoc, true, true);
                            string deliveryAddress1 = "";
                            string deliveryAddress2 = "";
                            string deliveryAddress3 = "";
                            string deliveryAddress4 = "";
                            string deliveryAddress5 = "";
                            string deliveryAddressPostcode = "";
                            if (oSite is object)
                            {
                                deliveryAddress1 = oSite.Address1;
                                deliveryAddress2 = oSite.Address2;
                                deliveryAddress3 = oSite.Address3;
                                deliveryAddress4 = oSite.Address4;
                                deliveryAddress5 = oSite.Address5;
                                deliveryAddressPostcode = oSite.Postcode;
                            }
                            else if (oWarehouse is object)
                            {
                                deliveryAddress1 = oWarehouse.Address1;
                                deliveryAddress2 = oWarehouse.Address2;
                                deliveryAddress3 = oWarehouse.Address3;
                                deliveryAddress4 = oWarehouse.Address4;
                                deliveryAddress5 = oWarehouse.Address5;
                                deliveryAddressPostcode = oWarehouse.Postcode;
                            }
                            else
                            {
                                deliveryAddress1 = App.TheSystem.Configuration.CompanyName;
                                deliveryAddress2 = App.TheSystem.Configuration.CompanyAddres1;
                                deliveryAddress3 = App.TheSystem.Configuration.CompanyAddres2;
                                deliveryAddress4 = App.TheSystem.Configuration.CompanyAddres3;
                                deliveryAddress5 = App.TheSystem.Configuration.CompanyAddres4;
                                deliveryAddressPostcode = App.TheSystem.Configuration.CompanyPostcode;
                            }

                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress1]", deliveryAddress1);
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress2]", deliveryAddress2);
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress3]", deliveryAddress3);
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress4]", deliveryAddress4);
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryAddress5]", deliveryAddress5);
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryPostcode]", Helper.FormatPostcode(deliveryAddressPostcode));
                            PrintHelper.ReplaceText(wordDoc, "[Name]", oSupplier.Name);
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSupplier.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSupplier.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSupplier.Address3);
                            PrintHelper.ReplaceText(wordDoc, "[Address4]", oSupplier.Address4);
                            PrintHelper.ReplaceText(wordDoc, "[Address5]", oSupplier.Address5);
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSupplier.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[Date]", DateTime.Now.ToString("dd MMM yyyy"));
                            PrintHelper.ReplaceText(wordDoc, "[User]", oUser.Fullname);
                            PrintHelper.ReplaceText(wordDoc, "[OrderNumber]", poNumber);
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryDueDate]", deadline != default ? deadline.ToString("dd MMM yyyy") : "N/A");
                            var dtParts = new DataTable();
                            dtParts.Columns.Add("Item");
                            dtParts.Columns.Add("Description");
                            dtParts.Columns.Add("Number");
                            dtParts.Columns.Add("Price");
                            dtParts.Columns.Add("Qty");
                            dtParts.Columns.Add("Total");
                            double total = 0.0;
                            if (dt is object && dt.Rows.Count > 0)
                            {
                                int index = 1;
                                foreach (DataRow r in dt.Rows)
                                {
                                    var nr = dtParts.NewRow();
                                    nr["Item"] = index;
                                    nr["Description"] = r["Name"];
                                    nr["Number"] = r["Number"];
                                    nr["Price"] = Helper.MakeDoubleValid(r["BuyPrice"]).ToString("C");
                                    nr["Qty"] = r["QuantityOnOrder"];
                                    nr["Total"] = Helper.MakeDoubleValid(Helper.MakeDoubleValid(r["BuyPrice"]) * Helper.MakeDoubleValid(r["QuantityOnOrder"])).ToString("C");
                                    total += Conversions.ToDouble(Helper.MakeDoubleValid(Helper.MakeDoubleValid(r["BuyPrice"]) * Helper.MakeDoubleValid(r["QuantityOnOrder"])).ToString("C"));
                                    dtParts.Rows.Add(nr);
                                    index += 1;
                                }

                                PrintHelper.AddRowsToTable(wordDoc, "Item", dtParts, "Arial", "16");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[Total]", total.ToString("C"));
                            var dtCharges = new DataTable();
                            dtCharges.Columns.Add("Type");
                            dtCharges.Columns.Add("Price");
                            if (dvCharges is object && dvCharges.Table.Rows.Count > 0)
                            {
                                foreach (DataRow r in dvCharges.Table.Rows)
                                {
                                    var nr = dtCharges.NewRow();
                                    nr["Type"] = r["ChargeType"];
                                    nr["Price"] = Helper.MakeDoubleValid(r["Amount"]).ToString("C");
                                    dtCharges.Rows.Add(nr);
                                }

                                PrintHelper.AddRowsToTable(wordDoc, "Type", dtCharges, "Arial", "16");
                            }
                        }

                        savePath = FileCheck(savePath);
                        var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                        if (toPdf)
                        {
                            savePath = PrintHelper.ToPdf(savePath);
                        }

                        var linkedDoc = new Documentss.Documents();
                        linkedDoc.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblOrder);
                        linkedDoc.SetRecordID = OrderID;
                        linkedDoc.SetDocumentTypeID = 162;
                        linkedDoc.SetName = Path.GetFileName(savePath);
                        linkedDoc.SetNotes = "";
                        linkedDoc.SetLocation = savePath;
                        var cV = new Documentss.DocumentsValidator();
                        cV.Validate(linkedDoc);
                        linkedDoc = App.DB.Documents.Insert(linkedDoc);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("ERROR : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return default;
            }

            private bool GenerateJobSheet(EngineerVisits.EngineerVisit EngineerVisit)
            {
                try
                {
                    var job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
                    // Get the payment terms and paidby details
                    var jow = App.DB.JobOfWorks.JobOfWork_Get(EngineerVisit.JobOfWorkID);
                    string jobOrOrderNumber = "";
                    int rowIndex = 1;
                    double subTotal = 0.0;
                    var site = App.DB.Sites.Get(job.PropertyID);
                    {
                        var withBlock = WordDoc.Tables[2];
                        {
                            var withBlock1 = withBlock.Rows.Add();
                            withBlock1.Range.Font.Bold = Conversions.ToInteger(false);
                            withBlock1.Range.Font.Size = 9;
                            withBlock1.Borders[WD.WdBorderType.wdBorderTop].LineStyle = WD.WdLineStyle.wdLineStyleNone;
                            withBlock1.Borders[WD.WdBorderType.wdBorderBottom].LineStyle = WD.WdLineStyle.wdLineStyleNone;
                        }

                        rowIndex += 1;

                        // Job Number /  'Order Number / Contract
                        if (jow.PONumber.Length == 0)
                        {
                            withBlock.Cell(rowIndex, 1).Range.Text = job.JobNumber;
                        }
                        else
                        {
                            withBlock.Cell(rowIndex, 1).Range.Text = job.JobNumber + " / " + jow.PONumber;
                        }

                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 1));
                        withBlock.Cell(rowIndex, 3).Range.Text = site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode(site.Postcode);
                        int cou = 0;
                        withBlock.Cell(rowIndex, 4).Range.Text = EngineerVisit.NotesToEngineer;
                        withBlock.Cell(rowIndex, 5).Range.Text = EngineerVisit.OutcomeDetails;
                        withBlock.Cell(rowIndex, 5).Range.Font.Bold = Conversions.ToInteger(true);
                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 4));
                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 5));
                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 3));
                    }

                    {
                        var withBlock2 = WordDoc.Tables[1];
                        withBlock2.Cell(3, 1).Range.Text = Helper.MakeStringValid(site.Name);
                        withBlock2.Cell(4, 1).Range.Text = Helper.MakeStringValid(site.Address1);
                        withBlock2.Cell(5, 1).Range.Text = Helper.MakeStringValid(site.Address2);
                        withBlock2.Cell(6, 1).Range.Text = Helper.MakeStringValid(site.Address3);
                        withBlock2.Cell(7, 1).Range.Text = Helper.MakeStringValid(site.Address4);
                        withBlock2.Cell(8, 1).Range.Text = Helper.MakeStringValid(site.Address5);
                        withBlock2.Cell(9, 1).Range.Text = Helper.MakeStringValid(Helper.FormatPostcode(site.Postcode));
                        withBlock2.Cell(3, 5).Range.Text = "";
                        withBlock2.Cell(5, 5).Range.Text = Strings.Format(EngineerVisit.StartDateTime, "dd/MM/yyyy");
                        withBlock2.Cell(7, 5).Range.Text = Helper.MakeStringValid("");
                        Marshal.ReleaseComObject(withBlock2.Cell(3, 1));
                        Marshal.ReleaseComObject(withBlock2.Cell(4, 1));
                        Marshal.ReleaseComObject(withBlock2.Cell(5, 1));
                        Marshal.ReleaseComObject(withBlock2.Cell(6, 1));
                        Marshal.ReleaseComObject(withBlock2.Cell(7, 1));
                        Marshal.ReleaseComObject(withBlock2.Cell(8, 1));
                        Marshal.ReleaseComObject(withBlock2.Cell(3, 5));
                        Marshal.ReleaseComObject(withBlock2.Cell(5, 5));
                        Marshal.ReleaseComObject(withBlock2.Cell(7, 5));
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateProforma(Jobs.Job job, ContractOriginalSites.ContractOriginalSite cos)
            {
                try
                {
                    string jobnumber = "";
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(((ArrayList)DetailsToPrint)[0], "JOB", false)))
                    {
                        jobnumber = job.JobNumber;
                    }
                    else
                    {
                        jobnumber = App.DB.ContractOriginal.Get(cos.ContractID).ContractReference;
                    }

                    // Get the payment terms and paidby details
                    // LETS GET THE INVOICE LINES MADE
                    string jobOrOrderNumber = "";
                    int rowIndex = 1;
                    double subTotal = 0.0;
                    {
                        var withBlock = WordDoc.Tables[2];
                        {
                            var withBlock1 = withBlock.Rows.Add();
                            withBlock1.Range.Font.Bold = Conversions.ToInteger(false);
                            withBlock1.Range.Font.Size = 9;
                            withBlock1.Borders[WD.WdBorderType.wdBorderTop].LineStyle = WD.WdLineStyle.wdLineStyleNone;
                            withBlock1.Borders[WD.WdBorderType.wdBorderBottom].LineStyle = WD.WdLineStyle.wdLineStyleNone;
                        }

                        rowIndex += 1;

                        // Job Number /  'Order Number / Contract
                        withBlock.Cell(rowIndex, 1).Range.Text = jobnumber;
                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 1));
                        var switchExpr = Helper.MakeStringValid(((ArrayList)DetailsToPrint)[0]);
                        switch (switchExpr)
                        {
                            case "JOB":
                                {
                                    var site = App.DB.Sites.Get(job.PropertyID);
                                    withBlock.Cell(rowIndex, 3).Range.Text = site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode(site.Postcode);
                                    withBlock.Cell(rowIndex, 4).Range.Text = details1;
                                    withBlock.Cell(rowIndex, 5).Range.Text = Strings.Format(Conversions.ToDouble(details2), "C");
                                    withBlock.Cell(rowIndex, 5).Range.Font.Bold = Conversions.ToInteger(true);
                                    subTotal += Conversions.ToDouble(details2);
                                    Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 3));
                                    Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 4));
                                    Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 5));
                                    break;
                                }

                            case "CONTRACT":
                                {
                                    var site = App.DB.Sites.Get(cos.PropertyID);
                                    withBlock.Cell(rowIndex, 3).Range.Text = site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode(site.Postcode);
                                    withBlock.Cell(rowIndex, 4).Range.Text = details1;
                                    withBlock.Cell(rowIndex, 5).Range.Text = Strings.Format(Conversions.ToDouble(details2), "C");
                                    subTotal += Helper.MakeDoubleValid(details2);
                                    Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 3));
                                    Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 4));
                                    Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 5));
                                    break;
                                }
                        }
                    }

                    decimal VATRate = Conversions.ToDecimal(Helper.MakeDoubleValid(((ArrayList)DetailsToPrint)[4]));
                    decimal VATRateDecimal = VATRate / 100;

                    // ***********************************************************************************
                    // REST OF THE DOCUMENT

                    {
                        var withBlock2 = WordDoc.Tables[1];
                        withBlock2.Cell(1, 1).Range.Text = Helper.MakeStringValid("PRO-FORMA");
                        {
                            var withBlock3 = WordDoc.Tables[3];
                            withBlock3.Cell(2, 1).Range.Text = "PRO-FORMA";
                            withBlock3.Cell(3, 1).Range.Text = "This is NOT a VAT Invoice";
                            Marshal.ReleaseComObject(withBlock3.Cell(2, 1));
                            Marshal.ReleaseComObject(withBlock3.Cell(3, 1));
                        }

                        Marshal.ReleaseComObject(withBlock2.Cell(1, 1));
                    }

                    var dtinvoicedetails = App.DB.Invoiced.InvoiceDetails_Get_InvoiceToBeRaisedID(Conversions.ToInteger(((ArrayList)DetailsToPrint)[5])).Table;
                    {
                        var withBlock4 = WordDoc.Tables[1];
                        withBlock4.Cell(3, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows[0]["SiteName"]);
                        withBlock4.Cell(4, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows[0]["address1"]);
                        withBlock4.Cell(5, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows[0]["address2"]);
                        withBlock4.Cell(6, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows[0]["address3"]);
                        withBlock4.Cell(7, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows[0]["address4"]);
                        withBlock4.Cell(8, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows[0]["address5"]);
                        withBlock4.Cell(9, 1).Range.Text = Helper.MakeStringValid(Helper.FormatPostcode(dtinvoicedetails.Rows[0]["postcode"]));
                        withBlock4.Cell(3, 5).Range.Text = "";
                        withBlock4.Cell(5, 5).Range.Text = Strings.Format(DateAndTime.Today, "dd/MM/yyyy");
                        withBlock4.Cell(7, 5).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows[0]["AccountNumber"]);
                        Marshal.ReleaseComObject(withBlock4.Cell(3, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(4, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(5, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(6, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(7, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(8, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(3, 5));
                        Marshal.ReleaseComObject(withBlock4.Cell(5, 5));
                        Marshal.ReleaseComObject(withBlock4.Cell(7, 5));
                    }

                    {
                        var withBlock5 = WordDoc.Tables[3];
                        withBlock5.Cell(2, 5).Range.Text = Strings.Format(subTotal, "C");
                        withBlock5.Cell(3, 5).Range.Text = Strings.Format(subTotal * Conversions.ToDouble(VATRateDecimal), "C");
                        withBlock5.Cell(4, 5).Range.Text = Strings.Format(subTotal * Conversions.ToDouble(VATRateDecimal) + subTotal, "C");
                        {
                            var withBlock6 = withBlock5.Rows;
                            withBlock6.WrapAroundText = Conversions.ToInteger(true);
                            withBlock6.HorizontalPosition = (float)WD.WdTablePosition.wdTableLeft;
                            withBlock6.RelativeHorizontalPosition = WD.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn;
                            withBlock6.DistanceLeft = MsWordApp.CentimetersToPoints(0.32F);
                            withBlock6.DistanceRight = MsWordApp.CentimetersToPoints(0.32F);
                            withBlock6.VerticalPosition = (float)WD.WdTablePosition.wdTableBottom;
                            withBlock6.RelativeVerticalPosition = WD.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
                            withBlock6.DistanceTop = MsWordApp.CentimetersToPoints(0);
                            withBlock6.DistanceBottom = MsWordApp.CentimetersToPoints(0);
                            withBlock6.AllowOverlap = Conversions.ToInteger(false);
                        }

                        Marshal.ReleaseComObject(withBlock5.Cell(2, 5));
                        Marshal.ReleaseComObject(withBlock5.Cell(3, 5));
                        Marshal.ReleaseComObject(withBlock5.Cell(4, 5));
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateProformaFromVisit(Jobs.Job job)
            {
                try
                {
                    string jobnumber = "";
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(((ArrayList)DetailsToPrint)[0], "JOB", false)))
                    {
                        jobnumber = job.JobNumber;
                    }
                    else
                    {
                        // jobnumber = DB.ContractOriginal.Get(cos.ContractID).ContractReference
                    }

                    // Get the payment terms and paidby details
                    // LETS GET THE INVOICE LINES MADE
                    string jobOrOrderNumber = "";
                    int rowIndex = 1;
                    double subTotal = 0.0;
                    var sites = App.DB.Sites.Get(job.PropertyID);
                    var siteHO = App.DB.Sites.Get(job.PropertyID);
                    if (!(sites.CustomerID == (int)Enums.Customer.Domestic))
                    {
                        siteHO = App.DB.Sites.Get(sites.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    }

                    {
                        var withBlock = WordDoc.Tables[2];
                        {
                            var withBlock1 = withBlock.Rows.Add();
                            withBlock1.Range.Font.Bold = Conversions.ToInteger(false);
                            withBlock1.Range.Font.Size = 9;
                            withBlock1.Borders[WD.WdBorderType.wdBorderTop].LineStyle = WD.WdLineStyle.wdLineStyleNone;
                            withBlock1.Borders[WD.WdBorderType.wdBorderBottom].LineStyle = WD.WdLineStyle.wdLineStyleNone;
                        }

                        rowIndex += 1;

                        // Job Number /
                        withBlock.Cell(rowIndex, 1).Range.Text = jobnumber;
                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 1));
                        withBlock.Cell(rowIndex, 3).Range.Text = sites.Address1 + ", " + sites.Address2 + ", " + Helper.FormatPostcode(sites.Postcode);
                        withBlock.Cell(rowIndex, 4).Range.Text = details1;
                        withBlock.Cell(rowIndex, 5).Range.Text = Strings.Format(Conversions.ToDouble(details2), "C");
                        withBlock.Cell(rowIndex, 5).Range.Font.Bold = Conversions.ToInteger(true);
                        subTotal += Conversions.ToDouble(details2);
                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 3));
                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 4));
                        Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 5));
                    }

                    var customer = App.DB.Customer.Customer_Get(sites.CustomerID);
                    decimal VATRate = Conversions.ToDecimal(Helper.MakeDoubleValid(((ArrayList)DetailsToPrint)[4]));
                    decimal VATRateDecimal = VATRate / 100;

                    // ***********************************************************************************
                    // REST OF THE DOCUMENT

                    {
                        var withBlock2 = WordDoc.Tables[1];
                        withBlock2.Cell(1, 1).Range.Text = Helper.MakeStringValid("PRO-FORMA");
                        {
                            var withBlock3 = WordDoc.Tables[3];
                            withBlock3.Cell(2, 1).Range.Text = "PRO-FORMA";
                            withBlock3.Cell(3, 1).Range.Text = "This is NOT a VAT Invoice";
                            Marshal.ReleaseComObject(withBlock3.Cell(2, 1));
                            Marshal.ReleaseComObject(withBlock3.Cell(3, 1));
                        }

                        Marshal.ReleaseComObject(withBlock2.Cell(1, 1));
                    }

                    {
                        var withBlock4 = WordDoc.Tables[1];
                        withBlock4.Cell(3, 1).Range.Text = Helper.MakeStringValid(siteHO.Name);
                        withBlock4.Cell(4, 1).Range.Text = Helper.MakeStringValid(siteHO.Address1);
                        withBlock4.Cell(5, 1).Range.Text = Helper.MakeStringValid(siteHO.Address2);
                        withBlock4.Cell(6, 1).Range.Text = Helper.MakeStringValid(siteHO.Address3);
                        withBlock4.Cell(7, 1).Range.Text = Helper.MakeStringValid(siteHO.Address4);
                        withBlock4.Cell(8, 1).Range.Text = Helper.MakeStringValid(siteHO.Address5);
                        withBlock4.Cell(9, 1).Range.Text = Helper.MakeStringValid(Helper.FormatPostcode(siteHO.Postcode));
                        withBlock4.Cell(3, 5).Range.Text = "";
                        withBlock4.Cell(5, 5).Range.Text = Strings.Format(DateAndTime.Today, "dd/MM/yyyy");
                        withBlock4.Cell(7, 5).Range.Text = Helper.MakeStringValid(customer.AccountNumber);
                        Marshal.ReleaseComObject(withBlock4.Cell(3, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(4, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(5, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(6, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(7, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(8, 1));
                        Marshal.ReleaseComObject(withBlock4.Cell(3, 5));
                        Marshal.ReleaseComObject(withBlock4.Cell(5, 5));
                        Marshal.ReleaseComObject(withBlock4.Cell(7, 5));
                    }

                    {
                        var withBlock5 = WordDoc.Tables[3];
                        withBlock5.Cell(2, 5).Range.Text = Strings.Format(subTotal, "C");
                        withBlock5.Cell(3, 5).Range.Text = Strings.Format(subTotal * Conversions.ToDouble(VATRateDecimal), "C");
                        withBlock5.Cell(4, 5).Range.Text = Strings.Format(subTotal * Conversions.ToDouble(VATRateDecimal) + subTotal, "C");
                        {
                            var withBlock6 = withBlock5.Rows;
                            withBlock6.WrapAroundText = Conversions.ToInteger(true);
                            withBlock6.HorizontalPosition = (float)WD.WdTablePosition.wdTableLeft;
                            withBlock6.RelativeHorizontalPosition = WD.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn;
                            withBlock6.DistanceLeft = MsWordApp.CentimetersToPoints(0.32F);
                            withBlock6.DistanceRight = MsWordApp.CentimetersToPoints(0.32F);
                            withBlock6.VerticalPosition = (float)WD.WdTablePosition.wdTableBottom;
                            withBlock6.RelativeVerticalPosition = WD.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
                            withBlock6.DistanceTop = MsWordApp.CentimetersToPoints(0);
                            withBlock6.DistanceBottom = MsWordApp.CentimetersToPoints(0);
                            withBlock6.AllowOverlap = Conversions.ToInteger(false);
                        }

                        Marshal.ReleaseComObject(withBlock5.Cell(2, 5));
                        Marshal.ReleaseComObject(withBlock5.Cell(3, 5));
                        Marshal.ReleaseComObject(withBlock5.Cell(4, 5));
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool QCPrint()
            {
                var worksheet = Convert.ToInt32(((ArrayList)DetailsToPrint)[1]);
                switch ((Enums.AdditionalChecksTypes)worksheet)
                {
                    case Enums.AdditionalChecksTypes.WorkInProgressAuditDomGASWork:
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\WIP Audit Domestic Gas Work.dot");
                        break;

                    case Enums.AdditionalChecksTypes.PostCompleteAuditDomWork:
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\Post Complete Audit Domestic Work.dot");
                        break;

                    case Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork:
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\WIP Audit Domestic Oil Work.dot");
                        break;

                    case Enums.AdditionalChecksTypes.WorkInProgressAuditCommercialGASWork:
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\WIP Audit Commercial Gas Work.dot");
                        break;

                    case Enums.AdditionalChecksTypes.ElectricalAudit:
                        WordDoc = MsWordApp.Documents.Add(Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\ElectricalQC.dot");
                        break;
                }

                var engineerVisitId = Convert.ToInt32(((ArrayList)DetailsToPrint)[0]);
                var type = Convert.ToInt32(((ArrayList)DetailsToPrint)[1]);
                var add = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(engineerVisitId, type);
                if (add.Test125 == 0)
                    add.SetTest125 = 53;
                var eng = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(add.Test125));
                var engv = App.DB.EngineerVisits.EngineerVisits_Get(engineerVisitId)?.Table;
                var auitor = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(engv.Rows[0]["EngineerID"]));
                var address = App.DB.Sites.Get(engineerVisitId, Sites.SiteSQL.GetBy.EngineerVisitId);
                var job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(engineerVisitId);
                var customer = App.DB.Customer.Customer_Get(address.CustomerID);
                try
                {
                    foreach (Match wordField in Printing.GetTemplateFields(WordDoc.Content.Text))
                    {
                        var switchExpr = wordField.Value.ToLower();
                        switch (switchExpr)
                        {
                            case var @case when @case == "[Client]".ToLower():
                                {
                                    var argmsWordDoc = WordDoc;
                                    ReplaceText(ref argmsWordDoc, wordField.Value, Helper.MakeStringValid(customer.Name));
                                    break;
                                }

                            case var case1 when case1 == "[UPRN]".ToLower():
                                {
                                    var argmsWordDoc1 = WordDoc;
                                    ReplaceText(ref argmsWordDoc1, wordField.Value, Helper.MakeStringValid(address.PolicyNumber));
                                    break;
                                }

                            case var case2 when case2 == "[Project]".ToLower():
                                {
                                    var argmsWordDoc2 = WordDoc;
                                    ReplaceText(ref argmsWordDoc2, wordField.Value, Helper.MakeStringValid(App.DB.Picklists.Get_One_As_Object(add.Test1).Name));
                                    break;
                                }

                            case var case3 when case3 == "[Address]".ToLower():
                                {
                                    var argmsWordDoc3 = WordDoc;
                                    ReplaceText(ref argmsWordDoc3, wordField.Value, Helper.MakeStringValid(address.Address1 + ", " + address.Address2 + ", " + address.Address3 + ", " + address.Postcode));
                                    break;
                                }

                            case var case4 when case4 == "[Type]".ToLower():
                                {
                                    var argmsWordDoc4 = WordDoc;
                                    ReplaceText(ref argmsWordDoc4, wordField.Value, Helper.MakeStringValid(App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(add.Test237)).Name));
                                    break;
                                }

                            case var case5 when case5 == "[eng]".ToLower():
                                {
                                    var argmsWordDoc5 = WordDoc;
                                    ReplaceText(ref argmsWordDoc5, wordField.Value, Helper.MakeStringValid(eng.Name));
                                    break;
                                }

                            case var case6 when case6 == "[ename]".ToLower():
                                {
                                    var argmsWordDoc6 = WordDoc;
                                    ReplaceText(ref argmsWordDoc6, wordField.Value, Helper.MakeStringValid(eng.Name));
                                    break;
                                }

                            case var case7 when case7 == "[CompletedBy]".ToLower():
                                {
                                    var argmsWordDoc7 = WordDoc;
                                    ReplaceText(ref argmsWordDoc7, wordField.Value, Helper.MakeStringValid(eng.Name));
                                    break;
                                }

                            case var case8 when case8 == "[aname]".ToLower():
                                {
                                    var argmsWordDoc8 = WordDoc;
                                    ReplaceText(ref argmsWordDoc8, wordField.Value, Helper.MakeStringValid(auitor.Name));
                                    break;
                                }

                            case var case9 when case9 == "[QCBy]".ToLower():
                                {
                                    var argmsWordDoc9 = WordDoc;
                                    ReplaceText(ref argmsWordDoc9, wordField.Value, Helper.MakeStringValid(auitor.Name));
                                    break;
                                }

                            case var case10 when case10 == "[sum]".ToLower():
                                {
                                    var argmsWordDoc10 = WordDoc;
                                    ReplaceText(ref argmsWordDoc10, wordField.Value, Helper.MakeStringValid(engv.Rows[0]["OutcomeDetails"]));
                                    break;
                                }

                            case var case11 when case11 == "[jn]".ToLower():
                                {
                                    var argmsWordDoc11 = WordDoc;
                                    ReplaceText(ref argmsWordDoc11, wordField.Value, Helper.MakeStringValid(add.Test238));
                                    break;
                                }

                            case var case12 when case12 == "[gs]".ToLower():
                                {
                                    var oilId = Convert.ToInt32(((ArrayList)DetailsToPrint)[1]);
                                    if (oilId == (int)Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork || address.SiteFuel == "Oil")
                                    {
                                        var argmsWordDoc12 = WordDoc;
                                        ReplaceText(ref argmsWordDoc12, wordField.Value, Helper.MakeStringValid(eng.OftecNo));
                                    }
                                    else
                                    {
                                        var argmsWordDoc12 = WordDoc;
                                        ReplaceText(ref argmsWordDoc12, wordField.Value, Helper.MakeStringValid(eng.GasSafeNo));
                                    }
                                    break;
                                }

                            case var case13 when case13 == "[date]".ToLower():
                                {
                                    var argmsWordDoc12 = WordDoc;
                                    ReplaceText(ref argmsWordDoc12, wordField.Value, Helper.MakeStringValid(Strings.Format(engv.Rows[0]["StartDateTime"], "dd/MM/yyyy")));
                                    break;
                                }

                            case var case14 when case14 == "[date2]".ToLower():
                                {
                                    var argmsWordDoc13 = WordDoc;
                                    ReplaceText(ref argmsWordDoc13, wordField.Value, Helper.MakeStringValid(Strings.Format(engv.Rows[0]["StartDateTime"], "dd/MM/yyyy")));
                                    break;
                                }

                            case var case15 when case15 == "[outcome]".ToLower():
                                {
                                    var argmsWordDoc14 = WordDoc;
                                    ReplaceText(ref argmsWordDoc14, wordField.Value, Helper.MakeStringValid(App.DB.Picklists.Get_One_As_Object(add.Test124).Name));
                                    break;
                                }

                            case var case16 when case16 == "[add]".ToLower():
                                {
                                    string strings = address.Address1 + ", " + Constants.vbNewLine + address.Address2 + ", " + Constants.vbNewLine + Helper.FormatPostcode(address.Postcode);
                                    var argmsWordDoc15 = WordDoc;
                                    ReplaceText(ref argmsWordDoc15, wordField.Value, Helper.MakeStringValid(strings));
                                    break;
                                }

                            case var case17 when case17 == "[Make]".ToLower():
                                {
                                    var argmsWordDoc16 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc16, wordField.Value, add.Test235);
                                    break;
                                }

                            case var case18 when case18 == "[Model]".ToLower():
                                {
                                    var argmsWordDoc17 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc17, wordField.Value, add.Test236);
                                    break;
                                }

                            case var case19 when case19 == "[1]".ToLower():
                                {
                                    var argmsWordDoc18 = WordDoc;
                                    ReplaceText(ref argmsWordDoc18, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test1).Name);
                                    break;
                                }

                            case var case20 when case20 == "[2]".ToLower():
                                {
                                    var argmsWordDoc19 = WordDoc;
                                    ReplaceText(ref argmsWordDoc19, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test2).Name);
                                    break;
                                }

                            case var case21 when case21 == "[3]".ToLower():
                                {
                                    var argmsWordDoc20 = WordDoc;
                                    ReplaceText(ref argmsWordDoc20, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test3).Name);
                                    break;
                                }

                            case var case22 when case22 == "[4]".ToLower():
                                {
                                    var argmsWordDoc21 = WordDoc;
                                    ReplaceText(ref argmsWordDoc21, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test4).Name);
                                    break;
                                }

                            case var case23 when case23 == "[5]".ToLower():
                                {
                                    var argmsWordDoc22 = WordDoc;
                                    ReplaceText(ref argmsWordDoc22, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test5).Name);
                                    break;
                                }

                            case var case24 when case24 == "[6]".ToLower():
                                {
                                    var argmsWordDoc23 = WordDoc;
                                    ReplaceText(ref argmsWordDoc23, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test6).Name);
                                    break;
                                }

                            case var case25 when case25 == "[7]".ToLower():
                                {
                                    var argmsWordDoc24 = WordDoc;
                                    ReplaceText(ref argmsWordDoc24, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test7).Name);
                                    break;
                                }

                            case var case26 when case26 == "[8]".ToLower():
                                {
                                    var argmsWordDoc25 = WordDoc;
                                    ReplaceText(ref argmsWordDoc25, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test8).Name);
                                    break;
                                }

                            case var case27 when case27 == "[9]".ToLower():
                                {
                                    var argmsWordDoc26 = WordDoc;
                                    ReplaceText(ref argmsWordDoc26, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test9).Name);
                                    break;
                                }

                            case var case28 when case28 == "[10]".ToLower():
                                {
                                    var argmsWordDoc27 = WordDoc;
                                    ReplaceText(ref argmsWordDoc27, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test10).Name);
                                    break;
                                }

                            case var case29 when case29 == "[1a]".ToLower():
                                {
                                    var argmsWordDoc28 = WordDoc;
                                    ReplaceText(ref argmsWordDoc28, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test111).Name);
                                    break;
                                }

                            case var case30 when case30 == "[2a]".ToLower():
                                {
                                    var argmsWordDoc29 = WordDoc;
                                    ReplaceText(ref argmsWordDoc29, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test2).Name);
                                    break;
                                }

                            case var case31 when case31 == "[3a]".ToLower():
                                {
                                    var argmsWordDoc30 = WordDoc;
                                    ReplaceText(ref argmsWordDoc30, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test3).Name);
                                    break;
                                }

                            case var case32 when case32 == "[4a]".ToLower():
                                {
                                    var argmsWordDoc31 = WordDoc;
                                    ReplaceText(ref argmsWordDoc31, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test4).Name);
                                    break;
                                }

                            case var case33 when case33 == "[5a]".ToLower():
                                {
                                    var argmsWordDoc32 = WordDoc;
                                    ReplaceText(ref argmsWordDoc32, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test5).Name);
                                    break;
                                }

                            case var case34 when case34 == "[6a]".ToLower():
                                {
                                    var argmsWordDoc33 = WordDoc;
                                    ReplaceText(ref argmsWordDoc33, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test6).Name);
                                    break;
                                }

                            case var case35 when case35 == "[7a]".ToLower():
                                {
                                    var argmsWordDoc34 = WordDoc;
                                    ReplaceText(ref argmsWordDoc34, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test7).Name);
                                    break;
                                }

                            case var case36 when case36 == "[8a]".ToLower():
                                {
                                    var argmsWordDoc35 = WordDoc;
                                    ReplaceText(ref argmsWordDoc35, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test8).Name);
                                    break;
                                }

                            case var case37 when case37 == "[9a]".ToLower():
                                {
                                    var argmsWordDoc36 = WordDoc;
                                    ReplaceText(ref argmsWordDoc36, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test9).Name);
                                    break;
                                }

                            case var case38 when case38 == "[10a]".ToLower():
                                {
                                    var argmsWordDoc37 = WordDoc;
                                    ReplaceText(ref argmsWordDoc37, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test10).Name);
                                    break;
                                }

                            case var case39 when case39 == "[11]".ToLower():
                                {
                                    var argmsWordDoc38 = WordDoc;
                                    ReplaceText(ref argmsWordDoc38, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test111).Name);
                                    break;
                                }

                            case var case40 when case40 == "[12]".ToLower():
                                {
                                    var argmsWordDoc39 = WordDoc;
                                    ReplaceText(ref argmsWordDoc39, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test112).Name);
                                    break;
                                }

                            case var case41 when case41 == "[13]".ToLower():
                                {
                                    var argmsWordDoc40 = WordDoc;
                                    ReplaceText(ref argmsWordDoc40, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test113).Name);
                                    break;
                                }

                            case var case42 when case42 == "[14]".ToLower():
                                {
                                    var argmsWordDoc41 = WordDoc;
                                    ReplaceText(ref argmsWordDoc41, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test114).Name);
                                    break;
                                }

                            case var case43 when case43 == "[15]".ToLower():
                                {
                                    var argmsWordDoc42 = WordDoc;
                                    ReplaceText(ref argmsWordDoc42, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test115).Name);
                                    break;
                                }

                            case var case44 when case44 == "[16]".ToLower():
                                {
                                    var argmsWordDoc43 = WordDoc;
                                    ReplaceText(ref argmsWordDoc43, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test116).Name);
                                    break;
                                }

                            case var case45 when case45 == "[17]".ToLower():
                                {
                                    var argmsWordDoc44 = WordDoc;
                                    ReplaceText(ref argmsWordDoc44, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test117).Name);
                                    break;
                                }

                            case var case46 when case46 == "[18]".ToLower():
                                {
                                    var argmsWordDoc45 = WordDoc;
                                    ReplaceText(ref argmsWordDoc45, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test118).Name);
                                    break;
                                }

                            case var case47 when case47 == "[19]".ToLower():
                                {
                                    var argmsWordDoc46 = WordDoc;
                                    ReplaceText(ref argmsWordDoc46, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test119).Name);
                                    break;
                                }

                            case var case48 when case48 == "[20]".ToLower():
                                {
                                    var argmsWordDoc47 = WordDoc;
                                    ReplaceText(ref argmsWordDoc47, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test120).Name);
                                    break;
                                }

                            case var case49 when case49 == "[21]".ToLower():
                                {
                                    var argmsWordDoc48 = WordDoc;
                                    ReplaceText(ref argmsWordDoc48, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test121).Name);
                                    break;
                                }

                            case var case50 when case50 == "[22]".ToLower():
                                {
                                    var argmsWordDoc49 = WordDoc;
                                    ReplaceText(ref argmsWordDoc49, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test122).Name);
                                    break;
                                }

                            case var case51 when case51 == "[23]".ToLower():
                                {
                                    var argmsWordDoc50 = WordDoc;
                                    ReplaceText(ref argmsWordDoc50, wordField.Value, App.DB.Picklists.Get_One_As_Object(add.Test123).Name);
                                    break;
                                }

                            case var case52 when case52 == "[c1]".ToLower():
                                {
                                    var argmsWordDoc51 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc51, wordField.Value, add.Test11);
                                    break;
                                }

                            case var case53 when case53 == "[c2]".ToLower():
                                {
                                    var argmsWordDoc52 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc52, wordField.Value, add.Test12);
                                    break;
                                }

                            case var case54 when case54 == "[c3]".ToLower():
                                {
                                    var argmsWordDoc53 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc53, wordField.Value, add.Test13);
                                    break;
                                }

                            case var case55 when case55 == "[c4]".ToLower():
                                {
                                    var argmsWordDoc54 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc54, wordField.Value, add.Test14);
                                    break;
                                }

                            case var case56 when case56 == "[c5]".ToLower():
                                {
                                    var argmsWordDoc55 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc55, wordField.Value, add.Test15);
                                    break;
                                }

                            case var case57 when case57 == "[c6]".ToLower():
                                {
                                    var argmsWordDoc56 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc56, wordField.Value, add.Test216);
                                    break;
                                }

                            case var case58 when case58 == "[c7]".ToLower():
                                {
                                    var argmsWordDoc57 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc57, wordField.Value, add.Test217);
                                    break;
                                }

                            case var case59 when case59 == "[c8]".ToLower():
                                {
                                    var argmsWordDoc58 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc58, wordField.Value, add.Test218);
                                    break;
                                }

                            case var case60 when case60 == "[c9]".ToLower():
                                {
                                    var argmsWordDoc59 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc59, wordField.Value, add.Test219);
                                    break;
                                }

                            case var case61 when case61 == "[c10]".ToLower():
                                {
                                    var argmsWordDoc60 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc60, wordField.Value, add.Test220);
                                    break;
                                }

                            case var case62 when case62 == "[c11]".ToLower():
                                {
                                    var argmsWordDoc61 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc61, wordField.Value, add.Test221);
                                    break;
                                }

                            case var case63 when case63 == "[c12]".ToLower():
                                {
                                    var argmsWordDoc62 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc62, wordField.Value, add.Test222);
                                    break;
                                }

                            case var case64 when case64 == "[c13]".ToLower():
                                {
                                    var argmsWordDoc63 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc63, wordField.Value, add.Test223);
                                    break;
                                }

                            case var case65 when case65 == "[c14]".ToLower():
                                {
                                    var argmsWordDoc64 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc64, wordField.Value, add.Test224);
                                    break;
                                }

                            case var case66 when case66 == "[c15]".ToLower():
                                {
                                    var argmsWordDoc65 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc65, wordField.Value, add.Test225);
                                    break;
                                }

                            case var case67 when case67 == "[c16]".ToLower():
                                {
                                    var argmsWordDoc66 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc66, wordField.Value, add.Test226);
                                    break;
                                }

                            case var case68 when case68 == "[c17]".ToLower():
                                {
                                    var argmsWordDoc67 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc67, wordField.Value, add.Test227);
                                    break;
                                }

                            case var case69 when case69 == "[c18]".ToLower():
                                {
                                    var argmsWordDoc68 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc68, wordField.Value, add.Test228);
                                    break;
                                }

                            case var case70 when case70 == "[c19]".ToLower():
                                {
                                    var argmsWordDoc69 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc69, wordField.Value, add.Test229);
                                    break;
                                }

                            case var case71 when case71 == "[c20]".ToLower():
                                {
                                    var argmsWordDoc70 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc70, wordField.Value, add.Test230);
                                    break;
                                }

                            case var case72 when case72 == "[c21]".ToLower():
                                {
                                    var argmsWordDoc71 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc71, wordField.Value, add.Test231);
                                    break;
                                }

                            case var case73 when case73 == "[c22]".ToLower():
                                {
                                    var argmsWordDoc72 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc72, wordField.Value, add.Test232);
                                    break;
                                }

                            case var case74 when case74 == "[c23]".ToLower():
                                {
                                    var argmsWordDoc73 = WordDoc;
                                    Printing.ReplaceText(ref argmsWordDoc73, wordField.Value, add.Test233);
                                    break;
                                }
                        }
                    }

                    if (engv.Rows[0]["EngineerSignature"] is object)
                    {
                        byte[] es = (byte[])engv.Rows[0]["EngineerSignature"];
                        var engSig = new Bitmap(new MemoryStream(es));
                        engSig.Save(Application.StartupPath + @"\TEMP\EngSig.bmp");
                        var worksheetType = Convert.ToInt32(((ArrayList)DetailsToPrint)[1]);
                        if (worksheetType != (int)Enums.AdditionalChecksTypes.ElectricalAudit)
                        {
                            WordDoc.Bookmarks["asig"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\Temp\EngSig.bmp");
                        }
                    }

                    if (engv.Rows[0]["CustomerSignature"] is object)
                    {
                        byte[] cs = (byte[])engv.Rows[0]["CustomerSignature"];
                        var custSig = new Bitmap(new MemoryStream(cs));
                        custSig.Save(Application.StartupPath + @"\TEMP\CustSig.bmp");

                        var worksheetType = Convert.ToInt32(((ArrayList)DetailsToPrint)[1]);
                        if (worksheetType != (int)Enums.AdditionalChecksTypes.ElectricalAudit)
                        {
                            WordDoc.Bookmarks["esig"].Range.InlineShapes.AddPicture(Application.StartupPath + @"\Temp\CustSig.bmp");
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateContractExpiry(DataRow dr, int tblIndex)
            {
                try
                {
                    foreach (Match wordField in Printing.GetTemplateFields(WordDoc.Content.Text))
                    {
                        var switchExpr = wordField.Value.ToLower();
                        switch (switchExpr)
                        {
                            case var @case when @case == "[Address1]".ToLower():
                                {
                                    var argmsWordDoc = WordDoc;
                                    ReplaceText(ref argmsWordDoc, wordField.Value, Helper.MakeStringValid(dr["Address1"]));
                                    break;
                                }

                            case var case1 when case1 == "[Address2]".ToLower():
                                {
                                    var argmsWordDoc1 = WordDoc;
                                    ReplaceText(ref argmsWordDoc1, wordField.Value, Helper.MakeStringValid(dr["Address2"]));
                                    break;
                                }

                            case var case2 when case2 == "[Address3]".ToLower():
                                {
                                    var argmsWordDoc2 = WordDoc;
                                    ReplaceText(ref argmsWordDoc2, wordField.Value, Helper.MakeStringValid(dr["Address3"]));
                                    break;
                                }

                            case var case3 when case3 == "[Address4]".ToLower():
                                {
                                    var argmsWordDoc3 = WordDoc;
                                    ReplaceText(ref argmsWordDoc3, wordField.Value, Helper.MakeStringValid(dr["Address4"]));
                                    break;
                                }

                            case var case4 when case4 == "[Address5]".ToLower():
                                {
                                    var argmsWordDoc4 = WordDoc;
                                    ReplaceText(ref argmsWordDoc4, wordField.Value, Helper.MakeStringValid(dr["Address5"]));
                                    break;
                                }

                            case var case5 when case5 == "[Postcode]".ToLower():
                                {
                                    var argmsWordDoc5 = WordDoc;
                                    ReplaceText(ref argmsWordDoc5, wordField.Value, Helper.FormatPostcode(dr["Postcode"]));
                                    break;
                                }

                            case var case6 when case6 == "[Date]".ToLower():
                                {
                                    var argmsWordDoc6 = WordDoc;
                                    ReplaceText(ref argmsWordDoc6, wordField.Value, Strings.Format(DateAndTime.Now, "dd/MM/yyyy"));
                                    break;
                                }

                            case var case7 when case7 == "[CompanyName]".ToLower():
                                {
                                    var argmsWordDoc7 = WordDoc;
                                    ReplaceText(ref argmsWordDoc7, wordField.Value, Helper.MakeStringValid(dr["Name"]));
                                    break;
                                }

                            case var case8 when case8 == "[ExpiryDate]".ToLower():
                                {
                                    var argmsWordDoc8 = WordDoc;
                                    ReplaceText(ref argmsWordDoc8, wordField.Value, Strings.Format(Helper.MakeDateTimeValid(dr["ContractEndDate"]), "dd/MM/yyyy"));
                                    break;
                                }

                            case var case9 when case9 == "[user]".ToLower():
                                {
                                    var argmsWordDoc9 = WordDoc;
                                    ReplaceText(ref argmsWordDoc9, wordField.Value, App.loggedInUser.Fullname);
                                    break;
                                }

                            case var case10 when case10 == "[ContractType]".ToLower():
                                {
                                    var argmsWordDoc10 = WordDoc;
                                    ReplaceText(ref argmsWordDoc10, wordField.Value, Helper.MakeStringValid(dr["ContractType"]));
                                    break;
                                }

                            case var case11 when case11 == "[ContractReference]".ToLower():
                                {
                                    var argmsWordDoc11 = WordDoc;
                                    ReplaceText(ref argmsWordDoc11, wordField.Value, Helper.MakeStringValid(dr["ContractReference"]));
                                    break;
                                }

                            case var case12 when case12 == "[SiteAddress1]".ToLower():
                                {
                                    var argmsWordDoc12 = WordDoc;
                                    ReplaceText(ref argmsWordDoc12, wordField.Value, Helper.MakeStringValid(dr["SiteAddress1"]));
                                    break;
                                }

                            case var case13 when case13 == "[PriceSentence]".ToLower():
                                {
                                    string strSentence = "";
                                    strSentence = App.DB.Picklists.Get_Single_Description(Conversions.ToString(dr["ContractType"]), Enums.PickListTypes.ContractPricing);
                                    var argmsWordDoc13 = WordDoc;
                                    ReplaceText(ref argmsWordDoc13, wordField.Value, strSentence);
                                    break;
                                }

                            case var case14 when case14 == "[ExcludeSentence]".ToLower():
                                {
                                    string strSentence = "";
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["ContractType"], "Gold Star", false) | Operators.ConditionalCompareObjectEqual(dr["ContractType"], "Platinum Star", false)))
                                    {
                                        strSentence = "Please be advised that we are now offering cover for boilermates or any other make of thermal store product as an additional appliance. Should you have a thermal store product";
                                    }
                                    // in your property and require cover, this could be added for an additional £109.34 per annum

                                    var argmsWordDoc14 = WordDoc;
                                    ReplaceText(ref argmsWordDoc14, wordField.Value, strSentence);
                                    break;
                                }

                            case var case15 when case15 == "[ExcludeSentence2]".ToLower():
                                {
                                    string strSentence = "";
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["ContractType"], "Gold Star", false)))
                                        strSentence = " in your property and require cover, this could be added for an additional " + Strings.Format(Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", (Enums.PickListTypes)52)), "C") + " per annum.";
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["ContractType"], "Platinum Star", false)))
                                        strSentence = " in your property and require cover, this could be added for an additional " + Strings.Format(Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52)), "C") + " per annum.";
                                    var argmsWordDoc15 = WordDoc;
                                    ReplaceText(ref argmsWordDoc15, wordField.Value, strSentence);
                                    break;
                                }

                            case var case16 when case16 == "[AHE]".ToLower():
                                {
                                    string strSentence = App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52);
                                    var argmsWordDoc16 = WordDoc;
                                    ReplaceText(ref argmsWordDoc16, wordField.Value, strSentence);
                                    break;
                                }
                        }
                    }
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            AddCompanyDetails(wordDoc, true);
                        }
                    }

                    var withBlock = WordDoc.Tables[tblIndex];
                    if (Helper.MakeBooleanValid(dr["DirectDebit"]) == true)
                    {
                        withBlock.Cell(2, 1).Delete();
                    }
                    else
                    {
                        withBlock.Cell(1, 1).Delete();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateDomesticGSRDue(DataRow[] dr, DataTable dtPrinted, string savePath, WordprocessingDocument batch = null)
            {
                try
                {
                    string template = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\GSRDue.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr[0]["SiteID"]));
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            var currentContract = App.DB.ContractOriginal.Get_Current_ForSite(Conversions.ToInteger(dr[0]["SiteID"]));
                            if (currentContract is null)
                            {
                                PrintHelper.DeleteBookmark(wordDoc, "OnContract1");
                                PrintHelper.DeleteBookmark(wordDoc, "StarMainMessage");
                                var dvOnContractAppliances = App.DB.Asset.Asset_GetForSite(Conversions.ToInteger(dr[0]["SiteID"]));
                                var dt = new DataTable();
                                dt.Columns.Add("Appliance");
                                foreach (DataRowView ddr in dvOnContractAppliances)
                                {
                                    if (Helper.MakeBooleanValid(ddr["Active"]))
                                    {
                                        DataRow nr;
                                        nr = dt.NewRow();
                                        nr["Appliance"] = ddr["Product"];
                                        dt.Rows.Add(nr);
                                    }
                                }

                                PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                                if (dt.Rows.Count > 0)
                                    PrintHelper.ReplaceBookmarkWithTable(wordDoc, "ApplianceTable", dt);
                                PrintHelper.ReplaceText(wordDoc, "[ContractCover]", "If you would like us to carry out your annual service and/or to discuss our Maintenance Cover further, please call us on 01603 309599.");
                            }
                            else
                            {
                                var dvOnContractAppliances = App.DB.ContractOriginal.ContractOriginalSiteAsset_GetAll_SiteID(Conversions.ToInteger(dr[0]["SiteID"]));
                                var dt = new DataTable();
                                dt.Columns.Add("Appliance");
                                foreach (DataRowView ddr in dvOnContractAppliances)
                                {
                                    DataRow nr;
                                    nr = dt.NewRow();
                                    nr["Appliance"] = ddr["Appliance"];
                                    dt.Rows.Add(nr);
                                }

                                if (dt.Rows.Count > 0)
                                    PrintHelper.ReplaceBookmarkWithTable(wordDoc, "ApplianceTable", dt);
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract1");
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract2");
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract3");
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract4");
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract5");
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract6");
                                PrintHelper.DeleteBookmark(wordDoc, "OffContract7");
                                PrintHelper.ReplaceText(wordDoc, "[ContractCover]", "If you would like us to carry out your annual service please call us on 01603 309590.");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[Tenant]", Helper.MakeStringValid(dr[0]["Tenant"]));
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", Conversions.ToString(dr[0]["Address1"]));
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", Conversions.ToString(dr[0]["Address2"]));
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", Conversions.ToString(dr[0]["Address3"]));
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(dr[0]["Postcode"]));
                            PrintHelper.ReplaceText(wordDoc, "[Date]", DateAndTime.Now.ToShortDateString());
                            PrintHelper.ReplaceText(wordDoc, "[NextServiceDate]", Strings.Format(Helper.MakeDateTimeValid(dr[0]["VisitDate"]).AddYears(1), "dd/MM/yyyy"));
                            wordDoc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), wordDoc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            wordDoc.MainDocumentPart.Document.Save();
                        }

                        savePath = FileCheck(savePath);
                        var fileStream = new FileStream(savePath, FileMode.CreateNew);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                        foreach (DataRow r in dr)
                        {
                            var ar = dtPrinted.NewRow();
                            ar["AssetID"] = r["AssetID"];
                            ar["DateDue"] = r["DueDate"];
                            dtPrinted.Rows.Add(ar);
                        }

                        if (batch is object)
                        {
                            var mainPart = batch.MainDocumentPart;
                            string altChunkId = "AltId" + Helper.MakeIntegerValid(dr[0]["SiteID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                            var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            mm.Position = 0;
                            using (mm)
                                chunk.FeedData(mm);
                            var altChunk = new WP.AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                            mainPart.Document.Save();
                        }
                        else
                        {
                            Process.Start(savePath);
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateLLGSRDue(DataRow[] dr, DataTable dtPrinted, string savePath, WordprocessingDocument batch = null)
            {
                try
                {
                    string template = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\GSRDueLL.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr[0]["SiteID"]));
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            var dt = new DataTable();
                            dt.Columns.Add("Property");
                            dt.Columns.Add("Service Due Date");
                            dt.Columns.Add("Appliance");
                            int lastSiteId = 0;
                            foreach (DataRow r in dr)
                            {
                                DataRow nr;
                                nr = dt.NewRow();
                                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(lastSiteId, r["SiteID"], false)))
                                    nr["Property"] = Conversions.ToString(Conversions.ToString(r["Tenant"] + ", ") + r["Address1"] + ", ") + r["Address2"] + ", " + Helper.FormatPostcode(r["Postcode"]);
                                nr["Service Due Date"] = Strings.Format(Helper.MakeDateTimeValid(r["DueDate"]).AddYears(1), "dd-MMM-yyyy");
                                nr["Appliance"] = r["Appliance"];
                                dt.Rows.Add(nr);
                                lastSiteId = Conversions.ToInteger(r["SiteID"]);
                            }

                            PrintHelper.ReplaceBookmarkWithTable(wordDoc, "SitesAndAppliances", dt);
                            var selHQ = App.DB.Sites.Get(dr[0]["CustomerID"], Sites.SiteSQL.GetBy.CustomerHq);
                            if (selHQ is null)
                                return false;
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[CustomerName]", Helper.MakeStringValid(dr[0]["CustomerName"]));
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", selHQ.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", selHQ.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", selHQ.Address3);
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(selHQ.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[Date]", DateAndTime.Now.ToShortDateString());
                            wordDoc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), wordDoc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            wordDoc.MainDocumentPart.Document.Save();
                        }

                        savePath = FileCheck(savePath);
                        var fileStream = new FileStream(savePath, FileMode.CreateNew);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                        foreach (DataRow r in dr)
                        {
                            var ar = dtPrinted.NewRow();
                            ar["AssetID"] = r["AssetID"];
                            ar["DateDue"] = r["DueDate"];
                            dtPrinted.Rows.Add(ar);
                        }

                        if (batch is object)
                        {
                            var mainPart = batch.MainDocumentPart;
                            string altChunkId = "AltId" + Helper.MakeIntegerValid(dr[0]["SiteID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                            var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            mm.Position = 0;
                            using (mm)
                                chunk.FeedData(mm);
                            var altChunk = new WP.AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                            mainPart.Document.Save();
                        }
                        else
                        {
                            Process.Start(savePath);
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GSR(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, DataView dvFaults, bool printHeader, DataView GSRS, string template, string savePath, Enums.WorksheetFuelTypes Fuel, string goldenRule, List<byte[]> fullDocument = null, bool NCCTemplate = false)
            {
                try
                {
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    int imageIndex = 100;
                    var oSiteHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = oEngineerVisit.ManualEntryOn;
                    }

                    int noOfRowsPerPage = 4; // as most pages have 4
                    switch (Fuel)
                    {
                        case Enums.WorksheetFuelTypes.Unvented:
                            {
                                noOfRowsPerPage = 12;
                                break;
                            }

                        case Enums.WorksheetFuelTypes.Oil:
                            {
                                noOfRowsPerPage = 1;
                                break;
                            }

                        default:
                            {
                                noOfRowsPerPage = 4;
                                break;
                            }
                    }

                    var pageNumbers = new List<int>();
                    pageNumbers.Add(Conversions.ToInteger(Math.Ceiling(GSRS.Table.Rows.Count / (double)noOfRowsPerPage)));
                    int pages = pageNumbers.Max();
                    if (pages < 1)
                        pages = 1;
                    try
                    {
                        // gsr
                        for (int page = 1, loopTo = pages; page <= loopTo; page++)
                        {
                            int lowAppIndex = page * noOfRowsPerPage - noOfRowsPerPage;
                            int highAppIndex = page * noOfRowsPerPage;
                            byte[] finaldoc = null;
                            var byteArray = File.ReadAllBytes(template);
                            var mm = new MemoryStream();
                            using (mm)
                            {
                                mm.Write(byteArray, 0, byteArray.Length);
                                var wordDoc = WordprocessingDocument.Open(mm, true);
                                using (wordDoc)
                                {
                                    PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                                    if (engineer is null)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", "");
                                    }
                                    else if (Fuel == Enums.WorksheetFuelTypes.Oil)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", engineer.OftecNo);
                                    }
                                    else
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", engineer.GasSafeNo);
                                    }

                                    string uid = oEngineerVisit.EngineerVisitID + "_" + DateAndTime.Now.ToString("ddMMyyyyhhmm") + "_" + Fuel.ToString().ToUpper();
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobSiteName", oSite.Name.Replace("T1", "").Trim(), "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress1", oSite.Address1, "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress2", oSite.Address2, "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress3", oSite.Address3, "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobPostCode", Helper.FormatPostcode(oSite.Postcode), "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate", uid, "6", true);
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate1", visitDate.ToLongDateString());
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate2", visitDate.ToLongDateString());
                                    AddCompanyDetails(wordDoc, true);
                                    if (oEngineerVisit.GasServiceCompleted == true & oEngineerVisit.OutcomeEnumID != (int)Enums.EngineerVisitOutcomes.Complete)
                                    {
                                        var customer = App.DB.Customer.Customer_Get_ForSiteID(oSite.SiteID);
                                        bool motstyle = false;
                                        if (customer is object && customer.MOTStyleService == true)
                                            motstyle = true;
                                        DateTime actualServiceDate;
                                        if (oEngineerVisit.StartDateTime == DateTime.MinValue)
                                        {
                                            if (oEngineerVisit.TimeSheets.Table.Rows.Count > 0)
                                            {
                                                actualServiceDate = Conversions.ToDate(oEngineerVisit.TimeSheets.Table.Rows[0]["StartDateTime"]);
                                            }
                                            else
                                            {
                                                actualServiceDate = DateAndTime.Now;
                                            }
                                        }
                                        else
                                        {
                                            actualServiceDate = oEngineerVisit.StartDateTime;
                                        }

                                        DateTime oldLastServiceDate = default;
                                        DateTime lastServiceDate = default;
                                        // update all

                                        oldLastServiceDate = Helper.MakeDateTimeValid(oSite.LastServiceDate);
                                        int sfServiceDiff = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Month, actualServiceDate, oldLastServiceDate.AddYears(1)));
                                        if (oldLastServiceDate.AddYears(1) > actualServiceDate & sfServiceDiff >= 0 & sfServiceDiff <= 2 & motstyle)
                                        {
                                            lastServiceDate = oldLastServiceDate.AddYears(1);
                                        }
                                        else
                                        {
                                            lastServiceDate = actualServiceDate;
                                        }

                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", lastServiceDate.AddYears(1).ToLongDateString());
                                    }
                                    else if (oEngineerVisit.GasServiceCompleted == true & oEngineerVisit.OutcomeEnumID == (int)Enums.EngineerVisitOutcomes.Complete & oEngineerVisit.VisitLocked)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", oSite.LastServiceDate.AddYears(1).ToLongDateString());
                                    }
                                    else
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", visitDate.AddYears(1).ToLongDateString());
                                    }

                                    var selected = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.SignatureSelectedID);
                                    if (selected is null)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "JobCustomerName", oEngineerVisit.CustomerName);
                                    }
                                    else
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "JobCustomerName", oEngineerVisit.CustomerName + " (" + selected.Name + ")");
                                    }

                                    if (oSiteHQ is object)
                                    {
                                        string strAddress = string.Empty;
                                        if (oSiteHQ.Address1.Length > 0)
                                        {
                                            strAddress += oSiteHQ.Address1 + ", ";
                                        }

                                        if (oSiteHQ.Address2.Length > 0)
                                        {
                                            strAddress += oSiteHQ.Address2 + ", ";
                                        }

                                        if (strAddress.Length > 0)
                                        {
                                            strAddress = strAddress.Substring(0, strAddress.Length - 2);
                                        }

                                        string strAddress1 = string.Empty;
                                        if (oSiteHQ.Address3.Length > 0)
                                        {
                                            strAddress1 += oSiteHQ.Address3 + ", ";
                                        }

                                        if (oSiteHQ.Address4.Length > 0)
                                        {
                                            strAddress1 += oSiteHQ.Address4 + ", ";
                                        }

                                        if (oSiteHQ.Address5.Length > 0)
                                        {
                                            strAddress1 += oSiteHQ.Address5 + ", ";
                                        }

                                        if (strAddress.Length > 0 & strAddress1.Length > 1)
                                        {
                                            strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);
                                        }

                                        string customerName = oSiteHQ.CustomerID != (int)Enums.Customer.Domestic ? App.DB.Customer.Customer_Get(oSite.CustomerID).Name : "";
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", customerName, "8");
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress1", strAddress, "8");
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress2", strAddress1, "8");
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LLPostcode", Helper.FormatPostcode(oSiteHQ.Postcode), "8");
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LLTelNo", oSiteHQ.TelephoneNum, "8");
                                    }
                                    else
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", "");
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress1", "");
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress2", "");
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LLPostcode", "");
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "LLTelNo", "");
                                    }

                                    var propRented = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.PropertyRented);
                                    if (propRented is null)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rented", "");
                                    }
                                    else
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rented", propRented.Name, "8");
                                    }

                                    if (engineer is null)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", "");
                                    }
                                    else
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", engineer.Name);
                                    }

                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustomerName", oEngineerVisit.CustomerName);
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "OtherNotes", oEngineerVisit.OutcomeDetails);
                                    switch (Fuel)
                                    {
                                        case Enums.WorksheetFuelTypes.Gas:
                                        case Enums.WorksheetFuelTypes.Oil:
                                        case Enums.WorksheetFuelTypes.Other:
                                        case Enums.WorksheetFuelTypes.Unvented:
                                            {
                                                if (GSRS.Table.Rows.Count == 0)
                                                {
                                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", "0", "8");
                                                }
                                                else
                                                {
                                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", GSRS.Table.Select("ApplianceTested='Yes'").Length.ToString(), "8");
                                                }

                                                break;
                                            }

                                        default:
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", GSRS.Table.Rows.Count.ToString(), "8");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "NumInspected", GSRS.Table.Rows.Count.ToString(), "8");
                                                break;
                                            }
                                    }

                                    var COMO = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.COMOAlarm);
                                    var SMOKE = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.SmokeAlarm);
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "COMO", COMO.Count.ToString());
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "SMOKE", SMOKE.Count.ToString());
                                    if (Fuel == Enums.WorksheetFuelTypes.Gas)
                                    {
                                        var ecv = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.EmergencyControlAccessibleID);
                                        if (ecv is null)
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "ECV", "");
                                        }
                                        else
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "ECV", ecv.Name);
                                        }

                                        var tightest = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.GasInstallationTightnessTestID);
                                        if (tightest is null)
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "tightest", "");
                                        }
                                        else
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "tightest", tightest.Name);
                                        }

                                        var bonding = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.BondingID);
                                        if (bonding is null)
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Bonding", "");
                                        }
                                        else
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Bonding", bonding.Name);
                                        }
                                    }

                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "WorkCarriedOut", oEngineerVisit.OutcomeDetails);
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobVisitNumber", oEngineerVisit.EngineerVisitID.ToString(), "9", true);
                                    if (oEngineerVisit.EngineerSignature is null)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EngineerSignature", "");
                                    }
                                    else
                                    {
                                        var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                        string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                        if (Fuel == Enums.WorksheetFuelTypes.Unvented)
                                        {
                                            PrintHelper.ReplaceBookmarkWithImage(wordDoc, "AJ", engSig, imgSavePath, imageIndex);
                                            imageIndex += 1;
                                        }
                                        else
                                        {
                                            PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngineerSignature", engSig, imgSavePath, imageIndex);
                                            imageIndex += 1;
                                        }
                                    }

                                    if (oEngineerVisit.CustomerSignature is null)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CustomerSignature", "");
                                    }
                                    else
                                    {
                                        var custSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                        string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                        PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustomerSignature", custSig, imgSavePath, imageIndex);
                                        imageIndex += 1;
                                    }

                                    if (GSRS.Table.Rows.Count == 0 || Information.IsDBNull(GSRS.Table.Rows[0]["ReadingType"]))
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafe", "7939");
                                    }
                                    else
                                    {
                                        var switchExpr = Helper.MakeIntegerValid(GSRS.Table.Rows[0]["ReadingType"]);
                                        switch (switchExpr)
                                        {
                                            case 0:
                                                {
                                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafe", "7939");
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafe", "6102");
                                                    break;
                                                }
                                        }
                                    }

                                    byte[] logo = null;
                                    try
                                    {
                                        logo = (byte[])App.DB.ExecuteScalar("Select Logo FROM tblCustomer where CustomerID = " + oSite.CustomerID);
                                    }
                                    catch
                                    {
                                        logo = null;
                                    }

                                    if (logo is object)
                                    {
                                        var custLogo = new Bitmap(new MemoryStream(logo));
                                        string imgSavePath = Application.StartupPath + @"\TEMP\custLogo.jpg";
                                        PrintHelper.ReplaceBookmarkWithImage(wordDoc, "Logo", custLogo, imgSavePath, imageIndex);
                                        imageIndex += 1;
                                    }
                                    else
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Logo", "");
                                    }

                                    if (NCCTemplate)
                                    {
                                        if (oSite.LeaseHold == true)
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "Leaseholder", "8");
                                        }
                                        else
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "Tenanted", "8");
                                        }
                                    }

                                    // TO BE REMOVED AFTER APPROVAL - CONFIRM WITH YF
                                    if (oEngineerVisit.EngineerVisitNCCGSR is object)
                                    {
                                        var dvNccGsr = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_Get_Friendly(oEngineerVisit.EngineerVisitNCCGSR.EngineerVisitNCCGSRID);
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rad", oEngineerVisit.EngineerVisitNCCGSR.Radiators.ToString());
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Age", oEngineerVisit.EngineerVisitNCCGSR.ApproxAgeOfBoiler.ToString());
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info1", Helper.MakeStringValid(dvNccGsr[0]["CorrectMaterialsUsed"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info2", Helper.MakeStringValid(dvNccGsr[0]["InstallationPipeWorkCorrect"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info3", Helper.MakeStringValid(dvNccGsr[0]["InstallationSafeToUse"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SF", Helper.MakeStringValid(dvNccGsr[0]["StrainerFitted"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SI", Helper.MakeStringValid(dvNccGsr[0]["StrainerInspected"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "HST", Helper.MakeStringValid(dvNccGsr[0]["HeatingSystemType"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "PH", Helper.MakeStringValid(dvNccGsr[0]["PartialHeating"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CT", Helper.MakeStringValid(dvNccGsr[0]["CylinderType"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Jack", Helper.MakeStringValid(dvNccGsr[0]["Jacket"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Im", Helper.MakeStringValid(dvNccGsr[0]["Immersion"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CO", Helper.MakeStringValid(dvNccGsr[0]["CODetectorFitted"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "FL", Helper.MakeStringValid(dvNccGsr[0]["FillDisc"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SIT", Helper.MakeStringValid(dvNccGsr[0]["SITimer"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CertType", Helper.MakeStringValid(dvNccGsr[0]["CertificateType"]));
                                    }

                                    if (Fuel != Enums.WorksheetFuelTypes.Unvented)
                                    {
                                        DataTable dtAppliances;
                                        DataTable dtFaults;
                                        try
                                        {
                                            dtAppliances = GSRS.Table.AsEnumerable().Where((row, index) => index >= lowAppIndex & index < highAppIndex).CopyToDataTable();
                                        }
                                        catch (Exception ex)
                                        {
                                            dtAppliances = new DataTable();
                                        }

                                        int lowIndex = page * 2 - 2;
                                        int highIndex = page * 2;
                                        try
                                        {
                                            try
                                            {
                                                List<int> assetIds = (from r in dtAppliances.AsEnumerable() select r.Field<int>("AssetID")).ToList();
                                                var drFaults = dvFaults.Table.AsEnumerable().Where((row, index) => assetIds.Contains((int)row["AssetID"]));
                                                if (drFaults.Any())
                                                {
                                                    dtFaults = drFaults.CopyToDataTable();
                                                }
                                                else
                                                {
                                                    dtFaults = new DataTable();
                                                }

                                                try
                                                {
                                                    var drSiteFaults = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0");
                                                    if (drSiteFaults.Length > 0)
                                                    {
                                                        dtFaults.Merge(drSiteFaults.CopyToDataTable().AsEnumerable().Where((row, index) => index >= lowIndex & index < highIndex).CopyToDataTable());
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    // empty
                                                }
                                            }
                                            // TO BE READDED AFTER APPROVAL -  CONFIRM WITH YF
                                            // If Fuel = Enums.WorksheetFuelTypes.Gas Then
                                            // dtFaults = dtFaults.Select("CategoryID = " & CInt(Enums.DefectCategory.AtRisk) & " OR CategoryID = " & CInt(Enums.DefectCategory.ImmediatelyDangerous)).CopyToDataTable()
                                            // End If
                                            catch (Exception ex)
                                            {
                                                // no assets
                                                dtFaults = new DataTable();
                                                var siteFaults = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0").CopyToDataTable();
                                                dtFaults.Merge(siteFaults.AsEnumerable().Where((row, index) => index >= lowIndex & index < highIndex).CopyToDataTable());
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            dtFaults = new DataTable();
                                        }

                                        int appCount = dtAppliances is object ? dtAppliances.Rows.Count : 0;
                                        AddAppliancesBatch(wordDoc, appCount, dtAppliances, dtFaults, false, Conversions.ToInteger(Fuel));
                                    }

                                    if (Fuel == Enums.WorksheetFuelTypes.Unvented)
                                    {
                                        AddAppliancesBatch(wordDoc, GSRS.Table.Rows.Count, GSRS.Table, dvFaults.Table, false, Conversions.ToInteger(Fuel));
                                        var ad = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.CommercialCateringCP42);
                                        if (ad is object)
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", ad.Test221);
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", ad.Test222);
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", ad.Test223);
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", ad.Test224);
                                        }

                                        string WorkRequest = "";
                                        WorkRequest = oEngineerVisit.NotesToEngineer;
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", WorkRequest);
                                        string WorkResult = "";
                                        WorkResult = oEngineerVisit.NotesFromEngineer;
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", WorkResult);
                                    }
                                }
                            }

                            var docsToMerge = new List<byte[]>();
                            docsToMerge.Add(mm.ToArray());

                            // TO BE READDED AFTER APPROVAL -  CONFIRM WITH YF
                            // If Fuel = Enums.WorksheetFuelTypes.Gas Then
                            // Dim dtCurrentPageFaults As DataTable = New DataTable()
                            // Dim currentAssetIds As List(Of Integer) = GSRS.Table.AsEnumerable().Where(Function(row, index) index >= lowAppIndex And index < highAppIndex)?.Select(Function(x) Helper.MakeIntegerValid(x("AssetID")))?.ToList()
                            // If currentAssetIds?.Count > 0 Then
                            // Dim assetFaults As DataRow() = dvFaults.Table.AsEnumerable().Where(Function(row, index) currentAssetIds.Contains(Helper.MakeStringValid(row("AssetID")))).ToArray()
                            // If assetFaults?.Length > 0 Then dtCurrentPageFaults = assetFaults?.CopyToDataTable()
                            // End If
                            // If page = 1 Then
                            // Dim siteFaults As DataRow() = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0")
                            // If siteFaults?.Length > 0 Then dtCurrentPageFaults.Merge(siteFaults.CopyToDataTable())
                            // End If

                            // docsToMerge.Add(AddLgsrSupplementaryInformation(oEngineerVisit, New DataView(dtCurrentPageFaults), oSite.SiteID, page)?.ToArray())
                            // End If

                            if (printHeader == true & page == pages)
                            {
                                docsToMerge.Add(LsrHeaderLetter(oSite, oSiteHQ, visitDate, null)?.ToArray());
                            }

                            finaldoc = PrintHelper.CombineDocs(docsToMerge);
                            savePath = FileCheck(savePath);
                            if (finaldoc is object)
                            {
                                fullDocument.Add(finaldoc);
                            }
                            else
                            {
                                var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                mm.Position = 0;
                                using (fileStream)
                                    mm.WriteTo(fileStream);
                            }
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                }

                return default;
            }

            public byte[] LsrHeaderLetter(Sites.Site oSite, Sites.Site oSiteHq, DateTime visitDate, MemoryStream mm)
            {
                byte[] finalDoc = null;
                if (oSiteHq is null)
                    oSiteHq = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                string coverLetterTemplate = Application.StartupPath + @"\Templates\GSR\GSRCoveringLetter.docx";
                string cGoldenRule = GetDocumentGoldenRule(coverLetterTemplate, oSite.SiteID);
                var cbyteArray = File.ReadAllBytes(coverLetterTemplate);
                var cmm = new MemoryStream();
                using (cmm)
                {
                    cmm.Write(cbyteArray, 0, cbyteArray.Length);
                    var cwordDoc = WordprocessingDocument.Open(cmm, true);
                    using (cwordDoc)
                    {
                        PrintHelper.ReplaceText(cwordDoc, "[GoldenRule]", cGoldenRule);
                        AddCompanyDetails(cwordDoc, true, false, false);
                        if (oSiteHq.CustomerID == (int)Enums.Customer.Domestic)
                        {
                            PrintHelper.ReplaceText(cwordDoc, "[CustomerName]", "the person(s) responsible for your property");
                        }
                        else
                        {
                            PrintHelper.ReplaceText(cwordDoc, "[CustomerName]", oSiteHq.Name);
                        }

                        PrintHelper.ReplaceText(cwordDoc, "[SiteName]", oSite.Name.Replace("T1", "").Trim());
                        PrintHelper.ReplaceText(cwordDoc, "[Name]", Helper.ToTitleCase(oSite.Name.Replace("T1", "").Trim()));
                        PrintHelper.ReplaceText(cwordDoc, "[Address1]", oSite.Address1);
                        PrintHelper.ReplaceText(cwordDoc, "[Address2]", oSite.Address2);
                        PrintHelper.ReplaceText(cwordDoc, "[Address3]", oSite.Address3);
                        PrintHelper.ReplaceText(cwordDoc, "[Address4]", oSite.Address4);
                        PrintHelper.ReplaceText(cwordDoc, "[Address5]", oSite.Address5);
                        PrintHelper.ReplaceText(cwordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode));
                        PrintHelper.ReplaceText(cwordDoc, "[Date]", DateAndTime.Now.ToShortDateString());
                        PrintHelper.ReplaceText(cwordDoc, "[ServiceDate]", visitDate.ToShortDateString());
                        string telNo = oSiteHq.CustomerID == (int)Enums.Customer.Victory ? "01603 309600" : "01603 258617";
                        PrintHelper.ReplaceText(cwordDoc, "[TelNo]", telNo);
                        var para = cwordDoc.MainDocumentPart.Document.Body.ChildElements.First<WP.Paragraph>();
                        if (para.ParagraphProperties is null)
                        {
                            para.ParagraphProperties = new WP.ParagraphProperties();
                        }

                        para.ParagraphProperties.PageBreakBefore = new WP.PageBreakBefore();
                    }

                    if (mm is object)
                    {
                        var files = new List<MemoryStream>() { mm, cmm };
                        finalDoc = PrintHelper.CombineDocs(files);
                    }
                    else
                    {
                        finalDoc = cmm.ToArray();
                    }
                }

                return finalDoc;
            }

            private int Add_Appliances_PreVisit(WD.Document wordDoc, int numberOfAppliances, int currentPage, int numberOfPages, DataTable Assets, DataTable faults, int nextTableForPrint, bool NCCTemplate = false)
            {
                int numberToReturn = numberOfAppliances;
                int rowNo = 0;
                int actualNo = 0;
                int ApplianceRows = 0;
                if (NCCTemplate)
                {
                    ApplianceRows = 4;
                }
                else
                {
                    ApplianceRows = 4;
                }

                for (int i = numberOfAppliances - 1, loopTo = numberOfAppliances - ApplianceRows; i >= loopTo; i -= 1)
                {
                    rowNo += 1;
                    actualNo += 1;
                    try
                    {
                        string emptyWord = "";
                        // This should be not Appliance Tested - not landlord appliance
                        PickLists.PickList llAppliance;
                        llAppliance = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["ApplianceTestedID"]));
                        if (llAppliance is object)
                        {
                            if ((llAppliance.Name ?? "") == "No")
                            {
                                emptyWord = "Not Tested";
                            }
                        }

                        foreach (Match wordField in Printing.GetTemplateFields(wordDoc.Content.Text))
                        {
                            var switchExpr = wordField.Value;
                            switch (switchExpr)
                            {
                                case var @case when @case == "[" + rowNo.ToString() + "A]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows[i]["Location"]));
                                        break;
                                    }

                                case var case1 when case1 == "[" + rowNo.ToString() + "B]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows[i]["Type"]));
                                        break;
                                    }

                                case var case2 when case2 == "[" + rowNo.ToString() + "C]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows[i]["Make"]));
                                        break;
                                    }

                                case var case3 when case3 == "[" + rowNo.ToString() + "D]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows[i]["Model"]));
                                        break;
                                    }

                                case var case4 when case4 == "[" + rowNo.ToString() + "E]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["LandlordsApplianceID"]));
                                        if (oPicklist.Name is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, "");
                                        }

                                        break;
                                    }

                                case var case5 when case5 == "[" + rowNo.ToString() + "F]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["ApplianceServiceOrInspectedID"]));
                                        if (oPicklist is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case6 when case6 == "[" + rowNo.ToString() + "G]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["ApplianceSafeID"]));
                                        if (oPicklist is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case7 when case7 == "[" + rowNo.ToString() + "H]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["FlueTerminationSatisfactoryID"]));
                                        if (oPicklist is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case8 when case8 == "[" + rowNo.ToString() + "I]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["VisualConditionOfFlueSatisfactoryID"]));
                                        if (oPicklist is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case9 when case9 == "[" + rowNo.ToString() + "J]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["FlueFlowTestID"]));
                                        if (oPicklist is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case10 when case10 == "[" + rowNo.ToString() + "K]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["SpillageTestID"]));
                                        if (oPicklist is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case11 when case11 == "[" + rowNo.ToString() + "L]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["VentilationProvisionSatisfactoryID"]));
                                        if (oPicklist is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case12 when case12 == "[" + rowNo.ToString() + "M]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[i]["SafetyDeviceOperationID"]));
                                        if (oPicklist is object)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case13 when case13 == "[" + rowNo.ToString() + "N]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["InletStaticPressure"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["InletStaticPressure"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case14 when case14 == "[" + rowNo.ToString() + "O]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["InletWorkingPressure"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["InletWorkingPressure"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case15 when case15 == "[" + rowNo.ToString() + "P]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["MinBurnerPressure"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["MinBurnerPressure"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case16 when case16 == "[" + rowNo.ToString() + "Q]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["MaxBurnerPressure"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["MaxBurnerPressure"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case17 when case17 == "[" + rowNo.ToString() + "R]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["CO2"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["CO2"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case18 when case18 == "[" + rowNo.ToString() + "S]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["CO2CORatio"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["CO2CORatio"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case19 when case19 == "[" + rowNo.ToString() + "T]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows[i]["GCNumber"]));
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case20 when case20 == "[" + rowNo.ToString() + "U]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows[i]["SerialNum"]));
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case21 when case21 == "[" + rowNo.ToString() + "V]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["DHWFlowRate"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["DHWFlowRate"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case22 when case22 == "[" + rowNo.ToString() + "W]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["ColdWaterTemp"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["ColdWaterTemp"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }

                                case var case23 when case23 == "[" + rowNo.ToString() + "X]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows[i]["DHWTemp"]) == 0)
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            }
                                            else
                                            {
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows[i]["DHWTemp"]).ToString());
                                            }
                                        }
                                        else
                                        {
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        }

                                        break;
                                    }
                            }
                        }

                        numberToReturn -= 1;
                    }
                    catch (Exception ex)
                    {
                        actualNo -= 1;
                        foreach (Match wordField in Printing.GetTemplateFields(wordDoc.Content.Text))
                        {
                            var switchExpr = wordField.Value;
                            switch (switchExpr)
                            {
                                case var @case when @case == "[" + rowNo.ToString() + "A]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case1 when case1 == "[" + rowNo.ToString() + "B]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case2 when case2 == "[" + rowNo.ToString() + "C]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case3 when case3 == "[" + rowNo.ToString() + "D]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case4 when case4 == "[" + rowNo.ToString() + "E]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case5 when case5 == "[" + rowNo.ToString() + "F]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case6 when case6 == "[" + rowNo.ToString() + "G]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case7 when case7 == "[" + rowNo.ToString() + "H]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case8 when case8 == "[" + rowNo.ToString() + "I]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case9 when case9 == "[" + rowNo.ToString() + "J]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case10 when case10 == "[" + rowNo.ToString() + "K]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case11 when case11 == "[" + rowNo.ToString() + "L]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case12 when case12 == "[" + rowNo.ToString() + "M]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case13 when case13 == "[" + rowNo.ToString() + "N]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case14 when case14 == "[" + rowNo.ToString() + "O]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case15 when case15 == "[" + rowNo.ToString() + "P]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case16 when case16 == "[" + rowNo.ToString() + "Q]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case17 when case17 == "[" + rowNo.ToString() + "R]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case18 when case18 == "[" + rowNo.ToString() + "S]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case19 when case19 == "[" + rowNo.ToString() + "T]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case20 when case20 == "[" + rowNo.ToString() + "U]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case21 when case21 == "[" + rowNo.ToString() + "V]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case22 when case22 == "[" + rowNo.ToString() + "W]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case var case23 when case23 == "[" + rowNo.ToString() + "X]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }
                            }
                        }

                        numberToReturn = 0;
                    }
                }

                return numberToReturn;
            }

            private void AddAppliancesBatch(WordprocessingDocument wordDoc, int numberOfAppliances, DataTable EngineerVisitAssetWorksheets, DataTable faults, bool NCCTemplate = false, int Fuel = 0)
            {
                int noOfApp = numberOfAppliances;
                int rowNo = 0;
                int actualNo = 0;
                int nextFaultRowForPrint = 0;
                int ApplianceRows = 0;
                if (Fuel == (int)Enums.WorksheetFuelTypes.Unvented)
                {
                    ApplianceRows = 12;
                }
                else if (Fuel == (int)Enums.WorksheetFuelTypes.SolidFuel)
                {
                    ApplianceRows = 2;
                }
                else
                {
                    ApplianceRows = 4;
                }

                for (int i = 0, loopTo = ApplianceRows - 1; i <= loopTo; i += 1)
                {
                    if (faults is object)
                    {
                        try
                        {
                            if (faults.Rows.Count == 0 & Fuel == 3)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No");
                            }
                            else
                            {
                                foreach (DataRow faultRow in faults.Select(Conversions.ToString("AssetID = " + EngineerVisitAssetWorksheets.Rows[1]["AssetID"])))
                                {
                                    if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(faultRow["ADDEDTOPRINTOUT"], true, false)))
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AA" + nextFaultRowForPrint, Conversions.ToString(faultRow["FullReason"]).Trim());
                                        if (Fuel == 2 | Fuel == 0 | Fuel == 5 | Fuel == 9 | Fuel == 7)
                                        {
                                            if (Conversions.ToBoolean(faultRow["WarningNoticeIssued"]))
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + nextFaultRowForPrint, "Yes");
                                            }
                                            else
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + nextFaultRowForPrint, "No");
                                            }
                                        }
                                        else if (Fuel == 3)
                                        {
                                            if (Conversions.ToBoolean(faultRow["WarningNoticeIssued"]))
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "Yes");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "Yes");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "Yes");
                                            }
                                            else
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No");
                                            }
                                        }

                                        if (Fuel != 3)
                                        {
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DD" + nextFaultRowForPrint, Conversions.ToString(faultRow["ActionTaken"]));
                                        }

                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CC" + nextFaultRowForPrint, Conversions.ToString(faultRow["Disconnected"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EE" + nextFaultRowForPrint, Conversions.ToString(faultRow["Comments"]));
                                        faultRow["ADDEDTOPRINTOUT"] = true;
                                        if (Fuel == 1)
                                            nextFaultRowForPrint += 1;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    nextFaultRowForPrint += 1;
                    rowNo += 1;
                    actualNo += 1;
                    try
                    {
                        var dvAssetWorksheet = App.DB.EngineerVisitAssetWorkSheet.Get_Friendly(Helper.MakeIntegerValid(EngineerVisitAssetWorksheets.Rows[i]["EngineerVisitAssetWorkSheetID"]));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AAA" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ApplianceTested"]));
                        if (Fuel == (int)Enums.WorksheetFuelTypes.Unvented)
                        {
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Type"]));
                        }
                        else
                        {
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Location"]));
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.Gas:
                            case (int)Enums.WorksheetFuelTypes.Oil:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Type"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Make"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Reading"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Model"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Make"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.HIU:
                            case (int)Enums.WorksheetFuelTypes.ASHP:
                            case (int)Enums.WorksheetFuelTypes.GSHP:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + rowNo.ToString(), Helper.MakeStringValid(Conversions.ToString(dvAssetWorksheet[0]["Model"] + " / ") + dvAssetWorksheet[0]["SerialNum"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["MaxBurnerPressure"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Model"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.Unvented:
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["InletStaticPressure"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["LandlordsAppliance"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["FlueTerminationSatisfactory"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["DHWFlowRate"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ApplianceServiceOrInspected"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["VisualConditionOfFlueSatisfactory"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ColdWaterTemp"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ApplianceSafe"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["FlueFlowTest"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.Unvented:
                            case (int)Enums.WorksheetFuelTypes.ASHP:
                            case (int)Enums.WorksheetFuelTypes.GSHP:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Discharge"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["FlueTerminationSatisfactory"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SpillageTest"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["VisualConditionOfFlueSatisfactory"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                            case (int)Enums.WorksheetFuelTypes.HIU:
                            case (int)Enums.WorksheetFuelTypes.ASHP:
                            case (int)Enums.WorksheetFuelTypes.GSHP:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["VentilationProvisionSatisfactory"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["FlueFlowTest"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SafetyDeviceOperation"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.HIU:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Nozzle"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SpillageTest"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["LandlordsAppliance"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.HIU:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SpillageTest"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["VentilationProvisionSatisfactory"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ApplianceTested"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.HIU:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SpillageTest"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SafetyDeviceOperation"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.Gas:
                            case (int)Enums.WorksheetFuelTypes.Oil:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["InletStaticPressure"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ApplianceServiceOrInspected"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ApplianceSafe"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Overall"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.Gas:
                            case (int)Enums.WorksheetFuelTypes.Oil:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["InletWorkingPressure"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Discharge"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SweepOutcome"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SweepOutcome"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["MinBurnerPressure"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["FlueType"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["MaxBurnerPressure"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["DHWFlowRate"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["CO2"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["BurModel"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["CO2CORatio"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.Gas:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["BurMake"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Overall"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["GCNumber"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.Gas:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["BurModel"]));
                                    break;
                                }

                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ColdWaterTempString"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["SerialNum"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["DHWTempString"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["DHWFlowRate"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["InletWorkingPressureString"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ColdWaterTemp"]));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case (int)Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["MinBurnerPressureString"]));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["DHWTemp"]));
                                    break;
                                }
                        }

                        PrintHelper.ReplaceGSRBookmark(wordDoc, "QQ" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["MinBurnerPressure"]));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "RR" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Nozzle"]));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SS" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["BurMake"]));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "TT" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["BurModel"]));
                        var switchExpr = Helper.MakeIntegerValid(dvAssetWorksheet[0]["TankID"]);
                        switch (switchExpr)
                        {
                            case 0:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + rowNo.ToString(), "N/A");
                                    break;
                                }

                            case 1:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + rowNo.ToString(), "Plastic");
                                    break;
                                }

                            case 2:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + rowNo.ToString(), "Bunded");
                                    break;
                                }

                            case 3:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + rowNo.ToString(), "Metal");
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + rowNo.ToString(), "");
                                    break;
                                }
                        }

                        PrintHelper.ReplaceGSRBookmark(wordDoc, "VV" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["FlueType"]));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "WW" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["GasType"]));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Y" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["ApplianceSafe"]));
                        int warningCount = 0;
                        string warningOutput = "";
                        if (faults?.Rows.Count > 0 == true)
                        {
                            var drWarnings = faults.Select(Conversions.ToString("AssetID = " + dvAssetWorksheet[0]["AssetID"] + " AND WarningNoticeIssued = 1"));
                            if (drWarnings?.Length > 0 == true)
                                warningCount = drWarnings.Length;
                        }

                        if (warningCount > 0)
                        {
                            warningOutput = "Yes";
                        }
                        else
                        {
                            warningOutput = "No";
                        }

                        if (Fuel == (int)Enums.WorksheetFuelTypes.SolidFuel)
                        {
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + rowNo.ToString(), warningOutput);
                        }
                        else
                        {
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + rowNo.ToString(), warningCount.ToString());
                        }

                        if (Fuel == (int)Enums.WorksheetFuelTypes.SolidFuel && rowNo == 1)
                        {
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "KS" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["CO2String"]));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "IS" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["CO2CORatioString"]));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "CL" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["BurMakeString"]));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "IH" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["NozzleString"]));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AF" + rowNo.ToString(), Helper.MakeStringValid(dvAssetWorksheet[0]["Tank"]));
                        }

                        noOfApp -= 1;
                    }
                    catch (Exception ex)
                    {
                        actualNo -= 1;
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AAA" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "QQ" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Y" + rowNo.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + rowNo.ToString(), "");
                        noOfApp = 0;
                    }
                }

                int NewPageCompareNo = 0;
                NewPageCompareNo = 5;
                if (noOfApp == 0)
                {
                    // LETS PUT NONE APPLIANCE DEFECTS IN
                    if (PrintType != Enums.SystemDocumentType.COMSR)
                    {
                        if (faults is object)
                        {
                            try
                            {
                                // For Each faultRow As DataRow In faults.Select("AssetID = 0")
                                foreach (DataRow faultRow in faults.Select("ADDEDTOPRINTOUT = 0 AND (AssetID IS NULL OR AssetID = 0)"))
                                {
                                    // If CInt(faultRow("AssetID")) = 0 Then
                                    if (actualNo == NewPageCompareNo)
                                    {
                                        // NEED A NEW PAGE

                                        nextFaultRowForPrint = 0;
                                    }

                                    if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(faultRow["ADDEDTOPRINTOUT"], true, false)))
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AA" + nextFaultRowForPrint.ToString(), Conversions.ToString(faultRow["FullReason"]).Trim());
                                        if (Fuel == 2 | Fuel == 0 | Fuel == 5 | Fuel == 9 | Fuel == 7) // gas/others/ashp/HIU
                                        {
                                            if (Conversions.ToBoolean(faultRow["WarningNoticeIssued"]))
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + nextFaultRowForPrint.ToString(), "Yes");
                                            }
                                            else
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + nextFaultRowForPrint.ToString(), "No");
                                            }
                                        }
                                        else if (Fuel == 3)
                                        {
                                            if (Conversions.ToBoolean(faultRow["WarningNoticeIssued"]))
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "Yes");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "Yes");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "Yes");
                                            }
                                            else
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No");
                                            }
                                        }

                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CC" + nextFaultRowForPrint.ToString(), Conversions.ToString(faultRow["Disconnected"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "DD" + nextFaultRowForPrint.ToString(), Conversions.ToString(faultRow["ActionTaken"]));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EE" + nextFaultRowForPrint.ToString(), Conversions.ToString(faultRow["Comments"]));
                                        faultRow["ADDEDTOPRINTOUT"] = true;
                                        nextFaultRowForPrint += 1;
                                    }

                                    actualNo = 1;
                                }
                            }
                            catch (Exception ex)
                            {
                                // no faults for this row so dont do anything
                            }
                        }
                        else
                        {
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB" + nextFaultRowForPrint.ToString(), "");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "");
                        }
                    }
                    else if (faults is object)
                    {
                        try
                        {
                            bool warningNotice = false;
                            string RemidialString = "";
                            foreach (DataRow faultRow in faults.Select("ADDEDTOPRINTOUT = 0"))
                            {
                                if (Conversions.ToInteger(faultRow["AssetID"]) == 0)
                                {
                                    if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(faultRow["ADDEDTOPRINTOUT"], true, false)))
                                    {
                                        RemidialString += Conversions.ToString(faultRow["FullReason"]).Trim();
                                        RemidialString += " - ";
                                        RemidialString += Conversions.ToString(faultRow["ActionTaken"]) + " ,  ";
                                        if (Conversions.ToBoolean(faultRow["WarningNoticeIssued"]))
                                        {
                                            warningNotice = true;
                                        }

                                        faultRow["ADDEDTOPRINTOUT"] = true;
                                        nextFaultRowForPrint += 1;
                                    }
                                }

                                actualNo = 1;
                            }

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", RemidialString);
                        }
                        catch (Exception ex)
                        {
                            // no faults for this row so dont do anything
                        }
                    }
                    else
                    {
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "DB" + nextFaultRowForPrint.ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "");
                    }
                }
            }

            private bool SiteVisitReport(EngineerVisits.EngineerVisit engineerVisit, string savePath)
            {
                try
                {
                    engineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisit.EngineerVisitID);
                    var job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(engineerVisit.EngineerVisitID);
                    var site = App.DB.Sites.Get(job.PropertyID);
                    var customer = App.DB.Customer.Customer_Get(site.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(engineerVisit.EngineerID);
                    var visitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(engineerVisit.EngineerVisitID);
                    var siteHq = App.DB.Sites.Get(site.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    var startDate = engineerVisit.StartDateTime;
                    var endDate = engineerVisit.EndDateTime;
                    if (startDate == default)
                        startDate = engineerVisit.ManualEntryOn;
                    if (endDate == default)
                        endDate = engineerVisit.ManualEntryOn;
                    int imageIndex = 101;
                    double total = 0.0;
                    double vat = 0.0;
                    if (visitCharge is object)
                    {
                        var switchExpr = visitCharge.ChargeTypeID;
                        switch (switchExpr)
                        {
                            case (int)Enums.JobChargingType.QuoteValue:
                                {
                                    if (job.JobDefinitionEnumID == Conversions.ToInteger(Enums.JobDefinition.Quoted))
                                    {
                                        total = Conversions.ToDouble(App.DB.QuoteJob.Get(job.QuoteID).GrandTotal);
                                    }

                                    break;
                                }

                            case (int)Enums.JobChargingType.JobValue:
                                {
                                    total = visitCharge.JobValue;
                                    break;
                                }

                            case (int)Enums.JobChargingType.PercentageOfQuote:
                                {
                                    if (job.JobDefinitionEnumID == Conversions.ToInteger(Enums.JobDefinition.Quoted))
                                    {
                                        total = visitCharge.Charge / 100 * Conversions.ToDouble(App.DB.QuoteJob.Get(job.QuoteID).GrandTotal);
                                    }

                                    break;
                                }
                        }

                        vat = App.DB.EngineerVisits.EngineerCharge_VAT_Amount(visitCharge.EngineerVisitChargeID, startDate, total);
                    }

                    var fullDocument = new List<byte[]>();
                    string usingdoc = Application.StartupPath + @"\Templates\SiteVisitReport.docx";
                    var byteArray = File.ReadAllBytes(usingdoc);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            AddCompanyDetails(wordDoc, true);
                            PrintHelper.ReplaceText(wordDoc, "[JobVisitNumber]", job.JobNumber + "" + engineerVisit.EngineerVisitID);
                            PrintHelper.ReplaceText(wordDoc, "[VisitDate]", startDate.ToLongDateString());
                            PrintHelper.ReplaceText(wordDoc, "[GasSafeIDNo]", Helper.MakeStringValid(engineer?.GasSafeNo));
                            PrintHelper.ReplaceText(wordDoc, "[JobCustomerName]", Helper.MakeStringValid(App.DB.Picklists.Get_One_As_Object(engineerVisit.SignatureSelectedID)?.Name) + " " + engineerVisit.CustomerName);
                            PrintHelper.ReplaceText(wordDoc, "[JobAddressName]", site.Name);
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress1]", site.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress2]", site.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress3]", site.Address3);
                            PrintHelper.ReplaceText(wordDoc, "[JobPostCode]", Helper.FormatPostcode(site.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[JobTelNo]", site.TelephoneNum);
                            PrintHelper.ReplaceText(wordDoc, "[LandLordAddress3]", "");
                            if (siteHq is object)
                            {
                                string strAddress = string.Empty;
                                if (siteHq.Address1.Length > 0)
                                {
                                    strAddress += siteHq.Address1 + ", ";
                                }

                                if (siteHq.Address2.Length > 0)
                                {
                                    strAddress += siteHq.Address2 + ", ";
                                }

                                if (strAddress.Length > 0)
                                {
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);
                                }

                                string strAddress1 = string.Empty;
                                if (siteHq.Address3.Length > 0)
                                {
                                    strAddress1 += siteHq.Address3 + ", ";
                                }

                                if (siteHq.Address4.Length > 0)
                                {
                                    strAddress1 += siteHq.Address4 + ", ";
                                }

                                if (siteHq.Address5.Length > 0)
                                {
                                    strAddress1 += siteHq.Address5 + ", ";
                                }

                                if (strAddress.Length > 0 & strAddress1.Length > 1)
                                {
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);
                                }

                                string customerName = siteHq.CustomerID != (int)Enums.Customer.Domestic ? customer.Name : "";
                                PrintHelper.ReplaceText(wordDoc, "[LandLordName]", customerName);
                                PrintHelper.ReplaceText(wordDoc, "[LandLordAddress1]", strAddress);
                                PrintHelper.ReplaceText(wordDoc, "[LandLordAddress2]", strAddress1);
                                PrintHelper.ReplaceText(wordDoc, "[LLPostcode]", Helper.FormatPostcode(siteHq.Postcode));
                                PrintHelper.ReplaceText(wordDoc, "[LLTelNo]", siteHq.TelephoneNum);
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[LandLordName]", "");
                                PrintHelper.ReplaceText(wordDoc, "[LandLordAddress1]", "");
                                PrintHelper.ReplaceText(wordDoc, "[LandLordAddress2]", "");
                                PrintHelper.ReplaceText(wordDoc, "[LLPostcode]", "");
                                PrintHelper.ReplaceText(wordDoc, "[LLTelNo]", "");
                            }

                            string strJOW = string.Empty;
                            foreach (JobOfWorks.JobOfWork jow in job.JobOfWorks)
                                strJOW += jow.PONumber + "/";
                            if (strJOW.Length > 0)
                            {
                                strJOW = strJOW.Substring(0, strJOW.Length - 1);
                            }

                            PrintHelper.ReplaceText(wordDoc, "[PO]", strJOW);
                            PrintHelper.ReplaceText(wordDoc, "[From]", startDate.ToShortTimeString());
                            PrintHelper.ReplaceText(wordDoc, "[To]", endDate.ToShortTimeString());
                            var dvFaults = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(engineerVisit.EngineerVisitID);
                            var warningNotices = (from r in dvFaults.Table.AsEnumerable()
                                                  where r.Field<bool>("WarningNoticeIssued") == true
                                                  select r).ToArray();
                            string warningNotice = warningNotices.Count() > 0 ? "Yes" : "No";
                            PrintHelper.ReplaceText(wordDoc, "[Warning]", warningNotice);
                            PrintHelper.ReplaceText(wordDoc, "[Engineer]", Helper.MakeStringValid(engineer?.Name));
                            PrintHelper.ReplaceText(wordDoc, "[Outcome]", engineerVisit.VisitOutcome);
                            PrintHelper.ReplaceText(wordDoc, "[PaymentMethod]", Helper.MakeStringValid(App.DB.Picklists.Get_One_As_Object(engineerVisit.PaymentMethodID)?.Name));
                            PrintHelper.ReplaceText(wordDoc, "[Total]", total == 0 ? "" : total.ToString("c"));
                            PrintHelper.ReplaceText(wordDoc, "[VAT]", vat == 0 ? "" : vat.ToString("c"));
                            PrintHelper.ReplaceText(wordDoc, "[AmntDue]", total + vat == 0 ? "" : (total + vat).ToString("c"));
                            PrintHelper.ReplaceText(wordDoc, "[OutcomeDetails]", engineerVisit.OutcomeDetails);
                            PrintHelper.ReplaceText(wordDoc, "[WorkRequired]", engineerVisit.NotesToEngineer);
                            if (engineerVisit.EngineerSignature is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");
                            }
                            else
                            {
                                var engSig = new Bitmap(new MemoryStream(engineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }

                            if (engineerVisit.CustomerSignature is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "");
                            }
                            else
                            {
                                var custSig = new Bitmap(new MemoryStream(engineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }

                            var dt = new DataTable();
                            dt.Columns.Add("Part No");
                            dt.Columns.Add("Description");
                            dt.Columns.Add("Qty");
                            if (engineerVisit.PartsAndProductsUsed.Table is object && engineerVisit.PartsAndProductsUsed.Table.Rows.Count > 0)
                            {
                                foreach (DataRow r in engineerVisit.PartsAndProductsUsed.Table.Rows)
                                {
                                    DataRow nr;
                                    nr = dt.NewRow();
                                    nr["Part No"] = r["Number"];
                                    nr["Description"] = r["Name"];
                                    nr["Qty"] = r["Quantity"];
                                    dt.Rows.Add(nr);
                                }
                            }

                            PrintHelper.AddRowsToTable(wordDoc, "[Parts]", dt, "Arial", "16", 1);
                            var dtTimeSheet = new DataTable();
                            dtTimeSheet.Columns.Add("Start");
                            dtTimeSheet.Columns.Add("End");
                            dtTimeSheet.Columns.Add("Type");
                            dtTimeSheet.Columns.Add("Comments");
                            if (engineerVisit.TimeSheets.Table is object && engineerVisit.TimeSheets.Table.Rows.Count > 0)
                            {
                                foreach (DataRow r in engineerVisit.TimeSheets.Table.Rows)
                                {
                                    DataRow nr;
                                    nr = dtTimeSheet.NewRow();
                                    nr["Start"] = Helper.MakeDateTimeValid(r["StartDateTime"]).ToString("HH:mm");
                                    nr["End"] = Helper.MakeDateTimeValid(r["EndDateTime"]).ToString("HH:mm");
                                    nr["Type"] = r["TimeSheetType"];
                                    nr["Comments"] = r["Comments"];
                                    dtTimeSheet.Rows.Add(nr);
                                }
                            }

                            PrintHelper.AddRowsToTable(wordDoc, "[TimeSheets]", dtTimeSheet, "Arial", "16", 1);
                        }

                        fullDocument.Add(mm.ToArray());
                        PrintGSR(engineerVisit.EngineerVisitID, fullDocument, "", true);
                        if (fullDocument.Count > 0)
                        {
                            File.WriteAllBytes(savePath, PrintHelper.CombineDocs(fullDocument));
                            PrintHelper.RemoveSpacingInDoc(savePath);
                            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
                                savePath = PrintHelper.LockFile(savePath, true);
                        }
                    }

                    var cbyteArray = File.ReadAllBytes(savePath);
                    var cmm = new MemoryStream();
                    using (cmm)
                    {
                        cmm.Write(cbyteArray, 0, cbyteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(cmm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "Landlord’s appliance", "Appliance");
                            PrintHelper.ReplaceText(wordDoc, "Landlord’s Details", "Details");
                            PrintHelper.ReplaceText(wordDoc, "LANDLORD", "");
                            wordDoc.MainDocumentPart.Document.Save();
                        }

                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        if (File.Exists(savePath))
                            File.Delete(savePath);
                        var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        cmm.Position = 0;
                        using (fileStream)
                            cmm.WriteTo(fileStream);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private void AddCompanyDetails(WordprocessingDocument doc, bool useLogo, bool centreLogo = false, bool isCommercial = false)
            {
                var companyDetails = App.DB.CompanyDetails.Get();
                PrintHelper.ReplaceText(doc, "[CompanyName]", companyDetails.Name);
                PrintHelper.ReplaceText(doc, "[CompanyAddress1]", companyDetails.Address1);
                PrintHelper.ReplaceText(doc, "[CompanyAddress2]", companyDetails.Address2);
                PrintHelper.ReplaceText(doc, "[CompanyAddress3]", companyDetails.Address3);
                PrintHelper.ReplaceText(doc, "[CompanyAddress4]", companyDetails.Address4);
                PrintHelper.ReplaceText(doc, "[CompanyAddress5]", companyDetails.Address5);
                PrintHelper.ReplaceText(doc, "[CompanyPostcode]", Helper.MakeStringValid(companyDetails.Postcode));
                PrintHelper.ReplaceText(doc, "[CompanyTelephoneNumber]", companyDetails.TelephoneNumber);
                PrintHelper.ReplaceText(doc, "[CompanyWebsite]", companyDetails.Website);
                PrintHelper.ReplaceText(doc, "[CompanyEmail]", companyDetails.EmailAddress);
                PrintHelper.ReplaceText(doc, "[CompanySortCode]", companyDetails.SortCode);
                PrintHelper.ReplaceText(doc, "[CompanyAccountNumber]", companyDetails.AccountNumber);
                PrintHelper.ReplaceText(doc, "[CompanyNumber]", companyDetails.CompanyNumber);
                PrintHelper.ReplaceText(doc, "[CompanyVatNumber]", companyDetails.VatNumber);
                if (useLogo)
                {
                    Bitmap logo = null;
                    if (App.IsRFT)
                    {
                        logo = My.Resources.Resources.rft_logo;
                    }
                    else if (App.IsGasway)
                    {
                        logo = isCommercial ? My.Resources.Resources.GC_Logo : My.Resources.Resources.GW_Logo;
                    }
                    else if (App.IsBlueflame)
                    {
                        logo = My.Resources.Resources.Blueflame;
                    }

                    string imgSavePath = Application.StartupPath + @"\TEMP\companyLogo.jpg";
                    PrintHelper.ReplaceBookmarkWithImage(doc, "Logo", logo, imgSavePath, 100, centreLogo);
                }
            }

            private bool JobContactLetter(Jobs.Job job)
            {
                try
                {
                    var oSite = App.DB.Sites.Get(job.PropertyID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var visitDate = ((ArrayList)DetailsToPrint)[1].ToString();
                    int currentPage = 1;
                    foreach (Match wordField in Printing.GetTemplateFields(WordDoc.Content.Text))
                    {
                        var switchExpr = wordField.Value.ToLower();
                        switch (switchExpr)
                        {
                            case var @case when @case == "[VisitDate]".ToLower():
                                {
                                    if (visitDate == default)
                                    {
                                        var argmsWordDoc = WordDoc;
                                        ReplaceText(ref argmsWordDoc, wordField.Value, "");
                                    }
                                    else
                                    {
                                        var argmsWordDoc1 = WordDoc;
                                        Printing.ReplaceText(ref argmsWordDoc1, wordField.Value, visitDate);
                                    }

                                    break;
                                }

                            case var case1 when case1 == "[VisitDate2]".ToLower():
                                {
                                    if (visitDate == default)
                                    {
                                        var argmsWordDoc2 = WordDoc;
                                        ReplaceText(ref argmsWordDoc2, wordField.Value, "");
                                    }
                                    else
                                    {
                                        var argmsWordDoc3 = WordDoc;
                                        Printing.ReplaceText(ref argmsWordDoc3, wordField.Value, visitDate);
                                    }

                                    break;
                                }

                            case var case2 when case2 == "[SentDate]".ToLower():
                                {
                                    if (visitDate == default)
                                    {
                                        var argmsWordDoc4 = WordDoc;
                                        ReplaceText(ref argmsWordDoc4, wordField.Value, "");
                                    }
                                    else
                                    {
                                        var argmsWordDoc5 = WordDoc;
                                        ReplaceText(ref argmsWordDoc5, wordField.Value, DateAndTime.Now.ToString("dd/MM/yyyy"));
                                    }

                                    break;
                                }

                            case var case3 when case3 == "[JobAddressName]".ToLower():
                                {
                                    var argmsWordDoc6 = WordDoc;
                                    ReplaceText(ref argmsWordDoc6, wordField.Value, oSite.Name);
                                    break;
                                }

                            case var case4 when case4 == "[Address1]".ToLower():
                                {
                                    var argmsWordDoc7 = WordDoc;
                                    ReplaceText(ref argmsWordDoc7, wordField.Value, oSite.Address1);
                                    break;
                                }

                            case var case5 when case5 == "[Address2]".ToLower():
                                {
                                    var argmsWordDoc8 = WordDoc;
                                    ReplaceText(ref argmsWordDoc8, wordField.Value, oSite.Address2);
                                    break;
                                }

                            case var case6 when case6 == "[Address3]".ToLower():
                                {
                                    if (oSite.Address3.Length > 0)
                                    {
                                        var argmsWordDoc9 = WordDoc;
                                        ReplaceText(ref argmsWordDoc9, wordField.Value, oSite.Address3);
                                    }
                                    else if (oSite.Address4.Length > 0)
                                    {
                                        var argmsWordDoc11 = WordDoc;
                                        ReplaceText(ref argmsWordDoc11, wordField.Value, oSite.Address4);
                                    }
                                    else
                                    {
                                        var argmsWordDoc10 = WordDoc;
                                        ReplaceText(ref argmsWordDoc10, wordField.Value, oSite.Address5);
                                    }

                                    break;
                                }

                            case var case7 when case7 == "[Name]".ToLower():
                                {
                                    var argmsWordDoc12 = WordDoc;
                                    ReplaceText(ref argmsWordDoc12, wordField.Value, oSite.Name);
                                    break;
                                }

                            case var case8 when case8 == "[PostCode]".ToLower():
                                {
                                    var argmsWordDoc13 = WordDoc;
                                    ReplaceText(ref argmsWordDoc13, wordField.Value, Helper.FormatPostcode(oSite.Postcode));
                                    break;
                                }
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool COMSR(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null, bool addLsrHeaderLetter = false)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    var EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(oEngineerVisit.EngineerVisitID);
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = oEngineerVisit.ManualEntryOn;
                    }

                    int imageIndex = 100;
                    var GSRs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(oEngineerVisit.EngineerVisitID);
                    int numberOfAppliances = GSRs.Table.Rows.Count;
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "COMSR");
                            if (oEngineerVisit.EngineerSignature is object)
                            {
                                var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");
                            }

                            var ComChecks = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 0);
                            if (oEngineerVisit.CustomerSignature is object)
                            {
                                var custSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "");
                            }

                            int currentPage = 1;
                            var ositeHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber + "-" + oEngineerVisit.EngineerVisitID);
                            if (engineer is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", engineer.GasSafeNo);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C", engineer.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", engineer.Name);
                            }

                            if (visitDate == default)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", visitDate.ToLongDateString());
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", engineer.Name);
                            }

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "E", oSite.Name, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "F", oSite.Address1, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "G", oSite.Address2, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Helper.FormatPostcode(oSite.Postcode), "8");
                            if (ositeHQ is object)
                            {
                                string strAddress = string.Empty;
                                string strAddress1 = string.Empty;
                                if (ositeHQ.Address1.Length > 0)
                                {
                                    strAddress += ositeHQ.Address1 + ", ";
                                }

                                if (ositeHQ.Address2.Length > 0)
                                {
                                    strAddress += ositeHQ.Address2 + ", ";
                                }

                                if (strAddress.Length > 0)
                                {
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);
                                }

                                if (ositeHQ.Address3.Length > 0)
                                {
                                    strAddress1 += ositeHQ.Address3 + ", ";
                                }

                                if (ositeHQ.Address4.Length > 0)
                                {
                                    strAddress1 += ositeHQ.Address4 + ", ";
                                }

                                if (strAddress1.Length > 0)
                                {
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", App.DB.Customer.Customer_Get(oSite.CustomerID).Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", strAddress, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress1, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "", "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", Helper.FormatPostcode(ositeHQ.Postcode), "8");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O", "");
                            }

                            string warning = "No";
                            foreach (DataRow row in App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(oEngineerVisit.EngineerVisitID).Table.Rows)
                            {
                                warning = "No";
                                if (Helper.MakeBooleanValid(row["WarningNoticeIssued"]))
                                {
                                    warning = "Yes";
                                    break;
                                }
                            }

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", warning);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", warning);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", warning);
                            if (oEngineerVisit.OutcomeDetails is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", oEngineerVisit.OutcomeDetails);
                            }

                            if (ComChecks is object)
                            {
                                var selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test1);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test2);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test4);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test5);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test6);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test7);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test8);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test9);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test10);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test111);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test112);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AL", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test113);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AM", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test114);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AN", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test115);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AO", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test116);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AP", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test117);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AQ", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test118);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AR", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test119);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AS", selected.Name);
                                AddAppliancesBatch(wordDoc, numberOfAppliances, GSRs.Table, null);
                            }
                            else
                            {
                                App.ShowMessage("Could not generate document : Missing Worksheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }

                        if (addLsrHeaderLetter)
                        {
                            var lsrHeaderTemplate = LsrHeaderLetter(oSite, null, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                        }

                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool COMCAT(EngineerVisits.EngineerVisit EngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null, bool addLsrHeaderLetter = false)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
                    var EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(EngineerVisit.EngineerVisitID);
                    var visitDate = EngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = EngineerVisit.ManualEntryOn;
                    }

                    int imageIndex = 100;
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Job]", EngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "COMCAT");
                            if (EngineerVisit.EngineerSignature is object)
                            {
                                var engSig = new Bitmap(new MemoryStream(EngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");
                            }

                            var ComChecks = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(EngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.CommercialCateringCP42);
                            if (EngineerVisit.CustomerSignature is object)
                            {
                                var custSig = new Bitmap(new MemoryStream(EngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "J", custSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", "");
                            }

                            int currentPage = 1;
                            var ositeHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber + "-" + EngineerVisit.EngineerVisitID, "9", true);
                            if (engineer is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", engineer.GasSafeNo);
                            }

                            if (visitDate == default)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", visitDate.ToLongDateString());
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", engineer.Name);
                            }

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "E", oSite.Name, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "F", oSite.Address1, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "G", oSite.Address2, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Helper.FormatPostcode(oSite.Postcode), "8");
                            if (ositeHQ is object)
                            {
                                string strAddress = string.Empty;
                                string strAddress1 = string.Empty;
                                if (ositeHQ.Address1.Length > 0)
                                {
                                    strAddress += ositeHQ.Address1 + ", ";
                                }

                                if (ositeHQ.Address2.Length > 0)
                                {
                                    strAddress += ositeHQ.Address2 + ", ";
                                }

                                if (strAddress.Length > 0)
                                {
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);
                                }

                                if (ositeHQ.Address3.Length > 0)
                                {
                                    strAddress1 += ositeHQ.Address3 + ", ";
                                }

                                if (ositeHQ.Address4.Length > 0)
                                {
                                    strAddress1 += ositeHQ.Address4 + ", ";
                                }

                                if (strAddress1.Length > 0)
                                {
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", ositeHQ.Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", strAddress1, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "", "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O", Helper.FormatPostcode(ositeHQ.Postcode), "8");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O", "");
                            }

                            var selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test1);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test2);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test4);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test5);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test6);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test7);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test8);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test9);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test10);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test111);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AL", Conversions.ToString(Interaction.IIf(selected.ManagerID == 70132, "Yes", "NO")));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AM", Conversions.ToString(Interaction.IIf(selected.ManagerID == 70133, "Yes", "NO")));
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test112);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AN", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test113);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AO", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test114);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AP", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test115);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AQ", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test116);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AR", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test117);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AS", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test118);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AT", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test119);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AU", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test120);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test121);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test122);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test123);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test124);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BE", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test125);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BF", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test126);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BG", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test127);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BH", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test128);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BI", selected.Name);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BK", ComChecks.Test11);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", ComChecks.Test12);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test129);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test130);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BM", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test131);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BN", selected.Name);
                            selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test132);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BO", selected.Name);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BP", ComChecks.Test13);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BQ", ComChecks.Test14);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BR", ComChecks.Test15);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BS", ComChecks.Test216);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BT", ComChecks.Test217);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BU", ComChecks.Test218);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BV", ComChecks.Test219);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "CA", ComChecks.Test220);
                        }

                        if (addLsrHeaderLetter)
                        {
                            var lsrHeaderTemplate = LsrHeaderLetter(oSite, null, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                        }

                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool ProptMain(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null, bool addLsrHeaderLetter = false)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    var ositeHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = oEngineerVisit.ManualEntryOn;
                    }

                    var PropMain = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist);
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            if (engineer is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", oSite.Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", oSite.Address1 + oSite.Address2 + ", " + oSite.Address3, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", Helper.FormatPostcode(oSite.Postcode), "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", engineer.Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", Conversions.ToString(visitDate), "11");
                            }

                            if (visitDate == default)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w1", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", App.DB.Picklists.Get_One_As_Object(PropMain.Test1).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", App.DB.Picklists.Get_One_As_Object(PropMain.Test2).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", App.DB.Picklists.Get_One_As_Object(PropMain.Test3).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", App.DB.Picklists.Get_One_As_Object(PropMain.Test4).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", App.DB.Picklists.Get_One_As_Object(PropMain.Test5).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", PropMain.Test11, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", PropMain.Test12, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w1", PropMain.Test13, "11");
                            }
                        }

                        if (addLsrHeaderLetter)
                        {
                            var lsrHeaderTemplate = LsrHeaderLetter(oSite, ositeHQ, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                        }

                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool Unvented(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, DataView LSR, string goldenRule, [Optional, DefaultParameterValue(null)] ref List<byte[]> fullDocument, bool addLsrHeaderLetter = false)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = oEngineerVisit.ManualEntryOn;
                    }

                    int imageIndex = 100;
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    PickLists.PickList oPicklist;
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSite.Name);
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSite.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSite.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode));
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["FlueTerminationSatisfactoryID"]));
                            PrintHelper.ReplaceText(wordDoc, "[i]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["FlueFlowTestID"]));
                            PrintHelper.ReplaceText(wordDoc, "[ii]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["SpillageTestID"]));
                            PrintHelper.ReplaceText(wordDoc, "[iii]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["VentilationProvisionSatisfactoryID"]));
                            PrintHelper.ReplaceText(wordDoc, "[iv]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["TankID"]));
                            PrintHelper.ReplaceText(wordDoc, "[v]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["DischargeID"]));
                            PrintHelper.ReplaceText(wordDoc, "[vi]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["SweepOutcomeID"]));
                            PrintHelper.ReplaceText(wordDoc, "[vii]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["SafetyDeviceOperationID"]));
                            PrintHelper.ReplaceText(wordDoc, "[viii]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["OverallID"]));
                            PrintHelper.ReplaceText(wordDoc, "[ix]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["ApplianceTestedID"]));
                            PrintHelper.ReplaceText(wordDoc, "[x]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["VisualConditionOfFlueSatisfactoryID"]));
                            PrintHelper.ReplaceText(wordDoc, "[xi]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["LandlordsApplianceID"]));
                            PrintHelper.ReplaceText(wordDoc, "[xii]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["ApplianceServiceOrInspectedID"]));
                            PrintHelper.ReplaceText(wordDoc, "[xiii]", oPicklist.Name);
                            oPicklist = null;
                            oPicklist = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["ApplianceSafeID"]));
                            PrintHelper.ReplaceText(wordDoc, "[xiv]", oPicklist.Name);
                            PrintHelper.ReplaceText(wordDoc, "[Additional]", oEngineerVisit.OutcomeDetails);
                            if (visitDate == default)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[Date]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[Date]", visitDate.ToLongDateString());
                            }

                            string engineerName = engineer is null ? "" : engineer.Name;
                            PrintHelper.ReplaceText(wordDoc, "[Engineer]", engineerName);
                            if (oEngineerVisit.CustomerSignature is object)
                            {
                                var CustSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "Tenant", CustSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "");
                            }
                        }

                        if (addLsrHeaderLetter)
                        {
                            var lsrHeaderTemplate = LsrHeaderLetter(oSite, null, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                        }

                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool SAFUnvented(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, EngineerVisitAdditionals.EngineerVisitAdditional SAFUNV1, string template, string savePath, string goldenRule, [Optional, DefaultParameterValue(null)] ref List<byte[]> fullDocument, bool addLsrHeaderLetter = false)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    var oSiteHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = oEngineerVisit.ManualEntryOn;
                    }

                    int imageIndex = 101;
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "UNVENTED");
                            if (oSiteHQ is object)
                            {
                                string strAddress = string.Empty;
                                if (oSiteHQ.Address1.Length > 0)
                                {
                                    strAddress += oSiteHQ.Address1 + ", ";
                                }

                                if (oSiteHQ.Address2.Length > 0)
                                {
                                    strAddress += oSiteHQ.Address2 + ", ";
                                }

                                if (strAddress.Length > 0)
                                {
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);
                                }

                                string strAddress1 = string.Empty;
                                if (oSiteHQ.Address3.Length > 0)
                                {
                                    strAddress1 += oSiteHQ.Address3 + ", ";
                                }

                                if (oSiteHQ.Address4.Length > 0)
                                {
                                    strAddress1 += oSiteHQ.Address4 + ", ";
                                }

                                if (oSiteHQ.Address5.Length > 0)
                                {
                                    strAddress1 += oSiteHQ.Address5 + ", ";
                                }

                                if (strAddress.Length > 0 & strAddress1.Length > 1)
                                {
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", App.DB.Customer.Customer_Get(oSite.CustomerID).Name, "8", true);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress1", strAddress, "8", true);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress2", strAddress1, "8", true);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LLPostcode", Helper.FormatPostcode(oSiteHQ.Postcode), "8", true);
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordAddress2", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LLPostcode", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LLTelNo", "");
                            }

                            byte[] logo = null;
                            try
                            {
                                logo = (byte[])App.DB.ExecuteScalar("Select Logo FROM tblCustomer where CustomerID = " + oSite.CustomerID);
                            }
                            catch
                            {
                                logo = null;
                            }

                            if (logo is object)
                            {
                                var custLogo = new Bitmap(new MemoryStream(logo));
                                string imgSavePath = Application.StartupPath + @"\TEMP\custLogo.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "Logo", custLogo, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Logo", "");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[JobNo]", Job.JobNumber);
                            PrintHelper.ReplaceText(wordDoc, "[A]", oSite.Name);
                            PrintHelper.ReplaceText(wordDoc, "[B]", oSite.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[C]", oSite.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[D]", Helper.FormatPostcode(oSite.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[E]", oSite.TelephoneNum);
                            PrintHelper.ReplaceText(wordDoc, "[AA]", SAFUNV1.Test11);
                            PrintHelper.ReplaceText(wordDoc, "[AB]", SAFUNV1.Test12);
                            PrintHelper.ReplaceText(wordDoc, "[AC]", SAFUNV1.Test13);
                            PrintHelper.ReplaceText(wordDoc, "[AD]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test1).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AE]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test2).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AF]", SAFUNV1.Test14);
                            PrintHelper.ReplaceText(wordDoc, "[AG]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test3).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AH]", SAFUNV1.Test15);
                            PrintHelper.ReplaceText(wordDoc, "[AI]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test4).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AJ]", SAFUNV1.Test216);
                            PrintHelper.ReplaceText(wordDoc, "[AK]", SAFUNV1.Test217);
                            PrintHelper.ReplaceText(wordDoc, "[AL]", SAFUNV1.Test218);
                            PrintHelper.ReplaceText(wordDoc, "[AM]", SAFUNV1.Test219);
                            PrintHelper.ReplaceText(wordDoc, "[AN]", SAFUNV1.Test220);
                            PrintHelper.ReplaceText(wordDoc, "[AO]", SAFUNV1.Test221);
                            PrintHelper.ReplaceText(wordDoc, "[AP]", SAFUNV1.Test222);
                            PrintHelper.ReplaceText(wordDoc, "[AQ]", SAFUNV1.Test223);
                            PrintHelper.ReplaceText(wordDoc, "[AR]", SAFUNV1.Test224);
                            PrintHelper.ReplaceText(wordDoc, "[AS]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test5).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AT]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test6).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AU]", SAFUNV1.Test225);
                            PrintHelper.ReplaceText(wordDoc, "[AV]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test7).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AW]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test8).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AX]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test9).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AY]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test10).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BA]", SAFUNV1.Test226);
                            PrintHelper.ReplaceText(wordDoc, "[BB]", SAFUNV1.Test227);
                            PrintHelper.ReplaceText(wordDoc, "[BC]", SAFUNV1.Test228);
                            PrintHelper.ReplaceText(wordDoc, "[BD]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test111).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BE]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test112).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BF]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test113).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BG]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test114).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BH]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test115).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BI]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test116).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BJ]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test117).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BK]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test118).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BL]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test119).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BM]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test120).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BN]", SAFUNV1.Test229);
                            PrintHelper.ReplaceText(wordDoc, "[BO]", SAFUNV1.Test230);
                            PrintHelper.ReplaceText(wordDoc, "[BP]", SAFUNV1.Test231);
                            if (visitDate == default)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[BS]", "");
                                PrintHelper.ReplaceText(wordDoc, "[BW]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[BS]", visitDate.ToLongDateString());
                                PrintHelper.ReplaceText(wordDoc, "[BW]", visitDate.ToLongDateString());
                            }

                            PrintHelper.ReplaceText(wordDoc, "[BR]", engineer.Name);
                            PrintHelper.ReplaceText(wordDoc, "[BU]", oEngineerVisit.CustomerName);
                            if (oEngineerVisit.EngineerSignature is object)
                            {
                                var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig2", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig2", "");
                            }

                            if (oEngineerVisit.CustomerSignature is object)
                            {
                                var CustSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig2", CustSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig2", "");
                            }
                        }

                        if (addLsrHeaderLetter)
                        {
                            var lsrHeaderTemplate = LsrHeaderLetter(oSite, oSiteHQ, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                        }

                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool ComChecklist(EngineerVisits.EngineerVisit oEngineerVisit)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    var oSite = App.DB.Sites.Get(Job.PropertyID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    var CommChecks = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.CommissioningChecklist);
                    Sites.Site oSiteHQ;
                    oSiteHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = oEngineerVisit.ManualEntryOn;
                    }

                    int imageIndex = 101;
                    string template = Application.StartupPath + @"\Templates\CommissioningChecklist.docx";
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    string saveDir = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblEngineerVisit) + @"\" + oEngineerVisit.EngineerVisitID;
                    Directory.CreateDirectory(saveDir);
                    string savePath = saveDir + @"\CommisioningChecklist" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            string strAddress = string.Empty;
                            if (oSite.Address1.Length > 0)
                            {
                                strAddress += oSite.Address1 + ", ";
                            }

                            if (oSite.Address2.Length > 0)
                            {
                                strAddress += oSite.Address2 + ", " + oSite.Address3 + ", " + oSite.Postcode;
                            }

                            PrintHelper.ReplaceText(wordDoc, "[custName]", oSite.Name);
                            PrintHelper.ReplaceText(wordDoc, "[tel1]", oSite.TelephoneNum);
                            PrintHelper.ReplaceText(wordDoc, "[address1]", strAddress);
                            PrintHelper.ReplaceText(wordDoc, "[makeModel]", CommChecks.Test12);
                            PrintHelper.ReplaceText(wordDoc, "[serial]", CommChecks.Test13);
                            PrintHelper.ReplaceText(wordDoc, "[commission]", engineer.Name);
                            PrintHelper.ReplaceText(wordDoc, "[commDate]", visitDate.ToLongDateString());
                            PrintHelper.ReplaceText(wordDoc, "[Breg]", CommChecks.Test11);
                            var switchExpr = CommChecks.Test1;
                            switch (switchExpr)
                            {
                                case (int)Enums.CommisioningChecksEnums.RoomThermostatAndTimer:
                                    {
                                        PrintHelper.ReplaceText(wordDoc, "[a]", "X");
                                        PrintHelper.ReplaceText(wordDoc, "[b]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[h]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[i]", "");
                                        break;
                                    }

                                case (int)Enums.CommisioningChecksEnums.LoadWeatherCompensation:
                                    {
                                        PrintHelper.ReplaceText(wordDoc, "[a]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[b]", "X");
                                        PrintHelper.ReplaceText(wordDoc, "[h]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[i]", "");
                                        break;
                                    }

                                case (int)Enums.CommisioningChecksEnums.ProgrammableRoomThermostat:
                                    {
                                        PrintHelper.ReplaceText(wordDoc, "[a]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[b]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[h]", "X");
                                        PrintHelper.ReplaceText(wordDoc, "[i]", "");
                                        break;
                                    }

                                case (int)Enums.CommisioningChecksEnums.OptimumStartControl:
                                    {
                                        PrintHelper.ReplaceText(wordDoc, "[a]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[b]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[h]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[i]", "X");
                                        break;
                                    }
                            }

                            if (CommChecks.Test2 == (int)Enums.CommisioningChecksEnums.CylinderThermostatAndTimer)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[c]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[j]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[c]", "");
                                PrintHelper.ReplaceText(wordDoc, "[j]", "X");
                            }

                            if (CommChecks.Test3 == (int)Enums.CommisioningChecksEnums.Fitted)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[d]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[k]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[d]", "");
                                PrintHelper.ReplaceText(wordDoc, "[k]", "X");
                            }

                            if (CommChecks.Test4 == (int)Enums.CommisioningChecksEnums.Fitted)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[e]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[l]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[e]", "");
                                PrintHelper.ReplaceText(wordDoc, "[l]", "X");
                            }

                            if (CommChecks.Test5 == (int)Enums.CommisioningChecksEnums.Fitted)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[f]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[m]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[f]", "");
                                PrintHelper.ReplaceText(wordDoc, "[m]", "X");
                            }

                            if (CommChecks.Test6 == (int)Enums.CommisioningChecksEnums.Fitted)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[g]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[n]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[g]", "");
                                PrintHelper.ReplaceText(wordDoc, "[n]", "X");
                            }

                            if (CommChecks.Test7 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[o]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[o]", "");
                            }

                            if (CommChecks.Test8 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[p]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[p]", "");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[cleaner]", CommChecks.Test14);
                            PrintHelper.ReplaceText(wordDoc, "[inhibitor]", CommChecks.Test15);
                            PrintHelper.ReplaceText(wordDoc, "[quantity]", CommChecks.Test216);
                            if (CommChecks.Test9 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[q]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[r]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[q]", "");
                                PrintHelper.ReplaceText(wordDoc, "[r]", "X");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[gasRate1]", CommChecks.Test217);
                            PrintHelper.ReplaceText(wordDoc, "[burnPress1]", CommChecks.Test218);
                            PrintHelper.ReplaceText(wordDoc, "[burnPress2]", CommChecks.Test219);
                            PrintHelper.ReplaceText(wordDoc, "[flowTemp]", CommChecks.Test220);
                            PrintHelper.ReplaceText(wordDoc, "[returnTemp]", CommChecks.Test221);
                            if (CommChecks.Test10 == (int)Enums.YesNoNA.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[s]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[u]", "");
                            }
                            else if (CommChecks.Test10 == (int)Enums.YesNoNA.No)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[s]", "");
                                PrintHelper.ReplaceText(wordDoc, "[u]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[s]", "");
                                PrintHelper.ReplaceText(wordDoc, "[u]", "");
                            }

                            if (CommChecks.Test111 == (int)Enums.YesNoNA.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[t]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[v]", "");
                            }
                            else if (CommChecks.Test111 == (int)Enums.YesNoNA.No)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[t]", "");
                                PrintHelper.ReplaceText(wordDoc, "[v]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[t]", "");
                                PrintHelper.ReplaceText(wordDoc, "[v]", "");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[scale]", CommChecks.Test222);
                            PrintHelper.ReplaceText(wordDoc, "[gasRate3]", CommChecks.Test223);
                            PrintHelper.ReplaceText(wordDoc, "[burnPress3]", CommChecks.Test224);
                            PrintHelper.ReplaceText(wordDoc, "[burnPress4]", CommChecks.Test225);
                            PrintHelper.ReplaceText(wordDoc, "[inletTemp]", CommChecks.Test226);
                            if (CommChecks.Test112 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[x]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[x]", "");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[temp]", CommChecks.Test227);
                            PrintHelper.ReplaceText(wordDoc, "[flowRate]", CommChecks.Test228);
                            if (CommChecks.Test113 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[y]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[y]", "");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[maxCO]", CommChecks.Test229);
                            PrintHelper.ReplaceText(wordDoc, "[maxRatio]", CommChecks.Test230);
                            PrintHelper.ReplaceText(wordDoc, "[minCO]", CommChecks.Test231);
                            PrintHelper.ReplaceText(wordDoc, "[minRatio]", CommChecks.Test232);
                            if (CommChecks.Test114 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[z]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[z]", "");
                            }

                            if (CommChecks.Test115 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[aa]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[aa]", "");
                            }

                            if (CommChecks.Test116 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[ab]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[ab]", "");
                            }

                            if (CommChecks.Test117 == (int)Enums.YesNo.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[ac]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[ac]", "");
                            }

                            if (oEngineerVisit.EngineerSignature is object)
                            {
                                var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "engSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "engSig", "");
                            }

                            if (oEngineerVisit.CustomerSignature is object)
                            {
                                var CustSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "custSig", CustSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "custSig", "");
                            }
                        }

                        savePath = FileCheck(savePath);
                        var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                    }

                    Process.Start(savePath);
                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateHotWorksPermit(EngineerVisits.EngineerVisit oEngineerVisit)
            {
                try
                {
                    var job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    var oSite = App.DB.Sites.Get(job.PropertyID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    var hotWorks = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.HotWorksPermit);
                    var oSiteHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                        visitDate = oEngineerVisit.ManualEntryOn;
                    int imageIndex = 101;
                    string template = Application.StartupPath + @"\Templates\HotWorksPermit.docx";
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    string saveDir = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblEngineerVisit) + @"\" + oEngineerVisit.EngineerVisitID;
                    Directory.CreateDirectory(saveDir);
                    string savePath = saveDir + @"\HotWorksPermit" + DateAndTime.Now.Day + "_" + DateAndTime.Now.ToString("MMM") + "_" + DateAndTime.Now.Year + ".docx";
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[JobNumber]", job.JobNumber.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test220]", hotWorks.Test220.ToUpper());
                            string strAddress = string.Empty;
                            if (oSite.Address1.Length > 0)
                            {
                                strAddress += oSite.Address1 + ", ";
                            }

                            if (oSite.Address2.Length > 0)
                            {
                                strAddress += oSite.Address2 + ", " + oSite.Address3 + ", " + oSite.Postcode;
                            }

                            PrintHelper.ReplaceText(wordDoc, "[Address]", strAddress);
                            PrintHelper.ReplaceText(wordDoc, "[Test221]", hotWorks.Test221.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test222]", hotWorks.Test222.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test11]", hotWorks.Test11.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[EngineerName]", engineer.Name.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test11]", hotWorks.Test11.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test12]", hotWorks.Test12.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test13]", hotWorks.Test13.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test14]", hotWorks.Test14.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test15]", hotWorks.Test15.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test216]", hotWorks.Test216.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test217]", hotWorks.Test217.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test218]", hotWorks.Test218.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test219]", hotWorks.Test219.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test223]", hotWorks.Test223.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test224]", hotWorks.Test224.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test225]", hotWorks.Test225.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test226]", hotWorks.Test226.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test227]", hotWorks.Test227.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[VisitDate]", visitDate.ToString("dd/MM/yyyy HH:mm"));
                            if (oEngineerVisit.EngineerSignature is object)
                            {
                                var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig1", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig1", "");
                            }
                        }

                        savePath = FileCheck(savePath);
                        var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                    }

                    Process.Start(savePath);
                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool ASHPM(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null, bool addHeaderLetter = false)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    var EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(oEngineerVisit.EngineerVisitID);
                    var GSRs = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(oEngineerVisit.EngineerVisitID);
                    int numberOfAppliances = GSRs.Table.Rows.Count;
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = oEngineerVisit.ManualEntryOn;
                    }

                    double total = 0.0;
                    double vat = 0.0;
                    var ASHP = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet);
                    var Solar = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.SolarThermalReport);
                    var ositeHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "ASHPM");
                            if (engineer is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobSiteName", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress2", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress3", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobPostCode", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobTelNo", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobSiteName", oSite.Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress1", oSite.Address1, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress2", oSite.Address2, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress3", oSite.Address3, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobPostCode", Helper.FormatPostcode(oSite.Postcode), "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobTelNo", oSite.TelephoneNum, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", engineer.Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a", ASHP.Test11);
                            }

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobVisitNumber", Job.JobNumber + "-" + oEngineerVisit.EngineerVisitID, "9", true);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate", Strings.Format(visitDate, "dd/MM/yyyy"), "9", true);
                            if (visitDate == default)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "i", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "s", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "v", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "x", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWCYL", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWMOD", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWSERIAL", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b", ASHP.Test12);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c", ASHP.Test13);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d", ASHP.Test14);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e", ASHP.Test15);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f", ASHP.Test216);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g", ASHP.Test217);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h", ASHP.Test218);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "i", ASHP.Test219);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j", ASHP.Test220);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k", ASHP.Test221);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l", ASHP.Test222);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m", ASHP.Test223);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n", ASHP.Test224);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o", ASHP.Test225);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p", ASHP.Test226);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q", ASHP.Test227);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r", ASHP.Test228);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "s", ASHP.Test229);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t", ASHP.Test230);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u", ASHP.Test231);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "v", ASHP.Test232);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w", ASHP.Test233);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "x", ASHP.Test234);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWCYL", ASHP.Test235);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWMOD", ASHP.Test236);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DHWSERIAL", ASHP.Test237);
                            }

                            if (Solar is object & visitDate != default)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", oSite.Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", oSite.Address1 + ", " + oSite.Address2, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", Helper.FormatPostcode(oSite.Postcode), "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d1", oSite.TelephoneNum, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e1", oSite.FaxNum, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", engineer.Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", Strings.Format(visitDate, "dd/MM/yyyy"), "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h1", Solar.Test217, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j1", Solar.Test218, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k1", App.DB.Picklists.Get_One_As_Object(Solar.Test1).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l1", App.DB.Picklists.Get_One_As_Object(Solar.Test2).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m1", App.DB.Picklists.Get_One_As_Object(Solar.Test3).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", App.DB.Picklists.Get_One_As_Object(Solar.Test4).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", App.DB.Picklists.Get_One_As_Object(Solar.Test5).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", App.DB.Picklists.Get_One_As_Object(Solar.Test6).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", Solar.Test11, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", Solar.Test12, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "s1", Solar.Test13, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", Solar.Test14, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", Solar.Test15, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "v1", Solar.Test216, "11");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "s1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "v1", "");
                            }
                        }

                        if (addHeaderLetter)
                        {
                            var lsrHeaderTemplate = LsrHeaderLetter(oSite, ositeHQ, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                        }

                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool COMTANDP(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    var ositeHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    var visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = oEngineerVisit.ManualEntryOn;
                    }

                    int imageIndex = 100;
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "COMTANDP");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber + "-" + oEngineerVisit.EngineerVisitID);
                            if (engineer is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", engineer.GasSafeNo);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "C", engineer.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "D", engineer.Name);
                            }

                            if (visitDate == default)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", visitDate.ToLongDateString());
                            }

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "E", oSite.Name, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "F", oSite.Address1, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "G", oSite.Address2, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Helper.FormatPostcode(oSite.Postcode), "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "I", oSite.TelephoneNum, "8");
                            if (ositeHQ is object)
                            {
                                string strAddress = string.Empty;
                                string strAddress1 = string.Empty;
                                if (ositeHQ.Address1.Length > 0)
                                {
                                    strAddress += ositeHQ.Address1 + ", ";
                                }

                                if (ositeHQ.Address2.Length > 0)
                                {
                                    strAddress += ositeHQ.Address2 + ", ";
                                }

                                if (strAddress.Length > 0)
                                {
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);
                                }

                                if (ositeHQ.Address3.Length > 0)
                                {
                                    strAddress1 += ositeHQ.Address3 + ", ";
                                }

                                if (ositeHQ.Address4.Length > 0)
                                {
                                    strAddress1 += ositeHQ.Address4 + ", ";
                                }

                                if (strAddress1.Length > 0)
                                {
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", App.DB.Customer.Customer_Get(oSite.CustomerID).Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", strAddress, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress1, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", Helper.FormatPostcode(ositeHQ.Postcode), "8");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "");
                            }

                            string warning = "No";
                            foreach (DataRow row in App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(oEngineerVisit.EngineerVisitID).Table.Rows)
                            {
                                if (Helper.MakeBooleanValid(row["WarningNoticeIssued"]))
                                {
                                    warning = "Yes";
                                    break;
                                }
                            }

                            if (oEngineerVisit.CustomerSignature is object)
                            {
                                var custSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig1", custSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig1", "");
                            }

                            if ((warning ?? "") == "Yes")
                            {
                                if (oEngineerVisit.EngineerSignature is object)
                                {
                                    var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                    string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig2", engSig, imgSavePath, imageIndex);
                                    imageIndex += 1;
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig2", "");
                                }

                                if (oEngineerVisit.CustomerSignature is object)
                                {
                                    var custSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                    string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig2", custSig, imgSavePath, imageIndex);
                                    imageIndex += 1;
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig2", "");
                                }

                                if (visitDate == default)
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", visitDate.ToLongDateString());
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", "");
                            }
                            else
                            {
                                if (oEngineerVisit.EngineerSignature is object)
                                {
                                    var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                    string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                    imageIndex += 1;
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");
                                }

                                if (oEngineerVisit.CustomerSignature is object)
                                {
                                    var custSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                    string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex);
                                    imageIndex += 1;
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "");
                                }

                                if (visitDate == default)
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", visitDate.ToLongDateString());
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "");
                            }

                            if (oEngineerVisit.OutcomeDetails is null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", oEngineerVisit.OutcomeDetails);
                            }

                            var ComChecks = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.CommercialStrengthTestCP16);
                            if (ComChecks is object)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X1", "X");
                                string cSelected = "";
                                var switchExpr = ComChecks.Test1;
                                switch (switchExpr)
                                {
                                    case 1:
                                        {
                                            cSelected = "P";
                                            break;
                                        }

                                    case 2:
                                        {
                                            cSelected = "H";
                                            break;
                                        }
                                }

                                if (string.IsNullOrEmpty(cSelected))
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", cSelected);
                                }

                                cSelected = "";
                                var switchExpr1 = ComChecks.Test2;
                                switch (switchExpr1)
                                {
                                    case 1:
                                        {
                                            cSelected = "N";
                                            break;
                                        }

                                    case 2:
                                        {
                                            cSelected = "NE";
                                            break;
                                        }

                                    case 3:
                                        {
                                            cSelected = "E";
                                            break;
                                        }
                                }

                                if (string.IsNullOrEmpty(cSelected))
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", cSelected);
                                }

                                var selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", ComChecks.Test11);
                                cSelected = "";
                                var switchExpr2 = ComChecks.Test4;
                                switch (switchExpr2)
                                {
                                    case 1:
                                        {
                                            cSelected = "AIR";
                                            break;
                                        }

                                    case 2:
                                        {
                                            cSelected = "NITRO";
                                            break;
                                        }

                                    case 3:
                                        {
                                            cSelected = "WATER";
                                            break;
                                        }
                                }

                                if (string.IsNullOrEmpty(cSelected))
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", cSelected);
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", ComChecks.Test12);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", ComChecks.Test13);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", ComChecks.Test14);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", ComChecks.Test15);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", ComChecks.Test216);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test120);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", selected.Name);
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X1", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", "");
                            }

                            ComChecks = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.CommercialTightnessTestCP16);
                            if (ComChecks is object)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X2", "X");
                                string cSelected = "";
                                var switchExpr3 = ComChecks.Test1;
                                switch (switchExpr3)
                                {
                                    case 1:
                                        {
                                            cSelected = "NG";
                                            break;
                                        }

                                    case 2:
                                        {
                                            cSelected = "LPG";
                                            break;
                                        }
                                }

                                if (string.IsNullOrEmpty(cSelected))
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", cSelected);
                                }

                                cSelected = "";
                                var switchExpr4 = ComChecks.Test2;
                                switch (switchExpr4)
                                {
                                    case 1:
                                        {
                                            cSelected = "N";
                                            break;
                                        }

                                    case 2:
                                        {
                                            cSelected = "NE";
                                            break;
                                        }

                                    case 3:
                                        {
                                            cSelected = "E";
                                            break;
                                        }
                                }

                                if (string.IsNullOrEmpty(cSelected))
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", cSelected);
                                }

                                var selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", selected.Name);
                                cSelected = "";
                                var switchExpr5 = ComChecks.Test4;
                                switch (switchExpr5)
                                {
                                    case 1:
                                        {
                                            cSelected = "Diap";
                                            break;
                                        }

                                    case 2:
                                        {
                                            cSelected = "Rota";
                                            break;
                                        }

                                    case 3:
                                        {
                                            cSelected = "Turb";
                                            break;
                                        }
                                }

                                if (string.IsNullOrEmpty(cSelected))
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", cSelected);
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BE", ComChecks.Test221);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test6);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BF", selected.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BG", ComChecks.Test11);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BH", ComChecks.Test12);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BI", ComChecks.Test13);
                                cSelected = "";
                                var switchExpr6 = ComChecks.Test7;
                                switch (switchExpr6)
                                {
                                    case 1:
                                        {
                                            cSelected = "Fuel Gas";
                                            break;
                                        }

                                    case 2:
                                        {
                                            cSelected = "Air";
                                            break;
                                        }
                                }

                                if (string.IsNullOrEmpty(cSelected))
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", cSelected);
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BK", ComChecks.Test14);
                                cSelected = "";
                                var switchExpr7 = ComChecks.Test8;
                                switch (switchExpr7)
                                {
                                    case 1:
                                        {
                                            cSelected = "Water";
                                            break;
                                        }

                                    case 2:
                                        {
                                            cSelected = "H. SG";
                                            break;
                                        }

                                    case 3:
                                        {
                                            cSelected = "Elec";
                                            break;
                                        }
                                }

                                if (string.IsNullOrEmpty(cSelected))
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", "");
                                }
                                else
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", cSelected);
                                }

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BM", ComChecks.Test15);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BN", ComChecks.Test216);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BO", ComChecks.Test217);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BP", ComChecks.Test218);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test9);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BQ", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test10);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BR", selected.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BT", ComChecks.Test219);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BU", ComChecks.Test220);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test119);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BV", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test120);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BX", selected.Name);
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X2", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BE", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BF", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BG", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BH", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BI", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BK", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BM", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BN", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BO", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BP", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BQ", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BR", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BT", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BU", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BV", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BX", "");
                            }

                            ComChecks = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, (int)Enums.AdditionalChecksTypes.CommercialPurgingTestCP16);
                            if (ComChecks is object)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X3", "X");
                                var selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test1);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CA", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test2);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CB", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CC", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test4);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CD", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test5);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CE", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test6);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CF", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test7);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CG", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test8);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CH", selected.Name);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test9);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CI", selected.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CJ", ComChecks.Test11);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CK", ComChecks.Test12);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CL", ComChecks.Test13);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test10);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CM", selected.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CN", ComChecks.Test14);
                                selected = App.DB.Picklists.Get_One_As_Object(ComChecks.Test120);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CO", ComChecks.Test14);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CP", selected.Name);
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X3", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CA", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CB", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CC", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CD", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CE", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CF", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CG", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CH", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CI", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CJ", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CK", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CL", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CM", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CN", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CO", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CP", "");
                            }
                        }

                        var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool Install(EngineerVisits.EngineerVisit EngineerVisit)
            {
                try
                {
                    var Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
                    var oSite = App.DB.Sites.Get(Job.PropertyID);
                    var oCustomer = App.DB.Customer.Customer_Get(oSite.CustomerID);
                    var engineer = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
                    var visitDate = EngineerVisit.StartDateTime;
                    if (visitDate == default)
                    {
                        visitDate = EngineerVisit.ManualEntryOn;
                    }

                    double total = 0.0;
                    double vat = 0.0;
                    var Assets = App.DB.JobAsset.JobAsset_Get_For_Job(Job.JobID);
                    int numberOfAppliances = Assets.Table.Rows.Count;
                    int numberOfPages = Conversions.ToInteger(Math.Ceiling(numberOfAppliances / (double)5));
                    if (numberOfPages == 0)
                    {
                        numberOfPages += 1;
                    }

                    int currentPage = 1;
                    Sites.Site ositeHQ = null;
                    if (!(oSite.CustomerID == (int)Enums.Customer.Domestic))
                    {
                        ositeHQ = App.DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    }

                    foreach (Match wordField in Printing.GetTemplateFields(WordDoc.Content.Text))
                    {
                        var switchExpr = wordField.Value.ToLower();
                        switch (switchExpr)
                        {
                            case var @case when @case == "[JobVisitNumber]".ToLower():
                                {
                                    var argmsWordDoc = WordDoc;
                                    ReplaceText(ref argmsWordDoc, wordField.Value, Job.JobNumber + "-" + EngineerVisit.EngineerVisitID);
                                    break;
                                }

                            case var case1 when case1 == "[VisitDate]".ToLower():
                                {
                                    if (visitDate == default)
                                    {
                                        var argmsWordDoc1 = WordDoc;
                                        ReplaceText(ref argmsWordDoc1, wordField.Value, "");
                                    }
                                    else
                                    {
                                        var argmsWordDoc2 = WordDoc;
                                        ReplaceText(ref argmsWordDoc2, wordField.Value, visitDate.ToLongDateString());
                                    }

                                    break;
                                }

                            case var case2 when case2 == "[GasSafeIDNo]".ToLower():
                                {
                                    if (engineer is null)
                                    {
                                        var argmsWordDoc3 = WordDoc;
                                        ReplaceText(ref argmsWordDoc3, wordField.Value, "");
                                    }
                                    else
                                    {
                                        var argmsWordDoc4 = WordDoc;
                                        ReplaceText(ref argmsWordDoc4, wordField.Value, engineer.GasSafeNo);
                                    }

                                    break;
                                }

                            case var case3 when case3 == "[JobCustomerName]".ToLower():
                                {
                                    var selected = App.DB.Picklists.Get_One_As_Object(EngineerVisit.SignatureSelectedID);
                                    if (selected is null)
                                    {
                                        var argmsWordDoc5 = WordDoc;
                                        ReplaceText(ref argmsWordDoc5, wordField.Value, EngineerVisit.CustomerName);
                                    }
                                    else
                                    {
                                        var argmsWordDoc6 = WordDoc;
                                        ReplaceText(ref argmsWordDoc6, wordField.Value, selected.Name + " " + EngineerVisit.CustomerName);
                                    }

                                    break;
                                }

                            case var case4 when case4 == "[JobAddressName]".ToLower():
                                {
                                    var argmsWordDoc7 = WordDoc;
                                    ReplaceText(ref argmsWordDoc7, wordField.Value, oSite.Name);
                                    break;
                                }

                            case var case5 when case5 == "[JobAddress1]".ToLower():
                                {
                                    var argmsWordDoc8 = WordDoc;
                                    ReplaceText(ref argmsWordDoc8, wordField.Value, oSite.Address1);
                                    break;
                                }

                            case var case6 when case6 == "[JobAddress2]".ToLower():
                                {
                                    var argmsWordDoc9 = WordDoc;
                                    ReplaceText(ref argmsWordDoc9, wordField.Value, oSite.Address2);
                                    break;
                                }

                            case var case7 when case7 == "[JobAddress3]".ToLower():
                                {
                                    var argmsWordDoc10 = WordDoc;
                                    ReplaceText(ref argmsWordDoc10, wordField.Value, oSite.Address3);
                                    break;
                                }

                            case var case8 when case8 == "[JobPostCode]".ToLower():
                                {
                                    var argmsWordDoc11 = WordDoc;
                                    ReplaceText(ref argmsWordDoc11, wordField.Value, Helper.FormatPostcode(oSite.Postcode));
                                    break;
                                }

                            case var case9 when case9 == "[JobTelNo]".ToLower():
                                {
                                    var argmsWordDoc12 = WordDoc;
                                    ReplaceText(ref argmsWordDoc12, wordField.Value, oSite.TelephoneNum);
                                    break;
                                }

                            case var case10 when case10 == "[LandLordName]".ToLower():
                                {
                                    if (ositeHQ is object)
                                    {
                                        var argmsWordDoc13 = WordDoc;
                                        ReplaceText(ref argmsWordDoc13, wordField.Value, App.DB.Customer.Customer_Get(oSite.CustomerID).Name);
                                    }
                                    else
                                    {
                                        var argmsWordDoc14 = WordDoc;
                                        ReplaceText(ref argmsWordDoc14, wordField.Value, "");
                                    }

                                    break;
                                }

                            case var case11 when case11 == "[LandLordAddress1]".ToLower():
                                {
                                    if (ositeHQ is object)
                                    {
                                        string strAddress = string.Empty;
                                        if (ositeHQ.Address1.Length > 0)
                                        {
                                            strAddress += ositeHQ.Address1;
                                        }

                                        var argmsWordDoc15 = WordDoc;
                                        ReplaceText(ref argmsWordDoc15, wordField.Value, strAddress);
                                    }
                                    else
                                    {
                                        var argmsWordDoc16 = WordDoc;
                                        ReplaceText(ref argmsWordDoc16, wordField.Value, "");
                                    }

                                    break;
                                }

                            case var case12 when case12 == "[LandLordAddress2]".ToLower():
                                {
                                    if (ositeHQ is object)
                                    {
                                        string strAddress = string.Empty;
                                        if (ositeHQ.Address2.Length > 0)
                                        {
                                            strAddress += ositeHQ.Address2;
                                        }

                                        var argmsWordDoc17 = WordDoc;
                                        ReplaceText(ref argmsWordDoc17, wordField.Value, strAddress);
                                    }
                                    else
                                    {
                                        var argmsWordDoc18 = WordDoc;
                                        ReplaceText(ref argmsWordDoc18, wordField.Value, "");
                                    }

                                    break;
                                }

                            case var case13 when case13 == "[LandLordAddress3]".ToLower():
                                {
                                    if (ositeHQ is object)
                                    {
                                        string strAddress = string.Empty;
                                        if (ositeHQ.Address3.Length > 0)
                                        {
                                            strAddress += ositeHQ.Address3;
                                        }

                                        var argmsWordDoc19 = WordDoc;
                                        ReplaceText(ref argmsWordDoc19, wordField.Value, strAddress);
                                    }
                                    else
                                    {
                                        var argmsWordDoc20 = WordDoc;
                                        ReplaceText(ref argmsWordDoc20, wordField.Value, "");
                                    }

                                    break;
                                }

                            case var case14 when case14 == "[LLPostcode]".ToLower():
                                {
                                    if (ositeHQ is object)
                                    {
                                        var argmsWordDoc21 = WordDoc;
                                        ReplaceText(ref argmsWordDoc21, wordField.Value, Helper.FormatPostcode(ositeHQ.Postcode));
                                    }
                                    else
                                    {
                                        var argmsWordDoc22 = WordDoc;
                                        ReplaceText(ref argmsWordDoc22, wordField.Value, "");
                                    }

                                    break;
                                }

                            case var case15 when case15 == "[LLTelNo]".ToLower():
                                {
                                    if (ositeHQ is object)
                                    {
                                        var argmsWordDoc23 = WordDoc;
                                        ReplaceText(ref argmsWordDoc23, wordField.Value, ositeHQ.TelephoneNum);
                                    }
                                    else
                                    {
                                        var argmsWordDoc24 = WordDoc;
                                        ReplaceText(ref argmsWordDoc24, wordField.Value, "");
                                    }

                                    break;
                                }

                            case var case16 when case16 == "[PO]".ToLower():
                                {
                                    if (Job.PONumber.Trim().Length == 0)
                                    {
                                        var argmsWordDoc25 = WordDoc;
                                        ReplaceText(ref argmsWordDoc25, wordField.Value, "N/A");
                                    }
                                    else
                                    {
                                        var argmsWordDoc26 = WordDoc;
                                        ReplaceText(ref argmsWordDoc26, wordField.Value, Job.PONumber);
                                    }

                                    break;
                                }

                            case var case17 when case17 == "[From]".ToLower():
                                {
                                    var sd = Helper.MakeDateTimeValid(EngineerVisit.StartDateTime);
                                    if (sd == default)
                                    {
                                        if (Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn) == default)
                                        {
                                            var argmsWordDoc27 = WordDoc;
                                            ReplaceText(ref argmsWordDoc27, wordField.Value, "");
                                        }
                                        else
                                        {
                                            sd = Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn);
                                            var argmsWordDoc28 = WordDoc;
                                            ReplaceText(ref argmsWordDoc28, wordField.Value, sd.ToShortTimeString());
                                        }
                                    }
                                    else
                                    {
                                        var argmsWordDoc29 = WordDoc;
                                        ReplaceText(ref argmsWordDoc29, wordField.Value, sd.ToShortTimeString());
                                    }

                                    break;
                                }

                            case var case18 when case18 == "[To]".ToLower():
                                {
                                    var ed = Helper.MakeDateTimeValid(EngineerVisit.EndDateTime);
                                    if (ed == default)
                                    {
                                        if (Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn) == default)
                                        {
                                            var argmsWordDoc30 = WordDoc;
                                            ReplaceText(ref argmsWordDoc30, wordField.Value, "");
                                        }
                                        else
                                        {
                                            ed = Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn);
                                            var argmsWordDoc31 = WordDoc;
                                            ReplaceText(ref argmsWordDoc31, wordField.Value, ed.ToShortTimeString());
                                        }
                                    }
                                    else
                                    {
                                        var argmsWordDoc32 = WordDoc;
                                        ReplaceText(ref argmsWordDoc32, wordField.Value, ed.ToShortTimeString());
                                    }

                                    break;
                                }

                            case var case19 when case19 == "[GASSAFEID]".ToLower():
                                {
                                    var eng = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
                                    if (eng is null)
                                    {
                                        var argmsWordDoc33 = WordDoc;
                                        ReplaceText(ref argmsWordDoc33, wordField.Value, "");
                                    }
                                    else
                                    {
                                        var argmsWordDoc34 = WordDoc;
                                        ReplaceText(ref argmsWordDoc34, wordField.Value, eng.GasSafeNo);
                                    }

                                    break;
                                }

                            case var case20 when case20 == "[Engineer]".ToLower():
                                {
                                    var eng = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
                                    if (eng is null)
                                    {
                                        var argmsWordDoc35 = WordDoc;
                                        ReplaceText(ref argmsWordDoc35, wordField.Value, "");
                                    }
                                    else
                                    {
                                        var argmsWordDoc36 = WordDoc;
                                        ReplaceText(ref argmsWordDoc36, wordField.Value, eng.Name);
                                    }

                                    break;
                                }

                            case var case21 when case21 == "[WorkRequired]".ToLower():
                                {
                                    var argmsWordDoc37 = WordDoc;
                                    ReplaceText(ref argmsWordDoc37, wordField.Value, EngineerVisit.NotesToEngineer);
                                    break;
                                }
                        }
                    }

                    MsWordApp.Selection.WholeStory();
                    MsWordApp.Selection.Copy();
                    numberOfAppliances = Add_Appliances_PreVisit(WordDoc, numberOfAppliances, currentPage, numberOfPages, Assets.Table, null, 1);
                    // While (numberOfAppliances > 0)
                    // WordApp.Selection.EndKey()
                    // WordApp.Selection.InsertBreak(Word.WdBreakType.wdPageBreak)
                    // WordApp.Selection.Paste()
                    // currentPage += 1

                    // numberOfAppliances = Add_Appliances_PreVisit(WordDoc, numberOfAppliances, currentPage, numberOfPages, Assets.Table, Nothing, currentPage)
                    // End While

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool SiteLetter(string template, string savePath)
            {
                try
                {
                    var oContact = App.DB.Contact.Contact_Get(Conversions.ToInteger(((ArrayList)DetailsToPrint)[0]));
                    var oSite = App.DB.Sites.Get(((ArrayList)DetailsToPrint)[1]);
                    var byteArray = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        var wordDoc = WordprocessingDocument.Open(mm, true);
                        using (wordDoc)
                        {
                            AddCompanyDetails(wordDoc, true, true);
                            string name = oContact is null ? oSite.Name : oContact.FirstName + " " + oContact.Surname;
                            PrintHelper.ReplaceText(wordDoc, "[Name]", name);
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSite.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSite.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSite.Address3);
                            PrintHelper.ReplaceText(wordDoc, "[Address4]", oSite.Address4);
                            PrintHelper.ReplaceText(wordDoc, "[Address5]", oSite.Address5);
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[theDate]", DateTime.Now.ToString("dd MMMM yyyy"));
                        }

                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        savePath = FileCheck(savePath);
                        var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                        var linkedDoc = new Documentss.Documents();
                        linkedDoc.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblSite);
                        linkedDoc.SetRecordID = oSite.SiteID;
                        linkedDoc.SetDocumentTypeID = 205;
                        linkedDoc.SetName = Path.GetFileName(savePath);
                        linkedDoc.SetNotes = "";
                        linkedDoc.SetLocation = savePath;
                        var cV = new Documentss.DocumentsValidator();
                        cV.Validate(linkedDoc);
                        linkedDoc = App.DB.Documents.Insert(linkedDoc);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool Credit()
            {
                try
                {
                    int rowIndex = 1;
                    // Dim dt As DataTable = CType(DetailsToPrint.item(0), DataTable)
                    DataTable dt = (DataTable)DetailsToPrint;
                    string Supplier = "";
                    string address1 = "";
                    string address2 = "";
                    string address3 = "";
                    string address4 = "";
                    string address5 = "";
                    string postcode = "";
                    string accountNumber = "";
                    string CreditRef = "";
                    foreach (DataRow r in dt.Rows)
                    {
                        if (Conversions.ToBoolean(r["Tick"]) == true)
                        {
                            {
                                var withBlock = WordDoc.Tables[1];
                                {
                                    var withBlock1 = withBlock.Rows.Add();
                                    withBlock1.Range.Font.Bold = Conversions.ToInteger(false);
                                    withBlock1.Range.Font.Size = 7;
                                    withBlock1.Borders[WD.WdBorderType.wdBorderTop].LineStyle = WD.WdLineStyle.wdLineStyleNone;
                                    withBlock1.Borders[WD.WdBorderType.wdBorderBottom].LineStyle = WD.WdLineStyle.wdLineStyleNone;
                                }

                                rowIndex += 1;
                                withBlock.Cell(rowIndex, 1).Range.Text = Helper.MakeStringValid(r["CreditReference"]);
                                withBlock.Cell(rowIndex, 2).Range.Text = Helper.MakeStringValid(r["OrderReference"]);
                                withBlock.Cell(rowIndex, 3).Range.Text = Helper.MakeStringValid(r["PartNumber"]);
                                withBlock.Cell(rowIndex, 4).Range.Text = Helper.MakeStringValid(r["PartName"]);
                                withBlock.Cell(rowIndex, 5).Range.Text = Helper.MakeIntegerValid(r["Qty"]).ToString();
                                withBlock.Cell(rowIndex, 6).Range.Text = Strings.Format(Helper.MakeDoubleValid(r["Price"]), "C");
                                withBlock.Cell(rowIndex, 7).Range.Text = Strings.Format(Helper.MakeDoubleValid(r["Total"]), "C");
                                withBlock.Cell(rowIndex, 1).Range.ParagraphFormat.Alignment = WD.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 2).Range.ParagraphFormat.Alignment = WD.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 3).Range.ParagraphFormat.Alignment = WD.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 4).Range.ParagraphFormat.Alignment = WD.WdParagraphAlignment.wdAlignParagraphLeft;
                                Supplier = Helper.MakeStringValid(r["Supplier"]);
                                address1 = Helper.MakeStringValid(r["Address1"]);
                                address2 = Helper.MakeStringValid(r["Address2"]);
                                address3 = Helper.MakeStringValid(r["Address3"]);
                                address4 = Helper.MakeStringValid(r["Address4"]);
                                address5 = Helper.MakeStringValid(r["Address5"]);
                                postcode = Helper.FormatPostcode(r["Postcode"]);
                                accountNumber = Helper.MakeStringValid(r["GaswayAccount"]);
                            }
                        }
                    }

                    foreach (Match wordField in Printing.GetTemplateFields(WordDoc.Content.Text))
                    {
                        var switchExpr = wordField.Value.ToLower();
                        switch (switchExpr)
                        {
                            case var @case when @case == "[CombinedCreditNumber]".ToLower():
                                {
                                    var argmsWordDoc = WordDoc;
                                    ReplaceText(ref argmsWordDoc, wordField.Value, "");
                                    break;
                                }

                            case var case1 when case1 == "[Name]".ToLower():
                                {
                                    var argmsWordDoc1 = WordDoc;
                                    ReplaceText(ref argmsWordDoc1, wordField.Value, Supplier);
                                    break;
                                }

                            case var case2 when case2 == "[Address1]".ToLower():
                                {
                                    var argmsWordDoc2 = WordDoc;
                                    ReplaceText(ref argmsWordDoc2, wordField.Value, address1);
                                    break;
                                }

                            case var case3 when case3 == "[Address2]".ToLower():
                                {
                                    var argmsWordDoc3 = WordDoc;
                                    ReplaceText(ref argmsWordDoc3, wordField.Value, address2);
                                    break;
                                }

                            case var case4 when case4 == "[Address3]".ToLower():
                                {
                                    var argmsWordDoc4 = WordDoc;
                                    ReplaceText(ref argmsWordDoc4, wordField.Value, address3);
                                    break;
                                }

                            case var case5 when case5 == "[Address4]".ToLower():
                                {
                                    var argmsWordDoc5 = WordDoc;
                                    ReplaceText(ref argmsWordDoc5, wordField.Value, address4);
                                    break;
                                }

                            case var case6 when case6 == "[Address5]".ToLower():
                                {
                                    var argmsWordDoc6 = WordDoc;
                                    ReplaceText(ref argmsWordDoc6, wordField.Value, address5);
                                    break;
                                }

                            case var case7 when case7 == "[Postcode]".ToLower():
                                {
                                    var argmsWordDoc7 = WordDoc;
                                    ReplaceText(ref argmsWordDoc7, wordField.Value, Helper.FormatPostcode(postcode));
                                    break;
                                }

                            case var case8 when case8 == "[Date]".ToLower():
                                {
                                    var argmsWordDoc8 = WordDoc;
                                    ReplaceText(ref argmsWordDoc8, wordField.Value, Strings.Format(DateAndTime.Now, "dd MMMM yyyy"));
                                    break;
                                }

                            case var case9 when case9 == "[OUR_ACCOUNT_SUPPLIER]".ToLower():
                                {
                                    var argmsWordDoc9 = WordDoc;
                                    ReplaceText(ref argmsWordDoc9, wordField.Value, accountNumber);
                                    break;
                                }

                            case var case10 when case10 == "[User]".ToLower():
                                {
                                    var argmsWordDoc10 = WordDoc;
                                    ReplaceText(ref argmsWordDoc10, wordField.Value, App.loggedInUser.Fullname);
                                    break;
                                }
                        }
                    }

                    WordDoc.Content.Font.Name = "Arial";
                    WordDoc.Tables[1].AllowAutoFit = true;
                    WordDoc.Tables[1].AutoFitBehavior(WD.WdAutoFitBehavior.wdAutoFitContent);
                    WordDoc.Tables[1].Range.Font.Size = 8;
                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool AlphaCredit()
            {
                try
                {
                    int rowIndex = 1;
                    DataTable dt = (DataTable)DetailsToPrint;
                    foreach (DataRow r in dt.Rows)
                    {
                        if (Conversions.ToBoolean(r["Tick"]) == true)
                        {
                            {
                                var withBlock = WordDoc.Tables[1];
                                if (!(rowIndex == 1))
                                {
                                    {
                                        var withBlock1 = withBlock.Rows.Add();
                                        withBlock1.Range.Font.Bold = Conversions.ToInteger(false);
                                        withBlock1.Range.Font.Size = 7;
                                    }
                                }

                                rowIndex += 1;
                                withBlock.Cell(rowIndex, 1).Range.Text = "";
                                withBlock.Cell(rowIndex, 2).Range.Text = Helper.MakeStringValid(r["PartName"]);
                                withBlock.Cell(rowIndex, 2).WordWrap = true;
                                withBlock.Cell(rowIndex, 3).Range.Text = Helper.MakeStringValid(r["PartNumber"]);
                                withBlock.Cell(rowIndex, 3).WordWrap = true;
                                withBlock.Cell(rowIndex, 4).Range.Text = "";
                                withBlock.Cell(rowIndex, 5).Range.Text = "";
                                withBlock.Cell(rowIndex, 1).Range.ParagraphFormat.Alignment = WD.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 2).Range.ParagraphFormat.Alignment = WD.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 3).Range.ParagraphFormat.Alignment = WD.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 4).Range.ParagraphFormat.Alignment = WD.WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                        }
                    }

                    WordDoc.Content.Font.Name = "Arial";
                    WordDoc.Tables[1].AllowAutoFit = true;
                    WordDoc.Tables[1].AutoFitBehavior(WD.WdAutoFitBehavior.wdAutoFitWindow);
                    WordDoc.Tables[1].Range.Font.Size = 8;
                    WordDoc.Tables[1].Rows[1].Range.Font.Size = 11;
                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private string GetDocumentGoldenRule(string templateFilePath, int refNo)
            {
                // ##Neopost|DocumentID(invoice)|PostalClass(2)|MergeCriteria(MAL)|DocumentSortation(1)|OutputFormat(D)|Colour/Mono(M)|CustomerID(CID)
                string neopost = "##Neopost";
                string documentType = string.Empty;
                string postalClass = "2";
                string mergeCriteria = "MAL";
                string documentOrder = string.Empty;
                string outputFormat = "S";
                string color = "M";
                string filename = Path.GetFileNameWithoutExtension(templateFilePath);
                switch (true)
                {
                    case object _ when (filename.ToLower() ?? "") == ("GSRCoveringLetter".ToLower() ?? ""):
                        {
                            documentType = "CoverLetter";
                            documentOrder = "1";
                            break;
                        }

                    case object _ when filename.ToLower().Contains("AnnualSafetyInspection".ToLower()):
                    case object _ when filename.ToLower().Contains("PatchCheck".ToLower()):
                        {
                            documentType = "AnnualSafetyInspection";
                            documentOrder = "1";
                            break;
                        }

                    case object _ when filename.ToLower().Contains("GSRDue".ToLower()):
                        {
                            documentType = "ServiceReminder";
                            documentOrder = "1";
                            break;
                        }

                    case object _ when filename.ToLower().Contains("TestingLetter".ToLower()):
                    case object _ when filename.ToLower().Contains("ElecMainLetter".ToLower()):
                        {
                            documentType = "ElectricalTesting";
                            documentOrder = "1";
                            break;
                        }

                    case object _ when filename.ToLower().Contains("GSR".ToLower()):
                        {
                            documentType = "GSR";
                            documentOrder = "2";
                            break;
                        }

                    case object _ when filename.ToLower().Contains("ContractDD".ToLower()):
                        {
                            documentType = "Contract";
                            documentOrder = "1";
                            break;
                        }

                    case object _ when filename.ToLower().Contains("ContractOption".ToLower()):
                        {
                            documentType = "Contract";
                            documentOrder = "2";
                            break;
                        }

                    case object _ when filename.ToLower().Contains("Receipt".ToLower()):
                    case object _ when filename.ToLower().Contains("Invoice".ToLower()):
                        {
                            documentType = "Invoice";
                            documentOrder = "3";
                            break;
                        }

                    case object _ when filename.ToLower().Contains("ContractTransfer".ToLower()):
                        {
                            documentType = "Contract";
                            documentOrder = "4";
                            break;
                        }
                }

                string goldenRule = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|", neopost, documentType, postalClass, mergeCriteria, documentOrder, outputFormat, color, refNo);
                return goldenRule;
            }

            private bool GenerateDDMS(DataRow[] drContracts)
            {
                var dtDdmsNew = new DataTable();
                dtDdmsNew.Columns.Add("Ref");
                dtDdmsNew.Columns.Add("Unknown");
                dtDdmsNew.Columns.Add("Salutation");
                dtDdmsNew.Columns.Add("FirstName");
                dtDdmsNew.Columns.Add("OtherName");
                dtDdmsNew.Columns.Add("LastName");
                dtDdmsNew.Columns.Add("Unknown1");
                dtDdmsNew.Columns.Add("Unknown2");
                dtDdmsNew.Columns.Add("Address1");
                dtDdmsNew.Columns.Add("Address2");
                dtDdmsNew.Columns.Add("Address3");
                dtDdmsNew.Columns.Add("Address4");
                dtDdmsNew.Columns.Add("Unknown3");
                dtDdmsNew.Columns.Add("Tel");
                dtDdmsNew.Columns.Add("Unknown4");
                dtDdmsNew.Columns.Add("Postcode");
                dtDdmsNew.Columns.Add("SortCode");
                dtDdmsNew.Columns.Add("AccNum");
                dtDdmsNew.Columns.Add("NameOnAcc");
                dtDdmsNew.Columns.Add("Ref2");
                dtDdmsNew.Columns.Add("InvoiceNumber");
                dtDdmsNew.Columns.Add("Type");
                dtDdmsNew.Columns.Add("SecondPayment");
                dtDdmsNew.Columns.Add("FirstPayment");
                dtDdmsNew.Columns.Add("ProcessDate");
                dtDdmsNew.Columns.Add("Unknown5");
                dtDdmsNew.Columns.Add("Installments");
                dtDdmsNew.Columns.Add("SecondPayment2");
                dtDdmsNew.Columns.Add("Unknown6");
                dtDdmsNew.Columns.Add("SecondPayment3");
                dtDdmsNew.Columns.Add("ContractEnd");
                var dtDdmsAmend = new DataTable();
                dtDdmsAmend = dtDdmsNew.Clone();
                try
                {
                    foreach (DataRow dr in drContracts)
                    {
                        string ddmsRef = Helper.MakeStringValid(dr["DDMSRef"]);
                        string contractRef = Helper.MakeStringValid(dr["ContractReference"]);
                        string payType = Helper.MakeStringValid(dr["Type"]);
                        int siteId = Helper.MakeIntegerValid(dr["siteid"]);
                        int installments = Helper.MakeIntegerValid(dr["installments"]);
                        int pifId = Helper.MakeIntegerValid(dr["PreviousInvoiceFrequencyID"]) == 0 ? Helper.MakeIntegerValid(dr["InvoiceFrequencyID"]) : Helper.MakeIntegerValid(dr["PreviousInvoiceFrequencyID"]);
                        Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Conversions.ToInteger(Helper.MakeIntegerValid(dr["InvoiceFrequencyID"]));
                        bool paymentMade = false;
                        if (installments % 12 == 0 && installments != 0)
                        {
                        }
                        else
                        {
                            paymentMade = true;
                        }

                        var processing = Helper.MakeDateTimeValid(dr["DDProcessingDate"]);
                        var contractEnd = Helper.MakeDateTimeValid(dr["ContractEndDate"]);
                        var wrapper = new Simple3Des(p);
                        string ddSort = string.Empty;
                        string ddAcc = string.Empty;
                        try
                        {
                            ddSort = wrapper.DecryptData(Helper.MakeStringValid(dr["sc"]));
                            ddAcc = wrapper.DecryptData(Helper.MakeStringValid(dr["Ac"]));
                        }
                        catch (Exception ex)
                        {
                        }

                        object cc = null;
                        if (ddmsRef.Length > 3)
                        {
                            cc = App.DB.ExecuteScalar("SELECT COUNT(DDMSREF) FROM tblContractOriginal co " + "INNER JOIN tblContractOriginalSite cos ON cos.ContractID = co.ContractID " + "Where co.Deleted = 0 AND co.DDMSREF = '" + ddmsRef + "' AND cos.SiteID <> " + siteId);
                        }
                        else
                        {
                            cc = App.DB.ExecuteScalar("SELECT COUNT(DDMSREF) FROM tblContractOriginal co " + "INNER JOIN tblContractOriginalSite cos ON cos.ContractID = co.ContractID " + "Where co.Deleted = 0 AND co.DDMSREF = '" + contractRef + "' AND cos.SiteID <> " + siteId);
                        }

                        if (Helper.MakeIntegerValid(cc) < 1)
                        {
                            double priceDiff = Helper.MakeDoubleValid(dr["FirstAmount"]) - Helper.MakeDoubleValid(dr["SecondPayment"]);
                            var drDDMSNew = dtDdmsNew.NewRow();
                            drDDMSNew["Ref"] = ddmsRef.Length > 3 ? ddmsRef : contractRef;
                            drDDMSNew["Salutation"] = Helper.MakeStringValid(dr["PayerSalutation"]).Replace(",", "");
                            drDDMSNew["FirstName"] = Helper.MakeStringValid(dr["PayerFirst"]).Replace(",", "");
                            drDDMSNew["LastName"] = Helper.MakeStringValid(dr["PayerSurname"]).Replace(",", "");
                            drDDMSNew["Address1"] = Helper.MakeStringValid(dr["PayerAddress1"]).Replace(",", "");
                            drDDMSNew["Address2"] = Helper.MakeStringValid(dr["PayerAddress2"]).Replace(",", "");
                            drDDMSNew["Address3"] = Helper.MakeStringValid(dr["PayerAddress3"]).Replace(",", "");
                            drDDMSNew["Address4"] = Helper.MakeStringValid(dr["PayerAddress4"]).Replace(",", "");
                            drDDMSNew["Tel"] = Helper.MakeStringValid(dr["PayerTel"]).Replace(",", "");
                            drDDMSNew["Postcode"] = Helper.FormatPostcode(dr["PayerPostCode"]).Replace(",", "");
                            drDDMSNew["SortCode"] = ddSort;
                            drDDMSNew["AccNum"] = ddAcc;
                            drDDMSNew["NameOnAcc"] = Helper.MakeStringValid(dr["AccName"]).Length > 0 ? Helper.MakeStringValid(dr["AccName"]).Replace(",", "") : Helper.MakeStringValid(dr["PayerName"]).Replace(",", "");
                            drDDMSNew["Ref2"] = ddmsRef.Length > 3 ? ddmsRef : contractRef;
                            drDDMSNew["InvoiceNumber"] = Helper.MakeStringValid(dr["InvoiceNumber"]).Replace(",", "");
                            drDDMSNew["Type"] = "17";
                            drDDMSNew["SecondPayment"] = Helper.MakeStringValid(dr["SecondPayment"]).Replace(",", "");
                            drDDMSNew["FirstPayment"] = paymentMade ? "0" : Helper.MakeStringValid(priceDiff.ToString());
                            drDDMSNew["ProcessDate"] = !paymentMade ? DateHelper.GetFirstDayOfMonth(processing).ToString("dd/MM/yyyy") : DateHelper.GetFirstDayOfMonth(processing.AddMonths(1)).ToString("dd/MM/yyyy");
                            drDDMSNew["Installments"] = Helper.MakeStringValid(dr["Installments"]).Replace(",", "");
                            drDDMSNew["SecondPayment2"] = Helper.MakeStringValid(dr["SecondPayment"]);
                            drDDMSNew["SecondPayment3"] = paymentMade ? Helper.MakeStringValid(dr["SecondPayment"]) : Helper.MakeStringValid(dr["FirstAmount"]);
                            drDDMSNew["ContractEnd"] = contractEnd.ToString("dd/MM/yyyy");
                            if (Helper.MakeIntegerValid(dr["Renewed"]) == 0 || pifId != Helper.MakeIntegerValid(dr["InvoiceFrequencyID"]) || (payType ?? "") == "TRANSD" || (payType ?? "") == "AMMENDD" || (payType ?? "") == "RENEWALD")
                            {
                                if (installments == 0 && invoiceFreq != Enums.InvoiceFrequency.AnnuallyDD)
                                {
                                }
                                else
                                {
                                    dtDdmsNew.Rows.Add(drDDMSNew);
                                }
                            }
                            else if ((payType ?? "") != "AMMEND" && (payType ?? "") != "TRANS")
                            {
                                if (installments == 0)
                                {
                                }
                                else
                                {
                                    dtDdmsAmend.Rows.Add(drDDMSNew.ItemArray);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate ddms : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    string ddmsNewCsv = "DDMS_IMPORT_NEW" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".csv";
                    string ddmsAmendCsv = "DDMS_IMPORT_RENEW_AMMEND" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".csv";
                    string ddmsNewCsvData = ExportHelper.DataTableToCSVNoHeaders(dtDdmsNew);
                    string ddmsAmendCsvData = string.Format(ExportHelper.DataTableToCSVNoHeaders(dtDdmsAmend));
                    string fileDir = App.TheSystem.Configuration.DocumentsLocation + @"Contracts\DDMS\";
                    Directory.CreateDirectory(fileDir);
                    var fsDdmsNew = new FileStream(fileDir + ddmsNewCsv, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    using (fsDdmsNew)
                    {
                        var info = new UTF8Encoding(true).GetBytes(ddmsNewCsvData);
                        fsDdmsNew.Write(info, 0, info.Length);
                    }

                    fsDdmsNew.Close();
                    var fsDdmsAmend = new FileStream(fileDir + ddmsAmendCsv, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    using (fsDdmsAmend)
                    {
                        var info = new UTF8Encoding(true).GetBytes(ddmsAmendCsvData);
                        fsDdmsAmend.Write(info, 0, info.Length);
                    }

                    fsDdmsAmend.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate ddms : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private string GenerateRenewalLetters(DataRow[] drContracts)
            {
                string fileName = "Contract_Renewal_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                string fileDir = App.TheSystem.Configuration.DocumentsLocation + @"Contracts\Renewal";
                Directory.CreateDirectory(fileDir);
                string filePath = fileDir + @"\" + fileName;
                File.Copy(Application.StartupPath + @"\Templates\Blank.docx", filePath);
                try
                {
                    var batch = WordprocessingDocument.Open(filePath, true);
                    using (batch)
                        foreach (DataRow dr in drContracts)
                        {
                            string payType = Helper.MakeStringValid(dr["Type"]);
                            bool success = false;
                            bool renewed = Helper.MakeBooleanValid(dr["Renewed"]);
                            Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Conversions.ToInteger(Helper.MakeIntegerValid(dr["InvoiceFrequencyID"]));
                            int installments = Helper.MakeIntegerValid(dr["installments"]);
                            if ((payType ?? "") == "AMMEND" || (payType ?? "") == "TRANS")
                            {
                            }
                            else if ((!renewed && installments > 0) | ((payType ?? "") == "TRANSD" || (payType ?? "") == "RENEWALD" || (payType ?? "") == "AMMENDD") | (!renewed && invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD))
                            {
                                success = GenerateDDLetter(dr, batch);
                                if (!success)
                                {
                                    throw new Exception();
                                }
                            }
                            else if (installments > 0)
                            {
                                success = GenerateDDRenewalLetter(dr, batch);
                                if (!success)
                                {
                                    throw new Exception();
                                }
                            }

                            success = GenerateContractLetter(dr, batch);
                            if (!success)
                            {
                                throw new Exception();
                            }

                            if (!string.IsNullOrEmpty(Helper.MakeStringValid(dr["InvoiceNumber"])))
                            {
                                if (string.IsNullOrEmpty(Helper.MakeStringValid(dr["InitialPaymentType"])) || (Helper.MakeStringValid(dr["InitialPaymentType"]) ?? "") != "Invoice")
                                {
                                    success = GenerateReceipt(dr, batch);
                                    if (!success)
                                    {
                                        throw new Exception();
                                    }
                                }
                                else
                                {
                                    success = GenerateContractInvoice(dr, batch);
                                    if (!success)
                                    {
                                        throw new Exception();
                                    }
                                }
                            }

                            if ((payType ?? "") == "TRANS")
                            {
                                success = GenerateTransferLetter(dr, batch);
                                if (!success)
                                {
                                    throw new Exception();
                                }
                            }
                        }

                    return filePath;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate renewal letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }

            private bool GenerateDDLetter(DataRow dr, WordprocessingDocument batch)
            {
                try
                {
                    if (Helper.MakeStringValid(dr["UpgradedFrom"]).Length > 0)
                        return true;
                    Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Conversions.ToInteger(Helper.MakeIntegerValid(dr["InvoiceFrequencyID"]));
                    string template = Application.StartupPath + @"\Templates\Contracts";
                    template += invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD ? @"\ContractDDA.docx" : @"\ContractDD.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr["ContractID"]));
                    var fileByte = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        var doc = WordprocessingDocument.Open(mm, true);
                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                            string companyName = Helper.MakeStringValid(dr["PayerSalutation"]).Length > 0 ? Helper.MakeStringValid(Conversions.ToString(dr["PayerSalutation"] + " ") + dr["PayerSurname"]) : Helper.MakeStringValid(dr["PayerName"]);
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName);
                            PrintHelper.ReplaceText(doc, "[Name]", companyName);
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr["PayerAddress1"]));
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr["PayerAddress2"]));
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr["PayerAddress3"]));
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr["PayerPostcode"]));
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr["ContractType"]));
                            string ddmsRef = Helper.MakeStringValid(dr["DDMSRef"]).Length > 3 ? Helper.MakeStringValid(dr["DDMSRef"]) : Helper.MakeStringValid(dr["ContractReference"]);
                            PrintHelper.ReplaceText(doc, "[DebitRef]", ddmsRef);
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(Conversions.ToString(Conversions.ToString(Conversions.ToString(dr["ContractReference"] + " - ") + dr["siteAddress1"] + ", ") + dr["siteAddress2"] + ", ") + dr["sitePostcode"]));
                            int installments = Helper.MakeIntegerValid(dr["installments"]);
                            bool paymentMade = false;
                            var contractStart = Helper.MakeDateTimeValid(dr["ContractStartDate"]);
                            var processing = Helper.MakeDateTimeValid(dr["DDProcessingDate"]);
                            if (installments % 12 == 0)
                            {
                                processing = contractStart == DateHelper.GetFirstDayOfMonth(contractStart) ? DateHelper.GetFirstDayOfMonth(contractStart) : DateHelper.GetFirstDayOfMonth(contractStart.AddMonths(1));
                                PrintHelper.ReplaceText(doc, "[FirstDate]", processing.ToString("dd/MM/yyyy"));
                            }
                            else
                            {
                                paymentMade = true;
                                PrintHelper.ReplaceText(doc, "[FirstDate]", DateHelper.GetFirstDayOfMonth(processing.AddMonths(1)).ToString("dd/MM/yyyy"));
                            }

                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(Conversions.ToString(Conversions.ToString(dr["siteAddress1"] + ", ") + dr["siteAddress2"] + ", ") + dr["sitePostcode"]));
                            PrintHelper.ReplaceText(doc, "[First]", paymentMade ? Helper.MakeDoubleValid(dr["SecondPayment"]).ToString("C") : Helper.MakeDoubleValid(dr["FirstAmount"]).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[Second]", Helper.MakeDoubleValid(dr["SecondPayment"]).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[Inst]", (Helper.MakeIntegerValid(dr["Installments"]) - 1).ToString());
                            string acName = Helper.MakeStringValid(dr["AccName"]).Length > 0 ? Helper.MakeStringValid(dr["AccName"]) : Helper.MakeStringValid(dr["PayerName"]);
                            PrintHelper.ReplaceText(doc, "[AcName]", acName);
                            var wrapper = new Simple3Des(p);
                            string ddSort = string.Empty;
                            string ddAcc = string.Empty;
                            try
                            {
                                ddSort = wrapper.DecryptData(Helper.MakeStringValid(dr["sc"]));
                                ddAcc = wrapper.DecryptData(Helper.MakeStringValid(dr["Ac"]));
                            }
                            catch
                            {
                            }

                            PrintHelper.ReplaceText(doc, "[AcNumber]", ddAcc);
                            PrintHelper.ReplaceText(doc, "[ScCode]", ddSort);
                            double ahe = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                            PrintHelper.ReplaceText(doc, "[AHE]", invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD ? ahe.ToString("C") : Math.Round(ahe / 12, 2).ToString("C"));
                            int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                            int addBreaks = 1;
                            addBreaks += pageCount % 2 == 0 ? 0 : 1;
                            for (int i = 0, loopTo = addBreaks - 1; i <= loopTo; i++)
                                doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            doc.MainDocumentPart.Document.Save();
                            string saveDir = App.TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr["ContractReference"]);
                            Directory.CreateDirectory(saveDir);
                            string fileName = "DD_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                            fileStream.Close();
                        }

                        var mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr["ContractID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;
                        using (mm)
                            chunk.FeedData(mm);
                        var altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate dd letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateDDRenewalLetter(DataRow dr, WordprocessingDocument batch)
            {
                try
                {
                    Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Conversions.ToInteger(Helper.MakeIntegerValid(dr["InvoiceFrequencyID"]));
                    string template = Application.StartupPath + @"\Templates\Contracts";
                    template += invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD ? @"\ContractDDARenewal.docx" : @"\ContractDDRenewal.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr["ContractID"]));
                    var fileByte = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        var doc = WordprocessingDocument.Open(mm, true);
                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                            string companyName = Helper.MakeStringValid(dr["PayerSalutation"]).Length > 0 ? Helper.MakeStringValid(Conversions.ToString(dr["PayerSalutation"] + " ") + dr["PayerSurname"]) : Helper.MakeStringValid(dr["PayerName"]);
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName);
                            PrintHelper.ReplaceText(doc, "[Name]", companyName);
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr["PayerAddress1"]));
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr["PayerAddress2"]));
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr["PayerAddress3"]));
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr["PayerPostcode"]));
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr["ContractType"]));
                            string ddmsRef = Helper.MakeStringValid(dr["DDMSRef"]).Length > 3 ? Helper.MakeStringValid(dr["DDMSRef"]) : Helper.MakeStringValid(dr["ContractReference"]);
                            PrintHelper.ReplaceText(doc, "[DebitRef]", ddmsRef);
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(Conversions.ToString(Conversions.ToString(Conversions.ToString(dr["ContractReference"] + " - ") + dr["siteAddress1"] + ", ") + dr["siteAddress2"] + ", ") + dr["sitePostcode"]));
                            int installments = Helper.MakeIntegerValid(dr["installments"]);
                            bool paymentMade = false;
                            var contractStart = Helper.MakeDateTimeValid(dr["ContractStartDate"]);
                            var processing = Helper.MakeDateTimeValid(dr["DDProcessingDate"]);
                            if ((installments % 12 == 0 && installments != 0) | (invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD && installments == 1))
                            {
                                PrintHelper.ReplaceText(doc, "[FirstDate]", contractStart.Day == 1 ? DateHelper.GetFirstDayOfMonth(contractStart).ToString("dd/MM/yyyy") : DateHelper.GetFirstDayOfMonth(contractStart.AddMonths(1)).ToString("dd/MM/yyyy"));
                            }
                            else
                            {
                                paymentMade = true;
                                PrintHelper.ReplaceText(doc, "[FirstDate]", DateHelper.GetFirstDayOfMonth(contractStart.AddMonths(2)).ToString("dd/MM/yyyy"));
                            }

                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(Conversions.ToString(Conversions.ToString(dr["siteAddress1"] + ", ") + dr["siteAddress2"] + ", ") + dr["sitePostcode"]));
                            PrintHelper.ReplaceText(doc, "[First]", paymentMade ? Helper.MakeDoubleValid(dr["SecondPayment"]).ToString("C") : Helper.MakeDoubleValid(dr["FirstAmount"]).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[Second]", Helper.MakeDoubleValid(dr["SecondPayment"]).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[Inst]", (Helper.MakeIntegerValid(dr["Installments"]) - 1).ToString());
                            PrintHelper.ReplaceText(doc, "[Inst2]", Helper.MakeIntegerValid(dr["Installments"]).ToString());
                            double monthlyApp = 0.0;
                            int contractType = Helper.MakeIntegerValid(dr["ContractTypeID"]);
                            if (contractType == Conversions.ToInteger(Enums.ContractTypes.PlatinumStar))
                            {
                                monthlyApp = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PS Additional Monthly", (Enums.PickListTypes)52));
                            }
                            else
                            {
                                monthlyApp = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Monthly", (Enums.PickListTypes)52));
                            }

                            PrintHelper.ReplaceText(doc, "[MonthApp]", invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD ? Math.Round(monthlyApp * 12, 2).ToString("C") : monthlyApp.ToString("C"));
                            double ahe = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                            PrintHelper.ReplaceText(doc, "[AHE]", invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD ? ahe.ToString("C") : Math.Round(ahe / 12, 2).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[UserName]", App.TheSystem.Configuration.CompanyName + " Coverplan Team");
                            int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                            int addBreaks = 1;
                            addBreaks += pageCount % 2 == 0 ? 0 : 1;
                            for (int i = 0, loopTo = addBreaks - 1; i <= loopTo; i++)
                                doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            doc.MainDocumentPart.Document.Save();
                            string saveDir = App.TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr["ContractReference"]);
                            Directory.CreateDirectory(saveDir);
                            string fileName = "DDRenewal_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                            fileStream.Close();
                        }

                        var mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr["ContractID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;
                        using (mm)
                            chunk.FeedData(mm);
                        var altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate dd renewal letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateContractLetter(DataRow dr, WordprocessingDocument batch = null)
            {
                try
                {
                    string template = Application.StartupPath + @"\Templates\Contracts\ContractOption11.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr["ContractID"]));
                    var fileByte = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        var doc = WordprocessingDocument.Open(mm, true);
                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            string customerName = Helper.MakeIntegerValid(dr["CustomerID"]) == Conversions.ToInteger(Enums.Customer.Domestic) ? Helper.MakeStringValid(dr["SiteName"]) : Helper.MakeStringValid(dr["CustName"]);
                            var dvAdditionalContacts = App.DB.Contact.Contacts_GetAll_ForLink(Conversions.ToInteger(Enums.TableNames.tblSite), Helper.MakeIntegerValid(dr["SiteID"]));
                            var drOnContractContacts = dvAdditionalContacts.Table.Select("OnContract = 1");
                            foreach (DataRow drContact in drOnContractContacts)
                                customerName += " / " + Helper.MakeStringValid(drContact["Title"]) + " " + Helper.MakeStringValid(drContact["FirstName"]) + " " + Helper.MakeStringValid(drContact["LastName"]);
                            PrintHelper.ReplaceText(doc, "[CustomerName]", customerName);
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr["SiteAddress1"]));
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr["SiteAddress2"]));
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr["SiteAddress3"]));
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr["SitePostcode"]));
                            PrintHelper.ReplaceText(doc, "[ContractType]", Helper.MakeStringValid(dr["ContractType"]));
                            PrintHelper.ReplaceText(doc, "[ContractReference]", Helper.MakeStringValid(dr["ContractReference"]));
                            PrintHelper.ReplaceText(doc, "[ContractStart]", Helper.MakeDateTimeValid(dr["ContractStartDate"]).ToString("dd/MM/yyyy"));
                            PrintHelper.ReplaceText(doc, "[ContractEnd]", Helper.MakeDateTimeValid(dr["ContractEndDate"]).ToString("dd/MM/yyyy"));
                            double contractTotal = Math.Round(Helper.MakeDoubleValid(dr["ContractPrice"]) * 1.2, 2);
                            PrintHelper.ReplaceText(doc, "[Total]", contractTotal.ToString("C"));
                            var drAssets = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(Helper.MakeIntegerValid(dr["ContractSiteID"]), Helper.MakeIntegerValid(dr["SiteID"])).Table.Select("Tick = 1");
                            var dtAssets = new DataTable();
                            dtAssets.Columns.Add("ApplianceCount");
                            dtAssets.Columns.Add("Appliance");
                            int primaryAssetCount = 0;
                            int secondaryAssetCount = 0;
                            int count = 1;
                            if (drAssets.Count() > 0)
                            {
                                var drPrimaryAssets = (from a in drAssets.CopyToDataTable().AsEnumerable()
                                                       where Helper.MakeBooleanValid(a["PrimAsset"]) == true
                                                       select a).ToArray();
                                primaryAssetCount = drPrimaryAssets.Length;
                                foreach (DataRow drContractAsset in drPrimaryAssets)
                                {
                                    var drAsset = dtAssets.NewRow();
                                    drAsset["ApplianceCount"] = "APPLIANCE " + count;
                                    drAsset["Appliance"] = drContractAsset["Product"];
                                    dtAssets.Rows.Add(drAsset);
                                    count += 1;
                                }

                                var drSecondaryAssets = (from a in drAssets.CopyToDataTable().AsEnumerable()
                                                         where Helper.MakeBooleanValid(a["PrimAsset"]) == false
                                                         select a).ToArray();
                                secondaryAssetCount = drSecondaryAssets.Length;
                                foreach (DataRow drContractAsset in drSecondaryAssets)
                                {
                                    var drAsset = dtAssets.NewRow();
                                    drAsset["ApplianceCount"] = "APPLIANCE " + count;
                                    drAsset["Appliance"] = drContractAsset["Product"];
                                    dtAssets.Rows.Add(drAsset);
                                    count += 1;
                                }
                            }

                            for (int i = 0, loopTo = Helper.MakeIntegerValid(dr["MainAppliances"]) - primaryAssetCount - 1; i <= loopTo; i++)
                            {
                                var drAsset = dtAssets.NewRow();
                                drAsset["ApplianceCount"] = "APPLIANCE " + count;
                                drAsset["Appliance"] = string.IsNullOrEmpty(Helper.MakeStringValid(dr["ManualApp"])) ? "UNKNOWN APPLIANCE" : Helper.MakeStringValid(dr["ManualApp"]);
                                dtAssets.Rows.Add(drAsset);
                                count += 1;
                            }

                            for (int i = 0, loopTo1 = Helper.MakeIntegerValid(dr["SecondryAppliances"]) - secondaryAssetCount - 1; i <= loopTo1; i++)
                            {
                                var drAsset = dtAssets.NewRow();
                                drAsset["ApplianceCount"] = "APPLIANCE " + count;
                                drAsset["Appliance"] = string.IsNullOrEmpty(Helper.MakeStringValid(dr["ManualApp"])) ? "UNKNOWN APPLIANCE" : Helper.MakeStringValid(dr["SecondApp"]);
                                dtAssets.Rows.Add(drAsset);
                                count += 1;
                            }

                            PrintHelper.ReplaceBookmarkWithTable(doc, "ApplianceTable", dtAssets, false, Enums.TableCellProperties.ContractAppliance);
                            bool hasWindowLockPest = Helper.MakeBooleanValid(dr["WindowLockPest"]);
                            bool hasPlumbingDrainage = Helper.MakeBooleanValid(dr["PlumbingDrainage"]);
                            bool hasGasSupplyPipework = Helper.MakeBooleanValid(dr["GasSupplyPipework"]);
                            PrintHelper.ReplaceText(doc, "[GasSupplyPipework]", hasGasSupplyPipework ? "Yes" : "No");
                            PrintHelper.ReplaceText(doc, "[PlumbingDrainage]", hasPlumbingDrainage ? "Yes" : "No");
                            PrintHelper.ReplaceText(doc, "[WindowLockPest]", hasWindowLockPest ? "Yes" : "No");
                            PrintHelper.ReplaceText(doc, "[UserName]", App.TheSystem.Configuration.CompanyName + " Coverplan Team");
                            int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                            var para = new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page }));
                            doc.MainDocumentPart.Document.Body.InsertAfter(para, doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            doc.MainDocumentPart.Document.Save();
                            string templateTnC = Application.StartupPath + @"\Templates\Contracts\ContractTermsAndConditions.docx";
                            var fileByteTnC = File.ReadAllBytes(templateTnC);
                            var mmTnC = new MemoryStream();
                            using (mmTnC)
                            {
                                mmTnC.Write(fileByteTnC, 0, fileByteTnC.Length);
                                var docTnC = WordprocessingDocument.Open(mmTnC, true);
                                using (docTnC)
                                {
                                    if (Helper.MakeIntegerValid(dr["DiscountID"]) != Conversions.ToInteger(Enums.ContractTypes.EmployeeFree))
                                    {
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef");
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef1");
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef2");
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef3");
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef4");
                                    }

                                    int termsPageCount = Helper.MakeIntegerValid(docTnC.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                                    int addBreaks = 1;
                                    addBreaks += (pageCount + termsPageCount) % 2 == 0 ? 0 : 1;
                                    for (int i = 0, loopTo2 = addBreaks - 1; i <= loopTo2; i++)
                                        docTnC.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), docTnC.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                                    docTnC.MainDocumentPart.Document.Save();
                                }

                                var mainPartContract = doc.MainDocumentPart;
                                string altChunkIdContract = "AltId" + Helper.MakeIntegerValid(dr["ContractID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                                var chunkContract = mainPartContract.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkIdContract);
                                mmTnC.Position = 0;
                                using (mmTnC)
                                    chunkContract.FeedData(mmTnC);
                                var altChunkContract = new WP.AltChunk();
                                altChunkContract.Id = altChunkIdContract;
                                mainPartContract.Document.Body.InsertAfter(altChunkContract, mainPartContract.Document.Body.Elements<WP.Paragraph>().Last());
                                mainPartContract.Document.Save();
                            }
                        }

                        string saveDir = App.TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr["ContractReference"]);
                        Directory.CreateDirectory(saveDir);
                        string fileName = "Contract_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                        string savePath = saveDir + @"\" + fileName;
                        savePath = FileCheck(savePath);
                        var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using (fileStream)
                            mm.WriteTo(fileStream);
                        fileStream.Close();
                        if (batch is object)
                        {
                            var mainPart = batch.MainDocumentPart;
                            string altChunkId = "AltId" + Helper.MakeIntegerValid(dr["ContractID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                            var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            mm.Position = 0;
                            using (mm)
                                chunk.FeedData(mm);
                            var altChunk = new WP.AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                            mainPart.Document.Save();
                        }
                        else
                        {
                            Process.Start(savePath);
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate contract letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateReceipt(DataRow dr, WordprocessingDocument batch, bool isCommercial = false, bool addPage = true)
            {
                try
                {
                    if (dr.Table.Columns.Contains("UpgradedFrom") && Helper.MakeStringValid(dr["UpgradedFrom"]).Length > 0)
                        return true;
                    Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Conversions.ToInteger(Helper.MakeIntegerValid(dr["InvoiceFrequencyID"]));
                    string template = Application.StartupPath + @"\Templates\Invoice\Receipt.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr["ContractID"]));
                    var fileByte = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        var doc = WordprocessingDocument.Open(mm, true);
                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            AddCompanyDetails(doc, true, false, isCommercial);
                            PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dr["PayerName"]));
                            PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dr["Payeraddress1"]));
                            PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dr["PayerAddress2"]));
                            PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dr["PayerAddress3"]));
                            PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dr["PayerPostcode"]));
                            PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(dr["InvoiceNumber"]));
                            PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(dr["RaiseDate"]).ToString("dd/MM/yyyy"));
                            PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dr["CustAcc"]));
                            var dtContract = new DataTable();
                            dtContract.Columns.Add("ContractReference");
                            dtContract.Columns.Add("Address");
                            dtContract.Columns.Add("Work");
                            dtContract.Columns.Add("Total");
                            var drContract = dtContract.NewRow();
                            drContract["ContractReference"] = string.IsNullOrEmpty(Helper.MakeStringValid(dr["PoNumber"])) ? Helper.MakeStringValid(dr["ContractReference"]) : Helper.MakeStringValid(Conversions.ToString(dr["ContractReference"] + " / ") + dr["PoNumber"]);
                            drContract["Address"] = Helper.MakeStringValid(Conversions.ToString(Conversions.ToString(dr["SiteAddress1"] + ", ") + dr["SiteAddress2"] + ", ") + dr["SitePostcode"]);
                            string payType = Helper.MakeStringValid(dr["Type"]);
                            string contractType = Helper.MakeStringValid(dr["ContractType"]);
                            int installments = Helper.MakeIntegerValid(dr["installments"]);
                            bool paymentMade = false;
                            bool renewed = Helper.MakeBooleanValid(dr["Renewed"]);
                            double contractTotal = Helper.MakeDoubleValid(dr["ContractPrice"]);
                            double subTotal = 0.0;
                            if (installments % 12 == 0 && installments != 0)
                            {
                            }
                            else
                            {
                                paymentMade = true;
                            }

                            if (renewed && installments == 0)
                            {
                                drContract["Work"] = contractType + " Coverplan Renewal " + Constants.vbCrLf + Constants.vbCrLf + "Paid " + Math.Round(contractTotal * 1.2, 2).ToString("C") + " by " + Helper.MakeStringValid(dr["InitialPaymentType"]) + ", received with thanks." + "" + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for renewing your plan.";
                                drContract["Total"] = contractTotal.ToString("C");
                                subTotal += contractTotal;
                            }
                            else if (installments == 0)
                            {
                                drContract["Work"] = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr["ContractStartDate"]).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "Paid " + Math.Round(contractTotal * 1.2, 2).ToString("C") + " by " + Helper.MakeStringValid(dr["InitialPaymentType"]) + ", received with thanks. " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for taking out this plan.";
                                drContract["Total"] = contractTotal.ToString("C");
                                subTotal += contractTotal;
                            }
                            else if (installments == 1 || invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD)
                            {
                                drContract["Work"] = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr["ContractStartDate"]).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "1 payment of " + Helper.MakeDoubleValid(dr["FirstAmount"]).ToString("C") + " to be paid annually by direct debit" + "" + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for taking out this plan.";
                                drContract["Total"] = Math.Round(Helper.MakeDoubleValid(dr["FirstAmount"]) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr["FirstAmount"]) / 1.2, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (installments > 0 && paymentMade && ((payType ?? "") == "AMMENDD" || (payType ?? "") == "TRANSD" || (payType ?? "") == "RENEWALD"))
                            {
                                drContract["Work"] = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr["ContractStartDate"]).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "1st payment of " + Helper.MakeDoubleValid(dr["FirstAmount"]).ToString("C") + " paid by " + Helper.MakeStringValid(dr["InitialPaymentType"]) + ", received with thanks. " + installments + " payments to be paid by monthly direct debit " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for renewing your plan.";
                                drContract["Total"] = Math.Round(Helper.MakeDoubleValid(dr["FirstAmount"]) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr["FirstAmount"]) / 1.2, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (installments > 0 && paymentMade)
                            {
                                drContract["Work"] = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr["ContractStartDate"]).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "1st payment of " + Helper.MakeDoubleValid(dr["FirstAmount"]).ToString("C") + " paid by " + Helper.MakeStringValid(dr["InitialPaymentType"]) + ", received with thanks. " + installments + " payments to be paid by monthly direct debit " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for taking out this plan.";
                                drContract["Total"] = Math.Round(Helper.MakeDoubleValid(dr["FirstAmount"]) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr["FirstAmount"]) / 1.2, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (installments > 0)
                            {
                                drContract["Work"] = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr["ContractStartDate"]).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "1 payment of " + Helper.MakeDoubleValid(dr["FirstAmount"]).ToString("C") + " to be paid by Annual direct debit " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for taking out this plan.";
                                drContract["Total"] = Math.Round(Helper.MakeDoubleValid(dr["FirstAmount"]) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr["FirstAmount"]) / 1.2, 2, MidpointRounding.AwayFromZero);
                            }

                            dtContract.Rows.Add(drContract);
                            PrintHelper.AddRowsToTable(doc, "Job No", dtContract, "Arial", "20");
                            PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[VAT]", Helper.RoundDown(subTotal * 0.2, 2).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[TiVAT]", Helper.RoundDown(subTotal * 1.2, 2).ToString("C"));
                            if (addPage)
                            {
                                int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                                int addBreaks = 1;
                                addBreaks += pageCount % 2 == 0 ? 0 : 1;
                                for (int i = 0, loopTo = addBreaks - 1; i <= loopTo; i++)
                                    doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            }

                            doc.MainDocumentPart.Document.Save();
                            string saveDir = App.TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr["ContractReference"]);
                            Directory.CreateDirectory(saveDir);
                            string fileName = "Receipt_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                            fileStream.Close();
                        }

                        var mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr["ContractID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;
                        using (mm)
                            chunk.FeedData(mm);
                        var altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate dd renewal letter : " + Constants.vbNewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateCredit(DataTable dt, string savePath)
            {
                try
                {
                    DataRow[] rr = null;
                    if (dt.Columns.Contains("Credit"))
                    {
                        rr = dt.Select("Credit > 0");
                    }
                    else
                    {
                        rr = dt.Select("Amount > 0");
                    }

                    var dtInvoiceDetails = App.DB.Invoiced.InvoiceDetails_Get_InvoicedID(Conversions.ToInteger(dt.Rows[0]["InvoicedID"])).Table;
                    if (dtInvoiceDetails.Rows.Count > 0)
                    {
                        if (rr.Length > 0)
                        {
                            string template = Application.StartupPath + @"\Templates\Invoice\SalesCredit.docx";
                            double subTotal = 0.0;
                            var oCredit = rr.Length == 1 ? App.DB.SalesCredit.SalesCredit_Get(Conversions.ToInteger(rr[0]["SalesCreditID"])) : App.DB.SalesCredit.SalesCredit_Get_For_InvoicedLine(Conversions.ToInteger(rr[0]["InvoicedLineID"]));
                            var site = App.DB.Sites.Get(rr[0]["SiteID"]);
                            var fileByte = File.ReadAllBytes(template);
                            var mm = new MemoryStream();
                            using (mm)
                            {
                                mm.Write(fileByte, 0, fileByte.Length);
                                var doc = WordprocessingDocument.Open(mm, true);
                                using (doc)
                                {
                                    AddCompanyDetails(doc, true, false, site.RegionID == (int)Enums.Region.GaswayCommercial);
                                    PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["SiteName"]));
                                    PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["address1"]));
                                    PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["address2"]));
                                    PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["address3"]));
                                    PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dtInvoiceDetails.Rows[0]["postcode"]));
                                    PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(oCredit.CreditReference));
                                    PrintHelper.ReplaceText(doc, "[RaiseDate]", Conversions.ToString(Helper.MakeDateTimeValid(oCredit.DateCredited.ToString("dd/MM/yyyy"))));
                                    PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["AccountNumber"]));
                                    var dtContract = new DataTable();
                                    dtContract.Columns.Add("ContractReference");
                                    dtContract.Columns.Add("Address");
                                    dtContract.Columns.Add("Work");
                                    dtContract.Columns.Add("Total");
                                    foreach (DataRow dr in rr)
                                    {
                                        var drContract = dtContract.NewRow();
                                        var Line = App.DB.InvoicedLines.InvoicedLines_Get(Conversions.ToInteger(dr["InvoicedLineID"]));
                                        drContract["ContractReference"] = Helper.MakeStringValid(dr["PoNumber"]).Length == 0 ? Helper.MakeStringValid(dr["JobNumber"]) : Helper.MakeStringValid(Conversions.ToString(dr["JobNumber"] + " / ") + dr["PoNumber"]);
                                        var switchExpr = (Enums.InvoiceType)Conversions.ToInteger(dr["InvoiceTypeID"]);
                                        switch (switchExpr)
                                        {
                                            case Enums.InvoiceType.Visit:
                                                {
                                                    var siteVisit = App.DB.Sites.Get(dr["SiteID"]);
                                                    drContract["Address"] = siteVisit.Address1 + ", " + siteVisit.Address2 + ", " + Helper.FormatPostcode(site.Postcode);
                                                    drContract["Work"] = dr["NotesFromEngineer"] + Constants.vbNewLine + Constants.vbNewLine + "Credit Against Invoice " + dr["InvoiceNumber"].ToString() + " - " + oCredit.ReasonForCredit;
                                                    drContract["Total"] = Helper.MakeDoubleValid(dr["Credit"]).ToString("C");
                                                    subTotal += Helper.MakeDoubleValid(dr["Credit"]);
                                                    break;
                                                }

                                            case Enums.InvoiceType.Order:
                                                {
                                                    double orderTotal = 0.0;
                                                    var ppOrdersData = App.DB.Order.Order_ItemsGetAll(Conversions.ToInteger(dr["OrderID"])).Table;
                                                    if (ppOrdersData.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow ppo in ppOrdersData.Rows)
                                                            orderTotal += Helper.MakeDoubleValid(ppo["QuantityReceived"]) * Helper.MakeDoubleValid(ppo["SellPrice"]);
                                                    }

                                                    var siteOrder = App.DB.Sites.Get(dr["SiteID"]);
                                                    drContract["Address"] = siteOrder.Address1 + ", " + siteOrder.Address2 + ", " + Helper.FormatPostcode(siteOrder.Postcode);
                                                    drContract["Work"] = "";
                                                    drContract["Total"] = orderTotal.ToString("C");
                                                    subTotal += orderTotal;
                                                    break;
                                                }

                                            case Enums.InvoiceType.Contract_Option1:
                                                {
                                                    var siteContract = App.DB.Sites.Get(dr["SiteID"]);
                                                    drContract["Address"] = siteContract.Address1 + ", " + siteContract.Address2 + ", " + Helper.FormatPostcode(siteContract.Postcode);
                                                    if (siteContract.RegionID == (int)Enums.Region.GaswayCommercial)
                                                    {
                                                        drContract["Work"] = "Periodic Service Charge " + Constants.vbNewLine + Constants.vbNewLine + "Credit Against Invoice " + dr["InvoiceNumber"].ToString() + " - " + oCredit.ReasonForCredit;
                                                    }
                                                    else
                                                    {
                                                        drContract["Work"] = "Contract Payment " + Constants.vbNewLine + Constants.vbNewLine + "Credit Against Invoice " + dr["InvoiceNumber"].ToString() + " - " + oCredit.ReasonForCredit;
                                                    }

                                                    drContract["Total"] = Helper.MakeDoubleValid(dr["Credit"]).ToString("C");
                                                    subTotal += Helper.MakeDoubleValid(dr["Credit"]);
                                                    break;
                                                }
                                        }

                                        dtContract.Rows.Add(drContract);
                                    }

                                    PrintHelper.AddRowsToTable(doc, "Job No", dtContract, "Arial", "20");
                                    decimal VATRate = Conversions.ToDecimal(Helper.MakeDoubleValid(dtInvoiceDetails.Rows[0]["VATRATE"]));
                                    decimal VATRateDecimal = VATRate / 100;
                                    PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"));
                                    PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(subTotal * Conversions.ToDouble(VATRateDecimal), 2).ToString("C"));
                                    PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round(subTotal * Conversions.ToDouble(VATRateDecimal) + subTotal, 2).ToString("C"));
                                }

                                var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                mm.Position = 0;
                                using (fileStream)
                                    mm.WriteTo(fileStream);
                                fileStream.Close();
                            }
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate invoice : " + Constants.vbNewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateSalesInvoice(Invoiceds.Invoiced invoice, WordprocessingDocument batch, bool isCommerical)
            {
                try
                {
                    var dtInvoiceDetails = App.DB.Invoiced.InvoiceDetails_Get_InvoicedID(invoice.InvoicedID).Table;
                    if (dtInvoiceDetails.Rows.Count > 0)
                    {
                        string template = Application.StartupPath + @"\Templates\Invoice\Invoice.docx";
                        string savePath = App.TheSystem.Configuration.DocumentsLocation + @"SiteInvoices\" + invoice.InvoiceNumber + @"\Invoice_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                        string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(invoice.InvoicedID));
                        var fileByte = File.ReadAllBytes(template);
                        var mm = new MemoryStream();
                        using (mm)
                        {
                            mm.Write(fileByte, 0, fileByte.Length);
                            var doc = WordprocessingDocument.Open(mm, true);
                            using (doc)
                            {
                                PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                                AddCompanyDetails(doc, true, false, isCommerical);
                                PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["SiteName"]));
                                PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["address1"]));
                                PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["address2"]));
                                PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["address3"]));
                                PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dtInvoiceDetails.Rows[0]["postcode"]));
                                PrintHelper.ReplaceText(doc, "[InvoiceNumber]", invoice.InvoiceNumber);
                                PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(invoice.RaisedDate).ToString("dd/MM/yyyy"));
                                PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dtInvoiceDetails.Rows[0]["AccountNumber"]));
                                var dtInvoiceLines = App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(invoice.InvoicedID).Table;
                                if (dtInvoiceLines.Rows.Count > 0)
                                {
                                    double subTotal = 0.0;
                                    var dtJobDetails = new DataTable();
                                    dtJobDetails.Columns.Add("Job");
                                    dtJobDetails.Columns.Add("Address");
                                    dtJobDetails.Columns.Add("Work");
                                    dtJobDetails.Columns.Add("Total");
                                    foreach (DataRow line in dtInvoiceLines.Rows)
                                    {
                                        var drJob = dtJobDetails.NewRow();
                                        drJob["Job"] = Helper.MakeStringValid(line["PoNumber"]).Length == 0 ? Helper.MakeStringValid(line["JobNumber"]) : Helper.MakeStringValid(Conversions.ToString(line["JobNumber"] + " / ") + line["PoNumber"]);
                                        string additionalNotes = App.DB.Invoiced.Invoice_GetAdditionalNotes(invoice.InvoicedID);
                                        var site = App.DB.Sites.Get(line["SiteID"]);
                                        drJob["Address"] = site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode(site.Postcode) + " Ref: " + site.PolicyNumber;
                                        if (string.IsNullOrEmpty(additionalNotes))
                                        {
                                            additionalNotes = Helper.MakeStringValid(line["Notes"]);
                                            if (!string.IsNullOrEmpty(additionalNotes))
                                            {
                                                App.DB.Invoiced.Invoice_UpdateAdditionalNotes(invoice.InvoicedID, additionalNotes);
                                            }
                                        }

                                        var switchExpr = (Enums.InvoiceType)Conversions.ToInteger(line["InvoiceTypeID"]);
                                        switch (switchExpr)
                                        {
                                            case Enums.InvoiceType.Visit:
                                                {
                                                    if (Helper.MakeBooleanValid(line["UseSORDescription"]))
                                                    {
                                                        var dt = App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(Conversions.ToInteger(line["EngineerVisitID"])).Table;
                                                        string sorDetails = "";
                                                        double sorTotal = 0.0;
                                                        foreach (DataRow dr in dt.Select("tick = 1"))
                                                        {
                                                            sorDetails += Conversions.ToString(Conversions.ToString(Conversions.ToString(dr["NumUnitsUsed"] + " X ") + dr["code"] + "-") + dr["Summary"] + "(£") + dr["Price"] + ")" + Constants.vbCrLf + Constants.vbCrLf;
                                                            sorTotal += Conversions.ToDouble(Helper.MakeDoubleValid(dr["Total"]).ToString("C"));
                                                        }

                                                        drJob["Work"] = sorDetails;
                                                        drJob["Total"] = sorTotal.ToString("C");
                                                        subTotal += sorTotal;
                                                    }
                                                    else
                                                    {
                                                        drJob["Work"] = line["NotesFromEngineer"];
                                                        drJob["Total"] = Helper.MakeDoubleValid(line["Amount"]).ToString("C");
                                                        subTotal += Helper.MakeDoubleValid(line["Amount"]);
                                                    }

                                                    break;
                                                }

                                            case Enums.InvoiceType.Order:
                                                {
                                                    double orderTotal = 0.0;
                                                    var ppOrdersData = App.DB.Order.Order_ItemsGetAll(Conversions.ToInteger(line["OrderID"])).Table;
                                                    if (ppOrdersData.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow ppo in ppOrdersData.Rows)
                                                            orderTotal += Helper.MakeDoubleValid(ppo["QuantityReceived"]) * Helper.MakeDoubleValid(ppo["SellPrice"]);
                                                    }

                                                    drJob["Total"] = orderTotal.ToString("C");
                                                    subTotal += orderTotal;
                                                    break;
                                                }

                                            case Enums.InvoiceType.Contract_Option1:
                                                {
                                                    var cont = App.DB.ContractOriginal.Get(Conversions.ToInteger(line["ContractID"]));
                                                    string period = "";
                                                    var switchExpr1 = cont.InvoiceFrequencyID;
                                                    switch (switchExpr1)
                                                    {
                                                        case (int)Enums.InvoiceFrequency_NoWeeK.Monthly:
                                                            {
                                                                period = "Monthly";
                                                                break;
                                                            }

                                                        case (int)Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits:
                                                            {
                                                                period = "4 Month";
                                                                break;
                                                            }

                                                        case (int)Enums.InvoiceFrequency_NoWeeK.Quarterly:
                                                            {
                                                                period = "Quarterly";
                                                                break;
                                                            }

                                                        case (int)Enums.InvoiceFrequency_NoWeeK.Bi_Annually:
                                                            {
                                                                period = "Bi-Annual";
                                                                break;
                                                            }

                                                        case (int)Enums.InvoiceFrequency_NoWeeK.Annually:
                                                            {
                                                                period = "Annual";
                                                                break;
                                                            }

                                                        default:
                                                            {
                                                                period = "";
                                                                break;
                                                            }
                                                    }

                                                    if (site.RegionID == (int)Enums.Region.GaswayCommercial)
                                                    {
                                                        drJob["Work"] = period + " Service Charge for Gasway Commercial maintenance contract";
                                                    }
                                                    else
                                                    {
                                                        drJob["Work"] = "Contract Payment";
                                                        if ((details1 ?? "") == "DDRECEIPT")
                                                        {
                                                            drJob["Work"] = "Unpaid Direct Debit collection for the month of " + invoice.RaisedDate.ToString("MMMM") + "." + Constants.vbNewLine + Constants.vbNewLine + "Paid by " + details2 + ", received with thanks.";
                                                        }
                                                        else if ((details1 ?? "") == "DDINVOICE")
                                                        {
                                                            drJob["Work"] = "Unpaid Direct Debit collection for the month of " + invoice.RaisedDate.ToString("MMMM") + "." + Constants.vbNewLine + Constants.vbNewLine + "Please arrange payment to cover this shortfall";
                                                        }
                                                    }

                                                    drJob["Total"] = Helper.MakeDoubleValid(line["Amount"]).ToString("C");
                                                    subTotal += Helper.MakeDoubleValid(line["Amount"]);
                                                    break;
                                                }
                                        }

                                        if (!string.IsNullOrEmpty(additionalNotes))
                                        {
                                            drJob["Work"] += Constants.vbNewLine + Constants.vbNewLine + additionalNotes;
                                        }

                                        dtJobDetails.Rows.Add(drJob);
                                    }

                                    var drLastRow = dtJobDetails.Rows[dtInvoiceDetails.Rows.Count - 1];
                                    var paymentdetails = App.DB.ExecuteWithReturn("SELECT PT.Name as PaymentTerm, ISNULL(PB.NAme,'') as PaymentBy from tblinvoiced I INNER JOIN tblpicklists PT ON PT.ManagerID = I.TermID LEFT JOIN tblpicklists PB ON PB.managerid = I.PaidByID WHERE InvoicedID = " + invoice.InvoicedID);
                                    if (paymentdetails.Rows.Count > 0)
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(paymentdetails.Rows[0]["PaymentTerm"], "RECEIPT", false)))
                                        {
                                            PrintHelper.ReplaceText(doc, "INVOICE", "RECEIPT");
                                            PrintHelper.ReplaceText(doc, "STRICTLY 30 DAYS NET", "PAID WITH THANKS");
                                            drLastRow["Work"] += Constants.vbNewLine + Constants.vbNewLine + "Paid by " + paymentdetails.Rows[0]["PaymentBy"] + " With thanks.";
                                        }
                                        else
                                        {
                                            PrintHelper.ReplaceText(doc, "STRICTLY 30 DAYS NET", Conversions.ToString(paymentdetails.Rows[0]["PaymentTerm"]));
                                        }
                                    }

                                    PrintHelper.AddRowsToTable(doc, "Job No", dtJobDetails, "Arial", "20");
                                    decimal vatRate = Conversions.ToDecimal(Helper.MakeDoubleValid(dtInvoiceDetails.Rows[0]["VATRATE"]));
                                    decimal vatRateDecimal = vatRate / 100;
                                    PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"));
                                    PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(subTotal * Conversions.ToDouble(vatRateDecimal), 2).ToString("C"));
                                    PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round(subTotal * Conversions.ToDouble(vatRateDecimal) + subTotal, 2).ToString("C"));
                                    doc.MainDocumentPart.Document.Save();
                                    Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                                    savePath = FileCheck(savePath);
                                    var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    mm.Position = 0;
                                    using (fileStream)
                                        mm.WriteTo(fileStream);
                                }
                            }

                            if (batch is object)
                            {
                                var mainPart = batch.MainDocumentPart;
                                string altChunkId = "AltId" + invoice.InvoicedID + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                                var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                                mm.Position = 0;
                                using (mm)
                                    chunk.FeedData(mm);
                                var altChunk = new WP.AltChunk();
                                altChunk.Id = altChunkId;
                                mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                                mainPart.Document.Save();
                            }
                            else
                            {
                                Process.Start(savePath);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate invoice : " + Constants.vbNewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return default;
            }

            private bool GenerateContractInvoice(DataRow dr, WordprocessingDocument batch, bool isCommerical = false, bool addPage = true)
            {
                try
                {
                    string template = Application.StartupPath + @"\Templates\Invoice\Invoice.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr["ContractID"]));
                    var fileByte = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        var doc = WordprocessingDocument.Open(mm, true);
                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            AddCompanyDetails(doc, true, false, isCommerical);
                            PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dr["PayerName"]));
                            PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dr["Payeraddress1"]));
                            PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dr["PayerAddress2"]));
                            PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dr["PayerAddress3"]));
                            PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dr["PayerPostcode"]));
                            PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(dr["InvoiceNumber"]));
                            PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(dr["RaiseDate"]).ToString("dd/MM/yyyy"));
                            PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dr["CustAcc"]));
                            var dtContract = new DataTable();
                            dtContract.Columns.Add("ContractReference");
                            dtContract.Columns.Add("Address");
                            dtContract.Columns.Add("Work");
                            dtContract.Columns.Add("Total");
                            var drContract = dtContract.NewRow();
                            drContract["ContractReference"] = Helper.MakeStringValid(dr["PoNumber"]).Length == 0 ? Helper.MakeStringValid(dr["ContractReference"]) : Helper.MakeStringValid(Conversions.ToString(dr["ContractReference"] + " / ") + dr["PoNumber"]);
                            drContract["Address"] = Helper.MakeStringValid(Conversions.ToString(Conversions.ToString(dr["SiteAddress1"] + ", ") + dr["SiteAddress2"] + ", ") + dr["SitePostcode"]);
                            string contractType = Helper.MakeStringValid(dr["ContractType"]);
                            int contractTypeId = Helper.MakeIntegerValid(dr["ContractTypeID"]);
                            int siteRegion = Helper.MakeIntegerValid(dr["SiteRegion"]);
                            double contractTotal = Helper.MakeDoubleValid(dr["ContractPrice"]);
                            double subTotal = 0.0;
                            if (siteRegion == Conversions.ToInteger(Enums.Region.GaswayCommercial))
                            {
                                drContract["Work"] = "Periodic Service Charge";
                            }
                            else if (contractTypeId == Conversions.ToInteger(Enums.ContractTypes.GoldStarAgency) || contractTypeId == Conversions.ToInteger(Enums.ContractTypes.PlatinumStarAgency))
                            {
                                drContract["Work"] = contractType + " Coverplan Renewal. " + Constants.vbCrLf + Constants.vbCrLf + "Blanket cover for all gas appliances" + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for Renewing this plan.";
                                drContract["Total"] = contractTotal.ToString("C");
                                subTotal += contractTotal;
                            }
                            else
                            {
                                drContract["Work"] = contractType + " Coverplan Renewal. " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for Renewing this plan.";
                                drContract["Total"] = contractTotal.ToString("C");
                                subTotal += contractTotal;
                            }

                            dtContract.Rows.Add(drContract);
                            PrintHelper.AddRowsToTable(doc, "Job No", dtContract, "20");
                            PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(subTotal * 0.2, 2).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round(subTotal * 1.2, 2).ToString("C"));
                            if (addPage)
                            {
                                int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                                int addBreaks = 1;
                                addBreaks += pageCount % 2 == 0 ? 0 : 1;
                                for (int i = 0, loopTo = addBreaks - 1; i <= loopTo; i++)
                                    doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            }

                            doc.MainDocumentPart.Document.Save();
                            string saveDir = App.TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr["ContractReference"]);
                            Directory.CreateDirectory(saveDir);
                            string fileName = "Invoice_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                            fileStream.Close();
                        }

                        var mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr["ContractID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;
                        using (mm)
                            chunk.FeedData(mm);
                        var altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate invoice : " + Constants.vbNewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateTransferLetter(DataRow dr, WordprocessingDocument batch)
            {
                try
                {
                    string template = Application.StartupPath + @"\Templates\Contracts\ContractTransfer.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr["ContractID"]));
                    var fileByte = File.ReadAllBytes(template);
                    var mm = new MemoryStream();
                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        var doc = WordprocessingDocument.Open(mm, true);
                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                            string companyName = Helper.MakeStringValid(dr["PayerSalutation"]).Length > 0 ? Helper.MakeStringValid(Conversions.ToString(dr["PayerSalutation"] + " ") + dr["PayerSurname"]) : Helper.MakeStringValid(dr["PayerName"]);
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName);
                            PrintHelper.ReplaceText(doc, "[Name]", companyName);
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr["PayerAddress1"]));
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr["PayerAddress2"]));
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr["PayerAddress3"]));
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr["PayerPostcode"]));
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr["ContractType"]));
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(Conversions.ToString(Conversions.ToString(Conversions.ToString(dr["ContractReference"] + " - ") + dr["siteAddress1"] + ", ") + dr["siteAddress2"] + ", ") + dr["sitePostcode"]));
                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(Conversions.ToString(Conversions.ToString(dr["siteAddress1"] + ", ") + dr["siteAddress2"] + ", ") + dr["sitePostcode"]));
                            PrintHelper.ReplaceText(doc, "[UserName]", App.TheSystem.Configuration.CompanyName + " Coverplan Team");
                            int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                            int addBreaks = 1;
                            addBreaks += pageCount % 2 == 0 ? 0 : 1;
                            for (int i = 0, loopTo = addBreaks - 1; i <= loopTo; i++)
                                doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            doc.MainDocumentPart.Document.Save();
                            string saveDir = App.TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr["ContractReference"]);
                            Directory.CreateDirectory(saveDir);
                            string fileName = "Transfer_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using (fileStream)
                                mm.WriteTo(fileStream);
                            fileStream.Close();
                        }

                        var mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr["ContractID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;
                        using (mm)
                            chunk.FeedData(mm);
                        var altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate transfer letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private string GenerateAnnualExpiryLetters(DataRow[] drAnnualContracts)
            {
                string fileName = "Annual_Contract_Expiry_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                string fileDir = App.TheSystem.Configuration.DocumentsLocation + @"Contracts\AnnualExpiry";
                Directory.CreateDirectory(fileDir);
                string filePath = fileDir + @"\" + fileName;
                File.Copy(Application.StartupPath + @"\Templates\ServiceLetter.docx", filePath);
                try
                {
                    var batch = WordprocessingDocument.Open(filePath, true);
                    using (batch)
                        foreach (DataRow dr in drAnnualContracts)
                        {
                            try
                            {
                                if (Helper.MakeDoubleValid(dr["RenewalPrice"]) == 0)
                                    continue;
                                string template = Application.StartupPath + @"\Templates\Contracts\AnnualContractExpiry.docx";
                                string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr["ContractID"]));
                                var fileByte = File.ReadAllBytes(template);
                                var mm = new MemoryStream();
                                using (mm)
                                {
                                    mm.Write(fileByte, 0, fileByte.Length);
                                    var doc = WordprocessingDocument.Open(mm, true);
                                    using (doc)
                                    {
                                        PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                                        PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr["PayerAddress1"]));
                                        PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr["PayerAddress2"]));
                                        PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr["PayerAddress3"]));
                                        PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr["PayerPostcode"]));
                                        PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                                        string companyName = Helper.MakeStringValid(dr["PayerSalutation"]).Length > 0 ? Helper.MakeStringValid(Conversions.ToString(dr["PayerSalutation"] + " ") + dr["PayerSurname"]) : Helper.MakeStringValid(dr["PayerName"]);
                                        PrintHelper.ReplaceText(doc, "[CompanyName]", companyName);
                                        PrintHelper.ReplaceText(doc, "[ExpiryDate]", Helper.MakeDateTimeValid(dr["ContractEndDate"]).ToString("dd/MM/yyyy"));
                                        PrintHelper.ReplaceText(doc, "[User]", App.TheSystem.Configuration.CompanyName + " Coverplan Team");
                                        PrintHelper.ReplaceText(doc, "[ContractType]", Helper.MakeStringValid(dr["ContractType"]));
                                        PrintHelper.ReplaceText(doc, "[ContractReference]", Helper.MakeStringValid(dr["ContractReference"]));
                                        PrintHelper.ReplaceText(doc, "[SiteAddress1]", Helper.MakeStringValid(dr["SiteAddress1"]));
                                        string price = Helper.MakeDoubleValid(dr["RenewalPrice"]) == -1 ? 0.ToString("C") : Helper.MakeDoubleValid(dr["RenewalPrice"]).ToString("C");
                                        PrintHelper.ReplaceText(doc, "[PriceSentence]", price);
                                        double addAppPrice = Helper.MakeDoubleValid(App.DB.Picklists.Get_Single_Description("Additional Appliance", (Enums.PickListTypes)52));
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["ContractType"], "Platinum Star", false)))
                                            addAppPrice = Helper.MakeDoubleValid(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52));
                                        if (addAppPrice > 0)
                                        {
                                            string sentence = "Please be advised that we are now offering cover for boilermates " + "or any other make of thermal store product as an additional appliance. " + "Should you have a thermal store product in your property and require cover, " + "this could be added for an additional " + addAppPrice.ToString("C") + " per annum.";
                                            PrintHelper.ReplaceText(doc, "[ExcludeSentence]", sentence);
                                        }
                                        else
                                        {
                                            PrintHelper.DeleteBookmark(doc, "ExcludeSentence");
                                        }

                                        double ahe = Helper.MakeDoubleValid(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                                        PrintHelper.ReplaceText(doc, "[AHE]", ahe.ToString("C"));
                                        int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                                        int addBreaks = 1;
                                        addBreaks += pageCount % 2 == 0 ? 0 : 1;
                                        for (int i = 0, loopTo = addBreaks - 1; i <= loopTo; i++)
                                            doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                                        doc.MainDocumentPart.Document.Save();
                                        string saveDir = App.TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr["ContractReference"]);
                                        Directory.CreateDirectory(saveDir);
                                        string savePath = saveDir + @"\" + fileName;
                                        savePath = FileCheck(savePath);
                                        var fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                        mm.Position = 0;
                                        using (fileStream)
                                            mm.WriteTo(fileStream);
                                        fileStream.Close();
                                    }

                                    var mainPart = batch.MainDocumentPart;
                                    string altChunkId = "AltId" + Helper.MakeIntegerValid(dr["ContractID"]) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                                    var chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                                    mm.Position = 0;
                                    using (mm)
                                        chunk.FeedData(mm);
                                    var altChunk = new WP.AltChunk();
                                    altChunk.Id = altChunkId;
                                    mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                                    mainPart.Document.Save();
                                }
                            }
                            catch (Exception ex)
                            {
                                App.ShowMessage("Could not renewal letter for " + Helper.MakeStringValid(dr["ContractReference"]) + ": " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    return filePath;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not renewal letter: " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }

            private string Finalise(string filepath, bool success, bool withSave = true, bool withKill = true, bool gsr = false)
            {
                Documentss.Documents documentLine;
                if (success)
                {
                    if (WordDoc is object)
                    {
                        if (withSave)
                        {
                            if (filepath.Trim().Length > 0)
                            {
                                if (OrderID > 0)
                                {
                                    if (answer == DialogResult.No)
                                    {
                                        object argFileName = filepath;
                                        WordDoc.SaveAs(ref argFileName);
                                        var linkedDoc = new Documentss.Documents();
                                        linkedDoc.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblOrder);
                                        linkedDoc.SetRecordID = OrderID;
                                        linkedDoc.SetDocumentTypeID = 162;
                                        var fileName = filepath.Split('\\');
                                        linkedDoc.SetName = fileName[filepath.Split('\\').Length - 1];
                                        linkedDoc.SetNotes = "";
                                        linkedDoc.SetLocation = filepath;
                                        var cV = new Documentss.DocumentsValidator();
                                        cV.Validate(linkedDoc);
                                        linkedDoc = App.DB.Documents.Insert(linkedDoc);
                                        File.Delete(filepath);
                                    }
                                    else
                                    {
                                        // hhhh
                                        filepath = Path.ChangeExtension(filepath, ".pdf");
                                        if (File.Exists(filepath))
                                        {
                                            File.Delete(filepath);
                                        }

                                        object argFileName1 = filepath;
                                        object argFileFormat = WD.WdSaveFormat.wdFormatPDF;
                                        WordDoc.SaveAs(ref argFileName1, ref argFileFormat);
                                        Process.Start(filepath);
                                        while (!File.Exists(filepath))
                                            System.Threading.Thread.Sleep(1000);
                                        var linkedDoc = new Documentss.Documents();
                                        linkedDoc.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblOrder);
                                        linkedDoc.SetRecordID = OrderID;
                                        linkedDoc.SetDocumentTypeID = 162;
                                        var fileName = filepath.Split('\\');
                                        linkedDoc.SetName = fileName[filepath.Split('\\').Length - 1];
                                        linkedDoc.SetNotes = "";
                                        linkedDoc.SetLocation = filepath;
                                        var cV = new Documentss.DocumentsValidator();
                                        cV.Validate(linkedDoc);
                                        linkedDoc = App.DB.Documents.Insert(linkedDoc);
                                    }
                                }
                                else if (PrintType == Enums.SystemDocumentType.SiteLetter)
                                {
                                    var linkedDoc = new Documentss.Documents();
                                    linkedDoc.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblSite);
                                    linkedDoc.SetRecordID = SiteID;
                                    linkedDoc.SetDocumentTypeID = 205;
                                    var fileName = filepath.Split('\\');
                                    linkedDoc.SetName = fileName[filepath.Split('\\').Length - 1];
                                    if (Directory.Exists(filepath.Replace(linkedDoc.Name, "")) == false)
                                    {
                                        Directory.CreateDirectory(filepath.Replace(linkedDoc.Name, ""));
                                    }

                                    object argFileName4 = filepath;
                                    WordDoc.SaveAs(ref argFileName4);
                                    linkedDoc.SetNotes = "";
                                    linkedDoc.SetLocation = filepath;
                                    var cV = new Documentss.DocumentsValidator();
                                    cV.Validate(linkedDoc);
                                    linkedDoc = App.DB.Documents.Insert(linkedDoc);
                                }

                                // System.IO.File.Delete(filepath)
                                else
                                {
                                    filepath = FileCheck(filepath);
                                    string fileExt = Path.GetExtension(filepath);
                                    if ((fileExt ?? "") == ".pdf")
                                    {
                                        object argFileName2 = filepath;
                                        object argFileFormat1 = WD.WdSaveFormat.wdFormatPDF;
                                        WordDoc.SaveAs(ref argFileName2, ref argFileFormat1);
                                    }
                                    else
                                    {
                                        object argFileName3 = filepath;
                                        WordDoc.SaveAs(ref argFileName3);
                                    }
                                }
                            }
                        }
                    }
                }

                DestroyWord(withKill);
                return filepath;
            }

            private string FileCheck(string filePath)
            {
                // check if file exists first
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                catch (Exception ex)
                {
                    // can't delete because another process is using
                    string ext = Path.GetExtension(filePath);
                    filePath = filePath.Replace(ext, "_New" + ext);
                }

                return filePath;
            }

            public void DestroyWord(bool withKill)
            {
                if (WordDoc is object)
                {
                    Marshal.ReleaseComObject(WordDoc.Content);
                    object argSaveChanges = false;
                    WordDoc.Close(SaveChanges: ref argSaveChanges);
                    Marshal.ReleaseComObject(WordDoc);
                    WordDoc = null;
                }

                if (withKill)
                {
                    if (MsWordApp is object)
                    {
                        foreach (WD.Document doc in _wordApp.Documents)
                        {
                            object argSaveChanges1 = (object)false;
                            doc.Close(SaveChanges: ref argSaveChanges1);
                            Marshal.ReleaseComObject(doc);
                        }

                        object argSaveChanges2 = (object)false;
                        MsWordApp.Quit(SaveChanges: ref argSaveChanges2);
                        Marshal.ReleaseComObject(MsWordApp);
                        MsWordApp = null;
                    }

                    var mp = Process.GetProcessesByName("WINWORD");
                    foreach (Process p in mp)
                    {
                        try
                        {
                            if (p.Responding)
                            {
                                if (string.IsNullOrEmpty(p.MainWindowTitle))
                                {
                                    p.Kill();
                                }
                            }
                            else
                            {
                                p.Kill();
                            }
                        }
                        catch
                        {
                        }
                    };
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            public static MatchCollection GetTemplateFields(string documentText)
            {
                var regex = new Regex(@"\[[A-z|0-9]*\]");
                return regex.Matches(documentText);
            }

            public static void ReplaceText(ref WD.Document msWordDoc, string OldText, string NewText)
            {
                {
                    var withBlock = msWordDoc.Content.Find;
                    withBlock.Text = OldText;
                    if (NewText.Length > 255)
                    {
                        withBlock.Replacement.Text = NewText.Substring(0, 255);
                    }
                    else
                    {
                        withBlock.Replacement.Text = NewText;
                    }

                    object argReplace = WD.WdReplace.wdReplaceAll;
                    withBlock.Execute(Replace: ref argReplace);
                }
            }

            public bool GSRSave(string filepath, EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string fileName)
            {
                try
                {
                    var oCustomer = App.DB.Customer.Customer_Get_Light(oSite.CustomerID);
                    if (oCustomer is null)
                        return false;
                    var oDocument = App.DB.Documents.Documents_Get_ByFilePath(filepath);
                    if (oDocument is null)
                    {
                        oDocument = new Documentss.Documents();
                        oDocument.SetTableEnumID = Conversions.ToInteger(Enums.TableNames.tblEngineerVisit);
                        oDocument.SetRecordID = oEngineerVisit.EngineerVisitID;
                        oDocument.SetDocumentTypeID = Consts.GSR;
                        oDocument.SetName = fileName;
                        oDocument.SetNotes = "Printed on " + DateAndTime.Now.ToShortDateString() + " at " + DateAndTime.Now.ToString("HH:mm") + " by " + App.loggedInUser.Fullname;
                        oDocument.SetLocation = filepath;
                        App.DB.Documents.Insert(oDocument, false);
                    }
                    else
                    {
                        oDocument.SetNotes = "Last printed on " + DateAndTime.Now.ToShortDateString() + " at " + DateAndTime.Now.ToString("HH:mm") + " by " + App.loggedInUser.Fullname;
                        App.DB.Documents.Update(oDocument);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            private void ElecCertPDF(EngineerVisits.EngineerVisit oEngineerVisit, EngineerVisitAdditionals.EngineerVisitAdditional ElectricalResuts, string filename)
            {
                string filePath = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblEngineerVisit);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                filePath += @"\" + oEngineerVisit.EngineerVisitID;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                filePath += @"\" + filename + DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";

                // If Not r("CustomerID") = Enums.Customer.NCC Then GSRSave(filePath, oEngineerVisit)

                string pdfTemp = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\" + filename + ".pdf"; // ---> It's the original pdf form you want to fill
                string newFile = filePath; // ---> It will generate new pdf that you have filled from your program

                // ------ READING -------

                var pdfReader = new PdfReader(pdfTemp);
                // ------ WRITING -------
                var ms = new MemoryStream();
                var pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create), '4'); // Creating the PDF in version 1.4

                // Method 1
                pdfStamper.FormFlattening = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.PDFEditor) ? false : true;
                // If you don�t specify version and append flag (last 2 params) in below line then you may receive �Extended Features� error when you open generated PDF
                // Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)

                // pdfStamper.FormfFlattening = True
                // pdfStamper.AcroFields.GenerateAppearances = True

                var pdfFormFields = pdfStamper.AcroFields;

                // --------Get some Data-----------
                var osite = App.DB.Sites.Get(ElectricalResuts.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId);
                var ositeHQ = new Sites.Site();
                if (!(osite.CustomerID == (int)Enums.Customer.Domestic))
                    ositeHQ = App.DB.Sites.Get(osite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                // ------ SET YOUR FORM FIELDS ------

                PdfSetFormFieldText(ref pdfFormFields, "Client", ositeHQ.Name, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "ClientAddress", ositeHQ.Address1 + (char)10 + ositeHQ.Address2 + (char)10 + ositeHQ.Address3, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "ClientPostcode", Helper.FormatPostcode(ositeHQ.Postcode), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Installer", osite.Name, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "InstallerAddress", osite.Address1 + (char)10 + osite.Address2 + (char)10 + osite.Address3, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "InstallerPostcode", Helper.FormatPostcode(osite.Postcode), 7.7F);
                string @ref = "20656" + oEngineerVisit.EngineerVisitID;
                int length = @ref.Length;
                int character = 0;
                for (character = length; character >= 0; character -= 1)
                    @ref = @ref.Insert(character, "  ");

                // Dim unicode As BaseFont = BaseFont.CreateFont(BaseFont.ZAPFDINGBATS, BaseFont.ZAPFDINGBATS, BaseFont.NOT_EMBEDDED)
                // pdfFormFields.SetFieldProperty("ID", "textfont", unicode, Nothing)
                // pdfFormFields.SetField("ID", "4") 'tick

                // Dim fields() As String = pdfStamper.AcroFields.Fields.[Select](Function(x) x.Key).ToArray()
                // For key As Integer = 0 To fields.Count - 1
                // pdfStamper.AcroFields.SetFieldProperty(fields(key), "setfflags", PdfFormField.FF_READ_ONLY, Nothing)
                // Next
                PdfSetFormFieldText(ref pdfFormFields, "CertNo", @ref, 14.25F);
                PdfSetFormFieldText(ref pdfFormFields, "Description1", ElectricalResuts.Test11, 8.0F);
                var switchExpr = ElectricalResuts.Test1;
                switch (switchExpr)
                {
                    case 69996:
                        {
                            PDFSetTick(ref pdfFormFields, "New", @ref, 12.0F);
                            break;
                        }

                    case 69997:
                        {
                            PDFSetTick(ref pdfFormFields, "Addition", @ref, 12.0F);
                            break;
                        }

                    case 69998:
                        {
                            PDFSetTick(ref pdfFormFields, "Alteration", @ref, 12.0F);
                            break;
                        }
                }

                var switchExpr1 = ElectricalResuts.Test2;
                switch (switchExpr1)
                {
                    case 386:
                        {
                            PDFSetTick(ref pdfFormFields, "RecordsYes", @ref, 12.0F);
                            break;
                        }

                    case 387:
                        {
                            PDFSetTick(ref pdfFormFields, "RecordsNo", @ref, 12.0F);
                            break;
                        }
                }

                PdfSetFormFieldText(ref pdfFormFields, "BS7671", "2008", 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Date1", "2015", 8.0F);
                var switchExpr2 = ElectricalResuts.Test3;
                switch (switchExpr2)
                {
                    case 69999:
                        {
                            PDFSetTick(ref pdfFormFields, "TNS", @ref, 8.0F);
                            break;
                        }

                    case 70001:
                        {
                            PDFSetTick(ref pdfFormFields, "TNCS", @ref, 12.0F);
                            break;
                        }

                    case 70000:
                        {
                            PDFSetTick(ref pdfFormFields, "TT", @ref, 12.0F);
                            break;
                        }

                    case 70002:
                        {
                            PDFSetTick(ref pdfFormFields, "Other1", @ref, 12.0F);
                            break;
                        }
                }

                PdfSetFormFieldText(ref pdfFormFields, "Specify1", ElectricalResuts.Test12, 12.0F);
                PDFSetTick(ref pdfFormFields, "Ac", @ref, 12.0F);
                // PdfSetFormFieldText(pdfFormFields, "Dc", ref, 12.0F)

                PdfSetFormFieldText(ref pdfFormFields, "Phases", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test4).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Wires", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test5).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Voltage1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test6).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Frequency", "50", 8.0F);
                if (ElectricalResuts.Test7 == 421)
                {
                    PDFSetTick(ref pdfFormFields, "Polarity1", @ref, 8.0F);
                }

                PdfSetFormFieldText(ref pdfFormFields, "FaultCurrent", ElectricalResuts.Test13, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Device", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test8).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Type1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test9).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Impedance", ElectricalResuts.Test14, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "RatedCurrent", ElectricalResuts.Test15, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "SupplySource", ElectricalResuts.Test216, 8.0F);
                if (ElectricalResuts.Test10 == 70017)
                {
                    PDFSetTick(ref pdfFormFields, "Facility", @ref, 12.0F);
                }
                else
                {
                    PDFSetTick(ref pdfFormFields, "EarthElectrode", @ref, 12.0F);
                }

                PdfSetFormFieldText(ref pdfFormFields, "Location1", ElectricalResuts.Test217, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Type2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test111).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Ma", ElectricalResuts.Test223, 8.0F); // text13
                PdfSetFormFieldText(ref pdfFormFields, "Resistance", ElectricalResuts.Test218, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "EarthConductor1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test112).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "EarthConductor2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test113).Name, 8.0F);
                PDFSetTick(ref pdfFormFields, "EarthingConductor3", @ref, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "BondingConductor1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test114).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "BondingConductor2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test115).Name, 8.0F);
                PDFSetTick(ref pdfFormFields, "BondingConductor3", @ref, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "SupplyConductor1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test116).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "SupplyConductor2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test117).Name, 8.0F);
                PDFSetTick(ref pdfFormFields, "SupplyConductor3", @ref, 8.0F);
                if (ElectricalResuts.Test118 == (int)Enums.TabletYesNoNA.Yes)
                {
                    PDFSetTick(ref pdfFormFields, "WaterPipe", @ref, 8.0F);
                }

                if (ElectricalResuts.Test119 == (int)Enums.TabletYesNoNA.Yes)
                {
                    PDFSetTick(ref pdfFormFields, "GasPipe", @ref, 8.0F);
                }

                if (ElectricalResuts.Test120 == (int)Enums.TabletYesNoNA.Yes)
                {
                    PDFSetTick(ref pdfFormFields, "OilPipe", @ref, 8.0F);
                }
                // If ElectricalResuts.Test118 = Enums.TabletYesNoNA.Yes Then ' not used
                // PdfSetFormFieldText(pdfFormFields, "Other2", ref, 8.0F)
                // End If
                if (ElectricalResuts.Test122 == (int)Enums.TabletYesNoNA.Yes)
                {
                    PDFSetTick(ref pdfFormFields, "Lighting", @ref, 8.0F);
                }

                if (ElectricalResuts.Test121 == (int)Enums.TabletYesNoNA.Yes)
                {
                    PDFSetTick(ref pdfFormFields, "Steel", @ref, 8.0F);
                }

                // PdfSetFormFieldText(pdfFormFields, "Specify2", ref, 8.0F) not used
                PdfSetFormFieldText(ref pdfFormFields, "Delay", ElectricalResuts.Test224, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Time", ElectricalResuts.Test225, 8.0F);
                var EquipmentDT = App.DB.Engineer.Equipment_GetForEngineer(oEngineerVisit.EngineerID).Table;
                string List = "";
                foreach (DataRow EquipmentDR in EquipmentDT.Select("EquipmentTypeID = 70962")) // Electrical Test Instrument
                    List += Conversions.ToString(EquipmentDR["SerialNumber"]) + (char)10;
                PdfSetFormFieldText(ref pdfFormFields, "SerialNumber", List, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "FuseDevice", ElectricalResuts.Test220, 8.0F);  // text10
                PdfSetFormFieldText(ref pdfFormFields, "BSEN", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test123).Name, 8.0F); // cbo23
                PdfSetFormFieldText(ref pdfFormFields, "Voltage2", ElectricalResuts.Test221, 8.0F);   // text11
                PdfSetFormFieldText(ref pdfFormFields, "Poles", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test124).Name, 8.0F); // cbo24
                PdfSetFormFieldText(ref pdfFormFields, "Location2", ElectricalResuts.Test222, 8.0F); // text12
                PdfSetFormFieldText(ref pdfFormFields, "Rating1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test125).Name, 8.0F); // cbo25
                PdfSetFormFieldText(ref pdfFormFields, "CircuitNo", ElectricalResuts.Test226, 8.0F); // text16
                PdfSetFormFieldText(ref pdfFormFields, "Designation", ElectricalResuts.Test227, 8.0F); // text17
                PdfSetFormFieldText(ref pdfFormFields, "Wiring", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test126).Name, 8.0F); // cbo26
                PdfSetFormFieldText(ref pdfFormFields, "Method", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test127).Name, 8.0F); // cbo27
                PdfSetFormFieldText(ref pdfFormFields, "PointsServed", ElectricalResuts.Test228, 8.0F); // text18
                PdfSetFormFieldText(ref pdfFormFields, "Live", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test128).Name, 8.0F); // cbo28
                PdfSetFormFieldText(ref pdfFormFields, "CPC", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test129).Name, 8.0F); // cbo29
                PdfSetFormFieldText(ref pdfFormFields, "Disconnection", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name, 8.0F); // cbo30
                PdfSetFormFieldText(ref pdfFormFields, "BSENNo", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test131).Name, 8.0F); // cbo31
                PdfSetFormFieldText(ref pdfFormFields, "TypeNo", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test132).Name, 8.0F); // cbo32
                PdfSetFormFieldText(ref pdfFormFields, "Rating2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test133).Name, 8.0F); // cbo33
                PdfSetFormFieldText(ref pdfFormFields, "Capacity", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test134).Name, 8.0F); // cbo34
                PdfSetFormFieldText(ref pdfFormFields, "RCD", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test135).Name, 8.0F); // cbo35
                var elecDt = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_ElectricalZsMatrix_Get(); // Get the matrix
                string BSNo = App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test131).Name;
                var switchExpr3 = BSNo;  // some are duplicated in matrix so covert to primary Number for this section of code
                switch (switchExpr3)
                {
                    case "1362":
                        {
                            BSNo = "1361";
                            break;
                        }

                    case "60898":
                    case "61008":
                        {
                            BSNo = "3871";
                            break;
                        }

                    case var @case when @case == "61008":
                        {
                            BSNo = "61009";
                            break;
                        }
                }

                string Type = App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test132).Name;
                var switchExpr4 = Type; // same with type
                switch (switchExpr4)
                {
                    case "B":
                        {
                            Type = "3";
                            break;
                        }

                    case "3":
                    case "C":
                        {
                            Type = "4";
                            break;
                        }

                    case "D":
                        {
                            Type = "5";
                            break;
                        }
                }

                string rated = App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test133).Name;
                if ((rated ?? "") == "2")
                    rated = "3"; // fix for error on tablet
                DataRow dr;
                try
                {
                    dr = elecDt.Select("Rated = " + rated)[0];
                }
                catch (Exception ex)
                {
                    dr = elecDt.Select("Rated = 3")[0];
                }

                string result = "N/A";
                if ((App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name ?? "") == "0.4" | (App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name ?? "") == "5")
                {
                    if ((BSNo ?? "") == "3871")
                    {
                        result = Conversions.ToString(dr["BS" + BSNo + "_" + Type]);
                    }
                    else
                    {
                        result = Conversions.ToString(dr["BS" + BSNo + "_" + App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name.ToString().Replace(".", "")]);
                    }
                }

                PdfSetFormFieldText(ref pdfFormFields, "BS7671Value", result, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "R1", ElectricalResuts.Test229, 8.0F); // text19
                PdfSetFormFieldText(ref pdfFormFields, "Rn", ElectricalResuts.Test230, 8.0F);  // text20
                PdfSetFormFieldText(ref pdfFormFields, "R2", ElectricalResuts.Test231, 8.0F);  // text21
                PdfSetFormFieldText(ref pdfFormFields, "Figure8", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test136).Name, 8.0F); // cbo36
                PdfSetFormFieldText(ref pdfFormFields, "R1R2", ElectricalResuts.Test232, 8.0F); // text22
                PdfSetFormFieldText(ref pdfFormFields, "R22", "N/A", 8.0F); // n/a
                PdfSetFormFieldText(ref pdfFormFields, "LiveLive", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test137).Name, 8.0F); // cbo37
                PdfSetFormFieldText(ref pdfFormFields, "LiveEarth", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test138).Name, 8.0F); // cbo38
                PdfSetFormFieldText(ref pdfFormFields, "Polarity2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test139).Name, 8.0F); // cbo39
                PdfSetFormFieldText(ref pdfFormFields, "Zs", ElectricalResuts.Test233, 8.0F); // text23
                PdfSetFormFieldText(ref pdfFormFields, "RCDTest1", ElectricalResuts.Test234, 8.0F); // text24
                PdfSetFormFieldText(ref pdfFormFields, "RCDTest2", ElectricalResuts.Test235, 8.0F); // text25
                PdfSetFormFieldText(ref pdfFormFields, "TestButtonOp", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test140).Name, 8.0F); // cbo40
                PdfSetFormFieldText(ref pdfFormFields, "CircuitDetails", "Electronic Equipment or Accessories", 8.0F); // always
                PdfSetFormFieldText(ref pdfFormFields, "RiskAssessment", "N/A", 5.0F); // HC small
                PdfSetFormFieldText(ref pdfFormFields, "JobTitle", "Electrician", 8.0F); // HC
                var Engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                PdfSetFormFieldText(ref pdfFormFields, "Engineer", Engineer.Name, 8.0F); // Get engineer
                var visitDate = oEngineerVisit.StartDateTime;
                if (visitDate == default)
                {
                    visitDate = oEngineerVisit.ManualEntryOn;
                }

                PdfSetFormFieldText(ref pdfFormFields, "Date2", visitDate.ToShortDateString(), 8.0F);
                var fp = pdfFormFields.GetFieldPositions("Signature")[0];
                int page = fp.page;
                var rect = fp.position;
                var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                engSig.Save(Application.StartupPath + @"\TEMP\EngSig.bmp");
                var image = text.Image.GetInstance(Application.StartupPath + @"\TEMP\EngSig.bmp");
                image.ScaleToFit(rect.Width, rect.Height);
                image.SetAbsolutePosition(rect.Left, rect.Bottom);
                var over = pdfStamper.GetOverContent(page);
                over.AddImage(image);

                // close the pdf
                pdfStamper.Close();
                // pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
                pdfStamper.Close();
                pdfReader.Close(); // DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP - well i did!!
                Cursor.Current = Cursors.WaitCursor;
                Process.Start(filePath);
                Cursor.Current = Cursors.Default;
            }

            private void PDFSetTick(ref AcroFields acroFields, string fieldName, string replacementText, float textSize)
            {
                var pdfFormFields = acroFields;
                var font = text.FontFactory.GetFont(Application.StartupPath + "/fonts/zapfdingbats.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 0.5F, text.Font.NORMAL, text.BaseColor.BLACK);
                var bf = font.BaseFont;
                pdfFormFields.SetFieldProperty(fieldName, "textfont", bf, null);
                pdfFormFields.SetField(fieldName, "4"); // tick '4
                pdfFormFields.SetFieldProperty(fieldName, "textsize", 5.0F, null);
            }

            private void PdfSetFormFieldText(ref AcroFields acroFields, string fieldName, string replacementText, float textSize)
            {
                // Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

                // Dim font As iTextSharp.text.Font = New iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL)  ' need to sus out regarding

                var pdfFormFields = acroFields;
                pdfFormFields.SetFieldProperty(fieldName, "bgcolor", text.BaseColor.WHITE, null);
                pdfFormFields.SetFieldProperty(fieldName, "textsize", textSize, null);
                pdfFormFields.SetField(fieldName, replacementText);
            }

            private void WarningNoticePDF(EngineerVisits.EngineerVisit oEngineerVisit, DataRow WarningNotice, string filename)
            {
                string filePath = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToInteger(Enums.TableNames.tblEngineerVisit);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                filePath += @"\" + oEngineerVisit.EngineerVisitID;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                filePath += @"\" + filename + DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";

                // If Not r("CustomerID") = Entity.Sys.Enums.Customer.NCC Then GSRSave(filePath, oEngineerVisit)

                string pdfTemp = Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + @"\" + filename + ".pdf"; // ---> It's the original pdf form you want to fill
                string newFile = filePath; // ---> It will generate new pdf that you have filled from your program

                // ------ READING -------

                var pdfReader = new PdfReader(pdfTemp);
                // ------ WRITING -------
                var ms = new MemoryStream();
                var pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create), '4'); // Creating the PDF in version 1.4

                // Method 1
                pdfStamper.FormFlattening = true;
                // If you don�t specify version and append flag (last 2 params) in below line then you may receive �Extended Features� error when you open generated PDF
                // Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)

                // pdfStamper.FormfFlattening = True
                // pdfStamper.AcroFields.GenerateAppearances = True

                var pdfFormFields = pdfStamper.AcroFields;

                // --------Get some Data-----------

                var osite = App.DB.Sites.Get(oEngineerVisit.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId);
                var ositeHQ = App.DB.Sites.Get(osite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                if (ositeHQ == null)
                    ositeHQ = new Sites.Site();
                var Timesheets = App.DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(oEngineerVisit.EngineerVisitID).Table;
                var Engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                var LastWorking = DateTime.MinValue;
                foreach (DataRow dr in Timesheets.Rows)
                {
                    if (Conversions.ToDate(dr["EnddateTime"]) > LastWorking && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["TimesheetTypeID"], "211", false)))
                    {
                        LastWorking = Conversions.ToDate(dr["Enddatetime"]);
                    }
                }

                if (LastWorking == DateTime.MinValue)
                    LastWorking = oEngineerVisit.EndDateTime;
                // ------ SET YOUR FORM FIELDS ------

                PdfSetFormFieldText(ref pdfFormFields, "ClientName", ositeHQ.Name, 6.0F);
                PdfSetFormFieldText(ref pdfFormFields, "ClientAddress", ositeHQ.Address1 + ", ", 6.0F);
                PdfSetFormFieldText(ref pdfFormFields, "ClientPostcode", ositeHQ.Address2 + ", " + ositeHQ.Address3 + ", " + ositeHQ.Postcode, 6.0F);
                PdfSetFormFieldText(ref pdfFormFields, "TenantName", osite.Name, 6.0F);
                PdfSetFormFieldText(ref pdfFormFields, "TenantAddress", osite.Address1 + ", ", 6.0F);
                PdfSetFormFieldText(ref pdfFormFields, "TenantPostcode", osite.Address2 + ", " + osite.Address3 + ", " + osite.Postcode, 6.0F);
                PdfSetFormFieldText(ref pdfFormFields, "IssueDate", LastWorking.ToString("dd/MM/yyyy"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "IssueTime", LastWorking.ToString("HH:mm"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "EngName", Engineer.Name, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Make", Conversions.ToString(WarningNotice["Make"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Model", Conversions.ToString(WarningNotice["Model"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Type", Conversions.ToString(WarningNotice["Model"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Location", Conversions.ToString(WarningNotice["Location"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Reason", Conversions.ToString(WarningNotice["Reason"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Action", Conversions.ToString(WarningNotice["ActionTaken"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Present", Conversions.ToString(WarningNotice["NoticeLeft"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Refused", Conversions.ToString(WarningNotice["NoSign"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "NG1", Conversions.ToString(WarningNotice["SupplierInformed"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "NG2", Conversions.ToString(WarningNotice["SupplierInformed"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "TenName", oEngineerVisit.CustomerName, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "TenDate", LastWorking.ToString("dd/MM/yyyy"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "GasEscape", Conversions.ToString(WarningNotice["GasEscape"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Reason2", Conversions.ToString(WarningNotice["SupplierInformedReason"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Reference", Conversions.ToString(WarningNotice["SupplierInformedRef"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Riddor", Conversions.ToString(WarningNotice["RiddorReported"]), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Reason3", Conversions.ToString(WarningNotice["RiddorReportedDetails"]), 7.7F);
                // ------------------ DO TICKS ----------------------------------------------
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(WarningNotice["CategoryID"], 405, false)))
                {
                    PDFSetTick(ref pdfFormFields, "ID", "", 8.0F);
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(WarningNotice["CategoryID"], 404, false)))
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(WarningNotice["TurnedOff"], "1", false)))
                    {
                        PDFSetTick(ref pdfFormFields, "AR1", "", 8.0F);
                    }
                    else
                    {
                        PDFSetTick(ref pdfFormFields, "AR2", "", 8.0F);
                    }
                }

                // --------------------------------------------------------------------------
                if (oEngineerVisit.EngineerSignature != null)
                {
                    var engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                    engSig.Save(Application.StartupPath + @"\TEMP\EngSig.bmp");
                    var ad = pdfFormFields.GetNewPushbuttonFromField("EngSig");
                    // ad.setLayout(PushbuttonField.LAYOUT_ICON_ONLY)
                    // ad.setProportionalIcon(True);
                    ad.Image = text.Image.GetInstance(Application.StartupPath + @"\TEMP\EngSig.bmp");
                    pdfFormFields.ReplacePushbuttonField("EngSig", ad.Field);
                }
                if (oEngineerVisit.CustomerSignature != null)
                {
                    var CustSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                    CustSig.Save(Application.StartupPath + @"\TEMP\CustSig.bmp");
                    var ad1 = pdfFormFields.GetNewPushbuttonFromField("Signature");
                    // ad.setLayout(PushbuttonField.LAYOUT_ICON_ONLY)
                    // ad.setProportionalIcon(True);
                    ad1.Image = text.Image.GetInstance(Application.StartupPath + @"\TEMP\CustSig.bmp");
                    pdfFormFields.ReplacePushbuttonField("Signature", ad1.Field);
                }

                // close the pdf
                pdfStamper.Close();
                // pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
                pdfStamper.Close();
                pdfReader.Close(); // DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP - well i did!!
                Cursor.Current = Cursors.WaitCursor;
                Process.Start(filePath);
                Cursor.Current = Cursors.Default;
            }
        }
    }
}