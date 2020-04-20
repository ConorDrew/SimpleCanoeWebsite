using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace JobInstalls
    {
        public class JobInstallSQL
        {
            private Sys.Database _database;

            public JobInstallSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public JobInstall JobINstall_GetFor_JobID(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("JobInstall_GetFor_JobID");
                var oJobInstall = new JobInstall();
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        oJobInstall.IgnoreExceptionsOnSetMethods = true;
                        oJobInstall.SetJobInstallID = dt.Rows[0]["JobInstallID"];
                        oJobInstall.SetJobID = dt.Rows[0]["JobID"];
                        oJobInstall.SetSurveyed = dt.Rows[0]["Surveyed"];
                        oJobInstall.SetDeposit = dt.Rows[0]["Deposit"];
                        oJobInstall.SetPOStatus = dt.Rows[0]["POStatus"];
                        oJobInstall.SetEngCalledSuper = dt.Rows[0]["EngCalledSuper"];
                        oJobInstall.SetExtraLabour = dt.Rows[0]["ExtraLabour"];
                        oJobInstall.SetFurtherWorks = dt.Rows[0]["FurtherWorks"];
                        oJobInstall.SetPaymentTaken = dt.Rows[0]["PaymentTaken"];
                        oJobInstall.SetQC = dt.Rows[0]["QcCarriedOut"];
                        oJobInstall.SetPaperWork = dt.Rows[0]["PaperWorkReturned"];
                        oJobInstall.SetEstPartCost = dt.Rows[0]["EstPartCost"];
                        oJobInstall.SetactPartCost = dt.Rows[0]["ActPartCost"];
                        oJobInstall.SetEstLabourCost = dt.Rows[0]["EstLabourCost"];
                        oJobInstall.SetactLabourCost = dt.Rows[0]["ActLabourCost"];
                        oJobInstall.SetEstTotalCost = dt.Rows[0]["EstTotalCost"];
                        oJobInstall.SetactTotalCost = dt.Rows[0]["ActTotalCost"];
                        oJobInstall.SetEstProfitMoney = dt.Rows[0]["EstProfitMoney"];
                        oJobInstall.SetActProfitMoney = dt.Rows[0]["ActProfitMoney"];
                        oJobInstall.SetEstProfitPerc = dt.Rows[0]["EstProfitPerc"];
                        oJobInstall.SetActProfitPerc = dt.Rows[0]["ActProfitPerc"];
                        oJobInstall.SetQuotedAmount = dt.Rows[0]["QuotedAmount"];
                        oJobInstall.SetEstElecCost = dt.Rows[0]["EstElectrical"];
                        oJobInstall.SetManual = dt.Rows[0]["Manual"];
                        oJobInstall.SetSubConEst = dt.Rows[0]["EstSubCon"];
                        oJobInstall.Exists = true;
                    }

                    _database.ClearParameter();
                    _database.AddParameter("@JobID", JobID);

                    // Get the datatable from the database store in dt
                    dt = _database.ExecuteSP_DataTable("JobInstall_GetCostsFor_JobID");
                    oJobInstall.SetactPartCost = dt.Rows[0]["ActPartCost"];
                    oJobInstall.SetactLabourCost = dt.Rows[0]["ActLabourCost"];
                    oJobInstall.SetSupplierInvoice = dt.Rows[0]["SupplierInvoice"];
                    oJobInstall.SetactElecCost = dt.Rows[0]["ElectricalPO"];
                    oJobInstall.SetSubConPO = dt.Rows[0]["SubPO"];
                    oJobInstall.SetSubConSI = dt.Rows[0]["SubSI"];
                    oJobInstall.SetPaymentTaken = dt.Rows[0]["Charge"];
                    if (!Information.IsDBNull(dt.Rows[0]["SupplierInvoice"]) && Conversions.ToBoolean(dt.Rows[0]["SupplierInvoice"] > 0))
                    {
                        oJobInstall.SIExists = true;
                    }

                    double Subby = 0;
                    if (oJobInstall.SubConSI != 0)
                    {
                        Subby = oJobInstall.SubConSI;
                    }
                    else
                    {
                        Subby = oJobInstall.SubConPO;
                    }


                    // Actual Calcs
                    if (oJobInstall.SIExists == true)
                    {
                        oJobInstall.SetactTotalCost = oJobInstall.SupplierInvoice + oJobInstall.actLabourCost + oJobInstall.actElecCost + Subby + oJobInstall.Manual;
                    }
                    else
                    {
                        oJobInstall.SetactTotalCost = oJobInstall.actPartCost + oJobInstall.actLabourCost + oJobInstall.actElecCost + Subby + oJobInstall.Manual;
                    }

                    oJobInstall.SetActProfitMoney = oJobInstall.PaymentTaken - oJobInstall.actTotalCost;
                    oJobInstall.SetActProfitPerc = Math.Round(Conversions.ToDouble(oJobInstall.ActProfitMoney) / Conversions.ToDouble(Conversions.ToDouble(oJobInstall.PaymentTaken)), 4) * 100;


                    // Estimate calcs
                    oJobInstall.SetEstTotalCost = oJobInstall.EstPartCost + oJobInstall.EstLabourCost + oJobInstall.EstElecCost;
                    oJobInstall.SetEstProfitMoney = oJobInstall.QuotedAmount - oJobInstall.EstTotalCost;
                    oJobInstall.SetEstProfitPerc = Math.Round(Conversions.ToDouble(oJobInstall.EstProfitMoney) / Conversions.ToDouble(Conversions.ToDouble(oJobInstall.QuotedAmount)), 4) * 100;
                    return oJobInstall;
                }
                else
                {
                    return null;
                }

                Orders.Order red;
            }

            public JobInstall Insert(JobInstall oJobInstall)
            {
                _database.ClearParameter();
                AddEngineerVisitQCParametersToCommand(ref oJobInstall);
                oJobInstall.SetJobInstallID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobInstall_Insert"));
                oJobInstall.Exists = true;
                return oJobInstall;
            }

            public void Update(JobInstall oJobInstall)
            {
                _database.ClearParameter();
                AddEngineerVisitQCParametersToCommand(ref oJobInstall);
                _database.ExecuteSP_NO_Return("JobInstall_Update");
            }

            private void AddEngineerVisitQCParametersToCommand(ref JobInstall oJobInstall)
            {
                {
                    var withBlock = _database;
                    _database.AddParameter("@JobInstallID", oJobInstall.JobInstallID, true);
                    withBlock.AddParameter("@JobID", oJobInstall.JobID, true);
                    withBlock.AddParameter("@Surveyed", oJobInstall.Surveyed, true);
                    withBlock.AddParameter("@Deposit", oJobInstall.Deposit, true);
                    withBlock.AddParameter("@POStatus", oJobInstall.POStatus, true);
                    withBlock.AddParameter("@EngCalledSuper", oJobInstall.EngCalledSuper, true);
                    withBlock.AddParameter("@ExtraLabour", oJobInstall.ExtraLabour, true);
                    withBlock.AddParameter("@FurtherWorks", oJobInstall.FurtherWorks, true);
                    withBlock.AddParameter("@PaymentTaken", oJobInstall.PaymentTaken, true);
                    withBlock.AddParameter("@QcCarriedOut", oJobInstall.QC, true);
                    withBlock.AddParameter("@PaperWorkReturned", oJobInstall.PaperWork, true);
                    withBlock.AddParameter("@EstPartCost", oJobInstall.EstPartCost, true);
                    withBlock.AddParameter("@ActPartCost", oJobInstall.actPartCost, true);
                    withBlock.AddParameter("@EstLabourCost", oJobInstall.EstLabourCost, true);
                    withBlock.AddParameter("@ActLabourCost", oJobInstall.actLabourCost, true);
                    withBlock.AddParameter("@EstTotalCost", oJobInstall.EstTotalCost, true);
                    withBlock.AddParameter("@ActTotalCost", oJobInstall.actTotalCost, true);
                    withBlock.AddParameter("@EstProfitMoney", oJobInstall.EstProfitMoney, true);
                    withBlock.AddParameter("@ActProfitMoney", oJobInstall.ActProfitMoney, true);
                    withBlock.AddParameter("@EstProfitPerc", 0, true); // RD
                    withBlock.AddParameter("@ActProfitPerc", 0, true); // RD
                    withBlock.AddParameter("@QuotedAmount", oJobInstall.QuotedAmount, true);
                    withBlock.AddParameter("@EstElectrical", oJobInstall.EstElecCost, true);
                    withBlock.AddParameter("@Manual", oJobInstall.Manual, true);
                    withBlock.AddParameter("@EstSubCon", oJobInstall.SubConEst, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}