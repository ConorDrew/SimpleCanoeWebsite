using System.Collections;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSiteJobOfWorks
    {
        public class QuoteContractAlternativeSiteJobOfWorkSQL
        {
            private Sys.Database _database;

            public QuoteContractAlternativeSiteJobOfWorkSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int QuoteContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, true);
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobOfWork_Delete");
            }

            public QuoteContractAlternativeSiteJobOfWork ContractAlternativeSiteJobOfWork_Get(int QuoteContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobOfWork_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteContractAlternativeSiteJobOfWork = new QuoteContractAlternativeSiteJobOfWork();
                        oQuoteContractAlternativeSiteJobOfWork.IgnoreExceptionsOnSetMethods = true;
                        oQuoteContractAlternativeSiteJobOfWork.SetQuoteContractSiteJobOfWorkID = dt.Rows[0]["QuoteContractSiteJobOfWorkID"];
                        oQuoteContractAlternativeSiteJobOfWork.SetQuoteContractSiteID = dt.Rows[0]["QuoteContractSiteID"];
                        oQuoteContractAlternativeSiteJobOfWork.FirstVisitDate = Conversions.ToDate(dt.Rows[0]["FirstVisitDate"]);
                        oQuoteContractAlternativeSiteJobOfWork.SetAverageMileage = dt.Rows[0]["AverageMileage"];
                        oQuoteContractAlternativeSiteJobOfWork.SetIncludeMileagePrice = dt.Rows[0]["IncludeMileagePrice"];
                        oQuoteContractAlternativeSiteJobOfWork.SetIncludeRates = dt.Rows[0]["IncludeRates"];
                        oQuoteContractAlternativeSiteJobOfWork.SetPricePerMile = dt.Rows[0]["PricePerMile"];
                        oQuoteContractAlternativeSiteJobOfWork.SetPricePerVisit = dt.Rows[0]["PricePerVisit"];
                        oQuoteContractAlternativeSiteJobOfWork.SetTotalSitePrice = dt.Rows[0]["TotalSitePrice"];
                        oQuoteContractAlternativeSiteJobOfWork.Exists = true;
                        return oQuoteContractAlternativeSiteJobOfWork;
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

            public ArrayList Get_For_QuoteContractSite_As_Objects(int QuoteContractSiteID)
            {
                var jobOfWorks = new ArrayList();
                foreach (DataRow row in JobOfWork_Get_For_QuoteContract(QuoteContractSiteID).Table.Rows)
                {
                    var jobOfWork = new QuoteContractAlternativeSiteJobOfWork();
                    jobOfWork.IgnoreExceptionsOnSetMethods = true;
                    jobOfWork.Exists = true;
                    jobOfWork.SetQuoteContractSiteID = row["QuoteContractSiteID"];
                    jobOfWork.SetQuoteContractSiteJobOfWorkID = row["QuoteContractSiteJobOfWorkID"];
                    jobOfWork.FirstVisitDate = Conversions.ToDate(row["FirstVisitDate"]);
                    jobOfWork.SetAverageMileage = row["AverageMileage"];
                    jobOfWork.SetIncludeMileagePrice = row["IncludeMileagePrice"];
                    jobOfWork.SetIncludeRates = row["IncludeRates"];
                    jobOfWork.SetPricePerMile = row["PricePerMile"];
                    jobOfWork.SetPricePerVisit = row["PricePerVisit"];
                    jobOfWork.SetTotalSitePrice = row["TotalSitePrice"];
                    // 'THIS IS A STUPID WORK AROUND ONLY USED IN THE CONVERTION -AMY
                    jobOfWork.ScheduledOfRates_UsedForConvertOnly = GetJobOfWorkScheduleOfRates(jobOfWork.QuoteContractSiteJobOfWorkID);
                    // '''--------------------------

                    jobOfWorks.Add(jobOfWork);
                }

                return jobOfWorks;
            }

            public DataView JobOfWork_Get_For_QuoteContract(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobOfWork_Get_For_QuoteContractSiteID");
                dt.TableName = Sys.Enums.TableNames.tblJobOfWork.ToString();
                return new DataView(dt);
            }

            public DataView QuoteContractAlternativeSiteJobOfWork_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobOfWork_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContractAlternativeSiteJobOfWork.ToString();
                return new DataView(dt);
            }

            public QuoteContractAlternativeSiteJobOfWork Insert(QuoteContractAlternativeSiteJobOfWork oQuoteContractAlternativeSiteJobOfWork)
            {
                _database.ClearParameter();
                AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(ref oQuoteContractAlternativeSiteJobOfWork);
                oQuoteContractAlternativeSiteJobOfWork.SetQuoteContractSiteJobOfWorkID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteJobOfWork_Insert"));
                oQuoteContractAlternativeSiteJobOfWork.Exists = true;
                return oQuoteContractAlternativeSiteJobOfWork;
            }

            public void Update(QuoteContractAlternativeSiteJobOfWork oQuoteContractAlternativeSiteJobOfWork, DataView oRates)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteJobOfWorkID, true);
                AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(ref oQuoteContractAlternativeSiteJobOfWork);
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobOfWork_Update");
                SaveRates(oRates, oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteJobOfWorkID);
            }

            private void AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(ref QuoteContractAlternativeSiteJobOfWork oQuoteContractAlternativeSiteJobOfWork)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractSiteID", oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteID, true);
                    withBlock.AddParameter("@FirstVisitDate", oQuoteContractAlternativeSiteJobOfWork.FirstVisitDate, true);
                    withBlock.AddParameter("@PricePerVisit", oQuoteContractAlternativeSiteJobOfWork.PricePerVisit, true);
                    withBlock.AddParameter("@AverageMileage", oQuoteContractAlternativeSiteJobOfWork.AverageMileage, true);
                    withBlock.AddParameter("@IncludeMileagePrice", oQuoteContractAlternativeSiteJobOfWork.IncludeMileagePrice, true);
                    withBlock.AddParameter("@IncludeRates", oQuoteContractAlternativeSiteJobOfWork.IncludeRates, true);
                    withBlock.AddParameter("@PricePerMile", oQuoteContractAlternativeSiteJobOfWork.PricePerMile, true);
                    withBlock.AddParameter("@TotalSitePrice", oQuoteContractAlternativeSiteJobOfWork.TotalSitePrice, true);
                }
            }

            public DataView GetJobOfWorkScheduleOfRates(int QuoteContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeJobOfWorkScheduleOfRate_Get");
                dt.TableName = Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
                return new DataView(dt);
            }

            private void SaveRates(DataView oRates, int QuoteContractSiteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, true);
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeJobOfWorkScheduleOfRate_Delete");
                foreach (DataRow r in oRates.Table.Rows)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, true);
                    _database.AddParameter("@ScheduleOfRatesCategoryID", r["ScheduleOfRatesCategoryID"], true);
                    _database.AddParameter("@Code", r["Code"], true);
                    _database.AddParameter("@Description", r["Description"], true);
                    _database.AddParameter("@Price", r["Price"], true);
                    _database.AddParameter("@QtyPerVisit", r["QtyPerVisit"], true);
                    _database.ExecuteSP_NO_Return("QuoteContractAlternativeJobOfWorkScheduleOfRate_Insert");
                }
            }

            public DataView JobOfWorks_For_QuoteContractID(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractAlternativeJobOfWorks_For_QuoteContractID");
                dt.TableName = Sys.Enums.TableNames.NO_TABLE.ToString();
                return new DataView(dt);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}