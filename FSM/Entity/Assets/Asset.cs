// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Assets.Asset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Assets
{
    public class Asset
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _AssetID;
        private int _PropertyID;
        private int _ProductID;
        private string _SerialNum;
        private DateTime _DateFitted;
        private string _Location;
        private DateTime _CertificateLastIssued;
        private DateTime _LastServicedDate;
        private string _BoughtFrom;
        private string _SuppliedBy;
        private string _Notes;
        private string _GCNumber;
        private string _YearOfManufacture;
        private double _ApproximateValue;
        private DateTime _WarrantyStartDate;
        private DateTime _WarrantyEndDate;
        private int _GasTypeID;
        private int _FlueTypeID;
        private bool _Active;
        private bool _TenantsAppliance;

        public Asset()
        {
            this._exists = false;
            this._deleted = false;
            this._AssetID = 0;
            this._PropertyID = 0;
            this._ProductID = 0;
            this._SerialNum = string.Empty;
            this._DateFitted = DateTime.MinValue;
            this._Location = string.Empty;
            this._CertificateLastIssued = DateTime.MinValue;
            this._LastServicedDate = DateTime.MinValue;
            this._BoughtFrom = string.Empty;
            this._SuppliedBy = string.Empty;
            this._Notes = string.Empty;
            this._GCNumber = string.Empty;
            this._YearOfManufacture = string.Empty;
            this._ApproximateValue = 0.0;
            this._WarrantyStartDate = DateTime.MinValue;
            this._WarrantyEndDate = DateTime.MinValue;
            this._GasTypeID = 0;
            this._FlueTypeID = 0;
            this._Active = false;
            this._TenantsAppliance = false;
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

        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
        }

        public object SetProductID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ProductID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string SerialNum
        {
            get
            {
                return this._SerialNum;
            }
        }

        public object SetSerialNum
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SerialNum", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime DateFitted
        {
            get
            {
                return this._DateFitted;
            }
            set
            {
                this._DateFitted = value;
            }
        }

        public string Location
        {
            get
            {
                return this._Location;
            }
        }

        public object SetLocation
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Location", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime CertificateLastIssued
        {
            get
            {
                return this._CertificateLastIssued;
            }
            set
            {
                this._CertificateLastIssued = value;
            }
        }

        public DateTime LastServicedDate
        {
            get
            {
                return this._LastServicedDate;
            }
            set
            {
                this._LastServicedDate = value;
            }
        }

        public string BoughtFrom
        {
            get
            {
                return this._BoughtFrom;
            }
        }

        public object SetBoughtFrom
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_BoughtFrom", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string SuppliedBy
        {
            get
            {
                return this._SuppliedBy;
            }
        }

        public object SetSuppliedBy
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SuppliedBy", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Notes
        {
            get
            {
                return this._Notes;
            }
        }

        public object SetNotes
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Notes", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string GCNumber
        {
            get
            {
                return this._GCNumber;
            }
        }

        public object SetGCNumber
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_GCNumber", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string YearOfManufacture
        {
            get
            {
                return this._YearOfManufacture;
            }
        }

        public object SetYearOfManufacture
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_YearOfManufacture", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double ApproximateValue
        {
            get
            {
                return this._ApproximateValue;
            }
        }

        public object SetApproximateValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ApproximateValue", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime WarrantyStartDate
        {
            get
            {
                return this._WarrantyStartDate;
            }
            set
            {
                this._WarrantyStartDate = value;
            }
        }

        public DateTime WarrantyEndDate
        {
            get
            {
                return this._WarrantyEndDate;
            }
            set
            {
                this._WarrantyEndDate = value;
            }
        }

        public int GasTypeID
        {
            get
            {
                return this._GasTypeID;
            }
        }

        public object SetGasTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_GasTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int FlueTypeID
        {
            get
            {
                return this._FlueTypeID;
            }
        }

        public object SetFlueTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FlueTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool Active
        {
            get
            {
                return this._Active;
            }
        }

        public object SetActive
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Active", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool TenantsAppliance
        {
            get
            {
                return this._TenantsAppliance;
            }
        }

        public object SetTenantsAppliance
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TenantsAppliance", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}