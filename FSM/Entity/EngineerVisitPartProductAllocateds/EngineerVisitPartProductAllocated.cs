// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitPartProductAllocateds.EngineerVisitPartProductAllocated
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitPartProductAllocateds
{
    public class EngineerVisitPartProductAllocated
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private string _Type;
        private int _ID;
        private int _EngineerVisitID;
        private int _PartProductID;
        private string _Name;
        private string _Number;
        private int _Quantity;
        private int _orderItemID;
        private int _orderLocationTypeID;
        private double _sellPrice;

        public EngineerVisitPartProductAllocated()
        {
            this._exists = false;
            this._deleted = false;
            this._Type = string.Empty;
            this._ID = 0;
            this._EngineerVisitID = 0;
            this._PartProductID = 0;
            this._Name = string.Empty;
            this._Number = string.Empty;
            this._Quantity = 0;
            this._orderItemID = 0;
            this._orderLocationTypeID = 0;
            this._sellPrice = 0.0;
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

        public string Type
        {
            get
            {
                return this._Type;
            }
        }

        public object SetType
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Type", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ID
        {
            get
            {
                return this._ID;
            }
        }

        public object SetID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerVisitID
        {
            get
            {
                return this._EngineerVisitID;
            }
        }

        public object SetEngineerVisitID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerVisitID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PartProductID
        {
            get
            {
                return this._PartProductID;
            }
        }

        public object SetPartProductID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartProductID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public object SetName
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Name", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Number
        {
            get
            {
                return this._Number;
            }
        }

        public object SetNumber
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Number", RuntimeHelpers.GetObjectValue(value));
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

        public int OrderItemID
        {
            get
            {
                return this._orderItemID;
            }
        }

        public object SetOrderItemID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_orderItemID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OrderLocationTypeID
        {
            get
            {
                return this._orderLocationTypeID;
            }
        }

        public object SetOrderLocationTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_orderLocationTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double SellPrice
        {
            get
            {
                return this._sellPrice;
            }
        }

        public object SetSellPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_sellPrice", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}