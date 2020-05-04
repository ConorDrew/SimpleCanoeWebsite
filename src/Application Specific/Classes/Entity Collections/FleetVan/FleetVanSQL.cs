using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace FleetVans
    {
        public class FleetSQL
        {
            private Sys.Database _database;

            public FleetSQL(Sys.Database database)
            {
                _database = database;
            }

            public DataView FleetJobType_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetJobType_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblFleetJobType.ToString();
                return new DataView(dt);
            }
        }

        public class FleetVanSQL
        {
            private Sys.Database _database;

            public FleetVanSQL(Sys.Database database)
            {
                _database = database;
            }

            private void AddParametersToCommand(ref FleetVan oFleetVan)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Registration", oFleetVan.Registration, true);
                    withBlock.AddParameter("@VanTypeID", oFleetVan.VanTypeID, true);
                    withBlock.AddParameter("@Mileage", oFleetVan.Mileage, true);
                    withBlock.AddParameter("@AverageMileage", oFleetVan.AverageMileage, true);
                    withBlock.AddParameter("@Department", oFleetVan.Department, true);
                    withBlock.AddParameter("@Notes", oFleetVan.Notes, true);
                    withBlock.AddParameter("@TyreSize", oFleetVan.TyreSize, true);
                }
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetVan_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanType.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_Returned()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetVan_GetAll_Returned");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanType.ToString();
                return new DataView(dt);
            }

            public FleetVan Get(int vanId)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanId);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVan_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new FleetVan();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetRegistration = dt.Rows[0]["Registration"];
                        oVan.SetVanTypeID = dt.Rows[0]["VanTypeID"];
                        oVan.SetMileage = dt.Rows[0]["Mileage"];
                        oVan.SetAverageMileage = dt.Rows[0]["AverageMileage"];
                        oVan.SetDepartment = dt.Rows[0]["Department"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.SetReturned = Sys.Helper.MakeBooleanValid(dt.Rows[0]["Returned"]);
                        if (dt.Columns.Contains("TyreSize"))
                            oVan.SetTyreSize = dt.Rows[0]["TyreSize"];
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

            public FleetVan Get_ByRegistration(string registration)
            {
                _database.ClearParameter();
                _database.AddParameter("@Registration", registration);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVan_Get_ByRegistrationTrim");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new FleetVan();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetRegistration = dt.Rows[0]["Registration"];
                        oVan.SetVanTypeID = dt.Rows[0]["VanTypeID"];
                        oVan.SetMileage = dt.Rows[0]["Mileage"];
                        oVan.SetAverageMileage = dt.Rows[0]["AverageMileage"];
                        oVan.SetDepartment = dt.Rows[0]["Department"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.SetReturned = Sys.Helper.MakeBooleanValid(dt.Rows[0]["Returned"]);
                        if (dt.Columns.Contains("TyreSize"))
                            oVan.SetTyreSize = dt.Rows[0]["TyreSize"];
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

            public int Get_NextVanID()
            {
                _database.ClearParameter();
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVan_Get_NextVan"));
            }

            public bool Update(FleetVan oVan)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", oVan.VanID, true);
                AddParametersToCommand(ref oVan);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVan_Update"), 1, false));
            }

            public FleetVan Insert(FleetVan van)
            {
                _database.ClearParameter();
                AddParametersToCommand(ref van);
                van.SetVanID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVan_Insert"));
                van.Exists = true;
                return van;
            }

            public DataView Search(string Criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", Criteria, true);
                var dt = _database.ExecuteSP_DataTable("FleetVan_Search");
                dt.TableName = Sys.Enums.TableNames.tblFleetVan.ToString();
                return new DataView(dt);
            }

            public bool ReturnVan(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID, true);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVan_ReturnVan"), 1, false));
            }

            public DataView VanAudit_Get(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@FleetVanID", vanID, true);
                var dt = _database.ExecuteSP_DataTable("FleetVanAudit_Get");
                dt.TableName = Sys.Enums.TableNames.tblEquipmentAudit.ToString();
                return new DataView(dt);
            }

            public void VanAudit_Insert(int vanID, string actionChange)
            {
                _database.ClearParameter();
                _database.AddParameter("@FleetVanID", vanID, true);
                _database.AddParameter("@ActionChange", actionChange, true);
                _database.AddParameter("@ActionDateTime", DateTime.Now, true);
                _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("FleetVanAudit_Insert");
            }
        }

        public class FleetVanTypeSQL
        {
            private Sys.Database _database;

            public FleetVanTypeSQL(Sys.Database database)
            {
                _database = database;
            }

            private void AddParametersToCommand(ref FleetVanType oFleetVanType)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Make", oFleetVanType.Make, true);
                    withBlock.AddParameter("@Model", oFleetVanType.Model, true);
                    withBlock.AddParameter("@MileageServiceInterval", oFleetVanType.MileageServiceInterval, true);
                    withBlock.AddParameter("@DateServiceInterval", oFleetVanType.DateServiceInterval, true);
                    withBlock.AddParameter("@GrossVehicleWeight", oFleetVanType.GrossVehicleWeight, true);
                    withBlock.AddParameter("@Payload", oFleetVanType.Payload, true);
                }
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetVanType_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanType.ToString();
                return new DataView(dt);
            }

            public FleetVanType Get(int vanTypeId)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanTypeID", vanTypeId);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanType_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVanType = new FleetVanType();
                        oVanType.IgnoreExceptionsOnSetMethods = true;
                        oVanType.SetVanTypeID = dt.Rows[0]["VanTypeID"];
                        oVanType.SetMake = dt.Rows[0]["Make"];
                        oVanType.SetModel = dt.Rows[0]["Model"];
                        oVanType.SetMileageServiceInterval = dt.Rows[0]["MileageServiceInterval"];
                        oVanType.SetDateServiceInterval = dt.Rows[0]["DateServiceInterval"];
                        if (dt.Columns.Contains("GrossVehicleWeight"))
                            oVanType.SetGrossVehicleWeight = dt.Rows[0]["GrossVehicleWeight"];
                        if (dt.Columns.Contains("Payload"))
                            oVanType.SetPayload = dt.Rows[0]["Payload"];
                        oVanType.Exists = true;
                        return oVanType;
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

            public FleetVanType Insert(FleetVanType vanType)
            {
                _database.ClearParameter();
                AddParametersToCommand(ref vanType);
                vanType.SetVanTypeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanType_Insert"));
                vanType.Exists = true;
                return vanType;
            }

            public bool Update(FleetVanType vanType)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanTypeID", vanType.VanTypeID, true);
                AddParametersToCommand(ref vanType);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVanType_Update"), 1, false));
            }

            public bool Delete(int vanTypeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanTypeID", vanTypeID, true);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVanType_Delete"), 1, false));
            }

            public DataView Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                var dt = _database.ExecuteSP_DataTable("FleetVanType_Search");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanType.ToString();
                return new DataView(dt);
            }
        }

        public class FleetVanEngineerSQL
        {
            private Sys.Database _database;

            public FleetVanEngineerSQL(Sys.Database database)
            {
                _database = database;
            }

            private void AddParametersToCommand(ref FleetVanEngineer oFleetVan)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@VanID", oFleetVan.VanID, true);
                    withBlock.AddParameter("@EngineerID", oFleetVan.EngineerID, true);
                    withBlock.AddParameter("@StartDateTime", oFleetVan.StartDate, true);
                    withBlock.AddParameter("@EndDateTime", Interaction.IIf(oFleetVan.EndDate != default, oFleetVan.EndDate, DBNull.Value), true);
                }
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetVanEngineer_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanType.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_ByVanID(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);
                var dt = _database.ExecuteSP_DataTable("FleetVanEngineer_GetAll_ForVan");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanFault.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_ByEngineerID(int engineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", engineerID);
                var dt = _database.ExecuteSP_DataTable("FleetVanEngineer_Get_EngineerID");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanFault.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_Trans(string where)
            {
                _database.ClearParameter();
                _database.AddParameter("@Where", where, true);
                var dt = _database.ExecuteSP_DataTable("FleetVanEngineer_GetAll_Trans");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanFault.ToString();
                return new DataView(dt);
            }

            public FleetVanEngineer Get(int vanEngineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanEngineerID", vanEngineerID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanEngineer_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVanEngineer = new FleetVanEngineer();
                        oVanEngineer.IgnoreExceptionsOnSetMethods = true;
                        oVanEngineer.SetVanEngineerID = dt.Rows[0]["VanEngineerID"];
                        oVanEngineer.SetVanID = dt.Rows[0]["VanID"];
                        oVanEngineer.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oVanEngineer.StartDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["StartDateTime"]);
                        oVanEngineer.EndDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["EndDateTime"]);
                        oVanEngineer.Exists = true;
                        return oVanEngineer;
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

            public FleetVanEngineer Get_ByVanID(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanEngineer_Get_VanID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVanEngineer = new FleetVanEngineer();
                        oVanEngineer.IgnoreExceptionsOnSetMethods = true;
                        oVanEngineer.SetVanEngineerID = dt.Rows[0]["VanEngineerID"];
                        oVanEngineer.SetVanID = dt.Rows[0]["VanID"];
                        oVanEngineer.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oVanEngineer.StartDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["StartDateTime"]);
                        oVanEngineer.EndDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["EndDateTime"]);
                        oVanEngineer.Exists = true;
                        return oVanEngineer;
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

            public bool Update(FleetVanEngineer oVan)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanEngineerID", oVan.VanEngineerID, true);
                AddParametersToCommand(ref oVan);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVanEngineer_Update"), 1, false));
            }

            public FleetVanEngineer Insert(FleetVanEngineer van)
            {
                _database.ClearParameter();
                AddParametersToCommand(ref van);
                van.SetVanEngineerID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanEngineer_Insert"));
                van.Exists = true;
                return van;
            }

            public bool Delete(int oVanEngineerID, DateTime endDate = default)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanEngineerID", oVanEngineerID, true);
                if (endDate != default)
                {
                    _database.AddParameter("@EndDate", endDate, true);
                }

                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVanEngineer_Delete"), 1, false));
            }
        }

        public class FleetVanMaintenanceSQL
        {
            private Sys.Database _database;

            public FleetVanMaintenanceSQL(Sys.Database database)
            {
                _database = database;
            }

            private void AddParametersToCommand(ref FleetVanMaintenance oFleetVan)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@VanID", oFleetVan.VanID, true);
                    withBlock.AddParameter("@LastService", oFleetVan.LastService, true);
                    withBlock.AddParameter("@NextService", oFleetVan.NextService, true);
                    withBlock.AddParameter("@LastServiceMileage", oFleetVan.LastServiceMileage, true);
                    withBlock.AddParameter("@MOTExpiry", oFleetVan.MOTExpiry, true);
                    withBlock.AddParameter("@RoadTaxExpiry", oFleetVan.RoadTaxExpiry, true);
                    withBlock.AddParameter("@Breakdown", oFleetVan.Breakdown, true);
                    withBlock.AddParameter("@BreakdownExpiry", oFleetVan.BreakdownExpiry, true);
                    withBlock.AddParameter("@WarrantyExpiry", oFleetVan.WarrantyExpiry, true);
                }
            }

            public FleetVanMaintenance Get(int vanMaintenanceID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanMaintenanceID", vanMaintenanceID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanMaintenance_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new FleetVanMaintenance();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanMaintenanceID = dt.Rows[0]["VanMaintenanceID"];
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.LastService = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["LastService"]);
                        oVan.NextService = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["NextService"]);
                        oVan.SetLastServiceMileage = dt.Rows[0]["LastServiceMileage"];
                        oVan.MOTExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["MOTExpiry"]);
                        oVan.RoadTaxExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["RoadTaxExpiry"]);
                        oVan.SetBreakdown = dt.Rows[0]["Breakdown"];
                        if (dt.Columns.Contains("WarrantyExpiry"))
                            oVan.WarrantyExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["WarrantyExpiry"]);
                        if (dt.Columns.Contains("BreakdownExpiry"))
                            oVan.BreakdownExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["BreakdownExpiry"]);
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

            public FleetVanMaintenance Get_ByVanID(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanMaintenance_Get_ForVan");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new FleetVanMaintenance();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanMaintenanceID = dt.Rows[0]["VanMaintenanceID"];
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.LastService = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["LastService"]);
                        oVan.NextService = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["NextService"]);
                        oVan.SetLastServiceMileage = dt.Rows[0]["LastServiceMileage"];
                        oVan.MOTExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["MOTExpiry"]);
                        oVan.RoadTaxExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["RoadTaxExpiry"]);
                        oVan.SetBreakdown = dt.Rows[0]["Breakdown"];
                        if (dt.Columns.Contains("WarrantyExpiry"))
                            oVan.WarrantyExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["WarrantyExpiry"]);
                        if (dt.Columns.Contains("BreakdownExpiry"))
                            oVan.BreakdownExpiry = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["BreakdownExpiry"]);
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

            public bool Update(FleetVanMaintenance oVan)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanMaintenanceID", oVan.VanMaintenanceID, true);
                AddParametersToCommand(ref oVan);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVanMaintenance_Update"), 1, false));
            }

            public FleetVanMaintenance Insert(FleetVanMaintenance van)
            {
                _database.ClearParameter();
                AddParametersToCommand(ref van);
                van.SetVanMaintenanceID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanMaintenance_Insert"));
                van.Exists = true;
                return van;
            }
        }

        public class FleetVanFaultSQL
        {
            private Sys.Database _database;

            public FleetVanFaultSQL(Sys.Database database)
            {
                _database = database;
            }

            private void AddParametersToCommand(ref FleetVanFault oFleetVan)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@VanID", oFleetVan.VanID, true);
                    withBlock.AddParameter("@FaultTypeID", oFleetVan.FaultTypeID, true);
                    withBlock.AddParameter("@FaultDate", oFleetVan.FaultDate, true);
                    if (oFleetVan.ResolvedDate != default)
                    {
                        withBlock.AddParameter("@ResolvedDate", oFleetVan.ResolvedDate, true);
                    }

                    withBlock.AddParameter("@EngineerNotes", oFleetVan.EngineerNotes, true);
                    withBlock.AddParameter("@Notes", oFleetVan.Notes, true);
                    withBlock.AddParameter("@JobID", oFleetVan.JobID, true);
                    withBlock.AddParameter("@UserID", App.loggedInUser.UserID, true);
                    withBlock.AddParameter("@Archive", oFleetVan.Archive, true);
                }
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetVanFault_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanFault.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_Trans(string where)
            {
                _database.ClearParameter();
                _database.AddParameter("@Where", where, true);
                var dt = _database.ExecuteSP_DataTable("FleetVanFault_GetAll_Trans");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanFault.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_Unresolved_WithNoJob()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetVanFault_GetAll_Unresolved_WithNoJob");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanFault.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_ByVanID(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);
                var dt = _database.ExecuteSP_DataTable("FleetVanFault_GetAll_ForVan");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanFault.ToString();
                return new DataView(dt);
            }

            public FleetVanFault Get(int vanFaultID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanFaultID", vanFaultID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanFault_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new FleetVanFault();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanFaultID = dt.Rows[0]["VanFaultID"];
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetFaultTypeID = dt.Rows[0]["FaultType"];
                        oVan.FaultDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["FaultDate"]);
                        if (dt.Rows[0]["ResolvedDate"] != DBNull.Value)
                        {
                            oVan.ResolvedDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["ResolvedDate"]);
                        }

                        oVan.SetEngineerNotes = dt.Rows[0]["EngineerNotes"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.SetJobID = dt.Rows[0]["JobID"];
                        oVan.SetArchive = Conversions.ToBoolean(dt.Rows[0]["Archive"]);
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

            public FleetVanFault Get_ByJobID(int jobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanFault_Get_ForJob");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new FleetVanFault();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanFaultID = dt.Rows[0]["VanFaultID"];
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetFaultTypeID = dt.Rows[0]["FaultType"];
                        oVan.FaultDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["FaultDate"]);
                        if (dt.Rows[0]["ResolvedDate"] != DBNull.Value)
                        {
                            oVan.ResolvedDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["ResolvedDate"]);
                        }

                        oVan.SetEngineerNotes = dt.Rows[0]["EngineerNotes"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.SetJobID = dt.Rows[0]["JobID"];
                        oVan.SetArchive = Conversions.ToBoolean(dt.Rows[0]["Archive"]);
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

            public bool Update(FleetVanFault oVan)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanFaultID", oVan.VanFaultID, true);
                AddParametersToCommand(ref oVan);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVanFault_Update"), 1, false));
            }

            public FleetVanFault Insert(FleetVanFault van)
            {
                _database.ClearParameter();
                AddParametersToCommand(ref van);
                van.SetFaultTypeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanFault_Insert"));
                van.Exists = true;
                return van;
            }

            public DataView FaultTypes_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetVanFaultType_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanFault.ToString();
                return new DataView(dt);
            }
        }

        public class FleetVanContractSQL
        {
            private Sys.Database _database;

            public FleetVanContractSQL(Sys.Database database)
            {
                _database = database;
            }

            private void AddParametersToCommand(ref FleetVanContract oFleetVan)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@VanID", oFleetVan.VanID, true);
                    withBlock.AddParameter("@Lessor", oFleetVan.Lessor, true);
                    withBlock.AddParameter("@ProcurementMethod", oFleetVan.ProcurementMethod, true);
                    withBlock.AddParameter("@ContractLength", oFleetVan.ContractLength, true);
                    withBlock.AddParameter("@StartDateTime", oFleetVan.ContractStart, true);
                    if (oFleetVan.ContractEnd != default)
                    {
                        withBlock.AddParameter("@EndDateTime", oFleetVan.ContractEnd, true);
                    }

                    withBlock.AddParameter("@ContractMileage", oFleetVan.ContractMileage, true);
                    withBlock.AddParameter("@StartingMileage", oFleetVan.StartingMileage, true);
                    withBlock.AddParameter("@ExcessMileageRate", oFleetVan.ExcessMileageRate, true);
                    withBlock.AddParameter("@WeeklyRental", oFleetVan.WeeklyRental, true);
                    withBlock.AddParameter("@MonthlyRental", oFleetVan.MonthlyRental, true);
                    withBlock.AddParameter("@AnnualRental", oFleetVan.AnnualRental, true);
                    withBlock.AddParameter("@ExcessMileageCost", oFleetVan.ExcessMileageCost, true);
                    withBlock.AddParameter("@ForecastExcessMileageCost", oFleetVan.ForecastExcessMileageCost, true);
                    withBlock.AddParameter("@AgreementRef", oFleetVan.AgreementRef, true);
                    withBlock.AddParameter("@Notes", oFleetVan.Notes, true);
                }
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetVanContract_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanContract.ToString();
                return new DataView(dt);
            }

            public FleetVanContract Get(int vanContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanContractID", vanContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanContract_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new FleetVanContract();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanContractID = dt.Rows[0]["VanContractID"];
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetLessor = dt.Rows[0]["Lessor"];
                        oVan.SetProcurementMethod = dt.Rows[0]["ProcurementMethod"];
                        oVan.SetContractLength = dt.Rows[0]["ContractLength"];
                        oVan.ContractStart = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["StartDateTime"]);
                        oVan.ContractEnd = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["EndDateTime"]);
                        oVan.SetContractMileage = dt.Rows[0]["ContractMileage"];
                        oVan.SetStartingMileage = dt.Rows[0]["StartingMileage"];
                        oVan.SetExcessMileageRate = dt.Rows[0]["ExcessMileageRate"];
                        oVan.SetWeeklyRental = dt.Rows[0]["WeeklyRental"];
                        oVan.SetMonthlyRental = dt.Rows[0]["MonthlyRental"];
                        oVan.SetAnnualRental = dt.Rows[0]["AnnualRental"];
                        oVan.SetAgreementRef = dt.Rows[0]["AgreementRef"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.SetExcessMileageCost = dt.Rows[0]["ExcessMileageCost"];
                        oVan.SetForecastExcessMileageCost = dt.Rows[0]["ForecastExcessMileageCost"];
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

            public FleetVanContract Get_ByVanID(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetVanContract_Get_ForVan");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVan = new FleetVanContract();
                        oVan.IgnoreExceptionsOnSetMethods = true;
                        oVan.SetVanContractID = dt.Rows[0]["VanContractID"];
                        oVan.SetVanID = dt.Rows[0]["VanID"];
                        oVan.SetLessor = dt.Rows[0]["Lessor"];
                        oVan.SetProcurementMethod = dt.Rows[0]["ProcurementMethod"];
                        oVan.SetContractLength = dt.Rows[0]["ContractLength"];
                        oVan.ContractStart = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["StartDateTime"]);
                        oVan.ContractEnd = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["EndDateTime"]);
                        oVan.SetContractMileage = dt.Rows[0]["ContractMileage"];
                        oVan.SetStartingMileage = dt.Rows[0]["StartingMileage"];
                        oVan.SetExcessMileageRate = dt.Rows[0]["ExcessMileageRate"];
                        oVan.SetWeeklyRental = dt.Rows[0]["WeeklyRental"];
                        oVan.SetMonthlyRental = dt.Rows[0]["MonthlyRental"];
                        oVan.SetAnnualRental = dt.Rows[0]["AnnualRental"];
                        oVan.SetAgreementRef = dt.Rows[0]["AgreementRef"];
                        oVan.SetNotes = dt.Rows[0]["Notes"];
                        oVan.SetExcessMileageCost = dt.Rows[0]["ExcessMileageCost"];
                        oVan.SetForecastExcessMileageCost = dt.Rows[0]["ForecastExcessMileageCost"];
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

            public bool Update(FleetVanContract oVan)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanContractID", oVan.VanContractID, true);
                AddParametersToCommand(ref oVan);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetVanContract_Update"), 1, false));
            }

            public FleetVanContract Insert(FleetVanContract van)
            {
                _database.ClearParameter();
                AddParametersToCommand(ref van);
                van.SetVanContractID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetVanContract_Insert"));
                van.Exists = true;
                return van;
            }
        }

        public class FleetVanServiceSQL
        {
            private Sys.Database _database;

            public FleetVanServiceSQL(Sys.Database database)
            {
                _database = database;
            }

            public DataView GetServices_ByVanId(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);
                var dt = _database.ExecuteSP_DataTable("FleetVanService_GetJobs_ForVan");
                dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
                return new DataView(dt);
            }

            public int GetVanId_ByJobId(int jobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobID);

                // Get the datatable from the database store in dt
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("FleetVanService_GetVan_ForJob"));
            }

            public int Update(int jobID, int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);
                _database.AddParameter("@JobID", jobID);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("FleetVanService_Update"));
            }

            public int Insert(int jobID, int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);
                _database.AddParameter("@JobID", jobID);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("FleetVanService_Insert"));
            }

            public void Delete(int jobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobID);
                _database.ExecuteSP_NO_Return("FleetVanService_Delete");
            }
        }

        public class FleetEquipmentSQL
        {
            private Sys.Database _database;

            public FleetEquipmentSQL(Sys.Database database)
            {
                _database = database;
            }

            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("FleetEquipment_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblFleetEquipment.ToString();
                return new DataView(dt);
            }

            public FleetEquipment Get(int equipmentId)
            {
                _database.ClearParameter();
                _database.AddParameter("@EquipmentID", equipmentId);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("FleetEquipment_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVanType = new FleetEquipment();
                        oVanType.IgnoreExceptionsOnSetMethods = true;
                        oVanType.SetEquipmentID = dt.Rows[0]["EquipmentID"];
                        oVanType.SetName = dt.Rows[0]["Name"];
                        oVanType.SetDescription = dt.Rows[0]["Description"];
                        oVanType.SetCost = dt.Rows[0]["Cost"];
                        oVanType.Exists = true;
                        return oVanType;
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

            public int GetActiveCount(int equipmentId)
            {
                _database.ClearParameter();
                _database.AddParameter("@EquipmentID", equipmentId, true);
                int siteCount = Conversions.ToInteger(_database.SP_ExecuteScalar("FleetEquipment_Get_ActiveCount"));
                return siteCount;
            }

            public FleetEquipment Insert(FleetEquipment oEquipment)
            {
                _database.ClearParameter();
                _database.AddParameter("@Name", oEquipment.Name, true);
                _database.AddParameter("@Description", oEquipment.Description, true);
                _database.AddParameter("@Cost", oEquipment.Cost, true);
                oEquipment.SetEquipmentID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("FleetEquipment_Insert"));
                oEquipment.Exists = true;
                return oEquipment;
            }

            public bool Update(FleetEquipment oEquipment)
            {
                _database.ClearParameter();
                _database.AddParameter("@EquipmentID", oEquipment.EquipmentID, true);
                _database.AddParameter("@Name", oEquipment.Name, true);
                _database.AddParameter("@Description", oEquipment.Description, true);
                _database.AddParameter("@Cost", oEquipment.Cost, true);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetEquipment_Update"), 1, false));
            }

            public bool Delete(int equipmentId)
            {
                _database.ClearParameter();
                _database.AddParameter("@EquipmentID", equipmentId, true);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("FleetEquipment_Delete"), 1, false));
            }

            public DataView Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                var dt = _database.ExecuteSP_DataTable("FleetEquipment_Search");
                dt.TableName = Sys.Enums.TableNames.tblFleetEquipment.ToString();
                return new DataView(dt);
            }
        }

        public class FleetVanEquipmentSQL
        {
            private Sys.Database _database;

            public FleetVanEquipmentSQL(Sys.Database database)
            {
                _database = database;
            }

            public DataView Get(int vanEquipmentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanEquipmentID", vanEquipmentID);
                var dt = _database.ExecuteSP_DataTable("FleetVanEquipment_Get");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanEquipment.ToString();
                return new DataView(dt);
            }

            public DataView Get_ByVanID(int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);
                var dt = _database.ExecuteSP_DataTable("FleetVanEquipment_Get_ForVan");
                dt.TableName = Sys.Enums.TableNames.tblFleetVanEquipment.ToString();
                return new DataView(dt);
            }

            public int Insert(int vanID, int equipmentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);
                _database.AddParameter("@EquipmentID", equipmentID);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("FleetVanEquipment_Insert"));
            }

            public int Check(int vanID, int equipmentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanID", vanID);
                _database.AddParameter("@EquipmentID", equipmentID);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("FleetVanEquipment_Check"));
            }

            public void Update(int vanEquipmentID, int vanID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanEquipmentID", vanEquipmentID);
                _database.AddParameter("@VanID", vanID);
                _database.ExecuteSP_NO_Return("FleetVanEquipment_Update");
            }

            public void Delete(int vanEquipmentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VanEquipmentID", vanEquipmentID);
                _database.ExecuteSP_NO_Return("FleetVanEquipment_Delete");
            }
        }
    }
}