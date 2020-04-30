using System.Collections;

namespace FSM.Entity
{
    namespace PartSupplierPriceRequests
    {
        public class PartSupplierPriceRequest
        {
            private DataTypeValidator _dataTypeValidator;

            public PartSupplierPriceRequest()
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

            
            

            private int _PartSupplierPriceRequestID = 0;

            public int PartSupplierPriceRequestID
            {
                get
                {
                    return _PartSupplierPriceRequestID;
                }
            }

            public object SetPartSupplierPriceRequestID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartSupplierPriceRequestID", value);
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

            private int _PartID = 0;

            public int PartID
            {
                get
                {
                    return _PartID;
                }
            }

            public object SetPartID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartID", value);
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



            
        }
    }
}