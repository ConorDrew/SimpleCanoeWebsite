// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanMaintenance
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
    public class FleetVanMaintenance
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _vanMaintenanceID;
        private int _vanID;
        private DateTime _lastService;
        private DateTime _nextService;
        private int _lastServiceMileage;
        private DateTime _MOTExpiry;
        private DateTime _taxExpiry;
        private string _breakdown;
        private DateTime _warrantyExpiry;
        private DateTime _breakdownExpiry;

        public FleetVanMaintenance()
        {
            this._exists = false;
            this._deleted = false;
            this._vanMaintenanceID = 0;
            this._vanID = 0;
            this._lastService = DateTime.MinValue;
            this._nextService = DateTime.MinValue;
            this._lastServiceMileage = 0;
            this._MOTExpiry = DateTime.MinValue;
            this._taxExpiry = DateTime.MinValue;
            this._breakdown = string.Empty;
            this._warrantyExpiry = DateTime.MinValue;
            this._breakdownExpiry = DateTime.MinValue;
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

        public int VanMaintenanceID
        {
            get
            {
                return this._vanMaintenanceID;
            }
        }

        public object SetVanMaintenanceID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_vanMaintenanceID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VanID
        {
            get
            {
                return this._vanID;
            }
        }

        public object SetVanID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_vanID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime LastService
        {
            get
            {
                return this._lastService;
            }
            set
            {
                this._lastService = value;
            }
        }

        public DateTime NextService
        {
            get
            {
                return this._nextService;
            }
            set
            {
                this._nextService = value;
            }
        }

        public int LastServiceMileage
        {
            get
            {
                return this._lastServiceMileage;
            }
        }

        public object SetLastServiceMileage
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_lastServiceMileage", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime MOTExpiry
        {
            get
            {
                return this._MOTExpiry;
            }
            set
            {
                this._MOTExpiry = value;
            }
        }

        public DateTime RoadTaxExpiry
        {
            get
            {
                return this._taxExpiry;
            }
            set
            {
                this._taxExpiry = value;
            }
        }

        public string Breakdown
        {
            get
            {
                return this._breakdown;
            }
        }

        public object SetBreakdown
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_breakdown", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime WarrantyExpiry
        {
            get
            {
                return this._warrantyExpiry;
            }
            set
            {
                this._warrantyExpiry = value;
            }
        }

        public DateTime BreakdownExpiry
        {
            get
            {
                return this._breakdownExpiry;
            }
            set
            {
                this._breakdownExpiry = value;
            }
        }
    }
}