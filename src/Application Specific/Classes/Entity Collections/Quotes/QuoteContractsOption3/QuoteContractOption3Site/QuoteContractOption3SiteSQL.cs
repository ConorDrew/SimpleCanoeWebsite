using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOption3Sites
    {
        public class QuoteContractOption3SiteSQL
        {
            private Sys.Database _database;

            public QuoteContractOption3SiteSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public int Delete(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("QuoteContractOption3Site_Delete"));
            }

            public QuoteContractOption3Site QuoteContractOption3Site_Get(int QuoteContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteContractOption3Site_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteContractOption3Site = new QuoteContractOption3Site();
                        oQuoteContractOption3Site.IgnoreExceptionsOnSetMethods = true;
                        oQuoteContractOption3Site.SetQuoteContractSiteID = dt.Rows[0]["QuoteContractSiteID"];
                        oQuoteContractOption3Site.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oQuoteContractOption3Site.SetSiteID = dt.Rows[0]["SiteID"];
                        oQuoteContractOption3Site.SetQuoteContractSiteReference = dt.Rows[0]["QuoteContractSiteReference"];
                        oQuoteContractOption3Site.StartDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["StartDate"]);
                        oQuoteContractOption3Site.EndDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["EndDate"]);
                        oQuoteContractOption3Site.FirstVisitDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["FirstVisitDate"]);
                        oQuoteContractOption3Site.SetVisitFrequencyID = dt.Rows[0]["VisitFrequencyID"];
                        oQuoteContractOption3Site.SetSitePrice = dt.Rows[0]["SitePrice"];
                        oQuoteContractOption3Site.Exists = true;
                        return oQuoteContractOption3Site;
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

            public DataView QuoteContractOption3Site_GetAll_ForQuoteContract(int QuoteContractID, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID);
                _database.AddParameter("@CustomerID", CustomerID);
                var dt = _database.ExecuteSP_DataTable("QuoteContractOption3Site_GetAll_ForQuoteContract");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString();
                return new DataView(dt);
            }

            public DataView QuoteContractOption3Site_GetSelected_ForQuoteContract(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID);
                var dt = _database.ExecuteSP_DataTable("QuoteContractOption3Site_GetSelected_ForQuoteContract");
                dt.TableName = Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString();
                return new DataView(dt);
            }

            public QuoteContractOption3Site Insert(QuoteContractOption3Site oQuoteContractOption3Site)
            {
                _database.ClearParameter();
                AddContractOption3SiteParametersToCommand(ref oQuoteContractOption3Site);
                oQuoteContractOption3Site.SetQuoteContractSiteID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOption3Site_Insert"));
                oQuoteContractOption3Site.Exists = true;
                return oQuoteContractOption3Site;
            }

            public void Update(QuoteContractOption3Site oQuoteContractOption3Site)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractSiteID", oQuoteContractOption3Site.QuoteContractSiteID, true);
                AddContractOption3SiteParametersToCommand(ref oQuoteContractOption3Site);
                _database.ExecuteSP_NO_Return("QuoteContractOption3Site_Update");
            }

            private void AddContractOption3SiteParametersToCommand(ref QuoteContractOption3Site oQuoteContractOption3Site)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteContractID", oQuoteContractOption3Site.QuoteContractID, true);
                    withBlock.AddParameter("@SiteID", oQuoteContractOption3Site.SiteID, true);
                    withBlock.AddParameter("@QuoteContractSiteReference", oQuoteContractOption3Site.QuoteContractSiteReference, true);
                    if (oQuoteContractOption3Site.StartDate == Conversions.ToDate("#12:00:00 AM#"))
                    {
                        withBlock.AddParameter("@StartDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@StartDate", oQuoteContractOption3Site.StartDate, true);
                    }

                    if (oQuoteContractOption3Site.EndDate == Conversions.ToDate("#12:00:00 AM#"))
                    {
                        withBlock.AddParameter("@EndDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@EndDate", oQuoteContractOption3Site.EndDate, true);
                    }

                    if (oQuoteContractOption3Site.FirstVisitDate == Conversions.ToDate("#12:00:00 AM#"))
                    {
                        withBlock.AddParameter("@FirstVisitDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@FirstVisitDate", oQuoteContractOption3Site.FirstVisitDate, true);
                    }

                    withBlock.AddParameter("@VisitFrequencyID", oQuoteContractOption3Site.VisitFrequencyID, true);
                    withBlock.AddParameter("@SitePrice", oQuoteContractOption3Site.SitePrice, true);
                }
            }

            public string GetNextSiteReference(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteContractOption3Site_GetLastSiteReference");
                string lastLetter = "";
                string nxtLetter = "";
                string postFix = "";
                if (Information.IsDBNull(dt.Rows[0]["SiteLetter"]))
                {
                    postFix = "-A";
                }
                else
                {
                    lastLetter = Strings.Right(Conversions.ToString(dt.Rows[0]["SiteLetter"]), 1);
                    if ((lastLetter ?? "") == "Z")
                    {
                        nxtLetter = "AA";
                    }
                    else
                    {
                        nxtLetter = Conversions.ToString((char)(Strings.Asc(lastLetter) + 1));
                    }

                    postFix = "-" + Strings.Replace(Strings.Left(Conversions.ToString(dt.Rows[0]["SiteLetter"]), Strings.Len(dt.Rows[0]["SiteLetter"]) - 1), "Z", "A") + nxtLetter;

                }

                return Conversions.ToString(dt.Rows[0]["QuoteContractReference"] + postFix);
            }

            // Public Function ActiveInactive(ByVal QuoteContractSiteID As Integer, ByVal InactiveFlag As Boolean) As Integer
            // _database.ClearParameter()
            // _database.AddParameter("@ContractSiteID", ContractSiteID, True)
            // _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
            // _database.AddParameter("@InactiveFlag", InactiveFlag, True)
            // Return _database.ExecuteSP_OBJECT("ContractOption3Site_ActiveInactive")
            // End Function

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}