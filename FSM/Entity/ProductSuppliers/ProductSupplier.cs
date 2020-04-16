// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ProductSuppliers.ProductSupplier
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ProductSuppliers
{
    public class ProductSupplier
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _ProductSupplierID;
        private int _ProductID;
        private int _SupplierID;
        private string _ProductCode;
        private double _Price;
        private double _QuantityInPack;

        public ProductSupplier()
        {
            this._exists = false;
            this._deleted = false;
            this._ProductSupplierID = 0;
            this._ProductID = 0;
            this._SupplierID = 0;
            this._ProductCode = string.Empty;
            this._Price = 0.0;
            this._QuantityInPack = 0.0;
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

        public int ProductSupplierID
        {
            get
            {
                return this._ProductSupplierID;
            }
        }

        public object SetProductSupplierID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ProductSupplierID", RuntimeHelpers.GetObjectValue(value));
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

        public string ProductCode
        {
            get
            {
                return this._ProductCode;
            }
        }

        public object SetProductCode
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ProductCode", RuntimeHelpers.GetObjectValue(value));
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
    }
}