// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativeSites.ContractAlternativeSiteSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractAlternativeSites
{
  public class ContractAlternativeSiteSQL
  {
    private Database _database;

    public ContractAlternativeSiteSQL(Database database)
    {
      this._database = database;
    }

    public ContractAlternativeSite Get(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractAlternativeSite_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractAlternativeSite) null;
      ContractAlternativeSite contractAlternativeSite1 = new ContractAlternativeSite();
      ContractAlternativeSite contractAlternativeSite2 = contractAlternativeSite1;
      contractAlternativeSite2.IgnoreExceptionsOnSetMethods = true;
      contractAlternativeSite2.SetContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ContractSiteID)]);
      contractAlternativeSite2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]);
      contractAlternativeSite2.SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
      contractAlternativeSite2.JobOfWorks = this._database.ContractAlternativeSiteJobOfWork.Get_For_ContractSite_As_Objects(ContractSiteID);
      contractAlternativeSite1.Exists = true;
      return contractAlternativeSite1;
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeSite_GetAll", true);
      table.TableName = Enums.TableNames.tblContractSite.ToString();
      return new DataView(table);
    }

    public DataView GetAll_ContractID(int ContractID, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeSite_GetAll_ContractID", true);
      table.TableName = Enums.TableNames.tblContractSite.ToString();
      return new DataView(table);
    }

    public ContractAlternativeSite Insert(
      ContractAlternativeSite oContractSite)
    {
      this._database.ClearParameter();
      this.AddContractSiteParametersToCommand(ref oContractSite);
      oContractSite.SetContractSiteID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractAlternativeSite_Insert", true)));
      oContractSite.Exists = true;
      return oContractSite;
    }

    public void Update(ContractAlternativeSite oContractSite)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) oContractSite.ContractSiteID, true);
      this.AddContractSiteParametersToCommand(ref oContractSite);
      this._database.ExecuteSP_NO_Return("ContractAlternativeSite_Update", true);
    }

    public int Delete(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      this._database.AddParameter("@DownloadStatus", (object) 6, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("ContractAlternativeSite_Delete", true));
    }

    public int ActiveInactive(int ContractSiteID, bool InactiveFlag)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      this._database.AddParameter("@DownloadStatus", (object) 6, true);
      this._database.AddParameter("@InactiveFlag", (object) InactiveFlag, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("ContractAlternativeSite_ActiveInactive", true));
    }

    private void AddContractSiteParametersToCommand(ref ContractAlternativeSite oContractSite)
    {
      Database database = this._database;
      database.AddParameter("@ContractID", (object) oContractSite.ContractID, true);
      database.AddParameter("@SiteID", (object) oContractSite.PropertyID, true);
    }
  }
}
