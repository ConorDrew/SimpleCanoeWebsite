using System.Collections;

namespace FSM.Entity
{
    namespace CustomerScheduleOfRates
    {
        public class CustomerScheduleOfRate
        {
            private DataTypeValidator _dataTypeValidator;

            public CustomerScheduleOfRate()
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

            
            

            private int _CustomerScheduleOfRateID = 0;

            public int CustomerScheduleOfRateID
            {
                get
                {
                    return _CustomerScheduleOfRateID;
                }
            }

            public object SetCustomerScheduleOfRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerScheduleOfRateID", value);
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

            private int _ScheduleOfRatesCategoryID = 0;

            public int ScheduleOfRatesCategoryID
            {
                get
                {
                    return _ScheduleOfRatesCategoryID;
                }
            }

            public object SetScheduleOfRatesCategoryID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ScheduleOfRatesCategoryID", value);
                }
            }

            private string _Code = string.Empty;

            public string Code
            {
                get
                {
                    return _Code;
                }
            }

            public object SetCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Code", value);
                }
            }

            private string _Description = string.Empty;

            public string Description
            {
                get
                {
                    return _Description;
                }
            }

            public object SetDescription
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Description", value);
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

            private bool _AllowDeleted = true;

            public bool AllowDeleted
            {
                get
                {
                    return _AllowDeleted;
                }
            }

            public object SetAllowDeleted
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AllowDeleted", value);
                }
            }

            private int _TimeInMins = 0;

            public int TimeInMins
            {
                get
                {
                    return _TimeInMins;
                }
            }

            public object SetTimeInMins
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TimeInMins", value);
                }
            }

            
        }
    }
}