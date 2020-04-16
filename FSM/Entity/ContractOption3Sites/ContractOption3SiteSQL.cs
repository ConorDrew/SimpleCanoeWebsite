// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3Sites.ContractOption3SiteSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3Sites
{
  public class ContractOption3SiteSQL
  {
    private Database _database;

    public ContractOption3SiteSQL(Database database)
    {
      this._database = database;
    }

    public int Delete(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      this._database.AddParameter("@DownloadStatus", (object) 6, true);
      this._database.AddParameter("@ContractOpt3Enum", (object) 330, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("ContractOption3Site_Delete", true));
    }

    public ContractOption3Site ContractOption3Site_Get(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (ContractOption3Site_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractOption3Site) null;
      ContractOption3Site contractOption3Site1 = new ContractOption3Site();
      ContractOption3Site contractOption3Site2 = contractOption3Site1;
      contractOption3Site2.IgnoreExceptionsOnSetMethods = true;
      contractOption3Site2.SetContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ContractSiteID)]);
      contractOption3Site2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]);
      contractOption3Site2.SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
      contractOption3Site2.SetContractSiteReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractSiteReference"]);
      contractOption3Site2.StartDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartDate"]));
      contractOption3Site2.EndDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndDate"]));
      contractOption3Site2.FirstVisitDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FirstVisitDate"]));
      contractOption3Site2.SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitFrequencyID"]);
      contractOption3Site2.SetInvoiceFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceFrequencyID"]);
      contractOption3Site2.SetSitePrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SitePrice"]);
      contractOption3Site2.FirstInvoiceDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FirstInvoiceDate"]));
      contractOption3Site2.SetInvoiceAddressID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressID"]);
      contractOption3Site2.SetInvoiceAddressTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceAddressTypeID"]);
      contractOption3Site1.Exists = true;
      return contractOption3Site1;
    }

    public DataView ContractOption3Site_GetAll_ForContract(int ContractID, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, false);
      this._database.AddParameter("@CustomerID", (object) CustomerID, false);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (ContractOption3Site_GetAll_ForContract), true);
      table.TableName = Enums.TableNames.tblContractOption3Site.ToString();
      return new DataView(table);
    }

    public ContractOption3Site Insert(ContractOption3Site oContractOption3Site)
    {
      this._database.ClearParameter();
      this.AddContractOption3SiteParametersToCommand(ref oContractOption3Site);
      oContractOption3Site.SetContractSiteID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOption3Site_Insert", true)));
      oContractOption3Site.Exists = true;
      return oContractOption3Site;
    }

    public void Update(ContractOption3Site oContractOption3Site)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) oContractOption3Site.ContractSiteID, true);
      this.AddContractOption3SiteParametersToCommand(ref oContractOption3Site);
      this._database.ExecuteSP_NO_Return("ContractOption3Site_Update", true);
    }

    private void AddContractOption3SiteParametersToCommand(
      ref ContractOption3Site oContractOption3Site)
    {
      Database database = this._database;
      database.AddParameter("@ContractID", (object) oContractOption3Site.ContractID, true);
      database.AddParameter("@SiteID", (object) oContractOption3Site.PropertyID, true);
      database.AddParameter("@ContractSiteReference", (object) oContractOption3Site.ContractSiteReference, true);
      if (DateTime.Compare(oContractOption3Site.StartDate, Conversions.ToDate("#12:00:00 AM#")) == 0)
        database.AddParameter("@StartDate", (object) DBNull.Value, true);
      else
        database.AddParameter("@StartDate", (object) oContractOption3Site.StartDate, true);
      if (DateTime.Compare(oContractOption3Site.EndDate, Conversions.ToDate("#12:00:00 AM#")) == 0)
        database.AddParameter("@EndDate", (object) DBNull.Value, true);
      else
        database.AddParameter("@EndDate", (object) oContractOption3Site.EndDate, true);
      if (DateTime.Compare(oContractOption3Site.FirstVisitDate, Conversions.ToDate("#12:00:00 AM#")) == 0)
        database.AddParameter("@FirstVisitDate", (object) DBNull.Value, true);
      else
        database.AddParameter("@FirstVisitDate", (object) oContractOption3Site.FirstVisitDate, true);
      database.AddParameter("@VisitFrequencyID", (object) oContractOption3Site.VisitFrequencyID, true);
      database.AddParameter("@InvoiceFrequencyID", (object) oContractOption3Site.InvoiceFrequencyID, true);
      database.AddParameter("@SitePrice", (object) oContractOption3Site.SitePrice, true);
      if (DateTime.Compare(oContractOption3Site.FirstInvoiceDate, Conversions.ToDate("#12:00:00 AM#")) == 0)
        database.AddParameter("@FirstInvoiceDate", (object) DBNull.Value, true);
      else
        database.AddParameter("@FirstInvoiceDate", (object) oContractOption3Site.FirstInvoiceDate, true);
      database.AddParameter("@InvoiceAddressID", (object) oContractOption3Site.InvoiceAddressID, true);
      database.AddParameter("@InvoiceAddressTypeID", (object) oContractOption3Site.InvoiceAddressTypeID, true);
    }

    public string GetNextSiteReference(int ContractID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractOption3Site_GetLastSiteReference", true);
      string str1;
      if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteLetter"])))
      {
        str1 = "-A";
      }
      else
      {
        string str2 = Strings.Right(Conversions.ToString(dataTable.Rows[0]["SiteLetter"]), 1);
        string str3 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "Z", false) != 0 ? Conversions.ToString(Strings.Chr(checked (Strings.Asc(str2) + 1))) : "AA";
        str1 = "-" + Strings.Replace(Strings.Left(Conversions.ToString(dataTable.Rows[0]["SiteLetter"]), checked (Strings.Len(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteLetter"])) - 1)), "Z", "A", 1, -1, CompareMethod.Binary) + str3;
      }
      return Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(dataTable.Rows[0]["ContractReference"], (object) str1));
    }

    public int ActiveInactive(int ContractSiteID, bool InactiveFlag)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      this._database.AddParameter("@DownloadStatus", (object) 6, true);
      this._database.AddParameter("@InactiveFlag", (object) InactiveFlag, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("ContractOption3Site_ActiveInactive", true));
    }
  }
}
