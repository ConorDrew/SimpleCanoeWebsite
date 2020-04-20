using System.Collections;

namespace FSM.Entity
{
    namespace EngineerPostalRegions
    {
        public class EngineerPostalRegion
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerPostalRegion()
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

            private int _EngineerPostalRegionID = 0;

            public int EngineerPostalRegionID
            {
                get
                {
                    return _EngineerPostalRegionID;
                }
            }

            public object SetEngineerPostalRegionID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerPostalRegionID", value);
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

            private int _PostalRegionID = 0;

            public int PostalRegionID
            {
                get
                {
                    return _PostalRegionID;
                }
            }

            public object SetPostalRegionID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PostalRegionID", value);
                }
            }






            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}