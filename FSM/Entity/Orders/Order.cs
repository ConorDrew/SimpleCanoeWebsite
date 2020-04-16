// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Orders.Order
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Orders
{
    public class Order
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _OrderID;
        private DateTime _DatePlaced;
        private int _OrderTypeID;
        private string _OrderReference;
        private int _UserID;
        private int _OrderStatusID;
        private string _ReasonForReject;
        private DateTime _DeliveryDeadline;
        private bool _sentToSage;
        private DateTime _supplierInvoiceDate;
        private double _supplierInvoiceAmount;
        private string _supplierInvoiceReference;
        private int _allocatedToUser;
        private int _invoiceAddressID;
        private int _contactID;
        private string _specialInstructions;
        private bool _Invoiced;
        private bool _ExportedToSage;
        private string _NominalCode;
        private string _DepartmentRef;
        private string _ExtraRef;
        private int _TaxCodeID;
        private bool _ReadyToSendToSage;
        private int _OrderConsolidationID;
        private double _VATAmount;
        private bool _DoNotConsolidated;
        private string _reason;

        public Order()
        {
            this._exists = false;
            this._deleted = false;
            this._OrderID = 0;
            this._DatePlaced = DateTime.MinValue;
            this._OrderTypeID = 0;
            this._OrderReference = string.Empty;
            this._UserID = 0;
            this._OrderStatusID = 0;
            this._ReasonForReject = string.Empty;
            this._DeliveryDeadline = DateTime.MinValue;
            this._sentToSage = false;
            this._supplierInvoiceDate = DateTime.MinValue;
            this._supplierInvoiceAmount = 0.0;
            this._supplierInvoiceReference = "";
            this._allocatedToUser = 0;
            this._invoiceAddressID = 0;
            this._contactID = 0;
            this._specialInstructions = "";
            this._Invoiced = false;
            this._ExportedToSage = false;
            this._NominalCode = "";
            this._DepartmentRef = "";
            this._ExtraRef = "";
            this._TaxCodeID = 0;
            this._ReadyToSendToSage = false;
            this._OrderConsolidationID = 0;
            this._VATAmount = 0.0;
            this._DoNotConsolidated = false;
            this._reason = string.Empty;
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

        public DateTime DatePlaced
        {
            get
            {
                return this._DatePlaced;
            }
            set
            {
                this._DatePlaced = value;
            }
        }

        public int OrderTypeID
        {
            get
            {
                return this._OrderTypeID;
            }
        }

        public object SetOrderTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderTypeID", RuntimeHelpers.GetObjectValue(value));
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

        public int UserID
        {
            get
            {
                return this._UserID;
            }
        }

        public object SetUserID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_UserID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OrderStatusID
        {
            get
            {
                return this._OrderStatusID;
            }
        }

        public object SetOrderStatusID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderStatusID", RuntimeHelpers.GetObjectValue(value));
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

        public bool SentToSage
        {
            get
            {
                return this._sentToSage;
            }
        }

        public object SetSentToSage
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_sentToSage", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime SupplierInvoiceDate
        {
            get
            {
                return this._supplierInvoiceDate;
            }
            set
            {
                this._supplierInvoiceDate = value;
            }
        }

        public double SupplierInvoiceAmount
        {
            get
            {
                return this._supplierInvoiceAmount;
            }
        }

        public object SetSupplierInvoiceAmount
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_supplierInvoiceAmount", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string SupplierInvoiceReference
        {
            get
            {
                return this._supplierInvoiceReference;
            }
        }

        public object SetSupplierInvoiceReference
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_supplierInvoiceReference", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AllocatedToUser
        {
            get
            {
                return this._allocatedToUser;
            }
        }

        public object SetAllocatedToUser
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_allocatedToUser", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int InvoiceAddressID
        {
            get
            {
                return this._invoiceAddressID;
            }
        }

        public object SetInvoiceAddressID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_invoiceAddressID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ContactID
        {
            get
            {
                return this._contactID;
            }
        }

        public object SetContactID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_contactID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string SpecialInstructions
        {
            get
            {
                return this._specialInstructions;
            }
        }

        public object SetSpecialInstructions
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_specialInstructions", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool Invoiced
        {
            get
            {
                return this._Invoiced;
            }
        }

        public bool SetInvoiced
        {
            set
            {
                this._Invoiced = value;
            }
        }

        public bool ExportedToSage
        {
            get
            {
                return this._ExportedToSage;
            }
        }

        public bool SetExportedToSage
        {
            set
            {
                this._ExportedToSage = value;
            }
        }

        public string NominalCode
        {
            get
            {
                return this._NominalCode;
            }
        }

        public object SetNominalCode
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_NominalCode", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string DepartmentRef
        {
            get
            {
                return this._DepartmentRef;
            }
        }

        public object SetDepartmentRef
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_DepartmentRef", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string ExtraRef
        {
            get
            {
                return this._ExtraRef;
            }
        }

        public object SetExtraRef
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ExtraRef", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int TaxCodeID
        {
            get
            {
                return this._TaxCodeID;
            }
        }

        public object SetTaxCodeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TaxCodeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool ReadyToSendToSage
        {
            get
            {
                return this._ReadyToSendToSage;
            }
        }

        public bool SetReadyToSendToSage
        {
            set
            {
                this._ReadyToSendToSage = value;
            }
        }

        public int OrderConsolidationID
        {
            get
            {
                return this._OrderConsolidationID;
            }
        }

        public object SetOrderConsolidationID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderConsolidationID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double VATAmount
        {
            get
            {
                return this._VATAmount;
            }
        }

        public object SetVATAmount
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VATAmount", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool DoNotConsolidated
        {
            get
            {
                return this._DoNotConsolidated;
            }
        }

        public object SetDoNotConsolidated
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_DoNotConsolidated", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Reason
        {
            get
            {
                return this._reason;
            }
        }

        public object SetReason
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_reason", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}