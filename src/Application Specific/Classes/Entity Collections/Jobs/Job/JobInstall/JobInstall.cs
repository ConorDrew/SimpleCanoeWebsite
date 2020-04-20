using System.Collections;

namespace FSM.Entity
{
    namespace JobInstalls
    {
        public class JobInstall
        {
            private DataTypeValidator _dataTypeValidator;

            public JobInstall()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _siexists = false;

            public bool SIExists
            {
                get
                {
                    return _siexists;
                }

                set
                {
                    _siexists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private int _JobInstallID = 0;

            public int JobInstallID
            {
                get
                {
                    return _JobInstallID;
                }
            }

            public object SetJobInstallID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobInstallID", value);
                }
            }

            private int _JobID = 0;

            public int JobID
            {
                get
                {
                    return _JobID;
                }
            }

            public object SetJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobID", value);
                }
            }

            private int _Surveyed = 0;

            public int Surveyed
            {
                get
                {
                    return _Surveyed;
                }
            }

            public object SetSurveyed
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Surveyed", value);
                }
            }

            private double _Deposit = 0;

            public double Deposit
            {
                get
                {
                    return _Deposit;
                }
            }

            public object SetDeposit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Deposit", value);
                }
            }

            private int _POStatus = 0;

            public int POStatus
            {
                get
                {
                    return _POStatus;
                }
            }

            public object SetPOStatus
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_POStatus", value);
                }
            }

            private int _EngCalledSuper = 0;

            public int EngCalledSuper
            {
                get
                {
                    return _EngCalledSuper;
                }
            }

            public object SetEngCalledSuper
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngCalledSuper", value);
                }
            }

            private int _ExtraLabour = 0;

            public int ExtraLabour
            {
                get
                {
                    return _ExtraLabour;
                }
            }

            public object SetExtraLabour
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ExtraLabour", value);
                }
            }

            private int _FurtherWorks = 0;

            public int FurtherWorks
            {
                get
                {
                    return _FurtherWorks;
                }
            }

            public object SetFurtherWorks
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FurtherWorks", value);
                }
            }

            private double _PaymentTaken = 0;

            public double PaymentTaken
            {
                get
                {
                    return _PaymentTaken;
                }
            }

            public object SetPaymentTaken
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PaymentTaken", value);
                }
            }

            private int _QC = 0;

            public int QC
            {
                get
                {
                    return _QC;
                }
            }

            public object SetQC
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QC", value);
                }
            }

            private int _PaperWork = 0;

            public int PaperWork
            {
                get
                {
                    return _PaperWork;
                }
            }

            public object SetPaperWork
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PaperWork", value);
                }
            }

            private double _EstPartCost = 0.0;

            public double EstPartCost
            {
                get
                {
                    return _EstPartCost;
                }
            }

            public object SetEstPartCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EstPartCost", value);
                }
            }

            private double _actPartCost = 0;

            public double actPartCost
            {
                get
                {
                    return _actPartCost;
                }
            }

            public object SetactPartCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_actPartCost", value);
                }
            }

            private double _EstLabourCost = 0;

            public double EstLabourCost
            {
                get
                {
                    return _EstLabourCost;
                }
            }

            public object SetEstLabourCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EstLabourCost", value);
                }
            }

            private double _actLabourCost = 0;

            public double actLabourCost
            {
                get
                {
                    return _actLabourCost;
                }
            }

            public object SetactLabourCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_actLabourCost", value);
                }
            }

            private double _EstElecCost = 0;

            public double EstElecCost
            {
                get
                {
                    return _EstElecCost;
                }
            }

            public object SetEstElecCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EstElecCost", value);
                }
            }

            private double _actElecCost = 0;

            public double actElecCost
            {
                get
                {
                    return _actElecCost;
                }
            }

            public object SetactElecCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_actElecCost", value);
                }
            }

            private double _EstTotalCost = 0;

            public double EstTotalCost
            {
                get
                {
                    return _EstTotalCost;
                }
            }

            public object SetEstTotalCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EstTotalCost", value);
                }
            }

            private double _actTotalCost = 0;

            public double actTotalCost
            {
                get
                {
                    return _actTotalCost;
                }
            }

            public object SetactTotalCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_actTotalCost", value);
                }
            }

            private double _EstProfitMoney = 0;

            public double EstProfitMoney
            {
                get
                {
                    return _EstProfitMoney;
                }
            }

            public object SetEstProfitMoney
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EstProfitMoney", value);
                }
            }

            private double _ActProfitMoney = 0;

            public double ActProfitMoney
            {
                get
                {
                    return _ActProfitMoney;
                }
            }

            public object SetActProfitMoney
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ActProfitMoney", value);
                }
            }

            private double _EstProfitPerc = 0;

            public double EstProfitPerc
            {
                get
                {
                    return _EstProfitPerc;
                }
            }

            public object SetEstProfitPerc
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EstProfitPerc", value);
                }
            }

            private double _ActProfitPerc = 0;

            public double ActProfitPerc
            {
                get
                {
                    return _ActProfitPerc;
                }
            }

            public object SetActProfitPerc
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ActProfitPerc", value);
                }
            }

            private double _QuotedAmount = 0;

            public double QuotedAmount
            {
                get
                {
                    return _QuotedAmount;
                }
            }

            public object SetQuotedAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuotedAmount", value);
                }
            }

            private double _SupplierInvoice = 0;

            public double SupplierInvoice
            {
                get
                {
                    return _SupplierInvoice;
                }
            }

            public object SetSupplierInvoice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SupplierInvoice", value);
                }
            }

            private double _SubConPO = 0;

            public double SubConPO
            {
                get
                {
                    return _SubConPO;
                }
            }

            public object SetSubConPO
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SubConPO", value);
                }
            }

            private double _SubConEst = 0;

            public double SubConEst
            {
                get
                {
                    return _SubConEst;
                }
            }

            public object SetSubConEst
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SubConEst", value);
                }
            }

            private double _SubConSI = 0;

            public double SubConSI
            {
                get
                {
                    return _SubConSI;
                }
            }

            public object SetSubConSI
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SubConSI", value);
                }
            }

            private double _Manual = 0;

            public double Manual
            {
                get
                {
                    return _Manual;
                }
            }

            public object SetManual
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Manual", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}