// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3SiteAsset.ContractOption3AssetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3SiteAsset
{
  public class ContractOption3AssetSQL
  {
    private Database _database;

    public ContractOption3AssetSQL(Database database)
    {
      this._database = database;
    }

    public DataView ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(
      int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, false);
      DataTable table = this._database.ExecuteSP_DataTable("ContractOption3SiteAssetDuration_GetAll_ForSiteID", true);
      table.TableName = Enums.TableNames.tblContractOption3SiteAsset.ToString();
      return new DataView(table);
    }

    public void ContractOption3SiteAssetDuration_Delete(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, false);
      this._database.ExecuteSP_NO_Return(nameof (ContractOption3SiteAssetDuration_Delete), true);
    }

    public FSM.Entity.ContractOption3SiteAsset.ContractOption3SiteAsset Insert(
      FSM.Entity.ContractOption3SiteAsset.ContractOption3SiteAsset oContractOption3SiteAsset)
    {
      this._database.ClearParameter();
      this.AddContractOption3SiteAssetParametersToCommand(ref oContractOption3SiteAsset);
      oContractOption3SiteAsset.SetContractSiteAssetDurationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOption3SiteAssetDuration_Insert", true)));
      oContractOption3SiteAsset.Exists = true;
      return oContractOption3SiteAsset;
    }

    private void AddContractOption3SiteAssetParametersToCommand(
      ref FSM.Entity.ContractOption3SiteAsset.ContractOption3SiteAsset oContractOption3SiteAsset)
    {
      Database database = this._database;
      database.AddParameter("@ContractSiteID", (object) oContractOption3SiteAsset.ContractSiteID, true);
      database.AddParameter("@AssetID", (object) oContractOption3SiteAsset.AssetID, true);
      database.AddParameter("@ScheduledMonth", (object) oContractOption3SiteAsset.ScheduledMonth, true);
      database.AddParameter("@VisitDuration", (object) oContractOption3SiteAsset.VisitDuration, true);
    }
  }
}
