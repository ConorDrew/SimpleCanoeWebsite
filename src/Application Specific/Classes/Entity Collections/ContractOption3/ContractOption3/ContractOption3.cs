using System.Collections;

namespace FSM.Entity
{
    namespace ContractOption3s
    {
        public class ContractOption3
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOption3()
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

            private int _ContractID = 0;

            public int ContractID
            {
                get
                {
                    return _ContractID;
                }
            }

            public object SetContractID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractID", value);
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

            private string _ContractReference = string.Empty;

            public string ContractReference
            {
                get
                {
                    return _ContractReference;
                }
            }

            public object SetContractReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractReference", value);
                }
            }

            private int _ContractStatusID = 0;

            public int ContractStatusID
            {
                get
                {
                    return _ContractStatusID;
                }
            }

            public object SetContractStatusID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractStatusID", value);
                }
            }

            private double _ContractPrice = 0;

            public double ContractPrice
            {
                get
                {
                    return _ContractPrice;
                }
            }

            public object SetContractPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractPrice", value);
                }
            }

            private int _QuoteContractID = 0;

            public int QuoteContractID
            {
                get
                {
                    return _QuoteContractID;
                }
            }

            public object SetQuoteContractID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractID", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}