// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSite
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativeSites
{
    public class QuoteContractAlternativeSite
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteContractSiteID;
        private int _QuoteContractID;
        private int _SiteID;
        private ArrayList _jobOfWorks;

        public QuoteContractAlternativeSite()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteContractSiteID = 0;
            this._QuoteContractID = 0;
            this._SiteID = 0;
            this._jobOfWorks = new ArrayList();
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

        public ArrayList JobOfWorks
        {
            get
            {
                return this._jobOfWorks;
            }
            set
            {
                this._jobOfWorks = value;
            }
        }
    }
}