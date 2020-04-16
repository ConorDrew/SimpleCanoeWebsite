// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Invoiceds.InvoicedSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FSM.Entity.Invoiceds
{
  public class InvoicedSQL
  {
    private Database _database;

    public InvoicedSQL(Database database)
    {
      this._database = database;
    }

    public Invoiced Invoiced_Get(int InvoicedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Invoiced_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Invoiced) null;
      Invoiced invoiced1 = new Invoiced();
      Invoiced invoiced2 = invoiced1;
      invoiced2.IgnoreExceptionsOnSetMethods = true;
      invoiced2.SetInvoicedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (InvoicedID)]);
      invoiced2.RaisedDate = Conversions.ToDate(dataTable.Rows[0]["RaisedDate"]);
      invoiced2.SetInvoiceNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceNumber"]);
      invoiced2.SetRaisedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RaisedByUserID"]);
      invoiced2.SetVATRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VATRateID"]);
      invoiced2.SetPaidByID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PaidByID"]);
      invoiced2.SetAdhocInvoiceType = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AdhocInvoiceType"]);
      invoiced1.Exists = true;
      return invoiced1;
    }

    public Invoiced Invoiced_Get_ByInvoiceNumber(int invoiceNumber)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedNumber", (object) invoiceNumber, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("Invoiced_Get_InvoiceNumber", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Invoiced) null;
      Invoiced invoiced1 = new Invoiced();
      Invoiced invoiced2 = invoiced1;
      invoiced2.IgnoreExceptionsOnSetMethods = true;
      invoiced2.SetInvoicedID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoicedID"]);
      invoiced2.RaisedDate = Conversions.ToDate(dataTable.Rows[0]["RaisedDate"]);
      invoiced2.SetInvoiceNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceNumber"]);
      invoiced2.SetRaisedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RaisedByUserID"]);
      invoiced2.SetVATRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VATRateID"]);
      invoiced2.SetPaidByID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PaidByID"]);
      invoiced2.SetAdhocInvoiceType = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AdhocInvoiceType"]);
      invoiced1.Exists = true;
      return invoiced1;
    }

    public DataView Invoiced_GetAll_Manager(
      DateTime RaisedFrom,
      DateTime RaisedTo,
      int customerId,
      int siteId,
      string postcode,
      int invoiceTypeId,
      string jobNumber,
      string invoiceNumber,
      int userId,
      int regionId,
      string department,
      int exportedToSage)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@RaisedFrom", (object) Conversions.ToDate(Strings.Format((object) RaisedFrom, "dd/MM/yyyy") + " 00:00:00"), true);
      this._database.AddParameter("@RaisedTo", (object) Conversions.ToDate(Strings.Format((object) RaisedTo, "dd/MM/yyyy") + " 23:59:59"), true);
      this._database.AddParameter("@InvoiceEnumVal", (object) 258, true);
      this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
      this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
      this._database.AddParameter("@Contract_Option1Enum", (object) 327, true);
      this._database.AddParameter("@Contract_Option2Enum", (object) 329, true);
      this._database.AddParameter("@Contract_Option3Enum", (object) 330, true);
      this._database.AddParameter("@CustomerId", (object) customerId, true);
      this._database.AddParameter("@SiteId", (object) siteId, true);
      this._database.AddParameter("@Postcode", (object) postcode, true);
      this._database.AddParameter("@InvoiceTypeID", (object) invoiceTypeId, true);
      this._database.AddParameter("@JobNumber", (object) jobNumber, true);
      this._database.AddParameter("@InvoiceNumber", (object) invoiceNumber, true);
      this._database.AddParameter("@UserId", (object) userId, true);
      this._database.AddParameter("@RegionId", (object) regionId, true);
      this._database.AddParameter("@Department", (object) department, true);
      this._database.AddParameter("@ExportedToSage", (object) exportedToSage, true);
      DataTable table = this._database.ExecuteSP_DataTable("Invoiced_GetAll_Manager5", true);
      table.TableName = Enums.TableNames.tblInvoiced.ToString();
      return new DataView(table);
    }

    public Invoiced Insert(Invoiced oInvoiced)
    {
      this._database.ClearParameter();
      this.AddInvoicedParametersToCommand(ref oInvoiced);
      oInvoiced.SetInvoicedID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Invoiced_Insert", true)));
      oInvoiced.Exists = true;
      return oInvoiced;
    }

    public void Update(Invoiced oInvoiced)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedID", (object) oInvoiced.InvoicedID, true);
      this.AddInvoicedParametersToCommand(ref oInvoiced);
      this._database.ExecuteSP_NO_Return("Invoiced_Update", true);
    }

    private void AddInvoicedParametersToCommand(ref Invoiced oInvoiced)
    {
      Database database = this._database;
      database.AddParameter("@InvoiceNumber", (object) oInvoiced.InvoiceNumber, true);
      database.AddParameter("@RaisedDate", (object) oInvoiced.RaisedDate, true);
      database.AddParameter("@RaisedByUserID", (object) oInvoiced.RaisedByUserID, true);
      database.AddParameter("@VATRateID", (object) oInvoiced.VATRateID, true);
      database.AddParameter("@PaymentTermID", (object) oInvoiced.PaymentTermID, true);
      database.AddParameter("@PaidByID", (object) oInvoiced.PaidByID, true);
      database.AddParameter("@AdhocInvoicetype", (object) oInvoiced.AdhocInvoiceType, true);
    }

    public DataView InvoiceDetails_Get_InvoicedID(int InvoicedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceEnumVal", (object) 258, true);
      this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
      this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
      this._database.AddParameter("@Contract_Option1Enum", (object) 327, true);
      this._database.AddParameter("@Contract_Option2Enum", (object) 329, true);
      this._database.AddParameter("@Contract_Option3Enum", (object) 330, true);
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (InvoiceDetails_Get_InvoicedID), true);
      table.TableName = Enums.TableNames.tblInvoiced.ToString();
      return new DataView(table);
    }

    public DataView InvoiceDetails_Get_InvoiceToBeRaisedID(int InvoicedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceToBeRaisedID", (object) InvoicedID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (InvoiceDetails_Get_InvoiceToBeRaisedID), true);
      table.TableName = Enums.TableNames.tblInvoiced.ToString();
      return new DataView(table);
    }

    public DataView InvoiceDetails_Get_InvoicedNumber(int InvoicedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceEnumVal", (object) 258, true);
      this._database.AddParameter("@JobInvTypeEnum", (object) 260, true);
      this._database.AddParameter("@OrderInvTypeEnum", (object) 261, true);
      this._database.AddParameter("@Contract_Option1Enum", (object) 327, true);
      this._database.AddParameter("@Contract_Option2Enum", (object) 329, true);
      this._database.AddParameter("@Contract_Option3Enum", (object) 330, true);
      this._database.AddParameter("@InvoicedNumber", (object) InvoicedID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (InvoiceDetails_Get_InvoicedNumber), true);
      table.TableName = Enums.TableNames.tblInvoiced.ToString();
      return new DataView(table);
    }

    public DataView Invoiced_GetContractOpt3_Jobs(int InvoicedID, int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractOpt3Enum", (object) 330, true);
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, true);
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Invoiced_GetContractOpt3_Jobs), true);
      table.TableName = Enums.TableNames.tblInvoiced.ToString();
      return new DataView(table);
    }

    public string Invoice_GetAdditionalNotes(int InvoicedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, true);
      return Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Invoiced_GetNotes", true)));
    }

    public void Invoice_UpdateAdditionalNotes(int InvoicedID, string Notes)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, true);
      this._database.AddParameter("@Notes", (object) Notes, true);
      this._database.ExecuteSP_NO_Return("Invoiced_UpdateNotes", true);
    }

    public DataView NCCValuation(int InvoicedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoicedID", (object) InvoicedID, true);
      DataTable table = this._database.ExecuteSP_DataTable("InvoicedManager_Get_NccVal", true);
      table.TableName = Enums.TableNames.tblInvoicedPaymentApplications.ToString();
      return new DataView(table);
    }

    public DataTable GetJobNominalCode_ForSupplierInvoice(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      return this._database.ExecuteSP_DataTable("Invoiced_GetJobNominalCode_ForSupplierInvoice", true);
    }

    public async Task MarkInvoiceAsExportedAsync(int invoicedId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@InvoicedID", (object) invoicedId)
      };
      object obj = await this._database.ExecuteAsync("Invoiced_Update_AsExported", sqlParameterArray);
    }

    public async Task MarkConsolidatedOrderAsExportedAsync(int orderConsolidationId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@OrderConsolidationID", (object) orderConsolidationId)
      };
      object obj = await this._database.ExecuteAsync("OrderConsolidation_Update_AsExported", sqlParameterArray);
    }

    public async Task MarkOrderAsExportedAsync(int supplierInvoiceId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@SupplierInvoiceID", (object) supplierInvoiceId)
      };
      object obj = await this._database.ExecuteAsync("OrderSupplierInvoices_Update_AsExported", sqlParameterArray);
    }

    public async Task MarkPartCreditedAsExportedAsync(
      int partCreditsId,
      int partsToBeCreditedId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[2]
      {
        new SqlParameter("@PartsToBeCreditedID", (object) partsToBeCreditedId),
        new SqlParameter("@PartCreditsID", (object) partCreditsId)
      };
      object obj = await this._database.ExecuteAsync("PartCredits_Update_AsExported", sqlParameterArray);
    }

    public async Task MarkSalesCreditAsExportedAsync(int salesCreditId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@SalesCreditID", (object) salesCreditId)
      };
      object obj = await this._database.ExecuteAsync("SalesCredit_Update_AsExported", sqlParameterArray);
    }

    public async Task MarkInvoiceAsNotExportedAsync(int invoicedId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@InvoicedID", (object) invoicedId)
      };
      object obj = await this._database.ExecuteAsync("Invoiced_Update_AsNotExported", sqlParameterArray);
    }

    public async Task MarkOrderAsNotExportedAsync(int supplierInvoiceId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@SupplierInvoiceID", (object) supplierInvoiceId)
      };
      object obj = await this._database.ExecuteAsync("OrderSupplierInvoices_Update_AsNotExported", sqlParameterArray);
    }

    public async Task MarkConsolidatedOrderAsNotExportedAsync(int orderConsolidationId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@OrderConsolidationID", (object) orderConsolidationId)
      };
      object obj = await this._database.ExecuteAsync("OrderConsolidation_Update_AsNotExported", sqlParameterArray);
    }

    public async Task MarkPartCreditedAsNotExportedAsync(
      int partCreditsId,
      int partsToBeCreditedId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[2]
      {
        new SqlParameter("@PartsToBeCreditedID", (object) partsToBeCreditedId),
        new SqlParameter("@PartCreditsID", (object) partCreditsId)
      };
      object obj = await this._database.ExecuteAsync("PartCredits_Update_AsNotExported", sqlParameterArray);
    }

    public async Task MarkSalesCreditAsNotExportedAsync(int salesCreditId)
    {
      SqlParameter[] sqlParameterArray = new SqlParameter[1]
      {
        new SqlParameter("@SalesCreditID", (object) salesCreditId)
      };
      object obj = await this._database.ExecuteAsync("SalesCredit_Update_AsNotExported", sqlParameterArray);
    }
  }
}
