using System;
using System.Collections;

namespace FSM.Entity
{
    namespace OrderConsolidations
    {
        public class OrderConsolidation
        {
            private DataTypeValidator _dataTypeValidator;

            public OrderConsolidation()
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

            private int _SupplierID = 0;

            public int SupplierID
            {
                get
                {
                    return _SupplierID;
                }
            }

            public object SetSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SupplierID", value);
                }
            }

            private int _LocationID = 0;

            public int LocationID
            {
                get
                {
                    return _LocationID;
                }
            }

            public object SetLocationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LocationID", value);
                }
            }

            private DateTime _ConsolidationDate = default;

            public DateTime ConsolidationDate
            {
                get
                {
                    return _ConsolidationDate;
                }

                set
                {
                    _ConsolidationDate = value;
                }
            }

            private string _ConsolidationRef = string.Empty;

            public string ConsolidationRef
            {
                get
                {
                    return _ConsolidationRef;
                }
            }

            public object SetConsolidationRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ConsolidationRef", value);
                }
            }

            private string _Comments = string.Empty;

            public string Comments
            {
                get
                {
                    return _Comments;
                }
            }

            public object SetComments
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Comments", value);
                }
            }

            private int _ConsolidatedOrderStatusID;

            public int ConsolidatedOrderStatusID
            {
                get
                {
                    return _ConsolidatedOrderStatusID;
                }
            }

            public int SetConsolidatedOrderStatusID
            {
                set
                {
                    _ConsolidatedOrderStatusID = value;
                }
            }

            private bool _HasSupplierPO = false;

            public bool HasSupplierPO
            {
                get
                {
                    return _HasSupplierPO;
                }

                set
                {
                    _HasSupplierPO = value;
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

            private DateTime _DateExported = default;

            public DateTime DateExported
            {
                get
                {
                    return _DateExported;
                }

                set
                {
                    _DateExported = value;
                }
            }

            
        }
    }
}