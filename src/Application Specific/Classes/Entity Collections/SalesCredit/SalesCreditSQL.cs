using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace SalesCredits
    {
        public class SalesCreditSQL
        {
            private Sys.Database _database;

            public SalesCreditSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public SalesCredit SalesCredit_Get(int SalesCreditID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SalesCreditID", SalesCreditID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("SalesCredit_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSC = new SalesCredit();
                        oSC.IgnoreExceptionsOnSetMethods = true;
                        oSC.SetAmountCredited = dt.Rows[0]["AmountCredited"];
                        oSC.SetNotes = dt.Rows[0]["Notes"];
                        oSC.SetTaxCodeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["TaxCodeID"]);
                        oSC.SetNominalCode = Sys.Helper.MakeIntegerValid(dt.Rows[0]["NominalCode"]);
                        oSC.SetDepartmentRef = dt.Rows[0]["DepartmentRef"];
                        oSC.SetExtraRef = dt.Rows[0]["ExtraRef"];
                        oSC.SetReasonForCredit = dt.Rows[0]["ReasonForCredit"];
                        oSC.SetRequestedBy = Sys.Helper.MakeIntegerValid(dt.Rows[0]["RequestedBy"]);
                        oSC.SetInvoicedLineID = Sys.Helper.MakeStringValid(dt.Rows[0]["InvoicedLineID"]);
                        oSC.DateCredited = Conversions.ToDate(dt.Rows[0]["DateCredited"]);
                        oSC.SetCreditReference = Sys.Helper.MakeStringValid(dt.Rows[0]["CreditReference"]);
                        oSC.Exists = true;
                        return oSC;
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

            public SalesCredit SalesCredit_Get_For_InvoicedLine(int SalesCreditID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedLineID", SalesCreditID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("SalesCredit_Get_For_InvoicedLine");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSC = new SalesCredit();
                        oSC.IgnoreExceptionsOnSetMethods = true;
                        oSC.SetAmountCredited = dt.Rows[0]["AmountCredited"];
                        oSC.SetNotes = dt.Rows[0]["Notes"];
                        oSC.SetTaxCodeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["TaxCodeID"]);
                        oSC.SetNominalCode = Sys.Helper.MakeIntegerValid(dt.Rows[0]["NominalCode"]);
                        oSC.SetDepartmentRef = dt.Rows[0]["DepartmentRef"];
                        oSC.SetExtraRef = dt.Rows[0]["ExtraRef"];
                        oSC.SetReasonForCredit = dt.Rows[0]["ReasonForCredit"];
                        oSC.SetRequestedBy = Sys.Helper.MakeIntegerValid(dt.Rows[0]["RequestedBy"]);
                        oSC.SetInvoicedLineID = Sys.Helper.MakeStringValid(dt.Rows[0]["InvoicedLineID"]);
                        oSC.SetCreditReference = Sys.Helper.MakeStringValid(dt.Rows[0]["CreditReference"]);
                        oSC.DateCredited = Conversions.ToDate(dt.Rows[0]["DateCredited"]);
                        oSC.SetAccountNumber = dt.Rows[0]["AccountNumber"];
                        oSC.Exists = true;
                        return oSC;
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

            public DataView PartsToBeCredited_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public DataView PartsToBeCredited_Get_PartsCreditID(int PartCreditID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartCreditID", PartCreditID, true);
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_PartsCreditID");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public DataView PartsToBeCredited_Get_OrderID(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_Order");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public DataView PartsToBeCredited_Get_OrderPartID(int OrderPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", OrderPartID, true);
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_OrderPart");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public SalesCredit Insert(SalesCredit oSalesCredited)
            {
                _database.ClearParameter();
                AddPartsToBeCreditedParametersToCommand(ref oSalesCredited);
                _database.AddParameter("@DateCredited", oSalesCredited.DateCredited, true);
                oSalesCredited.SetSalesCreditID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SalesCredit_Insert"));
                oSalesCredited.Exists = true;
                return oSalesCredited;
            }

            private void AddPartsToBeCreditedParametersToCommand(ref SalesCredit oPartsToBeCredited)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@AmountCredited", oPartsToBeCredited.AmountCredited, true);
                    withBlock.AddParameter("@Notes", oPartsToBeCredited.Notes, true);
                    withBlock.AddParameter("@TaxCodeID", oPartsToBeCredited.TaxCodeID, true);
                    withBlock.AddParameter("@NominalCode", oPartsToBeCredited.NominalCode, true);
                    withBlock.AddParameter("@DepartmentRef", oPartsToBeCredited.DepartmentRef, true);
                    withBlock.AddParameter("@ExtraRef", oPartsToBeCredited.ExtraRef, true);
                    withBlock.AddParameter("@Reason", oPartsToBeCredited.ReasonForCredit, true);
                    withBlock.AddParameter("@RequestBy", oPartsToBeCredited.RequestedBy, true);
                    withBlock.AddParameter("@InvoicedLineID", oPartsToBeCredited.InvoicedLineID, true);
                    withBlock.AddParameter("@CreditReference", oPartsToBeCredited.CreditReference, true);
                    withBlock.AddParameter("@AddedBy", oPartsToBeCredited.AddedByUser, true);
                    withBlock.AddParameter("@AccountNumber", oPartsToBeCredited.AccountNumber, true);
                }
            }

            public DataView InvoicedLines_GetAll_ByInvoicedID(int InvoicedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedID", InvoicedID, true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                _database.AddParameter("@Contract_Option1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                var dt = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoicedID_ForCredits");
                dt.TableName = Sys.Enums.TableNames.tblInvoicedLines.ToString();
                return new DataView(dt);
            }

            public DataView InvoicedLines_GetAll_ByInvoicedIDRows(DataRow[] Invoiced)
            {
                var masterdt = new DataTable();
                foreach (DataRow dr in Invoiced)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@InvoicedLineID", dr["InvoicedLineID"], true);
                    _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                    _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                    _database.AddParameter("@Contract_Option1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                    var dt = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoicedLineID_ForCredits");
                    dt.TableName = Sys.Enums.TableNames.tblInvoicedLines.ToString();
                    masterdt.Merge(dt);
                }

                return new DataView(masterdt);
            }

            public DataView InvoicedLines_GetAll_ByInvoicedNumber(string InvoicedNumber)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedNumber", InvoicedNumber, true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                _database.AddParameter("@Contract_Option1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                var dt = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_CreditsByInvoiceNumber");
                dt.TableName = Sys.Enums.TableNames.tblInvoicedLines.ToString();
                return new DataView(dt);
            }

            public DataView InvoicedLines_GetAll_ByCreditReference(string creditReference)
            {
                _database.ClearParameter();
                _database.AddParameter("@CreditReference", creditReference, true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                _database.AddParameter("@Contract_Option1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                var dt = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByCreditReference");
                dt.TableName = Sys.Enums.TableNames.tblInvoicedLines.ToString();
                return new DataView(dt);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}