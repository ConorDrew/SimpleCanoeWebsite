using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteOrders
    {
        public class QuoteOrderSQL
        {
            private Sys.Database _database;

            public QuoteOrderSQL(Sys.Database database)
            {
                _database = database;
            }

            

            public void Delete(int QuoteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, true);
                _database.ExecuteSP_NO_Return("QuoteOrder_Delete");
            }

            public void QuoteOrderProductsToInclude_Insert(int QuoteOrderID, int ProductSupplierID, double SellPrice)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, true);
                _database.AddParameter("@ProductSupplierID", ProductSupplierID, true);
                _database.AddParameter("@SellPrice", SellPrice, true);
                _database.ExecuteSP_NO_Return("QuoteOrderProductsToInclude_Insert");
            }

            public void QuoteOrderPartsToInclude_Insert(int QuoteOrderID, int PartSupplierID, double SellPrice)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, true);
                _database.AddParameter("@PartSupplierID", PartSupplierID, true);
                _database.AddParameter("@SellPrice", SellPrice, true);
                _database.ExecuteSP_NO_Return("QuoteOrderPartsToInclude_Insert");
            }

            public void QuoteOrder_DeleteItemsIncluded(int QuoteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID, true);
                _database.ExecuteSP_NO_Return("QuoteOrder_DeleteItemsIncluded");
            }

            public QuoteOrder QuoteOrder_Get(int QuoteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", QuoteOrderID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("QuoteOrder_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oQuoteOrder = new QuoteOrder();
                        oQuoteOrder.IgnoreExceptionsOnSetMethods = true;
                        oQuoteOrder.SetQuoteOrderID = dt.Rows[0]["QuoteOrderID"];
                        oQuoteOrder.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oQuoteOrder.SetPropertyID = dt.Rows[0]["SiteID"];
                        oQuoteOrder.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oQuoteOrder.SetContactID = dt.Rows[0]["ContactID"];
                        oQuoteOrder.SetInvoiceAddressID = dt.Rows[0]["InvoiceAddressID"];
                        oQuoteOrder.SetCustomerRef = dt.Rows[0]["CustomerRef"];
                        if (Information.IsDBNull(dt.Rows[0]["DeliveryDeadline"]))
                        {
                            oQuoteOrder.DeliveryDeadline = default;
                        }
                        else
                        {
                            oQuoteOrder.DeliveryDeadline = Conversions.ToDate(dt.Rows[0]["DeliveryDeadline"]);
                        }

                        oQuoteOrder.SetSpecialInstructions = dt.Rows[0]["SpecialInstructions"];
                        oQuoteOrder.SetCreatedByUser = dt.Rows[0]["CreatedByUser"];
                        oQuoteOrder.SetAllocatedToUser = dt.Rows[0]["AllocatedToUser"];
                        oQuoteOrder.EnquiryDate = Conversions.ToDate(dt.Rows[0]["EnquiryDate"]);
                        oQuoteOrder.ValidUntilDate = Conversions.ToDate(dt.Rows[0]["ValidUntilDate"]);
                        oQuoteOrder.SetAvailability = dt.Rows[0]["Availability"];
                        oQuoteOrder.SetPriceDetails = dt.Rows[0]["PriceDetails"];
                        oQuoteOrder.SetPriceExcludeDetails = dt.Rows[0]["PriceExcludeDetails"];
                        oQuoteOrder.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oQuoteOrder.SetQuoteStatusID = dt.Rows[0]["StatusID"];
                        oQuoteOrder.SetReasonForReject = dt.Rows[0]["ReasonForReject"];
                        oQuoteOrder.Exists = true;
                        return oQuoteOrder;
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

            public DataView QuoteOrder_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("QuoteOrder_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblQuoteOrder.ToString();
                return new DataView(dt);
            }

            public QuoteOrder Insert(QuoteOrder oQuoteOrder)
            {
                _database.ClearParameter();
                AddQuoteOrderParametersToCommand(ref oQuoteOrder);
                oQuoteOrder.SetQuoteOrderID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteOrder_Insert"));
                oQuoteOrder.Exists = true;
                return oQuoteOrder;
            }

            public void Update(QuoteOrder oQuoteOrder)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteOrderID", oQuoteOrder.QuoteOrderID, true);
                AddQuoteOrderParametersToCommand(ref oQuoteOrder);
                _database.ExecuteSP_NO_Return("QuoteOrder_Update");
            }

            public DataView Quote_PriceRequests_GetAll(int QuoteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteID", QuoteID, true);
                var dt = _database.ExecuteSP_DataTable("Quote_PriceRequests_GetAll");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
                return new DataView(dt);
            }

            public DataView Quote_PriceRequests_GetConfirmed(int QuoteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteID", QuoteID, true);
                var dt = _database.ExecuteSP_DataTable("Quote_PriceRequests_GetConfirmed");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
                foreach (DataRow row in dt.Rows)
                {
                    if (Information.IsDBNull(row["Included"]))
                    {
                        row["Included"] = 0;
                    }
                }

                return new DataView(dt);
            }

            private void AddQuoteOrderParametersToCommand(ref QuoteOrder oQuoteOrder)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CustomerID", oQuoteOrder.CustomerID, true);
                    withBlock.AddParameter("@SiteID", oQuoteOrder.PropertyID, true);
                    withBlock.AddParameter("@WarehouseID", oQuoteOrder.WarehouseID, true);
                    withBlock.AddParameter("@ContactID", oQuoteOrder.ContactID, true);
                    withBlock.AddParameter("@InvoiceAddressID", oQuoteOrder.InvoiceAddressID, true);
                    withBlock.AddParameter("@CustomerRef", oQuoteOrder.CustomerRef, true);
                    withBlock.AddParameter("@SpecialInstructions", oQuoteOrder.SpecialInstructions, true);
                    withBlock.AddParameter("@CreatedByUser", oQuoteOrder.CreatedByUser, true);
                    withBlock.AddParameter("@AllocatedToUser", oQuoteOrder.AllocatedToUser, true);
                    withBlock.AddParameter("@EnquiryDate", oQuoteOrder.EnquiryDate, true);
                    withBlock.AddParameter("@ValidUntilDate", oQuoteOrder.ValidUntilDate, true);
                    if (oQuoteOrder.DeliveryDeadline == default)
                    {
                        withBlock.AddParameter("@DeliveryDeadline", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@DeliveryDeadline", oQuoteOrder.DeliveryDeadline, true);
                    }

                    withBlock.AddParameter("@Availability", oQuoteOrder.Availability, true);
                    withBlock.AddParameter("@PriceDetails", oQuoteOrder.PriceDetails, true);
                    withBlock.AddParameter("@PriceExcludeDetails", oQuoteOrder.PriceExcludeDetails, true);
                    withBlock.AddParameter("@StatusID", oQuoteOrder.QuoteStatusID, true);
                    withBlock.AddParameter("@ReasonForReject", oQuoteOrder.ReasonForReject, true);
                }
            }
            
        }
    }
}