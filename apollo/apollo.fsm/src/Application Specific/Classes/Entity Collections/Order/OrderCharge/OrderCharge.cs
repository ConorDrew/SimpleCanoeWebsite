using System.Collections;

namespace FSM.Entity
{
    namespace OrderCharges
    {
        public class OrderCharge
        {
            private DataTypeValidator _dataTypeValidator;

            public OrderCharge()
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

            
            

            private int _OrderChargeID = 0;

            public int OrderChargeID
            {
                get
                {
                    return _OrderChargeID;
                }
            }

            public object SetOrderChargeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderChargeID", value);
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

            private int _OrderChargeTypeID = 0;

            public int OrderChargeTypeID
            {
                get
                {
                    return _OrderChargeTypeID;
                }
            }

            public object SetOrderChargeTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderChargeTypeID", value);
                }
            }

            private double _Amount = 0;

            public double Amount
            {
                get
                {
                    return _Amount;
                }
            }

            public object SetAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Amount", value);
                }
            }

            private string _Reference = string.Empty;

            public string Reference
            {
                get
                {
                    return _Reference;
                }
            }

            public object SetReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Reference", value);
                }
            }



            
        }
    }
}