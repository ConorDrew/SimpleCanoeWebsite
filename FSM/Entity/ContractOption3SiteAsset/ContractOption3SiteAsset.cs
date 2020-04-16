// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3SiteAsset.ContractOption3SiteAsset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3SiteAsset
{
    public class ContractOption3SiteAsset
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _ContractSiteAssetDurationID;
        private int _ContractSiteID;
        private int _AssetID;
        private DateTime _ScheduledMonth;
        private double _VisitDuration;

        public ContractOption3SiteAsset()
        {
            this._exists = false;
            this._deleted = false;
            this._ContractSiteAssetDurationID = 0;
            this._ContractSiteID = 0;
            this._AssetID = 0;
            this._ScheduledMonth = DateTime.MinValue;
            this._VisitDuration = 0.0;
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

        public int ContractSiteAssetDurationID
        {
            get
            {
                return this._ContractSiteAssetDurationID;
            }
        }

        public object SetContractSiteAssetDurationID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractSiteAssetDurationID", RuntimeHelpers.GetObjectValue(value));
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

        public int AssetID
        {
            get
            {
                return this._AssetID;
            }
        }

        public object SetAssetID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AssetID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime ScheduledMonth
        {
            get
            {
                return this._ScheduledMonth;
            }
            set
            {
                this._ScheduledMonth = value;
            }
        }

        public double VisitDuration
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
    }
}