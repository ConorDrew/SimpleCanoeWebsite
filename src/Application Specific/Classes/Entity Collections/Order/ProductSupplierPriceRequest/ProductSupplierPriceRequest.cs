using System.Collections;

namespace FSM.Entity
{
    namespace ProductSupplierPriceRequests
    {
        public class ProductSupplierPriceRequest
        {
            private DataTypeValidator _dataTypeValidator;

            public ProductSupplierPriceRequest()
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

            
            

            private int _ProductSupplierPriceRequestID = 0;

            public int ProductSupplierPriceRequestID
            {
                get
                {
                    return _ProductSupplierPriceRequestID;
                }
            }

            public object SetProductSupplierPriceRequestID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ProductSupplierPriceRequestID", value);
                }
            }

            private int _QuoteID = 0;

            public int QuoteID
            {
                get
                {
                    return _QuoteID;
                }
            }

            public object SetQuoteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteID", value);
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

            private int _QuantityInPack = 0;

            public int QuantityInPack
            {
                get
                {
                    return _QuantityInPack;
                }
            }

            public object SetQuantityInPack
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuantityInPack", value);
                }
            }

            private bool _Complete = false;

            public bool Complete
            {
                get
                {
                    return _Complete;
                }
            }

            public object SetComplete
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Complete", value);
                }
            }

            private int _ProductID = 0;

            public int ProductID
            {
                get
                {
                    return _ProductID;
                }
            }

            public object SetProductID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ProductID", value);
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



            
        }
    }
}