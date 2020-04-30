using System;
using System.Collections;

namespace FSM.Entity
{
    namespace Orders
    {
        public class Order
        {
            private DataTypeValidator _dataTypeValidator;

            public Order()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            
            
            private int _OrderID = 0;

            public int OrderID
            {
                get
                {
                    return _OrderID;
                }
            }

            public object SetOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderID", value);
                }
            }

            private DateTime _DatePlaced = default;

            public DateTime DatePlaced
            {
                get
                {
                    return _DatePlaced;
                }

                set
                {
                    _DatePlaced = value;
                }
            }

            private int _OrderTypeID = 0;

            public int OrderTypeID
            {
                get
                {
                    return _OrderTypeID;
                }
            }

            public object SetOrderTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderTypeID", value);
                }
            }

            private string _OrderReference = string.Empty;

            public string OrderReference
            {
                get
                {
                    return _OrderReference;
                }
            }

            public object SetOrderReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderReference", value);
                }
            }

            private int _UserID = 0;

            public int UserID
            {
                get
                {
                    return _UserID;
                }
            }

            public object SetUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UserID", value);
                }
            }

            private int _OrderStatusID = 0;

            public int OrderStatusID
            {
                get
                {
                    return _OrderStatusID;
                }
            }

            public object SetOrderStatusID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderStatusID", value);
                }
            }

            private string _ReasonForReject = string.Empty;

            public string ReasonForReject
            {
                get
                {
                    return _ReasonForReject;
                }
            }

            public object SetReasonForReject
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForReject", value);
                }
            }

            private DateTime _DeliveryDeadline = default;

            public DateTime DeliveryDeadline
            {
                get
                {
                    return _DeliveryDeadline;
                }

                set
                {
                    _DeliveryDeadline = value;
                }
            }

            private bool _sentToSage = false;

            public bool SentToSage
            {
                get
                {
                    return _sentToSage;
                }
            }

            public object SetSentToSage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_sentToSage", value);
                }
            }

            private DateTime _supplierInvoiceDate = default;

            public DateTime SupplierInvoiceDate
            {
                get
                {
                    return _supplierInvoiceDate;
                }

                set
                {
                    _supplierInvoiceDate = value;
                }
            }

            private double _supplierInvoiceAmount = 0;

            public double SupplierInvoiceAmount
            {
                get
                {
                    return _supplierInvoiceAmount;
                }
            }

            public object SetSupplierInvoiceAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_supplierInvoiceAmount", value);
                }
            }

            private string _supplierInvoiceReference = "";

            public string SupplierInvoiceReference
            {
                get
                {
                    return _supplierInvoiceReference;
                }
            }

            public object SetSupplierInvoiceReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_supplierInvoiceReference", value);
                }
            }

            private int _allocatedToUser = 0;

            public int AllocatedToUser
            {
                get
                {
                    return _allocatedToUser;
                }
            }

            public object SetAllocatedToUser
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_allocatedToUser", value);
                }
            }

            private int _invoiceAddressID = 0;

            public int InvoiceAddressID
            {
                get
                {
                    return _invoiceAddressID;
                }
            }

            public object SetInvoiceAddressID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_invoiceAddressID", value);
                }
            }

            private int _contactID = 0;

            public int ContactID
            {
                get
                {
                    return _contactID;
                }
            }

            public object SetContactID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_contactID", value);
                }
            }

            private string _specialInstructions = "";

            public string SpecialInstructions
            {
                get
                {
                    return _specialInstructions;
                }
            }

            public object SetSpecialInstructions
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_specialInstructions", value);
                }
            }

            private bool _Invoiced = false;

            public bool Invoiced
            {
                get
                {
                    return _Invoiced;
                }
            }

            public bool SetInvoiced
            {
                set
                {
                    _Invoiced = value;
                }
            }

            private bool _ExportedToSage = false;

            public bool ExportedToSage
            {
                get
                {
                    return _ExportedToSage;
                }
            }

            public bool SetExportedToSage
            {
                set
                {
                    _ExportedToSage = value;
                }
            }

            private string _NominalCode = "";

            public string NominalCode
            {
                get
                {
                    return _NominalCode;
                }
            }

            public object SetNominalCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NominalCode", value);
                }
            }

            private string _DepartmentRef = "";

            public string DepartmentRef
            {
                get
                {
                    return _DepartmentRef;
                }
            }

            public object SetDepartmentRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DepartmentRef", value);
                }
            }

            private string _ExtraRef = "";

            public string ExtraRef
            {
                get
                {
                    return _ExtraRef;
                }
            }

            public object SetExtraRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ExtraRef", value);
                }
            }

            private int _TaxCodeID = 0;

            public int TaxCodeID
            {
                get
                {
                    return _TaxCodeID;
                }
            }

            public object SetTaxCodeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TaxCodeID", value);
                }
            }

            private bool _ReadyToSendToSage = false;

            public bool ReadyToSendToSage
            {
                get
                {
                    return _ReadyToSendToSage;
                }
            }

            public bool SetReadyToSendToSage
            {
                set
                {
                    _ReadyToSendToSage = value;
                }
            }

            private int _OrderConsolidationID = 0;

            public int OrderConsolidationID
            {
                get
                {
                    return _OrderConsolidationID;
                }
            }

            public object SetOrderConsolidationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderConsolidationID", value);
                }
            }

            private double _VATAmount = 0.0;

            public double VATAmount
            {
                get
                {
                    return _VATAmount;
                }
            }

            public object SetVATAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VATAmount", value);
                }
            }

            private bool _DoNotConsolidated = false;

            public bool DoNotConsolidated
            {
                get
                {
                    return _DoNotConsolidated;
                }
            }

            public object SetDoNotConsolidated
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DoNotConsolidated", value);
                }
            }

            private string _reason = string.Empty;

            public string Reason
            {
                get
                {
                    return _reason;
                }
            }

            public object SetReason
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_reason", value);
                }
            }

            
        }
    }
}