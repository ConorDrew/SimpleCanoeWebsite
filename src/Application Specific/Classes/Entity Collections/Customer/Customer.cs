using System.Collections;

namespace FSM.Entity.Customers
{
    public class Customer
    {
        private DataTypeValidator _dataTypeValidator;

        public Customer()
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

        private string _Name = string.Empty;

        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public object SetName
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Name", value);
            }
        }

        private int _RegionID = 0;

        public int RegionID
        {
            get
            {
                return _RegionID;
            }
        }

        public object SetRegionID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_RegionID", value);
            }
        }

        private int _CustomerTypeID = 0;

        public int CustomerTypeID
        {
            get
            {
                return _CustomerTypeID;
            }
        }

        public object SetCustomerTypeID
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_CustomerTypeID", value);
            }
        }

        private string _Notes = string.Empty;

        public string Notes
        {
            get
            {
                return _Notes;
            }
        }

        public object SetNotes
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Notes", value);
            }
        }

        private string _AccountNumber = string.Empty;

        public string AccountNumber
        {
            get
            {
                return _AccountNumber;
            }
        }

        public object SetAccountNumber
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_AccountNumber", value);
            }
        }

        private int _Status = 0;

        public int Status
        {
            get
            {
                return _Status;
            }
        }

        public object SetStatus
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Status", value);
            }
        }

        private bool _PoNumReqd = false;

        public bool PoNumReqd
        {
            get
            {
                return _PoNumReqd;
            }
        }

        public object SetPoNumReqd
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_PoNumReqd", value);
            }
        }

        private bool _SuperBook = false;

        public bool SuperBook
        {
            get
            {
                return _SuperBook;
            }
        }

        public object SetSuperBook
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_SuperBook", value);
            }
        }

        private bool _AcceptChargesChanges = true;

        public bool AcceptChargesChanges
        {
            get
            {
                return _AcceptChargesChanges;
            }
        }

        public object SetAcceptChargesChanges
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_AcceptChargesChanges", value);
            }
        }

        private decimal _mainContractorDiscount = 0;

        public decimal MainContractorDiscount
        {
            get
            {
                return _mainContractorDiscount;
            }
        }

        public object SetMainContractorDiscount
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_mainContractorDiscount", value);
            }
        }

        private byte[] _Logo = null;

        public byte[] Logo
        {
            get
            {
                if (_Logo is null)
                {
                }

                return _Logo;
            }

            set
            {
                _Logo = value;
            }
        }

        private bool _JobPriorityMandatory = false;

        public bool JobPriorityMandatory
        {
            get
            {
                return _JobPriorityMandatory;
            }
        }

        public object SetJobPriorityMandatory
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_JobPriorityMandatory", value);
            }
        }

        private string _Nominal = string.Empty;

        public string Nominal
        {
            get
            {
                return _Nominal;
            }
        }

        public object SetNominal
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Nominal", value);
            }
        }

        private string _OverrideDept = string.Empty;

        public string OverrideDept
        {
            get
            {
                return _OverrideDept;
            }
        }

        public object SetOverrideDept
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_OverrideDept", value);
            }
        }

        private int _Terms = 0;

        public int Terms
        {
            get
            {
                return _Terms;
            }
        }

        public object SetTerms
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_Terms", value);
            }
        }

        private int _SummerServ = 0;

        public int SummerServ
        {
            get
            {
                return _SummerServ;
            }
        }

        public object SetSummerServ
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_SummerServ", value);
            }
        }

        private int _WinterServ = 0;

        public int WinterServ
        {
            get
            {
                return _WinterServ;
            }
        }

        public object SetWinterServ
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_WinterServ", value);
            }
        }

        private string _alertEmail = string.Empty;

        public string AlertEmail
        {
            get
            {
                return _alertEmail;
            }
        }

        public object SetAlertEmail
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_alertEmail", value);
            }
        }

        private bool _motStyleService = false;

        public bool MOTStyleService
        {
            get
            {
                return _motStyleService;
            }
        }

        public bool SetMOTStyleService
        {
            set
            {
                _motStyleService = value;
            }
        }

        private bool _isOutOfScope = false;

        public bool IsOutOfScope
        {
            get
            {
                return _isOutOfScope;
            }
        }

        public bool SetIsOutOfScope
        {
            set
            {
                _isOutOfScope = value;
            }
        }

        private bool _IsPFH = false;

        public bool IsPFH
        {
            get
            {
                return _IsPFH;
            }
        }

        public bool SetIsPFH
        {
            set
            {
                _IsPFH = value;
            }
        }

        private decimal _jobSpendLimit = default;

        public decimal JobSpendLimit
        {
            get
            {
                return _jobSpendLimit;
            }
        }

        public object SetJobSpendLimit
        {
            set
            {
                _dataTypeValidator.SetValue(this, "_jobSpendLimit", value);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}