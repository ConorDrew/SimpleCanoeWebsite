// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobItems.QuoteJobItem
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobItems
{
    public class QuoteJobItem
    {
        private DataTypeValidator _dataTypeValidator;
        private int _QuoteJobItemID;
        private int _QuoteJobOfWorkID;
        private string _Summary;
        private int _RateID;
        private Decimal _Qty;
        private int _systemLinkId;

        public QuoteJobItem()
        {
            this._QuoteJobItemID = 0;
            this._QuoteJobOfWorkID = 0;
            this._Summary = string.Empty;
            this._RateID = 0;
            this._systemLinkId = 0;
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

        public int QuoteJobItemID
        {
            get
            {
                return this._QuoteJobItemID;
            }
        }

        public object SetQuoteJobItemID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteJobItemID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuoteJobOfWorkID
        {
            get
            {
                return this._QuoteJobOfWorkID;
            }
        }

        public object SetQuoteJobOfWorkID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteJobOfWorkID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Summary
        {
            get
            {
                return this._Summary;
            }
        }

        public object SetSummary
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Summary", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int RateID
        {
            get
            {
                return this._RateID;
            }
        }

        public object SetRateID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_RateID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public Decimal Qty
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

        public int SystemLinkID
        {
            get
            {
                return this._systemLinkId;
            }
        }

        public object SetSystemLinkID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_systemLinkId", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}