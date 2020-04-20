using System;
using System.Collections;

namespace FSM.Entity
{
    namespace Appointments
    {
        public class Appointment
        {
            private DataTypeValidator _dataTypeValidator;

            public Appointment()
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
            private int _AppointmentID = 0;

            public int AppointmentID
            {
                get
                {
                    return _AppointmentID;
                }
            }

            public object SetAppointmentID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AppointmentID", value);
                }
            }

            private string _Name;

            public string Name
            {
                get
                {
                    return _Name;
                }
            }

            public object SetName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Name", value);
                }
            }

            private TimeSpan _StartTime;

            public TimeSpan StartTime
            {
                get
                {
                    return _StartTime;
                }
            }

            public object SetStartTime
            {
                set
                {
                    _StartTime = (TimeSpan)value;
                }
            }

            private TimeSpan _EndTime;

            public TimeSpan EndTime
            {
                get
                {
                    return _EndTime;
                }
            }

            public object SetEndTime
            {
                set
                {
                    _EndTime = (TimeSpan)value;
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}