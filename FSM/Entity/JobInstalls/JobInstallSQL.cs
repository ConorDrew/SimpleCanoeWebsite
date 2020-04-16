// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobInstalls.JobInstallSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobInstalls
{
    public class JobInstallSQL
    {
        private Database _database;

        public JobInstallSQL(Database database)
        {
            this._database = database;
        }

        public JobInstall JobINstall_GetFor_JobID(int JobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)JobID, false);
            DataTable dataTable1 = this._database.ExecuteSP_DataTable("JobInstall_GetFor_JobID", true);
            JobInstall jobInstall1 = new JobInstall();
            if (dataTable1 == null)
                return (JobInstall)null;
            if (dataTable1.Rows.Count > 0)
            {
                JobInstall jobInstall2 = jobInstall1;
                jobInstall2.IgnoreExceptionsOnSetMethods = true;
                jobInstall2.SetJobInstallID = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["JobInstallID"]);
                jobInstall2.SetJobID = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0][nameof(JobID)]);
                jobInstall2.SetSurveyed = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["Surveyed"]);
                jobInstall2.SetDeposit = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["Deposit"]);
                jobInstall2.SetPOStatus = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["POStatus"]);
                jobInstall2.SetEngCalledSuper = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["EngCalledSuper"]);
                jobInstall2.SetExtraLabour = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["ExtraLabour"]);
                jobInstall2.SetFurtherWorks = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["FurtherWorks"]);
                jobInstall2.SetPaymentTaken = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["PaymentTaken"]);
                jobInstall2.SetQC = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["QcCarriedOut"]);
                jobInstall2.SetPaperWork = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["PaperWorkReturned"]);
                jobInstall2.SetEstPartCost = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["EstPartCost"]);
                jobInstall2.SetactPartCost = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["ActPartCost"]);
                jobInstall2.SetEstLabourCost = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["EstLabourCost"]);
                jobInstall2.SetactLabourCost = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["ActLabourCost"]);
                jobInstall2.SetEstTotalCost = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["EstTotalCost"]);
                jobInstall2.SetactTotalCost = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["ActTotalCost"]);
                jobInstall2.SetEstProfitMoney = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["EstProfitMoney"]);
                jobInstall2.SetActProfitMoney = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["ActProfitMoney"]);
                jobInstall2.SetEstProfitPerc = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["EstProfitPerc"]);
                jobInstall2.SetActProfitPerc = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["ActProfitPerc"]);
                jobInstall2.SetQuotedAmount = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["QuotedAmount"]);
                jobInstall2.SetEstElecCost = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["EstElectrical"]);
                jobInstall2.SetManual = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["Manual"]);
                jobInstall2.SetSubConEst = RuntimeHelpers.GetObjectValue(dataTable1.Rows[0]["EstSubCon"]);
                jobInstall1.Exists = true;
            }
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object)JobID, false);
            DataTable dataTable2 = this._database.ExecuteSP_DataTable("JobInstall_GetCostsFor_JobID", true);
            jobInstall1.SetactPartCost = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["ActPartCost"]);
            jobInstall1.SetactLabourCost = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["ActLabourCost"]);
            jobInstall1.SetSupplierInvoice = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["SupplierInvoice"]);
            jobInstall1.SetactElecCost = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["ElectricalPO"]);
            jobInstall1.SetSubConPO = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["SubPO"]);
            jobInstall1.SetSubConSI = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["SubSI"]);
            jobInstall1.SetPaymentTaken = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["Charge"]);
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["SupplierInvoice"])) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(dataTable2.Rows[0]["SupplierInvoice"], (object)0, false))
                jobInstall1.SIExists = true;
            double num = jobInstall1.SubConSI == 0.0 ? jobInstall1.SubConPO : jobInstall1.SubConSI;
            jobInstall1.SetactTotalCost = !jobInstall1.SIExists ? (object)(jobInstall1.actPartCost + jobInstall1.actLabourCost + jobInstall1.actElecCost + num + jobInstall1.Manual) : (object)(jobInstall1.SupplierInvoice + jobInstall1.actLabourCost + jobInstall1.actElecCost + num + jobInstall1.Manual);
            jobInstall1.SetActProfitMoney = (object)(jobInstall1.PaymentTaken - jobInstall1.actTotalCost);
            jobInstall1.SetActProfitPerc = (object)(Math.Round(jobInstall1.ActProfitMoney / jobInstall1.PaymentTaken, 4) * 100.0);
            jobInstall1.SetEstTotalCost = (object)(jobInstall1.EstPartCost + jobInstall1.EstLabourCost + jobInstall1.EstElecCost);
            jobInstall1.SetEstProfitMoney = (object)(jobInstall1.QuotedAmount - jobInstall1.EstTotalCost);
            jobInstall1.SetEstProfitPerc = (object)(Math.Round(jobInstall1.EstProfitMoney / jobInstall1.QuotedAmount, 4) * 100.0);
            return jobInstall1;
        }

        public JobInstall Insert(JobInstall oJobInstall)
        {
            this._database.ClearParameter();
            this.AddEngineerVisitQCParametersToCommand(ref oJobInstall);
            oJobInstall.SetJobInstallID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobInstall_Insert", true)));
            oJobInstall.Exists = true;
            return oJobInstall;
        }

        public void Update(JobInstall oJobInstall)
        {
            this._database.ClearParameter();
            this.AddEngineerVisitQCParametersToCommand(ref oJobInstall);
            this._database.ExecuteSP_NO_Return("JobInstall_Update", true);
        }

        private void AddEngineerVisitQCParametersToCommand(ref JobInstall oJobInstall)
        {
            Database database = this._database;
            this._database.AddParameter("@JobInstallID", (object)oJobInstall.JobInstallID, true);
            database.AddParameter("@JobID", (object)oJobInstall.JobID, true);
            database.AddParameter("@Surveyed", (object)oJobInstall.Surveyed, true);
            database.AddParameter("@Deposit", (object)oJobInstall.Deposit, true);
            database.AddParameter("@POStatus", (object)oJobInstall.POStatus, true);
            database.AddParameter("@EngCalledSuper", (object)oJobInstall.EngCalledSuper, true);
            database.AddParameter("@ExtraLabour", (object)oJobInstall.ExtraLabour, true);
            database.AddParameter("@FurtherWorks", (object)oJobInstall.FurtherWorks, true);
            database.AddParameter("@PaymentTaken", (object)oJobInstall.PaymentTaken, true);
            database.AddParameter("@QcCarriedOut", (object)oJobInstall.QC, true);
            database.AddParameter("@PaperWorkReturned", (object)oJobInstall.PaperWork, true);
            database.AddParameter("@EstPartCost", (object)oJobInstall.EstPartCost, true);
            database.AddParameter("@ActPartCost", (object)oJobInstall.actPartCost, true);
            database.AddParameter("@EstLabourCost", (object)oJobInstall.EstLabourCost, true);
            database.AddParameter("@ActLabourCost", (object)oJobInstall.actLabourCost, true);
            database.AddParameter("@EstTotalCost", (object)oJobInstall.EstTotalCost, true);
            database.AddParameter("@ActTotalCost", (object)oJobInstall.actTotalCost, true);
            database.AddParameter("@EstProfitMoney", (object)oJobInstall.EstProfitMoney, true);
            database.AddParameter("@ActProfitMoney", (object)oJobInstall.ActProfitMoney, true);
            database.AddParameter("@EstProfitPerc", (object)0, true);
            database.AddParameter("@ActProfitPerc", (object)0, true);
            database.AddParameter("@QuotedAmount", (object)oJobInstall.QuotedAmount, true);
            database.AddParameter("@EstElectrical", (object)oJobInstall.EstElecCost, true);
            database.AddParameter("@Manual", (object)oJobInstall.Manual, true);
            database.AddParameter("@EstSubCon", (object)oJobInstall.SubConEst, true);
        }
    }
}