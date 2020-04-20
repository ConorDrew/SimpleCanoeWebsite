using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSites
    {
        public class QuoteContractAlternativeSiteSQL
        {
            private Sys.Database _database;

            public QuoteContractAlternativeSiteSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public QuoteContractAlternativeSite Get(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSite_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteContractSite = new QuoteContractAlternativeSite();
                        oQuoteContractSite.IgnoreExceptionsOnSetMethods = true;
                        oQuoteContractSite.SetQuoteContractSiteID = dt.Rows[0]["QuoteContractSiteID"];
                        oQuoteContractSite.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oQuoteContractSite.SetSiteID = dt.Rows[0]["SiteID"];
                        oQuoteContractSite.JobOfWorks = _database.QuoteContractAlternativeSiteJobOfWork.Get_For_QuoteContractSite_As_Objects(QuoteContractSiteID);
                        oQuoteContractSite.Exists = true;
                        return oQuoteContractSite;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSite_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractSite.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_QuoteContractID(int QuoteContractID, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSite_GetAll_QuoteContractID");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractSite.ToString();
                return new DataView(dt);
            }

            public QuoteContractAlternativeSite Insert(QuoteContractAlternativeSite oQuoteContractSite)
            {
                _database.ClearParameter();
                AddContractSiteParametersToCommand(ref oQuoteContractSite);
                oQuoteContractSite.SetQuoteContractSiteID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_Insert"));
                oQuoteContractSite.Exists = true;
                return oQuoteContractSite;
            }

            public void Update(QuoteContractAlternativeSite oQuoteContractSite)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", oQuoteContractSite.QuoteContractSiteID, true);
                AddContractSiteParametersToCommand(ref oQuoteContractSite);
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSite_Update");
            }

            public int Delete(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_Delete"));
            }

            public int ActiveInactive(int QuoteContractSiteID, bool InactiveFlag)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                _database.AddParameter("@DownloadStatus", Conversions.ToInteger(Sys.Enums.VisitStatus.Downloaded), true);
                _database.AddParameter("@InactiveFlag", InactiveFlag, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_ActiveInactive"));
            }

            private void AddContractSiteParametersToCommand(ref QuoteContractAlternativeSite oQuoteContractSite)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractID", oQuoteContractSite.QuoteContractID, true);
                    withBlock.AddParameter("@SiteID", oQuoteContractSite.SiteID, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        }
    }
}