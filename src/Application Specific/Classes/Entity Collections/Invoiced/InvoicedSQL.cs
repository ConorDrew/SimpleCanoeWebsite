using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Invoiceds
    {
        public class InvoicedSQL
        {
            private Sys.Database _database;

            public InvoicedSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public Invoiced Invoiced_Get(int InvoicedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedID", InvoicedID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Invoiced_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oInvoiced = new Invoiced();
                        oInvoiced.IgnoreExceptionsOnSetMethods = true;
                        oInvoiced.SetInvoicedID = dt.Rows[0]["InvoicedID"];
                        oInvoiced.RaisedDate = Conversions.ToDate(dt.Rows[0]["RaisedDate"]);
                        oInvoiced.SetInvoiceNumber = dt.Rows[0]["InvoiceNumber"];
                        oInvoiced.SetRaisedByUserID = dt.Rows[0]["RaisedByUserID"];
                        oInvoiced.SetVATRateID = dt.Rows[0]["VATRateID"];
                        oInvoiced.SetPaidByID = dt.Rows[0]["PaidByID"];
                        oInvoiced.SetAdhocInvoiceType = dt.Rows[0]["AdhocInvoiceType"];
                        oInvoiced.Exists = true;
                        return oInvoiced;
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

            public Invoiced Invoiced_Get_ByInvoiceNumber(int invoiceNumber)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedNumber", invoiceNumber);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Invoiced_Get_InvoiceNumber");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oInvoiced = new Invoiced();
                        oInvoiced.IgnoreExceptionsOnSetMethods = true;
                        oInvoiced.SetInvoicedID = dt.Rows[0]["InvoicedID"];
                        oInvoiced.RaisedDate = Conversions.ToDate(dt.Rows[0]["RaisedDate"]);
                        oInvoiced.SetInvoiceNumber = dt.Rows[0]["InvoiceNumber"];
                        oInvoiced.SetRaisedByUserID = dt.Rows[0]["RaisedByUserID"];
                        oInvoiced.SetVATRateID = dt.Rows[0]["VATRateID"];
                        oInvoiced.SetPaidByID = dt.Rows[0]["PaidByID"];
                        oInvoiced.SetAdhocInvoiceType = dt.Rows[0]["AdhocInvoiceType"];
                        oInvoiced.Exists = true;
                        return oInvoiced;
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

            public DataView Invoiced_GetAll_Manager(DateTime RaisedFrom, DateTime RaisedTo, int customerId, int siteId, string postcode, int invoiceTypeId, string jobNumber, string invoiceNumber, int userId, int regionId, string department, int exportedToSage)
            {
                _database.ClearParameter();
                _database.AddParameter("@RaisedFrom", Conversions.ToDate(Strings.Format(RaisedFrom, "dd/MM/yyyy") + " 00:00:00"), true);
                _database.AddParameter("@RaisedTo", Conversions.ToDate(Strings.Format(RaisedTo, "dd/MM/yyyy") + " 23:59:59"), true);
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                _database.AddParameter("@Contract_Option1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                _database.AddParameter("@Contract_Option2Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option2), true);
                _database.AddParameter("@Contract_Option3Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option3), true);
                _database.AddParameter("@CustomerId", customerId, true);
                _database.AddParameter("@SiteId", siteId, true);
                _database.AddParameter("@Postcode", postcode, true);
                _database.AddParameter("@InvoiceTypeID", invoiceTypeId, true);
                _database.AddParameter("@JobNumber", jobNumber, true);
                _database.AddParameter("@InvoiceNumber", invoiceNumber, true);
                _database.AddParameter("@UserId", userId, true);
                _database.AddParameter("@RegionId", regionId, true);
                _database.AddParameter("@Department", department, true);
                _database.AddParameter("@ExportedToSage", exportedToSage, true);
                var dt = _database.ExecuteSP_DataTable("Invoiced_GetAll_Manager5");
                dt.TableName = Sys.Enums.TableNames.tblInvoiced.ToString();
                return new DataView(dt);
            }

            public Invoiced Insert(Invoiced oInvoiced)
            {
                _database.ClearParameter();
                AddInvoicedParametersToCommand(ref oInvoiced);
                oInvoiced.SetInvoicedID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Invoiced_Insert"));
                oInvoiced.Exists = true;
                return oInvoiced;
            }

            public void Update(Invoiced oInvoiced)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedID", oInvoiced.InvoicedID, true);
                AddInvoicedParametersToCommand(ref oInvoiced);
                _database.ExecuteSP_NO_Return("Invoiced_Update");
            }

            private void AddInvoicedParametersToCommand(ref Invoiced oInvoiced)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@InvoiceNumber", oInvoiced.InvoiceNumber, true);
                    withBlock.AddParameter("@RaisedDate", oInvoiced.RaisedDate, true);
                    withBlock.AddParameter("@RaisedByUserID", oInvoiced.RaisedByUserID, true);
                    withBlock.AddParameter("@VATRateID", oInvoiced.VATRateID, true);
                    withBlock.AddParameter("@PaymentTermID", oInvoiced.PaymentTermID, true);
                    withBlock.AddParameter("@PaidByID", oInvoiced.PaidByID, true);
                    withBlock.AddParameter("@AdhocInvoicetype", oInvoiced.AdhocInvoiceType, true);
                }
            }

            public DataView InvoiceDetails_Get_InvoicedID(int InvoicedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                _database.AddParameter("@Contract_Option1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                _database.AddParameter("@Contract_Option2Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option2), true);
                _database.AddParameter("@Contract_Option3Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option3), true);
                _database.AddParameter("@InvoicedID", InvoicedID, true);
                var dt = _database.ExecuteSP_DataTable("InvoiceDetails_Get_InvoicedID");
                dt.TableName = Sys.Enums.TableNames.tblInvoiced.ToString();
                return new DataView(dt);
            }

            public DataView InvoiceDetails_Get_InvoiceToBeRaisedID(int InvoicedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceToBeRaisedID", InvoicedID, true);
                var dt = _database.ExecuteSP_DataTable("InvoiceDetails_Get_InvoiceToBeRaisedID");
                dt.TableName = Sys.Enums.TableNames.tblInvoiced.ToString();
                return new DataView(dt);
            }

            public DataView InvoiceDetails_Get_InvoicedNumber(int InvoicedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                _database.AddParameter("@Contract_Option1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                _database.AddParameter("@Contract_Option2Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option2), true);
                _database.AddParameter("@Contract_Option3Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option3), true);
                _database.AddParameter("@InvoicedNumber", InvoicedID, true);
                var dt = _database.ExecuteSP_DataTable("InvoiceDetails_Get_InvoicedNumber");
                dt.TableName = Sys.Enums.TableNames.tblInvoiced.ToString();
                return new DataView(dt);
            }

            public DataView Invoiced_GetContractOpt3_Jobs(int InvoicedID, int ContractSiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractOpt3Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option3), true);
                _database.AddParameter("@InvoicedID", InvoicedID, true);
                _database.AddParameter("@ContractSiteID", ContractSiteID, true);
                var dt = _database.ExecuteSP_DataTable("Invoiced_GetContractOpt3_Jobs");
                dt.TableName = Sys.Enums.TableNames.tblInvoiced.ToString();
                return new DataView(dt);
            }

            public string Invoice_GetAdditionalNotes(int InvoicedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedID", InvoicedID, true);
                return Sys.Helper.MakeStringValid(_database.ExecuteSP_OBJECT("Invoiced_GetNotes"));
            }

            public void Invoice_UpdateAdditionalNotes(int InvoicedID, string Notes)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedID", InvoicedID, true);
                _database.AddParameter("@Notes", Notes, true);
                _database.ExecuteSP_NO_Return("Invoiced_UpdateNotes");
            }

            public DataView NCCValuation(int InvoicedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedID", InvoicedID, true);
                var dt = _database.ExecuteSP_DataTable("InvoicedManager_Get_NccVal");
                dt.TableName = Sys.Enums.TableNames.tblInvoicedPaymentApplications.ToString();
                return new DataView(dt);
            }

            
            
            public DataTable GetJobNominalCode_ForSupplierInvoice(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var Results = _database.ExecuteSP_DataTable("Invoiced_GetJobNominalCode_ForSupplierInvoice");
                return Results;
            }

            
            public async Task MarkInvoiceAsExportedAsync(int invoicedId)
            {
                var sqlParams = new[] { new SqlParameter("@InvoicedID", invoicedId) };
                await _database.ExecuteAsync("Invoiced_Update_AsExported", sqlParams);
            }

            public async Task MarkConsolidatedOrderAsExportedAsync(int orderConsolidationId)
            {
                var sqlParams = new[] { new SqlParameter("@OrderConsolidationID", orderConsolidationId) };
                await _database.ExecuteAsync("OrderConsolidation_Update_AsExported", sqlParams);
            }

            public async Task MarkOrderAsExportedAsync(int supplierInvoiceId)
            {
                var sqlParams = new[] { new SqlParameter("@SupplierInvoiceID", supplierInvoiceId) };
                await _database.ExecuteAsync("OrderSupplierInvoices_Update_AsExported", sqlParams);
            }

            public async Task MarkPartCreditedAsExportedAsync(int partCreditsId, int partsToBeCreditedId)
            {
                var sqlParams = new[] { new SqlParameter("@PartsToBeCreditedID", partsToBeCreditedId), new SqlParameter("@PartCreditsID", partCreditsId) };
                await _database.ExecuteAsync("PartCredits_Update_AsExported", sqlParams);
            }

            public async Task MarkSalesCreditAsExportedAsync(int salesCreditId)
            {
                var sqlParams = new[] { new SqlParameter("@SalesCreditID", salesCreditId) };
                await _database.ExecuteAsync("SalesCredit_Update_AsExported", sqlParams);
            }

            
            
            public async Task MarkInvoiceAsNotExportedAsync(int invoicedId)
            {
                var sqlParams = new[] { new SqlParameter("@InvoicedID", invoicedId) };
                await _database.ExecuteAsync("Invoiced_Update_AsNotExported", sqlParams);
            }

            public async Task MarkOrderAsNotExportedAsync(int supplierInvoiceId)
            {
                var sqlParams = new[] { new SqlParameter("@SupplierInvoiceID", supplierInvoiceId) };
                await _database.ExecuteAsync("OrderSupplierInvoices_Update_AsNotExported", sqlParams);
            }

            public async Task MarkConsolidatedOrderAsNotExportedAsync(int orderConsolidationId)
            {
                var sqlParams = new[] { new SqlParameter("@OrderConsolidationID", orderConsolidationId) };
                await _database.ExecuteAsync("OrderConsolidation_Update_AsNotExported", sqlParams);
            }

            public async Task MarkPartCreditedAsNotExportedAsync(int partCreditsId, int partsToBeCreditedId)
            {
                var sqlParams = new[] { new SqlParameter("@PartsToBeCreditedID", partsToBeCreditedId), new SqlParameter("@PartCreditsID", partCreditsId) };
                await _database.ExecuteAsync("PartCredits_Update_AsNotExported", sqlParams);
            }

            public async Task MarkSalesCreditAsNotExportedAsync(int salesCreditId)
            {
                var sqlParams = new[] { new SqlParameter("@SalesCreditID", salesCreditId) };
                await _database.ExecuteAsync("SalesCredit_Update_AsNotExported", sqlParams);
            }

            
            
        }
    }
}