using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSiteJobItems
    {
        public class QuoteContractAlternativeSiteJobItemsSQL
        {
            private Sys.Database _database;

            public QuoteContractAlternativeSiteJobItemsSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int QuoteContractSiteJobItemID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID, true);
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobItems_Delete");
            }

            public QuoteContractAlternativeSiteJobItems Get(int QuoteContractSiteJobItemID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractAlternativeSiteJobItems = new QuoteContractAlternativeSiteJobItems();
                        oContractAlternativeSiteJobItems.IgnoreExceptionsOnSetMethods = true;
                        oContractAlternativeSiteJobItems.SetQuoteContractSiteJobItemID = dt.Rows[0]["ContractSiteJobItemID"];
                        oContractAlternativeSiteJobItems.SetQuoteContractSiteID = dt.Rows[0]["ContractSiteID"];
                        oContractAlternativeSiteJobItems.SetDescription = dt.Rows[0]["Description"];
                        oContractAlternativeSiteJobItems.SetVisitFrequencyID = dt.Rows[0]["VisitFrequencyID"];
                        oContractAlternativeSiteJobItems.SetVisitDuration = dt.Rows[0]["VisitDuration"];
                        oContractAlternativeSiteJobItems.SetItemPricePerVisit = dt.Rows[0]["PricePerVisit"];
                        oContractAlternativeSiteJobItems.SetJobOfWorkID = dt.Rows[0]["JobOfWorkID"];
                        oContractAlternativeSiteJobItems.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oContractAlternativeSiteJobItems.Exists = true;
                        return oContractAlternativeSiteJobItems;
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
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_For_QuoteContractSiteID(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll_For_QuoteContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_For_JobOfWorkID(int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll_For_JobOfWorkID");
                dt.TableName = Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
                return new DataView(dt);
            }

            public QuoteContractAlternativeSiteJobItems Insert(QuoteContractAlternativeSiteJobItems oQuoteContractAlternativeSiteJobItems)
            {
                _database.ClearParameter();
                AddContractAlternativeSiteJobItemsParametersToCommand(ref oQuoteContractAlternativeSiteJobItems);
                oQuoteContractAlternativeSiteJobItems.SetQuoteContractSiteJobItemID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteJobItems_Insert"));
                oQuoteContractAlternativeSiteJobItems.Exists = true;
                return oQuoteContractAlternativeSiteJobItems;
            }

            public void Update(int QuoteContractSiteJobItemID, int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID, true);
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobItems_Update");
            }

            private void AddContractAlternativeSiteJobItemsParametersToCommand(ref QuoteContractAlternativeSiteJobItems oQuoteContractAlternativeSiteJobItems)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractSiteID", oQuoteContractAlternativeSiteJobItems.QuoteContractSiteID, true);
                    withBlock.AddParameter("@Description", oQuoteContractAlternativeSiteJobItems.Description, true);
                    withBlock.AddParameter("@VisitFrequencyID", oQuoteContractAlternativeSiteJobItems.VisitFrequencyID, true);
                    withBlock.AddParameter("@VisitDuration", oQuoteContractAlternativeSiteJobItems.VisitDuration, true);
                    withBlock.AddParameter("@ItemPricePerVisit", oQuoteContractAlternativeSiteJobItems.ItemPricePerVisit, true);
                    withBlock.AddParameter("@JobOfWorkID", oQuoteContractAlternativeSiteJobItems.JobOfWorkID, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}