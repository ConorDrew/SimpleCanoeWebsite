using System.Collections;

namespace FSM.Entity
{
    namespace UserLevels
    {
        public class UserLevel
        {
            private DataTypeValidator _dataTypeValidator;

            public UserLevel()
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
            private int _UserLevelID = 0;

            public int UserLevelID
            {
                get
                {
                    return _UserLevelID;
                }
            }

            public object SetUserLevelID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UserLevelID", value);
                }
            }

            private int _LevelID = 0;

            public int LevelID
            {
                get
                {
                    return _LevelID;
                }
            }

            public object SetLevelID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LevelID", value);
                }
            }

            private int _UserID = 0;

            public int UserID
            {
                get
                {
                    return _UserID;
                }
            }

            public object SetUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UserID", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}