// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Locationss.Locations
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Locationss
{
    public class Locations
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _LocationID;
        private int _VanID;
        private int _WarehouseID;

        public Locations()
        {
            this._exists = false;
            this._deleted = false;
            this._LocationID = 0;
            this._VanID = 0;
            this._WarehouseID = 0;
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

        public int LocationID
        {
            get
            {
                return this._LocationID;
            }
        }

        public object SetLocationID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LocationID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VanID
        {
            get
            {
                return this._VanID;
            }
        }

        public object SetVanID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VanID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int WarehouseID
        {
            get
            {
                return this._WarehouseID;
            }
        }

        public object SetWarehouseID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_WarehouseID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}