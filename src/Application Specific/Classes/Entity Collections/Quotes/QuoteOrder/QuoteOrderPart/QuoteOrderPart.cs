using System.Collections;

namespace FSM.Entity
{
    namespace QuoteOrderParts
    {
        public class QuoteOrderPart
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteOrderPart()
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

            
            

            private int _QuoteOrderPartID = 0;

            public int QuoteOrderPartID
            {
                get
                {
                    return _QuoteOrderPartID;
                }
            }

            public object SetQuoteOrderPartID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteOrderPartID", value);
                }
            }

            private int _QuoteOrderID = 0;

            public int QuoteOrderID
            {
                get
                {
                    return _QuoteOrderID;
                }
            }

            public object SetQuoteOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteOrderID", value);
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

            private int _Quantity = 0;

            public int Quantity
            {
                get
                {
                    return _Quantity;
                }
            }

            public object SetQuantity
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Quantity", value);
                }
            }

            private double _Price = 0;

            public double Price
            {
                get
                {
                    return _Price;
                }
            }

            public object SetPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Price", value);
                }
            }

            
        }
    }
}