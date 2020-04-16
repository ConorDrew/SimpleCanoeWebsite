// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOption3SiteAssetDurations.QuoteContractOption3SiteAssetDurationSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOption3SiteAssetDurations
{
  public class QuoteContractOption3SiteAssetDurationSQL
  {
    private Database _database;

    public QuoteContractOption3SiteAssetDurationSQL(Database database)
    {
      this._database = database;
    }

    public DataView QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(
      int QuoteContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteID", (object) QuoteContractSiteID, false);
      DataTable table = this._database.ExecuteSP_DataTable("QuoteContractOption3SiteAssetDuration_GetAll_ForSiteID", true);
      table.TableName = Enums.TableNames.tblQuoteContractOption3SiteAsset.ToString();
      return new DataView(table);
    }

    public void QuoteContractOption3SiteAssetDuration_Delete(int QuoteContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteID", (object) QuoteContractSiteID, false);
      this._database.ExecuteSP_NO_Return(nameof (QuoteContractOption3SiteAssetDuration_Delete), true);
    }

    public QuoteContractOption3SiteAssetDuration Insert(
      QuoteContractOption3SiteAssetDuration oQuoteContractOption3SiteAsset)
    {
      this._database.ClearParameter();
      this.AddQuoteContractOption3SiteAssetParametersToCommand(ref oQuoteContractOption3SiteAsset);
      oQuoteContractOption3SiteAsset.SetQuoteContractSiteAssetDurationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOption3SiteAssetDuration_Insert", true)));
      oQuoteContractOption3SiteAsset.Exists = true;
      return oQuoteContractOption3SiteAsset;
    }

    private void AddQuoteContractOption3SiteAssetParametersToCommand(
      ref QuoteContractOption3SiteAssetDuration oQuoteContractOption3SiteAsset)
    {
      Database database = this._database;
      database.AddParameter("@QuoteContractSiteID", (object) oQuoteContractOption3SiteAsset.QuoteContractSiteID, true);
      database.AddParameter("@AssetID", (object) oQuoteContractOption3SiteAsset.AssetID, true);
      database.AddParameter("@ScheduledMonth", (object) oQuoteContractOption3SiteAsset.ScheduledMonth, true);
      database.AddParameter("@VisitDuration", (object) oQuoteContractOption3SiteAsset.VisitDuration, true);
    }
  }
}
