using System.Collections;

namespace FSM.Entity
{
    namespace Locationss
    {
        public class Locations
        {
            private DataTypeValidator _dataTypeValidator;

            public Locations()
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

            private int _LocationID = 0;

            public int LocationID
            {
                get
                {
                    return _LocationID;
                }
            }

            public object SetLocationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LocationID", value);
                }
            }

            private int _VanID = 0;

            public int VanID
            {
                get
                {
                    return _VanID;
                }
            }

            public object SetVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VanID", value);
                }
            }

            private int _WarehouseID = 0;

            public int WarehouseID
            {
                get
                {
                    return _WarehouseID;
                }
            }

            public object SetWarehouseID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WarehouseID", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}