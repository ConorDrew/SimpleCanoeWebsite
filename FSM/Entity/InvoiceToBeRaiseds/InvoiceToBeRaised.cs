// Decompiled with JetBrains decompiler
// Type: FSM.Entity.InvoiceToBeRaiseds.InvoiceToBeRaised
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.InvoiceToBeRaiseds
{
    public class InvoiceToBeRaised
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _InvoiceToBeRaisedID;
        private DateTime _RaiseDate;
        private int _InvoiceTypeID;
        private int _LinkID;
        private int _AddressTypeID;
        private int _AddressLinkID;
        private int _CustomerID;
        private int _TaxRateID;
        private int _PaymentTermID;
        private int _PaidByID;

        public InvoiceToBeRaised()
        {
            this._exists = false;
            this._deleted = false;
            this._InvoiceToBeRaisedID = 0;
            this._RaiseDate = DateTime.MinValue;
            this._InvoiceTypeID = 0;
            this._LinkID = 0;
            this._AddressTypeID = 0;
            this._AddressLinkID = 0;
            this._CustomerID = 0;
            this._TaxRateID = 0;
            this._PaymentTermID = 0;
            this._PaidByID = 0;
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

        public int InvoiceToBeRaisedID
        {
            get
            {
                return this._InvoiceToBeRaisedID;
            }
        }

        public object SetInvoiceToBeRaisedID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceToBeRaisedID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime RaiseDate
        {
            get
            {
                return this._RaiseDate;
            }
            set
            {
                this._RaiseDate = value;
            }
        }

        public int InvoiceTypeID
        {
            get
            {
                return this._InvoiceTypeID;
            }
        }

        public object SetInvoiceTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int LinkID
        {
            get
            {
                return this._LinkID;
            }
        }

        public object SetLinkID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LinkID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AddressTypeID
        {
            get
            {
                return this._AddressTypeID;
            }
        }

        public object SetAddressTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AddressTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AddressLinkID
        {
            get
            {
                return this._AddressLinkID;
            }
        }

        public object SetAddressLinkID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AddressLinkID", RuntimeHelpers.GetObjectValue(value));
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

        public int TaxRateID
        {
            get
            {
                return this._TaxRateID;
            }
        }

        public object SetTaxRateID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TaxRateID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PaymentTermID
        {
            get
            {
                return this._PaymentTermID;
            }
        }

        public object SetPaymentTermID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PaymentTermID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PaidByID
        {
            get
            {
                return this._PaidByID;
            }
        }

        public object SetPaidByID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PaidByID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}