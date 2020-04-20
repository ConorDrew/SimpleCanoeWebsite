using System.Collections;

namespace FSM.Entity
{
    namespace SystemScheduleOfRates
    {
        public class SystemScheduleOfRate
        {
            private DataTypeValidator _dataTypeValidator;

            public SystemScheduleOfRate()
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

            private int _SystemScheduleOfRateID = 0;

            public int SystemScheduleOfRateID
            {
                get
                {
                    return _SystemScheduleOfRateID;
                }
            }

            public object SetSystemScheduleOfRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SystemScheduleOfRateID", value);
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

            private int _jobTypeID = 0;

            public int JobTypeID
            {
                get
                {
                    return _jobTypeID;
                }
            }

            public object SetJobTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_jobTypeID", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}