using System;
using System.Collections;
using System.Reflection;

namespace FSM.Entity
{
    namespace Authority
    {
        public class Authority
        {
            private DataTypeValidator _dataTypeValidator;

            public Authority()
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

            public DataTypeValidator DTValIdator
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

            private int _authorityId = 0;

            public int AuthorityId
            {
                get
                {
                    return _authorityId;
                }
            }

            public object SetAuthorityId
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_authorityId", value);
                }
            }

            private string _notes = string.Empty;

            public string Notes
            {
                get
                {
                    return _notes;
                }
            }

            public object SetNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_notes", value);
                }
            }

            private DateTime _dateAdded = default;

            public DateTime DateAdded
            {
                get
                {
                    return _dateAdded;
                }

                set
                {
                    _dateAdded = value;
                }
            }

            private int _addedById = 0;

            public int AddedById
            {
                get
                {
                    return _addedById;
                }
            }

            public object SetAddedById
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_addedById", value);
                }
            }

            private DateTime _lastChanged = default;

            public DateTime LastChanged
            {
                get
                {
                    return _lastChanged;
                }

                set
                {
                    _lastChanged = value;
                }
            }

            private int _lastChangedById = 0;

            public int LastChangedById
            {
                get
                {
                    return _lastChangedById;
                }
            }

            public object SetLastChangedById
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_lastChangedById", value);
                }
            }

            public string GetChanges(Authority oldAuthority)
            {
                string changes = string.Empty;
                try
                {
                    var oType = oldAuthority.GetType();
                    foreach (PropertyInfo oProperty in oType.GetProperties())
                    {
                        var oOldValue = oProperty.GetValue(oldAuthority);
                        var oNewValue = oProperty.GetValue(this);
                        if (!Equals(oOldValue, oNewValue))
                        {
                            string sOldValue = oOldValue is null ? "null" : oOldValue.ToString();
                            string sNewValue = oNewValue is null ? "null" : oNewValue.ToString();
                            changes += "Property " + oProperty.Name + " was: " + sOldValue + "; is: " + sNewValue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    changes += ex.Message;
                }

                return changes;
            }
        }
    }
}