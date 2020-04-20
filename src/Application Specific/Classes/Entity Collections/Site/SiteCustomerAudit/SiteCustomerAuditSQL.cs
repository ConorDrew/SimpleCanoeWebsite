using System.Data;

namespace FSM.Entity
{
    namespace SiteCustomerAudits
    {
        public class SiteCustomerAuditSQL
        {
            private Sys.Database _database;

            public SiteCustomerAuditSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public DataView SiteCustomerAudit_GetAll(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("SiteCustomerAudit_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblSite.ToString();
                return new DataView(dt);
            }

            public SiteCustomerAudit Insert(SiteCustomerAudit oSiteCustomerAudit)
            {
                _database.ClearParameter();
                AddSiteCustomerAuditParametersToCommand(ref oSiteCustomerAudit);
                oSiteCustomerAudit.SetSiteCustomerAuditID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SiteCustomerAudit_Insert"));
                oSiteCustomerAudit.Exists = true;
                return oSiteCustomerAudit;
            }

            private void AddSiteCustomerAuditParametersToCommand(ref SiteCustomerAudit oSiteCustomerAudit)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@SiteID", oSiteCustomerAudit.SiteID, true);
                    withBlock.AddParameter("@PreviousCustomerID", oSiteCustomerAudit.PreviousCustomerID, true);
                    withBlock.AddParameter("@DateChanged", oSiteCustomerAudit.DateChanged, true);
                    withBlock.AddParameter("@UserID", oSiteCustomerAudit.UserID, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}