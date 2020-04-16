// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalSites.ContractOriginalSite
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalSites
{
    public class ContractOriginalSite
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _ContractSiteID;
        private int _ContractID;
        private int _PropertyID;
        private int _VisitFrequencyID;
        private int _VisitDuration;
        private DateTime _FirstVisitDate;
        private bool _IncludeAssetPrice;
        private double _AverageMileage;
        private double _PricePerMile;
        private bool _IncludeMileagePrice;
        private double _PricePerVisit;
        private double _TotalSitePrice;
        private DataView _ContractSiteScheduleOfRates;
        private bool _IncludeRates;
        private bool _LLCertReqd;
        private string _AdditionalNotes;
        private bool _Commercial;
        private int _MainAppliances;
        private int _SecondryAppliances;

        public ContractOriginalSite()
        {
            this._exists = false;
            this._deleted = false;
            this._ContractSiteID = 0;
            this._ContractID = 0;
            this._PropertyID = 0;
            this._VisitFrequencyID = 0;
            this._VisitDuration = 0;
            this._FirstVisitDate = DateTime.MinValue;
            this._IncludeAssetPrice = false;
            this._AverageMileage = 0.0;
            this._PricePerMile = 0.0;
            this._IncludeMileagePrice = false;
            this._PricePerVisit = 0.0;
            this._TotalSitePrice = 0.0;
            this._IncludeRates = false;
            this._LLCertReqd = false;
            this._AdditionalNotes = string.Empty;
            this._Commercial = false;
            this._MainAppliances = 0;
            this._SecondryAppliances = 0;
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

        public int ContractSiteID
        {
            get
            {
                return this._ContractSiteID;
            }
        }

        public object SetContractSiteID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractSiteID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ContractID
        {
            get
            {
                return this._ContractID;
            }
        }

        public object SetContractID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PropertyID
        {
            get
            {
                return this._PropertyID;
            }
        }

        public object SetPropertyID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PropertyID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VisitFrequencyID
        {
            get
            {
                return this._VisitFrequencyID;
            }
        }

        public object SetVisitFrequencyID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VisitFrequencyID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VisitDuration
        {
            get
            {
                return this._VisitDuration;
            }
        }

        public object SetVisitDuration
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VisitDuration", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime FirstVisitDate
        {
            get
            {
                return this._FirstVisitDate;
            }
            set
            {
                this._FirstVisitDate = value;
            }
        }

        public bool IncludeAssetPrice
        {
            get
            {
                return this._IncludeAssetPrice;
            }
        }

        public object SetIncludeAssetPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_IncludeAssetPrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double AverageMileage
        {
            get
            {
                return this._AverageMileage;
            }
        }

        public object SetAverageMileage
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AverageMileage", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double PricePerMile
        {
            get
            {
                return this._PricePerMile;
            }
        }

        public object SetPricePerMile
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PricePerMile", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool IncludeMileagePrice
        {
            get
            {
                return this._IncludeMileagePrice;
            }
        }

        public object SetIncludeMileagePrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_IncludeMileagePrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double PricePerVisit
        {
            get
            {
                return this._PricePerVisit;
            }
        }

        public object SetPricePerVisit
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PricePerVisit", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double TotalSitePrice
        {
            get
            {
                return this._TotalSitePrice;
            }
        }

        public object SetTotalSitePrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TotalSitePrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DataView ContractSiteScheduleOfRates
        {
            get
            {
                return this._ContractSiteScheduleOfRates;
            }
            set
            {
                this._ContractSiteScheduleOfRates = value;
            }
        }

        public bool IncludeRates
        {
            get
            {
                return this._IncludeRates;
            }
        }

        public object SetIncludeRates
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_IncludeRates", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool LLCertReqd
        {
            get
            {
                return this._LLCertReqd;
            }
        }

        public object SetLLCertReqd
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LLCertReqd", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string AdditionalNotes
        {
            get
            {
                return this._AdditionalNotes;
            }
        }

        public object SetAdditionalNotes
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AdditionalNotes", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool Commercial
        {
            get
            {
                return this._Commercial;
            }
        }

        public object SetCommercial
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Commercial", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int MainAppliances
        {
            get
            {
                return this._MainAppliances;
            }
        }

        public object SetMainAppliances
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MainAppliances", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SecondryAppliances
        {
            get
            {
                return this._SecondryAppliances;
            }
        }

        public object SetSecondryAppliances
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SecondryAppliances", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}