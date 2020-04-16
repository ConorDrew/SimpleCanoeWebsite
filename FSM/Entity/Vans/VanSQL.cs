// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Vans.VanSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Locationss;
using FSM.Entity.PartTransactions;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Vans
{
    public class VanSQL
    {
        private Database _database;

        public VanSQL(Database database)
        {
            this._database = database;
        }

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
                    if (Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() == registration)
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
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)VanID, false);
            DataTable table = this._database.ExecuteSP_DataTable("Van_Get", true);
            table.TableName = Enums.TableNames.tblVan.ToString();
            return new DataView(table);
        }

        public Van Van_Get(int VanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)VanID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Van_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Van)null;
            Van van1 = new Van();
            Van van2 = van1;
            van2.IgnoreExceptionsOnSetMethods = true;
            van2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(VanID)]);
            van2.SetRegistration = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Registration"]);
            van2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            van2.InsuranceDue = Conversions.ToDate(dataTable.Rows[0]["InsuranceDue"]);
            van2.MOTDue = Conversions.ToDate(dataTable.Rows[0]["MOTDue"]);
            van2.TaxDue = Conversions.ToDate(dataTable.Rows[0]["TaxDue"]);
            van2.ServiceDue = Conversions.ToDate(dataTable.Rows[0]["ServiceDue"]);
            van2.SetMileageLimit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MileageLimit"]);
            van2.SetPeriodValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PeriodValue"]);
            van2.SetPeriodType = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PeriodType"]);
            van2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            van2.SetPreferredSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PreferredSupplierID"]);
            van2.SetExcludeFromAutoReplenishment = Conversions.ToBoolean(dataTable.Rows[0]["ExcludeFromAutoReplenishment"]);
            van2.SetEngineerVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVanID"]);
            van2.SecondaryPrice = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SecondaryPrice"]));
            van2.SetUseContainerStock = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UseContainerStock"]));
            van1.Exists = true;
            return van1;
        }

        public Van Van_GetByLocationID(int LocationID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@LocationID", (object)LocationID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(Van_GetByLocationID), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (Van)null;
            Van van1 = new Van();
            Van van2 = van1;
            van2.IgnoreExceptionsOnSetMethods = true;
            van2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            van2.SetRegistration = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Registration"]);
            van2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            van2.InsuranceDue = Conversions.ToDate(dataTable.Rows[0]["InsuranceDue"]);
            van2.MOTDue = Conversions.ToDate(dataTable.Rows[0]["MOTDue"]);
            van2.TaxDue = Conversions.ToDate(dataTable.Rows[0]["TaxDue"]);
            van2.ServiceDue = Conversions.ToDate(dataTable.Rows[0]["ServiceDue"]);
            van2.SetMileageLimit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MileageLimit"]);
            van2.SetPeriodValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PeriodValue"]);
            van2.SetPeriodType = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PeriodType"]);
            van2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            van2.SetPreferredSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PreferredSupplierID"]);
            van2.SetExcludeFromAutoReplenishment = Conversions.ToBoolean(dataTable.Rows[0]["ExcludeFromAutoReplenishment"]);
            van2.SetUseContainerStock = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UseContainerStock"]));
            van1.Exists = true;
            return van1;
        }

        public Van Van_GetByLocationID(int LocationID, SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(Van_GetByLocationID);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@LocationID", (object)LocationID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            if (table == null || table.Rows.Count <= 0)
                return (Van)null;
            Van van1 = new Van();
            Van van2 = van1;
            van2.IgnoreExceptionsOnSetMethods = true;
            van2.SetVanID = RuntimeHelpers.GetObjectValue(table.Rows[0]["VanID"]);
            van2.SetRegistration = RuntimeHelpers.GetObjectValue(table.Rows[0]["Registration"]);
            van2.SetNotes = RuntimeHelpers.GetObjectValue(table.Rows[0]["Notes"]);
            van2.InsuranceDue = Conversions.ToDate(table.Rows[0]["InsuranceDue"]);
            van2.MOTDue = Conversions.ToDate(table.Rows[0]["MOTDue"]);
            van2.TaxDue = Conversions.ToDate(table.Rows[0]["TaxDue"]);
            van2.ServiceDue = Conversions.ToDate(table.Rows[0]["ServiceDue"]);
            van2.SetMileageLimit = RuntimeHelpers.GetObjectValue(table.Rows[0]["MileageLimit"]);
            van2.SetPeriodValue = RuntimeHelpers.GetObjectValue(table.Rows[0]["PeriodValue"]);
            van2.SetPeriodType = RuntimeHelpers.GetObjectValue(table.Rows[0]["PeriodType"]);
            van2.SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"]);
            van2.SetPreferredSupplierID = RuntimeHelpers.GetObjectValue(table.Rows[0]["PreferredSupplierID"]);
            van2.SetExcludeFromAutoReplenishment = Conversions.ToBoolean(table.Rows[0]["ExcludeFromAutoReplenishment"]);
            van2.SetUseContainerStock = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["UseContainerStock"]));
            van1.Exists = true;
            return van1;
        }

        public bool Check_Unique_Registration(string Registration, int ID)
        {
            int NumberOfVans = 0;

            foreach (DataRow row in Van_GetAll(true).Table.Rows)
            {
                if (Conversions.ToInteger(row["VanID"]) != ID)
                {
                    if (row["Registration"] == Registration)
                        NumberOfVans += 1;
                }
            }

            if (NumberOfVans == 0)
                return true;
            else
                return false;
        }

        public DataView Van_GetAll_AllLocations()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Van_GetAll_AllLocations), true);
            table.TableName = Enums.TableNames.tblVan.ToString();
            return new DataView(table);
        }

        public DataView Van_GetAll(bool Grouped)
        {
            _database.ClearParameter();
            DataTable dt = _database.ExecuteSP_DataTable("Van_GetAll");

            if (Grouped)
            {
                DataTable returnDT = new DataTable();

                foreach (DataColumn col in dt.Columns)
                    returnDT.Columns.Add(new DataColumn(col.ColumnName, col.DataType));

                foreach (DataRow row in dt.Rows)
                {
                    bool found = false;
                    string registrationToFind = Entity.Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim();

                    foreach (DataRow groupedVan in returnDT.Rows)
                    {
                        if (Entity.Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() == registrationToFind)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        DataRow rowToAdd = null/* TODO Change to default(_) if this is not a reference type */;

                        foreach (DataRow rowForRegistration in dt.Rows)
                        {
                            if (Entity.Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() == registrationToFind)
                            {
                                if (rowToAdd == null)
                                    rowToAdd = rowForRegistration;
                                else if (Operators.ConditionalCompareObjectLess(rowForRegistration["VanID"], rowToAdd["VanID"], false))
                                    rowToAdd = rowForRegistration;
                            }
                        }

                        if (rowToAdd != null)
                        {
                            DataRow r = returnDT.NewRow();
                            foreach (DataColumn col in returnDT.Columns)
                            {
                                if (col.ColumnName == "Registration")
                                    r[col.ColumnName] = registrationToFind;
                                else
                                    r[col.ColumnName] = rowToAdd[col.ColumnName];
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

                returnDT.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(returnDT);
            }
            else
            {
                dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(dt);
            }
        }

        public DataView Van_GetAll_incDeleted(bool Grouped)
        {
            _database.ClearParameter();
            DataTable dt = _database.ExecuteSP_DataTable("Van_GetAll_incDeleted");

            if (Grouped)
            {
                DataTable returnDT = new DataTable();

                foreach (DataColumn col in dt.Columns)
                    returnDT.Columns.Add(new DataColumn(col.ColumnName, col.DataType));

                foreach (DataRow row in dt.Rows)
                {
                    bool found = false;
                    string registrationToFind = Entity.Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim();

                    foreach (DataRow groupedVan in returnDT.Rows)
                    {
                        if (Entity.Sys.Helper.MakeStringValid(groupedVan["Registration"]).Split('*')[0].Trim() == registrationToFind)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        DataRow rowToAdd = null/* TODO Change to default(_) if this is not a reference type */;

                        foreach (DataRow rowForRegistration in dt.Rows)
                        {
                            if (Entity.Sys.Helper.MakeStringValid(rowForRegistration["Registration"]).Split('*')[0].Trim() == registrationToFind)
                            {
                                if (rowToAdd == null)
                                    rowToAdd = rowForRegistration;
                                else if (Operators.ConditionalCompareObjectLess(rowForRegistration["VanID"], rowToAdd["VanID"], false))
                                    rowToAdd = rowForRegistration;
                            }
                        }

                        if (rowToAdd != null)
                        {
                            DataRow r = returnDT.NewRow();
                            foreach (DataColumn col in returnDT.Columns)
                            {
                                if (col.ColumnName == "Registration")
                                    r[col.ColumnName] = registrationToFind;
                                else
                                    r[col.ColumnName] = rowToAdd[col.ColumnName];
                            }
                            returnDT.Rows.Add(r);
                        }
                    }
                }

                returnDT.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(returnDT);
            }
            else
            {
                dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(dt);
            }
        }

        public DataView Van_GetAll(bool Grouped, SqlTransaction trans)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
            {
                CommandText = nameof(Van_GetAll),
                CommandType = CommandType.StoredProcedure,
                Transaction = trans,
                Connection = trans.Connection
            });

            DataSet returnDS = new DataSet();
            sqlDataAdapter.Fill(returnDS);

            DataTable dt = returnDS.Tables[0];

            if (Grouped)
            {
                DataTable returnDT = new DataTable();

                foreach (DataColumn col in dt.Columns)
                    returnDT.Columns.Add(new DataColumn(col.ColumnName, col.DataType));

                foreach (DataRow row in dt.Rows)
                {
                    bool found = false;
                    string registrationToFind = Entity.Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim();

                    foreach (DataRow groupedVan in returnDT.Rows)
                    {
                        if (Entity.Sys.Helper.MakeStringValid(groupedVan["Registration"]).Split('*')[0].Trim() == registrationToFind)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        DataRow rowToAdd = null/* TODO Change to default(_) if this is not a reference type */;

                        foreach (DataRow rowForRegistration in dt.Rows)
                        {
                            if (Entity.Sys.Helper.MakeStringValid(rowForRegistration["Registration"]).Split('*')[0].Trim() == registrationToFind)
                            {
                                if (rowToAdd == null)
                                    rowToAdd = rowForRegistration;
                                else if (Operators.ConditionalCompareObjectLess(rowForRegistration["VanID"], rowToAdd["VanID"], false))
                                    rowToAdd = rowForRegistration;
                            }
                        }

                        if (rowToAdd != null)
                        {
                            DataRow r = returnDT.NewRow();
                            foreach (DataColumn col in returnDT.Columns)
                            {
                                if (col.ColumnName == "Registration")
                                    r[col.ColumnName] = registrationToFind;
                                else
                                    r[col.ColumnName] = rowToAdd[col.ColumnName];
                            }
                            returnDT.Rows.Add(r);
                        }
                    }
                }

                returnDT.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(returnDT);
            }
            else
            {
                dt.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString();
                return new DataView(dt);
            }
        }

        public DataView Van_Search(string Criteria)
        {
            _database.ClearParameter();
            _database.AddParameter("@SearchString", Criteria, true);
            DataTable dt = _database.ExecuteSP_DataTable("Van_SearchList");

            DataTable returnDT = new DataTable();

            foreach (DataColumn col in dt.Columns)
                returnDT.Columns.Add(new DataColumn(col.ColumnName, col.DataType));

            foreach (DataRow row in dt.Rows)
            {
                bool found = false;
                string registrationToFind = Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim();

                foreach (DataRow groupedVan in returnDT.Rows)
                {
                    if (Helper.MakeStringValid(groupedVan["Registration"]).Split('*')[0].Trim() == registrationToFind)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    DataRow rowToAdd = null/* TODO Change to default(_) if this is not a reference type */;

                    foreach (DataRow rowForRegistration in dt.Rows)
                    {
                        if (Helper.MakeStringValid(rowForRegistration["Registration"]).Split('*')[0].Trim() == registrationToFind)
                        {
                            if (rowToAdd == null)
                                rowToAdd = rowForRegistration;
                            else if (Operators.ConditionalCompareObjectLess(rowForRegistration["VanID"], rowToAdd["VanID"], false))
                                rowToAdd = rowForRegistration;
                        }
                    }

                    if (rowToAdd != null)
                    {
                        DataRow r = returnDT.NewRow();
                        foreach (DataColumn col in returnDT.Columns)
                        {
                            if (col.ColumnName == "Registration")
                                r[col.ColumnName] = registrationToFind;
                            else
                                r[col.ColumnName] = rowToAdd[col.ColumnName];
                        }
                        returnDT.Rows.Add(r);
                    }
                }
            }

            returnDT.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString();
            return new DataView(returnDT);
        }

        public Van Insert(Van oVan, string CopiedVanReg, DataView LocationsDataView, bool InsertFromWarehouses)
        {
            if (InsertFromWarehouses)
            {
                _database.ClearParameter();
                AddVanParametersToCommand(ref oVan);
                oVan.SetVanID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"));
                oVan.Exists = true;

                Entity.Locationss.Locations oLocation = new Entity.Locationss.Locations();
                oLocation.SetDeleted = false;
                oLocation.SetVanID = oVan.VanID;
                oLocation.SetWarehouseID = null;
                App.DB.Location.Insert(oLocation);

                return oVan;
            }
            else
            {
                Van returnVan = null/* TODO Change to default(_) if this is not a reference type */;
                string registrationEntered = oVan.Registration;

                DataTable copiedVanLocations = null;

                if (CopiedVanReg.Length > 0)
                    copiedVanLocations = App.DB.Location.Locations_Get_ForVanReg(CopiedVanReg).Table;

                foreach (DataRow row in App.DB.Warehouse.Warehouse_GetAll().Table.Rows)
                {
                    oVan.SetRegistration = registrationEntered.Trim() + " * " + Sys.Helper.MakeStringValid(row["Name"]).Trim();

                    _database.ClearParameter();
                    AddVanParametersToCommand(ref oVan);

                    oVan.SetVanID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Van_Insert"));
                    oVan.Exists = true;

                    Entity.Locationss.Locations oLocation = new Entity.Locationss.Locations();
                    oLocation.SetDeleted = false;
                    oLocation.SetVanID = oVan.VanID;
                    oLocation.SetWarehouseID = null;
                    App.DB.Location.Insert(oLocation);

                    foreach (DataRow warehouseRow in LocationsDataView.Table.Rows)
                    {
                        if (warehouseRow["WarehouseID"] == row["WarehouseID"])
                        {
                            if (Conversions.ToBoolean(warehouseRow["Tick"]))
                                App.DB.Location.Delete(oLocation.LocationID);
                        }
                    }

                    if (CopiedVanReg.Length > 0)
                    {
                        DataRow[] drLoc = copiedVanLocations.Select("Registration='" + CopiedVanReg.Trim() + " * " + Helper.MakeStringValid(row["Name"]).Trim() + "'");
                        if (drLoc.Length > 0)
                        {
                            foreach (DataRow l in drLoc)
                            {
                                DataTable lParts = App.DB.Part.PartLocations_GetForVan(Conversions.ToInteger(l["LocationID"])).Table;
                                foreach (DataRow p in lParts.Rows)
                                {
                                    _database.ClearParameter();
                                    _database.AddParameter("@PartID", p["PartID"], true);
                                    _database.AddParameter("@LocationID", oLocation.LocationID, true);
                                    _database.AddParameter("@MinQty", p["MinQty"], true);
                                    _database.AddParameter("@RecQty", p["RecQty"], true);

                                    _database.ExecuteSP_NO_Return("PartLocations_Insert");

                                    Entity.PartTransactions.PartTransaction oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                    oPartTransaction.SetLocationID = oLocation.LocationID; // row.Item("LocationID")
                                    oPartTransaction.SetAmount = 0;
                                    oPartTransaction.SetPartID = p["PartID"]; // row.Item("PartID")
                                    oPartTransaction.SetTransactionTypeID = System.Convert.ToInt32(Entity.Sys.Enums.Transaction.StockAdjustment);
                                    App.DB.PartTransaction.Insert(oPartTransaction);
                                }
                            }
                        }
                    }

                    if (returnVan == null)
                        returnVan = oVan;
                }

                return returnVan;
            }
        }

        public void Update(Van oVan, DataView LocationsDataView, bool UpdateFromWarehouses)
        {
            if (UpdateFromWarehouses)
            {
                this._database.ClearParameter();
                this._database.AddParameter("@VanID", (object)oVan.VanID, true);
                this.AddVanParametersToCommand(ref oVan);
                this._database.ExecuteSP_NO_Return("Van_Update", true);

                foreach (DataRow current in LocationsDataView.Table.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual((object)oVan.VanID, current["VanID"], false))
                        App.DB.Location.Update(Conversions.ToInteger(current["LocationID"]), Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(current["Tick"])));
                }
            }
            else
            {
                string registration = oVan.Registration;
                string Right = this.Van_Get(oVan.VanID).Registration.Split('*')[0].Trim();

                foreach (DataRow current in this.Van_GetAll_AllLocations().Table.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Registration"])).Split('*')[0].Trim(), Right, false) == 0)
                    {
                        oVan.SetRegistration = (object)(registration.Trim() + " * " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Registration"])).Split('*')[1].Trim());
                        this._database.ClearParameter();
                        this._database.AddParameter("@VanID", RuntimeHelpers.GetObjectValue(current["VanID"]), true);
                        this.AddVanParametersToCommand(ref oVan);
                        this._database.ExecuteSP_NO_Return("Van_Update", true);
                    }
                }

                foreach (DataRow current in LocationsDataView.Table.Rows)
                {
                    App.DB.Location.Update(Conversions.ToInteger(current["LocationID"]), Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(current["Tick"])));
                }
            }
        }

        private void AddVanParametersToCommand(ref Van oVan)
        {
            Database database = this._database;
            database.AddParameter("@Registration", (object)oVan.Registration, true);
            database.AddParameter("@Notes", (object)oVan.Notes, true);
            database.AddParameter("@InsuranceDue", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oVan.InsuranceDue)), true);
            database.AddParameter("@MOTDue", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oVan.MOTDue)), true);
            database.AddParameter("@TaxDue", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oVan.TaxDue)), true);
            database.AddParameter("@ServiceDue", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oVan.InsuranceDue)), true);
            database.AddParameter("@MileageLimit", (object)oVan.MileageLimit, true);
            database.AddParameter("@PeriodValue", (object)oVan.PeriodValue, true);
            database.AddParameter("@PeriodType", (object)oVan.PeriodType, true);
            database.AddParameter("@PreferredSupplierID", (object)oVan.PreferredSupplierID, true);
            database.AddParameter("@ExcludeFromAutoReplenishment", (object)oVan.ExcludeFromAutoReplenishment, true);
            database.AddParameter("@SecondaryPrice", (object)oVan.SecondaryPrice, true);
            database.AddParameter("@UseContainerStock", (object)oVan.UseContainerStock, true);
        }

        public DataView Van_GetWithProduct(int ProductID, SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(Van_GetWithProduct);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@ProductID", (object)ProductID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return new DataView(dataSet.Tables[0]);
        }

        public DataView Van_GetWithProduct(int ProductID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@ProductID", (object)ProductID, false);
            return new DataView(this._database.ExecuteSP_DataTable(nameof(Van_GetWithProduct), true));
        }

        public DataView Van_GetWithPart(int PartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, false);
            return new DataView(this._database.ExecuteSP_DataTable(nameof(Van_GetWithPart), true));
        }

        public DataView Van_GetWithPart(int PartID, SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(Van_GetWithPart);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@PartID", (object)PartID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return new DataView(dataSet.Tables[0]);
        }

        public DataView Van_GetAll_For_Warehouse(int WarehouseID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@WarehouseID", (object)WarehouseID, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(Van_GetAll_For_Warehouse), true);
            table.TableName = Enums.TableNames.tblVan.ToString();
            return new DataView(table);
        }

        public string Van_GetDepartment(int VanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)VanID, false);
            return Conversions.ToString(this._database.ExecuteScalar("SELECT tblEngineer.Department FROM tblVan INNER JOIN tblEngineerVan ON tblVan.VanID = tblEngineerVan.VanID INNER JOIN tblEngineer ON tblEngineerVan.EngineerID = tblEngineer.EngineerID WHERE (tblVan.VanID = @VanID) AND (tblVan.Deleted = 0) AND (tblEngineerVan.Deleted = 0)", true, false));
        }

        public Van CopyVan(
          Van oVan,
          string CopiedVanReg,
          DataView LocationsDataView,
          bool InsertFromWarehouses)
        {
            if (InsertFromWarehouses)
            {
                this._database.ClearParameter();
                this.AddVanParametersToCommand(ref oVan);
                oVan.SetVanID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Van_Insert", true)));
                oVan.Exists = true;
                App.DB.Location.Insert(new Locations()
                {
                    SetDeleted = false,
                    SetVanID = (object)oVan.VanID,
                    SetWarehouseID = (object)null
                });
                return oVan;
            }
            Van van = (Van)null;
            string registration = oVan.Registration;

            foreach (DataRow current1 in App.DB.Warehouse.Warehouse_GetAll().Table.Rows)
            {
                oVan.SetRegistration = (object)(registration.Trim() + " * " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Name"])).Trim());
                this._database.ClearParameter();
                this.AddVanParametersToCommand(ref oVan);
                oVan.SetVanID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Van_Insert", true)));
                oVan.Exists = true;
                Locations oLocations = new Locations();
                oLocations.SetDeleted = false;
                oLocations.SetVanID = (object)oVan.VanID;
                oLocations.SetWarehouseID = (object)null;
                App.DB.Location.Insert(oLocations);

                foreach (DataRow current2 in LocationsDataView.Table.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current2["WarehouseID"], current1["WarehouseID"], false) && Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(current2["Tick"])))
                        App.DB.Location.Delete(oLocations.LocationID);
                }
                DataTable table1 = null;
                if (CopiedVanReg.Length > 0)
                    table1 = App.DB.Location.Locations_Get_ForVanReg(CopiedVanReg).Table;
                if (CopiedVanReg.Length > 0)
                {
                    DataRow[] dataRowArray1 = table1.Select("Registration='" + CopiedVanReg.Trim() + " * " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Name"])).Trim() + "'");
                    if (dataRowArray1.Length > 0)
                    {
                        DataRow[] dataRowArray2 = dataRowArray1;
                        int index = 0;
                        while (index < dataRowArray2.Length)
                        {
                            DataRow dataRow = dataRowArray2[index];
                            if (!Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["Deleted"])))
                            {
                                DataTable table2 = App.DB.Part.PartLocations_GetForVan2(Conversions.ToInteger(dataRow["LocationID"])).Table;

                                foreach (DataRow current2 in table2.Rows)
                                {
                                    this._database.ClearParameter();
                                    this._database.AddParameter("@PartID", RuntimeHelpers.GetObjectValue(current2["PartID"]), true);
                                    this._database.AddParameter("@LocationID", (object)oLocations.LocationID, true);
                                    this._database.AddParameter("@MinQty", RuntimeHelpers.GetObjectValue(current2["Min"]), true);
                                    this._database.AddParameter("@RecQty", RuntimeHelpers.GetObjectValue(current2["Max"]), true);
                                    this._database.ExecuteSP_NO_Return("PartLocations_Insert", true);
                                    App.DB.PartTransaction.Insert(new PartTransaction()
                                    {
                                        SetLocationID = (object)oLocations.LocationID,
                                        SetAmount = (object)0,
                                        SetPartID = RuntimeHelpers.GetObjectValue(current2["PartID"]),
                                        SetTransactionTypeID = (object)1
                                    });
                                }
                            }
                            checked { ++index; }
                        }
                    }
                }
                if (van == null)
                    van = oVan;
            }
            return van;
        }

        public Van MergeVan(Van oVanToMergeFrom, Van CurrentVan)
        {
            Van van = CurrentVan;

            foreach (DataRow current1 in App.DB.Warehouse.Warehouse_GetAll().Table.Rows)
            {
                object table1 = (object)App.DB.Location.Locations_Get_ForVanReg(oVanToMergeFrom.Registration).Table;
                object table2 = (object)App.DB.Location.Locations_Get_ForVanReg(CurrentVan.Registration).Table;
                int index1 = 0;
                DataRow[] dataRowArray1 = (DataRow[])NewLateBinding.LateGet(table1, (Type)null, "Select", new object[1]
                {
            (object) ("Registration='" + oVanToMergeFrom.Registration.Split('*')[0].Trim() + " * " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Name"])).Trim() + "'")
                }, (string[])null, (Type[])null, (bool[])null);
                DataRow[] dataRowArray2 = (DataRow[])NewLateBinding.LateGet(table2, (Type)null, "Select", new object[1]
                {
            (object) ("Registration='" + CurrentVan.Registration.Split('*')[0].Trim() + " * " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current1["Name"])).Trim() + "'")
                }, (string[])null, (Type[])null, (bool[])null);
                if (dataRowArray1.Length > 0)
                {
                    DataRow[] dataRowArray3 = dataRowArray1;
                    int index2 = 0;
                    while (index2 < dataRowArray3.Length)
                    {
                        DataRow dataRow = dataRowArray3[index2];
                        if (!(Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["Deleted"])) | dataRowArray2.Length == 0))
                        {
                            DataTable table3 = App.DB.Part.PartLocations_GetForVan2(Conversions.ToInteger(dataRow["LocationID"])).Table;
                            DataTable table4 = App.DB.Part.PartLocations_GetForVan2(Conversions.ToInteger(dataRowArray2[index1]["LocationID"])).Table;

                            foreach (DataRow current2 in table3.Rows)
                            {
                                if (table4.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)"PartID=", current2["PartID"]))).Length > 0)
                                {
                                    this._database.ClearParameter();
                                    this._database.AddParameter("@PartLocationID", RuntimeHelpers.GetObjectValue(current2["PartLocationID"]), true);
                                    this._database.AddParameter("@MinQty", RuntimeHelpers.GetObjectValue(current2["Min"]), true);
                                    this._database.AddParameter("@MaxQty", RuntimeHelpers.GetObjectValue(current2["Max"]), true);
                                    this._database.ExecuteSP_NO_Return("PartLocations_UpdateMinMax", true);
                                }
                                else
                                {
                                    this._database.ClearParameter();
                                    this._database.AddParameter("@PartID", RuntimeHelpers.GetObjectValue(current2["PartID"]), true);
                                    this._database.AddParameter("@LocationID", RuntimeHelpers.GetObjectValue(dataRowArray2[index1]["LocationID"]), true);
                                    this._database.AddParameter("@MinQty", RuntimeHelpers.GetObjectValue(current2["Min"]), true);
                                    this._database.AddParameter("@RecQty", RuntimeHelpers.GetObjectValue(current2["Max"]), true);
                                    this._database.ExecuteSP_NO_Return("PartLocations_Insert", true);
                                    int stockLevel = App.DB.Part.PartLocation_GetStockLevel(Conversions.ToInteger(dataRowArray2[index1]["LocationID"]), Conversions.ToInteger(current2["PartID"]));
                                    if ((uint)stockLevel > 0U)
                                        App.DB.PartTransaction.Insert(new PartTransaction()
                                        {
                                            SetLocationID = RuntimeHelpers.GetObjectValue(dataRowArray2[index1]["LocationID"]),
                                            SetAmount = (object)stockLevel,
                                            SetPartID = RuntimeHelpers.GetObjectValue(current2["PartID"]),
                                            SetTransactionTypeID = (object)1
                                        });
                                    else
                                        App.DB.PartTransaction.Insert(new PartTransaction()
                                        {
                                            SetLocationID = RuntimeHelpers.GetObjectValue(dataRowArray2[index1]["LocationID"]),
                                            SetAmount = (object)0,
                                            SetPartID = RuntimeHelpers.GetObjectValue(current2["PartID"]),
                                            SetTransactionTypeID = (object)1
                                        });
                                }
                            }
                        }
                        checked { ++index1; }
                        checked { ++index2; }
                    }
                }
            }
            return van;
        }
    }
}