// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartSupplierPriceRequests.PartSupplierPriceRequest
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PartSupplierPriceRequests
{
    public class PartSupplierPriceRequest
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _PartSupplierPriceRequestID;
        private int _OrderID;
        private int _QuoteID;
        private int _SupplierID;
        private int _PartID;
        private int _QuantityInPack;
        private bool _Complete;

        public PartSupplierPriceRequest()
        {
            this._exists = false;
            this._deleted = false;
            this._PartSupplierPriceRequestID = 0;
            this._OrderID = 0;
            this._QuoteID = 0;
            this._SupplierID = 0;
            this._PartID = 0;
            this._QuantityInPack = 0;
            this._Complete = false;
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

        public int PartSupplierPriceRequestID
        {
            get
            {
                return this._PartSupplierPriceRequestID;
            }
        }

        public object SetPartSupplierPriceRequestID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartSupplierPriceRequestID", RuntimeHelpers.GetObjectValue(value));
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

        public int QuoteID
        {
            get
            {
                return this._QuoteID;
            }
        }

        public object SetQuoteID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteID", RuntimeHelpers.GetObjectValue(value));
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

        public int QuantityInPack
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

        public bool Complete
        {
            get
            {
                return this._Complete;
            }
        }

        public object SetComplete
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Complete", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}