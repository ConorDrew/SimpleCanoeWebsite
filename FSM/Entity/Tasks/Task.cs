// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Tasks.Task
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Tasks
{
    public class Task
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _TaskID;
        private int _AreaID;
        private string _Description;
        private int _OrderNumber;

        public Task()
        {
            this._exists = false;
            this._deleted = false;
            this._TaskID = 0;
            this._AreaID = 0;
            this._Description = string.Empty;
            this._OrderNumber = 0;
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

        public int TaskID
        {
            get
            {
                return this._TaskID;
            }
        }

        public object SetTaskID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TaskID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AreaID
        {
            get
            {
                return this._AreaID;
            }
        }

        public object SetAreaID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AreaID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
        }

        public object SetDescription
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Description", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OrderNumber
        {
            get
            {
                return this._OrderNumber;
            }
        }

        public object SetOrderNumber
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderNumber", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}