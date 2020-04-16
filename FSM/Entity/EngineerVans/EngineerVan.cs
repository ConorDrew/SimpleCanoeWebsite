// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVans.EngineerVan
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVans
{
    public class EngineerVan
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _EngineerVanID;
        private int _EngineerID;
        private int _VanID;
        private DateTime _StartDateTime;
        private DateTime _EndDateTime;

        public EngineerVan()
        {
            this._exists = false;
            this._deleted = false;
            this._EngineerVanID = 0;
            this._EngineerID = 0;
            this._VanID = 0;
            this._StartDateTime = DateTime.MinValue;
            this._EndDateTime = DateTime.MinValue;
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

        public int EngineerVanID
        {
            get
            {
                return this._EngineerVanID;
            }
        }

        public object SetEngineerVanID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerVanID", RuntimeHelpers.GetObjectValue(value));
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
    }
}