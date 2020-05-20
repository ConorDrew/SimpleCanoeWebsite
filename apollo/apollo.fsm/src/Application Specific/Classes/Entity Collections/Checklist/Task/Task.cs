using System.Collections;

namespace FSM.Entity
{
    namespace Tasks
    {
        public class Task
        {
            private DataTypeValidator _dataTypeValidator;

            public Task()
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

            
            

            private int _TaskID = 0;

            public int TaskID
            {
                get
                {
                    return _TaskID;
                }
            }

            public object SetTaskID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TaskID", value);
                }
            }

            private int _AreaID = 0;

            public int AreaID
            {
                get
                {
                    return _AreaID;
                }
            }

            public object SetAreaID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AreaID", value);
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

            private int _OrderNumber = 0;

            public int OrderNumber
            {
                get
                {
                    return _OrderNumber;
                }
            }

            public object SetOrderNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OrderNumber", value);
                }
            }



            
        }
    }
}