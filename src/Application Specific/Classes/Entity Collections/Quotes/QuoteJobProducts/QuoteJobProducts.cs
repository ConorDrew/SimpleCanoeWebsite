using System.Collections;

namespace FSM.Entity
{
    namespace QuoteJobProductss
    {
        public class QuoteJobProducts
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteJobProducts()
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

            private int _QuoteJobProductsID = 0;

            public int QuoteJobProductsID
            {
                get
                {
                    return _QuoteJobProductsID;
                }
            }

            public object SetQuoteJobProductsID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteJobProductsID", value);
                }
            }

            private int _QuoteJobID = 0;

            public int QuoteJobID
            {
                get
                {
                    return _QuoteJobID;
                }
            }

            public object SetQuoteJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteJobID", value);
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

            private double _SellPrice = 0;

            public double SellPrice
            {
                get
                {
                    return _SellPrice;
                }
            }

            public object SetSellPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SellPrice", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}