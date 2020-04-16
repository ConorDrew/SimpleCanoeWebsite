// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.Printing
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FSM.Entity.ContactAttempts;
using FSM.Entity.Contacts;
using FSM.Entity.ContractOriginalSites;
using FSM.Entity.ContractsOriginal;
using FSM.Entity.Customers;
using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.Documentss;
using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisitAdditionals;
using FSM.Entity.EngineerVisitCharges;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Invoiceds;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.Jobs;
using FSM.Entity.LetterManager;
using FSM.Entity.PickLists;
using FSM.Entity.SalesCredits;
using FSM.Entity.Sites;
using FSM.Entity.Suppliers;
using FSM.Entity.Users;
using FSM.Entity.Warehouses;
using FSM.LSR;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
  public class Printing
  {
    private string details1;
    private string details2;
    private int tableCnt;
    private DialogResult answer;
    private bool InsertDocument;
    private Microsoft.Office.Interop.Word.Application _wordApp;
    private Microsoft.Office.Interop.Word.Document _wordDoc;
    private object _detailsToPrint;
    private string _documentName;
    private Enums.SystemDocumentType _printType;
    private int _orderID;
    private int _siteID;
    private DataTable _ContractsDT;
    private List<LSRError> _lsrErrors;
    private bool missedfirst;
    private string ddsort;
    private string ddAcc;
    private string wpFilePath;
    private string p;

    public Microsoft.Office.Interop.Word.Application MsWordApp
    {
      get
      {
        Microsoft.Office.Interop.Word.Application wordApp = this._wordApp;
        return wordApp;
      }
      set
      {
        this._wordApp = value;
      }
    }

    private Microsoft.Office.Interop.Word.Document WordDoc
    {
      get
      {
        Microsoft.Office.Interop.Word.Document wordDoc = this._wordDoc;
        return wordDoc;
      }
      set
      {
        this._wordDoc = value;
      }
    }

    private object DetailsToPrint
    {
      get
      {
        return this._detailsToPrint;
      }
      set
      {
        this._detailsToPrint = RuntimeHelpers.GetObjectValue(value);
      }
    }

    private string DocumentName
    {
      get
      {
        return this._documentName;
      }
      set
      {
        this._documentName = value.Replace("/", "").Replace("\\", "");
      }
    }

    private Enums.SystemDocumentType PrintType
    {
      get
      {
        return this._printType;
      }
      set
      {
        this._printType = value;
      }
    }

    public int OrderID
    {
      get
      {
        return this._orderID;
      }
      set
      {
        this._orderID = value;
      }
    }

    public int SiteID
    {
      get
      {
        return this._siteID;
      }
      set
      {
        this._siteID = value;
      }
    }

    public DataTable ContractsDT
    {
      get
      {
        return this._ContractsDT;
      }
      set
      {
        this._ContractsDT = value;
      }
    }

    private List<LSRError> LSRErrors
    {
      get
      {
        return this._lsrErrors;
      }
      set
      {
        this._lsrErrors = value;
      }
    }

    public Printing(
      object detailsToPrintIn,
      string documentNameIn,
      Enums.SystemDocumentType printTypeIn,
      bool multipleDocs = false,
      int OrderID = 0,
      bool isEmail = false,
      int ApptsPerDay = 13,
      int CustomerID = 0,
      [DateTimeConstant(0), Optional] DateTime LetterCreationDate,
      DataTable dt = null)
    {
      this.details1 = "";
      this.details2 = "";
      this.tableCnt = 1;
      this.answer = DialogResult.No;
      this.InsertDocument = true;
      this._wordApp = (Microsoft.Office.Interop.Word.Application) null;
      this._wordDoc = (Microsoft.Office.Interop.Word.Document) null;
      this._detailsToPrint = (object) null;
      this._documentName = string.Empty;
      this._lsrErrors = new List<LSRError>();
      this.missedfirst = false;
      this.ddsort = "";
      this.ddAcc = "";
      this.wpFilePath = "";
      this.p = "Gasway100";
      this.ContractsDT = dt;
      this.DetailsToPrint = RuntimeHelpers.GetObjectValue(detailsToPrintIn);
      this.DocumentName = documentNameIn;
      this.PrintType = printTypeIn;
      this.OrderID = OrderID;
      if (isEmail)
        return;
      if (multipleDocs)
        this.PrintMultiDocs(ApptsPerDay, CustomerID, LetterCreationDate);
      else
        this.Print();
    }

    public ArrayList MultiEmail()
    {
      bool flag = false;
      string str = "";
      ArrayList arrayList = new ArrayList();
      Cursor.Current = Cursors.WaitCursor;
      switch (this.PrintType)
      {
        case Enums.SystemDocumentType.ContractExpiry:
          try
          {
            str = this.GenerateAnnualExpiryLetters(this.ContractsDT.Select("InvoiceFrequencyID = 6 OR ContractTypeID = 69420"));
            flag = true;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            flag = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
          }
          finally
          {
            if (flag)
              arrayList.Add((object) str);
            Cursor.Current = Cursors.Default;
          }
          return arrayList;
        case Enums.SystemDocumentType.ContractBatch:
          try
          {
            this.GenerateDDMS(this.ContractsDT.Select());
            str = this.GenerateRenewalLetters(this.ContractsDT.Select());
            flag = true;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            flag = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
          }
          finally
          {
            if (flag)
              arrayList.Add((object) str);
            Cursor.Current = Cursors.Default;
          }
          return arrayList;
        default:
          return arrayList;
      }
    }

    public string EmailWP()
    {
      bool flag = false;
      this.wpFilePath = "";
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        if (this.PrintType == Enums.SystemDocumentType.JobImportLetters)
        {
          DataTable dataTable = (DataTable) ((ArrayList) this.DetailsToPrint)[0];
          EngineerVisit engineervisit = (EngineerVisit) null;
          if (((ArrayList) this.DetailsToPrint).Count > 1)
            engineervisit = (EngineerVisit) ((ArrayList) this.DetailsToPrint)[1];
          DataRow row = dataTable.Rows[0];
          Job job1 = new Job();
          Job job2 = App.DB.Job.Job_Get(Conversions.ToInteger(row["JobID"]));
          bool boolean = Conversions.ToBoolean(Interaction.IIf(App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(Conversions.ToInteger(row["JobID"])).Count > 1, (object) false, (object) true));
          if (!this.GenerateJobLetter(dataTable.Rows[0], job2, boolean, (WordprocessingDocument) null, engineervisit))
            throw new Exception();
          if (!(!boolean ? App.DB.JobImports.JobImport_Update_Letter2(row, job2) : App.DB.JobImports.JobImport_Update_Letter1(row, job2)))
            throw new Exception();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        flag = false;
        int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
      return this.wpFilePath;
    }

    private void PrintMultiDocs(int MinsPerDayIn = 550, int CustomerID = 0, [DateTimeConstant(0), Optional] DateTime LetterCreationDate)
    {
      bool success = false;
      string str1 = "";
      switch (this.PrintType)
      {
        case Enums.SystemDocumentType.SupplierPurchaseOrder:
          ArrayList detailsToPrint1 = (ArrayList) this.DetailsToPrint;
          Site oSite = (Site) null;
          Warehouse oWarehouse = (Warehouse) null;
          User oUser = (User) detailsToPrint1[4];
          DataView dvCharges = (DataView) detailsToPrint1[7];
          bool toPdf = Conversions.ToInteger(detailsToPrint1[8]) == 6;
          DataSet dataSet = (DataSet) detailsToPrint1[0];
          if (detailsToPrint1[3] != null)
            oWarehouse = (Warehouse) detailsToPrint1[3];
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(detailsToPrint1[1], (object) "Site", false))
          {
            oSite = (Site) detailsToPrint1[2];
            oWarehouse = (Warehouse) null;
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(detailsToPrint1[1], (object) "Warehouse", false))
          {
            oSite = (Site) null;
            oWarehouse = (Warehouse) detailsToPrint1[2];
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(detailsToPrint1[1], (object) "Van", false))
          {
            oSite = (Site) null;
            oWarehouse = detailsToPrint1[2] != null ? (Warehouse) detailsToPrint1[2] : (Warehouse) null;
          }
          IEnumerator enumerator1;
          try
          {
            enumerator1 = dataSet.Tables.GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataTable current = (DataTable) enumerator1.Current;
              try
              {
                Supplier oSupplier = App.DB.Supplier.Supplier_Get(Conversions.ToInteger(current.Rows[0]["SupplierID"]));
                str1 = App.TheSystem.Configuration.DocumentsLocation + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + Helper.MakeFileNameValid(oSupplier.Name) + ".docx";
                Cursor.Current = Cursors.WaitCursor;
                success = this.GeneratePurchaseOrder(oSite, oWarehouse, current, oSupplier, oUser, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(detailsToPrint1[5])), Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(detailsToPrint1[6])), dvCharges, str1, toPdf);
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                success = false;
                int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
              }
              finally
              {
                if (success)
                {
                  if (toPdf)
                    str1 = Path.ChangeExtension(str1, ".pdf");
                  Cursor.Current = Cursors.WaitCursor;
                  Process.Start(str1);
                  Cursor.Current = Cursors.Default;
                }
                Cursor.Current = Cursors.Default;
              }
            }
            break;
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
        case Enums.SystemDocumentType.Invoice:
          ArrayList arrayList1 = new ArrayList();
          ArrayList detailsToPrint2 = (ArrayList) this.DetailsToPrint;
          ArrayList arrayList2 = new ArrayList();
          ArrayList arrayList3 = (ArrayList) detailsToPrint2[0];
          if (detailsToPrint2.Count > 1)
          {
            this.details1 = Conversions.ToString(detailsToPrint2[1]);
            this.details2 = Conversions.ToString(detailsToPrint2[2]);
          }
          ArrayList arrayList4 = new ArrayList();
          IEnumerator enumerator2;
          try
          {
            enumerator2 = arrayList3.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              ArrayList current = (ArrayList) enumerator2.Current;
              try
              {
                Invoiced invoice = App.DB.Invoiced.Invoiced_Get(Conversions.ToInteger(current[0]));
                if (invoice.PaidByID > 0)
                  this.details2 = App.DB.Picklists.Get_One_As_Object(invoice.PaidByID)?.Name;
                if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(invoice.AdhocInvoiceType, "", false) > 0U)
                  this.details1 = invoice.AdhocInvoiceType;
                str1 = App.TheSystem.Configuration.DocumentsLocation + this.DocumentName + "_" + invoice.InvoiceNumber + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
                Directory.CreateDirectory(Path.GetDirectoryName(str1));
                File.Copy(System.Windows.Forms.Application.StartupPath + "\\Templates\\Blank.docx", str1);
                Cursor.Current = Cursors.WaitCursor;
                WordprocessingDocument batch = WordprocessingDocument.Open(str1, true);
                using (batch)
                {
                  DataTable table1 = App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(Conversions.ToInteger(current[0])).Table;
                  DataTable table2 = App.DB.ContractOriginal.Get_NotProcessed(Conversions.ToInteger(table1.Rows[0]["ContractID"])).Table;
                  table2.Columns.Add("InvoiceNumber");
                  if (table2.Rows.Count > 0 && table2.Rows[0]["InitialPaymentType"].ToString().Length > 1)
                  {
                    table2.Rows[0]["InvoiceNumber"] = (object) invoice.InvoiceNumber;
                    if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(table2.Rows[0]["InvoiceNumber"])))
                      success = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(table2.Rows[0]["InitialPaymentType"])) && !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(table2.Rows[0]["InitialPaymentType"], (object) "Invoice", false) && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.details1, "DDRECEIPT", false) != 0 ? this.GenerateContractInvoice(table2.Rows[0], batch, Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(table2.Rows[0]["RegionID"], (object) Enums.Region.GaswayCommercial, false), false) : this.GenerateReceipt(table2.Rows[0], batch, Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(table2.Rows[0]["RegionID"], (object) Enums.Region.GaswayCommercial, false), false);
                  }
                  else
                    success = this.GenerateSalesInvoice(invoice, batch, Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current[1], (object) Enums.Region.GaswayCommercial, false));
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                success = false;
                int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
              }
              finally
              {
                if (App.IsRFT)
                  str1 = str1.ToLower().Replace(".doc", ".pdf");
                this.Finalise(str1, success, true, false, false);
                arrayList4.Add((object) str1);
                Cursor.Current = Cursors.Default;
              }
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          this.Finalise("", false, false, true, false);
          IEnumerator enumerator3;
          try
          {
            enumerator3 = arrayList4.GetEnumerator();
            while (enumerator3.MoveNext())
              Process.Start(Conversions.ToString(enumerator3.Current));
            break;
          }
          finally
          {
            if (enumerator3 is IDisposable)
              (enumerator3 as IDisposable).Dispose();
          }
        case Enums.SystemDocumentType.ContractOption1:
          try
          {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            int num = (int) folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.Trim().Length == 0)
              break;
            Cursor.Current = Cursors.WaitCursor;
            str1 = folderBrowserDialog.SelectedPath + "\\" + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
            File.Copy(System.Windows.Forms.Application.StartupPath + "\\Templates\\Blank.docx", str1);
            WordprocessingDocument batch = WordprocessingDocument.Open(str1, true);
            using (batch)
            {
              try
              {
                foreach (int contractId in (List<int>) this.DetailsToPrint)
                {
                  DataTable dataTable = App.DB.ContractOriginal.ProcessContract(contractId);
                  if (dataTable != null)
                    success = this.GenerateContractLetter(dataTable.Rows[0], batch);
                }
                break;
              }
              finally
              {
                List<int>.Enumerator enumerator4;
                enumerator4.Dispose();
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            if (success)
              Process.Start(str1);
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.ContractExpiry:
          try
          {
            FRMContractManager frmContractManager = (FRMContractManager) ((ArrayList) this.DetailsToPrint)[1];
            this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
            this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            this.MsWordApp.Visible = false;
            frmContractManager.MoveProgressOn(false);
            DataTable dataTable = (DataTable) ((ArrayList) this.DetailsToPrint)[0];
            if (!Directory.Exists(App.TheSystem.Configuration.DocumentsLocation + "ContractExpiryLetters"))
              Directory.CreateDirectory(App.TheSystem.Configuration.DocumentsLocation + "ContractExpiryLetters");
            frmContractManager.MoveProgressOn(false);
            str1 = App.TheSystem.Configuration.DocumentsLocation + "ContractExpiryLetters\\" + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "dd-MM-yyyy HHmm") + ".doc";
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents = this.MsWordApp.Documents;
            object obj1 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ContractExpiry.dot");
            ref object local1 = ref obj1;
            object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local2 = ref objectValue1;
            object obj2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local3 = ref obj2;
            object obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local4 = ref obj3;
            // ISSUE: reference to a compiler-generated method
            this.WordDoc = documents.Add(ref local1, ref local2, ref local3, ref local4);
            // ISSUE: reference to a compiler-generated method
            this.MsWordApp.Selection.WholeStory();
            // ISSUE: reference to a compiler-generated method
            this.MsWordApp.Selection.Copy();
            int num = 1;
            int tblIndex = 2;
            IEnumerator enumerator4;
            try
            {
              enumerator4 = dataTable.Rows.GetEnumerator();
              while (enumerator4.MoveNext())
              {
                success = this.GenerateContractExpiry((DataRow) enumerator4.Current, tblIndex);
                checked { ++num; }
                checked { tblIndex += 2; }
                if (num <= dataTable.Rows.Count)
                {
                  // ISSUE: variable of a compiler-generated type
                  Selection selection1 = this.MsWordApp.Selection;
                  obj3 = (object) WdUnits.wdStory;
                  ref object local5 = ref obj3;
                  obj2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local6 = ref obj2;
                  // ISSUE: reference to a compiler-generated method
                  selection1.EndKey(ref local5, ref local6);
                  // ISSUE: variable of a compiler-generated type
                  Selection selection2 = this.MsWordApp.Selection;
                  obj2 = (object) WdBreakType.wdPageBreak;
                  ref object local7 = ref obj2;
                  // ISSUE: reference to a compiler-generated method
                  selection2.InsertBreak(ref local7);
                  // ISSUE: reference to a compiler-generated method
                  this.MsWordApp.Selection.Paste();
                }
                frmContractManager.MoveProgressOn(false);
              }
            }
            finally
            {
              if (enumerator4 is IDisposable)
                (enumerator4 as IDisposable).Dispose();
            }
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
            object obj4 = (object) str1;
            ref object local8 = ref obj4;
            object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local9 = ref objectValue2;
            object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local10 = ref objectValue3;
            object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local11 = ref objectValue4;
            object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local12 = ref objectValue5;
            object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local13 = ref objectValue6;
            object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local14 = ref objectValue7;
            object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local15 = ref objectValue8;
            object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local16 = ref objectValue9;
            object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local17 = ref objectValue10;
            object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local18 = ref objectValue11;
            object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local19 = ref objectValue12;
            object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local20 = ref objectValue13;
            object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local21 = ref objectValue14;
            object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local22 = ref objectValue15;
            object objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local23 = ref objectValue16;
            // ISSUE: reference to a compiler-generated method
            wordDoc.SaveAs(ref local8, ref local9, ref local10, ref local11, ref local12, ref local13, ref local14, ref local15, ref local16, ref local17, ref local18, ref local19, ref local20, ref local21, ref local22, ref local23);
            Marshal.ReleaseComObject((object) this.WordDoc);
            this.WordDoc = (Microsoft.Office.Interop.Word.Document) null;
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            this.Finalise(str1, success, true, true, false);
            if (success)
            {
              Cursor.Current = Cursors.WaitCursor;
              Process.Start(str1);
              Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.GSRDue:
          try
          {
            DataTable dtPrinted = new DataTable();
            dtPrinted.Columns.Add("AssetID");
            dtPrinted.Columns.Add("DateDue");
            FRMLastGSRReport frmLastGsrReport = (FRMLastGSRReport) ((ArrayList) this.DetailsToPrint)[1];
            frmLastGsrReport.MoveProgressOn(false);
            DataView dataView = (DataView) ((ArrayList) this.DetailsToPrint)[0];
            str1 = App.TheSystem.Configuration.DocumentsLocation + "GSRDueLettersCreated" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmmff") + ".docx";
            File.Copy(System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\BlankNp.docx", str1);
            WordprocessingDocument batch = WordprocessingDocument.Open(str1, true);
            using (batch)
            {
              DataTable dataTable1 = new DataTable();
              dataTable1.Columns.Add("SiteID", System.Type.GetType("System.Int32"));
              dataTable1.Columns.Add("DueDate", System.Type.GetType("System.DateTime"));
              DataTable dataTable2 = new DataTable();
              dataTable2.Columns.Add(nameof (CustomerID));
              IEnumerator enumerator4;
              try
              {
                enumerator4 = dataView.GetEnumerator();
                while (enumerator4.MoveNext())
                {
                  DataRowView current = (DataRowView) enumerator4.Current;
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current[nameof (CustomerID)], (object) Enums.Customer.Domestic, false))
                  {
                    if (dataTable1.Select("DueDate='" + Conversions.ToString(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["DueDate"]))) + "' AND SiteID =" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["siteID"])))).Length == 0)
                    {
                      DataRow[] dr = dataView.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "SiteID =", current["siteID"]), (object) " AND DueDate='"), current["DueDate"]), (object) "'")));
                      string path = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) (App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(24) + "\\"), current["SiteID"]), (object) "\\ServiceReminders"));
                      Directory.CreateDirectory(path);
                      string savePath = path + "\\ServiceReminder_" + Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["DueDate"])).ToLongDateString() + ".docx";
                      success = this.GenerateDomesticGSRDue(dr, dtPrinted, savePath, batch);
                      if (success && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Email"])) & Helper.IsEmailValid(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["EmailAddress"]))))
                      {
                        Emails emails1 = new Emails();
                        emails1.To = Conversions.ToString(current["EmailAddress"]);
                        emails1.BCC = EmailAddress.Coverplan;
                        emails1.From = EmailAddress.Enquiries;
                        emails1.Subject = "Appliance Service Reminder";
                        emails1.Body = "Dear Tenant, <br/><br/>\r\n\r\n";
                        Emails emails2;
                        string str2 = (emails2 = emails1).Body + "Please find your service reminder attached.<br/><br/>\r\n\r\n";
                        emails2.Body = str2;
                        Emails emails3;
                        string str3 = (emails3 = emails1).Body + "Kind regards,<br/><br/>";
                        emails3.Body = str3;
                        Emails emails4;
                        string str4 = (emails4 = emails1).Body + App.TheSystem.Configuration.CompanyName;
                        emails4.Body = str4;
                        emails1.Attachments.Add((object) savePath);
                        emails1.SendMe = true;
                        emails1.Send();
                      }
                      DataRow row = dataTable1.NewRow();
                      row["SiteID"] = RuntimeHelpers.GetObjectValue(current["siteID"]);
                      row["DueDate"] = (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["DueDate"]));
                      dataTable1.Rows.Add(row);
                      dataTable1.AcceptChanges();
                    }
                    frmLastGsrReport.MoveProgressOn(false);
                  }
                }
              }
              finally
              {
                if (enumerator4 is IDisposable)
                  (enumerator4 as IDisposable).Dispose();
              }
              IEnumerator enumerator5;
              try
              {
                enumerator5 = dataView.GetEnumerator();
                while (enumerator5.MoveNext())
                {
                  DataRowView current = (DataRowView) enumerator5.Current;
                  if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current[nameof (CustomerID)], (object) Enums.Customer.Domestic, false))))
                  {
                    if (dataTable2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "CustomerID=", current[nameof (CustomerID)]))).Length == 0)
                    {
                      DataRow[] dr = dataView.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "CustomerID=", current[nameof (CustomerID)])));
                      string path = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) (App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(24) + "\\"), current["SiteID"]), (object) "\\ServiceReminders"));
                      Directory.CreateDirectory(path);
                      string savePath = path + "\\ServiceReminder.docx";
                      success = this.GenerateLLGSRDue(dr, dtPrinted, savePath, batch);
                      if (success && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Email"])) & Helper.IsEmailValid(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["EmailAddress"]))))
                      {
                        Emails emails1 = new Emails();
                        emails1.To = Conversions.ToString(current["EmailAddress"]);
                        emails1.BCC = EmailAddress.Coverplan;
                        emails1.From = EmailAddress.Enquiries;
                        emails1.Subject = "Appliance Service Reminder";
                        emails1.Body = "Dear Tenant, <br/><br/>\r\n\r\n";
                        Emails emails2;
                        string str2 = (emails2 = emails1).Body + "Please find your service reminder attached.<br/><br/>\r\n\r\n";
                        emails2.Body = str2;
                        Emails emails3;
                        string str3 = (emails3 = emails1).Body + "Kind regards,<br/><br/>";
                        emails3.Body = str3;
                        Emails emails4;
                        string str4 = (emails4 = emails1).Body + App.TheSystem.Configuration.CompanyName;
                        emails4.Body = str4;
                        emails1.Attachments.Add((object) savePath);
                        emails1.SendMe = true;
                        emails1.Send();
                      }
                      DataRow row = dataTable2.NewRow();
                      row[nameof (CustomerID)] = RuntimeHelpers.GetObjectValue(current[nameof (CustomerID)]);
                      dataTable2.Rows.Add(row);
                    }
                    frmLastGsrReport.MoveProgressOn(false);
                  }
                }
              }
              finally
              {
                if (enumerator5 is IDisposable)
                  (enumerator5 as IDisposable).Dispose();
              }
              IEnumerator enumerator6;
              try
              {
                enumerator6 = dtPrinted.Rows.GetEnumerator();
                while (enumerator6.MoveNext())
                {
                  DataRow current = (DataRow) enumerator6.Current;
                  App.DB.EngineerVisitAssetWorkSheet.PrintedGSRLettersInsert(Conversions.ToInteger(current["AssetID"]), Conversions.ToDate(current["DateDue"]), false);
                }
                break;
              }
              finally
              {
                if (enumerator6 is IDisposable)
                  (enumerator6 as IDisposable).Dispose();
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            this.Finalise(str1, success, true, true, false);
            if (success)
              Process.Start(str1);
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.PartCredit:
          try
          {
            ArrayList arrayList5 = new ArrayList();
            ArrayList detailsToPrint3 = (ArrayList) this.DetailsToPrint;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            int num1 = (int) folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.Trim().Length == 0)
              break;
            str1 = folderBrowserDialog.SelectedPath + "\\" + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".doc";
            this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
            this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            this.MsWordApp.Visible = false;
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents = this.MsWordApp.Documents;
            object obj1 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\CREDIT.dot");
            ref object local1 = ref obj1;
            object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local2 = ref objectValue1;
            object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local3 = ref objectValue2;
            object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local4 = ref objectValue3;
            // ISSUE: reference to a compiler-generated method
            this.WordDoc = documents.Add(ref local1, ref local2, ref local3, ref local4);
            // ISSUE: reference to a compiler-generated method
            this.MsWordApp.Selection.WholeStory();
            // ISSUE: reference to a compiler-generated method
            this.MsWordApp.Selection.Copy();
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = new DataTable();
            int num2 = checked (detailsToPrint3.Count - 1);
            int index = 0;
            while (index <= num2)
            {
              if (index == 0)
              {
                dataTable1 = (DataTable) detailsToPrint3[0];
              }
              else
              {
                DataTable dataTable3 = (DataTable) detailsToPrint3[index];
                dataTable1.ImportRow(dataTable3.Rows[0]);
              }
              checked { ++index; }
            }
            this.DetailsToPrint = (object) dataTable1;
            success = this.Credit();
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
            object obj2 = (object) str1;
            ref object local5 = ref obj2;
            object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local6 = ref objectValue4;
            objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local7 = ref objectValue1;
            object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local8 = ref objectValue5;
            object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local9 = ref objectValue6;
            object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local10 = ref objectValue7;
            object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local11 = ref objectValue8;
            object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local12 = ref objectValue9;
            object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local13 = ref objectValue10;
            object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local14 = ref objectValue11;
            object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local15 = ref objectValue12;
            object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local16 = ref objectValue13;
            object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local17 = ref objectValue14;
            object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local18 = ref objectValue15;
            object objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local19 = ref objectValue16;
            object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local20 = ref objectValue17;
            // ISSUE: reference to a compiler-generated method
            wordDoc.SaveAs(ref local5, ref local6, ref local7, ref local8, ref local9, ref local10, ref local11, ref local12, ref local13, ref local14, ref local15, ref local16, ref local17, ref local18, ref local19, ref local20);
            Marshal.ReleaseComObject((object) this.WordDoc);
            this.WordDoc = (Microsoft.Office.Interop.Word.Document) null;
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            this.Finalise(str1, success, true, true, false);
            if (success)
            {
              Cursor.Current = Cursors.WaitCursor;
              Process.Start(str1);
              Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.ServiceLetters:
          string str5 = "C:\\";
          try
          {
            this.MsWordApp = (Microsoft.Office.Interop.Word.Application) RuntimeHelpers.GetObjectValue(Activator.CreateInstance(System.Type.GetTypeFromProgID("Word.Application", true), true));
            MessageFilter.Register();
            this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            this.MsWordApp.Visible = false;
            str5 = App.TheSystem.Configuration.DocumentsLocation + "ServiceLetters\\ServiceLetters" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + "\\";
            if (!Directory.Exists(str5))
              Directory.CreateDirectory(str5);
            str1 = str5 + "ServiceLetters1_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc";
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents1 = this.MsWordApp.Documents;
            object obj1 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ServiceLetter.dot");
            ref object local1 = ref obj1;
            object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local2 = ref objectValue1;
            object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local3 = ref objectValue2;
            object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local4 = ref objectValue3;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document document1 = documents1.Add(ref local1, ref local2, ref local3, ref local4);
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents2 = this.MsWordApp.Documents;
            object obj2 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ServiceLetter.dot");
            ref object local5 = ref obj2;
            object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local6 = ref objectValue4;
            object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local7 = ref objectValue5;
            object obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local8 = ref obj3;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document document2 = documents2.Add(ref local5, ref local6, ref local7, ref local8);
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents3 = this.MsWordApp.Documents;
            obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ServiceLetter.dot");
            ref object local9 = ref obj3;
            object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local10 = ref objectValue6;
            object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local11 = ref objectValue7;
            object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local12 = ref objectValue8;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document document3 = documents3.Add(ref local9, ref local10, ref local11, ref local12);
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents4 = this.MsWordApp.Documents;
            object obj4 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ServiceLetter.dot");
            ref object local13 = ref obj4;
            objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local14 = ref objectValue7;
            object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local15 = ref objectValue9;
            obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local16 = ref obj3;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document document4 = documents4.Add(ref local13, ref local14, ref local15, ref local16);
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents5 = this.MsWordApp.Documents;
            obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ServiceLetter.dot");
            ref object local17 = ref obj3;
            object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local18 = ref objectValue10;
            object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local19 = ref objectValue11;
            object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local20 = ref objectValue12;
            // ISSUE: reference to a compiler-generated method
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document document5 = documents5.Add(ref local17, ref local18, ref local19, ref local20);
            document1.GrammarChecked = true;
            document1.SpellingChecked = true;
            document2.GrammarChecked = true;
            document2.SpellingChecked = true;
            document3.GrammarChecked = true;
            document3.SpellingChecked = true;
            document4.GrammarChecked = true;
            document4.SpellingChecked = true;
            document5.GrammarChecked = true;
            document5.SpellingChecked = true;
            DataRow[] dataRowArray1 = (DataRow[]) ((ArrayList) this.DetailsToPrint)[0];
            Array array = (Array) App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority, false).Table.Select("Name = 'Service'");
            int num1;
            if (array.Length == 0)
              num1 = App.DB.Picklists.Insert(new PickList()
              {
                SetName = (object) "Service",
                SetEnumTypeID = (object) 45
              });
            else
              num1 = Conversions.ToInteger(((DataRow) NewLateBinding.LateIndexGet((object) array, new object[1]
              {
                (object) 0
              }, (string[]) null))["ManagerID"]);
            StreamWriter text1 = File.CreateText(str5 + "SolidFuels.txt");
            text1.WriteLine("Solid Fuels Properties : ");
            StreamWriter text2 = File.CreateText(str5 + "WarningsAdvice.txt");
            text2.WriteLine("Properties with Warnings/Advice : ");
            StreamWriter text3 = File.CreateText(str5 + "Voids.txt");
            text3.WriteLine("Voids Properties : ");
            StreamWriter text4 = File.CreateText(str5 + "NonGasSiteFuels.txt");
            text4.WriteLine("Non Gas Site Fuel Properties : ");
            int num2 = 0;
            try
            {
              string AMPM = "";
              DataTable dataTable1 = new DataTable();
              dataTable1.Columns.Add("MondayDate", typeof (DateTime));
              dataTable1.Columns.Add("TheDate", typeof (DateTime));
              dataTable1.Columns.Add("Count");
              dataTable1.Columns.Add("AM");
              dataTable1.Columns.Add("PM");
              dataTable1.Columns.Add("ApptsMinsTally");
              dataTable1.Columns.Add("Loops");
              DataTable dataTable2 = new DataTable();
              dataTable2.Columns.Add("Date", typeof (DateTime));
              dataTable2.Columns.Add("Count");
              dataTable2.Columns.Add("AMAssigned");
              DataTable dataTable3 = new DataTable();
              dataTable3.Columns.Add("Date", typeof (DateTime));
              dataTable3.Columns.Add("Count");
              dataTable3.Columns.Add("AMAssigned");
              App.DB.LetterManager.Clear_LetterDays_Table();
              DataRow[] dataRowArray2 = dataRowArray1;
              int index1 = 0;
              DateTime dateTime1;
              while (index1 < dataRowArray2.Length)
              {
                DataRow dataRow1 = dataRowArray2[index1];
                if (CustomerID == 5155 & DateTime.Compare(Conversions.ToDate(dataRow1["LastServiceDate"]), Conversions.ToDate("2012-05-01 00:00:00")) < 0)
                  Conversions.ToDate(dataRow1["LastServiceDate"]);
                else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow1["type"], (object) "Letter 1", false))
                {
                  Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(dataRow1["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
                  DataRow[] dataRowArray3 = !site.CommercialDistrict ? (!site.SolidFuel ? App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7007'") : App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7001'")) : App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7008'");
                  int num3;
                  if (dataRowArray3.Length > 0)
                  {
                    DataRow dataRow2 = dataRowArray3[0];
                    int CustomerScheduleOfRateID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(dataRow2["ScheduleOfRatesCategoryID"]), Conversions.ToString(dataRow2["Description"]), Conversions.ToString(dataRow2["Code"]), CustomerID).AsEnumerable().ElementAtOrDefault<DataRow>(0)[0]));
                    num3 = CustomerScheduleOfRateID <= 0 ? Conversions.ToInteger(dataRow2["TimeInMins"]) : (App.DB.CustomerScheduleOfRate.Get(CustomerScheduleOfRateID) ?? new CustomerScheduleOfRate()).TimeInMins;
                  }
                  if (CustomerID == 5155)
                  {
                    if (DateTime.Compare(Conversions.ToDate(dataRow1["NextVisitDate"]), Conversions.ToDate("2013-05-07 00:00:00")) <= 0)
                    {
                      DateTime sourceDate = LetterCreationDate.AddDays(56.0);
                      dataRow1["NextVisitDate"] = (object) DateHelper.CheckBankHolidaySatOrSun(sourceDate, false);
                    }
                    else
                      dataRow1["NextVisitDate"] = (object) DateHelper.CheckBankHolidaySatOrSun(Conversions.ToDate(dataRow1["NextVisitDate"]), false);
                  }
                  else
                    dataRow1["NextVisitDate"] = (object) DateHelper.CheckBankHolidaySatOrSun(Conversions.ToDate(dataRow1["NextVisitDate"]), false);
                  int num4 = 1;
                  bool flag = false;
                  while (!flag)
                  {
                    int num5 = num4;
                    int num6 = 1;
                    while (num6 <= num5)
                    {
                      if (num6 > num2)
                        num2 = num6;
                      int num7 = 1;
                      do
                      {
                        DataTable table = App.DB.TimeSlotRates.BankHolidays_GetAll().Table;
                        dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                        string filterExpression1 = "BankHolidayDate='" + Conversions.ToString(dateTime1.AddDays((double) num7)) + "'";
                        if (table.Select(filterExpression1).Length == 0)
                        {
                          DataTable dataTable4 = dataTable1;
                          string[] strArray = new string[7]
                          {
                            "MondayDate='",
                            Conversions.ToString(DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]))),
                            "' AND TheDate='",
                            null,
                            null,
                            null,
                            null
                          };
                          dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                          strArray[3] = Conversions.ToString(dateTime1.AddDays((double) num7));
                          strArray[4] = "' AND Loops='";
                          strArray[5] = Conversions.ToString(num6);
                          strArray[6] = "'";
                          string filterExpression2 = string.Concat(strArray);
                          DataRow[] dataRowArray4 = dataTable4.Select(filterExpression2);
                          if (dataRowArray4.Length == 0)
                          {
                            DataRowCollection rows = dataTable1.Rows;
                            object[] objArray = new object[7];
                            objArray[0] = (object) DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            objArray[1] = (object) dateTime1.AddDays((double) num7);
                            objArray[2] = (object) 1;
                            objArray[3] = (object) 1;
                            objArray[4] = (object) 0;
                            objArray[5] = (object) num3;
                            objArray[6] = (object) num6;
                            rows.Add(objArray);
                            LetterManagerSQL letterManager = App.DB.LetterManager;
                            DateTime theMonday = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            DateTime TheDate = dateTime1.AddDays((double) num7);
                            int MinsTally = num3;
                            int LoopNumber = num6;
                            letterManager.Insert_LetterDays_Table(theMonday, TheDate, MinsTally, LoopNumber);
                            flag = true;
                            break;
                          }
                          int integer1 = Conversions.ToInteger(dataRowArray4[0]["ApptsMinsTally"]);
                          if ((double) integer1 <= (double) MinsPerDayIn / 2.0)
                          {
                            DataRow dataRow2;
                            (dataRow2 = dataRowArray4[0])["count"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["count"], (object) 1);
                            DataRow dataRow3;
                            (dataRow3 = dataRowArray4[0])["AM"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow3["AM"], (object) 1);
                            DataRow dataRow4;
                            (dataRow4 = dataRowArray4[0])["ApptsMinsTally"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow4["ApptsMinsTally"], (object) num3);
                            LetterManagerSQL letterManager = App.DB.LetterManager;
                            DateTime theMonday = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            DateTime TheDate = dateTime1.AddDays((double) num7);
                            int integer2 = Conversions.ToInteger(dataRowArray4[0]["count"]);
                            int integer3 = Conversions.ToInteger(dataRowArray4[0]["AM"]);
                            int integer4 = Conversions.ToInteger(dataRowArray4[0]["ApptsMinsTally"]);
                            int LoopNumber = num6;
                            letterManager.Update_LetterDays_Table(theMonday, TheDate, integer2, integer3, 0, integer4, LoopNumber);
                            flag = true;
                            break;
                          }
                          if ((double) integer1 > (double) MinsPerDayIn / 2.0 & integer1 <= MinsPerDayIn)
                          {
                            DataRow dataRow2;
                            (dataRow2 = dataRowArray4[0])["count"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["count"], (object) 1);
                            DataRow dataRow3;
                            (dataRow3 = dataRowArray4[0])["PM"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow3["PM"], (object) 1);
                            DataRow dataRow4;
                            (dataRow4 = dataRowArray4[0])["ApptsMinsTally"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow4["ApptsMinsTally"], (object) num3);
                            LetterManagerSQL letterManager = App.DB.LetterManager;
                            DateTime theMonday = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            DateTime TheDate = dateTime1.AddDays((double) num7);
                            int integer2 = Conversions.ToInteger(dataRowArray4[0]["count"]);
                            int integer3 = Conversions.ToInteger(dataRowArray4[0]["PM"]);
                            int integer4 = Conversions.ToInteger(dataRowArray4[0]["ApptsMinsTally"]);
                            int LoopNumber = num6;
                            letterManager.Update_LetterDays_Table(theMonday, TheDate, integer2, 0, integer3, integer4, LoopNumber);
                            flag = true;
                            break;
                          }
                          flag = false;
                        }
                        else
                          flag = false;
                        checked { ++num7; }
                      }
                      while (num7 <= 4);
                      if (!flag)
                      {
                        DataView all = App.DB.TimeSlotRates.BankHolidays_GetAll();
                        int num8 = 0;
                        DataTable table = all.Table;
                        dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                        string filterExpression1 = "BankHolidayDate='" + Conversions.ToString(dateTime1.AddDays((double) num8)) + "'";
                        if (table.Select(filterExpression1).Length == 0)
                        {
                          DataTable dataTable4 = dataTable1;
                          string[] strArray = new string[7]
                          {
                            "MondayDate='",
                            Conversions.ToString(DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]))),
                            "' AND TheDate='",
                            null,
                            null,
                            null,
                            null
                          };
                          dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                          strArray[3] = Conversions.ToString(dateTime1.AddDays((double) num8));
                          strArray[4] = "' AND Loops='";
                          strArray[5] = Conversions.ToString(num6);
                          strArray[6] = "'";
                          string filterExpression2 = string.Concat(strArray);
                          DataRow[] dataRowArray4 = dataTable4.Select(filterExpression2);
                          if (dataRowArray4.Length == 0)
                          {
                            DataRowCollection rows = dataTable1.Rows;
                            object[] objArray = new object[7];
                            objArray[0] = (object) DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            objArray[1] = (object) dateTime1.AddDays((double) num8);
                            objArray[2] = (object) 1;
                            objArray[3] = (object) 1;
                            objArray[4] = (object) 0;
                            objArray[5] = (object) num3;
                            objArray[6] = (object) num6;
                            rows.Add(objArray);
                            LetterManagerSQL letterManager = App.DB.LetterManager;
                            DateTime theMonday = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                            DateTime TheDate = dateTime1.AddDays((double) num8);
                            int MinsTally = num3;
                            int LoopNumber = num6;
                            letterManager.Insert_LetterDays_Table(theMonday, TheDate, MinsTally, LoopNumber);
                            flag = true;
                          }
                          else
                          {
                            int integer1 = Conversions.ToInteger(dataRowArray4[0]["ApptsMinsTally"]);
                            if ((double) integer1 <= (double) MinsPerDayIn / 2.0)
                            {
                              DataRow dataRow2;
                              (dataRow2 = dataRowArray4[0])["count"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["count"], (object) 1);
                              DataRow dataRow3;
                              (dataRow3 = dataRowArray4[0])["AM"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow3["AM"], (object) 1);
                              DataRow dataRow4;
                              (dataRow4 = dataRowArray4[0])["ApptsMinsTally"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow4["ApptsMinsTally"], (object) num3);
                              LetterManagerSQL letterManager = App.DB.LetterManager;
                              DateTime theMonday = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                              dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                              DateTime TheDate = dateTime1.AddDays((double) num8);
                              int integer2 = Conversions.ToInteger(dataRowArray4[0]["count"]);
                              int integer3 = Conversions.ToInteger(dataRowArray4[0]["AM"]);
                              int integer4 = Conversions.ToInteger(dataRowArray4[0]["ApptsMinsTally"]);
                              int LoopNumber = num6;
                              letterManager.Update_LetterDays_Table(theMonday, TheDate, integer2, integer3, 0, integer4, LoopNumber);
                              flag = true;
                            }
                            else if ((double) integer1 > (double) MinsPerDayIn / 2.0 & integer1 <= MinsPerDayIn)
                            {
                              DataRow dataRow2;
                              (dataRow2 = dataRowArray4[0])["count"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["count"], (object) 1);
                              DataRow dataRow3;
                              (dataRow3 = dataRowArray4[0])["PM"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow3["PM"], (object) 1);
                              DataRow dataRow4;
                              (dataRow4 = dataRowArray4[0])["ApptsMinsTally"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow4["ApptsMinsTally"], (object) num3);
                              LetterManagerSQL letterManager = App.DB.LetterManager;
                              DateTime theMonday = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                              dateTime1 = DateHelper.GetTheMonday(Conversions.ToDate(dataRow1["NextVisitDate"]));
                              DateTime TheDate = dateTime1.AddDays((double) num8);
                              int integer2 = Conversions.ToInteger(dataRowArray4[0]["count"]);
                              int integer3 = Conversions.ToInteger(dataRowArray4[0]["PM"]);
                              int integer4 = Conversions.ToInteger(dataRowArray4[0]["ApptsMinsTally"]);
                              int LoopNumber = num6;
                              letterManager.Update_LetterDays_Table(theMonday, TheDate, integer2, 0, integer3, integer4, LoopNumber);
                              flag = true;
                            }
                            else
                              checked { ++num4; }
                          }
                        }
                        else
                          checked { ++num4; }
                      }
                      if (!flag)
                        checked { ++num6; }
                      else
                        break;
                    }
                  }
                }
                else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow1["Type"], (object) "Letter 2", false))
                {
                  DataRow[] dataRowArray3 = dataTable2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Date='", dataRow1["NextVisitDate"]), (object) "'")));
                  if (dataRowArray3.Length == 0)
                  {
                    dataTable2.Rows.Add(dataRow1["NextVisitDate"], (object) 1, (object) 0);
                  }
                  else
                  {
                    DataRow dataRow2;
                    (dataRow2 = dataRowArray3[0])["count"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["count"], (object) 1);
                  }
                }
                else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow1["Type"], (object) "Letter 3", false))
                {
                  DataRow[] dataRowArray3 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Date='", dataRow1["NextVisitDate"]), (object) "'")));
                  if (dataRowArray3.Length == 0)
                  {
                    dataTable3.Rows.Add(dataRow1["NextVisitDate"], (object) 1, (object) 0);
                  }
                  else
                  {
                    DataRow dataRow2;
                    (dataRow2 = dataRowArray3[0])["count"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow2["count"], (object) 1);
                  }
                }
                checked { ++index1; }
              }
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents6 = this.MsWordApp.Documents;
              object obj5 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection.dot");
              ref object local21 = ref obj5;
              object obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local22 = ref obj6;
              object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local23 = ref objectValue13;
              obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local24 = ref obj3;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document6 = documents6.Add(ref local21, ref local22, ref local23, ref local24);
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents7 = this.MsWordApp.Documents;
              obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection2.dot");
              ref object local25 = ref obj3;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local26 = ref objectValue13;
              obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local27 = ref obj6;
              object obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local28 = ref obj7;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document7 = documents7.Add(ref local25, ref local26, ref local27, ref local28);
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents8 = this.MsWordApp.Documents;
              obj7 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection2HandLetter.dot");
              ref object local29 = ref obj7;
              obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local30 = ref obj6;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local31 = ref objectValue13;
              obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local32 = ref obj3;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document8 = documents8.Add(ref local29, ref local30, ref local31, ref local32);
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents9 = this.MsWordApp.Documents;
              obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection3.dot");
              ref object local33 = ref obj3;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local34 = ref objectValue13;
              obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local35 = ref obj6;
              obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local36 = ref obj7;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document9 = documents9.Add(ref local33, ref local34, ref local35, ref local36);
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents10 = this.MsWordApp.Documents;
              obj7 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection3HandLetter.dot");
              ref object local37 = ref obj7;
              obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local38 = ref obj6;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local39 = ref objectValue13;
              obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local40 = ref obj3;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document10 = documents10.Add(ref local37, ref local38, ref local39, ref local40);
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents11 = this.MsWordApp.Documents;
              obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection3HandLetterDistrict.dot");
              ref object local41 = ref obj3;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local42 = ref objectValue13;
              obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local43 = ref obj6;
              obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local44 = ref obj7;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document11 = documents11.Add(ref local41, ref local42, ref local43, ref local44);
              document7.GrammarChecked = true;
              document7.SpellingChecked = true;
              document8.GrammarChecked = true;
              document8.SpellingChecked = true;
              document9.GrammarChecked = true;
              document9.SpellingChecked = true;
              document10.GrammarChecked = true;
              document10.SpellingChecked = true;
              document11.GrammarChecked = true;
              document11.SpellingChecked = true;
              SqlTransaction trans = (SqlTransaction) null;
              SqlConnection sqlConnection = (SqlConnection) null;
              DataRow[] dataRowArray5 = dataRowArray1;
              int index2 = 0;
              while (index2 < dataRowArray5.Length)
              {
                DataRow dr = dataRowArray5[index2];
                try
                {
                  if (CustomerID == 5155 & DateTime.Compare(Conversions.ToDate(dr["LastServiceDate"]), Conversions.ToDate("2012-05-01 00:00:00")) < 0)
                  {
                    Conversions.ToDate(dr["LastServiceDate"]);
                  }
                  else
                  {
                    sqlConnection = new SqlConnection(App.DB.ServerConnectionString);
                    sqlConnection.Open();
                    trans = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
                    JobNumber jobNumber1 = new JobNumber();
                    JobNumber jobNumber2 = CustomerID == 2846 ? App.DB.Job.GetNextJobNumber(Enums.JobDefinition.SERVICE_LETTER_JOB, trans) : App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout, trans);
                    DateTime VisitDate;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["type"], (object) "Letter 1", false))
                    {
                      this.WordDoc = document1;
                      this.WordDoc.GrammarChecked = true;
                      this.WordDoc.SpellingChecked = true;
                      // ISSUE: reference to a compiler-generated method
                      document6.Select();
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.WholeStory();
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.Copy();
                      // ISSUE: reference to a compiler-generated method
                      this.WordDoc.Activate();
                      // ISSUE: variable of a compiler-generated type
                      Selection selection = this.MsWordApp.Selection;
                      obj7 = (object) WdUnits.wdStory;
                      ref object local45 = ref obj7;
                      obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                      ref object local46 = ref obj6;
                      // ISSUE: reference to a compiler-generated method
                      selection.EndKey(ref local45, ref local46);
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.Paste();
                      Conversions.ToDate(dr["NextVisitDate"]);
                      Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["Postcode"]));
                      IEnumerator enumerator4;
                      try
                      {
                        enumerator4 = dataTable1.Rows.GetEnumerator();
                        while (enumerator4.MoveNext())
                        {
                          DataRow current = (DataRow) enumerator4.Current;
                          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["MondayDate"], (object) DateHelper.GetTheMonday(Conversions.ToDate(dr["NextVisitDate"])), false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(current["Count"], (object) 0, false))))
                          {
                            VisitDate = Conversions.ToDate(current["TheDate"]);
                            DataRow dataRow1;
                            (dataRow1 = current)["Count"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dataRow1["Count"], (object) 1);
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(current["AM"], (object) 0, false))
                            {
                              AMPM = "AM";
                              DataRow dataRow2;
                              (dataRow2 = current)["AM"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dataRow2["AM"], (object) 1);
                              App.DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(dr["NextVisitDate"])), Conversions.ToDate(current["TheDate"]), Conversions.ToInteger(current["Count"]), Conversions.ToInteger(current["AM"]), 0, Conversions.ToInteger(current["ApptsMinsTally"]), Conversions.ToInteger(current["Loops"]));
                              break;
                            }
                            AMPM = "PM";
                            DataRow dataRow3;
                            (dataRow3 = current)["PM"] = Microsoft.VisualBasic.CompilerServices.Operators.SubtractObject(dataRow3["PM"], (object) 1);
                            App.DB.LetterManager.Update_LetterDays_Table(DateHelper.GetTheMonday(Conversions.ToDate(dr["NextVisitDate"])), Conversions.ToDate(current["TheDate"]), Conversions.ToInteger(current["Count"]), 0, Conversions.ToInteger(current["PM"]), Conversions.ToInteger(current["ApptsMinsTally"]), Conversions.ToInteger(current["Loops"]));
                            break;
                          }
                        }
                      }
                      finally
                      {
                        if (enumerator4 is IDisposable)
                          (enumerator4 as IDisposable).Dispose();
                      }
                    }
                    else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 2", false))
                    {
                      this.WordDoc = document2;
                      this.WordDoc.GrammarChecked = true;
                      this.WordDoc.SpellingChecked = true;
                      // ISSUE: reference to a compiler-generated method
                      document7.Select();
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.WholeStory();
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.Copy();
                      // ISSUE: reference to a compiler-generated method
                      this.WordDoc.Activate();
                      // ISSUE: variable of a compiler-generated type
                      Selection selection1 = this.MsWordApp.Selection;
                      obj6 = (object) WdUnits.wdStory;
                      ref object local45 = ref obj6;
                      obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                      ref object local46 = ref obj7;
                      // ISSUE: reference to a compiler-generated method
                      selection1.EndKey(ref local45, ref local46);
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.Paste();
                      VisitDate = DateHelper.CheckBankHolidaySatOrSun(Conversions.ToDate(dr["NextVisitDate"]), false);
                      DataRow[] dataRowArray3 = dataTable2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Date='", dr["NextVisitDate"]), (object) "'")));
                      if (dataRowArray3.Length > 0)
                      {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual(dataRowArray3[0]["AMAssigned"], Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(dataRowArray3[0]["Count"], (object) 2), false))
                        {
                          AMPM = "PM";
                        }
                        else
                        {
                          AMPM = "AM";
                          DataRow dataRow;
                          (dataRow = dataRowArray3[0])["AMAssigned"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow["AMAssigned"], (object) 1);
                        }
                      }
                      // ISSUE: variable of a compiler-generated type
                      Selection selection2 = this.MsWordApp.Selection;
                      obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                      ref object local47 = ref obj7;
                      // ISSUE: reference to a compiler-generated method
                      selection2.InsertBreak(ref local47);
                    }
                    else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 3", false))
                    {
                      this.WordDoc = document4;
                      this.WordDoc.GrammarChecked = true;
                      this.WordDoc.SpellingChecked = true;
                      // ISSUE: reference to a compiler-generated method
                      document9.Select();
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.WholeStory();
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.Copy();
                      // ISSUE: reference to a compiler-generated method
                      this.WordDoc.Activate();
                      // ISSUE: variable of a compiler-generated type
                      Selection selection = this.MsWordApp.Selection;
                      obj7 = (object) WdUnits.wdStory;
                      ref object local45 = ref obj7;
                      obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                      ref object local46 = ref obj6;
                      // ISSUE: reference to a compiler-generated method
                      selection.EndKey(ref local45, ref local46);
                      // ISSUE: reference to a compiler-generated method
                      this.MsWordApp.Selection.Paste();
                      VisitDate = DateHelper.CheckBankHolidaySatOrSun(Conversions.ToDate(dr["NextVisitDate"]), false);
                      DataRow[] dataRowArray3 = dataTable3.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Date='", dr["NextVisitDate"]), (object) "'")));
                      if (dataRowArray3.Length > 0)
                      {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual(dataRowArray3[0]["AMAssigned"], Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(dataRowArray3[0]["Count"], (object) 2), false))
                        {
                          AMPM = "PM";
                        }
                        else
                        {
                          AMPM = "AM";
                          DataRow dataRow;
                          (dataRow = dataRowArray3[0])["AMAssigned"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow["AMAssigned"], (object) 1);
                        }
                      }
                    }
                    success = this.GenerateServiceLetter(dr, AMPM, VisitDate, jobNumber2.Prefix + Conversions.ToString(jobNumber2.JobNumber), DateAndTime.Now);
                    if (success)
                    {
                      Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(dr["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["type"], (object) "Letter 1", false))
                        document1 = this.WordDoc;
                      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 2", false))
                      {
                        document2 = this.WordDoc;
                        this.WordDoc = document3;
                        this.WordDoc.GrammarChecked = true;
                        this.WordDoc.SpellingChecked = true;
                        // ISSUE: reference to a compiler-generated method
                        document8.Select();
                        // ISSUE: reference to a compiler-generated method
                        this.MsWordApp.Selection.WholeStory();
                        // ISSUE: reference to a compiler-generated method
                        this.MsWordApp.Selection.Copy();
                        // ISSUE: reference to a compiler-generated method
                        this.WordDoc.Activate();
                        // ISSUE: variable of a compiler-generated type
                        Selection selection = this.MsWordApp.Selection;
                        obj6 = (object) WdUnits.wdStory;
                        ref object local45 = ref obj6;
                        obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                        ref object local46 = ref obj7;
                        // ISSUE: reference to a compiler-generated method
                        selection.EndKey(ref local45, ref local46);
                        // ISSUE: reference to a compiler-generated method
                        this.MsWordApp.Selection.Paste();
                        success = this.GenerateServiceLetter(dr, AMPM, VisitDate, jobNumber2.Prefix + Conversions.ToString(jobNumber2.JobNumber), DateAndTime.Now);
                        document3 = this.WordDoc;
                      }
                      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 3", false))
                      {
                        document4 = this.WordDoc;
                        this.WordDoc = document5;
                        this.WordDoc.GrammarChecked = true;
                        this.WordDoc.SpellingChecked = true;
                        if (site.CommercialDistrict)
                        {
                          // ISSUE: reference to a compiler-generated method
                          document11.Select();
                        }
                        else
                        {
                          // ISSUE: reference to a compiler-generated method
                          document10.Select();
                        }
                        // ISSUE: reference to a compiler-generated method
                        this.MsWordApp.Selection.WholeStory();
                        // ISSUE: reference to a compiler-generated method
                        this.MsWordApp.Selection.Copy();
                        // ISSUE: reference to a compiler-generated method
                        this.WordDoc.Activate();
                        // ISSUE: variable of a compiler-generated type
                        Selection selection = this.MsWordApp.Selection;
                        obj7 = (object) WdUnits.wdStory;
                        ref object local45 = ref obj7;
                        obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                        ref object local46 = ref obj6;
                        // ISSUE: reference to a compiler-generated method
                        selection.EndKey(ref local45, ref local46);
                        // ISSUE: reference to a compiler-generated method
                        this.MsWordApp.Selection.Paste();
                        success = this.GenerateServiceLetter(dr, AMPM, VisitDate, jobNumber2.Prefix + Conversions.ToString(jobNumber2.JobNumber), DateAndTime.Now);
                        document5 = this.WordDoc;
                      }
                      if (success)
                      {
                        Job oJob = new Job();
                        oJob.SetPropertyID = RuntimeHelpers.GetObjectValue(dr["SiteID"]);
                        oJob.SetJobDefinitionEnumID = (object) 3;
                        oJob.SetJobTypeID = RuntimeHelpers.GetObjectValue(App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes, false).Table.Select("NAME = 'Service and Certificate'")[0]["ManagerID"]);
                        oJob.SetStatusEnumID = (object) 1;
                        oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
                        oJob.SetFOC = (object) true;
                        oJob.SetJobNumber = (object) (jobNumber2.Prefix + Conversions.ToString(jobNumber2.JobNumber));
                        oJob.SetPONumber = (object) "";
                        oJob.SetQuoteID = (object) 0;
                        oJob.SetContractID = (object) 0;
                        JobOfWork jobOfWork = new JobOfWork();
                        jobOfWork.SetPONumber = (object) "";
                        jobOfWork.SetPriority = (object) num1;
                        if ((uint) jobOfWork.Priority > 0U)
                          jobOfWork.PriorityDateSet = DateAndTime.Now;
                        jobOfWork.IgnoreExceptionsOnSetMethods = true;
                        DataRow[] dataRowArray3 = (DataRow[]) null;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 1", false))
                          dataRowArray3 = !site.CommercialDistrict ? (!site.SolidFuel ? App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7007'") : App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7001'")) : App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7008'");
                        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 2", false))
                          dataRowArray3 = !site.CommercialDistrict ? (!site.SolidFuel ? App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7007*'") : App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7001*'")) : App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7008*'");
                        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 3", false))
                          dataRowArray3 = !site.CommercialDistrict ? (!site.SolidFuel ? App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7007^'") : App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7001^'")) : App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table.Select("Code='EA7008^'");
                        if (dataRowArray3.Length > 0)
                        {
                          DataRow dataRow = dataRowArray3[0];
                          DataTable source = App.DB.CustomerScheduleOfRate.Exists(Conversions.ToInteger(dataRow["ScheduleOfRatesCategoryID"]), Conversions.ToString(dataRow["Description"]), Conversions.ToString(dataRow["Code"]), CustomerID);
                          int CustomerScheduleOfRateID = 0;
                          if (source.Rows.Count > 0)
                            CustomerScheduleOfRateID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(source.AsEnumerable().ElementAtOrDefault<DataRow>(0)[0]));
                          if (CustomerScheduleOfRateID <= 0)
                          {
                            CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
                            {
                              SetCode = RuntimeHelpers.GetObjectValue(dataRow["Code"]),
                              SetDescription = RuntimeHelpers.GetObjectValue(dataRow["Description"]),
                              SetPrice = RuntimeHelpers.GetObjectValue(dataRow["Price"]),
                              SetScheduleOfRatesCategoryID = RuntimeHelpers.GetObjectValue(dataRow["ScheduleOfRatesCategoryID"]),
                              SetTimeInMins = RuntimeHelpers.GetObjectValue(dataRow["TimeInMins"]),
                              SetCustomerID = (object) CustomerID
                            };
                            CustomerScheduleOfRateID = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
                            App.DB.CustomerScheduleOfRate.Delete(CustomerScheduleOfRateID);
                          }
                          jobOfWork.JobItems.Add((object) new JobItem()
                          {
                            IgnoreExceptionsOnSetMethods = true,
                            SetSummary = RuntimeHelpers.GetObjectValue(dataRow["Description"]),
                            SetQty = (object) 1,
                            SetRateID = (object) CustomerScheduleOfRateID,
                            SetSystemLinkID = (object) 95
                          });
                        }
                        EngineerVisit engineerVisit1 = new EngineerVisit();
                        engineerVisit1.IgnoreExceptionsOnSetMethods = true;
                        engineerVisit1.SetEngineerID = (object) 0;
                        string str2 = dr["SiteFuel"] != DBNull.Value ? (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dr["SiteFuel"], (object) "Gas", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dr["siteFuel"], (object) "0", false))) ? Conversions.ToString(dr["siteFuel"]) : "") : "";
                        engineerVisit1.SetNotesToEngineer = (object) ("(" + AMPM + ") - " + str2 + " - Carry out safety inspection");
                        switch (CustomerID)
                        {
                          case 2846:
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 2", false))
                              engineerVisit1.SetNotesToEngineer = (object) (engineerVisit1.NotesToEngineer + ", Take hand delivered letter and red sticker. ");
                            else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 3", false))
                              engineerVisit1.SetNotesToEngineer = (object) engineerVisit1.NotesToEngineer;
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dr["Type"], (object) "Letter 1", false))
                            {
                              engineerVisit1.SetPartsToFit = (object) true;
                              break;
                            }
                            break;
                          case 5155:
                            dateTime1 = Conversions.ToDate(dr["LastServiceDate"]);
                            DateTime dateTime2 = DateHelper.CheckBankHolidaySatOrSun(dateTime1.AddYears(1).AddDays(-7.0), false);
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 2", false))
                              engineerVisit1.SetNotesToEngineer = (object) (engineerVisit1.NotesToEngineer + ", Second Visit, Take hand delivered letter and Red Sticker. Final Visit: " + Conversions.ToString(dateTime2));
                            else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 3", false))
                              engineerVisit1.SetNotesToEngineer = (object) (engineerVisit1.NotesToEngineer + ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape.");
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dr["Type"], (object) "Letter 1", false))
                            {
                              engineerVisit1.SetPartsToFit = (object) false;
                              break;
                            }
                            break;
                          case 5872:
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 2", false))
                            {
                              EngineerVisit engineerVisit2 = engineerVisit1;
                              string notesToEngineer = engineerVisit1.NotesToEngineer;
                              dateTime1 = Conversions.ToDate(dr["LastServiceDate"]);
                              string str3 = Conversions.ToString(dateTime1.AddYears(1));
                              string str4 = notesToEngineer + ", Second Visit, Take hand delivered letter and Yellow Sticker. Service Expires: " + str3;
                              engineerVisit2.SetNotesToEngineer = (object) str4;
                            }
                            else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 3", false))
                              engineerVisit1.SetNotesToEngineer = (object) (engineerVisit1.NotesToEngineer + ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape.");
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dr["Type"], (object) "Letter 1", false))
                            {
                              engineerVisit1.SetPartsToFit = (object) false;
                              break;
                            }
                            break;
                          default:
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 2", false))
                              engineerVisit1.SetNotesToEngineer = (object) engineerVisit1.NotesToEngineer;
                            else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 3", false))
                              engineerVisit1.SetNotesToEngineer = (object) engineerVisit1.NotesToEngineer;
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dr["Type"], (object) "Letter 1", false))
                            {
                              engineerVisit1.SetPartsToFit = (object) false;
                              break;
                            }
                            break;
                        }
                        engineerVisit1.StartDateTime = DateTime.MinValue;
                        engineerVisit1.EndDateTime = DateTime.MinValue;
                        engineerVisit1.SetStatusEnumID = (object) 4;
                        engineerVisit1.DueDate = VisitDate;
                        engineerVisit1.SetAMPM = (object) AMPM;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 1", false))
                          engineerVisit1.SetVisitNumber = (object) 1;
                        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 2", false))
                          engineerVisit1.SetVisitNumber = (object) 2;
                        else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["Type"], (object) "Letter 3", false))
                          engineerVisit1.SetVisitNumber = (object) 3;
                        jobOfWork.EngineerVisits.Add((object) engineerVisit1);
                        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dr["Type"], (object) "Letter 3", false), (object) (CustomerID != 2846))))
                          jobOfWork.EngineerVisits.Add((object) engineerVisit1);
                        oJob.JobOfWorks.Add((object) jobOfWork);
                        Job job = App.DB.Job.Insert(oJob, trans);
                        App.DB.LetterManager.LetterGenerated(Conversions.ToInteger(dr["SiteID"]), Conversions.ToString(dr["Type"]), Conversions.ToDate(dr["LastServiceDate"]), job.JobID, str5, trans);
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["SolidFuel"], (object) true, false))
                          text1.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["Name"], (object) ", "), dr["Address1"]), (object) ", "), dr["Address2"]), (object) ", "), dr["Address3"]), (object) ", "), dr["Address4"]), (object) ", "), dr["Address5"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["Postcode"]))));
                        if (dr["Notes"].ToString().Contains("T1WARN") | dr["Notes"].ToString().Contains("T1ADVI") | dr["Notes"].ToString().Contains("T2WARN") | dr["Notes"].ToString().Contains("T2ADVI"))
                        {
                          text2.WriteLine(" ");
                          text2.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["Name"], (object) ", "), dr["Address1"]), (object) ", "), dr["Address2"]), (object) ", "), dr["Address3"]), (object) ", "), dr["Address4"]), (object) ", "), dr["Address5"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["Postcode"]))), (object) " NOTES : "), dr["Notes"]));
                        }
                        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dr["PropertyVoid"])))
                          text3.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["Name"], (object) ", "), dr["Address1"]), (object) ", "), dr["Address2"]), (object) ", "), dr["Address3"]), (object) ", "), dr["Address4"]), (object) ", "), dr["Address5"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["Postcode"]))));
                        if (dr["SiteFuel"] != DBNull.Value && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dr["SiteFuel"], (object) "Gas", false))))
                          text4.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["Name"], (object) ", "), dr["Address1"]), (object) ", "), dr["Address2"]), (object) ", "), dr["Address3"]), (object) ", "), dr["Address4"]), (object) ", "), dr["Address5"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["Postcode"]))), (object) ", "), dr["SiteFuel"]));
                      }
                    }
                    trans.Commit();
                  }
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  int num3 = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  trans?.Rollback();
                  sqlConnection?.Close();
                  ProjectData.ClearProjectError();
                }
                checked { ++index2; }
              }
              text1.Close();
              text2.Close();
              text3.Close();
              text4.Close();
              this.WordDoc = document1;
              this.WordDoc.GrammarChecked = true;
              this.WordDoc.SpellingChecked = true;
              // ISSUE: reference to a compiler-generated method
              document2.Activate();
              // ISSUE: reference to a compiler-generated method
              this.MsWordApp.Selection.WholeStory();
              this.MsWordApp.Selection.Font.Name = "Arial";
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document12 = document2;
              obj6 = (object) (str5 + "ServiceLetters2_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
              ref object local48 = ref obj6;
              obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local49 = ref obj7;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local50 = ref objectValue13;
              obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local51 = ref obj3;
              object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local52 = ref objectValue14;
              object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local53 = ref objectValue15;
              object objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local54 = ref objectValue16;
              object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local55 = ref objectValue17;
              object objectValue18 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local56 = ref objectValue18;
              object objectValue19 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local57 = ref objectValue19;
              object objectValue20 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local58 = ref objectValue20;
              object objectValue21 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local59 = ref objectValue21;
              object objectValue22 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local60 = ref objectValue22;
              object objectValue23 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local61 = ref objectValue23;
              object objectValue24 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local62 = ref objectValue24;
              object objectValue25 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local63 = ref objectValue25;
              // ISSUE: reference to a compiler-generated method
              document12.SaveAs(ref local48, ref local49, ref local50, ref local51, ref local52, ref local53, ref local54, ref local55, ref local56, ref local57, ref local58, ref local59, ref local60, ref local61, ref local62, ref local63);
              // ISSUE: reference to a compiler-generated method
              document4.Activate();
              // ISSUE: reference to a compiler-generated method
              this.MsWordApp.Selection.WholeStory();
              this.MsWordApp.Selection.Font.Name = "Arial";
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document13 = document4;
              object obj8 = (object) (str5 + "ServiceLetters3_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
              ref object local64 = ref obj8;
              objectValue24 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local65 = ref objectValue24;
              object objectValue26 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local66 = ref objectValue26;
              object objectValue27 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local67 = ref objectValue27;
              object objectValue28 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local68 = ref objectValue28;
              object objectValue29 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local69 = ref objectValue29;
              object objectValue30 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local70 = ref objectValue30;
              object objectValue31 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local71 = ref objectValue31;
              object objectValue32 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local72 = ref objectValue32;
              objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local73 = ref objectValue16;
              object objectValue33 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local74 = ref objectValue33;
              object objectValue34 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local75 = ref objectValue34;
              obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local76 = ref obj3;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local77 = ref objectValue13;
              obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local78 = ref obj7;
              obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local79 = ref obj6;
              // ISSUE: reference to a compiler-generated method
              document13.SaveAs(ref local64, ref local65, ref local66, ref local67, ref local68, ref local69, ref local70, ref local71, ref local72, ref local73, ref local74, ref local75, ref local76, ref local77, ref local78, ref local79);
              // ISSUE: reference to a compiler-generated method
              document3.Activate();
              // ISSUE: reference to a compiler-generated method
              this.MsWordApp.Selection.WholeStory();
              this.MsWordApp.Selection.Font.Name = "Arial";
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document14 = document3;
              obj6 = (object) (str5 + "ServiceLetters2HandDeliver_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
              ref object local80 = ref obj6;
              obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local81 = ref obj7;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local82 = ref objectValue13;
              obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local83 = ref obj3;
              object objectValue35 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local84 = ref objectValue35;
              object objectValue36 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local85 = ref objectValue36;
              objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local86 = ref objectValue16;
              object objectValue37 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local87 = ref objectValue37;
              object objectValue38 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local88 = ref objectValue38;
              object objectValue39 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local89 = ref objectValue39;
              objectValue29 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local90 = ref objectValue29;
              objectValue28 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local91 = ref objectValue28;
              object objectValue40 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local92 = ref objectValue40;
              object objectValue41 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local93 = ref objectValue41;
              objectValue24 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local94 = ref objectValue24;
              object objectValue42 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local95 = ref objectValue42;
              // ISSUE: reference to a compiler-generated method
              document14.SaveAs(ref local80, ref local81, ref local82, ref local83, ref local84, ref local85, ref local86, ref local87, ref local88, ref local89, ref local90, ref local91, ref local92, ref local93, ref local94, ref local95);
              // ISSUE: reference to a compiler-generated method
              document5.Activate();
              // ISSUE: reference to a compiler-generated method
              this.MsWordApp.Selection.WholeStory();
              this.MsWordApp.Selection.Font.Name = "Arial";
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document15 = document5;
              object obj9 = (object) (str5 + "ServiceLetters3HandDeliver_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
              ref object local96 = ref obj9;
              objectValue24 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local97 = ref objectValue24;
              object objectValue43 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local98 = ref objectValue43;
              object objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local99 = ref objectValue44;
              object objectValue45 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local100 = ref objectValue45;
              object objectValue46 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local101 = ref objectValue46;
              object objectValue47 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local102 = ref objectValue47;
              object objectValue48 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local103 = ref objectValue48;
              object objectValue49 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local104 = ref objectValue49;
              object objectValue50 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local105 = ref objectValue50;
              object objectValue51 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local106 = ref objectValue51;
              object objectValue52 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local107 = ref objectValue52;
              obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local108 = ref obj3;
              objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local109 = ref objectValue13;
              obj7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local110 = ref obj7;
              obj6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local111 = ref obj6;
              // ISSUE: reference to a compiler-generated method
              document15.SaveAs(ref local96, ref local97, ref local98, ref local99, ref local100, ref local101, ref local102, ref local103, ref local104, ref local105, ref local106, ref local107, ref local108, ref local109, ref local110, ref local111);
              Marshal.ReleaseComObject((object) document2);
              Marshal.ReleaseComObject((object) document6);
              Marshal.ReleaseComObject((object) document7);
              Marshal.ReleaseComObject((object) document8);
              Marshal.ReleaseComObject((object) document4);
              Marshal.ReleaseComObject((object) document9);
              Marshal.ReleaseComObject((object) document10);
              Marshal.ReleaseComObject((object) document11);
              // ISSUE: reference to a compiler-generated method
              this.WordDoc.Activate();
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num3 = (int) App.ShowMessage("Letter Generation Failed : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
            DateTime date = Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now.AddDays(1.0), "dd-MMM-yyyy") + " 00:00:00");
            if (DateAndTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
              date = Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now.AddDays(3.0), "dd-MMM-yyyy") + " 00:00:00");
            }
            else
            {
              DateTime now = DateAndTime.Now;
              if (now.DayOfWeek == DayOfWeek.Saturday)
              {
                now = DateAndTime.Now;
                date = Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) now.AddDays(2.0), "dd-MMM-yyyy") + " 00:00:00");
              }
            }
            Exporting exporting = new Exporting(App.DB.LetterManager.Letter3_TomorrowsVisit(date), "3rd Visits", str5, "", (DataSet) null);
            exporting = (Exporting) null;
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            // ISSUE: reference to a compiler-generated method
            this.MsWordApp.Selection.WholeStory();
            this.MsWordApp.Selection.Font.Name = "Arial";
            this.Finalise(str1, success, true, true, false);
            MessageFilter.Revoke();
            if (success)
              Process.Start(str5);
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.GSRBatch:
          try
          {
            this.LSRErrors.Clear();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            int num1 = (int) folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.Trim().Length == 0)
              break;
            str1 = folderBrowserDialog.SelectedPath + "\\" + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
            List<byte[]> numArrayList = new List<byte[]>();
            DataRow[] dataRowArray = (DataRow[]) ((ArrayList) this.DetailsToPrint)[0];
            int index = 0;
            while (index < dataRowArray.Length)
            {
              DataRow dataRow = dataRowArray[index];
              int engineerVisitId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["EngineerVisitID"]));
              string jobNumber = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["JobNumber"]));
              success = this.PrintGSR(engineerVisitId, numArrayList, jobNumber, false);
              checked { ++index; }
            }
            if (success && numArrayList.Count > 0)
            {
              File.WriteAllBytes(str1, PrintHelper.CombineDocs(numArrayList));
              PrintHelper.RemoveSpacingInDoc(str1);
              if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
                str1 = PrintHelper.LockFile(str1, true);
            }
            if (this.LSRErrors.Count > 0)
            {
              List<string> details = new List<string>();
              try
              {
                foreach (LSRError lsrError in this.LSRErrors)
                  details.Add("Job Number: " + lsrError.JobNumber + " | Visit Date: " + Conversions.ToString(lsrError.VisitDate) + " | Engineer:  " + lsrError.Engineer + " | EngineerVisitID:  " + Conversions.ToString(lsrError.EngineerVisitID));
              }
              finally
              {
                List<LSRError>.Enumerator enumerator4;
                enumerator4.Dispose();
              }
              int num2 = (int) App.ShowMessageWithDetails("Blank LSRs", "The following jobs have blank LSRs!", details);
              break;
            }
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            if (success)
              Process.Start(str1);
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.ServiceLetterReport:
          string str6 = "C:\\";
          try
          {
            this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
            this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            this.MsWordApp.Visible = false;
            DataTable dataTable = (DataTable) ((ArrayList) this.DetailsToPrint)[0];
            str6 = App.TheSystem.Configuration.DocumentsLocation + "ServiceLetters\\ServiceLetters" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + "\\";
            if (!Directory.Exists(str6))
              Directory.CreateDirectory(str6);
            string str2 = Conversions.ToString(dataTable.Rows[0]["Name"]);
            str6 + str2 + "ServiceLetters_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc";
            DataRow[] dataRowArray1 = dataTable.Select("LetterType ='Letter 1'");
            object obj1;
            object objectValue1;
            object objectValue2;
            object obj2;
            object objectValue3;
            object objectValue4;
            object objectValue5;
            object obj3;
            object objectValue6;
            if (dataRowArray1.Length > 0)
            {
              DataRow dr = dataRowArray1[0];
              switch (CustomerID)
              {
                case 2846:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents1 = this.MsWordApp.Documents;
                  object obj4 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection.dot");
                  ref object local1 = ref obj4;
                  object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local2 = ref objectValue7;
                  object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local3 = ref objectValue8;
                  object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local4 = ref objectValue9;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents1.Add(ref local1, ref local2, ref local3, ref local4);
                  break;
                case 4703:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents2 = this.MsWordApp.Documents;
                  object obj5 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\SuffolkAnnualSafetyInspection.dot");
                  ref object local5 = ref obj5;
                  object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local6 = ref objectValue10;
                  object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local7 = ref objectValue11;
                  object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local8 = ref objectValue12;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents2.Add(ref local5, ref local6, ref local7, ref local8);
                  break;
                case 5155:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents3 = this.MsWordApp.Documents;
                  object obj6 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\WDCAnnualSafetyInspection.dot");
                  ref object local9 = ref obj6;
                  object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local10 = ref objectValue13;
                  object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local11 = ref objectValue14;
                  object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local12 = ref objectValue15;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents3.Add(ref local9, ref local10, ref local11, ref local12);
                  break;
                case 5385:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents4 = this.MsWordApp.Documents;
                  object obj7 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\KierAnnualSafetyInspection.dot");
                  ref object local13 = ref obj7;
                  object objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local14 = ref objectValue16;
                  object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local15 = ref objectValue17;
                  object objectValue18 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local16 = ref objectValue18;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents4.Add(ref local13, ref local14, ref local15, ref local16);
                  break;
                case 5545:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents5 = this.MsWordApp.Documents;
                  object obj8 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\CHS_AnnualSafetyInspection.dot");
                  ref object local17 = ref obj8;
                  object objectValue19 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local18 = ref objectValue19;
                  object objectValue20 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local19 = ref objectValue20;
                  object objectValue21 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local20 = ref objectValue21;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents5.Add(ref local17, ref local18, ref local19, ref local20);
                  break;
                case 5853:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents6 = this.MsWordApp.Documents;
                  object obj9 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\HastoeAnnualSafetyInspection.dot");
                  ref object local21 = ref obj9;
                  object objectValue22 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local22 = ref objectValue22;
                  object objectValue23 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local23 = ref objectValue23;
                  object objectValue24 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local24 = ref objectValue24;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents6.Add(ref local21, ref local22, ref local23, ref local24);
                  break;
                case 5872:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents7 = this.MsWordApp.Documents;
                  object obj10 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\VHTAnnualSafetyInspection.dot");
                  ref object local25 = ref obj10;
                  object objectValue25 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local26 = ref objectValue25;
                  object objectValue26 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local27 = ref objectValue26;
                  object objectValue27 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local28 = ref objectValue27;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents7.Add(ref local25, ref local26, ref local27, ref local28);
                  break;
                case 6341:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents8 = this.MsWordApp.Documents;
                  object obj11 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\HastoeAnnualSafetyInspectionGBS.dot");
                  ref object local29 = ref obj11;
                  object objectValue28 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local30 = ref objectValue28;
                  object objectValue29 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local31 = ref objectValue29;
                  object objectValue30 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local32 = ref objectValue30;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents8.Add(ref local29, ref local30, ref local31, ref local32);
                  break;
                case 6526:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents9 = this.MsWordApp.Documents;
                  object obj12 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\TENAnnualSafetyInspection1.dot");
                  ref object local33 = ref obj12;
                  object objectValue31 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local34 = ref objectValue31;
                  object objectValue32 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local35 = ref objectValue32;
                  object objectValue33 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local36 = ref objectValue33;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents9.Add(ref local33, ref local34, ref local35, ref local36);
                  break;
                case 6561:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents10 = this.MsWordApp.Documents;
                  object obj13 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\SAFAnnualSafetyInspection1.dot");
                  ref object local37 = ref obj13;
                  object objectValue34 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local38 = ref objectValue34;
                  object objectValue35 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local39 = ref objectValue35;
                  object objectValue36 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local40 = ref objectValue36;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents10.Add(ref local37, ref local38, ref local39, ref local40);
                  break;
              }
              if (this.GenerateServiceLetter(dr, Conversions.ToString(dr["AMPM"]), Conversions.ToDate(dr["DueDate"]), Conversions.ToString(dr["JobNumber"]), Conversions.ToDate(dr["DateCreated"])))
              {
                // ISSUE: reference to a compiler-generated method
                this.MsWordApp.Selection.WholeStory();
                this.MsWordApp.Selection.Font.Name = "Arial";
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                obj1 = (object) (str6 + "ServiceLetter1_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
                ref object local41 = ref obj1;
                objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local42 = ref objectValue1;
                objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local43 = ref objectValue2;
                obj2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local44 = ref obj2;
                objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local45 = ref objectValue3;
                object objectValue37 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local46 = ref objectValue37;
                object objectValue38 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local47 = ref objectValue38;
                object objectValue39 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local48 = ref objectValue39;
                objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local49 = ref objectValue4;
                objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local50 = ref objectValue5;
                object objectValue40 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local51 = ref objectValue40;
                object objectValue41 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local52 = ref objectValue41;
                obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local53 = ref obj3;
                objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local54 = ref objectValue6;
                object objectValue42 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local55 = ref objectValue42;
                object objectValue43 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local56 = ref objectValue43;
                // ISSUE: reference to a compiler-generated method
                wordDoc.SaveAs(ref local41, ref local42, ref local43, ref local44, ref local45, ref local46, ref local47, ref local48, ref local49, ref local50, ref local51, ref local52, ref local53, ref local54, ref local55, ref local56);
              }
            }
            DataRow[] dataRowArray2 = dataTable.Select("LetterType ='Letter 2'");
            object obj14;
            object objectValue44;
            object objectValue45;
            object objectValue46;
            object objectValue47;
            if (dataRowArray2.Length > 0)
            {
              DataRow dr = dataRowArray2[0];
              switch (CustomerID)
              {
                case 2846:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents1 = this.MsWordApp.Documents;
                  object obj4 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection2.dot");
                  ref object local1 = ref obj4;
                  object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local2 = ref objectValue7;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local3 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local4 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents1.Add(ref local1, ref local2, ref local3, ref local4);
                  break;
                case 4703:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents2 = this.MsWordApp.Documents;
                  object obj5 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\SuffolkAnnualSafetyInspection2.dot");
                  ref object local5 = ref obj5;
                  object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local6 = ref objectValue8;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local7 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local8 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents2.Add(ref local5, ref local6, ref local7, ref local8);
                  break;
                case 5155:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents3 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\WDCAnnualSafetyInspection2.dot");
                  ref object local9 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local10 = ref objectValue6;
                  object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local11 = ref objectValue9;
                  object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local12 = ref objectValue10;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents3.Add(ref local9, ref local10, ref local11, ref local12);
                  break;
                case 5385:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents4 = this.MsWordApp.Documents;
                  object obj6 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\KierAnnualSafetyInspection2.dot");
                  ref object local13 = ref obj6;
                  object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local14 = ref objectValue11;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local15 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local16 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents4.Add(ref local13, ref local14, ref local15, ref local16);
                  break;
                case 5545:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents5 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\CHS_AnnualSafetyInspection2.dot");
                  ref object local17 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local18 = ref objectValue6;
                  object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local19 = ref objectValue12;
                  object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local20 = ref objectValue13;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents5.Add(ref local17, ref local18, ref local19, ref local20);
                  break;
                case 5853:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents6 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\HastoeAnnualSafetyInspection2.dot");
                  ref object local21 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local22 = ref objectValue6;
                  object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local23 = ref objectValue14;
                  object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local24 = ref objectValue15;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents6.Add(ref local21, ref local22, ref local23, ref local24);
                  break;
                case 5872:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents7 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\VHTAnnualSafetyInspection2.dot");
                  ref object local25 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local26 = ref objectValue6;
                  object objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local27 = ref objectValue16;
                  object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local28 = ref objectValue17;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents7.Add(ref local25, ref local26, ref local27, ref local28);
                  break;
                case 6341:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents8 = this.MsWordApp.Documents;
                  object obj7 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\HastoeAnnualSafetyInspection2GBS.dot");
                  ref object local29 = ref obj7;
                  object objectValue18 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local30 = ref objectValue18;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local31 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local32 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents8.Add(ref local29, ref local30, ref local31, ref local32);
                  break;
                case 6526:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents9 = this.MsWordApp.Documents;
                  object obj8 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\TENAnnualSafetyInspection2.dot");
                  ref object local33 = ref obj8;
                  object objectValue19 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local34 = ref objectValue19;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local35 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local36 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents9.Add(ref local33, ref local34, ref local35, ref local36);
                  break;
                case 6561:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents10 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\SAFAnnualSafetyInspection2.dot");
                  ref object local37 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local38 = ref objectValue6;
                  object objectValue20 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local39 = ref objectValue20;
                  object objectValue21 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local40 = ref objectValue21;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents10.Add(ref local37, ref local38, ref local39, ref local40);
                  break;
              }
              if (this.GenerateServiceLetter(dr, Conversions.ToString(dr["AMPM"]), Conversions.ToDate(dr["DueDate"]), Conversions.ToString(dr["JobNumber"]), Conversions.ToDate(dr["DateCreated"])))
              {
                // ISSUE: reference to a compiler-generated method
                this.MsWordApp.Selection.WholeStory();
                this.MsWordApp.Selection.Font.Name = "Arial";
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                obj14 = (object) (str6 + "ServiceLetter2_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
                ref object local41 = ref obj14;
                objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local42 = ref objectValue44;
                objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local43 = ref objectValue6;
                obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local44 = ref obj3;
                objectValue45 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local45 = ref objectValue45;
                object objectValue22 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local46 = ref objectValue22;
                objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local47 = ref objectValue5;
                objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local48 = ref objectValue4;
                objectValue46 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local49 = ref objectValue46;
                objectValue47 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local50 = ref objectValue47;
                object objectValue23 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local51 = ref objectValue23;
                objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local52 = ref objectValue3;
                obj2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local53 = ref obj2;
                objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local54 = ref objectValue2;
                objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local55 = ref objectValue1;
                obj1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local56 = ref obj1;
                // ISSUE: reference to a compiler-generated method
                wordDoc.SaveAs(ref local41, ref local42, ref local43, ref local44, ref local45, ref local46, ref local47, ref local48, ref local49, ref local50, ref local51, ref local52, ref local53, ref local54, ref local55, ref local56);
              }
              if (CustomerID == 2846)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Documents documents11 = this.MsWordApp.Documents;
                obj1 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection2HandLetter.dot");
                ref object local41 = ref obj1;
                objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local42 = ref objectValue1;
                objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local43 = ref objectValue2;
                obj2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local44 = ref obj2;
                // ISSUE: reference to a compiler-generated method
                this.WordDoc = documents11.Add(ref local41, ref local42, ref local43, ref local44);
              }
              if (this.GenerateServiceLetter(dr, Conversions.ToString(dr["AMPM"]), Conversions.ToDate(dr["DueDate"]), Conversions.ToString(dr["JobNumber"]), Conversions.ToDate(dr["DateCreated"])))
              {
                // ISSUE: reference to a compiler-generated method
                this.MsWordApp.Selection.WholeStory();
                this.MsWordApp.Selection.Font.Name = "Arial";
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                obj2 = (object) (str6 + "ServiceLetter2Hand_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
                ref object local41 = ref obj2;
                objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local42 = ref objectValue2;
                objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local43 = ref objectValue1;
                obj1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local44 = ref obj1;
                objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local45 = ref objectValue3;
                object objectValue22 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local46 = ref objectValue22;
                objectValue47 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local47 = ref objectValue47;
                objectValue46 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local48 = ref objectValue46;
                objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local49 = ref objectValue4;
                objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local50 = ref objectValue5;
                object objectValue23 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local51 = ref objectValue23;
                objectValue45 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local52 = ref objectValue45;
                obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local53 = ref obj3;
                objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local54 = ref objectValue6;
                objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local55 = ref objectValue44;
                obj14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local56 = ref obj14;
                // ISSUE: reference to a compiler-generated method
                wordDoc.SaveAs(ref local41, ref local42, ref local43, ref local44, ref local45, ref local46, ref local47, ref local48, ref local49, ref local50, ref local51, ref local52, ref local53, ref local54, ref local55, ref local56);
              }
            }
            DataRow[] dataRowArray3 = dataTable.Select("LetterType ='Letter 3'");
            if (dataRowArray3.Length > 0)
            {
              DataRow dr = dataRowArray3[0];
              switch (CustomerID)
              {
                case 2846:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents1 = this.MsWordApp.Documents;
                  obj14 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection3.dot");
                  ref object local1 = ref obj14;
                  objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local2 = ref objectValue44;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local3 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local4 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents1.Add(ref local1, ref local2, ref local3, ref local4);
                  break;
                case 5155:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents2 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\WDCAnnualSafetyInspection3.dot");
                  ref object local5 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local6 = ref objectValue6;
                  objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local7 = ref objectValue44;
                  obj14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local8 = ref obj14;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents2.Add(ref local5, ref local6, ref local7, ref local8);
                  break;
                case 5385:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents3 = this.MsWordApp.Documents;
                  obj14 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\KierAnnualSafetyInspection3.dot");
                  ref object local9 = ref obj14;
                  objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local10 = ref objectValue44;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local11 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local12 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents3.Add(ref local9, ref local10, ref local11, ref local12);
                  break;
                case 5853:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents4 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\HastoeAnnualSafetyInspection3.dot");
                  ref object local13 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local14 = ref objectValue6;
                  objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local15 = ref objectValue44;
                  obj14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local16 = ref obj14;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents4.Add(ref local13, ref local14, ref local15, ref local16);
                  break;
                case 5872:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents5 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\VHTAnnualSafetyInspection3.dot");
                  ref object local17 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local18 = ref objectValue6;
                  objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local19 = ref objectValue44;
                  obj14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local20 = ref obj14;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents5.Add(ref local17, ref local18, ref local19, ref local20);
                  break;
                case 6341:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents6 = this.MsWordApp.Documents;
                  obj14 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\HastoeAnnualSafetyInspection3.dot");
                  ref object local21 = ref obj14;
                  objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local22 = ref objectValue44;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local23 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local24 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents6.Add(ref local21, ref local22, ref local23, ref local24);
                  break;
                case 6526:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents7 = this.MsWordApp.Documents;
                  obj14 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\TENAnnualSafetyInspection3.dot");
                  ref object local25 = ref obj14;
                  objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local26 = ref objectValue44;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local27 = ref objectValue6;
                  obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local28 = ref obj3;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents7.Add(ref local25, ref local26, ref local27, ref local28);
                  break;
                case 6561:
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents8 = this.MsWordApp.Documents;
                  obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\SAFAnnualSafetyInspection3.dot");
                  ref object local29 = ref obj3;
                  objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local30 = ref objectValue6;
                  objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local31 = ref objectValue44;
                  obj14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local32 = ref obj14;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents8.Add(ref local29, ref local30, ref local31, ref local32);
                  break;
              }
              if (this.GenerateServiceLetter(dr, Conversions.ToString(dr["AMPM"]), Conversions.ToDate(dr["DueDate"]), Conversions.ToString(dr["JobNumber"]), Conversions.ToDate(dr["DateCreated"])))
              {
                // ISSUE: reference to a compiler-generated method
                this.MsWordApp.Selection.WholeStory();
                this.MsWordApp.Selection.Font.Name = "Arial";
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                obj14 = (object) (str6 + "ServiceLetter3_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
                ref object local33 = ref obj14;
                objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local34 = ref objectValue44;
                objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local35 = ref objectValue6;
                obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local36 = ref obj3;
                objectValue45 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local37 = ref objectValue45;
                object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local38 = ref objectValue7;
                objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local39 = ref objectValue5;
                objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local40 = ref objectValue4;
                objectValue46 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local41 = ref objectValue46;
                objectValue47 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local42 = ref objectValue47;
                object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local43 = ref objectValue8;
                objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local44 = ref objectValue3;
                obj1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local45 = ref obj1;
                objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local46 = ref objectValue1;
                objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local47 = ref objectValue2;
                obj2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local48 = ref obj2;
                // ISSUE: reference to a compiler-generated method
                wordDoc.SaveAs(ref local33, ref local34, ref local35, ref local36, ref local37, ref local38, ref local39, ref local40, ref local41, ref local42, ref local43, ref local44, ref local45, ref local46, ref local47, ref local48);
              }
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["CommercialDistrict"], (object) true, false))
              {
                if (CustomerID == 2846)
                {
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Documents documents9 = this.MsWordApp.Documents;
                  obj2 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection3HandLetterDistrict.dot");
                  ref object local33 = ref obj2;
                  objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local34 = ref objectValue2;
                  objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local35 = ref objectValue1;
                  obj1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                  ref object local36 = ref obj1;
                  // ISSUE: reference to a compiler-generated method
                  this.WordDoc = documents9.Add(ref local33, ref local34, ref local35, ref local36);
                }
              }
              else if (CustomerID == 2846)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Documents documents9 = this.MsWordApp.Documents;
                obj1 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\NCCAnnualSafetyInspection3HandLetter.dot");
                ref object local33 = ref obj1;
                objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local34 = ref objectValue1;
                objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local35 = ref objectValue2;
                obj2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local36 = ref obj2;
                // ISSUE: reference to a compiler-generated method
                this.WordDoc = documents9.Add(ref local33, ref local34, ref local35, ref local36);
              }
              if (this.GenerateServiceLetter(dr, Conversions.ToString(dr["AMPM"]), Conversions.ToDate(dr["DueDate"]), Conversions.ToString(dr["JobNumber"]), Conversions.ToDate(dr["DateCreated"])))
              {
                // ISSUE: reference to a compiler-generated method
                this.MsWordApp.Selection.WholeStory();
                this.MsWordApp.Selection.Font.Name = "Arial";
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                obj2 = (object) (str6 + "ServiceLetter3Hand_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".doc");
                ref object local33 = ref obj2;
                objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local34 = ref objectValue2;
                objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local35 = ref objectValue1;
                obj1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local36 = ref obj1;
                objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local37 = ref objectValue3;
                object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local38 = ref objectValue7;
                objectValue47 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local39 = ref objectValue47;
                objectValue46 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local40 = ref objectValue46;
                objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local41 = ref objectValue4;
                objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local42 = ref objectValue5;
                object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local43 = ref objectValue8;
                objectValue45 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local44 = ref objectValue45;
                obj3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local45 = ref obj3;
                objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local46 = ref objectValue6;
                objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local47 = ref objectValue44;
                obj14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local48 = ref obj14;
                // ISSUE: reference to a compiler-generated method
                wordDoc.SaveAs(ref local33, ref local34, ref local35, ref local36, ref local37, ref local38, ref local39, ref local40, ref local41, ref local42, ref local43, ref local44, ref local45, ref local46, ref local47, ref local48);
              }
            }
            StreamWriter text = File.CreateText(str6 + "Summary.txt");
            text.WriteLine("Letter Type\t\tLetter Created\t\t\tDue Date\t\tAM/PM\t\tJob Number");
            IEnumerator enumerator4;
            try
            {
              enumerator4 = dataTable.Rows.GetEnumerator();
              while (enumerator4.MoveNext())
              {
                DataRow current = (DataRow) enumerator4.Current;
                text.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["LetterType"], (object) "\t"), (object) "\t"), current["DateCreated"]), (object) "\t"), (object) "\t"), current["DueDate"]), (object) "\t"), (object) "\t"), current["AMPM"]), (object) "\t"), (object) "\t"), current["JobNumber"]));
              }
            }
            finally
            {
              if (enumerator4 is IDisposable)
                (enumerator4 as IDisposable).Dispose();
            }
            text.Close();
            success = true;
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            this.DestroyWord(true);
            if (success)
              Process.Start(str6);
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.AlphaPartCredit:
          try
          {
            ArrayList arrayList5 = new ArrayList();
            ArrayList detailsToPrint3 = (ArrayList) this.DetailsToPrint;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            int num1 = (int) folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.Trim().Length == 0)
              break;
            str1 = folderBrowserDialog.SelectedPath + "\\" + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".doc";
            this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
            this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            this.MsWordApp.Visible = false;
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents = this.MsWordApp.Documents;
            object obj1 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\AlphaReturnsForm.dot");
            ref object local1 = ref obj1;
            object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local2 = ref objectValue1;
            object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local3 = ref objectValue2;
            object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local4 = ref objectValue3;
            // ISSUE: reference to a compiler-generated method
            this.WordDoc = documents.Add(ref local1, ref local2, ref local3, ref local4);
            // ISSUE: reference to a compiler-generated method
            this.MsWordApp.Selection.WholeStory();
            // ISSUE: reference to a compiler-generated method
            this.MsWordApp.Selection.Copy();
            DataTable dataTable1 = new DataTable();
            DataTable dataTable2 = new DataTable();
            int num2 = checked (detailsToPrint3.Count - 1);
            int index = 0;
            while (index <= num2)
            {
              if (index == 0)
              {
                dataTable1 = (DataTable) detailsToPrint3[0];
              }
              else
              {
                DataTable dataTable3 = (DataTable) detailsToPrint3[index];
                dataTable1.ImportRow(dataTable3.Rows[0]);
              }
              checked { ++index; }
            }
            this.DetailsToPrint = (object) dataTable1;
            success = this.AlphaCredit();
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
            object obj2 = (object) str1;
            ref object local5 = ref obj2;
            object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local6 = ref objectValue4;
            objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local7 = ref objectValue1;
            object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local8 = ref objectValue5;
            object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local9 = ref objectValue6;
            object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local10 = ref objectValue7;
            object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local11 = ref objectValue8;
            object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local12 = ref objectValue9;
            object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local13 = ref objectValue10;
            object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local14 = ref objectValue11;
            object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local15 = ref objectValue12;
            object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local16 = ref objectValue13;
            object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local17 = ref objectValue14;
            object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local18 = ref objectValue15;
            object objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local19 = ref objectValue16;
            object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local20 = ref objectValue17;
            // ISSUE: reference to a compiler-generated method
            wordDoc.SaveAs(ref local5, ref local6, ref local7, ref local8, ref local9, ref local10, ref local11, ref local12, ref local13, ref local14, ref local15, ref local16, ref local17, ref local18, ref local19, ref local20);
            Marshal.ReleaseComObject((object) this.WordDoc);
            this.WordDoc = (Microsoft.Office.Interop.Word.Document) null;
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            this.Finalise(str1, success, true, true, false);
            if (success)
            {
              Cursor.Current = Cursors.WaitCursor;
              Process.Start(str1);
              Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.SalesCredit:
          try
          {
            Cursor.Current = Cursors.WaitCursor;
            str1 = App.TheSystem.Configuration.DocumentsLocation + "\\Sales Credits\\" + this.DocumentName + "_" + ((DataTable) this.DetailsToPrint).Rows[0]["InvoiceNumber"].ToString() + ".docx";
            Directory.CreateDirectory(Path.GetDirectoryName(str1));
            str1 = this.FileCheck(str1);
            success = this.GenerateCredit((DataTable) this.DetailsToPrint, str1);
            PrintHelper.RemoveSpacingInDoc(str1);
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            this.Finalise(str1, success, true, true, false);
            if (success)
            {
              Cursor.Current = Cursors.WaitCursor;
              Process.Start(str1);
              Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.ServiceLettersMK2:
          string str7 = "C:\\";
          try
          {
            str7 = App.TheSystem.Configuration.DocumentsLocation + "ServiceLetters\\ServiceLetters" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + "\\";
            Directory.CreateDirectory(str7);
            DataTable source1 = (DataTable) NewLateBinding.LateGet(((ArrayList) this.DetailsToPrint)[0], (System.Type) null, "table", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
            StreamWriter text1 = File.CreateText(str7 + "SolidFuels.txt");
            text1.WriteLine("Solid Fuels Properties : ");
            StreamWriter text2 = File.CreateText(str7 + "WarningsAdvice.txt");
            text2.WriteLine("Properties with Warnings/Advice : ");
            StreamWriter text3 = File.CreateText(str7 + "Voids.txt");
            text3.WriteLine("Voids Properties : ");
            StreamWriter text4 = File.CreateText(str7 + "NonGasSiteFuels.txt");
            text4.WriteLine("Non Gas Site Fuel Properties : ");
            try
            {
              try
              {
                bool justLetters = false;
                if (source1.Columns.Contains("JobNumber"))
                {
                  justLetters = true;
                }
                else
                {
                  source1.Columns.Add("JobNumber");
                  source1.Columns.Add("JobID");
                }
                if (source1.Select("Type = 'Letter 1' AND SendLetterTick = 1").Length > 0)
                {
                  str1 = str7 + "ServiceLetters1_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".docx";
                  List<byte[]> numArrayList = new List<byte[]>();
                  EnumerableRowCollection<DataRow> source2 = source1.AsEnumerable();
                  Func<DataRow, bool> predicate;
                  // ISSUE: reference to a compiler-generated field
                  if (Printing._Closure\u0024__.\u0024I49\u002D0 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    predicate = Printing._Closure\u0024__.\u0024I49\u002D0;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    Printing._Closure\u0024__.\u0024I49\u002D0 = predicate = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "Letter 1", false) == 0 & row.Field<bool>("SendLetterTick"));
                  }
                  EnumerableRowCollection<DataRow> source3 = source2.Where<DataRow>(predicate);
                  Func<DataRow, DataRow> selector;
                  // ISSUE: reference to a compiler-generated field
                  if (Printing._Closure\u0024__.\u0024I49\u002D1 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    selector = Printing._Closure\u0024__.\u0024I49\u002D1;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    Printing._Closure\u0024__.\u0024I49\u002D1 = selector = (Func<DataRow, DataRow>) (row => row);
                  }
                  DataRow[] array = source3.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
                  int index = 0;
                  while (index < array.Length)
                  {
                    DataRow dataRow = array[index];
                    if (DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["BookedDateTime"])), DateTime.MinValue) != 0)
                    {
                      Conversions.ToDate(dataRow["BookedDateTime"]);
                      DateTime date = Conversions.ToDate(dataRow["BookedDateTime"]);
                      string AMPM = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["AMPM"]));
                      int fuelId = 0;
                      if (dataRow.Table.Columns.Contains("FuelID") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["FuelID"])))
                        fuelId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["FuelID"]));
                      Job job = new Job();
                      if (!justLetters)
                      {
                        job = App.DB.Job.GenerateServiceLetterJob(dataRow, CustomerID, AMPM, fuelId);
                      }
                      else
                      {
                        job.SetJobID = RuntimeHelpers.GetObjectValue(dataRow["JobID"]);
                        job.SetJobNumber = RuntimeHelpers.GetObjectValue(dataRow["JobNumber"]);
                      }
                      if (!dataRow["SiteFuel"].ToString().StartsWith("&"))
                      {
                        success = this.GenerateServiceLetterMK2(dataRow, AMPM, date, job.JobNumber, DateAndTime.Now, numArrayList, job.JobID, justLetters);
                        if (success)
                        {
                          if (!justLetters)
                            App.DB.LetterManager.LetterGeneratedMK2(Conversions.ToInteger(dataRow["SiteID"]), Conversions.ToString(dataRow["Type"]), Conversions.ToDate(dataRow["LastServiceDate"]), job.JobID, str7, fuelId);
                          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["SolidFuel"], (object) true, false))
                            text1.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))));
                          if (dataRow["Notes"].ToString().Contains("T1WARN") | dataRow["Notes"].ToString().Contains("T1ADVI") | dataRow["Notes"].ToString().Contains("T2WARN") | dataRow["Notes"].ToString().Contains("T2ADVI"))
                          {
                            text2.WriteLine(" ");
                            text2.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))), (object) ", "), (object) " NOTES : "), dataRow["Notes"]));
                          }
                          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["PropertyVoid"])))
                            text3.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))));
                          if (dataRow["SiteFuel"] != DBNull.Value && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRow["SiteFuel"], (object) "Gas", false))))
                            text4.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))), (object) ", "), dataRow["SiteFuel"]));
                        }
                      }
                    }
                    checked { ++index; }
                  }
                  if (numArrayList.Count > 0)
                    File.WriteAllBytes(str1, PrintHelper.CombineDocs(numArrayList));
                }
                if (source1.Select("Type = 'Letter 2' AND SendLetterTick = 1").Length > 0)
                {
                  str1 = str7 + "ServiceLetters2_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmmss") + ".docx";
                  List<byte[]> numArrayList = new List<byte[]>();
                  EnumerableRowCollection<DataRow> source2 = source1.AsEnumerable();
                  Func<DataRow, bool> predicate;
                  // ISSUE: reference to a compiler-generated field
                  if (Printing._Closure\u0024__.\u0024I49\u002D2 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    predicate = Printing._Closure\u0024__.\u0024I49\u002D2;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    Printing._Closure\u0024__.\u0024I49\u002D2 = predicate = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "Letter 2", false) == 0 & row.Field<bool>("SendLetterTick"));
                  }
                  EnumerableRowCollection<DataRow> source3 = source2.Where<DataRow>(predicate);
                  Func<DataRow, DataRow> selector;
                  // ISSUE: reference to a compiler-generated field
                  if (Printing._Closure\u0024__.\u0024I49\u002D3 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    selector = Printing._Closure\u0024__.\u0024I49\u002D3;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    Printing._Closure\u0024__.\u0024I49\u002D3 = selector = (Func<DataRow, DataRow>) (row => row);
                  }
                  DataRow[] array = source3.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
                  int index = 0;
                  while (index < array.Length)
                  {
                    DataRow dataRow = array[index];
                    if (DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["BookedDateTime"])), DateTime.MinValue) != 0)
                    {
                      Conversions.ToDate(dataRow["BookedDateTime"]);
                      DateTime date = Conversions.ToDate(dataRow["BookedDateTime"]);
                      string AMPM = Conversions.ToString(dataRow["AMPM"]);
                      int fuelId = 0;
                      if (dataRow.Table.Columns.Contains("FuelID") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["FuelID"])))
                        fuelId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["FuelID"]));
                      Job job = new Job();
                      if (!justLetters)
                      {
                        job = App.DB.Job.GenerateServiceLetterJob(dataRow, CustomerID, AMPM, fuelId);
                        dataRow["JobNumber"] = (object) job.JobNumber;
                        dataRow["JobID"] = (object) job.JobID;
                      }
                      else
                      {
                        job.SetJobID = RuntimeHelpers.GetObjectValue(dataRow["JobID"]);
                        job.SetJobNumber = RuntimeHelpers.GetObjectValue(dataRow["JobNumber"]);
                      }
                      if (!dataRow["SiteFuel"].ToString().StartsWith("&"))
                      {
                        success = this.GenerateServiceLetterMK2(dataRow, AMPM, date, job.JobNumber, DateAndTime.Now, numArrayList, job.JobID, justLetters);
                        if (success)
                        {
                          if (!justLetters)
                            App.DB.LetterManager.LetterGeneratedMK2(Conversions.ToInteger(dataRow["SiteID"]), Conversions.ToString(dataRow["Type"]), Conversions.ToDate(dataRow["LastServiceDate"]), job.JobID, str7, fuelId);
                          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["SolidFuel"], (object) true, false))
                            text1.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))));
                          if (dataRow["Notes"].ToString().Contains("T1WARN") | dataRow["Notes"].ToString().Contains("T1ADVI") | dataRow["Notes"].ToString().Contains("T2WARN") | dataRow["Notes"].ToString().Contains("T2ADVI"))
                          {
                            text2.WriteLine(" ");
                            text2.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))), (object) ", "), (object) " NOTES : "), dataRow["Notes"]));
                          }
                          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["PropertyVoid"])))
                            text3.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))));
                          if (dataRow["SiteFuel"] != DBNull.Value && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRow["SiteFuel"], (object) "Gas", false))))
                            text4.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))), (object) ", "), dataRow["SiteFuel"]));
                        }
                      }
                    }
                    checked { ++index; }
                  }
                  if (numArrayList.Count > 0)
                    File.WriteAllBytes(str1, PrintHelper.CombineDocs(numArrayList));
                }
                if (source1.Select("Type = 'Letter 3' AND SendLetterTick = 1").Length > 0)
                {
                  str1 = str7 + "ServiceLetters3_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMyyHHmm") + ".docx";
                  List<byte[]> numArrayList = new List<byte[]>();
                  EnumerableRowCollection<DataRow> source2 = source1.AsEnumerable();
                  Func<DataRow, bool> predicate;
                  // ISSUE: reference to a compiler-generated field
                  if (Printing._Closure\u0024__.\u0024I49\u002D4 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    predicate = Printing._Closure\u0024__.\u0024I49\u002D4;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    Printing._Closure\u0024__.\u0024I49\u002D4 = predicate = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "Letter 3", false) == 0 & row.Field<bool>("SendLetterTick"));
                  }
                  EnumerableRowCollection<DataRow> source3 = source2.Where<DataRow>(predicate);
                  Func<DataRow, DataRow> selector;
                  // ISSUE: reference to a compiler-generated field
                  if (Printing._Closure\u0024__.\u0024I49\u002D5 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    selector = Printing._Closure\u0024__.\u0024I49\u002D5;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    Printing._Closure\u0024__.\u0024I49\u002D5 = selector = (Func<DataRow, DataRow>) (row => row);
                  }
                  DataRow[] array = source3.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
                  int index = 0;
                  while (index < array.Length)
                  {
                    DataRow dataRow = array[index];
                    if (DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["BookedDateTime"])), DateTime.MinValue) != 0)
                    {
                      Conversions.ToDate(dataRow["BookedDateTime"]);
                      DateTime VisitDate = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow[nameof (CustomerID)], (object) Enums.Customer.NCC, false) ? Conversions.ToDate(dataRow["BookedDateTime"]) : Conversions.ToDate(dataRow["BookedDateTime"]);
                      int fuelId = 0;
                      if (dataRow.Table.Columns.Contains("FuelID") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["FuelID"])))
                        fuelId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["FuelID"]));
                      string AMPM = Conversions.ToString(dataRow["AMPM"]);
                      Job job = new Job();
                      if (!justLetters)
                      {
                        job = App.DB.Job.GenerateServiceLetterJob(dataRow, CustomerID, AMPM, fuelId);
                        dataRow["JobNumber"] = (object) job.JobNumber;
                        dataRow["JobID"] = (object) job.JobID;
                      }
                      else
                      {
                        job.SetJobID = RuntimeHelpers.GetObjectValue(dataRow["JobID"]);
                        job.SetJobNumber = RuntimeHelpers.GetObjectValue(dataRow["JobNumber"]);
                      }
                      if (!dataRow["SiteFuel"].ToString().StartsWith("&"))
                      {
                        success = this.GenerateServiceLetterMK2(dataRow, AMPM, VisitDate, job.JobNumber, DateAndTime.Now, numArrayList, job.JobID, justLetters);
                        if (success)
                        {
                          if (!justLetters)
                            App.DB.LetterManager.LetterGeneratedMK2(Conversions.ToInteger(dataRow["SiteID"]), Conversions.ToString(dataRow["Type"]), Conversions.ToDate(dataRow["LastServiceDate"]), job.JobID, str7, fuelId);
                          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["SolidFuel"], (object) true, false))
                            text1.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))));
                          if (dataRow["Notes"].ToString().Contains("T1WARN") | dataRow["Notes"].ToString().Contains("T1ADVI") | dataRow["Notes"].ToString().Contains("T2WARN") | dataRow["Notes"].ToString().Contains("T2ADVI"))
                          {
                            text2.WriteLine(" ");
                            text2.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))), (object) " NOTES : "), dataRow["Notes"]));
                          }
                          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["PropertyVoid"])))
                            text3.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))));
                          if (dataRow["SiteFuel"] != DBNull.Value && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRow["SiteFuel"], (object) "Gas", false))))
                            text4.WriteLine(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["Name"], (object) ", "), dataRow["Address1"]), (object) ", "), dataRow["Address2"]), (object) ", "), dataRow["Address3"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"]))), (object) ", "), dataRow["SiteFuel"]));
                        }
                      }
                    }
                    checked { ++index; }
                  }
                  if (numArrayList.Count > 0)
                    File.WriteAllBytes(str1, PrintHelper.CombineDocs(numArrayList));
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ProjectData.ClearProjectError();
              }
              text1.Close();
              text2.Close();
              text3.Close();
              text4.Close();
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num = (int) App.ShowMessage("Letter Generation Failed : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
            DateTime date1 = Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now.AddDays(1.0), "dd-MMM-yyyy") + " 00:00:00");
            if (DateAndTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
              date1 = Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now.AddDays(3.0), "dd-MMM-yyyy") + " 00:00:00");
            }
            else
            {
              DateTime now = DateAndTime.Now;
              if (now.DayOfWeek == DayOfWeek.Saturday)
              {
                now = DateAndTime.Now;
                date1 = Conversions.ToDate(Microsoft.VisualBasic.Strings.Format((object) now.AddDays(2.0), "dd-MMM-yyyy") + " 00:00:00");
              }
            }
            Exporting exporting = new Exporting(App.DB.LetterManager.Letter3_TomorrowsVisit(date1), "3rd Visits", str7, "", (DataSet) null);
            exporting = (Exporting) null;
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            this.Finalise(str1, success, true, true, false);
            MessageFilter.Revoke();
            if (success)
              Process.Start(str7);
            Cursor.Current = Cursors.Default;
          }
        case Enums.SystemDocumentType.ProForma:
          ArrayList arrayList6 = new ArrayList();
          ArrayList detailsToPrint4 = (ArrayList) this.DetailsToPrint;
          Job job1 = new Job();
          ContractOriginalSite cos = new ContractOriginalSite();
          ArrayList arrayList7 = new ArrayList();
          this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
          this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
          this.MsWordApp.Visible = false;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(detailsToPrint4[0], (object) "JOB", false))
          {
            job1 = (Job) detailsToPrint4[1];
            this.details1 = Conversions.ToString(detailsToPrint4[2]);
            this.details2 = Conversions.ToString(detailsToPrint4[3]);
            str1 = App.TheSystem.Configuration.DocumentsLocation + this.DocumentName + "_" + job1.JobNumber + ".doc";
            Cursor.Current = Cursors.WaitCursor;
            if (App.DB.Customer.Customer_Get_ForSiteID(job1.PropertyID).RegionID == 68517)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents = this.MsWordApp.Documents;
              object obj = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\InvoiceGC.dot");
              ref object local1 = ref obj;
              object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local2 = ref objectValue1;
              object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local3 = ref objectValue2;
              object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local4 = ref objectValue3;
              // ISSUE: reference to a compiler-generated method
              this.WordDoc = documents.Add(ref local1, ref local2, ref local3, ref local4);
            }
            else
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents = this.MsWordApp.Documents;
              object obj = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\Invoice.dot");
              ref object local1 = ref obj;
              object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local2 = ref objectValue1;
              object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local3 = ref objectValue2;
              object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local4 = ref objectValue3;
              // ISSUE: reference to a compiler-generated method
              this.WordDoc = documents.Add(ref local1, ref local2, ref local3, ref local4);
            }
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(detailsToPrint4[0], (object) "CONTRACT", false))
          {
            cos = (ContractOriginalSite) detailsToPrint4[1];
            ContractOriginal contractOriginal = App.DB.ContractOriginal.Get(cos.ContractID);
            this.details1 = Conversions.ToString(detailsToPrint4[2]);
            this.details2 = Conversions.ToString(detailsToPrint4[3]);
            str1 = App.TheSystem.Configuration.DocumentsLocation + this.DocumentName + "_" + contractOriginal.ContractReference + ".doc";
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Documents documents = this.MsWordApp.Documents;
            object obj = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\Invoice.dot");
            ref object local1 = ref obj;
            object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local2 = ref objectValue1;
            object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local3 = ref objectValue2;
            object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local4 = ref objectValue3;
            // ISSUE: reference to a compiler-generated method
            this.WordDoc = documents.Add(ref local1, ref local2, ref local3, ref local4);
          }
          try
          {
            success = this.GenerateProforma(job1, cos);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
          }
          finally
          {
            this.Finalise(str1, success, true, false, false);
            arrayList7.Add((object) str1);
            Cursor.Current = Cursors.Default;
          }
          this.Finalise("", false, false, true, false);
          IEnumerator enumerator7;
          try
          {
            enumerator7 = arrayList7.GetEnumerator();
            while (enumerator7.MoveNext())
              Process.Start(Conversions.ToString(enumerator7.Current));
            break;
          }
          finally
          {
            if (enumerator7 is IDisposable)
              (enumerator7 as IDisposable).Dispose();
          }
        case Enums.SystemDocumentType.ProFormaFromVisit:
          ArrayList arrayList8 = new ArrayList();
          ArrayList detailsToPrint5 = (ArrayList) this.DetailsToPrint;
          Job job2 = new Job();
          ArrayList arrayList9 = new ArrayList();
          this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
          this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
          this.MsWordApp.Visible = false;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(detailsToPrint5[0], (object) "JOB", false))
          {
            job2 = (Job) detailsToPrint5[1];
            this.details1 = Conversions.ToString(detailsToPrint5[2]);
            this.details2 = Conversions.ToString(detailsToPrint5[3]);
            str1 = App.TheSystem.Configuration.DocumentsLocation + this.DocumentName + "_" + job2.JobNumber + ".doc";
            if (App.DB.Customer.Customer_Get_ForSiteID(job2.PropertyID).RegionID == 68517)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents = this.MsWordApp.Documents;
              object obj = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\InvoiceGC.dot");
              ref object local1 = ref obj;
              object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local2 = ref objectValue1;
              object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local3 = ref objectValue2;
              object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local4 = ref objectValue3;
              // ISSUE: reference to a compiler-generated method
              this.WordDoc = documents.Add(ref local1, ref local2, ref local3, ref local4);
            }
            else
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Documents documents = this.MsWordApp.Documents;
              object obj = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\Invoice.dot");
              ref object local1 = ref obj;
              object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local2 = ref objectValue1;
              object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local3 = ref objectValue2;
              object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local4 = ref objectValue3;
              // ISSUE: reference to a compiler-generated method
              this.WordDoc = documents.Add(ref local1, ref local2, ref local3, ref local4);
            }
          }
          try
          {
            Cursor.Current = Cursors.WaitCursor;
            success = this.GenerateProformaFromVisit(job2);
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
          }
          finally
          {
            this.Finalise(str1, success, true, false, false);
            arrayList9.Add((object) str1);
            Cursor.Current = Cursors.Default;
          }
          this.Finalise("", false, false, true, false);
          IEnumerator enumerator8;
          try
          {
            enumerator8 = arrayList9.GetEnumerator();
            while (enumerator8.MoveNext())
              Process.Start(Conversions.ToString(enumerator8.Current));
            break;
          }
          finally
          {
            if (enumerator8 is IDisposable)
              (enumerator8 as IDisposable).Dispose();
          }
        case Enums.SystemDocumentType.JobImportLetters:
          try
          {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            int num = (int) folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath.Trim().Length == 0)
              break;
            str1 = folderBrowserDialog.SelectedPath + "\\" + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
            File.Copy(System.Windows.Forms.Application.StartupPath + "\\Templates\\BlankNp.docx", str1);
            DataTable dataTable = (DataTable) NewLateBinding.LateGet(((ArrayList) this.DetailsToPrint)[0], (System.Type) null, "table", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
            bool boolean = Conversions.ToBoolean(((ArrayList) this.DetailsToPrint)[1]);
            WordprocessingDocument batch = WordprocessingDocument.Open(str1, true);
            using (batch)
            {
              DataRow[] dataRowArray1 = dataTable.Select("Letter1 Is Null AND Tick = 1");
              int index1 = 0;
              while (index1 < dataRowArray1.Length)
              {
                DataRow dataRow = dataRowArray1[index1];
                if (!(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["AMPM"])) & boolean))
                {
                  Job job3 = new Job();
                  Job importAdHocVisit = App.DB.Job.CreateJobImportAdHocVisit(dataRow, boolean);
                  if (boolean)
                  {
                    if (importAdHocVisit == null)
                      throw new Exception();
                    success = this.GenerateJobLetter(dataRow, importAdHocVisit, true, batch, (EngineerVisit) null);
                    if (!success)
                      throw new Exception();
                    success = App.DB.JobImports.JobImport_Update_Letter1(dataRow, importAdHocVisit);
                  }
                }
                checked { ++index1; }
              }
              DataRow[] dataRowArray2 = dataTable.Select("Letter1 Is Not Null AND Letter2 Is Null AND Tick = 1");
              int index2 = 0;
              while (index2 < dataRowArray2.Length)
              {
                DataRow dataRow = dataRowArray2[index2];
                if (!(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["AMPM"])) & boolean))
                {
                  Job job3 = new Job();
                  Job importAdHocVisit = App.DB.Job.CreateJobImportAdHocVisit(dataRow, boolean);
                  if (boolean)
                  {
                    if (importAdHocVisit == null)
                      throw new Exception();
                    success = this.GenerateJobLetter(dataRow, importAdHocVisit, false, batch, (EngineerVisit) null);
                    if (!success)
                      throw new Exception();
                    success = App.DB.JobImports.JobImport_Update_Letter2(dataRow, importAdHocVisit);
                  }
                }
                checked { ++index2; }
              }
            }
            string destFileName = App.TheSystem.Configuration.DocumentsLocation + "JobImports\\BatchLetters\\" + this.DocumentName + "_GEN_" + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
            File.Copy(str1, destFileName);
            break;
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Exception exception = ex;
            success = false;
            int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ProjectData.ClearProjectError();
            break;
          }
          finally
          {
            this.Finalise(str1, success, true, true, false);
            if (success)
            {
              Cursor.Current = Cursors.WaitCursor;
              Process.Start(str1);
              Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
          }
      }
    }

    private void Print()
    {
      bool success = false;
      string str1 = "";
      try
      {
        switch (this.PrintType)
        {
          case Enums.SystemDocumentType.ContractOption1:
          case Enums.SystemDocumentType.GSR:
          case Enums.SystemDocumentType.SVR:
          case Enums.SystemDocumentType.SiteLetter:
          case Enums.SystemDocumentType.ServiceLetters:
          case Enums.SystemDocumentType.SalesCredit:
          case Enums.SystemDocumentType.ComGSR:
          case Enums.SystemDocumentType.DomGSR:
          case Enums.SystemDocumentType.ComCat:
          case Enums.SystemDocumentType.SaffUnv:
          case Enums.SystemDocumentType.PropMaint:
          case Enums.SystemDocumentType.ASHP:
          case Enums.SystemDocumentType.Analyser:
            Cursor.Current = Cursors.WaitCursor;
            switch (this.PrintType)
            {
              case Enums.SystemDocumentType.ContractOption1:
                success = this.GenerateContractLetter(((DataTable) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null)).Rows[0], (WordprocessingDocument) null);
                break;
              case Enums.SystemDocumentType.GSR:
              case Enums.SystemDocumentType.ComGSR:
              case Enums.SystemDocumentType.DomGSR:
              case Enums.SystemDocumentType.ComCat:
              case Enums.SystemDocumentType.SaffUnv:
              case Enums.SystemDocumentType.PropMaint:
              case Enums.SystemDocumentType.ASHP:
                object obj1;
                if ((object) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null).GetType() != (object) typeof (EngineerVisit))
                  obj1 = NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                  {
                    (object) 0
                  }, (string[]) null);
                else
                  obj1 = NewLateBinding.LateGet(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                  {
                    (object) 0
                  }, (string[]) null), (System.Type) null, "EngineerVisitID", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
                int integer1 = Conversions.ToInteger(obj1);
                string empty1 = string.Empty;
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                int num1 = (int) folderBrowserDialog1.ShowDialog();
                if (folderBrowserDialog1.SelectedPath.Trim().Length == 0)
                  break;
                string str2 = folderBrowserDialog1.SelectedPath + "\\" + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".docx";
                List<byte[]> numArrayList = new List<byte[]>();
                success = this.PrintGSR(integer1, numArrayList, "", false);
                if (success && numArrayList.Count > 0)
                {
                  File.WriteAllBytes(str2, PrintHelper.CombineDocs(numArrayList));
                  PrintHelper.RemoveSpacingInDoc(str2);
                  if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
                    str2 = PrintHelper.LockFile(str2, true);
                  Process.Start(str2);
                }
                if (this.PrintType == Enums.SystemDocumentType.GSR)
                {
                  EngineerVisitAdditional forEngineerVisit = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(integer1, 69995);
                  if (forEngineerVisit != null)
                    this.ElecCertPDF((EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                    {
                      (object) 0
                    }, (string[]) null), forEngineerVisit, "Minor Works Cert");
                  EngineerVisit oEngineerVisit = (EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                  {
                    (object) 0
                  }, (string[]) null);
                  if (oEngineerVisit != null)
                  {
                    EnumerableRowCollection<DataRow> source1 = ((DataView) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                    {
                      (object) 2
                    }, (string[]) null)).Table.AsEnumerable();
                    Func<DataRow, bool> predicate;
                    // ISSUE: reference to a compiler-generated field
                    if (Printing._Closure\u0024__.\u0024I50\u002D0 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      predicate = Printing._Closure\u0024__.\u0024I50\u002D0;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      Printing._Closure\u0024__.\u0024I50\u002D0 = predicate = (Func<DataRow, bool>) (x => Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["WarningNoticeIssued"])));
                    }
                    EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
                    Func<DataRow, DataRow> selector;
                    // ISSUE: reference to a compiler-generated field
                    if (Printing._Closure\u0024__.\u0024I50\u002D1 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector = Printing._Closure\u0024__.\u0024I50\u002D1;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      Printing._Closure\u0024__.\u0024I50\u002D1 = selector = (Func<DataRow, DataRow>) (x => x);
                    }
                    DataRow[] array = source2.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
                    int index = 0;
                    while (index < array.Length)
                    {
                      DataRow WarningNotice = array[index];
                      this.WarningNoticePDF(oEngineerVisit, WarningNotice, "GasWarningNotice");
                      checked { ++index; }
                    }
                  }
                }
                Cursor.Current = Cursors.Default;
                break;
              case Enums.SystemDocumentType.SVR:
                string empty2 = string.Empty;
                FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
                int num2 = (int) folderBrowserDialog2.ShowDialog();
                if (folderBrowserDialog2.SelectedPath.Trim().Length == 0)
                  break;
                string savePath1 = folderBrowserDialog2.SelectedPath + "\\" + this.DocumentName + DateAndTime.Now.ToString("ddMMMyyyyHHmmss") + ".docx";
                Cursor.Current = Cursors.WaitCursor;
                success = this.SiteVisitReport((EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null), savePath1);
                str1 = savePath1;
                break;
              case Enums.SystemDocumentType.Install:
                this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                this.MsWordApp.Visible = false;
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Documents documents1 = this.MsWordApp.Documents;
                object obj2 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\Install.dot");
                ref object local1 = ref obj2;
                object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local2 = ref objectValue1;
                object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local3 = ref objectValue2;
                object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local4 = ref objectValue3;
                // ISSUE: reference to a compiler-generated method
                this.WordDoc = documents1.Add(ref local1, ref local2, ref local3, ref local4);
                success = this.Install((EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null));
                break;
              case Enums.SystemDocumentType.SiteLetter:
                this.SiteID = Conversions.ToInteger(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
                {
                  (object) 1
                }, (string[]) null, (System.Type[]) null, (bool[]) null));
                FRMSiteLetterList frmSiteLetterList = (FRMSiteLetterList) App.ShowForm(typeof (FRMSiteLetterList), true, (object[]) null, false);
                if (frmSiteLetterList.SelectedTemplate.Length > 0)
                {
                  Cursor.Current = Cursors.WaitCursor;
                  string path = App.TheSystem.Configuration.DocumentsLocation + "SiteLetters\\" + Conversions.ToString(this.SiteID) + "\\" + frmSiteLetterList.SelectedTemplate;
                  string withoutExtension = Path.GetFileNameWithoutExtension(path);
                  string savePath2 = path.Replace(withoutExtension, withoutExtension + "_" + DateTime.Now.ToString("ddMMMyyyyHHmmss"));
                  success = this.SiteLetter(System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\SiteLetters\\" + frmSiteLetterList.SelectedTemplate, savePath2);
                  str1 = savePath2;
                  break;
                }
                break;
              case Enums.SystemDocumentType.PartCredit:
                this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                this.MsWordApp.Visible = false;
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Documents documents2 = this.MsWordApp.Documents;
                object obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\CREDIT.dot");
                ref object local5 = ref obj3;
                object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local6 = ref objectValue4;
                object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local7 = ref objectValue5;
                object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local8 = ref objectValue6;
                // ISSUE: reference to a compiler-generated method
                this.WordDoc = documents2.Add(ref local5, ref local6, ref local7, ref local8);
                success = this.Credit();
                break;
              case Enums.SystemDocumentType.ServiceLetters:
                DataRow dr = (DataRow) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null);
                success = this.GenerateServiceLetterMK2(dr, Conversions.ToString(dr["AMPM"]), Conversions.ToDate(dr["StartDateTime"]), Conversions.ToString(dr["JobNUmber"]), DateAndTime.Today, (List<byte[]>) null, Conversions.ToInteger(dr["jobid"]), true);
                success = false;
                break;
              case Enums.SystemDocumentType.QCPrint:
                this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                this.MsWordApp.Visible = false;
                success = this.QCPrint();
                break;
              case Enums.SystemDocumentType.SalesCredit:
                str1 = App.TheSystem.Configuration.DocumentsLocation + "\\Sales Credits\\" + this.DocumentName + "_" + ((DataTable) this.DetailsToPrint).Rows[0]["CreditReference"].ToString() + ".docx";
                Directory.CreateDirectory(Path.GetDirectoryName(str1));
                str1 = this.FileCheck(str1);
                success = this.GenerateCredit((DataTable) this.DetailsToPrint, str1);
                Process.Start(str1);
                break;
              case Enums.SystemDocumentType.JobSheet:
                this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                this.MsWordApp.Visible = false;
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Documents documents3 = this.MsWordApp.Documents;
                object obj4 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\WorkSheet.dot");
                ref object local9 = ref obj4;
                object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local10 = ref objectValue7;
                object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local11 = ref objectValue8;
                object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local12 = ref objectValue9;
                // ISSUE: reference to a compiler-generated method
                this.WordDoc = documents3.Add(ref local9, ref local10, ref local11, ref local12);
                success = this.GenerateJobSheet((EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null));
                break;
              case Enums.SystemDocumentType.ElecMinor:
                this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                this.MsWordApp.Visible = false;
                EngineerVisitAdditional forEngineerVisit1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(Conversions.ToInteger(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null), (System.Type) null, "EngineerVisitID", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null)), 69995);
                Cursor.Current = Cursors.WaitCursor;
                this.ElecCertPDF((EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null), forEngineerVisit1, "Minor Works Cert");
                break;
              case Enums.SystemDocumentType.Warn:
                EngineerVisit oEngineerVisit1 = (EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null);
                if (oEngineerVisit1 != null)
                {
                  EnumerableRowCollection<DataRow> source1 = ((DataView) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                  {
                    (object) 1
                  }, (string[]) null)).Table.AsEnumerable();
                  Func<DataRow, bool> predicate;
                  // ISSUE: reference to a compiler-generated field
                  if (Printing._Closure\u0024__.\u0024I50\u002D2 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    predicate = Printing._Closure\u0024__.\u0024I50\u002D2;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    Printing._Closure\u0024__.\u0024I50\u002D2 = predicate = (Func<DataRow, bool>) (x => Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(x["WarningNoticeIssued"])));
                  }
                  EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
                  Func<DataRow, DataRow> selector;
                  // ISSUE: reference to a compiler-generated field
                  if (Printing._Closure\u0024__.\u0024I50\u002D3 != null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    selector = Printing._Closure\u0024__.\u0024I50\u002D3;
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    Printing._Closure\u0024__.\u0024I50\u002D3 = selector = (Func<DataRow, DataRow>) (x => x);
                  }
                  DataRow[] array = source2.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
                  int index = 0;
                  while (index < array.Length)
                  {
                    DataRow WarningNotice = array[index];
                    this.WarningNoticePDF(oEngineerVisit1, WarningNotice, "GasWarningNotice");
                    checked { ++index; }
                  }
                  break;
                }
                break;
              case Enums.SystemDocumentType.JobContactLetter:
                this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                this.MsWordApp.Visible = false;
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Documents documents4 = this.MsWordApp.Documents;
                object obj5 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\JobContactLetter.dot");
                ref object local13 = ref obj5;
                object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local14 = ref objectValue10;
                object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local15 = ref objectValue11;
                object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local16 = ref objectValue12;
                // ISSUE: reference to a compiler-generated method
                this.WordDoc = documents4.Add(ref local13, ref local14, ref local15, ref local16);
                success = this.JobContactLetter((Job) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null));
                break;
              case Enums.SystemDocumentType.Analyser:
                success = this.GenerateAnalyserLetter((DataTable) this.DetailsToPrint);
                break;
              case Enums.SystemDocumentType.PaymentReceipt:
                int integer2 = Conversions.ToInteger(this.DetailsToPrint);
                try
                {
                  success = this.GenerateSalesInvoice(App.DB.Invoiced.Invoiced_Get(integer2), (WordprocessingDocument) null, false);
                  break;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  Exception exception = ex;
                  success = false;
                  int num3 = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  ProjectData.ClearProjectError();
                  break;
                }
              case Enums.SystemDocumentType.CommissioningChecklist:
                this.MsWordApp = (Microsoft.Office.Interop.Word.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                this.MsWordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                this.MsWordApp.Visible = false;
                Cursor.Current = Cursors.WaitCursor;
                success = this.ComChecklist((EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null));
                break;
              case Enums.SystemDocumentType.HotWorksPermit:
                Cursor.Current = Cursors.WaitCursor;
                success = this.GenerateHotWorksPermit((EngineerVisit) NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
                {
                  (object) 0
                }, (string[]) null));
                break;
            }
            break;
          default:
            if (this.OrderID > 0)
            {
              str1 = App.TheSystem.Configuration.DocumentsLocation + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".doc";
              goto case Enums.SystemDocumentType.ContractOption1;
            }
            else
            {
              FolderBrowserDialog folderBrowserDialog3 = new FolderBrowserDialog();
              int num3 = (int) folderBrowserDialog3.ShowDialog();
              if (folderBrowserDialog3.SelectedPath.Trim().Length == 0)
                break;
              str1 = folderBrowserDialog3.SelectedPath + "\\" + this.DocumentName + Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") + ".doc";
              goto case Enums.SystemDocumentType.ContractOption1;
            }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        success = false;
        int num = (int) App.ShowMessage("Error printing : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        switch (this.PrintType)
        {
          case Enums.SystemDocumentType.ContractOption1:
          case Enums.SystemDocumentType.GSR:
          case Enums.SystemDocumentType.ServiceLetters:
          case Enums.SystemDocumentType.SalesCredit:
          case Enums.SystemDocumentType.ComGSR:
          case Enums.SystemDocumentType.DomGSR:
          case Enums.SystemDocumentType.ComCat:
          case Enums.SystemDocumentType.SaffUnv:
          case Enums.SystemDocumentType.PropMaint:
          case Enums.SystemDocumentType.ASHP:
          case Enums.SystemDocumentType.Analyser:
          case Enums.SystemDocumentType.PaymentReceipt:
          case Enums.SystemDocumentType.CommissioningChecklist:
          case Enums.SystemDocumentType.HotWorksPermit:
            Cursor.Current = Cursors.Default;
          default:
            if (success)
            {
              string fileName = this.Finalise(str1, success, true, true, false);
              Cursor.Current = Cursors.WaitCursor;
              Process.Start(fileName);
              Cursor.Current = Cursors.Default;
              goto case Enums.SystemDocumentType.ContractOption1;
            }
            else
              goto case Enums.SystemDocumentType.ContractOption1;
        }
      }
    }

    private bool PrintGSR(
      int engineerVisitId,
      List<byte[]> fullDocument,
      string jobNumber = "",
      bool isSvr = false)
    {
      bool flag1;
      try
      {
        bool flag2 = !string.IsNullOrEmpty(jobNumber);
        bool flag3 = false;
        bool flag4 = false;
        string empty = string.Empty;
        bool flag5 = false;
        EngineerVisit asObject = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisitId, true);
        Site oSite = App.DB.Sites.Get((object) asObject.EngineerVisitID, SiteSQL.GetBy.EngineerVisitId, (object) null);
        EngineerVisitAdditional engineerVisitAdditional1 = (EngineerVisitAdditional) null;
        EngineerVisitAdditional engineerVisitAdditional2 = (EngineerVisitAdditional) null;
        EngineerVisitAdditional SAFUNV1 = (EngineerVisitAdditional) null;
        EngineerVisitAdditional engineerVisitAdditional3 = (EngineerVisitAdditional) null;
        DataView dataView = (DataView) null;
        List<int> intList = new List<int>()
        {
          69109,
          69110,
          69108,
          69111
        };
        DataView forEngineerVisit = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(engineerVisitId);
        string path = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(50) + "\\" + Conversions.ToString(asObject.EngineerVisitID);
        Directory.CreateDirectory(path);
        if (this.PrintType == Enums.SystemDocumentType.GSR | this.PrintType == Enums.SystemDocumentType.GSRBatch)
        {
          engineerVisitAdditional1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(asObject.EngineerVisitID, 69419);
          engineerVisitAdditional2 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(asObject.EngineerVisitID, 69591);
          SAFUNV1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(asObject.EngineerVisitID, 69902);
          engineerVisitAdditional3 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(asObject.EngineerVisitID, 69903);
          EnumerableRowCollection<DataRow> source = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(asObject.EngineerVisitID, -1).Table.AsEnumerable().Where<DataRow>((Func<DataRow, bool>) (x => intList.Contains(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["TestType"])))));
          Func<DataRow, DataRow> selector;
          // ISSUE: reference to a compiler-generated field
          if (Printing._Closure\u0024__.\u0024I51\u002D1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            selector = Printing._Closure\u0024__.\u0024I51\u002D1;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            Printing._Closure\u0024__.\u0024I51\u002D1 = selector = (Func<DataRow, DataRow>) (x => x);
          }
          DataRow[] array = source.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
          dataView = array.Length <= 0 ? (DataView) null : new DataView(((IEnumerable<DataRow>) array).CopyToDataTable<DataRow>());
        }
        else if (this.PrintType == Enums.SystemDocumentType.ASHP)
          engineerVisitAdditional1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(asObject.EngineerVisitID, 69419);
        else if (this.PrintType == Enums.SystemDocumentType.PropMaint)
        {
          engineerVisitAdditional2 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(asObject.EngineerVisitID, 69591);
          goto label_144;
        }
        else if (this.PrintType == Enums.SystemDocumentType.ComCat)
          engineerVisitAdditional3 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(asObject.EngineerVisitID, 69903);
        else if (this.PrintType == Enums.SystemDocumentType.COMSR | this.PrintType == Enums.SystemDocumentType.ComGSR)
        {
          EnumerableRowCollection<DataRow> source = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(asObject.EngineerVisitID, -1).Table.AsEnumerable().Where<DataRow>((Func<DataRow, bool>) (x => intList.Contains(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["TestType"])))));
          Func<DataRow, DataRow> selector;
          // ISSUE: reference to a compiler-generated field
          if (Printing._Closure\u0024__.\u0024I51\u002D3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            selector = Printing._Closure\u0024__.\u0024I51\u002D3;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            Printing._Closure\u0024__.\u0024I51\u002D3 = selector = (Func<DataRow, DataRow>) (x => x);
          }
          DataRow[] array = source.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
          dataView = array.Length <= 0 ? (DataView) null : new DataView(((IEnumerable<DataRow>) array).CopyToDataTable<DataRow>());
        }
        else if (this.PrintType == Enums.SystemDocumentType.SaffUnv)
        {
          SAFUNV1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(asObject.EngineerVisitID, 69902);
          goto label_159;
        }
        DateTime now;
        if (((dataView == null ? 1 : (dataView.Count == 0 ? 1 : 0)) & (engineerVisitAdditional1 == null ? 1 : 0) | (this.PrintType == Enums.SystemDocumentType.DomGSR ? 1 : 0)) != 0)
        {
          DataView GSRS1 = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 0);
          DataView GSRS2 = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 1);
          DataView LSR = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 3);
          DataView GSRS3 = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 5);
          GSRS3.Table.Merge(App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 6).Table);
          DataView forVisit = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 8);
          DataView GSRS4 = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 9);
          DataView GSRS5 = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 7);
          GSRS5.Table.Merge(App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 4).Table);
          DataView GSRS6 = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(engineerVisitId, 2);
          if (this.PrintType == Enums.SystemDocumentType.ComCat)
          {
            GSRS1 = new DataView();
            GSRS2 = new DataView();
            GSRS5 = new DataView();
            LSR = new DataView();
            GSRS3 = new DataView();
            GSRS4 = new DataView();
            GSRS6 = new DataView();
          }
          if (((GSRS1.Table.Rows.Count == 0 & GSRS2.Table.Rows.Count == 0 & GSRS6.Table.Rows.Count == 0 & GSRS5.Table.Rows.Count == 0 & GSRS3.Table.Rows.Count == 0 & GSRS4.Table.Rows.Count == 0 & forVisit.Table.Rows.Count == 0 & LSR.Table.Rows.Count == 0 & forEngineerVisit.Table.Rows.Count == 0 ? 1 : 0) & (dataView == null ? 1 : (dataView.Count == 0 ? 1 : 0)) & (engineerVisitAdditional1 == null ? 1 : 0) & (engineerVisitAdditional2 == null ? 1 : 0) & (SAFUNV1 == null ? 1 : 0) & (engineerVisitAdditional3 == null ? 1 : 0)) != 0)
          {
            flag4 = true;
            flag3 = true;
            goto label_174;
          }
          else
          {
            bool flag6 = GSRS1.Table.Rows.Count == 0 && GSRS2.Table.Rows.Count == 0 && (GSRS5.Table.Rows.Count == 0 && GSRS3.Table.Rows.Count == 0) && (GSRS4.Table.Rows.Count == 0 && forVisit.Table.Rows.Count == 0) && forEngineerVisit.Table.Rows.Count > 0;
            if (GSRS1.Table.Rows.Count > 0)
            {
              string str1 = oSite.CustomerID != 2846 ? (oSite.CustomerID != 5155 ? System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSR.docx" : System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSR_WDC.docx") : System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSR_NCC.docx";
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSR";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str2 = this.FileCheck(string.Concat(strArray));
              string documentGoldenRule = this.GetDocumentGoldenRule(str1, oSite.SiteID);
              bool printHeader = false;
              if (!isSvr)
              {
                if (!flag5)
                  printHeader = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = printHeader;
              }
              flag3 = this.GSR(asObject, oSite, forEngineerVisit, printHeader, GSRS1, str1, str2, Enums.WorksheetFuelTypes.Gas, documentGoldenRule, fullDocument, oSite.CustomerID == 2846);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str2, true), asObject, oSite, "LSR_GAS");
            }
            if (GSRS2.Table.Rows.Count > 0)
            {
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSROil";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str1 = this.FileCheck(string.Concat(strArray));
              string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSROil.docx";
              bool printHeader = false;
              if (!isSvr)
              {
                if (!flag5)
                  printHeader = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = printHeader;
              }
              string documentGoldenRule = this.GetDocumentGoldenRule(str2, oSite.SiteID);
              flag3 = this.GSR(asObject, oSite, forEngineerVisit, printHeader, GSRS2, str2, str1, Enums.WorksheetFuelTypes.Oil, documentGoldenRule, fullDocument, false);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_OIL");
            }
            if (GSRS5.Table.Rows.Count > 0 | flag6)
            {
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSROther";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str1 = this.FileCheck(string.Concat(strArray));
              string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSROther.docx";
              bool printHeader = false;
              if (!isSvr)
              {
                if (!flag5)
                  printHeader = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = printHeader;
              }
              string documentGoldenRule = this.GetDocumentGoldenRule(str2, oSite.SiteID);
              flag3 = this.GSR(asObject, oSite, forEngineerVisit, printHeader, GSRS5, str2, str1, Enums.WorksheetFuelTypes.Other, documentGoldenRule, fullDocument, false);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_OTHER");
            }
            if (GSRS6.Table.Rows.Count > 0)
            {
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSRSolidFuel";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str1 = this.FileCheck(string.Concat(strArray));
              string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRSolidFuel.docx";
              bool printHeader = false;
              if (!isSvr)
              {
                if (!flag5)
                  printHeader = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = printHeader;
              }
              string documentGoldenRule = this.GetDocumentGoldenRule(str2, oSite.SiteID);
              flag3 = this.GSR(asObject, oSite, forEngineerVisit, printHeader, GSRS6, str2, str1, Enums.WorksheetFuelTypes.SolidFuel, documentGoldenRule, fullDocument, false);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_SOLIDFUEL");
            }
            if (GSRS3.Table.Rows.Count > 0)
            {
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSRASHPGSHP";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str1 = this.FileCheck(string.Concat(strArray));
              string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRASHPGSHP.docx";
              bool printHeader = false;
              if (!isSvr)
              {
                if (!flag5)
                  printHeader = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = printHeader;
              }
              string documentGoldenRule = this.GetDocumentGoldenRule(str2, oSite.SiteID);
              flag3 = this.GSR(asObject, oSite, forEngineerVisit, printHeader, GSRS3, str2, str1, Enums.WorksheetFuelTypes.ASHP, documentGoldenRule, fullDocument, false);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_ASHPGSHP");
            }
            if (GSRS4.Table.Rows.Count > 0)
            {
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSRHIU";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str1 = this.FileCheck(string.Concat(strArray));
              string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRHIU.docx";
              bool printHeader = false;
              if (!isSvr)
              {
                if (!flag5)
                  printHeader = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = printHeader;
              }
              string documentGoldenRule = this.GetDocumentGoldenRule(str2, oSite.SiteID);
              flag3 = this.GSR(asObject, oSite, forEngineerVisit, printHeader, GSRS4, str2, str1, Enums.WorksheetFuelTypes.HIU, documentGoldenRule, fullDocument, false);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_HIU");
            }
            if (LSR.Table.Rows.Count > 0)
            {
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSRUnvented";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str1 = this.FileCheck(string.Concat(strArray));
              string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRUnvented.docx";
              bool addLsrHeaderLetter = false;
              if (!isSvr)
              {
                if (!flag5)
                  addLsrHeaderLetter = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = addLsrHeaderLetter;
              }
              string documentGoldenRule = this.GetDocumentGoldenRule(str2, oSite.SiteID);
              flag3 = this.Unvented(asObject, oSite, str2, str1, LSR, documentGoldenRule, ref fullDocument, addLsrHeaderLetter);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_GSRUnvented");
            }
            if (forVisit.Table.Rows.Count > 0)
            {
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSRCOMCAT2";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str1 = this.FileCheck(string.Concat(strArray));
              string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRCOMCAT2.docx";
              bool printHeader = false;
              if (!isSvr)
              {
                if (!flag5)
                  printHeader = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = printHeader;
              }
              string documentGoldenRule = this.GetDocumentGoldenRule(str2, oSite.SiteID);
              flag3 = this.GSR(asObject, oSite, forEngineerVisit, printHeader, forVisit, str2, str1, Enums.WorksheetFuelTypes.Unvented, documentGoldenRule, fullDocument, false);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_COMCAT2");
            }
            if (engineerVisitAdditional3 != null)
            {
              string[] strArray = new string[8];
              strArray[0] = path;
              strArray[1] = "\\GSRCOMCAT";
              now = DateAndTime.Now;
              strArray[2] = Conversions.ToString(now.Day);
              strArray[3] = "_";
              now = DateAndTime.Now;
              strArray[4] = now.ToString("MMM");
              strArray[5] = "_";
              now = DateAndTime.Now;
              strArray[6] = Conversions.ToString(now.Year);
              strArray[7] = ".docx";
              string str1 = this.FileCheck(string.Concat(strArray));
              string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRCOMCAT.docx";
              bool addLsrHeaderLetter = false;
              if (!isSvr)
              {
                if (!flag5)
                  addLsrHeaderLetter = flag2 ? Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1])) : oSite.CustomerID == 2846;
                if (!flag5)
                  flag5 = addLsrHeaderLetter;
              }
              string documentGoldenRule = this.GetDocumentGoldenRule(str2, oSite.SiteID);
              flag3 = this.COMCAT(asObject, oSite, str2, str1, documentGoldenRule, fullDocument, addLsrHeaderLetter);
              if (flag3 & !flag2)
                this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_COMCAT");
            }
          }
        }
        else if (engineerVisitAdditional1 != null)
        {
          string[] strArray1 = new string[8];
          strArray1[0] = path;
          strArray1[1] = "\\ASHPM";
          now = DateAndTime.Now;
          strArray1[2] = Conversions.ToString(now.Day);
          strArray1[3] = "_";
          now = DateAndTime.Now;
          strArray1[4] = now.ToString("MMM");
          strArray1[5] = "_";
          now = DateAndTime.Now;
          strArray1[6] = Conversions.ToString(now.Year);
          strArray1[7] = ".docx";
          string str1 = this.FileCheck(string.Concat(strArray1));
          string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRASHPM.docx";
          bool addHeaderLetter = false;
          if (!isSvr)
          {
            if (!flag5)
              addHeaderLetter = flag2 && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1]));
            if (!flag5)
              flag5 = addHeaderLetter;
          }
          string documentGoldenRule1 = this.GetDocumentGoldenRule(str2, oSite.SiteID);
          flag3 = this.ASHPM(asObject, oSite, str2, str1, documentGoldenRule1, fullDocument, addHeaderLetter);
          if (flag3 & !flag2)
            this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_ASHPM");
          if (forEngineerVisit.Count > 0)
          {
            string[] strArray2 = new string[8];
            strArray2[0] = path;
            strArray2[1] = "\\GSROther";
            now = DateAndTime.Now;
            strArray2[2] = Conversions.ToString(now.Day);
            strArray2[3] = "_";
            now = DateAndTime.Now;
            strArray2[4] = now.ToString("MMM");
            strArray2[5] = "_";
            now = DateAndTime.Now;
            strArray2[6] = Conversions.ToString(now.Year);
            strArray2[7] = ".docx";
            string str3 = this.FileCheck(string.Concat(strArray2));
            string str4 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSROther.docx";
            string documentGoldenRule2 = this.GetDocumentGoldenRule(str4, oSite.SiteID);
            flag3 = this.GSR(asObject, oSite, forEngineerVisit, false, new DataView(new DataTable()), str4, str3, Enums.WorksheetFuelTypes.Other, documentGoldenRule2, fullDocument, false);
            if (flag3 & !flag2)
              this.GSRSave(PrintHelper.LockFile(str3, true), asObject, oSite, "LSR_OTHER");
          }
        }
        else
        {
          string[] strArray1 = new string[8]
          {
            path,
            "\\COMSR",
            Conversions.ToString(DateAndTime.Now.Day),
            "_",
            DateAndTime.Now.ToString("MMM"),
            "_",
            null,
            null
          };
          now = DateAndTime.Now;
          strArray1[6] = Conversions.ToString(now.Year);
          strArray1[7] = ".docx";
          string str1 = this.FileCheck(string.Concat(strArray1));
          string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRCOMSR.docx";
          bool addLsrHeaderLetter = false;
          if (!isSvr)
          {
            if (!flag5)
              addLsrHeaderLetter = flag2 && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1]));
            if (!flag5)
              flag5 = addLsrHeaderLetter;
          }
          string documentGoldenRule1 = this.GetDocumentGoldenRule(str2, oSite.SiteID);
          flag3 = this.COMSR(asObject, oSite, str2, str1, documentGoldenRule1, fullDocument, addLsrHeaderLetter);
          if (flag3 & !flag2)
            this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_COMSR");
          if (dataView != null && dataView.Count > 0)
          {
            string[] strArray2 = new string[8];
            strArray2[0] = path;
            strArray2[1] = "\\COMTANDP";
            now = DateAndTime.Now;
            strArray2[2] = Conversions.ToString(now.Day);
            strArray2[3] = "_";
            now = DateAndTime.Now;
            strArray2[4] = now.ToString("MMM");
            strArray2[5] = "_";
            now = DateAndTime.Now;
            strArray2[6] = Conversions.ToString(now.Year);
            strArray2[7] = ".docx";
            string str3 = this.FileCheck(string.Concat(strArray2));
            string str4 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRCOMTANDP.docx";
            string documentGoldenRule2 = this.GetDocumentGoldenRule(str4, oSite.SiteID);
            flag3 = this.COMTANDP(asObject, oSite, str4, str3, documentGoldenRule2, fullDocument);
            if (flag3 & !flag2)
              this.GSRSave(PrintHelper.LockFile(str3, true), asObject, oSite, "LSR_COMTANDP");
          }
          if (forEngineerVisit.Count > 0)
          {
            string[] strArray2 = new string[8];
            strArray2[0] = path;
            strArray2[1] = "\\GSROther";
            now = DateAndTime.Now;
            strArray2[2] = Conversions.ToString(now.Day);
            strArray2[3] = "_";
            now = DateAndTime.Now;
            strArray2[4] = now.ToString("MMM");
            strArray2[5] = "_";
            now = DateAndTime.Now;
            strArray2[6] = Conversions.ToString(now.Year);
            strArray2[7] = ".docx";
            string str3 = this.FileCheck(string.Concat(strArray2));
            string str4 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSROther.docx";
            string documentGoldenRule2 = this.GetDocumentGoldenRule(str4, oSite.SiteID);
            flag3 = this.GSR(asObject, oSite, forEngineerVisit, false, new DataView(new DataTable()), str4, str3, Enums.WorksheetFuelTypes.Other, documentGoldenRule2, fullDocument, false);
            if (flag3 & !flag2)
              this.GSRSave(PrintHelper.LockFile(str3, true), asObject, oSite, "LSR_OTHER");
          }
        }
label_144:
        if (engineerVisitAdditional2 != null)
        {
          string[] strArray1 = new string[8];
          strArray1[0] = path;
          strArray1[1] = "\\PropMain";
          now = DateAndTime.Now;
          strArray1[2] = Conversions.ToString(now.Day);
          strArray1[3] = "_";
          now = DateAndTime.Now;
          strArray1[4] = now.ToString("MMM");
          strArray1[5] = "_";
          now = DateAndTime.Now;
          strArray1[6] = Conversions.ToString(now.Year);
          strArray1[7] = ".docx";
          string str1 = this.FileCheck(string.Concat(strArray1));
          string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRPropMain.docx";
          bool addLsrHeaderLetter = false;
          if (!isSvr)
          {
            if (!flag5)
              addLsrHeaderLetter = flag2 && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1]));
            if (!flag5)
              flag5 = addLsrHeaderLetter;
          }
          string documentGoldenRule1 = this.GetDocumentGoldenRule(str2, oSite.SiteID);
          flag3 = this.ProptMain(asObject, oSite, str2, str1, documentGoldenRule1, fullDocument, addLsrHeaderLetter);
          if (flag3 & !flag2)
            this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_PropMain");
          if (forEngineerVisit.Count > 0)
          {
            string[] strArray2 = new string[8];
            strArray2[0] = path;
            strArray2[1] = "\\GSROther";
            now = DateAndTime.Now;
            strArray2[2] = Conversions.ToString(now.Day);
            strArray2[3] = "_";
            now = DateAndTime.Now;
            strArray2[4] = now.ToString("MMM");
            strArray2[5] = "_";
            now = DateAndTime.Now;
            strArray2[6] = Conversions.ToString(now.Year);
            strArray2[7] = ".docx";
            string str3 = this.FileCheck(string.Concat(strArray2));
            string str4 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSROther.docx";
            string documentGoldenRule2 = this.GetDocumentGoldenRule(str4, oSite.SiteID);
            flag3 = this.GSR(asObject, oSite, forEngineerVisit, false, new DataView(new DataTable()), str4, str3, Enums.WorksheetFuelTypes.Other, documentGoldenRule2, fullDocument, false);
            if (flag3 & !flag2)
              this.GSRSave(PrintHelper.LockFile(str3, true), asObject, oSite, "LSR_OTHER");
          }
        }
label_159:
        if (SAFUNV1 != null)
        {
          string[] strArray1 = new string[8];
          strArray1[0] = path;
          strArray1[1] = "\\SAFUnvASHP";
          now = DateAndTime.Now;
          strArray1[2] = Conversions.ToString(now.Day);
          strArray1[3] = "_";
          now = DateAndTime.Now;
          strArray1[4] = now.ToString("MMM");
          strArray1[5] = "_";
          now = DateAndTime.Now;
          strArray1[6] = Conversions.ToString(now.Year);
          strArray1[7] = ".docx";
          string str1 = this.FileCheck(string.Concat(strArray1));
          string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRUnvASHP.docx";
          bool addLsrHeaderLetter = false;
          if (!isSvr)
          {
            if (!flag5)
              addLsrHeaderLetter = flag2 && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((ArrayList) this.DetailsToPrint)[1]));
            if (!flag5)
              ;
          }
          string documentGoldenRule1 = this.GetDocumentGoldenRule(str2, oSite.SiteID);
          flag3 = this.SAFUnvented(asObject, oSite, SAFUNV1, str2, str1, documentGoldenRule1, ref fullDocument, addLsrHeaderLetter);
          if (flag3 & !flag2)
            this.GSRSave(PrintHelper.LockFile(str1, true), asObject, oSite, "LSR_SAFUnvASHP");
          if (forEngineerVisit.Count > 0)
          {
            string[] strArray2 = new string[8];
            strArray2[0] = path;
            strArray2[1] = "\\GSROther";
            now = DateAndTime.Now;
            strArray2[2] = Conversions.ToString(now.Day);
            strArray2[3] = "_";
            now = DateAndTime.Now;
            strArray2[4] = now.ToString("MMM");
            strArray2[5] = "_";
            now = DateAndTime.Now;
            strArray2[6] = Conversions.ToString(now.Year);
            strArray2[7] = ".docx";
            string str3 = this.FileCheck(string.Concat(strArray2));
            string str4 = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSROther.docx";
            string documentGoldenRule2 = this.GetDocumentGoldenRule(str4, oSite.SiteID);
            flag3 = this.GSR(asObject, oSite, forEngineerVisit, false, new DataView(new DataTable()), str4, str3, Enums.WorksheetFuelTypes.Other, documentGoldenRule2, fullDocument, false);
            if (flag3 & !flag2)
              this.GSRSave(PrintHelper.LockFile(str3, true), asObject, oSite, "LSR_OTHER");
          }
        }
label_174:
        if (flag4)
        {
          LSRError lsrError1 = new LSRError();
          LSRError lsrError2 = lsrError1;
          lsrError2.EngineerVisitID = asObject.EngineerVisitID;
          Engineer engineer = App.DB.Engineer.Engineer_Get(asObject.EngineerID);
          lsrError2.Engineer = engineer != null ? engineer.Name : "Unknown";
          lsrError2.VisitDate = asObject.StartDateTime;
          lsrError2.JobNumber = jobNumber;
          this.LSRErrors.Add(lsrError1);
        }
        flag1 = flag3;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      return flag1;
    }

    private bool GenerateServiceLetter(
      DataRow dr,
      string AMPM,
      DateTime VisitDate,
      string JobNumber,
      DateTime TheDate)
    {
      bool flag;
      try
      {
        IEnumerator enumerator;
        try
        {
          enumerator = Printing.GetTemplateFields(this.WordDoc.Content[]).GetEnumerator();
          while (enumerator.MoveNext())
          {
            Match current = (Match) enumerator.Current;
            string lower = current.Value.ToLower();
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address1]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address1"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address2]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address2"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address3]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address3"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address4]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address4"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address5]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address5"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Postcode]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["Postcode"]))));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[theDate]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Microsoft.VisualBasic.Strings.Format((object) TheDate, "dd/MM/yyyy"));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Date]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Microsoft.VisualBasic.Strings.Format((object) VisitDate, "dd/MM/yyyy"));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Name]".ToLower(), false) == 0)
            {
              string String1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Name"]));
              if (String1.Contains("T2"))
                String1 = String1.Substring(0, checked (Microsoft.VisualBasic.Strings.InStr(String1, "T2", CompareMethod.Binary) - 1));
              string NewText = String1.Replace("T1 ", "").Trim();
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[AMPM]".ToLower(), false) == 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(AMPM, "AM", false) == 0)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "8:00am - 1:00pm");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "12:00pm - 5:30pm");
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobRef]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) JobNumber));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[gascharge]".ToLower(), false) == 0)
            {
              DateTime Date2 = new DateTime(2017, 3, 31);
              if (DateAndTime.DateDiff(DateInterval.Day, VisitDate, Date2, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "£41.37");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "£37.00");
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[carpcharge]".ToLower(), false) == 0)
            {
              if (DateAndTime.DateDiff(DateInterval.Day, VisitDate, new DateTime(2017, 3, 31), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "£97.76");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "£88.03");
                this.WordDoc = wordDoc;
              }
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateAnalyserLetter(DataTable dt)
    {
      bool flag1;
      try
      {
        string path1 = System.Windows.Forms.Application.StartupPath + "\\Templates\\FGATempAnton.docx";
        DataRow row = dt.Rows[0];
        byte[] buffer = File.ReadAllBytes(path1);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (wordprocessingDocument)
          {
            string str1 = (string) null;
            StreamReader streamReader = new StreamReader(wordprocessingDocument.MainDocumentPart.GetStream());
            using (streamReader)
              str1 = streamReader.ReadToEnd();
            string str2 = str1.Replace("[Date]", DateAndTime.Now.ToLongDateString()).Replace("[Serial]", Conversions.ToString(row["SerialNumber"])).Replace("[Faults]", Conversions.ToString(row["Faults"])).Replace("[Username]", App.loggedInUser.Fullname).Replace("[Email]", App.loggedInUser.EmailAddress);
            StreamWriter streamWriter = new StreamWriter(wordprocessingDocument.MainDocumentPart.GetStream(FileMode.Create));
            using (streamWriter)
              streamWriter.Write(str2);
          }
          FSM.Entity.Documentss.Documents oDocuments = new FSM.Entity.Documentss.Documents();
          oDocuments.SetTableEnumID = (object) 146;
          oDocuments.SetRecordID = (object) Conversions.ToInteger(row["EquipmentID"]);
          oDocuments.SetDocumentTypeID = (object) 205;
          string path2 = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(146) + "\\" + Conversions.ToString(Conversions.ToInteger(row["EquipmentID"]));
          Directory.CreateDirectory(path2);
          string str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) (path2 + "\\AnalyserSerialNumber"), row["SerialNumber"]), (object) "_"), (object) DateTime.Now.ToFileTime()), (object) ".docx"));
          FileStream fileStream = new FileStream(str, FileMode.CreateNew);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
          fileStream.Close();
          bool flag2 = false;
          if (!Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(row["SendEmail"])))
            flag2 = true;
          string fileName = PrintHelper.LockFile(str, true);
          oDocuments.SetNotes = (object) "";
          oDocuments.SetLocation = (object) path2;
          oDocuments.SetName = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Anton Sprint eVo2, Serial Number ", row["SerialNumber"]);
          App.DB.Documents.Insert(oDocuments, false);
          if (Conversions.ToBoolean(row["SendEmail"]))
            new Emails()
            {
              To = Conversions.ToString(row["EmailAddress"]),
              From = App.loggedInUser.EmailAddress,
              Subject = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Anton Sprint eVo2, Serial Number ", row["SerialNumber"])),
              Body = "Please see letter attached",
              Attachments = {
                (object) fileName
              },
              SendMe = true
            }.Send();
          else
            Process.Start(fileName);
        }
        flag1 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      return flag1;
    }

    private bool GenerateServiceLetterMK2(
      DataRow dr,
      string AMPM,
      DateTime VisitDate,
      string JobNumber,
      DateTime TheDate,
      List<byte[]> batch = null,
      int jobid = 0,
      bool justLetters = false)
    {
      int customerId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["CustomerID"]));
      bool flag1 = dr.Table.Columns.Contains("PatchCheck") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dr["PatchCheck"]));
      CustomerServiceProcess forCustomer = App.DB.Customer.CustomerServiceProcess_Get_ForCustomer(customerId);
      string lower = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"])).ToLower();
      byte[] numArray = (byte[]) null;
      string str1 = !dr.Table.Columns.Contains("FileName") || string.IsNullOrEmpty(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["FileName"]))) ? string.Empty : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["FileName"]));
      DataView allForLink = App.DB.Contact.Contacts_GetAll_ForLink(24, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteID"])), false);
      DataRow dataRow = (DataRow) null;
      if (!string.IsNullOrEmpty(str1))
        numArray = TemplateHelper.ReadWordDoc(System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + str1);
      else if (Helper.MakeIntegerValid((object) forCustomer?.CustomerServiceProcessID) == 0)
        numArray = !flag1 ? TemplateHelper.ReadWordDoc(System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ServiceLetters\\AnnualSafetyInspection.docx") : TemplateHelper.ReadWordDoc(System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ServiceLetters\\PatchCheck.docx");
      else if (flag1)
        numArray = forCustomer.PatchCheckTemplate;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "letter 1", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "letter 2", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "letter 3", false) == 0)
            numArray = forCustomer.Template3;
        }
        else
          numArray = forCustomer.Template2;
      }
      else
        numArray = forCustomer.Template1;
      if (numArray == null)
        throw new Exception("Unable to locate template!");
      IEnumerator enumerator;
      try
      {
        enumerator = allForLink.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["POC"])))
            dataRow = current.Row;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      bool flag2;
      try
      {
        int num1 = checked (unchecked (dataRow != null) ? 2 : 1 - 1);
        int num2 = 0;
        while (num2 <= num1)
        {
          string documentGoldenRule = this.GetDocumentGoldenRule("AnnualSafetyInspection", Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteID"])));
          byte[] buffer = numArray;
          MemoryStream memoryStream = new MemoryStream();
          using (memoryStream)
          {
            memoryStream.Write(buffer, 0, buffer.Length);
            WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
            using (doc)
            {
              PrintHelper.ReplaceText(doc, "[GoldenRule]", documentGoldenRule);
              this.AddCompanyDetails(doc, true, false, false);
              FSM.Entity.Customers.Customer forSiteId = App.DB.Customer.Customer_Get_ForSiteID(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteID"])));
              if (forSiteId != null)
                PrintHelper.ReplaceText(doc, "$Customer", forSiteId.Name);
              PrintHelper.ReplaceText(doc, "$Address1", Conversions.ToString(dataRow == null || Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Address1"])) ? dr["Address1"] : dataRow["Address1"]));
              PrintHelper.ReplaceText(doc, "$Address2", Conversions.ToString(dataRow == null || Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Address2"])) ? dr["Address2"] : dataRow["Address2"]));
              PrintHelper.ReplaceText(doc, "$Address3", Conversions.ToString(dataRow == null || Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Address3"])) ? dr["Address3"] : dataRow["Address3"]));
              PrintHelper.ReplaceText(doc, "$Address4", string.Empty);
              PrintHelper.ReplaceText(doc, "$Address5", string.Empty);
              PrintHelper.ReplaceText(doc, "$Postcode", dataRow == null || Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["Postcode"])) ? Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["Postcode"])) : Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["Postcode"])));
              PrintHelper.ReplaceText(doc, "$TheDate", Microsoft.VisualBasic.Strings.Format((object) TheDate, "dd/MM/yyyy"));
              PrintHelper.ReplaceText(doc, "$Date", VisitDate.ToString("dddd, dd/MM/yyyy"));
              PrintHelper.ReplaceText(doc, "$Expiry", Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDate(dr["LastServiceDate"]).AddDays(366.0), "dd/MM/yyyy"));
              string str2 = string.Empty;
              if (dataRow != null && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["FirstName"])))
                str2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Title"])) + " " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["FirstName"])) + " " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["LastName"]));
              if (str2.Length > 0)
                str2 += " on behalf of ";
              string str3 = str2 + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Name"]));
              if (str3.Contains("T2"))
                str3 = str3.Replace("T2 ", "");
              string str4 = str3.Replace("T1 ", "").Trim();
              PrintHelper.ReplaceText(doc, "$Name", Microsoft.VisualBasic.Strings.StrConv(str4, VbStrConv.ProperCase, 0).Replace("&", "&amp;"));
              if (string.IsNullOrEmpty(AMPM))
                AMPM = VisitDate.Hour < 12 ? "AM" : "PM";
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(AMPM, "AM", false) == 0)
                PrintHelper.ReplaceText(doc, "$AMPM", "between 8:00am and 1:00pm");
              else
                PrintHelper.ReplaceText(doc, "$AMPM", "between 12:00pm and 5:30pm");
              PrintHelper.ReplaceText(doc, "$GasCharge", "£41.37");
              PrintHelper.ReplaceText(doc, "$CarpCharge", "£97.76");
              PrintHelper.ReplaceText(doc, "$JobRef", Helper.MakeStringValid((object) JobNumber));
              doc.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
              {
                (OpenXmlElement) new Run(new OpenXmlElement[1]
                {
                  (OpenXmlElement) new Break()
                  {
                    Type = (EnumValue<BreakValues>) BreakValues.Page
                  }
                })
              }), (OpenXmlElement) doc.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            }
            FSM.Entity.Documentss.Documents oDocuments = new FSM.Entity.Documentss.Documents();
            oDocuments.SetTableEnumID = (object) 47;
            oDocuments.SetRecordID = (object) jobid;
            oDocuments.SetDocumentTypeID = (object) 205;
            string path = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(47) + "\\" + Conversions.ToString(jobid);
            Directory.CreateDirectory(path);
            string str5 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) (path + "\\"), dr["Type"]), (object) DateTime.Now.ToString("HHmmssfff")), (object) ".docx"));
            FileStream fileStream = new FileStream(str5, FileMode.CreateNew);
            memoryStream.Position = 0L;
            using (fileStream)
              memoryStream.WriteTo((Stream) fileStream);
            oDocuments.SetNotes = (object) "";
            oDocuments.SetLocation = (object) path;
            App.DB.Documents.Insert(oDocuments, false);
            if (!justLetters & App.DB.LetterManager.LetterGenerated_CheckToday(Conversions.ToString(dr["Type"]), jobid, TheDate).Rows.Count > 0)
            {
              flag2 = true;
              goto label_63;
            }
            else
            {
              if (batch != null)
                batch.Add(memoryStream.ToArray());
              else
                Process.Start(str5);
              dataRow = (DataRow) null;
            }
          }
          checked { ++num2; }
        }
        flag2 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag2 = false;
        ProjectData.ClearProjectError();
      }
label_63:
      return flag2;
    }

    public bool GenerateJobLetter(
      DataRow dr,
      Job job,
      bool letter1,
      WordprocessingDocument batch = null,
      EngineerVisit engineervisit = null)
    {
      Site site = App.DB.Sites.Get((object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteID"])), SiteSQL.GetBy.SiteId, (object) null);
      JobOfWork jobOfWork = (JobOfWork) job.JobOfWorks[0];
      int index = 0;
      if (!letter1)
        index = 1;
      EngineerVisit engineerVisit = engineervisit != null ? engineervisit : (EngineerVisit) jobOfWork.EngineerVisits[index];
      string str1 = string.Empty;
      string lower = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"])).ToLower();
      string str2 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Electrical\\";
      string empty1 = string.Empty;
      bool flag1 = true;
      if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "NCC-EICR".ToLower(), false) == 0))
      {
        string str3 = letter1 ? "NCCTestingLetter1.docx" : "NCCTestingLetter2.docx";
        str1 = str2 + str3;
      }
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "NCC-SURVEY-UPGRADE".ToLower(), false) == 0) || flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "NCC-SURVEY-REWIRE".ToLower(), false) == 0))
      {
        string str3 = letter1 ? "NCCElecMainLetter1.docx" : "NCCElecMainLetter2.docx";
        str1 = str2 + str3;
      }
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "VHT-SMOKE".ToLower(), false) == 0))
        str1 = str2 + "VHTSMOKE.docx";
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "VHT-REMEDIAL".ToLower(), false) == 0))
        str1 = str2 + "VHTRemedial.docx";
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "SHS-REMEDIAL".ToLower(), false) == 0))
        str1 = str2 + "SHSRemedial.docx";
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "FHG-REMEDIAL".ToLower(), false) == 0))
        str1 = str2 + "FHGRemedial.docx";
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "NCC-REMEDIAL".ToLower(), false) == 0))
        str1 = str2 + "NCCRemedial.docx";
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "VHT-EICR".ToLower(), false) == 0))
      {
        string str3 = letter1 ? "VHTTestingLetter1.docx" : "VHTTestingLetter2.docx";
        str1 = str2 + str3;
      }
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "SHS-EICR".ToLower(), false) == 0))
      {
        string str3 = letter1 ? "SHSEicrLetter1.docx" : "SHSEicrLetter2.docx";
        str1 = str2 + str3;
      }
      else if (flag1 == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "FHG-EICR".ToLower(), false) == 0))
      {
        string str3 = letter1 ? "FHGTestingLetter1.docx" : "FHGTestingLetter2.docx";
        str1 = str2 + str3;
      }
      if (string.IsNullOrEmpty(str1))
      {
        string str3 = letter1 ? "NCCTestingLetter1.docx" : "NCCTestingLetter2.docx";
        str1 = str2 + str3;
      }
      bool flag2;
      try
      {
        string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteID"])));
        byte[] buffer = File.ReadAllBytes(str1);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[GoldenRule]", documentGoldenRule);
            string text1 = Microsoft.VisualBasic.Strings.StrConv(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Name"])), VbStrConv.ProperCase, 0).Replace("&", "&amp;").Trim();
            if (text1.Length == 0)
              text1 = "The Occupier";
            PrintHelper.ReplaceText(doc, "[Name]", text1);
            PrintHelper.ReplaceText(doc, "[Address1]", site.Address1);
            PrintHelper.ReplaceText(doc, "[Address2]", site.Address2);
            PrintHelper.ReplaceText(doc, "[Address3]", site.Address3);
            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode((object) site.Postcode));
            PrintHelper.ReplaceText(doc, "[Letter]", DateAndTime.Now.ToLongDateString());
            DateTime dateTime = DateTime.Compare(engineerVisit.StartDateTime, DateTime.MinValue) != 0 ? engineerVisit.StartDateTime : job.DateCreated;
            PrintHelper.ReplaceText(doc, "[Date]", dateTime.ToString("dd MMM yyyy"));
            dr["BookedVisit"] = (object) dateTime;
            string empty2 = string.Empty;
            string text2 = dateTime.Hour < 12 ? "8:00am - 1:00pm" : "12:00pm - 5:30pm";
            if (dateTime.Hour < 12)
              PrintHelper.ReplaceText(doc, "[Time]", text2);
            else
              PrintHelper.ReplaceText(doc, "[Time]", text2);
            PrintHelper.ReplaceText(doc, "[User]", App.loggedInUser.Fullname);
            if (Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"])).Contains("Rewire"))
              PrintHelper.ReplaceText(doc, "[Type]", "electrical rewiring");
            else
              PrintHelper.ReplaceText(doc, "[Type]", "electrical upgrades");
            if (batch != null)
              doc.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
              {
                (OpenXmlElement) new Run(new OpenXmlElement[1]
                {
                  (OpenXmlElement) new Break()
                  {
                    Type = (EnumValue<BreakValues>) BreakValues.Page
                  }
                })
              }), (OpenXmlElement) doc.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
          }
          FSM.Entity.Documentss.Documents oDocuments = new FSM.Entity.Documentss.Documents();
          oDocuments.SetTableEnumID = (object) 47;
          oDocuments.SetRecordID = (object) job.JobID;
          oDocuments.SetDocumentTypeID = (object) 205;
          string path1 = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(47) + "\\" + Conversions.ToString(job.JobID);
          Directory.CreateDirectory(path1);
          string path2 = this.FileCheck(path1 + "\\" + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"])) + (letter1 ? "_L1" : "_L2") + "_" + site.Address1.Replace("\\", "").Replace("/", "") + ".docx");
          FileStream fileStream = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
          oDocuments.SetNotes = (object) "";
          oDocuments.SetLocation = (object) path1;
          oDocuments.SetName = letter1 ? (object) "Letter1" : (object) "Letter2";
          App.DB.Documents.Insert(oDocuments, false);
          ContactAttempt contactAttempt1 = new ContactAttempt();
          ContactAttempt contactAttempt2 = contactAttempt1;
          contactAttempt2.ContactMethedID = 3;
          contactAttempt2.LinkID = 47;
          contactAttempt2.LinkRef = job.JobID;
          contactAttempt2.ContactMade = DateAndTime.Now;
          contactAttempt2.Notes = (letter1 ? "Letter 1" : "Letter 2") + " Generated";
          contactAttempt2.ContactMadeByUserId = App.loggedInUser.UserID;
          App.DB.ContactAttempts.Insert(contactAttempt1);
          if (batch != null)
          {
            MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
            string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
            AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
            memoryStream.Position = 0L;
            using (memoryStream)
              formatImportPart.FeedData((Stream) memoryStream);
            mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
            {
              Id = (StringValue) id
            }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            mainDocumentPart.Document.Save();
          }
          else
            this.wpFilePath = path2;
        }
        flag2 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag2 = false;
        ProjectData.ClearProjectError();
      }
      return flag2;
    }

    private bool GeneratePurchaseOrder(
      Site oSite,
      Warehouse oWarehouse,
      DataTable dt,
      Supplier oSupplier,
      User oUser,
      string poNumber,
      DateTime deadline,
      DataView dvCharges,
      string savePath,
      bool toPdf)
    {
      string path = System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\Invoice\\SupplierPurchaseOrder.docx";
      bool flag;
      try
      {
        byte[] buffer = File.ReadAllBytes(path);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc)
          {
            this.AddCompanyDetails(doc, true, true, false);
            string text1;
            string text2;
            string text3;
            string text4;
            string text5;
            string str1;
            if (oSite != null)
            {
              text1 = oSite.Address1;
              text2 = oSite.Address2;
              text3 = oSite.Address3;
              text4 = oSite.Address4;
              text5 = oSite.Address5;
              str1 = oSite.Postcode;
            }
            else if (oWarehouse != null)
            {
              text1 = oWarehouse.Address1;
              text2 = oWarehouse.Address2;
              text3 = oWarehouse.Address3;
              text4 = oWarehouse.Address4;
              text5 = oWarehouse.Address5;
              str1 = oWarehouse.Postcode;
            }
            else
            {
              text1 = App.TheSystem.Configuration.CompanyName;
              text2 = App.TheSystem.Configuration.CompanyAddres1;
              text3 = App.TheSystem.Configuration.CompanyAddres2;
              text4 = App.TheSystem.Configuration.CompanyAddres3;
              text5 = App.TheSystem.Configuration.CompanyAddres4;
              str1 = App.TheSystem.Configuration.CompanyPostcode;
            }
            PrintHelper.ReplaceText(doc, "[DeliveryAddress1]", text1);
            PrintHelper.ReplaceText(doc, "[DeliveryAddress2]", text2);
            PrintHelper.ReplaceText(doc, "[DeliveryAddress3]", text3);
            PrintHelper.ReplaceText(doc, "[DeliveryAddress4]", text4);
            PrintHelper.ReplaceText(doc, "[DeliveryAddress5]", text5);
            PrintHelper.ReplaceText(doc, "[DeliveryPostcode]", Helper.FormatPostcode((object) str1));
            PrintHelper.ReplaceText(doc, "[Name]", oSupplier.Name);
            PrintHelper.ReplaceText(doc, "[Address1]", oSupplier.Address1);
            PrintHelper.ReplaceText(doc, "[Address2]", oSupplier.Address2);
            PrintHelper.ReplaceText(doc, "[Address3]", oSupplier.Address3);
            PrintHelper.ReplaceText(doc, "[Address4]", oSupplier.Address4);
            PrintHelper.ReplaceText(doc, "[Address5]", oSupplier.Address5);
            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode((object) oSupplier.Postcode));
            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd MMM yyyy"));
            PrintHelper.ReplaceText(doc, "[User]", oUser.Fullname);
            PrintHelper.ReplaceText(doc, "[OrderNumber]", poNumber);
            PrintHelper.ReplaceText(doc, "[DeliveryDueDate]", DateTime.Compare(deadline, DateTime.MinValue) != 0 ? deadline.ToString("dd MMM yyyy") : "N/A");
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Item");
            dt1.Columns.Add("Description");
            dt1.Columns.Add("Number");
            dt1.Columns.Add("Price");
            dt1.Columns.Add("Qty");
            dt1.Columns.Add("Total");
            double num1 = 0.0;
            if (dt != null && dt.Rows.Count > 0)
            {
              int num2 = 1;
              IEnumerator enumerator;
              try
              {
                enumerator = dt.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  DataRow row = dt1.NewRow();
                  row["Item"] = (object) num2;
                  row["Description"] = RuntimeHelpers.GetObjectValue(current["Name"]);
                  row["Number"] = RuntimeHelpers.GetObjectValue(current["Number"]);
                  DataRow dataRow1 = row;
                  double num3 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["BuyPrice"]));
                  string str2 = num3.ToString("C");
                  dataRow1["Price"] = (object) str2;
                  row["Qty"] = RuntimeHelpers.GetObjectValue(current["QuantityOnOrder"]);
                  DataRow dataRow2 = row;
                  num3 = Helper.MakeDoubleValid((object) (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["BuyPrice"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["QuantityOnOrder"]))));
                  string str3 = num3.ToString("C");
                  dataRow2["Total"] = (object) str3;
                  double num4 = num1;
                  num3 = Helper.MakeDoubleValid((object) (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["BuyPrice"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["QuantityOnOrder"]))));
                  double num5 = Conversions.ToDouble(num3.ToString("C"));
                  num1 = num4 + num5;
                  dt1.Rows.Add(row);
                  checked { ++num2; }
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              PrintHelper.AddRowsToTable(doc, "Item", dt1, "Arial", "16", 0);
            }
            PrintHelper.ReplaceText(doc, "[Total]", num1.ToString("C"));
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Type");
            dt2.Columns.Add("Price");
            if (dvCharges != null && dvCharges.Table.Rows.Count > 0)
            {
              IEnumerator enumerator;
              try
              {
                enumerator = dvCharges.Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  DataRow row = dt2.NewRow();
                  row["Type"] = RuntimeHelpers.GetObjectValue(current["ChargeType"]);
                  row["Price"] = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Amount"])).ToString("C");
                  dt2.Rows.Add(row);
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              PrintHelper.AddRowsToTable(doc, "Type", dt2, "Arial", "16", 0);
            }
          }
          savePath = this.FileCheck(savePath);
          FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
          if (toPdf)
            savePath = PrintHelper.ToPdf(savePath, false, false);
          FSM.Entity.Documentss.Documents oDocuments = new FSM.Entity.Documentss.Documents();
          oDocuments.SetTableEnumID = (object) 32;
          oDocuments.SetRecordID = (object) this.OrderID;
          oDocuments.SetDocumentTypeID = (object) 162;
          oDocuments.SetName = (object) Path.GetFileName(savePath);
          oDocuments.SetNotes = (object) "";
          oDocuments.SetLocation = (object) savePath;
          new DocumentsValidator().Validate(oDocuments);
          App.DB.Documents.Insert(oDocuments, true);
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("ERROR : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateJobSheet(EngineerVisit EngineerVisit)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
        JobOfWork jobOfWork = App.DB.JobOfWorks.JobOfWork_Get(EngineerVisit.JobOfWorkID);
        int num = 1;
        Site site = App.DB.Sites.Get((object) anEngineerVisitId.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table1 = this.WordDoc.Tables[2];
        // ISSUE: variable of a compiler-generated type
        Rows rows = table1.Rows;
        object objectValue = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local = ref objectValue;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Row row = rows.Add(ref local);
        row[].Font.Bold = 0;
        row[].Font.Size = 9f;
        row[].Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
        row[].Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
        int Row = checked (num + 1);
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 1)[][] = jobOfWork.PONumber.Length != 0 ? anEngineerVisitId.JobNumber + " / " + jobOfWork.PONumber : anEngineerVisitId.JobNumber;
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 1)[]);
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 3)[][] = site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode((object) site.Postcode);
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 4)[][] = EngineerVisit.NotesToEngineer;
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 5)[][] = EngineerVisit.OutcomeDetails;
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 5)[].Font.Bold = -1;
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 4)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 3)[]);
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table2 = this.WordDoc.Tables[1];
        // ISSUE: reference to a compiler-generated method
        table2.Cell(3, 1)[][] = Helper.MakeStringValid((object) site.Name);
        // ISSUE: reference to a compiler-generated method
        table2.Cell(4, 1)[][] = Helper.MakeStringValid((object) site.Address1);
        // ISSUE: reference to a compiler-generated method
        table2.Cell(5, 1)[][] = Helper.MakeStringValid((object) site.Address2);
        // ISSUE: reference to a compiler-generated method
        table2.Cell(6, 1)[][] = Helper.MakeStringValid((object) site.Address3);
        // ISSUE: reference to a compiler-generated method
        table2.Cell(7, 1)[][] = Helper.MakeStringValid((object) site.Address4);
        // ISSUE: reference to a compiler-generated method
        table2.Cell(8, 1)[][] = Helper.MakeStringValid((object) site.Address5);
        // ISSUE: reference to a compiler-generated method
        table2.Cell(9, 1)[][] = Helper.MakeStringValid((object) Helper.FormatPostcode((object) site.Postcode));
        // ISSUE: reference to a compiler-generated method
        table2.Cell(3, 5)[][] = "";
        // ISSUE: reference to a compiler-generated method
        table2.Cell(5, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) EngineerVisit.StartDateTime, "dd/MM/yyyy");
        // ISSUE: reference to a compiler-generated method
        table2.Cell(7, 5)[][] = Helper.MakeStringValid((object) "");
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(3, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(4, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(5, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(6, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(7, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(8, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(3, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(5, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(7, 5)[]);
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateProforma(Job job, ContractOriginalSite cos)
    {
      bool flag;
      try
      {
        string str = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
        {
          (object) 0
        }, (string[]) null, (System.Type[]) null, (bool[]) null), (object) "JOB", false) ? App.DB.ContractOriginal.Get(cos.ContractID).ContractReference : job.JobNumber;
        int num1 = 1;
        double num2 = 0.0;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table1 = this.WordDoc.Tables[2];
        // ISSUE: variable of a compiler-generated type
        Rows rows1 = table1.Rows;
        object objectValue = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local = ref objectValue;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Row row = rows1.Add(ref local);
        row[].Font.Bold = 0;
        row[].Font.Size = 9f;
        row[].Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
        row[].Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
        int Row = checked (num1 + 1);
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 1)[][] = str;
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 1)[]);
        string Left = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
        {
          (object) 0
        }, (string[]) null, (System.Type[]) null, (bool[]) null)));
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "JOB", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "CONTRACT", false) == 0)
          {
            Site site = App.DB.Sites.Get((object) cos.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, 3)[][] = site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode((object) site.Postcode);
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, 4)[][] = this.details1;
            // ISSUE: reference to a compiler-generated method
            table1.Cell(Row, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDouble(this.details2), "C");
            num2 += Helper.MakeDoubleValid((object) this.details2);
            // ISSUE: reference to a compiler-generated method
            Marshal.ReleaseComObject((object) table1.Cell(Row, 3)[]);
            // ISSUE: reference to a compiler-generated method
            Marshal.ReleaseComObject((object) table1.Cell(Row, 4)[]);
            // ISSUE: reference to a compiler-generated method
            Marshal.ReleaseComObject((object) table1.Cell(Row, 5)[]);
          }
        }
        else
        {
          Site site = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
          // ISSUE: reference to a compiler-generated method
          table1.Cell(Row, 3)[][] = site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode((object) site.Postcode);
          // ISSUE: reference to a compiler-generated method
          table1.Cell(Row, 4)[][] = this.details1;
          // ISSUE: reference to a compiler-generated method
          table1.Cell(Row, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDouble(this.details2), "C");
          // ISSUE: reference to a compiler-generated method
          table1.Cell(Row, 5)[].Font.Bold = -1;
          num2 += Conversions.ToDouble(this.details2);
          // ISSUE: reference to a compiler-generated method
          Marshal.ReleaseComObject((object) table1.Cell(Row, 3)[]);
          // ISSUE: reference to a compiler-generated method
          Marshal.ReleaseComObject((object) table1.Cell(Row, 4)[]);
          // ISSUE: reference to a compiler-generated method
          Marshal.ReleaseComObject((object) table1.Cell(Row, 5)[]);
        }
        Decimal num3 = Decimal.Divide(new Decimal(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
        {
          (object) 4
        }, (string[]) null, (System.Type[]) null, (bool[]) null)))), new Decimal(100L));
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table2 = this.WordDoc.Tables[1];
        // ISSUE: reference to a compiler-generated method
        table2.Cell(1, 1)[][] = Helper.MakeStringValid((object) "PRO-FORMA");
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table3 = this.WordDoc.Tables[3];
        // ISSUE: reference to a compiler-generated method
        table3.Cell(2, 1)[][] = "PRO-FORMA";
        // ISSUE: reference to a compiler-generated method
        table3.Cell(3, 1)[][] = "This is NOT a VAT Invoice";
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table3.Cell(2, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table3.Cell(3, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(1, 1)[]);
        DataTable table4 = App.DB.Invoiced.InvoiceDetails_Get_InvoiceToBeRaisedID(Conversions.ToInteger(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
        {
          (object) 5
        }, (string[]) null, (System.Type[]) null, (bool[]) null))).Table;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table5 = this.WordDoc.Tables[1];
        // ISSUE: reference to a compiler-generated method
        table5.Cell(3, 1)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table4.Rows[0]["SiteName"]));
        // ISSUE: reference to a compiler-generated method
        table5.Cell(4, 1)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table4.Rows[0]["address1"]));
        // ISSUE: reference to a compiler-generated method
        table5.Cell(5, 1)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table4.Rows[0]["address2"]));
        // ISSUE: reference to a compiler-generated method
        table5.Cell(6, 1)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table4.Rows[0]["address3"]));
        // ISSUE: reference to a compiler-generated method
        table5.Cell(7, 1)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table4.Rows[0]["address4"]));
        // ISSUE: reference to a compiler-generated method
        table5.Cell(8, 1)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table4.Rows[0]["address5"]));
        // ISSUE: reference to a compiler-generated method
        table5.Cell(9, 1)[][] = Helper.MakeStringValid((object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(table4.Rows[0]["postcode"])));
        // ISSUE: reference to a compiler-generated method
        table5.Cell(3, 5)[][] = "";
        // ISSUE: reference to a compiler-generated method
        table5.Cell(5, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Today, "dd/MM/yyyy");
        // ISSUE: reference to a compiler-generated method
        table5.Cell(7, 5)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table4.Rows[0]["AccountNumber"]));
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(3, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(4, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(5, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(6, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(7, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(8, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(3, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(5, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(7, 5)[]);
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table6 = this.WordDoc.Tables[3];
        // ISSUE: reference to a compiler-generated method
        table6.Cell(2, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) num2, "C");
        // ISSUE: reference to a compiler-generated method
        table6.Cell(3, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) (num2 * Convert.ToDouble(num3)), "C");
        // ISSUE: reference to a compiler-generated method
        table6.Cell(4, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) (num2 * Convert.ToDouble(num3) + num2), "C");
        // ISSUE: variable of a compiler-generated type
        Rows rows2 = table6.Rows;
        rows2.WrapAroundText = -1;
        rows2.HorizontalPosition = -999998f;
        rows2.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn;
        // ISSUE: reference to a compiler-generated method
        rows2.DistanceLeft = this.MsWordApp.CentimetersToPoints(0.32f);
        // ISSUE: reference to a compiler-generated method
        rows2.DistanceRight = this.MsWordApp.CentimetersToPoints(0.32f);
        rows2.VerticalPosition = -999997f;
        rows2.RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
        // ISSUE: reference to a compiler-generated method
        rows2.DistanceTop = this.MsWordApp.CentimetersToPoints(0.0f);
        // ISSUE: reference to a compiler-generated method
        rows2.DistanceBottom = this.MsWordApp.CentimetersToPoints(0.0f);
        rows2.AllowOverlap = 0;
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table6.Cell(2, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table6.Cell(3, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table6.Cell(4, 5)[]);
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateProformaFromVisit(Job job)
    {
      bool flag;
      try
      {
        string str = "";
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
        {
          (object) 0
        }, (string[]) null, (System.Type[]) null, (bool[]) null), (object) "JOB", false))
          str = job.JobNumber;
        int num1 = 1;
        double num2 = 0.0;
        Site site1 = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        Site site2 = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        if (site1.CustomerID != 787)
          site2 = App.DB.Sites.Get((object) site1.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table1 = this.WordDoc.Tables[2];
        // ISSUE: variable of a compiler-generated type
        Rows rows1 = table1.Rows;
        object objectValue = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local = ref objectValue;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Row row = rows1.Add(ref local);
        row[].Font.Bold = 0;
        row[].Font.Size = 9f;
        row[].Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
        row[].Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
        int Row = checked (num1 + 1);
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 1)[][] = str;
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 1)[]);
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 3)[][] = site1.Address1 + ", " + site1.Address2 + ", " + Helper.FormatPostcode((object) site1.Postcode);
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 4)[][] = this.details1;
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDouble(this.details2), "C");
        // ISSUE: reference to a compiler-generated method
        table1.Cell(Row, 5)[].Font.Bold = -1;
        double num3 = num2 + Conversions.ToDouble(this.details2);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 3)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 4)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table1.Cell(Row, 5)[]);
        FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(site1.CustomerID);
        Decimal num4 = Decimal.Divide(new Decimal(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
        {
          (object) 4
        }, (string[]) null, (System.Type[]) null, (bool[]) null)))), new Decimal(100L));
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table2 = this.WordDoc.Tables[1];
        // ISSUE: reference to a compiler-generated method
        table2.Cell(1, 1)[][] = Helper.MakeStringValid((object) "PRO-FORMA");
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table3 = this.WordDoc.Tables[3];
        // ISSUE: reference to a compiler-generated method
        table3.Cell(2, 1)[][] = "PRO-FORMA";
        // ISSUE: reference to a compiler-generated method
        table3.Cell(3, 1)[][] = "This is NOT a VAT Invoice";
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table3.Cell(2, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table3.Cell(3, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table2.Cell(1, 1)[]);
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table4 = this.WordDoc.Tables[1];
        // ISSUE: reference to a compiler-generated method
        table4.Cell(3, 1)[][] = Helper.MakeStringValid((object) site2.Name);
        // ISSUE: reference to a compiler-generated method
        table4.Cell(4, 1)[][] = Helper.MakeStringValid((object) site2.Address1);
        // ISSUE: reference to a compiler-generated method
        table4.Cell(5, 1)[][] = Helper.MakeStringValid((object) site2.Address2);
        // ISSUE: reference to a compiler-generated method
        table4.Cell(6, 1)[][] = Helper.MakeStringValid((object) site2.Address3);
        // ISSUE: reference to a compiler-generated method
        table4.Cell(7, 1)[][] = Helper.MakeStringValid((object) site2.Address4);
        // ISSUE: reference to a compiler-generated method
        table4.Cell(8, 1)[][] = Helper.MakeStringValid((object) site2.Address5);
        // ISSUE: reference to a compiler-generated method
        table4.Cell(9, 1)[][] = Helper.MakeStringValid((object) Helper.FormatPostcode((object) site2.Postcode));
        // ISSUE: reference to a compiler-generated method
        table4.Cell(3, 5)[][] = "";
        // ISSUE: reference to a compiler-generated method
        table4.Cell(5, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Today, "dd/MM/yyyy");
        // ISSUE: reference to a compiler-generated method
        table4.Cell(7, 5)[][] = Helper.MakeStringValid((object) customer.AccountNumber);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(3, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(4, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(5, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(6, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(7, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(8, 1)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(3, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(5, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table4.Cell(7, 5)[]);
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table5 = this.WordDoc.Tables[3];
        // ISSUE: reference to a compiler-generated method
        table5.Cell(2, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) num3, "C");
        // ISSUE: reference to a compiler-generated method
        table5.Cell(3, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) (num3 * Convert.ToDouble(num4)), "C");
        // ISSUE: reference to a compiler-generated method
        table5.Cell(4, 5)[][] = Microsoft.VisualBasic.Strings.Format((object) (num3 * Convert.ToDouble(num4) + num3), "C");
        // ISSUE: variable of a compiler-generated type
        Rows rows2 = table5.Rows;
        rows2.WrapAroundText = -1;
        rows2.HorizontalPosition = -999998f;
        rows2.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionColumn;
        // ISSUE: reference to a compiler-generated method
        rows2.DistanceLeft = this.MsWordApp.CentimetersToPoints(0.32f);
        // ISSUE: reference to a compiler-generated method
        rows2.DistanceRight = this.MsWordApp.CentimetersToPoints(0.32f);
        rows2.VerticalPosition = -999997f;
        rows2.RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
        // ISSUE: reference to a compiler-generated method
        rows2.DistanceTop = this.MsWordApp.CentimetersToPoints(0.0f);
        // ISSUE: reference to a compiler-generated method
        rows2.DistanceBottom = this.MsWordApp.CentimetersToPoints(0.0f);
        rows2.AllowOverlap = 0;
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(2, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(3, 5)[]);
        // ISSUE: reference to a compiler-generated method
        Marshal.ReleaseComObject((object) table5.Cell(4, 5)[]);
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool QCPrint()
    {
      switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
      {
        (object) 1
      }, (string[]) null))))
      {
        case 69318:
          // ISSUE: variable of a compiler-generated type
          Microsoft.Office.Interop.Word.Documents documents1 = this.MsWordApp.Documents;
          object obj1 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\WIP Audit Domestic Gas Work.dot");
          ref object local1 = ref obj1;
          object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local2 = ref objectValue1;
          object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local3 = ref objectValue2;
          object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local4 = ref objectValue3;
          // ISSUE: reference to a compiler-generated method
          this.WordDoc = documents1.Add(ref local1, ref local2, ref local3, ref local4);
          break;
        case 69319:
          // ISSUE: variable of a compiler-generated type
          Microsoft.Office.Interop.Word.Documents documents2 = this.MsWordApp.Documents;
          object obj2 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\Post Complete Audit Domestic Work.dot");
          ref object local5 = ref obj2;
          object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local6 = ref objectValue4;
          object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local7 = ref objectValue5;
          object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local8 = ref objectValue6;
          // ISSUE: reference to a compiler-generated method
          this.WordDoc = documents2.Add(ref local5, ref local6, ref local7, ref local8);
          break;
        case 69473:
          // ISSUE: variable of a compiler-generated type
          Microsoft.Office.Interop.Word.Documents documents3 = this.MsWordApp.Documents;
          object obj3 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\WIP Audit Domestic Oil Work.dot");
          ref object local9 = ref obj3;
          object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local10 = ref objectValue7;
          object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local11 = ref objectValue8;
          object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local12 = ref objectValue9;
          // ISSUE: reference to a compiler-generated method
          this.WordDoc = documents3.Add(ref local9, ref local10, ref local11, ref local12);
          break;
        case 69592:
          // ISSUE: variable of a compiler-generated type
          Microsoft.Office.Interop.Word.Documents documents4 = this.MsWordApp.Documents;
          object obj4 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\WIP Audit Commercial Gas Work.dot");
          ref object local13 = ref obj4;
          object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local14 = ref objectValue10;
          object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local15 = ref objectValue11;
          object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local16 = ref objectValue12;
          // ISSUE: reference to a compiler-generated method
          this.WordDoc = documents4.Add(ref local13, ref local14, ref local15, ref local16);
          break;
        case 71484:
          // ISSUE: variable of a compiler-generated type
          Microsoft.Office.Interop.Word.Documents documents5 = this.MsWordApp.Documents;
          object obj5 = (object) (System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\ElectricalQC.dot");
          ref object local17 = ref obj5;
          object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local18 = ref objectValue13;
          object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local19 = ref objectValue14;
          object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local20 = ref objectValue15;
          // ISSUE: reference to a compiler-generated method
          this.WordDoc = documents5.Add(ref local17, ref local18, ref local19, ref local20);
          break;
      }
      EngineerVisitAdditional forEngineerVisit = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(Conversions.ToInteger(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
      {
        (object) 0
      }, (string[]) null)), Conversions.ToInteger(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
      {
        (object) 1
      }, (string[]) null)));
      if (forEngineerVisit.Test125 == 0)
        forEngineerVisit.SetTest125 = (object) 53;
      Engineer engineer1 = App.DB.Engineer.Engineer_Get(forEngineerVisit.Test125);
      DataTable table = App.DB.EngineerVisits.EngineerVisits_Get(Conversions.ToInteger(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
      {
        (object) 0
      }, (string[]) null))).Table;
      Engineer engineer2 = App.DB.Engineer.Engineer_Get(Conversions.ToInteger(table.AsEnumerable().ElementAtOrDefault<DataRow>(0)["EngineerID"]));
      Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
      {
        (object) 0
      }, (string[]) null)), SiteSQL.GetBy.EngineerVisitId, (object) null);
      App.DB.Job.Job_Get_For_An_EngineerVisit_ID(Conversions.ToInteger(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
      {
        (object) 0
      }, (string[]) null)));
      FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(site.CustomerID);
      bool flag;
      try
      {
        IEnumerator enumerator;
        try
        {
          enumerator = Printing.GetTemplateFields(this.WordDoc.Content[]).GetEnumerator();
          while (enumerator.MoveNext())
          {
            Match current = (Match) enumerator.Current;
            string lower = current.Value.ToLower();
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document wordDoc;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Client]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) customer.Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[UPRN]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) site.PolicyNumber));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Project]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test1).Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) (site.Address1 + ", " + site.Address2 + ", " + site.Address3 + ", " + site.Postcode)));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Type]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(forEngineerVisit.Test237)).Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[eng]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) engineer1.Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[ename]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) engineer1.Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[CompletedBy]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) engineer1.Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[aname]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) engineer2.Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[QCBy]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) engineer2.Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[sum]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table.AsEnumerable().ElementAtOrDefault<DataRow>(0)["OutcomeDetails"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[jn]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) forEngineerVisit.Test238));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[gs]".ToLower(), false) == 0)
            {
              if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
              {
                (object) 1
              }, (string[]) null), (object) 69473, false), (object) (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(site.SiteFuel, "Oil", false) == 0))))
              {
                wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) engineer1.OftecNo));
                this.WordDoc = wordDoc;
              }
              else
              {
                wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) engineer1.GasSafeNo));
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[date]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(table.AsEnumerable().ElementAtOrDefault<DataRow>(0)["StartDateTime"]), "dd/MM/yyyy")));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[date2]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(table.AsEnumerable().ElementAtOrDefault<DataRow>(0)["StartDateTime"]), "dd/MM/yyyy")));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[outcome]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test124).Name));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[add]".ToLower(), false) == 0)
            {
              string str = site.Address1 + ", \r\n" + site.Address2 + ", \r\n" + Helper.FormatPostcode((object) site.Postcode);
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid((object) str));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Make]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test235);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Model]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test236);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[1]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test1).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[2]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test2).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[3]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test3).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[4]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test4).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[5]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test5).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[6]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test6).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[7]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test7).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[8]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test8).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[9]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test9).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[10]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test10).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[1a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test111).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[2a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test2).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[3a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test3).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[4a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test4).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[5a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test5).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[6a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test6).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[7a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test7).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[8a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test8).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[9a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test9).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[10a]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test10).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[11]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test111).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[12]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test112).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[13]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test113).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[14]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test114).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[15]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test115).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[16]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test116).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[17]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test117).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[18]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test118).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[19]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test119).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[20]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test120).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[21]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test121).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[22]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test122).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[23]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test123).Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c1]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test11);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c2]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test12);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c3]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test13);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c4]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test14);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c5]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test15);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c6]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test216);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c7]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test217);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c8]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test218);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c9]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test219);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c10]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test220);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c11]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test221);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c12]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test222);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c13]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test223);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c14]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test224);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c15]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test225);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c16]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test226);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c17]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test227);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c18]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test228);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c19]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test229);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c20]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test230);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c21]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test231);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c22]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test232);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[c23]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, forEngineerVisit.Test233);
              this.WordDoc = wordDoc;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        object objectValue16;
        if (table.AsEnumerable().ElementAtOrDefault<DataRow>(0)["EngineerSignature"] != null)
        {
          new Bitmap((Stream) new MemoryStream((byte[]) table.AsEnumerable().ElementAtOrDefault<DataRow>(0)["EngineerSignature"])).Save(System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.bmp");
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
          {
            (object) 1
          }, (string[]) null), (object) 71484, false))
          {
            // ISSUE: variable of a compiler-generated type
            Bookmarks bookmarks = this.WordDoc.Bookmarks;
            object obj6 = (object) "asig";
            ref object local21 = ref obj6;
            // ISSUE: variable of a compiler-generated type
            InlineShapes inlineShapes = bookmarks[ref local21].Range.InlineShapes;
            string FileName = System.Windows.Forms.Application.StartupPath + "\\Temp\\EngSig.bmp";
            objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local22 = ref objectValue16;
            object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local23 = ref objectValue17;
            object objectValue18 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local24 = ref objectValue18;
            // ISSUE: reference to a compiler-generated method
            inlineShapes.AddPicture(FileName, ref local22, ref local23, ref local24);
          }
        }
        if (table.AsEnumerable().ElementAtOrDefault<DataRow>(0)["CustomerSignature"] != null)
        {
          new Bitmap((Stream) new MemoryStream((byte[]) table.AsEnumerable().ElementAtOrDefault<DataRow>(0)["CustomerSignature"])).Save(System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.bmp");
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
          {
            (object) 1
          }, (string[]) null), (object) 71484, false))
          {
            // ISSUE: variable of a compiler-generated type
            Bookmarks bookmarks = this.WordDoc.Bookmarks;
            object obj6 = (object) "esig";
            ref object local21 = ref obj6;
            // ISSUE: variable of a compiler-generated type
            InlineShapes inlineShapes = bookmarks[ref local21].Range.InlineShapes;
            string FileName = System.Windows.Forms.Application.StartupPath + "\\Temp\\CustSig.bmp";
            object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local22 = ref objectValue17;
            object objectValue18 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local23 = ref objectValue18;
            objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local24 = ref objectValue16;
            // ISSUE: reference to a compiler-generated method
            inlineShapes.AddPicture(FileName, ref local22, ref local23, ref local24);
          }
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateContractExpiry(DataRow dr, int tblIndex)
    {
      bool flag;
      try
      {
        IEnumerator enumerator;
        try
        {
          enumerator = Printing.GetTemplateFields(this.WordDoc.Content[]).GetEnumerator();
          while (enumerator.MoveNext())
          {
            Match current = (Match) enumerator.Current;
            string lower = current.Value.ToLower();
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document wordDoc;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address1]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address1"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address2]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address2"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address3]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address3"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address4]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address4"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address5]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Address5"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Postcode]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["Postcode"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Date]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "dd/MM/yyyy"));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[CompanyName]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Name"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[ExpiryDate]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractEndDate"])), "dd/MM/yyyy"));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[user]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.loggedInUser.Fullname);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[ContractType]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractType"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[ContractReference]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[SiteAddress1]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["SiteAddress1"])));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[PriceSentence]".ToLower(), false) == 0)
            {
              string singleDescription = App.DB.Picklists.Get_Single_Description(Conversions.ToString(dr["ContractType"]), Enums.PickListTypes.ContractPricing);
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, singleDescription);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[ExcludeSentence]".ToLower(), false) == 0)
            {
              string NewText = "";
              if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dr["ContractType"], (object) "Gold Star", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dr["ContractType"], (object) "Platinum Star", false))))
                NewText = "Please be advised that we are now offering cover for boilermates or any other make of thermal store product as an additional appliance. Should you have a thermal store product";
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[ExcludeSentence2]".ToLower(), false) == 0)
            {
              string NewText = "";
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["ContractType"], (object) "Gold Star", false))
                NewText = " in your property and require cover, this could be added for an additional " + Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", Enums.PickListTypes.ContractPricing)), "C") + " per annum.";
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr["ContractType"], (object) "Platinum Star", false))
                NewText = " in your property and require cover, this could be added for an additional " + Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing)), "C") + " per annum.";
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[AHE]".ToLower(), false) == 0)
            {
              string singleDescription = App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing);
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, singleDescription);
              this.WordDoc = wordDoc;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Table table = this.WordDoc.Tables[tblIndex];
        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dr["DirectDebit"])))
        {
          // ISSUE: reference to a compiler-generated method
          // ISSUE: variable of a compiler-generated type
          Cell cell = table.Cell(2, 1);
          object objectValue = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local = ref objectValue;
          // ISSUE: reference to a compiler-generated method
          cell.Delete(ref local);
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          // ISSUE: variable of a compiler-generated type
          Cell cell = table.Cell(1, 1);
          object objectValue = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local = ref objectValue;
          // ISSUE: reference to a compiler-generated method
          cell.Delete(ref local);
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateDomesticGSRDue(
      DataRow[] dr,
      DataTable dtPrinted,
      string savePath,
      WordprocessingDocument batch = null)
    {
      bool flag;
      try
      {
        string str = System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\GSRDue.docx";
        string documentGoldenRule = this.GetDocumentGoldenRule(str, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr[0]["SiteID"])));
        byte[] buffer = File.ReadAllBytes(str);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc1)
          {
            if (App.DB.ContractOriginal.Get_Current_ForSite(Conversions.ToInteger(dr[0]["SiteID"])) == null)
            {
              PrintHelper.DeleteBookmark(doc1, "OnContract1");
              PrintHelper.DeleteBookmark(doc1, "StarMainMessage");
              DataView forSite = App.DB.Asset.Asset_GetForSite(Conversions.ToInteger(dr[0]["SiteID"]));
              DataTable dt = new DataTable();
              dt.Columns.Add("Appliance");
              IEnumerator enumerator;
              try
              {
                enumerator = forSite.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRowView current = (DataRowView) enumerator.Current;
                  if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Active"])))
                  {
                    DataRow row = dt.NewRow();
                    row["Appliance"] = RuntimeHelpers.GetObjectValue(current["Product"]);
                    dt.Rows.Add(row);
                  }
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              PrintHelper.ReplaceText(doc1, "[GoldenRule]", documentGoldenRule);
              if (dt.Rows.Count > 0)
                PrintHelper.ReplaceBookmarkWithTable(doc1, "ApplianceTable", dt, false);
              PrintHelper.ReplaceText(doc1, "[ContractCover]", "If you would like us to carry out your annual service and/or to discuss our Maintenance Cover further, please call us on 01603 309599.");
            }
            else
            {
              DataView allSiteId = App.DB.ContractOriginal.ContractOriginalSiteAsset_GetAll_SiteID(Conversions.ToInteger(dr[0]["SiteID"]));
              DataTable dt = new DataTable();
              dt.Columns.Add("Appliance");
              IEnumerator enumerator;
              try
              {
                enumerator = allSiteId.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRowView current = (DataRowView) enumerator.Current;
                  DataRow row = dt.NewRow();
                  row["Appliance"] = RuntimeHelpers.GetObjectValue(current["Appliance"]);
                  dt.Rows.Add(row);
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              if (dt.Rows.Count > 0)
                PrintHelper.ReplaceBookmarkWithTable(doc1, "ApplianceTable", dt, false);
              PrintHelper.DeleteBookmark(doc1, "OffContract1");
              PrintHelper.DeleteBookmark(doc1, "OffContract2");
              PrintHelper.DeleteBookmark(doc1, "OffContract3");
              PrintHelper.DeleteBookmark(doc1, "OffContract4");
              PrintHelper.DeleteBookmark(doc1, "OffContract5");
              PrintHelper.DeleteBookmark(doc1, "OffContract6");
              PrintHelper.DeleteBookmark(doc1, "OffContract7");
              PrintHelper.ReplaceText(doc1, "[ContractCover]", "If you would like us to carry out your annual service please call us on 01603 309590.");
            }
            PrintHelper.ReplaceText(doc1, "[Tenant]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr[0]["Tenant"])));
            PrintHelper.ReplaceText(doc1, "[Address1]", Conversions.ToString(dr[0]["Address1"]));
            PrintHelper.ReplaceText(doc1, "[Address2]", Conversions.ToString(dr[0]["Address2"]));
            PrintHelper.ReplaceText(doc1, "[Address3]", Conversions.ToString(dr[0]["Address3"]));
            PrintHelper.ReplaceText(doc1, "[Postcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr[0]["Postcode"])));
            WordprocessingDocument doc2 = doc1;
            DateTime dateTime = DateAndTime.Now;
            string shortDateString = dateTime.ToShortDateString();
            PrintHelper.ReplaceText(doc2, "[Date]", shortDateString);
            WordprocessingDocument doc3 = doc1;
            dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr[0]["VisitDate"]));
            string text = Microsoft.VisualBasic.Strings.Format((object) dateTime.AddYears(1), "dd/MM/yyyy");
            PrintHelper.ReplaceText(doc3, "[NextServiceDate]", text);
            doc1.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
            {
              (OpenXmlElement) new Run(new OpenXmlElement[1]
              {
                (OpenXmlElement) new Break()
                {
                  Type = (EnumValue<BreakValues>) BreakValues.Page
                }
              })
            }), (OpenXmlElement) doc1.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            doc1.MainDocumentPart.Document.Save();
          }
          savePath = this.FileCheck(savePath);
          FileStream fileStream = new FileStream(savePath, FileMode.CreateNew);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
          DataRow[] dataRowArray = dr;
          int index = 0;
          while (index < dataRowArray.Length)
          {
            DataRow dataRow = dataRowArray[index];
            DataRow row = dtPrinted.NewRow();
            row["AssetID"] = RuntimeHelpers.GetObjectValue(dataRow["AssetID"]);
            row["DateDue"] = RuntimeHelpers.GetObjectValue(dataRow["DueDate"]);
            dtPrinted.Rows.Add(row);
            checked { ++index; }
          }
          if (batch != null)
          {
            MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
            string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr[0]["SiteID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
            AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
            memoryStream.Position = 0L;
            using (memoryStream)
              formatImportPart.FeedData((Stream) memoryStream);
            mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
            {
              Id = (StringValue) id
            }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            mainDocumentPart.Document.Save();
          }
          else
            Process.Start(savePath);
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateLLGSRDue(
      DataRow[] dr,
      DataTable dtPrinted,
      string savePath,
      WordprocessingDocument batch = null)
    {
      bool flag;
      try
      {
        string str1 = System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\GSRDueLL.docx";
        string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr[0]["SiteID"])));
        byte[] buffer = File.ReadAllBytes(str1);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc1)
          {
            DataTable dt = new DataTable();
            dt.Columns.Add("Property");
            dt.Columns.Add("Service Due Date");
            dt.Columns.Add("Appliance");
            int num = 0;
            DataRow[] dataRowArray = dr;
            int index = 0;
            DateTime dateTime;
            while (index < dataRowArray.Length)
            {
              DataRow dataRow1 = dataRowArray[index];
              DataRow row = dt.NewRow();
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual((object) num, dataRow1["SiteID"], false))
                row["Property"] = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow1["Tenant"], (object) ", "), dataRow1["Address1"]), (object) ", "), dataRow1["Address2"]), (object) ", "), (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow1["Postcode"])));
              DataRow dataRow2 = row;
              dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow1["DueDate"]));
              string str2 = Microsoft.VisualBasic.Strings.Format((object) dateTime.AddYears(1), "dd-MMM-yyyy");
              dataRow2["Service Due Date"] = (object) str2;
              row["Appliance"] = RuntimeHelpers.GetObjectValue(dataRow1["Appliance"]);
              dt.Rows.Add(row);
              num = Conversions.ToInteger(dataRow1["SiteID"]);
              checked { ++index; }
            }
            PrintHelper.ReplaceBookmarkWithTable(doc1, "SitesAndAppliances", dt, false);
            Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(dr[0]["CustomerID"]), SiteSQL.GetBy.CustomerHq, (object) null);
            if (site == null)
            {
              flag = false;
              goto label_35;
            }
            else
            {
              PrintHelper.ReplaceText(doc1, "[GoldenRule]", documentGoldenRule);
              PrintHelper.ReplaceText(doc1, "[CustomerName]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr[0]["CustomerName"])));
              PrintHelper.ReplaceText(doc1, "[Address1]", site.Address1);
              PrintHelper.ReplaceText(doc1, "[Address2]", site.Address2);
              PrintHelper.ReplaceText(doc1, "[Address3]", site.Address3);
              PrintHelper.ReplaceText(doc1, "[Postcode]", Helper.FormatPostcode((object) site.Postcode));
              WordprocessingDocument doc2 = doc1;
              dateTime = DateAndTime.Now;
              string shortDateString = dateTime.ToShortDateString();
              PrintHelper.ReplaceText(doc2, "[Date]", shortDateString);
              doc1.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
              {
                (OpenXmlElement) new Run(new OpenXmlElement[1]
                {
                  (OpenXmlElement) new Break()
                  {
                    Type = (EnumValue<BreakValues>) BreakValues.Page
                  }
                })
              }), (OpenXmlElement) doc1.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
              doc1.MainDocumentPart.Document.Save();
            }
          }
          savePath = this.FileCheck(savePath);
          FileStream fileStream = new FileStream(savePath, FileMode.CreateNew);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
          DataRow[] dataRowArray1 = dr;
          int index1 = 0;
          while (index1 < dataRowArray1.Length)
          {
            DataRow dataRow = dataRowArray1[index1];
            DataRow row = dtPrinted.NewRow();
            row["AssetID"] = RuntimeHelpers.GetObjectValue(dataRow["AssetID"]);
            row["DateDue"] = RuntimeHelpers.GetObjectValue(dataRow["DueDate"]);
            dtPrinted.Rows.Add(row);
            checked { ++index1; }
          }
          if (batch != null)
          {
            MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
            string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr[0]["SiteID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
            AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
            memoryStream.Position = 0L;
            using (memoryStream)
              formatImportPart.FeedData((Stream) memoryStream);
            mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
            {
              Id = (StringValue) id
            }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            mainDocumentPart.Document.Save();
          }
          else
            Process.Start(savePath);
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
label_35:
      return flag;
    }

    private bool GSR(
      EngineerVisit oEngineerVisit,
      Site oSite,
      DataView dvFaults,
      bool printHeader,
      DataView GSRS,
      string template,
      string savePath,
      Enums.WorksheetFuelTypes Fuel,
      string goldenRule,
      List<byte[]> fullDocument = null,
      bool NCCTemplate = false)
    {
      bool flag1;
      try
      {
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        int index = 100;
        Site oSiteHq = App.DB.Sites.Get((object) oSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        DateTime dateTime1 = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(dateTime1, DateTime.MinValue) == 0)
          dateTime1 = oEngineerVisit.ManualEntryOn;
        int num1;
        switch (Fuel)
        {
          case Enums.WorksheetFuelTypes.Oil:
            num1 = 1;
            break;
          case Enums.WorksheetFuelTypes.Unvented:
            num1 = 12;
            break;
          default:
            num1 = 4;
            break;
        }
        int num2 = new List<int>()
        {
          checked ((int) Math.Ceiling(unchecked ((double) GSRS.Table.Rows.Count / (double) num1)))
        }.Max();
        if (num2 < 1)
          num2 = 1;
        try
        {
          int num3 = num2;
          int num4 = 1;
          while (num4 <= num3)
          {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            Printing._Closure\u0024__64\u002D0 closure640 = new Printing._Closure\u0024__64\u002D0(closure640);
            // ISSUE: reference to a compiler-generated field
            closure640.\u0024VB\u0024Local_lowAppIndex = checked (num4 * num1 - num1);
            // ISSUE: reference to a compiler-generated field
            closure640.\u0024VB\u0024Local_highAppIndex = checked (num4 * num1);
            byte[] buffer1 = File.ReadAllBytes(template);
            MemoryStream memoryStream = new MemoryStream();
            using (memoryStream)
            {
              memoryStream.Write(buffer1, 0, buffer1.Length);
              WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open((Stream) memoryStream, true);
              using (wordprocessingDocument)
              {
                PrintHelper.ReplaceText(wordprocessingDocument, "[GoldenRule]", goldenRule);
                if (engineer == null)
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "GasSafeIDNo", "", "7", false);
                else if (Fuel == Enums.WorksheetFuelTypes.Oil)
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "GasSafeIDNo", engineer.OftecNo, "7", false);
                else
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "GasSafeIDNo", engineer.GasSafeNo, "7", false);
                string text1 = Conversions.ToString(oEngineerVisit.EngineerVisitID) + "_" + DateAndTime.Now.ToString("ddMMyyyyhhmm") + "_" + Fuel.ToString().ToUpper();
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobSiteName", oSite.Name.Replace("T1", "").Trim(), "8", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobAddress1", oSite.Address1, "8", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobAddress2", oSite.Address2, "8", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobAddress3", oSite.Address3, "8", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobPostCode", Helper.FormatPostcode((object) oSite.Postcode), "8", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "VisitDate", text1, "6", true);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "VisitDate1", dateTime1.ToLongDateString(), "7", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "VisitDate2", dateTime1.ToLongDateString(), "7", false);
                this.AddCompanyDetails(wordprocessingDocument, true, false, false);
                if (oEngineerVisit.GasServiceCompleted & oEngineerVisit.OutcomeEnumID != 1)
                {
                  FSM.Entity.Customers.Customer forSiteId = App.DB.Customer.Customer_Get_ForSiteID(oSite.SiteID);
                  bool flag2 = false;
                  if (forSiteId != null && forSiteId.MOTStyleService)
                    flag2 = true;
                  DateTime dateTime2 = DateTime.Compare(oEngineerVisit.StartDateTime, DateTime.MinValue) != 0 ? oEngineerVisit.StartDateTime : (oEngineerVisit.TimeSheets.Table.Rows.Count <= 0 ? DateAndTime.Now : Conversions.ToDate(oEngineerVisit.TimeSheets.Table.Rows[0]["StartDateTime"]));
                  DateTime minValue1 = DateTime.MinValue;
                  DateTime minValue2 = DateTime.MinValue;
                  DateTime dateTime3 = Helper.MakeDateTimeValid((object) oSite.LastServiceDate);
                  int num5 = checked ((int) DateAndTime.DateDiff(DateInterval.Month, dateTime2, dateTime3.AddYears(1), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1));
                  DateTime dateTime4 = !(DateTime.Compare(dateTime3.AddYears(1), dateTime2) > 0 & num5 >= 0 & num5 <= 2 & flag2) ? dateTime2 : dateTime3.AddYears(1);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "NextServiceDue", dateTime4.AddYears(1).ToLongDateString(), "7", false);
                }
                else if (oEngineerVisit.GasServiceCompleted & oEngineerVisit.OutcomeEnumID == 1 & oEngineerVisit.VisitLocked)
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "NextServiceDue", oSite.LastServiceDate.AddYears(1).ToLongDateString(), "7", false);
                else
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "NextServiceDue", dateTime1.AddYears(1).ToLongDateString(), "7", false);
                PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.SignatureSelectedID);
                if (oneAsObject1 == null)
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobCustomerName", oEngineerVisit.CustomerName, "7", false);
                else
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobCustomerName", oEngineerVisit.CustomerName + " (" + oneAsObject1.Name + ")", "7", false);
                if (oSiteHq != null)
                {
                  string text2 = string.Empty;
                  if (oSiteHq.Address1.Length > 0)
                    text2 = text2 + oSiteHq.Address1 + ", ";
                  if (oSiteHq.Address2.Length > 0)
                    text2 = text2 + oSiteHq.Address2 + ", ";
                  if (text2.Length > 0)
                    text2 = text2.Substring(0, checked (text2.Length - 2));
                  string text3 = string.Empty;
                  if (oSiteHq.Address3.Length > 0)
                    text3 = text3 + oSiteHq.Address3 + ", ";
                  if (oSiteHq.Address4.Length > 0)
                    text3 = text3 + oSiteHq.Address4 + ", ";
                  if (oSiteHq.Address5.Length > 0)
                    text3 = text3 + oSiteHq.Address5 + ", ";
                  if (text2.Length > 0 & text3.Length > 1)
                    text3 = text3.Substring(0, checked (text3.Length - 2));
                  string text4 = oSiteHq.CustomerID != 787 ? App.DB.Customer.Customer_Get(oSite.CustomerID).Name : "";
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LandLordName", text4, "8", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LandLordAddress1", text2, "8", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LandLordAddress2", text3, "8", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LLPostcode", Helper.FormatPostcode((object) oSiteHq.Postcode), "8", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LLTelNo", oSiteHq.TelephoneNum, "8", false);
                }
                else
                {
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LandLordName", "", "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LandLordAddress1", "", "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LandLordAddress2", "", "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LLPostcode", "", "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "LLTelNo", "", "7", false);
                }
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.PropertyRented);
                if (oneAsObject2 == null)
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Rented", "", "7", false);
                else
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Rented", oneAsObject2.Name, "8", false);
                if (engineer == null)
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Engineer", "", "7", false);
                else
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Engineer", engineer.Name, "7", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "CustomerName", oEngineerVisit.CustomerName, "7", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "OtherNotes", oEngineerVisit.OutcomeDetails, "7", false);
                switch (Fuel)
                {
                  case Enums.WorksheetFuelTypes.Gas:
                  case Enums.WorksheetFuelTypes.Oil:
                  case Enums.WorksheetFuelTypes.Unvented:
                  case Enums.WorksheetFuelTypes.Other:
                    if (GSRS.Table.Rows.Count == 0)
                    {
                      PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "NoOfAppliances", "0", "8", false);
                      break;
                    }
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "NoOfAppliances", Conversions.ToString(GSRS.Table.Select("ApplianceTested='Yes'").Length), "8", false);
                    break;
                  default:
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "NoOfAppliances", Conversions.ToString(GSRS.Table.Rows.Count), "8", false);
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "NumInspected", Conversions.ToString(GSRS.Table.Rows.Count), "8", false);
                    break;
                }
                DataView forVisitDvProper1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(oEngineerVisit.EngineerVisitID, 68650);
                DataView forVisitDvProper2 = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(oEngineerVisit.EngineerVisitID, 68649);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "COMO", forVisitDvProper1.Count.ToString(), "7", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "SMOKE", forVisitDvProper2.Count.ToString(), "7", false);
                if (Fuel == Enums.WorksheetFuelTypes.Gas)
                {
                  PickList oneAsObject3 = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.EmergencyControlAccessibleID);
                  if (oneAsObject3 == null)
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "ECV", "", "7", false);
                  else
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "ECV", oneAsObject3.Name, "7", false);
                  PickList oneAsObject4 = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.GasInstallationTightnessTestID);
                  if (oneAsObject4 == null)
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "tightest", "", "7", false);
                  else
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "tightest", oneAsObject4.Name, "7", false);
                  PickList oneAsObject5 = App.DB.Picklists.Get_One_As_Object(oEngineerVisit.BondingID);
                  if (oneAsObject5 == null)
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Bonding", "", "7", false);
                  else
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Bonding", oneAsObject5.Name, "7", false);
                }
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "WorkCarriedOut", oEngineerVisit.OutcomeDetails, "7", false);
                PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobVisitNumber", Conversions.ToString(oEngineerVisit.EngineerVisitID), "9", true);
                if (oEngineerVisit.EngineerSignature == null)
                {
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "EngineerSignature", "", "7", false);
                }
                else
                {
                  Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature));
                  string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
                  if (Fuel == Enums.WorksheetFuelTypes.Unvented)
                  {
                    PrintHelper.ReplaceBookmarkWithImage(wordprocessingDocument, "AJ", img, savePath1, index, false);
                    checked { ++index; }
                  }
                  else
                  {
                    PrintHelper.ReplaceBookmarkWithImage(wordprocessingDocument, "EngineerSignature", img, savePath1, index, false);
                    checked { ++index; }
                  }
                }
                if (oEngineerVisit.CustomerSignature == null)
                {
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "CustomerSignature", "", "7", false);
                }
                else
                {
                  Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature));
                  string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
                  PrintHelper.ReplaceBookmarkWithImage(wordprocessingDocument, "CustomerSignature", img, savePath1, index, false);
                  checked { ++index; }
                }
                if (GSRS.Table.Rows.Count == 0 || Information.IsDBNull(RuntimeHelpers.GetObjectValue(GSRS.Table.Rows[0]["ReadingType"])))
                {
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "GasSafe", "7939", "7", false);
                }
                else
                {
                  switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(GSRS.Table.Rows[0]["ReadingType"])))
                  {
                    case 0:
                      PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "GasSafe", "7939", "7", false);
                      break;
                    case 2:
                      PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "GasSafe", "6102", "7", false);
                      break;
                  }
                }
                byte[] buffer2;
                try
                {
                  buffer2 = (byte[]) App.DB.ExecuteScalar("Select Logo FROM tblCustomer where CustomerID = " + Conversions.ToString(oSite.CustomerID), true, false);
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  buffer2 = (byte[]) null;
                  ProjectData.ClearProjectError();
                }
                if (buffer2 != null)
                {
                  Bitmap img = new Bitmap((Stream) new MemoryStream(buffer2));
                  string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\custLogo.jpg";
                  PrintHelper.ReplaceBookmarkWithImage(wordprocessingDocument, "Logo", img, savePath1, index, false);
                  checked { ++index; }
                }
                else
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Logo", "", "7", false);
                if (NCCTemplate)
                {
                  if (oSite.LeaseHold)
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Tenant", "Leaseholder", "8", false);
                  else
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Tenant", "Tenanted", "8", false);
                }
                if (oEngineerVisit.EngineerVisitNCCGSR != null)
                {
                  DataView friendly = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_Get_Friendly(oEngineerVisit.EngineerVisitNCCGSR.EngineerVisitNCCGSRID);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Rad", Conversions.ToString(oEngineerVisit.EngineerVisitNCCGSR.Radiators), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Age", Conversions.ToString(oEngineerVisit.EngineerVisitNCCGSR.ApproxAgeOfBoiler), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Info1", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CorrectMaterialsUsed"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Info2", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["InstallationPipeWorkCorrect"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Info3", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["InstallationSafeToUse"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "SF", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["StrainerFitted"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "SI", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["StrainerInspected"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "HST", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["HeatingSystemType"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "PH", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["PartialHeating"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "CT", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CylinderType"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Jack", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Jacket"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "Im", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Immersion"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "CO", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CODetectorFitted"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "FL", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["FillDisc"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "SIT", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SITimer"])), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "CertType", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CertificateType"])), "7", false);
                }
                if (Fuel != Enums.WorksheetFuelTypes.Unvented)
                {
                  // ISSUE: object of a compiler-generated type is created
                  // ISSUE: variable of a compiler-generated type
                  Printing._Closure\u0024__64\u002D2 closure642 = new Printing._Closure\u0024__64\u002D2(closure642);
                  DataTable dataTable1;
                  try
                  {
                    // ISSUE: reference to a compiler-generated method
                    dataTable1 = GSRS.Table.AsEnumerable().Where<DataRow>(new Func<DataRow, int, bool>(closure640._Lambda\u0024__0)).CopyToDataTable<DataRow>();
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    dataTable1 = new DataTable();
                    ProjectData.ClearProjectError();
                  }
                  // ISSUE: reference to a compiler-generated field
                  closure642.\u0024VB\u0024Local_lowIndex = checked (num4 * 2 - 2);
                  // ISSUE: reference to a compiler-generated field
                  closure642.\u0024VB\u0024Local_highIndex = checked (num4 * 2);
                  DataTable faults;
                  try
                  {
                    try
                    {
                      // ISSUE: object of a compiler-generated type is created
                      // ISSUE: variable of a compiler-generated type
                      Printing._Closure\u0024__64\u002D1 closure641_1 = new Printing._Closure\u0024__64\u002D1(closure641_1);
                      // ISSUE: variable of a compiler-generated type
                      Printing._Closure\u0024__64\u002D1 closure641_2 = closure641_1;
                      EnumerableRowCollection<DataRow> source = dataTable1.AsEnumerable();
                      Func<DataRow, int> selector;
                      // ISSUE: reference to a compiler-generated field
                      if (Printing._Closure\u0024__.\u0024I64\u002D1 != null)
                      {
                        // ISSUE: reference to a compiler-generated field
                        selector = Printing._Closure\u0024__.\u0024I64\u002D1;
                      }
                      else
                      {
                        // ISSUE: reference to a compiler-generated field
                        Printing._Closure\u0024__.\u0024I64\u002D1 = selector = (Func<DataRow, int>) (r => r.Field<int>("AssetID"));
                      }
                      List<int> list = source.Select<DataRow, int>(selector).ToList<int>();
                      // ISSUE: reference to a compiler-generated field
                      closure641_2.\u0024VB\u0024Local_assetIds = list;
                      // ISSUE: reference to a compiler-generated method
                      faults = dvFaults.Table.AsEnumerable().Where<DataRow>(new Func<DataRow, int, bool>(closure641_1._Lambda\u0024__2)).CopyToDataTable<DataRow>();
                      try
                      {
                        DataRow[] dataRowArray = dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0");
                        if (dataRowArray.Length > 0)
                        {
                          // ISSUE: reference to a compiler-generated method
                          faults.Merge(((IEnumerable<DataRow>) dataRowArray).CopyToDataTable<DataRow>().AsEnumerable().Where<DataRow>(new Func<DataRow, int, bool>(closure642._Lambda\u0024__3)).CopyToDataTable<DataRow>());
                        }
                      }
                      catch (Exception ex)
                      {
                        ProjectData.SetProjectError(ex);
                        ProjectData.ClearProjectError();
                      }
                    }
                    catch (Exception ex)
                    {
                      ProjectData.SetProjectError(ex);
                      faults = new DataTable();
                      DataTable dataTable2 = ((IEnumerable<DataRow>) dvFaults.Table.Select("AssetID IS NULL OR AssetID = 0")).CopyToDataTable<DataRow>();
                      // ISSUE: reference to a compiler-generated method
                      faults.Merge(dataTable2.AsEnumerable().Where<DataRow>(new Func<DataRow, int, bool>(closure642._Lambda\u0024__4)).CopyToDataTable<DataRow>());
                      ProjectData.ClearProjectError();
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    faults = new DataTable();
                    ProjectData.ClearProjectError();
                  }
                  int numberOfAppliances = dataTable1 != null ? dataTable1.Rows.Count : 0;
                  this.AddAppliancesBatch(wordprocessingDocument, numberOfAppliances, dataTable1, faults, false, (int) Fuel);
                }
                if (Fuel == Enums.WorksheetFuelTypes.Unvented)
                {
                  this.AddAppliancesBatch(wordprocessingDocument, GSRS.Table.Rows.Count, GSRS.Table, dvFaults.Table, false, (int) Fuel);
                  EngineerVisitAdditional forEngineerVisit = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 69903);
                  if (forEngineerVisit != null)
                  {
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AA", forEngineerVisit.Test221, "7", false);
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AB", forEngineerVisit.Test222, "7", false);
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AC", forEngineerVisit.Test223, "7", false);
                    PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AD", forEngineerVisit.Test224, "7", false);
                  }
                  string notesToEngineer = oEngineerVisit.NotesToEngineer;
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AE", notesToEngineer, "7", false);
                  string notesFromEngineer = oEngineerVisit.NotesFromEngineer;
                  PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AF", notesFromEngineer, "7", false);
                }
              }
            }
            List<byte[]> docs = new List<byte[]>();
            docs.Add(memoryStream.ToArray());
            if (printHeader & num4 == num2)
            {
              List<byte[]> numArrayList = docs;
              byte[] numArray1 = this.LsrHeaderLetter(oSite, oSiteHq, dateTime1, (MemoryStream) null);
              byte[] numArray2 = numArray1 != null ? ((IEnumerable<byte>) numArray1).ToArray<byte>() : (byte[]) null;
              numArrayList.Add(numArray2);
            }
            byte[] numArray = PrintHelper.CombineDocs(docs);
            savePath = this.FileCheck(savePath);
            if (numArray != null)
            {
              fullDocument.Add(numArray);
            }
            else
            {
              FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
              memoryStream.Position = 0L;
              using (fileStream)
                memoryStream.WriteTo((Stream) fileStream);
            }
            checked { ++num4; }
          }
          flag1 = true;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num3 = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          flag1 = false;
          ProjectData.ClearProjectError();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return flag1;
    }

    private byte[] AddLgsrSupplementaryInformation(
      EngineerVisit engineerVisit,
      DataView dvDefects,
      int siteId,
      int pageNo)
    {
      byte[] numArray = (byte[]) null;
      string str = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\LGSR_Supplementary_Info.docx";
      string documentGoldenRule = this.GetDocumentGoldenRule(str, siteId);
      byte[] buffer = File.ReadAllBytes(str);
      MemoryStream memoryStream = new MemoryStream();
      using (memoryStream)
      {
        memoryStream.Write(buffer, 0, buffer.Length);
        WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream) memoryStream, true);
        using (doc1)
        {
          PrintHelper.ReplaceText(doc1, "[GoldenRule]", documentGoldenRule);
          DataTable dt = new DataTable();
          dt.Columns.Add("Appliance");
          dt.Columns.Add("Category");
          dt.Columns.Add("Reason");
          dt.Columns.Add("Action Taken");
          dt.Columns.Add("Comments");
          if (dvDefects.Count > 0)
          {
            DataRow[] dataRowArray = dvDefects.Table.Select("", "AssetID DESC");
            int index = 0;
            while (index < dataRowArray.Length)
            {
              DataRow dataRow = dataRowArray[index];
              DataRow row = dt.NewRow();
              row["Appliance"] = RuntimeHelpers.GetObjectValue(dataRow["typemakemodel"]);
              row["Category"] = RuntimeHelpers.GetObjectValue(dataRow["Category"]);
              row["Reason"] = RuntimeHelpers.GetObjectValue(dataRow["Reason"]);
              row["Action Taken"] = RuntimeHelpers.GetObjectValue(dataRow["ActionTaken"]);
              row["Comments"] = RuntimeHelpers.GetObjectValue(dataRow["Comments"]);
              dt.Rows.Add(row);
              checked { ++index; }
            }
          }
          if (dt.Rows.Count > 0)
          {
            PrintHelper.AddRowsToTable(doc1, "[NCS]", dt, "Arial", "14", 0);
            PrintHelper.ReplaceText(doc1, "[NoDefects]", string.Empty);
          }
          else
          {
            PrintHelper.DeleteTableBookmark(doc1, "[NCS]");
            PrintHelper.ReplaceText(doc1, "[NoDefects]", "NO DEFECTS RECORDED");
          }
          if (pageNo == 1)
          {
            if (!Helper.IsStringEmpty((object) engineerVisit.OutcomeDetails))
              PrintHelper.ReplaceText(doc1, "[EngineerNotes]", engineerVisit.OutcomeDetails);
            else
              PrintHelper.DeleteTableBookmark(doc1, "[EngineerNotes]");
            DataView forVisitDvProper1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(engineerVisit.EngineerVisitID, 68650);
            DataView forVisitDvProper2 = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(engineerVisit.EngineerVisitID, 68649);
            WordprocessingDocument doc2 = doc1;
            int count = forVisitDvProper1.Count;
            string text1 = count.ToString();
            PrintHelper.ReplaceText(doc2, "[Como]", text1);
            WordprocessingDocument doc3 = doc1;
            count = forVisitDvProper2.Count;
            string text2 = count.ToString();
            PrintHelper.ReplaceText(doc3, "[Smoke]", text2);
            DataView friendly = App.DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_Get_Friendly(engineerVisit.EngineerVisitNCCGSR?.EngineerVisitNCCGSRID.Value);
            // ISSUE: explicit non-virtual call
            if ((friendly != null ? (__nonvirtual (friendly.Count) > 0 ? 1 : 0) : 0) != 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(friendly[0]["CorrectMaterialsUsedID"])) > 0)
            {
              PrintHelper.ReplaceText(doc1, "[Rad]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Radiators"])));
              PrintHelper.ReplaceText(doc1, "[Age]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ApproxAgeOfBoiler"])));
              PrintHelper.ReplaceText(doc1, "[Info1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CorrectMaterialsUsed"])));
              PrintHelper.ReplaceText(doc1, "[Info2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["InstallationPipeWorkCorrect"])));
              PrintHelper.ReplaceText(doc1, "[Info3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["InstallationSafeToUse"])));
              PrintHelper.ReplaceText(doc1, "[SF]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["StrainerFitted"])));
              PrintHelper.ReplaceText(doc1, "[SI]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["StrainerInspected"])));
              PrintHelper.ReplaceText(doc1, "[HST]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["HeatingSystemType"])));
              PrintHelper.ReplaceText(doc1, "[PH]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["PartialHeating"])));
              PrintHelper.ReplaceText(doc1, "[CT]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CylinderType"])));
              PrintHelper.ReplaceText(doc1, "[Jack]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Jacket"])));
              PrintHelper.ReplaceText(doc1, "[IM]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Immersion"])));
              PrintHelper.ReplaceText(doc1, "[CO]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CODetectorFitted"])));
              PrintHelper.ReplaceText(doc1, "[FL]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["FillDisc"])));
              PrintHelper.ReplaceText(doc1, "[SIT]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SITimer"])));
              PrintHelper.ReplaceText(doc1, "[CertType]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CertificateType"])));
            }
            else
              PrintHelper.DeleteTableBookmark(doc1, "[NCC]");
          }
          else
          {
            PrintHelper.DeleteTableBookmark(doc1, "[EngineerNotes]");
            PrintHelper.DeleteTableBookmark(doc1, "[Como]");
            PrintHelper.DeleteTableBookmark(doc1, "[NCC]");
          }
          DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = doc1.MainDocumentPart.Document.Body.ChildElements.First<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
          if (paragraph.ParagraphProperties == null)
            paragraph.ParagraphProperties = new ParagraphProperties();
          paragraph.ParagraphProperties.PageBreakBefore = new PageBreakBefore();
          doc1.MainDocumentPart.Document.Save();
          numArray = memoryStream.ToArray();
        }
      }
      return numArray;
    }

    public byte[] LsrHeaderLetter(Site oSite, Site oSiteHq, DateTime visitDate, MemoryStream mm)
    {
      byte[] numArray = (byte[]) null;
      if (oSiteHq == null)
        oSiteHq = App.DB.Sites.Get((object) oSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
      string str = System.Windows.Forms.Application.StartupPath + "\\Templates\\GSR\\GSRCoveringLetter.docx";
      string documentGoldenRule = this.GetDocumentGoldenRule(str, oSite.SiteID);
      byte[] buffer = File.ReadAllBytes(str);
      MemoryStream memoryStream = new MemoryStream();
      using (memoryStream)
      {
        memoryStream.Write(buffer, 0, buffer.Length);
        WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
        using (doc)
        {
          PrintHelper.ReplaceText(doc, "[GoldenRule]", documentGoldenRule);
          this.AddCompanyDetails(doc, true, false, false);
          if (oSiteHq.CustomerID == 787)
            PrintHelper.ReplaceText(doc, "[CustomerName]", "the person(s) responsible for your property");
          else
            PrintHelper.ReplaceText(doc, "[CustomerName]", oSiteHq.Name);
          PrintHelper.ReplaceText(doc, "[SiteName]", oSite.Name.Replace("T1", "").Trim());
          PrintHelper.ReplaceText(doc, "[Name]", Helper.ToTitleCase(oSite.Name.Replace("T1", "").Trim()));
          PrintHelper.ReplaceText(doc, "[Address1]", oSite.Address1);
          PrintHelper.ReplaceText(doc, "[Address2]", oSite.Address2);
          PrintHelper.ReplaceText(doc, "[Address3]", oSite.Address3);
          PrintHelper.ReplaceText(doc, "[Address4]", oSite.Address4);
          PrintHelper.ReplaceText(doc, "[Address5]", oSite.Address5);
          PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode((object) oSite.Postcode));
          PrintHelper.ReplaceText(doc, "[Date]", DateAndTime.Now.ToShortDateString());
          PrintHelper.ReplaceText(doc, "[ServiceDate]", visitDate.ToShortDateString());
          string text = oSiteHq.CustomerID == 5872 ? "01603 309600" : "01603 258617";
          PrintHelper.ReplaceText(doc, "[TelNo]", text);
          DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = doc.MainDocumentPart.Document.Body.ChildElements.First<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
          if (paragraph.ParagraphProperties == null)
            paragraph.ParagraphProperties = new ParagraphProperties();
          paragraph.ParagraphProperties.PageBreakBefore = new PageBreakBefore();
        }
        if (mm != null)
          numArray = PrintHelper.CombineDocs(new List<MemoryStream>()
          {
            mm,
            memoryStream
          });
        else
          numArray = memoryStream.ToArray();
      }
      return numArray;
    }

    private int Add_Appliances_PreVisit(
      Microsoft.Office.Interop.Word.Document wordDoc,
      int numberOfAppliances,
      int currentPage,
      int numberOfPages,
      DataTable Assets,
      DataTable faults,
      int nextTableForPrint,
      bool NCCTemplate = false)
    {
      int num1 = numberOfAppliances;
      int num2 = 0;
      int num3 = 0;
      int num4 = !NCCTemplate ? 4 : 4;
      int num5 = checked (numberOfAppliances - 1);
      int num6 = checked (numberOfAppliances - num4);
      int index = num5;
      while (index >= num6)
      {
        checked { ++num2; }
        checked { ++num3; }
        try
        {
          string NewText = "";
          PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["ApplianceTestedID"]));
          if (oneAsObject1 != null && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(oneAsObject1.Name, "No", false) == 0)
            NewText = "Not Tested";
          IEnumerator enumerator;
          try
          {
            enumerator = Printing.GetTemplateFields(wordDoc.Content[]).GetEnumerator();
            while (enumerator.MoveNext())
            {
              Match current = (Match) enumerator.Current;
              string Left = current.Value;
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "A]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["Location"])));
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "B]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["Type"])));
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "C]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["Make"])));
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "D]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["Model"])));
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "E]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["LandlordsApplianceID"]));
                if (oneAsObject2.Name != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, "");
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "F]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["ApplianceServiceOrInspectedID"]));
                if (oneAsObject2 != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "G]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["ApplianceSafeID"]));
                if (oneAsObject2 != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "H]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["FlueTerminationSatisfactoryID"]));
                if (oneAsObject2 != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "I]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["VisualConditionOfFlueSatisfactoryID"]));
                if (oneAsObject2 != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "J]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["FlueFlowTestID"]));
                if (oneAsObject2 != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "K]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["SpillageTestID"]));
                if (oneAsObject2 != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "L]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["VentilationProvisionSatisfactoryID"]));
                if (oneAsObject2 != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "M]", false) == 0)
              {
                PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Assets.Rows[index]["SafetyDeviceOperationID"]));
                if (oneAsObject2 != null)
                  Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject2.Name);
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "N]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["InletStaticPressure"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["InletStaticPressure"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "O]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["InletWorkingPressure"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["InletWorkingPressure"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "P]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["MinBurnerPressure"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["MinBurnerPressure"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "Q]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["MaxBurnerPressure"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["MaxBurnerPressure"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "R]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["CO2"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["CO2"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "S]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["CO2CORatio"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["CO2CORatio"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "T]", false) == 0)
              {
                if (NewText.Length == 0)
                  Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["GCNumber"])));
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "U]", false) == 0)
              {
                if (NewText.Length == 0)
                  Printing.ReplaceText(ref wordDoc, current.Value, Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["SerialNum"])));
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "V]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["DHWFlowRate"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["DHWFlowRate"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "W]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["ColdWaterTemp"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["ColdWaterTemp"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "X]", false) == 0)
              {
                if (NewText.Length == 0)
                {
                  if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["DHWTemp"])) == 0.0)
                    Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                  else
                    Printing.ReplaceText(ref wordDoc, current.Value, Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(Assets.Rows[index]["DHWTemp"]))));
                }
                else
                  Printing.ReplaceText(ref wordDoc, current.Value, NewText);
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          checked { --num1; }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          checked { --num3; }
          IEnumerator enumerator;
          try
          {
            enumerator = Printing.GetTemplateFields(wordDoc.Content[]).GetEnumerator();
            while (enumerator.MoveNext())
            {
              Match current = (Match) enumerator.Current;
              string Left = current.Value;
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "A]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "B]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "C]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "D]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "E]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "F]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "G]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "H]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "I]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "J]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "K]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "L]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "M]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "N]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "O]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "P]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "Q]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "R]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "S]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "T]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "U]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "V]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "W]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "[" + num2.ToString() + "X]", false) == 0)
                Printing.ReplaceText(ref wordDoc, current.Value, "");
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          num1 = 0;
          ProjectData.ClearProjectError();
        }
        checked { index += -1; }
      }
      return num1;
    }

    private void AddAppliancesBatch(
      WordprocessingDocument wordDoc,
      int numberOfAppliances,
      DataTable EngineerVisitAssetWorksheets,
      DataTable faults,
      bool NCCTemplate = false,
      int Fuel = 0)
    {
      int num1 = numberOfAppliances;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5;
      switch (Fuel)
      {
        case 2:
          num5 = 2;
          break;
        case 3:
          num5 = 12;
          break;
        default:
          num5 = 4;
          break;
      }
      int num6 = checked (num5 - 1);
      int index1 = 0;
      while (index1 <= num6)
      {
        if (faults != null)
        {
          try
          {
            if (faults.Rows.Count == 0 & Fuel == 3)
            {
              PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No", "7", false);
            }
            else
            {
              DataRow[] dataRowArray = faults.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AssetID = ", EngineerVisitAssetWorksheets.Rows[index1]["AssetID"])));
              int index2 = 0;
              while (index2 < dataRowArray.Length)
              {
                DataRow dataRow = dataRowArray[index2];
                if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRow["ADDEDTOPRINTOUT"], (object) true, false))))
                {
                  PrintHelper.ReplaceGSRBookmark(wordDoc, "AA" + Conversions.ToString(num4), Conversions.ToString(dataRow["FullReason"]).Trim(), "7", false);
                  if (Fuel == 2 | Fuel == 0 | Fuel == 5 | Fuel == 9 | Fuel == 7)
                  {
                    if (Conversions.ToBoolean(dataRow["WarningNoticeIssued"]))
                      PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + Conversions.ToString(num4), "Yes", "7", false);
                    else
                      PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + Conversions.ToString(num4), "No", "7", false);
                  }
                  else if (Fuel == 3)
                  {
                    if (Conversions.ToBoolean(dataRow["WarningNoticeIssued"]))
                    {
                      PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "Yes", "7", false);
                      PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "Yes", "7", false);
                      PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "Yes", "7", false);
                    }
                    else
                    {
                      PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No", "7", false);
                      PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No", "7", false);
                      PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No", "7", false);
                    }
                  }
                  if (Fuel != 3)
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "DD" + Conversions.ToString(num4), Conversions.ToString(dataRow["ActionTaken"]), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordDoc, "CC" + Conversions.ToString(num4), Conversions.ToString(dataRow["Disconnected"]), "7", false);
                  PrintHelper.ReplaceGSRBookmark(wordDoc, "EE" + Conversions.ToString(num4), Conversions.ToString(dataRow["Comments"]), "7", false);
                  dataRow["ADDEDTOPRINTOUT"] = (object) true;
                  if (Fuel == 1)
                    checked { ++num4; }
                }
                checked { ++index2; }
              }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
        checked { ++num4; }
        checked { ++num2; }
        checked { ++num3; }
        try
        {
          DataView friendly = App.DB.EngineerVisitAssetWorkSheet.Get_Friendly(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(EngineerVisitAssetWorksheets.Rows[index1]["EngineerVisitAssetWorkSheetID"])));
          PrintHelper.ReplaceGSRBookmark(wordDoc, "AAA" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ApplianceTested"])), "7", false);
          if (Fuel == 3)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Type"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Location"])), "7", false);
          switch (Fuel)
          {
            case 0:
            case 1:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Type"])), "7", false);
              break;
            case 3:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Make"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Reading"])), "7", false);
              break;
          }
          if (Fuel == 3)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Model"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Make"])), "7", false);
          switch (Fuel)
          {
            case 3:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["MaxBurnerPressure"])), "7", false);
              break;
            case 5:
            case 6:
            case 9:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + num2.ToString(), Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(friendly[0]["Model"], (object) " / "), friendly[0]["SerialNum"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Model"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 2:
            case 3:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["InletStaticPressure"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["LandlordsAppliance"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["FlueTerminationSatisfactory"])), "7", false);
              break;
            case 3:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["DHWFlowRate"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ApplianceServiceOrInspected"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["VisualConditionOfFlueSatisfactory"])), "7", false);
              break;
            case 3:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ColdWaterTemp"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ApplianceSafe"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["FlueFlowTest"])), "7", false);
              break;
            case 3:
            case 5:
            case 6:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Discharge"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["FlueTerminationSatisfactory"])), "7", false);
              break;
          }
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SpillageTest"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["VisualConditionOfFlueSatisfactory"])), "7", false);
          switch (Fuel)
          {
            case 2:
            case 5:
            case 6:
            case 9:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["VentilationProvisionSatisfactory"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["FlueFlowTest"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SafetyDeviceOperation"])), "7", false);
              break;
            case 9:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Nozzle"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SpillageTest"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["LandlordsAppliance"])), "7", false);
              break;
            case 9:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SpillageTest"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["VentilationProvisionSatisfactory"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ApplianceTested"])), "7", false);
              break;
            case 9:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SpillageTest"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SafetyDeviceOperation"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 0:
            case 1:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["InletStaticPressure"])), "7", false);
              break;
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ApplianceServiceOrInspected"])), "7", false);
              break;
            case 3:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ApplianceSafe"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Overall"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 0:
            case 1:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["InletWorkingPressure"])), "7", false);
              break;
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Discharge"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SweepOutcome"])), "7", false);
              break;
          }
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SweepOutcome"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["MinBurnerPressure"])), "7", false);
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["FlueType"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["MaxBurnerPressure"])), "7", false);
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["DHWFlowRate"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CO2"])), "7", false);
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["BurModel"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CO2CORatio"])), "7", false);
          switch (Fuel)
          {
            case 0:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["BurMake"])), "7", false);
              break;
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Overall"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["GCNumber"])), "7", false);
              break;
          }
          switch (Fuel)
          {
            case 0:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["BurModel"])), "7", false);
              break;
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ColdWaterTempString"])), "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["SerialNum"])), "7", false);
              break;
          }
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["DHWTempString"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["DHWFlowRate"])), "7", false);
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["InletWorkingPressureString"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ColdWaterTemp"])), "7", false);
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["MinBurnerPressureString"])), "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["DHWTemp"])), "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "QQ" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["MinBurnerPressure"])), "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "RR" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Nozzle"])), "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "SS" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["BurMake"])), "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "TT" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["BurModel"])), "7", false);
          switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(friendly[0]["TankID"])))
          {
            case 0:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + num2.ToString(), "N/A", "7", false);
              break;
            case 1:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + num2.ToString(), "Plastic", "7", false);
              break;
            case 2:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + num2.ToString(), "Bunded", "7", false);
              break;
            case 3:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + num2.ToString(), "Metal", "7", false);
              break;
            default:
              PrintHelper.ReplaceGSRBookmark(wordDoc, "UU" + num2.ToString(), "", "7", false);
              break;
          }
          PrintHelper.ReplaceGSRBookmark(wordDoc, "VV" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["FlueType"])), "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "WW" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["GasType"])), "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "Y" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["ApplianceSafe"])), "7", false);
          int num7 = 0;
          if (faults != null && faults.Rows.Count > 0)
          {
            DataRow[] dataRowArray = faults.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AssetID = ", friendly[0]["AssetID"]), (object) " AND WarningNoticeIssued = 1")));
            if (dataRowArray != null && dataRowArray.Length > 0)
              num7 = dataRowArray.Length;
          }
          string text = num7 <= 0 ? "No" : "Yes";
          if (Fuel == 2)
            PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + num2.ToString(), text, "7", false);
          else
            PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + num2.ToString(), num7.ToString(), "7", false);
          if (Fuel == 2 && num2 == 1)
          {
            PrintHelper.ReplaceGSRBookmark(wordDoc, "KS" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CO2String"])), "7", false);
            PrintHelper.ReplaceGSRBookmark(wordDoc, "IS" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["CO2CORatioString"])), "7", false);
            PrintHelper.ReplaceGSRBookmark(wordDoc, "CL" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["BurMakeString"])), "7", false);
            PrintHelper.ReplaceGSRBookmark(wordDoc, "IH" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["NozzleString"])), "7", false);
            PrintHelper.ReplaceGSRBookmark(wordDoc, "AF" + num2.ToString(), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(friendly[0]["Tank"])), "7", false);
          }
          checked { --num1; }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          checked { --num3; }
          PrintHelper.ReplaceGSRBookmark(wordDoc, "AAA" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "A" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "B" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "C" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "D" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "E" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "F" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "G" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "H" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "I" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "J" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "K" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "L" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "M" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "N" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "O" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "P" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "Q" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "R" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "S" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "T" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "U" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "V" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "W" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "X" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "QQ" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "Y" + num2.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "Z" + num2.ToString(), "", "7", false);
          num1 = 0;
          ProjectData.ClearProjectError();
        }
        checked { ++index1; }
      }
      int num8 = 5;
      if (num1 != 0)
        return;
      if (this.PrintType != Enums.SystemDocumentType.COMSR)
      {
        if (faults != null)
        {
          try
          {
            DataRow[] dataRowArray = faults.Select("ADDEDTOPRINTOUT = 0 AND (AssetID IS NULL OR AssetID = 0)");
            int index2 = 0;
            while (index2 < dataRowArray.Length)
            {
              DataRow dataRow = dataRowArray[index2];
              if (num3 == num8)
                num4 = 0;
              if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRow["ADDEDTOPRINTOUT"], (object) true, false))))
              {
                PrintHelper.ReplaceGSRBookmark(wordDoc, "AA" + num4.ToString(), Conversions.ToString(dataRow["FullReason"]).Trim(), "7", false);
                if (Fuel == 2 | Fuel == 0 | Fuel == 5 | Fuel == 9 | Fuel == 7)
                {
                  if (Conversions.ToBoolean(dataRow["WarningNoticeIssued"]))
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + num4.ToString(), "Yes", "7", false);
                  else
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "BB" + num4.ToString(), "No", "7", false);
                }
                else if (Fuel == 3)
                {
                  if (Conversions.ToBoolean(dataRow["WarningNoticeIssued"]))
                  {
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "Yes", "7", false);
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "Yes", "7", false);
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "Yes", "7", false);
                  }
                  else
                  {
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AG", "No", "7", false);
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AH", "No", "7", false);
                    PrintHelper.ReplaceGSRBookmark(wordDoc, "AI", "No", "7", false);
                  }
                }
                PrintHelper.ReplaceGSRBookmark(wordDoc, "CC" + num4.ToString(), Conversions.ToString(dataRow["Disconnected"]), "7", false);
                PrintHelper.ReplaceGSRBookmark(wordDoc, "DD" + num4.ToString(), Conversions.ToString(dataRow["ActionTaken"]), "7", false);
                PrintHelper.ReplaceGSRBookmark(wordDoc, "EE" + num4.ToString(), Conversions.ToString(dataRow["Comments"]), "7", false);
                dataRow["ADDEDTOPRINTOUT"] = (object) true;
                checked { ++num4; }
              }
              num3 = 1;
              checked { ++index2; }
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
        }
        else
        {
          PrintHelper.ReplaceGSRBookmark(wordDoc, "DB" + num4.ToString(), "", "7", false);
          PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "", "7", false);
        }
      }
      else if (faults != null)
      {
        try
        {
          bool flag = false;
          string text = "";
          DataRow[] dataRowArray = faults.Select("ADDEDTOPRINTOUT = 0");
          int index2 = 0;
          while (index2 < dataRowArray.Length)
          {
            DataRow dataRow = dataRowArray[index2];
            if (Conversions.ToInteger(dataRow["AssetID"]) == 0 && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dataRow["ADDEDTOPRINTOUT"], (object) true, false))))
            {
              text = text + Conversions.ToString(dataRow["FullReason"]).Trim() + " - " + Conversions.ToString(dataRow["ActionTaken"]) + " ,  ";
              if (Conversions.ToBoolean(dataRow["WarningNoticeIssued"]))
                flag = true;
              dataRow["ADDEDTOPRINTOUT"] = (object) true;
              checked { ++num4; }
            }
            checked { ++index2; }
          }
          PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", text, "7", false);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        PrintHelper.ReplaceGSRBookmark(wordDoc, "DB" + num4.ToString(), "", "7", false);
        PrintHelper.ReplaceGSRBookmark(wordDoc, "DB", "", "7", false);
      }
    }

    private bool SiteVisitReport(EngineerVisit engineerVisit, string savePath)
    {
      bool flag;
      try
      {
        engineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(engineerVisit.EngineerVisitID, true);
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(engineerVisit.EngineerVisitID);
        Site site1 = App.DB.Sites.Get((object) anEngineerVisitId.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(site1.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(engineerVisit.EngineerID);
        EngineerVisitCharge engineerVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(engineerVisit.EngineerVisitID);
        Site site2 = App.DB.Sites.Get((object) site1.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        DateTime dateTime = engineerVisit.StartDateTime;
        DateTime t1 = engineerVisit.EndDateTime;
        if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
          dateTime = engineerVisit.ManualEntryOn;
        if (DateTime.Compare(t1, DateTime.MinValue) == 0)
          t1 = engineerVisit.ManualEntryOn;
        int index = 101;
        double Amount = 0.0;
        double num1 = 0.0;
        if (engineerVisitCharge != null)
        {
          switch (engineerVisitCharge.ChargeTypeID)
          {
            case 1:
              Amount = engineerVisitCharge.JobValue;
              break;
            case 2:
              if (anEngineerVisitId.JobDefinitionEnumID == 1)
              {
                Amount = Convert.ToDouble(App.DB.QuoteJob.Get(anEngineerVisitId.QuoteID).GrandTotal);
                break;
              }
              break;
            case 6:
              if (anEngineerVisitId.JobDefinitionEnumID == 1)
              {
                Amount = engineerVisitCharge.Charge / 100.0 * Convert.ToDouble(App.DB.QuoteJob.Get(anEngineerVisitId.QuoteID).GrandTotal);
                break;
              }
              break;
          }
          num1 = App.DB.EngineerVisits.EngineerCharge_VAT_Amount(engineerVisitCharge.EngineerVisitChargeID, dateTime, Amount);
        }
        List<byte[]> numArrayList = new List<byte[]>();
        byte[] buffer1 = File.ReadAllBytes(System.Windows.Forms.Application.StartupPath + "\\Templates\\SiteVisitReport.docx");
        MemoryStream memoryStream1 = new MemoryStream();
        using (memoryStream1)
        {
          memoryStream1.Write(buffer1, 0, buffer1.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream1, true);
          using (doc)
          {
            this.AddCompanyDetails(doc, true, false, false);
            PrintHelper.ReplaceText(doc, "[JobVisitNumber]", anEngineerVisitId.JobNumber + Conversions.ToString(engineerVisit.EngineerVisitID));
            PrintHelper.ReplaceText(doc, "[VisitDate]", dateTime.ToLongDateString());
            PrintHelper.ReplaceText(doc, "[GasSafeIDNo]", Helper.MakeStringValid((object) engineer?.GasSafeNo));
            PrintHelper.ReplaceText(doc, "[JobCustomerName]", Helper.MakeStringValid((object) App.DB.Picklists.Get_One_As_Object(engineerVisit.SignatureSelectedID)?.Name) + " " + engineerVisit.CustomerName);
            PrintHelper.ReplaceText(doc, "[JobAddressName]", site1.Name);
            PrintHelper.ReplaceText(doc, "[JobAddress1]", site1.Address1);
            PrintHelper.ReplaceText(doc, "[JobAddress2]", site1.Address2);
            PrintHelper.ReplaceText(doc, "[JobAddress3]", site1.Address3);
            PrintHelper.ReplaceText(doc, "[JobPostCode]", Helper.FormatPostcode((object) site1.Postcode));
            PrintHelper.ReplaceText(doc, "[JobTelNo]", site1.TelephoneNum);
            PrintHelper.ReplaceText(doc, "[LandLordAddress3]", "");
            if (site2 != null)
            {
              string text1 = string.Empty;
              if (site2.Address1.Length > 0)
                text1 = text1 + site2.Address1 + ", ";
              if (site2.Address2.Length > 0)
                text1 = text1 + site2.Address2 + ", ";
              if (text1.Length > 0)
                text1 = text1.Substring(0, checked (text1.Length - 2));
              string text2 = string.Empty;
              if (site2.Address3.Length > 0)
                text2 = text2 + site2.Address3 + ", ";
              if (site2.Address4.Length > 0)
                text2 = text2 + site2.Address4 + ", ";
              if (site2.Address5.Length > 0)
                text2 = text2 + site2.Address5 + ", ";
              if (text1.Length > 0 & text2.Length > 1)
                text2 = text2.Substring(0, checked (text2.Length - 2));
              string text3 = site2.CustomerID != 787 ? customer.Name : "";
              PrintHelper.ReplaceText(doc, "[LandLordName]", text3);
              PrintHelper.ReplaceText(doc, "[LandLordAddress1]", text1);
              PrintHelper.ReplaceText(doc, "[LandLordAddress2]", text2);
              PrintHelper.ReplaceText(doc, "[LLPostcode]", Helper.FormatPostcode((object) site2.Postcode));
              PrintHelper.ReplaceText(doc, "[LLTelNo]", site2.TelephoneNum);
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[LandLordName]", "");
              PrintHelper.ReplaceText(doc, "[LandLordAddress1]", "");
              PrintHelper.ReplaceText(doc, "[LandLordAddress2]", "");
              PrintHelper.ReplaceText(doc, "[LLPostcode]", "");
              PrintHelper.ReplaceText(doc, "[LLTelNo]", "");
            }
            string text4 = string.Empty;
            IEnumerator enumerator1;
            try
            {
              enumerator1 = anEngineerVisitId.JobOfWorks.GetEnumerator();
              while (enumerator1.MoveNext())
              {
                JobOfWork current = (JobOfWork) enumerator1.Current;
                text4 = text4 + current.PONumber + "/";
              }
            }
            finally
            {
              if (enumerator1 is IDisposable)
                (enumerator1 as IDisposable).Dispose();
            }
            if (text4.Length > 0)
              text4 = text4.Substring(0, checked (text4.Length - 1));
            PrintHelper.ReplaceText(doc, "[PO]", text4);
            PrintHelper.ReplaceText(doc, "[From]", dateTime.ToShortTimeString());
            PrintHelper.ReplaceText(doc, "[To]", t1.ToShortTimeString());
            EnumerableRowCollection<DataRow> source1 = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(engineerVisit.EngineerVisitID).Table.AsEnumerable();
            Func<DataRow, bool> predicate;
            // ISSUE: reference to a compiler-generated field
            if (Printing._Closure\u0024__.\u0024I69\u002D0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              predicate = Printing._Closure\u0024__.\u0024I69\u002D0;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              Printing._Closure\u0024__.\u0024I69\u002D0 = predicate = (Func<DataRow, bool>) (r => r.Field<bool>("WarningNoticeIssued"));
            }
            EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
            Func<DataRow, DataRow> selector;
            // ISSUE: reference to a compiler-generated field
            if (Printing._Closure\u0024__.\u0024I69\u002D1 != null)
            {
              // ISSUE: reference to a compiler-generated field
              selector = Printing._Closure\u0024__.\u0024I69\u002D1;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              Printing._Closure\u0024__.\u0024I69\u002D1 = selector = (Func<DataRow, DataRow>) (r => r);
            }
            string text5 = ((IEnumerable<DataRow>) source2.Select<DataRow, DataRow>(selector).ToArray<DataRow>()).Count<DataRow>() > 0 ? "Yes" : "No";
            PrintHelper.ReplaceText(doc, "[Warning]", text5);
            PrintHelper.ReplaceText(doc, "[Engineer]", Helper.MakeStringValid((object) engineer?.Name));
            PrintHelper.ReplaceText(doc, "[Outcome]", engineerVisit.VisitOutcome);
            PrintHelper.ReplaceText(doc, "[PaymentMethod]", Helper.MakeStringValid((object) App.DB.Picklists.Get_One_As_Object(engineerVisit.PaymentMethodID)?.Name));
            PrintHelper.ReplaceText(doc, "[Total]", Amount == 0.0 ? "" : Amount.ToString("c"));
            PrintHelper.ReplaceText(doc, "[VAT]", num1 == 0.0 ? "" : num1.ToString("c"));
            PrintHelper.ReplaceText(doc, "[AmntDue]", Amount + num1 == 0.0 ? "" : (Amount + num1).ToString("c"));
            PrintHelper.ReplaceText(doc, "[OutcomeDetails]", engineerVisit.OutcomeDetails);
            PrintHelper.ReplaceText(doc, "[WorkRequired]", engineerVisit.NotesToEngineer);
            if (engineerVisit.EngineerSignature == null)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "EngSig", "", "7", false);
            }
            else
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(engineerVisit.EngineerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "EngSig", img, savePath1, index, false);
              checked { ++index; }
            }
            if (engineerVisit.CustomerSignature == null)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "CustSig", "", "7", false);
            }
            else
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(engineerVisit.CustomerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "CustSig", img, savePath1, index, false);
              int num2 = checked (index + 1);
            }
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Part No");
            dt1.Columns.Add("Description");
            dt1.Columns.Add("Qty");
            IEnumerator enumerator2;
            if (engineerVisit.PartsAndProductsUsed.Table != null && engineerVisit.PartsAndProductsUsed.Table.Rows.Count > 0)
            {
              try
              {
                enumerator2 = engineerVisit.PartsAndProductsUsed.Table.Rows.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  DataRow current = (DataRow) enumerator2.Current;
                  DataRow row = dt1.NewRow();
                  row["Part No"] = RuntimeHelpers.GetObjectValue(current["Number"]);
                  row["Description"] = RuntimeHelpers.GetObjectValue(current["Name"]);
                  row["Qty"] = RuntimeHelpers.GetObjectValue(current["Quantity"]);
                  dt1.Rows.Add(row);
                }
              }
              finally
              {
                if (enumerator2 is IDisposable)
                  (enumerator2 as IDisposable).Dispose();
              }
            }
            PrintHelper.AddRowsToTable(doc, "[Parts]", dt1, "Arial", "16", 1);
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Start");
            dt2.Columns.Add("End");
            dt2.Columns.Add("Type");
            dt2.Columns.Add("Comments");
            IEnumerator enumerator3;
            if (engineerVisit.TimeSheets.Table != null && engineerVisit.TimeSheets.Table.Rows.Count > 0)
            {
              try
              {
                enumerator3 = engineerVisit.TimeSheets.Table.Rows.GetEnumerator();
                while (enumerator3.MoveNext())
                {
                  DataRow current = (DataRow) enumerator3.Current;
                  DataRow row = dt2.NewRow();
                  row["Start"] = (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["StartDateTime"])).ToString("HH:mm");
                  row["End"] = (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["EndDateTime"])).ToString("HH:mm");
                  row["Type"] = RuntimeHelpers.GetObjectValue(current["TimeSheetType"]);
                  row["Comments"] = RuntimeHelpers.GetObjectValue(current["Comments"]);
                  dt2.Rows.Add(row);
                }
              }
              finally
              {
                if (enumerator3 is IDisposable)
                  (enumerator3 as IDisposable).Dispose();
              }
            }
            PrintHelper.AddRowsToTable(doc, "[TimeSheets]", dt2, "Arial", "16", 1);
          }
          numArrayList.Add(memoryStream1.ToArray());
          this.PrintGSR(engineerVisit.EngineerVisitID, numArrayList, "", true);
          if (numArrayList.Count > 0)
          {
            File.WriteAllBytes(savePath, PrintHelper.CombineDocs(numArrayList));
            PrintHelper.RemoveSpacingInDoc(savePath);
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.GSREditor))
              savePath = PrintHelper.LockFile(savePath, true);
          }
        }
        byte[] buffer2 = File.ReadAllBytes(savePath);
        MemoryStream memoryStream2 = new MemoryStream();
        using (memoryStream2)
        {
          memoryStream2.Write(buffer2, 0, buffer2.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream2, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "Landlord’s appliance", "Appliance");
            PrintHelper.ReplaceText(doc, "Landlord’s Details", "Details");
            PrintHelper.ReplaceText(doc, "LANDLORD", "");
            doc.MainDocumentPart.Document.Save();
          }
          Directory.CreateDirectory(Path.GetDirectoryName(savePath));
          if (File.Exists(savePath))
            File.Delete(savePath);
          FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          memoryStream2.Position = 0L;
          using (fileStream)
            memoryStream2.WriteTo((Stream) fileStream);
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private void AddCompanyDetails(
      WordprocessingDocument doc,
      bool useLogo,
      bool centreLogo = false,
      bool isCommercial = false)
    {
      FSM.Entity.CompanyDetails.CompanyDetails companyDetails = App.DB.CompanyDetails.Get();
      PrintHelper.ReplaceText(doc, "[CompanyName]", companyDetails.Name);
      PrintHelper.ReplaceText(doc, "[CompanyAddress1]", companyDetails.Address1);
      PrintHelper.ReplaceText(doc, "[CompanyAddress2]", companyDetails.Address2);
      PrintHelper.ReplaceText(doc, "[CompanyAddress3]", companyDetails.Address3);
      PrintHelper.ReplaceText(doc, "[CompanyAddress4]", companyDetails.Address4);
      PrintHelper.ReplaceText(doc, "[CompanyAddress5]", companyDetails.Address5);
      PrintHelper.ReplaceText(doc, "[CompanyPostcode]", Helper.MakeStringValid((object) companyDetails.Postcode));
      PrintHelper.ReplaceText(doc, "[CompanyTelephoneNumber]", companyDetails.TelephoneNumber);
      PrintHelper.ReplaceText(doc, "[CompanyWebsite]", companyDetails.Website);
      PrintHelper.ReplaceText(doc, "[CompanyEmail]", companyDetails.EmailAddress);
      PrintHelper.ReplaceText(doc, "[CompanySortCode]", companyDetails.SortCode);
      PrintHelper.ReplaceText(doc, "[CompanyAccountNumber]", companyDetails.AccountNumber);
      PrintHelper.ReplaceText(doc, "[CompanyNumber]", companyDetails.CompanyNumber);
      PrintHelper.ReplaceText(doc, "[CompanyVatNumber]", companyDetails.VatNumber);
      if (!useLogo)
        return;
      Bitmap img = (Bitmap) null;
      if (App.IsRFT)
        img = FSM.My.Resources.Resources.rft_logo;
      else if (App.IsGasway)
        img = isCommercial ? FSM.My.Resources.Resources.GC_Logo : FSM.My.Resources.Resources.GW_Logo;
      else if (App.IsBlueflame)
        img = FSM.My.Resources.Resources.Blueflame;
      string savePath = System.Windows.Forms.Application.StartupPath + "\\TEMP\\companyLogo.jpg";
      PrintHelper.ReplaceBookmarkWithImage(doc, "Logo", img, savePath, 100, centreLogo);
    }

    private bool JobContactLetter(Job job)
    {
      bool flag;
      try
      {
        Site site = App.DB.Sites.Get((object) job.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        App.DB.Customer.Customer_Get(site.CustomerID);
        string str = Conversions.ToString(NewLateBinding.LateIndexGet(this.DetailsToPrint, new object[1]
        {
          (object) 1
        }, (string[]) null));
        IEnumerator enumerator;
        try
        {
          enumerator = Printing.GetTemplateFields(this.WordDoc.Content[]).GetEnumerator();
          while (enumerator.MoveNext())
          {
            Match current = (Match) enumerator.Current;
            string lower = current.Value.ToLower();
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[VisitDate]".ToLower(), false) == 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, (string) null, false) == 0)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, str);
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[VisitDate2]".ToLower(), false) == 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, (string) null, false) == 0)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, str);
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[SentDate]".ToLower(), false) == 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, (string) null, false) == 0)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, DateAndTime.Now.ToString("dd/MM/yyyy"));
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobAddressName]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site.Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address1]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site.Address1);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address2]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site.Address2);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address3]".ToLower(), false) == 0)
            {
              if (site.Address3.Length > 0)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, site.Address3);
                this.WordDoc = wordDoc;
              }
              else if (site.Address4.Length > 0)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, site.Address4);
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, site.Address5);
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Name]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site.Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[PostCode]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.FormatPostcode((object) site.Postcode));
              this.WordDoc = wordDoc;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool COMSR(
      EngineerVisit oEngineerVisit,
      Site oSite,
      string template,
      string savePath,
      string goldenRule,
      List<byte[]> fullDocument = null,
      bool addLsrHeaderLetter = false)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
        App.DB.Customer.Customer_Get(oSite.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(oEngineerVisit.EngineerVisitID);
        DateTime dateTime = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
          dateTime = oEngineerVisit.ManualEntryOn;
        int index = 100;
        DataView forVisit = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(oEngineerVisit.EngineerVisitID, -1);
        int count = forVisit.Table.Rows.Count;
        byte[] buffer = File.ReadAllBytes(template);
        MemoryStream mm = new MemoryStream();
        using (mm)
        {
          mm.Write(buffer, 0, buffer.Length);
          WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open((Stream) mm, true);
          using (wordprocessingDocument)
          {
            PrintHelper.ReplaceText(wordprocessingDocument, "[GoldenRule]", goldenRule);
            PrintHelper.ReplaceText(wordprocessingDocument, "[Job]", Conversions.ToString(oEngineerVisit.EngineerVisitID) + "_" + dateTime.ToString("ddMMyyyyhhmm") + "_COMSR");
            if (oEngineerVisit.EngineerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(wordprocessingDocument, "EngSig", img, savePath1, index, false);
              checked { ++index; }
            }
            else
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "EngSig", "", "7", false);
            EngineerVisitAdditional forEngineerVisit = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 0);
            if (oEngineerVisit.CustomerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(wordprocessingDocument, "CustSig", img, savePath1, index, false);
              int num = checked (index + 1);
            }
            else
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "CustSig", "", "7", false);
            Site site = App.DB.Sites.Get((object) oSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
            PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "JobNo", anEngineerVisitId.JobNumber + "-" + Conversions.ToString(oEngineerVisit.EngineerVisitID), "7", false);
            if (engineer == null)
            {
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "A", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "C", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "D", "", "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "A", engineer.GasSafeNo, "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "C", engineer.Name, "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "D", engineer.Name, "7", false);
            }
            if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
            {
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "B", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "D", "", "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "B", dateTime.ToLongDateString(), "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "D", engineer.Name, "7", false);
            }
            PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "E", oSite.Name, "8", false);
            PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "F", oSite.Address1, "8", false);
            PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "G", oSite.Address2, "8", false);
            PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "H", Helper.FormatPostcode((object) oSite.Postcode), "8", false);
            if (site != null)
            {
              string text1 = string.Empty;
              string text2 = string.Empty;
              if (site.Address1.Length > 0)
                text1 = text1 + site.Address1 + ", ";
              if (site.Address2.Length > 0)
                text1 = text1 + site.Address2 + ", ";
              if (text1.Length > 0)
                text1 = text1.Substring(0, checked (text1.Length - 2));
              if (site.Address3.Length > 0)
                text2 = text2 + site.Address3 + ", ";
              if (site.Address4.Length > 0)
                text2 = text2 + site.Address4 + ", ";
              if (text2.Length > 0)
                text2 = text2.Substring(0, checked (text2.Length - 2));
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "J", App.DB.Customer.Customer_Get(oSite.CustomerID).Name, "8", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "K", text1, "8", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "L", text2, "8", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "M", "", "8", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "N", Helper.FormatPostcode((object) site.Postcode), "8", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "J", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "K", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "L", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "M", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "N", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "O", "", "7", false);
            }
            string text = "No";
            IEnumerator enumerator;
            try
            {
              enumerator = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(oEngineerVisit.EngineerVisitID).Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                text = "No";
                if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["WarningNoticeIssued"])))
                {
                  text = "Yes";
                  break;
                }
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "BA", text, "7", false);
            PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "BB", text, "7", false);
            PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "BC", text, "7", false);
            if (oEngineerVisit.OutcomeDetails == null)
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "OutcomeDetails", "", "7", false);
            else
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "OutcomeDetails", oEngineerVisit.OutcomeDetails, "7", false);
            if (forEngineerVisit != null)
            {
              PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test1);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AA", oneAsObject1.Name, "7", false);
              PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test2);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AB", oneAsObject2.Name, "7", false);
              PickList oneAsObject3 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test3);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AC", oneAsObject3.Name, "7", false);
              PickList oneAsObject4 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test4);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AD", oneAsObject4.Name, "7", false);
              PickList oneAsObject5 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test5);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AE", oneAsObject5.Name, "7", false);
              PickList oneAsObject6 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test6);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AF", oneAsObject6.Name, "7", false);
              PickList oneAsObject7 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test7);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AG", oneAsObject7.Name, "7", false);
              PickList oneAsObject8 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test8);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AH", oneAsObject8.Name, "7", false);
              PickList oneAsObject9 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test9);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AI", oneAsObject9.Name, "7", false);
              PickList oneAsObject10 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test10);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AJ", oneAsObject10.Name, "7", false);
              PickList oneAsObject11 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test111);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AK", oneAsObject11.Name, "7", false);
              PickList oneAsObject12 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test112);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AL", oneAsObject12.Name, "7", false);
              PickList oneAsObject13 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test113);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AM", oneAsObject13.Name, "7", false);
              PickList oneAsObject14 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test114);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AN", oneAsObject14.Name, "7", false);
              PickList oneAsObject15 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test115);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AO", oneAsObject15.Name, "7", false);
              PickList oneAsObject16 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test116);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AP", oneAsObject16.Name, "7", false);
              PickList oneAsObject17 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test117);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AQ", oneAsObject17.Name, "7", false);
              PickList oneAsObject18 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test118);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AR", oneAsObject18.Name, "7", false);
              PickList oneAsObject19 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test119);
              PrintHelper.ReplaceGSRBookmark(wordprocessingDocument, "AS", oneAsObject19.Name, "7", false);
              this.AddAppliancesBatch(wordprocessingDocument, count, forVisit.Table, (DataTable) null, false, 0);
            }
            else
            {
              int num = (int) App.ShowMessage("Could not generate document : Missing Worksheet", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              flag = false;
              goto label_62;
            }
          }
          if (addLsrHeaderLetter)
          {
            byte[] bytes = this.LsrHeaderLetter(oSite, (Site) null, dateTime, mm);
            fullDocument.Add(bytes);
            File.WriteAllBytes(savePath, bytes);
          }
          else
          {
            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            mm.Position = 0L;
            using (fileStream)
              mm.WriteTo((Stream) fileStream);
          }
          fullDocument.Add(mm.ToArray());
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
label_62:
      return flag;
    }

    private bool COMCAT(
      EngineerVisit EngineerVisit,
      Site oSite,
      string template,
      string savePath,
      string goldenRule,
      List<byte[]> fullDocument = null,
      bool addLsrHeaderLetter = false)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
        App.DB.Customer.Customer_Get(oSite.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
        App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(EngineerVisit.EngineerVisitID);
        DateTime dateTime = EngineerVisit.StartDateTime;
        if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
          dateTime = EngineerVisit.ManualEntryOn;
        int index = 100;
        byte[] buffer = File.ReadAllBytes(template);
        MemoryStream mm = new MemoryStream();
        using (mm)
        {
          mm.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) mm, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
            PrintHelper.ReplaceText(doc, "[Job]", Conversions.ToString(EngineerVisit.EngineerVisitID) + "_" + dateTime.ToString("ddMMyyyyhhmm") + "_COMCAT");
            if (EngineerVisit.EngineerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(EngineerVisit.EngineerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "EngSig", img, savePath1, index, false);
              checked { ++index; }
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "EngSig", "", "7", false);
            EngineerVisitAdditional forEngineerVisit = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(EngineerVisit.EngineerVisitID, 69903);
            if (EngineerVisit.CustomerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(EngineerVisit.CustomerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "J", img, savePath1, index, false);
              int num = checked (index + 1);
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "J", "", "7", false);
            Site site = App.DB.Sites.Get((object) oSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
            PrintHelper.ReplaceGSRBookmark(doc, "JobNo", anEngineerVisitId.JobNumber + "-" + Conversions.ToString(EngineerVisit.EngineerVisitID), "9", true);
            if (engineer == null)
              PrintHelper.ReplaceGSRBookmark(doc, "A", "", "7", false);
            else
              PrintHelper.ReplaceGSRBookmark(doc, "A", engineer.GasSafeNo, "7", false);
            if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "B", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "D", "", "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "B", dateTime.ToLongDateString(), "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "D", engineer.Name, "7", false);
            }
            PrintHelper.ReplaceGSRBookmark(doc, "E", oSite.Name, "8", false);
            PrintHelper.ReplaceGSRBookmark(doc, "F", oSite.Address1, "8", false);
            PrintHelper.ReplaceGSRBookmark(doc, "G", oSite.Address2, "8", false);
            PrintHelper.ReplaceGSRBookmark(doc, "H", Helper.FormatPostcode((object) oSite.Postcode), "8", false);
            if (site != null)
            {
              string text1 = string.Empty;
              string text2 = string.Empty;
              if (site.Address1.Length > 0)
                text1 = text1 + site.Address1 + ", ";
              if (site.Address2.Length > 0)
                text1 = text1 + site.Address2 + ", ";
              if (text1.Length > 0)
                text1 = text1.Substring(0, checked (text1.Length - 2));
              if (site.Address3.Length > 0)
                text2 = text2 + site.Address3 + ", ";
              if (site.Address4.Length > 0)
                text2 = text2 + site.Address4 + ", ";
              if (text2.Length > 0)
                text2 = text2.Substring(0, checked (text2.Length - 2));
              PrintHelper.ReplaceGSRBookmark(doc, "K", site.Name, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "L", text1, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "M", text2, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "N", "", "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "O", Helper.FormatPostcode((object) site.Postcode), "8", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "K", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "L", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "M", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "N", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "O", "", "7", false);
            }
            PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test1);
            PrintHelper.ReplaceGSRBookmark(doc, "AB", oneAsObject1.Name, "7", false);
            PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test2);
            PrintHelper.ReplaceGSRBookmark(doc, "AC", oneAsObject2.Name, "7", false);
            PickList oneAsObject3 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test3);
            PrintHelper.ReplaceGSRBookmark(doc, "AD", oneAsObject3.Name, "7", false);
            PickList oneAsObject4 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test4);
            PrintHelper.ReplaceGSRBookmark(doc, "AE", oneAsObject4.Name, "7", false);
            PickList oneAsObject5 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test5);
            PrintHelper.ReplaceGSRBookmark(doc, "AF", oneAsObject5.Name, "7", false);
            PickList oneAsObject6 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test6);
            PrintHelper.ReplaceGSRBookmark(doc, "AG", oneAsObject6.Name, "7", false);
            PickList oneAsObject7 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test7);
            PrintHelper.ReplaceGSRBookmark(doc, "AH", oneAsObject7.Name, "7", false);
            PickList oneAsObject8 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test8);
            PrintHelper.ReplaceGSRBookmark(doc, "AI", oneAsObject8.Name, "7", false);
            PickList oneAsObject9 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test9);
            PrintHelper.ReplaceGSRBookmark(doc, "AJ", oneAsObject9.Name, "7", false);
            PickList oneAsObject10 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test10);
            PrintHelper.ReplaceGSRBookmark(doc, "AK", oneAsObject10.Name, "7", false);
            PickList oneAsObject11 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test111);
            PrintHelper.ReplaceGSRBookmark(doc, "AL", Conversions.ToString(Interaction.IIf(oneAsObject11.ManagerID == 70132, (object) "Yes", (object) "NO")), "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "AM", Conversions.ToString(Interaction.IIf(oneAsObject11.ManagerID == 70133, (object) "Yes", (object) "NO")), "7", false);
            PickList oneAsObject12 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test112);
            PrintHelper.ReplaceGSRBookmark(doc, "AN", oneAsObject12.Name, "7", false);
            PickList oneAsObject13 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test113);
            PrintHelper.ReplaceGSRBookmark(doc, "AO", oneAsObject13.Name, "7", false);
            PickList oneAsObject14 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test114);
            PrintHelper.ReplaceGSRBookmark(doc, "AP", oneAsObject14.Name, "7", false);
            PickList oneAsObject15 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test115);
            PrintHelper.ReplaceGSRBookmark(doc, "AQ", oneAsObject15.Name, "7", false);
            PickList oneAsObject16 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test116);
            PrintHelper.ReplaceGSRBookmark(doc, "AR", oneAsObject16.Name, "7", false);
            PickList oneAsObject17 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test117);
            PrintHelper.ReplaceGSRBookmark(doc, "AS", oneAsObject17.Name, "7", false);
            PickList oneAsObject18 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test118);
            PrintHelper.ReplaceGSRBookmark(doc, "AT", oneAsObject18.Name, "7", false);
            PickList oneAsObject19 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test119);
            PrintHelper.ReplaceGSRBookmark(doc, "AU", oneAsObject19.Name, "7", false);
            PickList oneAsObject20 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test120);
            PrintHelper.ReplaceGSRBookmark(doc, "BA", oneAsObject20.Name, "7", false);
            PickList oneAsObject21 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test121);
            PrintHelper.ReplaceGSRBookmark(doc, "BB", oneAsObject21.Name, "7", false);
            PickList oneAsObject22 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test122);
            PrintHelper.ReplaceGSRBookmark(doc, "BC", oneAsObject22.Name, "7", false);
            PickList oneAsObject23 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test123);
            PrintHelper.ReplaceGSRBookmark(doc, "BD", oneAsObject23.Name, "7", false);
            PickList oneAsObject24 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test124);
            PrintHelper.ReplaceGSRBookmark(doc, "BE", oneAsObject24.Name, "7", false);
            PickList oneAsObject25 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test125);
            PrintHelper.ReplaceGSRBookmark(doc, "BF", oneAsObject25.Name, "7", false);
            PickList oneAsObject26 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test126);
            PrintHelper.ReplaceGSRBookmark(doc, "BG", oneAsObject26.Name, "7", false);
            PickList oneAsObject27 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test127);
            PrintHelper.ReplaceGSRBookmark(doc, "BH", oneAsObject27.Name, "7", false);
            PickList oneAsObject28 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test128);
            PrintHelper.ReplaceGSRBookmark(doc, "BI", oneAsObject28.Name, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BK", forEngineerVisit.Test11, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BJ", forEngineerVisit.Test12, "7", false);
            PickList oneAsObject29 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test129);
            PrintHelper.ReplaceGSRBookmark(doc, "BL", oneAsObject29.Name, "7", false);
            PickList oneAsObject30 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test130);
            PrintHelper.ReplaceGSRBookmark(doc, "BM", oneAsObject30.Name, "7", false);
            PickList oneAsObject31 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test131);
            PrintHelper.ReplaceGSRBookmark(doc, "BN", oneAsObject31.Name, "7", false);
            PickList oneAsObject32 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test132);
            PrintHelper.ReplaceGSRBookmark(doc, "BO", oneAsObject32.Name, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BP", forEngineerVisit.Test13, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BQ", forEngineerVisit.Test14, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BR", forEngineerVisit.Test15, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BS", forEngineerVisit.Test216, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BT", forEngineerVisit.Test217, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BU", forEngineerVisit.Test218, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "BV", forEngineerVisit.Test219, "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "CA", forEngineerVisit.Test220, "7", false);
          }
          if (addLsrHeaderLetter)
          {
            byte[] bytes = this.LsrHeaderLetter(oSite, (Site) null, dateTime, mm);
            fullDocument.Add(bytes);
            File.WriteAllBytes(savePath, bytes);
          }
          else
          {
            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            mm.Position = 0L;
            using (fileStream)
              mm.WriteTo((Stream) fileStream);
          }
          fullDocument.Add(mm.ToArray());
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool ProptMain(
      EngineerVisit oEngineerVisit,
      Site oSite,
      string template,
      string savePath,
      string goldenRule,
      List<byte[]> fullDocument = null,
      bool addLsrHeaderLetter = false)
    {
      bool flag;
      try
      {
        App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
        App.DB.Customer.Customer_Get(oSite.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        Site oSiteHq = App.DB.Sites.Get((object) oSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        DateTime dateTime = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
          dateTime = oEngineerVisit.ManualEntryOn;
        EngineerVisitAdditional forEngineerVisit = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 69591);
        byte[] buffer = File.ReadAllBytes(template);
        MemoryStream mm = new MemoryStream();
        using (mm)
        {
          mm.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) mm, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
            if (engineer == null)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "a1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "b1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "c1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "f1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "g1", "", "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "a1", oSite.Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "b1", oSite.Address1 + oSite.Address2 + ", " + oSite.Address3, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "c1", Helper.FormatPostcode((object) oSite.Postcode), "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "f1", engineer.Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "g1", Conversions.ToString(dateTime), "11", false);
            }
            if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "n1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "o1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "p1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "q1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "r1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "t1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "u1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "w1", "", "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "n1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test1).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "o1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test2).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "p1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test3).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "q1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test4).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "r1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit.Test5).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "t1", forEngineerVisit.Test11, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "u1", forEngineerVisit.Test12, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "w1", forEngineerVisit.Test13, "11", false);
            }
          }
          if (addLsrHeaderLetter)
          {
            byte[] bytes = this.LsrHeaderLetter(oSite, oSiteHq, dateTime, mm);
            fullDocument.Add(bytes);
            File.WriteAllBytes(savePath, bytes);
          }
          else
          {
            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            mm.Position = 0L;
            using (fileStream)
              mm.WriteTo((Stream) fileStream);
          }
          fullDocument.Add(mm.ToArray());
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool Unvented(
      EngineerVisit oEngineerVisit,
      Site oSite,
      string template,
      string savePath,
      DataView LSR,
      string goldenRule,
      ref List<byte[]> fullDocument = null,
      bool addLsrHeaderLetter = false)
    {
      bool flag;
      try
      {
        App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
        App.DB.Customer.Customer_Get(oSite.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        DateTime dateTime = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
          dateTime = oEngineerVisit.ManualEntryOn;
        int index = 100;
        byte[] buffer = File.ReadAllBytes(template);
        MemoryStream mm = new MemoryStream();
        using (mm)
        {
          mm.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) mm, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
            PrintHelper.ReplaceText(doc, "[Address1]", oSite.Name);
            PrintHelper.ReplaceText(doc, "[Address2]", oSite.Address1);
            PrintHelper.ReplaceText(doc, "[Address3]", oSite.Address2);
            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode((object) oSite.Postcode));
            PickList pickList = (PickList) null;
            PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["FlueTerminationSatisfactoryID"]));
            PrintHelper.ReplaceText(doc, "[i]", oneAsObject1.Name);
            pickList = (PickList) null;
            PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["FlueFlowTestID"]));
            PrintHelper.ReplaceText(doc, "[ii]", oneAsObject2.Name);
            pickList = (PickList) null;
            PickList oneAsObject3 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["SpillageTestID"]));
            PrintHelper.ReplaceText(doc, "[iii]", oneAsObject3.Name);
            pickList = (PickList) null;
            PickList oneAsObject4 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["VentilationProvisionSatisfactoryID"]));
            PrintHelper.ReplaceText(doc, "[iv]", oneAsObject4.Name);
            pickList = (PickList) null;
            PickList oneAsObject5 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["TankID"]));
            PrintHelper.ReplaceText(doc, "[v]", oneAsObject5.Name);
            pickList = (PickList) null;
            PickList oneAsObject6 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["DischargeID"]));
            PrintHelper.ReplaceText(doc, "[vi]", oneAsObject6.Name);
            pickList = (PickList) null;
            PickList oneAsObject7 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["SweepOutcomeID"]));
            PrintHelper.ReplaceText(doc, "[vii]", oneAsObject7.Name);
            pickList = (PickList) null;
            PickList oneAsObject8 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["SafetyDeviceOperationID"]));
            PrintHelper.ReplaceText(doc, "[viii]", oneAsObject8.Name);
            pickList = (PickList) null;
            PickList oneAsObject9 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["OverallID"]));
            PrintHelper.ReplaceText(doc, "[ix]", oneAsObject9.Name);
            pickList = (PickList) null;
            PickList oneAsObject10 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["ApplianceTestedID"]));
            PrintHelper.ReplaceText(doc, "[x]", oneAsObject10.Name);
            pickList = (PickList) null;
            PickList oneAsObject11 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["VisualConditionOfFlueSatisfactoryID"]));
            PrintHelper.ReplaceText(doc, "[xi]", oneAsObject11.Name);
            pickList = (PickList) null;
            PickList oneAsObject12 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["LandlordsApplianceID"]));
            PrintHelper.ReplaceText(doc, "[xii]", oneAsObject12.Name);
            pickList = (PickList) null;
            PickList oneAsObject13 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["ApplianceServiceOrInspectedID"]));
            PrintHelper.ReplaceText(doc, "[xiii]", oneAsObject13.Name);
            pickList = (PickList) null;
            PickList oneAsObject14 = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(LSR[0]["ApplianceSafeID"]));
            PrintHelper.ReplaceText(doc, "[xiv]", oneAsObject14.Name);
            PrintHelper.ReplaceText(doc, "[Additional]", oEngineerVisit.OutcomeDetails);
            if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
              PrintHelper.ReplaceText(doc, "[Date]", "");
            else
              PrintHelper.ReplaceText(doc, "[Date]", dateTime.ToLongDateString());
            string text = engineer == null ? "" : engineer.Name;
            PrintHelper.ReplaceText(doc, "[Engineer]", text);
            if (oEngineerVisit.CustomerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "Tenant", img, savePath1, index, false);
              int num = checked (index + 1);
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "Tenant", "", "7", false);
          }
          if (addLsrHeaderLetter)
          {
            byte[] bytes = this.LsrHeaderLetter(oSite, (Site) null, dateTime, mm);
            fullDocument.Add(bytes);
            File.WriteAllBytes(savePath, bytes);
          }
          else
          {
            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            mm.Position = 0L;
            using (fileStream)
              mm.WriteTo((Stream) fileStream);
          }
          fullDocument.Add(mm.ToArray());
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool SAFUnvented(
      EngineerVisit oEngineerVisit,
      Site oSite,
      EngineerVisitAdditional SAFUNV1,
      string template,
      string savePath,
      string goldenRule,
      ref List<byte[]> fullDocument = null,
      bool addLsrHeaderLetter = false)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
        App.DB.Customer.Customer_Get(oSite.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        Site oSiteHq = App.DB.Sites.Get((object) oSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        DateTime dateTime = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
          dateTime = oEngineerVisit.ManualEntryOn;
        int index = 101;
        byte[] buffer1 = File.ReadAllBytes(template);
        MemoryStream mm = new MemoryStream();
        using (mm)
        {
          mm.Write(buffer1, 0, buffer1.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) mm, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[Job]", Conversions.ToString(oEngineerVisit.EngineerVisitID) + "_" + dateTime.ToString("ddMMyyyyhhmm") + "_UNVENTED");
            if (oSiteHq != null)
            {
              string text1 = string.Empty;
              if (oSiteHq.Address1.Length > 0)
                text1 = text1 + oSiteHq.Address1 + ", ";
              if (oSiteHq.Address2.Length > 0)
                text1 = text1 + oSiteHq.Address2 + ", ";
              if (text1.Length > 0)
                text1 = text1.Substring(0, checked (text1.Length - 2));
              string text2 = string.Empty;
              if (oSiteHq.Address3.Length > 0)
                text2 = text2 + oSiteHq.Address3 + ", ";
              if (oSiteHq.Address4.Length > 0)
                text2 = text2 + oSiteHq.Address4 + ", ";
              if (oSiteHq.Address5.Length > 0)
                text2 = text2 + oSiteHq.Address5 + ", ";
              if (text1.Length > 0 & text2.Length > 1)
                text2 = text2.Substring(0, checked (text2.Length - 2));
              PrintHelper.ReplaceGSRBookmark(doc, "LandLordName", App.DB.Customer.Customer_Get(oSite.CustomerID).Name, "8", true);
              PrintHelper.ReplaceGSRBookmark(doc, "LandLordAddress1", text1, "8", true);
              PrintHelper.ReplaceGSRBookmark(doc, "LandLordAddress2", text2, "8", true);
              PrintHelper.ReplaceGSRBookmark(doc, "LLPostcode", Helper.FormatPostcode((object) oSiteHq.Postcode), "8", true);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "LandLordName", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "LandLordAddress1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "LandLordAddress2", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "LLPostcode", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "LLTelNo", "", "7", false);
            }
            byte[] buffer2;
            try
            {
              buffer2 = (byte[]) App.DB.ExecuteScalar("Select Logo FROM tblCustomer where CustomerID = " + Conversions.ToString(oSite.CustomerID), true, false);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              buffer2 = (byte[]) null;
              ProjectData.ClearProjectError();
            }
            if (buffer2 != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(buffer2));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\custLogo.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "Logo", img, savePath1, index, false);
              checked { ++index; }
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "Logo", "", "7", false);
            PrintHelper.ReplaceText(doc, "[JobNo]", anEngineerVisitId.JobNumber);
            PrintHelper.ReplaceText(doc, "[A]", oSite.Name);
            PrintHelper.ReplaceText(doc, "[B]", oSite.Address1);
            PrintHelper.ReplaceText(doc, "[C]", oSite.Address2);
            PrintHelper.ReplaceText(doc, "[D]", Helper.FormatPostcode((object) oSite.Postcode));
            PrintHelper.ReplaceText(doc, "[E]", oSite.TelephoneNum);
            PrintHelper.ReplaceText(doc, "[AA]", SAFUNV1.Test11);
            PrintHelper.ReplaceText(doc, "[AB]", SAFUNV1.Test12);
            PrintHelper.ReplaceText(doc, "[AC]", SAFUNV1.Test13);
            PrintHelper.ReplaceText(doc, "[AD]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test1).Name);
            PrintHelper.ReplaceText(doc, "[AE]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test2).Name);
            PrintHelper.ReplaceText(doc, "[AF]", SAFUNV1.Test14);
            PrintHelper.ReplaceText(doc, "[AG]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test3).Name);
            PrintHelper.ReplaceText(doc, "[AH]", SAFUNV1.Test15);
            PrintHelper.ReplaceText(doc, "[AI]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test4).Name);
            PrintHelper.ReplaceText(doc, "[AJ]", SAFUNV1.Test216);
            PrintHelper.ReplaceText(doc, "[AK]", SAFUNV1.Test217);
            PrintHelper.ReplaceText(doc, "[AL]", SAFUNV1.Test218);
            PrintHelper.ReplaceText(doc, "[AM]", SAFUNV1.Test219);
            PrintHelper.ReplaceText(doc, "[AN]", SAFUNV1.Test220);
            PrintHelper.ReplaceText(doc, "[AO]", SAFUNV1.Test221);
            PrintHelper.ReplaceText(doc, "[AP]", SAFUNV1.Test222);
            PrintHelper.ReplaceText(doc, "[AQ]", SAFUNV1.Test223);
            PrintHelper.ReplaceText(doc, "[AR]", SAFUNV1.Test224);
            PrintHelper.ReplaceText(doc, "[AS]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test5).Name);
            PrintHelper.ReplaceText(doc, "[AT]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test6).Name);
            PrintHelper.ReplaceText(doc, "[AU]", SAFUNV1.Test225);
            PrintHelper.ReplaceText(doc, "[AV]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test7).Name);
            PrintHelper.ReplaceText(doc, "[AW]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test8).Name);
            PrintHelper.ReplaceText(doc, "[AX]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test9).Name);
            PrintHelper.ReplaceText(doc, "[AY]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test10).Name);
            PrintHelper.ReplaceText(doc, "[BA]", SAFUNV1.Test226);
            PrintHelper.ReplaceText(doc, "[BB]", SAFUNV1.Test227);
            PrintHelper.ReplaceText(doc, "[BC]", SAFUNV1.Test228);
            PrintHelper.ReplaceText(doc, "[BD]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test111).Name);
            PrintHelper.ReplaceText(doc, "[BE]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test112).Name);
            PrintHelper.ReplaceText(doc, "[BF]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test113).Name);
            PrintHelper.ReplaceText(doc, "[BG]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test114).Name);
            PrintHelper.ReplaceText(doc, "[BH]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test115).Name);
            PrintHelper.ReplaceText(doc, "[BI]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test116).Name);
            PrintHelper.ReplaceText(doc, "[BJ]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test117).Name);
            PrintHelper.ReplaceText(doc, "[BK]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test118).Name);
            PrintHelper.ReplaceText(doc, "[BL]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test119).Name);
            PrintHelper.ReplaceText(doc, "[BM]", App.DB.Picklists.Get_One_As_Object(SAFUNV1.Test120).Name);
            PrintHelper.ReplaceText(doc, "[BN]", SAFUNV1.Test229);
            PrintHelper.ReplaceText(doc, "[BO]", SAFUNV1.Test230);
            PrintHelper.ReplaceText(doc, "[BP]", SAFUNV1.Test231);
            if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
            {
              PrintHelper.ReplaceText(doc, "[BS]", "");
              PrintHelper.ReplaceText(doc, "[BW]", "");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[BS]", dateTime.ToLongDateString());
              PrintHelper.ReplaceText(doc, "[BW]", dateTime.ToLongDateString());
            }
            PrintHelper.ReplaceText(doc, "[BR]", engineer.Name);
            PrintHelper.ReplaceText(doc, "[BU]", oEngineerVisit.CustomerName);
            if (oEngineerVisit.EngineerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "EngSig2", img, savePath1, index, false);
              checked { ++index; }
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "EngSig2", "", "7", false);
            if (oEngineerVisit.CustomerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "CustSig2", img, savePath1, index, false);
              int num = checked (index + 1);
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "CustSig2", "", "7", false);
          }
          if (addLsrHeaderLetter)
          {
            byte[] bytes = this.LsrHeaderLetter(oSite, oSiteHq, dateTime, mm);
            fullDocument.Add(bytes);
            File.WriteAllBytes(savePath, bytes);
          }
          else
          {
            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            mm.Position = 0L;
            using (fileStream)
              mm.WriteTo((Stream) fileStream);
          }
          fullDocument.Add(mm.ToArray());
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool ComChecklist(EngineerVisit oEngineerVisit)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
        Site site = App.DB.Sites.Get((object) anEngineerVisitId.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        App.DB.Customer.Customer_Get(site.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        EngineerVisitAdditional forEngineerVisit = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 71482);
        App.DB.Sites.Get((object) site.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        DateTime t1 = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(t1, DateTime.MinValue) == 0)
          t1 = oEngineerVisit.ManualEntryOn;
        int index = 101;
        byte[] buffer = File.ReadAllBytes(System.Windows.Forms.Application.StartupPath + "\\Templates\\CommissioningChecklist.docx");
        MemoryStream memoryStream = new MemoryStream();
        string path = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(50) + "\\" + Conversions.ToString(oEngineerVisit.EngineerVisitID);
        Directory.CreateDirectory(path);
        string str = path + "\\CommisioningChecklist" + Conversions.ToString(DateAndTime.Now.Day) + "_" + DateAndTime.Now.ToString("MMM") + "_" + Conversions.ToString(DateAndTime.Now.Year) + ".docx";
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc)
          {
            string text = string.Empty;
            if (site.Address1.Length > 0)
              text = text + site.Address1 + ", ";
            if (site.Address2.Length > 0)
              text = text + site.Address2 + ", " + site.Address3 + ", " + site.Postcode;
            PrintHelper.ReplaceText(doc, "[custName]", site.Name);
            PrintHelper.ReplaceText(doc, "[tel1]", site.TelephoneNum);
            PrintHelper.ReplaceText(doc, "[address1]", text);
            PrintHelper.ReplaceText(doc, "[makeModel]", forEngineerVisit.Test12);
            PrintHelper.ReplaceText(doc, "[serial]", forEngineerVisit.Test13);
            PrintHelper.ReplaceText(doc, "[commission]", engineer.Name);
            PrintHelper.ReplaceText(doc, "[commDate]", t1.ToLongDateString());
            PrintHelper.ReplaceText(doc, "[Breg]", forEngineerVisit.Test11);
            switch (forEngineerVisit.Test1)
            {
              case 71486:
                PrintHelper.ReplaceText(doc, "[a]", "X");
                PrintHelper.ReplaceText(doc, "[b]", "");
                PrintHelper.ReplaceText(doc, "[h]", "");
                PrintHelper.ReplaceText(doc, "[i]", "");
                break;
              case 71487:
                PrintHelper.ReplaceText(doc, "[a]", "");
                PrintHelper.ReplaceText(doc, "[b]", "");
                PrintHelper.ReplaceText(doc, "[h]", "X");
                PrintHelper.ReplaceText(doc, "[i]", "");
                break;
              case 71488:
                PrintHelper.ReplaceText(doc, "[a]", "");
                PrintHelper.ReplaceText(doc, "[b]", "X");
                PrintHelper.ReplaceText(doc, "[h]", "");
                PrintHelper.ReplaceText(doc, "[i]", "");
                break;
              case 71489:
                PrintHelper.ReplaceText(doc, "[a]", "");
                PrintHelper.ReplaceText(doc, "[b]", "");
                PrintHelper.ReplaceText(doc, "[h]", "");
                PrintHelper.ReplaceText(doc, "[i]", "X");
                break;
            }
            if (forEngineerVisit.Test2 == 71490)
            {
              PrintHelper.ReplaceText(doc, "[c]", "X");
              PrintHelper.ReplaceText(doc, "[j]", "");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[c]", "");
              PrintHelper.ReplaceText(doc, "[j]", "X");
            }
            if (forEngineerVisit.Test3 == 71492)
            {
              PrintHelper.ReplaceText(doc, "[d]", "X");
              PrintHelper.ReplaceText(doc, "[k]", "");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[d]", "");
              PrintHelper.ReplaceText(doc, "[k]", "X");
            }
            if (forEngineerVisit.Test4 == 71492)
            {
              PrintHelper.ReplaceText(doc, "[e]", "X");
              PrintHelper.ReplaceText(doc, "[l]", "");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[e]", "");
              PrintHelper.ReplaceText(doc, "[l]", "X");
            }
            if (forEngineerVisit.Test5 == 71492)
            {
              PrintHelper.ReplaceText(doc, "[f]", "X");
              PrintHelper.ReplaceText(doc, "[m]", "");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[f]", "");
              PrintHelper.ReplaceText(doc, "[m]", "X");
            }
            if (forEngineerVisit.Test6 == 71492)
            {
              PrintHelper.ReplaceText(doc, "[g]", "X");
              PrintHelper.ReplaceText(doc, "[n]", "");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[g]", "");
              PrintHelper.ReplaceText(doc, "[n]", "X");
            }
            if (forEngineerVisit.Test7 == 386)
              PrintHelper.ReplaceText(doc, "[o]", "X");
            else
              PrintHelper.ReplaceText(doc, "[o]", "");
            if (forEngineerVisit.Test8 == 386)
              PrintHelper.ReplaceText(doc, "[p]", "X");
            else
              PrintHelper.ReplaceText(doc, "[p]", "");
            PrintHelper.ReplaceText(doc, "[cleaner]", forEngineerVisit.Test14);
            PrintHelper.ReplaceText(doc, "[inhibitor]", forEngineerVisit.Test15);
            PrintHelper.ReplaceText(doc, "[quantity]", forEngineerVisit.Test216);
            if (forEngineerVisit.Test9 == 386)
            {
              PrintHelper.ReplaceText(doc, "[q]", "X");
              PrintHelper.ReplaceText(doc, "[r]", "");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[q]", "");
              PrintHelper.ReplaceText(doc, "[r]", "X");
            }
            PrintHelper.ReplaceText(doc, "[gasRate1]", forEngineerVisit.Test217);
            PrintHelper.ReplaceText(doc, "[burnPress1]", forEngineerVisit.Test218);
            PrintHelper.ReplaceText(doc, "[burnPress2]", forEngineerVisit.Test219);
            PrintHelper.ReplaceText(doc, "[flowTemp]", forEngineerVisit.Test220);
            PrintHelper.ReplaceText(doc, "[returnTemp]", forEngineerVisit.Test221);
            if (forEngineerVisit.Test10 == 390)
            {
              PrintHelper.ReplaceText(doc, "[s]", "X");
              PrintHelper.ReplaceText(doc, "[u]", "");
            }
            else if (forEngineerVisit.Test10 == 391)
            {
              PrintHelper.ReplaceText(doc, "[s]", "");
              PrintHelper.ReplaceText(doc, "[u]", "X");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[s]", "");
              PrintHelper.ReplaceText(doc, "[u]", "");
            }
            if (forEngineerVisit.Test111 == 390)
            {
              PrintHelper.ReplaceText(doc, "[t]", "X");
              PrintHelper.ReplaceText(doc, "[v]", "");
            }
            else if (forEngineerVisit.Test111 == 391)
            {
              PrintHelper.ReplaceText(doc, "[t]", "");
              PrintHelper.ReplaceText(doc, "[v]", "X");
            }
            else
            {
              PrintHelper.ReplaceText(doc, "[t]", "");
              PrintHelper.ReplaceText(doc, "[v]", "");
            }
            PrintHelper.ReplaceText(doc, "[scale]", forEngineerVisit.Test222);
            PrintHelper.ReplaceText(doc, "[gasRate3]", forEngineerVisit.Test223);
            PrintHelper.ReplaceText(doc, "[burnPress3]", forEngineerVisit.Test224);
            PrintHelper.ReplaceText(doc, "[burnPress4]", forEngineerVisit.Test225);
            PrintHelper.ReplaceText(doc, "[inletTemp]", forEngineerVisit.Test226);
            if (forEngineerVisit.Test112 == 386)
              PrintHelper.ReplaceText(doc, "[x]", "X");
            else
              PrintHelper.ReplaceText(doc, "[x]", "");
            PrintHelper.ReplaceText(doc, "[temp]", forEngineerVisit.Test227);
            PrintHelper.ReplaceText(doc, "[flowRate]", forEngineerVisit.Test228);
            if (forEngineerVisit.Test113 == 386)
              PrintHelper.ReplaceText(doc, "[y]", "X");
            else
              PrintHelper.ReplaceText(doc, "[y]", "");
            PrintHelper.ReplaceText(doc, "[maxCO]", forEngineerVisit.Test229);
            PrintHelper.ReplaceText(doc, "[maxRatio]", forEngineerVisit.Test230);
            PrintHelper.ReplaceText(doc, "[minCO]", forEngineerVisit.Test231);
            PrintHelper.ReplaceText(doc, "[minRatio]", forEngineerVisit.Test232);
            if (forEngineerVisit.Test114 == 386)
              PrintHelper.ReplaceText(doc, "[z]", "X");
            else
              PrintHelper.ReplaceText(doc, "[z]", "");
            if (forEngineerVisit.Test115 == 386)
              PrintHelper.ReplaceText(doc, "[aa]", "X");
            else
              PrintHelper.ReplaceText(doc, "[aa]", "");
            if (forEngineerVisit.Test116 == 386)
              PrintHelper.ReplaceText(doc, "[ab]", "X");
            else
              PrintHelper.ReplaceText(doc, "[ab]", "");
            if (forEngineerVisit.Test117 == 386)
              PrintHelper.ReplaceText(doc, "[ac]", "X");
            else
              PrintHelper.ReplaceText(doc, "[ac]", "");
            if (oEngineerVisit.EngineerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature));
              string savePath = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "engSig", img, savePath, index, false);
              checked { ++index; }
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "engSig", "", "7", false);
            if (oEngineerVisit.CustomerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature));
              string savePath = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "custSig", img, savePath, index, false);
              int num = checked (index + 1);
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "custSig", "", "7", false);
          }
          str = this.FileCheck(str);
          FileStream fileStream = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
        }
        Process.Start(str);
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateHotWorksPermit(EngineerVisit oEngineerVisit)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
        Site site = App.DB.Sites.Get((object) anEngineerVisitId.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        App.DB.Customer.Customer_Get(site.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        EngineerVisitAdditional forEngineerVisit = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 71914);
        App.DB.Sites.Get((object) site.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        DateTime t1 = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(t1, DateTime.MinValue) == 0)
          t1 = oEngineerVisit.ManualEntryOn;
        int index1 = 101;
        byte[] buffer = File.ReadAllBytes(System.Windows.Forms.Application.StartupPath + "\\Templates\\HotWorksPermit.docx");
        MemoryStream memoryStream = new MemoryStream();
        string path = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(50) + "\\" + Conversions.ToString(oEngineerVisit.EngineerVisitID);
        Directory.CreateDirectory(path);
        string str = path + "\\HotWorksPermit" + Conversions.ToString(DateAndTime.Now.Day) + "_" + DateAndTime.Now.ToString("MMM") + "_" + Conversions.ToString(DateAndTime.Now.Year) + ".docx";
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[JobNumber]", anEngineerVisitId.JobNumber.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test220]", forEngineerVisit.Test220.ToUpper());
            string text = string.Empty;
            if (site.Address1.Length > 0)
              text = text + site.Address1 + ", ";
            if (site.Address2.Length > 0)
              text = text + site.Address2 + ", " + site.Address3 + ", " + site.Postcode;
            PrintHelper.ReplaceText(doc, "[Address]", text);
            PrintHelper.ReplaceText(doc, "[Test221]", forEngineerVisit.Test221.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test222]", forEngineerVisit.Test222.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test11]", forEngineerVisit.Test11.ToUpper());
            PrintHelper.ReplaceText(doc, "[EngineerName]", engineer.Name.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test11]", forEngineerVisit.Test11.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test12]", forEngineerVisit.Test12.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test13]", forEngineerVisit.Test13.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test14]", forEngineerVisit.Test14.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test15]", forEngineerVisit.Test15.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test216]", forEngineerVisit.Test216.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test217]", forEngineerVisit.Test217.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test218]", forEngineerVisit.Test218.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test219]", forEngineerVisit.Test219.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test223]", forEngineerVisit.Test223.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test224]", forEngineerVisit.Test224.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test225]", forEngineerVisit.Test225.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test226]", forEngineerVisit.Test226.ToUpper());
            PrintHelper.ReplaceText(doc, "[Test227]", forEngineerVisit.Test227.ToUpper());
            PrintHelper.ReplaceText(doc, "[VisitDate]", t1.ToString("dd/MM/yyyy HH:mm"));
            if (oEngineerVisit.EngineerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature));
              string savePath = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "EngSig", img, savePath, index1, false);
              int index2 = checked (index1 + 1);
              PrintHelper.ReplaceBookmarkWithImage(doc, "EngSig1", img, savePath, index2, false);
              int num = checked (index2 + 1);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "EngSig", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "EngSig1", "", "7", false);
            }
          }
          str = this.FileCheck(str);
          FileStream fileStream = new FileStream(str, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
        }
        Process.Start(str);
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool ASHPM(
      EngineerVisit oEngineerVisit,
      Site oSite,
      string template,
      string savePath,
      string goldenRule,
      List<byte[]> fullDocument = null,
      bool addHeaderLetter = false)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
        App.DB.Customer.Customer_Get(oSite.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(oEngineerVisit.EngineerVisitID);
        int count = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(oEngineerVisit.EngineerVisitID, -1).Table.Rows.Count;
        DateTime dateTime = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
          dateTime = oEngineerVisit.ManualEntryOn;
        EngineerVisitAdditional forEngineerVisit1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 69419);
        EngineerVisitAdditional forEngineerVisit2 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 69424);
        Site oSiteHq = App.DB.Sites.Get((object) oSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        byte[] buffer = File.ReadAllBytes(template);
        MemoryStream mm = new MemoryStream();
        using (mm)
        {
          mm.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) mm, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
            PrintHelper.ReplaceText(doc, "[Job]", Conversions.ToString(oEngineerVisit.EngineerVisitID) + "_" + dateTime.ToString("ddMMyyyyhhmm") + "_ASHPM");
            if (engineer == null)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "JobSiteName", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobAddress1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobAddress2", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobAddress3", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobPostCode", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobTelNo", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "Engineer", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "a", "", "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "JobSiteName", oSite.Name, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobAddress1", oSite.Address1, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobAddress2", oSite.Address2, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobAddress3", oSite.Address3, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobPostCode", Helper.FormatPostcode((object) oSite.Postcode), "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "JobTelNo", oSite.TelephoneNum, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "Engineer", engineer.Name, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "a", forEngineerVisit1.Test11, "7", false);
            }
            PrintHelper.ReplaceGSRBookmark(doc, "JobVisitNumber", anEngineerVisitId.JobNumber + "-" + Conversions.ToString(oEngineerVisit.EngineerVisitID), "9", true);
            PrintHelper.ReplaceGSRBookmark(doc, "VisitDate", Microsoft.VisualBasic.Strings.Format((object) dateTime, "dd/MM/yyyy"), "9", true);
            if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "b", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "c", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "d", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "e", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "f", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "g", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "h", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "i", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "j", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "k", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "l", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "m", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "n", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "o", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "p", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "q", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "r", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "s", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "t", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "u", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "v", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "w", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "x", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "DHWCYL", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "DHWMOD", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "DHWSERIAL", "", "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "b", forEngineerVisit1.Test12, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "c", forEngineerVisit1.Test13, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "d", forEngineerVisit1.Test14, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "e", forEngineerVisit1.Test15, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "f", forEngineerVisit1.Test216, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "g", forEngineerVisit1.Test217, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "h", forEngineerVisit1.Test218, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "i", forEngineerVisit1.Test219, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "j", forEngineerVisit1.Test220, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "k", forEngineerVisit1.Test221, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "l", forEngineerVisit1.Test222, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "m", forEngineerVisit1.Test223, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "n", forEngineerVisit1.Test224, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "o", forEngineerVisit1.Test225, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "p", forEngineerVisit1.Test226, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "q", forEngineerVisit1.Test227, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "r", forEngineerVisit1.Test228, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "s", forEngineerVisit1.Test229, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "t", forEngineerVisit1.Test230, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "u", forEngineerVisit1.Test231, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "v", forEngineerVisit1.Test232, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "w", forEngineerVisit1.Test233, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "x", forEngineerVisit1.Test234, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "DHWCYL", forEngineerVisit1.Test235, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "DHWMOD", forEngineerVisit1.Test236, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "DHWSERIAL", forEngineerVisit1.Test237, "7", false);
            }
            if (forEngineerVisit2 != null & (uint) DateTime.Compare(dateTime, DateTime.MinValue) > 0U)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "a1", oSite.Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "b1", oSite.Address1 + ", " + oSite.Address2, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "c1", Helper.FormatPostcode((object) oSite.Postcode), "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "d1", oSite.TelephoneNum, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "e1", oSite.FaxNum, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "f1", engineer.Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "g1", Microsoft.VisualBasic.Strings.Format((object) dateTime, "dd/MM/yyyy"), "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "h1", forEngineerVisit2.Test217, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "j1", forEngineerVisit2.Test218, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "k1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test1).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "l1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test2).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "m1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test3).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "n1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test4).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "o1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test5).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "p1", App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test6).Name, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "q1", forEngineerVisit2.Test11, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "r1", forEngineerVisit2.Test12, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "s1", forEngineerVisit2.Test13, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "t1", forEngineerVisit2.Test14, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "u1", forEngineerVisit2.Test15, "11", false);
              PrintHelper.ReplaceGSRBookmark(doc, "v1", forEngineerVisit2.Test216, "11", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "a1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "b1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "c1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "d1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "e1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "f1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "g1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "h1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "j1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "k1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "l1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "m1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "n1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "o1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "p1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "q1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "r1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "s1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "t1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "u1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "v1", "", "7", false);
            }
          }
          if (addHeaderLetter)
          {
            byte[] bytes = this.LsrHeaderLetter(oSite, oSiteHq, dateTime, mm);
            fullDocument.Add(bytes);
            File.WriteAllBytes(savePath, bytes);
          }
          else
          {
            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            mm.Position = 0L;
            using (fileStream)
              mm.WriteTo((Stream) fileStream);
          }
          fullDocument.Add(mm.ToArray());
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool COMTANDP(
      EngineerVisit oEngineerVisit,
      Site oSite,
      string template,
      string savePath,
      string goldenRule,
      List<byte[]> fullDocument = null)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID);
        App.DB.Customer.Customer_Get(oSite.CustomerID);
        Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
        Site site = App.DB.Sites.Get((object) oSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        DateTime t1 = oEngineerVisit.StartDateTime;
        if (DateTime.Compare(t1, DateTime.MinValue) == 0)
          t1 = oEngineerVisit.ManualEntryOn;
        int index = 100;
        byte[] buffer = File.ReadAllBytes(template);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[GoldenRule]", goldenRule);
            PrintHelper.ReplaceText(doc, "[Job]", Conversions.ToString(oEngineerVisit.EngineerVisitID) + "_" + t1.ToString("ddMMyyyyhhmm") + "_COMTANDP");
            PrintHelper.ReplaceGSRBookmark(doc, "JobNo", anEngineerVisitId.JobNumber + "-" + Conversions.ToString(oEngineerVisit.EngineerVisitID), "7", false);
            if (engineer == null)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "A", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "C", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "D", "", "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "A", engineer.GasSafeNo, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "C", engineer.Name, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "D", engineer.Name, "7", false);
            }
            if (DateTime.Compare(t1, DateTime.MinValue) == 0)
              PrintHelper.ReplaceGSRBookmark(doc, "B", "", "7", false);
            else
              PrintHelper.ReplaceGSRBookmark(doc, "B", t1.ToLongDateString(), "7", false);
            PrintHelper.ReplaceGSRBookmark(doc, "E", oSite.Name, "8", false);
            PrintHelper.ReplaceGSRBookmark(doc, "F", oSite.Address1, "8", false);
            PrintHelper.ReplaceGSRBookmark(doc, "G", oSite.Address2, "8", false);
            PrintHelper.ReplaceGSRBookmark(doc, "H", Helper.FormatPostcode((object) oSite.Postcode), "8", false);
            PrintHelper.ReplaceGSRBookmark(doc, "I", oSite.TelephoneNum, "8", false);
            if (site != null)
            {
              string text1 = string.Empty;
              string text2 = string.Empty;
              if (site.Address1.Length > 0)
                text1 = text1 + site.Address1 + ", ";
              if (site.Address2.Length > 0)
                text1 = text1 + site.Address2 + ", ";
              if (text1.Length > 0)
                text1 = text1.Substring(0, checked (text1.Length - 2));
              if (site.Address3.Length > 0)
                text2 = text2 + site.Address3 + ", ";
              if (site.Address4.Length > 0)
                text2 = text2 + site.Address4 + ", ";
              if (text2.Length > 0)
                text2 = text2.Substring(0, checked (text2.Length - 2));
              PrintHelper.ReplaceGSRBookmark(doc, "J", App.DB.Customer.Customer_Get(oSite.CustomerID).Name, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "K", text1, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "L", text2, "8", false);
              PrintHelper.ReplaceGSRBookmark(doc, "M", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "N", Helper.FormatPostcode((object) site.Postcode), "8", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "J", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "K", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "L", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "M", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "N", "", "7", false);
            }
            string Left = "No";
            IEnumerator enumerator;
            try
            {
              enumerator = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(oEngineerVisit.EngineerVisitID).Table.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(((DataRow) enumerator.Current)["WarningNoticeIssued"])))
                {
                  Left = "Yes";
                  break;
                }
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            if (oEngineerVisit.CustomerSignature != null)
            {
              Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature));
              string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
              PrintHelper.ReplaceBookmarkWithImage(doc, "CustSig1", img, savePath1, index, false);
              checked { ++index; }
            }
            else
              PrintHelper.ReplaceGSRBookmark(doc, "CustSig1", "", "7", false);
            int num;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Yes", false) == 0)
            {
              if (oEngineerVisit.EngineerSignature != null)
              {
                Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature));
                string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
                PrintHelper.ReplaceBookmarkWithImage(doc, "EngSig2", img, savePath1, index, false);
                checked { ++index; }
              }
              else
                PrintHelper.ReplaceGSRBookmark(doc, "EngSig2", "", "7", false);
              if (oEngineerVisit.CustomerSignature != null)
              {
                Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature));
                string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
                PrintHelper.ReplaceBookmarkWithImage(doc, "CustSig2", img, savePath1, index, false);
                num = checked (index + 1);
              }
              else
                PrintHelper.ReplaceGSRBookmark(doc, "CustSig2", "", "7", false);
              if (DateTime.Compare(t1, DateTime.MinValue) == 0)
                PrintHelper.ReplaceGSRBookmark(doc, "DB", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "DB", t1.ToLongDateString(), "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "DA", "", "7", false);
            }
            else
            {
              if (oEngineerVisit.EngineerSignature != null)
              {
                Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature));
                string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.jpg";
                PrintHelper.ReplaceBookmarkWithImage(doc, "EngSig", img, savePath1, index, false);
                checked { ++index; }
              }
              else
                PrintHelper.ReplaceGSRBookmark(doc, "EngSig", "", "7", false);
              if (oEngineerVisit.CustomerSignature != null)
              {
                Bitmap img = new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature));
                string savePath1 = System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.jpg";
                PrintHelper.ReplaceBookmarkWithImage(doc, "CustSig", img, savePath1, index, false);
                num = checked (index + 1);
              }
              else
                PrintHelper.ReplaceGSRBookmark(doc, "CustSig", "", "7", false);
              if (DateTime.Compare(t1, DateTime.MinValue) == 0)
                PrintHelper.ReplaceGSRBookmark(doc, "DA", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "DA", t1.ToLongDateString(), "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "DB", "", "7", false);
            }
            if (oEngineerVisit.OutcomeDetails == null)
              PrintHelper.ReplaceGSRBookmark(doc, "OutcomeDetails", "", "7", false);
            else
              PrintHelper.ReplaceGSRBookmark(doc, "OutcomeDetails", oEngineerVisit.OutcomeDetails, "7", false);
            EngineerVisitAdditional forEngineerVisit1 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 69109);
            if (forEngineerVisit1 != null)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "X1", "X", "7", false);
              string text1 = "";
              switch (forEngineerVisit1.Test1)
              {
                case 1:
                  text1 = "P";
                  break;
                case 2:
                  text1 = "H";
                  break;
              }
              if (string.IsNullOrEmpty(text1))
                PrintHelper.ReplaceGSRBookmark(doc, "AA", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "AA", text1, "7", false);
              string text2 = "";
              switch (forEngineerVisit1.Test2)
              {
                case 1:
                  text2 = "N";
                  break;
                case 2:
                  text2 = "NE";
                  break;
                case 3:
                  text2 = "E";
                  break;
              }
              if (string.IsNullOrEmpty(text2))
                PrintHelper.ReplaceGSRBookmark(doc, "AB", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "AB", text2, "7", false);
              PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit1.Test3);
              PrintHelper.ReplaceGSRBookmark(doc, "AC", oneAsObject1.Name, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AD", forEngineerVisit1.Test11, "7", false);
              string text3 = "";
              switch (forEngineerVisit1.Test4)
              {
                case 1:
                  text3 = "AIR";
                  break;
                case 2:
                  text3 = "NITRO";
                  break;
                case 3:
                  text3 = "WATER";
                  break;
              }
              if (string.IsNullOrEmpty(text3))
                PrintHelper.ReplaceGSRBookmark(doc, "AE", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "AE", text3, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AF", forEngineerVisit1.Test12, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AG", forEngineerVisit1.Test13, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AH", forEngineerVisit1.Test14, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AI", forEngineerVisit1.Test15, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AJ", forEngineerVisit1.Test216, "7", false);
              PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit1.Test120);
              PrintHelper.ReplaceGSRBookmark(doc, "AK", oneAsObject2.Name, "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "X1", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AA", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AB", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AC", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AD", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AE", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AF", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AG", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AH", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AI", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AJ", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "AK", "", "7", false);
            }
            EngineerVisitAdditional forEngineerVisit2 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 69111);
            if (forEngineerVisit2 != null)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "X2", "X", "7", false);
              string text1 = "";
              switch (forEngineerVisit2.Test1)
              {
                case 1:
                  text1 = "NG";
                  break;
                case 2:
                  text1 = "LPG";
                  break;
              }
              if (string.IsNullOrEmpty(text1))
                PrintHelper.ReplaceGSRBookmark(doc, "BA", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "BA", text1, "7", false);
              string text2 = "";
              switch (forEngineerVisit2.Test2)
              {
                case 1:
                  text2 = "N";
                  break;
                case 2:
                  text2 = "NE";
                  break;
                case 3:
                  text2 = "E";
                  break;
              }
              if (string.IsNullOrEmpty(text2))
                PrintHelper.ReplaceGSRBookmark(doc, "BB", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "BB", text2, "7", false);
              PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test3);
              PrintHelper.ReplaceGSRBookmark(doc, "BC", oneAsObject1.Name, "7", false);
              string text3 = "";
              switch (forEngineerVisit2.Test4)
              {
                case 1:
                  text3 = "Diap";
                  break;
                case 2:
                  text3 = "Rota";
                  break;
                case 3:
                  text3 = "Turb";
                  break;
              }
              if (string.IsNullOrEmpty(text3))
                PrintHelper.ReplaceGSRBookmark(doc, "BD", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "BD", text3, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BE", forEngineerVisit2.Test221, "7", false);
              PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test6);
              PrintHelper.ReplaceGSRBookmark(doc, "BF", oneAsObject2.Name, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BG", forEngineerVisit2.Test11, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BH", forEngineerVisit2.Test12, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BI", forEngineerVisit2.Test13, "7", false);
              string text4 = "";
              switch (forEngineerVisit2.Test7)
              {
                case 1:
                  text4 = "Fuel Gas";
                  break;
                case 2:
                  text4 = "Air";
                  break;
              }
              if (string.IsNullOrEmpty(text4))
                PrintHelper.ReplaceGSRBookmark(doc, "BJ", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "BJ", text4, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BK", forEngineerVisit2.Test14, "7", false);
              string text5 = "";
              switch (forEngineerVisit2.Test8)
              {
                case 1:
                  text5 = "Water";
                  break;
                case 2:
                  text5 = "H. SG";
                  break;
                case 3:
                  text5 = "Elec";
                  break;
              }
              if (string.IsNullOrEmpty(text5))
                PrintHelper.ReplaceGSRBookmark(doc, "BL", "", "7", false);
              else
                PrintHelper.ReplaceGSRBookmark(doc, "BL", text5, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BM", forEngineerVisit2.Test15, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BN", forEngineerVisit2.Test216, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BO", forEngineerVisit2.Test217, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BP", forEngineerVisit2.Test218, "7", false);
              PickList oneAsObject3 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test9);
              PrintHelper.ReplaceGSRBookmark(doc, "BQ", oneAsObject3.Name, "7", false);
              PickList oneAsObject4 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test10);
              PrintHelper.ReplaceGSRBookmark(doc, "BR", oneAsObject4.Name, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BT", forEngineerVisit2.Test219, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BU", forEngineerVisit2.Test220, "7", false);
              PickList oneAsObject5 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test119);
              PrintHelper.ReplaceGSRBookmark(doc, "BV", oneAsObject5.Name, "7", false);
              PickList oneAsObject6 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit2.Test120);
              PrintHelper.ReplaceGSRBookmark(doc, "BX", oneAsObject6.Name, "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "X2", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BA", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BB", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BC", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BD", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BE", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BF", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BG", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BH", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BI", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BJ", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BK", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BL", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BM", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BN", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BO", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BP", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BQ", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BR", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BT", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BU", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BV", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "BX", "", "7", false);
            }
            EngineerVisitAdditional forEngineerVisit3 = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(oEngineerVisit.EngineerVisitID, 69110);
            if (forEngineerVisit3 != null)
            {
              PrintHelper.ReplaceGSRBookmark(doc, "X3", "X", "7", false);
              PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test1);
              PrintHelper.ReplaceGSRBookmark(doc, "CA", oneAsObject1.Name, "7", false);
              PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test2);
              PrintHelper.ReplaceGSRBookmark(doc, "CB", oneAsObject2.Name, "7", false);
              PickList oneAsObject3 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test3);
              PrintHelper.ReplaceGSRBookmark(doc, "CC", oneAsObject3.Name, "7", false);
              PickList oneAsObject4 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test4);
              PrintHelper.ReplaceGSRBookmark(doc, "CD", oneAsObject4.Name, "7", false);
              PickList oneAsObject5 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test5);
              PrintHelper.ReplaceGSRBookmark(doc, "CE", oneAsObject5.Name, "7", false);
              PickList oneAsObject6 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test6);
              PrintHelper.ReplaceGSRBookmark(doc, "CF", oneAsObject6.Name, "7", false);
              PickList oneAsObject7 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test7);
              PrintHelper.ReplaceGSRBookmark(doc, "CG", oneAsObject7.Name, "7", false);
              PickList oneAsObject8 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test8);
              PrintHelper.ReplaceGSRBookmark(doc, "CH", oneAsObject8.Name, "7", false);
              PickList oneAsObject9 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test9);
              PrintHelper.ReplaceGSRBookmark(doc, "CI", oneAsObject9.Name, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CJ", forEngineerVisit3.Test11, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CK", forEngineerVisit3.Test12, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CL", forEngineerVisit3.Test13, "7", false);
              PickList oneAsObject10 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test10);
              PrintHelper.ReplaceGSRBookmark(doc, "CM", oneAsObject10.Name, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CN", forEngineerVisit3.Test14, "7", false);
              PickList oneAsObject11 = App.DB.Picklists.Get_One_As_Object(forEngineerVisit3.Test120);
              PrintHelper.ReplaceGSRBookmark(doc, "CO", forEngineerVisit3.Test14, "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CP", oneAsObject11.Name, "7", false);
            }
            else
            {
              PrintHelper.ReplaceGSRBookmark(doc, "X3", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CA", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CB", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CC", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CD", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CE", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CF", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CG", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CH", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CI", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CJ", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CK", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CL", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CM", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CN", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CO", "", "7", false);
              PrintHelper.ReplaceGSRBookmark(doc, "CP", "", "7", false);
            }
          }
          FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
          fullDocument.Add(memoryStream.ToArray());
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool Install(EngineerVisit EngineerVisit)
    {
      bool flag;
      try
      {
        Job anEngineerVisitId = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
        Site site1 = App.DB.Sites.Get((object) anEngineerVisitId.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
        App.DB.Customer.Customer_Get(site1.CustomerID);
        Engineer engineer1 = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
        DateTime t1_1 = EngineerVisit.StartDateTime;
        if (DateTime.Compare(t1_1, DateTime.MinValue) == 0)
          t1_1 = EngineerVisit.ManualEntryOn;
        DataView forJob = App.DB.JobAsset.JobAsset_Get_For_Job(anEngineerVisitId.JobID);
        int count = forJob.Table.Rows.Count;
        int numberOfPages = checked ((int) Math.Ceiling(unchecked ((double) count / 5.0)));
        if (numberOfPages == 0)
          checked { ++numberOfPages; }
        int currentPage = 1;
        Site site2 = (Site) null;
        if (site1.CustomerID != 787)
          site2 = App.DB.Sites.Get((object) site1.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        IEnumerator enumerator;
        try
        {
          enumerator = Printing.GetTemplateFields(this.WordDoc.Content[]).GetEnumerator();
          while (enumerator.MoveNext())
          {
            Match current = (Match) enumerator.Current;
            string lower = current.Value.ToLower();
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobVisitNumber]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, anEngineerVisitId.JobNumber + "-" + Conversions.ToString(EngineerVisit.EngineerVisitID));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[VisitDate]".ToLower(), false) == 0)
            {
              if (DateTime.Compare(t1_1, DateTime.MinValue) == 0)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, t1_1.ToLongDateString());
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[GasSafeIDNo]".ToLower(), false) == 0)
            {
              if (engineer1 == null)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, engineer1.GasSafeNo);
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobCustomerName]".ToLower(), false) == 0)
            {
              PickList oneAsObject = App.DB.Picklists.Get_One_As_Object(EngineerVisit.SignatureSelectedID);
              if (oneAsObject == null)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, EngineerVisit.CustomerName);
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, oneAsObject.Name + " " + EngineerVisit.CustomerName);
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobAddressName]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site1.Name);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobAddress1]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site1.Address1);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobAddress2]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site1.Address2);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobAddress3]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site1.Address3);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobPostCode]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.FormatPostcode((object) site1.Postcode));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[JobTelNo]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, site1.TelephoneNum);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[LandLordName]".ToLower(), false) == 0)
            {
              if (site2 != null)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, App.DB.Customer.Customer_Get(site1.CustomerID).Name);
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[LandLordAddress1]".ToLower(), false) == 0)
            {
              if (site2 != null)
              {
                string empty = string.Empty;
                if (site2.Address1.Length > 0)
                  empty += site2.Address1;
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, empty);
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[LandLordAddress2]".ToLower(), false) == 0)
            {
              if (site2 != null)
              {
                string empty = string.Empty;
                if (site2.Address2.Length > 0)
                  empty += site2.Address2;
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, empty);
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[LandLordAddress3]".ToLower(), false) == 0)
            {
              if (site2 != null)
              {
                string empty = string.Empty;
                if (site2.Address3.Length > 0)
                  empty += site2.Address3;
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, empty);
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[LLPostcode]".ToLower(), false) == 0)
            {
              if (site2 != null)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, Helper.FormatPostcode((object) site2.Postcode));
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[LLTelNo]".ToLower(), false) == 0)
            {
              if (site2 != null)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, site2.TelephoneNum);
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[PO]".ToLower(), false) == 0)
            {
              if (anEngineerVisitId.PONumber.Trim().Length == 0)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "N/A");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, anEngineerVisitId.PONumber);
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[From]".ToLower(), false) == 0)
            {
              DateTime t1_2 = Helper.MakeDateTimeValid((object) EngineerVisit.StartDateTime);
              if (DateTime.Compare(t1_2, DateTime.MinValue) == 0)
              {
                if (DateTime.Compare(Helper.MakeDateTimeValid((object) EngineerVisit.ManualEntryOn), DateTime.MinValue) == 0)
                {
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                  Printing.ReplaceText(ref wordDoc, current.Value, "");
                  this.WordDoc = wordDoc;
                }
                else
                {
                  t1_2 = Helper.MakeDateTimeValid((object) EngineerVisit.ManualEntryOn);
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                  Printing.ReplaceText(ref wordDoc, current.Value, t1_2.ToShortTimeString());
                  this.WordDoc = wordDoc;
                }
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, t1_2.ToShortTimeString());
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[To]".ToLower(), false) == 0)
            {
              DateTime t1_2 = Helper.MakeDateTimeValid((object) EngineerVisit.EndDateTime);
              if (DateTime.Compare(t1_2, DateTime.MinValue) == 0)
              {
                if (DateTime.Compare(Helper.MakeDateTimeValid((object) EngineerVisit.ManualEntryOn), DateTime.MinValue) == 0)
                {
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                  Printing.ReplaceText(ref wordDoc, current.Value, "");
                  this.WordDoc = wordDoc;
                }
                else
                {
                  t1_2 = Helper.MakeDateTimeValid((object) EngineerVisit.ManualEntryOn);
                  // ISSUE: variable of a compiler-generated type
                  Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                  Printing.ReplaceText(ref wordDoc, current.Value, t1_2.ToShortTimeString());
                  this.WordDoc = wordDoc;
                }
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, t1_2.ToShortTimeString());
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[GASSAFEID]".ToLower(), false) == 0)
            {
              Engineer engineer2 = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
              if (engineer2 == null)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, engineer2.GasSafeNo);
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Engineer]".ToLower(), false) == 0)
            {
              Engineer engineer2 = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
              if (engineer2 == null)
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, "");
                this.WordDoc = wordDoc;
              }
              else
              {
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
                Printing.ReplaceText(ref wordDoc, current.Value, engineer2.Name);
                this.WordDoc = wordDoc;
              }
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[WorkRequired]".ToLower(), false) == 0)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, EngineerVisit.NotesToEngineer);
              this.WordDoc = wordDoc;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        // ISSUE: reference to a compiler-generated method
        this.MsWordApp.Selection.WholeStory();
        // ISSUE: reference to a compiler-generated method
        this.MsWordApp.Selection.Copy();
        this.Add_Appliances_PreVisit(this.WordDoc, count, currentPage, numberOfPages, forJob.Table, (DataTable) null, 1, false);
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool SiteLetter(string template, string savePath)
    {
      bool flag;
      try
      {
        Contact contact = App.DB.Contact.Contact_Get(Conversions.ToInteger(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
        {
          (object) 0
        }, (string[]) null, (System.Type[]) null, (bool[]) null)));
        Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(this.DetailsToPrint, (System.Type) null, "item", new object[1]
        {
          (object) 1
        }, (string[]) null, (System.Type[]) null, (bool[]) null)), SiteSQL.GetBy.SiteId, (object) null);
        byte[] buffer = File.ReadAllBytes(template);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc)
          {
            this.AddCompanyDetails(doc, true, true, false);
            string text = contact == null ? site.Name : contact.FirstName + " " + contact.Surname;
            PrintHelper.ReplaceText(doc, "[Name]", text);
            PrintHelper.ReplaceText(doc, "[Address1]", site.Address1);
            PrintHelper.ReplaceText(doc, "[Address2]", site.Address2);
            PrintHelper.ReplaceText(doc, "[Address3]", site.Address3);
            PrintHelper.ReplaceText(doc, "[Address4]", site.Address4);
            PrintHelper.ReplaceText(doc, "[Address5]", site.Address5);
            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode((object) site.Postcode));
            PrintHelper.ReplaceText(doc, "[theDate]", DateTime.Now.ToString("dd MMMM yyyy"));
          }
          Directory.CreateDirectory(Path.GetDirectoryName(savePath));
          savePath = this.FileCheck(savePath);
          FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          memoryStream.Position = 0L;
          using (fileStream)
            memoryStream.WriteTo((Stream) fileStream);
          FSM.Entity.Documentss.Documents oDocuments = new FSM.Entity.Documentss.Documents();
          oDocuments.SetTableEnumID = (object) 24;
          oDocuments.SetRecordID = (object) site.SiteID;
          oDocuments.SetDocumentTypeID = (object) 205;
          oDocuments.SetName = (object) Path.GetFileName(savePath);
          oDocuments.SetNotes = (object) "";
          oDocuments.SetLocation = (object) savePath;
          new DocumentsValidator().Validate(oDocuments);
          App.DB.Documents.Insert(oDocuments, true);
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool Credit()
    {
      bool flag;
      try
      {
        int Row = 1;
        DataTable detailsToPrint = (DataTable) this.DetailsToPrint;
        string NewText1 = "";
        string NewText2 = "";
        string NewText3 = "";
        string NewText4 = "";
        string NewText5 = "";
        string NewText6 = "";
        string str = "";
        string NewText7 = "";
        IEnumerator enumerator1;
        try
        {
          enumerator1 = detailsToPrint.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current = (DataRow) enumerator1.Current;
            if (Conversions.ToBoolean(current["Tick"]))
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Table table = this.WordDoc.Tables[1];
              // ISSUE: variable of a compiler-generated type
              Rows rows = table.Rows;
              object objectValue = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local = ref objectValue;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Row row = rows.Add(ref local);
              row[].Font.Bold = 0;
              row[].Font.Size = 7f;
              row[].Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleNone;
              row[].Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
              checked { ++Row; }
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 1)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["CreditReference"]));
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 2)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["OrderReference"]));
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 3)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["PartNumber"]));
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 4)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["PartName"]));
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 5)[][] = Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Qty"])));
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 6)[][] = Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"])), "C");
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 7)[][] = Microsoft.VisualBasic.Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Total"])), "C");
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 1)[].ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 2)[].ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 3)[].ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 4)[].ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
              NewText1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Supplier"]));
              NewText2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address1"]));
              NewText3 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address2"]));
              NewText4 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address3"]));
              NewText5 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address4"]));
              NewText6 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address5"]));
              str = Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(current["Postcode"]));
              NewText7 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["GaswayAccount"]));
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        IEnumerator enumerator2;
        try
        {
          enumerator2 = Printing.GetTemplateFields(this.WordDoc.Content[]).GetEnumerator();
          while (enumerator2.MoveNext())
          {
            Match current = (Match) enumerator2.Current;
            string lower = current.Value.ToLower();
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Document wordDoc;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[CombinedCreditNumber]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, "");
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Name]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText1);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address1]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText2);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address2]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText3);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address3]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText4);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address4]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText5);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Address5]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText6);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Postcode]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Helper.FormatPostcode((object) str));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[Date]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, Microsoft.VisualBasic.Strings.Format((object) DateAndTime.Now, "dd MMMM yyyy"));
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[OUR_ACCOUNT_SUPPLIER]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, NewText7);
              this.WordDoc = wordDoc;
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(lower, "[User]".ToLower(), false) == 0)
            {
              wordDoc = this.WordDoc;
              Printing.ReplaceText(ref wordDoc, current.Value, App.loggedInUser.Fullname);
              this.WordDoc = wordDoc;
            }
          }
        }
        finally
        {
          if (enumerator2 is IDisposable)
            (enumerator2 as IDisposable).Dispose();
        }
        this.WordDoc.Content.Font.Name = "Arial";
        this.WordDoc.Tables[1].AllowAutoFit = true;
        // ISSUE: reference to a compiler-generated method
        this.WordDoc.Tables[1].AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
        this.WordDoc.Tables[1][].Font.Size = 8f;
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool AlphaCredit()
    {
      bool flag;
      try
      {
        int Row = 1;
        DataTable detailsToPrint = (DataTable) this.DetailsToPrint;
        IEnumerator enumerator;
        try
        {
          enumerator = detailsToPrint.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(current["Tick"]))
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Table table = this.WordDoc.Tables[1];
              if (Row != 1)
              {
                // ISSUE: variable of a compiler-generated type
                Rows rows = table.Rows;
                object objectValue = RuntimeHelpers.GetObjectValue((object) Missing.Value);
                ref object local = ref objectValue;
                // ISSUE: reference to a compiler-generated method
                // ISSUE: variable of a compiler-generated type
                Microsoft.Office.Interop.Word.Row row = rows.Add(ref local);
                row[].Font.Bold = 0;
                row[].Font.Size = 7f;
              }
              checked { ++Row; }
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 1)[][] = "";
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 2)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["PartName"]));
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 2).WordWrap = true;
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 3)[][] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["PartNumber"]));
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 3).WordWrap = true;
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 4)[][] = "";
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 5)[][] = "";
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 1)[].ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 2)[].ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 3)[].ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
              // ISSUE: reference to a compiler-generated method
              table.Cell(Row, 4)[].ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.WordDoc.Content.Font.Name = "Arial";
        this.WordDoc.Tables[1].AllowAutoFit = true;
        // ISSUE: reference to a compiler-generated method
        this.WordDoc.Tables[1].AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
        this.WordDoc.Tables[1][].Font.Size = 8f;
        this.WordDoc.Tables[1].Rows[1][].Font.Size = 11f;
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private string GetDocumentGoldenRule(string templateFilePath, int refNo)
    {
      string str1 = "##Neopost";
      string str2 = string.Empty;
      string str3 = "2";
      string str4 = "MAL";
      string str5 = string.Empty;
      string str6 = "S";
      string str7 = "M";
      string withoutExtension = Path.GetFileNameWithoutExtension(templateFilePath);
      bool flag = true;
      if (flag == (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(withoutExtension.ToLower(), "GSRCoveringLetter".ToLower(), false) == 0))
      {
        str2 = "CoverLetter";
        str5 = "1";
      }
      else if (flag == withoutExtension.ToLower().Contains("AnnualSafetyInspection".ToLower()) || flag == withoutExtension.ToLower().Contains("PatchCheck".ToLower()))
      {
        str2 = "AnnualSafetyInspection";
        str5 = "1";
      }
      else if (flag == withoutExtension.ToLower().Contains("GSRDue".ToLower()))
      {
        str2 = "ServiceReminder";
        str5 = "1";
      }
      else if (flag == withoutExtension.ToLower().Contains("TestingLetter".ToLower()) || flag == withoutExtension.ToLower().Contains("ElecMainLetter".ToLower()))
      {
        str2 = "ElectricalTesting";
        str5 = "1";
      }
      else if (flag == withoutExtension.ToLower().Contains("GSR".ToLower()))
      {
        str2 = "GSR";
        str5 = "2";
      }
      else if (flag == withoutExtension.ToLower().Contains("ContractDD".ToLower()))
      {
        str2 = "Contract";
        str5 = "1";
      }
      else if (flag == withoutExtension.ToLower().Contains("ContractOption".ToLower()))
      {
        str2 = "Contract";
        str5 = "2";
      }
      else if (flag == withoutExtension.ToLower().Contains("Receipt".ToLower()) || flag == withoutExtension.ToLower().Contains("Invoice".ToLower()))
      {
        str2 = "Invoice";
        str5 = "3";
      }
      else if (flag == withoutExtension.ToLower().Contains("ContractTransfer".ToLower()))
      {
        str2 = "Contract";
        str5 = "4";
      }
      return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|", (object) str1, (object) str2, (object) str3, (object) str4, (object) str5, (object) str6, (object) str7, (object) refNo);
    }

    private bool GenerateDDMS(DataRow[] drContracts)
    {
      DataTable dt1 = new DataTable();
      dt1.Columns.Add("Ref");
      dt1.Columns.Add("Unknown");
      dt1.Columns.Add("Salutation");
      dt1.Columns.Add("FirstName");
      dt1.Columns.Add("OtherName");
      dt1.Columns.Add("LastName");
      dt1.Columns.Add("Unknown1");
      dt1.Columns.Add("Unknown2");
      dt1.Columns.Add("Address1");
      dt1.Columns.Add("Address2");
      dt1.Columns.Add("Address3");
      dt1.Columns.Add("Address4");
      dt1.Columns.Add("Unknown3");
      dt1.Columns.Add("Tel");
      dt1.Columns.Add("Unknown4");
      dt1.Columns.Add("Postcode");
      dt1.Columns.Add("SortCode");
      dt1.Columns.Add("AccNum");
      dt1.Columns.Add("NameOnAcc");
      dt1.Columns.Add("Ref2");
      dt1.Columns.Add("InvoiceNumber");
      dt1.Columns.Add("Type");
      dt1.Columns.Add("SecondPayment");
      dt1.Columns.Add("FirstPayment");
      dt1.Columns.Add("ProcessDate");
      dt1.Columns.Add("Unknown5");
      dt1.Columns.Add("Installments");
      dt1.Columns.Add("SecondPayment2");
      dt1.Columns.Add("Unknown6");
      dt1.Columns.Add("SecondPayment3");
      dt1.Columns.Add("ContractEnd");
      DataTable dataTable = new DataTable();
      DataTable dt2 = dt1.Clone();
      DateTime dateTime1;
      bool flag1;
      try
      {
        DataRow[] dataRowArray = drContracts;
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow dataRow1 = dataRowArray[index];
          string str1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["DDMSRef"]));
          string str2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["ContractReference"]));
          string Left = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["Type"]));
          int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow1["siteid"]));
          int num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow1["installments"]));
          int num3 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow1["PreviousInvoiceFrequencyID"])) == 0 ? Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow1["InvoiceFrequencyID"])) : Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow1["PreviousInvoiceFrequencyID"]));
          Enums.InvoiceFrequency invoiceFrequency = (Enums.InvoiceFrequency) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow1["InvoiceFrequencyID"]));
          bool flag2 = false;
          if (num2 % 12 != 0 || (uint) num2 <= 0U)
            flag2 = true;
          DateTime sourceDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow1["DDProcessingDate"]));
          DateTime dateTime2 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow1["ContractEndDate"]));
          Simple3Des simple3Des = new Simple3Des(this.p);
          string str3 = string.Empty;
          string str4 = string.Empty;
          try
          {
            str3 = simple3Des.DecryptData(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["sc"])));
            str4 = simple3Des.DecryptData(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["Ac"])));
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            ProjectData.ClearProjectError();
          }
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(str1.Length <= 3 ? RuntimeHelpers.GetObjectValue(App.DB.ExecuteScalar("SELECT COUNT(DDMSREF) FROM tblContractOriginal co INNER JOIN tblContractOriginalSite cos ON cos.ContractID = co.ContractID Where co.Deleted = 0 AND co.DDMSREF = '" + str2 + "' AND cos.SiteID <> " + Conversions.ToString(num1), true, false)) : RuntimeHelpers.GetObjectValue(App.DB.ExecuteScalar("SELECT COUNT(DDMSREF) FROM tblContractOriginal co INNER JOIN tblContractOriginalSite cos ON cos.ContractID = co.ContractID Where co.Deleted = 0 AND co.DDMSREF = '" + str1 + "' AND cos.SiteID <> " + Conversions.ToString(num1), true, false)))) < 1)
          {
            double num4 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow1["FirstAmount"])) - Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow1["SecondPayment"]));
            DataRow row = dt1.NewRow();
            row["Ref"] = str1.Length > 3 ? (object) str1 : (object) str2;
            row["Salutation"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerSalutation"])).Replace(",", "");
            row["FirstName"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerFirst"])).Replace(",", "");
            row["LastName"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerSurname"])).Replace(",", "");
            row["Address1"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerAddress1"])).Replace(",", "");
            row["Address2"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerAddress2"])).Replace(",", "");
            row["Address3"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerAddress3"])).Replace(",", "");
            row["Address4"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerAddress4"])).Replace(",", "");
            row["Tel"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerTel"])).Replace(",", "");
            row["Postcode"] = (object) Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow1["PayerPostCode"])).Replace(",", "");
            row["SortCode"] = (object) str3;
            row["AccNum"] = (object) str4;
            row["NameOnAcc"] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["AccName"])).Length > 0 ? (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["AccName"])).Replace(",", "") : (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PayerName"])).Replace(",", "");
            row["Ref2"] = str1.Length > 3 ? (object) str1 : (object) str2;
            row["InvoiceNumber"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["InvoiceNumber"])).Replace(",", "");
            row["Type"] = (object) "17";
            row["SecondPayment"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["SecondPayment"])).Replace(",", "");
            row["FirstPayment"] = flag2 ? (object) "0" : (object) Helper.MakeStringValid((object) num4.ToString());
            DataRow dataRow2 = row;
            string str5;
            if (flag2)
            {
              str5 = DateHelper.GetFirstDayOfMonth(sourceDate.AddMonths(1)).ToString("dd/MM/yyyy");
            }
            else
            {
              dateTime1 = DateHelper.GetFirstDayOfMonth(sourceDate);
              str5 = dateTime1.ToString("dd/MM/yyyy");
            }
            dataRow2["ProcessDate"] = (object) str5;
            row["Installments"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["Installments"])).Replace(",", "");
            row["SecondPayment2"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["SecondPayment"]));
            row["SecondPayment3"] = flag2 ? (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["SecondPayment"])) : (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["FirstAmount"]));
            row["ContractEnd"] = (object) dateTime2.ToString("dd/MM/yyyy");
            if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow1["Renewed"])) == 0 || num3 != Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow1["InvoiceFrequencyID"])) || (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "TRANSD", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMMENDD", false) == 0) || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "RENEWALD", false) == 0)
            {
              if (num2 != 0 || invoiceFrequency == Enums.InvoiceFrequency.AnnuallyDD)
                dt1.Rows.Add(row);
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMMEND", false) != 0 && (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "TRANS", false) > 0U && num2 != 0)
              dt2.Rows.Add(row.ItemArray);
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate ddms : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
        goto label_32;
      }
      try
      {
        dateTime1 = DateTime.Now;
        string str1 = "DDMS_IMPORT_NEW" + dateTime1.ToString("ddMMyyyyHHmmss") + ".csv";
        dateTime1 = DateTime.Now;
        string str2 = "DDMS_IMPORT_RENEW_AMMEND" + dateTime1.ToString("ddMMyyyyHHmmss") + ".csv";
        string csvNoHeaders = ExportHelper.DataTableToCSVNoHeaders(dt1);
        string s = string.Format(ExportHelper.DataTableToCSVNoHeaders(dt2));
        string path = App.TheSystem.Configuration.DocumentsLocation + "Contracts\\DDMS\\";
        Directory.CreateDirectory(path);
        FileStream fileStream1 = new FileStream(path + str1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        using (fileStream1)
        {
          byte[] bytes = new UTF8Encoding(true).GetBytes(csvNoHeaders);
          fileStream1.Write(bytes, 0, bytes.Length);
        }
        fileStream1.Close();
        FileStream fileStream2 = new FileStream(path + str2, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        using (fileStream2)
        {
          byte[] bytes = new UTF8Encoding(true).GetBytes(s);
          fileStream2.Write(bytes, 0, bytes.Length);
        }
        fileStream2.Close();
        flag1 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate ddms : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
label_32:
      return flag1;
    }

    private string GenerateRenewalLetters(DataRow[] drContracts)
    {
      string str1 = "Contract_Renewal_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
      string path = App.TheSystem.Configuration.DocumentsLocation + "Contracts\\Renewal";
      Directory.CreateDirectory(path);
      string str2 = path + "\\" + str1;
      File.Copy(System.Windows.Forms.Application.StartupPath + "\\Templates\\Blank.docx", str2);
      string str3;
      try
      {
        WordprocessingDocument batch = WordprocessingDocument.Open(str2, true);
        using (batch)
        {
          DataRow[] dataRowArray = drContracts;
          int index = 0;
          while (index < dataRowArray.Length)
          {
            DataRow dr = dataRowArray[index];
            string Left = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"]));
            bool flag = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dr["Renewed"]));
            Enums.InvoiceFrequency invoiceFrequency = (Enums.InvoiceFrequency) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["InvoiceFrequencyID"]));
            int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["installments"]));
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMMEND", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "TRANS", false) != 0)
            {
              if (((flag ? 0 : (num > 0 ? 1 : 0)) | (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "TRANSD", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "RENEWALD", false) == 0 ? 1 : (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMMENDD", false) == 0 ? 1 : 0)) | (flag ? 0 : (invoiceFrequency == Enums.InvoiceFrequency.AnnuallyDD ? 1 : 0))) != 0)
              {
                if (!this.GenerateDDLetter(dr, batch))
                  throw new Exception();
              }
              else if (num > 0 && !this.GenerateDDRenewalLetter(dr, batch))
                throw new Exception();
            }
            if (!this.GenerateContractLetter(dr, batch))
              throw new Exception();
            if (!string.IsNullOrEmpty(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InvoiceNumber"]))))
            {
              if (string.IsNullOrEmpty(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InitialPaymentType"]))) || (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InitialPaymentType"])), "Invoice", false) > 0U)
              {
                if (!this.GenerateReceipt(dr, batch, false, true))
                  throw new Exception();
              }
              else if (!this.GenerateContractInvoice(dr, batch, false, true))
                throw new Exception();
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "TRANS", false) == 0 && !this.GenerateTransferLetter(dr, batch))
              throw new Exception();
            checked { ++index; }
          }
        }
        str3 = str2;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate renewal letter : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        str3 = string.Empty;
        ProjectData.ClearProjectError();
      }
      return str3;
    }

    private bool GenerateDDLetter(DataRow dr, WordprocessingDocument batch)
    {
      bool flag1;
      try
      {
        if (Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["UpgradedFrom"])).Length > 0)
        {
          flag1 = true;
        }
        else
        {
          Enums.InvoiceFrequency invoiceFrequency = (Enums.InvoiceFrequency) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["InvoiceFrequencyID"]));
          string str1 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Contracts" + (invoiceFrequency == Enums.InvoiceFrequency.AnnuallyDD ? "\\ContractDDA.docx" : "\\ContractDD.docx");
          string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"])));
          byte[] buffer = File.ReadAllBytes(str1);
          MemoryStream memoryStream = new MemoryStream();
          using (memoryStream)
          {
            memoryStream.Write(buffer, 0, buffer.Length);
            WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream) memoryStream, true);
            using (doc1)
            {
              PrintHelper.ReplaceText(doc1, "[GoldenRule]", documentGoldenRule);
              PrintHelper.ReplaceText(doc1, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
              string text1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerSalutation"])).Length > 0 ? Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["PayerSalutation"], (object) " "), dr["PayerSurname"])) : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerName"]));
              PrintHelper.ReplaceText(doc1, "[CompanyName]", text1);
              PrintHelper.ReplaceText(doc1, "[Name]", text1);
              PrintHelper.ReplaceText(doc1, "[Address1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress1"])));
              PrintHelper.ReplaceText(doc1, "[Address2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress2"])));
              PrintHelper.ReplaceText(doc1, "[Address3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress3"])));
              PrintHelper.ReplaceText(doc1, "[Postcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["PayerPostcode"])));
              PrintHelper.ReplaceText(doc1, "[Plan]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractType"])));
              string text2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["DDMSRef"])).Length > 3 ? Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["DDMSRef"])) : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"]));
              PrintHelper.ReplaceText(doc1, "[DebitRef]", text2);
              PrintHelper.ReplaceText(doc1, "[DebitRef2]", Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["ContractReference"], (object) " - "), dr["siteAddress1"]), (object) ", "), dr["siteAddress2"]), (object) ", "), dr["sitePostcode"])));
              int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["installments"]));
              bool flag2 = false;
              DateTime dateTime1 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractStartDate"]));
              DateTime dateTime2 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["DDProcessingDate"]));
              if (num1 % 12 == 0)
              {
                DateTime dateTime3 = DateTime.Compare(dateTime1, DateHelper.GetFirstDayOfMonth(dateTime1)) == 0 ? DateHelper.GetFirstDayOfMonth(dateTime1) : DateHelper.GetFirstDayOfMonth(dateTime1.AddMonths(1));
                PrintHelper.ReplaceText(doc1, "[FirstDate]", dateTime3.ToString("dd/MM/yyyy"));
              }
              else
              {
                flag2 = true;
                PrintHelper.ReplaceText(doc1, "[FirstDate]", DateHelper.GetFirstDayOfMonth(dateTime2.AddMonths(1)).ToString("dd/MM/yyyy"));
              }
              PrintHelper.ReplaceText(doc1, "[Site]", Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["siteAddress1"], (object) ", "), dr["siteAddress2"]), (object) ", "), dr["sitePostcode"])));
              WordprocessingDocument doc2 = doc1;
              double num2;
              string text3;
              if (!flag2)
              {
                num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"]));
                text3 = num2.ToString("C");
              }
              else
              {
                num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["SecondPayment"]));
                text3 = num2.ToString("C");
              }
              PrintHelper.ReplaceText(doc2, "[First]", text3);
              WordprocessingDocument doc3 = doc1;
              num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["SecondPayment"]));
              string text4 = num2.ToString("C");
              PrintHelper.ReplaceText(doc3, "[Second]", text4);
              PrintHelper.ReplaceText(doc1, "[Inst]", checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["Installments"])) - 1).ToString());
              string text5 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["AccName"])).Length > 0 ? Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["AccName"])) : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerName"]));
              PrintHelper.ReplaceText(doc1, "[AcName]", text5);
              Simple3Des simple3Des = new Simple3Des(this.p);
              string text6 = string.Empty;
              string text7 = string.Empty;
              try
              {
                text6 = simple3Des.DecryptData(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["sc"])));
                text7 = simple3Des.DecryptData(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Ac"])));
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
              }
              PrintHelper.ReplaceText(doc1, "[AcNumber]", text7);
              PrintHelper.ReplaceText(doc1, "[ScCode]", text6);
              double num3 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
              PrintHelper.ReplaceText(doc1, "[AHE]", invoiceFrequency == Enums.InvoiceFrequency.AnnuallyDD ? num3.ToString("C") : Math.Round(num3 / 12.0, 2).ToString("C"));
              int num4 = checked (1 + (unchecked (Helper.MakeIntegerValid((object) doc1.ExtendedFilePropertiesPart.Properties.Pages.InnerText) % 2 == 0) ? 0 : 1) - 1);
              int num5 = 0;
              while (num5 <= num4)
              {
                doc1.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
                {
                  (OpenXmlElement) new Run(new OpenXmlElement[1]
                  {
                    (OpenXmlElement) new Break()
                    {
                      Type = (EnumValue<BreakValues>) BreakValues.Page
                    }
                  })
                }), (OpenXmlElement) doc1.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
                checked { ++num5; }
              }
              doc1.MainDocumentPart.Document.Save();
              string path = App.TheSystem.Configuration.DocumentsLocation + "SiteContracts\\" + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"]));
              Directory.CreateDirectory(path);
              string str2 = "DD_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
              FileStream fileStream = new FileStream(this.FileCheck(path + "\\" + str2), FileMode.OpenOrCreate, FileAccess.ReadWrite);
              memoryStream.Position = 0L;
              using (fileStream)
                memoryStream.WriteTo((Stream) fileStream);
              fileStream.Close();
            }
            MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
            string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
            AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
            memoryStream.Position = 0L;
            using (memoryStream)
              formatImportPart.FeedData((Stream) memoryStream);
            mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
            {
              Id = (StringValue) id
            }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            mainDocumentPart.Document.Save();
          }
          flag1 = true;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate dd letter : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      return flag1;
    }

    private bool GenerateDDRenewalLetter(DataRow dr, WordprocessingDocument batch)
    {
      bool flag1;
      try
      {
        Enums.InvoiceFrequency invoiceFrequency = (Enums.InvoiceFrequency) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["InvoiceFrequencyID"]));
        string str1 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Contracts" + (invoiceFrequency == Enums.InvoiceFrequency.AnnuallyDD ? "\\ContractDDARenewal.docx" : "\\ContractDDRenewal.docx");
        string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"])));
        byte[] buffer = File.ReadAllBytes(str1);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[GoldenRule]", documentGoldenRule);
            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
            string text1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerSalutation"])).Length > 0 ? Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["PayerSalutation"], (object) " "), dr["PayerSurname"])) : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerName"]));
            PrintHelper.ReplaceText(doc, "[CompanyName]", text1);
            PrintHelper.ReplaceText(doc, "[Name]", text1);
            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress1"])));
            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress2"])));
            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress3"])));
            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["PayerPostcode"])));
            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractType"])));
            string text2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["DDMSRef"])).Length > 3 ? Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["DDMSRef"])) : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"]));
            PrintHelper.ReplaceText(doc, "[DebitRef]", text2);
            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["ContractReference"], (object) " - "), dr["siteAddress1"]), (object) ", "), dr["siteAddress2"]), (object) ", "), dr["sitePostcode"])));
            int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["installments"]));
            bool flag2 = false;
            DateTime sourceDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractStartDate"]));
            Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["DDProcessingDate"]));
            if (((num1 % 12 != 0 ? 0 : ((uint) num1 > 0U ? 1 : 0)) | (invoiceFrequency != Enums.InvoiceFrequency.AnnuallyDD ? 0 : (num1 == 1 ? 1 : 0))) != 0)
            {
              PrintHelper.ReplaceText(doc, "[FirstDate]", sourceDate.Day == 1 ? DateHelper.GetFirstDayOfMonth(sourceDate).ToString("dd/MM/yyyy") : DateHelper.GetFirstDayOfMonth(sourceDate.AddMonths(1)).ToString("dd/MM/yyyy"));
            }
            else
            {
              flag2 = true;
              PrintHelper.ReplaceText(doc, "[FirstDate]", DateHelper.GetFirstDayOfMonth(sourceDate.AddMonths(2)).ToString("dd/MM/yyyy"));
            }
            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["siteAddress1"], (object) ", "), dr["siteAddress2"]), (object) ", "), dr["sitePostcode"])));
            PrintHelper.ReplaceText(doc, "[First]", flag2 ? Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["SecondPayment"])).ToString("C") : Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])).ToString("C"));
            PrintHelper.ReplaceText(doc, "[Second]", Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["SecondPayment"])).ToString("C"));
            PrintHelper.ReplaceText(doc, "[Inst]", checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["Installments"])) - 1).ToString());
            PrintHelper.ReplaceText(doc, "[Inst2]", Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["Installments"])).ToString());
            double num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractTypeID"])) != 369 ? Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Monthly", Enums.PickListTypes.ContractPricing)) : Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PS Additional Monthly", Enums.PickListTypes.ContractPricing));
            PrintHelper.ReplaceText(doc, "[MonthApp]", invoiceFrequency == Enums.InvoiceFrequency.AnnuallyDD ? Math.Round(num2 * 12.0, 2).ToString("C") : num2.ToString("C"));
            double num3 = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
            PrintHelper.ReplaceText(doc, "[AHE]", invoiceFrequency == Enums.InvoiceFrequency.AnnuallyDD ? num3.ToString("C") : Math.Round(num3 / 12.0, 2).ToString("C"));
            PrintHelper.ReplaceText(doc, "[UserName]", App.TheSystem.Configuration.CompanyName + " Coverplan Team");
            int num4 = checked (1 + (unchecked (Helper.MakeIntegerValid((object) doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText) % 2 == 0) ? 0 : 1) - 1);
            int num5 = 0;
            while (num5 <= num4)
            {
              doc.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
              {
                (OpenXmlElement) new Run(new OpenXmlElement[1]
                {
                  (OpenXmlElement) new Break()
                  {
                    Type = (EnumValue<BreakValues>) BreakValues.Page
                  }
                })
              }), (OpenXmlElement) doc.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
              checked { ++num5; }
            }
            doc.MainDocumentPart.Document.Save();
            string path = App.TheSystem.Configuration.DocumentsLocation + "SiteContracts\\" + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"]));
            Directory.CreateDirectory(path);
            string str2 = "DDRenewal_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
            FileStream fileStream = new FileStream(this.FileCheck(path + "\\" + str2), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            memoryStream.Position = 0L;
            using (fileStream)
              memoryStream.WriteTo((Stream) fileStream);
            fileStream.Close();
          }
          MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
          string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
          AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
          memoryStream.Position = 0L;
          using (memoryStream)
            formatImportPart.FeedData((Stream) memoryStream);
          mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
          {
            Id = (StringValue) id
          }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
          mainDocumentPart.Document.Save();
        }
        flag1 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate dd renewal letter : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      return flag1;
    }

    private bool GenerateContractLetter(DataRow dr, WordprocessingDocument batch = null)
    {
      bool flag1;
      try
      {
        string str1 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Contracts\\ContractOption11.docx";
        string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"])));
        byte[] buffer1 = File.ReadAllBytes(str1);
        MemoryStream memoryStream1 = new MemoryStream();
        using (memoryStream1)
        {
          memoryStream1.Write(buffer1, 0, buffer1.Length);
          WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream) memoryStream1, true);
          using (doc1)
          {
            PrintHelper.ReplaceText(doc1, "[GoldenRule]", documentGoldenRule);
            string text = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["CustomerID"])) == 787 ? Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["SiteName"])) : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["CustName"]));
            DataRow[] dataRowArray1 = App.DB.Contact.Contacts_GetAll_ForLink(24, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteID"])), false).Table.Select("OnContract = 1");
            int index1 = 0;
            while (index1 < dataRowArray1.Length)
            {
              DataRow dataRow = dataRowArray1[index1];
              text = text + " / " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Title"])) + " " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["FirstName"])) + " " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["LastName"]));
              checked { ++index1; }
            }
            PrintHelper.ReplaceText(doc1, "[CustomerName]", text);
            PrintHelper.ReplaceText(doc1, "[Address1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["SiteAddress1"])));
            PrintHelper.ReplaceText(doc1, "[Address2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["SiteAddress2"])));
            PrintHelper.ReplaceText(doc1, "[Address3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["SiteAddress3"])));
            PrintHelper.ReplaceText(doc1, "[Postcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["SitePostcode"])));
            PrintHelper.ReplaceText(doc1, "[ContractType]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractType"])));
            PrintHelper.ReplaceText(doc1, "[ContractReference]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"])));
            PrintHelper.ReplaceText(doc1, "[ContractStart]", Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractStartDate"])).ToString("dd/MM/yyyy"));
            PrintHelper.ReplaceText(doc1, "[ContractEnd]", Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractEndDate"])).ToString("dd/MM/yyyy"));
            double num1 = Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["ContractPrice"])) * 1.2, 2);
            PrintHelper.ReplaceText(doc1, "[Total]", num1.ToString("C"));
            DataRow[] dataRowArray2 = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractSiteID"])), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteID"]))).Table.Select("Tick = 1");
            DataTable dt = new DataTable();
            dt.Columns.Add("ApplianceCount");
            dt.Columns.Add("Appliance");
            int num2 = 0;
            int num3 = 0;
            int num4 = 1;
            if (((IEnumerable<DataRow>) dataRowArray2).Count<DataRow>() > 0)
            {
              EnumerableRowCollection<DataRow> source1 = ((IEnumerable<DataRow>) dataRowArray2).CopyToDataTable<DataRow>().AsEnumerable();
              Func<DataRow, bool> predicate1;
              // ISSUE: reference to a compiler-generated field
              if (Printing._Closure\u0024__.\u0024I90\u002D0 != null)
              {
                // ISSUE: reference to a compiler-generated field
                predicate1 = Printing._Closure\u0024__.\u0024I90\u002D0;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                Printing._Closure\u0024__.\u0024I90\u002D0 = predicate1 = (Func<DataRow, bool>) (a => Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(a["PrimAsset"])));
              }
              EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate1);
              Func<DataRow, DataRow> selector1;
              // ISSUE: reference to a compiler-generated field
              if (Printing._Closure\u0024__.\u0024I90\u002D1 != null)
              {
                // ISSUE: reference to a compiler-generated field
                selector1 = Printing._Closure\u0024__.\u0024I90\u002D1;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                Printing._Closure\u0024__.\u0024I90\u002D1 = selector1 = (Func<DataRow, DataRow>) (a => a);
              }
              DataRow[] array1 = source2.Select<DataRow, DataRow>(selector1).ToArray<DataRow>();
              num2 = array1.Length;
              DataRow[] dataRowArray3 = array1;
              int index2 = 0;
              while (index2 < dataRowArray3.Length)
              {
                DataRow dataRow = dataRowArray3[index2];
                DataRow row = dt.NewRow();
                row["ApplianceCount"] = (object) ("APPLIANCE " + Conversions.ToString(num4));
                row["Appliance"] = RuntimeHelpers.GetObjectValue(dataRow["Product"]);
                dt.Rows.Add(row);
                checked { ++num4; }
                checked { ++index2; }
              }
              EnumerableRowCollection<DataRow> source3 = ((IEnumerable<DataRow>) dataRowArray2).CopyToDataTable<DataRow>().AsEnumerable();
              Func<DataRow, bool> predicate2;
              // ISSUE: reference to a compiler-generated field
              if (Printing._Closure\u0024__.\u0024I90\u002D2 != null)
              {
                // ISSUE: reference to a compiler-generated field
                predicate2 = Printing._Closure\u0024__.\u0024I90\u002D2;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                Printing._Closure\u0024__.\u0024I90\u002D2 = predicate2 = (Func<DataRow, bool>) (a => !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(a["PrimAsset"])));
              }
              EnumerableRowCollection<DataRow> source4 = source3.Where<DataRow>(predicate2);
              Func<DataRow, DataRow> selector2;
              // ISSUE: reference to a compiler-generated field
              if (Printing._Closure\u0024__.\u0024I90\u002D3 != null)
              {
                // ISSUE: reference to a compiler-generated field
                selector2 = Printing._Closure\u0024__.\u0024I90\u002D3;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                Printing._Closure\u0024__.\u0024I90\u002D3 = selector2 = (Func<DataRow, DataRow>) (a => a);
              }
              DataRow[] array2 = source4.Select<DataRow, DataRow>(selector2).ToArray<DataRow>();
              num3 = array2.Length;
              DataRow[] dataRowArray4 = array2;
              int index3 = 0;
              while (index3 < dataRowArray4.Length)
              {
                DataRow dataRow = dataRowArray4[index3];
                DataRow row = dt.NewRow();
                row["ApplianceCount"] = (object) ("APPLIANCE " + Conversions.ToString(num4));
                row["Appliance"] = RuntimeHelpers.GetObjectValue(dataRow["Product"]);
                dt.Rows.Add(row);
                checked { ++num4; }
                checked { ++index3; }
              }
            }
            int num5 = checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["MainAppliances"])) - num2 - 1);
            int num6 = 0;
            while (num6 <= num5)
            {
              DataRow row = dt.NewRow();
              row["ApplianceCount"] = (object) ("APPLIANCE " + Conversions.ToString(num4));
              row["Appliance"] = string.IsNullOrEmpty(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ManualApp"]))) ? (object) "UNKNOWN APPLIANCE" : (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ManualApp"]));
              dt.Rows.Add(row);
              checked { ++num4; }
              checked { ++num6; }
            }
            int num7 = checked (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SecondryAppliances"])) - num3 - 1);
            int num8 = 0;
            while (num8 <= num7)
            {
              DataRow row = dt.NewRow();
              row["ApplianceCount"] = (object) ("APPLIANCE " + Conversions.ToString(num4));
              row["Appliance"] = string.IsNullOrEmpty(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ManualApp"]))) ? (object) "UNKNOWN APPLIANCE" : (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["SecondApp"]));
              dt.Rows.Add(row);
              checked { ++num4; }
              checked { ++num8; }
            }
            PrintHelper.ReplaceBookmarkWithTable(doc1, "ApplianceTable", dt, false, Enums.TableCellProperties.ContractAppliance);
            bool flag2 = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dr["WindowLockPest"]));
            bool flag3 = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dr["PlumbingDrainage"]));
            bool flag4 = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dr["GasSupplyPipework"]));
            PrintHelper.ReplaceText(doc1, "[GasSupplyPipework]", flag4 ? "Yes" : "No");
            PrintHelper.ReplaceText(doc1, "[PlumbingDrainage]", flag3 ? "Yes" : "No");
            PrintHelper.ReplaceText(doc1, "[WindowLockPest]", flag2 ? "Yes" : "No");
            PrintHelper.ReplaceText(doc1, "[UserName]", App.TheSystem.Configuration.CompanyName + " Coverplan Team");
            int num9 = Helper.MakeIntegerValid((object) doc1.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
            DocumentFormat.OpenXml.Wordprocessing.Paragraph newChild = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
            {
              (OpenXmlElement) new Run(new OpenXmlElement[1]
              {
                (OpenXmlElement) new Break()
                {
                  Type = (EnumValue<BreakValues>) BreakValues.Page
                }
              })
            });
            doc1.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(newChild, (OpenXmlElement) doc1.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            doc1.MainDocumentPart.Document.Save();
            byte[] buffer2 = File.ReadAllBytes(System.Windows.Forms.Application.StartupPath + "\\Templates\\Contracts\\ContractTermsAndConditions.docx");
            MemoryStream memoryStream2 = new MemoryStream();
            using (memoryStream2)
            {
              memoryStream2.Write(buffer2, 0, buffer2.Length);
              WordprocessingDocument doc2 = WordprocessingDocument.Open((Stream) memoryStream2, true);
              using (doc2)
              {
                if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["DiscountID"])) != 68698)
                {
                  PrintHelper.DeleteBookmark(doc2, "EmployeeRef");
                  PrintHelper.DeleteBookmark(doc2, "EmployeeRef1");
                  PrintHelper.DeleteBookmark(doc2, "EmployeeRef2");
                  PrintHelper.DeleteBookmark(doc2, "EmployeeRef3");
                  PrintHelper.DeleteBookmark(doc2, "EmployeeRef4");
                }
                int num10 = Helper.MakeIntegerValid((object) doc2.ExtendedFilePropertiesPart.Properties.Pages.InnerText);
                int num11 = checked (1 + (unchecked (checked (num9 + num10) % 2 == 0) ? 0 : 1) - 1);
                int num12 = 0;
                while (num12 <= num11)
                {
                  doc2.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
                  {
                    (OpenXmlElement) new Run(new OpenXmlElement[1]
                    {
                      (OpenXmlElement) new Break()
                      {
                        Type = (EnumValue<BreakValues>) BreakValues.Page
                      }
                    })
                  }), (OpenXmlElement) doc2.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
                  checked { ++num12; }
                }
                doc2.MainDocumentPart.Document.Save();
              }
              MainDocumentPart mainDocumentPart = doc1.MainDocumentPart;
              string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
              AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
              memoryStream2.Position = 0L;
              using (memoryStream2)
                formatImportPart.FeedData((Stream) memoryStream2);
              mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
              {
                Id = (StringValue) id
              }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
              mainDocumentPart.Document.Save();
            }
          }
          string path = App.TheSystem.Configuration.DocumentsLocation + "SiteContracts\\" + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"]));
          Directory.CreateDirectory(path);
          string str2 = "Contract_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
          string str3 = this.FileCheck(path + "\\" + str2);
          FileStream fileStream = new FileStream(str3, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          memoryStream1.Position = 0L;
          using (fileStream)
            memoryStream1.WriteTo((Stream) fileStream);
          fileStream.Close();
          if (batch != null)
          {
            MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
            string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
            AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
            memoryStream1.Position = 0L;
            using (memoryStream1)
              formatImportPart.FeedData((Stream) memoryStream1);
            mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
            {
              Id = (StringValue) id
            }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            mainDocumentPart.Document.Save();
          }
          else
            Process.Start(str3);
        }
        flag1 = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate contract letter : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      return flag1;
    }

    private bool GenerateReceipt(
      DataRow dr,
      WordprocessingDocument batch,
      bool isCommercial = false,
      bool addPage = true)
    {
      bool flag1;
      try
      {
        if (dr.Table.Columns.Contains("UpgradedFrom") && Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["UpgradedFrom"])).Length > 0)
        {
          flag1 = true;
        }
        else
        {
          Enums.InvoiceFrequency invoiceFrequency = (Enums.InvoiceFrequency) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["InvoiceFrequencyID"]));
          string str1 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Invoice\\Receipt.docx";
          string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"])));
          byte[] buffer = File.ReadAllBytes(str1);
          MemoryStream memoryStream = new MemoryStream();
          using (memoryStream)
          {
            memoryStream.Write(buffer, 0, buffer.Length);
            WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream) memoryStream, true);
            using (doc1)
            {
              PrintHelper.ReplaceText(doc1, "[GoldenRule]", documentGoldenRule);
              this.AddCompanyDetails(doc1, true, false, isCommercial);
              PrintHelper.ReplaceText(doc1, "[PayerName]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerName"])));
              PrintHelper.ReplaceText(doc1, "[PayerAddress1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Payeraddress1"])));
              PrintHelper.ReplaceText(doc1, "[PayerAddress2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress2"])));
              PrintHelper.ReplaceText(doc1, "[PayerAddress3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress3"])));
              PrintHelper.ReplaceText(doc1, "[PayerPostcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["PayerPostcode"])));
              PrintHelper.ReplaceText(doc1, "[InvoiceNumber]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InvoiceNumber"])));
              PrintHelper.ReplaceText(doc1, "[RaiseDate]", Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["RaiseDate"])).ToString("dd/MM/yyyy"));
              PrintHelper.ReplaceText(doc1, "[AccountNumber]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["CustAcc"])));
              DataTable dt = new DataTable();
              dt.Columns.Add("ContractReference");
              dt.Columns.Add("Address");
              dt.Columns.Add("Work");
              dt.Columns.Add("Total");
              DataRow row = dt.NewRow();
              row["ContractReference"] = string.IsNullOrEmpty(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PoNumber"]))) ? (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"])) : (object) Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["ContractReference"], (object) " / "), dr["PoNumber"]));
              row["Address"] = (object) Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["SiteAddress1"], (object) ", "), dr["SiteAddress2"]), (object) ", "), dr["SitePostcode"]));
              string Left = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Type"]));
              string str2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractType"]));
              int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["installments"]));
              bool flag2 = false;
              bool flag3 = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dr["Renewed"]));
              double num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["ContractPrice"]));
              double num3 = 0.0;
              if (num1 % 12 != 0 || (uint) num1 <= 0U)
                flag2 = true;
              double num4;
              DateTime dateTime;
              if (flag3 && num1 == 0)
              {
                DataRow dataRow = row;
                string[] strArray = new string[6]
                {
                  str2,
                  " Coverplan Renewal \r\n\r\nPaid ",
                  null,
                  null,
                  null,
                  null
                };
                num4 = Math.Round(num2 * 1.2, 2);
                strArray[2] = num4.ToString("C");
                strArray[3] = " by ";
                strArray[4] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InitialPaymentType"]));
                strArray[5] = ", received with thanks.";
                string str3 = string.Concat(strArray) + "\r\n\r\nPlease find enclosed your certificate of cover.\r\n\r\nThank you for renewing your plan.";
                dataRow["Work"] = (object) str3;
                row["Total"] = (object) num2.ToString("C");
                num3 += num2;
              }
              else
              {
                int num5;
                switch (num1)
                {
                  case 0:
                    DataRow dataRow1 = row;
                    string[] strArray1 = new string[8];
                    strArray1[0] = str2;
                    strArray1[1] = " Coverplan commencing ";
                    dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractStartDate"]));
                    strArray1[2] = dateTime.ToString("dd/MM/yyyy");
                    strArray1[3] = ".\r\n\r\nPaid ";
                    strArray1[4] = Math.Round(num2 * 1.2, 2).ToString("C");
                    strArray1[5] = " by ";
                    strArray1[6] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InitialPaymentType"]));
                    strArray1[7] = ", received with thanks. \r\n\r\nPlease find enclosed your certificate of cover.\r\n\r\nThank you for taking out this plan.";
                    string str3 = string.Concat(strArray1);
                    dataRow1["Work"] = (object) str3;
                    row["Total"] = (object) num2.ToString("C");
                    num3 += num2;
                    goto label_21;
                  case 1:
                    num5 = 1;
                    break;
                  default:
                    num5 = invoiceFrequency == Enums.InvoiceFrequency.AnnuallyDD ? 1 : 0;
                    break;
                }
                if (num5 != 0)
                {
                  DataRow dataRow2 = row;
                  string[] strArray2 = new string[6]
                  {
                    str2,
                    " Coverplan commencing ",
                    null,
                    null,
                    null,
                    null
                  };
                  dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractStartDate"]));
                  strArray2[2] = dateTime.ToString("dd/MM/yyyy");
                  strArray2[3] = ".\r\n\r\n1 payment of ";
                  strArray2[4] = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])).ToString("C");
                  strArray2[5] = " to be paid annually by direct debit";
                  string str4 = string.Concat(strArray2) + "\r\n\r\nPlease find enclosed your certificate of cover.\r\n\r\nThank you for taking out this plan.";
                  dataRow2["Work"] = (object) str4;
                  DataRow dataRow3 = row;
                  num4 = Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])) / 1.2, 2, MidpointRounding.AwayFromZero);
                  string str5 = num4.ToString("C");
                  dataRow3["Total"] = (object) str5;
                  num3 += Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])) / 1.2, 2, MidpointRounding.AwayFromZero);
                }
                else if (num1 > 0 && flag2 && (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMMENDD", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "TRANSD", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "RENEWALD", false) == 0))
                {
                  DataRow dataRow2 = row;
                  string[] strArray2 = new string[10];
                  strArray2[0] = str2;
                  strArray2[1] = " Coverplan commencing ";
                  dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractStartDate"]));
                  strArray2[2] = dateTime.ToString("dd/MM/yyyy");
                  strArray2[3] = ".\r\n\r\n1st payment of ";
                  strArray2[4] = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])).ToString("C");
                  strArray2[5] = " paid by ";
                  strArray2[6] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InitialPaymentType"]));
                  strArray2[7] = ", received with thanks. ";
                  strArray2[8] = Conversions.ToString(num1);
                  strArray2[9] = " payments to be paid by monthly direct debit \r\n\r\nPlease find enclosed your certificate of cover.\r\n\r\nThank you for renewing your plan.";
                  string str4 = string.Concat(strArray2);
                  dataRow2["Work"] = (object) str4;
                  row["Total"] = (object) Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                  num3 += Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])) / 1.2, 2, MidpointRounding.AwayFromZero);
                }
                else if (num1 > 0 && flag2)
                {
                  DataRow dataRow2 = row;
                  string[] strArray2 = new string[10];
                  strArray2[0] = str2;
                  strArray2[1] = " Coverplan commencing ";
                  dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractStartDate"]));
                  strArray2[2] = dateTime.ToString("dd/MM/yyyy");
                  strArray2[3] = ".\r\n\r\n1st payment of ";
                  strArray2[4] = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])).ToString("C");
                  strArray2[5] = " paid by ";
                  strArray2[6] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InitialPaymentType"]));
                  strArray2[7] = ", received with thanks. ";
                  strArray2[8] = Conversions.ToString(num1);
                  strArray2[9] = " payments to be paid by monthly direct debit \r\n\r\nPlease find enclosed your certificate of cover.\r\n\r\nThank you for taking out this plan.";
                  string str4 = string.Concat(strArray2);
                  dataRow2["Work"] = (object) str4;
                  row["Total"] = (object) Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                  num3 += Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])) / 1.2, 2, MidpointRounding.AwayFromZero);
                }
                else if (num1 > 0)
                {
                  DataRow dataRow2 = row;
                  string[] strArray2 = new string[6]
                  {
                    str2,
                    " Coverplan commencing ",
                    null,
                    null,
                    null,
                    null
                  };
                  dateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["ContractStartDate"]));
                  strArray2[2] = dateTime.ToString("dd/MM/yyyy");
                  strArray2[3] = ".\r\n\r\n1 payment of ";
                  strArray2[4] = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])).ToString("C");
                  strArray2[5] = " to be paid by Annual direct debit \r\n\r\nPlease find enclosed your certificate of cover.\r\n\r\nThank you for taking out this plan.";
                  string str4 = string.Concat(strArray2);
                  dataRow2["Work"] = (object) str4;
                  row["Total"] = (object) Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])) / 1.2, 2, MidpointRounding.AwayFromZero).ToString("C");
                  num3 += Math.Round(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["FirstAmount"])) / 1.2, 2, MidpointRounding.AwayFromZero);
                }
              }
label_21:
              dt.Rows.Add(row);
              PrintHelper.AddRowsToTable(doc1, "Job No", dt, "Arial", "20", 0);
              WordprocessingDocument doc2 = doc1;
              num4 = Math.Round(num3, 2);
              string text1 = num4.ToString("C");
              PrintHelper.ReplaceText(doc2, "[TxVAT]", text1);
              WordprocessingDocument doc3 = doc1;
              num4 = Helper.RoundDown(num3 * 0.2, 2);
              string text2 = num4.ToString("C");
              PrintHelper.ReplaceText(doc3, "[VAT]", text2);
              WordprocessingDocument doc4 = doc1;
              num4 = Helper.RoundDown(num3 * 1.2, 2);
              string text3 = num4.ToString("C");
              PrintHelper.ReplaceText(doc4, "[TiVAT]", text3);
              if (addPage)
              {
                int num5 = checked (1 + (unchecked (Helper.MakeIntegerValid((object) doc1.ExtendedFilePropertiesPart.Properties.Pages.InnerText) % 2 == 0) ? 0 : 1) - 1);
                int num6 = 0;
                while (num6 <= num5)
                {
                  doc1.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
                  {
                    (OpenXmlElement) new Run(new OpenXmlElement[1]
                    {
                      (OpenXmlElement) new Break()
                      {
                        Type = (EnumValue<BreakValues>) BreakValues.Page
                      }
                    })
                  }), (OpenXmlElement) doc1.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
                  checked { ++num6; }
                }
              }
              doc1.MainDocumentPart.Document.Save();
              string path = App.TheSystem.Configuration.DocumentsLocation + "SiteContracts\\" + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"]));
              Directory.CreateDirectory(path);
              dateTime = DateTime.Now;
              string str6 = "Receipt_" + dateTime.ToString("dd_MM_yyyy_HH_mm") + ".docx";
              FileStream fileStream = new FileStream(this.FileCheck(path + "\\" + str6), FileMode.OpenOrCreate, FileAccess.ReadWrite);
              memoryStream.Position = 0L;
              using (fileStream)
                memoryStream.WriteTo((Stream) fileStream);
              fileStream.Close();
            }
            MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
            string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
            AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
            memoryStream.Position = 0L;
            using (memoryStream)
              formatImportPart.FeedData((Stream) memoryStream);
            mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
            {
              Id = (StringValue) id
            }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
            mainDocumentPart.Document.Save();
          }
          flag1 = true;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate dd renewal letter : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag1 = false;
        ProjectData.ClearProjectError();
      }
      return flag1;
    }

    private bool GenerateCredit(DataTable dt, string savePath)
    {
      bool flag;
      try
      {
        DataRow[] dataRowArray1 = !dt.Columns.Contains("Credit") ? dt.Select("Amount > 0") : dt.Select("Credit > 0");
        DataTable table1 = App.DB.Invoiced.InvoiceDetails_Get_InvoicedID(Conversions.ToInteger(dt.Rows[0]["InvoicedID"])).Table;
        if (table1.Rows.Count > 0 && dataRowArray1.Length > 0)
        {
          string path = System.Windows.Forms.Application.StartupPath + "\\Templates\\Invoice\\SalesCredit.docx";
          double num1 = 0.0;
          SalesCredit salesCredit = dataRowArray1.Length == 1 ? App.DB.SalesCredit.SalesCredit_Get(Conversions.ToInteger(dataRowArray1[0]["SalesCreditID"])) : App.DB.SalesCredit.SalesCredit_Get_For_InvoicedLine(Conversions.ToInteger(dataRowArray1[0]["InvoicedLineID"]));
          Site site1 = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
          byte[] buffer = File.ReadAllBytes(path);
          MemoryStream memoryStream = new MemoryStream();
          using (memoryStream)
          {
            memoryStream.Write(buffer, 0, buffer.Length);
            WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream) memoryStream, true);
            using (doc1)
            {
              this.AddCompanyDetails(doc1, true, false, site1.RegionID == 68517);
              PrintHelper.ReplaceText(doc1, "[PayerName]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["SiteName"])));
              PrintHelper.ReplaceText(doc1, "[PayerAddress1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["address1"])));
              PrintHelper.ReplaceText(doc1, "[PayerAddress2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["address2"])));
              PrintHelper.ReplaceText(doc1, "[PayerAddress3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["address3"])));
              PrintHelper.ReplaceText(doc1, "[PayerPostcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(table1.Rows[0]["postcode"])));
              PrintHelper.ReplaceText(doc1, "[InvoiceNumber]", Helper.MakeStringValid((object) salesCredit.CreditReference));
              PrintHelper.ReplaceText(doc1, "[RaiseDate]", Conversions.ToString(Helper.MakeDateTimeValid((object) salesCredit.DateCredited.ToString("dd/MM/yyyy"))));
              PrintHelper.ReplaceText(doc1, "[AccountNumber]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["AccountNumber"])));
              DataTable dt1 = new DataTable();
              dt1.Columns.Add("ContractReference");
              dt1.Columns.Add("Address");
              dt1.Columns.Add("Work");
              dt1.Columns.Add("Total");
              DataRow[] dataRowArray2 = dataRowArray1;
              int index = 0;
              double num2;
              while (index < dataRowArray2.Length)
              {
                DataRow dataRow1 = dataRowArray2[index];
                DataRow row = dt1.NewRow();
                App.DB.InvoicedLines.InvoicedLines_Get(Conversions.ToInteger(dataRow1["InvoicedLineID"]));
                row["ContractReference"] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["PoNumber"])).Length == 0 ? (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow1["JobNumber"])) : (object) Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow1["JobNumber"], (object) " / "), dataRow1["PoNumber"]));
                switch ((Enums.InvoiceType) Conversions.ToInteger(dataRow1["InvoiceTypeID"]))
                {
                  case Enums.InvoiceType.Visit:
                    Site site2 = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(dataRow1["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
                    row["Address"] = (object) (site2.Address1 + ", " + site2.Address2 + ", " + Helper.FormatPostcode((object) site1.Postcode));
                    row["Work"] = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow1["NotesFromEngineer"], (object) "\r\n"), (object) "\r\n"), (object) "Credit Against Invoice "), (object) dataRow1["InvoiceNumber"].ToString()), (object) " - "), (object) salesCredit.ReasonForCredit);
                    DataRow dataRow2 = row;
                    num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow1["Credit"]));
                    string str1 = num2.ToString("C");
                    dataRow2["Total"] = (object) str1;
                    num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow1["Credit"]));
                    break;
                  case Enums.InvoiceType.Order:
                    double num3 = 0.0;
                    DataTable table2 = App.DB.Order.Order_ItemsGetAll(Conversions.ToInteger(dataRow1["OrderID"])).Table;
                    IEnumerator enumerator;
                    if (table2.Rows.Count > 0)
                    {
                      try
                      {
                        enumerator = table2.Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                          DataRow current = (DataRow) enumerator.Current;
                          num3 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["QuantityReceived"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["SellPrice"]));
                        }
                      }
                      finally
                      {
                        if (enumerator is IDisposable)
                          (enumerator as IDisposable).Dispose();
                      }
                    }
                    Site site3 = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(dataRow1["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
                    row["Address"] = (object) (site3.Address1 + ", " + site3.Address2 + ", " + Helper.FormatPostcode((object) site3.Postcode));
                    row["Work"] = (object) "";
                    row["Total"] = (object) num3.ToString("C");
                    num1 += num3;
                    break;
                  case Enums.InvoiceType.Contract_Option1:
                    Site site4 = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(dataRow1["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
                    row["Address"] = (object) (site4.Address1 + ", " + site4.Address2 + ", " + Helper.FormatPostcode((object) site4.Postcode));
                    row["Work"] = site4.RegionID != 68517 ? (object) ("Contract Payment \r\n\r\nCredit Against Invoice " + dataRow1["InvoiceNumber"].ToString() + " - " + salesCredit.ReasonForCredit) : (object) ("Periodic Service Charge \r\n\r\nCredit Against Invoice " + dataRow1["InvoiceNumber"].ToString() + " - " + salesCredit.ReasonForCredit);
                    DataRow dataRow3 = row;
                    num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow1["Credit"]));
                    string str2 = num2.ToString("C");
                    dataRow3["Total"] = (object) str2;
                    num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow1["Credit"]));
                    break;
                }
                dt1.Rows.Add(row);
                checked { ++index; }
              }
              PrintHelper.AddRowsToTable(doc1, "Job No", dt1, "Arial", "20", 0);
              Decimal num4 = Decimal.Divide(new Decimal(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["VATRATE"]))), new Decimal(100L));
              WordprocessingDocument doc2 = doc1;
              num2 = Math.Round(num1, 2);
              string text1 = num2.ToString("C");
              PrintHelper.ReplaceText(doc2, "[TxVAT]", text1);
              WordprocessingDocument doc3 = doc1;
              num2 = Math.Round(num1 * Convert.ToDouble(num4), 2);
              string text2 = num2.ToString("C");
              PrintHelper.ReplaceText(doc3, "[VAT]", text2);
              WordprocessingDocument doc4 = doc1;
              num2 = Math.Round(num1 * Convert.ToDouble(num4) + num1, 2);
              string text3 = num2.ToString("C");
              PrintHelper.ReplaceText(doc4, "[TiVAT]", text3);
            }
            FileStream fileStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            memoryStream.Position = 0L;
            using (fileStream)
              memoryStream.WriteTo((Stream) fileStream);
            fileStream.Close();
          }
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate invoice : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateSalesInvoice(
      Invoiced invoice,
      WordprocessingDocument batch,
      bool isCommerical)
    {
      bool flag;
      try
      {
        DataTable table1 = App.DB.Invoiced.InvoiceDetails_Get_InvoicedID(invoice.InvoicedID).Table;
        if (table1.Rows.Count > 0)
        {
          string str1 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Invoice\\Invoice.docx";
          string str2 = App.TheSystem.Configuration.DocumentsLocation + "SiteInvoices\\" + invoice.InvoiceNumber + "\\Invoice_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
          string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid((object) invoice.InvoicedID));
          byte[] buffer = File.ReadAllBytes(str1);
          MemoryStream memoryStream = new MemoryStream();
          using (memoryStream)
          {
            memoryStream.Write(buffer, 0, buffer.Length);
            WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
            using (doc)
            {
              PrintHelper.ReplaceText(doc, "[GoldenRule]", documentGoldenRule);
              this.AddCompanyDetails(doc, true, false, isCommerical);
              PrintHelper.ReplaceText(doc, "[PayerName]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["SiteName"])));
              PrintHelper.ReplaceText(doc, "[PayerAddress1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["address1"])));
              PrintHelper.ReplaceText(doc, "[PayerAddress2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["address2"])));
              PrintHelper.ReplaceText(doc, "[PayerAddress3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["address3"])));
              PrintHelper.ReplaceText(doc, "[PayerPostcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(table1.Rows[0]["postcode"])));
              PrintHelper.ReplaceText(doc, "[InvoiceNumber]", invoice.InvoiceNumber);
              PrintHelper.ReplaceText(doc, "[RaiseDate]", Helper.MakeDateTimeValid((object) invoice.RaisedDate).ToString("dd/MM/yyyy"));
              PrintHelper.ReplaceText(doc, "[AccountNumber]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["AccountNumber"])));
              DataTable table2 = App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(invoice.InvoicedID).Table;
              if (table2.Rows.Count > 0)
              {
                double num1 = 0.0;
                DataTable dt = new DataTable();
                dt.Columns.Add("Job");
                dt.Columns.Add("Address");
                dt.Columns.Add("Work");
                dt.Columns.Add("Total");
                IEnumerator enumerator1;
                try
                {
                  enumerator1 = table2.Rows.GetEnumerator();
                  while (enumerator1.MoveNext())
                  {
                    DataRow current1 = (DataRow) enumerator1.Current;
                    DataRow row = dt.NewRow();
                    row["Job"] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["PoNumber"])).Length == 0 ? (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["JobNumber"])) : (object) Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current1["JobNumber"], (object) " / "), current1["PoNumber"]));
                    string Notes = App.DB.Invoiced.Invoice_GetAdditionalNotes(invoice.InvoicedID);
                    Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(current1["SiteID"]), SiteSQL.GetBy.SiteId, (object) null);
                    row["Address"] = (object) (site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode((object) site.Postcode) + " Ref: " + site.PolicyNumber);
                    if (string.IsNullOrEmpty(Notes))
                    {
                      Notes = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Notes"]));
                      if (!string.IsNullOrEmpty(Notes))
                        App.DB.Invoiced.Invoice_UpdateAdditionalNotes(invoice.InvoicedID, Notes);
                    }
                    double num2;
                    switch ((Enums.InvoiceType) Conversions.ToInteger(current1["InvoiceTypeID"]))
                    {
                      case Enums.InvoiceType.Visit:
                        if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current1["UseSORDescription"])))
                        {
                          DataTable table3 = App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(Conversions.ToInteger(current1["EngineerVisitID"])).Table;
                          string str3 = "";
                          double num3 = 0.0;
                          DataRow[] dataRowArray = table3.Select("tick = 1");
                          int index = 0;
                          while (index < dataRowArray.Length)
                          {
                            DataRow dataRow = dataRowArray[index];
                            str3 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str3, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["NumUnitsUsed"], (object) " X "), dataRow["code"]), (object) "-"), dataRow["Summary"]), (object) "(£"), dataRow["Price"]), (object) ")"), (object) "\r\n"), (object) "\r\n")));
                            double num4 = num3;
                            num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["Total"]));
                            double num5 = Conversions.ToDouble(num2.ToString("C"));
                            num3 = num4 + num5;
                            checked { ++index; }
                          }
                          row["Work"] = (object) str3;
                          row["Total"] = (object) num3.ToString("C");
                          num1 += num3;
                          break;
                        }
                        row["Work"] = RuntimeHelpers.GetObjectValue(current1["NotesFromEngineer"]);
                        DataRow dataRow1 = row;
                        num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current1["Amount"]));
                        string str4 = num2.ToString("C");
                        dataRow1["Total"] = (object) str4;
                        num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current1["Amount"]));
                        break;
                      case Enums.InvoiceType.Order:
                        double num6 = 0.0;
                        DataTable table4 = App.DB.Order.Order_ItemsGetAll(Conversions.ToInteger(current1["OrderID"])).Table;
                        IEnumerator enumerator2;
                        if (table4.Rows.Count > 0)
                        {
                          try
                          {
                            enumerator2 = table4.Rows.GetEnumerator();
                            while (enumerator2.MoveNext())
                            {
                              DataRow current2 = (DataRow) enumerator2.Current;
                              num6 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current2["QuantityReceived"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current2["SellPrice"]));
                            }
                          }
                          finally
                          {
                            if (enumerator2 is IDisposable)
                              (enumerator2 as IDisposable).Dispose();
                          }
                        }
                        row["Total"] = (object) num6.ToString("C");
                        num1 += num6;
                        break;
                      case Enums.InvoiceType.Contract_Option1:
                        string str5;
                        switch (App.DB.ContractOriginal.Get(Conversions.ToInteger(current1["ContractID"])).InvoiceFrequencyID)
                        {
                          case 2:
                            str5 = "Monthly";
                            break;
                          case 3:
                            str5 = "Quarterly";
                            break;
                          case 4:
                            str5 = "Bi-Annual";
                            break;
                          case 6:
                            str5 = "Annual";
                            break;
                          case 8:
                            str5 = "4 Month";
                            break;
                          default:
                            str5 = "";
                            break;
                        }
                        if (site.RegionID == 68517)
                        {
                          row["Work"] = (object) (str5 + " Service Charge for Gasway Commercial maintenance contract");
                        }
                        else
                        {
                          row["Work"] = (object) "Contract Payment";
                          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.details1, "DDRECEIPT", false) == 0)
                            row["Work"] = (object) ("Unpaid Direct Debit collection for the month of " + invoice.RaisedDate.ToString("MMMM") + ".\r\n\r\nPaid by " + this.details2 + ", received with thanks.");
                          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.details1, "DDINVOICE", false) == 0)
                            row["Work"] = (object) ("Unpaid Direct Debit collection for the month of " + invoice.RaisedDate.ToString("MMMM") + ".\r\n\r\nPlease arrange payment to cover this shortfall");
                        }
                        DataRow dataRow2 = row;
                        num2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current1["Amount"]));
                        string str6 = num2.ToString("C");
                        dataRow2["Total"] = (object) str6;
                        num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current1["Amount"]));
                        break;
                    }
                    if (!string.IsNullOrEmpty(Notes))
                    {
                      DataRow dataRow3;
                      (dataRow3 = row)["Work"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow3["Work"], (object) ("\r\n\r\n" + Notes));
                    }
                    dt.Rows.Add(row);
                  }
                }
                finally
                {
                  if (enumerator1 is IDisposable)
                    (enumerator1 as IDisposable).Dispose();
                }
                DataRow row1 = dt.Rows[checked (table1.Rows.Count - 1)];
                DataTable dataTable = App.DB.ExecuteWithReturn("SELECT PT.Name as PaymentTerm, ISNULL(PB.NAme,'') as PaymentBy from tblinvoiced I INNER JOIN tblpicklists PT ON PT.ManagerID = I.TermID LEFT JOIN tblpicklists PB ON PB.managerid = I.PaidByID WHERE InvoicedID = " + Conversions.ToString(invoice.InvoicedID), true);
                if (dataTable.Rows.Count > 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataTable.Rows[0]["PaymentTerm"], (object) "RECEIPT", false))
                  {
                    PrintHelper.ReplaceText(doc, "INVOICE", "RECEIPT");
                    PrintHelper.ReplaceText(doc, "STRICTLY 30 DAYS NET", "PAID WITH THANKS");
                    DataRow dataRow;
                    (dataRow = row1)["Work"] = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(dataRow["Work"], Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "\r\n\r\nPaid by ", dataTable.Rows[0]["PaymentBy"]), (object) " With thanks."));
                  }
                  else
                    PrintHelper.ReplaceText(doc, "STRICTLY 30 DAYS NET", Conversions.ToString(dataTable.Rows[0]["PaymentTerm"]));
                }
                PrintHelper.AddRowsToTable(doc, "Job No", dt, "Arial", "20", 0);
                Decimal num7 = Decimal.Divide(new Decimal(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["VATRATE"]))), new Decimal(100L));
                PrintHelper.ReplaceText(doc, "[TxVAT]", Math.Round(num1, 2).ToString("C"));
                PrintHelper.ReplaceText(doc, "[VAT]", Math.Round(num1 * Convert.ToDouble(num7), 2).ToString("C"));
                PrintHelper.ReplaceText(doc, "[TiVAT]", Math.Round(num1 * Convert.ToDouble(num7) + num1, 2).ToString("C"));
                doc.MainDocumentPart.Document.Save();
                Directory.CreateDirectory(Path.GetDirectoryName(str2));
                str2 = this.FileCheck(str2);
                FileStream fileStream = new FileStream(str2, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                memoryStream.Position = 0L;
                using (fileStream)
                  memoryStream.WriteTo((Stream) fileStream);
              }
            }
            if (batch != null)
            {
              MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
              string id = "AltId" + Conversions.ToString(invoice.InvoicedID) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
              AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
              memoryStream.Position = 0L;
              using (memoryStream)
                formatImportPart.FeedData((Stream) memoryStream);
              mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
              {
                Id = (StringValue) id
              }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
              mainDocumentPart.Document.Save();
            }
            else
              Process.Start(str2);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate invoice : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_75;
      }
label_75:
      return flag;
    }

    private bool GenerateContractInvoice(
      DataRow dr,
      WordprocessingDocument batch,
      bool isCommerical = false,
      bool addPage = true)
    {
      bool flag;
      try
      {
        string str1 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Invoice\\Invoice.docx";
        string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"])));
        byte[] buffer = File.ReadAllBytes(str1);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc1 = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc1)
          {
            PrintHelper.ReplaceText(doc1, "[GoldenRule]", documentGoldenRule);
            this.AddCompanyDetails(doc1, true, false, isCommerical);
            PrintHelper.ReplaceText(doc1, "[PayerName]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerName"])));
            PrintHelper.ReplaceText(doc1, "[PayerAddress1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Payeraddress1"])));
            PrintHelper.ReplaceText(doc1, "[PayerAddress2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress2"])));
            PrintHelper.ReplaceText(doc1, "[PayerAddress3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress3"])));
            PrintHelper.ReplaceText(doc1, "[PayerPostcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["PayerPostcode"])));
            PrintHelper.ReplaceText(doc1, "[InvoiceNumber]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["InvoiceNumber"])));
            PrintHelper.ReplaceText(doc1, "[RaiseDate]", Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dr["RaiseDate"])).ToString("dd/MM/yyyy"));
            PrintHelper.ReplaceText(doc1, "[AccountNumber]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["CustAcc"])));
            DataTable dt = new DataTable();
            dt.Columns.Add("ContractReference");
            dt.Columns.Add("Address");
            dt.Columns.Add("Work");
            dt.Columns.Add("Total");
            DataRow row = dt.NewRow();
            row["ContractReference"] = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PoNumber"])).Length == 0 ? (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"])) : (object) Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["ContractReference"], (object) " / "), dr["PoNumber"]));
            row["Address"] = (object) Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["SiteAddress1"], (object) ", "), dr["SiteAddress2"]), (object) ", "), dr["SitePostcode"]));
            string str2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractType"]));
            int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractTypeID"]));
            int num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SiteRegion"]));
            double num3 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dr["ContractPrice"]));
            double num4 = 0.0;
            if (num2 == 68517)
              row["Work"] = (object) "Periodic Service Charge";
            else if (num1 == 69173 || num1 == 69172)
            {
              row["Work"] = (object) (str2 + " Coverplan Renewal. \r\n\r\nBlanket cover for all gas appliances\r\n\r\nPlease find enclosed your certificate of cover.\r\n\r\nThank you for Renewing this plan.");
              row["Total"] = (object) num3.ToString("C");
              num4 += num3;
            }
            else
            {
              row["Work"] = (object) (str2 + " Coverplan Renewal. \r\n\r\nPlease find enclosed your certificate of cover.\r\n\r\nThank you for Renewing this plan.");
              row["Total"] = (object) num3.ToString("C");
              num4 += num3;
            }
            dt.Rows.Add(row);
            PrintHelper.AddRowsToTable(doc1, "Job No", dt, "20", "", 0);
            WordprocessingDocument doc2 = doc1;
            double num5 = Math.Round(num4, 2);
            string text1 = num5.ToString("C");
            PrintHelper.ReplaceText(doc2, "[TxVAT]", text1);
            WordprocessingDocument doc3 = doc1;
            num5 = Math.Round(num4 * 0.2, 2);
            string text2 = num5.ToString("C");
            PrintHelper.ReplaceText(doc3, "[VAT]", text2);
            WordprocessingDocument doc4 = doc1;
            num5 = Math.Round(num4 * 1.2, 2);
            string text3 = num5.ToString("C");
            PrintHelper.ReplaceText(doc4, "[TiVAT]", text3);
            if (addPage)
            {
              int num6 = checked (1 + (unchecked (Helper.MakeIntegerValid((object) doc1.ExtendedFilePropertiesPart.Properties.Pages.InnerText) % 2 == 0) ? 0 : 1) - 1);
              int num7 = 0;
              while (num7 <= num6)
              {
                doc1.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
                {
                  (OpenXmlElement) new Run(new OpenXmlElement[1]
                  {
                    (OpenXmlElement) new Break()
                    {
                      Type = (EnumValue<BreakValues>) BreakValues.Page
                    }
                  })
                }), (OpenXmlElement) doc1.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
                checked { ++num7; }
              }
            }
            doc1.MainDocumentPart.Document.Save();
            string path = App.TheSystem.Configuration.DocumentsLocation + "SiteContracts\\" + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"]));
            Directory.CreateDirectory(path);
            string str3 = "Invoice_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
            FileStream fileStream = new FileStream(this.FileCheck(path + "\\" + str3), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            memoryStream.Position = 0L;
            using (fileStream)
              memoryStream.WriteTo((Stream) fileStream);
            fileStream.Close();
          }
          MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
          string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
          AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
          memoryStream.Position = 0L;
          using (memoryStream)
            formatImportPart.FeedData((Stream) memoryStream);
          mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
          {
            Id = (StringValue) id
          }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
          mainDocumentPart.Document.Save();
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate invoice : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private bool GenerateTransferLetter(DataRow dr, WordprocessingDocument batch)
    {
      bool flag;
      try
      {
        string str1 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Contracts\\ContractTransfer.docx";
        string documentGoldenRule = this.GetDocumentGoldenRule(str1, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"])));
        byte[] buffer = File.ReadAllBytes(str1);
        MemoryStream memoryStream = new MemoryStream();
        using (memoryStream)
        {
          memoryStream.Write(buffer, 0, buffer.Length);
          WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
          using (doc)
          {
            PrintHelper.ReplaceText(doc, "[GoldenRule]", documentGoldenRule);
            PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
            string text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerSalutation"])).Length > 0 ? Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["PayerSalutation"], (object) " "), dr["PayerSurname"])) : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerName"]));
            PrintHelper.ReplaceText(doc, "[CompanyName]", text);
            PrintHelper.ReplaceText(doc, "[Name]", text);
            PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress1"])));
            PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress2"])));
            PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["PayerAddress3"])));
            PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dr["PayerPostcode"])));
            PrintHelper.ReplaceText(doc, "[Plan]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractType"])));
            PrintHelper.ReplaceText(doc, "[DebitRef2]", Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["ContractReference"], (object) " - "), dr["siteAddress1"]), (object) ", "), dr["siteAddress2"]), (object) ", "), dr["sitePostcode"])));
            PrintHelper.ReplaceText(doc, "[Site]", Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dr["siteAddress1"], (object) ", "), dr["siteAddress2"]), (object) ", "), dr["sitePostcode"])));
            PrintHelper.ReplaceText(doc, "[UserName]", App.TheSystem.Configuration.CompanyName + " Coverplan Team");
            int num1 = checked (1 + (unchecked (Helper.MakeIntegerValid((object) doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText) % 2 == 0) ? 0 : 1) - 1);
            int num2 = 0;
            while (num2 <= num1)
            {
              doc.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
              {
                (OpenXmlElement) new Run(new OpenXmlElement[1]
                {
                  (OpenXmlElement) new Break()
                  {
                    Type = (EnumValue<BreakValues>) BreakValues.Page
                  }
                })
              }), (OpenXmlElement) doc.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
              checked { ++num2; }
            }
            doc.MainDocumentPart.Document.Save();
            string path = App.TheSystem.Configuration.DocumentsLocation + "SiteContracts\\" + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["ContractReference"]));
            Directory.CreateDirectory(path);
            string str2 = "Transfer_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm") + ".docx";
            FileStream fileStream = new FileStream(this.FileCheck(path + "\\" + str2), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            memoryStream.Position = 0L;
            using (fileStream)
              memoryStream.WriteTo((Stream) fileStream);
            fileStream.Close();
          }
          MainDocumentPart mainDocumentPart = batch.MainDocumentPart;
          string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["ContractID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
          AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
          memoryStream.Position = 0L;
          using (memoryStream)
            formatImportPart.FeedData((Stream) memoryStream);
          mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
          {
            Id = (StringValue) id
          }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
          mainDocumentPart.Document.Save();
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate transfer letter : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private string GenerateAnnualExpiryLetters(DataRow[] drAnnualContracts)
    {
      string str1 = "Annual_Contract_Expiry_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".docx";
      string path1 = App.TheSystem.Configuration.DocumentsLocation + "Contracts\\AnnualExpiry";
      Directory.CreateDirectory(path1);
      string str2 = path1 + "\\" + str1;
      File.Copy(System.Windows.Forms.Application.StartupPath + "\\Templates\\ServiceLetter.docx", str2);
      string str3;
      try
      {
        WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(str2, true);
        using (wordprocessingDocument)
        {
          DataRow[] dataRowArray = drAnnualContracts;
          int index = 0;
          while (index < dataRowArray.Length)
          {
            DataRow dataRow = dataRowArray[index];
            try
            {
              if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["RenewalPrice"])) != 0.0)
              {
                string str4 = System.Windows.Forms.Application.StartupPath + "\\Templates\\Contracts\\AnnualContractExpiry.docx";
                string documentGoldenRule = this.GetDocumentGoldenRule(str4, Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["ContractID"])));
                byte[] buffer = File.ReadAllBytes(str4);
                MemoryStream memoryStream = new MemoryStream();
                using (memoryStream)
                {
                  memoryStream.Write(buffer, 0, buffer.Length);
                  WordprocessingDocument doc = WordprocessingDocument.Open((Stream) memoryStream, true);
                  using (doc)
                  {
                    PrintHelper.ReplaceText(doc, "[GoldenRule]", documentGoldenRule);
                    PrintHelper.ReplaceText(doc, "[Address1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["PayerAddress1"])));
                    PrintHelper.ReplaceText(doc, "[Address2]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["PayerAddress2"])));
                    PrintHelper.ReplaceText(doc, "[Address3]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["PayerAddress3"])));
                    PrintHelper.ReplaceText(doc, "[Postcode]", Helper.FormatPostcode(RuntimeHelpers.GetObjectValue(dataRow["PayerPostcode"])));
                    PrintHelper.ReplaceText(doc, "[Date]", DateTime.Now.ToString("dd/MM/yyyy"));
                    string text1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["PayerSalutation"])).Length > 0 ? Helper.MakeStringValid(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["PayerSalutation"], (object) " "), dataRow["PayerSurname"])) : Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["PayerName"]));
                    PrintHelper.ReplaceText(doc, "[CompanyName]", text1);
                    PrintHelper.ReplaceText(doc, "[ExpiryDate]", Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["ContractEndDate"])).ToString("dd/MM/yyyy"));
                    PrintHelper.ReplaceText(doc, "[User]", App.TheSystem.Configuration.CompanyName + " Coverplan Team");
                    PrintHelper.ReplaceText(doc, "[ContractType]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["ContractType"])));
                    PrintHelper.ReplaceText(doc, "[ContractReference]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["ContractReference"])));
                    PrintHelper.ReplaceText(doc, "[SiteAddress1]", Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["SiteAddress1"])));
                    string text2 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["RenewalPrice"])) == -1.0 ? 0.ToString("C") : Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["RenewalPrice"])).ToString("C");
                    PrintHelper.ReplaceText(doc, "[PriceSentence]", text2);
                    double num1 = Helper.MakeDoubleValid((object) App.DB.Picklists.Get_Single_Description("Additional Appliance", Enums.PickListTypes.ContractPricing));
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow["ContractType"], (object) "Platinum Star", false))
                      num1 = Helper.MakeDoubleValid((object) App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", Enums.PickListTypes.ContractPricing));
                    if (num1 > 0.0)
                    {
                      string text3 = "Please be advised that we are now offering cover for boilermates or any other make of thermal store product as an additional appliance. Should you have a thermal store product in your property and require cover, this could be added for an additional " + num1.ToString("C") + " per annum.";
                      PrintHelper.ReplaceText(doc, "[ExcludeSentence]", text3);
                    }
                    else
                      PrintHelper.DeleteBookmark(doc, "ExcludeSentence");
                    double num2 = Helper.MakeDoubleValid((object) App.DB.Picklists.Get_Single_Description("AHE", Enums.PickListTypes.ContractPricing));
                    PrintHelper.ReplaceText(doc, "[AHE]", num2.ToString("C"));
                    int num3 = checked (1 + (unchecked (Helper.MakeIntegerValid((object) doc.ExtendedFilePropertiesPart.Properties.Pages.InnerText) % 2 == 0) ? 0 : 1) - 1);
                    int num4 = 0;
                    while (num4 <= num3)
                    {
                      doc.MainDocumentPart.Document.Body.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Paragraph>(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
                      {
                        (OpenXmlElement) new Run(new OpenXmlElement[1]
                        {
                          (OpenXmlElement) new Break()
                          {
                            Type = (EnumValue<BreakValues>) BreakValues.Page
                          }
                        })
                      }), (OpenXmlElement) doc.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
                      checked { ++num4; }
                    }
                    doc.MainDocumentPart.Document.Save();
                    string path2 = App.TheSystem.Configuration.DocumentsLocation + "SiteContracts\\" + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["ContractReference"]));
                    Directory.CreateDirectory(path2);
                    FileStream fileStream = new FileStream(this.FileCheck(path2 + "\\" + str1), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    memoryStream.Position = 0L;
                    using (fileStream)
                      memoryStream.WriteTo((Stream) fileStream);
                    fileStream.Close();
                  }
                  MainDocumentPart mainDocumentPart = wordprocessingDocument.MainDocumentPart;
                  string id = "AltId" + Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["ContractID"]))) + DateTime.Now.ToString("ddMMyyyyHHmmssfff");
                  AlternativeFormatImportPart formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, id);
                  memoryStream.Position = 0L;
                  using (memoryStream)
                    formatImportPart.FeedData((Stream) memoryStream);
                  mainDocumentPart.Document.Body.InsertAfter<AltChunk>(new AltChunk()
                  {
                    Id = (StringValue) id
                  }, (OpenXmlElement) mainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last<DocumentFormat.OpenXml.Wordprocessing.Paragraph>());
                  mainDocumentPart.Document.Save();
                }
              }
              else
                goto label_35;
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Exception exception = ex;
              int num = (int) App.ShowMessage("Could not renewal letter for " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["ContractReference"])) + ": \r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              ProjectData.ClearProjectError();
            }
label_35:
            checked { ++index; }
          }
        }
        str3 = str2;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not renewal letter: \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        str3 = string.Empty;
        ProjectData.ClearProjectError();
      }
      return str3;
    }

    private string Finalise(
      string filepath,
      bool success,
      bool withSave = true,
      bool withKill = true,
      bool gsr = false)
    {
      int num1;
      string str;
      int num2;
      try
      {
label_2:
        ProjectData.ClearProjectError();
        num1 = -2;
label_3:
        int num3 = 2;
        if (!success)
          goto label_75;
label_4:
        num3 = 3;
        if (this.WordDoc == null)
          goto label_73;
label_5:
        num3 = 4;
        if (!withSave)
          goto label_71;
label_6:
        num3 = 5;
        if (filepath.Trim().Length <= 0)
          goto label_69;
label_7:
        num3 = 6;
        if (this.OrderID <= 0)
          goto label_44;
label_8:
        num3 = 7;
        if (this.answer != DialogResult.No)
          goto label_22;
label_9:
        num3 = 8;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Document wordDoc1 = this.WordDoc;
        object obj1 = (object) filepath;
        ref object local1 = ref obj1;
        object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local2 = ref objectValue1;
        object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local3 = ref objectValue2;
        object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local4 = ref objectValue3;
        object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local5 = ref objectValue4;
        object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local6 = ref objectValue5;
        object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local7 = ref objectValue6;
        object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local8 = ref objectValue7;
        object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local9 = ref objectValue8;
        object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local10 = ref objectValue9;
        object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local11 = ref objectValue10;
        object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local12 = ref objectValue11;
        object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local13 = ref objectValue12;
        object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local14 = ref objectValue13;
        object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local15 = ref objectValue14;
        object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local16 = ref objectValue15;
        // ISSUE: reference to a compiler-generated method
        wordDoc1.SaveAs(ref local1, ref local2, ref local3, ref local4, ref local5, ref local6, ref local7, ref local8, ref local9, ref local10, ref local11, ref local12, ref local13, ref local14, ref local15, ref local16);
label_10:
        num3 = 9;
        FSM.Entity.Documentss.Documents oDocuments1 = new FSM.Entity.Documentss.Documents();
label_11:
        num3 = 10;
        oDocuments1.SetTableEnumID = (object) 32;
label_12:
        num3 = 11;
        oDocuments1.SetRecordID = (object) this.OrderID;
label_13:
        num3 = 12;
        oDocuments1.SetDocumentTypeID = (object) 162;
label_14:
        num3 = 13;
        string[] strArray1 = filepath.Split('\\');
label_15:
        num3 = 14;
        oDocuments1.SetName = (object) strArray1[checked (filepath.Split('\\').Length - 1)];
label_16:
        num3 = 15;
        oDocuments1.SetNotes = (object) "";
label_17:
        num3 = 16;
        oDocuments1.SetLocation = (object) filepath;
label_18:
        num3 = 17;
        DocumentsValidator documentsValidator1 = new DocumentsValidator();
label_19:
        num3 = 18;
        documentsValidator1.Validate(oDocuments1);
label_20:
        num3 = 19;
        oDocuments1 = App.DB.Documents.Insert(oDocuments1, true);
label_21:
        num3 = 20;
        File.Delete(filepath);
        goto label_68;
label_22:
        num3 = 22;
        filepath = filepath.ToLower().Replace(".doc", ".pdf");
label_23:
        num3 = 23;
        if (!File.Exists(filepath))
          goto label_26;
label_24:
        num3 = 24;
        File.Delete(filepath);
label_25:
label_26:
label_27:
        num3 = 26;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Document wordDoc2 = this.WordDoc;
        object obj2 = (object) filepath;
        ref object local17 = ref obj2;
        object obj3 = (object) WdSaveFormat.wdFormatPDF;
        ref object local18 = ref obj3;
        object objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local19 = ref objectValue16;
        object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local20 = ref objectValue17;
        object objectValue18 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local21 = ref objectValue18;
        object objectValue19 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local22 = ref objectValue19;
        object objectValue20 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local23 = ref objectValue20;
        object objectValue21 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local24 = ref objectValue21;
        object objectValue22 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local25 = ref objectValue22;
        object objectValue23 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local26 = ref objectValue23;
        object objectValue24 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local27 = ref objectValue24;
        object objectValue25 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local28 = ref objectValue25;
        object objectValue26 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local29 = ref objectValue26;
        object objectValue27 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local30 = ref objectValue27;
        object objectValue28 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local31 = ref objectValue28;
        object objectValue29 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local32 = ref objectValue29;
        // ISSUE: reference to a compiler-generated method
        wordDoc2.SaveAs(ref local17, ref local18, ref local19, ref local20, ref local21, ref local22, ref local23, ref local24, ref local25, ref local26, ref local27, ref local28, ref local29, ref local30, ref local31, ref local32);
label_28:
        num3 = 27;
        Process.Start(filepath);
        goto label_31;
label_29:
        num3 = 30;
        Thread.Sleep(1000);
label_30:
label_31:
        num3 = 29;
        if (!File.Exists(filepath))
          goto label_29;
label_32:
        num3 = 32;
        FSM.Entity.Documentss.Documents oDocuments2 = new FSM.Entity.Documentss.Documents();
label_33:
        num3 = 33;
        oDocuments2.SetTableEnumID = (object) 32;
label_34:
        num3 = 34;
        oDocuments2.SetRecordID = (object) this.OrderID;
label_35:
        num3 = 35;
        oDocuments2.SetDocumentTypeID = (object) 162;
label_36:
        num3 = 36;
        string[] strArray2 = filepath.Split('\\');
label_37:
        num3 = 37;
        oDocuments2.SetName = (object) strArray2[checked (filepath.Split('\\').Length - 1)];
label_38:
        num3 = 38;
        oDocuments2.SetNotes = (object) "";
label_39:
        num3 = 39;
        oDocuments2.SetLocation = (object) filepath;
label_40:
        num3 = 40;
        DocumentsValidator documentsValidator2 = new DocumentsValidator();
label_41:
        num3 = 41;
        documentsValidator2.Validate(oDocuments2);
label_42:
        num3 = 42;
        oDocuments2 = App.DB.Documents.Insert(oDocuments2, true);
label_43:
        goto label_68;
label_44:
        num3 = 45;
        if (this.PrintType != Enums.SystemDocumentType.SiteLetter)
          goto label_61;
label_45:
        num3 = 46;
        FSM.Entity.Documentss.Documents oDocuments3 = new FSM.Entity.Documentss.Documents();
label_46:
        num3 = 47;
        oDocuments3.SetTableEnumID = (object) 24;
label_47:
        num3 = 48;
        oDocuments3.SetRecordID = (object) this.SiteID;
label_48:
        num3 = 49;
        oDocuments3.SetDocumentTypeID = (object) 205;
label_49:
        num3 = 50;
        string[] strArray3 = filepath.Split('\\');
label_50:
        num3 = 51;
        oDocuments3.SetName = (object) strArray3[checked (filepath.Split('\\').Length - 1)];
label_51:
        num3 = 52;
        if (Directory.Exists(filepath.Replace(oDocuments3.Name, "")))
          goto label_54;
label_52:
        num3 = 53;
        Directory.CreateDirectory(filepath.Replace(oDocuments3.Name, ""));
label_53:
label_54:
label_55:
        num3 = 55;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Document wordDoc3 = this.WordDoc;
        object obj4 = (object) filepath;
        ref object local33 = ref obj4;
        object objectValue30 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local34 = ref objectValue30;
        object objectValue31 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local35 = ref objectValue31;
        object objectValue32 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local36 = ref objectValue32;
        object objectValue33 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local37 = ref objectValue33;
        object objectValue34 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local38 = ref objectValue34;
        object objectValue35 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local39 = ref objectValue35;
        object objectValue36 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local40 = ref objectValue36;
        object objectValue37 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local41 = ref objectValue37;
        object objectValue38 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local42 = ref objectValue38;
        object objectValue39 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local43 = ref objectValue39;
        object objectValue40 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local44 = ref objectValue40;
        object objectValue41 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local45 = ref objectValue41;
        object objectValue42 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local46 = ref objectValue42;
        object objectValue43 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local47 = ref objectValue43;
        object objectValue44 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local48 = ref objectValue44;
        // ISSUE: reference to a compiler-generated method
        wordDoc3.SaveAs(ref local33, ref local34, ref local35, ref local36, ref local37, ref local38, ref local39, ref local40, ref local41, ref local42, ref local43, ref local44, ref local45, ref local46, ref local47, ref local48);
label_56:
        num3 = 56;
        oDocuments3.SetNotes = (object) "";
label_57:
        num3 = 57;
        oDocuments3.SetLocation = (object) filepath;
label_58:
        num3 = 58;
        DocumentsValidator documentsValidator3 = new DocumentsValidator();
label_59:
        num3 = 59;
        documentsValidator3.Validate(oDocuments3);
label_60:
        num3 = 60;
        oDocuments3 = App.DB.Documents.Insert(oDocuments3, true);
        goto label_68;
label_61:
        num3 = 62;
        filepath = this.FileCheck(filepath);
label_62:
        num3 = 63;
        string extension = Path.GetExtension(filepath);
label_63:
        num3 = 64;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(extension, ".pdf", false) != 0)
          goto label_65;
label_64:
        num3 = 65;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Document wordDoc4 = this.WordDoc;
        object obj5 = (object) filepath;
        ref object local49 = ref obj5;
        object obj6 = (object) WdSaveFormat.wdFormatPDF;
        ref object local50 = ref obj6;
        object objectValue45 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local51 = ref objectValue45;
        object objectValue46 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local52 = ref objectValue46;
        object objectValue47 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local53 = ref objectValue47;
        object objectValue48 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local54 = ref objectValue48;
        object objectValue49 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local55 = ref objectValue49;
        object objectValue50 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local56 = ref objectValue50;
        object objectValue51 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local57 = ref objectValue51;
        object objectValue52 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local58 = ref objectValue52;
        object objectValue53 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local59 = ref objectValue53;
        object objectValue54 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local60 = ref objectValue54;
        object objectValue55 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local61 = ref objectValue55;
        object objectValue56 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local62 = ref objectValue56;
        object objectValue57 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local63 = ref objectValue57;
        object objectValue58 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local64 = ref objectValue58;
        // ISSUE: reference to a compiler-generated method
        wordDoc4.SaveAs(ref local49, ref local50, ref local51, ref local52, ref local53, ref local54, ref local55, ref local56, ref local57, ref local58, ref local59, ref local60, ref local61, ref local62, ref local63, ref local64);
        goto label_67;
label_65:
        num3 = 67;
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Document wordDoc5 = this.WordDoc;
        object obj7 = (object) filepath;
        ref object local65 = ref obj7;
        object objectValue59 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local66 = ref objectValue59;
        object objectValue60 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local67 = ref objectValue60;
        object objectValue61 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local68 = ref objectValue61;
        object objectValue62 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local69 = ref objectValue62;
        object objectValue63 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local70 = ref objectValue63;
        object objectValue64 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local71 = ref objectValue64;
        object objectValue65 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local72 = ref objectValue65;
        object objectValue66 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local73 = ref objectValue66;
        object objectValue67 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local74 = ref objectValue67;
        object objectValue68 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local75 = ref objectValue68;
        object objectValue69 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local76 = ref objectValue69;
        object objectValue70 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local77 = ref objectValue70;
        object objectValue71 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local78 = ref objectValue71;
        object objectValue72 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local79 = ref objectValue72;
        object objectValue73 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local80 = ref objectValue73;
        // ISSUE: reference to a compiler-generated method
        wordDoc5.SaveAs(ref local65, ref local66, ref local67, ref local68, ref local69, ref local70, ref local71, ref local72, ref local73, ref local74, ref local75, ref local76, ref local77, ref local78, ref local79, ref local80);
label_66:
label_67:
label_68:
label_69:
label_70:
label_71:
label_72:
label_73:
label_74:
label_75:
label_76:
        num3 = 74;
        this.DestroyWord(withKill);
label_77:
        str = filepath;
        goto label_83;
label_79:
        num2 = num3;
        switch (num1 > -2 ? num1 : 1)
        {
          case 1:
            int num4 = num2 + 1;
            num2 = 0;
            switch (num4)
            {
              case 1:
                goto label_2;
              case 2:
                goto label_3;
              case 3:
                goto label_4;
              case 4:
                goto label_5;
              case 5:
                goto label_6;
              case 6:
                goto label_7;
              case 7:
                goto label_8;
              case 8:
                goto label_9;
              case 9:
                goto label_10;
              case 10:
                goto label_11;
              case 11:
                goto label_12;
              case 12:
                goto label_13;
              case 13:
                goto label_14;
              case 14:
                goto label_15;
              case 15:
                goto label_16;
              case 16:
                goto label_17;
              case 17:
                goto label_18;
              case 18:
                goto label_19;
              case 19:
                goto label_20;
              case 20:
                goto label_21;
              case 21:
              case 44:
              case 61:
              case 70:
                goto label_68;
              case 22:
                goto label_22;
              case 23:
                goto label_23;
              case 24:
                goto label_24;
              case 25:
                goto label_25;
              case 26:
                goto label_27;
              case 27:
                goto label_28;
              case 28:
              case 29:
                goto label_31;
              case 30:
                goto label_29;
              case 31:
                goto label_30;
              case 32:
                goto label_32;
              case 33:
                goto label_33;
              case 34:
                goto label_34;
              case 35:
                goto label_35;
              case 36:
                goto label_36;
              case 37:
                goto label_37;
              case 38:
                goto label_38;
              case 39:
                goto label_39;
              case 40:
                goto label_40;
              case 41:
                goto label_41;
              case 42:
                goto label_42;
              case 43:
                goto label_43;
              case 45:
                goto label_44;
              case 46:
                goto label_45;
              case 47:
                goto label_46;
              case 48:
                goto label_47;
              case 49:
                goto label_48;
              case 50:
                goto label_49;
              case 51:
                goto label_50;
              case 52:
                goto label_51;
              case 53:
                goto label_52;
              case 54:
                goto label_53;
              case 55:
                goto label_55;
              case 56:
                goto label_56;
              case 57:
                goto label_57;
              case 58:
                goto label_58;
              case 59:
                goto label_59;
              case 60:
                goto label_60;
              case 62:
                goto label_61;
              case 63:
                goto label_62;
              case 64:
                goto label_63;
              case 65:
                goto label_64;
              case 66:
              case 69:
                goto label_67;
              case 67:
                goto label_65;
              case 68:
                goto label_66;
              case 71:
                goto label_70;
              case 72:
                goto label_72;
              case 73:
                goto label_74;
              case 74:
                goto label_76;
              case 75:
                goto label_77;
              case 76:
                goto label_83;
            }
            break;
        }
      }
      catch (Exception ex) when (ex is Exception & (uint) num1 > 0U & num2 == 0)
      {
        ProjectData.SetProjectError(ex);
        goto label_79;
      }
      throw ProjectData.CreateProjectError(-2146828237);
label_83:
      if (num2 != 0)
        ProjectData.ClearProjectError();
      return str;
    }

    private string FileCheck(string filePath)
    {
      try
      {
        if (File.Exists(filePath))
          File.Delete(filePath);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        string extension = Path.GetExtension(filePath);
        filePath = filePath.Replace(extension, "_New" + extension);
        ProjectData.ClearProjectError();
      }
      return filePath;
    }

    public void DestroyWord(bool withKill)
    {
      int num1;
      int num2;
      try
      {
        if (this.WordDoc != null)
        {
          Marshal.ReleaseComObject((object) this.WordDoc.Content);
          // ISSUE: variable of a compiler-generated type
          Microsoft.Office.Interop.Word.Document wordDoc = this.WordDoc;
          object obj = (object) false;
          ref object local1 = ref obj;
          object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local2 = ref objectValue1;
          object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
          ref object local3 = ref objectValue2;
          // ISSUE: reference to a compiler-generated method
          wordDoc.Close(ref local1, ref local2, ref local3);
          Marshal.ReleaseComObject((object) this.WordDoc);
          this.WordDoc = (Microsoft.Office.Interop.Word.Document) null;
        }
        if (withKill)
        {
          if (this.MsWordApp != null)
          {
            object obj1;
            foreach (Microsoft.Office.Interop.Word.Document document1 in this._wordApp.Documents)
            {
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Word.Document document2 = document1;
              obj1 = (object) false;
              ref object local1 = ref obj1;
              object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local2 = ref objectValue1;
              object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
              ref object local3 = ref objectValue2;
              // ISSUE: reference to a compiler-generated method
              document2.Close(ref local1, ref local2, ref local3);
              Marshal.ReleaseComObject((object) document1);
            }
            IEnumerator enumerator;
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
            // ISSUE: variable of a compiler-generated type
            Microsoft.Office.Interop.Word.Application msWordApp = this.MsWordApp;
            object obj2 = (object) false;
            ref object local4 = ref obj2;
            object objectValue = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local5 = ref objectValue;
            obj1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
            ref object local6 = ref obj1;
            // ISSUE: reference to a compiler-generated method
            msWordApp.Quit(ref local4, ref local5, ref local6);
            Marshal.ReleaseComObject((object) this.MsWordApp);
            this.MsWordApp = (Microsoft.Office.Interop.Word.Application) null;
          }
          Process[] processesByName = Process.GetProcessesByName("WINWORD");
          int index = 0;
          while (index < processesByName.Length)
          {
            Process process = processesByName[index];
            if (process.Responding)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(process.MainWindowTitle, "", false) == 0)
                process.Kill();
            }
            else
              process.Kill();
            checked { ++index; }
          }
          ProjectData.ClearProjectError();
          num1 = 0;
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        goto label_25;
label_20:
        switch (num2)
        {
        }
      }
      catch (Exception ex) when (ex is Exception & (uint) num2 > 0U & num1 == 0)
      {
        ProjectData.SetProjectError(ex);
        goto label_20;
      }
      throw ProjectData.CreateProjectError(-2146828237);
label_25:
      if (num1 == 0)
        return;
      ProjectData.ClearProjectError();
    }

    public static MatchCollection GetTemplateFields(string documentText)
    {
      return new Regex("\\[[A-z|0-9]*\\]").Matches(documentText);
    }

    public static void ReplaceText(ref Microsoft.Office.Interop.Word.Document msWordDoc, string OldText, string NewText)
    {
      // ISSUE: variable of a compiler-generated type
      Find find1 = msWordDoc.Content.Find;
      find1.Text = OldText;
      find1.Replacement.Text = NewText.Length <= (int) byte.MaxValue ? NewText : NewText.Substring(0, (int) byte.MaxValue);
      // ISSUE: variable of a compiler-generated type
      Find find2 = find1;
      object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local1 = ref objectValue1;
      object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local2 = ref objectValue2;
      object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local3 = ref objectValue3;
      object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local4 = ref objectValue4;
      object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local5 = ref objectValue5;
      object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local6 = ref objectValue6;
      object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local7 = ref objectValue7;
      object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local8 = ref objectValue8;
      object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local9 = ref objectValue9;
      object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local10 = ref objectValue10;
      object obj = (object) WdReplace.wdReplaceAll;
      ref object local11 = ref obj;
      object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local12 = ref objectValue11;
      object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local13 = ref objectValue12;
      object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local14 = ref objectValue13;
      object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
      ref object local15 = ref objectValue14;
      // ISSUE: reference to a compiler-generated method
      find2.Execute(ref local1, ref local2, ref local3, ref local4, ref local5, ref local6, ref local7, ref local8, ref local9, ref local10, ref local11, ref local12, ref local13, ref local14, ref local15);
    }

    public bool GSRSave(
      string filepath,
      EngineerVisit oEngineerVisit,
      Site oSite,
      string fileName)
    {
      bool flag;
      try
      {
        if (App.DB.Customer.Customer_Get_Light(oSite.CustomerID) == null)
        {
          flag = false;
        }
        else
        {
          FSM.Entity.Documentss.Documents byFilePath = App.DB.Documents.Documents_Get_ByFilePath(filepath);
          if (byFilePath == null)
          {
            FSM.Entity.Documentss.Documents oDocuments = new FSM.Entity.Documentss.Documents();
            oDocuments.SetTableEnumID = (object) 50;
            oDocuments.SetRecordID = (object) oEngineerVisit.EngineerVisitID;
            oDocuments.SetDocumentTypeID = (object) 66994;
            oDocuments.SetName = (object) fileName;
            FSM.Entity.Documentss.Documents documents = oDocuments;
            string[] strArray = new string[6];
            strArray[0] = "Printed on ";
            DateTime now = DateAndTime.Now;
            strArray[1] = now.ToShortDateString();
            strArray[2] = " at ";
            now = DateAndTime.Now;
            strArray[3] = now.ToString("HH:mm");
            strArray[4] = " by ";
            strArray[5] = App.loggedInUser.Fullname;
            string str = string.Concat(strArray);
            documents.SetNotes = (object) str;
            oDocuments.SetLocation = (object) filepath;
            App.DB.Documents.Insert(oDocuments, false);
          }
          else
          {
            byFilePath.SetNotes = (object) ("Last printed on " + DateAndTime.Now.ToShortDateString() + " at " + DateAndTime.Now.ToString("HH:mm") + " by " + App.loggedInUser.Fullname);
            App.DB.Documents.Update(byFilePath);
          }
          flag = true;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    private void ElecCertPDF(
      EngineerVisit oEngineerVisit,
      EngineerVisitAdditional ElectricalResuts,
      string filename)
    {
      string path1 = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(50);
      if (!Directory.Exists(path1))
        Directory.CreateDirectory(path1);
      string path2 = path1 + "\\" + Conversions.ToString(oEngineerVisit.EngineerVisitID);
      if (!Directory.Exists(path2))
        Directory.CreateDirectory(path2);
      string fileName = path2 + "\\" + filename + DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";
      string filename1 = System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\" + filename + ".pdf";
      string path3 = fileName;
      PdfReader reader = new PdfReader(filename1);
      MemoryStream memoryStream = new MemoryStream();
      PdfStamper pdfStamper = new PdfStamper(reader, (Stream) new FileStream(path3, FileMode.Create), '4');
      pdfStamper.FormFlattening = !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.PDFEditor);
      AcroFields acroFields = pdfStamper.AcroFields;
      Site site1 = App.DB.Sites.Get((object) ElectricalResuts.EngineerVisitID, SiteSQL.GetBy.EngineerVisitId, (object) null);
      Site site2 = new Site();
      if (site1.CustomerID != 787)
        site2 = App.DB.Sites.Get((object) site1.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
      this.PdfSetFormFieldText(ref acroFields, "Client", site2.Name, 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "ClientAddress", site2.Address1 + "\n" + site2.Address2 + "\n" + site2.Address3, 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "ClientPostcode", Helper.FormatPostcode((object) site2.Postcode), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Installer", site1.Name, 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "InstallerAddress", site1.Address1 + "\n" + site1.Address2 + "\n" + site1.Address3, 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "InstallerPostcode", Helper.FormatPostcode((object) site1.Postcode), 7.7f);
      string replacementText1 = "20656" + Conversions.ToString(oEngineerVisit.EngineerVisitID);
      int length = replacementText1.Length;
      while (length >= 0)
      {
        replacementText1 = replacementText1.Insert(length, "  ");
        checked { length += -1; }
      }
      this.PdfSetFormFieldText(ref acroFields, "CertNo", replacementText1, 14.25f);
      this.PdfSetFormFieldText(ref acroFields, "Description1", ElectricalResuts.Test11, 8f);
      switch (ElectricalResuts.Test1)
      {
        case 69996:
          this.PDFSetTick(ref acroFields, "New", replacementText1, 12f);
          break;
        case 69997:
          this.PDFSetTick(ref acroFields, "Addition", replacementText1, 12f);
          break;
        case 69998:
          this.PDFSetTick(ref acroFields, "Alteration", replacementText1, 12f);
          break;
      }
      switch (ElectricalResuts.Test2)
      {
        case 386:
          this.PDFSetTick(ref acroFields, "RecordsYes", replacementText1, 12f);
          break;
        case 387:
          this.PDFSetTick(ref acroFields, "RecordsNo", replacementText1, 12f);
          break;
      }
      this.PdfSetFormFieldText(ref acroFields, "BS7671", "2008", 8f);
      this.PdfSetFormFieldText(ref acroFields, "Date1", "2015", 8f);
      switch (ElectricalResuts.Test3)
      {
        case 69999:
          this.PDFSetTick(ref acroFields, "TNS", replacementText1, 8f);
          break;
        case 70000:
          this.PDFSetTick(ref acroFields, "TT", replacementText1, 12f);
          break;
        case 70001:
          this.PDFSetTick(ref acroFields, "TNCS", replacementText1, 12f);
          break;
        case 70002:
          this.PDFSetTick(ref acroFields, "Other1", replacementText1, 12f);
          break;
      }
      this.PdfSetFormFieldText(ref acroFields, "Specify1", ElectricalResuts.Test12, 12f);
      this.PDFSetTick(ref acroFields, "Ac", replacementText1, 12f);
      this.PdfSetFormFieldText(ref acroFields, "Phases", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test4).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Wires", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test5).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Voltage1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test6).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Frequency", "50", 8f);
      if (ElectricalResuts.Test7 == 421)
        this.PDFSetTick(ref acroFields, "Polarity1", replacementText1, 8f);
      this.PdfSetFormFieldText(ref acroFields, "FaultCurrent", ElectricalResuts.Test13, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Device", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test8).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Type1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test9).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Impedance", ElectricalResuts.Test14, 8f);
      this.PdfSetFormFieldText(ref acroFields, "RatedCurrent", ElectricalResuts.Test15, 8f);
      this.PdfSetFormFieldText(ref acroFields, "SupplySource", ElectricalResuts.Test216, 8f);
      if (ElectricalResuts.Test10 == 70017)
        this.PDFSetTick(ref acroFields, "Facility", replacementText1, 12f);
      else
        this.PDFSetTick(ref acroFields, "EarthElectrode", replacementText1, 12f);
      this.PdfSetFormFieldText(ref acroFields, "Location1", ElectricalResuts.Test217, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Type2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test111).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Ma", ElectricalResuts.Test223, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Resistance", ElectricalResuts.Test218, 8f);
      this.PdfSetFormFieldText(ref acroFields, "EarthConductor1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test112).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "EarthConductor2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test113).Name, 8f);
      this.PDFSetTick(ref acroFields, "EarthingConductor3", replacementText1, 8f);
      this.PdfSetFormFieldText(ref acroFields, "BondingConductor1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test114).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "BondingConductor2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test115).Name, 8f);
      this.PDFSetTick(ref acroFields, "BondingConductor3", replacementText1, 8f);
      this.PdfSetFormFieldText(ref acroFields, "SupplyConductor1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test116).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "SupplyConductor2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test117).Name, 8f);
      this.PDFSetTick(ref acroFields, "SupplyConductor3", replacementText1, 8f);
      if (ElectricalResuts.Test118 == 66597)
        this.PDFSetTick(ref acroFields, "WaterPipe", replacementText1, 8f);
      if (ElectricalResuts.Test119 == 66597)
        this.PDFSetTick(ref acroFields, "GasPipe", replacementText1, 8f);
      if (ElectricalResuts.Test120 == 66597)
        this.PDFSetTick(ref acroFields, "OilPipe", replacementText1, 8f);
      if (ElectricalResuts.Test122 == 66597)
        this.PDFSetTick(ref acroFields, "Lighting", replacementText1, 8f);
      if (ElectricalResuts.Test121 == 66597)
        this.PDFSetTick(ref acroFields, "Steel", replacementText1, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Delay", ElectricalResuts.Test224, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Time", ElectricalResuts.Test225, 8f);
      DataTable table = App.DB.Engineer.Equipment_GetForEngineer(oEngineerVisit.EngineerID).Table;
      string replacementText2 = "";
      DataRow[] dataRowArray = table.Select("EquipmentTypeID = 70962");
      int index = 0;
      while (index < dataRowArray.Length)
      {
        DataRow dataRow = dataRowArray[index];
        replacementText2 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) replacementText2, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataRow["SerialNumber"], (object) '\n')));
        checked { ++index; }
      }
      this.PdfSetFormFieldText(ref acroFields, "SerialNumber", replacementText2, 8f);
      this.PdfSetFormFieldText(ref acroFields, "FuseDevice", ElectricalResuts.Test220, 8f);
      this.PdfSetFormFieldText(ref acroFields, "BSEN", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test123).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Voltage2", ElectricalResuts.Test221, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Poles", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test124).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Location2", ElectricalResuts.Test222, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Rating1", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test125).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "CircuitNo", ElectricalResuts.Test226, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Designation", ElectricalResuts.Test227, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Wiring", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test126).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Method", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test127).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "PointsServed", ElectricalResuts.Test228, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Live", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test128).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "CPC", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test129).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Disconnection", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "BSENNo", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test131).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "TypeNo", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test132).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Rating2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test133).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Capacity", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test134).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "RCD", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test135).Name, 8f);
      DataTable dataTable = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_ElectricalZsMatrix_Get();
      string Left1 = App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test131).Name;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "1362", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "60898", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "61008", false) == 0)
          Left1 = "3871";
      }
      else
        Left1 = "1361";
      string Left2 = App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test132).Name;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "B", false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "3", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "C", false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "D", false) == 0)
            Left2 = "5";
        }
        else
          Left2 = "4";
      }
      else
        Left2 = "3";
      string Left3 = App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test133).Name;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, "2", false) == 0)
        Left3 = "3";
      DataRow dataRow1;
      try
      {
        dataRow1 = dataTable.Select("Rated = " + Left3)[0];
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        dataRow1 = dataTable.Select("Rated = 3")[0];
        ProjectData.ClearProjectError();
      }
      string replacementText3 = "N/A";
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name, "0.4", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name, "5", false) == 0)
        replacementText3 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "3871", false) != 0 ? Conversions.ToString(dataRow1["BS" + Left1 + "_" + App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test130).Name.ToString().Replace(".", "")]) : Conversions.ToString(dataRow1["BS" + Left1 + "_" + Left2]);
      this.PdfSetFormFieldText(ref acroFields, "BS7671Value", replacementText3, 8f);
      this.PdfSetFormFieldText(ref acroFields, "R1", ElectricalResuts.Test229, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Rn", ElectricalResuts.Test230, 8f);
      this.PdfSetFormFieldText(ref acroFields, "R2", ElectricalResuts.Test231, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Figure8", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test136).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "R1R2", ElectricalResuts.Test232, 8f);
      this.PdfSetFormFieldText(ref acroFields, "R22", "N/A", 8f);
      this.PdfSetFormFieldText(ref acroFields, "LiveLive", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test137).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "LiveEarth", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test138).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Polarity2", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test139).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "Zs", ElectricalResuts.Test233, 8f);
      this.PdfSetFormFieldText(ref acroFields, "RCDTest1", ElectricalResuts.Test234, 8f);
      this.PdfSetFormFieldText(ref acroFields, "RCDTest2", ElectricalResuts.Test235, 8f);
      this.PdfSetFormFieldText(ref acroFields, "TestButtonOp", App.DB.Picklists.Get_One_As_Object(ElectricalResuts.Test140).Name, 8f);
      this.PdfSetFormFieldText(ref acroFields, "CircuitDetails", "Electronic Equipment or Accessories", 8f);
      this.PdfSetFormFieldText(ref acroFields, "RiskAssessment", "N/A", 5f);
      this.PdfSetFormFieldText(ref acroFields, "JobTitle", "Electrician", 8f);
      Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
      this.PdfSetFormFieldText(ref acroFields, "Engineer", engineer.Name, 8f);
      DateTime t1 = oEngineerVisit.StartDateTime;
      if (DateTime.Compare(t1, DateTime.MinValue) == 0)
        t1 = oEngineerVisit.ManualEntryOn;
      this.PdfSetFormFieldText(ref acroFields, "Date2", t1.ToShortDateString(), 8f);
      AcroFields.FieldPosition fieldPosition = acroFields.GetFieldPositions("Signature")[0];
      int page = fieldPosition.page;
      iTextSharp.text.Rectangle position = fieldPosition.position;
      new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature)).Save(System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.bmp");
      iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.bmp");
      instance.ScaleToFit(position.Width, position.Height);
      instance.SetAbsolutePosition(position.Left, position.Bottom);
      pdfStamper.GetOverContent(page).AddImage(instance);
      pdfStamper.Close();
      pdfStamper.Close();
      reader.Close();
      Cursor.Current = Cursors.WaitCursor;
      Process.Start(fileName);
      Cursor.Current = Cursors.Default;
    }

    private void PDFSetTick(
      ref AcroFields acroFields,
      string fieldName,
      string replacementText,
      float textSize)
    {
      AcroFields acroFields1 = acroFields;
      BaseFont baseFont = FontFactory.GetFont(System.Windows.Forms.Application.StartupPath + "/fonts/zapfdingbats.ttf", "Identity-H", true, 0.5f, 0, BaseColor.BLACK).BaseFont;
      acroFields1.SetFieldProperty(fieldName, "textfont", (object) baseFont, (int[]) null);
      acroFields1.SetField(fieldName, "4");
      acroFields1.SetFieldProperty(fieldName, "textsize", (object) 5f, (int[]) null);
    }

    private void PdfSetFormFieldText(
      ref AcroFields acroFields,
      string fieldName,
      string replacementText,
      float textSize)
    {
      AcroFields acroFields1 = acroFields;
      acroFields1.SetFieldProperty(fieldName, "bgcolor", (object) BaseColor.WHITE, (int[]) null);
      acroFields1.SetFieldProperty(fieldName, "textsize", (object) textSize, (int[]) null);
      acroFields1.SetField(fieldName, replacementText);
    }

    private void WarningNoticePDF(
      EngineerVisit oEngineerVisit,
      DataRow WarningNotice,
      string filename)
    {
      string path1 = App.TheSystem.Configuration.DocumentsLocation + Conversions.ToString(50);
      if (!Directory.Exists(path1))
        Directory.CreateDirectory(path1);
      string path2 = path1 + "\\" + Conversions.ToString(oEngineerVisit.EngineerVisitID);
      if (!Directory.Exists(path2))
        Directory.CreateDirectory(path2);
      string fileName = path2 + "\\" + filename + DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";
      string filename1 = System.Windows.Forms.Application.StartupPath + App.TheSystem.Configuration.TemplateLocation + "\\" + filename + ".pdf";
      string path3 = fileName;
      PdfReader reader = new PdfReader(filename1);
      MemoryStream memoryStream = new MemoryStream();
      PdfStamper pdfStamper = new PdfStamper(reader, (Stream) new FileStream(path3, FileMode.Create), '4');
      pdfStamper.FormFlattening = true;
      AcroFields acroFields = pdfStamper.AcroFields;
      Site site1 = App.DB.Sites.Get((object) oEngineerVisit.EngineerVisitID, SiteSQL.GetBy.EngineerVisitId, (object) null);
      Site site2 = App.DB.Sites.Get((object) site1.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
      if (site1.CustomerID == 787)
        site2 = new Site();
      DataTable table = App.DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(oEngineerVisit.EngineerVisitID).Table;
      Engineer engineer = App.DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID);
      DateTime dateTime = DateTime.MinValue;
      IEnumerator enumerator;
      try
      {
        enumerator = table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (DateTime.Compare(Conversions.ToDate(current["EnddateTime"]), dateTime) > 0 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["TimesheetTypeID"], (object) "211", false))
            dateTime = Conversions.ToDate(current["Enddatetime"]);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
        dateTime = oEngineerVisit.EndDateTime;
      this.PdfSetFormFieldText(ref acroFields, "ClientName", site2.Name, 6f);
      this.PdfSetFormFieldText(ref acroFields, "ClientAddress", site2.Address1 + ", ", 6f);
      this.PdfSetFormFieldText(ref acroFields, "ClientPostcode", site2.Address2 + ", " + site2.Address3 + ", " + site2.Postcode, 6f);
      this.PdfSetFormFieldText(ref acroFields, "TenantName", site1.Name, 6f);
      this.PdfSetFormFieldText(ref acroFields, "TenantAddress", site1.Address1 + ", ", 6f);
      this.PdfSetFormFieldText(ref acroFields, "TenantPostcode", site1.Address2 + ", " + site1.Address3 + ", " + site1.Postcode, 6f);
      this.PdfSetFormFieldText(ref acroFields, "IssueDate", dateTime.ToString("dd/MM/yyyy"), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "IssueTime", dateTime.ToString("HH:mm"), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "EngName", engineer.Name, 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Make", Conversions.ToString(WarningNotice["Make"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Model", Conversions.ToString(WarningNotice["Model"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Type", Conversions.ToString(WarningNotice["Model"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Location", Conversions.ToString(WarningNotice["Location"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Reason", Conversions.ToString(WarningNotice["Reason"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Action", Conversions.ToString(WarningNotice["ActionTaken"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Present", Conversions.ToString(WarningNotice["NoticeLeft"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Refused", Conversions.ToString(WarningNotice["NoSign"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "NG1", Conversions.ToString(WarningNotice["SupplierInformed"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "NG2", Conversions.ToString(WarningNotice["SupplierInformed"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "TenName", oEngineerVisit.CustomerName, 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "TenDate", dateTime.ToString("dd/MM/yyyy"), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "GasEscape", Conversions.ToString(WarningNotice["GasEscape"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Reason2", Conversions.ToString(WarningNotice["SupplierInformedReason"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Reference", Conversions.ToString(WarningNotice["SupplierInformedRef"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Riddor", Conversions.ToString(WarningNotice["RiddorReported"]), 7.7f);
      this.PdfSetFormFieldText(ref acroFields, "Reason3", Conversions.ToString(WarningNotice["RiddorReportedDetails"]), 7.7f);
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(WarningNotice["CategoryID"], (object) 405, false))
        this.PDFSetTick(ref acroFields, "ID", "", 8f);
      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(WarningNotice["CategoryID"], (object) 404, false))
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(WarningNotice["TurnedOff"], (object) "1", false))
          this.PDFSetTick(ref acroFields, "AR1", "", 8f);
        else
          this.PDFSetTick(ref acroFields, "AR2", "", 8f);
      }
      new Bitmap((Stream) new MemoryStream(oEngineerVisit.EngineerSignature)).Save(System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.bmp");
      PushbuttonField pushbuttonFromField1 = acroFields.GetNewPushbuttonFromField("EngSig");
      pushbuttonFromField1.Image = iTextSharp.text.Image.GetInstance(System.Windows.Forms.Application.StartupPath + "\\TEMP\\EngSig.bmp");
      acroFields.ReplacePushbuttonField("EngSig", pushbuttonFromField1.Field);
      new Bitmap((Stream) new MemoryStream(oEngineerVisit.CustomerSignature)).Save(System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.bmp");
      PushbuttonField pushbuttonFromField2 = acroFields.GetNewPushbuttonFromField("Signature");
      pushbuttonFromField2.Image = iTextSharp.text.Image.GetInstance(System.Windows.Forms.Application.StartupPath + "\\TEMP\\CustSig.bmp");
      acroFields.ReplacePushbuttonField("Signature", pushbuttonFromField2.Field);
      pdfStamper.Close();
      pdfStamper.Close();
      reader.Close();
      Cursor.Current = Cursors.WaitCursor;
      Process.Start(fileName);
      Cursor.Current = Cursors.Default;
    }
  }
}
