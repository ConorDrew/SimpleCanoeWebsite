// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOriginalPPMVisits.QuoteContractOriginalPPMVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOriginalPPMVisits
{
    public class QuoteContractOriginalPPMVisit
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteContractPPMVisitID;
        private int _QuoteContractSiteID;
        private DateTime _EstimatedVisitDate;

        public QuoteContractOriginalPPMVisit()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteContractPPMVisitID = 0;
            this._QuoteContractSiteID = 0;
            this._EstimatedVisitDate = DateTime.MinValue;
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

        public int QuoteContractPPMVisitID
        {
            get
            {
                return this._QuoteContractPPMVisitID;
            }
        }

        public object SetQuoteContractPPMVisitID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractPPMVisitID", RuntimeHelpers.GetObjectValue(value));
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

        public DateTime EstimatedVisitDate
        {
            get
            {
                return this._EstimatedVisitDate;
            }
            set
            {
                this._EstimatedVisitDate = value;
            }
        }
    }
}