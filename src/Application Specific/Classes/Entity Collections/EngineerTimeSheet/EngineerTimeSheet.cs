using System;
using System.Collections;

namespace FSM.Entity
{
    namespace EngineerTimeSheets
    {
        public class EngineerTimeSheet
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerTimeSheet()
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

            private int _EngineerTimeSheetID = 0;

            public int EngineerTimeSheetID
            {
                get
                {
                    return _EngineerTimeSheetID;
                }
            }

            public object SetEngineerTimeSheetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerTimeSheetID", value);
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

            private DateTime _StartDateTime = default;

            public DateTime StartDateTime
            {
                get
                {
                    return _StartDateTime;
                }

                set
                {
                    _StartDateTime = value;
                }
            }

            private DateTime _EndDateTime = default;

            public DateTime EndDateTime
            {
                get
                {
                    return _EndDateTime;
                }

                set
                {
                    _EndDateTime = value;
                }
            }

            private string _Comments = string.Empty;

            public string Comments
            {
                get
                {
                    return _Comments;
                }
            }

            public object SetComments
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Comments", value);
                }
            }

            private int _TimeSheetTypeID = 0;

            public int TimeSheetTypeID
            {
                get
                {
                    return _TimeSheetTypeID;
                }
            }

            public object SetTimeSheetTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TimeSheetTypeID", value);
                }
            }

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }
        }
    }
}