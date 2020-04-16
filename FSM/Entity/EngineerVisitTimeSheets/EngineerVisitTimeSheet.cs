// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitTimeSheets.EngineerVisitTimeSheet
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitTimeSheets
{
    public class EngineerVisitTimeSheet
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _EngineerVisitTimeSheetID;
        private int _EngineerVisitID;
        private DateTime _StartDateTime;
        private DateTime _EndDateTime;
        private string _Comments;
        private int _TimeSheetTypeID;

        public EngineerVisitTimeSheet()
        {
            this._exists = false;
            this._deleted = false;
            this._EngineerVisitTimeSheetID = 0;
            this._EngineerVisitID = 0;
            this._StartDateTime = DateTime.MinValue;
            this._EndDateTime = DateTime.MinValue;
            this._Comments = string.Empty;
            this._TimeSheetTypeID = 0;
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

        public int EngineerVisitTimeSheetID
        {
            get
            {
                return this._EngineerVisitTimeSheetID;
            }
        }

        public object SetEngineerVisitTimeSheetID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerVisitTimeSheetID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerVisitID
        {
            get
            {
                return this._EngineerVisitID;
            }
        }

        public object SetEngineerVisitID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerVisitID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime StartDateTime
        {
            get
            {
                return this._StartDateTime;
            }
            set
            {
                this._StartDateTime = value;
            }
        }

        public DateTime EndDateTime
        {
            get
            {
                return this._EndDateTime;
            }
            set
            {
                this._EndDateTime = value;
            }
        }

        public string Comments
        {
            get
            {
                return this._Comments;
            }
        }

        public object SetComments
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Comments", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int TimeSheetTypeID
        {
            get
            {
                return this._TimeSheetTypeID;
            }
        }

        public object SetTimeSheetTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TimeSheetTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}