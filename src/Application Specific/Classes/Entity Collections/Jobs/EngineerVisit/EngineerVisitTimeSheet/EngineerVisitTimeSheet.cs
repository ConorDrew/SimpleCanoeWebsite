using System;
using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitTimeSheets
    {
        public class EngineerVisitTimeSheet
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitTimeSheet()
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

            private int _EngineerVisitTimeSheetID = 0;

            public int EngineerVisitTimeSheetID
            {
                get
                {
                    return _EngineerVisitTimeSheetID;
                }
            }

            public object SetEngineerVisitTimeSheetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitTimeSheetID", value);
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


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}