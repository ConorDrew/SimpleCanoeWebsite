// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Notes.Notes
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Notes
{
    public class Notes
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _NoteID;
        private int _CategoryID;
        private DateTime _NoteDate;
        private string _Note;
        private DateTime _DateCreated;
        private int _UserIDBy;
        private int _contactID;
        private DateTime _DateTimeOfReminder;
        private int _ReminderStatusID;
        private int _UserIDFor;

        public Notes()
        {
            this._exists = false;
            this._deleted = false;
            this._NoteID = 0;
            this._CategoryID = 0;
            this._NoteDate = DateTime.MinValue;
            this._Note = string.Empty;
            this._DateCreated = DateTime.MinValue;
            this._UserIDBy = 0;
            this._contactID = 0;
            this._DateTimeOfReminder = DateTime.MinValue;
            this._ReminderStatusID = 2;
            this._UserIDFor = 0;
            this._dataTypeValidator = new DataTypeValidator();
        }

        public bool IgnoreExceptionsOnSetMethods
        {
            get
            {
                return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
            }
            set
            {
                this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
            }
        }

        public Hashtable Errors
        {
            get
            {
                return this._dataTypeValidator.Errors;
            }
        }

        public DataTypeValidator DTValidator
        {
            get
            {
                return this._dataTypeValidator;
            }
        }

        public bool Exists
        {
            get
            {
                return this._exists;
            }
            set
            {
                this._exists = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return this._deleted;
            }
        }

        public bool SetDeleted
        {
            set
            {
                this._deleted = value;
            }
        }

        public int NoteID
        {
            get
            {
                return this._NoteID;
            }
        }

        public object SetNoteID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_NoteID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int CategoryID
        {
            get
            {
                return this._CategoryID;
            }
        }

        public object SetCategoryID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CategoryID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime NoteDate
        {
            get
            {
                return this._NoteDate;
            }
            set
            {
                this._NoteDate = value;
            }
        }

        public string Note
        {
            get
            {
                return this._Note;
            }
        }

        public object SetNote
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Note", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return this._DateCreated;
            }
            set
            {
                this._DateCreated = value;
            }
        }

        public int UserIDBy
        {
            get
            {
                return this._UserIDBy;
            }
        }

        public object SetUserIDBy
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_UserIDBy", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ContactID
        {
            get
            {
                return this._contactID;
            }
        }

        public object SetContactID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_contactID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime DateTimeOfReminder
        {
            get
            {
                return this._DateTimeOfReminder;
            }
            set
            {
                this._DateTimeOfReminder = value;
            }
        }

        public int ReminderStatusID
        {
            get
            {
                return this._ReminderStatusID;
            }
        }

        public object SetReminderStatusID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ReminderStatusID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int UserIDFor
        {
            get
            {
                return this._UserIDFor;
            }
        }

        public object SetUserIDFor
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_UserIDFor", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}