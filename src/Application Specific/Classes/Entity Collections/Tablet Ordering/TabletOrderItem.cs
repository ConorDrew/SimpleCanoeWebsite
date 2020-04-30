using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace TabletOrders
    {
        public class TabletOrderItem
        {
            private DataTypeValidator _dataTypeValidator;

            public TabletOrderItem()
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

            
            

            private int _TabletOrderID = 0;

            public int TabletOrderID
            {
                get
                {
                    return _TabletOrderID;
                }
            }

            public object SetTabletOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TabletOrderID", value);
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

            private int _SupplierID;

            public int SupplierID
            {
                get
                {
                    return _SupplierID;
                }
            }

            public object SetSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SupplierID", value);
                }
            }

            private int _SelectedVisitID;

            public string SelectedVisitID
            {
                get
                {
                    return _SelectedVisitID.ToString();
                }
            }

            public object SetSelectedVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SelectedVisitID", value);
                }
            }

            private bool _ForNextVisit;

            public bool ForNextVisit
            {
                get
                {
                    return _ForNextVisit;
                }
            }

            public object SetForNextVisit
            {
                set
                {
                    _ForNextVisit = Conversions.ToBoolean(value);
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

            private DateTime _OrderCreated;

            public DateTime OrderCreated
            {
                get
                {
                    return _OrderCreated;
                }
            }

            public object SetOrderCreated
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderCreated", value);
                }
            }

            private DateTime _LastUpdated;

            public DateTime LastUpdated
            {
                get
                {
                    return _LastUpdated;
                }
            }

            public object SetLastUpdated
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LastUpdated", value);
                }
            }

            
        }
    }
}