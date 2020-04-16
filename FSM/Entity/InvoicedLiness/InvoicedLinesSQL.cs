// Decompiled with JetBrains decompiler
// Type: FSM.Entity.InvoicedLiness.InvoicedLinesSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.InvoicedLiness
{
  public class InvoicedLinesSQL
  {
    private Database _database;

    public InvoicedLinesSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int InvoicedLineID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedLineID", (object) InvoicedLineID, true);
      this._database.ExecuteSP_NO_Return("InvoicedLines_Delete", true);
    }

    public InvoicedLines InvoicedLines_Get(int InvoicedLineID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedLineID", (object) InvoicedLineID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (InvoicedLines_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (InvoicedLines) null;
      InvoicedLines invoicedLines1 = new InvoicedLines();
      InvoicedLines invoicedLines2 = invoicedLines1;
      invoicedLines2.IgnoreExceptionsOnSetMethods = true;
      invoicedLines2.SetInvoicedLineID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (InvoicedLineID)]);
      invoicedLines2.SetInvoicedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoicedID"]);
      invoicedLines2.SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceToBeRaisedID"]);
      invoicedLines2.SetAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]);
      invoicedLines1.Exists = true;
      return invoicedLines1;
    }

    public DataView InvoicedLines_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (InvoicedLines_GetAll), true);
      table.TableName = Enums.TableNames.tblInvoicedLines.ToString();
      return new DataView(table);
    }

    public DataView InvoicedLines_GetAll_ByInvoiceToBeRaisedID(int InvoiceToBeRaisedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceToBeRaisedID", (object) InvoiceToBeRaisedID, true);
      this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
      this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (InvoicedLines_GetAll_ByInvoiceToBeRaisedID), true);
      table.TableName = Enums.TableNames.tblInvoicedLines.ToString();
      return new DataView(table);
    }

    public DataView InvoicedLines_GetAll_ByInvoicedID(int InvoicedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, true);
      this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
      this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
      this._database.AddParameter("@Contract_Option1Enum", (object) 327, true);
      this._database.AddParameter("@Contract_Option2Enum", (object) 329, true);
      this._database.AddParameter("@Contract_Option3Enum", (object) 330, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (InvoicedLines_GetAll_ByInvoicedID), true);
      table.TableName = Enums.TableNames.tblInvoicedLines.ToString();
      return new DataView(table);
    }

    public InvoicedLines Insert(InvoicedLines oInvoicedLines)
    {
      this._database.ClearParameter();
      this.AddInvoicedLinesParametersToCommand(ref oInvoicedLines);
      oInvoicedLines.SetInvoicedLineID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("InvoicedLines_Insert", true)));
      oInvoicedLines.Exists = true;
      return oInvoicedLines;
    }

    public void Update(InvoicedLines oInvoicedLines)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedLineID", (object) oInvoicedLines.InvoicedLineID, true);
      this.AddInvoicedLinesParametersToCommand(ref oInvoicedLines);
      this._database.ExecuteSP_NO_Return("InvoicedLines_Update", true);
    }

    private void AddInvoicedLinesParametersToCommand(ref InvoicedLines oInvoicedLines)
    {
      Database database = this._database;
      database.AddParameter("@InvoicedID", (object) oInvoicedLines.InvoicedID, true);
      database.AddParameter("@InvoiceToBeRaisedID", (object) oInvoicedLines.InvoiceToBeRaisedID, true);
      database.AddParameter("@Amount", (object) oInvoicedLines.Amount, true);
    }

    public void InvoicedLinesTotal_Change(int InvoicedLineID, double Amount)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedLineID", (object) InvoicedLineID, true);
      this._database.AddParameter("@Amount", (object) Amount, true);
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return(nameof (InvoicedLinesTotal_Change), true);
    }

    public void InvoicedLinesTotal_ChangeInvoiceDetails(
      int InvoicedLineID,
      string AccountCode,
      string Department,
      string NominalCode,
      DateTime TaxDate,
      int InvoiceTypeID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedLineID", (object) InvoicedLineID, true);
      this._database.AddParameter("@AccountCode", (object) AccountCode, true);
      this._database.AddParameter("@Department", (object) Department, true);
      this._database.AddParameter("@NominalCode", (object) NominalCode, true);
      this._database.AddParameter("@TaxDate", (object) TaxDate, true);
      this._database.AddParameter("@InvoiceTypeID", (object) InvoiceTypeID, true);
      this._database.ExecuteSP_NO_Return("InvoicedLinesTotal_ChangeDetails", true);
    }

    public void Invoiced_ChangeTerm(int InvoicedID, int Term, int PaidBy)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, true);
      this._database.AddParameter("@TermID", (object) Term, true);
      if (PaidBy > 0)
        this._database.AddParameter("@PaidByID", (object) PaidBy, true);
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return(nameof (Invoiced_ChangeTerm), true);
    }
  }
}
