// Decompiled with JetBrains decompiler
// Type: FSM.Entity.InvoiceAddresss.InvoiceAddress
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.InvoiceAddresss
{
    public class InvoiceAddress
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _InvoiceAddressID;
        private string _Address1;
        private string _Address2;
        private string _Address3;
        private string _Address4;
        private string _Address5;
        private string _Postcode;
        private string _TelephoneNum;
        private string _FaxNum;
        private string _EmailAddress;
        private int _SiteID;

        public InvoiceAddress()
        {
            this._exists = false;
            this._deleted = false;
            this._InvoiceAddressID = 0;
            this._Address1 = string.Empty;
            this._Address2 = string.Empty;
            this._Address3 = string.Empty;
            this._Address4 = string.Empty;
            this._Address5 = string.Empty;
            this._Postcode = string.Empty;
            this._TelephoneNum = string.Empty;
            this._FaxNum = string.Empty;
            this._EmailAddress = string.Empty;
            this._SiteID = 0;
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

        public string Address1
        {
            get
            {
                return this._Address1;
            }
        }

        public object SetAddress1
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address1", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address2
        {
            get
            {
                return this._Address2;
            }
        }

        public object SetAddress2
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address2", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address3
        {
            get
            {
                return this._Address3;
            }
        }

        public object SetAddress3
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address3", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address4
        {
            get
            {
                return this._Address4;
            }
        }

        public object SetAddress4
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address4", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address5
        {
            get
            {
                return this._Address5;
            }
        }

        public object SetAddress5
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address5", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Postcode
        {
            get
            {
                return this._Postcode;
            }
        }

        public object SetPostcode
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Postcode", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string TelephoneNum
        {
            get
            {
                return this._TelephoneNum;
            }
        }

        public object SetTelephoneNum
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TelephoneNum", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string FaxNum
        {
            get
            {
                return this._FaxNum;
            }
        }

        public object SetFaxNum
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FaxNum", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string EmailAddress
        {
            get
            {
                return this._EmailAddress;
            }
        }

        public object SetEmailAddress
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EmailAddress", RuntimeHelpers.GetObjectValue(value));
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
    }
}