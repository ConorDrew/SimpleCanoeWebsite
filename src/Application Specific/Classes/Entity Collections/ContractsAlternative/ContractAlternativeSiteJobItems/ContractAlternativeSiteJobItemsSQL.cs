using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteJobItems
    {
        public class ContractAlternativeSiteJobItemsSQL
        {
            private Sys.Database _database;

            public ContractAlternativeSiteJobItemsSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int ContractSiteJobItemID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID, true);
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteJobItems_Delete");
            }

            public ContractAlternativeSiteJobItems Get(int ContractSiteJobItemID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractAlternativeSiteJobItems = new ContractAlternativeSiteJobItems();
                        oContractAlternativeSiteJobItems.IgnoreExceptionsOnSetMethods = true;
                        oContractAlternativeSiteJobItems.SetContractSiteJobItemID = dt.Rows[0]["ContractSiteJobItemID"];
                        oContractAlternativeSiteJobItems.SetContractSiteID = dt.Rows[0]["ContractSiteID"];
                        oContractAlternativeSiteJobItems.SetDescription = dt.Rows[0]["Description"];
                        oContractAlternativeSiteJobItems.SetVisitFrequencyID = dt.Rows[0]["VisitFrequencyID"];
                        oContractAlternativeSiteJobItems.SetVisitDuration = dt.Rows[0]["VisitDuration"];
                        oContractAlternativeSiteJobItems.SetItemPricePerVisit = dt.Rows[0]["ItemPricePerVisit"];
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
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_For_ContractSiteID(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID);
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll_For_ContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_For_JobOfWorkID(int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID);
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll_For_JobOfWorkID");
                dt.TableName = Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
                return new DataView(dt);
            }

            public ContractAlternativeSiteJobItems Insert(ContractAlternativeSiteJobItems oContractAlternativeSiteJobItems)
            {
                _database.ClearParameter();
                AddContractAlternativeSiteJobItemsParametersToCommand(ref oContractAlternativeSiteJobItems);
                oContractAlternativeSiteJobItems.SetContractSiteJobItemID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativeSiteJobItems_Insert"));
                oContractAlternativeSiteJobItems.Exists = true;
                return oContractAlternativeSiteJobItems;
            }

            public void Update(int ContractSiteJobItemID, int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID, true);
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteJobItems_Update");
            }

            private void AddContractAlternativeSiteJobItemsParametersToCommand(ref ContractAlternativeSiteJobItems oContractAlternativeSiteJobItems)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteID", oContractAlternativeSiteJobItems.ContractSiteID, true);
                    withBlock.AddParameter("@Description", oContractAlternativeSiteJobItems.Description, true);
                    withBlock.AddParameter("@VisitFrequencyID", oContractAlternativeSiteJobItems.VisitFrequencyID, true);
                    withBlock.AddParameter("@VisitDuration", oContractAlternativeSiteJobItems.VisitDuration, true);
                    withBlock.AddParameter("@ItemPricePerVisit", oContractAlternativeSiteJobItems.ItemPricePerVisit, true);
                    withBlock.AddParameter("@JobOfWorkID", oContractAlternativeSiteJobItems.JobOfWorkID, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}