// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativeSiteAssets.QuoteContractAlternativeSiteAssetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativeSiteAssets
{
  public class QuoteContractAlternativeSiteAssetSQL
  {
    private Database _database;

    public QuoteContractAlternativeSiteAssetSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetAll_SiteID(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSiteAsset_GetAll_SiteID", true);
      table.TableName = Enums.TableNames.tblContractSiteAsset.ToString();
      return new DataView(table);
    }

    public DataView GetAll_JobItemID(int QuoteContractSiteJobItemID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteJobItemID", (object) QuoteContractSiteJobItemID, true);
      DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSiteAsset_GetAll_JobItemID", true);
      table.TableName = Enums.TableNames.tblContractSiteAsset.ToString();
      return new DataView(table);
    }

    public QuoteContractAlternativeSiteAsset Insert(
      QuoteContractAlternativeSiteAsset oQuoteContractSiteAsset)
    {
      this._database.ClearParameter();
      this.AddContractSiteAssetParametersToCommand(ref oQuoteContractSiteAsset);
      oQuoteContractSiteAsset.SetQuoteContractSiteAssetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteAsset_Insert", true)));
      oQuoteContractSiteAsset.Exists = true;
      return oQuoteContractSiteAsset;
    }

    public void Delete(int QuoteContractSiteJobItemID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteJobItemID", (object) QuoteContractSiteJobItemID, true);
      this._database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteAsset_Delete", true);
    }

    private void AddContractSiteAssetParametersToCommand(
      ref QuoteContractAlternativeSiteAsset oQuoteContractSiteAsset)
    {
      Database database = this._database;
      database.AddParameter("@QuoteContractSiteJobItemID", (object) oQuoteContractSiteAsset.QuoteContractSiteJobItemID, true);
      database.AddParameter("@AssetID", (object) oQuoteContractSiteAsset.AssetID, true);
    }
  }
}
