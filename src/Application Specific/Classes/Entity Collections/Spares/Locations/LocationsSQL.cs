using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Locationss
    {
        public class LocationsSQL
        {
            private Sys.Database _database;

            public LocationsSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID, true);
                _database.ExecuteSP_NO_Return("Locations_Delete");
            }

            public Locations Locations_Get(int LocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Locations_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oLocations = new Locations();
                        oLocations.IgnoreExceptionsOnSetMethods = true;
                        oLocations.SetLocationID = dt.Rows[0]["LocationID"];
                        oLocations.SetVanID = dt.Rows[0]["VanID"];
                        oLocations.SetWarehouseID = dt.Rows[0]["WarehouseID"];
                        oLocations.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oLocations.Exists = true;
                        return oLocations;
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

            public DataView Locations_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Locations_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }

            public DataView Locations_Get_ForVanReg(string VanReg)
            {
                _database.ClearParameter();
                _database.AddParameter("@Reg", VanReg, true);
                var dt = _database.ExecuteSP_DataTable("Locations_Get_ForVanReg_ActiveOnly");  // ' Why would it be pulling deleted ones? I changed this to not.
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }

            public DataView Locations_Get_ForVanReg_ActiveOnly(string VanReg)
            {
                _database.ClearParameter();
                _database.AddParameter("@Reg", VanReg, true);
                var dt = _database.ExecuteSP_DataTable("Locations_Get_ForVanReg_ActiveOnly");
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }

            public DataView Locations_GetAll_WithNames(SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Locations_GetAll_WithNames";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                return new DataView(dt);
            }

            public DataView Locations_GetAll_WithNames()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Locations_GetAll_WithNames");
                dt.TableName = Sys.Enums.TableNames.tblLocations.ToString();
                return new DataView(dt);
            }

            public DataView StockTake_GetAll(bool ShowOnlyWithLocation, int CategoryID, int WarehouseID, int VanID, bool ExpectedNotZero, bool ShowWarehousesOnly, bool ShowVansOnly)
            {
                _database.ClearParameter();
                if (ShowOnlyWithLocation)
                {
                    _database.AddParameter("@ShowOnlyWithLocation", 1, true);
                }
                else
                {
                    _database.AddParameter("@ShowOnlyWithLocation", 0, true);
                }

                if (ExpectedNotZero)
                {
                    _database.AddParameter("@ExpectedNotZero", 1, true);
                }
                else
                {
                    _database.AddParameter("@ExpectedNotZero", 0, true);
                }

                _database.AddParameter("@CategoryID", CategoryID, true);
                _database.AddParameter("@WarehouseID", WarehouseID, true);
                _database.AddParameter("@VanID", VanID, true);
                if (ShowWarehousesOnly)
                {
                    _database.AddParameter("@ShowWarehousesOnly", 1, true);
                }
                else
                {
                    _database.AddParameter("@ShowWarehousesOnly", 0, true);
                }

                if (ShowVansOnly)
                {
                    _database.AddParameter("@ShowVansOnly", 1, true);
                }
                else
                {
                    _database.AddParameter("@ShowVansOnly", 0, true);
                }

                var dt = _database.ExecuteSP_DataTable("StockTake_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblStock.ToString();
                return new DataView(dt);
            }

            public DataView StockTake_GetAll_WithName(bool ShowOnlyWithLocation, int CategoryID, int WarehouseID, int VanID, bool ExpectedNotZero, bool ShowWarehousesOnly, bool ShowVansOnly, string MPN)
            {
                _database.ClearParameter();
                if (ShowOnlyWithLocation)
                {
                    _database.AddParameter("@ShowOnlyWithLocation", 1, true);
                }
                else
                {
                    _database.AddParameter("@ShowOnlyWithLocation", 0, true);
                }

                if (ExpectedNotZero)
                {
                    _database.AddParameter("@ExpectedNotZero", 1, true);
                }
                else
                {
                    _database.AddParameter("@ExpectedNotZero", 0, true);
                }

                _database.AddParameter("@CategoryID", CategoryID, true);
                _database.AddParameter("@WarehouseID", WarehouseID, true);
                _database.AddParameter("@VanID", VanID, true);
                if (ShowWarehousesOnly)
                {
                    _database.AddParameter("@ShowWarehousesOnly", 1, true);
                }
                else
                {
                    _database.AddParameter("@ShowWarehousesOnly", 0, true);
                }

                if (ShowVansOnly)
                {
                    _database.AddParameter("@ShowVansOnly", 1, true);
                }
                else
                {
                    _database.AddParameter("@ShowVansOnly", 0, true);
                }

                _database.AddParameter("@MPN", MPN, true);
                var dt = _database.ExecuteSP_DataTable("StockTake_GetAll_PartName");
                dt.TableName = Sys.Enums.TableNames.tblStock.ToString();
                return new DataView(dt);
            }

            // Public Function StockTake_Replenishment_GetAll() As DataView
            // _database.ClearParameter()

            // Dim dt As DataTable = _database.ExecuteSP_DataTable("StockTake_Replenishment_GetAll")
            // dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
            // Return New DataView(dt)
            // End Function

            public DataView StockTake_Replenishment_Filtered(string Location, string Item, bool IncludeVans, bool LessMin, bool LessRec)

            {
                _database.ClearParameter();
                _database.AddParameter("@Location", Location, true);
                _database.AddParameter("@Item", Item, true);
                _database.AddParameter("@IncludeVans", IncludeVans, true);
                _database.AddParameter("@LessMin", LessMin, true);
                _database.AddParameter("@LessRec", LessRec, true);
                var dt = _database.ExecuteSP_DataTable("StockTake_Replenishment_Filtered");
                dt.TableName = Sys.Enums.TableNames.tblStock.ToString();
                return new DataView(dt);
            }

            public DataView StockTake_Replenishment_UpdateExclude(int ItemID, bool Exclude)
            {
                _database.ClearParameter();
                _database.AddParameter("@ItemID", ItemID, true);
                _database.AddParameter("@Exclude", Exclude, true);
                _database.ExecuteSP_NO_Return("StockTake_Replenishment_Daily_UpdateExclude");
                return default;
            }

            public DataView StockTake_Replenishment_UpdateAmountToOrder(int ItemID, int AmountToOrder)
            {
                _database.ClearParameter();
                _database.AddParameter("@ItemID", ItemID, true);
                _database.AddParameter("@AmountToOrder", AmountToOrder, true);
                _database.ExecuteSP_NO_Return("StockTake_Replenishment_Daily_UpdateAmountToOrder");
                return default;
            }

            public DataView StockTakeReason_Get()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("StockReason_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblStock.ToString();
                return new DataView(dt);
            }

            public Locations Insert(Locations oLocations)
            {
                _database.ClearParameter();
                AddLocationsParametersToCommand(ref oLocations);
                oLocations.SetLocationID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Locations_Insert"));
                oLocations.Exists = true;
                return oLocations;
            }

            public void Update(int LocationID, bool Deleted)
            {
                _database.ClearParameter();
                _database.AddParameter("@LocationID", LocationID, true);
                if (Deleted)
                {
                    _database.AddParameter("@Deleted", 1, true);
                }
                else
                {
                    _database.AddParameter("@Deleted", 0, true);
                }

                _database.ExecuteSP_NO_Return("Locations_Update");
            }

            private void AddLocationsParametersToCommand(ref Locations oLocations)
            {
                {
                    var withBlock = _database;
                    if (oLocations.VanID == 0)
                    {
                        withBlock.AddParameter("@VanID", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@VanID", oLocations.VanID, true);
                    }

                    if (oLocations.WarehouseID == 0)
                    {
                        withBlock.AddParameter("@WarehouseID", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@WarehouseID", oLocations.WarehouseID, true);
                    }
                }
            }

            public void IPT_Audit_Insert(int PartID, int ProductID, int FromLocationID, int ToLocationID, int Quantity)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@ProductID", ProductID, true);
                _database.AddParameter("@FromLocationID", FromLocationID, true);
                _database.AddParameter("@ToLocationID", ToLocationID, true);
                _database.AddParameter("@Quantity", Quantity, true);
                _database.AddParameter("@MovedByUserID", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("IPT_Audit_Insert");
            }

            public DataView IPT_Audit_Get(string Type, string Name, string Number, string Reference, int FromLocationID, int ToLocationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@Type", Type, true);
                _database.AddParameter("@Name", Name, true);
                _database.AddParameter("@Number", Number, true);
                _database.AddParameter("@Reference", Reference, true);
                _database.AddParameter("@FromLocationID", FromLocationID, true);
                _database.AddParameter("@ToLocationID", ToLocationID, true);
                var dt = _database.ExecuteSP_DataTable("IPT_Audit_Get");
                dt.TableName = Sys.Enums.TableNames.tblIPTAudit.ToString();
                return new DataView(dt);
            }
        }
    }
}