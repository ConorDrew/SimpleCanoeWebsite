using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitPartProductAllocateds
    {
        public class EngineerVisitPartProductAllocatedSQL
        {
            private Sys.Database _database;

            public EngineerVisitPartProductAllocatedSQL(Sys.Database database)
            {
                _database = database;
            }

            public DataView EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@OrderLocationSupplierEnumValue", Sys.Enums.LocationType.Supplier, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsAllocated_GetAll_For_Engineer_Visit2");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_tblEngineerVisitPartAndProductAllocated.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(int EngineerVisitID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandText = "EngineerVisitPartsAndProductsAllocated_GetAll_For_Engineer_Visit";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@EngineerVisitID", EngineerVisitID);
                Command.Parameters.AddWithValue("@OrderLocationSupplierEnumValue", Sys.Enums.LocationType.Supplier);
                var Adapter = new System.Data.SqlClient.SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_tblEngineerVisitPartAndProductAllocated.ToString();
                return new DataView(dt);
            }

            public DataTable EngineerVisitPartAllocated_MoveVisit(int OldEngineerVisitID, int NewEngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OldEngineerVisitID", OldEngineerVisitID, true);
                _database.AddParameter("@NewEngineerVisitID", NewEngineerVisitID, true);
                return _database.ExecuteSP_DataTable("EngineerVisitPartAllocated_MoveVisit");
            }

            public void Insert(DataView PartsAndProducts, int EngineerVisitID, int JobID, System.Data.SqlClient.SqlTransaction trans)
            {
                if (PartsAndProducts.Table is object)
                {
                    // THIS IS VERY CONFUSING BUT BASICALLY I SPLITTING IT IN TWO TABLES ORDER / NOT ORDER
                    // ALP

                    var PartProductToOrder = new DataTable();
                    PartProductToOrder.Columns.Add("Type");
                    PartProductToOrder.Columns.Add("ID");
                    PartProductToOrder.Columns.Add("EngineerVisitID");
                    PartProductToOrder.Columns.Add("PartProductID");
                    PartProductToOrder.Columns.Add("Name");
                    PartProductToOrder.Columns.Add("Number");
                    PartProductToOrder.Columns.Add("Quantity");
                    PartProductToOrder.Columns.Add("OrderItemID");
                    PartProductToOrder.Columns.Add("OrderLocationTypeID");
                    PartProductToOrder.Columns.Add("SellPrice");
                    var PartProductNOTToOrder = new DataTable();
                    PartProductNOTToOrder.Columns.Add("Type");
                    PartProductNOTToOrder.Columns.Add("ID");
                    PartProductNOTToOrder.Columns.Add("EngineerVisitID");
                    PartProductNOTToOrder.Columns.Add("PartProductID");
                    PartProductNOTToOrder.Columns.Add("Name");
                    PartProductNOTToOrder.Columns.Add("Number");
                    PartProductNOTToOrder.Columns.Add("Quantity");
                    PartProductNOTToOrder.Columns.Add("OrderItemID");
                    PartProductNOTToOrder.Columns.Add("OrderLocationTypeID");
                    PartProductNOTToOrder.Columns.Add("SellPrice");
                    string msgStr = "";
                    foreach (DataRow row in PartsAndProducts.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["OrderItemID"], 0, false)))
                        {
                            msgStr += Conversions.ToString(Conversions.ToString(" * " + row["Name"] + ", ") + row["Number"] + ", ") + row["Quantity"] + Constants.vbCrLf;
                            DataRow ppr;
                            ppr = PartProductToOrder.NewRow();
                            ppr["Type"] = row["Type"];
                            ppr["ID"] = row["ID"];
                            ppr["EngineerVisitID"] = EngineerVisitID;
                            ppr["PartProductID"] = row["PartProductID"];
                            ppr["Name"] = row["Name"];
                            ppr["Number"] = row["Number"];
                            ppr["Quantity"] = row["Quantity"];
                            ppr["OrderItemID"] = row["OrderItemID"];
                            ppr["OrderLocationTypeID"] = row["OrderLocationTypeID"];
                            ppr["SellPrice"] = row["SellPrice"];
                            PartProductToOrder.Rows.Add(ppr);
                        }
                        else
                        {
                            DataRow ppr;
                            ppr = PartProductNOTToOrder.NewRow();
                            ppr["Type"] = row["Type"];
                            ppr["ID"] = row["ID"];
                            ppr["EngineerVisitID"] = EngineerVisitID;
                            ppr["PartProductID"] = row["PartProductID"];
                            ppr["Name"] = row["Name"];
                            ppr["Number"] = row["Number"];
                            ppr["Quantity"] = row["Quantity"];
                            ppr["OrderItemID"] = row["OrderItemID"];
                            ppr["OrderLocationTypeID"] = row["OrderLocationTypeID"];
                            ppr["SellPrice"] = row["SellPrice"];
                            PartProductNOTToOrder.Rows.Add(ppr);
                        }
                    }

                    // DO THEY WANT TO ORDER NOW?
                    if (msgStr.Length > 0)
                    {
                        if (MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: " + Constants.vbCrLf + msgStr + Constants.vbCrLf + " Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.ShowForm(typeof(FRMConvertToAnOrder), true, new object[] { Conversions.ToInteger(Sys.Enums.OrderType.Job), JobID, new DataView(PartProductToOrder), 0, EngineerVisitID, trans });
                        }
                    }

                    // DELETE EVERYTHING

                    var Command = new System.Data.SqlClient.SqlCommand();
                    Command.CommandText = "EngineerVisitPartsAndProductsAllocated_Delete";
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Transaction = trans;
                    Command.Connection = trans.Connection;
                    Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID));
                    Command.ExecuteNonQuery();

                    // CYCLE THROUGH NOT ORDERS
                    foreach (DataRow row in PartProductNOTToOrder.Rows)
                        InsertOne(EngineerVisitID, Conversions.ToString(row["Type"]), Conversions.ToInteger(row["Quantity"]), Conversions.ToInteger(row["OrderItemID"]), Conversions.ToInteger(row["PartProductID"]), Conversions.ToInteger(row["OrderLocationTypeID"]), trans);

                    // CYCLE THROUGH ORDERS
                    foreach (DataRow row in PartProductToOrder.Rows)
                    {
                        row.AcceptChanges();
                        if (Information.IsDBNull(row["Quantity"]))
                        {
                            row["Quantity"] = row["QuantityToOrder"];
                        }

                        InsertOne(EngineerVisitID, Conversions.ToString(row["Type"]), Conversions.ToInteger(row["Quantity"]), Conversions.ToInteger(row["OrderItemID"]), Conversions.ToInteger(row["PartProductID"]), Sys.Helper.MakeIntegerValid(row["OrderLocationTypeID"]), trans);
                    }
                }
            }

            public void NewInsert(DataView PartsAndProducts, int EngineerVisitID, int JobID, System.Data.SqlClient.SqlTransaction trans)
            {
                if (PartsAndProducts.Table is object)
                {
                    // 'DELETE EVERYTHING

                    // Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                    // Command.CommandText = "EngineerVisitPartsAndProductsAllocated_Delete"
                    // Command.CommandType = CommandType.StoredProcedure
                    // Command.Transaction = trans
                    // Command.Connection = trans.Connection

                    // Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID))
                    // Command.ExecuteNonQuery()

                    // CYCLE THROUGH NOT ORDERS
                    foreach (DataRow row in PartsAndProducts.Table.Rows)
                    {
                        int allocationID = InsertOne(EngineerVisitID, Conversions.ToString(row["Type"]), Conversions.ToInteger(row["Quantity"]), 0, Conversions.ToInteger(row["PartProductID"]), 0, trans);
                        row["ID"] = allocationID;
                        row.AcceptChanges();
                    }
                }
            }

            public void SplitToOrder(DataView PartsAndProducts, int EngineerVisitID, int JobID)
            {
                if (PartsAndProducts.Table is object)
                {
                    // THIS IS VERY CONFUSING BUT BASICALLY I SPLITTING IT IN TWO TABLES ORDER / NOT ORDER
                    // ALP

                    var PartProductToOrder = new DataTable();
                    PartProductToOrder.Columns.Add("Type");
                    PartProductToOrder.Columns.Add("ID");
                    PartProductToOrder.Columns.Add("EngineerVisitID");
                    PartProductToOrder.Columns.Add("PartProductID");
                    PartProductToOrder.Columns.Add("Name");
                    PartProductToOrder.Columns.Add("Number");
                    PartProductToOrder.Columns.Add("Quantity");
                    PartProductToOrder.Columns.Add("OrderItemID");
                    PartProductToOrder.Columns.Add("OrderLocationTypeID");
                    PartProductToOrder.Columns.Add("SellPrice");
                    var PartProductNOTToOrder = new DataTable();
                    PartProductNOTToOrder.Columns.Add("Type");
                    PartProductNOTToOrder.Columns.Add("ID");
                    PartProductNOTToOrder.Columns.Add("EngineerVisitID");
                    PartProductNOTToOrder.Columns.Add("PartProductID");
                    PartProductNOTToOrder.Columns.Add("Name");
                    PartProductNOTToOrder.Columns.Add("Number");
                    PartProductNOTToOrder.Columns.Add("Quantity");
                    PartProductNOTToOrder.Columns.Add("OrderItemID");
                    PartProductNOTToOrder.Columns.Add("OrderLocationTypeID");
                    PartProductNOTToOrder.Columns.Add("SellPrice");
                    string msgStr = "";
                    foreach (DataRow row in PartsAndProducts.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["OrderItemID"], 0, false)))
                        {
                            msgStr += Conversions.ToString(Conversions.ToString(" * " + row["Name"] + ", ") + row["Number"] + ", ") + row["Quantity"] + Constants.vbCrLf;
                            DataRow ppr;
                            ppr = PartProductToOrder.NewRow();
                            ppr["Type"] = row["Type"];
                            ppr["ID"] = row["ID"];
                            ppr["EngineerVisitID"] = EngineerVisitID;
                            ppr["PartProductID"] = row["PartProductID"];
                            ppr["Name"] = row["Name"];
                            ppr["Number"] = row["Number"];
                            ppr["Quantity"] = row["Quantity"];
                            ppr["OrderItemID"] = row["OrderItemID"];
                            ppr["OrderLocationTypeID"] = row["OrderLocationTypeID"];
                            ppr["SellPrice"] = row["SellPrice"];
                            PartProductToOrder.Rows.Add(ppr);
                        }
                        else
                        {
                            DataRow ppr;
                            ppr = PartProductNOTToOrder.NewRow();
                            ppr["Type"] = row["Type"];
                            ppr["ID"] = row["ID"];
                            ppr["EngineerVisitID"] = EngineerVisitID;
                            ppr["PartProductID"] = row["PartProductID"];
                            ppr["Name"] = row["Name"];
                            ppr["Number"] = row["Number"];
                            ppr["Quantity"] = row["Quantity"];
                            ppr["OrderItemID"] = row["OrderItemID"];
                            ppr["OrderLocationTypeID"] = row["OrderLocationTypeID"];
                            ppr["SellPrice"] = row["SellPrice"];
                            PartProductNOTToOrder.Rows.Add(ppr);
                        }
                    }

                    // DO THEY WANT TO ORDER NOW?
                    if (msgStr.Length > 0)
                    {
                        if (MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: " + Constants.vbCrLf + msgStr + Constants.vbCrLf + " Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.ShowForm(typeof(FRMConvertToAnOrder), true, new object[] { Conversions.ToInteger(Sys.Enums.OrderType.Job), JobID, new DataView(PartProductToOrder), 0, EngineerVisitID, true });
                        }
                    }
                }
            }

            public void Insert(DataView PartsAndProducts, int EngineerVisitID, int JobID)
            {
                if (PartsAndProducts.Table is object)
                {
                    // THIS IS VERY CONFUSING BUT BASICALLY I SPLITTING IT IN TWO TABLES ORDER / NOT ORDER
                    // ALP

                    var PartProductToOrder = new DataTable();
                    PartProductToOrder.Columns.Add("Type");
                    PartProductToOrder.Columns.Add("ID");
                    PartProductToOrder.Columns.Add("EngineerVisitID");
                    PartProductToOrder.Columns.Add("PartProductID");
                    PartProductToOrder.Columns.Add("Name");
                    PartProductToOrder.Columns.Add("Number");
                    PartProductToOrder.Columns.Add("Quantity");
                    PartProductToOrder.Columns.Add("OrderItemID");
                    PartProductToOrder.Columns.Add("OrderLocationTypeID");
                    PartProductToOrder.Columns.Add("SellPrice");
                    var PartProductNOTToOrder = new DataTable();
                    PartProductNOTToOrder.Columns.Add("Type");
                    PartProductNOTToOrder.Columns.Add("ID");
                    PartProductNOTToOrder.Columns.Add("EngineerVisitID");
                    PartProductNOTToOrder.Columns.Add("PartProductID");
                    PartProductNOTToOrder.Columns.Add("Name");
                    PartProductNOTToOrder.Columns.Add("Number");
                    PartProductNOTToOrder.Columns.Add("Quantity");
                    PartProductNOTToOrder.Columns.Add("OrderItemID");
                    PartProductNOTToOrder.Columns.Add("OrderLocationTypeID");
                    PartProductNOTToOrder.Columns.Add("SellPrice");
                    string msgStr = "";
                    foreach (DataRow row in PartsAndProducts.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["OrderItemID"], 0, false)))
                        {
                            msgStr += Conversions.ToString(Conversions.ToString(" * " + row["Name"] + ", ") + row["Number"] + ", ") + row["Quantity"] + Constants.vbCrLf;
                            DataRow ppr;
                            ppr = PartProductToOrder.NewRow();
                            ppr["Type"] = row["Type"];
                            ppr["ID"] = row["ID"];
                            ppr["EngineerVisitID"] = EngineerVisitID;
                            ppr["PartProductID"] = row["PartProductID"];
                            ppr["Name"] = row["Name"];
                            ppr["Number"] = row["Number"];
                            ppr["Quantity"] = row["Quantity"];
                            ppr["OrderItemID"] = row["OrderItemID"];
                            ppr["OrderLocationTypeID"] = row["OrderLocationTypeID"];
                            ppr["SellPrice"] = row["SellPrice"];
                            PartProductToOrder.Rows.Add(ppr);
                        }
                        else
                        {
                            DataRow ppr;
                            ppr = PartProductNOTToOrder.NewRow();
                            ppr["Type"] = row["Type"];
                            ppr["ID"] = row["ID"];
                            ppr["EngineerVisitID"] = EngineerVisitID;
                            ppr["PartProductID"] = row["PartProductID"];
                            ppr["Name"] = row["Name"];
                            ppr["Number"] = row["Number"];
                            ppr["Quantity"] = row["Quantity"];
                            ppr["OrderItemID"] = row["OrderItemID"];
                            ppr["OrderLocationTypeID"] = row["OrderLocationTypeID"];
                            ppr["SellPrice"] = row["SellPrice"];
                            PartProductNOTToOrder.Rows.Add(ppr);
                        }
                    }

                    // DO THEY WANT TO ORDER NOW?
                    if (msgStr.Length > 0)
                    {
                        if (MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: " + Constants.vbCrLf + msgStr + Constants.vbCrLf + " Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            App.ShowForm(typeof(FRMConvertToAnOrder), true, new object[] { Conversions.ToInteger(Sys.Enums.OrderType.Job), JobID, new DataView(PartProductToOrder), 0, EngineerVisitID });
                        }
                    }

                    // DELETE EVERYTHING
                    _database.ClearParameter();
                    _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                    _database.ExecuteSP_OBJECT("EngineerVisitPartsAndProductsAllocated_Delete");

                    // CYCLE THROUGH NOT ORDERS
                    foreach (DataRow row in PartProductNOTToOrder.Rows)
                        InsertOne(EngineerVisitID, Conversions.ToString(row["Type"]), Conversions.ToInteger(row["Quantity"]), Conversions.ToInteger(row["OrderItemID"]), Conversions.ToInteger(row["PartProductID"]), Conversions.ToInteger(row["OrderLocationTypeID"]));

                    // CYCLE THROUGH ORDERS
                    foreach (DataRow row in PartProductToOrder.Rows)
                    {
                        row.AcceptChanges();
                        if (Information.IsDBNull(row["Quantity"]))
                        {
                            row["Quantity"] = row["QuantityToOrder"];
                        }

                        InsertOne(EngineerVisitID, Conversions.ToString(row["Type"]), Conversions.ToInteger(row["Quantity"]), Conversions.ToInteger(row["OrderItemID"]), Conversions.ToInteger(row["PartProductID"]), Sys.Helper.MakeIntegerValid(row["OrderLocationTypeID"]));
                    }
                }
            }

            public void InsertOne(int EngineerVisitID, string type, int Quantity, int OrderItemID, int PartProductID, int OrderLocationTypeID)
            {
                string spToRun = "";
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@Quantity", Quantity, true);
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, true);
                switch (type)
                {
                    case "Part":
                        {
                            _database.AddParameter("@PartID", PartProductID, true);
                            _database.AddParameter("@OrderPartID", OrderItemID, true);
                            spToRun = "EngineerVisitPartAllocated_Insert";
                            break;
                        }

                    case "Product":
                        {
                            _database.AddParameter("@ProductID", PartProductID, true);
                            _database.AddParameter("@OrderProductID", OrderItemID, true);
                            spToRun = "EngineerVisitProductAllocated_Insert";
                            break;
                        }
                }

                _database.ExecuteSP_OBJECT(spToRun);
            }

            public int InsertOne(int EngineerVisitID, string type, int Quantity, int OrderItemID, int PartProductID, int OrderLocationTypeID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandType = CommandType.StoredProcedure;
                switch (type)
                {
                    case "Part":
                        {
                            Command.CommandText = "EngineerVisitPartAllocated_Insert";
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PartID", PartProductID));
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderPartID", OrderItemID));
                            break;
                        }

                    case "Product":
                        {
                            Command.CommandText = "EngineerVisitProductAllocated_Insert";
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProductID", PartProductID));
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderProductID", OrderItemID));
                            break;
                        }
                }

                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", Quantity));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderLocationTypeID", OrderLocationTypeID));
                return Conversions.ToInteger(Command.ExecuteScalar());
            }

            public void UpdateOne(int AllocationID, int EngineerVisitID, string type, int Quantity, int OrderItemID, int PartProductID, int OrderLocationTypeID)
            {
                string spToRun = "";
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@Quantity", Quantity, true);
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, true);
                switch (type)
                {
                    case "Part":
                        {
                            _database.AddParameter("@EngineerVisitPartAllocatedID", AllocationID, true);
                            _database.AddParameter("@PartID", PartProductID, true);
                            _database.AddParameter("@OrderPartID", OrderItemID, true);
                            spToRun = "EngineerVisitPartAllocated_Update";
                            break;
                        }

                    case "Product":
                        {
                            _database.AddParameter("@EngineerVisitProductAllocatedID", AllocationID, true);
                            _database.AddParameter("@ProductID", PartProductID, true);
                            _database.AddParameter("@OrderProductID", OrderItemID, true);
                            spToRun = "EngineerVisitProductAllocated_Update";
                            break;
                        }
                }

                _database.ExecuteSP_OBJECT(spToRun);
            }

            public void UpdateOne(int AllocationID, int EngineerVisitID, string type, int Quantity, int OrderItemID, int PartProductID, int OrderLocationTypeID, System.Data.SqlClient.SqlTransaction trans)
            {
                var Command = new System.Data.SqlClient.SqlCommand();
                Command.CommandType = CommandType.StoredProcedure;
                switch (type)
                {
                    case "Part":
                        {
                            Command.CommandText = "EngineerVisitPartAllocated_Update";
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerVisitPartAllocatedID", AllocationID));
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PartID", PartProductID));
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderPartID", OrderItemID));
                            break;
                        }

                    case "Product":
                        {
                            Command.CommandText = "EngineerVisitProductAllocated_Update";
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerVisitProductAllocatedID", AllocationID));
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProductID", PartProductID));
                            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderProductID", OrderItemID));
                            break;
                        }
                }

                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", Quantity));
                Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderLocationTypeID", OrderLocationTypeID));
                Command.ExecuteNonQuery();
            }

            public void EngineerVisitProductAllocated_Delete(int OrderLocationTypeID, int OrderProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderProductID", OrderProductID, true);
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, true);
                _database.AddParameter("@SupplierOrderLocationEnumValue", Conversions.ToInteger(Sys.Enums.LocationType.Supplier), true);
                App.DB.ExecuteSP_NO_Return("EngineerVisitProductAllocated_Delete");
            }

            public void EngineerVisitPartAllocated_RemoveFromOrder(int OrderLocationTypeID, int OrderPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", OrderPartID, true);
                _database.AddParameter("@OrderLocationTypeID", OrderLocationTypeID, true);
                _database.AddParameter("@SupplierOrderLocationEnumValue", Conversions.ToInteger(Sys.Enums.LocationType.Supplier), true);
                App.DB.ExecuteSP_NO_Return("EngineerVisitPartAllocated_RemoveFromOrder");
            }

            public DataView Get_ByJobId(int jobId)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartAllocated_Get_ByJobId");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
                return new DataView(dt);
            }
        }
    }
}