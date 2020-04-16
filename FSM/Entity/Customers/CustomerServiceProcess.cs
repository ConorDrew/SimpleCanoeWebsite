// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Customers.CustomerServiceProcess
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Customers
{
    public class CustomerServiceProcess
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _CustomerServiceProcessID;
        private int _CustomerID;
        private int _Letter1;
        private int _Letter2;
        private int _Letter3;
        private int _Appointment1;
        private int _Appointment2;
        private int _Appointment3;
        private DateTime _DateAdded;
        private int _AddedBy;
        private byte[] _template1;
        private byte[] _template2;
        private byte[] _template3;
        private byte[] _patchCheckTemplate;

        public CustomerServiceProcess()
        {
            this._exists = false;
            this._deleted = false;
            this._CustomerServiceProcessID = 0;
            this._CustomerID = 0;
            this._Letter1 = 0;
            this._Letter2 = 0;
            this._Letter3 = 0;
            this._Appointment1 = 0;
            this._Appointment2 = 0;
            this._Appointment3 = 0;
            this._DateAdded = DateTime.MinValue;
            this._AddedBy = 0;
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

        public int CustomerServiceProcessID
        {
            get
            {
                return this._CustomerServiceProcessID;
            }
        }

        public object SetCustomerServiceProcessID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerServiceProcessID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int CustomerID
        {
            get
            {
                return this._CustomerID;
            }
        }

        public object SetCustomerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Letter1
        {
            get
            {
                return this._Letter1;
            }
        }

        public object SetLetter1
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Letter1", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Letter2
        {
            get
            {
                return this._Letter2;
            }
        }

        public object SetLetter2
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Letter2", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Letter3
        {
            get
            {
                return this._Letter3;
            }
        }

        public object SetLetter3
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Letter3", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Appointment1
        {
            get
            {
                return this._Appointment1;
            }
        }

        public object SetAppointment1
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Appointment1", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Appointment2
        {
            get
            {
                return this._Appointment2;
            }
        }

        public object SetAppointment2
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Appointment2", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Appointment3
        {
            get
            {
                return this._Appointment3;
            }
        }

        public object SetAppointment3
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Appointment3", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime DateAdded
        {
            get
            {
                return this._DateAdded;
            }
            set
            {
                this._DateAdded = value;
            }
        }

        public int AddedBy
        {
            get
            {
                return this._AddedBy;
            }
        }

        public object SetAddedBy
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AddedBy", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public byte[] Template1
        {
            get
            {
                return this._template1;
            }
            set
            {
                this._template1 = value;
            }
        }

        public byte[] Template2
        {
            get
            {
                return this._template2;
            }
            set
            {
                this._template2 = value;
            }
        }

        public byte[] Template3
        {
            get
            {
                return this._template3;
            }
            set
            {
                this._template3 = value;
            }
        }

        public byte[] PatchCheckTemplate
        {
            get
            {
                return this._patchCheckTemplate;
            }
            set
            {
                this._patchCheckTemplate = value;
            }
        }
    }
}