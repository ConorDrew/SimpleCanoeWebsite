using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitOrders
    {
        public class EngineerVisitOrder
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitOrder()
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

            private int _EngineerVisitOrderID = 0;

            public int EngineerVisitOrderID
            {
                get
                {
                    return _EngineerVisitOrderID;
                }
            }

            public object SetEngineerVisitOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitOrderID", value);
                }
            }

            private int _OrderID = 0;

            public int OrderID
            {
                get
                {
                    return _OrderID;
                }
            }

            public object SetOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderID", value);
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