using System.Collections;

namespace FSM.Entity
{
    namespace EngineerLevels
    {
        public class EngineerLevel
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerLevel()
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

            private int _EngineerLevelID = 0;

            public int EngineerLevelID
            {
                get
                {
                    return _EngineerLevelID;
                }
            }

            public object SetEngineerLevelID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerLevelID", value);
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



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}