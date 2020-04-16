// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
    public class FleetVanSQL
    {
        private Database _database;

        public FleetVanSQL(Database database)
        {
            this._database = database;
        }

        private void AddParametersToCommand(ref FleetVan oFleetVan)
        {
            Database database = this._database;
            database.AddParameter("@Registration", (object)oFleetVan.Registration, true);
            database.AddParameter("@VanTypeID", (object)oFleetVan.VanTypeID, true);
            database.AddParameter("@Mileage", (object)oFleetVan.Mileage, true);
            database.AddParameter("@AverageMileage", (object)oFleetVan.AverageMileage, true);
            database.AddParameter("@Department", (object)oFleetVan.Department, true);
            database.AddParameter("@Notes", (object)oFleetVan.Notes, true);
            database.AddParameter("@TyreSize", (object)oFleetVan.TyreSize, true);
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("FleetVan_GetAll", true);
            table.TableName = Enums.TableNames.tblFleetVanType.ToString();
            return new DataView(table);
        }

        public DataView GetAll_Returned()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("FleetVan_GetAll_Returned", true);
            table.TableName = Enums.TableNames.tblFleetVanType.ToString();
            return new DataView(table);
        }

        public FleetVan Get(int vanId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanId, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVan_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (FleetVan)null;
            FleetVan fleetVan1 = new FleetVan();
            FleetVan fleetVan2 = fleetVan1;
            fleetVan2.IgnoreExceptionsOnSetMethods = true;
            fleetVan2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            fleetVan2.SetRegistration = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Registration"]);
            fleetVan2.SetVanTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanTypeID"]);
            fleetVan2.SetMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Mileage"]);
            fleetVan2.SetAverageMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AverageMileage"]);
            fleetVan2.SetDepartment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Department"]);
            fleetVan2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            fleetVan2.SetReturned = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Returned"]));
            if (dataTable.Columns.Contains("TyreSize"))
                fleetVan2.SetTyreSize = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TyreSize"]);
            fleetVan1.Exists = true;
            return fleetVan1;
        }

        public FleetVan Get_ByRegistration(string registration)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Registration", (object)registration, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVan_Get_ByRegistrationTrim", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (FleetVan)null;
            FleetVan fleetVan1 = new FleetVan();
            FleetVan fleetVan2 = fleetVan1;
            fleetVan2.IgnoreExceptionsOnSetMethods = true;
            fleetVan2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            fleetVan2.SetRegistration = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Registration"]);
            fleetVan2.SetVanTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanTypeID"]);
            fleetVan2.SetMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Mileage"]);
            fleetVan2.SetAverageMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AverageMileage"]);
            fleetVan2.SetDepartment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Department"]);
            fleetVan2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            fleetVan2.SetReturned = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Returned"]));
            if (dataTable.Columns.Contains("TyreSize"))
                fleetVan2.SetTyreSize = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TyreSize"]);
            fleetVan1.Exists = true;
            return fleetVan1;
        }

        public int Get_NextVanID()
        {
            this._database.ClearParameter();
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("FleetVan_Get_NextVan", true)));
        }

        public bool Update(FleetVan oVan)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)oVan.VanID, true);
            this.AddParametersToCommand(ref oVan);
            return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVan_Update", true), (object)1, false);
        }

        public FleetVan Insert(FleetVan van)
        {
            this._database.ClearParameter();
            this.AddParametersToCommand(ref van);
            van.SetVanID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("FleetVan_Insert", true)));
            van.Exists = true;
            return van;
        }

        public DataView Search(string Criteria)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)Criteria, true);
            DataTable table = this._database.ExecuteSP_DataTable("FleetVan_Search", true);
            table.TableName = Enums.TableNames.tblFleetVan.ToString();
            return new DataView(table);
        }

        public bool ReturnVan(int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, true);
            return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVan_ReturnVan", true), (object)1, false);
        }

        public DataView VanAudit_Get(int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@FleetVanID", (object)vanID, true);
            DataTable table = this._database.ExecuteSP_DataTable("FleetVanAudit_Get", true);
            table.TableName = Enums.TableNames.tblEquipmentAudit.ToString();
            return new DataView(table);
        }

        public void VanAudit_Insert(int vanID, string actionChange)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@FleetVanID", (object)vanID, true);
            this._database.AddParameter("@ActionChange", (object)actionChange, true);
            this._database.AddParameter("@ActionDateTime", (object)DateTime.Now, true);
            this._database.AddParameter("@UserID", (object)App.loggedInUser.UserID, true);
            this._database.ExecuteSP_NO_Return("FleetVanAudit_Insert", true);
        }
    }
}