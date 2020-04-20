using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Orders
    {
        public class POInvoiceSQL
        {
            private Sys.Database _database;

            public POInvoiceSQL(Sys.Database database)
            {
                _database = database;
            }
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void POInvoiceImport_UpdateAuthorised(int ID, bool Authorised, int AuthorisedByUserID, DateTime AuthorisedOn, string AuthReason, string AuthReasonDetail = "")
            {
                _database.ClearParameter();
                _database.AddParameter("@ID", ID, true);
                _database.AddParameter("@Authorised", Authorised, true);
                _database.AddParameter("@AuthorisedByUserID", AuthorisedByUserID, true);
                _database.AddParameter("@AuthorisedOn", AuthorisedOn, true);
                _database.AddParameter("@AuthReason", AuthReason, true);
                _database.AddParameter("@AuthReasonDetail", AuthReasonDetail, true);
                _database.AddParameter("@ValidateResult", 11, true);
                _database.ExecuteSP_NO_Return("POInvoiceImport_UpdateAuthorisation");
            }

            public DataView POInvoiceImport_RefreshData(int ValidateResult, string PODepartment)
            {
                _database.ClearParameter();
                _database.AddParameter("@ValidateResult", ValidateResult, true);
                _database.AddParameter("@PODepartment", PODepartment, true);
                var dt = _database.ExecuteSP_DataTable("POInvoiceImport_ShowDataAuthorisation");
                dt.TableName = "POInvoiceImport_ShowData";
                return new DataView(dt);
            }

            public int POExceptionCount(string PODepartment)
            {
                _database.ClearParameter();
                _database.AddParameter("@PODepartment", PODepartment, true);
                return Conversions.ToInteger(_database.ExecuteScalar("SELECT COUNT(*) from tblPOInvoiceImport_Orders WHERE RequiresAuthorisation = 1 AND Authorised = 0 AND PODepartment = @PODepartment"));
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}