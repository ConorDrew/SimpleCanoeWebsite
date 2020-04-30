using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Orders
    {
        public class SupplierInvoice
        {
            private DataTypeValidator _dataTypeValidator;

            public SupplierInvoice()
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

            
            
            private int _InvoiceID = 0;

            public int InvoiceID
            {
                get
                {
                    return _InvoiceID;
                }
            }

            public object SetInvoiceID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceID", value);
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

            private string _InvoiceReference;

            public string InvoiceReference
            {
                get
                {
                    return _InvoiceReference;
                }
            }

            public object SetInvoiceReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceReference", value);
                }
            }

            private DateTime _InvoiceDate = default;

            public DateTime InvoiceDate
            {
                get
                {
                    return _InvoiceDate;
                }
            }

            public object SetInvoiceDate
            {
                set
                {
                    _InvoiceDate = Conversions.ToDate(value);
                }
            }

            private double _GoodsAmount;

            public double GoodsAmount
            {
                get
                {
                    return _GoodsAmount;
                }
            }

            public object SetGoodsAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_GoodsAmount", value);
                }
            }

            private double _VATAmount;

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

            private double _TotalAmount;

            public double TotalAmount
            {
                get
                {
                    return _TotalAmount;
                }
            }

            public object SetTotalAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TotalAmount", value);
                }
            }

            private int _TaxCodeID;

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
                    _TaxCodeID = Conversions.ToInteger(value);
                }
            }

            private string _NominalCode;

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

            private string _ExtraRef;

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

            private bool _ReadyToSendToSage;

            public bool ReadyToSendToSage
            {
                get
                {
                    return _ReadyToSendToSage;
                }
            }

            public object SetReadyToSendToSage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReadyToSendToSage", value);
                }
            }

            private bool _SentToSage;

            public bool SentToSage
            {
                get
                {
                    return _SentToSage;
                }
            }

            public object SetSentToSage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SentToSage", value);
                }
            }

            private bool _OldSystemInvoice;

            public bool OldSystemInvoice
            {
                get
                {
                    return _OldSystemInvoice;
                }
            }

            public object SetOldSystemInvoice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OldSystemInvoice", value);
                }
            }

            private DateTime _DateExported = default;

            public DateTime DateExported
            {
                get
                {
                    return _DateExported;
                }
            }

            public object SetDateExported
            {
                set
                {
                    _DateExported = Conversions.ToDate(value);
                }
            }

            private int _KeyedBy;

            public int KeyedBy
            {
                get
                {
                    return _KeyedBy;
                }
            }

            public object SetKeyedBy
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_KeyedBy", value);
                }
            }
            
        }
    }
}