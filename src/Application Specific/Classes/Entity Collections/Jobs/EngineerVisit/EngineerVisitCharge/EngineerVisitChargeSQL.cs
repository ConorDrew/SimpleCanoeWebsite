using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitCharges
    {
        public class EngineerVisitChargeSQL
        {
            private Sys.Database _database;

            public EngineerVisitChargeSQL(Sys.Database database)
            {
                _database = database;
            }

            public void EngineerVisitCharge_Delete(int EngineerVisitChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitChargeID", EngineerVisitChargeID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitCharge_Delete");
            }

            public int EngineerVisitCharge_Check(int EngineerVisitChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitChargeID, true);
                return Conversions.ToInteger(_database.ExecuteSP_OBJECT("EngineerVisitCharge_Check"));
            }

            public EngineerVisitCharge EngineerVisitCharge_Get(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitCharge_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitCharge = new EngineerVisitCharge();
                        oEngineerVisitCharge.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitCharge.SetEngineerVisitChargeID = dt.Rows[0]["EngineerVisitChargeID"];
                        oEngineerVisitCharge.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitCharge.SetLabourRate = dt.Rows[0]["MileageRate"];
                        oEngineerVisitCharge.SetApplyMileageToTotal = dt.Rows[0]["ApplyMileageToTotal"];
                        oEngineerVisitCharge.SetJobValue = dt.Rows[0]["JobValue"];
                        oEngineerVisitCharge.SetChargeTypeID = dt.Rows[0]["ChargeTypeID"];
                        oEngineerVisitCharge.SetCharge = dt.Rows[0]["Charge"];
                        oEngineerVisitCharge.SetInvoiceReadyID = dt.Rows[0]["InvoiceReadyID"];
                        oEngineerVisitCharge.SetMainContractorDiscount = dt.Rows[0]["MainContractorDiscount"];
                        oEngineerVisitCharge.SetNominalCode = dt.Rows[0]["NominalCode"];
                        oEngineerVisitCharge.SetDepartment = dt.Rows[0]["Department"];
                        oEngineerVisitCharge.SetForSageAccountCode = dt.Rows[0]["ForSageAccountCode"];
                        oEngineerVisitCharge.SetPartsMarkUp = dt.Rows[0]["PartsMarkUp"];
                        oEngineerVisitCharge.SetPartsPrice = dt.Rows[0]["PartsPrice"];
                        oEngineerVisitCharge.SetLabourPrice = dt.Rows[0]["LabourPrice"];
                        oEngineerVisitCharge.SetHasChargesFromJob = Sys.Helper.MakeBooleanValid(dt.Rows[0]["HasChargesFromJob"]);
                        oEngineerVisitCharge.Exists = true;
                        return oEngineerVisitCharge;
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

            public EngineerVisitCharge EngineerVisitCharge_Insert(EngineerVisitCharge oEngineerVisitCharge)
            {
                _database.ClearParameter();
                AddEngineerVisitChargeParametersToCommand(ref oEngineerVisitCharge);
                _database.AddParameter("@RecordAddedOn", DateAndTime.Now, true);
                _database.AddParameter("@RecordAddedBy", App.loggedInUser.UserID, true);
                oEngineerVisitCharge.SetEngineerVisitChargeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitCharge_Insert"));
                oEngineerVisitCharge.Exists = true;
                return EngineerVisitCharge_Get(oEngineerVisitCharge.EngineerVisitID);
            }

            public void EngineerVisitCharge_Update(EngineerVisitCharge oEngineerVisitCharge, Jobs.Job job = null)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitChargeID", oEngineerVisitCharge.EngineerVisitChargeID, true);
                AddEngineerVisitChargeParametersToCommand(ref oEngineerVisitCharge);
                if (Sys.Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("EngineerVisitCharge_Update")) == true)
                {
                    // Status Changed enter Job Audit
                    if (job is object)
                    {
                        var jA = new JobAudits.JobAudit();
                        jA.SetJobID = job.JobID;
                        jA.SetActionChange = "Visit Status changed to Invoice " + Strings.Replace(((Sys.Enums.InvoiceReady)Conversions.ToInteger(oEngineerVisitCharge.InvoiceReadyID)).ToString(), "_", " ") + " (Unique Visit ID: " + oEngineerVisitCharge.EngineerVisitID + ")";
                        App.DB.JobAudit.Insert(jA);
                    }
                }
            }

            private void AddEngineerVisitChargeParametersToCommand(ref EngineerVisitCharge oEngineerVisitCharge)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitCharge.EngineerVisitID, true);
                    withBlock.AddParameter("@MileageRate", oEngineerVisitCharge.LabourRate, true);
                    withBlock.AddParameter("@ApplyMileageToTotal", oEngineerVisitCharge.ApplyMileageToTotal, true);
                    withBlock.AddParameter("@JobValue", oEngineerVisitCharge.JobValue, true);
                    withBlock.AddParameter("@ChargeTypeID", oEngineerVisitCharge.ChargeTypeID, true);
                    withBlock.AddParameter("@Charge", oEngineerVisitCharge.Charge, true);
                    withBlock.AddParameter("@InvoiceReadyID", oEngineerVisitCharge.InvoiceReadyID, true);
                    withBlock.AddParameter("@MainContractorDiscount", oEngineerVisitCharge.MainContractorDiscount, true);
                    withBlock.AddParameter("@NominalCode", oEngineerVisitCharge.NominalCode, true);
                    withBlock.AddParameter("@Department", oEngineerVisitCharge.Department, true);
                    withBlock.AddParameter("@ForSageAccountCode", oEngineerVisitCharge.ForSageAccountCode, true);
                    withBlock.AddParameter("@PartsMarkUp", oEngineerVisitCharge.PartsMarkUp, true);
                    withBlock.AddParameter("@PartsPrice", oEngineerVisitCharge.PartsPrice, true);
                    withBlock.AddParameter("@LabourPrice", oEngineerVisitCharge.LabourPrice, true);
                    withBlock.AddParameter("@HasChargesFromJob", oEngineerVisitCharge.HasChargesFromJob, true);
                }
            }

            public double EngineerVisit_Get_MileageRate_For_Site(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                return Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("EngineerVisit_Get_MileageRate_For_Site"));
            }

            public double EngineerVisit_Get_MileageRate_For_ContractJob(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                return Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("EngineerVisit_Get_MileageRate_For_ContractJob"));
            }

            public int EngineerVisitCharge_GetContractInvoiceFrequency(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitCharge_GetContractInvoiceFrequency"));
            }

            public double EngineerVisit_Get_CustomerContractorDiscount(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                return Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("EngineerVisit_Get_CustomerContractorDiscount"));
            }

            public DataView EngineerVisitCharge_Get_ChargedBreakDown(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitCharge_Get_ChargedBreakDown");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitCharge_Get_SorBreakdownForVal(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitCharge_Get_SorBreakdownForVal");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
                return new DataView(dt);
            }

            public void EngineerVisitAdditionalCharge_Delete(int EngineerVisitAdditionalChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitAdditionalChargeID", EngineerVisitAdditionalChargeID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitAdditionalCharge_Delete");
            }

            public DataView EngineerVisitAdditionalCharge_GetAll(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAdditionalCharge_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
                return new DataView(dt);
            }

            public void EngineerVisitAdditionalCharge_Insert(int EngineerVisitID, string ChargeDescription, double Charge)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@ChargeDescription", ChargeDescription, true);
                _database.AddParameter("@Charge", Charge, true);
                _database.ExecuteSP_NO_Return("EngineerVisitAdditionalCharge_Insert");
            }

            public DataView EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
                return new DataView(dt);
            }

            public void EngineerVisitScheduleOfRatesCharge_Insert(int EngineerVisitID, int JobItemID, double Price, int tick)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@JobItemID", JobItemID, true);
                _database.AddParameter("@Price", Price, true);
                _database.AddParameter("@tick", tick, true);
                _database.ExecuteSP_NO_Return("EngineerVisitScheduleOfRatesCharge_Insert");
            }

            public void EngineerVisitScheduleOfRatesCharge_Delete(int EngineerVisitScheduleOfRateChargesID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitScheduleOfRateChargesID", EngineerVisitScheduleOfRateChargesID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitScheduleOfRatesCharge_Delete");
            }

            public DataView EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsCharge_Get_For_EngineerVisitID");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitPartsAndProductsCharge_Get_For_JobID(int JobID, int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsCharge_Get_ForJob");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
                return new DataView(dt);
            }

            public void EngineerVisitPartCharge_Insert(int EngineerVisitID, int PartID, double Price, int tick, double Cost, int PartUsedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@Price", Price, true);
                _database.AddParameter("@tick", tick, true);
                _database.AddParameter("@cost", Cost, true);
                _database.AddParameter("@PartUsedID", PartUsedID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartCharge_Insert");
            }

            public void EngineerVisitPartCharge_Delete(int EngineerVisitPartCharge)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitPartCharge", EngineerVisitPartCharge, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartCharge_Delete");
            }

            public void EngineerVisitProductCharge_Insert(int EngineerVisitID, int ProductID, double Price, int tick, double Cost)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@ProductID", ProductID, true);
                _database.AddParameter("@Price", Price, true);
                _database.AddParameter("@tick", tick, true);
                _database.AddParameter("@cost", Cost, true);
                _database.ExecuteSP_NO_Return("EngineerVisitProductCharge_Insert");
            }

            public void EngineerVisitProductCharge_Delete(int EngineerVisitProductChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitProductChargeID", EngineerVisitProductChargeID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitProductCharge_Delete");
            }

            public void EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID");
            }

            public void EngineerVisitPartsCharge_Update_Price(int Id, int markup)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", Id, true);
                _database.AddParameter("@MarkUp", markup, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartsCharge_Update_Price");
            }

            public DataView EngineerVisitTimeSheetCharges_Get(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitTimeSheetCharges_Get");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitTimeSheetCharges_Get_ForJob(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitTimeSheetCharges_Get_ForJob");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
                return new DataView(dt);
            }

            public void EngineerVisitTimeSheetCharges_Insert(int EngineerVisitID, int Tick, DateTime StartDateTime, DateTime EndDateTime, double Price, int TimeSheetTypeID, string Summary, double EngineerCost)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@Tick", Tick, true);
                _database.AddParameter("@Price", Price, true);
                _database.AddParameter("@TimeSheetTypeID", TimeSheetTypeID, true);
                _database.AddParameter("@StartDateTime", StartDateTime, true);
                _database.AddParameter("@EndDateTime", EndDateTime, true);
                _database.AddParameter("@Summary", Summary, true);
                _database.AddParameter("@EngineerCost", EngineerCost, true);
                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheetCharges_Insert");
            }

            public void EngineerVisitTimeSheetCharges_Update(int EngineerVisitTimesheetChargeID, int Tick)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitTimesheetChargeID", EngineerVisitTimesheetChargeID, true);
                _database.AddParameter("@Tick", Tick, true);
                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheetCharges_Update");
            }

            public void EngineerVisitTimeSheetCharges_Delete(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheetCharges_Delete");
            }

            public DataView EngineerVisitTimesheetCharge_ByTimeSheet(int EngineerVisitTimeSheetID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitTimeSheetID", EngineerVisitTimeSheetID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitTimesheetCharge_ByTimeSheet");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
                return new DataView(dt);
            }

            public int EngineerVisitTimeSheetCharges_BankHoliday(DateTime theDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@theDate", Conversions.ToDate(Strings.Format(theDate, "dd/MM/yyyy") + " 00:00:00"), true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitTimeSheetCharges_BankHoliday"));
            }
        }
    }
}