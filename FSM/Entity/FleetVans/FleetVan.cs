// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVan
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
    public class FleetVan
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _VanID;
        private string _Registration;
        private int _VanTypeID;
        private int _Mileage;
        private int _AverageMileage;
        private string _department;
        private bool _Returned;
        private string _Notes;
        private string _TyreSize;

        public FleetVan()
        {
            this._exists = false;
            this._deleted = false;
            this._VanID = 0;
            this._Registration = string.Empty;
            this._VanTypeID = 0;
            this._Mileage = 0;
            this._AverageMileage = 0;
            this._department = string.Empty;
            this._Returned = false;
            this._Notes = string.Empty;
            this._TyreSize = string.Empty;
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

        public string Registration
        {
            get
            {
                return this._Registration;
            }
        }

        public object SetRegistration
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Registration", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VanTypeID
        {
            get
            {
                return this._VanTypeID;
            }
        }

        public object SetVanTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VanTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Mileage
        {
            get
            {
                return this._Mileage;
            }
        }

        public object SetMileage
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Mileage", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AverageMileage
        {
            get
            {
                return this._AverageMileage;
            }
        }

        public object SetAverageMileage
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AverageMileage", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Department
        {
            get
            {
                return this._department;
            }
        }

        public object SetDepartment
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_department", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool Returned
        {
            get
            {
                return this._Returned;
            }
        }

        public object SetReturned
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Returned", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Notes
        {
            get
            {
                return this._Notes;
            }
        }

        public object SetNotes
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Notes", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string TyreSize
        {
            get
            {
                return this._TyreSize;
            }
        }

        public object SetTyreSize
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TyreSize", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}