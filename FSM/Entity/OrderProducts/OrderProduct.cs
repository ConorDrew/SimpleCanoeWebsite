// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderProducts.OrderProduct
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderProducts
{
    public class OrderProduct
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _OrderProductID;
        private int _ProductSupplierID;
        private int _Quantity;
        private int _QuantityReceived;
        private double _BuyPrice;
        private double _SellPrice;
        private int _OrderID;
        private int _DispatchSiteID;
        private int _DispatchWarehouseID;

        public OrderProduct()
        {
            this._exists = false;
            this._deleted = false;
            this._OrderProductID = 0;
            this._ProductSupplierID = 0;
            this._Quantity = 0;
            this._QuantityReceived = 0;
            this._BuyPrice = 0.0;
            this._SellPrice = 0.0;
            this._OrderID = 0;
            this._DispatchSiteID = 0;
            this._DispatchWarehouseID = 0;
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

        public int OrderProductID
        {
            get
            {
                return this._OrderProductID;
            }
        }

        public object SetOrderProductID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderProductID", RuntimeHelpers.GetObjectValue(value));
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

        public int Quantity
        {
            get
            {
                return this._Quantity;
            }
        }

        public object SetQuantity
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Quantity", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuantityReceived
        {
            get
            {
                return this._QuantityReceived;
            }
        }

        public object SetQuantityReceived
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuantityReceived", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double BuyPrice
        {
            get
            {
                return this._BuyPrice;
            }
        }

        public object SetBuyPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_BuyPrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double SellPrice
        {
            get
            {
                return this._SellPrice;
            }
        }

        public object SetSellPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SellPrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
        }

        public object SetOrderID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int DispatchSiteID
        {
            get
            {
                return this._DispatchSiteID;
            }
        }

        public object SetDispatchSiteID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_DispatchSiteID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int DispatchWarehouseID
        {
            get
            {
                return this._DispatchWarehouseID;
            }
        }

        public object SetDispatchWarehouseID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_DispatchWarehouseID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}