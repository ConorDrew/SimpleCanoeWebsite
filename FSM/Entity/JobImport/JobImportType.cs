// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobImport.JobImportType
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobImport
{
    public class JobImportType
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _jobImportTypeId;
        private string _name;
        private int _jobTypeID;
        private string _jobTypeName;
        private int _engineerQualID;
        private int _cycle;

        public JobImportType()
        {
            this._exists = false;
            this._deleted = false;
            this._jobImportTypeId = 0;
            this._name = string.Empty;
            this._jobTypeID = 0;
            this._jobTypeName = string.Empty;
            this._engineerQualID = 0;
            this._cycle = 0;
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

        public int JobImportTypeID
        {
            get
            {
                return this._jobImportTypeId;
            }
        }

        public object SetJobImportTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_jobImportTypeId", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public object SetName
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_name", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int JobTypeID
        {
            get
            {
                return this._jobTypeID;
            }
        }

        public object SetJobTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_jobTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string JobTypeName
        {
            get
            {
                return this._jobTypeName;
            }
        }

        public object SetJobTypeName
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_jobTypeName", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerQualID
        {
            get
            {
                return this._engineerQualID;
            }
        }

        public object SetEngineerQualID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_engineerQualID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Cycle
        {
            get
            {
                return this._cycle;
            }
        }

        public object SetCycle
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_cycle", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}