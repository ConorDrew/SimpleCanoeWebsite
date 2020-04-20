using System.Collections;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteJobOfWorks
    {
        public class ContractAlternativeSiteJobOfWorkSQL
        {
            private Sys.Database _database;

            public ContractAlternativeSiteJobOfWorkSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int ContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, true);
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteJobOfWork_Delete");
            }

            public ContractAlternativeSiteJobOfWork ContractAlternativeSiteJobOfWork_Get(int ContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobOfWork_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractAlternativeSiteJobOfWork = new ContractAlternativeSiteJobOfWork();
                        oContractAlternativeSiteJobOfWork.IgnoreExceptionsOnSetMethods = true;
                        oContractAlternativeSiteJobOfWork.SetContractSiteJobOfWorkID = dt.Rows[0]["ContractSiteJobOfWorkID"];
                        oContractAlternativeSiteJobOfWork.SetContractSiteID = dt.Rows[0]["ContractSiteID"];
                        oContractAlternativeSiteJobOfWork.FirstVisitDate = Conversions.ToDate(dt.Rows[0]["FirstVisitDate"]);
                        oContractAlternativeSiteJobOfWork.SetAverageMileage = dt.Rows[0]["AverageMileage"];
                        oContractAlternativeSiteJobOfWork.SetIncludeMileagePrice = dt.Rows[0]["IncludeMileagePrice"];
                        oContractAlternativeSiteJobOfWork.SetIncludeRates = dt.Rows[0]["IncludeRates"];
                        oContractAlternativeSiteJobOfWork.SetPricePerMile = dt.Rows[0]["PricePerMile"];
                        oContractAlternativeSiteJobOfWork.SetPricePerVisit = dt.Rows[0]["PricePerVisit"];
                        oContractAlternativeSiteJobOfWork.SetTotalSitePrice = dt.Rows[0]["TotalSitePrice"];
                        oContractAlternativeSiteJobOfWork.Exists = true;
                        return oContractAlternativeSiteJobOfWork;
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

            public ArrayList Get_For_ContractSite_As_Objects(int ContractSiteID)
            {
                var jobOfWorks = new ArrayList();
                foreach (DataRow row in JobOfWork_Get_For_Contract(ContractSiteID).Table.Rows)
                {
                    var jobOfWork = new ContractAlternativeSiteJobOfWork();
                    jobOfWork.IgnoreExceptionsOnSetMethods = true;
                    jobOfWork.Exists = true;
                    jobOfWork.SetContractSiteID = row["ContractSiteID"];
                    jobOfWork.SetContractSiteJobOfWorkID = row["ContractSiteJobOfWorkID"];
                    jobOfWork.FirstVisitDate = Conversions.ToDate(row["FirstVisitDate"]);
                    jobOfWork.SetAverageMileage = row["AverageMileage"];
                    jobOfWork.SetIncludeMileagePrice = row["IncludeMileagePrice"];
                    jobOfWork.SetIncludeRates = row["IncludeRates"];
                    jobOfWork.SetPricePerMile = row["PricePerMile"];
                    jobOfWork.SetPricePerVisit = row["PricePerVisit"];
                    jobOfWork.SetTotalSitePrice = row["TotalSitePrice"];
                    jobOfWorks.Add(jobOfWork);
                }

                return jobOfWorks;
            }

            public DataView JobOfWork_Get_For_Contract(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobOfWork_Get_For_ContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblJobOfWork.ToString();
                return new DataView(dt);
            }

            public DataView ContractAlternativeSiteJobOfWork_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobOfWork_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContractAlternativeSiteJobOfWork.ToString();
                return new DataView(dt);
            }

            public ContractAlternativeSiteJobOfWork Insert(ContractAlternativeSiteJobOfWork oContractAlternativeSiteJobOfWork)
            {
                _database.ClearParameter();
                AddContractAlternativeSiteJobOfWorkParametersToCommand(ref oContractAlternativeSiteJobOfWork);
                oContractAlternativeSiteJobOfWork.SetContractSiteJobOfWorkID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativeSiteJobOfWork_Insert"));
                oContractAlternativeSiteJobOfWork.Exists = true;
                return oContractAlternativeSiteJobOfWork;
            }

            public void Update(ContractAlternativeSiteJobOfWork oContractAlternativeSiteJobOfWork, DataView oRates)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobOfWorkID", oContractAlternativeSiteJobOfWork.ContractSiteJobOfWorkID, true);
                AddContractAlternativeSiteJobOfWorkParametersToCommand(ref oContractAlternativeSiteJobOfWork);
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteJobOfWork_Update");
                SaveRates(oRates, oContractAlternativeSiteJobOfWork.ContractSiteJobOfWorkID);
            }

            private void AddContractAlternativeSiteJobOfWorkParametersToCommand(ref ContractAlternativeSiteJobOfWork oContractAlternativeSiteJobOfWork)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractSiteID", oContractAlternativeSiteJobOfWork.ContractSiteID, true);
                    withBlock.AddParameter("@FirstVisitDate", oContractAlternativeSiteJobOfWork.FirstVisitDate, true);
                    withBlock.AddParameter("@PricePerVisit", oContractAlternativeSiteJobOfWork.PricePerVisit, true);
                    withBlock.AddParameter("@AverageMileage", oContractAlternativeSiteJobOfWork.AverageMileage, true);
                    withBlock.AddParameter("@IncludeMileagePrice", oContractAlternativeSiteJobOfWork.IncludeMileagePrice, true);
                    withBlock.AddParameter("@IncludeRates", oContractAlternativeSiteJobOfWork.IncludeRates, true);
                    withBlock.AddParameter("@PricePerMile", oContractAlternativeSiteJobOfWork.PricePerMile, true);
                    withBlock.AddParameter("@TotalSitePrice", oContractAlternativeSiteJobOfWork.TotalSitePrice, true);
                }
            }

            public DataView GetJobOfWorkScheduleOfRates(int ContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("ContractAlternativeJobOfWorkScheduleOfRate_Get");
                dt.TableName = Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public void SaveRates(DataView oRates, int ContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, true);
                _database.ExecuteSP_NO_Return("ContractAlternativeJobOfWorkScheduleOfRate_Delete");
                foreach (DataRow r in oRates.Table.Rows)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, true);
                    _database.AddParameter("@ScheduleOfRatesCategoryID", r["ScheduleOfRatesCategoryID"], true);
                    _database.AddParameter("@Code", r["Code"], true);
                    _database.AddParameter("@Description", r["Description"], true);
                    _database.AddParameter("@Price", r["Price"], true);
                    _database.AddParameter("@QtyPerVisit", r["QtyPerVisit"], true);
                    _database.ExecuteSP_NO_Return("ContractAlternativeJobOfWorkScheduleOfRate_Insert");
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}