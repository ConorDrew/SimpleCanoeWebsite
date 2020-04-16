// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitCharges.EngineerVisitChargeSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.JobAudits;
using FSM.Entity.Jobs;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitCharges
{
    public class EngineerVisitChargeSQL
    {
        private Database _database;

        public EngineerVisitChargeSQL(Database database)
        {
            this._database = database;
        }

        public void EngineerVisitCharge_Delete(int EngineerVisitChargeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitChargeID", (object)EngineerVisitChargeID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitCharge_Delete), true);
        }

        public int EngineerVisitCharge_Check(int EngineerVisitChargeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitChargeID, true);
            return Conversions.ToInteger(this._database.ExecuteSP_OBJECT(nameof(EngineerVisitCharge_Check), true));
        }

        public EngineerVisitCharge EngineerVisitCharge_Get(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(EngineerVisitCharge_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (EngineerVisitCharge)null;
            EngineerVisitCharge engineerVisitCharge1 = new EngineerVisitCharge();
            EngineerVisitCharge engineerVisitCharge2 = engineerVisitCharge1;
            engineerVisitCharge2.IgnoreExceptionsOnSetMethods = true;
            engineerVisitCharge2.SetEngineerVisitChargeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitChargeID"]);
            engineerVisitCharge2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(EngineerVisitID)]);
            engineerVisitCharge2.SetLabourRate = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MileageRate"]);
            engineerVisitCharge2.SetApplyMileageToTotal = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ApplyMileageToTotal"]);
            engineerVisitCharge2.SetJobValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobValue"]);
            engineerVisitCharge2.SetChargeTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ChargeTypeID"]);
            engineerVisitCharge2.SetCharge = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Charge"]);
            engineerVisitCharge2.SetInvoiceReadyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["InvoiceReadyID"]);
            engineerVisitCharge2.SetMainContractorDiscount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MainContractorDiscount"]);
            engineerVisitCharge2.SetNominalCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NominalCode"]);
            engineerVisitCharge2.SetDepartment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Department"]);
            engineerVisitCharge2.SetForSageAccountCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ForSageAccountCode"]);
            engineerVisitCharge2.SetPartsMarkUp = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsMarkUp"]);
            engineerVisitCharge2.SetPartsPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartsPrice"]);
            engineerVisitCharge2.SetLabourPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LabourPrice"]);
            engineerVisitCharge2.SetHasChargesFromJob = (object)Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HasChargesFromJob"]));
            engineerVisitCharge1.Exists = true;
            return engineerVisitCharge1;
        }

        public EngineerVisitCharge EngineerVisitCharge_Insert(
          EngineerVisitCharge oEngineerVisitCharge)
        {
            this._database.ClearParameter();
            this.AddEngineerVisitChargeParametersToCommand(ref oEngineerVisitCharge);
            this._database.AddParameter("@RecordAddedOn", (object)DateAndTime.Now, true);
            this._database.AddParameter("@RecordAddedBy", (object)App.loggedInUser.UserID, true);
            oEngineerVisitCharge.SetEngineerVisitChargeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisitCharge_Insert), true)));
            oEngineerVisitCharge.Exists = true;
            return this.EngineerVisitCharge_Get(oEngineerVisitCharge.EngineerVisitID);
        }

        public void EngineerVisitCharge_Update(EngineerVisitCharge oEngineerVisitCharge, Job job = null)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitChargeID", (object)oEngineerVisitCharge.EngineerVisitChargeID, true);
            this.AddEngineerVisitChargeParametersToCommand(ref oEngineerVisitCharge);
            if (!Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisitCharge_Update), true))) || job == null)
                return;
            App.DB.JobAudit.Insert(new JobAudit()
            {
                SetJobID = (object)job.JobID,
                SetActionChange = (object)("Visit Status changed to Invoice " + Strings.Replace(((Enums.InvoiceReady)oEngineerVisitCharge.InvoiceReadyID).ToString(), "_", " ", 1, -1, CompareMethod.Binary) + " (Unique Visit ID: " + Conversions.ToString(oEngineerVisitCharge.EngineerVisitID) + ")")
            });
        }

        private void AddEngineerVisitChargeParametersToCommand(
          ref EngineerVisitCharge oEngineerVisitCharge)
        {
            Database database = this._database;
            database.AddParameter("@EngineerVisitID", (object)oEngineerVisitCharge.EngineerVisitID, true);
            database.AddParameter("@MileageRate", (object)oEngineerVisitCharge.LabourRate, true);
            database.AddParameter("@ApplyMileageToTotal", (object)oEngineerVisitCharge.ApplyMileageToTotal, true);
            database.AddParameter("@JobValue", (object)oEngineerVisitCharge.JobValue, true);
            database.AddParameter("@ChargeTypeID", (object)oEngineerVisitCharge.ChargeTypeID, true);
            database.AddParameter("@Charge", (object)oEngineerVisitCharge.Charge, true);
            database.AddParameter("@InvoiceReadyID", (object)oEngineerVisitCharge.InvoiceReadyID, true);
            database.AddParameter("@MainContractorDiscount", (object)oEngineerVisitCharge.MainContractorDiscount, true);
            database.AddParameter("@NominalCode", (object)oEngineerVisitCharge.NominalCode, true);
            database.AddParameter("@Department", (object)oEngineerVisitCharge.Department, true);
            database.AddParameter("@ForSageAccountCode", (object)oEngineerVisitCharge.ForSageAccountCode, true);
            database.AddParameter("@PartsMarkUp", (object)oEngineerVisitCharge.PartsMarkUp, true);
            database.AddParameter("@PartsPrice", (object)oEngineerVisitCharge.PartsPrice, true);
            database.AddParameter("@LabourPrice", (object)oEngineerVisitCharge.LabourPrice, true);
            database.AddParameter("@HasChargesFromJob", (object)oEngineerVisitCharge.HasChargesFromJob, true);
        }

        public double EngineerVisit_Get_MileageRate_For_Site(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisit_Get_MileageRate_For_Site), true)));
        }

        public double EngineerVisit_Get_MileageRate_For_ContractJob(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)JobID, true);
            return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisit_Get_MileageRate_For_ContractJob), true)));
        }

        public int EngineerVisitCharge_GetContractInvoiceFrequency(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisitCharge_GetContractInvoiceFrequency), true)));
        }

        public double EngineerVisit_Get_CustomerContractorDiscount(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            return Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisit_Get_CustomerContractorDiscount), true)));
        }

        public DataView EngineerVisitCharge_Get_ChargedBreakDown(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitCharge_Get_ChargedBreakDown), true);
            table.TableName = Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisitCharge_Get_SorBreakdownForVal(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitCharge_Get_SorBreakdownForVal), true);
            table.TableName = Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
            return new DataView(table);
        }

        public void EngineerVisitAdditionalCharge_Delete(int EngineerVisitAdditionalChargeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitAdditionalChargeID", (object)EngineerVisitAdditionalChargeID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitAdditionalCharge_Delete), true);
        }

        public DataView EngineerVisitAdditionalCharge_GetAll(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitAdditionalCharge_GetAll), true);
            table.TableName = Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
            return new DataView(table);
        }

        public void EngineerVisitAdditionalCharge_Insert(
          int EngineerVisitID,
          string ChargeDescription,
          double Charge)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@ChargeDescription", (object)ChargeDescription, true);
            this._database.AddParameter("@Charge", (object)Charge, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitAdditionalCharge_Insert), true);
        }

        public DataView EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(
          int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID), true);
            table.TableName = Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
            return new DataView(table);
        }

        public void EngineerVisitScheduleOfRatesCharge_Insert(
          int EngineerVisitID,
          int JobItemID,
          double Price,
          int tick)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@JobItemID", (object)JobItemID, true);
            this._database.AddParameter("@Price", (object)Price, true);
            this._database.AddParameter("@tick", (object)tick, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitScheduleOfRatesCharge_Insert), true);
        }

        public void EngineerVisitScheduleOfRatesCharge_Delete(int EngineerVisitScheduleOfRateChargesID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitScheduleOfRateChargesID", (object)EngineerVisitScheduleOfRateChargesID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitScheduleOfRatesCharge_Delete), true);
        }

        public DataView EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(
          int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitPartsCharge_Get_For_EngineerVisitID", true);
            table.TableName = Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisitPartsAndProductsCharge_Get_For_JobID(
          int JobID,
          int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@JobID", (object)JobID, true);
            DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsCharge_Get_ForJob", true);
            table.TableName = Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
            return new DataView(table);
        }

        public void EngineerVisitPartCharge_Insert(
          int EngineerVisitID,
          int PartID,
          double Price,
          int tick,
          double Cost,
          int PartUsedID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@Price", (object)Price, true);
            this._database.AddParameter("@tick", (object)tick, true);
            this._database.AddParameter("@cost", (object)Cost, true);
            this._database.AddParameter("@PartUsedID", (object)PartUsedID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitPartCharge_Insert), true);
        }

        public void EngineerVisitPartCharge_Delete(int EngineerVisitPartCharge)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitPartCharge", (object)EngineerVisitPartCharge, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitPartCharge_Delete), true);
        }

        public void EngineerVisitProductCharge_Insert(
          int EngineerVisitID,
          int ProductID,
          double Price,
          int tick,
          double Cost)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@ProductID", (object)ProductID, true);
            this._database.AddParameter("@Price", (object)Price, true);
            this._database.AddParameter("@tick", (object)tick, true);
            this._database.AddParameter("@cost", (object)Cost, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitProductCharge_Insert), true);
        }

        public void EngineerVisitProductCharge_Delete(int EngineerVisitProductChargeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitProductChargeID", (object)EngineerVisitProductChargeID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitProductCharge_Delete), true);
        }

        public void EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID), true);
        }

        public void EngineerVisitPartsCharge_Update_Price(int Id, int markup)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)Id, true);
            this._database.AddParameter("@MarkUp", (object)markup, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitPartsCharge_Update_Price), true);
        }

        public DataView EngineerVisitTimeSheetCharges_Get(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitTimeSheetCharges_Get), true);
            table.TableName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisitTimeSheetCharges_Get_ForJob(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)JobID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitTimeSheetCharges_Get_ForJob), true);
            table.TableName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
            return new DataView(table);
        }

        public void EngineerVisitTimeSheetCharges_Insert(
          int EngineerVisitID,
          int Tick,
          DateTime StartDateTime,
          DateTime EndDateTime,
          double Price,
          int TimeSheetTypeID,
          string Summary,
          double EngineerCost)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@Tick", (object)Tick, true);
            this._database.AddParameter("@Price", (object)Price, true);
            this._database.AddParameter("@TimeSheetTypeID", (object)TimeSheetTypeID, true);
            this._database.AddParameter("@StartDateTime", (object)StartDateTime, true);
            this._database.AddParameter("@EndDateTime", (object)EndDateTime, true);
            this._database.AddParameter("@Summary", (object)Summary, true);
            this._database.AddParameter("@EngineerCost", (object)EngineerCost, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitTimeSheetCharges_Insert), true);
        }

        public void EngineerVisitTimeSheetCharges_Update(int EngineerVisitTimesheetChargeID, int Tick)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitTimesheetChargeID", (object)EngineerVisitTimesheetChargeID, true);
            this._database.AddParameter("@Tick", (object)Tick, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitTimeSheetCharges_Update), true);
        }

        public void EngineerVisitTimeSheetCharges_Update_PriceAndMarkUp(
          int EngineerVisitTimesheetChargeID,
          int Tick)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitTimesheetChargeID", (object)EngineerVisitTimesheetChargeID, true);
            this._database.AddParameter("@Tick", (object)Tick, true);
            this._database.ExecuteSP_NO_Return("EngineerVisitTimeSheetCharges_Update", true);
        }

        public void EngineerVisitTimeSheetCharges_Delete(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.ExecuteSP_NO_Return(nameof(EngineerVisitTimeSheetCharges_Delete), true);
        }

        public DataView EngineerVisitTimesheetCharge_ByTimeSheet(int EngineerVisitTimeSheetID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitTimeSheetID", (object)EngineerVisitTimeSheetID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitTimesheetCharge_ByTimeSheet), true);
            table.TableName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
            return new DataView(table);
        }

        public int EngineerVisitTimeSheetCharges_BankHoliday(DateTime theDate)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@theDate", (object)Conversions.ToDate(Strings.Format((object)theDate, "dd/MM/yyyy") + " 00:00:00"), true);
            return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(EngineerVisitTimeSheetCharges_BankHoliday), true)));
        }
    }
}