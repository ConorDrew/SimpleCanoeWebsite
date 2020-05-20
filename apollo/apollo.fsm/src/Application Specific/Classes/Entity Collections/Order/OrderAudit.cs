using System.Collections;

namespace FSM.Entity
{
    public class OrderAudit
    {
        private FSM.DataTypeValidator _dataTypeValidator;

        public OrderAudit()
        {
            _dataTypeValidator = new FSM.DataTypeValidator();
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

        public FSM.DataTypeValidator DTValidator
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

        private int _orderAuditID = 0;

        public int OrderAuditID
        {
            get
            {
                return _orderAuditID;
            }
        }

        public object SetOrderAuditID
        {
            set
            {
                _dataTypeValidator.SetValue(this, nameof(_orderAuditID), value);
            }
        }

        private int _orderID = 0;

        public int OrderID
        {
            get
            {
                return _orderID;
            }
        }

        public object SetOrderID
        {
            set
            {
                _dataTypeValidator.SetValue(this, nameof(_orderID), value);
            }
        }

        private int _reasonID = 0;

        public int ReasonID
        {
            get
            {
                return _reasonID;
            }
        }

        public object SetReason
        {
            set
            {
                _dataTypeValidator.SetValue(this, nameof(_reasonID), value);
            }
        }

        private string _description = null;

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public object SetDescription
        {
            set
            {
                _dataTypeValidator.SetValue(this, nameof(_description), value);
            }
        }

        private int _userID = 0;

        public int UserID
        {
            get
            {
                return _userID;
            }
        }

        public object SetUserID
        {
            set
            {
                _dataTypeValidator.SetValue(this, nameof(_userID), value);
            }
        }
    }
}