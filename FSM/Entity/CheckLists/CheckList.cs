// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CheckLists.CheckList
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CheckLists
{
    public class CheckList
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _CheckListID;
        private int _EngineerVisitID;
        private int _SectionID;
        private DateTime _AddedOn;

        public CheckList()
        {
            this._exists = false;
            this._deleted = false;
            this._CheckListID = 0;
            this._EngineerVisitID = 0;
            this._SectionID = 0;
            this._AddedOn = DateTime.MinValue;
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

        public int CheckListID
        {
            get
            {
                return this._CheckListID;
            }
        }

        public object SetCheckListID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CheckListID", RuntimeHelpers.GetObjectValue(value));
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

        public int SectionID
        {
            get
            {
                return this._SectionID;
            }
        }

        public object SetSectionID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SectionID", RuntimeHelpers.GetObjectValue(value));
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
    }
}