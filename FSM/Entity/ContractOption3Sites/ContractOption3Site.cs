// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3Sites.ContractOption3Site
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3Sites
{
    public class ContractOption3Site
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _ContractSiteID;
        private int _ContractID;
        private int _PropertyID;
        private string _ContractSiteReference;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private DateTime _FirstVisitDate;
        private int _VisitFrequencyID;
        private int _InvoiceFrequencyID;
        private double _SitePrice;
        private DateTime _FirstInvoiceDate;
        private int _InvoiceAddressTypeID;
        private int _InvoiceAddressID;

        public ContractOption3Site()
        {
            this._exists = false;
            this._deleted = false;
            this._ContractSiteID = 0;
            this._ContractID = 0;
            this._PropertyID = 0;
            this._ContractSiteReference = string.Empty;
            this._StartDate = DateTime.MinValue;
            this._EndDate = DateTime.MinValue;
            this._FirstVisitDate = DateTime.MinValue;
            this._VisitFrequencyID = 0;
            this._InvoiceFrequencyID = 0;
            this._SitePrice = 0.0;
            this._InvoiceAddressID = 0;
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

        public string ContractSiteReference
        {
            get
            {
                return this._ContractSiteReference;
            }
        }

        public object SetContractSiteReference
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractSiteReference", RuntimeHelpers.GetObjectValue(value));
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

        public int InvoiceFrequencyID
        {
            get
            {
                return this._InvoiceFrequencyID;
            }
        }

        public object SetInvoiceFrequencyID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceFrequencyID", RuntimeHelpers.GetObjectValue(value));
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

        public DateTime FirstInvoiceDate
        {
            get
            {
                return this._FirstInvoiceDate;
            }
            set
            {
                this._FirstInvoiceDate = value;
            }
        }

        public int InvoiceAddressTypeID
        {
            get
            {
                return this._InvoiceAddressTypeID;
            }
        }

        public object SetInvoiceAddressTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceAddressTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int InvoiceAddressID
        {
            get
            {
                return this._InvoiceAddressID;
            }
        }

        public object SetInvoiceAddressID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceAddressID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}