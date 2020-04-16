// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SalesCredits.SalesCreditSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.SalesCredits
{
  public class SalesCreditSQL
  {
    private Database _database;

    public SalesCreditSQL(Database database)
    {
      this._database = database;
    }

    public SalesCredit SalesCredit_Get(int SalesCreditID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SalesCreditID", (object) SalesCreditID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (SalesCredit_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (SalesCredit) null;
      SalesCredit salesCredit1 = new SalesCredit();
      SalesCredit salesCredit2 = salesCredit1;
      salesCredit2.IgnoreExceptionsOnSetMethods = true;
      salesCredit2.SetAmountCredited = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AmountCredited"]);
      salesCredit2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      salesCredit2.SetTaxCodeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TaxCodeID"]));
      salesCredit2.SetNominalCode = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NominalCode"]));
      salesCredit2.SetDepartmentRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DepartmentRef"]);
      salesCredit2.SetExtraRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExtraRef"]);
      salesCredit2.SetReasonForCredit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForCredit"]);
      salesCredit2.SetRequestedBy = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RequestedBy"]));
      salesCredit2.SetInvoicedLineID = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoicedLineID"]));
      salesCredit2.DateCredited = Conversions.ToDate(dataTable.Rows[0]["DateCredited"]);
      salesCredit2.SetCreditReference = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreditReference"]));
      salesCredit1.Exists = true;
      return salesCredit1;
    }

    public SalesCredit SalesCredit_Get_For_InvoicedLine(int SalesCreditID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedLineID", (object) SalesCreditID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (SalesCredit_Get_For_InvoicedLine), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (SalesCredit) null;
      SalesCredit salesCredit1 = new SalesCredit();
      SalesCredit salesCredit2 = salesCredit1;
      salesCredit2.IgnoreExceptionsOnSetMethods = true;
      salesCredit2.SetAmountCredited = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AmountCredited"]);
      salesCredit2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      salesCredit2.SetTaxCodeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TaxCodeID"]));
      salesCredit2.SetNominalCode = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NominalCode"]));
      salesCredit2.SetDepartmentRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DepartmentRef"]);
      salesCredit2.SetExtraRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExtraRef"]);
      salesCredit2.SetReasonForCredit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForCredit"]);
      salesCredit2.SetRequestedBy = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RequestedBy"]));
      salesCredit2.SetInvoicedLineID = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoicedLineID"]));
      salesCredit2.SetCreditReference = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreditReference"]));
      salesCredit2.DateCredited = Conversions.ToDate(dataTable.Rows[0]["DateCredited"]);
      salesCredit2.SetAccountNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccountNumber"]);
      salesCredit1.Exists = true;
      return salesCredit1;
    }

    public DataView PartsToBeCredited_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (PartsToBeCredited_GetAll), true);
      table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
      return new DataView(table);
    }

    public DataView PartsToBeCredited_Get_PartsCreditID(int PartCreditID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartCreditID", (object) PartCreditID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (PartsToBeCredited_Get_PartsCreditID), true);
      table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
      return new DataView(table);
    }

    public DataView PartsToBeCredited_Get_OrderID(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_Order", true);
      table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
      return new DataView(table);
    }

    public DataView PartsToBeCredited_Get_OrderPartID(int OrderPartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderPartID", (object) OrderPartID, true);
      DataTable table = this._database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_OrderPart", true);
      table.TableName = Enums.TableNames.tblPartsToBeCredited.ToString();
      return new DataView(table);
    }

    public SalesCredit Insert(SalesCredit oSalesCredited)
    {
      this._database.ClearParameter();
      this.AddPartsToBeCreditedParametersToCommand(ref oSalesCredited);
      this._database.AddParameter("@DateCredited", (object) oSalesCredited.DateCredited, true);
      oSalesCredited.SetSalesCreditID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("SalesCredit_Insert", true)));
      oSalesCredited.Exists = true;
      return oSalesCredited;
    }

    private void AddPartsToBeCreditedParametersToCommand(ref SalesCredit oPartsToBeCredited)
    {
      Database database = this._database;
      database.AddParameter("@AmountCredited", (object) oPartsToBeCredited.AmountCredited, true);
      database.AddParameter("@Notes", (object) oPartsToBeCredited.Notes, true);
      database.AddParameter("@TaxCodeID", (object) oPartsToBeCredited.TaxCodeID, true);
      database.AddParameter("@NominalCode", (object) oPartsToBeCredited.NominalCode, true);
      database.AddParameter("@DepartmentRef", (object) oPartsToBeCredited.DepartmentRef, true);
      database.AddParameter("@ExtraRef", (object) oPartsToBeCredited.ExtraRef, true);
      database.AddParameter("@Reason", (object) oPartsToBeCredited.ReasonForCredit, true);
      database.AddParameter("@RequestBy", (object) oPartsToBeCredited.RequestedBy, true);
      database.AddParameter("@InvoicedLineID", (object) oPartsToBeCredited.InvoicedLineID, true);
      database.AddParameter("@CreditReference", (object) oPartsToBeCredited.CreditReference, true);
      database.AddParameter("@AddedBy", (object) oPartsToBeCredited.AddedByUser, true);
      database.AddParameter("@AccountNumber", (object) oPartsToBeCredited.AccountNumber, true);
    }

    public DataView InvoicedLines_GetAll_ByInvoicedID(int InvoicedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, true);
      this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
      this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
      this._database.AddParameter("@Contract_Option1Enum", (object) 327, true);
      DataTable table = this._database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoicedID_ForCredits", true);
      table.TableName = Enums.TableNames.tblInvoicedLines.ToString();
      return new DataView(table);
    }

    public DataView InvoicedLines_GetAll_ByInvoicedIDRows(DataRow[] Invoiced)
    {
      DataTable table1 = new DataTable();
      DataRow[] dataRowArray = Invoiced;
      int index = 0;
      while (index < dataRowArray.Length)
      {
        DataRow dataRow = dataRowArray[index];
        this._database.ClearParameter();
        this._database.AddParameter("@InvoicedLineID", RuntimeHelpers.GetObjectValue(dataRow["InvoicedLineID"]), true);
        this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
        this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
        this._database.AddParameter("@Contract_Option1Enum", (object) 327, true);
        DataTable table2 = this._database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoicedLineID_ForCredits", true);
        table2.TableName = Enums.TableNames.tblInvoicedLines.ToString();
        table1.Merge(table2);
        checked { ++index; }
      }
      return new DataView(table1);
    }

    public DataView InvoicedLines_GetAll_ByInvoicedNumber(string InvoicedNumber)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedNumber", (object) InvoicedNumber, true);
      this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
      this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
      this._database.AddParameter("@Contract_Option1Enum", (object) 327, true);
      DataTable table = this._database.ExecuteSP_DataTable("InvoicedLines_GetAll_CreditsByInvoiceNumber", true);
      table.TableName = Enums.TableNames.tblInvoicedLines.ToString();
      return new DataView(table);
    }

    public DataView InvoicedLines_GetAll_ByCreditReference(string creditReference)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CreditReference", (object) creditReference, true);
      this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
      this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
      this._database.AddParameter("@Contract_Option1Enum", (object) 327, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (InvoicedLines_GetAll_ByCreditReference), true);
      table.TableName = Enums.TableNames.tblInvoicedLines.ToString();
      return new DataView(table);
    }
  }
}
