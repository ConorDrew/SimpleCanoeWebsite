using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOption3Sites
    {
        public class ContractOption3SiteSQL
        {
            private Sys.Database _database;

            public ContractOption3SiteSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public int Delete(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.AddParameter("@DownloadStatus", Conversions.ToInteger(Sys.Enums.VisitStatus.Downloaded), true);
                _database.AddParameter("@ContractOpt3Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option3), true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("ContractOption3Site_Delete"));
            }

            public ContractOption3Site ContractOption3Site_Get(int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractOption3Site_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractOption3Site = new ContractOption3Site();
                        oContractOption3Site.IgnoreExceptionsOnSetMethods = true;
                        oContractOption3Site.SetContractSiteID = dt.Rows[0]["ContractSiteID"];
                        oContractOption3Site.SetContractID = dt.Rows[0]["ContractID"];
                        oContractOption3Site.SetPropertyID = dt.Rows[0]["SiteID"];
                        oContractOption3Site.SetContractSiteReference = dt.Rows[0]["ContractSiteReference"];
                        oContractOption3Site.StartDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["StartDate"]);
                        oContractOption3Site.EndDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["EndDate"]);
                        oContractOption3Site.FirstVisitDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["FirstVisitDate"]);
                        oContractOption3Site.SetVisitFrequencyID = dt.Rows[0]["VisitFrequencyID"];
                        oContractOption3Site.SetInvoiceFrequencyID = dt.Rows[0]["InvoiceFrequencyID"];
                        oContractOption3Site.SetSitePrice = dt.Rows[0]["SitePrice"];
                        oContractOption3Site.FirstInvoiceDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["FirstInvoiceDate"]);
                        oContractOption3Site.SetInvoiceAddressID = dt.Rows[0]["InvoiceAddressID"];
                        oContractOption3Site.SetInvoiceAddressTypeID = dt.Rows[0]["InvoiceAddressTypeID"];
                        oContractOption3Site.Exists = true;
                        return oContractOption3Site;
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

            public DataView ContractOption3Site_GetAll_ForContract(int ContractID, int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID);
                _database.AddParameter("@CustomerID", CustomerID);
                var dt = _database.ExecuteSP_DataTable("ContractOption3Site_GetAll_ForContract");
                dt.TableName = Sys.Enums.TableNames.tblContractOption3Site.ToString();
                return new DataView(dt);
            }

            public ContractOption3Site Insert(ContractOption3Site oContractOption3Site)
            {
                _database.ClearParameter();
                AddContractOption3SiteParametersToCommand(ref oContractOption3Site);
                oContractOption3Site.SetContractSiteID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOption3Site_Insert"));
                oContractOption3Site.Exists = true;
                return oContractOption3Site;
            }

            public void Update(ContractOption3Site oContractOption3Site)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", oContractOption3Site.ContractSiteID, true);
                AddContractOption3SiteParametersToCommand(ref oContractOption3Site);
                _database.ExecuteSP_NO_Return("ContractOption3Site_Update");
            }

            private void AddContractOption3SiteParametersToCommand(ref ContractOption3Site oContractOption3Site)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ContractID", oContractOption3Site.ContractID, true);
                    withBlock.AddParameter("@SiteID", oContractOption3Site.PropertyID, true);
                    withBlock.AddParameter("@ContractSiteReference", oContractOption3Site.ContractSiteReference, true);
                    if (oContractOption3Site.StartDate == Conversions.ToDate("#12:00:00 AM#"))
                    {
                        withBlock.AddParameter("@StartDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@StartDate", oContractOption3Site.StartDate, true);
                    }

                    if (oContractOption3Site.EndDate == Conversions.ToDate("#12:00:00 AM#"))
                    {
                        withBlock.AddParameter("@EndDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@EndDate", oContractOption3Site.EndDate, true);
                    }

                    if (oContractOption3Site.FirstVisitDate == Conversions.ToDate("#12:00:00 AM#"))
                    {
                        withBlock.AddParameter("@FirstVisitDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@FirstVisitDate", oContractOption3Site.FirstVisitDate, true);
                    }

                    withBlock.AddParameter("@VisitFrequencyID", oContractOption3Site.VisitFrequencyID, true);
                    withBlock.AddParameter("@InvoiceFrequencyID", oContractOption3Site.InvoiceFrequencyID, true);
                    withBlock.AddParameter("@SitePrice", oContractOption3Site.SitePrice, true);
                    if (oContractOption3Site.FirstInvoiceDate == Conversions.ToDate("#12:00:00 AM#"))
                    {
                        withBlock.AddParameter("@FirstInvoiceDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@FirstInvoiceDate", oContractOption3Site.FirstInvoiceDate, true);
                    }

                    withBlock.AddParameter("@InvoiceAddressID", oContractOption3Site.InvoiceAddressID, true);
                    withBlock.AddParameter("@InvoiceAddressTypeID", oContractOption3Site.InvoiceAddressTypeID, true);
                }
            }

            public string GetNextSiteReference(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractOption3Site_GetLastSiteReference");
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

                return Conversions.ToString(dt.Rows[0]["ContractReference"] + postFix);
            }

            public int ActiveInactive(int ContractSiteID, bool InactiveFlag)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.AddParameter("@DownloadStatus", Conversions.ToInteger(Sys.Enums.VisitStatus.Downloaded), true);
                _database.AddParameter("@InactiveFlag", InactiveFlag, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("ContractOption3Site_ActiveInactive"));
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}