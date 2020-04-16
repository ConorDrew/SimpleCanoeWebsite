// Decompiled with JetBrains decompiler
// Type: FSM.Entity.TabletOrders.TabletOrderPart
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.TabletOrders
{
    public class TabletOrderPart
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _OrderPartID;
        private int _OrderID;
        private int _EngineerID;
        private int _Quantity;
        private int _PartSupplierID;
        private string _Status;

        public TabletOrderPart()
        {
            this._exists = false;
            this._deleted = false;
            this._OrderPartID = 0;
            this._Status = string.Empty;
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

        public int OrderPartID
        {
            get
            {
                return this._OrderPartID;
            }
        }

        public object SetOrderPartID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderPartID", RuntimeHelpers.GetObjectValue(value));
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

        public int EngineerID
        {
            get
            {
                return this._EngineerID;
            }
        }

        public object SetEngineerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Quantity
        {
            get
            {
                return Conversions.ToString(this._Quantity);
            }
        }

        public object SetQuantity
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Quantity", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string PartSupplierID
        {
            get
            {
                return Conversions.ToString(this._PartSupplierID);
            }
        }

        public object SetPartSupplierID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartSupplierID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Status
        {
            get
            {
                return this._Status;
            }
        }

        public object SetStatus
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Status", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}