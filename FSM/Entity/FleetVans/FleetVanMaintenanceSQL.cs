// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanMaintenanceSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
    public class FleetVanMaintenanceSQL
    {
        private Database _database;

        public FleetVanMaintenanceSQL(Database database)
        {
            this._database = database;
        }

        private void AddParametersToCommand(ref FleetVanMaintenance oFleetVan)
        {
            Database database = this._database;
            database.AddParameter("@VanID", (object)oFleetVan.VanID, true);
            database.AddParameter("@LastService", (object)oFleetVan.LastService, true);
            database.AddParameter("@NextService", (object)oFleetVan.NextService, true);
            database.AddParameter("@LastServiceMileage", (object)oFleetVan.LastServiceMileage, true);
            database.AddParameter("@MOTExpiry", (object)oFleetVan.MOTExpiry, true);
            database.AddParameter("@RoadTaxExpiry", (object)oFleetVan.RoadTaxExpiry, true);
            database.AddParameter("@Breakdown", (object)oFleetVan.Breakdown, true);
            database.AddParameter("@BreakdownExpiry", (object)oFleetVan.BreakdownExpiry, true);
            database.AddParameter("@WarrantyExpiry", (object)oFleetVan.WarrantyExpiry, true);
        }

        public FleetVanMaintenance Get(int vanMaintenanceID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanMaintenanceID", (object)vanMaintenanceID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanMaintenance_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (FleetVanMaintenance)null;
            FleetVanMaintenance fleetVanMaintenance1 = new FleetVanMaintenance();
            FleetVanMaintenance fleetVanMaintenance2 = fleetVanMaintenance1;
            fleetVanMaintenance2.IgnoreExceptionsOnSetMethods = true;
            fleetVanMaintenance2.SetVanMaintenanceID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanMaintenanceID"]);
            fleetVanMaintenance2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            fleetVanMaintenance2.LastService = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastService"]));
            fleetVanMaintenance2.NextService = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NextService"]));
            fleetVanMaintenance2.SetLastServiceMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastServiceMileage"]);
            fleetVanMaintenance2.MOTExpiry = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MOTExpiry"]));
            fleetVanMaintenance2.RoadTaxExpiry = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RoadTaxExpiry"]));
            fleetVanMaintenance2.SetBreakdown = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Breakdown"]);
            if (dataTable.Columns.Contains("WarrantyExpiry"))
                fleetVanMaintenance2.WarrantyExpiry = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarrantyExpiry"]));
            if (dataTable.Columns.Contains("BreakdownExpiry"))
                fleetVanMaintenance2.BreakdownExpiry = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BreakdownExpiry"]));
            fleetVanMaintenance1.Exists = true;
            return fleetVanMaintenance1;
        }

        public FleetVanMaintenance Get_ByVanID(int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanMaintenance_Get_ForVan", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (FleetVanMaintenance)null;
            FleetVanMaintenance fleetVanMaintenance1 = new FleetVanMaintenance();
            FleetVanMaintenance fleetVanMaintenance2 = fleetVanMaintenance1;
            fleetVanMaintenance2.IgnoreExceptionsOnSetMethods = true;
            fleetVanMaintenance2.SetVanMaintenanceID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanMaintenanceID"]);
            fleetVanMaintenance2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            fleetVanMaintenance2.LastService = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastService"]));
            fleetVanMaintenance2.NextService = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NextService"]));
            fleetVanMaintenance2.SetLastServiceMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastServiceMileage"]);
            fleetVanMaintenance2.MOTExpiry = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MOTExpiry"]));
            fleetVanMaintenance2.RoadTaxExpiry = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RoadTaxExpiry"]));
            fleetVanMaintenance2.SetBreakdown = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Breakdown"]);
            if (dataTable.Columns.Contains("WarrantyExpiry"))
                fleetVanMaintenance2.WarrantyExpiry = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarrantyExpiry"]));
            if (dataTable.Columns.Contains("BreakdownExpiry"))
                fleetVanMaintenance2.BreakdownExpiry = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BreakdownExpiry"]));
            fleetVanMaintenance1.Exists = true;
            return fleetVanMaintenance1;
        }

        public bool Update(FleetVanMaintenance oVan)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanMaintenanceID", (object)oVan.VanMaintenanceID, true);
            this.AddParametersToCommand(ref oVan);
            return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVanMaintenance_Update", true), (object)1, false);
        }

        public FleetVanMaintenance Insert(FleetVanMaintenance van)
        {
            this._database.ClearParameter();
            this.AddParametersToCommand(ref van);
            van.SetVanMaintenanceID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("FleetVanMaintenance_Insert", true)));
            van.Exists = true;
            return van;
        }
    }
}