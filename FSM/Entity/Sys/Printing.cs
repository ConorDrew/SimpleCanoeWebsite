using DocumentFormat.OpenXml.Packaging;
using FSM.Entity.ContactAttempts;
using FSM.Entity.Sys;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using text = iTextSharp.text;
using WD = Microsoft.Office.Interop.Word;
using WP = DocumentFormat.OpenXml.Wordprocessing;

namespace Entity
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

            private WD.Application _wordApp = null/* TODO Change to default(_) if this is not a reference type */;

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

            private WD.Document _wordDoc = null/* TODO Change to default(_) if this is not a reference type */;

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

            private List<FSM.LSR.LSRError> _lsrErrors = new List<FSM.LSR.LSRError>();

            private List<FSM.LSR.LSRError> LSRErrors
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

            public Printing(object detailsToPrintIn, string documentNameIn, Enums.SystemDocumentType printTypeIn, bool multipleDocs = false, int OrderID = 0, bool isEmail = false, int ApptsPerDay = 13, int CustomerID = default(int), DateTime LetterCreationDate = default(DateTime), DataTable dt = null/* TODO Change to default(_) if this is not a reference type */)
            {
                ContractsDT = dt;
                DetailsToPrint = detailsToPrintIn;
                DocumentName = documentNameIn;
                PrintType = printTypeIn;
                this.OrderID = OrderID;
                if (!isEmail == true)
                {
                    if (multipleDocs == true)
                        PrintMultiDocs(ApptsPerDay, CustomerID, LetterCreationDate);
                    else
                        Print();
                }
            }

            public ArrayList MultiEmail()
            {
                string DetailsToPrint = "";
                bool success = false;
                string filePath = "";
                ArrayList returnStuff = new ArrayList();

                Cursor.Current = Cursors.WaitCursor;

                switch (PrintType)
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
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (success)
                                    returnStuff.Add(filePath);
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
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (success)
                                    returnStuff.Add(filePath);
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

                    switch (PrintType)
                    {
                        case object _ when Enums.SystemDocumentType.JobImportLetters:
                            {
                                DataTable dt = (ArrayList)this.DetailsToPrint.Item(0);
                                EngineerVisits.EngineerVisit engineerVisit = null/* TODO Change to default(_) if this is not a reference type */;
                                if ((ArrayList)this.DetailsToPrint.Count > 1)
                                    engineerVisit = (ArrayList)this.DetailsToPrint.Item(1);
                                DataRow r = dt.Rows(0);
                                Jobs.Job job = new Jobs.Job();

                                job = DB.Job.Job_Get(r("JobID"));
                                int visitAmount = DB.EngineerVisits.EngineerVisits_Get_All_JobID(System.Convert.ToInt32(r("JobID"))).Count;
                                bool letter1 = Interaction.IIf(visitAmount > 1, false, true);
                                success = GenerateJobLetter(dt.Rows(0), job, letter1, null/* TODO Change to default(_) if this is not a reference type */, engineerVisit);
                                if (!success)
                                    throw new Exception();
                                // mark letter as completed in dbf
                                if (letter1)
                                    success = DB.JobImports.JobImport_Update_Letter1(r, job);
                                else
                                    success = DB.JobImports.JobImport_Update_Letter2(r, job);
                                if (!success)
                                    throw new Exception();
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    success = false;
                    ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
                return wpFilePath;
            }

            private void PrintMultiDocs(int MinsPerDayIn = 550, int CustomerID = default(Integer), DateTime LetterCreationDate = default(DateTime))
            {
                // Dim DetailsToPrint As String = ""
                bool success = false;
                string filePath = "";

                switch (PrintType)
                {
                    case object _ when Enums.SystemDocumentType.GSRBatch:
                        {
                            try
                            {
                                LSRErrors.Clear();
                                FolderBrowserDialog folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim.Length == 0)
                                    return;
                                else
                                    filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".docx";

                                List<byte[]> fullDocument = new List<byte[]>();

                                DataRow[] dr = (ArrayList)this.DetailsToPrint.Item(0);
                                foreach (DataRow r in dr)
                                {
                                    int engineerVisitId = Helper.MakeIntegerValid(r("EngineerVisitID"));
                                    string jobNumber = Helper.MakeStringValid(r("JobNumber"));
                                    success = PrintGSR(engineerVisitId, fullDocument, jobNumber);
                                }

                                if (success)
                                {
                                    if (fullDocument.Count > 0)
                                    {
                                        File.WriteAllBytes(filePath, PrintHelper.CombineDocs(fullDocument));

                                        PrintHelper.RemoveSpacingInDoc(filePath);
                                        if (!loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
                                            filePath = PrintHelper.LockFile(filePath, true);
                                    }
                                }

                                if (LSRErrors.Count > 0)
                                {
                                    List<string> errors = new List<string>();
                                    foreach (LSR.LSRError lsrError in LSRErrors)
                                    {
                                        {
                                            var withBlock = lsrError;
                                            errors.Add("Job Number: " + withBlock.JobNumber + " | Visit Date: " + withBlock.VisitDate + " | Engineer:  " + withBlock.Engineer + " | EngineerVisitID:  " + withBlock.EngineerVisitID);
                                        }
                                    }
                                    ShowMessageWithDetails("Blank LSRs", "The following jobs have blank LSRs!", errors);
                                }
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (success)
                                    Process.Start(filePath);
                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case object _ when Enums.SystemDocumentType.ServiceLetters:
                        {
                            string folderName = @"C:\";

                            try
                            {
                                object obj;
                                System.Type t;

                                // Get the ProgID for Word
                                t = System.Type.GetTypeFromProgID("Word.Application", true);

                                obj = System.Activator.CreateInstance(t, true);

                                MsWordApp = (Word.Application)obj;

                                MessageFilter.Register();

                                // WordApp = New Word.Application
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;

                                folderName = TheSystem.Configuration.DocumentsLocation + @"ServiceLetters\ServiceLetters" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + @"\";
                                if (System.IO.Directory.Exists(folderName) == false)
                                    System.IO.Directory.CreateDirectory(folderName);

                                filePath = folderName + "ServiceLetters1_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc";

                                Word.Document Letter1Doc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot");
                                Word.Document Letter2Doc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot");
                                Word.Document Letter2HandLetters = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot");
                                // WordDoc = WordApp.Documents.Add(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetter.dot")
                                Word.Document Letter3Doc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot");
                                Word.Document Letter3HandLetters = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ServiceLetter.dot");

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

                                DataRow[] dr = (ArrayList)this.DetailsToPrint.Item(0);

                                // Dim AMsToDo As Integer = 0
                                // Dim AMsAssigned As Integer = 0
                                // AMsToDo = dr.Length / 2

                                int servicePriority = 0;
                                Array rows = DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'Service'");
                                if (rows.Length == 0)
                                {
                                    PickLists.PickList oPickList = new PickLists.PickList();
                                    oPickList.SetName = "Service";
                                    oPickList.SetEnumTypeID = System.Convert.ToInt32(Enums.PickListTypes.JOWPriority);
                                    servicePriority = DB.Picklists.Insert(oPickList);
                                }
                                else
                                    servicePriority = (DataRow)rows(0).Item("ManagerID");

                                System.IO.StreamWriter oWriteSolidFuels;
                                oWriteSolidFuels = File.CreateText(folderName + "SolidFuels.txt");
                                oWriteSolidFuels.WriteLine("Solid Fuels Properties : ");

                                System.IO.StreamWriter oWriteWA;
                                oWriteWA = File.CreateText(folderName + "WarningsAdvice.txt");
                                oWriteWA.WriteLine("Properties with Warnings/Advice : ");

                                System.IO.StreamWriter oWriteVoids;
                                oWriteVoids = File.CreateText(folderName + "Voids.txt");
                                oWriteVoids.WriteLine("Voids Properties : ");

                                System.IO.StreamWriter oWriteSiteFuel;
                                oWriteSiteFuel = File.CreateText(folderName + "NonGasSiteFuels.txt");
                                oWriteSiteFuel.WriteLine("Non Gas Site Fuel Properties : ");

                                int HighestLoops = 0;

                                try
                                {
                                    string AMPM = "";
                                    string Fuel = "";
                                    DataTable dtDays = new DataTable();
                                    dtDays.Columns.Add("MondayDate", typeof(DateTime));
                                    dtDays.Columns.Add("TheDate", typeof(DateTime));
                                    dtDays.Columns.Add("Count");
                                    dtDays.Columns.Add("AM");
                                    dtDays.Columns.Add("PM");
                                    dtDays.Columns.Add("ApptsMinsTally");
                                    dtDays.Columns.Add("Loops");

                                    DataTable dtLetter2AMPM = new DataTable();
                                    dtLetter2AMPM.Columns.Add("Date", typeof(DateTime));
                                    dtLetter2AMPM.Columns.Add("Count");
                                    dtLetter2AMPM.Columns.Add("AMAssigned");

                                    DataTable dtLetter3AMPM = new DataTable();
                                    dtLetter3AMPM.Columns.Add("Date", typeof(DateTime));
                                    dtLetter3AMPM.Columns.Add("Count");
                                    dtLetter3AMPM.Columns.Add("AMAssigned");

                                    DB.LetterManager.Clear_LetterDays_Table();

                                    // LETS DO DATES FIRST
                                    foreach (DataRow d in dr)
                                    {
                                        if (CustomerID == 5155 & (DateTime)d("LastServiceDate") < (DateTime)"2012-05-01 00:00:00")
                                            // do nothing
                                            DateTime DateHolder = (DateTime)d("LastServiceDate");
                                        else if (d("type") == "Letter 1")
                                        {
                                            Sites.Site oSite = DB.Sites.Get(d("SiteID"));
                                            DataRow[] sorRows;

                                            if (oSite.CommercialDistrict == true)
                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7008'");
                                            else if (oSite.SolidFuel == true)
                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7001'");
                                            else
                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7007'");

                                            int TimeInMins;
                                            if (sorRows.Length > 0)
                                            {
                                                DataRow sorRow = sorRows[0];
                                                DataTable customerSors = DB.CustomerScheduleOfRate.Exists(sorRow("ScheduleOfRatesCategoryID"), sorRow("Description"), sorRow("Code"), CustomerID);
                                                int customerSorId = Helper.MakeIntegerValid(customerSors(0)(0));

                                                if (customerSorId > 0)
                                                {
                                                    CustomerScheduleOfRates.CustomerScheduleOfRate customerSor = DB.CustomerScheduleOfRate.Get(customerSorId);
                                                    if (customerSor == null)
                                                        customerSor = new CustomerScheduleOfRates.CustomerScheduleOfRate();
                                                    // Use Site SOR
                                                    TimeInMins = customerSor.TimeInMins;
                                                }
                                                else
                                                    // Use System SOR
                                                    TimeInMins = sorRow("TimeInMins");
                                            }

                                            if (CustomerID == 5155)
                                            {
                                                if ((DateTime)d("NextVisitDate") <= (DateTime)"2013-05-07 00:00:00")
                                                {
                                                    DateTime NewNextVisitDate = LetterCreationDate.AddDays(56);
                                                    d("NextVisitDate") = DateHelper.CheckBankHolidaySatOrSun(NewNextVisitDate);
                                                }
                                                else
                                                    d("NextVisitDate") = DateHelper.CheckBankHolidaySatOrSun(d("NextVisitDate"));
                                            }
                                            else
                                                d("NextVisitDate") = DateHelper.CheckBankHolidaySatOrSun(d("NextVisitDate"));

                                            int MaxLoops = 1;

                                            bool ApptFound = false;
                                            while (ApptFound == false)
                                            {
                                                for (int lps = 1; lps <= MaxLoops; lps++)
                                                {
                                                    if (lps > HighestLoops)
                                                        HighestLoops = lps;

                                                    for (int dow = 1; dow <= 4; dow++)
                                                    {
                                                        DataView dvBankHolidays = DB.TimeSlotRates.BankHolidays_GetAll;
                                                        if (dvBankHolidays.Table.Select("BankHolidayDate='" + DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow) + "'").Length == 0)
                                                        {
                                                            DataRow[] theRow = dtDays.Select("MondayDate='" + DateHelper.GetTheMonday(d("NextVisitDate")) + "' AND TheDate='" + DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow) + "' AND Loops='" + lps + "'");
                                                            if (theRow.Length == 0)
                                                            {
                                                                dtDays.Rows.Add(new object[] { DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), 1, 1, 0, TimeInMins, lps });
                                                                DB.LetterManager.Insert_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), TimeInMins, lps);
                                                                ApptFound = true;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                int ApptsMinsTally = theRow[0].Item("ApptsMinsTally");
                                                                if (ApptsMinsTally <= (MinsPerDayIn / (double)2))
                                                                {
                                                                    theRow[0].Item("count") += 1;
                                                                    theRow[0].Item("AM") += 1;
                                                                    theRow[0].Item("ApptsMinsTally") += TimeInMins;
                                                                    DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), theRow[0].Item("count"), theRow[0].Item("AM"), null/* TODO Change to default(_) if this is not a reference type */, theRow[0].Item("ApptsMinsTally"), lps);
                                                                    ApptFound = true;
                                                                    break;
                                                                }
                                                                else if (ApptsMinsTally > (MinsPerDayIn / (double)2) & ApptsMinsTally <= MinsPerDayIn)
                                                                {
                                                                    theRow[0].Item("count") += 1;
                                                                    theRow[0].Item("PM") += 1;
                                                                    theRow[0].Item("ApptsMinsTally") += TimeInMins;
                                                                    DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), theRow[0].Item("count"), null/* TODO Change to default(_) if this is not a reference type */, theRow[0].Item("PM"), theRow[0].Item("ApptsMinsTally"), lps);
                                                                    ApptFound = true;
                                                                    break;
                                                                }
                                                                else
                                                                    ApptFound = false;
                                                            }
                                                        }
                                                        else
                                                            ApptFound = false;
                                                    }

                                                    if (ApptFound == false)
                                                    {
                                                        DataView dvBankHolidays = DB.TimeSlotRates.BankHolidays_GetAll;
                                                        int dow = 0;
                                                        bool ResetApptMins = false;

                                                        if (dvBankHolidays.Table.Select("BankHolidayDate='" + DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow) + "'").Length == 0)
                                                        {
                                                            DataRow[] theRow = dtDays.Select("MondayDate='" + DateHelper.GetTheMonday(d("NextVisitDate")) + "' AND TheDate='" + DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow) + "' AND Loops='" + lps + "'");
                                                            if (theRow.Length == 0)
                                                            {
                                                                dtDays.Rows.Add(new object[] { DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), 1, 1, 0, TimeInMins, lps });
                                                                DB.LetterManager.Insert_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), TimeInMins, lps);
                                                                ApptFound = true;
                                                            }
                                                            else
                                                            {
                                                                int ApptsMinsTally = theRow[0].Item("ApptsMinsTally");
                                                                if (ApptsMinsTally <= (MinsPerDayIn / (double)2))
                                                                {
                                                                    theRow[0].Item("count") += 1;
                                                                    theRow[0].Item("AM") += 1;
                                                                    theRow[0].Item("ApptsMinsTally") += TimeInMins;
                                                                    DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), theRow[0].Item("count"), theRow[0].Item("AM"), null/* TODO Change to default(_) if this is not a reference type */, theRow[0].Item("ApptsMinsTally"), lps);
                                                                    ApptFound = true;
                                                                }
                                                                else if (ApptsMinsTally > (MinsPerDayIn / (double)2) & ApptsMinsTally <= MinsPerDayIn)
                                                                {
                                                                    theRow[0].Item("count") += 1;
                                                                    theRow[0].Item("PM") += 1;
                                                                    theRow[0].Item("ApptsMinsTally") += TimeInMins;
                                                                    DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(d("NextVisitDate")), DateHelper.GetTheMonday(d("NextVisitDate")).AddDays(dow), theRow[0].Item("count"), null/* TODO Change to default(_) if this is not a reference type */, theRow[0].Item("PM"), theRow[0].Item("ApptsMinsTally"), lps);
                                                                    ApptFound = true;
                                                                }
                                                                else
                                                                    // theRow(0).Item("ApptsMinsTally") = 0
                                                                    MaxLoops += 1;
                                                            }
                                                        }
                                                        else
                                                            MaxLoops += 1;
                                                    }

                                                    if (ApptFound)
                                                        break;
                                                }
                                            }
                                        }
                                        else if (d("Type") == "Letter 2")
                                        {
                                            DataRow[] theRow = dtLetter2AMPM.Select("Date='" + d("NextVisitDate") + "'");
                                            if (theRow.Length == 0)
                                                dtLetter2AMPM.Rows.Add(new object[] { d("NextVisitDate"), 1, 0 });
                                            else
                                                theRow[0].Item("count") += 1;
                                        }
                                        else if (d("Type") == "Letter 3")
                                        {
                                            DataRow[] theRow = dtLetter3AMPM.Select("Date='" + d("NextVisitDate") + "'");
                                            if (theRow.Length == 0)
                                                dtLetter3AMPM.Rows.Add(new object[] { d("NextVisitDate"), 1, 0 });
                                            else
                                                theRow[0].Item("count") += 1;
                                        }
                                        else
                                        {
                                        }
                                    }

                                    Word.Document WordDocCopy = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection.dot");
                                    Word.Document WordDoc2Copy = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection2.dot");
                                    Word.Document WordDoc2HandCopy = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection2HandLetter.dot");
                                    Word.Document WordDoc3Copy = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3.dot");
                                    Word.Document WordDoc3HandCopy = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3HandLetter.dot");
                                    Word.Document WordDoc3HandCopyCommercial = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3HandLetterDistrict.dot");

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
                                    DateTime theVisitDate;

                                    SqlClient.SqlTransaction trans = null/* TODO Change to default(_) if this is not a reference type */;
                                    SqlClient.SqlConnection con = null/* TODO Change to default(_) if this is not a reference type */;

                                    int Letter1_CurrentApptDay = 1; // Zero based day of week (1 = Tuesday)
                                    int Letter1_TodaysApptsLength = 0;

                                    // MAIN LOOP
                                    foreach (DataRow r in dr)
                                    {
                                        try
                                        {
                                            if (CustomerID == 5155 & (DateTime)r("LastServiceDate") < (DateTime)"2012-05-01 00:00:00")
                                                // do nothing
                                                DateTime DateHolder = (DateTime)r("LastServiceDate");
                                            else
                                            {
                                                con = new SqlClient.SqlConnection(DB.ServerConnectionString);
                                                con.Open();
                                                trans = con.BeginTransaction(IsolationLevel.ReadUncommitted);

                                                JobNumber JobNumber = new JobNumber();
                                                switch (CustomerID)
                                                {
                                                    case object _ when Enums.Customer.NCC // Norwich City Council
                                                   :
                                                        {
                                                            JobNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.SERVICE_LETTER_JOB, trans);
                                                            break;
                                                        }

                                                    default:
                                                        {
                                                            JobNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout, trans);
                                                            break;
                                                        }
                                                }

                                                if (r("type") == "Letter 1")
                                                {
                                                    WordDoc = Letter1Doc;

                                                    WordDoc.GrammarChecked = true;
                                                    WordDoc.SpellingChecked = true;

                                                    WordDocCopy.Select();
                                                    MsWordApp.Selection.WholeStory();
                                                    MsWordApp.Selection.Copy();
                                                    WordDoc.Activate();
                                                    MsWordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
                                                    MsWordApp.Selection.Paste();

                                                    DateTime VisitDateHolder = r("NextVisitDate");
                                                    string PostCodeHolder = Sys.Helper.FormatPostcode(r("Postcode"));

                                                    foreach (DataRow dDay in dtDays.Rows)
                                                    {
                                                        if (dDay("MondayDate") == DateHelper.GetTheMonday(r("NextVisitDate")) & dDay("Count") != 0)
                                                        {
                                                            theVisitDate = dDay("TheDate");
                                                            dDay("Count") -= 1;
                                                            if (dDay("AM") != 0)
                                                            {
                                                                AMPM = "AM";
                                                                dDay("AM") -= 1;
                                                                DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(r("NextVisitDate")), dDay("TheDate"), dDay("Count"), dDay("AM"), null/* TODO Change to default(_) if this is not a reference type */, dDay("ApptsMinsTally"), dDay("Loops"));
                                                            }
                                                            else
                                                            {
                                                                AMPM = "PM";
                                                                dDay("PM") -= 1;
                                                                DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(r("NextVisitDate")), dDay("TheDate"), dDay("Count"), null/* TODO Change to default(_) if this is not a reference type */, dDay("PM"), dDay("ApptsMinsTally"), dDay("Loops"));
                                                            }
                                                            break;
                                                        }
                                                    }
                                                }
                                                else if (r("Type") == "Letter 2")
                                                {
                                                    WordDoc = Letter2Doc;

                                                    WordDoc.GrammarChecked = true;
                                                    WordDoc.SpellingChecked = true;

                                                    WordDoc2Copy.Select();
                                                    MsWordApp.Selection.WholeStory();
                                                    MsWordApp.Selection.Copy();
                                                    WordDoc.Activate();
                                                    MsWordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
                                                    MsWordApp.Selection.Paste();

                                                    theVisitDate = DateHelper.CheckBankHolidaySatOrSun(r("NextVisitDate"));

                                                    DataRow[] theRow = dtLetter2AMPM.Select("Date='" + r("NextVisitDate") + "'");
                                                    if (theRow.Length > 0)
                                                    {
                                                        if (theRow[0]("AMAssigned") >= (theRow[0]("Count") / (double)2))
                                                            AMPM = "PM";
                                                        else
                                                        {
                                                            AMPM = "AM";
                                                            theRow[0]("AMAssigned") += 1;
                                                        }
                                                    }

                                                    MsWordApp.Selection.InsertBreak();
                                                }
                                                else if (r("Type") == "Letter 3")
                                                {
                                                    WordDoc = Letter3Doc;

                                                    WordDoc.GrammarChecked = true;
                                                    WordDoc.SpellingChecked = true;

                                                    WordDoc3Copy.Select();
                                                    MsWordApp.Selection.WholeStory();
                                                    MsWordApp.Selection.Copy();
                                                    WordDoc.Activate();
                                                    MsWordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
                                                    MsWordApp.Selection.Paste();

                                                    theVisitDate = DateHelper.CheckBankHolidaySatOrSun(r("NextVisitDate"));

                                                    DataRow[] theRow = dtLetter3AMPM.Select("Date='" + r("NextVisitDate") + "'");
                                                    if (theRow.Length > 0)
                                                    {
                                                        if (theRow[0]("AMAssigned") >= (theRow[0]("Count") / (double)2))
                                                            AMPM = "PM";
                                                        else
                                                        {
                                                            AMPM = "AM";
                                                            theRow[0]("AMAssigned") += 1;
                                                        }
                                                    }
                                                }

                                                success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix + JobNumber.JobNumber, DateTime.Now);

                                                if (success == true)
                                                {
                                                    Sites.Site oSite = DB.Sites.Get(r("SiteID"));

                                                    if (r("type") == "Letter 1")
                                                        Letter1Doc = WordDoc;
                                                    else if (r("Type") == "Letter 2")
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
                                                        MsWordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
                                                        MsWordApp.Selection.Paste();
                                                        success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix + JobNumber.JobNumber, DateTime.Now);
                                                        Letter2HandLetters = WordDoc;
                                                    }
                                                    else if (r("Type") == "Letter 3")
                                                    {
                                                        Letter3Doc = WordDoc;
                                                        // HAND DELIVER LETTER
                                                        WordDoc = Letter3HandLetters;

                                                        WordDoc.GrammarChecked = true;
                                                        WordDoc.SpellingChecked = true;

                                                        if (oSite.CommercialDistrict == true)
                                                            WordDoc3HandCopyCommercial.Select();
                                                        else
                                                            WordDoc3HandCopy.Select();

                                                        MsWordApp.Selection.WholeStory();
                                                        MsWordApp.Selection.Copy();
                                                        WordDoc.Activate();
                                                        MsWordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
                                                        MsWordApp.Selection.Paste();
                                                        success = GenerateServiceLetter(r, AMPM, theVisitDate, JobNumber.Prefix + JobNumber.JobNumber, DateTime.Now);
                                                        Letter3HandLetters = WordDoc;
                                                    }

                                                    if (success == true)
                                                    {
                                                        // CREATE JOB
                                                        _currentJob = new Jobs.Job();
                                                        _currentJob.SetPropertyID = r("SiteID");
                                                        _currentJob.SetJobDefinitionEnumID = System.Convert.ToInt32(Enums.JobDefinition.Callout);
                                                        _currentJob.SetJobTypeID = DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")(0).Item("ManagerID");
                                                        _currentJob.SetStatusEnumID = System.Convert.ToInt32(Enums.JobStatus.Open);
                                                        _currentJob.SetCreatedByUserID = loggedInUser.UserID;
                                                        _currentJob.SetFOC = true;

                                                        _currentJob.SetJobNumber = JobNumber.Prefix + JobNumber.JobNumber;
                                                        _currentJob.SetPONumber = "";
                                                        _currentJob.SetQuoteID = 0;
                                                        _currentJob.SetContractID = 0;

                                                        // INSERT JOB ITEM
                                                        JobOfWorks.JobOfWork jobOfWork = new JobOfWorks.JobOfWork();
                                                        jobOfWork.SetPONumber = "";
                                                        jobOfWork.SetPriority = servicePriority;
                                                        if (!jobOfWork.Priority == 0)
                                                            jobOfWork.PriorityDateSet = DateTime.Now;
                                                        jobOfWork.IgnoreExceptionsOnSetMethods = true;

                                                        DataRow[] sorRows = null;

                                                        if (r("Type") == "Letter 1")
                                                        {
                                                            if (oSite.CommercialDistrict == true)
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7008'");
                                                            else if (oSite.SolidFuel == true)
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7001'");
                                                            else
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7007'");
                                                        }
                                                        else if (r("Type") == "Letter 2")
                                                        {
                                                            if (oSite.CommercialDistrict == true)
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7008*'");
                                                            else if (oSite.SolidFuel == true)
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7001*'");
                                                            else
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7007*'");
                                                        }
                                                        else if (r("Type") == "Letter 3")
                                                        {
                                                            if (oSite.CommercialDistrict == true)
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7008^'");
                                                            else if (oSite.SolidFuel == true)
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7001^'");
                                                            else
                                                                sorRows = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table.Select("Code='EA7007^'");
                                                        }

                                                        if (sorRows.Length > 0)
                                                        {
                                                            DataRow sorRow = sorRows[0];
                                                            DataTable customerSors = DB.CustomerScheduleOfRate.Exists(sorRow("ScheduleOfRatesCategoryID"), sorRow("Description"), sorRow("Code"), CustomerID);
                                                            int customerSorId = 0;
                                                            if (customerSors.Rows.Count > 0)
                                                                customerSorId = Helper.MakeIntegerValid(customerSors(0)(0));

                                                            if (!customerSorId > 0)
                                                            {
                                                                CustomerScheduleOfRates.CustomerScheduleOfRate customerSor = new CustomerScheduleOfRates.CustomerScheduleOfRate()
                                                                {
                                                                    SetCode = sorRow("Code"),
                                                                    SetDescription = sorRow("Description"),
                                                                    SetPrice = sorRow("Price"),
                                                                    SetScheduleOfRatesCategoryID = sorRow("ScheduleOfRatesCategoryID"),
                                                                    SetTimeInMins = sorRow("TimeInMins"),
                                                                    SetCustomerID = CustomerID
                                                                };
                                                                customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                                                                DB.CustomerScheduleOfRate.Delete(customerSorId);
                                                            }

                                                            JobItems.JobItem jobItem = new JobItems.JobItem();
                                                            jobItem.IgnoreExceptionsOnSetMethods = true;
                                                            jobItem.SetSummary = sorRow("Description");
                                                            jobItem.SetQty = 1;
                                                            jobItem.SetRateID = customerSorId;
                                                            jobItem.SetSystemLinkID = System.Convert.ToInt32(Enums.TableNames.tblCustomerScheduleOfRate);
                                                            jobOfWork.JobItems.Add(jobItem);
                                                        }

                                                        EngineerVisits.EngineerVisit engineerVisit = new EngineerVisits.EngineerVisit();
                                                        engineerVisit.IgnoreExceptionsOnSetMethods = true;
                                                        engineerVisit.SetEngineerID = 0;

                                                        // set site fuel in visit notes
                                                        if ((r("SiteFuel") == DBNull.Value))
                                                            Fuel = "";
                                                        else if (r("SiteFuel") == "Gas" | r("siteFuel") == "0")
                                                            Fuel = "";
                                                        else
                                                            Fuel = r("siteFuel");

                                                        engineerVisit.SetNotesToEngineer = "(" + AMPM + ") - " + Fuel + " - Carry out safety inspection";

                                                        switch (CustomerID)
                                                        {
                                                            case object _ when Enums.Customer.NCC // Norwich City Council
                                                           :
                                                                {
                                                                    if (r("Type") == "Letter 2")
                                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Take hand delivered letter and red sticker. ";
                                                                    else if (r("Type") == "Letter 3")
                                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                                                                    if (r("Type") != "Letter 1")
                                                                        engineerVisit.SetPartsToFit = true;
                                                                    break;
                                                                }

                                                            case 5872:
                                                                {
                                                                    if (r("Type") == "Letter 2")
                                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Second Visit, Take hand delivered letter and Yellow Sticker. Service Expires: " + (DateTime)r("LastServiceDate").AddYears(1);
                                                                    else if (r("Type") == "Letter 3")
                                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape.";
                                                                    if (r("Type") != "Letter 1")
                                                                        engineerVisit.SetPartsToFit = false;
                                                                    break;
                                                                }

                                                            case 5155:
                                                                {
                                                                    DateTime ChangedDate = (DateTime)r("LastServiceDate").AddYears(1);
                                                                    ChangedDate = ChangedDate.AddDays(-7);
                                                                    ChangedDate = DateHelper.CheckBankHolidaySatOrSun(ChangedDate);

                                                                    if (r("Type") == "Letter 2")
                                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Second Visit, Take hand delivered letter and Red Sticker. Final Visit: " + ChangedDate;
                                                                    else if (r("Type") == "Letter 3")
                                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape.";
                                                                    if (r("Type") != "Letter 1")
                                                                        engineerVisit.SetPartsToFit = false;
                                                                    break;
                                                                }

                                                            default:
                                                                {
                                                                    if (r("Type") == "Letter 2")
                                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                                                                    else if (r("Type") == "Letter 3")
                                                                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                                                                    if (r("Type") != "Letter 1")
                                                                        engineerVisit.SetPartsToFit = false;
                                                                    break;
                                                                }
                                                        }

                                                        engineerVisit.StartDateTime = DateTime.MinValue;
                                                        engineerVisit.EndDateTime = DateTime.MinValue;
                                                        engineerVisit.SetStatusEnumID = System.Convert.ToInt32(Enums.VisitStatus.Ready_For_Schedule);
                                                        engineerVisit.DueDate = theVisitDate;
                                                        engineerVisit.SetAMPM = AMPM;

                                                        if (r("Type") == "Letter 1")
                                                            engineerVisit.SetVisitNumber = 1;
                                                        else if (r("Type") == "Letter 2")
                                                            engineerVisit.SetVisitNumber = 2;
                                                        else if (r("Type") == "Letter 3")
                                                            engineerVisit.SetVisitNumber = 3;

                                                        jobOfWork.EngineerVisits.Add(engineerVisit);

                                                        if (r("Type") == "Letter 3" & CustomerID != Enums.Customer.NCC)
                                                            jobOfWork.EngineerVisits.Add(engineerVisit);

                                                        _currentJob.JobOfWorks.Add(jobOfWork);
                                                        _currentJob = DB.Job.Insert(_currentJob, trans);

                                                        // RECORD JOB/LETTER CREATION
                                                        DB.LetterManager.LetterGenerated(r("SiteID"), r("Type"), r("LastServiceDate"), _currentJob.JobID, folderName, trans);

                                                        // RECORD SOLID FUELS
                                                        if (r("SolidFuel") == true)
                                                            oWriteSolidFuels.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + r("Address4") + ", " + r("Address5") + ", " + Sys.Helper.FormatPostcode(r("Postcode")));

                                                        // RECORD WARNINGS OR ADVICE
                                                        if (r("Notes").ToString.Contains("T1WARN") | r("Notes").ToString.Contains("T1ADVI") | r("Notes").ToString.Contains("T2WARN") | r("Notes").ToString.Contains("T2ADVI"))
                                                        {
                                                            oWriteWA.WriteLine(" ");
                                                            oWriteWA.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + r("Address4") + ", " + r("Address5") + ", " + Sys.Helper.FormatPostcode(r("Postcode")) + " NOTES : " + r("Notes"));
                                                        }

                                                        // RECORD VOID PROPERTIES
                                                        if (Helper.MakeBooleanValid(r("PropertyVoid")) == true)
                                                            oWriteVoids.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + r("Address4") + ", " + r("Address5") + ", " + Sys.Helper.FormatPostcode(r("Postcode")));

                                                        // RECORD NON GAS SITE FUELS
                                                        if (!r("SiteFuel") == DBNull.Value)
                                                        {
                                                            if (!r("SiteFuel") == "Gas")
                                                                oWriteSiteFuel.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + r("Address4") + ", " + r("Address5") + ", " + Sys.Helper.FormatPostcode(r("Postcode")) + ", " + r("SiteFuel"));
                                                        }
                                                    }
                                                }

                                                trans.Commit();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                            if (!trans == null)
                                                trans.Rollback();
                                            if (!con == null)
                                                con.Close();
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
                                    Letter2Doc.SaveAs(folderName + "ServiceLetters2_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");

                                    Letter3Doc.Activate();
                                    MsWordApp.Selection.WholeStory();
                                    MsWordApp.Selection.Font.Name = "Arial";
                                    Letter3Doc.SaveAs(folderName + "ServiceLetters3_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");

                                    Letter2HandLetters.Activate();
                                    MsWordApp.Selection.WholeStory();
                                    MsWordApp.Selection.Font.Name = "Arial";
                                    Letter2HandLetters.SaveAs(folderName + "ServiceLetters2HandDeliver_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");

                                    Letter3HandLetters.Activate();
                                    MsWordApp.Selection.WholeStory();
                                    MsWordApp.Selection.Font.Name = "Arial";
                                    Letter3HandLetters.SaveAs(folderName + "ServiceLetters3HandDeliver_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");

                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Letter2Doc);
                                    Letter2Doc = null/* TODO Change to default(_) if this is not a reference type */;
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDocCopy);
                                    WordDocCopy = null/* TODO Change to default(_) if this is not a reference type */;
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc2Copy);
                                    WordDoc2Copy = null/* TODO Change to default(_) if this is not a reference type */;
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc2HandCopy);
                                    WordDoc2HandCopy = null/* TODO Change to default(_) if this is not a reference type */;

                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Letter3Doc);
                                    Letter3Doc = null/* TODO Change to default(_) if this is not a reference type */;
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc3Copy);
                                    WordDoc3Copy = null/* TODO Change to default(_) if this is not a reference type */;
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc3HandCopy);
                                    WordDoc3HandCopy = null/* TODO Change to default(_) if this is not a reference type */;
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc3HandCopyCommercial);
                                    WordDoc3HandCopyCommercial = null/* TODO Change to default(_) if this is not a reference type */;

                                    WordDoc.Activate();
                                }
                                catch (Exception ex)
                                {
                                    ShowMessage("Letter Generation Failed : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                // GENERATE EXCEL REPORT
                                // GET ALL TOMORROWS LETTER 3 VISITS
                                // IS TOMORROW SAT OR SUN - THEN GET MONDAY
                                DateTime tomorrow = Strings.Format(DateTime.Now.AddDays(1), "dd-MMM-yyyy") + " 00:00:00";
                                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                                    tomorrow = Strings.Format(DateTime.Now.AddDays(3), "dd-MMM-yyyy") + " 00:00:00";
                                else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                                    tomorrow = Strings.Format(DateTime.Now.AddDays(2), "dd-MMM-yyyy") + " 00:00:00";

                                DataTable dt3rdVisitReport = DB.LetterManager.Letter3_TomorrowsVisit(tomorrow);
                                Exporting exporter = new Exporting(dt3rdVisitReport, "3rd Visits", folderName);
                                exporter = null/* TODO Change to default(_) if this is not a reference type */;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                MsWordApp.Selection.WholeStory();
                                MsWordApp.Selection.Font.Name = "Arial";
                                Finalise(filePath, success);

                                MessageFilter.Revoke();

                                if (success)
                                    Process.Start(folderName);
                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case object _ when Enums.SystemDocumentType.ServiceLettersMK2:
                        {
                            string folderName = @"C:\";

                            try
                            {
                                folderName = TheSystem.Configuration.DocumentsLocation + @"ServiceLetters\ServiceLetters" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + @"\";
                                Directory.CreateDirectory(folderName);
                                DataTable dt = (ArrayList)this.DetailsToPrint.Item(0).table;

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
                                            JustLetters = true;
                                        else
                                        {
                                            dt.Columns.Add("JobNumber");
                                            dt.Columns.Add("JobID");
                                        }

                                        int VisitTime = 0;
                                        if (dt.Select("Type = 'Letter 1' AND SendLetterTick = 1").Length > 0)
                                        {
                                            filePath = folderName + "ServiceLetters1_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".docx";

                                            List<byte[]> document = new List<byte[]>();
                                            DataRow[] dr = (from row in dt.AsEnumerable()
                                                            where row.Field<string>("Type") == "Letter 1" & row.Field<bool>("SendLetterTick") == true
                                                            select row).ToArray();
                                            foreach (DataRow r in dr)
                                            {
                                                if (Helper.MakeDateTimeValid(r("BookedDateTime")) == null/* TODO Change to default(_) if this is not a reference type */ )
                                                    continue;
                                                DateTime VisitDateHolder = r("BookedDateTime");
                                                theVisitDate = r("BookedDateTime");
                                                string fuel = "";
                                                string AMPM = Helper.MakeStringValid(r("AMPM"));
                                                int fuelId = 0;

                                                if (r.Table.Columns.Contains("FuelID") && !IsDBNull(r("FuelID")))
                                                    fuelId = Helper.MakeIntegerValid(r("FuelID"));
                                                Jobs.Job jobnumbers = new Jobs.Job();
                                                if (JustLetters == false)
                                                    jobnumbers = DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId);
                                                else
                                                {
                                                    jobnumbers.SetJobID = r("JobID");
                                                    jobnumbers.SetJobNumber = r("JobNumber");
                                                }
                                                if (!r("SiteFuel").ToString.StartsWith("&"))
                                                {
                                                    success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, DateTime.Now, document, jobnumbers.JobID, JustLetters);
                                                    if (success == true)
                                                    {
                                                        // RECORD JOB/LETTER CREATION
                                                        if (JustLetters == false)
                                                            DB.LetterManager.LetterGeneratedMK2(r("SiteID"), r("Type"), r("LastServiceDate"), jobnumbers.JobID, folderName, fuelId);

                                                        // RECORD SOLID FUELS
                                                        if (r("SolidFuel") == true)
                                                            oWriteSolidFuels.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")));
                                                        // RECORD WARNINGS OR ADVICE
                                                        if (r("Notes").ToString.Contains("T1WARN") | r("Notes").ToString.Contains("T1ADVI") | r("Notes").ToString.Contains("T2WARN") | r("Notes").ToString.Contains("T2ADVI"))
                                                        {
                                                            oWriteWA.WriteLine(" ");
                                                            oWriteWA.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")) + ", " + " NOTES : " + r("Notes"));
                                                        }
                                                        // RECORD VOID PROPERTIES
                                                        if (Helper.MakeBooleanValid(r("PropertyVoid")) == true)
                                                            oWriteVoids.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")));
                                                        // RECORD NON GAS SITE FUELS
                                                        if (!r("SiteFuel") == DBNull.Value)
                                                        {
                                                            if (!r("SiteFuel") == "Gas")
                                                                oWriteSiteFuel.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")) + ", " + r("SiteFuel"));
                                                        }
                                                    }
                                                }
                                            }

                                            if (document.Count > 0)
                                                File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document));
                                        }

                                        if (dt.Select("Type = 'Letter 2' AND SendLetterTick = 1").Length > 0)
                                        {
                                            filePath = folderName + "ServiceLetters2_" + Strings.Format(DateTime.Now, "ddMMyyHHmmss") + ".docx";
                                            List<byte[]> document = new List<byte[]>();
                                            DataRow[] dr = (from row in dt.AsEnumerable()
                                                            where row.Field<string>("Type") == "Letter 2" & row.Field<bool>("SendLetterTick") == true
                                                            select row).ToArray();
                                            foreach (DataRow r in dr)
                                            {
                                                if (Helper.MakeDateTimeValid(r("BookedDateTime")) == null/* TODO Change to default(_) if this is not a reference type */ )
                                                    continue;
                                                DateTime VisitDateHolder = r("BookedDateTime");
                                                theVisitDate = r("BookedDateTime");
                                                string fuel = "";
                                                string AMPM = r("AMPM");
                                                int fuelId = 0;
                                                if (r.Table.Columns.Contains("FuelID") && !IsDBNull(r("FuelID")))
                                                    fuelId = Helper.MakeIntegerValid(r("FuelID"));
                                                Jobs.Job jobnumbers = new Jobs.Job();
                                                if (JustLetters == false)
                                                {
                                                    jobnumbers = DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId);
                                                    r("JobNumber") = jobnumbers.JobNumber;
                                                    r("JobID") = jobnumbers.JobID;
                                                }
                                                else
                                                {
                                                    jobnumbers.SetJobID = r("JobID");
                                                    jobnumbers.SetJobNumber = r("JobNumber");
                                                }

                                                if (!r("SiteFuel").ToString.StartsWith("&"))
                                                {
                                                    success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, DateTime.Now, document, jobnumbers.JobID, JustLetters);

                                                    if (success == true)
                                                    {
                                                        // RECORD JOB/LETTER CREATION
                                                        if (JustLetters == false)
                                                            DB.LetterManager.LetterGeneratedMK2(r("SiteID"), r("Type"), r("LastServiceDate"), jobnumbers.JobID, folderName, fuelId);

                                                        // RECORD SOLID FUELS
                                                        if (r("SolidFuel") == true)
                                                            oWriteSolidFuels.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")));
                                                        // RECORD WARNINGS OR ADVICE
                                                        if (r("Notes").ToString.Contains("T1WARN") | r("Notes").ToString.Contains("T1ADVI") | r("Notes").ToString.Contains("T2WARN") | r("Notes").ToString.Contains("T2ADVI"))
                                                        {
                                                            oWriteWA.WriteLine(" ");
                                                            oWriteWA.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")) + ", " + " NOTES : " + r("Notes"));
                                                        }
                                                        // RECORD VOID PROPERTIES
                                                        if (Helper.MakeBooleanValid(r("PropertyVoid")) == true)
                                                            oWriteVoids.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")));
                                                        // RECORD NON GAS SITE FUELS
                                                        if (!r("SiteFuel") == DBNull.Value)
                                                        {
                                                            if (!r("SiteFuel") == "Gas")
                                                                oWriteSiteFuel.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")) + ", " + r("SiteFuel"));
                                                        }
                                                    }
                                                }
                                            }
                                            if (document.Count > 0)
                                                File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document));
                                        }

                                        if (dt.Select("Type = 'Letter 3' AND SendLetterTick = 1").Length > 0)
                                        {
                                            filePath = folderName + "ServiceLetters3_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".docx";
                                            List<byte[]> document = new List<byte[]>();
                                            DataRow[] dr = (from row in dt.AsEnumerable()
                                                            where row.Field<string>("Type") == "Letter 3" & row.Field<bool>("SendLetterTick") == true
                                                            select row).ToArray();

                                            foreach (DataRow r in dr)
                                            {
                                                if (Helper.MakeDateTimeValid(r("BookedDateTime")) == null/* TODO Change to default(_) if this is not a reference type */ )
                                                    continue;

                                                DateTime VisitDateHolder = r("BookedDateTime");
                                                if (r("CustomerID") == Enums.Customer.NCC)
                                                    theVisitDate = r("BookedDateTime");
                                                else
                                                    theVisitDate = r("BookedDateTime");

                                                string fuel = "";
                                                int fuelId = 0;
                                                if (r.Table.Columns.Contains("FuelID") && !IsDBNull(r("FuelID")))
                                                    fuelId = Helper.MakeIntegerValid(r("FuelID"));
                                                string AMPM = r("AMPM");
                                                Jobs.Job jobnumbers = new Jobs.Job();
                                                if (JustLetters == false)
                                                {
                                                    jobnumbers = DB.Job.GenerateServiceLetterJob(r, CustomerID, AMPM, fuelId);

                                                    r("JobNumber") = jobnumbers.JobNumber;
                                                    r("JobID") = jobnumbers.JobID;
                                                }
                                                else
                                                {
                                                    jobnumbers.SetJobID = r("JobID");
                                                    jobnumbers.SetJobNumber = r("JobNumber");
                                                }

                                                if (!r("SiteFuel").ToString.StartsWith("&"))
                                                {
                                                    success = GenerateServiceLetterMK2(r, AMPM, theVisitDate, jobnumbers.JobNumber, DateTime.Now, document, jobnumbers.JobID, JustLetters);

                                                    if (success == true)
                                                    {
                                                        // RECORD JOB/LETTER CREATION
                                                        if (JustLetters == false)
                                                            DB.LetterManager.LetterGeneratedMK2(r("SiteID"), r("Type"), r("LastServiceDate"), jobnumbers.JobID, folderName, fuelId);

                                                        // RECORD SOLID FUELS
                                                        if (r("SolidFuel") == true)
                                                            oWriteSolidFuels.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")));
                                                        // RECORD WARNINGS OR ADVICE
                                                        if (r("Notes").ToString.Contains("T1WARN") | r("Notes").ToString.Contains("T1ADVI") | r("Notes").ToString.Contains("T2WARN") | r("Notes").ToString.Contains("T2ADVI"))
                                                        {
                                                            oWriteWA.WriteLine(" ");
                                                            oWriteWA.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")) + " NOTES : " + r("Notes"));
                                                        }
                                                        // RECORD VOID PROPERTIES
                                                        if (Helper.MakeBooleanValid(r("PropertyVoid")) == true)
                                                            oWriteVoids.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")));
                                                        // RECORD NON GAS SITE FUELS
                                                        if (!r("SiteFuel") == DBNull.Value)
                                                        {
                                                            if (!r("SiteFuel") == "Gas")
                                                                oWriteSiteFuel.WriteLine(r("Name") + ", " + r("Address1") + ", " + r("Address2") + ", " + r("Address3") + ", " + Sys.Helper.FormatPostcode(r("Postcode")) + ", " + r("SiteFuel"));
                                                        }
                                                    }
                                                }
                                            }

                                            if (document.Count > 0)
                                                File.WriteAllBytes(filePath, PrintHelper.CombineDocs(document));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    oWriteSolidFuels.Close();
                                    oWriteWA.Close();
                                    oWriteVoids.Close();
                                    oWriteSiteFuel.Close();
                                }
                                catch (Exception ex)
                                {
                                    ShowMessage("Letter Generation Failed : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                // GENERATE EXCEL REPORT
                                // GET ALL TOMORROWS LETTER 3 VISITS
                                // IS TOMORROW SAT OR SUN - THEN GET MONDAY
                                DateTime tomorrow = Strings.Format(DateTime.Now.AddDays(1), "dd-MMM-yyyy") + " 00:00:00";
                                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                                    tomorrow = Strings.Format(DateTime.Now.AddDays(3), "dd-MMM-yyyy") + " 00:00:00";
                                else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                                    tomorrow = Strings.Format(DateTime.Now.AddDays(2), "dd-MMM-yyyy") + " 00:00:00";

                                DataTable dt3rdVisitReport = DB.LetterManager.Letter3_TomorrowsVisit(tomorrow);
                                Exporting exporter = new Exporting(dt3rdVisitReport, "3rd Visits", folderName);
                                exporter = null/* TODO Change to default(_) if this is not a reference type */;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);

                                MessageFilter.Revoke();

                                if (success)
                                    Process.Start(folderName);
                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case object _ when Enums.SystemDocumentType.ServiceLetterReport:
                        {
                            string folderName = @"C:\";

                            try
                            {
                                MsWordApp = new Word.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;

                                DataTable dt = (ArrayList)this.DetailsToPrint.Item(0);

                                folderName = TheSystem.Configuration.DocumentsLocation + @"ServiceLetters\ServiceLetters" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + @"\";
                                if (System.IO.Directory.Exists(folderName) == false)
                                    System.IO.Directory.CreateDirectory(folderName);

                                string SiteName = dt.Rows(0).Item("Name");

                                filePath = folderName + SiteName + "ServiceLetters_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc";

                                DataRow[] dr;
                                DataRow r;

                                // Print Letter 1
                                dr = dt.Select("LetterType ='Letter 1'");
                                if (dr.Length > 0)
                                {
                                    r = dr[0];
                                    switch (CustomerID)
                                    {
                                        case 2846 // NCC
                                       :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection.dot");
                                                break;
                                            }

                                        case 5155 // Waveney
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\WDCAnnualSafetyInspection.dot");
                                                break;
                                            }

                                        case 4703 // Suffolk Housing
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\SuffolkAnnualSafetyInspection.dot");
                                                break;
                                            }

                                        case 5545 // Cambridge Housing Society
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\CHS_AnnualSafetyInspection.dot");
                                                break;
                                            }

                                        case 5385 // Kier
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\KierAnnualSafetyInspection.dot");
                                                break;
                                            }

                                        case 5853 // Hastoe
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection.dot");
                                                break;
                                            }

                                        case 6341 // Hastoe 2
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspectionGBS.dot");
                                                break;
                                            }

                                        case 5872 // Victory
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\VHTAnnualSafetyInspection.dot");
                                                break;
                                            }

                                        case 6526 // TEN
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\TENAnnualSafetyInspection1.dot");
                                                break;
                                            }

                                        case 6561 // TEN
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\SAFAnnualSafetyInspection1.dot");
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    if (GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        WordDoc.SaveAs(folderName + "ServiceLetter1_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");
                                    }
                                }

                                // Print Letter 2
                                dr = dt.Select("LetterType ='Letter 2'");
                                if (dr.Length > 0)
                                {
                                    r = dr[0];
                                    switch (CustomerID)
                                    {
                                        case 2846 // NCC
                                       :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        case 5155 // Waveney
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\WDCAnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        case 4703 // Suffolk Housing
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\SuffolkAnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        case 5545 // Cambridge Housing Society
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\CHS_AnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        case 5385 // Kier
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\KierAnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        case 5853 // Hastoe
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        case 6341 // Hastoe
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection2GBS.dot");
                                                break;
                                            }

                                        case 5872 // Victory
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\VHTAnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        case 6526 // TEN
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\TENAnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        case 6561 // SAF
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\SAFAnnualSafetyInspection2.dot");
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    if (GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        WordDoc.SaveAs(folderName + "ServiceLetter2_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");
                                    }

                                    switch (CustomerID)
                                    {
                                        case 2846 // NCC
                                       :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection2HandLetter.dot");
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    if (GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        WordDoc.SaveAs(folderName + "ServiceLetter2Hand_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");
                                    }
                                }

                                // Print Letter 3
                                dr = dt.Select("LetterType ='Letter 3'");
                                if (dr.Length > 0)
                                {
                                    r = dr[0];
                                    switch (CustomerID)
                                    {
                                        case 2846 // NCC
                                       :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3.dot");
                                                break;
                                            }

                                        case 5155 // Waveney
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\WDCAnnualSafetyInspection3.dot");
                                                break;
                                            }

                                        case 5385 // Kier
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\KierAnnualSafetyInspection3.dot");
                                                break;
                                            }

                                        case 5853 // Hastoe
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection3.dot");
                                                break;
                                            }

                                        case 6341 // Hastoe
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\HastoeAnnualSafetyInspection3.dot");
                                                break;
                                            }

                                        case 5872 // Victory
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\VHTAnnualSafetyInspection3.dot");
                                                break;
                                            }

                                        case 6526 // TEN
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\TENAnnualSafetyInspection3.dot");
                                                break;
                                            }

                                        case 6561 // SAF
                                 :
                                            {
                                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\SAFAnnualSafetyInspection3.dot");
                                                break;
                                            }

                                        default:
                                            {
                                                break;
                                            }
                                    }

                                    if (GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        WordDoc.SaveAs(folderName + "ServiceLetter3_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");
                                    }

                                    if (r("CommercialDistrict") == true)
                                    {
                                        switch (CustomerID)
                                        {
                                            case 2846 // NCC
                                           :
                                                {
                                                    WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3HandLetterDistrict.dot");
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                        switch (CustomerID)
                                        {
                                            case 2846 // NCC
                                           :
                                                {
                                                    WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\NCCAnnualSafetyInspection3HandLetter.dot");
                                                    break;
                                                }

                                            default:
                                                {
                                                    break;
                                                }
                                        }

                                    if (GenerateServiceLetter(r, r("AMPM"), r("DueDate"), r("JobNumber"), r("DateCreated")))
                                    {
                                        MsWordApp.Selection.WholeStory();
                                        MsWordApp.Selection.Font.Name = "Arial";
                                        WordDoc.SaveAs(folderName + "ServiceLetter3Hand_" + Strings.Format(DateTime.Now, "ddMMyyHHmm") + ".doc");
                                    }
                                }

                                System.IO.StreamWriter oWriteSolidFuels;
                                oWriteSolidFuels = System.IO.File.CreateText(folderName + "Summary.txt");
                                oWriteSolidFuels.WriteLine("Letter Type" + Constants.vbTab + Constants.vbTab + "Letter Created" + Constants.vbTab + Constants.vbTab + Constants.vbTab + "Due Date" + Constants.vbTab + Constants.vbTab + "AM/PM" + Constants.vbTab + Constants.vbTab + "Job Number");
                                foreach (DataRow drS in dt.Rows)
                                    oWriteSolidFuels.WriteLine(drS("LetterType") + Constants.vbTab + Constants.vbTab + drS("DateCreated") + Constants.vbTab + Constants.vbTab + drS("DueDate") + Constants.vbTab + Constants.vbTab + drS("AMPM") + Constants.vbTab + Constants.vbTab + drS("JobNumber"));

                                oWriteSolidFuels.Close();

                                success = true;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                DestroyWord(true);
                                if (success)
                                    Process.Start(folderName);
                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case object _ when Enums.SystemDocumentType.GSRDue:
                        {
                            try
                            {
                                DataTable dtPrinted = new DataTable();
                                dtPrinted.Columns.Add("AssetID");
                                dtPrinted.Columns.Add("DateDue");

                                FRMLastGSRReport fLastGSRReport = (ArrayList)this.DetailsToPrint.Item(1);
                                fLastGSRReport.MoveProgressOn();

                                DataView dv = (ArrayList)this.DetailsToPrint.Item(0);
                                filePath = TheSystem.Configuration.DocumentsLocation + "GSRDueLettersCreated" + Strings.Format(DateTime.Now, "ddMMyyHHmmff") + ".docx";
                                System.IO.File.Copy(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\BlankNp.docx", filePath);
                                WordprocessingDocument batch = WordprocessingDocument.Open(filePath, true);
                                using ((batch))
                                {
                                    DataTable domesticSitesAdded = new DataTable();
                                    domesticSitesAdded.Columns.Add("SiteID", System.Type.GetType("System.Int32"));
                                    domesticSitesAdded.Columns.Add("DueDate", System.Type.GetType("System.DateTime"));

                                    DataTable nonDomesticCustomersAdded = new DataTable();
                                    nonDomesticCustomersAdded.Columns.Add("CustomerID");

                                    foreach (DataRowView dr in dv)
                                    {
                                        if (dr("CustomerID") == Enums.Customer.Domestic)
                                        {
                                            DataRow[] domSel = domesticSitesAdded.Select("DueDate='" + Helper.MakeDateTimeValid(dr("DueDate")) + "' AND SiteID =" + Helper.MakeIntegerValid(dr("siteID")));
                                            if (domSel.Length == 0)
                                            {
                                                DataRow[] selSites;
                                                selSites = dv.Table.Select("SiteID =" + dr("siteID") + " AND DueDate='" + dr("DueDate") + "'");
                                                string tFilePath = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblSite) + @"\" + dr("SiteID") + @"\ServiceReminders";
                                                Directory.CreateDirectory(tFilePath);
                                                tFilePath += @"\ServiceReminder_" + Helper.MakeDateTimeValid(dr("DueDate")).ToLongDateString + ".docx";
                                                success = GenerateDomesticGSRDue(selSites, dtPrinted, tFilePath, batch);
                                                if (success == true)
                                                {
                                                    if (Helper.MakeBooleanValid(dr("Email")) & Helper.IsEmailValid(Helper.MakeStringValid(dr("EmailAddress"))))
                                                    {
                                                        Emails email = new Emails();
                                                        email.To = dr("EmailAddress");
                                                        email.BCC = EmailAddress.Coverplan;
                                                        email.From = EmailAddress.Enquiries;
                                                        email.Subject = "Appliance Service Reminder";
                                                        email.Body = "Dear Tenant, <br/><br/>" + Constants.vbCrLf + Constants.vbCrLf;
                                                        email.Body += "Please find your service reminder attached.<br/><br/>" + Constants.vbCrLf + Constants.vbCrLf;
                                                        email.Body += "Kind regards," + "<br/><br/>";
                                                        email.Body += TheSystem.Configuration.CompanyName;
                                                        email.Attachments.Add(tFilePath);
                                                        email.SendMe = true;
                                                        email.Send();
                                                    }
                                                }
                                                DataRow domr = null/* TODO Change to default(_) if this is not a reference type */;
                                                domr = domesticSitesAdded.NewRow;
                                                domr("SiteID") = dr("siteID");
                                                domr("DueDate") = Helper.MakeDateTimeValid(dr("DueDate"));
                                                domesticSitesAdded.Rows.Add(domr);
                                                domesticSitesAdded.AcceptChanges();
                                            }
                                            fLastGSRReport.MoveProgressOn();
                                        }
                                    }

                                    foreach (DataRowView dr in dv)
                                    {
                                        if (!dr("CustomerID") == Enums.Customer.Domestic)
                                        {
                                            if (nonDomesticCustomersAdded.Select("CustomerID=" + dr("CustomerID")).Length == 0)
                                            {
                                                DataRow[] selCust;
                                                selCust = dv.Table.Select("CustomerID=" + dr("CustomerID"));
                                                string tFilePath = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblSite) + @"\" + dr("SiteID") + @"\ServiceReminders";
                                                Directory.CreateDirectory(tFilePath);
                                                tFilePath += @"\ServiceReminder.docx";
                                                success = GenerateLLGSRDue(selCust, dtPrinted, tFilePath, batch);
                                                if (success == true)
                                                {
                                                    if (Helper.MakeBooleanValid(dr("Email")) & Helper.IsEmailValid(Helper.MakeStringValid(dr("EmailAddress"))))
                                                    {
                                                        Emails email = new Emails();
                                                        email.To = dr("EmailAddress");
                                                        email.BCC = EmailAddress.Coverplan;
                                                        email.From = EmailAddress.Enquiries;
                                                        email.Subject = "Appliance Service Reminder";
                                                        email.Body = "Dear Tenant, <br/><br/>" + Constants.vbCrLf + Constants.vbCrLf;
                                                        email.Body += "Please find your service reminder attached.<br/><br/>" + Constants.vbCrLf + Constants.vbCrLf;
                                                        email.Body += "Kind regards," + "<br/><br/>";
                                                        email.Body += TheSystem.Configuration.CompanyName;
                                                        email.Attachments.Add(tFilePath);
                                                        email.SendMe = true;
                                                        email.Send();
                                                    }
                                                }
                                                DataRow r;
                                                r = nonDomesticCustomersAdded.NewRow;
                                                r("CustomerID") = dr("CustomerID");
                                                nonDomesticCustomersAdded.Rows.Add(r);
                                            }
                                            fLastGSRReport.MoveProgressOn();
                                        }
                                    }
                                    foreach (DataRow pr in dtPrinted.Rows)
                                        DB.EngineerVisitAssetWorkSheet.PrintedGSRLettersInsert(pr("AssetID"), pr("DateDue"));
                                }
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success);
                                if (success)
                                    Process.Start(filePath);
                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case object _ when Enums.SystemDocumentType.ContractExpiry:
                        {
                            try
                            {
                                FRMContractManager fCMngr = (ArrayList)this.DetailsToPrint.Item(1);

                                MsWordApp = new Word.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;

                                fCMngr.MoveProgressOn();

                                DataTable dt = (ArrayList)this.DetailsToPrint.Item(0);
                                if (System.IO.Directory.Exists(TheSystem.Configuration.DocumentsLocation + "ContractExpiryLetters") == false)
                                    System.IO.Directory.CreateDirectory(TheSystem.Configuration.DocumentsLocation + "ContractExpiryLetters");
                                fCMngr.MoveProgressOn();

                                filePath = TheSystem.Configuration.DocumentsLocation + @"ContractExpiryLetters\" + DocumentName + Strings.Format(DateTime.Now, "dd-MM-yyyy HHmm") + ".doc"; // "_" & dr("ContractReference") & ".doc"
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ContractExpiry.dot");
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
                                        MsWordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
                                        MsWordApp.Selection.InsertBreak(Type: Word.WdBreakType.wdPageBreak);
                                        MsWordApp.Selection.Paste();
                                    }
                                    fCMngr.MoveProgressOn();
                                }
                                WordDoc.SaveAs((object)filePath);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc);
                                WordDoc = null/* TODO Change to default(_) if this is not a reference type */;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    case object _ when Enums.SystemDocumentType.Invoice:
                        {
                            ArrayList details = new ArrayList();
                            details = (ArrayList)this.DetailsToPrint;
                            ArrayList arLst = new ArrayList();
                            arLst = (ArrayList)details.Item(0);

                            if (details.Count > 1)
                            {
                                details1 = System.Convert.ToString(details.Item(1));
                                details2 = System.Convert.ToString(details.Item(2));
                            }

                            ArrayList invoices = new ArrayList();

                            foreach (ArrayList InvoiceID in arLst)
                            {
                                try
                                {
                                    Invoiceds.Invoiced oInvoice = DB.Invoiced.Invoiced_Get(InvoiceID(0));
                                    if (oInvoice.PaidByID > 0)
                                        details2 = DB.Picklists.Get_One_As_Object(oInvoice.PaidByID)?.Name;
                                    if (oInvoice.AdhocInvoiceType != "")
                                        details1 = oInvoice.AdhocInvoiceType;

                                    filePath = TheSystem.Configuration.DocumentsLocation + DocumentName + "_" + oInvoice.InvoiceNumber + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                                    File.Copy(Application.StartupPath + @"\Templates\Blank.docx", filePath);
                                    Cursor.Current = Cursors.WaitCursor;

                                    WordprocessingDocument batch = WordprocessingDocument.Open(filePath, true);
                                    using (batch)
                                    {
                                        DataTable dtInvoicedLines = DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(InvoiceID(0)).Table;
                                        DataTable ContractsDT = DB.ContractOriginal.Get_NotProcessed(dtInvoicedLines.Rows(0)("ContractID")).Table;
                                        ContractsDT.Columns.Add("InvoiceNumber");

                                        if (ContractsDT.Rows.Count > 0 && ContractsDT.Rows(0)("InitialPaymentType").ToString.Length > 1)
                                        {
                                            ContractsDT.Rows(0)("InvoiceNumber") = oInvoice.InvoiceNumber;
                                            if (!IsDBNull(ContractsDT.Rows(0)("InvoiceNumber")))
                                            {
                                                if (IsDBNull(ContractsDT.Rows(0)("InitialPaymentType")) || ContractsDT.Rows(0)("InitialPaymentType") != "Invoice" || (details1 == "DDRECEIPT"))
                                                    success = GenerateReceipt(ContractsDT.Rows(0), batch, ContractsDT.Rows(0)("RegionID") == Enums.Region.GaswayCommercial, false);
                                                else
                                                    success = GenerateContractInvoice(ContractsDT.Rows(0), batch, ContractsDT.Rows(0)("RegionID") == Enums.Region.GaswayCommercial, false);
                                            }
                                        }
                                        else
                                            success = GenerateSalesInvoice(oInvoice, batch, InvoiceID(1) == Enums.Region.GaswayCommercial);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    success = false;
                                    ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                finally
                                {
                                    if (IsRFT)
                                        filePath = filePath.ToLower().Replace(".doc", ".pdf");

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

                    case object _ when Enums.SystemDocumentType.SupplierPurchaseOrder:
                        {
                            ArrayList details = (ArrayList)this.DetailsToPrint;
                            Sites.Site oSite = null/* TODO Change to default(_) if this is not a reference type */;
                            Warehouses.Warehouse oWarehouse = null/* TODO Change to default(_) if this is not a reference type */;
                            Users.User oUser = (Users.User)details.Item(4);
                            DataView oAdditionalCharges = (DataView)details.Item(7);
                            bool isPdf = (DialogResult)details.Item(8) == DialogResult.Yes ? true : false;
                            DataSet ds = (DataSet)details.Item(0);

                            if (!details.Item(3) == null)
                                oWarehouse = (Warehouses.Warehouse)details.Item(3);

                            if (details.Item(1) == "Site")
                            {
                                oSite = (Sites.Site)details.Item(2);
                                oWarehouse = null/* TODO Change to default(_) if this is not a reference type */;
                            }
                            else if (details.Item(1) == "Warehouse")
                            {
                                oSite = null/* TODO Change to default(_) if this is not a reference type */;
                                oWarehouse = (Warehouses.Warehouse)details.Item(2);
                            }
                            else if (details.Item(1) == "Van")
                            {
                                oSite = null/* TODO Change to default(_) if this is not a reference type */;
                                if (details.Item(2) == null)
                                    oWarehouse = null/* TODO Change to default(_) if this is not a reference type */;
                                else
                                    oWarehouse = (Warehouses.Warehouse)details.Item(2);
                            }

                            foreach (DataTable dt in ds.Tables)
                            {
                                try
                                {
                                    Suppliers.Supplier oSupplier = DB.Supplier.Supplier_Get(dt.Rows(0).Item("SupplierID"));
                                    filePath = TheSystem.Configuration.DocumentsLocation + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + Helper.MakeFileNameValid(oSupplier.Name) + ".docx";
                                    Cursor.Current = Cursors.WaitCursor;
                                    success = GeneratePurchaseOrder(oSite, oWarehouse, dt, oSupplier, oUser, Helper.MakeStringValid(details.Item(5)), Helper.MakeDateTimeValid(details.Item(6)), oAdditionalCharges, filePath, isPdf);
                                }
                                catch (Exception ex)
                                {
                                    success = false;
                                    ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    case object _ when Enums.SystemDocumentType.ContractOption1:
                        {
                            try
                            {
                                FolderBrowserDialog folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();

                                if (folderToSaveTo.SelectedPath.Trim.Length == 0)
                                    return;
                                Cursor.Current = Cursors.WaitCursor;

                                filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                                System.IO.File.Copy(Application.StartupPath + @"\Templates\Blank.docx", filePath);

                                WordprocessingDocument batch = WordprocessingDocument.Open(filePath, true);
                                using ((batch))
                                    foreach (int contractId in (List<int>)DetailsToPrint)
                                    {
                                        DataTable dtContracts = DB.ContractOriginal.ProcessContract(contractId);
                                        if (dtContracts == null)
                                            continue;
                                        DataRow dr = dtContracts.Rows(0);
                                        success = GenerateContractLetter(dr, batch);
                                    }
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (success)
                                    Process.Start(filePath);
                                Cursor.Current = Cursors.Default;
                            }

                            break;
                        }

                    case object _ when Enums.SystemDocumentType.PartCredit:
                        {
                            try
                            {
                                ArrayList details = new ArrayList();
                                details = (ArrayList)this.DetailsToPrint;

                                FolderBrowserDialog folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();

                                if (folderToSaveTo.SelectedPath.Trim.Length == 0)
                                    return;
                                else
                                    filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".doc";

                                MsWordApp = new Word.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;

                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\CREDIT.dot");
                                MsWordApp.Selection.WholeStory();
                                MsWordApp.Selection.Copy();

                                int i = 1;
                                int tblIndex = 0;
                                DataTable dt = new DataTable();
                                DataTable detailsdt = new DataTable();
                                for (int h = 0; h <= details.Count - 1; h++)
                                {
                                    // Dim ds As New DataSet
                                    if (h == 0)
                                        dt = details.Item(0);
                                    else
                                    {
                                        detailsdt = details.Item(h);
                                        dt.ImportRow(detailsdt.Rows(0));
                                    }
                                }

                                DetailsToPrint = dt; // ds.Tables(0)
                                success = Credit();

                                WordDoc.SaveAs((object)filePath);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc);
                                WordDoc = null/* TODO Change to default(_) if this is not a reference type */;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    case object _ when Enums.SystemDocumentType.ProForma:
                        {
                            ArrayList details = new ArrayList();
                            details = (ArrayList)this.DetailsToPrint;

                            Jobs.Job job = new Jobs.Job();
                            ContractsOriginal.ContractOriginal Contract;
                            ContractOriginalSites.ContractOriginalSite cos = new ContractOriginalSites.ContractOriginalSite();
                            ArrayList invoices = new ArrayList();
                            MsWordApp = new Word.Application();
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                            MsWordApp.Visible = false;

                            if (details.Item(0) == "JOB")
                            {
                                job = (Jobs.Job)details.Item(1);
                                details1 = System.Convert.ToString(details.Item(2));
                                details2 = System.Convert.ToString(details.Item(3));
                                filePath = TheSystem.Configuration.DocumentsLocation + DocumentName + "_" + job.JobNumber + ".doc";
                                Cursor.Current = Cursors.WaitCursor;
                                Customers.Customer Customer = DB.Customer.Customer_Get_ForSiteID(job.PropertyID); // get the customer to check region
                                if (Customer.RegionID == Enums.Region.GaswayCommercial)
                                    WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\InvoiceGC.dot"); // use Standard GC Invoice Template
                                else
                                    WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\Invoice.dot");// use Standard Invoice Template
                            }
                            else if (details.Item(0) == "CONTRACT")
                            {
                                cos = (ContractOriginalSites.ContractOriginalSite)details.Item(1);
                                Contract = DB.ContractOriginal.Get(cos.ContractID);
                                details1 = System.Convert.ToString(details.Item(2));
                                details2 = System.Convert.ToString(details.Item(3));
                                filePath = TheSystem.Configuration.DocumentsLocation + DocumentName + "_" + Contract.ContractReference + ".doc";
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\Invoice.dot"); // use Standard Invoice Template
                            }

                            try
                            {
                                success = GenerateProforma(job, cos);
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    case object _ when Enums.SystemDocumentType.ProFormaFromVisit:
                        {
                            ArrayList details = new ArrayList();
                            details = (ArrayList)this.DetailsToPrint;
                            Jobs.Job job = new Jobs.Job();
                            ArrayList invoices = new ArrayList();
                            MsWordApp = new Word.Application();
                            MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                            MsWordApp.Visible = false;
                            if (details.Item(0) == "JOB")
                            {
                                job = (Jobs.Job)details.Item(1);      // Job Entity
                                details1 = System.Convert.ToString(details.Item(2));   // Money
                                details2 = System.Convert.ToString(details.Item(3));   // VAT
                                filePath = TheSystem.Configuration.DocumentsLocation + DocumentName + "_" + job.JobNumber + ".doc"; // name doc
                                Customers.Customer Customer = DB.Customer.Customer_Get_ForSiteID(job.PropertyID); // get the customer to check region
                                if (Customer.RegionID == Enums.Region.GaswayCommercial)
                                    WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\InvoiceGC.dot"); // use Standard GC Invoice Template
                                else
                                    WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\Invoice.dot");// use Standard Invoice Template
                            }

                            try
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                success = GenerateProformaFromVisit(job); // Use FromVisit Function
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                Finalise(filePath, success, true, false);
                                invoices.Add(filePath);
                                Cursor.Current = Cursors.Default;
                            }
                            Finalise("", false, false, true);
                            foreach (string i in invoices)
                                Process.Start(i);// open Word
                            break;
                        }

                    case object _ when Enums.SystemDocumentType.AlphaPartCredit:
                        {
                            try
                            {
                                ArrayList details = new ArrayList();
                                details = (ArrayList)this.DetailsToPrint;

                                FolderBrowserDialog folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();

                                if (folderToSaveTo.SelectedPath.Trim.Length == 0)
                                    return;
                                else
                                    filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".doc";

                                MsWordApp = new Word.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;

                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\AlphaReturnsForm.dot");
                                MsWordApp.Selection.WholeStory();
                                MsWordApp.Selection.Copy();

                                int i = 1;
                                int tblIndex = 0;
                                DataTable dt = new DataTable();
                                DataTable detailsdt = new DataTable();
                                for (int h = 0; h <= details.Count - 1; h++)
                                {
                                    // Dim ds As New DataSet
                                    if (h == 0)
                                        dt = details.Item(0);
                                    else
                                    {
                                        detailsdt = details.Item(h);
                                        dt.ImportRow(detailsdt.Rows(0));
                                    }
                                }

                                DetailsToPrint = dt; // ds.Tables(0)
                                success = AlphaCredit();

                                WordDoc.SaveAs((object)filePath);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc);
                                WordDoc = null/* TODO Change to default(_) if this is not a reference type */;
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    case object _ when Enums.SystemDocumentType.JobImportLetters:
                        {
                            try
                            {
                                FolderBrowserDialog folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();

                                if (folderToSaveTo.SelectedPath.Trim.Length == 0)
                                    return;
                                filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                                File.Copy(Application.StartupPath + @"\Templates\BlankNp.docx", filePath);

                                DataTable dt = (ArrayList)this.DetailsToPrint.Item(0).table;
                                bool scheduleJobs = (ArrayList)this.DetailsToPrint.Item(1);

                                WordprocessingDocument batch = WordprocessingDocument.Open(filePath, true);
                                using ((batch))
                                {
                                    foreach (DataRow r in dt.Select("Letter1 Is Null AND Tick = 1"))
                                    {
                                        if (IsDBNull(r("AMPM")) & scheduleJobs)
                                            continue;
                                        Jobs.Job job = new Jobs.Job();
                                        job = DB.Job.CreateJobImportAdHocVisit(r, scheduleJobs);

                                        if (!scheduleJobs)
                                            continue;
                                        if (job == null)
                                            throw new Exception();
                                        success = GenerateJobLetter(r, job, true, batch);
                                        if (!success)
                                            throw new Exception();
                                        // mark letter as completed in db
                                        success = DB.JobImports.JobImport_Update_Letter1(r, job);
                                    }
                                    foreach (DataRow r in dt.Select("Letter1 Is Not Null AND Letter2 Is Null AND Tick = 1"))
                                    {
                                        if (IsDBNull(r("AMPM")) & scheduleJobs)
                                            continue;
                                        Jobs.Job job = new Jobs.Job();
                                        job = DB.Job.CreateJobImportAdHocVisit(r, scheduleJobs);

                                        if (!scheduleJobs)
                                            continue;
                                        if (job == null)
                                            throw new Exception();
                                        success = GenerateJobLetter(r, job, false, batch);
                                        if (!success)
                                            throw new Exception();
                                        success = DB.JobImports.JobImport_Update_Letter2(r, job);
                                    }
                                }
                                string batchFilePath = TheSystem.Configuration.DocumentsLocation + @"JobImports\BatchLetters\" + DocumentName + "_GEN_" + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                                File.Copy(filePath, batchFilePath);
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    case object _ when Enums.SystemDocumentType.SalesCredit:
                        {
                            try
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                filePath = TheSystem.Configuration.DocumentsLocation + @"\Sales Credits\" + DocumentName + "_" + (DataTable)DetailsToPrint.Rows(0)("InvoiceNumber").ToString + ".docx";
                                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                                filePath = FileCheck(filePath);
                                success = GenerateCredit((DataTable)DetailsToPrint, filePath);
                                PrintHelper.RemoveSpacingInDoc(filePath);
                            }
                            catch (Exception ex)
                            {
                                success = false;
                                ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    switch (PrintType)
                    {
                        case object _ when Enums.SystemDocumentType.DomGSR:
                        case object _ when Enums.SystemDocumentType.GSR:
                        case object _ when Enums.SystemDocumentType.ASHP:
                        case object _ when Enums.SystemDocumentType.SaffUnv:
                        case object _ when Enums.SystemDocumentType.PropMaint:
                        case object _ when Enums.SystemDocumentType.ComCat:
                        case object _ when Enums.SystemDocumentType.ComGSR:
                        case object _ when Enums.SystemDocumentType.ServiceLetters:
                        case object _ when Enums.SystemDocumentType.Analyser:
                        case object _ when Enums.SystemDocumentType.SalesCredit:
                        case object _ when Enums.SystemDocumentType.SiteLetter:
                        case object _ when Enums.SystemDocumentType.ContractOption1:
                        case object _ when Enums.SystemDocumentType.SVR:
                            {
                                break;
                            }

                        default:
                            {
                                if (OrderID > 0)
                                    filePath = TheSystem.Configuration.DocumentsLocation + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".doc";
                                else
                                {
                                    FolderBrowserDialog folderToSaveTo = new FolderBrowserDialog();
                                    folderToSaveTo.ShowDialog();

                                    if (folderToSaveTo.SelectedPath.Trim.Length == 0)
                                        return;
                                    else
                                        filePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".doc";
                                }

                                break;
                            }
                    }

                    Cursor.Current = Cursors.WaitCursor;

                    switch (PrintType)
                    {
                        case object _ when Enums.SystemDocumentType.DomGSR:
                        case object _ when Enums.SystemDocumentType.GSR:
                        case object _ when Enums.SystemDocumentType.ASHP:
                        case object _ when Enums.SystemDocumentType.SaffUnv:
                        case object _ when Enums.SystemDocumentType.PropMaint:
                        case object _ when Enums.SystemDocumentType.ComCat:
                        case object _ when Enums.SystemDocumentType.ComGSR:
                            {
                                int engineerVisitId = DetailsToPrint(0).GetType() == typeof(EngineerVisits.EngineerVisit) ? DetailsToPrint(0).EngineerVisitID : DetailsToPrint(0);
                                string savePath = string.Empty;
                                FolderBrowserDialog folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim.Length == 0)
                                    return;
                                else
                                    savePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + Strings.Format(DateTime.Now, "ddMMMyyyyHHmmss") + ".docx";

                                List<byte[]> fullDocument = new List<byte[]>();
                                success = PrintGSR(engineerVisitId, fullDocument);

                                if (success)
                                {
                                    if (fullDocument.Count > 0)
                                    {
                                        File.WriteAllBytes(savePath, PrintHelper.CombineDocs(fullDocument));
                                        PrintHelper.RemoveSpacingInDoc(savePath);
                                        if (!loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
                                            savePath = PrintHelper.LockFile(savePath, true);
                                        Process.Start(savePath);
                                    }
                                }

                                if (PrintType == Enums.SystemDocumentType.GSR)
                                {
                                    EngineerVisitAdditionals.EngineerVisitAdditional MinorElectrical = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(engineerVisitId, Enums.AdditionalChecksTypes.MinorWorksSingleCircuitElecCert);
                                    if (!MinorElectrical == null)
                                        ElecCertPDF((EngineerVisits.EngineerVisit)DetailsToPrint(0), MinorElectrical, "Minor Works Cert");
                                    EngineerVisits.EngineerVisit engineerVisit = (EngineerVisits.EngineerVisit)this.DetailsToPrint(0);
                                    if (engineerVisit != null)
                                    {
                                        DataView dvEngineerVisitDefects = (DataView)this.DetailsToPrint(2);
                                        DataRow[] drWarningNotices = (from x in dvEngineerVisitDefects.Table.AsEnumerable()
                                                                      where Helper.MakeBooleanValid(x("WarningNoticeIssued")) == true
                                                                      select x).ToArray();
                                        foreach (DataRow drWarningNotice in drWarningNotices)
                                            WarningNoticePDF(engineerVisit, drWarningNotice, "GasWarningNotice");
                                    }
                                }
                                Cursor.Current = Cursors.Default;
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.ServiceLetters:
                            {
                                DataRow dr = DetailsToPrint(0);
                                success = GenerateServiceLetterMK2(dr, dr("AMPM"), (DateTime)dr("StartDateTime"), dr("JobNUmber"), DateTime.Today, null/* TODO Change to default(_) if this is not a reference type */, dr("jobid"), true);
                                success = false;
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.ContractOption1:
                            {
                                DataRow dr = (DataTable)DetailsToPrint(0).Rows(0);
                                success = GenerateContractLetter(dr);
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.JobSheet:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\WorkSheet.dot");
                                success = GenerateJobSheet((EngineerVisits.EngineerVisit)this.DetailsToPrint(0));
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.QCPrint:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                success = QCPrint();
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.Install:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\Install.dot");
                                success = Install((EngineerVisits.EngineerVisit)this.DetailsToPrint(0));
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.ElecMinor:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                EngineerVisitAdditionals.EngineerVisitAdditional MinorElectrical = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(this.DetailsToPrint(0).EngineerVisitID, Enums.AdditionalChecksTypes.MinorWorksSingleCircuitElecCert);
                                Cursor.Current = Cursors.WaitCursor;
                                // new PDF method
                                ElecCertPDF(((EngineerVisits.EngineerVisit)this.DetailsToPrint(0)), MinorElectrical, "Minor Works Cert");
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.CommissioningChecklist:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                Cursor.Current = Cursors.WaitCursor;
                                success = ComChecklist((EngineerVisits.EngineerVisit)this.DetailsToPrint(0));
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.HotWorksPermit:
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                success = GenerateHotWorksPermit((EngineerVisits.EngineerVisit)this.DetailsToPrint(0));
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.SVR:
                            {
                                string savePath = string.Empty;
                                FolderBrowserDialog folderToSaveTo = new FolderBrowserDialog();
                                folderToSaveTo.ShowDialog();
                                if (folderToSaveTo.SelectedPath.Trim.Length == 0)
                                    return;
                                else
                                    savePath = folderToSaveTo.SelectedPath + @"\" + DocumentName + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ".docx";
                                Cursor.Current = Cursors.WaitCursor;
                                success = SiteVisitReport((EngineerVisits.EngineerVisit)this.DetailsToPrint(0), savePath);
                                filePath = savePath;
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.JobContactLetter:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\JobContactLetter.dot");
                                success = JobContactLetter((Jobs.Job)this.DetailsToPrint(0));
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.SiteLetter:
                            {
                                SiteID = DetailsToPrint.item(1);
                                FRMSiteLetterList fSelectTemplate = ShowForm(typeof(FRMSiteLetterList), true, null/* TODO Change to default(_) if this is not a reference type */);
                                if (fSelectTemplate.SelectedTemplate.Length > 0)
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    string savePath = TheSystem.Configuration.DocumentsLocation + @"SiteLetters\" + SiteID + @"\" + fSelectTemplate.SelectedTemplate;
                                    string fileName = Path.GetFileNameWithoutExtension(savePath);
                                    savePath = savePath.Replace(fileName, fileName + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss"));
                                    string template = Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\SiteLetters\" + fSelectTemplate.SelectedTemplate;
                                    success = SiteLetter(template, savePath);
                                    filePath = savePath;
                                }

                                break;
                            }

                        case object _ when Enums.SystemDocumentType.PartCredit:
                            {
                                MsWordApp = new WD.Application();
                                MsWordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                                MsWordApp.Visible = false;
                                WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\CREDIT.dot");
                                success = Credit();
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.SalesCredit:
                            {
                                filePath = TheSystem.Configuration.DocumentsLocation + @"\Sales Credits\" + DocumentName + "_" + (DataTable)DetailsToPrint.Rows(0)("CreditReference").ToString + ".docx";
                                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                                filePath = FileCheck(filePath);
                                success = GenerateCredit((DataTable)DetailsToPrint, filePath);
                                Process.Start(filePath);
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.Analyser:
                            {
                                DataTable dt = (DataTable)this.DetailsToPrint;
                                success = GenerateAnalyserLetter(dt);
                                break;
                            }

                        case object _ when Enums.SystemDocumentType.PaymentReceipt:
                            {
                                int invoiceId = 0;
                                invoiceId = System.Convert.ToInt32(this.DetailsToPrint);
                                try
                                {
                                    Invoiceds.Invoiced oInvoice = DB.Invoiced.Invoiced_Get(invoiceId);
                                    success = GenerateSalesInvoice(oInvoice, null/* TODO Change to default(_) if this is not a reference type */, false);
                                }
                                catch (Exception ex)
                                {
                                    success = false;
                                    ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                break;
                            }

                        case object _ when Enums.SystemDocumentType.Warn:
                            {
                                EngineerVisits.EngineerVisit engineerVisit = (EngineerVisits.EngineerVisit)this.DetailsToPrint(0);
                                if (engineerVisit != null)
                                {
                                    DataView dvEngineerVisitDefects = (DataView)this.DetailsToPrint(1);
                                    DataRow[] drWarningNotices = (from x in dvEngineerVisitDefects.Table.AsEnumerable()
                                                                  where Helper.MakeBooleanValid(x("WarningNoticeIssued")) == true
                                                                  select x).ToArray();
                                    foreach (DataRow drWarningNotice in drWarningNotices)
                                        WarningNoticePDF(engineerVisit, drWarningNotice, "GasWarningNotice");
                                }

                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    success = false;
                    ShowMessage("Error printing : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    switch (PrintType)
                    {
                        case object _ when Enums.SystemDocumentType.DomGSR:
                        case object _ when Enums.SystemDocumentType.GSR:
                        case object _ when Enums.SystemDocumentType.ASHP:
                        case object _ when Enums.SystemDocumentType.SaffUnv:
                        case object _ when Enums.SystemDocumentType.PropMaint:
                        case object _ when Enums.SystemDocumentType.ComCat:
                        case object _ when Enums.SystemDocumentType.ComGSR:
                        case object _ when Enums.SystemDocumentType.ServiceLetters:
                        case object _ when Enums.SystemDocumentType.Analyser:
                        case object _ when Enums.SystemDocumentType.ContractOption1:
                        case object _ when Enums.SystemDocumentType.CommissioningChecklist:
                        case object _ when Enums.SystemDocumentType.SalesCredit:
                        case object _ when Enums.SystemDocumentType.HotWorksPermit:
                        case object _ when Enums.SystemDocumentType.PaymentReceipt:
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

                    EngineerVisits.EngineerVisit oEngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId);
                    Sites.Site oSite = DB.Sites.Get(oEngineerVisit.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId);

                    EngineerVisitAdditionals.EngineerVisitAdditional ASHP = null/* TODO Change to default(_) if this is not a reference type */;
                    EngineerVisitAdditionals.EngineerVisitAdditional PM = null/* TODO Change to default(_) if this is not a reference type */;
                    EngineerVisitAdditionals.EngineerVisitAdditional SaffUnv = null/* TODO Change to default(_) if this is not a reference type */;
                    EngineerVisitAdditionals.EngineerVisitAdditional ComCatAdd = null/* TODO Change to default(_) if this is not a reference type */;

                    DataView dvAdditionalWorksheet = null/* TODO Change to default(_) if this is not a reference type */;
                    List<int> comLsrList = new List<int>() { Enums.AdditionalChecksTypes.CommercialStrengthTestCP16, Enums.AdditionalChecksTypes.CommercialPurgingTestCP16, Enums.AdditionalChecksTypes.CommercialSiteChecksCP17, Enums.AdditionalChecksTypes.CommercialTightnessTestCP16 };

                    DataView dvFaults = DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(engineerVisitId);

                    string template = "";
                    string saveDir = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblEngineerVisit) + @"\" + oEngineerVisit.EngineerVisitID;
                    Directory.CreateDirectory(saveDir);

                    if ((PrintType == Enums.SystemDocumentType.GSR | PrintType == Enums.SystemDocumentType.GSRBatch))
                    {
                        ASHP = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet);
                        PM = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist);
                        SaffUnv = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SaffronUnventedReport);
                        ComCatAdd = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialCateringCP42);

                        dvAdditionalWorksheet = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(oEngineerVisit.EngineerVisitID);
                        DataRow[] comWorkSheets = (from x in dvAdditionalWorksheet.Table.AsEnumerable()
                                                   where comLsrList.Contains(Helper.MakeIntegerValid(x("TestType")))
                                                   select x).ToArray();
                        if (comWorkSheets.Length > 0)
                            dvAdditionalWorksheet = new DataView(comWorkSheets.CopyToDataTable());
                        else
                            dvAdditionalWorksheet = null/* TODO Change to default(_) if this is not a reference type */;
                    }
                    else if (PrintType == Enums.SystemDocumentType.ASHP)
                        ASHP = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet);
                    else if (PrintType == Enums.SystemDocumentType.PropMaint)
                    {
                        PM = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist);
                        goto ProptMain;
                    }
                    else if (PrintType == Enums.SystemDocumentType.ComCat)
                        ComCatAdd = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialCateringCP42);
                    else if (PrintType == Enums.SystemDocumentType.COMSR | PrintType == Enums.SystemDocumentType.ComGSR)
                    {
                        dvAdditionalWorksheet = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(oEngineerVisit.EngineerVisitID);
                        DataRow[] comWorkSheets = (from x in dvAdditionalWorksheet.Table.AsEnumerable()
                                                   where comLsrList.Contains(Helper.MakeIntegerValid(x("TestType")))
                                                   select x).ToArray();
                        if (comWorkSheets.Length > 0)
                            dvAdditionalWorksheet = new DataView(comWorkSheets.CopyToDataTable());
                        else
                            dvAdditionalWorksheet = null/* TODO Change to default(_) if this is not a reference type */;
                    }
                    else if (PrintType == Enums.SystemDocumentType.SaffUnv)
                    {
                        SaffUnv = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SaffronUnventedReport);
                        goto SaffUnv;
                    }

                    if (((dvAdditionalWorksheet == null || dvAdditionalWorksheet.Count == 0) & ASHP == null) | (PrintType == Enums.SystemDocumentType.DomGSR))
                    {
                        DataView gasLsrs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Gas);
                        DataView oilLsrs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Oil);
                        DataView unventedLsrs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Unvented);
                        DataView hpLsrs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.ASHP);
                        hpLsrs.Table.Merge(DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.GSHP).Table);
                        DataView comCatLsrs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.ComCat);
                        DataView hiuLsrs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.HIU);
                        DataView otherLsrs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Other);
                        otherLsrs.Table.Merge(DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.Solar).Table);
                        DataView solidFuelLsrs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, Enums.WorksheetFuelTypes.SolidFuel);

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

                        if (gasLsrs.Table.Rows.Count == 0 & oilLsrs.Table.Rows.Count == 0 & solidFuelLsrs.Table.Rows.Count == 0 & otherLsrs.Table.Rows.Count == 0 & hpLsrs.Table.Rows.Count == 0 & hiuLsrs.Table.Rows.Count == 0 & comCatLsrs.Table.Rows.Count == 0 & unventedLsrs.Table.Rows.Count == 0 & dvFaults.Table.Rows.Count == 0 & (dvAdditionalWorksheet == null || dvAdditionalWorksheet.Count == 0) & ASHP == null & PM == null & SaffUnv == null & ComCatAdd == null)
                        {
                            isBlank = true;
                            success = true;
                            goto NextLSR;
                        }

                        bool hasOnlyDefects = (gasLsrs.Table.Rows.Count == 0 && oilLsrs.Table.Rows.Count == 0 && otherLsrs.Table.Rows.Count == 0 && hpLsrs.Table.Rows.Count == 0 && hiuLsrs.Table.Rows.Count == 0 && comCatLsrs.Table.Rows.Count == 0 && dvFaults.Table.Rows.Count > 0);

                        if (gasLsrs.Table.Rows.Count > 0)
                        {
                            if (oSite.CustomerID == Enums.Customer.NCC)
                                template = Application.StartupPath + @"\Templates\GSR\GSR_NCC.docx";
                            else if (oSite.CustomerID == Enums.Customer.WDC)
                                template = Application.StartupPath + @"\Templates\GSR\GSR_WDC.docx";
                            else
                                template = Application.StartupPath + @"\Templates\GSR\GSR.docx";
                            string savePath = saveDir + @"\GSR" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);

                            goldenRule = GetDocumentGoldenRule(template, oSite.SiteID);

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
                                if (!hasLsrHeaderLetter)
                                    hasLsrHeaderLetter = printerHeader;
                            }

                            success = GSR(oEngineerVisit, oSite, dvFaults, printerHeader, gasLsrs, template, savePath, Enums.WorksheetFuelTypes.Gas, goldenRule, fullDocument, oSite.CustomerID == Enums.Customer.NCC);

                            if (success & !batch)
                            {
                                savePath = PrintHelper.LockFile(savePath, true);
                                GSRSave(savePath, oEngineerVisit, oSite, "LSR_GAS");
                            }
                        }

                        if (oilLsrs.Table.Rows.Count > 0)
                        {
                            string savePath = saveDir + @"\GSROil" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSROil.docx";

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
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
                            string savePath = saveDir + @"\GSROther" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSROther.docx";

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
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
                            string savePath = saveDir + @"\GSRSolidFuel" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRSolidFuel.docx";

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
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
                            string savePath = saveDir + @"\GSRASHPGSHP" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRASHPGSHP.docx";

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
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
                            string savePath = saveDir + @"\GSRHIU" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRHIU.docx";

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
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
                            string savePath = saveDir + @"\GSRUnvented" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRUnvented.docx";

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
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
                            string savePath = saveDir + @"\GSRCOMCAT2" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRCOMCAT2.docx";

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
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

                        if (!ComCatAdd == null)
                        {
                            string savePath = saveDir + @"\GSRCOMCAT" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                            savePath = FileCheck(savePath);
                            template = Application.StartupPath + @"\Templates\GSR\GSRCOMCAT.docx";

                            bool printerHeader = false;
                            if (!isSvr)
                            {
                                if (!hasLsrHeaderLetter)
                                    printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : oSite.CustomerID == Enums.Customer.NCC;
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
                    else if (!ASHP == null)
                    {
                        string savePath = saveDir + @"\ASHPM" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                        savePath = FileCheck(savePath);
                        template = Application.StartupPath + @"\Templates\GSR\GSRASHPM.docx";

                        bool printerHeader = false;
                        if (!isSvr)
                        {
                            if (!hasLsrHeaderLetter)
                                printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : false;
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
                            savePath = saveDir + @"\GSROther" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
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
                        string savePath = saveDir + @"\COMSR" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                        savePath = FileCheck(savePath);
                        template = Application.StartupPath + @"\Templates\GSR\GSRCOMSR.docx";

                        bool printerHeader = false;
                        if (!isSvr)
                        {
                            if (!hasLsrHeaderLetter)
                                printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : false;
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

                        if ((dvAdditionalWorksheet != null && dvAdditionalWorksheet.Count > 0))
                        {
                            savePath = saveDir + @"\COMTANDP" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
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
                            savePath = saveDir + @"\GSROther" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
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
                    if (PM != null)
                    {
                        string savePath = saveDir + @"\PropMain" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                        savePath = FileCheck(savePath);
                        template = Application.StartupPath + @"\Templates\GSR\GSRPropMain.docx";

                        bool printerHeader = false;
                        if (!isSvr)
                        {
                            if (!hasLsrHeaderLetter)
                                printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : false;
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
                            savePath = saveDir + @"\GSROther" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
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
                    if (SaffUnv != null)
                    {
                        string savePath = saveDir + @"\SAFUnvASHP" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                        savePath = FileCheck(savePath);
                        template = Application.StartupPath + @"\Templates\GSR\GSRUnvASHP.docx";

                        bool printerHeader = false;
                        if (!isSvr)
                        {
                            if (!hasLsrHeaderLetter)
                                printerHeader = batch ? Helper.MakeBooleanValid((ArrayList)this.DetailsToPrint.Item(1)) : false;
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
                            savePath = saveDir + @"\GSROther" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
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
                        LSR.LSRError lsrError = new LSR.LSRError();
                        {
                            var withBlock = lsrError;
                            withBlock.EngineerVisitID = oEngineerVisit.EngineerVisitID;
                            Engineers.Engineer eng = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                            withBlock.Engineer = eng != null ? eng.Name : "Unknown";
                            withBlock.VisitDate = oEngineerVisit.StartDateTime;
                            withBlock.JobNumber = jobNumber;
                        }
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
                try
                {
                    foreach (System.Text.RegularExpressions.Match wordField in GetTemplateFields(WordDoc.Content.Text))
                    {
                        switch (wordField.Value.ToLower())
                        {
                            case object _ when "[Address1]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address1")));
                                    break;
                                }

                            case object _ when "[Address2]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address2")));
                                    break;
                                }

                            case object _ when "[Address3]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address3")));
                                    break;
                                }

                            case object _ when "[Address4]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address4")));
                                    break;
                                }

                            case object _ when "[Address5]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address5")));
                                    break;
                                }

                            case object _ when "[Postcode]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(Sys.Helper.FormatPostcode(dr("Postcode"))));
                                    break;
                                }

                            case object _ when "[theDate]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Strings.Format(TheDate, "dd/MM/yyyy"));
                                    break;
                                }

                            case object _ when "[Date]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Strings.Format(VisitDate, "dd/MM/yyyy"));
                                    break;
                                }

                            case object _ when "[Name]".ToLower():
                                {
                                    string name = Sys.Helper.MakeStringValid(dr("Name"));
                                    if (name.Contains("T2"))
                                        name = name.Substring(0, Strings.InStr(name, "T2") - 1);
                                    name = name.Replace("T1 ", "");
                                    name = name.Trim();
                                    ReplaceText(ref WordDoc, wordField.Value, name);
                                    break;
                                }

                            case object _ when "[AMPM]".ToLower():
                                {
                                    if (AMPM == "AM")
                                        ReplaceText(ref WordDoc, wordField.Value, "8:00am - 1:00pm");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "12:00pm - 5:30pm");
                                    break;
                                }

                            case object _ when "[JobRef]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(JobNumber));
                                    break;
                                }

                            case object _ when "[gascharge]".ToLower():
                                {
                                    DateTime thecutoff = new DateTime(2017, 3, 31);
                                    if (DateTime.DateDiff(DateInterval.Day, VisitDate, thecutoff) < 0)
                                        ReplaceText(ref WordDoc, wordField.Value, "£41.37");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "£37.00");
                                    break;
                                }

                            case object _ when "[carpcharge]".ToLower():
                                {
                                    if (DateTime.DateDiff(DateInterval.Day, VisitDate, new DateTime(2017, 3, 31)) < 0)
                                        ReplaceText(ref WordDoc, wordField.Value, "£97.76");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "£88.03");
                                    break;
                                }
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateAnalyserLetter(DataTable dt)
            {
                try
                {
                    string usingdoc = Application.StartupPath + @"\Templates\FGATempAnton.docx";
                    DataRow dr = dt.Rows(0);

                    byte[] byteArray = File.ReadAllBytes(usingdoc);
                    MemoryStream mm = new MemoryStream();
                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            string docText = null;

                            StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream);
                            using ((sr))
                                docText = sr.ReadToEnd();

                            docText = docText.Replace("[Date]", DateTime.Now.ToLongDateString());
                            docText = docText.Replace("[Serial]", dr("SerialNumber"));
                            docText = docText.Replace("[Faults]", dr("Faults"));
                            docText = docText.Replace("[Username]", loggedInUser.Fullname);
                            docText = docText.Replace("[Email]", loggedInUser.EmailAddress);
                            StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create));
                            using ((sw))
                                sw.Write(docText);
                        }

                        Documentss.Documents linkedDoc = new Documentss.Documents();
                        linkedDoc.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblEquipment);
                        linkedDoc.SetRecordID = System.Convert.ToInt32(dr("EquipmentID"));
                        linkedDoc.SetDocumentTypeID = 205;

                        string filePath = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblEquipment) + @"\" + System.Convert.ToInt32(dr("EquipmentID"));
                        Directory.CreateDirectory(filePath);

                        string newfile = filePath + @"\AnalyserSerialNumber" + dr("SerialNumber") + "_" + DateTime.Now.ToFileTime() + ".docx";
                        FileStream fileStream = new FileStream(newfile, System.IO.FileMode.CreateNew);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);
                        fileStream.Close();

                        bool openFile = false;
                        if (!Helper.MakeBooleanValid(dr("SendEmail")))
                            openFile = true;

                        newfile = PrintHelper.LockFile(newfile, true);

                        linkedDoc.SetNotes = "";
                        linkedDoc.SetLocation = filePath;
                        linkedDoc.SetName = "Anton Sprint eVo2, Serial Number " + dr("SerialNumber");
                        linkedDoc = DB.Documents.Insert(linkedDoc, false);

                        if (System.Convert.ToBoolean(dr("SendEmail")))
                        {
                            Emails email = new Emails();
                            email.To = dr("EmailAddress");
                            email.From = loggedInUser.EmailAddress;
                            email.Subject = "Anton Sprint eVo2, Serial Number " + dr("SerialNumber");
                            email.Body = "Please see letter attached";
                            email.Attachments.Add(newfile);
                            email.SendMe = true;
                            email.Send();
                        }
                        else
                            Process.Start(newfile);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateServiceLetterMK2(DataRow dr, string AMPM, DateTime VisitDate, string JobNumber, DateTime TheDate, List<byte[]> batch = null, int jobid = 0, bool justLetters = false)
            {
                int customerId = Helper.MakeIntegerValid(dr("CustomerID"));
                bool patchCheck = dr.Table.Columns.Contains("PatchCheck") && Helper.MakeBooleanValid(dr("PatchCheck"));
                Customers.CustomerServiceProcess serviceProcess = DB.Customer.CustomerServiceProcess_Get_ForCustomer(customerId);
                string letter = Helper.MakeStringValid(dr("Type")).ToLower();
                byte[] template = null;
                string fileName = dr.Table.Columns.Contains("FileName") && !string.IsNullOrEmpty(Helper.MakeStringValid(dr("FileName"))) ? Helper.MakeStringValid(dr("FileName")) : string.Empty;
                DataView contacts = DB.Contact.Contacts_GetAll_ForLink(System.Convert.ToInt32(Enums.TableNames.tblSite), Helper.MakeIntegerValid(dr("SiteID")));
                DataRow drPOC = null/* TODO Change to default(_) if this is not a reference type */;

                if (!string.IsNullOrEmpty(fileName))
                    template = TemplateHelper.ReadWordDoc(Application.StartupPath + TheSystem.Configuration.TemplateLocation + fileName);
                else if (Helper.MakeIntegerValid(serviceProcess?.CustomerServiceProcessID) == 0)
                {
                    if (patchCheck)
                        template = TemplateHelper.ReadWordDoc(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ServiceLetters\PatchCheck.docx");
                    else
                        template = TemplateHelper.ReadWordDoc(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ServiceLetters\AnnualSafetyInspection.docx");
                }
                else if (patchCheck)
                    template = serviceProcess.PatchCheckTemplate;
                else
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

                if (template == null)
                    throw new Exception("Unable to locate template!");

                foreach (DataRowView contact in contacts)
                {
                    if (Helper.MakeBooleanValid(contact("POC")) == true)
                        drPOC = contact.Row;
                }

                try
                {
                    int count = drPOC != null ? 2 : 1;
                    for (int i = 0; i <= count - 1; i += 1)
                    {
                        string goldenRule = GetDocumentGoldenRule("AnnualSafetyInspection", Helper.MakeIntegerValid(dr("SiteID")));
                        byte[] byteArray = template;
                        MemoryStream mm = new MemoryStream();
                        using ((mm))
                        {
                            mm.Write(byteArray, 0, byteArray.Length);
                            WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                            using ((wordDoc))
                            {
                                PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);

                                AddCompanyDetails(wordDoc, true);

                                Customers.Customer customer = DB.Customer.Customer_Get_ForSiteID(Helper.MakeIntegerValid(dr("SiteID")));
                                if (customer != null)
                                    PrintHelper.ReplaceText(wordDoc, "$Customer", customer.Name);
                                PrintHelper.ReplaceText(wordDoc, "$Address1", drPOC != null && !IsDBNull(drPOC("Address1")) ? drPOC("Address1") : dr("Address1"));
                                PrintHelper.ReplaceText(wordDoc, "$Address2", drPOC != null && !IsDBNull(drPOC("Address2")) ? drPOC("Address2") : dr("Address2"));
                                PrintHelper.ReplaceText(wordDoc, "$Address3", drPOC != null && !IsDBNull(drPOC("Address3")) ? drPOC("Address3") : dr("Address3"));
                                PrintHelper.ReplaceText(wordDoc, "$Address4", string.Empty);
                                PrintHelper.ReplaceText(wordDoc, "$Address5", string.Empty);
                                PrintHelper.ReplaceText(wordDoc, "$Postcode", drPOC != null && !IsDBNull(drPOC("Postcode")) ? Helper.FormatPostcode(drPOC("Postcode")) : Helper.FormatPostcode(dr("Postcode")));
                                PrintHelper.ReplaceText(wordDoc, "$TheDate", Strings.Format(TheDate, "dd/MM/yyyy"));
                                PrintHelper.ReplaceText(wordDoc, "$Date", VisitDate.ToString("dddd, dd/MM/yyyy"));
                                PrintHelper.ReplaceText(wordDoc, "$Expiry", Strings.Format((DateTime)dr("LastServiceDate").AddDays(366), "dd/MM/yyyy"));

                                string name = string.Empty;
                                if ((drPOC != null && !IsDBNull(drPOC("FirstName"))))
                                    name = Helper.MakeStringValid(drPOC("Title")) + " " + Helper.MakeStringValid(drPOC("FirstName")) + " " + Helper.MakeStringValid(drPOC("LastName"));
                                if (name.Length > 0)
                                    name += " on behalf of ";
                                name += Sys.Helper.MakeStringValid(dr("Name"));
                                if (name.Contains("T2"))
                                    name = name.Replace("T2 ", "");
                                name = name.Replace("T1 ", "");
                                name = name.Trim();
                                PrintHelper.ReplaceText(wordDoc, "$Name", Strings.StrConv(name, VbStrConv.ProperCase).Replace("&", "&amp;"));
                                if (string.IsNullOrEmpty(AMPM))
                                    AMPM = VisitDate.Hour < 12 ? "AM" : "PM";
                                if (AMPM == "AM")
                                    PrintHelper.ReplaceText(wordDoc, "$AMPM", "between 8:00am and 1:00pm");
                                else
                                    PrintHelper.ReplaceText(wordDoc, "$AMPM", "between 12:00pm and 5:30pm");
                                PrintHelper.ReplaceText(wordDoc, "$GasCharge", "£41.37");
                                PrintHelper.ReplaceText(wordDoc, "$CarpCharge", "£97.76");
                                PrintHelper.ReplaceText(wordDoc, "$JobRef", Helper.MakeStringValid(JobNumber));

                                wordDoc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), wordDoc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            }

                            Documentss.Documents linkedDoc = new Documentss.Documents();
                            linkedDoc.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblJob);
                            linkedDoc.SetRecordID = jobid;
                            linkedDoc.SetDocumentTypeID = 205;

                            string filePath = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblJob) + @"\" + jobid;
                            Directory.CreateDirectory(filePath);

                            string newfile = filePath + @"\" + dr("Type") + DateTime.Now.ToString("HHmmssfff") + ".docx";
                            FileStream fileStream = new FileStream(newfile, FileMode.CreateNew);
                            mm.Position = 0;
                            using ((fileStream))
                                mm.WriteTo(fileStream);

                            linkedDoc.SetNotes = "";
                            linkedDoc.SetLocation = filePath;
                            linkedDoc = DB.Documents.Insert(linkedDoc, false);

                            if (!justLetters & DB.LetterManager.LetterGenerated_CheckToday(dr("Type"), jobid, TheDate).Rows.Count > 0)
                                return true;
                            if (batch != null)
                                batch.Add(mm.ToArray());
                            else
                                Process.Start(newfile);

                            drPOC = null/* TODO Change to default(_) if this is not a reference type */;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            public bool GenerateJobLetter(DataRow dr, Jobs.Job job, bool letter1, WordprocessingDocument batch = null/* TODO Change to default(_) if this is not a reference type */, EngineerVisits.EngineerVisit engineervisit = null/* TODO Change to default(_) if this is not a reference type */)
            {
                Sites.Site oSite = DB.Sites.Get(Helper.MakeIntegerValid(dr("SiteID")));
                JobOfWorks.JobOfWork oJobOfWork = (JobOfWorks.JobOfWork)job.JobOfWorks(0);
                int letter = 0;
                if (!letter1)
                    letter = 1;
                EngineerVisits.EngineerVisit oEngineerVisit;
                if (engineervisit == null)
                    oEngineerVisit = (EngineerVisits.EngineerVisit)oJobOfWork.EngineerVisits(letter);
                else
                    oEngineerVisit = engineervisit;

                string doc = string.Empty;
                string workStream = Helper.MakeStringValid(dr("Type")).ToLower();
                string templateLocation = Application.StartupPath + @"\Templates\Electrical\";
                string template = string.Empty;

                switch (true)
                {
                    case object _ when workStream == "NCC-EICR".ToLower()  // eicr job
                   :
                        {
                            template = letter1 ? "NCCTestingLetter1.docx" : "NCCTestingLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }

                    case object _ when workStream == "NCC-SURVEY-UPGRADE".ToLower():
                    case object _ when workStream == "NCC-SURVEY-REWIRE".ToLower() // rewire/upgrade job
             :
                        {
                            template = letter1 ? "NCCElecMainLetter1.docx" : "NCCElecMainLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }

                    case object _ when workStream == "VHT-SMOKE".ToLower():
                        {
                            doc = templateLocation + "VHTSMOKE.docx";
                            break;
                        }

                    case object _ when workStream == "VHT-REMEDIAL".ToLower():
                        {
                            doc = templateLocation + "VHTRemedial.docx";
                            break;
                        }

                    case object _ when workStream == "SHS-REMEDIAL".ToLower():
                        {
                            doc = templateLocation + "SHSRemedial.docx";
                            break;
                        }

                    case object _ when workStream == "FHG-REMEDIAL".ToLower():
                        {
                            doc = templateLocation + "FHGRemedial.docx";
                            break;
                        }

                    case object _ when workStream == "NCC-REMEDIAL".ToLower():
                        {
                            doc = templateLocation + "NCCRemedial.docx";
                            break;
                        }

                    case object _ when workStream == "VHT-EICR".ToLower():
                        {
                            template = letter1 ? "VHTTestingLetter1.docx" : "VHTTestingLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }

                    case object _ when workStream == "SHS-EICR".ToLower():
                        {
                            template = letter1 ? "SHSEicrLetter1.docx" : "SHSEicrLetter2.docx";
                            doc = templateLocation + template;
                            break;
                        }

                    case object _ when workStream == "FHG-EICR".ToLower():
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
                    string goldenRule = GetDocumentGoldenRule(doc, Helper.MakeIntegerValid(dr("SiteID")));
                    byte[] byteArray = File.ReadAllBytes(doc);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            string name = StrConv(Helper.MakeStringValid(dr("Name")), VbStrConv.ProperCase).Replace("&", "&amp;").Trim();
                            if (name.Length == 0)
                                name = "The Occupier";
                            PrintHelper.ReplaceText(wordDoc, "[Name]", name);
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSite.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSite.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSite.Address3);
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[Letter]", DateTime.Now.ToLongDateString());
                            DateTime visitDate = oEngineerVisit.StartDateTime != null/* TODO Change to default(_) if this is not a reference type */? oEngineerVisit.StartDateTime : job.DateCreated;
                            PrintHelper.ReplaceText(wordDoc, "[Date]", visitDate.ToString("dd MMM yyyy"));
                            dr("BookedVisit") = visitDate;

                            string timePeriod = string.Empty;
                            timePeriod = visitDate.Hour < 12 ? "8:00am - 1:00pm" : "12:00pm - 5:30pm";

                            if (visitDate.Hour < 12)
                                PrintHelper.ReplaceText(wordDoc, "[Time]", timePeriod);
                            else
                                PrintHelper.ReplaceText(wordDoc, "[Time]", timePeriod);
                            PrintHelper.ReplaceText(wordDoc, "[User]", loggedInUser.Fullname);
                            if (Helper.MakeStringValid(dr("Type")).Contains("Rewire"))
                                PrintHelper.ReplaceText(wordDoc, "[Type]", "electrical rewiring");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[Type]", "electrical upgrades");
                            if (batch != null)
                                wordDoc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), wordDoc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                        }

                        Documentss.Documents linkedDoc = new Documentss.Documents();
                        linkedDoc.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblJob);
                        linkedDoc.SetRecordID = job.JobID;
                        linkedDoc.SetDocumentTypeID = 205;

                        string filePath = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblJob) + @"\" + job.JobID;
                        Directory.CreateDirectory(filePath);

                        string newfile = filePath + @"\" + Helper.MakeStringValid(dr("Type"));
                        newfile += letter1 ? "_L1" : "_L2";
                        newfile += "_" + oSite.Address1.Replace(@"\", "").Replace("/", "") + ".docx";

                        newfile = FileCheck(newfile);

                        FileStream fileStream = new FileStream(newfile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);

                        linkedDoc.SetNotes = "";
                        linkedDoc.SetLocation = filePath;
                        linkedDoc.SetName = letter1 ? "Letter1" : "Letter2";
                        linkedDoc = DB.Documents.Insert(linkedDoc, false);

                        ContactAttempt contactAttempt = new ContactAttempt();
                        {
                            var withBlock = contactAttempt;
                            withBlock.ContactMethedID = 3;
                            withBlock.LinkID = System.Convert.ToInt32(Enums.TableNames.tblJob);
                            withBlock.LinkRef = job.JobID;
                            withBlock.ContactMade = DateTime.Now;
                            withBlock.Notes = letter1 ? "Letter 1" : "Letter 2" + " Generated";
                            withBlock.ContactMadeByUserId = loggedInUser.UserID;
                        }
                        contactAttempt = DB.ContactAttempts.Insert(contactAttempt);

                        if (!batch == null)
                        {
                            MainDocumentPart mainPart = batch.MainDocumentPart;
                            string altChunkId = "AltId" + Helper.MakeIntegerValid(dr("SiteID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                            AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            mm.Position = 0;

                            using (mm)
                                chunk.FeedData(mm);

                            WP.AltChunk altChunk = new WP.AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                            mainPart.Document.Save();
                        }
                        else
                            wpFilePath = newfile;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GeneratePurchaseOrder(Sites.Site oSite, Warehouses.Warehouse oWarehouse, DataTable dt, Suppliers.Supplier oSupplier, Users.User oUser, string poNumber, DateTime deadline, DataView dvCharges, string savePath, bool toPdf)
            {
                string template = Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\Invoice\SupplierPurchaseOrder.docx";

                try
                {
                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();
                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            AddCompanyDetails(wordDoc, true, true);

                            string deliveryAddress1 = "";
                            string deliveryAddress2 = "";
                            string deliveryAddress3 = "";
                            string deliveryAddress4 = "";
                            string deliveryAddress5 = "";
                            string deliveryAddressPostcode = "";

                            if (!oSite == null)
                            {
                                deliveryAddress1 = oSite.Address1;
                                deliveryAddress2 = oSite.Address2;
                                deliveryAddress3 = oSite.Address3;
                                deliveryAddress4 = oSite.Address4;
                                deliveryAddress5 = oSite.Address5;
                                deliveryAddressPostcode = oSite.Postcode;
                            }
                            else if (!oWarehouse == null)
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
                                deliveryAddress1 = TheSystem.Configuration.CompanyName;
                                deliveryAddress2 = TheSystem.Configuration.CompanyAddres1;
                                deliveryAddress3 = TheSystem.Configuration.CompanyAddres2;
                                deliveryAddress4 = TheSystem.Configuration.CompanyAddres3;
                                deliveryAddress5 = TheSystem.Configuration.CompanyAddres4;
                                deliveryAddressPostcode = TheSystem.Configuration.CompanyPostcode;
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
                            PrintHelper.ReplaceText(wordDoc, "[DeliveryDueDate]", deadline != default(DateTime) ? deadline.ToString("dd MMM yyyy") : "N/A");

                            DataTable dtParts = new DataTable();
                            dtParts.Columns.Add("Item");
                            dtParts.Columns.Add("Description");
                            dtParts.Columns.Add("Number");
                            dtParts.Columns.Add("Price");
                            dtParts.Columns.Add("Qty");
                            dtParts.Columns.Add("Total");
                            double total = 0.0;

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                int index = 1;
                                foreach (DataRow r in dt.Rows)
                                {
                                    DataRow nr = dtParts.NewRow;
                                    nr("Item") = index;
                                    nr("Description") = r("Name");
                                    nr("Number") = r("Number");
                                    nr("Price") = Helper.MakeDoubleValid(r("BuyPrice")).ToString("C");
                                    nr("Qty") = r("QuantityOnOrder");
                                    nr("Total") = Helper.MakeDoubleValid(Helper.MakeDoubleValid(r("BuyPrice")) * Helper.MakeDoubleValid(r("QuantityOnOrder"))).ToString("C");
                                    total += Helper.MakeDoubleValid(Helper.MakeDoubleValid(r("BuyPrice")) * Helper.MakeDoubleValid(r("QuantityOnOrder"))).ToString("C");
                                    dtParts.Rows.Add(nr);
                                    index += 1;
                                }

                                PrintHelper.AddRowsToTable(wordDoc, "Item", dtParts, "Arial", "16");
                            }

                            PrintHelper.ReplaceText(wordDoc, "[Total]", total.ToString("C"));

                            DataTable dtCharges = new DataTable();
                            dtCharges.Columns.Add("Type");
                            dtCharges.Columns.Add("Price");

                            if (dvCharges != null && dvCharges.Table.Rows.Count > 0)
                            {
                                foreach (DataRow r in dvCharges.Table.Rows)
                                {
                                    DataRow nr = dtCharges.NewRow;
                                    nr("Type") = r("ChargeType");
                                    nr("Price") = Helper.MakeDoubleValid(r("Amount")).ToString("C");
                                    dtCharges.Rows.Add(nr);
                                }

                                PrintHelper.AddRowsToTable(wordDoc, "Type", dtCharges, "Arial", "16");
                            }
                        }

                        savePath = FileCheck(savePath);
                        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);

                        if (toPdf)
                            savePath = PrintHelper.ToPdf(savePath);

                        Documentss.Documents linkedDoc = new Documentss.Documents();
                        linkedDoc.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblOrder);
                        linkedDoc.SetRecordID = OrderID;
                        linkedDoc.SetDocumentTypeID = 162;
                        linkedDoc.SetName = Path.GetFileName(savePath);
                        linkedDoc.SetNotes = "";
                        linkedDoc.SetLocation = savePath;

                        Documentss.DocumentsValidator cV = new Documentss.DocumentsValidator();
                        cV.Validate(linkedDoc);

                        linkedDoc = DB.Documents.Insert(linkedDoc);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("ERROR : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private bool GenerateJobSheet(EngineerVisits.EngineerVisit EngineerVisit)
            {
                try
                {
                    Jobs.Job job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
                    // Get the payment terms and paidby details
                    JobOfWorks.JobOfWork jow = DB.JobOfWorks.JobOfWork_Get(EngineerVisit.JobOfWorkID);

                    string jobOrOrderNumber = "";
                    int rowIndex = 1;
                    double subTotal = 0.0;
                    Sites.Site site = DB.Sites.Get(job.PropertyID);

                    {
                        var withBlock = WordDoc.Tables.Item(2);
                        {
                            var withBlock1 = withBlock.Rows.Add();
                            withBlock1.Range.Font.Bold = System.Convert.ToInt32(false);
                            withBlock1.Range.Font.Size = 9;
                            withBlock1.Range.Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone;
                            withBlock1.Range.Borders.Item(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone;
                        }
                        rowIndex += 1;

                        // Job Number /  'Order Number / Contract
                        if (jow.PONumber.Length == 0)
                            withBlock.Cell(rowIndex, 1).Range.Text = job.JobNumber;
                        else
                            withBlock.Cell(rowIndex, 1).Range.Text = job.JobNumber + " / " + jow.PONumber;
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 1).Range);
                        withBlock.Cell(rowIndex, 3).Range.Text = site.Address1 + ", " + site.Address2 + ", " + Sys.Helper.FormatPostcode(site.Postcode);

                        int cou = 0;
                        withBlock.Cell(rowIndex, 4).Range.Text = EngineerVisit.NotesToEngineer;
                        withBlock.Cell(rowIndex, 5).Range.Text = EngineerVisit.OutcomeDetails;
                        withBlock.Cell(rowIndex, 5).Range.Font.Bold = System.Convert.ToInt32(true);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 4).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 3).Range);
                    }

                    {
                        var withBlock = WordDoc.Tables.Item(1);
                        withBlock.Cell(3, 1).Range.Text = Helper.MakeStringValid(site.Name);
                        withBlock.Cell(4, 1).Range.Text = Helper.MakeStringValid(site.Address1);
                        withBlock.Cell(5, 1).Range.Text = Helper.MakeStringValid(site.Address2);
                        withBlock.Cell(6, 1).Range.Text = Helper.MakeStringValid(site.Address3);
                        withBlock.Cell(7, 1).Range.Text = Helper.MakeStringValid(site.Address4);
                        withBlock.Cell(8, 1).Range.Text = Helper.MakeStringValid(site.Address5);
                        withBlock.Cell(9, 1).Range.Text = Helper.MakeStringValid(Sys.Helper.FormatPostcode(site.Postcode));
                        withBlock.Cell(3, 5).Range.Text = "";
                        withBlock.Cell(5, 5).Range.Text = Strings.Format(EngineerVisit.StartDateTime, "dd/MM/yyyy");
                        withBlock.Cell(7, 5).Range.Text = Helper.MakeStringValid("");

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(3, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(4, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(5, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(6, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(7, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(8, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(3, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(5, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(7, 5).Range);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateProforma(Jobs.Job job, ContractOriginalSites.ContractOriginalSite cos)
            {
                try
                {
                    string jobnumber = "";

                    if (DetailsToPrint.item(0) == "JOB")
                        jobnumber = job.JobNumber;
                    else
                        jobnumber = DB.ContractOriginal.Get(cos.ContractID).ContractReference;

                    // Get the payment terms and paidby details
                    // LETS GET THE INVOICE LINES MADE
                    string jobOrOrderNumber = "";
                    int rowIndex = 1;
                    double subTotal = 0.0;

                    {
                        var withBlock = WordDoc.Tables.Item(2);
                        {
                            var withBlock1 = withBlock.Rows.Add();
                            withBlock1.Range.Font.Bold = System.Convert.ToInt32(false);
                            withBlock1.Range.Font.Size = 9;
                            withBlock1.Range.Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone;
                            withBlock1.Range.Borders.Item(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone;
                        }
                        rowIndex += 1;

                        // Job Number /  'Order Number / Contract
                        withBlock.Cell(rowIndex, 1).Range.Text = jobnumber;
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 1).Range);
                        switch (Helper.MakeStringValid(DetailsToPrint.item(0)))
                        {
                            case "JOB":
                                {
                                    Sites.Site site = DB.Sites.Get(job.PropertyID);
                                    withBlock.Cell(rowIndex, 3).Range.Text = site.Address1 + ", " + site.Address2 + ", " + Sys.Helper.FormatPostcode(site.Postcode);
                                    withBlock.Cell(rowIndex, 4).Range.Text = details1;

                                    withBlock.Cell(rowIndex, 5).Range.Text = Strings.Format((double)details2, "C");
                                    withBlock.Cell(rowIndex, 5).Range.Font.Bold = System.Convert.ToInt32(true);
                                    subTotal += System.Convert.ToDouble(details2);

                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 3).Range);
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 4).Range);
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 5).Range);
                                    break;
                                }

                            case "CONTRACT":
                                {
                                    Sites.Site site = DB.Sites.Get(cos.PropertyID);
                                    withBlock.Cell(rowIndex, 3).Range.Text = site.Address1 + ", " + site.Address2 + ", " + Sys.Helper.FormatPostcode(site.Postcode);
                                    withBlock.Cell(rowIndex, 4).Range.Text = details1;
                                    withBlock.Cell(rowIndex, 5).Range.Text = Strings.Format((double)details2, "C");
                                    subTotal += Helper.MakeDoubleValid(details2);

                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 3).Range);
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 4).Range);
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 5).Range);
                                    break;
                                }
                        }
                    }

                    decimal VATRate = Sys.Helper.MakeDoubleValid(DetailsToPrint.item(4));
                    decimal VATRateDecimal = VATRate / (double)100;

                    // ***********************************************************************************
                    // REST OF THE DOCUMENT

                    {
                        var withBlock = WordDoc.Tables.Item(1);
                        withBlock.Cell(1, 1).Range.Text = Helper.MakeStringValid("PRO-FORMA");

                        {
                            var withBlock1 = WordDoc.Tables.Item(3);
                            withBlock1.Cell(2, 1).Range.Text = "PRO-FORMA";
                            withBlock1.Cell(3, 1).Range.Text = "This is NOT a VAT Invoice";
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock1.Cell(2, 1).Range);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock1.Cell(3, 1).Range);
                        }

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(1, 1).Range);
                    }

                    DataTable dtinvoicedetails = DB.Invoiced.InvoiceDetails_Get_InvoiceToBeRaisedID(DetailsToPrint.item(5)).Table;

                    {
                        var withBlock = WordDoc.Tables.Item(1);
                        withBlock.Cell(3, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("SiteName"));
                        withBlock.Cell(4, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address1"));
                        withBlock.Cell(5, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address2"));
                        withBlock.Cell(6, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address3"));
                        withBlock.Cell(7, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address4"));
                        withBlock.Cell(8, 1).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("address5"));
                        withBlock.Cell(9, 1).Range.Text = Helper.MakeStringValid(Sys.Helper.FormatPostcode(dtinvoicedetails.Rows(0).Item("postcode")));
                        withBlock.Cell(3, 5).Range.Text = "";
                        withBlock.Cell(5, 5).Range.Text = Strings.Format(DateTime.Today, "dd/MM/yyyy");
                        withBlock.Cell(7, 5).Range.Text = Helper.MakeStringValid(dtinvoicedetails.Rows(0).Item("AccountNumber"));

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(3, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(4, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(5, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(6, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(7, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(8, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(3, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(5, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(7, 5).Range);
                    }

                    {
                        var withBlock = WordDoc.Tables.Item(3);
                        withBlock.Cell(2, 5).Range.Text = Strings.Format(subTotal, "C");
                        withBlock.Cell(3, 5).Range.Text = Strings.Format(subTotal * VATRateDecimal, "C");
                        withBlock.Cell(4, 5).Range.Text = Strings.Format((subTotal * VATRateDecimal) + subTotal, "C");

                        {
                            var withBlock1 = withBlock.Rows;
                            withBlock1.WrapAroundText = true;
                            withBlock1.HorizontalPosition = Word.WdTablePosition.wdTableLeft;
                            withBlock1.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn;
                            withBlock1.DistanceLeft = MsWordApp.CentimetersToPoints(0.32);
                            withBlock1.DistanceRight = MsWordApp.CentimetersToPoints(0.32);
                            withBlock1.VerticalPosition = Word.WdTablePosition.wdTableBottom;
                            withBlock1.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
                            withBlock1.DistanceTop = MsWordApp.CentimetersToPoints(0);
                            withBlock1.DistanceBottom = MsWordApp.CentimetersToPoints(0);
                            withBlock1.AllowOverlap = false;
                        }

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(2, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(3, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(4, 5).Range);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateProformaFromVisit(Jobs.Job job)
            {
                try
                {
                    string jobnumber = "";

                    if (DetailsToPrint.item(0) == "JOB")
                        jobnumber = job.JobNumber;
                    else
                    {
                    }

                    // Get the payment terms and paidby details
                    // LETS GET THE INVOICE LINES MADE
                    string jobOrOrderNumber = "";
                    int rowIndex = 1;
                    double subTotal = 0.0;

                    Sites.Site sites = DB.Sites.Get(job.PropertyID);
                    Sites.Site siteHO = DB.Sites.Get(job.PropertyID);

                    if (!sites.CustomerID == Enums.Customer.Domestic)
                        siteHO = DB.Sites.Get(sites.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq);

                    {
                        var withBlock = WordDoc.Tables.Item(2);
                        {
                            var withBlock1 = withBlock.Rows.Add();
                            withBlock1.Range.Font.Bold = System.Convert.ToInt32(false);
                            withBlock1.Range.Font.Size = 9;
                            withBlock1.Range.Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone;
                            withBlock1.Range.Borders.Item(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone;
                        }
                        rowIndex += 1;

                        // Job Number /
                        withBlock.Cell(rowIndex, 1).Range.Text = jobnumber;
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 1).Range);
                        withBlock.Cell(rowIndex, 3).Range.Text = sites.Address1 + ", " + sites.Address2 + ", " + Sys.Helper.FormatPostcode(sites.Postcode);
                        withBlock.Cell(rowIndex, 4).Range.Text = details1;
                        withBlock.Cell(rowIndex, 5).Range.Text = Strings.Format((double)details2, "C");
                        withBlock.Cell(rowIndex, 5).Range.Font.Bold = System.Convert.ToInt32(true);
                        subTotal += System.Convert.ToDouble(details2);

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 3).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 4).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(rowIndex, 5).Range);
                    }

                    Customers.Customer customer = DB.Customer.Customer_Get(sites.CustomerID);
                    decimal VATRate = Sys.Helper.MakeDoubleValid(DetailsToPrint.item(4));
                    decimal VATRateDecimal = VATRate / (double)100;

                    // ***********************************************************************************
                    // REST OF THE DOCUMENT

                    {
                        var withBlock = WordDoc.Tables.Item(1);
                        withBlock.Cell(1, 1).Range.Text = Helper.MakeStringValid("PRO-FORMA");

                        {
                            var withBlock1 = WordDoc.Tables.Item(3);
                            withBlock1.Cell(2, 1).Range.Text = "PRO-FORMA";
                            withBlock1.Cell(3, 1).Range.Text = "This is NOT a VAT Invoice";
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock1.Cell(2, 1).Range);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock1.Cell(3, 1).Range);
                        }

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(1, 1).Range);
                    }

                    {
                        var withBlock = WordDoc.Tables.Item(1);
                        withBlock.Cell(3, 1).Range.Text = Helper.MakeStringValid(siteHO.Name);
                        withBlock.Cell(4, 1).Range.Text = Helper.MakeStringValid(siteHO.Address1);
                        withBlock.Cell(5, 1).Range.Text = Helper.MakeStringValid(siteHO.Address2);
                        withBlock.Cell(6, 1).Range.Text = Helper.MakeStringValid(siteHO.Address3);
                        withBlock.Cell(7, 1).Range.Text = Helper.MakeStringValid(siteHO.Address4);
                        withBlock.Cell(8, 1).Range.Text = Helper.MakeStringValid(siteHO.Address5);
                        withBlock.Cell(9, 1).Range.Text = Helper.MakeStringValid(Sys.Helper.FormatPostcode(siteHO.Postcode));
                        withBlock.Cell(3, 5).Range.Text = "";
                        withBlock.Cell(5, 5).Range.Text = Strings.Format(DateTime.Today, "dd/MM/yyyy");
                        withBlock.Cell(7, 5).Range.Text = Helper.MakeStringValid(customer.AccountNumber);

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(3, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(4, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(5, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(6, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(7, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(8, 1).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(3, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(5, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(7, 5).Range);
                    }

                    {
                        var withBlock = WordDoc.Tables.Item(3);
                        withBlock.Cell(2, 5).Range.Text = Strings.Format(subTotal, "C");
                        withBlock.Cell(3, 5).Range.Text = Strings.Format(subTotal * VATRateDecimal, "C");
                        withBlock.Cell(4, 5).Range.Text = Strings.Format((subTotal * VATRateDecimal) + subTotal, "C");

                        {
                            var withBlock1 = withBlock.Rows;
                            withBlock1.WrapAroundText = true;
                            withBlock1.HorizontalPosition = Word.WdTablePosition.wdTableLeft;
                            withBlock1.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn;
                            withBlock1.DistanceLeft = MsWordApp.CentimetersToPoints(0.32);
                            withBlock1.DistanceRight = MsWordApp.CentimetersToPoints(0.32);
                            withBlock1.VerticalPosition = Word.WdTablePosition.wdTableBottom;
                            withBlock1.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
                            withBlock1.DistanceTop = MsWordApp.CentimetersToPoints(0);
                            withBlock1.DistanceBottom = MsWordApp.CentimetersToPoints(0);
                            withBlock1.AllowOverlap = false;
                        }

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(2, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(3, 5).Range);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(withBlock.Cell(4, 5).Range);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool QCPrint()
            {
                switch (Helper.MakeIntegerValid(DetailsToPrint(1)))
                {
                    case object _ when System.Convert.ToInt32(Enums.AdditionalChecksTypes.WorkInProgressAuditDomGASWork):
                        {
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\WIP Audit Domestic Gas Work.dot");
                            break;
                        }

                    case object _ when System.Convert.ToInt32(Enums.AdditionalChecksTypes.PostCompleteAuditDomWork):
                        {
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\Post Complete Audit Domestic Work.dot");
                            break;
                        }

                    case object _ when System.Convert.ToInt32(Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork):
                        {
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\WIP Audit Domestic Oil Work.dot");
                            break;
                        }

                    case object _ when System.Convert.ToInt32(Enums.AdditionalChecksTypes.WorkInProgressAuditCommercialGASWork):
                        {
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\WIP Audit Commercial Gas Work.dot");
                            break;
                        }

                    case object _ when System.Convert.ToInt32(Enums.AdditionalChecksTypes.ElectricalAudit):
                        {
                            WordDoc = MsWordApp.Documents.Add(Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\ElectricalQC.dot");
                            break;
                        }
                }

                EngineerVisitAdditionals.EngineerVisitAdditional add = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(DetailsToPrint(0), DetailsToPrint(1));

                if (add.Test125 == 0)
                    add.SetTest125 = 53;
                Engineers.Engineer eng = DB.Engineer.Engineer_Get(System.Convert.ToInt32(add.Test125));
                DataTable engv = DB.EngineerVisits.EngineerVisits_Get(DetailsToPrint(0)).Table;
                Engineers.Engineer auitor = DB.Engineer.Engineer_Get(System.Convert.ToInt32(engv(0)("EngineerID")));
                Sites.Site address = DB.Sites.Get(DetailsToPrint(0), Sites.SiteSQL.GetBy.EngineerVisitId);
                Jobs.Job job = DB.Job.Job_Get_For_An_EngineerVisit_ID(DetailsToPrint(0));
                Customers.Customer customer = DB.Customer.Customer_Get(address.CustomerID);

                try
                {
                    foreach (System.Text.RegularExpressions.Match wordField in GetTemplateFields(WordDoc.Content.Text))
                    {
                        switch (wordField.Value.ToLower())
                        {
                            case object _ when "[Client]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(customer.Name));
                                    break;
                                }

                            case object _ when "[UPRN]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(address.PolicyNumber));
                                    break;
                                }

                            case object _ when "[Project]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(add.Test1).Name));
                                    break;
                                }

                            case object _ when "[Address]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(address.Address1 + ", " + address.Address2 + ", " + address.Address3 + ", " + address.Postcode));
                                    break;
                                }

                            case object _ when "[Type]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(add.Test237).Name));
                                    break;
                                }

                            case object _ when "[eng]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.Name));
                                    break;
                                }

                            case object _ when "[ename]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.Name));
                                    break;
                                }

                            case object _ when "[CompletedBy]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.Name));
                                    break;
                                }

                            case object _ when "[aname]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(auitor.Name));
                                    break;
                                }

                            case object _ when "[QCBy]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(auitor.Name));
                                    break;
                                }

                            case object _ when "[sum]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(engv(0)("OutcomeDetails")));
                                    break;
                                }

                            case object _ when "[jn]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(add.Test238));
                                    break;
                                }

                            case object _ when "[gs]".ToLower():
                                {
                                    if (DetailsToPrint(1) == (int)Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork | address.SiteFuel == "Oil")
                                        ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.OftecNo));
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(eng.GasSafeNo));
                                    break;
                                }

                            case object _ when "[date]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(Format(engv(0)("StartDateTime"), "dd/MM/yyyy")));
                                    break;
                                }

                            case object _ when "[date2]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(Format(engv(0)("StartDateTime"), "dd/MM/yyyy")));
                                    break;
                                }

                            case object _ when "[outcome]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(add.Test124).Name));
                                    break;
                                }

                            case object _ when "[add]".ToLower():
                                {
                                    string strings = address.Address1 + ", " + Constants.vbNewLine + address.Address2 + ", " + Constants.vbNewLine + Sys.Helper.FormatPostcode(address.Postcode);
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(strings));
                                    break;
                                }

                            case object _ when "[Make]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test235);
                                    break;
                                }

                            case object _ when "[Model]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test236);
                                    break;
                                }

                            case object _ when "[1]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test1).Name);
                                    break;
                                }

                            case object _ when "[2]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test2).Name);
                                    break;
                                }

                            case object _ when "[3]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test3).Name);
                                    break;
                                }

                            case object _ when "[4]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test4).Name);
                                    break;
                                }

                            case object _ when "[5]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test5).Name);
                                    break;
                                }

                            case object _ when "[6]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test6).Name);
                                    break;
                                }

                            case object _ when "[7]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test7).Name);
                                    break;
                                }

                            case object _ when "[8]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test8).Name);
                                    break;
                                }

                            case object _ when "[9]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test9).Name);
                                    break;
                                }

                            case object _ when "[10]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test10).Name);
                                    break;
                                }

                            case object _ when "[1a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test111).Name);
                                    break;
                                }

                            case object _ when "[2a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test2).Name);
                                    break;
                                }

                            case object _ when "[3a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test3).Name);
                                    break;
                                }

                            case object _ when "[4a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test4).Name);
                                    break;
                                }

                            case object _ when "[5a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test5).Name);
                                    break;
                                }

                            case object _ when "[6a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test6).Name);
                                    break;
                                }

                            case object _ when "[7a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test7).Name);
                                    break;
                                }

                            case object _ when "[8a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test8).Name);
                                    break;
                                }

                            case object _ when "[9a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test9).Name);
                                    break;
                                }

                            case object _ when "[10a]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test10).Name);
                                    break;
                                }

                            case object _ when "[11]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test111).Name);
                                    break;
                                }

                            case object _ when "[12]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test112).Name);
                                    break;
                                }

                            case object _ when "[13]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test113).Name);
                                    break;
                                }

                            case object _ when "[14]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test114).Name);
                                    break;
                                }

                            case object _ when "[15]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test115).Name);
                                    break;
                                }

                            case object _ when "[16]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test116).Name);
                                    break;
                                }

                            case object _ when "[17]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test117).Name);
                                    break;
                                }

                            case object _ when "[18]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test118).Name);
                                    break;
                                }

                            case object _ when "[19]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test119).Name);
                                    break;
                                }

                            case object _ when "[20]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test120).Name);
                                    break;
                                }

                            case object _ when "[21]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test121).Name);
                                    break;
                                }

                            case object _ when "[22]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test122).Name);
                                    break;
                                }

                            case object _ when "[23]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, DB.Picklists.Get_One_As_Object(add.Test123).Name);
                                    break;
                                }

                            case object _ when "[c1]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test11);
                                    break;
                                }

                            case object _ when "[c2]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test12);
                                    break;
                                }

                            case object _ when "[c3]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test13);
                                    break;
                                }

                            case object _ when "[c4]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test14);
                                    break;
                                }

                            case object _ when "[c5]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test15);
                                    break;
                                }

                            case object _ when "[c6]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test216);
                                    break;
                                }

                            case object _ when "[c7]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test217);
                                    break;
                                }

                            case object _ when "[c8]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test218);
                                    break;
                                }

                            case object _ when "[c9]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test219);
                                    break;
                                }

                            case object _ when "[c10]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test220);
                                    break;
                                }

                            case object _ when "[c11]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test221);
                                    break;
                                }

                            case object _ when "[c12]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test222);
                                    break;
                                }

                            case object _ when "[c13]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test223);
                                    break;
                                }

                            case object _ when "[c14]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test224);
                                    break;
                                }

                            case object _ when "[c15]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test225);
                                    break;
                                }

                            case object _ when "[c16]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test226);
                                    break;
                                }

                            case object _ when "[c17]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test227);
                                    break;
                                }

                            case object _ when "[c18]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test228);
                                    break;
                                }

                            case object _ when "[c19]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test229);
                                    break;
                                }

                            case object _ when "[c20]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test230);
                                    break;
                                }

                            case object _ when "[c21]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test231);
                                    break;
                                }

                            case object _ when "[c22]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test232);
                                    break;
                                }

                            case object _ when "[c23]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, add.Test233);
                                    break;
                                }
                        }
                    }

                    if (!engv(0)("EngineerSignature") == null)
                    {
                        byte[] es = engv(0)("EngineerSignature");
                        Bitmap engSig = new Bitmap(new System.IO.MemoryStream(es));
                        engSig.Save(Application.StartupPath + @"\TEMP\EngSig.bmp");
                        if (DetailsToPrint(1) != (int)Enums.AdditionalChecksTypes.ElectricalAudit)
                            WordDoc.Bookmarks.Item("asig").Range.InlineShapes.AddPicture(Application.StartupPath + @"\Temp\EngSig.bmp");
                    }

                    if (!engv(0)("CustomerSignature") == null)
                    {
                        byte[] cs = engv(0)("CustomerSignature");
                        Bitmap custSig = new Bitmap(new System.IO.MemoryStream(cs));
                        custSig.Save(Application.StartupPath + @"\TEMP\CustSig.bmp");
                        if (DetailsToPrint(1) != (int)Enums.AdditionalChecksTypes.ElectricalAudit)
                            WordDoc.Bookmarks.Item("esig").Range.InlineShapes.AddPicture(Application.StartupPath + @"\Temp\CustSig.bmp");
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateContractExpiry(DataRow dr, int tblIndex)
            {
                try
                {
                    foreach (System.Text.RegularExpressions.Match wordField in GetTemplateFields(WordDoc.Content.Text))
                    {
                        switch (wordField.Value.ToLower())
                        {
                            case object _ when "[Address1]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address1")));
                                    break;
                                }

                            case object _ when "[Address2]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address2")));
                                    break;
                                }

                            case object _ when "[Address3]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address3")));
                                    break;
                                }

                            case object _ when "[Address4]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address4")));
                                    break;
                                }

                            case object _ when "[Address5]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Address5")));
                                    break;
                                }

                            case object _ when "[Postcode]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.FormatPostcode(dr("Postcode")));
                                    break;
                                }

                            case object _ when "[Date]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Strings.Format(DateTime.Now, "dd/MM/yyyy"));
                                    break;
                                }

                            case object _ when "[CompanyName]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("Name")));
                                    break;
                                }

                            case object _ when "[ExpiryDate]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Strings.Format(Sys.Helper.MakeDateTimeValid(dr("ContractEndDate")), "dd/MM/yyyy"));
                                    break;
                                }

                            case object _ when "[user]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, loggedInUser.Fullname);
                                    break;
                                }

                            case object _ when "[ContractType]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("ContractType")));
                                    break;
                                }

                            case object _ when "[ContractReference]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("ContractReference")));
                                    break;
                                }

                            case object _ when "[SiteAddress1]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.MakeStringValid(dr("SiteAddress1")));
                                    break;
                                }

                            case object _ when "[PriceSentence]".ToLower():
                                {
                                    string strSentence = "";

                                    strSentence = DB.Picklists.Get_Single_Description(dr("ContractType"), Enums.PickListTypes.ContractPricing);
                                    ReplaceText(ref WordDoc, wordField.Value, strSentence);
                                    break;
                                }

                            case object _ when "[ExcludeSentence]".ToLower():
                                {
                                    string strSentence = "";

                                    if (dr("ContractType") == "Gold Star" | dr("ContractType") == "Platinum Star")
                                        strSentence = "Please be advised that we are now offering cover for boilermates or any other make of thermal store product as an additional appliance. Should you have a thermal store product";
                                    // in your property and require cover, this could be added for an additional £109.34 per annum

                                    ReplaceText(ref WordDoc, wordField.Value, strSentence);
                                    break;
                                }

                            case object _ when "[ExcludeSentence2]".ToLower():
                                {
                                    string strSentence = "";

                                    if (dr("ContractType") == "Gold Star")
                                        strSentence = " in your property and require cover, this could be added for an additional " + Format(System.Convert.ToDouble(DB.Picklists.Get_Single_Description("Additional Appliance", 52)), "C") + " per annum.";

                                    if (dr("ContractType") == "Platinum Star")
                                        strSentence = " in your property and require cover, this could be added for an additional " + Format(System.Convert.ToDouble(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52)), "C") + " per annum.";

                                    ReplaceText(ref WordDoc, wordField.Value, strSentence);
                                    break;
                                }

                            case object _ when "[AHE]".ToLower():
                                {
                                    string strSentence = DB.Picklists.Get_Single_Description("AHE", 52);
                                    ReplaceText(ref WordDoc, wordField.Value, strSentence);
                                    break;
                                }
                        }
                    }

                    {
                        var withBlock = WordDoc.Tables.Item(tblIndex);
                        if (Sys.Helper.MakeBooleanValid(dr("DirectDebit")) == true)
                            withBlock.Cell(2, 1).Delete();
                        else
                            withBlock.Cell(1, 1).Delete();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateDomesticGSRDue(DataRow[] dr, DataTable dtPrinted, string savePath, WordprocessingDocument batch = null/* TODO Change to default(_) if this is not a reference type */)
            {
                try
                {
                    string template = Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\GSRDue.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr[0]("SiteID")));
                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            ContractsOriginal.ContractOriginal currentContract = DB.ContractOriginal.Get_Current_ForSite(dr[0]("SiteID"));
                            if (currentContract == null)
                            {
                                PrintHelper.DeleteBookmark(wordDoc, "OnContract1");
                                PrintHelper.DeleteBookmark(wordDoc, "StarMainMessage");

                                DataView dvOnContractAppliances = DB.Asset.Asset_GetForSite(dr[0]("SiteID"));
                                DataTable dt = new DataTable();
                                dt.Columns.Add("Appliance");

                                foreach (DataRowView ddr in dvOnContractAppliances)
                                {
                                    if (Helper.MakeBooleanValid(ddr("Active")))
                                    {
                                        DataRow nr;
                                        nr = dt.NewRow;
                                        nr("Appliance") = ddr("Product");
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
                                DataView dvOnContractAppliances = DB.ContractOriginal.ContractOriginalSiteAsset_GetAll_SiteID(dr[0]("SiteID"));
                                DataTable dt = new DataTable();
                                dt.Columns.Add("Appliance");

                                foreach (DataRowView ddr in dvOnContractAppliances)
                                {
                                    DataRow nr;
                                    nr = dt.NewRow;
                                    nr("Appliance") = ddr("Appliance");
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
                            PrintHelper.ReplaceText(wordDoc, "[Tenant]", Sys.Helper.MakeStringValid(dr[0]("Tenant")));
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", dr[0]("Address1"));
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", dr[0]("Address2"));
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", dr[0]("Address3"));
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Sys.Helper.FormatPostcode(dr[0]("Postcode")));
                            PrintHelper.ReplaceText(wordDoc, "[Date]", DateTime.Now.ToShortDateString());
                            PrintHelper.ReplaceText(wordDoc, "[NextServiceDate]", Strings.Format(Sys.Helper.MakeDateTimeValid(dr[0]("VisitDate")).AddYears(1), "dd/MM/yyyy"));
                            wordDoc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), wordDoc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            wordDoc.MainDocumentPart.Document.Save();
                        }

                        savePath = FileCheck(savePath);
                        FileStream fileStream = new FileStream(savePath, System.IO.FileMode.CreateNew);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);

                        foreach (DataRow r in dr)
                        {
                            DataRow ar = dtPrinted.NewRow;
                            ar("AssetID") = r("AssetID");
                            ar("DateDue") = r("DueDate");
                            dtPrinted.Rows.Add(ar);
                        }

                        if (!batch == null)
                        {
                            MainDocumentPart mainPart = batch.MainDocumentPart;
                            string altChunkId = "AltId" + Helper.MakeIntegerValid(dr[0]("SiteID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                            AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            mm.Position = 0;

                            using (mm)
                                chunk.FeedData(mm);

                            WP.AltChunk altChunk = new WP.AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                            mainPart.Document.Save();
                        }
                        else
                            Process.Start(savePath);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateLLGSRDue(DataRow[] dr, DataTable dtPrinted, string savePath, WordprocessingDocument batch = null/* TODO Change to default(_) if this is not a reference type */)
            {
                try
                {
                    string template = Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\GSRDueLL.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr[0]("SiteID")));
                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            DataTable dt = new DataTable();
                            dt.Columns.Add("Property");
                            dt.Columns.Add("Service Due Date");
                            dt.Columns.Add("Appliance");

                            int lastSiteId = 0;
                            foreach (DataRow r in dr)
                            {
                                DataRow nr;
                                nr = dt.NewRow;
                                if (lastSiteId != r("SiteID"))
                                    nr("Property") = r("Tenant") + ", " + r("Address1") + ", " + r("Address2") + ", " + Sys.Helper.FormatPostcode(r("Postcode"));
                                nr("Service Due Date") = Strings.Format(Sys.Helper.MakeDateTimeValid(r("DueDate")).AddYears(1), "dd-MMM-yyyy");
                                nr("Appliance") = r("Appliance");
                                dt.Rows.Add(nr);
                                lastSiteId = r("SiteID");
                            }

                            PrintHelper.ReplaceBookmarkWithTable(wordDoc, "SitesAndAppliances", dt);
                            Sites.Site selHQ = DB.Sites.Get(dr[0]("CustomerID"), Sites.SiteSQL.GetBy.CustomerHq);
                            if (selHQ == null)
                                return false;
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[CustomerName]", Sys.Helper.MakeStringValid(dr[0]("CustomerName")));
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", selHQ.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", selHQ.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", selHQ.Address3);
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Sys.Helper.FormatPostcode(selHQ.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[Date]", DateTime.Now.ToShortDateString());
                            wordDoc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), wordDoc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            wordDoc.MainDocumentPart.Document.Save();
                        }

                        savePath = FileCheck(savePath);
                        FileStream fileStream = new FileStream(savePath, System.IO.FileMode.CreateNew);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);

                        foreach (DataRow r in dr)
                        {
                            DataRow ar = dtPrinted.NewRow;
                            ar("AssetID") = r("AssetID");
                            ar("DateDue") = r("DueDate");
                            dtPrinted.Rows.Add(ar);
                        }

                        if (!batch == null)
                        {
                            MainDocumentPart mainPart = batch.MainDocumentPart;
                            string altChunkId = "AltId" + Helper.MakeIntegerValid(dr[0]("SiteID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                            AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            mm.Position = 0;

                            using (mm)
                                chunk.FeedData(mm);

                            WP.AltChunk altChunk = new WP.AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                            mainPart.Document.Save();
                        }
                        else
                            Process.Start(savePath);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GSR(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, DataView dvFaults, bool printHeader, DataView GSRS, string template, string savePath, Enums.WorksheetFuelTypes Fuel, string goldenRule, List<byte[]> fullDocument = null, bool NCCTemplate = false)
            {
                try
                {
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    int imageIndex = 100;
                    Sites.Site oSiteHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;

                    int noOfRowsPerPage = 4; // as most pages have 4
                    switch (Fuel)
                    {
                        case object _ when Enums.WorksheetFuelTypes.Unvented:
                            {
                                noOfRowsPerPage = 12;
                                break;
                            }

                        case object _ when Enums.WorksheetFuelTypes.Oil:
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
                    List<int> pageNumbers = new List<int>();
                    pageNumbers.Add(Math.Ceiling(GSRS.Table.Rows.Count / (double)noOfRowsPerPage));

                    int pages = pageNumbers.Max();
                    if (pages < 1)
                        pages = 1;
                    try
                    {
                        // gsr
                        for (int page = 1; page <= pages; page++)
                        {
                            int lowAppIndex = (page * noOfRowsPerPage) - noOfRowsPerPage;
                            int highAppIndex = page * noOfRowsPerPage;

                            byte[] finaldoc = null;
                            byte[] byteArray = File.ReadAllBytes(template);
                            MemoryStream mm = new MemoryStream();
                            using ((mm))
                            {
                                mm.Write(byteArray, 0, byteArray.Length);
                                WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                                using ((wordDoc))
                                {
                                    PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                                    if (engineer == null)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", "");
                                    else if (Fuel == Enums.WorksheetFuelTypes.Oil)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", engineer.OftecNo);
                                    else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafeIDNo", engineer.GasSafeNo);

                                    string uid = oEngineerVisit.EngineerVisitID + "_" + DateTime.Now.ToString("ddMMyyyyhhmm") + "_" + Fuel.ToString().ToUpper();
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobSiteName", oSite.Name.Replace("T1", "").Trim(), "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress1", oSite.Address1, "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress2", oSite.Address2, "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobAddress3", oSite.Address3, "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobPostCode", Helper.FormatPostcode(oSite.Postcode), "8");
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate", uid, "6", true);
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate1", visitDate.ToLongDateString());
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate2", visitDate.ToLongDateString());

                                    AddCompanyDetails(wordDoc, true);

                                    if (oEngineerVisit.GasServiceCompleted == true & oEngineerVisit.OutcomeEnumID != Enums.EngineerVisitOutcomes.Complete)
                                    {
                                        Customers.Customer customer = DB.Customer.Customer_Get_ForSiteID(oSite.SiteID);
                                        bool motstyle = false;
                                        if (customer != null && customer.MOTStyleService == true)
                                            motstyle = true;

                                        DateTime actualServiceDate;
                                        if (oEngineerVisit.StartDateTime == DateTime.MinValue)
                                        {
                                            if (oEngineerVisit.TimeSheets.Table.Rows.Count > 0)
                                                actualServiceDate = oEngineerVisit.TimeSheets.Table.Rows(0).Item("StartDateTime");
                                            else
                                                actualServiceDate = DateTime.Now();
                                        }
                                        else
                                            actualServiceDate = oEngineerVisit.StartDateTime;

                                        DateTime oldLastServiceDate = default(DateTime);
                                        DateTime lastServiceDate = default(DateTime);
                                        // update all

                                        oldLastServiceDate = Helper.MakeDateTimeValid(oSite.LastServiceDate);
                                        int sfServiceDiff = DateTime.DateDiff(DateInterval.Month, actualServiceDate, oldLastServiceDate.AddYears(1));
                                        if (oldLastServiceDate.AddYears(1) > actualServiceDate & sfServiceDiff >= 0 & sfServiceDiff <= 2 & motstyle)
                                            lastServiceDate = oldLastServiceDate.AddYears(1);
                                        else
                                            lastServiceDate = actualServiceDate;

                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", lastServiceDate.AddYears(1).ToLongDateString());
                                    }
                                    else if (oEngineerVisit.GasServiceCompleted == true & oEngineerVisit.OutcomeEnumID == Enums.EngineerVisitOutcomes.Complete & oEngineerVisit.VisitLocked)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", oSite.LastServiceDate.AddYears(1).ToLongDateString);
                                    else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "NextServiceDue", visitDate.AddYears(1).ToLongDateString());

                                    PickLists.PickList selected = DB.Picklists.Get_One_As_Object(oEngineerVisit.SignatureSelectedID);
                                    if (selected == null)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "JobCustomerName", oEngineerVisit.CustomerName);
                                    else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "JobCustomerName", oEngineerVisit.CustomerName + " (" + selected.Name + ")");

                                    if (!oSiteHQ == null)
                                    {
                                        string strAddress = string.Empty;

                                        if (oSiteHQ.Address1.Length > 0)
                                            strAddress += oSiteHQ.Address1 + ", ";

                                        if (oSiteHQ.Address2.Length > 0)
                                            strAddress += oSiteHQ.Address2 + ", ";

                                        if (strAddress.Length > 0)
                                            strAddress = strAddress.Substring(0, strAddress.Length - 2);

                                        string strAddress1 = string.Empty;

                                        if (oSiteHQ.Address3.Length > 0)
                                            strAddress1 += oSiteHQ.Address3 + ", ";

                                        if (oSiteHQ.Address4.Length > 0)
                                            strAddress1 += oSiteHQ.Address4 + ", ";

                                        if (oSiteHQ.Address5.Length > 0)
                                            strAddress1 += oSiteHQ.Address5 + ", ";

                                        if (strAddress.Length > 0 & strAddress1.Length > 1)
                                            strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);

                                        string customerName = oSiteHQ.CustomerID != Enums.Customer.Domestic ? DB.Customer.Customer_Get(oSite.CustomerID).Name : "";

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

                                    PickLists.PickList propRented = DB.Picklists.Get_One_As_Object(oEngineerVisit.PropertyRented);
                                    if (propRented == null)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rented", "");
                                    else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rented", propRented.Name, "8");

                                    if (engineer == null)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", "");
                                    else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", engineer.Name);

                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustomerName", oEngineerVisit.CustomerName);
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "OtherNotes", oEngineerVisit.OutcomeDetails);

                                    switch (Fuel)
                                    {
                                        case object _ when Enums.WorksheetFuelTypes.Gas:
                                        case object _ when Enums.WorksheetFuelTypes.Oil:
                                        case object _ when Enums.WorksheetFuelTypes.Other:
                                        case object _ when Enums.WorksheetFuelTypes.Unvented:
                                            {
                                                if (GSRS.Table.Rows.Count == 0)
                                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", "0", "8");
                                                else
                                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", GSRS.Table.Select("ApplianceTested='Yes'").Length, "8");
                                                break;
                                            }

                                        default:
                                            {
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "NoOfAppliances", GSRS.Table.Rows.Count, "8");
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "NumInspected", GSRS.Table.Rows.Count, "8");
                                                break;
                                            }
                                    }

                                    DataView COMO = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.COMOAlarm);
                                    DataView SMOKE = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SmokeAlarm);

                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "COMO", COMO.Count.ToString);
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "SMOKE", SMOKE.Count.ToString);

                                    if (Fuel == Enums.WorksheetFuelTypes.Gas)
                                    {
                                        PickLists.PickList ecv = DB.Picklists.Get_One_As_Object(oEngineerVisit.EmergencyControlAccessibleID);
                                        if (ecv == null)
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "ECV", "");
                                        else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "ECV", ecv.Name);
                                        PickLists.PickList tightest = DB.Picklists.Get_One_As_Object(oEngineerVisit.GasInstallationTightnessTestID);
                                        if (tightest == null)
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "tightest", "");
                                        else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "tightest", tightest.Name);
                                        PickLists.PickList bonding = DB.Picklists.Get_One_As_Object(oEngineerVisit.BondingID);
                                        if (bonding == null)
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Bonding", "");
                                        else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Bonding", bonding.Name);
                                    }
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "WorkCarriedOut", oEngineerVisit.OutcomeDetails);
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "JobVisitNumber", oEngineerVisit.EngineerVisitID, "9", true);

                                    if (oEngineerVisit.EngineerSignature == null)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EngineerSignature", "");
                                    else
                                    {
                                        Bitmap engSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.EngineerSignature));
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

                                    if (oEngineerVisit.CustomerSignature == null)
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CustomerSignature", "");
                                    else
                                    {
                                        Bitmap custSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.CustomerSignature));
                                        string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                        PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustomerSignature", custSig, imgSavePath, imageIndex);
                                        imageIndex += 1;
                                    }

                                    if (GSRS.Table.Rows.Count == 0 || IsDBNull(GSRS.Table.Rows(0)("ReadingType")))
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "GasSafe", "7939");
                                    else
                                        switch (Helper.MakeIntegerValid(GSRS.Table.Rows(0)("ReadingType")))
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

                                    byte[] logo = null;
                                    try
                                    {
                                        logo = DB.ExecuteScalar("Select Logo FROM tblCustomer where CustomerID = " + oSite.CustomerID);
                                    }
                                    catch
                                    {
                                        logo = null;
                                    }

                                    if (logo != null)
                                    {
                                        Bitmap custLogo = new Bitmap(new System.IO.MemoryStream(logo));
                                        string imgSavePath = Application.StartupPath + @"\TEMP\custLogo.jpg";
                                        PrintHelper.ReplaceBookmarkWithImage(wordDoc, "Logo", custLogo, imgSavePath, imageIndex);
                                        imageIndex += 1;
                                    }
                                    else
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Logo", "");

                                    if (NCCTemplate)
                                    {
                                        if (oSite.LeaseHold == true)
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "Leaseholder", "8");
                                        else
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "Tenanted", "8");
                                    }

                                    // TO BE REMOVED AFTER APPROVAL - CONFIRM WITH YF
                                    if (!oEngineerVisit.EngineerVisitNCCGSR == null)
                                    {
                                        DataView dvNccGsr = DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_Get_Friendly(oEngineerVisit.EngineerVisitNCCGSR.EngineerVisitNCCGSRID);
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Rad", oEngineerVisit.EngineerVisitNCCGSR.Radiators);
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Age", oEngineerVisit.EngineerVisitNCCGSR.ApproxAgeOfBoiler);
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info1", Helper.MakeStringValid(dvNccGsr(0)("CorrectMaterialsUsed")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info2", Helper.MakeStringValid(dvNccGsr(0)("InstallationPipeWorkCorrect")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Info3", Helper.MakeStringValid(dvNccGsr(0)("InstallationSafeToUse")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SF", Helper.MakeStringValid(dvNccGsr(0)("StrainerFitted")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SI", Helper.MakeStringValid(dvNccGsr(0)("StrainerInspected")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "HST", Helper.MakeStringValid(dvNccGsr(0)("HeatingSystemType")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "PH", Helper.MakeStringValid(dvNccGsr(0)("PartialHeating")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CT", Helper.MakeStringValid(dvNccGsr(0)("CylinderType")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Jack", Helper.MakeStringValid(dvNccGsr(0)("Jacket")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Im", Helper.MakeStringValid(dvNccGsr(0)("Immersion")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CO", Helper.MakeStringValid(dvNccGsr(0)("CODetectorFitted")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "FL", Helper.MakeStringValid(dvNccGsr(0)("FillDisc")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SIT", Helper.MakeStringValid(dvNccGsr(0)("SITimer")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CertType", Helper.MakeStringValid(dvNccGsr(0)("CertificateType")));
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

                                        int lowIndex = (page * 2) - 2;
                                        int highIndex = page * 2;
                                        try
                                        {
                                            try
                                            {
                                                List<int> assetIds = (from r in dtAppliances.AsEnumerable()
                                                                      select r.Field<int>("AssetID")).ToList();
                                                dtFaults = dvFaults.Table.AsEnumerable().Where((row, index) => assetIds.Contains(Helper.MakeStringValid(row("AssetID")))).CopyToDataTable();

                                                try
                                                {
                                                    DataRow[] drSiteFaults = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0");
                                                    if (drSiteFaults.Length > 0)
                                                        dtFaults.Merge(drSiteFaults.CopyToDataTable().AsEnumerable().Where((row, index) => index >= lowIndex & index < highIndex).CopyToDataTable());
                                                }
                                                catch (Exception ex)
                                                {
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
                                                DataTable siteFaults = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0").CopyToDataTable();
                                                dtFaults.Merge(siteFaults.AsEnumerable().Where((row, index) => index >= lowIndex & index < highIndex).CopyToDataTable());
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            dtFaults = new DataTable();
                                        }

                                        int appCount = dtAppliances != null ? dtAppliances.Rows.Count : 0;

                                        AddAppliancesBatch(wordDoc, appCount, dtAppliances, dtFaults, false, System.Convert.ToInt32(Fuel));
                                    }

                                    if (Fuel == Enums.WorksheetFuelTypes.Unvented)
                                    {
                                        AddAppliancesBatch(wordDoc, GSRS.Table.Rows.Count, GSRS.Table, dvFaults.Table, false, System.Convert.ToInt32(Fuel));

                                        EngineerVisitAdditionals.EngineerVisitAdditional ad = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialCateringCP42);
                                        if (ad != null)
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

                            List<byte[]> docsToMerge = new List<byte[]>();
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
                                docsToMerge.Add(LsrHeaderLetter(oSite, oSiteHQ, visitDate, null/* TODO Change to default(_) if this is not a reference type */)?.ToArray());

                            finaldoc = PrintHelper.CombineDocs(docsToMerge);

                            savePath = FileCheck(savePath);

                            if (finaldoc != null)
                                fullDocument.Add(finaldoc);
                            else
                            {
                                FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                mm.Position = 0;
                                using ((fileStream))
                                    mm.WriteTo(fileStream);
                            }
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                }
            }

            private byte[] AddLgsrSupplementaryInformation(EngineerVisits.EngineerVisit engineerVisit, DataView dvDefects, int siteId, int pageNo)
            {
                byte[] doc = null;
                string template = Application.StartupPath + @"\Templates\GSR\LGSR_Supplementary_Info.docx";
                string cGoldenRule = GetDocumentGoldenRule(template, siteId);
                byte[] cbyteArray = File.ReadAllBytes(template);
                MemoryStream cmm = new MemoryStream();
                using ((cmm))
                {
                    cmm.Write(cbyteArray, 0, cbyteArray.Length);
                    WordprocessingDocument wordDoc = WordprocessingDocument.Open(cmm, true);
                    using ((wordDoc))
                    {
                        PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", cGoldenRule);

                        DataTable dt = new DataTable();
                        dt.Columns.Add("Appliance");
                        dt.Columns.Add("Category");
                        dt.Columns.Add("Reason");
                        dt.Columns.Add("Action Taken");
                        dt.Columns.Add("Comments");

                        if (dvDefects.Count > 0)
                        {
                            foreach (DataRow r in dvDefects.Table.Select("", "AssetID DESC"))
                            {
                                DataRow nr;
                                nr = dt.NewRow;
                                nr("Appliance") = r("typemakemodel");
                                nr("Category") = r("Category");
                                nr("Reason") = r("Reason");
                                nr("Action Taken") = r("ActionTaken");
                                nr("Comments") = r("Comments");
                                dt.Rows.Add(nr);
                            }
                        }

                        if (dt.Rows.Count > 0)
                        {
                            PrintHelper.AddRowsToTable(wordDoc, "[NCS]", dt, "Arial", "14");
                            PrintHelper.ReplaceText(wordDoc, "[NoDefects]", string.Empty);
                        }
                        else
                        {
                            PrintHelper.DeleteTableBookmark(wordDoc, "[NCS]");
                            PrintHelper.ReplaceText(wordDoc, "[NoDefects]", "NO DEFECTS RECORDED");
                        }

                        if (pageNo == 1)
                        {
                            if (!Helper.IsStringEmpty(engineerVisit.OutcomeDetails))
                                PrintHelper.ReplaceText(wordDoc, "[EngineerNotes]", engineerVisit.OutcomeDetails);
                            else
                                PrintHelper.DeleteTableBookmark(wordDoc, "[EngineerNotes]");

                            DataView COMO = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(engineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.COMOAlarm);
                            DataView SMOKE = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(engineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SmokeAlarm);

                            PrintHelper.ReplaceText(wordDoc, "[Como]", COMO.Count.ToString);
                            PrintHelper.ReplaceText(wordDoc, "[Smoke]", SMOKE.Count.ToString);

                            DataView dvNccGsr = DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_Get_Friendly(engineerVisit.EngineerVisitNCCGSR?.EngineerVisitNCCGSRID);
                            if (dvNccGsr?.Count > 0 && Helper.MakeIntegerValid(dvNccGsr(0)("CorrectMaterialsUsedID")) > 0)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[Rad]", Helper.MakeStringValid(dvNccGsr(0)("Radiators")));
                                PrintHelper.ReplaceText(wordDoc, "[Age]", Helper.MakeStringValid(dvNccGsr(0)("ApproxAgeOfBoiler")));
                                PrintHelper.ReplaceText(wordDoc, "[Info1]", Helper.MakeStringValid(dvNccGsr(0)("CorrectMaterialsUsed")));
                                PrintHelper.ReplaceText(wordDoc, "[Info2]", Helper.MakeStringValid(dvNccGsr(0)("InstallationPipeWorkCorrect")));
                                PrintHelper.ReplaceText(wordDoc, "[Info3]", Helper.MakeStringValid(dvNccGsr(0)("InstallationSafeToUse")));
                                PrintHelper.ReplaceText(wordDoc, "[SF]", Helper.MakeStringValid(dvNccGsr(0)("StrainerFitted")));
                                PrintHelper.ReplaceText(wordDoc, "[SI]", Helper.MakeStringValid(dvNccGsr(0)("StrainerInspected")));
                                PrintHelper.ReplaceText(wordDoc, "[HST]", Helper.MakeStringValid(dvNccGsr(0)("HeatingSystemType")));
                                PrintHelper.ReplaceText(wordDoc, "[PH]", Helper.MakeStringValid(dvNccGsr(0)("PartialHeating")));
                                PrintHelper.ReplaceText(wordDoc, "[CT]", Helper.MakeStringValid(dvNccGsr(0)("CylinderType")));
                                PrintHelper.ReplaceText(wordDoc, "[Jack]", Helper.MakeStringValid(dvNccGsr(0)("Jacket")));
                                PrintHelper.ReplaceText(wordDoc, "[IM]", Helper.MakeStringValid(dvNccGsr(0)("Immersion")));
                                PrintHelper.ReplaceText(wordDoc, "[CO]", Helper.MakeStringValid(dvNccGsr(0)("CODetectorFitted")));
                                PrintHelper.ReplaceText(wordDoc, "[FL]", Helper.MakeStringValid(dvNccGsr(0)("FillDisc")));
                                PrintHelper.ReplaceText(wordDoc, "[SIT]", Helper.MakeStringValid(dvNccGsr(0)("SITimer")));
                                PrintHelper.ReplaceText(wordDoc, "[CertType]", Helper.MakeStringValid(dvNccGsr(0)("CertificateType")));
                            }
                            else
                                PrintHelper.DeleteTableBookmark(wordDoc, "[NCC]");
                        }
                        else
                        {
                            PrintHelper.DeleteTableBookmark(wordDoc, "[EngineerNotes]");
                            PrintHelper.DeleteTableBookmark(wordDoc, "[Como]");
                            PrintHelper.DeleteTableBookmark(wordDoc, "[NCC]");
                        }

                        WP.Paragraph para = wordDoc.MainDocumentPart.Document.Body.ChildElements.First<WP.Paragraph>();
                        if (para.ParagraphProperties == null)
                            para.ParagraphProperties = new WP.ParagraphProperties();
                        para.ParagraphProperties.PageBreakBefore = new WP.PageBreakBefore();
                        wordDoc.MainDocumentPart.Document.Save();

                        doc = cmm.ToArray();
                    }
                }
                return doc;
            }

            public byte[] LsrHeaderLetter(Sites.Site oSite, Sites.Site oSiteHq, DateTime visitDate, MemoryStream mm)
            {
                byte[] finalDoc = null;
                if (oSiteHq == null)
                    oSiteHq = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                string coverLetterTemplate = Application.StartupPath + @"\Templates\GSR\GSRCoveringLetter.docx";
                string cGoldenRule = GetDocumentGoldenRule(coverLetterTemplate, oSite.SiteID);
                byte[] cbyteArray = File.ReadAllBytes(coverLetterTemplate);
                MemoryStream cmm = new MemoryStream();
                using ((cmm))
                {
                    cmm.Write(cbyteArray, 0, cbyteArray.Length);
                    WordprocessingDocument cwordDoc = WordprocessingDocument.Open(cmm, true);
                    using ((cwordDoc))
                    {
                        PrintHelper.ReplaceText(cwordDoc, "[GoldenRule]", cGoldenRule);
                        AddCompanyDetails(cwordDoc, true, false, false);
                        if (oSiteHq.CustomerID == Enums.Customer.Domestic)
                            PrintHelper.ReplaceText(cwordDoc, "[CustomerName]", "the person(s) responsible for your property");
                        else
                            PrintHelper.ReplaceText(cwordDoc, "[CustomerName]", oSiteHq.Name);
                        PrintHelper.ReplaceText(cwordDoc, "[SiteName]", oSite.Name.Replace("T1", "").Trim);
                        PrintHelper.ReplaceText(cwordDoc, "[Name]", Helper.ToTitleCase(oSite.Name.Replace("T1", "").Trim));
                        PrintHelper.ReplaceText(cwordDoc, "[Address1]", oSite.Address1);
                        PrintHelper.ReplaceText(cwordDoc, "[Address2]", oSite.Address2);
                        PrintHelper.ReplaceText(cwordDoc, "[Address3]", oSite.Address3);
                        PrintHelper.ReplaceText(cwordDoc, "[Address4]", oSite.Address4);
                        PrintHelper.ReplaceText(cwordDoc, "[Address5]", oSite.Address5);
                        PrintHelper.ReplaceText(cwordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode));
                        PrintHelper.ReplaceText(cwordDoc, "[Date]", DateTime.Now.ToShortDateString());
                        PrintHelper.ReplaceText(cwordDoc, "[ServiceDate]", visitDate.ToShortDateString());
                        string telNo = oSiteHq.CustomerID == Enums.Customer.Victory ? "01603 309600" : "01603 258617";
                        PrintHelper.ReplaceText(cwordDoc, "[TelNo]", telNo);

                        WP.Paragraph para = cwordDoc.MainDocumentPart.Document.Body.ChildElements.First<WP.Paragraph>();

                        if (para.ParagraphProperties == null)
                            para.ParagraphProperties = new WP.ParagraphProperties();

                        para.ParagraphProperties.PageBreakBefore = new WP.PageBreakBefore();
                    }
                    if (mm != null)
                    {
                        List<MemoryStream> files = new List<MemoryStream>() { mm, cmm };
                        finalDoc = PrintHelper.CombineDocs(files);
                    }
                    else
                        finalDoc = cmm.ToArray();
                }
                return finalDoc;
            }

            private int Add_Appliances_PreVisit(Word.Document wordDoc, int numberOfAppliances, int currentPage, int numberOfPages, DataTable Assets, DataTable faults, int nextTableForPrint, bool NCCTemplate = false)
            {
                int numberToReturn = numberOfAppliances;
                int rowNo = 0;
                int actualNo = 0;

                int ApplianceRows = 0;
                if (NCCTemplate)
                    ApplianceRows = 4;
                else
                    ApplianceRows = 4;

                for (int i = (numberOfAppliances - 1); i >= (numberOfAppliances - ApplianceRows); i += -1)
                {
                    rowNo += 1;
                    actualNo += 1;

                    try
                    {
                        string emptyWord = "";
                        // This should be not Appliance Tested - not landlord appliance
                        PickLists.PickList llAppliance;
                        llAppliance = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("ApplianceTestedID"));
                        if (!llAppliance == null)
                        {
                            if (llAppliance.Name == "No")
                                emptyWord = "Not Tested";
                        }

                        foreach (System.Text.RegularExpressions.Match wordField in GetTemplateFields(wordDoc.Content.Text))
                        {
                            switch (wordField.Value)
                            {
                                case object _ when "[" + (rowNo).ToString() + "A]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("Location")));
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "B]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("Type")));
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "C]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("Make")));
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "D]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("Model")));
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "E]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("LandlordsApplianceID"));
                                        if (!oPicklist.Name == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "F]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("ApplianceServiceOrInspectedID"));
                                        if (!oPicklist == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "G]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("ApplianceSafeID"));
                                        if (!oPicklist == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "H]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("FlueTerminationSatisfactoryID"));
                                        if (!oPicklist == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "I]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("VisualConditionOfFlueSatisfactoryID"));
                                        if (!oPicklist == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "J]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("FlueFlowTestID"));
                                        if (!oPicklist == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "K]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("SpillageTestID"));
                                        if (!oPicklist == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "L]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("VentilationProvisionSatisfactoryID"));
                                        if (!oPicklist == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "M]":
                                    {
                                        PickLists.PickList oPicklist;
                                        oPicklist = DB.Picklists.Get_One_As_Object(Assets.Rows(i).Item("SafetyDeviceOperationID"));
                                        if (!oPicklist == null)
                                            ReplaceText(ref wordDoc, wordField.Value, oPicklist.Name);
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "N]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("InletStaticPressure")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("InletStaticPressure")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "O]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("InletWorkingPressure")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("InletWorkingPressure")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "P]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("MinBurnerPressure")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("MinBurnerPressure")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "Q]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("MaxBurnerPressure")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("MaxBurnerPressure")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "R]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("CO2")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("CO2")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "S]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("CO2CORatio")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("CO2CORatio")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "T]":
                                    {
                                        if (emptyWord.Length == 0)
                                            ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("GCNumber")));
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "U]":
                                    {
                                        if (emptyWord.Length == 0)
                                            ReplaceText(ref wordDoc, wordField.Value, Helper.MakeStringValid(Assets.Rows(i).Item("SerialNum")));
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "V]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("DHWFlowRate")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("DHWFlowRate")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "W]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("ColdWaterTemp")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("ColdWaterTemp")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "X]":
                                    {
                                        if (emptyWord.Length == 0)
                                        {
                                            if (Helper.MakeDoubleValid(Assets.Rows(i).Item("DHWTemp")) == 0)
                                                ReplaceText(ref wordDoc, wordField.Value, "N/A");
                                            else
                                                ReplaceText(ref wordDoc, wordField.Value, Helper.MakeDoubleValid(Assets.Rows(i).Item("DHWTemp")));
                                        }
                                        else
                                            ReplaceText(ref wordDoc, wordField.Value, emptyWord);
                                        break;
                                    }
                            }
                        }
                        numberToReturn -= 1;
                    }
                    catch (Exception ex)
                    {
                        actualNo -= 1;

                        foreach (System.Text.RegularExpressions.Match wordField in GetTemplateFields(wordDoc.Content.Text))
                        {
                            switch (wordField.Value)
                            {
                                case object _ when "[" + (rowNo).ToString() + "A]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "B]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "C]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "D]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "E]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "F]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "G]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "H]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "I]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "J]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "K]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "L]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "M]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "N]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "O]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "P]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "Q]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "R]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "S]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "T]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "U]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "V]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "W]":
                                    {
                                        ReplaceText(ref wordDoc, wordField.Value, "");
                                        break;
                                    }

                                case object _ when "[" + (rowNo).ToString() + "X]":
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

                if (Fuel == Enums.WorksheetFuelTypes.Unvented)
                    ApplianceRows = 12;
                else if (Fuel == Enums.WorksheetFuelTypes.SolidFuel)
                    ApplianceRows = 2;
                else
                    ApplianceRows = 4;

                for (int i = 0; i <= (ApplianceRows - 1); i += 1)
                {
                    if (!faults == null)
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
                                foreach (DataRow faultRow in faults.Select("AssetID = " + EngineerVisitAssetWorksheets.Rows(i).Item("AssetID")))
                                {
                                    if (!faultRow.Item("ADDEDTOPRINTOUT") == true)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AA" + nextFaultRowForPrint, System.Convert.ToString(faultRow.Item("FullReason")).Trim);
                                        if (Fuel == 2 | Fuel == 0 | Fuel == 5 | Fuel == 9 | Fuel == 7)
                                        {
                                            if (faultRow.Item("WarningNoticeIssued"))
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + nextFaultRowForPrint, "Yes");
                                            else
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + nextFaultRowForPrint, "No");
                                        }
                                        else if (Fuel == 3)
                                        {
                                            if (faultRow.Item("WarningNoticeIssued"))
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
                                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DD" + nextFaultRowForPrint, System.Convert.ToString(faultRow.Item("ActionTaken")));

                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CC" + nextFaultRowForPrint, faultRow.Item("Disconnected"));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EE" + nextFaultRowForPrint, System.Convert.ToString(faultRow.Item("Comments")));

                                        faultRow.Item("ADDEDTOPRINTOUT") = true;
                                        if (Fuel == 1)
                                            nextFaultRowForPrint += 1;
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
                        DataView dvAssetWorksheet = DB.EngineerVisitAssetWorkSheet.Get_Friendly(Helper.MakeIntegerValid(EngineerVisitAssetWorksheets.Rows(i).Item("EngineerVisitAssetWorkSheetID")));

                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AAA" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceTested")));
                        if (Fuel == Enums.WorksheetFuelTypes.Unvented)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Type")));
                        else
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Location")));

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.Gas:
                            case object _ when Enums.WorksheetFuelTypes.Oil:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Type")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Make")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Reading")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Model")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Make")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.HIU:
                            case object _ when Enums.WorksheetFuelTypes.ASHP:
                            case object _ when Enums.WorksheetFuelTypes.GSHP:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Model") + " / " + dvAssetWorksheet(0)("SerialNum")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("MaxBurnerPressure")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Model")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.Unvented:
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("InletStaticPressure")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("LandlordsAppliance")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("FlueTerminationSatisfactory")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("DHWFlowRate")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceServiceOrInspected")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("VisualConditionOfFlueSatisfactory")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ColdWaterTemp")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceSafe")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("FlueFlowTest")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.Unvented:
                            case object _ when Enums.WorksheetFuelTypes.ASHP:
                            case object _ when Enums.WorksheetFuelTypes.GSHP:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Discharge")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("FlueTerminationSatisfactory")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SpillageTest")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("VisualConditionOfFlueSatisfactory")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                            case object _ when Enums.WorksheetFuelTypes.HIU:
                            case object _ when Enums.WorksheetFuelTypes.ASHP:
                            case object _ when Enums.WorksheetFuelTypes.GSHP:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("VentilationProvisionSatisfactory")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("FlueFlowTest")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SafetyDeviceOperation")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.HIU:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Nozzle")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SpillageTest")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("LandlordsAppliance")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.HIU:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SpillageTest")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("VentilationProvisionSatisfactory")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceTested")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.HIU:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SpillageTest")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SafetyDeviceOperation")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.Gas:
                            case object _ when Enums.WorksheetFuelTypes.Oil:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("InletStaticPressure")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceServiceOrInspected")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.Unvented:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceSafe")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Overall")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.Gas:
                            case object _ when Enums.WorksheetFuelTypes.Oil:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("InletWorkingPressure")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Discharge")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SweepOutcome")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SweepOutcome")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("MinBurnerPressure")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("FlueType")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("MaxBurnerPressure")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("DHWFlowRate")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("CO2")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("BurModel")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("CO2CORatio")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.Gas:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("BurMake")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Overall")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("GCNumber")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.Gas:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("BurModel")));
                                    break;
                                }

                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ColdWaterTempString")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("SerialNum")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("DHWTempString")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("DHWFlowRate")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("InletWorkingPressureString")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ColdWaterTemp")));
                                    break;
                                }
                        }

                        switch (Fuel)
                        {
                            case object _ when Enums.WorksheetFuelTypes.SolidFuel:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("MinBurnerPressureString")));
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("DHWTemp")));
                                    break;
                                }
                        }

                        PrintHelper.ReplaceGSRBookmark(wordDoc, "QQ" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("MinBurnerPressure")));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "RR" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Nozzle")));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "SS" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("BurMake")));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "TT" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("BurModel")));

                        switch (Helper.MakeIntegerValid(dvAssetWorksheet(0)("TankID")))
                        {
                            case 0:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + (rowNo).ToString(), "N/A");
                                    break;
                                }

                            case 1:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + (rowNo).ToString(), "Plastic");
                                    break;
                                }

                            case 2:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + (rowNo).ToString(), "Bunded");
                                    break;
                                }

                            case 3:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + (rowNo).ToString(), "Metal");
                                    break;
                                }

                            default:
                                {
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + (rowNo).ToString(), "");
                                    break;
                                }
                        }

                        PrintHelper.ReplaceGSRBookmark(wordDoc, "VV" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("FlueType")));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "WW" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("GasType")));
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Y" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("ApplianceSafe")));

                        int warningCount = 0;
                        string warningOutput = "";
                        if (faults?.Rows.Count > 0)
                        {
                            DataRow[] drWarnings = faults.Select("AssetID = " + dvAssetWorksheet(0)("AssetID") + " AND WarningNoticeIssued = 1");
                            if (drWarnings?.Length > 0)
                                warningCount = drWarnings.Length;
                        }

                        if (warningCount > 0)
                            warningOutput = "Yes";
                        else
                            warningOutput = "No";
                        if (Fuel == Enums.WorksheetFuelTypes.SolidFuel)
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + (rowNo).ToString(), warningOutput);
                        else
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + (rowNo).ToString(), warningCount.ToString());

                        if (Fuel == Enums.WorksheetFuelTypes.SolidFuel && rowNo == 1)
                        {
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "KS" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("CO2String")));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "IS" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("CO2CORatioString")));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "CL" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("BurMakeString")));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "IH" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("NozzleString")));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AF" + (rowNo).ToString(), Helper.MakeStringValid(dvAssetWorksheet(0)("Tank")));
                        }

                        noOfApp -= 1;
                    }
                    catch (Exception ex)
                    {
                        actualNo -= 1;
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AAA" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "QQ" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Y" + (rowNo).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + (rowNo).ToString(), "");

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
                        if (!faults == null)
                        {
                            try
                            {
                                // For Each faultRow As DataRow In faults.Select("AssetID = 0")
                                foreach (DataRow faultRow in faults.Select("ADDEDTOPRINTOUT = 0 AND (AssetID IS NULL OR AssetID = 0)"))
                                {
                                    // If CInt(faultRow("AssetID")) = 0 Then
                                    if (actualNo == NewPageCompareNo)
                                        // NEED A NEW PAGE

                                        nextFaultRowForPrint = 0;
                                    if (!faultRow.Item("ADDEDTOPRINTOUT") == true)
                                    {
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "AA" + (nextFaultRowForPrint).ToString(), System.Convert.ToString(faultRow.Item("FullReason")).Trim);
                                        if (Fuel == 2 | Fuel == 0 | Fuel == 5 | Fuel == 9 | Fuel == 7)
                                        {
                                            if (faultRow.Item("WarningNoticeIssued"))
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + (nextFaultRowForPrint).ToString(), "Yes");
                                            else
                                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + (nextFaultRowForPrint).ToString(), "No");
                                        }
                                        else if (Fuel == 3)
                                        {
                                            if (faultRow.Item("WarningNoticeIssued"))
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
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "CC" + (nextFaultRowForPrint).ToString(), faultRow.Item("Disconnected"));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "DD" + (nextFaultRowForPrint).ToString(), System.Convert.ToString(faultRow.Item("ActionTaken")));
                                        PrintHelper.ReplaceGSRBookmark(wordDoc, "EE" + (nextFaultRowForPrint).ToString(), System.Convert.ToString(faultRow.Item("Comments")));
                                        faultRow.Item("ADDEDTOPRINTOUT") = true;
                                        nextFaultRowForPrint += 1;
                                    }
                                    actualNo = 1;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        else
                        {
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB" + (nextFaultRowForPrint).ToString(), "");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "");
                        }
                    }
                    else if (!faults == null)
                    {
                        try
                        {
                            bool warningNotice = false;
                            string RemidialString = "";
                            foreach (DataRow faultRow in faults.Select("ADDEDTOPRINTOUT = 0"))
                            {
                                if (System.Convert.ToInt32(faultRow("AssetID")) == 0)
                                {
                                    if (!faultRow.Item("ADDEDTOPRINTOUT") == true)
                                    {
                                        RemidialString += System.Convert.ToString(faultRow.Item("FullReason")).Trim;
                                        RemidialString += " - ";
                                        RemidialString += System.Convert.ToString(faultRow.Item("ActionTaken")) + " ,  ";
                                        if (faultRow.Item("WarningNoticeIssued"))
                                            warningNotice = true;
                                        faultRow.Item("ADDEDTOPRINTOUT") = true;
                                        nextFaultRowForPrint += 1;
                                    }
                                }
                                actualNo = 1;
                            }
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", RemidialString);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "DB" + (nextFaultRowForPrint).ToString(), "");
                        PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "");
                    }
                }
            }

            private bool SiteVisitReport(EngineerVisits.EngineerVisit engineerVisit, string savePath)
            {
                try
                {
                    engineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisit.EngineerVisitID);
                    Jobs.Job job = DB.Job.Job_Get_For_An_EngineerVisit_ID(engineerVisit.EngineerVisitID);
                    Sites.Site site = DB.Sites.Get(job.PropertyID);
                    Customers.Customer customer = DB.Customer.Customer_Get(site.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(engineerVisit.EngineerID);
                    EngineerVisitCharges.EngineerVisitCharge visitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(engineerVisit.EngineerVisitID);
                    Sites.Site siteHq = DB.Sites.Get(site.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                    DateTime startDate = engineerVisit.StartDateTime;
                    DateTime endDate = engineerVisit.EndDateTime;
                    if (startDate == default(DateTime))
                        startDate = engineerVisit.ManualEntryOn;
                    if (endDate == default(DateTime))
                        endDate = engineerVisit.ManualEntryOn;

                    int imageIndex = 101;
                    double total = 0.0;
                    double vat = 0.0;

                    if (visitCharge != null)
                    {
                        switch (visitCharge.ChargeTypeID)
                        {
                            case object _ when System.Convert.ToInt32(Enums.JobChargingType.QuoteValue):
                                {
                                    if (job.JobDefinitionEnumID == System.Convert.ToInt32(Enums.JobDefinition.Quoted))
                                        total = DB.QuoteJob.Get(job.QuoteID).GrandTotal;
                                    break;
                                }

                            case object _ when System.Convert.ToInt32(Enums.JobChargingType.JobValue):
                                {
                                    total = visitCharge.JobValue;
                                    break;
                                }

                            case object _ when System.Convert.ToInt32(Enums.JobChargingType.PercentageOfQuote):
                                {
                                    if (job.JobDefinitionEnumID == System.Convert.ToInt32(Enums.JobDefinition.Quoted))
                                        total = ((visitCharge.Charge / (double)100) * DB.QuoteJob.Get(job.QuoteID).GrandTotal);
                                    break;
                                }
                        }
                        vat = DB.EngineerVisits.EngineerCharge_VAT_Amount(visitCharge.EngineerVisitChargeID, startDate, total);
                    }

                    List<byte[]> fullDocument = new List<byte[]>();

                    string usingdoc = Application.StartupPath + @"\Templates\SiteVisitReport.docx";
                    byte[] byteArray = File.ReadAllBytes(usingdoc);
                    MemoryStream mm = new MemoryStream();
                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            AddCompanyDetails(wordDoc, true);

                            PrintHelper.ReplaceText(wordDoc, "[JobVisitNumber]", job.JobNumber + "" + engineerVisit.EngineerVisitID);
                            PrintHelper.ReplaceText(wordDoc, "[VisitDate]", startDate.ToLongDateString());
                            PrintHelper.ReplaceText(wordDoc, "[GasSafeIDNo]", Helper.MakeStringValid(engineer?.GasSafeNo));
                            PrintHelper.ReplaceText(wordDoc, "[JobCustomerName]", Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(engineerVisit.SignatureSelectedID)?.Name) + " " + engineerVisit.CustomerName);
                            PrintHelper.ReplaceText(wordDoc, "[JobAddressName]", site.Name);
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress1]", site.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress2]", site.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[JobAddress3]", site.Address3);
                            PrintHelper.ReplaceText(wordDoc, "[JobPostCode]", Helper.FormatPostcode(site.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[JobTelNo]", site.TelephoneNum);
                            PrintHelper.ReplaceText(wordDoc, "[LandLordAddress3]", "");

                            if (!siteHq == null)
                            {
                                string strAddress = string.Empty;

                                if (siteHq.Address1.Length > 0)
                                    strAddress += siteHq.Address1 + ", ";

                                if (siteHq.Address2.Length > 0)
                                    strAddress += siteHq.Address2 + ", ";

                                if (strAddress.Length > 0)
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);

                                string strAddress1 = string.Empty;

                                if (siteHq.Address3.Length > 0)
                                    strAddress1 += siteHq.Address3 + ", ";

                                if (siteHq.Address4.Length > 0)
                                    strAddress1 += siteHq.Address4 + ", ";

                                if (siteHq.Address5.Length > 0)
                                    strAddress1 += siteHq.Address5 + ", ";

                                if (strAddress.Length > 0 & strAddress1.Length > 1)
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);

                                string customerName = siteHq.CustomerID != Enums.Customer.Domestic ? customer.Name : "";

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
                                strJOW = strJOW.Substring(0, strJOW.Length - 1);

                            PrintHelper.ReplaceText(wordDoc, "[PO]", strJOW);
                            PrintHelper.ReplaceText(wordDoc, "[From]", startDate.ToShortTimeString());
                            PrintHelper.ReplaceText(wordDoc, "[To]", endDate.ToShortTimeString());

                            DataView dvFaults = DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(engineerVisit.EngineerVisitID);
                            DataRow[] warningNotices = (from r in dvFaults.Table.AsEnumerable()
                                                        where r.Field<bool>("WarningNoticeIssued") == true
                                                        select r).ToArray();
                            string warningNotice = warningNotices.Count > 0 ? "Yes" : "No";
                            PrintHelper.ReplaceText(wordDoc, "[Warning]", warningNotice);

                            PrintHelper.ReplaceText(wordDoc, "[Engineer]", Helper.MakeStringValid(engineer?.Name));
                            PrintHelper.ReplaceText(wordDoc, "[Outcome]", engineerVisit.VisitOutcome);
                            PrintHelper.ReplaceText(wordDoc, "[PaymentMethod]", Helper.MakeStringValid(DB.Picklists.Get_One_As_Object(engineerVisit.PaymentMethodID)?.Name));
                            PrintHelper.ReplaceText(wordDoc, "[Total]", total == 0 ? "" : total.ToString("c"));
                            PrintHelper.ReplaceText(wordDoc, "[VAT]", vat == 0 ? "" : vat.ToString("c"));
                            PrintHelper.ReplaceText(wordDoc, "[AmntDue]", total + vat == 0 ? "" : (total + vat).ToString("c"));
                            PrintHelper.ReplaceText(wordDoc, "[OutcomeDetails]", engineerVisit.OutcomeDetails);
                            PrintHelper.ReplaceText(wordDoc, "[WorkRequired]", engineerVisit.NotesToEngineer);

                            if (engineerVisit.EngineerSignature == null)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");
                            else
                            {
                                Bitmap engSig = new Bitmap(new System.IO.MemoryStream(engineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }

                            if (engineerVisit.CustomerSignature == null)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "");
                            else
                            {
                                Bitmap custSig = new Bitmap(new System.IO.MemoryStream(engineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }

                            DataTable dt = new DataTable();
                            dt.Columns.Add("Part No");
                            dt.Columns.Add("Description");
                            dt.Columns.Add("Qty");

                            if (engineerVisit.PartsAndProductsUsed.Table != null && engineerVisit.PartsAndProductsUsed.Table.Rows.Count > 0)
                            {
                                foreach (DataRow r in engineerVisit.PartsAndProductsUsed.Table.Rows)
                                {
                                    DataRow nr;
                                    nr = dt.NewRow;
                                    nr("Part No") = r("Number");
                                    nr("Description") = r("Name");
                                    nr("Qty") = r("Quantity");
                                    dt.Rows.Add(nr);
                                }
                            }

                            PrintHelper.AddRowsToTable(wordDoc, "[Parts]", dt, "Arial", "16", 1);

                            DataTable dtTimeSheet = new DataTable();
                            dtTimeSheet.Columns.Add("Start");
                            dtTimeSheet.Columns.Add("End");
                            dtTimeSheet.Columns.Add("Type");
                            dtTimeSheet.Columns.Add("Comments");

                            if (engineerVisit.TimeSheets.Table != null && engineerVisit.TimeSheets.Table.Rows.Count > 0)
                            {
                                foreach (DataRow r in engineerVisit.TimeSheets.Table.Rows)
                                {
                                    DataRow nr;
                                    nr = dtTimeSheet.NewRow;
                                    nr("Start") = Helper.MakeDateTimeValid(r("StartDateTime")).ToString("HH:mm");
                                    nr("End") = Helper.MakeDateTimeValid(r("EndDateTime")).ToString("HH:mm");
                                    nr("Type") = r("TimeSheetType");
                                    nr("Comments") = r("Comments");
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
                            if (!loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
                                savePath = PrintHelper.LockFile(savePath, true);
                        }
                    }

                    byte[] cbyteArray = File.ReadAllBytes(savePath);
                    MemoryStream cmm = new MemoryStream();
                    using ((cmm))
                    {
                        cmm.Write(cbyteArray, 0, cbyteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(cmm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "Landlord’s appliance", "Appliance");
                            PrintHelper.ReplaceText(wordDoc, "Landlord’s Details", "Details");
                            PrintHelper.ReplaceText(wordDoc, "LANDLORD", "");
                            wordDoc.MainDocumentPart.Document.Save();
                        }

                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        if (File.Exists(savePath))
                            File.Delete(savePath);

                        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        cmm.Position = 0;
                        using ((fileStream))
                            cmm.WriteTo(fileStream);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private void AddCompanyDetails(WordprocessingDocument doc, bool useLogo, bool centreLogo = false, bool isCommercial = false)
            {
                CompanyDetails.CompanyDetails companyDetails = DB.CompanyDetails.Get();

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
                    Bitmap logo = null/* TODO Change to default(_) if this is not a reference type */;
                    if (IsRFT)
                        logo = global::FSM.My.Resources.Resources.rft_logo;
                    else if (IsGasway)
                        logo = isCommercial ? global::FSM.My.Resources.Resources.GC_Logo : global::FSM.My.Resources.Resources.GW_Logo;
                    else if (IsBlueflame)
                        logo = global::FSM.My.Resources.Resources.Blueflame;
                    string imgSavePath = Application.StartupPath + @"\TEMP\companyLogo.jpg";
                    PrintHelper.ReplaceBookmarkWithImage(doc, "Logo", logo, imgSavePath, 100, centreLogo);
                }
            }

            private bool JobContactLetter(Jobs.Job job)
            {
                try
                {
                    Sites.Site oSite = DB.Sites.Get(job.PropertyID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);

                    string visitDate = this.DetailsToPrint(1);

                    int currentPage = 1;

                    foreach (System.Text.RegularExpressions.Match wordField in GetTemplateFields(WordDoc.Content.Text))
                    {
                        switch (wordField.Value.ToLower())
                        {
                            case object _ when "[VisitDate]".ToLower():
                                {
                                    if (visitDate == null)
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, visitDate);
                                    break;
                                }

                            case object _ when "[VisitDate2]".ToLower():
                                {
                                    if (visitDate == null)
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, visitDate);
                                    break;
                                }

                            case object _ when "[SentDate]".ToLower():
                                {
                                    if (visitDate == null)
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, DateTime.Now.ToString("dd/MM/yyyy"));
                                    break;
                                }

                            case object _ when "[JobAddressName]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.Name);
                                    break;
                                }

                            case object _ when "[Address1]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.Address1);
                                    break;
                                }

                            case object _ when "[Address2]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.Address2);
                                    break;
                                }

                            case object _ when "[Address3]".ToLower():
                                {
                                    if (oSite.Address3.Length > 0)
                                        ReplaceText(ref WordDoc, wordField.Value, oSite.Address3);
                                    else if (oSite.Address4.Length > 0)
                                        ReplaceText(ref WordDoc, wordField.Value, oSite.Address4);
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, oSite.Address5);
                                    break;
                                }

                            case object _ when "[Name]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.Name);
                                    break;
                                }

                            case object _ when "[PostCode]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.FormatPostcode(oSite.Postcode));
                                    break;
                                }
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool COMSR(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null, bool addLsrHeaderLetter = false)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    EngineerVisitCharges.EngineerVisitCharge EngVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(oEngineerVisit.EngineerVisitID);

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;

                    int imageIndex = 100;
                    DataView GSRs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(oEngineerVisit.EngineerVisitID);
                    int numberOfAppliances = GSRs.Table.Rows.Count;

                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "COMSR");
                            if (!oEngineerVisit.EngineerSignature == null)
                            {
                                Bitmap engSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");

                            EngineerVisitAdditionals.EngineerVisitAdditional ComChecks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 0);

                            if (!oEngineerVisit.CustomerSignature == null)
                            {
                                Bitmap custSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "");

                            int currentPage = 1;
                            Sites.Site ositeHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber + "-" + oEngineerVisit.EngineerVisitID);

                            if (engineer == null)
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

                            if (visitDate == default(DateTime))
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
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Sys.Helper.FormatPostcode(oSite.Postcode), "8");

                            if (!ositeHQ == null)
                            {
                                string strAddress = string.Empty;
                                string strAddress1 = string.Empty;

                                if (ositeHQ.Address1.Length > 0)
                                    strAddress += ositeHQ.Address1 + ", ";

                                if (ositeHQ.Address2.Length > 0)
                                    strAddress += ositeHQ.Address2 + ", ";

                                if (strAddress.Length > 0)
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);

                                if (ositeHQ.Address3.Length > 0)
                                    strAddress1 += ositeHQ.Address3 + ", ";

                                if (ositeHQ.Address4.Length > 0)
                                    strAddress1 += ositeHQ.Address4 + ", ";

                                if (strAddress1.Length > 0)
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", DB.Customer.Customer_Get(oSite.CustomerID).Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", strAddress, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress1, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "", "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", Sys.Helper.FormatPostcode(ositeHQ.Postcode), "8");
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
                            foreach (DataRow row in DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(oEngineerVisit.EngineerVisitID).Table.Rows)
                            {
                                warning = "No";
                                if (Helper.MakeBooleanValid(row.Item("WarningNoticeIssued")))
                                {
                                    warning = "Yes";
                                    break;
                                }
                            }
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", warning);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", warning);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", warning);

                            if (oEngineerVisit.OutcomeDetails == null)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", "");
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", oEngineerVisit.OutcomeDetails);

                            if (ComChecks != null)
                            {
                                PickLists.PickList selected = DB.Picklists.Get_One_As_Object(ComChecks.Test1);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test2);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test4);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test5);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test6);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test7);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test8);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test9);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test10);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test111);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test112);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AL", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test113);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AM", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test114);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AN", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test115);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AO", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test116);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AP", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test117);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AQ", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test118);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AR", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test119);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AS", selected.Name);
                                AddAppliancesBatch(wordDoc, numberOfAppliances, GSRs.Table, null/* TODO Change to default(_) if this is not a reference type */);
                            }
                            else
                            {
                                ShowMessage("Could not generate document : Missing Worksheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }

                        if (addLsrHeaderLetter)
                        {
                            byte[] lsrHeaderTemplate = LsrHeaderLetter(oSite, null/* TODO Change to default(_) if this is not a reference type */, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using ((fileStream))
                                mm.WriteTo(fileStream);
                        }
                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool COMCAT(EngineerVisits.EngineerVisit EngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null, bool addLsrHeaderLetter = false)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);

                    EngineerVisitCharges.EngineerVisitCharge EngVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(EngineerVisit.EngineerVisitID);

                    DateTime visitDate = EngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = EngineerVisit.ManualEntryOn;

                    int imageIndex = 100;
                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Job]", EngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "COMCAT");
                            if (!EngineerVisit.EngineerSignature == null)
                            {
                                Bitmap engSig = new Bitmap(new System.IO.MemoryStream(EngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");

                            EngineerVisitAdditionals.EngineerVisitAdditional ComChecks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(EngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialCateringCP42);

                            if (!EngineerVisit.CustomerSignature == null)
                            {
                                Bitmap custSig = new Bitmap(new System.IO.MemoryStream(EngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "J", custSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", "");

                            int currentPage = 1;
                            Sites.Site ositeHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber + "-" + EngineerVisit.EngineerVisitID, "9", true);

                            if (engineer == null)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", "");
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "A", engineer.GasSafeNo);

                            if (visitDate == default(DateTime))
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
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Sys.Helper.FormatPostcode(oSite.Postcode), "8");

                            if (!ositeHQ == null)
                            {
                                string strAddress = string.Empty;
                                string strAddress1 = string.Empty;

                                if (ositeHQ.Address1.Length > 0)
                                    strAddress += ositeHQ.Address1 + ", ";

                                if (ositeHQ.Address2.Length > 0)
                                    strAddress += ositeHQ.Address2 + ", ";

                                if (strAddress.Length > 0)
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);

                                if (ositeHQ.Address3.Length > 0)
                                    strAddress1 += ositeHQ.Address3 + ", ";

                                if (ositeHQ.Address4.Length > 0)
                                    strAddress1 += ositeHQ.Address4 + ", ";

                                if (strAddress1.Length > 0)
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", ositeHQ.Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", strAddress1, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "", "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O", Sys.Helper.FormatPostcode(ositeHQ.Postcode), "8");
                            }
                            else
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "O", "");
                            }

                            PickLists.PickList selected = DB.Picklists.Get_One_As_Object(ComChecks.Test1);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test2);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test4);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test5);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test6);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test7);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test8);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test9);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test10);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AK", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test111);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AL", IIf(selected.ManagerID == 70132, "Yes", "NO"));
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AM", IIf(selected.ManagerID == 70133, "Yes", "NO"));
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test112);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AN", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test113);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AO", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test114);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AP", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test115);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AQ", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test116);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AR", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test117);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AS", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test118);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AT", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test119);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "AU", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test120);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test121);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test122);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test123);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test124);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BE", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test125);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BF", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test126);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BG", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test127);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BH", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test128);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BI", selected.Name);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BK", ComChecks.Test11);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", ComChecks.Test12);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test129);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test130);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BM", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test131);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "BN", selected.Name);
                            selected = DB.Picklists.Get_One_As_Object(ComChecks.Test132);
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
                            byte[] lsrHeaderTemplate = LsrHeaderLetter(oSite, null/* TODO Change to default(_) if this is not a reference type */, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using ((fileStream))
                                mm.WriteTo(fileStream);
                        }
                        fullDocument.Add(mm.ToArray());
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool ProptMain(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null, bool addLsrHeaderLetter = false)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    Sites.Site ositeHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;

                    EngineerVisitAdditionals.EngineerVisitAdditional PropMain = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist);

                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            if (engineer == null)
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
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", Sys.Helper.FormatPostcode(oSite.Postcode), "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", engineer.Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", visitDate, "11");
                            }

                            if (visitDate == default(DateTime))
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
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", DB.Picklists.Get_One_As_Object(PropMain.Test1).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", DB.Picklists.Get_One_As_Object(PropMain.Test2).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", DB.Picklists.Get_One_As_Object(PropMain.Test3).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "q1", DB.Picklists.Get_One_As_Object(PropMain.Test4).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "r1", DB.Picklists.Get_One_As_Object(PropMain.Test5).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "t1", PropMain.Test11, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "u1", PropMain.Test12, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "w1", PropMain.Test13, "11");
                            }
                        }

                        if (addLsrHeaderLetter)
                        {
                            byte[] lsrHeaderTemplate = LsrHeaderLetter(oSite, ositeHQ, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using ((fileStream))
                                mm.WriteTo(fileStream);
                        }
                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool Unvented(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, DataView LSR, string goldenRule, ref List<byte[]> fullDocument = null, bool addLsrHeaderLetter = false)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;
                    int imageIndex = 100;

                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();
                    PickLists.PickList oPicklist;
                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Address1]", oSite.Name);
                            PrintHelper.ReplaceText(wordDoc, "[Address2]", oSite.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[Address3]", oSite.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[Postcode]", Helper.FormatPostcode(oSite.Postcode));
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("FlueTerminationSatisfactoryID"));
                            PrintHelper.ReplaceText(wordDoc, "[i]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("FlueFlowTestID"));
                            PrintHelper.ReplaceText(wordDoc, "[ii]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("SpillageTestID"));
                            PrintHelper.ReplaceText(wordDoc, "[iii]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("VentilationProvisionSatisfactoryID"));
                            PrintHelper.ReplaceText(wordDoc, "[iv]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("TankID"));
                            PrintHelper.ReplaceText(wordDoc, "[v]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("DischargeID"));
                            PrintHelper.ReplaceText(wordDoc, "[vi]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("SweepOutcomeID"));
                            PrintHelper.ReplaceText(wordDoc, "[vii]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("SafetyDeviceOperationID"));
                            PrintHelper.ReplaceText(wordDoc, "[viii]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("OverallID"));
                            PrintHelper.ReplaceText(wordDoc, "[ix]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("ApplianceTestedID"));
                            PrintHelper.ReplaceText(wordDoc, "[x]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("VisualConditionOfFlueSatisfactoryID"));
                            PrintHelper.ReplaceText(wordDoc, "[xi]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("LandlordsApplianceID"));
                            PrintHelper.ReplaceText(wordDoc, "[xii]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("ApplianceServiceOrInspectedID"));
                            PrintHelper.ReplaceText(wordDoc, "[xiii]", oPicklist.Name);
                            oPicklist = null/* TODO Change to default(_) if this is not a reference type */;
                            oPicklist = DB.Picklists.Get_One_As_Object(LSR(0)("ApplianceSafeID"));
                            PrintHelper.ReplaceText(wordDoc, "[xiv]", oPicklist.Name);

                            PrintHelper.ReplaceText(wordDoc, "[Additional]", oEngineerVisit.OutcomeDetails);
                            if (visitDate == default(DateTime))
                                PrintHelper.ReplaceText(wordDoc, "[Date]", "");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[Date]", visitDate.ToLongDateString());
                            string engineerName = engineer == null ? "" : engineer.Name;
                            PrintHelper.ReplaceText(wordDoc, "[Engineer]", engineerName);

                            if (!oEngineerVisit.CustomerSignature == null)
                            {
                                Bitmap CustSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "Tenant", CustSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Tenant", "");
                        }

                        if (addLsrHeaderLetter)
                        {
                            byte[] lsrHeaderTemplate = LsrHeaderLetter(oSite, null/* TODO Change to default(_) if this is not a reference type */, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using ((fileStream))
                                mm.WriteTo(fileStream);
                        }
                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool SAFUnvented(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, EngineerVisitAdditionals.EngineerVisitAdditional SAFUNV1, string template, string savePath, string goldenRule, ref List<byte[]> fullDocument = null, bool addLsrHeaderLetter = false)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    Sites.Site oSiteHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;
                    int imageIndex = 101;

                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "UNVENTED");
                            if (!oSiteHQ == null)
                            {
                                string strAddress = string.Empty;

                                if (oSiteHQ.Address1.Length > 0)
                                    strAddress += oSiteHQ.Address1 + ", ";

                                if (oSiteHQ.Address2.Length > 0)
                                    strAddress += oSiteHQ.Address2 + ", ";

                                if (strAddress.Length > 0)
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);

                                string strAddress1 = string.Empty;

                                if (oSiteHQ.Address3.Length > 0)
                                    strAddress1 += oSiteHQ.Address3 + ", ";

                                if (oSiteHQ.Address4.Length > 0)
                                    strAddress1 += oSiteHQ.Address4 + ", ";

                                if (oSiteHQ.Address5.Length > 0)
                                    strAddress1 += oSiteHQ.Address5 + ", ";

                                if (strAddress.Length > 0 & strAddress1.Length > 1)
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "LandLordName", DB.Customer.Customer_Get(oSite.CustomerID).Name, "8", true);
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
                                logo = DB.ExecuteScalar("Select Logo FROM tblCustomer where CustomerID = " + oSite.CustomerID);
                            }
                            catch
                            {
                                logo = null;
                            }

                            if (logo != null)
                            {
                                Bitmap custLogo = new Bitmap(new MemoryStream(logo));
                                string imgSavePath = Application.StartupPath + @"\TEMP\custLogo.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "Logo", custLogo, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Logo", "");

                            PrintHelper.ReplaceText(wordDoc, "[JobNo]", Job.JobNumber);
                            PrintHelper.ReplaceText(wordDoc, "[A]", oSite.Name);
                            PrintHelper.ReplaceText(wordDoc, "[B]", oSite.Address1);
                            PrintHelper.ReplaceText(wordDoc, "[C]", oSite.Address2);
                            PrintHelper.ReplaceText(wordDoc, "[D]", Helper.FormatPostcode(oSite.Postcode));
                            PrintHelper.ReplaceText(wordDoc, "[E]", oSite.TelephoneNum);

                            PrintHelper.ReplaceText(wordDoc, "[AA]", SAFUNV1.Test11);
                            PrintHelper.ReplaceText(wordDoc, "[AB]", SAFUNV1.Test12);
                            PrintHelper.ReplaceText(wordDoc, "[AC]", SAFUNV1.Test13);
                            PrintHelper.ReplaceText(wordDoc, "[AD]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test1).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AE]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test2).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AF]", SAFUNV1.Test14);
                            PrintHelper.ReplaceText(wordDoc, "[AG]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test3).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AH]", SAFUNV1.Test15);
                            PrintHelper.ReplaceText(wordDoc, "[AI]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test4).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AJ]", SAFUNV1.Test216);
                            PrintHelper.ReplaceText(wordDoc, "[AK]", SAFUNV1.Test217);
                            PrintHelper.ReplaceText(wordDoc, "[AL]", SAFUNV1.Test218);
                            PrintHelper.ReplaceText(wordDoc, "[AM]", SAFUNV1.Test219);
                            PrintHelper.ReplaceText(wordDoc, "[AN]", SAFUNV1.Test220);
                            PrintHelper.ReplaceText(wordDoc, "[AO]", SAFUNV1.Test221);
                            PrintHelper.ReplaceText(wordDoc, "[AP]", SAFUNV1.Test222);
                            PrintHelper.ReplaceText(wordDoc, "[AQ]", SAFUNV1.Test223);
                            PrintHelper.ReplaceText(wordDoc, "[AR]", SAFUNV1.Test224);
                            PrintHelper.ReplaceText(wordDoc, "[AS]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test5).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AT]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test6).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AU]", SAFUNV1.Test225);
                            PrintHelper.ReplaceText(wordDoc, "[AV]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test7).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AW]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test8).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AX]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test9).Name);
                            PrintHelper.ReplaceText(wordDoc, "[AY]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test10).Name);

                            PrintHelper.ReplaceText(wordDoc, "[BA]", SAFUNV1.Test226);
                            PrintHelper.ReplaceText(wordDoc, "[BB]", SAFUNV1.Test227);
                            PrintHelper.ReplaceText(wordDoc, "[BC]", SAFUNV1.Test228);
                            PrintHelper.ReplaceText(wordDoc, "[BD]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test111).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BE]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test112).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BF]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test113).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BG]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test114).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BH]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test115).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BI]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test116).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BJ]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test117).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BK]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test118).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BL]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test119).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BM]", DB.Picklists.Get_One_As_Object(SAFUNV1.Test120).Name);
                            PrintHelper.ReplaceText(wordDoc, "[BN]", SAFUNV1.Test229);
                            PrintHelper.ReplaceText(wordDoc, "[BO]", SAFUNV1.Test230);
                            PrintHelper.ReplaceText(wordDoc, "[BP]", SAFUNV1.Test231);

                            if (visitDate == default(DateTime))
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

                            if (!oEngineerVisit.EngineerSignature == null)
                            {
                                Bitmap engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig2", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig2", "");

                            if (!oEngineerVisit.CustomerSignature == null)
                            {
                                Bitmap CustSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig2", CustSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig2", "");
                        }

                        if (addLsrHeaderLetter)
                        {
                            byte[] lsrHeaderTemplate = LsrHeaderLetter(oSite, oSiteHQ, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using ((fileStream))
                                mm.WriteTo(fileStream);
                        }
                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool ComChecklist(EngineerVisits.EngineerVisit oEngineerVisit)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    Sites.Site oSite = DB.Sites.Get(Job.PropertyID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    EngineerVisitAdditionals.EngineerVisitAdditional CommChecks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommissioningChecklist);
                    Sites.Site oSiteHQ;
                    oSiteHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;
                    int imageIndex = 101;

                    string template = Application.StartupPath + @"\Templates\CommissioningChecklist.docx";

                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();
                    string saveDir = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblEngineerVisit) + @"\" + oEngineerVisit.EngineerVisitID;
                    Directory.CreateDirectory(saveDir);
                    string savePath = saveDir + @"\CommisioningChecklist" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            string strAddress = string.Empty;

                            if (oSite.Address1.Length > 0)
                                strAddress += oSite.Address1 + ", ";

                            if (oSite.Address2.Length > 0)
                                strAddress += oSite.Address2 + ", " + oSite.Address3 + ", " + oSite.Postcode;

                            PrintHelper.ReplaceText(wordDoc, "[custName]", oSite.Name);
                            PrintHelper.ReplaceText(wordDoc, "[tel1]", oSite.TelephoneNum);
                            PrintHelper.ReplaceText(wordDoc, "[address1]", strAddress);
                            PrintHelper.ReplaceText(wordDoc, "[makeModel]", CommChecks.Test12);
                            PrintHelper.ReplaceText(wordDoc, "[serial]", CommChecks.Test13);
                            PrintHelper.ReplaceText(wordDoc, "[commission]", engineer.Name);
                            PrintHelper.ReplaceText(wordDoc, "[commDate]", visitDate.ToLongDateString());
                            PrintHelper.ReplaceText(wordDoc, "[Breg]", CommChecks.Test11);

                            switch (CommChecks.Test1)
                            {
                                case object _ when Enums.CommisioningChecksEnums.RoomThermostatAndTimer:
                                    {
                                        PrintHelper.ReplaceText(wordDoc, "[a]", "X");
                                        PrintHelper.ReplaceText(wordDoc, "[b]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[h]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[i]", "");
                                        break;
                                    }

                                case object _ when Enums.CommisioningChecksEnums.LoadWeatherCompensation:
                                    {
                                        PrintHelper.ReplaceText(wordDoc, "[a]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[b]", "X");
                                        PrintHelper.ReplaceText(wordDoc, "[h]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[i]", "");
                                        break;
                                    }

                                case object _ when Enums.CommisioningChecksEnums.ProgrammableRoomThermostat:
                                    {
                                        PrintHelper.ReplaceText(wordDoc, "[a]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[b]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[h]", "X");
                                        PrintHelper.ReplaceText(wordDoc, "[i]", "");
                                        break;
                                    }

                                case object _ when Enums.CommisioningChecksEnums.OptimumStartControl:
                                    {
                                        PrintHelper.ReplaceText(wordDoc, "[a]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[b]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[h]", "");
                                        PrintHelper.ReplaceText(wordDoc, "[i]", "X");
                                        break;
                                    }
                            }

                            if (CommChecks.Test2 == Enums.CommisioningChecksEnums.CylinderThermostatAndTimer)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[c]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[j]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[c]", "");
                                PrintHelper.ReplaceText(wordDoc, "[j]", "X");
                            }

                            if (CommChecks.Test3 == Enums.CommisioningChecksEnums.Fitted)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[d]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[k]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[d]", "");
                                PrintHelper.ReplaceText(wordDoc, "[k]", "X");
                            }

                            if (CommChecks.Test4 == Enums.CommisioningChecksEnums.Fitted)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[e]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[l]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[e]", "");
                                PrintHelper.ReplaceText(wordDoc, "[l]", "X");
                            }

                            if (CommChecks.Test5 == Enums.CommisioningChecksEnums.Fitted)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[f]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[m]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[f]", "");
                                PrintHelper.ReplaceText(wordDoc, "[m]", "X");
                            }

                            if (CommChecks.Test6 == Enums.CommisioningChecksEnums.Fitted)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[g]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[n]", "");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[g]", "");
                                PrintHelper.ReplaceText(wordDoc, "[n]", "X");
                            }

                            if (CommChecks.Test7 == Enums.YesNo.Yes)
                                PrintHelper.ReplaceText(wordDoc, "[o]", "X");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[o]", "");

                            if (CommChecks.Test8 == Enums.YesNo.Yes)
                                PrintHelper.ReplaceText(wordDoc, "[p]", "X");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[p]", "");

                            PrintHelper.ReplaceText(wordDoc, "[cleaner]", CommChecks.Test14);
                            PrintHelper.ReplaceText(wordDoc, "[inhibitor]", CommChecks.Test15);
                            PrintHelper.ReplaceText(wordDoc, "[quantity]", CommChecks.Test216);

                            if (CommChecks.Test9 == Enums.YesNo.Yes)
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

                            if (CommChecks.Test10 == Enums.YesNoNA.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[s]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[u]", "");
                            }
                            else if (CommChecks.Test10 == Enums.YesNoNA.No)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[s]", "");
                                PrintHelper.ReplaceText(wordDoc, "[u]", "X");
                            }
                            else
                            {
                                PrintHelper.ReplaceText(wordDoc, "[s]", "");
                                PrintHelper.ReplaceText(wordDoc, "[u]", "");
                            }

                            if (CommChecks.Test111 == Enums.YesNoNA.Yes)
                            {
                                PrintHelper.ReplaceText(wordDoc, "[t]", "X");
                                PrintHelper.ReplaceText(wordDoc, "[v]", "");
                            }
                            else if (CommChecks.Test111 == Enums.YesNoNA.No)
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

                            if (CommChecks.Test112 == Enums.YesNo.Yes)
                                PrintHelper.ReplaceText(wordDoc, "[x]", "X");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[x]", "");

                            PrintHelper.ReplaceText(wordDoc, "[temp]", CommChecks.Test227);
                            PrintHelper.ReplaceText(wordDoc, "[flowRate]", CommChecks.Test228);

                            if (CommChecks.Test113 == Enums.YesNo.Yes)
                                PrintHelper.ReplaceText(wordDoc, "[y]", "X");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[y]", "");

                            PrintHelper.ReplaceText(wordDoc, "[maxCO]", CommChecks.Test229);
                            PrintHelper.ReplaceText(wordDoc, "[maxRatio]", CommChecks.Test230);
                            PrintHelper.ReplaceText(wordDoc, "[minCO]", CommChecks.Test231);
                            PrintHelper.ReplaceText(wordDoc, "[minRatio]", CommChecks.Test232);

                            if (CommChecks.Test114 == Enums.YesNo.Yes)
                                PrintHelper.ReplaceText(wordDoc, "[z]", "X");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[z]", "");
                            if (CommChecks.Test115 == Enums.YesNo.Yes)
                                PrintHelper.ReplaceText(wordDoc, "[aa]", "X");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[aa]", "");
                            if (CommChecks.Test116 == Enums.YesNo.Yes)
                                PrintHelper.ReplaceText(wordDoc, "[ab]", "X");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[ab]", "");
                            if (CommChecks.Test117 == Enums.YesNo.Yes)
                                PrintHelper.ReplaceText(wordDoc, "[ac]", "X");
                            else
                                PrintHelper.ReplaceText(wordDoc, "[ac]", "");

                            if (!oEngineerVisit.EngineerSignature == null)
                            {
                                Bitmap engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "engSig", engSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "engSig", "");

                            if (!oEngineerVisit.CustomerSignature == null)
                            {
                                Bitmap CustSig = new Bitmap(new MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "custSig", CustSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "custSig", "");
                        }

                        savePath = FileCheck(savePath);

                        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);
                    }

                    Process.Start(savePath);

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateHotWorksPermit(EngineerVisits.EngineerVisit oEngineerVisit)
            {
                try
                {
                    Jobs.Job job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    Sites.Site oSite = DB.Sites.Get(job.PropertyID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    EngineerVisitAdditionals.EngineerVisitAdditional hotWorks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.HotWorksPermit);
                    Sites.Site oSiteHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;

                    int imageIndex = 101;
                    string template = Application.StartupPath + @"\Templates\HotWorksPermit.docx";

                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();
                    string saveDir = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblEngineerVisit) + @"\" + oEngineerVisit.EngineerVisitID;
                    Directory.CreateDirectory(saveDir);
                    string savePath = saveDir + @"\HotWorksPermit" + DateTime.Now.Day + "_" + DateTime.Now.ToString("MMM") + "_" + DateTime.Now.Year + ".docx";
                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[JobNumber]", job.JobNumber.ToUpper());
                            PrintHelper.ReplaceText(wordDoc, "[Test220]", hotWorks.Test220.ToUpper());

                            string strAddress = string.Empty;
                            if (oSite.Address1.Length > 0)
                                strAddress += oSite.Address1 + ", ";
                            if (oSite.Address2.Length > 0)
                                strAddress += oSite.Address2 + ", " + oSite.Address3 + ", " + oSite.Postcode;

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

                            if (!oEngineerVisit.EngineerSignature == null)
                            {
                                Bitmap engSig = new Bitmap(new MemoryStream(oEngineerVisit.EngineerSignature));
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

                        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);
                    }

                    Process.Start(savePath);

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool ASHPM(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null, bool addHeaderLetter = false)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    EngineerVisitCharges.EngineerVisitCharge EngVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(oEngineerVisit.EngineerVisitID);
                    DataView GSRs = DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(oEngineerVisit.EngineerVisitID);
                    int numberOfAppliances = GSRs.Table.Rows.Count;

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;

                    double total = 0.0;
                    double vat = 0.0;
                    EngineerVisitAdditionals.EngineerVisitAdditional ASHP = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet);
                    EngineerVisitAdditionals.EngineerVisitAdditional Solar = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.SolarThermalReport);

                    Sites.Site ositeHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);
                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "ASHPM");
                            if (engineer == null)
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
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobPostCode", Sys.Helper.FormatPostcode(oSite.Postcode), "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "JobTelNo", oSite.TelephoneNum, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "Engineer", engineer.Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a", ASHP.Test11);
                            }

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobVisitNumber", Job.JobNumber + "-" + oEngineerVisit.EngineerVisitID, "9", true);
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "VisitDate", Strings.Format(visitDate, "dd/MM/yyyy"), "9", true);

                            if (visitDate == default(DateTime))
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

                            if (!Solar == null & visitDate != default(DateTime))
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "a1", oSite.Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "b1", oSite.Address1 + ", " + oSite.Address2, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "c1", Sys.Helper.FormatPostcode(oSite.Postcode), "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "d1", oSite.TelephoneNum, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "e1", oSite.FaxNum, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "f1", engineer.Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "g1", Strings.Format(visitDate, "dd/MM/yyyy"), "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "h1", Solar.Test217, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "j1", Solar.Test218, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "k1", DB.Picklists.Get_One_As_Object(Solar.Test1).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "l1", DB.Picklists.Get_One_As_Object(Solar.Test2).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "m1", DB.Picklists.Get_One_As_Object(Solar.Test3).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "n1", DB.Picklists.Get_One_As_Object(Solar.Test4).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "o1", DB.Picklists.Get_One_As_Object(Solar.Test5).Name, "11");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "p1", DB.Picklists.Get_One_As_Object(Solar.Test6).Name, "11");
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
                            byte[] lsrHeaderTemplate = LsrHeaderLetter(oSite, ositeHQ, visitDate, mm);
                            fullDocument.Add(lsrHeaderTemplate);
                            File.WriteAllBytes(savePath, lsrHeaderTemplate);
                        }
                        else
                        {
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;
                            using ((fileStream))
                                mm.WriteTo(fileStream);
                        }
                        fullDocument.Add(mm.ToArray());
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool COMTANDP(EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string template, string savePath, string goldenRule, List<byte[]> fullDocument = null)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                    Sites.Site ositeHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                    DateTime visitDate = oEngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = oEngineerVisit.ManualEntryOn;
                    int imageIndex = 100;

                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            PrintHelper.ReplaceText(wordDoc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(wordDoc, "[Job]", oEngineerVisit.EngineerVisitID + "_" + visitDate.ToString("ddMMyyyyhhmm") + "_" + "COMTANDP");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "JobNo", Job.JobNumber + "-" + oEngineerVisit.EngineerVisitID);
                            if (engineer == null)
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

                            if (visitDate == default(DateTime))
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", "");
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "B", visitDate.ToLongDateString());

                            PrintHelper.ReplaceGSRBookmark(wordDoc, "E", oSite.Name, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "F", oSite.Address1, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "G", oSite.Address2, "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "H", Sys.Helper.FormatPostcode(oSite.Postcode), "8");
                            PrintHelper.ReplaceGSRBookmark(wordDoc, "I", oSite.TelephoneNum, "8");

                            if (!ositeHQ == null)
                            {
                                string strAddress = string.Empty;
                                string strAddress1 = string.Empty;

                                if (ositeHQ.Address1.Length > 0)
                                    strAddress += ositeHQ.Address1 + ", ";

                                if (ositeHQ.Address2.Length > 0)
                                    strAddress += ositeHQ.Address2 + ", ";

                                if (strAddress.Length > 0)
                                    strAddress = strAddress.Substring(0, strAddress.Length - 2);

                                if (ositeHQ.Address3.Length > 0)
                                    strAddress1 += ositeHQ.Address3 + ", ";

                                if (ositeHQ.Address4.Length > 0)
                                    strAddress1 += ositeHQ.Address4 + ", ";

                                if (strAddress1.Length > 0)
                                    strAddress1 = strAddress1.Substring(0, strAddress1.Length - 2);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "J", DB.Customer.Customer_Get(oSite.CustomerID).Name, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "K", strAddress, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "L", strAddress1, "8");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "M", "");
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "N", Sys.Helper.FormatPostcode(ositeHQ.Postcode), "8");
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
                            foreach (DataRow row in DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(oEngineerVisit.EngineerVisitID).Table.Rows)
                            {
                                if (Helper.MakeBooleanValid(row.Item("WarningNoticeIssued")))
                                {
                                    warning = "Yes";
                                    break;
                                }
                            }

                            if (!oEngineerVisit.CustomerSignature == null)
                            {
                                Bitmap custSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.CustomerSignature));
                                string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig1", custSig, imgSavePath, imageIndex);
                                imageIndex += 1;
                            }
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig1", "");

                            if (warning == "Yes")
                            {
                                if (!oEngineerVisit.EngineerSignature == null)
                                {
                                    Bitmap engSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.EngineerSignature));
                                    string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig2", engSig, imgSavePath, imageIndex);
                                    imageIndex += 1;
                                }
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig2", "");

                                if (!oEngineerVisit.CustomerSignature == null)
                                {
                                    Bitmap custSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.CustomerSignature));
                                    string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig2", custSig, imgSavePath, imageIndex);
                                    imageIndex += 1;
                                }
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig2", "");

                                if (visitDate == default(DateTime))
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", visitDate.ToLongDateString());

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", "");
                            }
                            else
                            {
                                if (!oEngineerVisit.EngineerSignature == null)
                                {
                                    Bitmap engSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.EngineerSignature));
                                    string imgSavePath = Application.StartupPath + @"\TEMP\EngSig.jpg";
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "EngSig", engSig, imgSavePath, imageIndex);
                                    imageIndex += 1;
                                }
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "EngSig", "");

                                if (!oEngineerVisit.CustomerSignature == null)
                                {
                                    Bitmap custSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.CustomerSignature));
                                    string imgSavePath = Application.StartupPath + @"\TEMP\CustSig.jpg";
                                    PrintHelper.ReplaceBookmarkWithImage(wordDoc, "CustSig", custSig, imgSavePath, imageIndex);
                                    imageIndex += 1;
                                }
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "CustSig", "");

                                if (visitDate == default(DateTime))
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DA", visitDate.ToLongDateString());

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "");
                            }

                            if (oEngineerVisit.OutcomeDetails == null)
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", "");
                            else
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "OutcomeDetails", oEngineerVisit.OutcomeDetails);

                            EngineerVisitAdditionals.EngineerVisitAdditional ComChecks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialStrengthTestCP16);

                            if (ComChecks != null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X1", "X");

                                string cSelected = "";
                                switch ((ComChecks.Test1))
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
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AA", cSelected);

                                cSelected = "";
                                switch ((ComChecks.Test2))
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
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AB", cSelected);

                                PickLists.PickList selected = DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AC", selected.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AD", ComChecks.Test11);

                                cSelected = "";
                                switch ((ComChecks.Test4))
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
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AE", cSelected);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AF", ComChecks.Test12);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", ComChecks.Test13);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", ComChecks.Test14);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", ComChecks.Test15);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "AJ", ComChecks.Test216);

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test120);
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

                            ComChecks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialTightnessTestCP16);

                            if (ComChecks != null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X2", "X");

                                string cSelected = "";
                                switch ((ComChecks.Test1))
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
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BA", cSelected);

                                cSelected = "";
                                switch ((ComChecks.Test2))
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
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BB", cSelected);

                                PickLists.PickList selected = DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BC", selected.Name);

                                cSelected = "";
                                switch ((ComChecks.Test4))
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
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BD", cSelected);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BE", ComChecks.Test221);

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test6);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BF", selected.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BG", ComChecks.Test11);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BH", ComChecks.Test12);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BI", ComChecks.Test13);

                                cSelected = "";
                                switch ((ComChecks.Test7))
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
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BJ", cSelected);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BK", ComChecks.Test14);

                                cSelected = "";
                                switch ((ComChecks.Test8))
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
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", "");
                                else
                                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BL", cSelected);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BM", ComChecks.Test15);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BN", ComChecks.Test216);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BO", ComChecks.Test217);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BP", ComChecks.Test218);

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test9);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BQ", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test10);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BR", selected.Name);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BT", ComChecks.Test219);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BU", ComChecks.Test220);

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test119);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "BV", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test120);
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

                            ComChecks = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, Enums.AdditionalChecksTypes.CommercialPurgingTestCP16);

                            if (ComChecks != null)
                            {
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "X3", "X");

                                PickLists.PickList selected = DB.Picklists.Get_One_As_Object(ComChecks.Test1);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CA", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test2);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CB", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test3);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CC", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test4);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CD", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test5);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CE", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test6);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CF", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test7);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CG", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test8);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CH", selected.Name);
                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test9);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CI", selected.Name);

                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CJ", ComChecks.Test11);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CK", ComChecks.Test12);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CL", ComChecks.Test13);

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test10);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CM", selected.Name);
                                PrintHelper.ReplaceGSRBookmark(wordDoc, "CN", ComChecks.Test14);

                                selected = DB.Picklists.Get_One_As_Object(ComChecks.Test120);
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

                        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);
                        fullDocument.Add(mm.ToArray());
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool Install(EngineerVisits.EngineerVisit EngineerVisit)
            {
                try
                {
                    Jobs.Job Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);

                    Sites.Site oSite = DB.Sites.Get(Job.PropertyID);
                    Customers.Customer oCustomer = DB.Customer.Customer_Get(oSite.CustomerID);
                    Engineers.Engineer engineer = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);

                    DateTime visitDate = EngineerVisit.StartDateTime;
                    if (visitDate == default(DateTime))
                        visitDate = EngineerVisit.ManualEntryOn;

                    double total = 0.0;
                    double vat = 0.0;

                    DataView Assets = DB.JobAsset.JobAsset_Get_For_Job(Job.JobID);

                    int numberOfAppliances = Assets.Table.Rows.Count;

                    int numberOfPages = Math.Ceiling(numberOfAppliances / (double)5);
                    if (numberOfPages == 0)
                        numberOfPages += 1;

                    int currentPage = 1;

                    Sites.Site ositeHQ = null/* TODO Change to default(_) if this is not a reference type */;
                    if (!oSite.CustomerID == Enums.Customer.Domestic)
                        ositeHQ = DB.Sites.Get(oSite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                    foreach (System.Text.RegularExpressions.Match wordField in GetTemplateFields(WordDoc.Content.Text))
                    {
                        switch (wordField.Value.ToLower())
                        {
                            case object _ when "[JobVisitNumber]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Job.JobNumber + "-" + EngineerVisit.EngineerVisitID);
                                    break;
                                }

                            case object _ when "[VisitDate]".ToLower():
                                {
                                    if (visitDate == default(DateTime))
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, visitDate.ToLongDateString());
                                    break;
                                }

                            case object _ when "[GasSafeIDNo]".ToLower():
                                {
                                    if (engineer == null)
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, engineer.GasSafeNo);
                                    break;
                                }

                            case object _ when "[JobCustomerName]".ToLower():
                                {
                                    PickLists.PickList selected = DB.Picklists.Get_One_As_Object(EngineerVisit.SignatureSelectedID);
                                    if (selected == null)
                                        ReplaceText(ref WordDoc, wordField.Value, EngineerVisit.CustomerName);
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, selected.Name + " " + EngineerVisit.CustomerName);
                                    break;
                                }

                            case object _ when "[JobAddressName]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.Name);
                                    break;
                                }

                            case object _ when "[JobAddress1]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.Address1);
                                    break;
                                }

                            case object _ when "[JobAddress2]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.Address2);
                                    break;
                                }

                            case object _ when "[JobAddress3]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.Address3);
                                    break;
                                }

                            case object _ when "[JobPostCode]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.FormatPostcode(oSite.Postcode));
                                    break;
                                }

                            case object _ when "[JobTelNo]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, oSite.TelephoneNum);
                                    break;
                                }

                            case object _ when "[LandLordName]".ToLower():
                                {
                                    if (!ositeHQ == null)
                                        ReplaceText(ref WordDoc, wordField.Value, DB.Customer.Customer_Get(oSite.CustomerID).Name);
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    break;
                                }

                            case object _ when "[LandLordAddress1]".ToLower():
                                {
                                    if (!ositeHQ == null)
                                    {
                                        string strAddress = string.Empty;

                                        if (ositeHQ.Address1.Length > 0)
                                            strAddress += ositeHQ.Address1;

                                        ReplaceText(ref WordDoc, wordField.Value, strAddress);
                                    }
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    break;
                                }

                            case object _ when "[LandLordAddress2]".ToLower():
                                {
                                    if (!ositeHQ == null)
                                    {
                                        string strAddress = string.Empty;

                                        if (ositeHQ.Address2.Length > 0)
                                            strAddress += ositeHQ.Address2;

                                        ReplaceText(ref WordDoc, wordField.Value, strAddress);
                                    }
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    break;
                                }

                            case object _ when "[LandLordAddress3]".ToLower():
                                {
                                    if (!ositeHQ == null)
                                    {
                                        string strAddress = string.Empty;

                                        if (ositeHQ.Address3.Length > 0)
                                            strAddress += ositeHQ.Address3;

                                        ReplaceText(ref WordDoc, wordField.Value, strAddress);
                                    }
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    break;
                                }

                            case object _ when "[LLPostcode]".ToLower():
                                {
                                    if (!ositeHQ == null)
                                        ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.FormatPostcode(ositeHQ.Postcode));
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    break;
                                }

                            case object _ when "[LLTelNo]".ToLower():
                                {
                                    if (!ositeHQ == null)
                                        ReplaceText(ref WordDoc, wordField.Value, ositeHQ.TelephoneNum);
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    break;
                                }

                            case object _ when "[PO]".ToLower():
                                {
                                    if (Job.PONumber.Trim.Length == 0)
                                        ReplaceText(ref WordDoc, wordField.Value, "N/A");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, Job.PONumber);
                                    break;
                                }

                            case object _ when "[From]".ToLower():
                                {
                                    DateTime sd = Helper.MakeDateTimeValid(EngineerVisit.StartDateTime);
                                    if (sd == default(DateTime))
                                    {
                                        if (Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn) == null/* TODO Change to default(_) if this is not a reference type */ )
                                            ReplaceText(ref WordDoc, wordField.Value, "");
                                        else
                                        {
                                            sd = Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn);
                                            ReplaceText(ref WordDoc, wordField.Value, sd.ToShortTimeString());
                                        }
                                    }
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, sd.ToShortTimeString());
                                    break;
                                }

                            case object _ when "[To]".ToLower():
                                {
                                    DateTime ed = Helper.MakeDateTimeValid(EngineerVisit.EndDateTime);
                                    if (ed == default(DateTime))
                                    {
                                        if (Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn) == null/* TODO Change to default(_) if this is not a reference type */ )
                                            ReplaceText(ref WordDoc, wordField.Value, "");
                                        else
                                        {
                                            ed = Helper.MakeDateTimeValid(EngineerVisit.ManualEntryOn);
                                            ReplaceText(ref WordDoc, wordField.Value, ed.ToShortTimeString());
                                        }
                                    }
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, ed.ToShortTimeString());
                                    break;
                                }

                            case object _ when "[GASSAFEID]".ToLower():
                                {
                                    Engineers.Engineer eng = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
                                    if (eng == null)
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, eng.GasSafeNo);
                                    break;
                                }

                            case object _ when "[Engineer]".ToLower():
                                {
                                    Engineers.Engineer eng = DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
                                    if (eng == null)
                                        ReplaceText(ref WordDoc, wordField.Value, "");
                                    else
                                        ReplaceText(ref WordDoc, wordField.Value, eng.Name);
                                    break;
                                }

                            case object _ when "[WorkRequired]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, EngineerVisit.NotesToEngineer);
                                    break;
                                }
                        }
                    }

                    MsWordApp.Selection.WholeStory();
                    MsWordApp.Selection.Copy();

                    numberOfAppliances = Add_Appliances_PreVisit(WordDoc, numberOfAppliances, currentPage, numberOfPages, Assets.Table, null/* TODO Change to default(_) if this is not a reference type */, 1);
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
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool SiteLetter(string template, string savePath)
            {
                try
                {
                    Contacts.Contact oContact = DB.Contact.Contact_Get(DetailsToPrint.item(0));
                    Sites.Site oSite = DB.Sites.Get(DetailsToPrint.item(1));

                    byte[] byteArray = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();
                    using ((mm))
                    {
                        mm.Write(byteArray, 0, byteArray.Length);
                        WordprocessingDocument wordDoc = WordprocessingDocument.Open(mm, true);
                        using ((wordDoc))
                        {
                            AddCompanyDetails(wordDoc, true, true);
                            string name = oContact == null ? oSite.Name : oContact.FirstName + " " + oContact.Surname;
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
                        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;
                        using ((fileStream))
                            mm.WriteTo(fileStream);

                        Documentss.Documents linkedDoc = new Documentss.Documents();
                        linkedDoc.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblSite);
                        linkedDoc.SetRecordID = oSite.SiteID;
                        linkedDoc.SetDocumentTypeID = 205;
                        linkedDoc.SetName = Path.GetFileName(savePath);
                        linkedDoc.SetNotes = "";
                        linkedDoc.SetLocation = savePath;

                        Documentss.DocumentsValidator cV = new Documentss.DocumentsValidator();
                        cV.Validate(linkedDoc);

                        linkedDoc = DB.Documents.Insert(linkedDoc);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (System.Convert.ToBoolean(r("Tick")) == true)
                        {
                            {
                                var withBlock = WordDoc.Tables.Item(1);
                                {
                                    var withBlock1 = withBlock.Rows.Add();
                                    withBlock1.Range.Font.Bold = System.Convert.ToInt32(false);
                                    withBlock1.Range.Font.Size = 7;
                                    withBlock1.Range.Borders.Item(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone;
                                    withBlock1.Range.Borders.Item(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleNone;
                                }
                                rowIndex += 1;

                                withBlock.Cell(rowIndex, 1).Range.Text = Helper.MakeStringValid(r("CreditReference"));
                                withBlock.Cell(rowIndex, 2).Range.Text = Helper.MakeStringValid(r("OrderReference"));
                                withBlock.Cell(rowIndex, 3).Range.Text = Helper.MakeStringValid(r("PartNumber"));
                                withBlock.Cell(rowIndex, 4).Range.Text = Helper.MakeStringValid(r("PartName"));
                                withBlock.Cell(rowIndex, 5).Range.Text = Helper.MakeIntegerValid(r("Qty"));
                                withBlock.Cell(rowIndex, 6).Range.Text = Strings.Format(Helper.MakeDoubleValid(r("Price")), "C");
                                withBlock.Cell(rowIndex, 7).Range.Text = Strings.Format(Helper.MakeDoubleValid(r("Total")), "C");
                                withBlock.Cell(rowIndex, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                Supplier = Helper.MakeStringValid(r.Item("Supplier"));
                                address1 = Helper.MakeStringValid(r.Item("Address1"));
                                address2 = Helper.MakeStringValid(r.Item("Address2"));
                                address3 = Helper.MakeStringValid(r.Item("Address3"));
                                address4 = Helper.MakeStringValid(r.Item("Address4"));
                                address5 = Helper.MakeStringValid(r.Item("Address5"));
                                postcode = Helper.FormatPostcode(r.Item("Postcode"));
                                accountNumber = Helper.MakeStringValid(r.Item("GaswayAccount"));
                            }
                        }
                    }

                    foreach (System.Text.RegularExpressions.Match wordField in GetTemplateFields(WordDoc.Content.Text))
                    {
                        switch (wordField.Value.ToLower())
                        {
                            case object _ when "[CombinedCreditNumber]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, "");
                                    break;
                                }

                            case object _ when "[Name]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Supplier);
                                    break;
                                }

                            case object _ when "[Address1]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, address1);
                                    break;
                                }

                            case object _ when "[Address2]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, address2);
                                    break;
                                }

                            case object _ when "[Address3]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, address3);
                                    break;
                                }

                            case object _ when "[Address4]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, address4);
                                    break;
                                }

                            case object _ when "[Address5]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, address5);
                                    break;
                                }

                            case object _ when "[Postcode]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Sys.Helper.FormatPostcode(postcode));
                                    break;
                                }

                            case object _ when "[Date]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, Strings.Format(DateTime.Now, "dd MMMM yyyy"));
                                    break;
                                }

                            case object _ when "[OUR_ACCOUNT_SUPPLIER]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, accountNumber);
                                    break;
                                }

                            case object _ when "[User]".ToLower():
                                {
                                    ReplaceText(ref WordDoc, wordField.Value, loggedInUser.Fullname);
                                    break;
                                }
                        }
                    }
                    WordDoc.Content.Font.Name = "Arial";
                    WordDoc.Tables.Item(1).AllowAutoFit = true;
                    WordDoc.Tables.Item(1).AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
                    WordDoc.Tables.Item(1).Range.Font.Size = 8;

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (System.Convert.ToBoolean(r("Tick")) == true)
                        {
                            {
                                var withBlock = WordDoc.Tables.Item(1);
                                if (!rowIndex == 1)
                                {
                                    {
                                        var withBlock1 = withBlock.Rows.Add();
                                        withBlock1.Range.Font.Bold = System.Convert.ToInt32(false);
                                        withBlock1.Range.Font.Size = 7;
                                    }
                                }
                                rowIndex += 1;
                                withBlock.Cell(rowIndex, 1).Range.Text = "";
                                withBlock.Cell(rowIndex, 2).Range.Text = Helper.MakeStringValid(r("PartName"));
                                withBlock.Cell(rowIndex, 2).WordWrap = true;
                                withBlock.Cell(rowIndex, 3).Range.Text = Helper.MakeStringValid(r("PartNumber"));
                                withBlock.Cell(rowIndex, 3).WordWrap = true;
                                withBlock.Cell(rowIndex, 4).Range.Text = "";
                                withBlock.Cell(rowIndex, 5).Range.Text = "";
                                withBlock.Cell(rowIndex, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                withBlock.Cell(rowIndex, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                        }
                    }
                    WordDoc.Content.Font.Name = "Arial";
                    WordDoc.Tables.Item(1).AllowAutoFit = true;
                    WordDoc.Tables.Item(1).AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);
                    WordDoc.Tables.Item(1).Range.Font.Size = 8;
                    WordDoc.Tables.Item(1).Rows.Item(1).Range.Font.Size = 11;
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    case object _ when filename.ToLower() == "GSRCoveringLetter".ToLower():
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
                DataTable dtDdmsNew = new DataTable();
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
                DataTable dtDdmsAmend = new DataTable();
                dtDdmsAmend = dtDdmsNew.Clone();

                try
                {
                    foreach (DataRow dr in drContracts)
                    {
                        string ddmsRef = Helper.MakeStringValid(dr("DDMSRef"));
                        string contractRef = Helper.MakeStringValid(dr("ContractReference"));
                        string payType = Helper.MakeStringValid(dr("Type"));
                        int siteId = Helper.MakeIntegerValid(dr("siteid"));
                        int installments = Helper.MakeIntegerValid(dr("installments"));
                        int pifId = (Helper.MakeIntegerValid(dr("PreviousInvoiceFrequencyID")) == 0) ? Helper.MakeIntegerValid(dr("InvoiceFrequencyID")) : Helper.MakeIntegerValid(dr("PreviousInvoiceFrequencyID"));
                        Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Helper.MakeIntegerValid(dr("InvoiceFrequencyID"));
                        bool paymentMade = false;

                        if (installments % 12 == 0 && installments != 0)
                        {
                        }
                        else
                            paymentMade = true;

                        DateTime processing = Helper.MakeDateTimeValid(dr("DDProcessingDate"));
                        DateTime contractEnd = Helper.MakeDateTimeValid(dr("ContractEndDate"));
                        Simple3Des wrapper = new Simple3Des(p);
                        string ddSort = string.Empty;
                        string ddAcc = string.Empty;

                        try
                        {
                            ddSort = wrapper.DecryptData(Helper.MakeStringValid(dr("sc")));
                            ddAcc = wrapper.DecryptData(Helper.MakeStringValid(dr("Ac")));
                        }
                        catch (Exception ex)
                        {
                        }

                        object cc = null;

                        if (ddmsRef.Length > 3)
                            cc = App.DB.ExecuteScalar("SELECT COUNT(DDMSREF) FROM tblContractOriginal co " + "INNER JOIN tblContractOriginalSite cos ON cos.ContractID = co.ContractID " + "Where co.Deleted = 0 AND co.DDMSREF = '" + ddmsRef + "' AND cos.SiteID <> " + siteId);
                        else
                            cc = App.DB.ExecuteScalar("SELECT COUNT(DDMSREF) FROM tblContractOriginal co " + "INNER JOIN tblContractOriginalSite cos ON cos.ContractID = co.ContractID " + "Where co.Deleted = 0 AND co.DDMSREF = '" + contractRef + "' AND cos.SiteID <> " + siteId);

                        if (Helper.MakeIntegerValid(cc) < 1)
                        {
                            double priceDiff = Helper.MakeDoubleValid(dr("FirstAmount")) - Helper.MakeDoubleValid(dr("SecondPayment"));
                            DataRow drDDMSNew = dtDdmsNew.NewRow();
                            drDDMSNew("Ref") = (ddmsRef.Length > 3) ? ddmsRef : contractRef;
                            drDDMSNew("Salutation") = Helper.MakeStringValid(dr("PayerSalutation")).Replace(",", "");
                            drDDMSNew("FirstName") = Helper.MakeStringValid(dr("PayerFirst")).Replace(",", "");
                            drDDMSNew("LastName") = Helper.MakeStringValid(dr("PayerSurname")).Replace(",", "");
                            drDDMSNew("Address1") = Helper.MakeStringValid(dr("PayerAddress1")).Replace(",", "");
                            drDDMSNew("Address2") = Helper.MakeStringValid(dr("PayerAddress2")).Replace(",", "");
                            drDDMSNew("Address3") = Helper.MakeStringValid(dr("PayerAddress3")).Replace(",", "");
                            drDDMSNew("Address4") = Helper.MakeStringValid(dr("PayerAddress4")).Replace(",", "");
                            drDDMSNew("Tel") = Helper.MakeStringValid(dr("PayerTel")).Replace(",", "");
                            drDDMSNew("Postcode") = Helper.FormatPostcode(dr("PayerPostCode")).Replace(",", "");
                            drDDMSNew("SortCode") = ddSort;
                            drDDMSNew("AccNum") = ddAcc;
                            drDDMSNew("NameOnAcc") = (Helper.MakeStringValid(dr("AccName")).Length > 0) ? Helper.MakeStringValid(dr("AccName")).Replace(",", "") : Helper.MakeStringValid(dr("PayerName")).Replace(",", "");
                            drDDMSNew("Ref2") = (ddmsRef.Length > 3) ? ddmsRef : contractRef;
                            drDDMSNew("InvoiceNumber") = Helper.MakeStringValid(dr("InvoiceNumber")).Replace(",", "");
                            drDDMSNew("Type") = "17";
                            drDDMSNew("SecondPayment") = Helper.MakeStringValid(dr("SecondPayment")).Replace(",", "");
                            drDDMSNew("FirstPayment") = (paymentMade) ? "0" : Helper.MakeStringValid(priceDiff.ToString());
                            drDDMSNew("ProcessDate") = (!paymentMade) ? DateHelper.GetFirstDayOfMonth(processing).ToString("dd/MM/yyyy") : DateHelper.GetFirstDayOfMonth(processing.AddMonths(1)).ToString("dd/MM/yyyy");
                            drDDMSNew("Installments") = Helper.MakeStringValid(dr("Installments")).Replace(",", "");
                            drDDMSNew("SecondPayment2") = Helper.MakeStringValid(dr("SecondPayment"));
                            drDDMSNew("SecondPayment3") = (paymentMade) ? Helper.MakeStringValid(dr("SecondPayment")) : Helper.MakeStringValid(dr("FirstAmount"));
                            drDDMSNew("ContractEnd") = contractEnd.ToString("dd/MM/yyyy");

                            if (Helper.MakeIntegerValid(dr("Renewed")) == 0 || (pifId != Helper.MakeIntegerValid(dr("InvoiceFrequencyID"))) || payType == "TRANSD" || payType == "AMMENDD" || payType == "RENEWALD")
                            {
                                if (installments == 0 && invoiceFreq != Enums.InvoiceFrequency.AnnuallyDD)
                                {
                                }
                                else
                                    dtDdmsNew.Rows.Add(drDDMSNew);
                            }
                            else if (payType != "AMMEND" && payType != "TRANS")
                            {
                                if (installments == 0)
                                {
                                }
                                else
                                    dtDdmsAmend.Rows.Add(drDDMSNew.ItemArray);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate ddms : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    string ddmsNewCsv = "DDMS_IMPORT_NEW" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".csv";
                    string ddmsAmendCsv = "DDMS_IMPORT_RENEW_AMMEND" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".csv";
                    string ddmsNewCsvData = ExportHelper.DataTableToCSVNoHeaders(dtDdmsNew);
                    string ddmsAmendCsvData = string.Format(ExportHelper.DataTableToCSVNoHeaders(dtDdmsAmend));
                    string fileDir = TheSystem.Configuration.DocumentsLocation + @"Contracts\DDMS\";
                    Directory.CreateDirectory(fileDir);
                    FileStream fsDdmsNew = new FileStream(fileDir + ddmsNewCsv, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    using (fsDdmsNew)
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(ddmsNewCsvData);
                        fsDdmsNew.Write(info, 0, info.Length);
                    }

                    fsDdmsNew.Close();
                    FileStream fsDdmsAmend = new FileStream(fileDir + ddmsAmendCsv, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    using (fsDdmsAmend)
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(ddmsAmendCsvData);
                        fsDdmsAmend.Write(info, 0, info.Length);
                    }

                    fsDdmsAmend.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate ddms : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private string GenerateRenewalLetters(DataRow[] drContracts)
            {
                string fileName = "Contract_Renewal_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                string fileDir = TheSystem.Configuration.DocumentsLocation + @"Contracts\Renewal";
                Directory.CreateDirectory(fileDir);
                string filePath = fileDir + @"\" + fileName;
                File.Copy(Application.StartupPath + @"\Templates\Blank.docx", filePath);

                try
                {
                    WordprocessingDocument batch = WordprocessingDocument.Open(filePath, true);
                    using (batch)
                        foreach (DataRow dr in drContracts)
                        {
                            string payType = Helper.MakeStringValid(dr("Type"));
                            bool success = false;
                            bool renewed = Helper.MakeBooleanValid(dr("Renewed"));
                            Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Helper.MakeIntegerValid(dr("InvoiceFrequencyID"));
                            int installments = Helper.MakeIntegerValid(dr("installments"));

                            if (payType == "AMMEND" || payType == "TRANS")
                            {
                            }
                            else if ((!renewed && installments > 0) | (payType == "TRANSD" || payType == "RENEWALD" || payType == "AMMENDD") | (!renewed && invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD))
                            {
                                success = GenerateDDLetter(dr, batch);

                                if (!success)
                                    throw new Exception();
                            }
                            else if (installments > 0)
                            {
                                success = GenerateDDRenewalLetter(dr, batch);

                                if (!success)
                                    throw new Exception();
                            }

                            success = GenerateContractLetter(dr, batch);

                            if (!success)
                                throw new Exception();

                            if (!string.IsNullOrEmpty(Helper.MakeStringValid(dr("InvoiceNumber"))))
                            {
                                if (string.IsNullOrEmpty(Helper.MakeStringValid(dr("InitialPaymentType"))) || Helper.MakeStringValid(dr("InitialPaymentType")) != "Invoice")
                                {
                                    success = GenerateReceipt(dr, batch);

                                    if (!success)
                                        throw new Exception();
                                }
                                else
                                {
                                    success = GenerateContractInvoice(dr, batch);

                                    if (!success)
                                        throw new Exception();
                                }
                            }

                            if (payType == "TRANS")
                            {
                                success = GenerateTransferLetter(dr, batch);

                                if (!success)
                                    throw new Exception();
                            }
                        }

                    return filePath;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate renewal letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }

            private bool GenerateDDLetter(DataRow dr, WordprocessingDocument batch)
            {
                try
                {
                    if (Helper.MakeStringValid(dr("UpgradedFrom")).Length > 0)
                        return true;
                    Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Helper.MakeIntegerValid(dr("InvoiceFrequencyID"));
                    string template = Application.StartupPath + @"\Templates\Contracts";
                    template += (invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD) ? @"\ContractDDA.docx" : @"\ContractDD.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")));
                    byte[] fileByte = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);
                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                            string companyName = (Helper.MakeStringValid(dr("PayerSalutation")).Length > 0) ? Helper.MakeStringValid(dr("PayerSalutation") + " " + dr("PayerSurname")) : Helper.MakeStringValid(dr("PayerName"));
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName);
                            PrintHelper.ReplaceText(doc, "[Name]", companyName);
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("PayerAddress1")));
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("PayerAddress2")));
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("PayerAddress3")));
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("PayerPostcode")));
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr("ContractType")));
                            string ddmsRef = (Helper.MakeStringValid(dr("DDMSRef")).Length > 3) ? Helper.MakeStringValid(dr("DDMSRef")) : Helper.MakeStringValid(dr("ContractReference"));
                            PrintHelper.ReplaceText(doc, "[DebitRef]", ddmsRef);
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(dr("ContractReference") + " - " + dr("siteAddress1") + ", " + dr("siteAddress2") + ", " + dr("sitePostcode")));
                            int installments = Helper.MakeIntegerValid(dr("installments"));
                            bool paymentMade = false;
                            DateTime contractStart = Helper.MakeDateTimeValid(dr("ContractStartDate"));
                            DateTime processing = Helper.MakeDateTimeValid(dr("DDProcessingDate"));

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

                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(dr("siteAddress1") + ", " + dr("siteAddress2") + ", " + dr("sitePostcode")));
                            PrintHelper.ReplaceText(doc, "[First]", (paymentMade) ? Helper.MakeDoubleValid(dr("SecondPayment")).ToString("C") : Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[Second]", Helper.MakeDoubleValid(dr("SecondPayment")).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[Inst]", (Helper.MakeIntegerValid(dr("Installments")) - 1).ToString());
                            string acName = (Helper.MakeStringValid(dr("AccName")).Length > 0) ? Helper.MakeStringValid(dr("AccName")) : Helper.MakeStringValid(dr("PayerName"));
                            PrintHelper.ReplaceText(doc, "[AcName]", acName);
                            Simple3Des wrapper = new Simple3Des(p);
                            string ddSort = string.Empty;
                            string ddAcc = string.Empty;

                            try
                            {
                                ddSort = wrapper.DecryptData(Helper.MakeStringValid(dr("sc")));
                                ddAcc = wrapper.DecryptData(Helper.MakeStringValid(dr("Ac")));
                            }
                            catch
                            {
                            }

                            PrintHelper.ReplaceText(doc, "[AcNumber]", ddAcc);
                            PrintHelper.ReplaceText(doc, "[ScCode]", ddSort);
                            double ahe = System.Convert.ToDouble(DB.Picklists.Get_Single_Description("AHE", 52));
                            PrintHelper.ReplaceText(doc, "[AHE]", (invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD) ? ahe.ToString("C") : Math.Round(ahe / 12, 2).ToString("C"));
                            int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                            int addBreaks = 1;
                            addBreaks += (pageCount % 2 == 0) ? 0 : 1;

                            for (int i = 0; i <= addBreaks - 1; i++)
                                doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());

                            doc.MainDocumentPart.Document.Save();
                            string saveDir = TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr("ContractReference"));
                            Directory.CreateDirectory(saveDir);
                            string fileName = "DD_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;

                            using (fileStream)
                                mm.WriteTo(fileStream);

                            fileStream.Close();
                        }

                        MainDocumentPart mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr("ContractID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;

                        using (mm)
                            chunk.FeedData(mm);

                        WP.AltChunk altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate dd letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateDDRenewalLetter(DataRow dr, WordprocessingDocument batch)
            {
                try
                {
                    Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Helper.MakeIntegerValid(dr("InvoiceFrequencyID"));
                    string template = Application.StartupPath + @"\Templates\Contracts";
                    template += (invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD) ? @"\ContractDDARenewal.docx" : @"\ContractDDRenewal.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")));
                    byte[] fileByte = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);

                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                            string companyName = (Helper.MakeStringValid(dr("PayerSalutation")).Length > 0) ? Helper.MakeStringValid(dr("PayerSalutation") + " " + dr("PayerSurname")) : Helper.MakeStringValid(dr("PayerName"));
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName);
                            PrintHelper.ReplaceText(doc, "[Name]", companyName);
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("PayerAddress1")));
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("PayerAddress2")));
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("PayerAddress3")));
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("PayerPostcode")));
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr("ContractType")));
                            string ddmsRef = (Helper.MakeStringValid(dr("DDMSRef")).Length > 3) ? Helper.MakeStringValid(dr("DDMSRef")) : Helper.MakeStringValid(dr("ContractReference"));
                            PrintHelper.ReplaceText(doc, "[DebitRef]", ddmsRef);
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(dr("ContractReference") + " - " + dr("siteAddress1") + ", " + dr("siteAddress2") + ", " + dr("sitePostcode")));
                            int installments = Helper.MakeIntegerValid(dr("installments"));
                            bool paymentMade = false;
                            DateTime contractStart = Helper.MakeDateTimeValid(dr("ContractStartDate"));
                            DateTime processing = Helper.MakeDateTimeValid(dr("DDProcessingDate"));

                            if ((installments % 12 == 0 && installments != 0) | (invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD && installments == 1))
                                PrintHelper.ReplaceText(doc, "[FirstDate]", (contractStart.Day == 1) ? DateHelper.GetFirstDayOfMonth(contractStart).ToString("dd/MM/yyyy") : DateHelper.GetFirstDayOfMonth(contractStart.AddMonths(1)).ToString("dd/MM/yyyy"));
                            else
                            {
                                paymentMade = true;
                                PrintHelper.ReplaceText(doc, "[FirstDate]", DateHelper.GetFirstDayOfMonth(contractStart.AddMonths(2)).ToString("dd/MM/yyyy"));
                            }

                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(dr("siteAddress1") + ", " + dr("siteAddress2") + ", " + dr("sitePostcode")));
                            PrintHelper.ReplaceText(doc, "[First]", (paymentMade) ? Helper.MakeDoubleValid(dr("SecondPayment")).ToString("C") : Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[Second]", Helper.MakeDoubleValid(dr("SecondPayment")).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[Inst]", (Helper.MakeIntegerValid(dr("Installments")) - 1).ToString());
                            PrintHelper.ReplaceText(doc, "[Inst2]", (Helper.MakeIntegerValid(dr("Installments"))).ToString());

                            double monthlyApp = 0.0;
                            int contractType = Helper.MakeIntegerValid(dr("ContractTypeID"));
                            if (contractType == System.Convert.ToInt32(Enums.ContractTypes.PlatinumStar))
                                monthlyApp = System.Convert.ToDouble(DB.Picklists.Get_Single_Description("PS Additional Monthly", 52));
                            else
                                monthlyApp = System.Convert.ToDouble(DB.Picklists.Get_Single_Description("Additional Monthly", 52));
                            PrintHelper.ReplaceText(doc, "[MonthApp]", (invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD) ? Math.Round(monthlyApp * 12, 2).ToString("C") : monthlyApp.ToString("C"));
                            double ahe = System.Convert.ToDouble(DB.Picklists.Get_Single_Description("AHE", 52));
                            PrintHelper.ReplaceText(doc, "[AHE]", (invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD) ? ahe.ToString("C") : Math.Round(ahe / 12, 2).ToString("C"));
                            PrintHelper.ReplaceText(doc, "[UserName]", TheSystem.Configuration.CompanyName + " Coverplan Team");
                            int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                            int addBreaks = 1;
                            addBreaks += (pageCount % 2 == 0) ? 0 : 1;

                            for (int i = 0; i <= addBreaks - 1; i++)
                                doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());

                            doc.MainDocumentPart.Document.Save();
                            string saveDir = TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr("ContractReference"));
                            Directory.CreateDirectory(saveDir);
                            string fileName = "DDRenewal_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;

                            using (fileStream)
                                mm.WriteTo(fileStream);

                            fileStream.Close();
                        }

                        MainDocumentPart mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr("ContractID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;

                        using (mm)
                            chunk.FeedData(mm);

                        WP.AltChunk altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate dd renewal letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateContractLetter(DataRow dr, WordprocessingDocument batch = null/* TODO Change to default(_) if this is not a reference type */)
            {
                try
                {
                    string template = Application.StartupPath + @"\Templates\Contracts\ContractOption11.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")));
                    byte[] fileByte = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);

                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            string customerName = (Helper.MakeIntegerValid(dr("CustomerID")) == System.Convert.ToInt32(Enums.Customer.Domestic)) ? Helper.MakeStringValid(dr("SiteName")) : Helper.MakeStringValid(dr("CustName"));
                            DataView dvAdditionalContacts = DB.Contact.Contacts_GetAll_ForLink(System.Convert.ToInt32(Enums.TableNames.tblSite), Helper.MakeIntegerValid(dr("SiteID")));
                            DataRow[] drOnContractContacts = dvAdditionalContacts.Table.Select("OnContract = 1");
                            foreach (DataRow drContact in drOnContractContacts)
                                customerName += " / " + Helper.MakeStringValid(drContact("Title")) + " " + Helper.MakeStringValid(drContact("FirstName")) + " " + Helper.MakeStringValid(drContact("LastName"));
                            PrintHelper.ReplaceText(doc, "[CustomerName]", customerName);
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("SiteAddress1")));
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("SiteAddress2")));
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("SiteAddress3")));
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("SitePostcode")));
                            PrintHelper.ReplaceText(doc, "[ContractType]", Helper.MakeStringValid(dr("ContractType")));
                            PrintHelper.ReplaceText(doc, "[ContractReference]", Helper.MakeStringValid(dr("ContractReference")));
                            PrintHelper.ReplaceText(doc, "[ContractStart]", Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy"));
                            PrintHelper.ReplaceText(doc, "[ContractEnd]", Helper.MakeDateTimeValid(dr("ContractEndDate")).ToString("dd/MM/yyyy"));
                            double contractTotal = Math.Round(Helper.MakeDoubleValid(dr("ContractPrice")) * 1.2, 2);
                            PrintHelper.ReplaceText(doc, "[Total]", contractTotal.ToString("C"));
                            DataRow[] drAssets = DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(Helper.MakeIntegerValid(dr("ContractSiteID")), Helper.MakeIntegerValid(dr("SiteID"))).Table.Select("Tick = 1");
                            DataTable dtAssets = new DataTable();
                            dtAssets.Columns.Add("ApplianceCount");
                            dtAssets.Columns.Add("Appliance");
                            int primaryAssetCount = 0;
                            int secondaryAssetCount = 0;
                            int count = 1;

                            if (drAssets.Count > 0)
                            {
                                DataRow[] drPrimaryAssets = (from a in drAssets.CopyToDataTable().AsEnumerable
                                                             where Helper.MakeBooleanValid(a("PrimAsset")) == true
                                                             select a).ToArray();
                                primaryAssetCount = drPrimaryAssets.Length;

                                foreach (DataRow drContractAsset in drPrimaryAssets)
                                {
                                    DataRow drAsset = dtAssets.NewRow();
                                    drAsset("ApplianceCount") = "APPLIANCE " + count;
                                    drAsset("Appliance") = drContractAsset("Product");
                                    dtAssets.Rows.Add(drAsset);
                                    count += 1;
                                }

                                DataRow[] drSecondaryAssets = (from a in drAssets.CopyToDataTable().AsEnumerable
                                                               where Helper.MakeBooleanValid(a("PrimAsset")) == false
                                                               select a).ToArray();
                                secondaryAssetCount = drSecondaryAssets.Length;

                                foreach (DataRow drContractAsset in drSecondaryAssets)
                                {
                                    DataRow drAsset = dtAssets.NewRow();
                                    drAsset("ApplianceCount") = "APPLIANCE " + count;
                                    drAsset("Appliance") = drContractAsset("Product");
                                    dtAssets.Rows.Add(drAsset);
                                    count += 1;
                                }
                            }

                            for (int i = 0; i <= (Helper.MakeIntegerValid(dr("MainAppliances")) - primaryAssetCount) - 1; i++)
                            {
                                DataRow drAsset = dtAssets.NewRow();
                                drAsset("ApplianceCount") = "APPLIANCE " + count;
                                drAsset("Appliance") = (string.IsNullOrEmpty(Helper.MakeStringValid(dr("ManualApp")))) ? "UNKNOWN APPLIANCE" : Helper.MakeStringValid(dr("ManualApp"));
                                dtAssets.Rows.Add(drAsset);
                                count += 1;
                            }

                            for (int i = 0; i <= (Helper.MakeIntegerValid(dr("SecondryAppliances")) - secondaryAssetCount) - 1; i++)
                            {
                                DataRow drAsset = dtAssets.NewRow();
                                drAsset("ApplianceCount") = "APPLIANCE " + count;
                                drAsset("Appliance") = (string.IsNullOrEmpty(Helper.MakeStringValid(dr("ManualApp")))) ? "UNKNOWN APPLIANCE" : Helper.MakeStringValid(dr("SecondApp"));
                                dtAssets.Rows.Add(drAsset);
                                count += 1;
                            }

                            PrintHelper.ReplaceBookmarkWithTable(doc, "ApplianceTable", dtAssets, false, Enums.TableCellProperties.ContractAppliance);
                            bool hasWindowLockPest = Helper.MakeBooleanValid(dr("WindowLockPest"));
                            bool hasPlumbingDrainage = Helper.MakeBooleanValid(dr("PlumbingDrainage"));
                            bool hasGasSupplyPipework = Helper.MakeBooleanValid(dr("GasSupplyPipework"));
                            PrintHelper.ReplaceText(doc, "[GasSupplyPipework]", (hasGasSupplyPipework) ? "Yes" : "No");
                            PrintHelper.ReplaceText(doc, "[PlumbingDrainage]", (hasPlumbingDrainage) ? "Yes" : "No");
                            PrintHelper.ReplaceText(doc, "[WindowLockPest]", (hasWindowLockPest) ? "Yes" : "No");
                            PrintHelper.ReplaceText(doc, "[UserName]", TheSystem.Configuration.CompanyName + " Coverplan Team");
                            int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                            WP.Paragraph para = new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page }));
                            doc.MainDocumentPart.Document.Body.InsertAfter(para, doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            doc.MainDocumentPart.Document.Save();
                            string templateTnC = Application.StartupPath + @"\Templates\Contracts\ContractTermsAndConditions.docx";
                            byte[] fileByteTnC = File.ReadAllBytes(templateTnC);
                            MemoryStream mmTnC = new MemoryStream();

                            using (mmTnC)
                            {
                                mmTnC.Write(fileByteTnC, 0, fileByteTnC.Length);
                                WordprocessingDocument docTnC = WordprocessingDocument.Open(mmTnC, true);

                                using (docTnC)
                                {
                                    if (Helper.MakeIntegerValid(dr("DiscountID")) != System.Convert.ToInt32(Enums.ContractTypes.EmployeeFree))
                                    {
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef");
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef1");
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef2");
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef3");
                                        PrintHelper.DeleteBookmark(docTnC, "EmployeeRef4");
                                    }

                                    int termsPageCount = Helper.MakeIntegerValid(docTnC.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                                    int addBreaks = 1;
                                    addBreaks += ((pageCount + termsPageCount) % 2 == 0) ? 0 : 1;

                                    for (int i = 0; i <= addBreaks - 1; i++)
                                        docTnC.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), docTnC.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());

                                    docTnC.MainDocumentPart.Document.Save();
                                }

                                MainDocumentPart mainPartContract = doc.MainDocumentPart;
                                string altChunkIdContract = "AltId" + Helper.MakeIntegerValid(dr("ContractID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                                AlternativeFormatImportPart chunkContract = mainPartContract.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkIdContract);
                                mmTnC.Position = 0;

                                using (mmTnC)
                                    chunkContract.FeedData(mmTnC);

                                WP.AltChunk altChunkContract = new WP.AltChunk();
                                altChunkContract.Id = altChunkIdContract;
                                mainPartContract.Document.Body.InsertAfter(altChunkContract, mainPartContract.Document.Body.Elements<WP.Paragraph>().Last());
                                mainPartContract.Document.Save();
                            }
                        }

                        string saveDir = TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr("ContractReference"));
                        Directory.CreateDirectory(saveDir);
                        string fileName = "Contract_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                        string savePath = saveDir + @"\" + fileName;
                        savePath = FileCheck(savePath);
                        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        mm.Position = 0;

                        using (fileStream)
                            mm.WriteTo(fileStream);

                        fileStream.Close();
                        if (batch != null)
                        {
                            MainDocumentPart mainPart = batch.MainDocumentPart;
                            string altChunkId = "AltId" + Helper.MakeIntegerValid(dr("ContractID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                            AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            mm.Position = 0;

                            using (mm)
                                chunk.FeedData(mm);

                            WP.AltChunk altChunk = new WP.AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                            mainPart.Document.Save();
                        }
                        else
                            Process.Start(savePath);
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate contract letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateReceipt(DataRow dr, WordprocessingDocument batch, bool isCommercial = false, bool addPage = true)
            {
                try
                {
                    if (dr.Table.Columns.Contains("UpgradedFrom") && Helper.MakeStringValid(dr("UpgradedFrom")).Length > 0)
                        return true;
                    Enums.InvoiceFrequency invoiceFreq = (Enums.InvoiceFrequency)Helper.MakeIntegerValid(dr("InvoiceFrequencyID"));
                    string template = Application.StartupPath + @"\Templates\Invoice\Receipt.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")));
                    byte[] fileByte = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);

                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            AddCompanyDetails(doc, true, false, isCommercial);
                            PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dr("PayerName")));
                            PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dr("Payeraddress1")));
                            PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dr("PayerAddress2")));
                            PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dr("PayerAddress3")));
                            PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dr("PayerPostcode")));
                            PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(dr("InvoiceNumber")));
                            PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(dr("RaiseDate")).ToString("dd/MM/yyyy"));
                            PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dr("CustAcc")));
                            DataTable dtContract = new DataTable();
                            dtContract.Columns.Add("ContractReference");
                            dtContract.Columns.Add("Address");
                            dtContract.Columns.Add("Work");
                            dtContract.Columns.Add("Total");
                            DataRow drContract = dtContract.NewRow();
                            drContract("ContractReference") = (string.IsNullOrEmpty(Helper.MakeStringValid(dr("PoNumber")))) ? Helper.MakeStringValid(dr("ContractReference")) : Helper.MakeStringValid(dr("ContractReference") + " / " + dr("PoNumber"));
                            drContract("Address") = Helper.MakeStringValid(dr("SiteAddress1") + ", " + dr("SiteAddress2") + ", " + dr("SitePostcode"));
                            string payType = Helper.MakeStringValid(dr("Type"));
                            string contractType = Helper.MakeStringValid(dr("ContractType"));
                            int installments = Helper.MakeIntegerValid(dr("installments"));
                            bool paymentMade = false;
                            bool renewed = Helper.MakeBooleanValid(dr("Renewed"));
                            double contractTotal = Helper.MakeDoubleValid(dr("ContractPrice"));
                            double subTotal = 0.0;

                            if (installments % 12 == 0 && installments != 0)
                            {
                            }
                            else
                                paymentMade = true;

                            if (renewed && installments == 0)
                            {
                                drContract("Work") = contractType + " Coverplan Renewal " + Constants.vbCrLf + Constants.vbCrLf + "Paid " + Math.Round(contractTotal * 1.2, 2).ToString("C") + " by " + Helper.MakeStringValid(dr("InitialPaymentType")) + ", received with thanks." + "" + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for renewing your plan.";
                                drContract("Total") = contractTotal.ToString("C");
                                subTotal += contractTotal;
                            }
                            else if (installments == 0)
                            {
                                drContract("Work") = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "Paid " + Math.Round(contractTotal * 1.2, 2).ToString("C") + " by " + Helper.MakeStringValid(dr("InitialPaymentType")) + ", received with thanks. " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for taking out this plan.";
                                drContract("Total") = contractTotal.ToString("C");
                                subTotal += contractTotal;
                            }
                            else if (installments == 1 || invoiceFreq == Enums.InvoiceFrequency.AnnuallyDD)
                            {
                                drContract("Work") = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "1 payment of " + Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C") + " to be paid annually by direct debit" + "" + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for taking out this plan.";
                                drContract("Total") = Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (installments > 0 && paymentMade && (payType == "AMMENDD" || payType == "TRANSD" || payType == "RENEWALD"))
                            {
                                drContract("Work") = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "1st payment of " + Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C") + " paid by " + Helper.MakeStringValid(dr("InitialPaymentType")) + ", received with thanks. " + installments + " payments to be paid by monthly direct debit " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for renewing your plan.";
                                drContract("Total") = Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (installments > 0 && paymentMade)
                            {
                                drContract("Work") = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "1st payment of " + Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C") + " paid by " + Helper.MakeStringValid(dr("InitialPaymentType")) + ", received with thanks. " + installments + " payments to be paid by monthly direct debit " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for taking out this plan.";
                                drContract("Total") = Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero);
                            }
                            else if (installments > 0)
                            {
                                drContract("Work") = contractType + " Coverplan commencing " + Helper.MakeDateTimeValid(dr("ContractStartDate")).ToString("dd/MM/yyyy") + "." + Constants.vbCrLf + Constants.vbCrLf + "1 payment of " + Helper.MakeDoubleValid(dr("FirstAmount")).ToString("C") + " to be paid by Annual direct debit " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for taking out this plan.";
                                drContract("Total") = Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                                subTotal += Math.Round(Helper.MakeDoubleValid(dr("FirstAmount")) / 1.2, 2, MidpointRounding.AwayFromZero);
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
                                addBreaks += (pageCount % 2 == 0) ? 0 : 1;

                                for (int i = 0; i <= addBreaks - 1; i++)
                                    doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            }

                            doc.MainDocumentPart.Document.Save();
                            string saveDir = TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr("ContractReference"));
                            Directory.CreateDirectory(saveDir);
                            string fileName = "Receipt_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;

                            using (fileStream)
                                mm.WriteTo(fileStream);

                            fileStream.Close();
                        }

                        MainDocumentPart mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr("ContractID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;

                        using (mm)
                            chunk.FeedData(mm);

                        WP.AltChunk altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate dd renewal letter : " + Constants.vbNewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateCredit(DataTable dt, string savePath)
            {
                try
                {
                    DataRow[] rr = null;
                    if (dt.Columns.Contains("Credit"))
                        rr = dt.Select("Credit > 0");
                    else
                        rr = dt.Select("Amount > 0");
                    DataTable dtInvoiceDetails = DB.Invoiced.InvoiceDetails_Get_InvoicedID(System.Convert.ToInt32(dt.Rows(0)("InvoicedID"))).Table;

                    if (dtInvoiceDetails.Rows.Count > 0)
                    {
                        if (rr.Length > 0)
                        {
                            string template = Application.StartupPath + @"\Templates\Invoice\SalesCredit.docx";
                            double subTotal = 0.0;
                            SalesCredits.SalesCredit oCredit = rr.Length == 1 ? DB.SalesCredit.SalesCredit_Get(rr[0]("SalesCreditID")) : DB.SalesCredit.SalesCredit_Get_For_InvoicedLine(rr[0]("InvoicedLineID"));
                            Sites.Site site = DB.Sites.Get(rr[0]("SiteID"));

                            byte[] fileByte = File.ReadAllBytes(template);
                            MemoryStream mm = new MemoryStream();
                            using (mm)
                            {
                                mm.Write(fileByte, 0, fileByte.Length);
                                WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);
                                using (doc)
                                {
                                    AddCompanyDetails(doc, true, false, site.RegionID == Enums.Region.GaswayCommercial);
                                    PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("SiteName")));
                                    PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("address1")));
                                    PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("address2")));
                                    PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("address3")));
                                    PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dtInvoiceDetails.Rows(0)("postcode")));
                                    PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(oCredit.CreditReference));
                                    PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(oCredit.DateCredited.ToString("dd/MM/yyyy")));
                                    PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0)("AccountNumber")));

                                    DataTable dtContract = new DataTable();
                                    dtContract.Columns.Add("ContractReference");
                                    dtContract.Columns.Add("Address");
                                    dtContract.Columns.Add("Work");
                                    dtContract.Columns.Add("Total");

                                    foreach (DataRow dr in rr)
                                    {
                                        DataRow drContract = dtContract.NewRow();
                                        InvoicedLiness.InvoicedLines Line = DB.InvoicedLines.InvoicedLines_Get(dr("InvoicedLineID"));

                                        drContract("ContractReference") = (Helper.MakeStringValid(dr("PoNumber")).Length == 0) ? Helper.MakeStringValid(dr("JobNumber")) : Helper.MakeStringValid(dr("JobNumber") + " / " + dr("PoNumber"));

                                        switch ((Enums.InvoiceType)dr("InvoiceTypeID"))
                                        {
                                            case object _ when Enums.InvoiceType.Visit:
                                                {
                                                    Sites.Site siteVisit = DB.Sites.Get(dr("SiteID"));
                                                    drContract("Address") = siteVisit.Address1 + ", " + siteVisit.Address2 + ", " + Helper.FormatPostcode(site.Postcode);
                                                    drContract("Work") = dr("NotesFromEngineer") + Constants.vbNewLine + Constants.vbNewLine + "Credit Against Invoice " + dr("InvoiceNumber").ToString + " - " + oCredit.ReasonForCredit;
                                                    drContract("Total") = Helper.MakeDoubleValid(dr("Credit")).ToString("C");
                                                    subTotal += Helper.MakeDoubleValid(dr("Credit"));
                                                    break;
                                                }

                                            case object _ when Enums.InvoiceType.Order:
                                                {
                                                    double orderTotal = 0.0;
                                                    DataTable ppOrdersData = DB.Order.Order_ItemsGetAll(dr("OrderID")).Table;
                                                    if (ppOrdersData.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow ppo in ppOrdersData.Rows)
                                                            orderTotal += Helper.MakeDoubleValid(ppo("QuantityReceived")) * Helper.MakeDoubleValid(ppo("SellPrice"));
                                                    }

                                                    Sites.Site siteOrder = DB.Sites.Get(dr("SiteID"));
                                                    drContract("Address") = siteOrder.Address1 + ", " + siteOrder.Address2 + ", " + Helper.FormatPostcode(siteOrder.Postcode);
                                                    drContract("Work") = "";
                                                    drContract("Total") = orderTotal.ToString("C");
                                                    subTotal += orderTotal;
                                                    break;
                                                }

                                            case object _ when Enums.InvoiceType.Contract_Option1:
                                                {
                                                    Sites.Site siteContract = DB.Sites.Get(dr("SiteID"));
                                                    drContract("Address") = siteContract.Address1 + ", " + siteContract.Address2 + ", " + Helper.FormatPostcode(siteContract.Postcode);
                                                    if (siteContract.RegionID == Enums.Region.GaswayCommercial)
                                                        drContract("Work") = "Periodic Service Charge " + Constants.vbNewLine + Constants.vbNewLine + "Credit Against Invoice " + dr("InvoiceNumber").ToString + " - " + oCredit.ReasonForCredit;
                                                    else
                                                        drContract("Work") = "Contract Payment " + Constants.vbNewLine + Constants.vbNewLine + "Credit Against Invoice " + dr("InvoiceNumber").ToString + " - " + oCredit.ReasonForCredit;
                                                    drContract("Total") = Helper.MakeDoubleValid(dr("Credit")).ToString("C");
                                                    subTotal += Helper.MakeDoubleValid(dr("Credit"));
                                                    break;
                                                }
                                        }
                                        dtContract.Rows.Add(drContract);
                                    }
                                    PrintHelper.AddRowsToTable(doc, "Job No", dtContract, "Arial", "20");

                                    decimal VATRate = Helper.MakeDoubleValid(dtInvoiceDetails.Rows(0)("VATRATE"));
                                    decimal VATRateDecimal = VATRate / (double)100;

                                    PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"));
                                    PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(subTotal * VATRateDecimal, 2).ToString("C"));
                                    PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round((subTotal * VATRateDecimal) + subTotal, 2).ToString("C"));
                                }

                                FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
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
                    ShowMessage("Could not generate invoice : " + Constants.vbNewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateSalesInvoice(Invoiceds.Invoiced invoice, WordprocessingDocument batch, bool isCommerical)
            {
                try
                {
                    DataTable dtInvoiceDetails = DB.Invoiced.InvoiceDetails_Get_InvoicedID(invoice.InvoicedID).Table;
                    if (dtInvoiceDetails.Rows.Count > 0)
                    {
                        string template = Application.StartupPath + @"\Templates\Invoice\Invoice.docx";
                        string savePath = TheSystem.Configuration.DocumentsLocation + @"SiteInvoices\" + invoice.InvoiceNumber + @"\Invoice_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";

                        string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(invoice.InvoicedID));

                        byte[] fileByte = File.ReadAllBytes(template);
                        MemoryStream mm = new MemoryStream();
                        using (mm)
                        {
                            mm.Write(fileByte, 0, fileByte.Length);
                            WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);
                            using (doc)
                            {
                                PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                                AddCompanyDetails(doc, true, false, isCommerical);
                                PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("SiteName")));
                                PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("address1")));
                                PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("address2")));
                                PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("address3")));
                                PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dtInvoiceDetails.Rows(0).Item("postcode")));
                                PrintHelper.ReplaceText(doc, "[InvoiceNumber]", invoice.InvoiceNumber);
                                PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(invoice.RaisedDate).ToString("dd/MM/yyyy"));
                                PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dtInvoiceDetails.Rows(0).Item("AccountNumber")));

                                DataTable dtInvoiceLines = DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(invoice.InvoicedID).Table;
                                if (dtInvoiceLines.Rows.Count > 0)
                                {
                                    double subTotal = 0.0;

                                    DataTable dtJobDetails = new DataTable();
                                    dtJobDetails.Columns.Add("Job");
                                    dtJobDetails.Columns.Add("Address");
                                    dtJobDetails.Columns.Add("Work");
                                    dtJobDetails.Columns.Add("Total");

                                    foreach (DataRow line in dtInvoiceLines.Rows)
                                    {
                                        DataRow drJob = dtJobDetails.NewRow();
                                        drJob("Job") = (Helper.MakeStringValid(line("PoNumber")).Length == 0) ? Helper.MakeStringValid(line("JobNumber")) : Helper.MakeStringValid(line("JobNumber") + " / " + line("PoNumber"));

                                        string additionalNotes = DB.Invoiced.Invoice_GetAdditionalNotes(invoice.InvoicedID);
                                        Sites.Site site = DB.Sites.Get(line("SiteID"));
                                        drJob("Address") = site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode(site.Postcode) + " Ref: " + site.PolicyNumber;

                                        if (string.IsNullOrEmpty(additionalNotes))
                                        {
                                            additionalNotes = Helper.MakeStringValid(line("Notes"));

                                            if (!string.IsNullOrEmpty(additionalNotes))
                                                DB.Invoiced.Invoice_UpdateAdditionalNotes(invoice.InvoicedID, additionalNotes);
                                        }

                                        switch ((Enums.InvoiceType)line("InvoiceTypeID"))
                                        {
                                            case object _ when Enums.InvoiceType.Visit:
                                                {
                                                    if (Helper.MakeBooleanValid(line("UseSORDescription")))
                                                    {
                                                        DataTable dt = DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(line("EngineerVisitID")).Table;
                                                        string sorDetails = "";
                                                        double sorTotal = 0.0;

                                                        foreach (DataRow dr in dt.Select("tick = 1"))
                                                        {
                                                            sorDetails += dr("NumUnitsUsed") + " X " + dr("code") + "-" + dr("Summary") + "(£" + dr("Price") + ")" + Constants.vbCrLf + Constants.vbCrLf;
                                                            sorTotal += Helper.MakeDoubleValid(dr("Total")).ToString("C");
                                                        }
                                                        drJob("Work") = sorDetails;
                                                        drJob("Total") = sorTotal.ToString("C");
                                                        subTotal += sorTotal;
                                                    }
                                                    else
                                                    {
                                                        drJob("Work") = line("NotesFromEngineer");
                                                        drJob("Total") = Helper.MakeDoubleValid(line("Amount")).ToString("C");
                                                        subTotal += Helper.MakeDoubleValid(line("Amount"));
                                                    }

                                                    break;
                                                }

                                            case object _ when Enums.InvoiceType.Order:
                                                {
                                                    double orderTotal = 0.0;
                                                    DataTable ppOrdersData = DB.Order.Order_ItemsGetAll(line("OrderID")).Table;
                                                    if (ppOrdersData.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow ppo in ppOrdersData.Rows)
                                                            orderTotal += Helper.MakeDoubleValid(ppo("QuantityReceived")) * Helper.MakeDoubleValid(ppo("SellPrice"));
                                                    }

                                                    drJob("Total") = orderTotal.ToString("C");
                                                    subTotal += orderTotal;
                                                    break;
                                                }

                                            case object _ when Enums.InvoiceType.Contract_Option1:
                                                {
                                                    ContractsOriginal.ContractOriginal cont = DB.ContractOriginal.Get(line("ContractID"));

                                                    string period = "";

                                                    switch (cont.InvoiceFrequencyID)
                                                    {
                                                        case object _ when Enums.InvoiceFrequency_NoWeeK.Monthly:
                                                            {
                                                                period = "Monthly";
                                                                break;
                                                            }

                                                        case object _ when Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits:
                                                            {
                                                                period = "4 Month";
                                                                break;
                                                            }

                                                        case object _ when Enums.InvoiceFrequency_NoWeeK.Quarterly:
                                                            {
                                                                period = "Quarterly";
                                                                break;
                                                            }

                                                        case object _ when Enums.InvoiceFrequency_NoWeeK.Bi_Annually:
                                                            {
                                                                period = "Bi-Annual";
                                                                break;
                                                            }

                                                        case object _ when Enums.InvoiceFrequency_NoWeeK.Annually:
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

                                                    if (site.RegionID == Enums.Region.GaswayCommercial)
                                                        drJob("Work") = period + " Service Charge for Gasway Commercial maintenance contract";
                                                    else
                                                    {
                                                        drJob("Work") = "Contract Payment";

                                                        if (details1 == "DDRECEIPT")
                                                            drJob("Work") = "Unpaid Direct Debit collection for the month of " + invoice.RaisedDate.ToString("MMMM") + "." + Constants.vbNewLine + Constants.vbNewLine + "Paid by " + details2 + ", received with thanks.";
                                                        else if (details1 == "DDINVOICE")
                                                            drJob("Work") = "Unpaid Direct Debit collection for the month of " + invoice.RaisedDate.ToString("MMMM") + "." + Constants.vbNewLine + Constants.vbNewLine + "Please arrange payment to cover this shortfall";
                                                    }

                                                    drJob("Total") = Helper.MakeDoubleValid(line("Amount")).ToString("C");
                                                    subTotal += Helper.MakeDoubleValid(line("Amount"));
                                                    break;
                                                }
                                        }

                                        if (!string.IsNullOrEmpty(additionalNotes))
                                            drJob("Work") += Constants.vbNewLine + Constants.vbNewLine + additionalNotes;

                                        dtJobDetails.Rows.Add(drJob);
                                    }

                                    DataRow drLastRow = dtJobDetails.Rows(dtInvoiceDetails.Rows.Count - 1);

                                    DataTable paymentdetails = DB.ExecuteWithReturn("SELECT PT.Name as PaymentTerm, ISNULL(PB.NAme,'') as PaymentBy from tblinvoiced I INNER JOIN tblpicklists PT ON PT.ManagerID = I.TermID LEFT JOIN tblpicklists PB ON PB.managerid = I.PaidByID WHERE InvoicedID = " + invoice.InvoicedID);
                                    if (paymentdetails.Rows.Count > 0)
                                    {
                                        if (paymentdetails.Rows(0)("PaymentTerm") == "RECEIPT")
                                        {
                                            PrintHelper.ReplaceText(doc, "INVOICE", "RECEIPT");
                                            PrintHelper.ReplaceText(doc, "STRICTLY 30 DAYS NET", "PAID WITH THANKS");
                                            drLastRow("Work") += Constants.vbNewLine + Constants.vbNewLine + "Paid by " + paymentdetails.Rows(0)("PaymentBy") + " With thanks.";
                                        }
                                        else
                                            PrintHelper.ReplaceText(doc, "STRICTLY 30 DAYS NET", paymentdetails.Rows(0)("PaymentTerm"));
                                    }

                                    PrintHelper.AddRowsToTable(doc, "Job No", dtJobDetails, "Arial", "20");

                                    decimal vatRate = Helper.MakeDoubleValid(dtInvoiceDetails.Rows(0).Item("VATRATE"));
                                    decimal vatRateDecimal = vatRate / (double)100;
                                    PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(subTotal, 2).ToString("C"));
                                    PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(subTotal * vatRateDecimal, 2).ToString("C"));
                                    PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round((subTotal * vatRateDecimal) + subTotal, 2).ToString("C"));

                                    doc.MainDocumentPart.Document.Save();

                                    Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                                    savePath = FileCheck(savePath);
                                    FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                    mm.Position = 0;
                                    using (fileStream)
                                        mm.WriteTo(fileStream);
                                }
                            }

                            if (batch != null)
                            {
                                MainDocumentPart mainPart = batch.MainDocumentPart;
                                string altChunkId = "AltId" + invoice.InvoicedID + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                                AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                                mm.Position = 0;

                                using (mm)
                                    chunk.FeedData(mm);

                                WP.AltChunk altChunk = new WP.AltChunk();
                                altChunk.Id = altChunkId;
                                mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                                mainPart.Document.Save();
                            }
                            else
                                Process.Start(savePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate invoice : " + Constants.vbNewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateContractInvoice(DataRow dr, WordprocessingDocument batch, bool isCommerical = false, bool addPage = true)
            {
                try
                {
                    string template = Application.StartupPath + @"\Templates\Invoice\Invoice.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")));
                    byte[] fileByte = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);

                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            AddCompanyDetails(doc, true, false, isCommerical);
                            PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(dr("PayerName")));
                            PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(dr("Payeraddress1")));
                            PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(dr("PayerAddress2")));
                            PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(dr("PayerAddress3")));
                            PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(dr("PayerPostcode")));
                            PrintHelper.ReplaceText(doc, "[InvoiceNumber]", Helper.MakeStringValid(dr("InvoiceNumber")));
                            PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid(dr("RaiseDate")).ToString("dd/MM/yyyy"));
                            PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(dr("CustAcc")));
                            DataTable dtContract = new DataTable();
                            dtContract.Columns.Add("ContractReference");
                            dtContract.Columns.Add("Address");
                            dtContract.Columns.Add("Work");
                            dtContract.Columns.Add("Total");
                            DataRow drContract = dtContract.NewRow();
                            drContract("ContractReference") = (Helper.MakeStringValid(dr("PoNumber")).Length == 0) ? Helper.MakeStringValid(dr("ContractReference")) : Helper.MakeStringValid(dr("ContractReference") + " / " + dr("PoNumber"));
                            drContract("Address") = Helper.MakeStringValid(dr("SiteAddress1") + ", " + dr("SiteAddress2") + ", " + dr("SitePostcode"));
                            string contractType = Helper.MakeStringValid(dr("ContractType"));
                            int contractTypeId = Helper.MakeIntegerValid(dr("ContractTypeID"));
                            int siteRegion = Helper.MakeIntegerValid(dr("SiteRegion"));
                            double contractTotal = Helper.MakeDoubleValid(dr("ContractPrice"));
                            double subTotal = 0.0;

                            if (siteRegion == System.Convert.ToInt32(Enums.Region.GaswayCommercial))
                                drContract("Work") = "Periodic Service Charge";
                            else if ((contractTypeId == System.Convert.ToInt32(Enums.ContractTypes.GoldStarAgency)) || (contractTypeId == System.Convert.ToInt32(Enums.ContractTypes.PlatinumStarAgency)))
                            {
                                drContract("Work") = contractType + " Coverplan Renewal. " + Constants.vbCrLf + Constants.vbCrLf + "Blanket cover for all gas appliances" + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for Renewing this plan.";
                                drContract("Total") = contractTotal.ToString("C");
                                subTotal += contractTotal;
                            }
                            else
                            {
                                drContract("Work") = contractType + " Coverplan Renewal. " + Constants.vbCrLf + Constants.vbCrLf + "Please find enclosed your certificate of cover." + Constants.vbCrLf + Constants.vbCrLf + "Thank you for Renewing this plan.";
                                drContract("Total") = contractTotal.ToString("C");
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
                                addBreaks += (pageCount % 2 == 0) ? 0 : 1;

                                for (int i = 0; i <= addBreaks - 1; i++)
                                    doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());
                            }

                            doc.MainDocumentPart.Document.Save();
                            string saveDir = TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr("ContractReference"));
                            Directory.CreateDirectory(saveDir);
                            string fileName = "Invoice_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;

                            using (fileStream)
                                mm.WriteTo(fileStream);

                            fileStream.Close();
                        }

                        MainDocumentPart mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr("ContractID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;

                        using (mm)
                            chunk.FeedData(mm);

                        WP.AltChunk altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate invoice : " + Constants.vbNewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private bool GenerateTransferLetter(DataRow dr, WordprocessingDocument batch)
            {
                try
                {
                    string template = Application.StartupPath + @"\Templates\Contracts\ContractTransfer.docx";
                    string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")));
                    byte[] fileByte = File.ReadAllBytes(template);
                    MemoryStream mm = new MemoryStream();

                    using (mm)
                    {
                        mm.Write(fileByte, 0, fileByte.Length);
                        WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);

                        using (doc)
                        {
                            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                            string companyName = (Helper.MakeStringValid(dr("PayerSalutation")).Length > 0) ? Helper.MakeStringValid(dr("PayerSalutation") + " " + dr("PayerSurname")) : Helper.MakeStringValid(dr("PayerName"));
                            PrintHelper.ReplaceText(doc, "[CompanyName]", companyName);
                            PrintHelper.ReplaceText(doc, "[Name]", companyName);
                            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("PayerAddress1")));
                            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("PayerAddress2")));
                            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("PayerAddress3")));
                            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("PayerPostcode")));
                            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(dr("ContractType")));
                            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(dr("ContractReference") + " - " + dr("siteAddress1") + ", " + dr("siteAddress2") + ", " + dr("sitePostcode")));
                            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(dr("siteAddress1") + ", " + dr("siteAddress2") + ", " + dr("sitePostcode")));
                            PrintHelper.ReplaceText(doc, "[UserName]", TheSystem.Configuration.CompanyName + " Coverplan Team");
                            int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                            int addBreaks = 1;
                            addBreaks += (pageCount % 2 == 0) ? 0 : 1;

                            for (int i = 0; i <= addBreaks - 1; i++)
                                doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());

                            doc.MainDocumentPart.Document.Save();
                            string saveDir = TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr("ContractReference"));
                            Directory.CreateDirectory(saveDir);
                            string fileName = "Transfer_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
                            string savePath = saveDir + @"\" + fileName;
                            savePath = FileCheck(savePath);
                            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            mm.Position = 0;

                            using (fileStream)
                                mm.WriteTo(fileStream);

                            fileStream.Close();
                        }

                        MainDocumentPart mainPart = batch.MainDocumentPart;
                        string altChunkId = "AltId" + Helper.MakeIntegerValid(dr("ContractID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                        AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                        mm.Position = 0;

                        using (mm)
                            chunk.FeedData(mm);

                        WP.AltChunk altChunk = new WP.AltChunk();
                        altChunk.Id = altChunkId;
                        mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                        mainPart.Document.Save();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not generate transfer letter : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            private string GenerateAnnualExpiryLetters(DataRow[] drAnnualContracts)
            {
                string fileName = "Annual_Contract_Expiry_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                string fileDir = TheSystem.Configuration.DocumentsLocation + @"Contracts\AnnualExpiry";
                Directory.CreateDirectory(fileDir);
                string filePath = fileDir + @"\" + fileName;
                File.Copy(Application.StartupPath + @"\Templates\ServiceLetter.docx", filePath);

                try
                {
                    WordprocessingDocument batch = WordprocessingDocument.Open(filePath, true);
                    using (batch)
                        foreach (DataRow dr in drAnnualContracts)
                        {
                            try
                            {
                                if (Helper.MakeDoubleValid(dr("RenewalPrice")) == 0)
                                    continue;
                                string template = Application.StartupPath + @"\Templates\Contracts\AnnualContractExpiry.docx";
                                string goldenRule = GetDocumentGoldenRule(template, Helper.MakeIntegerValid(dr("ContractID")));
                                byte[] fileByte = File.ReadAllBytes(template);
                                MemoryStream mm = new MemoryStream();

                                using (mm)
                                {
                                    mm.Write(fileByte, 0, fileByte.Length);
                                    WordprocessingDocument doc = WordprocessingDocument.Open(mm, true);

                                    using (doc)
                                    {
                                        PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
                                        PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(dr("PayerAddress1")));
                                        PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(dr("PayerAddress2")));
                                        PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(dr("PayerAddress3")));
                                        PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(dr("PayerPostcode")));
                                        PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                                        string companyName = (Helper.MakeStringValid(dr("PayerSalutation")).Length > 0) ? Helper.MakeStringValid(dr("PayerSalutation") + " " + dr("PayerSurname")) : Helper.MakeStringValid(dr("PayerName"));
                                        PrintHelper.ReplaceText(doc, "[CompanyName]", companyName);
                                        PrintHelper.ReplaceText(doc, "[ExpiryDate]", Helper.MakeDateTimeValid(dr("ContractEndDate")).ToString("dd/MM/yyyy"));
                                        PrintHelper.ReplaceText(doc, "[User]", TheSystem.Configuration.CompanyName + " Coverplan Team");
                                        PrintHelper.ReplaceText(doc, "[ContractType]", Helper.MakeStringValid(dr("ContractType")));
                                        PrintHelper.ReplaceText(doc, "[ContractReference]", Helper.MakeStringValid(dr("ContractReference")));
                                        PrintHelper.ReplaceText(doc, "[SiteAddress1]", Helper.MakeStringValid(dr("SiteAddress1")));
                                        string price = (Helper.MakeDoubleValid(dr("RenewalPrice")) == -1) ? 0.ToString("C") : Helper.MakeDoubleValid(dr("RenewalPrice")).ToString("C");
                                        PrintHelper.ReplaceText(doc, "[PriceSentence]", price);

                                        double addAppPrice = Helper.MakeDoubleValid(DB.Picklists.Get_Single_Description("Additional Appliance", 52));
                                        if (dr("ContractType") == "Platinum Star")
                                            addAppPrice = Helper.MakeDoubleValid(DB.Picklists.Get_Single_Description("Additional Appliance PLAT", 52));

                                        if (addAppPrice > 0)
                                        {
                                            string sentence = "Please be advised that we are now offering cover for boilermates " + "or any other make of thermal store product as an additional appliance. " + "Should you have a thermal store product in your property and require cover, " + "this could be added for an additional " + addAppPrice.ToString("C") + " per annum.";
                                            PrintHelper.ReplaceText(doc, "[ExcludeSentence]", sentence);
                                        }
                                        else
                                            PrintHelper.DeleteBookmark(doc, "ExcludeSentence");

                                        double ahe = Helper.MakeDoubleValid(DB.Picklists.Get_Single_Description("AHE", 52));
                                        PrintHelper.ReplaceText(doc, "[AHE]", ahe.ToString("C"));
                                        int pageCount = Helper.MakeIntegerValid(doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                                        int addBreaks = 1;
                                        addBreaks += (pageCount % 2 == 0) ? 0 : 1;

                                        for (int i = 0; i <= addBreaks - 1; i++)
                                            doc.MainDocumentPart.Document.Body.InsertAfter(new WP.Paragraph(new WP.Run(new WP.Break() { Type = WP.BreakValues.Page })), doc.MainDocumentPart.Document.Body.Elements<WP.Paragraph>().Last());

                                        doc.MainDocumentPart.Document.Save();
                                        string saveDir = TheSystem.Configuration.DocumentsLocation + @"SiteContracts\" + Helper.MakeStringValid(dr("ContractReference"));
                                        Directory.CreateDirectory(saveDir);
                                        string savePath = saveDir + @"\" + fileName;
                                        savePath = FileCheck(savePath);
                                        FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                        mm.Position = 0;

                                        using (fileStream)
                                            mm.WriteTo(fileStream);

                                        fileStream.Close();
                                    }

                                    MainDocumentPart mainPart = batch.MainDocumentPart;
                                    string altChunkId = "AltId" + Helper.MakeIntegerValid(dr("ContractID")) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                                    AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                                    mm.Position = 0;

                                    using (mm)
                                        chunk.FeedData(mm);

                                    WP.AltChunk altChunk = new WP.AltChunk();
                                    altChunk.Id = altChunkId;
                                    mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements<WP.Paragraph>().Last());
                                    mainPart.Document.Save();
                                }
                            }
                            catch (Exception ex)
                            {
                                ShowMessage("Could not renewal letter for " + Helper.MakeStringValid(dr("ContractReference")) + ": " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    return filePath;
                }
                catch (Exception ex)
                {
                    ShowMessage("Could not renewal letter: " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }

            private string Finalise(string filepath, bool success, bool withSave = true, bool withKill = true, bool gsr = false)
            {
                ;/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 640020
   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorResumeNextStatement(OnErrorResumeNextStatementSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorResumeNextStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input:
                On Error Resume Next

 */
                Documentss.Documents documentLine;

                if (success)
                {
                    if (!WordDoc == null)
                    {
                        if (withSave)
                        {
                            if (filepath.Trim().Length > 0)
                            {
                                if (OrderID > 0)
                                {
                                    if (answer == DialogResult.No)
                                    {
                                        WordDoc.SaveAs((object)filepath);
                                        Documentss.Documents linkedDoc = new Documentss.Documents();

                                        linkedDoc.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblOrder);
                                        linkedDoc.SetRecordID = OrderID;
                                        linkedDoc.SetDocumentTypeID = 162;

                                        string[] fileName = filepath.Split(@"\");
                                        linkedDoc.SetName = fileName[filepath.Split(@"\").Length - 1];

                                        linkedDoc.SetNotes = "";
                                        linkedDoc.SetLocation = filepath;

                                        Documentss.DocumentsValidator cV = new Documentss.DocumentsValidator();
                                        cV.Validate(linkedDoc);

                                        linkedDoc = DB.Documents.Insert(linkedDoc);

                                        System.IO.File.Delete(filepath);
                                    }
                                    else
                                    {
                                        // hhhh
                                        filepath = filepath.ToLower().Replace(".doc", ".pdf");

                                        if (System.IO.File.Exists(filepath))
                                            System.IO.File.Delete(filepath);

                                        WordDoc.SaveAs((object)filepath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                                        Process.Start(filepath);

                                        while (!System.IO.File.Exists(filepath))
                                            System.Threading.Thread.Sleep(1000);

                                        Documentss.Documents linkedDoc = new Documentss.Documents();

                                        linkedDoc.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblOrder);
                                        linkedDoc.SetRecordID = OrderID;
                                        linkedDoc.SetDocumentTypeID = 162;

                                        string[] fileName = filepath.Split(@"\");
                                        linkedDoc.SetName = fileName[filepath.Split(@"\").Length - 1];

                                        linkedDoc.SetNotes = "";
                                        linkedDoc.SetLocation = filepath;

                                        Documentss.DocumentsValidator cV = new Documentss.DocumentsValidator();
                                        cV.Validate(linkedDoc);

                                        linkedDoc = DB.Documents.Insert(linkedDoc);
                                    }
                                }
                                else if (PrintType == Enums.SystemDocumentType.SiteLetter)
                                {
                                    Documentss.Documents linkedDoc = new Documentss.Documents();

                                    linkedDoc.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblSite);
                                    linkedDoc.SetRecordID = SiteID;
                                    linkedDoc.SetDocumentTypeID = 205;

                                    string[] fileName = filepath.Split(@"\");
                                    linkedDoc.SetName = fileName[filepath.Split(@"\").Length - 1];
                                    if (System.IO.Directory.Exists(filepath.Replace(linkedDoc.Name, "")) == false)
                                        System.IO.Directory.CreateDirectory(filepath.Replace(linkedDoc.Name, ""));

                                    WordDoc.SaveAs((object)filepath);

                                    linkedDoc.SetNotes = "";
                                    linkedDoc.SetLocation = filepath;

                                    Documentss.DocumentsValidator cV = new Documentss.DocumentsValidator();
                                    cV.Validate(linkedDoc);

                                    linkedDoc = DB.Documents.Insert(linkedDoc);
                                }
                                else
                                {
                                    filepath = FileCheck(filepath);
                                    string fileExt = Path.GetExtension(filepath);
                                    if (fileExt == ".pdf")
                                        WordDoc.SaveAs((object)filepath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                                    else
                                        WordDoc.SaveAs((object)filepath);
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
                        File.Delete(filePath);
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
                if (!WordDoc == null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc.Content);
                    WordDoc.Close(SaveChanges: false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(WordDoc);
                    WordDoc = null/* TODO Change to default(_) if this is not a reference type */;
                }

                if (withKill)
                {
                    if (!MsWordApp == null)
                    {
                        foreach (Word.Document doc in _wordApp.Documents)
                        {
                            doc.Close(SaveChanges: false);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                            doc = null/* TODO Change to default(_) if this is not a reference type */;
                        }

                        MsWordApp.Quit(SaveChanges: false);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(MsWordApp);
                        MsWordApp = null/* TODO Change to default(_) if this is not a reference type */;
                    }

                    Process[] mp = Process.GetProcessesByName("WINWORD");
                    Process p;
                    foreach (var p in mp)
                    {
                        if (p.Responding)
                        {
                            if (p.MainWindowTitle == "")
                                p.Kill();
                        }
                        else
                            p.Kill();
                    };/* Cannot convert OnErrorGoToStatementSyntax, CONVERSION ERROR: Conversion for OnErrorGoToMinusOneStatement not implemented, please report this issue in 'On Error GoTo - 1' at character 647417
   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorGoToStatement(OnErrorGoToStatementSyntax node)
   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorGoToStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

Input:
                    On Error GoTo - 1

 */
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            public static System.Text.RegularExpressions.MatchCollection GetTemplateFields(string documentText)
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\[[A-z|0-9]*\]");
                return regex.Matches(documentText);
            }

            public static void ReplaceText(ref Word.Document msWordDoc, string OldText, string NewText)
            {
                {
                    var withBlock = msWordDoc.Content.Find;
                    withBlock.Text = OldText;
                    if (NewText.Length > 255)
                        withBlock.Replacement.Text = NewText.Substring(0, 255);
                    else
                        withBlock.Replacement.Text = NewText;
                    withBlock.Execute(Replace: Word.WdReplace.wdReplaceAll);
                }
            }

            public bool GSRSave(string filepath, EngineerVisits.EngineerVisit oEngineerVisit, Sites.Site oSite, string fileName)
            {
                try
                {
                    Customers.Customer oCustomer = DB.Customer.Customer_Get_Light(oSite.CustomerID);
                    if (oCustomer == null)
                        return false;
                    Documentss.Documents oDocument = DB.Documents.Documents_Get_ByFilePath(filepath);
                    if (oDocument == null)
                    {
                        oDocument = new Documentss.Documents();
                        oDocument.SetTableEnumID = System.Convert.ToInt32(Enums.TableNames.tblEngineerVisit);
                        oDocument.SetRecordID = oEngineerVisit.EngineerVisitID;
                        oDocument.SetDocumentTypeID = Consts.GSR;
                        oDocument.SetName = fileName;
                        oDocument.SetNotes = "Printed on " + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToString("HH:mm") + " by " + loggedInUser.Fullname;
                        oDocument.SetLocation = filepath;
                        DB.Documents.Insert(oDocument, false);
                    }
                    else
                    {
                        oDocument.SetNotes = "Last printed on " + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToString("HH:mm") + " by " + loggedInUser.Fullname;
                        DB.Documents.Update(oDocument);
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
                string filePath = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Enums.TableNames.tblEngineerVisit);
                if (!System.IO.Directory.Exists(filePath))
                    System.IO.Directory.CreateDirectory(filePath);
                filePath += @"\" + oEngineerVisit.EngineerVisitID;
                if (!System.IO.Directory.Exists(filePath))
                    System.IO.Directory.CreateDirectory(filePath);
                filePath += @"\" + filename + DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";

                // If Not r("CustomerID") = Enums.Customer.NCC Then GSRSave(filePath, oEngineerVisit)

                string pdfTemp = Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\" + filename + ".pdf"; // ---> It's the original pdf form you want to fill
                string newFile = filePath; // ---> It will generate new pdf that you have filled from your program

                // ------ READING -------

                PdfReader pdfReader = new PdfReader(pdfTemp);
                // ------ WRITING -------
                MemoryStream ms = new MemoryStream();
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create), "4"); // Creating the PDF in version 1.4

                // Method 1
                pdfStamper.FormFlattening = loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.PDFEditor) ? false : true;
                // If you don�t specify version and append flag (last 2 params) in below line then you may receive �Extended Features� error when you open generated PDF
                // Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)

                // pdfStamper.FormfFlattening = True
                // pdfStamper.AcroFields.GenerateAppearances = True

                AcroFields pdfFormFields = pdfStamper.AcroFields;

                // --------Get some Data-----------
                Sites.Site osite = DB.Sites.Get(ElectricalResuts.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId);
                Sites.Site ositeHQ = new Sites.Site();

                if (!osite.CustomerID == Enums.Customer.Domestic)
                    ositeHQ = DB.Sites.Get(osite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                // ------ SET YOUR FORM FIELDS ------

                PdfSetFormFieldText(ref pdfFormFields, "Client", ositeHQ.Name, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "ClientAddress", ositeHQ.Address1 + Strings.Chr(10) + ositeHQ.Address2 + Strings.Chr(10) + ositeHQ.Address3, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "ClientPostcode", Sys.Helper.FormatPostcode(ositeHQ.Postcode), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Installer", osite.Name, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "InstallerAddress", osite.Address1 + Strings.Chr(10) + osite.Address2 + Strings.Chr(10) + osite.Address3, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "InstallerPostcode", Sys.Helper.FormatPostcode(osite.Postcode), 7.7F);

                string @ref = "20656" + oEngineerVisit.EngineerVisitID;
                int length = @ref.Length;
                int character = 0;
                for (character = length; character >= 0; character += -1)
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

                switch (ElectricalResuts.Test1)
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

                switch (ElectricalResuts.Test2)
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

                switch (ElectricalResuts.Test3)
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

                PdfSetFormFieldText(ref pdfFormFields, "Phases", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test4).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Wires", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test5).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Voltage1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test6).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Frequency", "50", 8.0F);
                if (ElectricalResuts.Test7 == 421)
                    PDFSetTick(ref pdfFormFields, "Polarity1", @ref, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "FaultCurrent", ElectricalResuts.Test13, 8.0F);

                PdfSetFormFieldText(ref pdfFormFields, "Device", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test8).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Type1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test9).Name, 8.0F);

                PdfSetFormFieldText(ref pdfFormFields, "Impedance", ElectricalResuts.Test14, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "RatedCurrent", ElectricalResuts.Test15, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "SupplySource", ElectricalResuts.Test216, 8.0F);

                if (ElectricalResuts.Test10 == 70017)
                    PDFSetTick(ref pdfFormFields, "Facility", @ref, 12.0F);
                else
                    PDFSetTick(ref pdfFormFields, "EarthElectrode", @ref, 12.0F);

                PdfSetFormFieldText(ref pdfFormFields, "Location1", ElectricalResuts.Test217, 8.0F);

                PdfSetFormFieldText(ref pdfFormFields, "Type2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test111).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Ma", ElectricalResuts.Test223, 8.0F); // text13

                PdfSetFormFieldText(ref pdfFormFields, "Resistance", ElectricalResuts.Test218, 8.0F);

                PdfSetFormFieldText(ref pdfFormFields, "EarthConductor1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test112).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "EarthConductor2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test113).Name, 8.0F);
                PDFSetTick(ref pdfFormFields, "EarthingConductor3", @ref, 8.0F);

                PdfSetFormFieldText(ref pdfFormFields, "BondingConductor1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test114).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "BondingConductor2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test115).Name, 8.0F);
                PDFSetTick(ref pdfFormFields, "BondingConductor3", @ref, 8.0F);

                PdfSetFormFieldText(ref pdfFormFields, "SupplyConductor1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test116).Name, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "SupplyConductor2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test117).Name, 8.0F);
                PDFSetTick(ref pdfFormFields, "SupplyConductor3", @ref, 8.0F);

                if (ElectricalResuts.Test118 == Enums.TabletYesNoNA.Yes)
                    PDFSetTick(ref pdfFormFields, "WaterPipe", @ref, 8.0F);
                if (ElectricalResuts.Test119 == Enums.TabletYesNoNA.Yes)
                    PDFSetTick(ref pdfFormFields, "GasPipe", @ref, 8.0F);
                if (ElectricalResuts.Test120 == Enums.TabletYesNoNA.Yes)
                    PDFSetTick(ref pdfFormFields, "OilPipe", @ref, 8.0F);
                // If ElectricalResuts.Test118 = Enums.TabletYesNoNA.Yes Then ' not used
                // PdfSetFormFieldText(pdfFormFields, "Other2", ref, 8.0F)
                // End If
                if (ElectricalResuts.Test122 == Enums.TabletYesNoNA.Yes)
                    PDFSetTick(ref pdfFormFields, "Lighting", @ref, 8.0F);
                if (ElectricalResuts.Test121 == Enums.TabletYesNoNA.Yes)
                    PDFSetTick(ref pdfFormFields, "Steel", @ref, 8.0F);

                // PdfSetFormFieldText(pdfFormFields, "Specify2", ref, 8.0F) not used
                PdfSetFormFieldText(ref pdfFormFields, "Delay", ElectricalResuts.Test224, 8.0F);
                PdfSetFormFieldText(ref pdfFormFields, "Time", ElectricalResuts.Test225, 8.0F);

                DataTable EquipmentDT = DB.Engineer.Equipment_GetForEngineer(oEngineerVisit.EngineerID).Table;
                string List = "";
                foreach (DataRow EquipmentDR in EquipmentDT.Select("EquipmentTypeID = 70962")) // Electrical Test Instrument
                    List += EquipmentDR("SerialNumber") + Strings.Chr(10);

                PdfSetFormFieldText(ref pdfFormFields, "SerialNumber", List, 8.0F);

                PdfSetFormFieldText(ref pdfFormFields, "FuseDevice", ElectricalResuts.Test220, 8.0F);  // text10
                PdfSetFormFieldText(ref pdfFormFields, "BSEN", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test123).Name, 8.0F); // cbo23
                PdfSetFormFieldText(ref pdfFormFields, "Voltage2", ElectricalResuts.Test221, 8.0F);   // text11
                PdfSetFormFieldText(ref pdfFormFields, "Poles", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test124).Name, 8.0F); // cbo24
                PdfSetFormFieldText(ref pdfFormFields, "Location2", ElectricalResuts.Test222, 8.0F); // text12
                PdfSetFormFieldText(ref pdfFormFields, "Rating1", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test125).Name, 8.0F); // cbo25
                PdfSetFormFieldText(ref pdfFormFields, "CircuitNo", ElectricalResuts.Test226, 8.0F); // text16
                PdfSetFormFieldText(ref pdfFormFields, "Designation", ElectricalResuts.Test227, 8.0F); // text17
                PdfSetFormFieldText(ref pdfFormFields, "Wiring", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test126).Name, 8.0F); // cbo26
                PdfSetFormFieldText(ref pdfFormFields, "Method", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test127).Name, 8.0F); // cbo27
                PdfSetFormFieldText(ref pdfFormFields, "PointsServed", ElectricalResuts.Test228, 8.0F); // text18
                PdfSetFormFieldText(ref pdfFormFields, "Live", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test128).Name, 8.0F); // cbo28
                PdfSetFormFieldText(ref pdfFormFields, "CPC", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test129).Name, 8.0F); // cbo29
                PdfSetFormFieldText(ref pdfFormFields, "Disconnection", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name, 8.0F); // cbo30
                PdfSetFormFieldText(ref pdfFormFields, "BSENNo", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test131).Name, 8.0F); // cbo31
                PdfSetFormFieldText(ref pdfFormFields, "TypeNo", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test132).Name, 8.0F); // cbo32
                PdfSetFormFieldText(ref pdfFormFields, "Rating2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test133).Name, 8.0F); // cbo33
                PdfSetFormFieldText(ref pdfFormFields, "Capacity", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test134).Name, 8.0F); // cbo34
                PdfSetFormFieldText(ref pdfFormFields, "RCD", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test135).Name, 8.0F); // cbo35

                DataTable elecDt = DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_ElectricalZsMatrix_Get; // Get the matrix

                string BSNo = DB.Picklists.Get_One_As_Object(ElectricalResuts.Test131).Name;
                switch (BSNo)  // some are duplicated in matrix so covert to primary Number for this section of code
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

                    case "61008":
                        {
                            BSNo = "61009";
                            break;
                        }
                }

                string Type = DB.Picklists.Get_One_As_Object(ElectricalResuts.Test132).Name;

                switch (Type) // same with type
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

                string rated = DB.Picklists.Get_One_As_Object(ElectricalResuts.Test133).Name;
                if (rated == "2")
                    rated = "3"; // fix for error on tablet
                DataRow dr;
                try
                {
                    dr = elecDt.Select("Rated = " + rated)(0);
                }
                catch (Exception ex)
                {
                    dr = elecDt.Select("Rated = 3")(0);
                }

                string result = "N/A";
                if (DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name == "0.4" | DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name == "5")
                {
                    if (BSNo == "3871")
                        result = dr("BS" + BSNo + "_" + Type);
                    else
                        result = dr("BS" + BSNo + "_" + (DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name).ToString.Replace(".", ""));
                }

                PdfSetFormFieldText(ref pdfFormFields, "BS7671Value", result, 8.0F);

                PdfSetFormFieldText(ref pdfFormFields, "R1", ElectricalResuts.Test229, 8.0F); // text19
                PdfSetFormFieldText(ref pdfFormFields, "Rn", ElectricalResuts.Test230, 8.0F);  // text20
                PdfSetFormFieldText(ref pdfFormFields, "R2", ElectricalResuts.Test231, 8.0F);  // text21
                PdfSetFormFieldText(ref pdfFormFields, "Figure8", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test136).Name, 8.0F); // cbo36

                PdfSetFormFieldText(ref pdfFormFields, "R1R2", ElectricalResuts.Test232, 8.0F); // text22
                PdfSetFormFieldText(ref pdfFormFields, "R22", "N/A", 8.0F); // n/a
                PdfSetFormFieldText(ref pdfFormFields, "LiveLive", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test137).Name, 8.0F); // cbo37
                PdfSetFormFieldText(ref pdfFormFields, "LiveEarth", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test138).Name, 8.0F); // cbo38
                PdfSetFormFieldText(ref pdfFormFields, "Polarity2", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test139).Name, 8.0F); // cbo39
                PdfSetFormFieldText(ref pdfFormFields, "Zs", ElectricalResuts.Test233, 8.0F); // text23
                PdfSetFormFieldText(ref pdfFormFields, "RCDTest1", ElectricalResuts.Test234, 8.0F); // text24
                PdfSetFormFieldText(ref pdfFormFields, "RCDTest2", ElectricalResuts.Test235, 8.0F); // text25
                PdfSetFormFieldText(ref pdfFormFields, "TestButtonOp", DB.Picklists.Get_One_As_Object(ElectricalResuts.Test140).Name, 8.0F); // cbo40
                PdfSetFormFieldText(ref pdfFormFields, "CircuitDetails", "Electronic Equipment or Accessories", 8.0F); // always
                PdfSetFormFieldText(ref pdfFormFields, "RiskAssessment", "N/A", 5.0F); // HC small
                PdfSetFormFieldText(ref pdfFormFields, "JobTitle", "Electrician", 8.0F); // HC

                Engineers.Engineer Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
                PdfSetFormFieldText(ref pdfFormFields, "Engineer", Engineer.Name, 8.0F); // Get engineer

                DateTime visitDate = oEngineerVisit.StartDateTime;
                if (visitDate == default(DateTime))
                    visitDate = oEngineerVisit.ManualEntryOn;

                PdfSetFormFieldText(ref pdfFormFields, "Date2", visitDate.ToShortDateString(), 8.0F);

                AcroFields.FieldPosition fp = pdfFormFields.GetFieldPositions("Signature")(0);

                int page = fp.page;
                text.Rectangle rect = fp.position;

                Bitmap engSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.EngineerSignature));
                engSig.Save(Application.StartupPath + @"\TEMP\EngSig.bmp");

                text.Image image = text.Image.GetInstance(Application.StartupPath + @"\TEMP\EngSig.bmp");

                image.ScaleToFit(rect.Width, rect.Height);
                image.SetAbsolutePosition(rect.Left, rect.Bottom);

                PdfContentByte over = pdfStamper.GetOverContent(page);
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
                AcroFields pdfFormFields = acroFields;
                text.Font font = text.FontFactory.GetFont(Application.StartupPath + "/fonts/zapfdingbats.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 0.5F, text.Font.NORMAL, text.BaseColor.BLACK);
                BaseFont bf = font.BaseFont;
                pdfFormFields.SetFieldProperty(fieldName, "textfont", bf, null/* TODO Change to default(_) if this is not a reference type */);
                pdfFormFields.SetField(fieldName, "4"); // tick '4
                pdfFormFields.SetFieldProperty(fieldName, "textsize", 5.0F, null/* TODO Change to default(_) if this is not a reference type */);
            }

            private void PdfSetFormFieldText(ref AcroFields acroFields, string fieldName, string replacementText, float textSize)
            {
                // Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

                // Dim font As iTextSharp.text.Font = New iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL)  ' need to sus out regarding

                AcroFields pdfFormFields = acroFields;

                pdfFormFields.SetFieldProperty(fieldName, "bgcolor", iTextSharp.text.BaseColor.WHITE, null/* TODO Change to default(_) if this is not a reference type */);

                pdfFormFields.SetFieldProperty(fieldName, "textsize", textSize, null/* TODO Change to default(_) if this is not a reference type */);

                pdfFormFields.SetField(fieldName, replacementText);
            }

            private void WarningNoticePDF(Entity.EngineerVisits.EngineerVisit oEngineerVisit, DataRow WarningNotice, string filename)
            {
                string filePath = TheSystem.Configuration.DocumentsLocation + System.Convert.ToInt32(Entity.Sys.Enums.TableNames.tblEngineerVisit);
                if (!System.IO.Directory.Exists(filePath))
                    System.IO.Directory.CreateDirectory(filePath);
                filePath += @"\" + oEngineerVisit.EngineerVisitID;
                if (!System.IO.Directory.Exists(filePath))
                    System.IO.Directory.CreateDirectory(filePath);
                filePath += @"\" + filename + DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";

                // If Not r("CustomerID") = Entity.Sys.Enums.Customer.NCC Then GSRSave(filePath, oEngineerVisit)

                string pdfTemp = Application.StartupPath + TheSystem.Configuration.TemplateLocation + @"\" + filename + ".pdf"; // ---> It's the original pdf form you want to fill
                string newFile = filePath; // ---> It will generate new pdf that you have filled from your program

                // ------ READING -------

                PdfReader pdfReader = new PdfReader(pdfTemp);
                // ------ WRITING -------
                MemoryStream ms = new MemoryStream();
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create), "4"); // Creating the PDF in version 1.4

                // Method 1
                pdfStamper.FormFlattening = true;
                // If you don�t specify version and append flag (last 2 params) in below line then you may receive �Extended Features� error when you open generated PDF
                // Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)

                // pdfStamper.FormfFlattening = True
                // pdfStamper.AcroFields.GenerateAppearances = True

                AcroFields pdfFormFields = pdfStamper.AcroFields;

                // --------Get some Data-----------

                Sites.Site osite = DB.Sites.Get(oEngineerVisit.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId);
                Sites.Site ositeHQ = DB.Sites.Get(osite.CustomerID, Sites.SiteSQL.GetBy.CustomerHq);

                if (osite.CustomerID == Enums.Customer.Domestic)
                    ositeHQ = new Sites.Site();

                DataTable Timesheets = DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(oEngineerVisit.EngineerVisitID).Table;
                Entity.Engineers.Engineer Engineer = DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);

                DateTime LastWorking = DateTime.MinValue;
                foreach (DataRow dr in Timesheets.Rows)
                {
                    if ((DateTime)dr("EnddateTime") > LastWorking && dr("TimesheetTypeID") == "211")
                        LastWorking = (DateTime)dr("Enddatetime");
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
                PdfSetFormFieldText(ref pdfFormFields, "Make", WarningNotice("Make"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Model", WarningNotice("Model"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Type", WarningNotice("Model"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Location", WarningNotice("Location"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Reason", WarningNotice("Reason"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Action", WarningNotice("ActionTaken"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Present", WarningNotice("NoticeLeft"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Refused", WarningNotice("NoSign"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "NG1", WarningNotice("SupplierInformed"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "NG2", WarningNotice("SupplierInformed"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "TenName", oEngineerVisit.CustomerName, 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "TenDate", LastWorking.ToString("dd/MM/yyyy"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "GasEscape", WarningNotice("GasEscape"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Reason2", WarningNotice("SupplierInformedReason"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Reference", WarningNotice("SupplierInformedRef"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Riddor", WarningNotice("RiddorReported"), 7.7F);
                PdfSetFormFieldText(ref pdfFormFields, "Reason3", WarningNotice("RiddorReportedDetails"), 7.7F);
                // ------------------ DO TICKS ----------------------------------------------
                if (WarningNotice("CategoryID") == 405)
                    PDFSetTick(ref pdfFormFields, "ID", "", 8.0F);
                else if (WarningNotice("CategoryID") == 404)
                {
                    if (WarningNotice("TurnedOff") == "1")
                        PDFSetTick(ref pdfFormFields, "AR1", "", 8.0F);
                    else
                        PDFSetTick(ref pdfFormFields, "AR2", "", 8.0F);
                }

                // --------------------------------------------------------------------------
                Bitmap engSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.EngineerSignature));
                engSig.Save(Application.StartupPath + @"\TEMP\EngSig.bmp");

                PushbuttonField ad = pdfFormFields.GetNewPushbuttonFromField("EngSig");
                // ad.setLayout(PushbuttonField.LAYOUT_ICON_ONLY)
                // ad.setProportionalIcon(True);
                ad.Image = text.Image.GetInstance((Application.StartupPath + @"\TEMP\EngSig.bmp"));
                pdfFormFields.ReplacePushbuttonField("EngSig", ad.Field);

                Bitmap CustSig = new Bitmap(new System.IO.MemoryStream(oEngineerVisit.CustomerSignature));
                CustSig.Save(Application.StartupPath + @"\TEMP\CustSig.bmp");

                PushbuttonField ad1 = pdfFormFields.GetNewPushbuttonFromField("Signature");
                // ad.setLayout(PushbuttonField.LAYOUT_ICON_ONLY)
                // ad.setProportionalIcon(True);
                ad1.Image = text.Image.GetInstance((Application.StartupPath + @"\TEMP\CustSig.bmp"));
                pdfFormFields.ReplacePushbuttonField("Signature", ad1.Field);

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