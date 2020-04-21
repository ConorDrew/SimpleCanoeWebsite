using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Warehouses
    {
        public class WarehouseSQL
        {
            private Sys.Database _database;

            public WarehouseSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int WarehouseID)
            {
                string WarehouseName = Warehouse_Get(WarehouseID).Name.Trim();
                _database.ClearParameter();
                _database.AddParameter("@WarehouseID", WarehouseID, true);
                _database.ExecuteSP_NO_Return("Warehouse_Delete");
                foreach (DataRow row in App.DB.Van.Van_GetAll(false).Table.Rows)
                {
                    if ((Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[1].Trim() ?? "") == (WarehouseName ?? ""))
                    {
                        App.DB.Van.Delete(Conversions.ToInteger(row["VanID"]), true);
                    }
                }
            }

            public DataView Warehouse_GetDV(int WarehouseID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Warehouse_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblWarehouse.ToString();
                return new DataView(dt);
            }

            public DataView Warehouse_GetDV(int WarehouseID)
            {
                _database.ClearParameter();
                _database.AddParameter("@WarehouseID", WarehouseID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Warehouse_Get");
                dt.TableName = Sys.Enums.TableNames.tblWarehouse.ToString();
                return new DataView(dt);
            }

            public Warehouse Warehouse_Get(int WarehouseID)
            {
                _database.ClearParameter();
                _database.AddParameter("@WarehouseID", WarehouseID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Warehouse_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oWarehouse = new Warehouse();
                        oWarehouse.IgnoreExceptionsOnSetMethods = true;
                        oWarehouse.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oWarehouse.SetName = dt.Rows[0]["warehouseName"];
                        oWarehouse.SetSize = dt.Rows[0]["Size"];
                        oWarehouse.SetNotes = dt.Rows[0]["Notes"];
                        oWarehouse.SetAddress1 = dt.Rows[0]["Address1"];
                        oWarehouse.SetAddress2 = dt.Rows[0]["Address2"];
                        oWarehouse.SetAddress3 = dt.Rows[0]["Address3"];
                        oWarehouse.SetAddress4 = dt.Rows[0]["Address4"];
                        oWarehouse.SetAddress5 = dt.Rows[0]["Address5"];
                        oWarehouse.SetPostcode = dt.Rows[0]["Postcode"];
                        oWarehouse.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oWarehouse.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oWarehouse.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oWarehouse.SetActive = dt.Rows[0]["Active"];
                        oWarehouse.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oWarehouse.Exists = true;
                        return oWarehouse;
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

            public Warehouse Warehouse_Get(int WarehouseID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Warehouse_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@WarehouseID", WarehouseID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oWarehouse = new Warehouse();
                        oWarehouse.IgnoreExceptionsOnSetMethods = true;
                        oWarehouse.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oWarehouse.SetName = dt.Rows[0]["warehouseName"];
                        oWarehouse.SetSize = dt.Rows[0]["Size"];
                        oWarehouse.SetNotes = dt.Rows[0]["Notes"];
                        oWarehouse.SetAddress1 = dt.Rows[0]["Address1"];
                        oWarehouse.SetAddress2 = dt.Rows[0]["Address2"];
                        oWarehouse.SetAddress3 = dt.Rows[0]["Address3"];
                        oWarehouse.SetAddress4 = dt.Rows[0]["Address4"];
                        oWarehouse.SetAddress5 = dt.Rows[0]["Address5"];
                        oWarehouse.SetPostcode = dt.Rows[0]["Postcode"];
                        oWarehouse.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oWarehouse.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oWarehouse.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oWarehouse.SetActive = dt.Rows[0]["Active"];
                        oWarehouse.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oWarehouse.Exists = true;
                        return oWarehouse;
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

            public Warehouse Warehouse_GetByLocationID(int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Warehouse_GetByLocationID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oWarehouse = new Warehouse();
                        oWarehouse.IgnoreExceptionsOnSetMethods = true;
                        oWarehouse.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oWarehouse.SetName = dt.Rows[0]["warehouseName"];
                        oWarehouse.SetSize = dt.Rows[0]["Size"];
                        oWarehouse.SetNotes = dt.Rows[0]["Notes"];
                        oWarehouse.SetAddress1 = dt.Rows[0]["Address1"];
                        oWarehouse.SetAddress2 = dt.Rows[0]["Address2"];
                        oWarehouse.SetAddress3 = dt.Rows[0]["Address3"];
                        oWarehouse.SetAddress4 = dt.Rows[0]["Address4"];
                        oWarehouse.SetAddress5 = dt.Rows[0]["Address5"];
                        oWarehouse.SetPostcode = dt.Rows[0]["Postcode"];
                        oWarehouse.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oWarehouse.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oWarehouse.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oWarehouse.SetActive = dt.Rows[0]["Active"];
                        oWarehouse.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oWarehouse.Exists = true;
                        return oWarehouse;
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

            public Warehouse Warehouse_GetByLocationID(int LocationID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Warehouse_GetByLocationID";
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
                        var oWarehouse = new Warehouse();
                        oWarehouse.IgnoreExceptionsOnSetMethods = true;
                        oWarehouse.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oWarehouse.SetName = dt.Rows[0]["warehouseName"];
                        oWarehouse.SetSize = dt.Rows[0]["Size"];
                        oWarehouse.SetNotes = dt.Rows[0]["Notes"];
                        oWarehouse.SetAddress1 = dt.Rows[0]["Address1"];
                        oWarehouse.SetAddress2 = dt.Rows[0]["Address2"];
                        oWarehouse.SetAddress3 = dt.Rows[0]["Address3"];
                        oWarehouse.SetAddress4 = dt.Rows[0]["Address4"];
                        oWarehouse.SetAddress5 = dt.Rows[0]["Address5"];
                        oWarehouse.SetPostcode = dt.Rows[0]["Postcode"];
                        oWarehouse.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oWarehouse.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oWarehouse.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oWarehouse.SetActive = dt.Rows[0]["Active"];
                        oWarehouse.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oWarehouse.Exists = true;
                        return oWarehouse;
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

            public DataView Warehouse_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Warehouse_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblWarehouse.ToString();
                return new DataView(dt);
            }

            public DataView Warehouse_GetAll_For_Van2(int VanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", VanID);
                var dt = _database.ExecuteSP_DataTable("Warehouse_GetAll_For_Van2");  // rd change
                dt.TableName = Sys.Enums.TableNames.tblWarehouse.ToString();
                return new DataView(dt);
            }

            public DataView Warehouse_GetAll(SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Warehouse_GetAll";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblWarehouse.ToString();
                return new DataView(dt);
            }

            public Warehouse Insert(Warehouse oWarehouse, DataView LocationsDataView)
            {
                _database.ClearParameter();
                AddWarehouseParametersToCommand(ref oWarehouse);
                oWarehouse.SetWarehouseID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Warehouse_Insert"));
                oWarehouse.Exists = true;
                var oLocation = new Locationss.Locations();
                oLocation.SetDeleted = false;
                oLocation.SetVanID = null;
                oLocation.SetWarehouseID = oWarehouse.WarehouseID;
                App.DB.Location.Insert(oLocation);
                foreach (DataRow row in App.DB.Van.Van_GetAll(true).Table.Rows)
                {
                    var oVan = new Vans.Van();
                    oVan.SetRegistration = row["Registration"] + " * " + oWarehouse.Name;
                    oVan.SetNotes = row["Notes"];
                    oVan.InsuranceDue = Conversions.ToDate(row["InsuranceDue"]);
                    oVan.MOTDue = Conversions.ToDate(row["MOTDue"]);
                    oVan.TaxDue = Conversions.ToDate(row["TaxDue"]);
                    oVan.ServiceDue = Conversions.ToDate(row["ServiceDue"]);
                    oVan.SetMileageLimit = row["MileageLimit"];
                    oVan.SetPeriodValue = row["PeriodValue"];
                    oVan.SetPeriodType = row["PeriodType"];
                    App.DB.Van.Insert(oVan, "", null, true);
                }

                foreach (DataRow row in App.DB.Van.Van_GetAll(true).Table.Rows)
                {
                    foreach (DataRow locationRow in LocationsDataView.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Registration"], locationRow["Registration"], false)))
                        {
                            int locID = Conversions.ToInteger(App.DB.Van.Van_GetAll_For_Warehouse(oWarehouse.WarehouseID).Table.Select(Conversions.ToString("Registration = '" + row["Registration"] + "'"))[0]["LocationID"]);
                            App.DB.Location.Update(locID, Conversions.ToBoolean((!(bool)locationRow["Tick"])));
                        }
                    }
                }

                return oWarehouse;
            }

            public DataView Warehouse_Search(string criteria, string SearchOnField)
            {
                if (SearchOnField.Trim().Length > 0)
                {
                    criteria = "'%" + criteria + "%'";
                }

                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                _database.AddParameter("@SearchOnField", SearchOnField, true);
                var dt = _database.ExecuteSP_DataTable("Warehouse_Search");
                dt.TableName = Sys.Enums.TableNames.tblWarehouse.ToString();
                return new DataView(dt);
            }

            public void Update(Warehouse oWarehouse, DataView LocationsDataView)
            {
                string WarehouseName = Warehouse_Get(oWarehouse.WarehouseID).Name.Trim();
                _database.ClearParameter();
                _database.AddParameter("@WarehouseID", oWarehouse.WarehouseID, true);
                AddWarehouseParametersToCommand(ref oWarehouse);
                _database.ExecuteSP_NO_Return("Warehouse_Update");
                foreach (DataRow row in App.DB.Van.Van_GetAll(false).Table.Rows)
                {
                    if ((Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[1].Trim() ?? "") == (WarehouseName ?? ""))
                    {
                        var oVan = new Vans.Van();
                        oVan.SetVanID = row["VanID"];
                        oVan.SetRegistration = Sys.Helper.MakeStringValid(row["Registration"]).Split('*')[0].Trim() + " * " + oWarehouse.Name;
                        oVan.SetNotes = row["Notes"];
                        oVan.InsuranceDue = Conversions.ToDate(row["InsuranceDue"]);
                        oVan.MOTDue = Conversions.ToDate(row["MOTDue"]);
                        oVan.TaxDue = Conversions.ToDate(row["TaxDue"]);
                        oVan.ServiceDue = Conversions.ToDate(row["ServiceDue"]);
                        oVan.SetMileageLimit = row["MileageLimit"];
                        oVan.SetPeriodValue = row["PeriodValue"];
                        oVan.SetPeriodType = row["PeriodType"];
                        App.DB.Van.Update(oVan, LocationsDataView, true);
                    }
                }
            }

            private void AddWarehouseParametersToCommand(ref Warehouse oWarehouse)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Name", oWarehouse.Name, true);
                    withBlock.AddParameter("@Size", oWarehouse.Size, true);
                    withBlock.AddParameter("@Notes", oWarehouse.Notes, true);
                    withBlock.AddParameter("@Address1", oWarehouse.Address1, true);
                    withBlock.AddParameter("@Address2", oWarehouse.Address2, true);
                    withBlock.AddParameter("@Address3", oWarehouse.Address3, true);
                    withBlock.AddParameter("@Address4", oWarehouse.Address4, true);
                    withBlock.AddParameter("@Address5", oWarehouse.Address5, true);
                    withBlock.AddParameter("@Postcode", oWarehouse.Postcode, true);
                    withBlock.AddParameter("@TelephoneNum", oWarehouse.TelephoneNum, true);
                    withBlock.AddParameter("@FaxNum", oWarehouse.FaxNum, true);
                    withBlock.AddParameter("@EmailAddress", oWarehouse.EmailAddress, true);
                    withBlock.AddParameter("@Active", oWarehouse.Active, true);
                }
            }

            public DataView Warehouse_GetWithProduct(int ProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductID", ProductID);

                // Get the datatable from the database store in dt
                return new DataView(_database.ExecuteSP_DataTable("Warehouse_GetWithProduct"));
            }

            public DataView Warehouse_GetWithProduct(int ProductID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Warehouse_GetWithProduct";
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

            public DataView Warehouse_GetWithPart(int PartID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Warehouse_GetWithPart";
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

            public DataView Warehouse_GetWithPart(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID);

                // Get the datatable from the database store in dt
                return new DataView(_database.ExecuteSP_DataTable("Warehouse_GetWithPart"));
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}