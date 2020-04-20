// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteOrders.QuoteOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteOrders
{
    public class QuoteOrder
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteOrderID;
        private int _CustomerID;
        private int _WarehouseID;
        private int _PropertyID;
        private int _QuoteStatusID;
        private int _ContactID;
        private int _InvoiceAddressID;
        private string _ReasonForReject;
        private int _ReasonForRejectID;
        private string _CustomerRef;
        private DateTime _DeliveryDeadline;
        private string _SpecialInstructions;
        private int _CreatedByUser;
        private int _AllocatedToUser;
        private DateTime _EnquiryDate;
        private DateTime _validUntilDate;
        private string _Availability;
        private string _PriceDetails;
        private string _PriceExcludeDetails;

        public QuoteOrder()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteOrderID = 0;
            this._CustomerID = 0;
            this._WarehouseID = 0;
            this._PropertyID = 0;
            this._QuoteStatusID = 0;
            this._ContactID = 0;
            this._InvoiceAddressID = 0;
            this._ReasonForReject = string.Empty;
            this._ReasonForRejectID = 0;
            this._CustomerRef = string.Empty;
            this._DeliveryDeadline = DateTime.MinValue;
            this._SpecialInstructions = string.Empty;
            this._CreatedByUser = 0;
            this._AllocatedToUser = 0;
            this._EnquiryDate = DateTime.MinValue;
            this._validUntilDate = DateTime.MinValue;
            this._Availability = string.Empty;
            this._PriceDetails = string.Empty;
            this._PriceExcludeDetails = string.Empty;
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

        public int QuoteOrderID
        {
            get
            {
                return this._QuoteOrderID;
            }
        }

        public object SetQuoteOrderID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteOrderID", RuntimeHelpers.GetObjectValue(value));
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

        public int WarehouseID
        {
            get
            {
                return this._WarehouseID;
            }
        }

        public object SetWarehouseID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_WarehouseID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PropertyID
        {
            get
            {
                return this._PropertyID;
            }
        }

        public object SetPropertyID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PropertyID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuoteStatusID
        {
            get
            {
                return this._QuoteStatusID;
            }
        }

        public object SetQuoteStatusID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteStatusID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ContactID
        {
            get
            {
                return this._ContactID;
            }
        }

        public object SetContactID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContactID", RuntimeHelpers.GetObjectValue(value));
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

        public string CustomerRef
        {
            get
            {
                return this._CustomerRef;
            }
        }

        public object SetCustomerRef
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerRef", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime DeliveryDeadline
        {
            get
            {
                return this._DeliveryDeadline;
            }
            set
            {
                this._DeliveryDeadline = value;
            }
        }

        public string SpecialInstructions
        {
            get
            {
                return this._SpecialInstructions;
            }
        }

        public object SetSpecialInstructions
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SpecialInstructions", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int CreatedByUser
        {
            get
            {
                return this._CreatedByUser;
            }
        }

        public object SetCreatedByUser
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CreatedByUser", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AllocatedToUser
        {
            get
            {
                return this._AllocatedToUser;
            }
        }

        public object SetAllocatedToUser
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AllocatedToUser", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime EnquiryDate
        {
            get
            {
                return this._EnquiryDate;
            }
            set
            {
                this._EnquiryDate = value;
            }
        }

        public DateTime ValidUntilDate
        {
            get
            {
                return this._validUntilDate;
            }
            set
            {
                this._validUntilDate = value;
            }
        }

        public string Availability
        {
            get
            {
                return this._Availability;
            }
        }

        public object SetAvailability
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Availability", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string PriceDetails
        {
            get
            {
                return this._PriceDetails;
            }
        }

        public object SetPriceDetails
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PriceDetails", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string PriceExcludeDetails
        {
            get
            {
                return this._PriceExcludeDetails;
            }
        }

        public object SetPriceExcludeDetails
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PriceExcludeDetails", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}