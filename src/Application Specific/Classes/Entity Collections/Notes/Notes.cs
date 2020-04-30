using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Notes
    {
        public class Notes
        {
            private DataTypeValidator _dataTypeValidator;

            public Notes()
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

            
            

            private int _NoteID = 0;

            public int NoteID
            {
                get
                {
                    return _NoteID;
                }
            }

            public object SetNoteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NoteID", value);
                }
            }

            private int _CategoryID = 0;

            public int CategoryID
            {
                get
                {
                    return _CategoryID;
                }
            }

            public object SetCategoryID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CategoryID", value);
                }
            }

            private DateTime _NoteDate = default;

            public DateTime NoteDate
            {
                get
                {
                    return _NoteDate;
                }

                set
                {
                    _NoteDate = value;
                }
            }

            private string _Note = string.Empty;

            public string Note
            {
                get
                {
                    return _Note;
                }
            }

            public object SetNote
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Note", value);
                }
            }

            private DateTime _DateCreated = default;

            public DateTime DateCreated
            {
                get
                {
                    return _DateCreated;
                }

                set
                {
                    _DateCreated = value;
                }
            }

            private int _UserIDBy = 0;

            public int UserIDBy
            {
                get
                {
                    return _UserIDBy;
                }
            }

            public object SetUserIDBy
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UserIDBy", value);
                }
            }

            private int _contactID = 0;

            public int ContactID
            {
                get
                {
                    return _contactID;
                }
            }

            public object SetContactID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_contactID", value);
                }
            }

            private DateTime _DateTimeOfReminder = default;

            public DateTime DateTimeOfReminder
            {
                get
                {
                    return _DateTimeOfReminder;
                }

                set
                {
                    _DateTimeOfReminder = value;
                }
            }

            private int _ReminderStatusID = Conversions.ToInteger(Sys.Enums.NoteReminderStatus.Cancelled);

            public int ReminderStatusID
            {
                get
                {
                    return _ReminderStatusID;
                }
            }

            public object SetReminderStatusID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReminderStatusID", value);
                }
            }

            private int _UserIDFor = 0;

            public int UserIDFor
            {
                get
                {
                    return _UserIDFor;
                }
            }

            public object SetUserIDFor
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UserIDFor", value);
                }
            }
            
        }
    }
}