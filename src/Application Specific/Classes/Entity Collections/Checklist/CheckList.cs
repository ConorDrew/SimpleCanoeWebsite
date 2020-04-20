using System;
using System.Collections;

namespace FSM.Entity
{
    namespace CheckLists
    {
        public class CheckList
        {
            private DataTypeValidator _dataTypeValidator;

            public CheckList()
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

            private int _CheckListID = 0;

            public int CheckListID
            {
                get
                {
                    return _CheckListID;
                }
            }

            public object SetCheckListID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CheckListID", value);
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

            private int _SectionID = 0;

            public int SectionID
            {
                get
                {
                    return _SectionID;
                }
            }

            public object SetSectionID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SectionID", value);
                }
            }

            private DateTime _AddedOn = DateTime.MinValue;

            public DateTime AddedOn
            {
                get
                {
                    return _AddedOn;
                }

                set
                {
                    _AddedOn = value;
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}