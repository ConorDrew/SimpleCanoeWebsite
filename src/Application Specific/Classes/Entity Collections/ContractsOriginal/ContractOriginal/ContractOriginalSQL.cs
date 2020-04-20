using System;
using System.Data;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractsOriginal
    {
        public class ContractOriginalSQL
        {
            private Database _database;

            public ContractOriginalSQL(Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public ContractOriginal Get(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractOriginal_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContract = new ContractOriginal();
                        oContract.IgnoreExceptionsOnSetMethods = true;
                        oContract.SetContractID = dt.Rows[0]["ContractID"];
                        oContract.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oContract.SetContractReference = dt.Rows[0]["ContractReference"];
                        oContract.ContractStartDate = Conversions.ToDate(dt.Rows[0]["ContractStartDate"]);
                        oContract.ContractEndDate = Conversions.ToDate(dt.Rows[0]["ContractEndDate"]);
                        oContract.SetContractStatusID = dt.Rows[0]["ContractStatusID"];
                        oContract.SetContractPrice = dt.Rows[0]["ContractPrice"];
                        oContract.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oContract.SetInvoiceFrequencyID = dt.Rows[0]["InvoiceFrequencyID"];
                        oContract.SetInvoiceAddressID = dt.Rows[0]["InvoiceAddressID"];
                        oContract.SetInvoiceAddressTypeID = dt.Rows[0]["InvoiceAddressTypeID"];
                        oContract.FirstInvoiceDate = Conversions.ToDate(dt.Rows[0]["FirstInvoiceDate"]);
                        oContract.SetContractTypeID = dt.Rows[0]["ContractTypeID"];
                        oContract.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oContract.SetCheque = Helper.MakeBooleanValid(dt.Rows[0]["Cheque"]);
                        oContract.SetCreditCard = Helper.MakeBooleanValid(dt.Rows[0]["CreditCard"]);
                        oContract.SetDirectDebit = Helper.MakeBooleanValid(dt.Rows[0]["DirectDebit"]);
                        oContract.SetBankName = Helper.MakeStringValid(dt.Rows[0]["BankName"]);
                        oContract.SetAccountNumber = Helper.MakeStringValid(dt.Rows[0]["AccountNumber"]);
                        oContract.SetSortCode = Helper.MakeStringValid(dt.Rows[0]["SortCode"]);
                        oContract.SetGasSupplyPipework = Helper.MakeBooleanValid(dt.Rows[0]["GasSupplyPipework"]);
                        if (Information.IsDBNull(dt.Rows[0]["CancelledDate"]))
                        {
                            oContract.CancelledDate = DateTime.MinValue;
                        }
                        else
                        {
                            oContract.CancelledDate = Helper.MakeDateTimeValid(dt.Rows[0]["CancelledDate"]);
                        }

                        oContract.SetReasonID = Helper.MakeIntegerValid(dt.Rows[0]["ReasonID"]);
                        oContract.SetPlumbingDrainage = Helper.MakeBooleanValid(dt.Rows[0]["PlumbingDrainage"]);
                        oContract.SetWindowLockPest = Helper.MakeBooleanValid(dt.Rows[0]["WindowLockPest"]);
                        oContract.SetPoNumber = Helper.MakeStringValid(dt.Rows[0]["PONumber"]);
                        oContract.SetAnnual = Helper.MakeBooleanValid(dt.Rows[0]["Annual"]);
                        oContract.SetDiscountID = dt.Rows[0]["DiscountID"];
                        oContract.SetDoNotRenew = dt.Rows[0]["DoNotRenew"];
                        oContract.SetDDMSRef = dt.Rows[0]["DDMSRef"];
                        oContract.SetNotes = dt.Rows[0]["Notes"];
                        oContract.Exists = true;
                        return oContract;
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

            public double ContractCalculatedTotal(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                return Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("ContractOriginalCalculatedTotal"));
            }

            public DataView Contract_GetAll_Renewal()
            {
                var dt = _database.ExecuteSP_DataTable("Contract_GetAll_Renewal");
                dt.TableName = Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView Contract_Get_Renewal(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                var dt = _database.ExecuteSP_DataTable("Contract_Get_Renewal");
                dt.TableName = Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public ContractOriginal Get_For_Quote_ID(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginal_Get_For_Quote_ID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContract = new ContractOriginal();
                        oContract.IgnoreExceptionsOnSetMethods = true;
                        oContract.SetContractID = dt.Rows[0]["ContractID"];
                        oContract.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oContract.SetContractReference = dt.Rows[0]["ContractReference"];
                        oContract.ContractStartDate = Conversions.ToDate(dt.Rows[0]["ContractStartDate"]);
                        oContract.ContractEndDate = Conversions.ToDate(dt.Rows[0]["ContractEndDate"]);
                        oContract.SetContractStatusID = dt.Rows[0]["ContractStatusID"];
                        oContract.SetContractPrice = dt.Rows[0]["ContractPrice"];
                        oContract.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oContract.SetInvoiceFrequencyID = dt.Rows[0]["InvoiceFrequencyID"];
                        oContract.FirstInvoiceDate = Conversions.ToDate(dt.Rows[0]["FirstInvoiceDate"]);
                        oContract.SetInvoiceAddressID = dt.Rows[0]["InvoiceAddressID"];
                        oContract.SetInvoiceAddressTypeID = dt.Rows[0]["InvoiceAddressTypeID"];
                        oContract.SetContractTypeID = dt.Rows[0]["ContractTypeID"];
                        oContract.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oContract.SetCheque = Helper.MakeBooleanValid(dt.Rows[0]["Cheque"]);
                        oContract.SetCreditCard = Helper.MakeBooleanValid(dt.Rows[0]["CreditCard"]);
                        oContract.SetDirectDebit = Helper.MakeBooleanValid(dt.Rows[0]["DirectDebit"]);
                        oContract.SetBankName = Helper.MakeStringValid(dt.Rows[0]["BankName"]);
                        oContract.SetAccountNumber = Helper.MakeStringValid(dt.Rows[0]["AccountNumber"]);
                        oContract.SetSortCode = Helper.MakeStringValid(dt.Rows[0]["SortCode"]);
                        oContract.SetGasSupplyPipework = Helper.MakeBooleanValid(dt.Rows[0]["GasSupplyPipework"]);
                        oContract.SetPlumbingDrainage = Helper.MakeBooleanValid(dt.Rows[0]["PlumbingDrainage"]);
                        oContract.SetWindowLockPest = Helper.MakeBooleanValid(dt.Rows[0]["WindowLockPest"]);
                        oContract.SetPoNumber = Helper.MakeStringValid(dt.Rows[0]["PONumber"]);
                        oContract.SetDiscountID = dt.Rows[0]["DiscountID"];
                        oContract.SetDoNotRenew = dt.Rows[0]["DoNotRenew"];
                        oContract.SetDDMSRef = dt.Rows[0]["DDMSRef"];
                        oContract.SetNotes = dt.Rows[0]["Notes"];
                        oContract.Exists = true;
                        return oContract;
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

            public ContractOriginal Insert(ContractOriginal oContract)
            {
                _database.ClearParameter();
                AddContractParametersToCommand(ref oContract);
                oContract.SetContractID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginal_Insert"));
                oContract.Exists = true;
                return oContract;
            }

            public void Insert_UpgradedFrom(int contractId, string upgradedFrom)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", contractId, true);
                _database.AddParameter("@UpgradedFrom", upgradedFrom, true);
                _database.ExecuteSP_NO_Return("ContractOriginal_Insert_UpgradedFrom");
            }

            public void Update(ContractOriginal oContract)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", oContract.ContractID, true);
                if (oContract.CancelledDate == DateTime.MinValue)
                {
                    _database.AddParameter("@CancelledDate", DBNull.Value, true);
                }
                else
                {
                    _database.AddParameter("@CancelledDate", oContract.CancelledDate, true);
                }

                _database.AddParameter("@ReasonID", oContract.ReasonID, true);
                AddContractParametersToCommand(ref oContract);
                _database.ExecuteSP_NO_Return("ContractOriginal_Update");
            }

            public void Delete(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                _database.AddParameter("@ContractOpt1Enum", Conversions.ToInteger(Enums.InvoiceType.Contract_Option1), true);
                _database.ExecuteSP_NO_Return("ContractOriginal_Delete");
            }

            public object Transfer(int ContractID, int ContractSiteID, DateTime EffDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                _database.AddParameter("@EffDate", EffDate, true);
                return _database.ExecuteSP_OBJECT("ContractOriginal_Transfer");
            }

            private void AddContractParametersToCommand(ref ContractOriginal oContract)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CustomerID", oContract.CustomerID, true);
                    withBlock.AddParameter("@ContractReference", oContract.ContractReference, true);
                    withBlock.AddParameter("@ContractStartDate", oContract.ContractStartDate, true);
                    withBlock.AddParameter("@ContractEndDate", oContract.ContractEndDate, true);
                    withBlock.AddParameter("@ContractStatusID", oContract.ContractStatusID, true);
                    withBlock.AddParameter("@ContractPrice", oContract.ContractPrice, true);
                    withBlock.AddParameter("@QuoteContractID", oContract.QuoteContractID, true);
                    withBlock.AddParameter("@InvoiceFrequencyID", oContract.InvoiceFrequencyID, true);
                    withBlock.AddParameter("@FirstInvoiceDate", oContract.FirstInvoiceDate, true);
                    withBlock.AddParameter("@InvoiceAddressID", oContract.InvoiceAddressID, true);
                    withBlock.AddParameter("@InvoiceAddressTypeID", oContract.InvoiceAddressTypeID, true);
                    withBlock.AddParameter("@ContractTypeID", oContract.ContractTypeID, true);
                    withBlock.AddParameter("@Cheque", oContract.Cheque, true);
                    withBlock.AddParameter("@CreditCard", oContract.CreditCard, true);
                    withBlock.AddParameter("@DirectDebit", oContract.DirectDebit, true);
                    withBlock.AddParameter("@BankName", oContract.BankName, true);
                    withBlock.AddParameter("@AccountNumber", oContract.AccountNumber, true);
                    withBlock.AddParameter("@SortCode", oContract.SortCode, true);
                    withBlock.AddParameter("@GasSupplyPipework", oContract.GasSupplyPipework, true);
                    withBlock.AddParameter("@PlumbingDrainage", oContract.PlumbingDrainage, true);
                    withBlock.AddParameter("@WindowLockPest", oContract.WindowLockPest, true);
                    withBlock.AddParameter("@PONumber", oContract.PoNumber, true);
                    withBlock.AddParameter("@Annual", oContract.Annual, true);
                    withBlock.AddParameter("@AfterVAT", oContract.ContractPriceAfterVAT, true);
                    withBlock.AddParameter("@DiscountID", oContract.DiscountID, true);
                    withBlock.AddParameter("@DoNotRenew", oContract.DoNotRenew, true);
                    withBlock.AddParameter("@DDMSRef", oContract.DDMSRef, true);
                    withBlock.AddParameter("@PreviousInvoiceFrequencyID", oContract.PreviousInvoiceFrequencyID, true);
                    withBlock.AddParameter("@Notes", oContract.Notes, true);
                }
            }

            public ContractOriginal Get_Current_ForSite(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractOriginal_Get_Current_ForSite");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContract = new ContractOriginal();
                        oContract.IgnoreExceptionsOnSetMethods = true;
                        oContract.SetContractID = dt.Rows[0]["ContractID"];
                        oContract.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oContract.SetContractReference = dt.Rows[0]["ContractReference"];
                        oContract.ContractStartDate = Conversions.ToDate(dt.Rows[0]["ContractStartDate"]);
                        oContract.ContractEndDate = Conversions.ToDate(dt.Rows[0]["ContractEndDate"]);
                        oContract.SetContractStatusID = dt.Rows[0]["ContractStatusID"];
                        oContract.SetContractPrice = dt.Rows[0]["ContractPrice"];
                        oContract.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oContract.SetInvoiceFrequencyID = dt.Rows[0]["InvoiceFrequencyID"];
                        oContract.SetInvoiceAddressID = dt.Rows[0]["InvoiceAddressID"];
                        oContract.SetInvoiceAddressTypeID = dt.Rows[0]["InvoiceAddressTypeID"];
                        oContract.FirstInvoiceDate = Conversions.ToDate(dt.Rows[0]["FirstInvoiceDate"]);
                        oContract.SetContractTypeID = dt.Rows[0]["ContractTypeID"];
                        oContract.SetContractType = dt.Rows[0]["Type"];
                        oContract.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oContract.SetGasSupplyPipework = Helper.MakeBooleanValid(dt.Rows[0]["GasSupplyPipework"]);
                        oContract.SetPlumbingDrainage = Helper.MakeBooleanValid(dt.Rows[0]["PlumbingDrainage"]);
                        oContract.SetWindowLockPest = Helper.MakeBooleanValid(dt.Rows[0]["WindowLockPest"]);
                        oContract.SetPoNumber = Helper.MakeStringValid(dt.Rows[0]["PONumber"]);
                        oContract.SetDiscountID = dt.Rows[0]["DiscountID"];
                        oContract.SetDoNotRenew = dt.Rows[0]["DoNotRenew"];
                        oContract.SetDDMSRef = dt.Rows[0]["DDMSRef"];
                        oContract.SetNotes = dt.Rows[0]["Notes"];
                        oContract.Exists = true;
                        return oContract;
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

            public DataView GetAll_ForSite(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("Contract_GetAll_ForSite");
                dt.TableName = Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("ContractOriginal_GetAll");
                dt.TableName = Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView GetAllActive()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("ContractOriginal_GetAll_Active");
                dt.TableName = Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_ForSite_Active(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("Contract_GetAll_ForSite_Active");
                dt.TableName = Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView GetAssetsForContract(int ContractSiteID, bool MainApp)
            {
                var dt = _database.ExecuteWithReturn("Select AssetID,Product From tblContractOriginalSiteAsset Where ContractSiteID =" + ContractSiteID + " AND (PrimaryAsset = '" + MainApp + "' ) ");
                return new DataView(dt);
            }

            public DataView Get_NotProcessed(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                var dt = _database.ExecuteSP_DataTable("Contract_Get_NotProcessed");
                dt.TableName = Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataView ContractOriginalSiteAsset_GetAll_SiteID(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("ContractOriginalSiteAsset_GetAll_SiteID");
                dt.TableName = Enums.TableNames.tblContract.ToString();
                return new DataView(dt);
            }

            public DataTable ProcessContract(int contractId)
            {
                var dtContracts = App.DB.ContractOriginal.Get_NotProcessed(contractId).Table;
                dtContracts.Columns.Add("InvoiceNumber");
                try
                {
                    foreach (DataRow i in dtContracts.Rows)
                    {
                        string PayType = "";
                        if (Information.IsDBNull(i["Type"]))
                        {
                            PayType = "";
                        }
                        else
                        {
                            PayType = Conversions.ToString(i["Type"]);
                        }

                        string printed = "0";
                        if (!Information.IsDBNull(i["Printed"]))
                        {
                            printed = Conversions.ToString(i["Printed"]);
                        }

                        if (Conversions.ToBoolean(printed) | Information.IsDBNull(i["Processed"]) | Helper.MakeBooleanValid(i["Processed"])) // added fail for old plans
                        {
                            var dt = App.DB.ExecuteWithReturn(Conversions.ToString("select * from tblInvoicedLines il INNER join tblInvoiced i on i.InvoicedID = il.InvoicedID WHERE InvoiceToBeRaisedID = " + i["InvoiceToBeRaisedID"]));
                            if (dt.Rows.Count > 0) // an invoice already exists
                            {
                                i["InvoiceNumber"] = dt.Rows[0]["InvoiceNumber"];
                            }
                        }
                        else if (Conversions.ToBoolean((PayType ?? "") == "TRANS" | (PayType ?? "") == "AMEND" | (PayType ?? "") == "RENEWAL" & (Operators.ConditionalCompareObjectEqual(i["InvoiceFrequencyID"], Enums.InvoiceFrequency.AnnuallyDD, false) | Operators.ConditionalCompareObjectEqual(i["InvoiceFrequencyID"], Enums.InvoiceFrequency.Monthly, false)) | Operators.ConditionalCompareObjectEqual(i["installments"] % 12, 0, false) & !Operators.ConditionalCompareObjectEqual(i["installments"], 0, false)))
                        {
                        }
                        // DONT RAISE A FUCKING INVOICE
                        else
                        {
                            var dt = App.DB.ExecuteWithReturn(Conversions.ToString("select * from tblInvoicedLines il INNER join tblInvoiced i on i.InvoicedID = il.InvoicedID WHERE InvoiceToBeRaisedID = " + i["InvoiceToBeRaisedID"]));
                            if (dt.Rows.Count > 0) // an invoice already exists
                            {
                                i["InvoiceNumber"] = dt.Rows[0]["InvoiceNumber"];
                            }
                            else
                            {
                                var inv = new Invoiceds.Invoiced();
                                var invNum = new JobNumber();
                                invNum = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                                inv.SetInvoiceNumber = invNum.Prefix + invNum.JobNumber;
                                inv.SetRaisedByUserID = App.loggedInUser.UserID;
                                inv.RaisedDate = Conversions.ToDate(i["RaiseDate"]);
                                inv.SetVATRateID = App.DB.VATRatesSQL.VATRates_Get_ByDate(DateAndTime.Now);
                                inv = App.DB.Invoiced.Insert(inv); // stop creating for now
                                var invLines = new InvoicedLiness.InvoicedLines();
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(i["InvoiceFrequencyID"], Enums.InvoiceFrequency.Monthly, false)))
                                {
                                    invLines.SetAmount = i["FirstAmount"] / 1.2;
                                }
                                else
                                {
                                    invLines.SetAmount = i["ContractPrice"];
                                }

                                invLines.SetInvoicedID = inv.InvoicedID;
                                invLines.SetInvoiceToBeRaisedID = i["InvoiceToBeRaisedID"];
                                invLines = App.DB.InvoicedLines.Insert(invLines);
                                i["InvoiceNumber"] = inv.InvoiceNumber;
                            }
                        }
                    }

                    return dtContracts;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}