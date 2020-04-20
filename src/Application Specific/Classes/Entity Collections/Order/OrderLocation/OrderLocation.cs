using System.Collections;

namespace FSM.Entity
{
    namespace OrderLocations
    {
        public class OrderLocation
        {
            private DataTypeValidator _dataTypeValidator;

            public OrderLocation()
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

            private int _OrderLocationID = 0;

            public int OrderLocationID
            {
                get
                {
                    return _OrderLocationID;
                }
            }

            public object SetOrderLocationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderLocationID", value);
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

            private int _deliveryAddressID = 0;

            public int DeliveryAddressID
            {
                get
                {
                    return _deliveryAddressID;
                }
            }

            public object SetDeliveryAddressID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_deliveryAddressID", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}