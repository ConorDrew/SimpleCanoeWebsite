using System.Collections;

namespace FSM.Entity
{
    namespace MaxEngineerTimes
    {
        public class MaxEngineerTime
        {
            private DataTypeValidator _dataTypeValidator;

            public MaxEngineerTime()
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

            
            

            private int _MaxEngineerTimeID = 0;

            public int MaxEngineerTimeID
            {
                get
                {
                    return _MaxEngineerTimeID;
                }
            }

            public object SetMaxEngineerTimeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MaxEngineerTimeID", value);
                }
            }

            private int _EngineerID = 0;

            public int EngineerID
            {
                get
                {
                    return _EngineerID;
                }
            }

            public object SetEngineerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerID", value);
                }
            }

            private int _MondayValue = 0;

            public int MondayValue
            {
                get
                {
                    return _MondayValue;
                }
            }

            public object SetMondayValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MondayValue", value);
                }
            }

            private int _TuesdayValue = 0;

            public int TuesdayValue
            {
                get
                {
                    return _TuesdayValue;
                }
            }

            public object SetTuesdayValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TuesdayValue", value);
                }
            }

            private int _WednesdayValue = 0;

            public int WednesdayValue
            {
                get
                {
                    return _WednesdayValue;
                }
            }

            public object SetWednesdayValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WednesdayValue", value);
                }
            }

            private int _ThursdayValue = 0;

            public int ThursdayValue
            {
                get
                {
                    return _ThursdayValue;
                }
            }

            public object SetThursdayValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ThursdayValue", value);
                }
            }

            private int _FridayValue = 0;

            public int FridayValue
            {
                get
                {
                    return _FridayValue;
                }
            }

            public object SetFridayValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FridayValue", value);
                }
            }

            private int _SaturdayValue = 0;

            public int SaturdayValue
            {
                get
                {
                    return _SaturdayValue;
                }
            }

            public object SetSaturdayValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SaturdayValue", value);
                }
            }

            private int _SundayValue = 0;

            public int SundayValue
            {
                get
                {
                    return _SundayValue;
                }
            }

            public object SetSundayValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SundayValue", value);
                }
            }



            
        }
    }
}