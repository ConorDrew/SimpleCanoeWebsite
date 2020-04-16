// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOriginalSites.QuoteContractOriginalSiteSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOriginalSites
{
    public class QuoteContractOriginalSiteSQL
    {
        private Database _database;

        public QuoteContractOriginalSiteSQL(Database database)
        {
            this._database = database;
        }

        public QuoteContractOriginalSite Get(int QuoteContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)QuoteContractSiteID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("QuoteContractOriginalSite_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (QuoteContractOriginalSite)null;
            QuoteContractOriginalSite contractOriginalSite1 = new QuoteContractOriginalSite();
            QuoteContractOriginalSite contractOriginalSite2 = contractOriginalSite1;
            contractOriginalSite2.IgnoreExceptionsOnSetMethods = true;
            contractOriginalSite2.SetQuoteContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(QuoteContractSiteID)]);
            contractOriginalSite2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractID"]);
            contractOriginalSite2.SetSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
            contractOriginalSite2.SetPricePerVisit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PricePerVisit"]);
            contractOriginalSite2.SetVisitFrequencyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitFrequencyID"]);
            contractOriginalSite2.SetVisitDuration = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitDuration"]);
            contractOriginalSite2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            contractOriginalSite2.SetIncludeAssetPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IncludeAssetPrice"]);
            contractOriginalSite2.SetAverageMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AverageMileage"]);
            contractOriginalSite2.SetPricePerMile = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PricePerMile"]);
            contractOriginalSite2.SetIncludeMileagePrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IncludeMileagePrice"]);
            contractOriginalSite2.SetIncludeRates = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IncludeRates"]);
            contractOriginalSite2.SetTotalSitePrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TotalSitePrice"]);
            contractOriginalSite2.ContractSiteScheduleOfRates = (DataView)this.GetQuoteContractOriginalSiteScheduleOfRate(contractOriginalSite2.QuoteContractSiteID);
            contractOriginalSite1.Exists = true;
            return contractOriginalSite1;
        }

        public DataView GetAll_QuoteContractID(int QuoteContractID, int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractID", (object)QuoteContractID, true);
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractOriginalSite_GetAll_QuoteContractID", true);
            table.TableName = Enums.TableNames.tblQuoteContractSite.ToString();
            return new DataView(table);
        }

        public object GetQuoteContractOriginalSiteScheduleOfRate(int QuoteContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)QuoteContractSiteID, true);
            DataTable table = this._database.ExecuteSP_DataTable("QuoteContractOriginalSiteScheduleOfRate_Get", true);
            table.TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
            return (object)new DataView(table);
        }

        public QuoteContractOriginalSite Insert(
          QuoteContractOriginalSite oQuoteContractSite)
        {
            this._database.ClearParameter();
            this.AddQuoteContractSiteParametersToCommand(ref oQuoteContractSite);
            oQuoteContractSite.SetQuoteContractSiteID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractOriginalSite_Insert", true)));
            oQuoteContractSite.Exists = true;
            this.SaveRates(oQuoteContractSite);
            return oQuoteContractSite;
        }

        public void Update(QuoteContractOriginalSite oQuoteContractSite)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)oQuoteContractSite.QuoteContractSiteID, true);
            this.AddQuoteContractSiteParametersToCommand(ref oQuoteContractSite);
            this._database.ExecuteSP_NO_Return("QuoteContractOriginalSite_Update", true);
            this.SaveRates(oQuoteContractSite);
        }

        public void Delete(int QuoteContractSiteID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)QuoteContractSiteID, true);
            this._database.ExecuteSP_NO_Return("QuoteContractOriginalSite_Delete", true);
        }

        private void AddQuoteContractSiteParametersToCommand(
          ref QuoteContractOriginalSite oQuoteContractSite)
        {
            Database database = this._database;
            database.AddParameter("@QuoteContractID", (object)oQuoteContractSite.QuoteContractID, true);
            database.AddParameter("@SiteID", (object)oQuoteContractSite.SiteID, true);
            database.AddParameter("@PricePerVisit", (object)oQuoteContractSite.PricePerVisit, true);
            database.AddParameter("@VisitFrequencyID", (object)oQuoteContractSite.VisitFrequencyID, true);
            database.AddParameter("@VisitDuration", (object)oQuoteContractSite.VisitDuration, true);
            database.AddParameter("@IncludeAssetPrice", (object)oQuoteContractSite.IncludeAssetPrice, true);
            database.AddParameter("@AverageMileage", (object)oQuoteContractSite.AverageMileage, true);
            database.AddParameter("@PricePerMile", (object)oQuoteContractSite.PricePerMile, true);
            database.AddParameter("@IncludeMileagePrice", (object)oQuoteContractSite.IncludeMileagePrice, true);
            database.AddParameter("@IncludeRates", (object)oQuoteContractSite.IncludeRates, true);
            database.AddParameter("@TotalSitePrice", (object)oQuoteContractSite.TotalSitePrice, true);
        }

        private void SaveRates(QuoteContractOriginalSite oQuoteContractSite)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteContractSiteID", (object)oQuoteContractSite.QuoteContractSiteID, true);
            this._database.ExecuteSP_NO_Return("QuoteContractOriginalSiteScheduleOfRate_Delete", true);
            if (oQuoteContractSite.ContractSiteScheduleOfRates == null)
                return;

            foreach (DataRow current in oQuoteContractSite.ContractSiteScheduleOfRates.Table.Rows)
            {
                this._database.ClearParameter();
                this._database.AddParameter("@QuoteContractSiteID", (object)oQuoteContractSite.QuoteContractSiteID, true);
                this._database.AddParameter("@ScheduleOfRatesCategoryID", RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"]), true);
                this._database.AddParameter("@Code", RuntimeHelpers.GetObjectValue(current["Code"]), true);
                this._database.AddParameter("@Description", RuntimeHelpers.GetObjectValue(current["Description"]), true);
                this._database.AddParameter("@Price", RuntimeHelpers.GetObjectValue(current["Price"]), true);
                this._database.AddParameter("@QtyPerVisit", RuntimeHelpers.GetObjectValue(current["QtyPerVisit"]), true);
                this._database.ExecuteSP_NO_Return("QuoteContractOriginalSiteScheduleOfRate_Insert", true);
            }
        }
    }
}