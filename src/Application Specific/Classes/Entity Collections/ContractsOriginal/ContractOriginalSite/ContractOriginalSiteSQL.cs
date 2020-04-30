using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOriginalSites
    {
        public class ContractOriginalSiteSQL
        {
            private Sys.Database _database;

            public ContractOriginalSiteSQL(Sys.Database database)
            {
                _database = database;
            }

            public ContractOriginalSite Get(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSite_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractSite = new ContractOriginalSite();
                        oContractSite.IgnoreExceptionsOnSetMethods = true;
                        oContractSite.SetContractSiteID = dt.Rows[0]["ContractSiteID"];
                        oContractSite.SetContractID = dt.Rows[0]["ContractID"];
                        oContractSite.SetPropertyID = dt.Rows[0]["SiteID"];
                        oContractSite.SetPricePerVisit = dt.Rows[0]["PricePerVisit"];
                        oContractSite.FirstVisitDate = Conversions.ToDate(dt.Rows[0]["FirstVisitDate"]);
                        oContractSite.SetVisitFrequencyID = dt.Rows[0]["VisitFrequencyID"];
                        oContractSite.SetVisitDuration = dt.Rows[0]["VisitDuration"];
                        oContractSite.SetAverageMileage = dt.Rows[0]["AverageMileage"];
                        oContractSite.SetIncludeAssetPrice = dt.Rows[0]["IncludeAssetPrice"];
                        oContractSite.SetIncludeMileagePrice = dt.Rows[0]["IncludeMileagePrice"];
                        oContractSite.SetPricePerMile = dt.Rows[0]["PricePerMile"];
                        oContractSite.SetTotalSitePrice = dt.Rows[0]["TotalSitePrice"];
                        oContractSite.SetIncludeRates = dt.Rows[0]["IncludeRates"];
                        oContractSite.SetLLCertReqd = dt.Rows[0]["LLCertReqd"];
                        oContractSite.SetAdditionalNotes = dt.Rows[0]["AdditionalNotes"];
                        oContractSite.SetCommercial = Sys.Helper.MakeBooleanValid(dt.Rows[0]["Commercial"]);
                        oContractSite.SetMainAppliances = dt.Rows[0]["MainAppliances"];
                        oContractSite.SetSecondryAppliances = dt.Rows[0]["SecondryAppliances"];
                        oContractSite.ContractSiteScheduleOfRates = App.DB.ContractOriginalSiteRates.ContractOriginalSiteRates_GetForContractSite(oContractSite.ContractSiteID);
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
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSite_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContractSite.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_ContractID(int ContractID, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSite_GetAll_ContractID");
                dt.TableName = Sys.Enums.TableNames.tblContractSite.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_ContractID2(int ContractID, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSite_GetAll_ContractID2");
                dt.TableName = Sys.Enums.TableNames.tblContractSite.ToString();
                return new DataView(dt);
            }

            private object GetContractOriginalSiteScheduleOfRate(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSiteScheduleOfRate_Get");
                dt.TableName = Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public ContractOriginalSite Insert(ContractOriginalSite oContractSite)
            {
                _database.ClearParameter();
                AddContractSiteParametersToCommand(ref oContractSite);
                oContractSite.SetContractSiteID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalSite_Insert"));
                oContractSite.Exists = true;
                // SaveRates(oContractSite)
                return oContractSite;
            }

            public void Update(ContractOriginalSite oContractSite)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", oContractSite.ContractSiteID, true);
                AddContractSiteParametersToCommand(ref oContractSite);
                _database.ExecuteSP_NO_Return("ContractOriginalSite_Update");
                // SaveRates(oContractSite)
            }

            public int Delete(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.AddParameter("@DownloadStatus", Conversions.ToInteger(Sys.Enums.VisitStatus.Downloaded), true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("ContractOriginalSite_Delete"));
            }

            public int ActiveInactive(int ContractSiteID, bool InactiveFlag)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.AddParameter("@DownloadStatus", Conversions.ToInteger(Sys.Enums.VisitStatus.Scheduled), true);
                _database.AddParameter("@InactiveFlag", InactiveFlag, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("ContractOriginalSite_ActiveInactive"));
            }

            public void Delete_Visits(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.ExecuteSP_OBJECT("ContractOriginalSite_Visits_Delete");
            }

            private void AddContractSiteParametersToCommand(ref ContractOriginalSite oContractSite)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractID", oContractSite.ContractID, true);
                    withBlock.AddParameter("@SiteID", oContractSite.PropertyID, true);
                    withBlock.AddParameter("@PricePerVisit", oContractSite.PricePerVisit, true);
                    withBlock.AddParameter("@FirstVisitDate", oContractSite.FirstVisitDate, true);
                    withBlock.AddParameter("@VisitFrequencyID", oContractSite.VisitFrequencyID, true);
                    withBlock.AddParameter("@VisitDuration", oContractSite.VisitDuration, true);
                    withBlock.AddParameter("@AverageMileage", oContractSite.AverageMileage, true);
                    withBlock.AddParameter("@IncludeAssetPrice", oContractSite.IncludeAssetPrice, true);
                    withBlock.AddParameter("@IncludeMileagePrice", oContractSite.IncludeMileagePrice, true);
                    withBlock.AddParameter("@PricePerMile", oContractSite.PricePerMile, true);
                    withBlock.AddParameter("@TotalSitePrice", oContractSite.TotalSitePrice, true);
                    withBlock.AddParameter("@IncludeRates", oContractSite.IncludeRates, true);
                    withBlock.AddParameter("@LLCertReqd", oContractSite.LLCertReqd, true);
                    withBlock.AddParameter("@AdditionalNotes", oContractSite.AdditionalNotes, true);
                    withBlock.AddParameter("@Commercial", oContractSite.Commercial, true);
                    withBlock.AddParameter("@MainAppliances", oContractSite.MainAppliances, true);
                    withBlock.AddParameter("@SecondryAppliances", oContractSite.SecondryAppliances, true);
                }
            }
        }
    }
}