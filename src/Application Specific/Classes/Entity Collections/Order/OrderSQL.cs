using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Orders
    {
        public class OrderSQL
        {
            private Sys.Database _database;

            public OrderSQL(Sys.Database database)
            {
                _database = database;
            }

            public DataView Order_CheckReference(string OrderRef)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderReference", OrderRef, true);
                var dt = _database.ExecuteSP_DataTable("Order_CheckReference");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView Order_ItemsGetAll(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("Order_ItemsGetAll");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView OrderSupplierItemsForPrint_Get(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("OrderSupplierItemsForPrint_Get");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public void Delete(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("Order_Delete");
            }

            public void Delete(int OrderID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Order_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@OrderID", OrderID));
                Command.ExecuteNonQuery();
            }

            public Order Order_Get(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID);
                _database.AddParameter("@OrderInvoiceTypeID", Conversions.ToInteger(Sys.Enums.InvoiceType.Order));
                _database.AddParameter("@VisitInvoiceTypeID", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit));

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Order_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrder = new Order();
                        oOrder.IgnoreExceptionsOnSetMethods = true;
                        oOrder.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrder.DatePlaced = Conversions.ToDate(dt.Rows[0]["DatePlaced"]);
                        oOrder.SetOrderTypeID = dt.Rows[0]["OrderTypeID"];
                        oOrder.SetOrderReference = dt.Rows[0]["OrderReference"];
                        oOrder.SetUserID = dt.Rows[0]["UserID"];
                        oOrder.SetOrderStatusID = dt.Rows[0]["OrderStatusID"];
                        oOrder.SetReasonForReject = dt.Rows[0]["ReasonForReject"];
                        if (!Information.IsDBNull(dt.Rows[0]["DeliveryDeadline"]))
                        {
                            oOrder.DeliveryDeadline = Conversions.ToDate(dt.Rows[0]["DeliveryDeadline"]);
                        }
                        else
                        {
                            oOrder.DeliveryDeadline = default;
                        }

                        oOrder.SetSentToSage = Sys.Helper.MakeBooleanValid(dt.Rows[0]["SentToSage"]);
                        oOrder.SetSupplierInvoiceAmount = Sys.Helper.MakeDoubleValid(dt.Rows[0]["SupplierInvoiceAmount"]);
                        oOrder.SetSupplierInvoiceReference = Sys.Helper.MakeStringValid(dt.Rows[0]["SupplierInvoiceReference"]);
                        if (!Information.IsDBNull(dt.Rows[0]["SupplierInvoiceDate"]))
                        {
                            oOrder.SupplierInvoiceDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["SupplierInvoiceDate"]);
                        }
                        else
                        {
                            oOrder.SupplierInvoiceDate = default;
                        }

                        oOrder.SetSpecialInstructions = Sys.Helper.MakeStringValid(dt.Rows[0]["SpecialInstructions"]);
                        oOrder.SetContactID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["ContactID"]);
                        oOrder.SetInvoiceAddressID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["InvoiceAddressID"]);
                        oOrder.SetAllocatedToUser = Sys.Helper.MakeIntegerValid(dt.Rows[0]["AllocatedToUser"]);
                        oOrder.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrder.SetInvoiced = Conversions.ToBoolean(dt.Rows[0]["Invoiced"]);
                        oOrder.SetExportedToSage = Conversions.ToBoolean(dt.Rows[0]["ExportedToSage"]);
                        oOrder.SetNominalCode = Sys.Helper.MakeStringValid(dt.Rows[0]["NominalCode"]);
                        oOrder.SetDepartmentRef = Sys.Helper.MakeStringValid(dt.Rows[0]["DepartmentRef"]);
                        oOrder.SetExtraRef = Sys.Helper.MakeStringValid(dt.Rows[0]["ExtraRef"]);
                        oOrder.SetTaxCodeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["TaxCodeID"]);
                        oOrder.SetReadyToSendToSage = Sys.Helper.MakeBooleanValid(dt.Rows[0]["ReadyToSendToSage"]);
                        oOrder.SetOrderConsolidationID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["OrderConsolidationID"]);
                        oOrder.SetVATAmount = Sys.Helper.MakeDoubleValid(dt.Rows[0]["VATAmount"]);
                        oOrder.SetDoNotConsolidated = Sys.Helper.MakeBooleanValid(dt.Rows[0]["DoNotConsolidated"]);
                        oOrder.Exists = true;
                        return oOrder;
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

            public Order Order_Get(int OrderID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Order_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderID", OrderID);
                Command.Parameters.AddWithValue("@OrderInvoiceTypeID", Conversions.ToInteger(Sys.Enums.InvoiceType.Order));
                Command.Parameters.AddWithValue("@VisitInvoiceTypeID", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit));
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrder = new Order();
                        oOrder.IgnoreExceptionsOnSetMethods = true;
                        oOrder.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrder.DatePlaced = Conversions.ToDate(dt.Rows[0]["DatePlaced"]);
                        oOrder.SetOrderTypeID = dt.Rows[0]["OrderTypeID"];
                        oOrder.SetOrderReference = dt.Rows[0]["OrderReference"];
                        oOrder.SetUserID = dt.Rows[0]["UserID"];
                        oOrder.SetOrderStatusID = dt.Rows[0]["OrderStatusID"];
                        oOrder.SetReasonForReject = dt.Rows[0]["ReasonForReject"];
                        if (!Information.IsDBNull(dt.Rows[0]["DeliveryDeadline"]))
                        {
                            oOrder.DeliveryDeadline = Conversions.ToDate(dt.Rows[0]["DeliveryDeadline"]);
                        }
                        else
                        {
                            oOrder.DeliveryDeadline = default;
                        }

                        oOrder.SetSentToSage = Sys.Helper.MakeBooleanValid(dt.Rows[0]["SentToSage"]);
                        oOrder.SetSupplierInvoiceAmount = Sys.Helper.MakeDoubleValid(dt.Rows[0]["SupplierInvoiceAmount"]);
                        oOrder.SetSupplierInvoiceReference = Sys.Helper.MakeStringValid(dt.Rows[0]["SupplierInvoiceReference"]);
                        if (!Information.IsDBNull(dt.Rows[0]["SupplierInvoiceDate"]))
                        {
                            oOrder.SupplierInvoiceDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["SupplierInvoiceDate"]);
                        }
                        else
                        {
                            oOrder.SupplierInvoiceDate = default;
                        }

                        oOrder.SetSpecialInstructions = Sys.Helper.MakeStringValid(dt.Rows[0]["SpecialInstructions"]);
                        oOrder.SetContactID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["ContactID"]);
                        oOrder.SetInvoiceAddressID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["InvoiceAddressID"]);
                        oOrder.SetAllocatedToUser = Sys.Helper.MakeIntegerValid(dt.Rows[0]["AllocatedToUser"]);
                        oOrder.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrder.SetInvoiced = Conversions.ToBoolean(dt.Rows[0]["Invoiced"]);
                        oOrder.SetExportedToSage = Conversions.ToBoolean(dt.Rows[0]["ExportedToSage"]);
                        oOrder.SetNominalCode = Sys.Helper.MakeStringValid(dt.Rows[0]["NominalCode"]);
                        oOrder.SetDepartmentRef = Sys.Helper.MakeStringValid(dt.Rows[0]["DepartmentRef"]);
                        oOrder.SetExtraRef = Sys.Helper.MakeStringValid(dt.Rows[0]["ExtraRef"]);
                        oOrder.SetTaxCodeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["TaxCodeID"]);
                        oOrder.SetReadyToSendToSage = Sys.Helper.MakeBooleanValid(dt.Rows[0]["ReadyToSendToSage"]);
                        oOrder.SetOrderConsolidationID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["OrderConsolidationID"]);
                        oOrder.SetVATAmount = Sys.Helper.MakeDoubleValid(dt.Rows[0]["VATAmount"]);
                        oOrder.SetDoNotConsolidated = Sys.Helper.MakeBooleanValid(dt.Rows[0]["DoNotConsolidated"]);
                        oOrder.Exists = true;
                        return oOrder;
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

            public DataView Order_Get_ByRef(string OrderReference)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderReference", OrderReference, true);
                var dt = _database.ExecuteSP_DataTable("Order_Get_ByRef");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView Order_Get_ByRef(string OrderReference, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Order_Get_ByRef";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderReference", OrderReference);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView OrderPart_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("OrderPart_GetForOrder");
                dt.TableName = Sys.Enums.TableNames.tblPartSupplier.ToString();
                return new DataView(dt);
            }

            public DataView OrderPart_GetForOrder(int OrderID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderPart_GetForOrder";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderID", OrderID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblPartSupplier.ToString();
                return new DataView(dt);
            }

            public DataView Order_GetAll(string SearchCriteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderInvoiceTypeID", Conversions.ToInteger(Sys.Enums.InvoiceType.Order));
                _database.AddParameter("@VisitInvoiceTypeID", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit));
                _database.AddParameter("@SearchCriteria", SearchCriteria, true);
                var dt = _database.ExecuteSP_DataTable("Order_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView Order_GetAll_NEW(string SearchCriteria, int OrderSiteID, int OrderVanID, int OrderWarehouseID, int OrderJobID, int OrderTypeID, string OrderReference, string OrderConsolidationRef, int OrderStatus, int PartsNotReceived, int OrderSupplierExported, int OrderSupplierID, DateTime? OrderDatePlacedFrom, DateTime? OrderDatePlacedTo, DateTime? OrderDeliveryDeadlineFrom, DateTime? OrderDeliveryDeadlineTo, string OrderDepartment)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderInvoiceTypeID", Conversions.ToInteger(Sys.Enums.InvoiceType.Order));
                _database.AddParameter("@VisitInvoiceTypeID", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit));
                _database.AddParameter("@SearchCriteria", SearchCriteria, true);
                _database.AddParameter("@OrderSiteID", OrderSiteID, true);
                _database.AddParameter("@OrderVanID", OrderVanID, true);
                _database.AddParameter("@OrderWarehouseID", OrderWarehouseID, true);
                _database.AddParameter("@OrderJobID", OrderJobID, true);
                _database.AddParameter("@PartsNotReceived", PartsNotReceived, true);
                _database.AddParameter("@OrderTypeID", OrderTypeID, true);
                // _database.AddParameter("@OrderDisplayStatusID", OrderDisplayStatusID, True)
                _database.AddParameter("@OrderSupplierID", OrderSupplierID, true);
                _database.AddParameter("@OrderSupplierExported", OrderSupplierExported, true);
                _database.AddParameter("@OrderReference", OrderReference, true);
                _database.AddParameter("@OrderConsolidationRef", OrderConsolidationRef, true);
                _database.AddParameter("@OrderDatePlacedFrom", OrderDatePlacedFrom, true);
                _database.AddParameter("@OrderDatePlacedTo", OrderDatePlacedTo, true);
                _database.AddParameter("@OrderDeliveryDeadlineFrom", OrderDeliveryDeadlineFrom, true);
                _database.AddParameter("@OrderDeliveryDeadlineTo", OrderDeliveryDeadlineTo, true);
                _database.AddParameter("@OrderStatus", OrderStatus, true);
                _database.AddParameter("@OrderDepartment", OrderDepartment, true);
                var dt = _database.ExecuteSP_DataTable("Order_GetAll_NEW");
                // Dim dt As DataTable = _database.ExecuteSP_DataTable("Order_GetAll")
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView Orders_GetForJob(int jobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@jobID", jobID, true);
                var dt = _database.ExecuteSP_DataTable("Orders_GetForJob");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView Orders_GetJob(int orderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", orderID, true);
                var dt = _database.ExecuteSP_DataTable("Order_GetJob_OrderID");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView Orders_GetForEngineerVisit(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("Orders_GetForEngineerVisit");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public Order Insert(Order oOrder)
            {
                _database.ClearParameter();
                AddOrderParametersToCommand(ref oOrder);
                oOrder.SetOrderID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Order_Insert"));
                oOrder.Exists = true;
                return oOrder;
            }

            public Order Insert(Order oOrder, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Order_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@DatePlaced", oOrder.DatePlaced);
                Command.Parameters.AddWithValue("@OrderTypeID", oOrder.OrderTypeID);
                Command.Parameters.AddWithValue("@OrderReference", oOrder.OrderReference);
                Command.Parameters.AddWithValue("@UserID", oOrder.UserID);
                Command.Parameters.AddWithValue("@OrderStatusID", oOrder.OrderStatusID);
                Command.Parameters.AddWithValue("@ReasonForReject", oOrder.ReasonForReject);
                if (oOrder.DeliveryDeadline == default)
                {
                    Command.Parameters.AddWithValue("@DeliveryDeadline", DBNull.Value);
                }
                else
                {
                    Command.Parameters.AddWithValue("@DeliveryDeadline", oOrder.DeliveryDeadline);
                }

                Command.Parameters.AddWithValue("@SpecialInstructions", oOrder.SpecialInstructions);
                Command.Parameters.AddWithValue("@ContactID", oOrder.ContactID);
                Command.Parameters.AddWithValue("@InvoiceAddressID", oOrder.InvoiceAddressID);
                Command.Parameters.AddWithValue("@AllocatedToUser", oOrder.AllocatedToUser);
                Command.Parameters.AddWithValue("@DepartmentRef", oOrder.DepartmentRef);
                Command.Parameters.AddWithValue("@DoNotConsolidated", oOrder.DoNotConsolidated);
                oOrder.SetOrderID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oOrder.Exists = true;
                return oOrder;
            }

            public DataView Order_PriceRequests_GetAll(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("Order_PriceRequests_GetAll");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PriceRequests.ToString();
                return new DataView(dt);
            }

            public void Update(Order oOrder)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", oOrder.OrderID, true);
                AddOrderParametersToCommand(ref oOrder);
                _database.AddParameter("@Reason", oOrder.Reason, true);
                _database.ExecuteSP_NO_Return("Order_Update");
            }

            public void Update_OrderRef(int orderId, string orderRef)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", orderId, true);
                _database.AddParameter("@OrderRef", orderRef, true);
                _database.ExecuteSP_NO_Return("Order_Update_OrderReference");
            }

            private void AddOrderParametersToCommand(ref Order oOrder)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@DatePlaced", oOrder.DatePlaced, true);
                    withBlock.AddParameter("@OrderTypeID", oOrder.OrderTypeID, true);
                    withBlock.AddParameter("@OrderReference", oOrder.OrderReference, true);
                    withBlock.AddParameter("@UserID", oOrder.UserID, true);
                    withBlock.AddParameter("@OrderStatusID", oOrder.OrderStatusID, true);
                    withBlock.AddParameter("@ReasonForReject", oOrder.ReasonForReject, true);
                    if (oOrder.DeliveryDeadline == default)
                    {
                        withBlock.AddParameter("@DeliveryDeadline", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@DeliveryDeadline", oOrder.DeliveryDeadline, true);
                    }

                    withBlock.AddParameter("@SpecialInstructions", oOrder.SpecialInstructions, true);
                    withBlock.AddParameter("@ContactID", oOrder.ContactID, true);
                    withBlock.AddParameter("@InvoiceAddressID", oOrder.InvoiceAddressID, true);
                    withBlock.AddParameter("@AllocatedToUser", oOrder.AllocatedToUser, true);
                    withBlock.AddParameter("@DepartmentRef", oOrder.DepartmentRef, true);
                    withBlock.AddParameter("@DoNotConsolidated", oOrder.DoNotConsolidated, true);
                }
            }

            public DataView Get_All_Places_Item_Can_Be_Got_From()
            {
                var getFroms = new DataTable();
                getFroms.Columns.Add(new DataColumn("ValueMember"));
                getFroms.Columns.Add(new DataColumn("DisplayMember"));
                getFroms.Columns.Add(new DataColumn("TableName"));
                DataRow newRow;
                newRow = getFroms.NewRow();
                newRow["ValueMember"] = 0;
                newRow["DisplayMember"] = Sys.Enums.ComboValues.Please_Select.ToString().Replace("_", " ").Replace("P", "--- P").Replace("t", "t ---");
                newRow["TableName"] = Sys.Enums.TableNames.NO_TABLE.ToString();
                getFroms.Rows.Add(newRow);
                newRow = getFroms.NewRow();
                newRow["ValueMember"] = 1;
                newRow["DisplayMember"] = "SUPPLIER";
                getFroms.Rows.Add(newRow);
                newRow = getFroms.NewRow();
                newRow["ValueMember"] = 3;
                newRow["DisplayMember"] = "WAREHOUSE";
                getFroms.Rows.Add(newRow);
                newRow = getFroms.NewRow();
                newRow["ValueMember"] = 2;
                newRow["DisplayMember"] = "VAN";
                getFroms.Rows.Add(newRow);
                return new DataView(getFroms);
            }

            public string Order_Get_OrderID_ByRef(string PONumber)
            {
                _database.ClearParameter();
                _database.AddParameter("@PONumber", PONumber, true);
                return Conversions.ToString(_database.ExecuteScalar("SELECT TOP (1) OrderID FROM tblOrder WHERE (OrderReference = @PONumber) ORDER BY DatePlaced DESC"));
            }

            public DataView Search(string criteria, int userId)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                _database.AddParameter("@UserID", userId, true);
                var dt = _database.ExecuteSP_DataTable("Order_Search_Mk1");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public void AllocatedDistributions(DataTable PartsAndProductsDistribution)
            {
                foreach (DataRow row in PartsAndProductsDistribution.Rows)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@LocationID", row["LocationID"], true);
                    _database.AddParameter("@AllocatedID", row["AllocatedID"], true);
                    _database.AddParameter("@Other", row["Other"], true);
                    _database.AddParameter("@Quantity", row["Quantity"], true);
                    _database.AddParameter("@PartProductID", row["PartProductID"], true);
                    _database.AddParameter("@OrderPartProductID", row["OrderPartProductID"], true);
                    _database.ExecuteSP_NO_Return("EngineerVisitPartDistributed_Insert");
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["StockTransactionType"], -1, false)))
                    {
                        // PART CREDIT
                        var CurrentPartsToBeCredited = new PartsToBeCrediteds.PartsToBeCredited();
                        CurrentPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
                        var op = App.DB.OrderPart.OrderPart_Get(Conversions.ToInteger(row["OrderPartProductID"]));
                        var ps = App.DB.PartSupplier.PartSupplier_Get(op.PartSupplierID);
                        CurrentPartsToBeCredited.SetOrderID = op.OrderID;
                        CurrentPartsToBeCredited.SetSupplierID = ps.SupplierID;
                        CurrentPartsToBeCredited.SetPartID = row["PartProductID"];
                        CurrentPartsToBeCredited.SetQty = row["Quantity"];
                        CurrentPartsToBeCredited.SetStatusID = Conversions.ToInteger(Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return);
                        CurrentPartsToBeCredited.SetManuallyAdded = false;
                        CurrentPartsToBeCredited.SetOrderReference = App.DB.Order.Order_Get(op.OrderID).OrderReference;
                        App.DB.PartsToBeCredited.Insert(CurrentPartsToBeCredited);
                    }

                    if (Conversions.ToBoolean((int)row["LocationID"] > 0 & (int)row["StockTransactionType"] > 0))
                    {
                        var oPartTransaction = new PartTransactions.PartTransaction();
                        oPartTransaction.SetLocationID = row["LocationID"];
                        oPartTransaction.SetPartID = row["PartProductID"];
                        oPartTransaction.SetOrderPartID = row["OrderPartProductID"];
                        if (Conversions.ToInteger(row["StockTransactionType"]) == Conversions.ToInteger(Sys.Enums.Transaction.StockOut))
                        {
                            oPartTransaction.SetAmount = (int)row["Quantity"] * -1;
                        }
                        else
                        {
                            oPartTransaction.SetAmount = row["Quantity"];
                        }

                        oPartTransaction.SetTransactionTypeID = row["StockTransactionType"];
                        App.DB.PartTransaction.Insert(oPartTransaction);
                    }
                }
            }

            public DataView OrderStatus_Get_All()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("OrderStatus_Get_All");
                return new DataView(dt);
            }
        }
    }
}