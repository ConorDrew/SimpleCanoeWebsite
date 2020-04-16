// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOption3Sites.QuoteContractOption3Site
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOption3Sites
{
    public class QuoteContractOption3Site
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteContractSiteID;
        private int _QuoteContractID;
        private int _SiteID;
        private string _QuoteContractSiteReference;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private DateTime _FirstVisitDate;
        private int _VisitFrequencyID;
        private double _SitePrice;

        public QuoteContractOption3Site()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteContractSiteID = 0;
            this._QuoteContractID = 0;
            this._SiteID = 0;
            this._QuoteContractSiteReference = string.Empty;
            this._StartDate = DateTime.MinValue;
            this._EndDate = DateTime.MinValue;
            this._FirstVisitDate = DateTime.MinValue;
            this._VisitFrequencyID = 0;
            this._SitePrice = 0.0;
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

        public string QuoteContractSiteReference
        {
            get
            {
                return this._QuoteContractSiteReference;
            }
        }

        public object SetQuoteContractSiteReference
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractSiteReference", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                this._StartDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                this._EndDate = value;
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

        public double SitePrice
        {
            get
            {
                return this._SitePrice;
            }
        }

        public object SetSitePrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SitePrice", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}