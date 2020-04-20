using System;
using System.Collections;

namespace FSM.Entity
{
    namespace Invoiceds
    {
        public class Invoiced
        {
            private DataTypeValidator _dataTypeValidator;

            public Invoiced()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private int _InvoicedID = 0;

            public int InvoicedID
            {
                get
                {
                    return _InvoicedID;
                }
            }

            public object SetInvoicedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoicedID", value);
                }
            }

            private string _InvoiceNumber = string.Empty;

            public string InvoiceNumber
            {
                get
                {
                    return _InvoiceNumber;
                }
            }

            public object SetInvoiceNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceNumber", value);
                }
            }

            private string _AdhocInvoiceType = string.Empty;

            public string AdhocInvoiceType
            {
                get
                {
                    return _AdhocInvoiceType;
                }
            }

            public object SetAdhocInvoiceType
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AdhocInvoiceType", value);
                }
            }

            // AdhocInvoiceType

            private DateTime _RaisedDate = default;

            public DateTime RaisedDate
            {
                get
                {
                    return _RaisedDate;
                }

                set
                {
                    _RaisedDate = value;
                }
            }

            private int _RaisedByUserID = 0;

            public int RaisedByUserID
            {
                get
                {
                    return _RaisedByUserID;
                }
            }

            public object SetRaisedByUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RaisedByUserID", value);
                }
            }

            private int _VATRateID = 0;

            public int VATRateID
            {
                get
                {
                    return _VATRateID;
                }
            }

            public object SetVATRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VATRateID", value);
                }
            }

            private int _PaymentTermID = 0;

            public int PaymentTermID
            {
                get
                {
                    return _PaymentTermID;
                }
            }

            public object SetPaymentTermID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PaymentTermID", value);
                }
            }

            private int _PaidByID = 0;

            public int PaidByID
            {
                get
                {
                    return _PaidByID;
                }
            }

            public object SetPaidByID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PaidByID", value);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}