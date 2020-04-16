// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractsAlternative.ContractAlternative
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractsAlternative
{
    public class ContractAlternative
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _ContractID;
        private int _CustomerID;
        private string _ContractReference;
        private DateTime _ContractStartDate;
        private DateTime _ContractEndDate;
        private int _ContractStatusID;
        private double _ContractPrice;
        private int _QuoteContractID;
        private int _InvoiceFrequencyID;
        private DateTime _FirstInvoiceDate;
        private int _InvoiceAddressTypeID;
        private int _InvoiceAddressID;

        public ContractAlternative()
        {
            this._exists = false;
            this._deleted = false;
            this._ContractID = 0;
            this._CustomerID = 0;
            this._ContractReference = string.Empty;
            this._ContractStartDate = DateTime.MinValue;
            this._ContractEndDate = DateTime.MinValue;
            this._ContractStatusID = 0;
            this._ContractPrice = 0.0;
            this._QuoteContractID = 0;
            this._InvoiceFrequencyID = 0;
            this._InvoiceAddressID = 0;
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

        public int ContractID
        {
            get
            {
                return this._ContractID;
            }
        }

        public object SetContractID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractID", RuntimeHelpers.GetObjectValue(value));
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

        public string ContractReference
        {
            get
            {
                return this._ContractReference;
            }
        }

        public object SetContractReference
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractReference", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime ContractStartDate
        {
            get
            {
                return this._ContractStartDate;
            }
            set
            {
                this._ContractStartDate = value;
            }
        }

        public DateTime ContractEndDate
        {
            get
            {
                return this._ContractEndDate;
            }
            set
            {
                this._ContractEndDate = value;
            }
        }

        public int ContractStatusID
        {
            get
            {
                return this._ContractStatusID;
            }
        }

        public object SetContractStatusID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractStatusID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double ContractPrice
        {
            get
            {
                return this._ContractPrice;
            }
        }

        public object SetContractPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractPrice", RuntimeHelpers.GetObjectValue(value));
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

        public int InvoiceFrequencyID
        {
            get
            {
                return this._InvoiceFrequencyID;
            }
        }

        public object SetInvoiceFrequencyID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceFrequencyID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime FirstInvoiceDate
        {
            get
            {
                return this._FirstInvoiceDate;
            }
            set
            {
                this._FirstInvoiceDate = value;
            }
        }

        public int InvoiceAddressTypeID
        {
            get
            {
                return this._InvoiceAddressTypeID;
            }
        }

        public object SetInvoiceAddressTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceAddressTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int InvoiceAddressID
        {
            get
            {
                return this._InvoiceAddressID;
            }
        }

        public object SetInvoiceAddressID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceAddressID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}