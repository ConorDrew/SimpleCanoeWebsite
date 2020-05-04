using System;
using System.Collections;

namespace FSM.Entity.UserAbsence
{
    public class UserAbsence
    {
        private DataTypeValidator _dataTypeValidator;

        public UserAbsence()
        {
            _dataTypeValidator = new DataTypeValidator();
        }

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

        private int _UserAbsenceID = 0;

        public int UserAbsenceID
        {
            get
            {
                return _UserAbsenceID;
            }
        }

        public object SetUserAbsenceID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_UserAbsenceID", value);
            }
        }

        private string _UserID = string.Empty;

        public string UserID
        {
            get
            {
                return _UserID;
            }
        }

        public object SetUserID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_UserID", value);
            }
        }

        private int _AbsenceTypeID = 0;

        public int AbsenceTypeID
        {
            get
            {
                return _AbsenceTypeID;
            }
        }

        public object SetAbsenceTypeID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_AbsenceTypeID", value);
            }
        }

        private DateTime _DateFrom = default;

        public DateTime DateFrom
        {
            get
            {
                return _DateFrom;
            }

            set
            {
                _DateFrom = value;
            }
        }

        private DateTime _DateTo = default;

        public DateTime DateTo
        {
            get
            {
                return _DateTo;
            }

            set
            {
                _DateTo = value;
            }
        }

        private string _Comments = string.Empty;

        public string Comments
        {
            get
            {
                return _Comments;
            }
        }

        public object SetComments
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Comments", value);
            }
        }
    }
}