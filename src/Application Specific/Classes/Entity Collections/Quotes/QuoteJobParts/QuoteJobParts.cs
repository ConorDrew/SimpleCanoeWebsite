using System.Collections;

namespace FSM.Entity
{
    namespace QuoteJobPartss
    {
        public class QuoteJobParts
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteJobParts()
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

            private int _QuoteJobPartsID = 0;

            public int QuoteJobPartsID
            {
                get
                {
                    return _QuoteJobPartsID;
                }
            }

            public object SetQuoteJobPartsID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteJobPartsID", value);
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

            private double _BuyPrice = 0;

            public double BuyPrice
            {
                get
                {
                    return _BuyPrice;
                }
            }

            public object SetBuyPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BuyPrice", value);
                }
            }

            private double _SpecialCost = 0;

            public double SpecialCost
            {
                get
                {
                    return _SpecialCost;
                }
            }

            public object SetSpecialCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SpecialCost", value);
                }
            }

            private int _PartSupplierID = 0;

            public int PartSupplierID
            {
                get
                {
                    return _PartSupplierID;
                }
            }

            public object SetPartSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartSupplierID", value);
                }
            }

            private string _SpecialDescription = "";

            public string SpecialDescription
            {
                get
                {
                    return _SpecialDescription;
                }
            }

            public object SetSpecialDescription
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SpecialDescription", value);
                }
            }

            private string _Extra = "";

            public string Extra
            {
                get
                {
                    return _Extra;
                }
            }

            public object SetExtra
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Extra", value);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}