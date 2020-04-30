using System;
using System.Data;

namespace FSM.Entity
{
    namespace Reports
    {
        public class ReportSQL
        {
            private Sys.Database _database;

            public ReportSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public DataView Reports_ServicingStatistics(string WhereClause, string OrderClause)
            {
                _database.ClearParameter();
                _database.AddParameter("@Where", WhereClause, true);
                _database.AddParameter("@OrderBy", OrderClause, true);
                _database.ExecuteSP_NO_Return("Reports_ServicingStatistics");
                return default;
            }

            public DataView Reports_WeeklyStatistics_Summary(DateTime StartDate, DateTime EndDate, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@in_start", StartDate, true);
                _database.AddParameter("@in_finish", EndDate, true);
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("Reports_Servicing_WeeklyStats_Summary");
                return new DataView(dt);
            }

            public DataView Reports_WeeklyStatistics_Detailed(DateTime StartDate, DateTime EndDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@in_start", StartDate, true);
                _database.AddParameter("@in_finish", EndDate, true);
                var dt = _database.ExecuteSP_DataTable("Reports_Servicing_WeeklyStats_Detailed");
                return new DataView(dt);
            }

            public DataView Reports_ServiceLettersGenerated_Count(DateTime StartDate, DateTime EndDate, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@StartDate", StartDate, true);
                _database.AddParameter("@EndDate", EndDate, true);
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("Reports_ServiceLettersGenerated_Count");
                return new DataView(dt);
            }

            public DataView Reports_EngineerVisits_Scheduled(DateTime StartDate, DateTime EndDate, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@totalRowCount", 0, true);
                _database.AddParameter("@sortBy", "1", true);
                _database.AddParameter("@InvoiceTypeIDEnum", 260, true);
                _database.AddParameter("@InvoicedIDEnum", 10, true);
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", 9, true);
                _database.AddParameter("@NoNeedForInvoiceIDEnum", 8, true);
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@SiteID", 0, true);
                _database.AddParameter("@EngineerID", 0, true);
                _database.AddParameter("@JobDefinitionEnumID", "0", true);
                _database.AddParameter("@JobTypeID", 4702, true);
                _database.AddParameter("@VisitEnumID", "5", true);
                _database.AddParameter("@OutcomeEnumID", "0", true);
                _database.AddParameter("@JobNumber", "", true);
                _database.AddParameter("@PONumber", "", true);
                _database.AddParameter("@DateFrom", StartDate, true);
                _database.AddParameter("@DateTo", EndDate, true);
                _database.AddParameter("@postcode", "", true);
                _database.AddParameter("@RegionID", 0, true);
                _database.AddParameter("@ContractTypeID", "0", true);
                _database.AddParameter("@LetterType", "0", true);
                _database.AddParameter("@DueDateFrom", null, true);
                _database.AddParameter("@DueDateTo", null, true);
                _database.AddParameter("@ChargeInProgress", "0", true);
                _database.AddParameter("@CostsTo", "%", true);
                var dt = _database.ExecuteSP_DataTable("Reports_EngineerVisits_Scheduled");
                return new DataView(dt);
            }

            public DataView Reports_BatchVisitCosts(string Where)
            {
                _database.ClearParameter();
                _database.AddParameter("@Wherestring", Where, true);
                var dt = _database.ExecuteSP_DataTable("Reports_BatchVisitCosts");
                return new DataView(dt);
            }
            
        }
    }
}