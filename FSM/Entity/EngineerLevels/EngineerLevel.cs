// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerLevels.EngineerLevel
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerLevels
{
    public class EngineerLevel
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _EngineerLevelID;
        private int _LevelID;
        private int _EngineerID;

        public EngineerLevel()
        {
            this._exists = false;
            this._deleted = false;
            this._EngineerLevelID = 0;
            this._LevelID = 0;
            this._EngineerID = 0;
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

        public int EngineerLevelID
        {
            get
            {
                return this._EngineerLevelID;
            }
        }

        public object SetEngineerLevelID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerLevelID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int LevelID
        {
            get
            {
                return this._LevelID;
            }
        }

        public object SetLevelID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LevelID", RuntimeHelpers.GetObjectValue(value));
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
    }
}