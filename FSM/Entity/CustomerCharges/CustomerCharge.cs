// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CustomerCharges.CustomerCharge
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CustomerCharges
{
    public class CustomerCharge
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _CustomerChargeID;
        private int _CustomerID;
        private double _MileageRate;
        private double _PartsMarkup;
        private double _RatesMarkup;

        public CustomerCharge()
        {
            this._exists = false;
            this._deleted = false;
            this._CustomerChargeID = 0;
            this._CustomerID = 0;
            this._MileageRate = 1.0;
            this._PartsMarkup = 0.0;
            this._RatesMarkup = 0.0;
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

        public int CustomerChargeID
        {
            get
            {
                return this._CustomerChargeID;
            }
        }

        public object SetCustomerChargeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerChargeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int CustomerID
        {
            get
            {
                return this._CustomerID;
            }
        }

        public object SetCustomerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double MileageRate
        {
            get
            {
                return this._MileageRate;
            }
        }

        public object SetMileageRate
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MileageRate", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double PartsMarkup
        {
            get
            {
                return this._PartsMarkup;
            }
        }

        public object SetPartsMarkup
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartsMarkup", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double RatesMarkup
        {
            get
            {
                return this._RatesMarkup;
            }
        }

        public object SetRatesMarkup
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_RatesMarkup", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}