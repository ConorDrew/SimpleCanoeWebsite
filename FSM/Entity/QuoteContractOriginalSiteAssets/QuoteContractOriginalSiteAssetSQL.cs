// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOriginalSiteAssets.QuoteContractOriginalSiteAssetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOriginalSiteAssets
{
  public class QuoteContractOriginalSiteAssetSQL
  {
    private Database _database;

    public QuoteContractOriginalSiteAssetSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int QuoteContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteID", (object) QuoteContractSiteID, true);
      this._database.ExecuteSP_NO_Return("QuoteContractOriginalSiteAsset_Delete", true);
    }

    public DataView QuoteContractSiteAsset_GetAll_QuoteContractSiteID(
      int QuoteContractSiteID,
      int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteID", (object) QuoteContractSiteID, true);
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("QuoteContractOriginalSiteAsset_GetAll_QuoteContractSiteID", true);
      table.TableName = Enums.TableNames.tblQuoteContractSiteAsset.ToString();
      return new DataView(table);
    }

    public QuoteContractOriginalSiteAsset Insert(
      QuoteContractOriginalSiteAsset oQuoteContractSiteAsset)
    {
      this._database.ClearParameter();
      this.AddQuoteContractSiteAssetParametersToCommand(ref oQuoteContractSiteAsset);
      oQuoteContractSiteAsset.SetQuoteContractSiteAssetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOriginalSiteAsset_Insert", true)));
      oQuoteContractSiteAsset.Exists = true;
      return oQuoteContractSiteAsset;
    }

    private void AddQuoteContractSiteAssetParametersToCommand(
      ref QuoteContractOriginalSiteAsset oQuoteContractSiteAsset)
    {
      Database database = this._database;
      database.AddParameter("@QuoteContractSiteID", (object) oQuoteContractSiteAsset.QuoteContractSiteID, true);
      database.AddParameter("@AssetID", (object) oQuoteContractSiteAsset.AssetID, true);
      database.AddParameter("@PricePerVisit", (object) oQuoteContractSiteAsset.PricePerVisit, true);
    }
  }
}
