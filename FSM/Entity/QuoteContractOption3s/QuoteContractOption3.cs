// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOption3s.QuoteContractOption3
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOption3s
{
    public class QuoteContractOption3
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteContractID;
        private int _CustomerID;
        private string _QuoteContractReference;
        private int _QuoteContractStatusID;
        private DateTime _QuoteContractDate;
        private double _QuoteContractPrice;
        private string _ReasonForReject;
        private int _ReasonForRejectID;

        public QuoteContractOption3()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteContractID = 0;
            this._CustomerID = 0;
            this._QuoteContractReference = string.Empty;
            this._QuoteContractStatusID = 0;
            this._QuoteContractDate = DateTime.MinValue;
            this._QuoteContractPrice = 0.0;
            this._ReasonForReject = string.Empty;
            this._ReasonForRejectID = 0;
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

        public int QuoteContractID
        {
            get
            {
                return this._QuoteContractID;
            }
        }

        public object SetQuoteContractID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractID", RuntimeHelpers.GetObjectValue(value));
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

        public string QuoteContractReference
        {
            get
            {
                return this._QuoteContractReference;
            }
        }

        public object SetQuoteContractReference
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractReference", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuoteContractStatusID
        {
            get
            {
                return this._QuoteContractStatusID;
            }
        }

        public object SetQuoteContractStatusID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractStatusID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime QuoteContractDate
        {
            get
            {
                return this._QuoteContractDate;
            }
            set
            {
                this._QuoteContractDate = value;
            }
        }

        public double QuoteContractPrice
        {
            get
            {
                return this._QuoteContractPrice;
            }
        }

        public object SetQuoteContractPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractPrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string ReasonForReject
        {
            get
            {
                return this._ReasonForReject;
            }
        }

        public object SetReasonForReject
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ReasonForReject", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ReasonForRejectID
        {
            get
            {
                return this._ReasonForRejectID;
            }
        }

        public object SetReasonForRejectID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ReasonForRejectID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}