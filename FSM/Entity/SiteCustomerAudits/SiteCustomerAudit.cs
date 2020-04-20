// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SiteCustomerAudits.SiteCustomerAudit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.SiteCustomerAudits
{
    public class SiteCustomerAudit
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _SiteCustomerAuditID;
        private int _SiteID;
        private int _PreviousCustomerID;
        private DateTime _DateChanged;
        private int _userID;

        public SiteCustomerAudit()
        {
            this._exists = false;
            this._deleted = false;
            this._SiteCustomerAuditID = 0;
            this._SiteID = 0;
            this._PreviousCustomerID = 0;
            this._DateChanged = DateTime.MinValue;
            this._userID = 0;
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

        public int SiteCustomerAuditID
        {
            get
            {
                return this._SiteCustomerAuditID;
            }
        }

        public object SetSiteCustomerAuditID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SiteCustomerAuditID", RuntimeHelpers.GetObjectValue(value));
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

        public int PreviousCustomerID
        {
            get
            {
                return this._PreviousCustomerID;
            }
        }

        public object SetPreviousCustomerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PreviousCustomerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime DateChanged
        {
            get
            {
                return this._DateChanged;
            }
            set
            {
                this._DateChanged = value;
            }
        }

        public int UserID
        {
            get
            {
                return this._userID;
            }
        }

        public object SetUserID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_userID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}