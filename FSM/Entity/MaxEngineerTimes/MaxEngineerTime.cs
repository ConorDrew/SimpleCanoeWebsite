// Decompiled with JetBrains decompiler
// Type: FSM.Entity.MaxEngineerTimes.MaxEngineerTime
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.MaxEngineerTimes
{
    public class MaxEngineerTime
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _MaxEngineerTimeID;
        private int _EngineerID;
        private int _MondayValue;
        private int _TuesdayValue;
        private int _WednesdayValue;
        private int _ThursdayValue;
        private int _FridayValue;
        private int _SaturdayValue;
        private int _SundayValue;

        public MaxEngineerTime()
        {
            this._exists = false;
            this._deleted = false;
            this._MaxEngineerTimeID = 0;
            this._EngineerID = 0;
            this._MondayValue = 0;
            this._TuesdayValue = 0;
            this._WednesdayValue = 0;
            this._ThursdayValue = 0;
            this._FridayValue = 0;
            this._SaturdayValue = 0;
            this._SundayValue = 0;
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

        public int MaxEngineerTimeID
        {
            get
            {
                return this._MaxEngineerTimeID;
            }
        }

        public object SetMaxEngineerTimeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MaxEngineerTimeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerID
        {
            get
            {
                return this._EngineerID;
            }
        }

        public object SetEngineerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int MondayValue
        {
            get
            {
                return this._MondayValue;
            }
        }

        public object SetMondayValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MondayValue", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int TuesdayValue
        {
            get
            {
                return this._TuesdayValue;
            }
        }

        public object SetTuesdayValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TuesdayValue", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int WednesdayValue
        {
            get
            {
                return this._WednesdayValue;
            }
        }

        public object SetWednesdayValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_WednesdayValue", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ThursdayValue
        {
            get
            {
                return this._ThursdayValue;
            }
        }

        public object SetThursdayValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ThursdayValue", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int FridayValue
        {
            get
            {
                return this._FridayValue;
            }
        }

        public object SetFridayValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FridayValue", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SaturdayValue
        {
            get
            {
                return this._SaturdayValue;
            }
        }

        public object SetSaturdayValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SaturdayValue", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SundayValue
        {
            get
            {
                return this._SundayValue;
            }
        }

        public object SetSundayValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SundayValue", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}