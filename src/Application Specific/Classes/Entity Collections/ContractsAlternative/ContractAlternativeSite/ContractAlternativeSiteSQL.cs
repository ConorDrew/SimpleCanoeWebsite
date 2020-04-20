using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractAlternativeSites
    {
        public class ContractAlternativeSiteSQL
        {
            private Sys.Database _database;

            public ContractAlternativeSiteSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public ContractAlternativeSite Get(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSite_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractSite = new ContractAlternativeSite();
                        oContractSite.IgnoreExceptionsOnSetMethods = true;
                        oContractSite.SetContractSiteID = dt.Rows[0]["ContractSiteID"];
                        oContractSite.SetContractID = dt.Rows[0]["ContractID"];
                        oContractSite.SetPropertyID = dt.Rows[0]["SiteID"];
                        oContractSite.JobOfWorks = _database.ContractAlternativeSiteJobOfWork.Get_For_ContractSite_As_Objects(ContractSiteID);
                        oContractSite.Exists = true;
                        return oContractSite;
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
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSite_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContractSite.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_ContractID(int ContractID, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSite_GetAll_ContractID");
                dt.TableName = Sys.Enums.TableNames.tblContractSite.ToString();
                return new DataView(dt);
            }

            public ContractAlternativeSite Insert(ContractAlternativeSite oContractSite)
            {
                _database.ClearParameter();
                AddContractSiteParametersToCommand(ref oContractSite);
                oContractSite.SetContractSiteID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativeSite_Insert"));
                oContractSite.Exists = true;
                return oContractSite;
            }

            public void Update(ContractAlternativeSite oContractSite)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", oContractSite.ContractSiteID, true);
                AddContractSiteParametersToCommand(ref oContractSite);
                _database.ExecuteSP_NO_Return("ContractAlternativeSite_Update");
            }

            public int Delete(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.AddParameter("@DownloadStatus", Conversions.ToInteger(Sys.Enums.VisitStatus.Downloaded), true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("ContractAlternativeSite_Delete"));
            }

            public int ActiveInactive(int ContractSiteID, bool InactiveFlag)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.AddParameter("@DownloadStatus", Conversions.ToInteger(Sys.Enums.VisitStatus.Downloaded), true);
                _database.AddParameter("@InactiveFlag", InactiveFlag, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("ContractAlternativeSite_ActiveInactive"));
            }

            private void AddContractSiteParametersToCommand(ref ContractAlternativeSite oContractSite)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractID", oContractSite.ContractID, true);
                    withBlock.AddParameter("@SiteID", oContractSite.PropertyID, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}