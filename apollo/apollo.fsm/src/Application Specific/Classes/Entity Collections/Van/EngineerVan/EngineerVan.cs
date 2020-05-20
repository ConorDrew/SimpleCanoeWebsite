using System;
using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVans
    {
        public class EngineerVan
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVan()
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

            
            

            private int _EngineerVanID = 0;

            public int EngineerVanID
            {
                get
                {
                    return _EngineerVanID;
                }
            }

            public object SetEngineerVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVanID", value);
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



            
        }
    }
}