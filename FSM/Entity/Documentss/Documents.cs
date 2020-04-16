// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Documentss.Documents
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Documentss
{
    public class Documents
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _DocumentID;
        private int _TableEnumID;
        private int _RecordID;
        private int _DocumentTypeID;
        private string _Name;
        private string _Notes;
        private string _Location;
        private DateTime _AddedOn;
        private int _AddedByUserID;
        private DateTime _LastUpdatedOn;
        private int _LastUpdatedByUserID;
        private string _Type;
        private string _AddedByUserName;
        private string _LastUpdatedByUserName;

        public Documents()
        {
            this._exists = false;
            this._deleted = false;
            this._DocumentID = 0;
            this._TableEnumID = 0;
            this._RecordID = 0;
            this._DocumentTypeID = 0;
            this._Name = string.Empty;
            this._Notes = string.Empty;
            this._Location = string.Empty;
            this._AddedOn = DateTime.MinValue;
            this._AddedByUserID = 0;
            this._LastUpdatedOn = DateTime.MinValue;
            this._LastUpdatedByUserID = 0;
            this._Type = string.Empty;
            this._AddedByUserName = string.Empty;
            this._LastUpdatedByUserName = string.Empty;
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

        public int DocumentID
        {
            get
            {
                return this._DocumentID;
            }
        }

        public object SetDocumentID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_DocumentID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int TableEnumID
        {
            get
            {
                return this._TableEnumID;
            }
        }

        public object SetTableEnumID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TableEnumID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int RecordID
        {
            get
            {
                return this._RecordID;
            }
        }

        public object SetRecordID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_RecordID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int DocumentTypeID
        {
            get
            {
                return this._DocumentTypeID;
            }
        }

        public object SetDocumentTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_DocumentTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public object SetName
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Name", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Notes
        {
            get
            {
                return this._Notes;
            }
        }

        public object SetNotes
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Notes", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Location
        {
            get
            {
                return this._Location;
            }
        }

        public object SetLocation
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Location", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime AddedOn
        {
            get
            {
                return this._AddedOn;
            }
            set
            {
                this._AddedOn = value;
            }
        }

        public int AddedByUserID
        {
            get
            {
                return this._AddedByUserID;
            }
        }

        public object SetAddedByUserID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AddedByUserID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime LastUpdatedOn
        {
            get
            {
                return this._LastUpdatedOn;
            }
            set
            {
                this._LastUpdatedOn = value;
            }
        }

        public int LastUpdatedByUserID
        {
            get
            {
                return this._LastUpdatedByUserID;
            }
        }

        public object SetLastUpdatedByUserID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LastUpdatedByUserID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }

        public string AddedByUserName
        {
            get
            {
                return this._AddedByUserName;
            }
            set
            {
                this._AddedByUserName = value;
            }
        }

        public string LastUpdatedByUserName
        {
            get
            {
                return this._LastUpdatedByUserName;
            }
            set
            {
                this._LastUpdatedByUserName = value;
            }
        }
    }
}