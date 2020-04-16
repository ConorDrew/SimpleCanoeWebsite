// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativeSiteAssets.ContractAlternativeSiteAssetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractAlternativeSiteAssets
{
  public class ContractAlternativeSiteAssetSQL
  {
    private Database _database;

    public ContractAlternativeSiteAssetSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetAll_SiteID(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeSiteAsset_GetAll_SiteID", true);
      table.TableName = Enums.TableNames.tblContractSiteAsset.ToString();
      return new DataView(table);
    }

    public DataView GetAll_JobItemID(int ContractSiteJobItemID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteJobItemID", (object) ContractSiteJobItemID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractAlternativeSiteAsset_GetAll_JobItemID", true);
      table.TableName = Enums.TableNames.tblContractSiteAsset.ToString();
      return new DataView(table);
    }

    public ContractAlternativeSiteAsset Insert(
      ContractAlternativeSiteAsset oContractSiteAsset)
    {
      this._database.ClearParameter();
      this.AddContractSiteAssetParametersToCommand(ref oContractSiteAsset);
      oContractSiteAsset.SetContractSiteAssetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractAlternativeSiteAsset_Insert", true)));
      oContractSiteAsset.Exists = true;
      return oContractSiteAsset;
    }

    public void Delete(int ContractSiteJobItemID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteJobItemID", (object) ContractSiteJobItemID, true);
      this._database.ExecuteSP_NO_Return("ContractAlternativeSiteAsset_Delete", true);
    }

    private void AddContractSiteAssetParametersToCommand(
      ref ContractAlternativeSiteAsset oContractSiteAsset)
    {
      Database database = this._database;
      database.AddParameter("@ContractSiteJobItemID", (object) oContractSiteAsset.ContractSiteJobItemID, true);
      database.AddParameter("@AssetID", (object) oContractSiteAsset.AssetID, true);
    }
  }
}
