// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanEngineer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
    public class FleetVanEngineer
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _vanEngineerID;
        private int _vanID;
        private int _engineerID;
        private DateTime _startDate;
        private DateTime _endDate;

        public FleetVanEngineer()
        {
            this._exists = false;
            this._deleted = false;
            this._vanEngineerID = 0;
            this._vanID = 0;
            this._engineerID = 0;
            this._startDate = DateTime.MinValue;
            this._endDate = DateTime.MinValue;
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

        public int VanEngineerID
        {
            get
            {
                return this._vanEngineerID;
            }
        }

        public object SetVanEngineerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_vanEngineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VanID
        {
            get
            {
                return this._vanID;
            }
        }

        public object SetVanID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_vanID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerID
        {
            get
            {
                return this._engineerID;
            }
        }

        public object SetEngineerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_engineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                this._startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
            }
        }
    }
}