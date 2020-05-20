using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOriginalSites
    {
        public class QuoteContractOriginalSiteSQL
        {
            private Sys.Database _database;

            public QuoteContractOriginalSiteSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public QuoteContractOriginalSite Get(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteContractOriginalSite_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteContractSite = new QuoteContractOriginalSite();
                        oQuoteContractSite.IgnoreExceptionsOnSetMethods = true;
                        oQuoteContractSite.SetQuoteContractSiteID = dt.Rows[0]["QuoteContractSiteID"];
                        oQuoteContractSite.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oQuoteContractSite.SetSiteID = dt.Rows[0]["SiteID"];
                        oQuoteContractSite.SetPricePerVisit = dt.Rows[0]["PricePerVisit"];
                        oQuoteContractSite.SetVisitFrequencyID = dt.Rows[0]["VisitFrequencyID"];
                        oQuoteContractSite.SetVisitDuration = dt.Rows[0]["VisitDuration"];
                        oQuoteContractSite.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oQuoteContractSite.SetIncludeAssetPrice = dt.Rows[0]["IncludeAssetPrice"];
                        oQuoteContractSite.SetAverageMileage = dt.Rows[0]["AverageMileage"];
                        oQuoteContractSite.SetPricePerMile = dt.Rows[0]["PricePerMile"];
                        oQuoteContractSite.SetIncludeMileagePrice = dt.Rows[0]["IncludeMileagePrice"];
                        oQuoteContractSite.SetIncludeRates = dt.Rows[0]["IncludeRates"];
                        oQuoteContractSite.SetTotalSitePrice = dt.Rows[0]["TotalSitePrice"];
                        oQuoteContractSite.ContractSiteScheduleOfRates = (DataView)GetQuoteContractOriginalSiteScheduleOfRate(oQuoteContractSite.QuoteContractSiteID);
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

            public DataView GetAll_QuoteContractID(int QuoteContractID, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractOriginalSite_GetAll_QuoteContractID");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractSite.ToString();
                return new DataView(dt);
            }

            public object GetQuoteContractOriginalSiteScheduleOfRate(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteContractOriginalSiteScheduleOfRate_Get");
                dt.TableName = Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public QuoteContractOriginalSite Insert(QuoteContractOriginalSite oQuoteContractSite)
            {
                _database.ClearParameter();
                AddQuoteContractSiteParametersToCommand(ref oQuoteContractSite);
                oQuoteContractSite.SetQuoteContractSiteID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOriginalSite_Insert"));
                oQuoteContractSite.Exists = true;
                SaveRates(oQuoteContractSite);
                return oQuoteContractSite;
            }

            public void Update(QuoteContractOriginalSite oQuoteContractSite)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", oQuoteContractSite.QuoteContractSiteID, true);
                AddQuoteContractSiteParametersToCommand(ref oQuoteContractSite);
                _database.ExecuteSP_NO_Return("QuoteContractOriginalSite_Update");
                SaveRates(oQuoteContractSite);
            }

            public void Delete(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                _database.ExecuteSP_NO_Return("QuoteContractOriginalSite_Delete");
            }

            private void AddQuoteContractSiteParametersToCommand(ref QuoteContractOriginalSite oQuoteContractSite)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractID", oQuoteContractSite.QuoteContractID, true);
                    withBlock.AddParameter("@SiteID", oQuoteContractSite.SiteID, true);
                    withBlock.AddParameter("@PricePerVisit", oQuoteContractSite.PricePerVisit, true);
                    withBlock.AddParameter("@VisitFrequencyID", oQuoteContractSite.VisitFrequencyID, true);
                    withBlock.AddParameter("@VisitDuration", oQuoteContractSite.VisitDuration, true);
                    withBlock.AddParameter("@IncludeAssetPrice", oQuoteContractSite.IncludeAssetPrice, true);
                    withBlock.AddParameter("@AverageMileage", oQuoteContractSite.AverageMileage, true);
                    withBlock.AddParameter("@PricePerMile", oQuoteContractSite.PricePerMile, true);
                    withBlock.AddParameter("@IncludeMileagePrice", oQuoteContractSite.IncludeMileagePrice, true);
                    withBlock.AddParameter("@IncludeRates", oQuoteContractSite.IncludeRates, true);
                    withBlock.AddParameter("@TotalSitePrice", oQuoteContractSite.TotalSitePrice, true);
                }
            }

            private void SaveRates(QuoteContractOriginalSite oQuoteContractSite)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", oQuoteContractSite.QuoteContractSiteID, true);
                _database.ExecuteSP_NO_Return("QuoteContractOriginalSiteScheduleOfRate_Delete");
                if (oQuoteContractSite.ContractSiteScheduleOfRates is object)
                {
                    foreach (DataRow r in oQuoteContractSite.ContractSiteScheduleOfRates.Table.Rows)
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@QuoteContractSiteID", oQuoteContractSite.QuoteContractSiteID, true);
                        _database.AddParameter("@ScheduleOfRatesCategoryID", r["ScheduleOfRatesCategoryID"], true);
                        _database.AddParameter("@Code", r["Code"], true);
                        _database.AddParameter("@Description", r["Description"], true);
                        _database.AddParameter("@Price", r["Price"], true);
                        _database.AddParameter("@QtyPerVisit", r["QtyPerVisit"], true);
                        _database.ExecuteSP_NO_Return("QuoteContractOriginalSiteScheduleOfRate_Insert");
                    }
                }
            }
            
        }
    }
}