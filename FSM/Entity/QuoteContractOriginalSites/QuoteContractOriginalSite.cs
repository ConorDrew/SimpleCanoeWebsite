// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOriginalSites.QuoteContractOriginalSite
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOriginalSites
{
    public class QuoteContractOriginalSite
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteContractSiteID;
        private int _QuoteContractID;
        private int _SiteID;
        private double _PricePerVisit;
        private int _VisitFrequencyID;
        private int _VisitDuration;
        private bool _IncludeAssetPrice;
        private double _AverageMileage;
        private double _PricePerMile;
        private bool _IncludeMileagePrice;
        private bool _IncludeRates;
        private double _TotalSitePrice;
        private DataView _ContractSiteScheduleOfRates;

        public QuoteContractOriginalSite()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteContractSiteID = 0;
            this._QuoteContractID = 0;
            this._SiteID = 0;
            this._PricePerVisit = 0.0;
            this._VisitFrequencyID = 0;
            this._VisitDuration = 0;
            this._IncludeAssetPrice = false;
            this._AverageMileage = 0.0;
            this._PricePerMile = 0.0;
            this._IncludeMileagePrice = false;
            this._IncludeRates = false;
            this._TotalSitePrice = 0.0;
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

        public int QuoteContractSiteID
        {
            get
            {
                return this._QuoteContractSiteID;
            }
        }

        public object SetQuoteContractSiteID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractSiteID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuoteContractID
        {
            get
            {
                return this._QuoteContractID;
            }
        }

        public object SetQuoteContractID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SiteID
        {
            get
            {
                return this._SiteID;
            }
        }

        public object SetSiteID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SiteID", RuntimeHelpers.GetObjectValue(value));
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
    }
}