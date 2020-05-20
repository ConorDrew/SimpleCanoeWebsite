using System.Collections;

namespace FSM.Entity
{
    namespace PickLists
    {
        public class PickList
        {
            private DataTypeValidator _dataTypeValidator;

            public PickList()
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

            
            
            private int _ManagerID = 0;

            public int ManagerID
            {
                get
                {
                    return _ManagerID;
                }
            }

            public object SetManagerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ManagerID", value);
                }
            }

            private int _EnumTypeID = 0;

            public int EnumTypeID
            {
                get
                {
                    return _EnumTypeID;
                }
            }

            public object SetEnumTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EnumTypeID", value);
                }
            }

            private string _Name = string.Empty;

            public string Name
            {
                get
                {
                    return _Name;
                }
            }

            public object SetName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Name", value);
                }
            }

            private string _Description = string.Empty;

            public string Description
            {
                get
                {
                    return _Description;
                }
            }

            public object SetDescription
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Description", value);
                }
            }

            private double _PercentageRate = 0.0;

            public double PercentageRate
            {
                get
                {
                    return _PercentageRate;
                }
            }

            public object SetPercentageRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PercentageRate", value);
                }
            }

            private bool _Mandatory = false;

            public bool Mandatory
            {
                get
                {
                    return _Mandatory;
                }
            }

            public bool SetMandatory
            {
                set
                {
                    _Mandatory = value;
                }
            }

            
        }
    }
}