// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobProductss.QuoteJobProducts
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobProductss
{
    public class QuoteJobProducts
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteJobProductsID;
        private int _QuoteJobID;
        private int _ProductID;
        private int _Quantity;
        private double _SellPrice;

        public QuoteJobProducts()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteJobProductsID = 0;
            this._QuoteJobID = 0;
            this._ProductID = 0;
            this._Quantity = 0;
            this._SellPrice = 0.0;
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

        public int QuoteJobProductsID
        {
            get
            {
                return this._QuoteJobProductsID;
            }
        }

        public object SetQuoteJobProductsID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteJobProductsID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuoteJobID
        {
            get
            {
                return this._QuoteJobID;
            }
        }

        public object SetQuoteJobID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteJobID", RuntimeHelpers.GetObjectValue(value));
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
    }
}