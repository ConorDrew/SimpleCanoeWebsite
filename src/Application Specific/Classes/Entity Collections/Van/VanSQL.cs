using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Vans
    {
        public class VanSQL
        {
            private Sys.Database _database;

            public VanSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int VanID, bool DeleteFromWarehouses = false)
            {
                if (DeleteFromWarehouses)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@VanID", VanID, true);
                    _database.ExecuteSP_NO_Return("Van_Delete");
                }
                else
                {
                    string registration = Van_Get(VanID).Registration.Split('*')[0].Trim();
                    foreach (DataRow row in Van_GetAll_incDeleted(false).Table.Rows)
                    {
                        if ((Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() ?? "") == (registration ?? ""))
                        {
                            _database.ClearParameter();
                            _database.AddParameter("@VanID", row["VanID"], true);
                            _database.ExecuteSP_NO_Return("Van_Delete");
                        }
                    }
                }
            }

            public DataView Van_GetDV(int VanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", VanID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Van_Get");
                dt.TableName = Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(dt);
            }

            public Van Van_Get(int VanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", VanID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Van_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new Van();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetRegistration = dt.Rows[0]["Registration"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.InsuranceDue = Conversions.ToDate(dt.Rows[0]["InsuranceDue"]);
                        oVan.MOTDue = Conversions.ToDate(dt.Rows[0]["MOTDue"]);
                        oVan.TaxDue = Conversions.ToDate(dt.Rows[0]["TaxDue"]);
                        oVan.ServiceDue = Conversions.ToDate(dt.Rows[0]["ServiceDue"]);
                        oVan.SetMileageLimit = dt.Rows[0]["MileageLimit"];
                        oVan.SetPeriodValue = dt.Rows[0]["PeriodValue"];
                        oVan.SetPeriodType = dt.Rows[0]["PeriodType"];
                        oVan.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oVan.SetPreferredSupplierID = dt.Rows[0]["PreferredSupplierID"];
                        oVan.SetExcludeFromAutoReplenishment = Conversions.ToBoolean(dt.Rows[0]["ExcludeFromAutoReplenishment"]);
                        oVan.SetEngineerVanID = dt.Rows[0]["EngineerVanID"];
                        oVan.SecondaryPrice = Sys.Helper.MakeBooleanValid(dt.Rows[0]["SecondaryPrice"]);
                        oVan.SetUseContainerStock = Sys.Helper.MakeBooleanValid(dt.Rows[0]["UseContainerStock"]);
                        oVan.Exists = true;
                        return oVan;
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

            public Van Van_GetByLocationID(int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Van_GetByLocationID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new Van();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetRegistration = dt.Rows[0]["Registration"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.InsuranceDue = Conversions.ToDate(dt.Rows[0]["InsuranceDue"]);
                        oVan.MOTDue = Conversions.ToDate(dt.Rows[0]["MOTDue"]);
                        oVan.TaxDue = Conversions.ToDate(dt.Rows[0]["TaxDue"]);
                        oVan.ServiceDue = Conversions.ToDate(dt.Rows[0]["ServiceDue"]);
                        oVan.SetMileageLimit = dt.Rows[0]["MileageLimit"];
                        oVan.SetPeriodValue = dt.Rows[0]["PeriodValue"];
                        oVan.SetPeriodType = dt.Rows[0]["PeriodType"];
                        oVan.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oVan.SetPreferredSupplierID = dt.Rows[0]["PreferredSupplierID"];
                        oVan.SetExcludeFromAutoReplenishment = Conversions.ToBoolean(dt.Rows[0]["ExcludeFromAutoReplenishment"]);
                        oVan.SetUseContainerStock = Sys.Helper.MakeBooleanValid(dt.Rows[0]["UseContainerStock"]);
                        oVan.Exists = true;
                        return oVan;
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

            public Van Van_GetByLocationID(int LocationID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Van_GetByLocationID";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@LocationID", LocationID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new Van();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetRegistration = dt.Rows[0]["Registration"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.InsuranceDue = Conversions.ToDate(dt.Rows[0]["InsuranceDue"]);
                        oVan.MOTDue = Conversions.ToDate(dt.Rows[0]["MOTDue"]);
                        oVan.TaxDue = Conversions.ToDate(dt.Rows[0]["TaxDue"]);
                        oVan.ServiceDue = Conversions.ToDate(dt.Rows[0]["ServiceDue"]);
                        oVan.SetMileageLimit = dt.Rows[0]["MileageLimit"];
                        oVan.SetPeriodValue = dt.Rows[0]["PeriodValue"];
                        oVan.SetPeriodType = dt.Rows[0]["PeriodType"];
                        oVan.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oVan.SetPreferredSupplierID = dt.Rows[0]["PreferredSupplierID"];
                        oVan.SetExcludeFromAutoReplenishment = Conversions.ToBoolean(dt.Rows[0]["ExcludeFromAutoReplenishment"]);
                        oVan.SetUseContainerStock = Sys.Helper.MakeBooleanValid(dt.Rows[0]["UseContainerStock"]);
                        oVan.Exists = true;
                        return oVan;
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

            public bool Check_Unique_Registration(string Registration, int ID)
            {
                int NumberOfVans = 0;
                foreach (DataRow row in Van_GetAll(true).Table.Rows)
                {
                    if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(row["VanID"], ID, false)))
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Registration"], Registration, false)))
                        {
                            NumberOfVans += 1;
                        }
                    }
                }

                // NumberOfVans = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(VanID) as 'NumberOfVans' " & _
                // "FROM tblVan WHERE Registration = '" & Registration & "' AND vanid <> " & ID, False))

                if (NumberOfVans == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public DataView Van_GetAll_AllLocations()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Van_GetAll_AllLocations");
                dt.TableName = Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(dt);
            }

            public DataView Van_GetAll(bool Grouped)
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Van_GetAll");
                if (Grouped)
                {
                    var returnDT = new DataTable();
                    foreach (DataColumn col in dt.Columns)
                        returnDT.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
                    foreach (DataRow row in dt.Rows)
                    {
                        bool found = false;
                        string registrationToFind = Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim();
                        foreach (DataRow groupedVan in returnDT.Rows)
                        {
                            if ((Sys.Helper.MakeStringValid(groupedVan["Registration"]).Split('*')[0].Trim() ?? "") == (registrationToFind ?? ""))
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            DataRow rowToAdd = null;
                            foreach (DataRow rowForRegistration in dt.Rows)
                            {
                                if ((Sys.Helper.MakeStringValid(rowForRegistration["Registration"]).Split('*')[0].Trim() ?? "") == (registrationToFind ?? ""))
                                {
                                    if (rowToAdd is null)
                                    {
                                        rowToAdd = rowForRegistration;
                                    }
                                    else if (Conversions.ToBoolean(rowForRegistration["VanID"] < rowToAdd["VanID"]))
                                    {
                                        rowToAdd = rowForRegistration;
                                    }
                                }
                            }

                            if (rowToAdd is object)
                            {
                                var r = returnDT.NewRow();
                                foreach (DataColumn col in returnDT.Columns)
                                {
                                    if ((col.ColumnName ?? "") == "Registration")
                                    {
                                        r[col.ColumnName] = registrationToFind;
                                    }
                                    else
                                    {
                                        r[col.ColumnName] = rowToAdd[col.ColumnName];
                                    }
                                }

                                returnDT.Rows.Add(r);
                            }
                        }
                    }

                    returnDT.Columns.Remove("InsuranceDue");
                    returnDT.Columns.Remove("MOTDue");
                    returnDT.Columns.Remove("ServiceDue");
                    returnDT.Columns.Remove("MileageLimit");
                    returnDT.Columns.Remove("PeriodValue");
                    returnDT.Columns.Remove("PeriodType");
                    returnDT.TableName = Sys.Enums.TableNames.tblVan.ToString();
                    return new DataView(returnDT);
                }
                else
                {
                    dt.TableName = Sys.Enums.TableNames.tblVan.ToString();
                    return new DataView(dt);
                }
            }

            public DataView Van_GetAll_incDeleted(bool Grouped)
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Van_GetAll_incDeleted");
                if (Grouped)
                {
                    var returnDT = new DataTable();
                    foreach (DataColumn col in dt.Columns)
                        returnDT.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
                    foreach (DataRow row in dt.Rows)
                    {
                        bool found = false;
                        string registrationToFind = Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim();
                        foreach (DataRow groupedVan in returnDT.Rows)
                        {
                            if ((Sys.Helper.MakeStringValid(groupedVan["Registration"]).Split('*')[0].Trim() ?? "") == (registrationToFind ?? ""))
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            DataRow rowToAdd = null;
                            foreach (DataRow rowForRegistration in dt.Rows)
                            {
                                if ((Sys.Helper.MakeStringValid(rowForRegistration["Registration"]).Split('*')[0].Trim() ?? "") == (registrationToFind ?? ""))
                                {
                                    if (rowToAdd is null)
                                    {
                                        rowToAdd = rowForRegistration;
                                    }
                                    else if (Conversions.ToBoolean(rowForRegistration["VanID"] < rowToAdd["VanID"]))
                                    {
                                        rowToAdd = rowForRegistration;
                                    }
                                }
                            }

                            if (rowToAdd is object)
                            {
                                var r = returnDT.NewRow();
                                foreach (DataColumn col in returnDT.Columns)
                                {
                                    if ((col.ColumnName ?? "") == "Registration")
                                    {
                                        r[col.ColumnName] = registrationToFind;
                                    }
                                    else
                                    {
                                        r[col.ColumnName] = rowToAdd[col.ColumnName];
                                    }
                                }

                                returnDT.Rows.Add(r);
                            }
                        }
                    }

                    returnDT.TableName = Sys.Enums.TableNames.tblVan.ToString();
                    return new DataView(returnDT);
                }
                else
                {
                    dt.TableName = Sys.Enums.TableNames.tblVan.ToString();
                    return new DataView(dt);
                }
            }

            public DataView Van_GetAll(bool Grouped, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Van_GetAll";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (Grouped)
                {
                    var returnDT = new DataTable();
                    foreach (DataColumn col in dt.Columns)
                        returnDT.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
                    foreach (DataRow row in dt.Rows)
                    {
                        bool found = false;
                        string registrationToFind = Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim();
                        foreach (DataRow groupedVan in returnDT.Rows)
                        {
                            if ((Sys.Helper.MakeStringValid(groupedVan["Registration"]).Split('*')[0].Trim() ?? "") == (registrationToFind ?? ""))
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            DataRow rowToAdd = null;
                            foreach (DataRow rowForRegistration in dt.Rows)
                            {
                                if ((Sys.Helper.MakeStringValid(rowForRegistration["Registration"]).Split('*')[0].Trim() ?? "") == (registrationToFind ?? ""))
                                {
                                    if (rowToAdd is null)
                                    {
                                        rowToAdd = rowForRegistration;
                                    }
                                    else if (Conversions.ToBoolean(rowForRegistration["VanID"] < rowToAdd["VanID"]))
                                    {
                                        rowToAdd = rowForRegistration;
                                    }
                                }
                            }

                            if (rowToAdd is object)
                            {
                                var r = returnDT.NewRow();
                                foreach (DataColumn col in returnDT.Columns)
                                {
                                    if ((col.ColumnName ?? "") == "Registration")
                                    {
                                        r[col.ColumnName] = registrationToFind;
                                    }
                                    else
                                    {
                                        r[col.ColumnName] = rowToAdd[col.ColumnName];
                                    }
                                }

                                returnDT.Rows.Add(r);
                            }
                        }
                    }

                    returnDT.TableName = Sys.Enums.TableNames.tblVan.ToString();
                    return new DataView(returnDT);
                }
                else
                {
                    dt.TableName = Sys.Enums.TableNames.tblVan.ToString();
                    return new DataView(dt);
                }
            }

            public DataView Van_Search(string Criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", Criteria, true);
                var dt = _database.ExecuteSP_DataTable("Van_SearchList");
                var returnDT = new DataTable();
                foreach (DataColumn col in dt.Columns)
                    returnDT.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
                foreach (DataRow row in dt.Rows)
                {
                    bool found = false;
                    string registrationToFind = Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim();
                    foreach (DataRow groupedVan in returnDT.Rows)
                    {
                        if ((Sys.Helper.MakeStringValid(groupedVan["Registration"]).Split('*')[0].Trim() ?? "") == (registrationToFind ?? ""))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        DataRow rowToAdd = null;
                        foreach (DataRow rowForRegistration in dt.Rows)
                        {
                            if ((Sys.Helper.MakeStringValid(rowForRegistration["Registration"]).Split('*')[0].Trim() ?? "") == (registrationToFind ?? ""))
                            {
                                if (rowToAdd is null)
                                {
                                    rowToAdd = rowForRegistration;
                                }
                                else if (Conversions.ToBoolean(rowForRegistration["VanID"] < rowToAdd["VanID"]))
                                {
                                    rowToAdd = rowForRegistration;
                                }
                            }
                        }

                        if (rowToAdd is object)
                        {
                            var r = returnDT.NewRow();
                            foreach (DataColumn col in returnDT.Columns)
                            {
                                if ((col.ColumnName ?? "") == "Registration")
                                {
                                    r[col.ColumnName] = registrationToFind;
                                }
                                else
                                {
                                    r[col.ColumnName] = rowToAdd[col.ColumnName];
                                }
                            }

                            returnDT.Rows.Add(r);
                        }
                    }
                }

                returnDT.TableName = Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(returnDT);
            }

            public Van Insert(Van oVan, string CopiedVanReg, DataView LocationsDataView, bool InsertFromWarehouses)
            {
                if (InsertFromWarehouses)
                {
                    _database.ClearParameter();
                    AddVanParametersToCommand(ref oVan);
                    oVan.SetVanID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"));
                    oVan.Exists = true;
                    var oLocation = new Locationss.Locations();
                    oLocation.SetDeleted = false;
                    oLocation.SetVanID = oVan.VanID;
                    oLocation.SetWarehouseID = null;
                    App.DB.Location.Insert(oLocation);
                    return oVan;
                }
                else
                {
                    Van returnVan = null;
                    string registrationEntered = oVan.Registration;
                    var copiedVanLocations = default(DataTable);
                    if (CopiedVanReg.Length > 0)
                    {
                        copiedVanLocations = App.DB.Location.Locations_Get_ForVanReg(CopiedVanReg).Table;
                    }

                    foreach (DataRow row in App.DB.Warehouse.Warehouse_GetAll().Table.Rows)
                    {
                        oVan.SetRegistration = registrationEntered.Trim() + " * " + Sys.Helper.MakeStringValid(row["Name"]).Trim();
                        _database.ClearParameter();
                        AddVanParametersToCommand(ref oVan);
                        oVan.SetVanID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"));
                        oVan.Exists = true;
                        var oLocation = new Locationss.Locations();
                        oLocation.SetDeleted = false;
                        oLocation.SetVanID = oVan.VanID;
                        oLocation.SetWarehouseID = null;
                        App.DB.Location.Insert(oLocation);
                        foreach (DataRow warehouseRow in LocationsDataView.Table.Rows)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(warehouseRow["WarehouseID"], row["WarehouseID"], false)))
                            {
                                if (Conversions.ToBoolean(!warehouseRow["Tick"]))
                                {
                                    App.DB.Location.Delete(oLocation.LocationID);
                                }
                            }
                        }

                        if (CopiedVanReg.Length > 0)
                        {
                            var drLoc = copiedVanLocations.Select("Registration='" + CopiedVanReg.Trim() + " * " + Sys.Helper.MakeStringValid(row["Name"]).Trim() + "'");
                            if (drLoc.Length > 0)
                            {
                                foreach (DataRow l in drLoc)
                                {
                                    var lParts = App.DB.Part.PartLocations_GetForVan(Conversions.ToInteger(l["LocationID"])).Table;
                                    foreach (DataRow p in lParts.Rows)
                                    {
                                        _database.ClearParameter();
                                        _database.AddParameter("@PartID", p["PartID"], true);
                                        _database.AddParameter("@LocationID", oLocation.LocationID, true);
                                        _database.AddParameter("@MinQty", p["MinQty"], true);
                                        _database.AddParameter("@RecQty", p["RecQty"], true);
                                        _database.ExecuteSP_NO_Return("PartLocations_Insert");
                                        var oPartTransaction = new PartTransactions.PartTransaction();
                                        oPartTransaction.SetLocationID = oLocation.LocationID; // row.Item("LocationID")
                                        oPartTransaction.SetAmount = 0;
                                        oPartTransaction.SetPartID = p["PartID"]; // row.Item("PartID")
                                        oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Sys.Enums.Transaction.StockAdjustment);
                                        App.DB.PartTransaction.Insert(oPartTransaction);
                                    }
                                }
                            }
                        }

                        if (returnVan is null)
                        {
                            returnVan = oVan;
                        }
                    }

                    return returnVan;
                }
            }

            public void Update(Van oVan, DataView LocationsDataView, bool UpdateFromWarehouses)
            {
                if (UpdateFromWarehouses)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@VanID", oVan.VanID, true);
                    AddVanParametersToCommand(ref oVan);
                    _database.ExecuteSP_NO_Return("Van_Update");
                    foreach (DataRow locationRow in LocationsDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(oVan.VanID, locationRow["VanID"], false)))
                        {
                            App.DB.Location.Update(Conversions.ToInteger(locationRow["LocationID"]), Conversions.ToBoolean(!locationRow["Tick"]));
                        }
                    }
                }
                else
                {
                    string registrationEntered = oVan.Registration;
                    string registration = Van_Get(oVan.VanID).Registration.Split('*')[0].Trim();
                    foreach (DataRow row in Van_GetAll_AllLocations().Table.Rows)
                    {
                        if ((Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() ?? "") == (registration ?? ""))
                        {
                            oVan.SetRegistration = registrationEntered.Trim() + " * " + Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[1].Trim();
                            _database.ClearParameter();
                            _database.AddParameter("@VanID", row["VanID"], true);
                            AddVanParametersToCommand(ref oVan);
                            _database.ExecuteSP_NO_Return("Van_Update");
                        }
                    }

                    foreach (DataRow row in LocationsDataView.Table.Rows)
                        App.DB.Location.Update(Conversions.ToInteger(row["LocationID"]), Conversions.ToBoolean(!row["Tick"]));
                }
            }

            private void AddVanParametersToCommand(ref Van oVan)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Registration", oVan.Registration, true);
                    withBlock.AddParameter("@Notes", oVan.Notes, true);
                    withBlock.AddParameter("@InsuranceDue", Sys.Helper.InsertDateIntoDb(oVan.InsuranceDue), true);
                    withBlock.AddParameter("@MOTDue", Sys.Helper.InsertDateIntoDb(oVan.MOTDue), true);
                    withBlock.AddParameter("@TaxDue", Sys.Helper.InsertDateIntoDb(oVan.TaxDue), true);
                    withBlock.AddParameter("@ServiceDue", Sys.Helper.InsertDateIntoDb(oVan.InsuranceDue), true);
                    withBlock.AddParameter("@MileageLimit", oVan.MileageLimit, true);
                    withBlock.AddParameter("@PeriodValue", oVan.PeriodValue, true);
                    withBlock.AddParameter("@PeriodType", oVan.PeriodType, true);
                    withBlock.AddParameter("@PreferredSupplierID", oVan.PreferredSupplierID, true);
                    withBlock.AddParameter("@ExcludeFromAutoReplenishment", oVan.ExcludeFromAutoReplenishment, true);
                    withBlock.AddParameter("@SecondaryPrice", oVan.SecondaryPrice, true);
                    withBlock.AddParameter("@UseContainerStock", oVan.UseContainerStock, true);
                }
            }

            public DataView Van_GetWithProduct(int ProductID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Van_GetWithProduct";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@ProductID", ProductID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                return new DataView(dt);
            }

            public DataView Van_GetWithProduct(int ProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductID", ProductID);

                // Get the datatable from the database store in dt
                return new DataView(_database.ExecuteSP_DataTable("Van_GetWithProduct"));
            }

            public DataView Van_GetWithPart(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID);

                // Get the datatable from the database store in dt
                return new DataView(_database.ExecuteSP_DataTable("Van_GetWithPart"));
            }

            public DataView Van_GetWithPart(int PartID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Van_GetWithPart";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartID", PartID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                return new DataView(dt);
            }

            public DataView Van_GetAll_For_Warehouse(int WarehouseID)
            {
                _database.ClearParameter();
                _database.AddParameter("@WarehouseID", WarehouseID);
                var dt = _database.ExecuteSP_DataTable("Van_GetAll_For_Warehouse");
                dt.TableName = Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(dt);
            }

            public string Van_GetDepartment(int VanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", VanID);

                // Get the datatable from the database store in dt
                return Conversions.ToString(_database.ExecuteScalar("SELECT tblEngineer.Department FROM tblVan INNER JOIN tblEngineerVan ON tblVan.VanID = tblEngineerVan.VanID INNER JOIN tblEngineer ON tblEngineerVan.EngineerID = tblEngineer.EngineerID WHERE (tblVan.VanID = @VanID) AND (tblVan.Deleted = 0) AND (tblEngineerVan.Deleted = 0)"));
            }

            // Public Sub Van_ClearObject(ByVal oVan As Entity.Vans.Van)
            // oVan.SetDeleted = Nothing
            // oVan.s()
            // End Sub

            public Van CopyVan(Van oVan, string CopiedVanReg, DataView LocationsDataView, bool InsertFromWarehouses)
            {
                if (InsertFromWarehouses)
                {
                    _database.ClearParameter();
                    AddVanParametersToCommand(ref oVan);
                    oVan.SetVanID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"));
                    oVan.Exists = true;
                    var oLocation = new Locationss.Locations();
                    oLocation.SetDeleted = false;
                    oLocation.SetVanID = oVan.VanID;
                    oLocation.SetWarehouseID = null;
                    App.DB.Location.Insert(oLocation);
                    return oVan;
                }
                else
                {
                    Van returnVan = null;
                    string registrationEntered = oVan.Registration;
                    var copiedVanLocations = default(DataTable);
                    foreach (DataRow row in App.DB.Warehouse.Warehouse_GetAll().Table.Rows)
                    {
                        oVan.SetRegistration = registrationEntered.Trim() + " * " + Sys.Helper.MakeStringValid(row["Name"]).Trim();
                        _database.ClearParameter();
                        AddVanParametersToCommand(ref oVan);
                        oVan.SetVanID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"));
                        oVan.Exists = true;
                        var oLocation = new Locationss.Locations();
                        oLocation.SetDeleted = false;
                        oLocation.SetVanID = oVan.VanID;
                        oLocation.SetWarehouseID = null;
                        App.DB.Location.Insert(oLocation);
                        foreach (DataRow warehouseRow in LocationsDataView.Table.Rows)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(warehouseRow["WarehouseID"], row["WarehouseID"], false)))
                            {
                                if (Conversions.ToBoolean(!warehouseRow["Tick"]))
                                {
                                    App.DB.Location.Delete(oLocation.LocationID);
                                }
                            }
                        }

                        if (CopiedVanReg.Length > 0)
                        {
                            copiedVanLocations = App.DB.Location.Locations_Get_ForVanReg(CopiedVanReg).Table;
                        }

                        if (CopiedVanReg.Length > 0)
                        {
                            var drLoc = copiedVanLocations.Select("Registration='" + CopiedVanReg.Trim() + " * " + Sys.Helper.MakeStringValid(row["Name"]).Trim() + "'");
                            if (drLoc.Length > 0)
                            {
                                foreach (DataRow l in drLoc)
                                {
                                    if (Sys.Helper.MakeBooleanValid(l["Deleted"]) == true)
                                    {
                                    }
                                    else
                                    {
                                        var lParts = App.DB.Part.PartLocations_GetForVan2(Conversions.ToInteger(l["LocationID"])).Table;
                                        foreach (DataRow p in lParts.Rows)
                                        {
                                            _database.ClearParameter();
                                            _database.AddParameter("@PartID", p["PartID"], true);
                                            _database.AddParameter("@LocationID", oLocation.LocationID, true);
                                            _database.AddParameter("@MinQty", p["Min"], true);
                                            _database.AddParameter("@RecQty", p["Max"], true);
                                            _database.ExecuteSP_NO_Return("PartLocations_Insert");
                                            var oPartTransaction = new PartTransactions.PartTransaction();
                                            oPartTransaction.SetLocationID = oLocation.LocationID; // row.Item("LocationID")
                                            oPartTransaction.SetAmount = 0;
                                            oPartTransaction.SetPartID = p["PartID"]; // row.Item("PartID")
                                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Sys.Enums.Transaction.StockAdjustment);
                                            App.DB.PartTransaction.Insert(oPartTransaction);
                                        }
                                    }
                                }
                            }
                        }

                        if (returnVan is null)
                        {
                            returnVan = oVan;
                        }
                    }

                    return returnVan;
                }
            }

            public Van MergeVan(Van oVanToMergeFrom, Van CurrentVan)
            {
                var returnVan = CurrentVan;
                DataTable copiedVanLocations;
                foreach (DataRow row in App.DB.Warehouse.Warehouse_GetAll().Table.Rows)
                {

                    // Dim oLocation As New Entity.Locationss.Locations
                    // oLocation.SetDeleted = False
                    // oLocation.SetVanID = CurrentVan.VanID
                    // oLocation.SetWarehouseID = Nothing
                    // DB.Location.Insert(oLocation)

                    object LocationsFromDonorVan = App.DB.Location.Locations_Get_ForVanReg(oVanToMergeFrom.Registration).Table;
                    object LocationsFromCurrentVan = App.DB.Location.Locations_Get_ForVanReg(CurrentVan.Registration).Table;
                    int i = 0;
                    DataRow[] drLoc = (DataRow[])LocationsFromDonorVan.Select("Registration='" + oVanToMergeFrom.Registration.Split('*')[0].Trim() + " * " + Sys.Helper.MakeStringValid(row["Name"]).Trim() + "'"); // ' from van
                    DataRow[] drLocto = (DataRow[])LocationsFromCurrentVan.Select("Registration='" + CurrentVan.Registration.Split('*')[0].Trim() + " * " + Sys.Helper.MakeStringValid(row["Name"]).Trim() + "'"); // ' to van
                    if (drLoc.Length > 0)
                    {
                        foreach (DataRow l in drLoc)  // GAsway, Vokera ,Alpha Etc,
                        {
                            if (Sys.Helper.MakeBooleanValid(l["Deleted"]) == true | drLocto.Length == 0)
                            {
                            }
                            else
                            {
                                var lParts = App.DB.Part.PartLocations_GetForVan2(Conversions.ToInteger(l["LocationID"])).Table;   // gets parts list for from VAN
                                var lPartsto = App.DB.Part.PartLocations_GetForVan2(Conversions.ToInteger(drLocto[i]["LocationID"])).Table; // Gets parts of the 'to' van  6
                                foreach (DataRow p in lParts.Rows)
                                {
                                    if (lPartsto.Select(Conversions.ToString("PartID=" + p["PartID"])).Length > 0) // just change min /max
                                    {
                                        _database.ClearParameter();
                                        _database.AddParameter("@PartLocationID", p["PartLocationID"], true);
                                        _database.AddParameter("@MinQty", p["Min"], true);
                                        _database.AddParameter("@MaxQty", p["Max"], true);
                                        _database.ExecuteSP_NO_Return("PartLocations_UpdateMinMax");
                                    }
                                    else   // insert a new line
                                    {
                                        _database.ClearParameter();
                                        _database.AddParameter("@PartID", p["PartID"], true);
                                        _database.AddParameter("@LocationID", drLocto[i]["LocationID"], true);
                                        _database.AddParameter("@MinQty", p["Min"], true);
                                        _database.AddParameter("@RecQty", p["Max"], true);
                                        _database.ExecuteSP_NO_Return("PartLocations_Insert");
                                        int stock = App.DB.Part.PartLocation_GetStockLevel(Conversions.ToInteger(drLocto[i]["LocationID"]), Conversions.ToInteger(p["PartID"]));
                                        if (stock != 0) // but what if its not a location but stocked on the van?
                                        {
                                            var oPartTransaction = new PartTransactions.PartTransaction();
                                            oPartTransaction.SetLocationID = drLocto[i]["LocationID"];
                                            oPartTransaction.SetAmount = stock;
                                            oPartTransaction.SetPartID = p["PartID"];
                                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Sys.Enums.Transaction.StockAdjustment);
                                            App.DB.PartTransaction.Insert(oPartTransaction);
                                        }
                                        else
                                        {
                                            var oPartTransaction = new PartTransactions.PartTransaction();
                                            oPartTransaction.SetLocationID = drLocto[i]["LocationID"];
                                            oPartTransaction.SetAmount = 0;
                                            oPartTransaction.SetPartID = p["PartID"];
                                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Sys.Enums.Transaction.StockAdjustment);
                                            App.DB.PartTransaction.Insert(oPartTransaction);
                                        }
                                    }
                                }
                            }

                            i = i + 1;
                        }
                    }
                }

                return returnVan;
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}