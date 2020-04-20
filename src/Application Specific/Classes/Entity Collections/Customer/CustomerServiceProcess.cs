using System;
using System.Collections;

namespace FSM.Entity.Customers
{
    public class CustomerServiceProcess
    {
        private DataTypeValidator _dataTypeValidator;

        public CustomerServiceProcess()
        {
            _dataTypeValidator = new DataTypeValidator();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public bool IgnoreExceptionsOnSetMethods
        {
            get
            {
                return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
            }

            set
            {
                _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
            }
        }

        public Hashtable Errors
        {
            get
            {
                return _dataTypeValidator.Errors;
            }
        }

        public DataTypeValidator DTValidator
        {
            get
            {
                return _dataTypeValidator;
            }
        }

        private bool _exists = false;

        public bool Exists
        {
            get
            {
                return _exists;
            }

            set
            {
                _exists = value;
            }
        }

        private bool _deleted = false;

        public bool Deleted
        {
            get
            {
                return _deleted;
            }
        }

        public bool SetDeleted
        {
            set
            {
                _deleted = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private int _CustomerServiceProcessID = 0;

        public int CustomerServiceProcessID
        {
            get
            {
                return _CustomerServiceProcessID;
            }
        }

        public object SetCustomerServiceProcessID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_CustomerServiceProcessID", value);
            }
        }

        private int _CustomerID = 0;

        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
        }

        public object SetCustomerID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_CustomerID", value);
            }
        }

        private int _Letter1 = 0;

        public int Letter1
        {
            get
            {
                return _Letter1;
            }
        }

        public object SetLetter1
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Letter1", value);
            }
        }

        private int _Letter2 = 0;

        public int Letter2
        {
            get
            {
                return _Letter2;
            }
        }

        public object SetLetter2
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Letter2", value);
            }
        }

        private int _Letter3 = 0;

        public int Letter3
        {
            get
            {
                return _Letter3;
            }
        }

        public object SetLetter3
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Letter3", value);
            }
        }

        private int _Appointment1 = 0;

        public int Appointment1
        {
            get
            {
                return _Appointment1;
            }
        }

        public object SetAppointment1
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Appointment1", value);
            }
        }

        private int _Appointment2 = 0;

        public int Appointment2
        {
            get
            {
                return _Appointment2;
            }
        }

        public object SetAppointment2
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Appointment2", value);
            }
        }

        private int _Appointment3 = 0;

        public int Appointment3
        {
            get
            {
                return _Appointment3;
            }
        }

        public object SetAppointment3
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Appointment3", value);
            }
        }

        private DateTime _DateAdded = default;

        public DateTime DateAdded
        {
            get
            {
                return _DateAdded;
            }

            set
            {
                _DateAdded = value;
            }
        }

        private int _AddedBy = 0;

        public int AddedBy
        {
            get
            {
                return _AddedBy;
            }
        }

        public object SetAddedBy
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_AddedBy", value);
            }
        }

        private byte[] _template1;

        public byte[] Template1
        {
            get
            {
                return _template1;
            }

            set
            {
                _template1 = value;
            }
        }

        private byte[] _template2;

        public byte[] Template2
        {
            get
            {
                return _template2;
            }

            set
            {
                _template2 = value;
            }
        }

        private byte[] _template3;

        public byte[] Template3
        {
            get
            {
                return _template3;
            }

            set
            {
                _template3 = value;
            }
        }

        private byte[] _patchCheckTemplate;

        public byte[] PatchCheckTemplate
        {
            get
            {
                return _patchCheckTemplate;
            }

            set
            {
                _patchCheckTemplate = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}