// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractsAlternative.ContractAlternativeSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractsAlternative
{
  public class ContractAlternativeSQL
  {
    private Database _database;

    public ContractAlternativeSQL(Database database)
    {
      this._database = database;
    }

    public ContractAlternative Get(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractAlternative_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractAlternative) null;
      ContractAlternative contractAlternative1 = new ContractAlternative();
      ContractAlternative contractAlternative2 = contractAlternative1;
      contractAlternative2.IgnoreExceptionsOnSetMethods = true;
      contractAlternative2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ContractID)]);
      contractAlternative2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      contractAlternative2.SetContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractReference"]);
      contractAlternative2.ContractStartDate = Conversions.ToDate(dataTable.Rows[0]["ContractStartDate"]);
      contractAlternative2.ContractEndDate = Conversions.ToDate(dataTable.Rows[0]["ContractEndDate"]);
      contractAlternative2.SetContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractStatusID"]);
      contractAlternative2.SetContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractPrice"]);
      contractAlternative2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractID"]);
      contractAlternative2.SetInvoiceFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceFrequencyID"]);
      contractAlternative2.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressID"]);
      contractAlternative2.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressTypeID"]);
      contractAlternative2.FirstInvoiceDate = Conversions.ToDate(dataTable.Rows[0]["FirstInvoiceDate"]);
      contractAlternative2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      contractAlternative1.Exists = true;
      return contractAlternative1;
    }

    public DataView GetAll_For_Customer_ID(int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternative_GetAll_For_Customer_ID", true);
      table.TableName = Enums.TableNames.tblDocuments.ToString();
      return new DataView(table);
    }

    public double ContractAlternativeCalculatedTotal(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof (ContractAlternativeCalculatedTotal), true)));
    }

    public ContractAlternative Get_For_Quote_ID(int QuoteContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractAlternative_Get_For_Quote_ID", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractAlternative) null;
      ContractAlternative contractAlternative1 = new ContractAlternative();
      ContractAlternative contractAlternative2 = contractAlternative1;
      contractAlternative2.IgnoreExceptionsOnSetMethods = true;
      contractAlternative2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]);
      contractAlternative2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      contractAlternative2.SetContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractReference"]);
      contractAlternative2.ContractStartDate = Conversions.ToDate(dataTable.Rows[0]["ContractStartDate"]);
      contractAlternative2.ContractEndDate = Conversions.ToDate(dataTable.Rows[0]["ContractEndDate"]);
      contractAlternative2.SetContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractStatusID"]);
      contractAlternative2.SetContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractPrice"]);
      contractAlternative2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (QuoteContractID)]);
      contractAlternative2.SetInvoiceFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceFrequencyID"]);
      contractAlternative2.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressID"]);
      contractAlternative2.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressTypeID"]);
      contractAlternative2.FirstInvoiceDate = Conversions.ToDate(dataTable.Rows[0]["FirstInvoiceDate"]);
      contractAlternative2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      contractAlternative1.Exists = true;
      return contractAlternative1;
    }

    public ContractAlternative Insert(ContractAlternative oContract)
    {
      this._database.ClearParameter();
      this.AddContractParametersToCommand(ref oContract);
      oContract.SetContractID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractAlternative_Insert", true)));
      oContract.Exists = true;
      return oContract;
    }

    public void Update(ContractAlternative oContract)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) oContract.ContractID, true);
      this.AddContractParametersToCommand(ref oContract);
      this._database.ExecuteSP_NO_Return("ContractAlternative_Update", true);
    }

    public void Delete(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      this._database.AddParameter("@ContractOpt2Enum", (object) 329, true);
      this._database.ExecuteSP_NO_Return("ContractAlternative_Delete", true);
    }

    private void AddContractParametersToCommand(ref ContractAlternative oContract)
    {
      Database database = this._database;
      database.AddParameter("@CustomerID", (object) oContract.CustomerID, true);
      database.AddParameter("@ContractReference", (object) oContract.ContractReference, true);
      database.AddParameter("@ContractStartDate", (object) oContract.ContractStartDate, true);
      database.AddParameter("@ContractEndDate", (object) oContract.ContractEndDate, true);
      database.AddParameter("@ContractStatusID", (object) oContract.ContractStatusID, true);
      database.AddParameter("@ContractPrice", (object) oContract.ContractPrice, true);
      database.AddParameter("@QuoteContractID", (object) oContract.QuoteContractID, true);
      database.AddParameter("@InvoiceFrequencyID", (object) oContract.InvoiceFrequencyID, true);
      database.AddParameter("@InvoiceAddressID", (object) oContract.InvoiceAddressID, true);
      database.AddParameter("@InvoiceAddressTypeID", (object) oContract.InvoiceAddressTypeID, true);
      database.AddParameter("@FirstInvoiceDate", (object) oContract.FirstInvoiceDate, true);
    }
  }
}
