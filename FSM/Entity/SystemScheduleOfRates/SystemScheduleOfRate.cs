// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SystemScheduleOfRates.SystemScheduleOfRate
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.SystemScheduleOfRates
{
    public class SystemScheduleOfRate
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _SystemScheduleOfRateID;
        private int _ScheduleOfRatesCategoryID;
        private string _Code;
        private string _Description;
        private double _Price;
        private bool _AllowDeleted;
        private int _TimeInMins;
        private int _jobTypeID;

        public SystemScheduleOfRate()
        {
            this._exists = false;
            this._deleted = false;
            this._SystemScheduleOfRateID = 0;
            this._ScheduleOfRatesCategoryID = 0;
            this._Code = string.Empty;
            this._Description = string.Empty;
            this._Price = 0.0;
            this._AllowDeleted = true;
            this._TimeInMins = 0;
            this._jobTypeID = 0;
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

        public int SystemScheduleOfRateID
        {
            get
            {
                return this._SystemScheduleOfRateID;
            }
        }

        public object SetSystemScheduleOfRateID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SystemScheduleOfRateID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ScheduleOfRatesCategoryID
        {
            get
            {
                return this._ScheduleOfRatesCategoryID;
            }
        }

        public object SetScheduleOfRatesCategoryID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ScheduleOfRatesCategoryID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Code
        {
            get
            {
                return this._Code;
            }
        }

        public object SetCode
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Code", RuntimeHelpers.GetObjectValue(value));
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

        public double Price
        {
            get
            {
                return this._Price;
            }
        }

        public object SetPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Price", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool AllowDeleted
        {
            get
            {
                return this._AllowDeleted;
            }
        }

        public object SetAllowDeleted
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AllowDeleted", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int TimeInMins
        {
            get
            {
                return this._TimeInMins;
            }
        }

        public object SetTimeInMins
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TimeInMins", RuntimeHelpers.GetObjectValue(value));
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
    }
}