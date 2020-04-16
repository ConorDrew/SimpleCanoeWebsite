// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractsOriginal.ContractOriginalSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.InvoicedLiness;
using FSM.Entity.Invoiceds;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractsOriginal
{
  public class ContractOriginalSQL
  {
    private Database _database;

    public ContractOriginalSQL(Database database)
    {
      this._database = database;
    }

    public ContractOriginal Get(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractOriginal_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractOriginal) null;
      ContractOriginal contractOriginal1 = new ContractOriginal();
      ContractOriginal contractOriginal2 = contractOriginal1;
      contractOriginal2.IgnoreExceptionsOnSetMethods = true;
      contractOriginal2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ContractID)]);
      contractOriginal2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      contractOriginal2.SetContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractReference"]);
      contractOriginal2.ContractStartDate = Conversions.ToDate(dataTable.Rows[0]["ContractStartDate"]);
      contractOriginal2.ContractEndDate = Conversions.ToDate(dataTable.Rows[0]["ContractEndDate"]);
      contractOriginal2.SetContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractStatusID"]);
      contractOriginal2.SetContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractPrice"]);
      contractOriginal2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractID"]);
      contractOriginal2.SetInvoiceFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceFrequencyID"]);
      contractOriginal2.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressID"]);
      contractOriginal2.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressTypeID"]);
      contractOriginal2.FirstInvoiceDate = Conversions.ToDate(dataTable.Rows[0]["FirstInvoiceDate"]);
      contractOriginal2.SetContractTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractTypeID"]);
      contractOriginal2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      contractOriginal2.SetCheque = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Cheque"]));
      contractOriginal2.SetCreditCard = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreditCard"]));
      contractOriginal2.SetDirectDebit = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DirectDebit"]));
      contractOriginal2.SetBankName = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BankName"]));
      contractOriginal2.SetAccountNumber = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccountNumber"]));
      contractOriginal2.SetSortCode = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SortCode"]));
      contractOriginal2.SetGasSupplyPipework = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GasSupplyPipework"]));
      contractOriginal2.CancelledDate = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CancelledDate"])) ? Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CancelledDate"])) : DateTime.MinValue;
      contractOriginal2.SetReasonID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonID"]));
      contractOriginal2.SetPlumbingDrainage = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PlumbingDrainage"]));
      contractOriginal2.SetWindowLockPest = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WindowLockPest"]));
      contractOriginal2.SetPoNumber = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PONumber"]));
      contractOriginal2.SetAnnual = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Annual"]));
      contractOriginal2.SetDiscountID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DiscountID"]);
      contractOriginal2.SetDoNotRenew = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DoNotRenew"]);
      contractOriginal2.SetDDMSRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DDMSRef"]);
      contractOriginal2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      contractOriginal1.Exists = true;
      return contractOriginal1;
    }

    public double ContractCalculatedTotal(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOriginalCalculatedTotal", true)));
    }

    public DataView Contract_GetAll_Renewal()
    {
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Contract_GetAll_Renewal), true);
      table.TableName = Enums.TableNames.tblContract.ToString();
      return new DataView(table);
    }

    public DataView Contract_Get_Renewal(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Contract_Get_Renewal), true);
      table.TableName = Enums.TableNames.tblContract.ToString();
      return new DataView(table);
    }

    public ContractOriginal Get_For_Quote_ID(int QuoteContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractOriginal_Get_For_Quote_ID", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractOriginal) null;
      ContractOriginal contractOriginal1 = new ContractOriginal();
      ContractOriginal contractOriginal2 = contractOriginal1;
      contractOriginal2.IgnoreExceptionsOnSetMethods = true;
      contractOriginal2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]);
      contractOriginal2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      contractOriginal2.SetContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractReference"]);
      contractOriginal2.ContractStartDate = Conversions.ToDate(dataTable.Rows[0]["ContractStartDate"]);
      contractOriginal2.ContractEndDate = Conversions.ToDate(dataTable.Rows[0]["ContractEndDate"]);
      contractOriginal2.SetContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractStatusID"]);
      contractOriginal2.SetContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractPrice"]);
      contractOriginal2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (QuoteContractID)]);
      contractOriginal2.SetInvoiceFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceFrequencyID"]);
      contractOriginal2.FirstInvoiceDate = Conversions.ToDate(dataTable.Rows[0]["FirstInvoiceDate"]);
      contractOriginal2.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressID"]);
      contractOriginal2.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressTypeID"]);
      contractOriginal2.SetContractTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractTypeID"]);
      contractOriginal2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      contractOriginal2.SetCheque = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Cheque"]));
      contractOriginal2.SetCreditCard = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreditCard"]));
      contractOriginal2.SetDirectDebit = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DirectDebit"]));
      contractOriginal2.SetBankName = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BankName"]));
      contractOriginal2.SetAccountNumber = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccountNumber"]));
      contractOriginal2.SetSortCode = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SortCode"]));
      contractOriginal2.SetGasSupplyPipework = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GasSupplyPipework"]));
      contractOriginal2.SetPlumbingDrainage = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PlumbingDrainage"]));
      contractOriginal2.SetWindowLockPest = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WindowLockPest"]));
      contractOriginal2.SetPoNumber = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PONumber"]));
      contractOriginal2.SetDiscountID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DiscountID"]);
      contractOriginal2.SetDoNotRenew = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DoNotRenew"]);
      contractOriginal2.SetDDMSRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DDMSRef"]);
      contractOriginal2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      contractOriginal1.Exists = true;
      return contractOriginal1;
    }

    public ContractOriginal Insert(ContractOriginal oContract)
    {
      this._database.ClearParameter();
      this.AddContractParametersToCommand(ref oContract);
      oContract.SetContractID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOriginal_Insert", true)));
      oContract.Exists = true;
      return oContract;
    }

    public void Insert_UpgradedFrom(int contractId, string upgradedFrom)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) contractId, true);
      this._database.AddParameter("@UpgradedFrom", (object) upgradedFrom, true);
      this._database.ExecuteSP_NO_Return("ContractOriginal_Insert_UpgradedFrom", true);
    }

    public void Update(ContractOriginal oContract)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) oContract.ContractID, true);
      if (DateTime.Compare(oContract.CancelledDate, DateTime.MinValue) == 0)
        this._database.AddParameter("@CancelledDate", (object) DBNull.Value, true);
      else
        this._database.AddParameter("@CancelledDate", (object) oContract.CancelledDate, true);
      this._database.AddParameter("@ReasonID", (object) oContract.ReasonID, true);
      this.AddContractParametersToCommand(ref oContract);
      this._database.ExecuteSP_NO_Return("ContractOriginal_Update", true);
    }

    public void Delete(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      this._database.AddParameter("@ContractOpt1Enum", (object) 327, true);
      this._database.ExecuteSP_NO_Return("ContractOriginal_Delete", true);
    }

    public object Transfer(int ContractID, int ContractSiteID, DateTime EffDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      this._database.AddParameter("@EffDate", (object) EffDate, true);
      return this._database.ExecuteSP_OBJECT("ContractOriginal_Transfer", true);
    }

    private void AddContractParametersToCommand(ref ContractOriginal oContract)
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
      database.AddParameter("@FirstInvoiceDate", (object) oContract.FirstInvoiceDate, true);
      database.AddParameter("@InvoiceAddressID", (object) oContract.InvoiceAddressID, true);
      database.AddParameter("@InvoiceAddressTypeID", (object) oContract.InvoiceAddressTypeID, true);
      database.AddParameter("@ContractTypeID", (object) oContract.ContractTypeID, true);
      database.AddParameter("@Cheque", (object) oContract.Cheque, true);
      database.AddParameter("@CreditCard", (object) oContract.CreditCard, true);
      database.AddParameter("@DirectDebit", (object) oContract.DirectDebit, true);
      database.AddParameter("@BankName", (object) oContract.BankName, true);
      database.AddParameter("@AccountNumber", (object) oContract.AccountNumber, true);
      database.AddParameter("@SortCode", (object) oContract.SortCode, true);
      database.AddParameter("@GasSupplyPipework", (object) oContract.GasSupplyPipework, true);
      database.AddParameter("@PlumbingDrainage", (object) oContract.PlumbingDrainage, true);
      database.AddParameter("@WindowLockPest", (object) oContract.WindowLockPest, true);
      database.AddParameter("@PONumber", (object) oContract.PoNumber, true);
      database.AddParameter("@Annual", (object) oContract.Annual, true);
      database.AddParameter("@AfterVAT", (object) oContract.ContractPriceAfterVAT, true);
      database.AddParameter("@DiscountID", (object) oContract.DiscountID, true);
      database.AddParameter("@DoNotRenew", (object) oContract.DoNotRenew, true);
      database.AddParameter("@DDMSRef", (object) oContract.DDMSRef, true);
      database.AddParameter("@PreviousInvoiceFrequencyID", (object) oContract.PreviousInvoiceFrequencyID, true);
      database.AddParameter("@Notes", (object) oContract.Notes, true);
    }

    public ContractOriginal Get_Current_ForSite(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractOriginal_Get_Current_ForSite", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractOriginal) null;
      ContractOriginal contractOriginal1 = new ContractOriginal();
      ContractOriginal contractOriginal2 = contractOriginal1;
      contractOriginal2.IgnoreExceptionsOnSetMethods = true;
      contractOriginal2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]);
      contractOriginal2.SetCustomerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]);
      contractOriginal2.SetContractReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractReference"]);
      contractOriginal2.ContractStartDate = Conversions.ToDate(dataTable.Rows[0]["ContractStartDate"]);
      contractOriginal2.ContractEndDate = Conversions.ToDate(dataTable.Rows[0]["ContractEndDate"]);
      contractOriginal2.SetContractStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractStatusID"]);
      contractOriginal2.SetContractPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractPrice"]);
      contractOriginal2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractID"]);
      contractOriginal2.SetInvoiceFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceFrequencyID"]);
      contractOriginal2.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressID"]);
      contractOriginal2.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressTypeID"]);
      contractOriginal2.FirstInvoiceDate = Conversions.ToDate(dataTable.Rows[0]["FirstInvoiceDate"]);
      contractOriginal2.SetContractTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractTypeID"]);
      contractOriginal2.SetContractType = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Type"]);
      contractOriginal2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      contractOriginal2.SetGasSupplyPipework = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GasSupplyPipework"]));
      contractOriginal2.SetPlumbingDrainage = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PlumbingDrainage"]));
      contractOriginal2.SetWindowLockPest = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WindowLockPest"]));
      contractOriginal2.SetPoNumber = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PONumber"]));
      contractOriginal2.SetDiscountID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DiscountID"]);
      contractOriginal2.SetDoNotRenew = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DoNotRenew"]);
      contractOriginal2.SetDDMSRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DDMSRef"]);
      contractOriginal2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      contractOriginal1.Exists = true;
      return contractOriginal1;
    }

    public DataView GetAll_ForSite(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Contract_GetAll_ForSite", true);
      table.TableName = Enums.TableNames.tblContract.ToString();
      return new DataView(table);
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginal_GetAll", true);
      table.TableName = Enums.TableNames.tblContract.ToString();
      return new DataView(table);
    }

    public DataView GetAllActive()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginal_GetAll_Active", true);
      table.TableName = Enums.TableNames.tblContract.ToString();
      return new DataView(table);
    }

    public DataView GetAll_ForSite_Active(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Contract_GetAll_ForSite_Active", true);
      table.TableName = Enums.TableNames.tblContract.ToString();
      return new DataView(table);
    }

    public DataView GetAssetsForContract(int ContractSiteID, bool MainApp)
    {
      return new DataView(this._database.ExecuteWithReturn("Select AssetID,Product From tblContractOriginalSiteAsset Where ContractSiteID =" + Conversions.ToString(ContractSiteID) + " AND (PrimaryAsset = '" + Conversions.ToString(MainApp) + "' ) ", true));
    }

    public DataView Get_NotProcessed(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Contract_Get_NotProcessed", true);
      table.TableName = Enums.TableNames.tblContract.ToString();
      return new DataView(table);
    }

    public DataView ContractOriginalSiteAsset_GetAll_SiteID(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (ContractOriginalSiteAsset_GetAll_SiteID), true);
      table.TableName = Enums.TableNames.tblContract.ToString();
      return new DataView(table);
    }

    public DataTable ProcessContract(int contractId)
    {
      DataTable table = App.DB.ContractOriginal.Get_NotProcessed(contractId).Table;
      table.Columns.Add("InvoiceNumber");
      DataTable dataTable1;
      try
      {
        IEnumerator enumerator;
        try
        {
          enumerator = table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            string Left = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Type"])) ? Conversions.ToString(current["Type"]) : "";
            string str = "0";
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Printed"])))
              str = Conversions.ToString(current["Printed"]);
            if (Conversions.ToBoolean(str) | Information.IsDBNull(RuntimeHelpers.GetObjectValue(current["Processed"])) | Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["Processed"])))
            {
              DataTable dataTable2 = App.DB.ExecuteWithReturn(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "select * from tblInvoicedLines il INNER join tblInvoiced i on i.InvoicedID = il.InvoicedID WHERE InvoiceToBeRaisedID = ", current["InvoiceToBeRaisedID"])), true);
              if (dataTable2.Rows.Count > 0)
                current["InvoiceNumber"] = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["InvoiceNumber"]);
            }
            else if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "TRANS", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "AMEND", false) == 0), Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "RENEWAL", false) == 0), Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["InvoiceFrequencyID"], (object) Enums.InvoiceFrequency.AnnuallyDD, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["InvoiceFrequencyID"], (object) Enums.InvoiceFrequency.Monthly, false)))), Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(Microsoft.VisualBasic.CompilerServices.Operators.ModObject(current["installments"], (object) 12), (object) 0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(current["installments"], (object) 0, false)))))
            {
              DataTable dataTable2 = App.DB.ExecuteWithReturn(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "select * from tblInvoicedLines il INNER join tblInvoiced i on i.InvoicedID = il.InvoicedID WHERE InvoiceToBeRaisedID = ", current["InvoiceToBeRaisedID"])), true);
              if (dataTable2.Rows.Count > 0)
              {
                current["InvoiceNumber"] = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["InvoiceNumber"]);
              }
              else
              {
                Invoiced oInvoiced = new Invoiced();
                JobNumber jobNumber = new JobNumber();
                JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Quoted | Enums.JobDefinition.Misc);
                oInvoiced.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
                oInvoiced.SetRaisedByUserID = (object) App.loggedInUser.UserID;
                oInvoiced.RaisedDate = Conversions.ToDate(current["RaiseDate"]);
                oInvoiced.SetVATRateID = (object) App.DB.VATRatesSQL.VATRates_Get_ByDate(DateAndTime.Now);
                Invoiced invoiced = App.DB.Invoiced.Insert(oInvoiced);
                App.DB.InvoicedLines.Insert(new InvoicedLines()
                {
                  SetAmount = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceFrequencyID"], (object) Enums.InvoiceFrequency.Monthly, false) ? RuntimeHelpers.GetObjectValue(current["ContractPrice"]) : Microsoft.VisualBasic.CompilerServices.Operators.DivideObject(current["FirstAmount"], (object) 1.2),
                  SetInvoicedID = (object) invoiced.InvoicedID,
                  SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(current["InvoiceToBeRaisedID"])
                });
                current["InvoiceNumber"] = (object) invoiced.InvoiceNumber;
              }
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        dataTable1 = table;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        dataTable1 = (DataTable) null;
        ProjectData.ClearProjectError();
      }
      return dataTable1;
    }
  }
}
