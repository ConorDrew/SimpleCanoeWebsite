using System.Collections;

namespace FSM.Entity
{
    namespace SiteOrders
    {
        public class SiteOrder
        {
            private DataTypeValidator _dataTypeValidator;

            public SiteOrder()
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

            
            

            private int _SiteOrderID = 0;

            public int SiteOrderID
            {
                get
                {
                    return _SiteOrderID;
                }
            }

            public object SetSiteOrderID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteOrderID", value);
                }
            }

            private int _SiteID = 0;

            public int SiteID
            {
                get
                {
                    return _SiteID;
                }
            }

            public object SetSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteID", value);
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



            
        }
    }
}