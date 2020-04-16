// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalSites.ContractOriginalSiteSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalSites
{
  public class ContractOriginalSiteSQL
  {
    private Database _database;

    public ContractOriginalSiteSQL(Database database)
    {
      this._database = database;
    }

    public ContractOriginalSite Get(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("ContractOriginalSite_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ContractOriginalSite) null;
      ContractOriginalSite contractOriginalSite1 = new ContractOriginalSite();
      ContractOriginalSite contractOriginalSite2 = contractOriginalSite1;
      contractOriginalSite2.IgnoreExceptionsOnSetMethods = true;
      contractOriginalSite2.SetContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ContractSiteID)]);
      contractOriginalSite2.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]);
      contractOriginalSite2.SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
      contractOriginalSite2.SetPricePerVisit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PricePerVisit"]);
      contractOriginalSite2.FirstVisitDate = Conversions.ToDate(dataTable.Rows[0]["FirstVisitDate"]);
      contractOriginalSite2.SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitFrequencyID"]);
      contractOriginalSite2.SetVisitDuration = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitDuration"]);
      contractOriginalSite2.SetAverageMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AverageMileage"]);
      contractOriginalSite2.SetIncludeAssetPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IncludeAssetPrice"]);
      contractOriginalSite2.SetIncludeMileagePrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IncludeMileagePrice"]);
      contractOriginalSite2.SetPricePerMile = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PricePerMile"]);
      contractOriginalSite2.SetTotalSitePrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TotalSitePrice"]);
      contractOriginalSite2.SetIncludeRates = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IncludeRates"]);
      contractOriginalSite2.SetLLCertReqd = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LLCertReqd"]);
      contractOriginalSite2.SetAdditionalNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AdditionalNotes"]);
      contractOriginalSite2.SetCommercial = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Commercial"]));
      contractOriginalSite2.SetMainAppliances = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MainAppliances"]);
      contractOriginalSite2.SetSecondryAppliances = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SecondryAppliances"]);
      contractOriginalSite2.ContractSiteScheduleOfRates = App.DB.ContractOriginalSiteRates.ContractOriginalSiteRates_GetForContractSite(contractOriginalSite2.ContractSiteID);
      contractOriginalSite1.Exists = true;
      return contractOriginalSite1;
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginalSite_GetAll", true);
      table.TableName = Enums.TableNames.tblContractSite.ToString();
      return new DataView(table);
    }

    public DataView GetAll_ContractID(int ContractID, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginalSite_GetAll_ContractID", true);
      table.TableName = Enums.TableNames.tblContractSite.ToString();
      return new DataView(table);
    }

    public DataView GetAll_ContractID2(int ContractID, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractID", (object) ContractID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginalSite_GetAll_ContractID2", true);
      table.TableName = Enums.TableNames.tblContractSite.ToString();
      return new DataView(table);
    }

    private object GetContractOriginalSiteScheduleOfRate(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("ContractOriginalSiteScheduleOfRate_Get", true);
      table.TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
      return (object) new DataView(table);
    }

    public ContractOriginalSite Insert(ContractOriginalSite oContractSite)
    {
      this._database.ClearParameter();
      this.AddContractSiteParametersToCommand(ref oContractSite);
      oContractSite.SetContractSiteID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ContractOriginalSite_Insert", true)));
      oContractSite.Exists = true;
      return oContractSite;
    }

    public void Update(ContractOriginalSite oContractSite)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) oContractSite.ContractSiteID, true);
      this.AddContractSiteParametersToCommand(ref oContractSite);
      this._database.ExecuteSP_NO_Return("ContractOriginalSite_Update", true);
    }

    public int Delete(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      this._database.AddParameter("@DownloadStatus", (object) 6, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("ContractOriginalSite_Delete", true));
    }

    public int ActiveInactive(int ContractSiteID, bool InactiveFlag)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      this._database.AddParameter("@DownloadStatus", (object) 5, true);
      this._database.AddParameter("@InactiveFlag", (object) InactiveFlag, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("ContractOriginalSite_ActiveInactive", true));
    }

    public void Delete_Visits(int ContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) ContractSiteID, true);
      this._database.ExecuteSP_OBJECT("ContractOriginalSite_Visits_Delete", true);
    }

    private void AddContractSiteParametersToCommand(ref ContractOriginalSite oContractSite)
    {
      Database database = this._database;
      database.AddParameter("@ContractID", (object) oContractSite.ContractID, true);
      database.AddParameter("@SiteID", (object) oContractSite.PropertyID, true);
      database.AddParameter("@PricePerVisit", (object) oContractSite.PricePerVisit, true);
      database.AddParameter("@FirstVisitDate", (object) oContractSite.FirstVisitDate, true);
      database.AddParameter("@VisitFrequencyID", (object) oContractSite.VisitFrequencyID, true);
      database.AddParameter("@VisitDuration", (object) oContractSite.VisitDuration, true);
      database.AddParameter("@AverageMileage", (object) oContractSite.AverageMileage, true);
      database.AddParameter("@IncludeAssetPrice", (object) oContractSite.IncludeAssetPrice, true);
      database.AddParameter("@IncludeMileagePrice", (object) oContractSite.IncludeMileagePrice, true);
      database.AddParameter("@PricePerMile", (object) oContractSite.PricePerMile, true);
      database.AddParameter("@TotalSitePrice", (object) oContractSite.TotalSitePrice, true);
      database.AddParameter("@IncludeRates", (object) oContractSite.IncludeRates, true);
      database.AddParameter("@LLCertReqd", (object) oContractSite.LLCertReqd, true);
      database.AddParameter("@AdditionalNotes", (object) oContractSite.AdditionalNotes, true);
      database.AddParameter("@Commercial", (object) oContractSite.Commercial, true);
      database.AddParameter("@MainAppliances", (object) oContractSite.MainAppliances, true);
      database.AddParameter("@SecondryAppliances", (object) oContractSite.SecondryAppliances, true);
    }

    private void SaveRates(ContractOriginalSite oContractSite)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContractSiteID", (object) oContractSite.ContractSiteID, true);
      this._database.ExecuteSP_NO_Return("ContractOriginalSiteScheduleOfRate_Delete", true);
      if (oContractSite.ContractSiteScheduleOfRates == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = oContractSite.ContractSiteScheduleOfRates.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          this._database.ClearParameter();
          this._database.AddParameter("@ContractSiteID", (object) oContractSite.ContractSiteID, true);
          this._database.AddParameter("@ScheduleOfRatesCategoryID", RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"]), true);
          this._database.AddParameter("@Code", RuntimeHelpers.GetObjectValue(current["Code"]), true);
          this._database.AddParameter("@Description", RuntimeHelpers.GetObjectValue(current["Description"]), true);
          this._database.AddParameter("@Price", RuntimeHelpers.GetObjectValue(current["Price"]), true);
          this._database.AddParameter("@QtyPerVisit", RuntimeHelpers.GetObjectValue(current["QtyPerVisit"]), true);
          this._database.ExecuteSP_NO_Return("ContractOriginalSiteScheduleOfRate_Insert", true);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }
  }
}
