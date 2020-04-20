// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Reports.ReportSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;

namespace FSM.Entity.Reports
{
    public class ReportSQL
    {
        private Database _database;

        public ReportSQL(Database database)
        {
            this._database = database;
        }

        public DataView Reports_ServicingStatistics(string WhereClause, string OrderClause)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Where", (object)WhereClause, true);
            this._database.AddParameter("@OrderBy", (object)OrderClause, true);
            this._database.ExecuteSP_NO_Return(nameof(Reports_ServicingStatistics), true);
            DataView dataView = null;
            return dataView;
        }

        public DataView Reports_WeeklyStatistics_Summary(
          DateTime StartDate,
          DateTime EndDate,
          int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@in_start", (object)StartDate, true);
            this._database.AddParameter("@in_finish", (object)EndDate, true);
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            return new DataView(this._database.ExecuteSP_DataTable("Reports_Servicing_WeeklyStats_Summary", true));
        }

        public DataView Reports_WeeklyStatistics_Detailed(DateTime StartDate, DateTime EndDate)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@in_start", (object)StartDate, true);
            this._database.AddParameter("@in_finish", (object)EndDate, true);
            return new DataView(this._database.ExecuteSP_DataTable("Reports_Servicing_WeeklyStats_Detailed", true));
        }

        public DataView Reports_ServiceLettersGenerated_Count(
          DateTime StartDate,
          DateTime EndDate,
          int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@StartDate", (object)StartDate, true);
            this._database.AddParameter("@EndDate", (object)EndDate, true);
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            return new DataView(this._database.ExecuteSP_DataTable(nameof(Reports_ServiceLettersGenerated_Count), true));
        }

        public DataView Reports_EngineerVisits_Scheduled(
          DateTime StartDate,
          DateTime EndDate,
          int CustomerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@totalRowCount", (object)0, true);
            this._database.AddParameter("@sortBy", (object)"1", true);
            this._database.AddParameter("@InvoiceTypeIDEnum", (object)260, true);
            this._database.AddParameter("@InvoicedIDEnum", (object)10, true);
            this._database.AddParameter("@ReadyToBeInvoicedIDEnum", (object)9, true);
            this._database.AddParameter("@NoNeedForInvoiceIDEnum", (object)8, true);
            this._database.AddParameter("@CustomerID", (object)CustomerID, true);
            this._database.AddParameter("@SiteID", (object)0, true);
            this._database.AddParameter("@EngineerID", (object)0, true);
            this._database.AddParameter("@JobDefinitionEnumID", (object)"0", true);
            this._database.AddParameter("@JobTypeID", (object)4702, true);
            this._database.AddParameter("@VisitEnumID", (object)"5", true);
            this._database.AddParameter("@OutcomeEnumID", (object)"0", true);
            this._database.AddParameter("@JobNumber", (object)"", true);
            this._database.AddParameter("@PONumber", (object)"", true);
            this._database.AddParameter("@DateFrom", (object)StartDate, true);
            this._database.AddParameter("@DateTo", (object)EndDate, true);
            this._database.AddParameter("@postcode", (object)"", true);
            this._database.AddParameter("@RegionID", (object)0, true);
            this._database.AddParameter("@ContractTypeID", (object)"0", true);
            this._database.AddParameter("@LetterType", (object)"0", true);
            this._database.AddParameter("@DueDateFrom", (object)null, true);
            this._database.AddParameter("@DueDateTo", (object)null, true);
            this._database.AddParameter("@ChargeInProgress", (object)"0", true);
            this._database.AddParameter("@CostsTo", (object)"%", true);
            return new DataView(this._database.ExecuteSP_DataTable(nameof(Reports_EngineerVisits_Scheduled), true));
        }

        public DataView Reports_BatchVisitCosts(string Where)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Wherestring", (object)Where, true);
            return new DataView(this._database.ExecuteSP_DataTable(nameof(Reports_BatchVisitCosts), true));
        }
    }
}