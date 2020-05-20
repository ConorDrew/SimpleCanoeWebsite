using System.Collections;

namespace FSM.Entity
{
    public class StockTakeAudit
    {
        private DataTypeValidator _dataTypeValidator;

        public StockTakeAudit()
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

        
        private int _stockTakeAuditID = 0;

        public int StockTakeAuditID
        {
            get
            {
                return _stockTakeAuditID;
            }
        }

        public object SetStockTakeAuditID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_stockTakeAuditID", value);
            }
        }

        private int _partID = 0;

        public int PartID
        {
            get
            {
                return _partID;
            }
        }

        public object SetPartID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_partID", value);
            }
        }

        private int _originalAmount = 0;

        public int OriginalAmount
        {
            get
            {
                return _originalAmount;
            }
        }

        public object SetOriginalAmount
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_originalAmount", value);
            }
        }

        private int _newAmount = 0;

        public int NewAmount
        {
            get
            {
                return _newAmount;
            }
        }

        public object SetNewAmount
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_newAmount", value);
            }
        }

        private int _reasonChangeID = 0;

        public int ReasonChange
        {
            get
            {
                return _reasonChangeID;
            }
        }

        public int SetReasonChange
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_reasonChangeID", value);
            }
        }

        private int _locationID = 0;

        public int LocationID
        {
            get
            {
                return _locationID;
            }
        }

        public object SetLocationID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_locationID", value);
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
                _dataTypeValidator.SetValue(this, "_userID", value);
            }
        }

        
    }
}