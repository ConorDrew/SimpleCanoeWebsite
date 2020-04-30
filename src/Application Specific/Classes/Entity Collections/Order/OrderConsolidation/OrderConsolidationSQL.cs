using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderConsolidations
    {
        public class OrderConsolidationSQL
        {
            private Sys.Database _database;

            public OrderConsolidationSQL(Sys.Database database)
            {
                _database = database;
            }

            public void OrderConsolidation_Clear_Orders(int OrderConsolidationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, true);
                _database.ExecuteSP_NO_Return("OrderConsolidation_Clear_Orders");
            }

            public void Order_Set_Consolidated(int OrderConsolidationID, int OrderID, bool ReleaseConsolidated)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, true);
                _database.AddParameter("@OrderID", OrderID, true);
                if (ReleaseConsolidated)
                {
                    _database.AddParameter("@ReleaseConsolidated", 1, true);
                }
                else
                {
                    _database.AddParameter("@ReleaseConsolidated", 0, true);
                }

                _database.ExecuteSP_NO_Return("Order_Set_Consolidated");
            }

            public void Order_Set_Consolidated(int OrderConsolidationID, int OrderID, bool ReleaseConsolidated, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Order_Set_Consolidated";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderConsolidationID", OrderConsolidationID);
                Command.Parameters.AddWithValue("@OrderID", OrderID);
                if (ReleaseConsolidated)
                {
                    Command.Parameters.AddWithValue("@ReleaseConsolidated", 1);
                }
                else
                {
                    Command.Parameters.AddWithValue("@ReleaseConsolidated", 0);
                }

                Command.ExecuteNonQuery();
            }

            public OrderConsolidation OrderConsolidation_Get(int OrderConsolidationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("OrderConsolidation_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderConsolidation = new OrderConsolidation();
                        oOrderConsolidation.IgnoreExceptionsOnSetMethods = true;
                        oOrderConsolidation.SetOrderConsolidationID = dt.Rows[0]["OrderConsolidationID"];
                        oOrderConsolidation.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oOrderConsolidation.SetLocationID = dt.Rows[0]["LocationID"];
                        oOrderConsolidation.ConsolidationDate = Conversions.ToDate(dt.Rows[0]["ConsolidationDate"]);
                        oOrderConsolidation.SetConsolidationRef = dt.Rows[0]["ConsolidationRef"];
                        oOrderConsolidation.SetComments = dt.Rows[0]["Comments"];
                        oOrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(dt.Rows[0]["ConsolidatedOrderStatusID"]);
                        oOrderConsolidation.HasSupplierPO = Conversions.ToBoolean(dt.Rows[0]["HasSupplierPO"]);
                        oOrderConsolidation.SetSupplierInvoiceReference = dt.Rows[0]["SupplierInvoiceReference"];
                        oOrderConsolidation.SupplierInvoiceDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["SupplierInvoiceDate"]);
                        oOrderConsolidation.SetSupplierInvoiceAmount = dt.Rows[0]["SupplierInvoiceAmount"];
                        oOrderConsolidation.SetVATAmount = dt.Rows[0]["VATAmount"];
                        oOrderConsolidation.SetTaxCodeID = dt.Rows[0]["TaxCodeID"];
                        oOrderConsolidation.SetExtraRef = dt.Rows[0]["ExtraRef"];
                        oOrderConsolidation.SetNominalCode = dt.Rows[0]["NominalCode"];
                        oOrderConsolidation.SetDepartmentRef = dt.Rows[0]["DepartmentRef"];
                        oOrderConsolidation.SetReadyToSendToSage = Conversions.ToBoolean(dt.Rows[0]["ReadyToSendToSage"]);
                        oOrderConsolidation.SetSentToSage = dt.Rows[0]["SentToSage"];
                        oOrderConsolidation.DateExported = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["DateExported"]);
                        oOrderConsolidation.Exists = true;
                        return oOrderConsolidation;
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

            public DataView Order_GetForConsolidation(int SupplierID, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierID", SupplierID, true);
                _database.AddParameter("@LocationID", LocationID, true);
                var dt = _database.ExecuteSP_DataTable("[Order_GetForConsolidation]");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView Order_GetForConsolidationByID(int OrderConsolidationID, int SupplierID, int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, true);
                _database.AddParameter("@SupplierID", SupplierID, true);
                _database.AddParameter("@LocationID", LocationID, true);
                var dt = _database.ExecuteSP_DataTable("[Order_GetForConsolidationByID]");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataView Order_GetForConsolidationByID_Confirmed(int OrderConsolidationID, bool ForLocation)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, true);
                if (ForLocation)
                {
                    _database.AddParameter("@ForLocation", 1, true);
                }
                else
                {
                    _database.AddParameter("@ForLocation", 0, true);
                }

                var dt = _database.ExecuteSP_DataTable("[Order_GetForConsolidationByID_Confirmed]");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public void Create_And_Insert_Supplier(int PartSupplierID, int ProductSupplierID, int OrderID)
            {
                int supplierID = 0;
                try
                {
                    if (!(PartSupplierID == 0))
                    {
                        supplierID = App.DB.PartSupplier.PartSupplier_Get(PartSupplierID).SupplierID;
                    }
                    else if (!(ProductSupplierID == 0))
                    {
                        supplierID = App.DB.ProductSupplier.ProductSupplier_Get(ProductSupplierID).SupplierID;
                    }

                    if (supplierID == 0)
                    {
                        throw new Exception("Supplier could not be determined");
                    }
                    else
                    {
                        int OrderConsolidationID = 0;
                        OrderConsolidationID = App.DB.Order.Order_Get(OrderID).OrderConsolidationID;
                        if (OrderConsolidationID == 0)
                        {
                            _database.ClearParameter();
                            _database.AddParameter("@SupplierID", supplierID, true);
                            _database.AddParameter("@LocationID", 0, true);
                            OrderConsolidationID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderConsolidation_Check_If_Exists"));
                        }

                        if (OrderConsolidationID == 0)
                        {
                            var oOrderConsolidation = new OrderConsolidation();
                            oOrderConsolidation.SetSupplierID = supplierID;
                            oOrderConsolidation.SetComments = "Automatically Created";
                            oOrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(Sys.Enums.OrderStatus.AwaitingConfirmation);
                            var OrderNumber = App.DB.Job.GetNextJobNumber(Sys.Enums.JobDefinition.CONSOLIDATION);
                            OrderNumber.OrderNumber = OrderNumber.Number.ToString();
                            while (OrderNumber.OrderNumber.Length < 5)
                                OrderNumber.OrderNumber = "0" + OrderNumber.OrderNumber;
                            string typePrefix = "W";
                            string userPrefix = "";
                            var username = App.loggedInUser.Fullname.Split(' ');
                            foreach (string s in username)
                                userPrefix += s.Substring(0, 1);
                            OrderNumber.OrderNumber = userPrefix + typePrefix + OrderNumber.OrderNumber;
                            oOrderConsolidation.SetConsolidationRef = OrderNumber.OrderNumber;
                            OrderConsolidationID = Insert(oOrderConsolidation);
                        }

                        Order_Set_Consolidated(OrderConsolidationID, OrderID, false);
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Consolidation could not be created:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void Create_And_Insert_Supplier(int PartSupplierID, int ProductSupplierID, int OrderID, SqlTransaction trans)
            {
                int supplierID = 0;
                try
                {
                    if (!(PartSupplierID == 0))
                    {
                        supplierID = App.DB.PartSupplier.PartSupplier_Get(PartSupplierID, trans).SupplierID;
                    }
                    else if (!(ProductSupplierID == 0))
                    {
                        supplierID = App.DB.ProductSupplier.ProductSupplier_Get(ProductSupplierID, trans).SupplierID;
                    }

                    if (supplierID == 0)
                    {
                        throw new Exception("Supplier could not be determined");
                    }
                    else
                    {
                        int OrderConsolidationID = 0;
                        OrderConsolidationID = App.DB.Order.Order_Get(OrderID, trans).OrderConsolidationID;
                        if (OrderConsolidationID == 0)
                        {
                            var Command = new SqlCommand();
                            Command.CommandText = "OrderConsolidation_Check_If_Exists";
                            Command.CommandType = CommandType.StoredProcedure;
                            Command.Transaction = trans;
                            Command.Connection = trans.Connection;
                            Command.Parameters.AddWithValue("@SupplierID", supplierID);
                            Command.Parameters.AddWithValue("@LocationID", 0);
                            OrderConsolidationID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                        }

                        if (OrderConsolidationID == 0)
                        {
                            var oOrderConsolidation = new OrderConsolidation();
                            oOrderConsolidation.SetSupplierID = supplierID;
                            oOrderConsolidation.SetComments = "Automatically Created";
                            oOrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(Sys.Enums.OrderStatus.AwaitingConfirmation);
                            var OrderNumber = App.DB.Job.GetNextJobNumber(Sys.Enums.JobDefinition.CONSOLIDATION, trans);
                            OrderNumber.OrderNumber = OrderNumber.Number.ToString();
                            while (OrderNumber.OrderNumber.Length < 5)
                                OrderNumber.OrderNumber = "0" + OrderNumber.OrderNumber;
                            string typePrefix = "W";
                            string userPrefix = "";
                            var username = App.loggedInUser.Fullname.Split(' ');
                            foreach (string s in username)
                                userPrefix += s.Substring(0, 1);
                            OrderNumber.OrderNumber = userPrefix + typePrefix + OrderNumber.OrderNumber;
                            oOrderConsolidation.SetConsolidationRef = OrderNumber.OrderNumber;
                            OrderConsolidationID = Insert(oOrderConsolidation, trans);
                        }

                        Order_Set_Consolidated(OrderConsolidationID, OrderID, false, trans);
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Consolidation could not be created:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void Create_And_Insert_Location(int LocationID, int OrderID, SqlTransaction trans)
            {
                try
                {
                    if (LocationID == 0)
                    {
                        throw new Exception("Location could not be determined");
                    }
                    else
                    {
                        int OrderConsolidationID = 0;
                        OrderConsolidationID = App.DB.Order.Order_Get(OrderID, trans).OrderConsolidationID;
                        if (OrderConsolidationID == 0)
                        {
                            var Command = new SqlCommand();
                            Command.CommandText = "OrderConsolidation_Check_If_Exists";
                            Command.CommandType = CommandType.StoredProcedure;
                            Command.Transaction = trans;
                            Command.Connection = trans.Connection;
                            Command.Parameters.AddWithValue("@SupplierID", 0);
                            Command.Parameters.AddWithValue("@LocationID", LocationID);
                            OrderConsolidationID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                        }

                        if (OrderConsolidationID == 0)
                        {
                            var oOrderConsolidation = new OrderConsolidation();
                            oOrderConsolidation.SetLocationID = LocationID;
                            oOrderConsolidation.SetComments = "Automatically Created";
                            oOrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(Sys.Enums.OrderStatus.AwaitingConfirmation);
                            var OrderNumber = App.DB.Job.GetNextJobNumber(Sys.Enums.JobDefinition.CONSOLIDATION, trans);
                            OrderNumber.OrderNumber = OrderNumber.Number.ToString();
                            while (OrderNumber.OrderNumber.Length < 6)
                                OrderNumber.OrderNumber = "0" + OrderNumber.OrderNumber;
                            oOrderConsolidation.SetConsolidationRef = OrderNumber.Prefix + OrderNumber.OrderNumber;
                            OrderConsolidationID = Insert(oOrderConsolidation, trans);
                        }

                        Order_Set_Consolidated(OrderConsolidationID, OrderID, false, trans);
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Consolidation could not be created:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void Create_And_Insert_Location(int LocationID, int OrderID)
            {
                try
                {
                    if (LocationID == 0)
                    {
                        throw new Exception("Location could not be determined");
                    }
                    else
                    {
                        int OrderConsolidationID = 0;
                        OrderConsolidationID = App.DB.Order.Order_Get(OrderID).OrderConsolidationID;
                        if (OrderConsolidationID == 0)
                        {
                            _database.ClearParameter();
                            _database.AddParameter("@SupplierID", 0, true);
                            _database.AddParameter("@LocationID", LocationID, true);
                            OrderConsolidationID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderConsolidation_Check_If_Exists"));
                        }

                        if (OrderConsolidationID == 0)
                        {
                            var oOrderConsolidation = new OrderConsolidation();
                            oOrderConsolidation.SetLocationID = LocationID;
                            oOrderConsolidation.SetComments = "Automatically Created";
                            oOrderConsolidation.SetConsolidatedOrderStatusID = Conversions.ToInteger(Sys.Enums.OrderStatus.AwaitingConfirmation);
                            var OrderNumber = App.DB.Job.GetNextJobNumber(Sys.Enums.JobDefinition.CONSOLIDATION);
                            OrderNumber.OrderNumber = OrderNumber.Number.ToString();
                            while (OrderNumber.OrderNumber.Length < 6)
                                OrderNumber.OrderNumber = "0" + OrderNumber.OrderNumber;
                            oOrderConsolidation.SetConsolidationRef = OrderNumber.Prefix + OrderNumber.OrderNumber;
                            OrderConsolidationID = Insert(oOrderConsolidation);
                        }

                        Order_Set_Consolidated(OrderConsolidationID, OrderID, false);
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Consolidation could not be created:" + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public int Insert(OrderConsolidation oOrderConsolidation)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierID", oOrderConsolidation.SupplierID, true);
                _database.AddParameter("@LocationID", oOrderConsolidation.LocationID, true);
                _database.AddParameter("@ConsolidationRef", oOrderConsolidation.ConsolidationRef, true);
                _database.AddParameter("@Comments", oOrderConsolidation.Comments, true);
                _database.AddParameter("@ConsolidatedOrderStatusID", oOrderConsolidation.ConsolidatedOrderStatusID, true);
                oOrderConsolidation.SetOrderConsolidationID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderConsolidation_Insert"));
                oOrderConsolidation.Exists = true;
                return oOrderConsolidation.OrderConsolidationID;
            }

            public int Insert(OrderConsolidation oOrderConsolidation, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "OrderConsolidation_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@SupplierID", oOrderConsolidation.SupplierID);
                Command.Parameters.AddWithValue("@LocationID", oOrderConsolidation.LocationID);
                Command.Parameters.AddWithValue("@ConsolidationRef", oOrderConsolidation.ConsolidationRef);
                Command.Parameters.AddWithValue("@Comments", oOrderConsolidation.Comments);
                Command.Parameters.AddWithValue("@ConsolidatedOrderStatusID", oOrderConsolidation.ConsolidatedOrderStatusID);
                oOrderConsolidation.SetOrderConsolidationID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oOrderConsolidation.Exists = true;
                return oOrderConsolidation.OrderConsolidationID;
            }

            public void Update(OrderConsolidation oOrderConsolidation)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", oOrderConsolidation.OrderConsolidationID, true);
                _database.AddParameter("@Comments", oOrderConsolidation.Comments, true);
                _database.AddParameter("@ConsolidatedOrderStatusID", oOrderConsolidation.ConsolidatedOrderStatusID, true);
                if (oOrderConsolidation.HasSupplierPO)
                {
                    _database.AddParameter("@HasSupplierPO", 1, true);
                }
                else
                {
                    _database.AddParameter("@HasSupplierPO", 0, true);
                }

                _database.AddParameter("@SupplierInvoiceReference", oOrderConsolidation.SupplierInvoiceReference, true);
                if (oOrderConsolidation.SupplierInvoiceDate == default)
                {
                    _database.AddParameter("@SupplierInvoiceDate", DBNull.Value, true);
                }
                else
                {
                    _database.AddParameter("@SupplierInvoiceDate", oOrderConsolidation.SupplierInvoiceDate, true);
                }

                _database.AddParameter("@SupplierInvoiceAmount", oOrderConsolidation.SupplierInvoiceAmount, true);
                _database.AddParameter("@VATAmount", oOrderConsolidation.VATAmount, true);
                _database.AddParameter("@TaxCodeID", oOrderConsolidation.TaxCodeID, true);
                _database.AddParameter("@ExtraRef", oOrderConsolidation.ExtraRef, true);
                _database.AddParameter("@NominalCode", oOrderConsolidation.NominalCode, true);
                _database.AddParameter("@DepartmentRef", oOrderConsolidation.DepartmentRef, true);
                if (oOrderConsolidation.ReadyToSendToSage)
                {
                    _database.AddParameter("@ReadyToSendToSage", 1, true);
                }
                else
                {
                    _database.AddParameter("@ReadyToSendToSage", 0, true);
                }

                _database.ExecuteSP_NO_Return("OrderConsolidation_Update");
            }

            public DataView Order_GetItemForConsolidationID(int OrderConsolidationID, bool ForLocation)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, true);
                if (ForLocation)
                {
                    _database.AddParameter("@ForLocation", 1, true);
                }
                else
                {
                    _database.AddParameter("@ForLocation", 0, true);
                }

                var dt = _database.ExecuteSP_DataTable("[Order_GetItemForConsolidationID]");
                dt.TableName = Sys.Enums.TableNames.tblOrder.ToString();
                return new DataView(dt);
            }

            public DataSet Orders_Complete_ByConsolidationOrderID(int OrderConsolidationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, true);
                return _database.ExecuteSP_DataSet("[Orders_Complete_ByConsolidationOrderID]");
            }
        }
    }
}