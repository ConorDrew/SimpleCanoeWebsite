// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobInstalls.JobInstall
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobInstalls
{
    public class JobInstall
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _siexists;
        private bool _deleted;
        private int _JobInstallID;
        private int _JobID;
        private int _Surveyed;
        private double _Deposit;
        private int _POStatus;
        private int _EngCalledSuper;
        private int _ExtraLabour;
        private int _FurtherWorks;
        private double _PaymentTaken;
        private int _QC;
        private int _PaperWork;
        private double _EstPartCost;
        private double _actPartCost;
        private double _EstLabourCost;
        private double _actLabourCost;
        private double _EstElecCost;
        private double _actElecCost;
        private double _EstTotalCost;
        private double _actTotalCost;
        private double _EstProfitMoney;
        private double _ActProfitMoney;
        private double _EstProfitPerc;
        private double _ActProfitPerc;
        private double _QuotedAmount;
        private double _SupplierInvoice;
        private double _SubConPO;
        private double _SubConEst;
        private double _SubConSI;
        private double _Manual;

        public JobInstall()
        {
            this._exists = false;
            this._siexists = false;
            this._deleted = false;
            this._JobInstallID = 0;
            this._JobID = 0;
            this._Surveyed = 0;
            this._Deposit = 0.0;
            this._POStatus = 0;
            this._EngCalledSuper = 0;
            this._ExtraLabour = 0;
            this._FurtherWorks = 0;
            this._PaymentTaken = 0.0;
            this._QC = 0;
            this._PaperWork = 0;
            this._EstPartCost = 0.0;
            this._actPartCost = 0.0;
            this._EstLabourCost = 0.0;
            this._actLabourCost = 0.0;
            this._EstElecCost = 0.0;
            this._actElecCost = 0.0;
            this._EstTotalCost = 0.0;
            this._actTotalCost = 0.0;
            this._EstProfitMoney = 0.0;
            this._ActProfitMoney = 0.0;
            this._EstProfitPerc = 0.0;
            this._ActProfitPerc = 0.0;
            this._QuotedAmount = 0.0;
            this._SupplierInvoice = 0.0;
            this._SubConPO = 0.0;
            this._SubConEst = 0.0;
            this._SubConSI = 0.0;
            this._Manual = 0.0;
            this._dataTypeValidator = new DataTypeValidator();
        }

        public bool IgnoreExceptionsOnSetMethods
        {
            get
            {
                return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
            }
            set
            {
                this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
            }
        }

        public Hashtable Errors
        {
            get
            {
                return this._dataTypeValidator.Errors;
            }
        }

        public DataTypeValidator DTValidator
        {
            get
            {
                return this._dataTypeValidator;
            }
        }

        public bool Exists
        {
            get
            {
                return this._exists;
            }
            set
            {
                this._exists = value;
            }
        }

        public bool SIExists
        {
            get
            {
                return this._siexists;
            }
            set
            {
                this._siexists = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return this._deleted;
            }
        }

        public bool SetDeleted
        {
            set
            {
                this._deleted = value;
            }
        }

        public int JobInstallID
        {
            get
            {
                return this._JobInstallID;
            }
        }

        public object SetJobInstallID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_JobInstallID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int JobID
        {
            get
            {
                return this._JobID;
            }
        }

        public object SetJobID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_JobID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Surveyed
        {
            get
            {
                return this._Surveyed;
            }
        }

        public object SetSurveyed
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Surveyed", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double Deposit
        {
            get
            {
                return this._Deposit;
            }
        }

        public object SetDeposit
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Deposit", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int POStatus
        {
            get
            {
                return this._POStatus;
            }
        }

        public object SetPOStatus
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_POStatus", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngCalledSuper
        {
            get
            {
                return this._EngCalledSuper;
            }
        }

        public object SetEngCalledSuper
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngCalledSuper", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ExtraLabour
        {
            get
            {
                return this._ExtraLabour;
            }
        }

        public object SetExtraLabour
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ExtraLabour", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int FurtherWorks
        {
            get
            {
                return this._FurtherWorks;
            }
        }

        public object SetFurtherWorks
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FurtherWorks", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double PaymentTaken
        {
            get
            {
                return this._PaymentTaken;
            }
        }

        public object SetPaymentTaken
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PaymentTaken", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QC
        {
            get
            {
                return this._QC;
            }
        }

        public object SetQC
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QC", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PaperWork
        {
            get
            {
                return this._PaperWork;
            }
        }

        public object SetPaperWork
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PaperWork", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double EstPartCost
        {
            get
            {
                return this._EstPartCost;
            }
        }

        public object SetEstPartCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EstPartCost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double actPartCost
        {
            get
            {
                return this._actPartCost;
            }
        }

        public object SetactPartCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_actPartCost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double EstLabourCost
        {
            get
            {
                return this._EstLabourCost;
            }
        }

        public object SetEstLabourCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EstLabourCost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double actLabourCost
        {
            get
            {
                return this._actLabourCost;
            }
        }

        public object SetactLabourCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_actLabourCost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double EstElecCost
        {
            get
            {
                return this._EstElecCost;
            }
        }

        public object SetEstElecCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EstElecCost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double actElecCost
        {
            get
            {
                return this._actElecCost;
            }
        }

        public object SetactElecCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_actElecCost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double EstTotalCost
        {
            get
            {
                return this._EstTotalCost;
            }
        }

        public object SetEstTotalCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EstTotalCost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double actTotalCost
        {
            get
            {
                return this._actTotalCost;
            }
        }

        public object SetactTotalCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_actTotalCost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double EstProfitMoney
        {
            get
            {
                return this._EstProfitMoney;
            }
        }

        public object SetEstProfitMoney
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EstProfitMoney", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double ActProfitMoney
        {
            get
            {
                return this._ActProfitMoney;
            }
        }

        public object SetActProfitMoney
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ActProfitMoney", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double EstProfitPerc
        {
            get
            {
                return this._EstProfitPerc;
            }
        }

        public object SetEstProfitPerc
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EstProfitPerc", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double ActProfitPerc
        {
            get
            {
                return this._ActProfitPerc;
            }
        }

        public object SetActProfitPerc
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ActProfitPerc", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double QuotedAmount
        {
            get
            {
                return this._QuotedAmount;
            }
        }

        public object SetQuotedAmount
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuotedAmount", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double SupplierInvoice
        {
            get
            {
                return this._SupplierInvoice;
            }
        }

        public object SetSupplierInvoice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SupplierInvoice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double SubConPO
        {
            get
            {
                return this._SubConPO;
            }
        }

        public object SetSubConPO
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SubConPO", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double SubConEst
        {
            get
            {
                return this._SubConEst;
            }
        }

        public object SetSubConEst
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SubConEst", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double SubConSI
        {
            get
            {
                return this._SubConSI;
            }
        }

        public object SetSubConSI
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SubConSI", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double Manual
        {
            get
            {
                return this._Manual;
            }
        }

        public object SetManual
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Manual", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}