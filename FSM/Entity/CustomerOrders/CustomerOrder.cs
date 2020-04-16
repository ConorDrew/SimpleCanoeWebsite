// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CustomerOrders.CustomerOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CustomerOrders
{
    public class CustomerOrder
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _CustomerOrderID;
        private int _OrderID;
        private int _CustomerID;

        public CustomerOrder()
        {
            this._exists = false;
            this._deleted = false;
            this._CustomerOrderID = 0;
            this._OrderID = 0;
            this._CustomerID = 0;
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

        public int CustomerOrderID
        {
            get
            {
                return this._CustomerOrderID;
            }
        }

        public object SetCustomerOrderID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerOrderID", RuntimeHelpers.GetObjectValue(value));
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
    }
}