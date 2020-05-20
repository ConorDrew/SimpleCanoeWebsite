using System.Collections;

namespace FSM.Entity
{
    namespace ContractOriginalSiteRatess
    {
        public class ContractOriginalSiteRates
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOriginalSiteRates()
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

            
            

            private int _ContractOriginalSiteRateID = 0;

            public int ContractOriginalSiteRateID
            {
                get
                {
                    return _ContractOriginalSiteRateID;
                }
            }

            public object SetContractOriginalSiteRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractOriginalSiteRateID", value);
                }
            }

            private int _ContractSiteID = 0;

            public int ContractSiteID
            {
                get
                {
                    return _ContractSiteID;
                }
            }

            public object SetContractSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteID", value);
                }
            }

            private int _RateID = 0;

            public int RateID
            {
                get
                {
                    return _RateID;
                }
            }

            public object SetRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RateID", value);
                }
            }

            private int _Qty = 0;

            public int Qty
            {
                get
                {
                    return _Qty;
                }
            }

            public object SetQty
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Qty", value);
                }
            }



            
        }
    }
}