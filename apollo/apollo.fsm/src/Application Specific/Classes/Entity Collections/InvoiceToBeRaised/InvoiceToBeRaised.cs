using System;
using System.Collections;

namespace FSM.Entity
{
    namespace InvoiceToBeRaiseds
    {
        public class InvoiceToBeRaised
        {
            private DataTypeValidator _dataTypeValidator;

            public InvoiceToBeRaised()
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

            
            

            private int _InvoiceToBeRaisedID = 0;

            public int InvoiceToBeRaisedID
            {
                get
                {
                    return _InvoiceToBeRaisedID;
                }
            }

            public object SetInvoiceToBeRaisedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceToBeRaisedID", value);
                }
            }

            private DateTime _RaiseDate = default;

            public DateTime RaiseDate
            {
                get
                {
                    return _RaiseDate;
                }

                set
                {
                    _RaiseDate = value;
                }
            }

            private int _InvoiceTypeID = 0;

            public int InvoiceTypeID
            {
                get
                {
                    return _InvoiceTypeID;
                }
            }

            public object SetInvoiceTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceTypeID", value);
                }
            }

            private int _LinkID = 0;

            public int LinkID
            {
                get
                {
                    return _LinkID;
                }
            }

            public object SetLinkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LinkID", value);
                }
            }

            private int _AddressTypeID = 0;

            public int AddressTypeID
            {
                get
                {
                    return _AddressTypeID;
                }
            }

            public object SetAddressTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AddressTypeID", value);
                }
            }

            private int _AddressLinkID = 0;

            public int AddressLinkID
            {
                get
                {
                    return _AddressLinkID;
                }
            }

            public object SetAddressLinkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AddressLinkID", value);
                }
            }

            private int _CustomerID = 0;

            public int CustomerID
            {
                get
                {
                    return _CustomerID;
                }
            }

            public object SetCustomerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerID", value);
                }
            }

            private int _TaxRateID = 0;

            public int TaxRateID
            {
                get
                {
                    return _TaxRateID;
                }
            }

            public object SetTaxRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TaxRateID", value);
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


            
        }
    }
}