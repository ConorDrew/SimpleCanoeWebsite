using System.Collections;

namespace FSM.Entity
{
    namespace TabletOrders
    {
        public class TabletOrderPart
        {
            private DataTypeValidator _dataTypeValidator;

            public TabletOrderPart()
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

            private int _OrderPartID = 0;

            public int OrderPartID
            {
                get
                {
                    return _OrderPartID;
                }
            }

            public object SetOrderPartID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderPartID", value);
                }
            }

            private int _OrderID;

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

            private int _EngineerID;

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

            private int _Quantity;

            public string Quantity
            {
                get
                {
                    return _Quantity.ToString();
                }
            }

            public object SetQuantity
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Quantity", value);
                }
            }

            private int _PartSupplierID;

            public string PartSupplierID
            {
                get
                {
                    return _PartSupplierID.ToString();
                }
            }

            public object SetPartSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartSupplierID", value);
                }
            }

            private string _Status = string.Empty;

            public string Status
            {
                get
                {
                    return _Status;
                }
            }

            public object SetStatus
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Status", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}