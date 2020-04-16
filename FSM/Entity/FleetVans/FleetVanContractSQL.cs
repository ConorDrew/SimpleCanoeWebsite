// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanContractSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
    public class FleetVanContractSQL
    {
        private Database _database;

        public FleetVanContractSQL(Database database)
        {
            this._database = database;
        }

        private void AddParametersToCommand(ref FleetVanContract oFleetVan)
        {
            Database database = this._database;
            database.AddParameter("@VanID", (object)oFleetVan.VanID, true);
            database.AddParameter("@Lessor", (object)oFleetVan.Lessor, true);
            database.AddParameter("@ProcurementMethod", (object)oFleetVan.ProcurementMethod, true);
            database.AddParameter("@ContractLength", (object)oFleetVan.ContractLength, true);
            database.AddParameter("@StartDateTime", (object)oFleetVan.ContractStart, true);
            if ((uint)DateTime.Compare(oFleetVan.ContractEnd, DateTime.MinValue) > 0U)
                database.AddParameter("@EndDateTime", (object)oFleetVan.ContractEnd, true);
            database.AddParameter("@ContractMileage", (object)oFleetVan.ContractMileage, true);
            database.AddParameter("@StartingMileage", (object)oFleetVan.StartingMileage, true);
            database.AddParameter("@ExcessMileageRate", (object)oFleetVan.ExcessMileageRate, true);
            database.AddParameter("@WeeklyRental", (object)oFleetVan.WeeklyRental, true);
            database.AddParameter("@MonthlyRental", (object)oFleetVan.MonthlyRental, true);
            database.AddParameter("@AnnualRental", (object)oFleetVan.AnnualRental, true);
            database.AddParameter("@ExcessMileageCost", (object)oFleetVan.ExcessMileageCost, true);
            database.AddParameter("@ForecastExcessMileageCost", (object)oFleetVan.ForecastExcessMileageCost, true);
            database.AddParameter("@AgreementRef", (object)oFleetVan.AgreementRef, true);
            database.AddParameter("@Notes", (object)oFleetVan.Notes, true);
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("FleetVanContract_GetAll", true);
            table.TableName = Enums.TableNames.tblFleetVanContract.ToString();
            return new DataView(table);
        }

        public DataView GetAll_Active()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("FleetVanContract_GetAll_Active", true);
            table.TableName = Enums.TableNames.tblFleetVanContract.ToString();
            return new DataView(table);
        }

        public FleetVanContract Get(int vanContractID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanContractID", (object)vanContractID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanContract_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (FleetVanContract)null;
            FleetVanContract fleetVanContract1 = new FleetVanContract();
            FleetVanContract fleetVanContract2 = fleetVanContract1;
            fleetVanContract2.IgnoreExceptionsOnSetMethods = true;
            fleetVanContract2.SetVanContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanContractID"]);
            fleetVanContract2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            fleetVanContract2.SetLessor = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Lessor"]);
            fleetVanContract2.SetProcurementMethod = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProcurementMethod"]);
            fleetVanContract2.SetContractLength = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractLength"]);
            fleetVanContract2.ContractStart = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartDateTime"]));
            fleetVanContract2.ContractEnd = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndDateTime"]));
            fleetVanContract2.SetContractMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractMileage"]);
            fleetVanContract2.SetStartingMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartingMileage"]);
            fleetVanContract2.SetExcessMileageRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExcessMileageRate"]);
            fleetVanContract2.SetWeeklyRental = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WeeklyRental"]);
            fleetVanContract2.SetMonthlyRental = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MonthlyRental"]);
            fleetVanContract2.SetAnnualRental = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AnnualRental"]);
            fleetVanContract2.SetAgreementRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AgreementRef"]);
            fleetVanContract2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            fleetVanContract2.SetExcessMileageCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExcessMileageCost"]);
            fleetVanContract2.SetForecastExcessMileageCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ForecastExcessMileageCost"]);
            fleetVanContract1.Exists = true;
            return fleetVanContract1;
        }

        public FleetVanContract Get_ByVanID(int vanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)vanID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("FleetVanContract_Get_ForVan", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (FleetVanContract)null;
            FleetVanContract fleetVanContract1 = new FleetVanContract();
            FleetVanContract fleetVanContract2 = fleetVanContract1;
            fleetVanContract2.IgnoreExceptionsOnSetMethods = true;
            fleetVanContract2.SetVanContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanContractID"]);
            fleetVanContract2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            fleetVanContract2.SetLessor = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Lessor"]);
            fleetVanContract2.SetProcurementMethod = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProcurementMethod"]);
            fleetVanContract2.SetContractLength = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractLength"]);
            fleetVanContract2.ContractStart = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartDateTime"]));
            fleetVanContract2.ContractEnd = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndDateTime"]));
            fleetVanContract2.SetContractMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractMileage"]);
            fleetVanContract2.SetStartingMileage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartingMileage"]);
            fleetVanContract2.SetExcessMileageRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExcessMileageRate"]);
            fleetVanContract2.SetWeeklyRental = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WeeklyRental"]);
            fleetVanContract2.SetMonthlyRental = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MonthlyRental"]);
            fleetVanContract2.SetAnnualRental = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AnnualRental"]);
            fleetVanContract2.SetAgreementRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AgreementRef"]);
            fleetVanContract2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
            fleetVanContract2.SetExcessMileageCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExcessMileageCost"]);
            fleetVanContract2.SetForecastExcessMileageCost = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ForecastExcessMileageCost"]);
            fleetVanContract1.Exists = true;
            return fleetVanContract1;
        }

        public bool Update(FleetVanContract oVan)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanContractID", (object)oVan.VanContractID, true);
            this.AddParametersToCommand(ref oVan);
            return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT("FleetVanContract_Update", true), (object)1, false);
        }

        public FleetVanContract Insert(FleetVanContract van)
        {
            this._database.ClearParameter();
            this.AddParametersToCommand(ref van);
            van.SetVanContractID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("FleetVanContract_Insert", true)));
            van.Exists = true;
            return van;
        }
    }
}