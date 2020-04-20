using System.Collections;

namespace FSM.Entity
{
    namespace CustomerCharges
    {
        public class CustomerCharge
        {
            private DataTypeValidator _dataTypeValidator;

            public CustomerCharge()
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

            private int _CustomerChargeID = 0;

            public int CustomerChargeID
            {
                get
                {
                    return _CustomerChargeID;
                }
            }

            public object SetCustomerChargeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerChargeID", value);
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

            private double _MileageRate = 1;

            public double MileageRate
            {
                get
                {
                    return _MileageRate;
                }
            }

            public object SetMileageRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MileageRate", value);
                }
            }

            private double _PartsMarkup = 0;

            public double PartsMarkup
            {
                get
                {
                    return _PartsMarkup;
                }
            }

            public object SetPartsMarkup
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsMarkup", value);
                }
            }

            private double _RatesMarkup = 0;

            public double RatesMarkup
            {
                get
                {
                    return _RatesMarkup;
                }
            }

            public object SetRatesMarkup
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RatesMarkup", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}