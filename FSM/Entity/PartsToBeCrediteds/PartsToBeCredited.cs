// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartsToBeCrediteds.PartsToBeCredited
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PartsToBeCrediteds
{
    public class PartsToBeCredited
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _PartsToBeCreditedID;
        private int _OrderID;
        private int _SupplierID;
        private int _PartID;
        private int _Qty;
        private bool _ManuallyAdded;
        private int _StatusID;
        private double _CreditReceived;
        private string _OrderReference;
        private int _PartOrderID;
        private string _ReturnRef;

        public PartsToBeCredited()
        {
            this._exists = false;
            this._deleted = false;
            this._PartsToBeCreditedID = 0;
            this._OrderID = 0;
            this._SupplierID = 0;
            this._PartID = 0;
            this._Qty = 0;
            this._ManuallyAdded = false;
            this._StatusID = 0;
            this._CreditReceived = 0.0;
            this._OrderReference = Conversions.ToString(0);
            this._PartOrderID = 0;
            this._ReturnRef = Conversions.ToString(0);
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

        public int PartsToBeCreditedID
        {
            get
            {
                return this._PartsToBeCreditedID;
            }
        }

        public object SetPartsToBeCreditedID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartsToBeCreditedID", RuntimeHelpers.GetObjectValue(value));
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

        public int Qty
        {
            get
            {
                return this._Qty;
            }
        }

        public object SetQty
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Qty", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ManuallyAdded
        {
            get
            {
                return -(this._ManuallyAdded ? 1 : 0);
            }
        }

        public object SetManuallyAdded
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ManuallyAdded", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int StatusID
        {
            get
            {
                return this._StatusID;
            }
        }

        public object SetStatusID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_StatusID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double CreditReceived
        {
            get
            {
                return this._CreditReceived;
            }
        }

        public object SetCreditReceived
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CreditReceived", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string OrderReference
        {
            get
            {
                return this._OrderReference;
            }
        }

        public object SetOrderReference
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderReference", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PartOrderID
        {
            get
            {
                return this._PartOrderID;
            }
        }

        public object SetPartOrderID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartOrderID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string ReturnRef
        {
            get
            {
                return this._ReturnRef;
            }
        }

        public object SetReturnRef
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ReturnRef", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}