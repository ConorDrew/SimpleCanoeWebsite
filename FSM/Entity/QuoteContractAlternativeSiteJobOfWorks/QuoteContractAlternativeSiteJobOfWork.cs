// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativeSiteJobOfWorks
{
    public class QuoteContractAlternativeSiteJobOfWork
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteContractSiteJobOfWorkID;
        private int _QuoteContractSiteID;
        private DateTime _FirstVisitDate;
        private double _PricePerVisit;
        private double _AverageMileage;
        private double _PricePerMile;
        private bool _IncludeMileagePrice;
        private bool _IncludeRates;
        private double _TotalSitePrice;
        private DataView _ScheduledOfRates_UsedForConvertOnly;

        public QuoteContractAlternativeSiteJobOfWork()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteContractSiteJobOfWorkID = 0;
            this._QuoteContractSiteID = 0;
            this._FirstVisitDate = DateTime.MinValue;
            this._PricePerVisit = 0.0;
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

        public int QuoteContractSiteJobOfWorkID
        {
            get
            {
                return this._QuoteContractSiteJobOfWorkID;
            }
        }

        public object SetQuoteContractSiteJobOfWorkID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractSiteJobOfWorkID", RuntimeHelpers.GetObjectValue(value));
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

        public DataView ScheduledOfRates_UsedForConvertOnly
        {
            get
            {
                return this._ScheduledOfRates_UsedForConvertOnly;
            }
            set
            {
                this._ScheduledOfRates_UsedForConvertOnly = value;
            }
        }
    }
}