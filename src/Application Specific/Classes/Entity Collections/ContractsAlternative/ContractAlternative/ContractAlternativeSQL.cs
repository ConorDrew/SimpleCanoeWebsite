using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractsAlternative
    {
        public class ContractAlternativeSQL
        {
            private Sys.Database _database;

            public ContractAlternativeSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public ContractAlternative Get(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractAlternative_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContract = new ContractAlternative();
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
                        oContract.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
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

            public DataView GetAll_For_Customer_ID(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("ContractAlternative_GetAll_For_Customer_ID");
                dt.TableName = Sys.Enums.TableNames.tblDocuments.ToString();
                return new DataView(dt);
            }

            public double ContractAlternativeCalculatedTotal(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                return Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("ContractAlternativeCalculatedTotal"));
            }

            public ContractAlternative Get_For_Quote_ID(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                var dt = _database.ExecuteSP_DataTable("ContractAlternative_Get_For_Quote_ID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContract = new ContractAlternative();
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
                        oContract.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
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

            public ContractAlternative Insert(ContractAlternative oContract)
            {
                _database.ClearParameter();
                AddContractParametersToCommand(ref oContract);
                oContract.SetContractID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternative_Insert"));
                oContract.Exists = true;
                return oContract;
            }

            public void Update(ContractAlternative oContract)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", oContract.ContractID, true);
                AddContractParametersToCommand(ref oContract);
                _database.ExecuteSP_NO_Return("ContractAlternative_Update");
            }

            public void Delete(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                _database.AddParameter("@ContractOpt2Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option2), true);
                _database.ExecuteSP_NO_Return("ContractAlternative_Delete");
            }

            private void AddContractParametersToCommand(ref ContractAlternative oContract)
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
                    withBlock.AddParameter("@InvoiceAddressID", oContract.InvoiceAddressID, true);
                    withBlock.AddParameter("@InvoiceAddressTypeID", oContract.InvoiceAddressTypeID, true);
                    withBlock.AddParameter("@FirstInvoiceDate", oContract.FirstInvoiceDate, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}