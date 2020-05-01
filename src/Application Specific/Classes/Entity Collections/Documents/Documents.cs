using System;
using System.Collections;

namespace FSM.Entity
{
    namespace Documentss
    {
        public class Documents
        {
            private DataTypeValidator _dataTypeValidator;

            public Documents()
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

            private int _DocumentID = 0;

            public int DocumentID
            {
                get
                {
                    return _DocumentID;
                }
            }

            public object SetDocumentID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DocumentID", value);
                }
            }

            private int _TableEnumID = 0;

            public int TableEnumID
            {
                get
                {
                    return _TableEnumID;
                }
            }

            public object SetTableEnumID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TableEnumID", value);
                }
            }

            private int _RecordID = 0;

            public int RecordID
            {
                get
                {
                    return _RecordID;
                }
            }

            public object SetRecordID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RecordID", value);
                }
            }

            private int _DocumentTypeID = 0;

            public int DocumentTypeID
            {
                get
                {
                    return _DocumentTypeID;
                }
            }

            public object SetDocumentTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DocumentTypeID", value);
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

            private string _Notes = string.Empty;

            public string Notes
            {
                get
                {
                    return _Notes;
                }
            }

            public object SetNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Notes", value);
                }
            }

            private string _Location = string.Empty;

            public string Location
            {
                get
                {
                    return _Location;
                }
            }

            public object SetLocation
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Location", value);
                }
            }

            private DateTime _AddedOn = default;

            public DateTime AddedOn
            {
                get
                {
                    return _AddedOn;
                }

                set
                {
                    _AddedOn = value;
                }
            }

            public object SetAddedByUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AddedByUserID", value);
                }
            }

            private DateTime _LastUpdatedOn = default;

            public DateTime LastUpdatedOn
            {
                get
                {
                    return _LastUpdatedOn;
                }

                set
                {
                    _LastUpdatedOn = value;
                }
            }

            public object SetLastUpdatedByUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LastUpdatedByUserID", value);
                }
            }

            private string _Type = string.Empty;

            public string Type
            {
                get
                {
                    return _Type;
                }

                set
                {
                    _Type = value;
                }
            }

            private string _AddedByUserName = string.Empty;

            public string AddedByUserName
            {
                get
                {
                    return _AddedByUserName;
                }

                set
                {
                    _AddedByUserName = value;
                }
            }

            private string _LastUpdatedByUserName = string.Empty;

            public string LastUpdatedByUserName
            {
                get
                {
                    return _LastUpdatedByUserName;
                }

                set
                {
                    _LastUpdatedByUserName = value;
                }
            }
        }
    }
}