// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartSuppliers.PartSupplier
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PartSuppliers
{
    public class PartSupplier
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _PartSupplierID;
        private string _PartCode;
        private int _PartID;
        private int _SupplierID;
        private double _Price;
        private double _SecondaryPrice;
        private double _QuantityInPack;
        private bool _preferred;

        public PartSupplier()
        {
            this._exists = false;
            this._deleted = false;
            this._PartSupplierID = 0;
            this._PartCode = string.Empty;
            this._PartID = 0;
            this._SupplierID = 0;
            this._Price = 0.0;
            this._SecondaryPrice = 0.0;
            this._QuantityInPack = 0.0;
            this._preferred = false;
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

        public int PartSupplierID
        {
            get
            {
                return this._PartSupplierID;
            }
        }

        public object SetPartSupplierID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartSupplierID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string PartCode
        {
            get
            {
                return this._PartCode;
            }
        }

        public object SetPartCode
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartCode", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PartID
        {
            get
            {
                return this._PartID;
            }
        }

        public object SetPartID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SupplierID
        {
            get
            {
                return this._SupplierID;
            }
        }

        public object SetSupplierID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SupplierID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double Price
        {
            get
            {
                return this._Price;
            }
        }

        public object SetPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Price", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double SecondaryPrice
        {
            get
            {
                return this._SecondaryPrice;
            }
        }

        public object SetSecondaryPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SecondaryPrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double QuantityInPack
        {
            get
            {
                return this._QuantityInPack;
            }
        }

        public object SetQuantityInPack
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuantityInPack", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool Preferred
        {
            get
            {
                return this._preferred;
            }
        }

        public bool SetPreferred
        {
            set
            {
                this._preferred = value;
            }
        }
    }
}