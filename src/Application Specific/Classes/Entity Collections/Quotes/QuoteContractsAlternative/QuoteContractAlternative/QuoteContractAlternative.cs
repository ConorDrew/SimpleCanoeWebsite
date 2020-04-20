using System;
using System.Collections;

namespace FSM.Entity
{
    namespace QuoteContractAlternatives
    {
        public class QuoteContractAlternative
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractAlternative()
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

            private string _QuoteContractReference = string.Empty;

            public string QuoteContractReference
            {
                get
                {
                    return _QuoteContractReference;
                }
            }

            public object SetQuoteContractReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractReference", value);
                }
            }

            private DateTime _QuoteContractDate = default;

            public DateTime QuoteContractDate
            {
                get
                {
                    return _QuoteContractDate;
                }

                set
                {
                    _QuoteContractDate = value;
                }
            }

            private DateTime _ContractStart = default;

            public DateTime ContractStart
            {
                get
                {
                    return _ContractStart;
                }

                set
                {
                    _ContractStart = value;
                }
            }

            private DateTime _ContractEnd = default;

            public DateTime ContractEnd
            {
                get
                {
                    return _ContractEnd;
                }

                set
                {
                    _ContractEnd = value;
                }
            }

            private int _QuoteContractStatusID = 0;

            public int QuoteContractStatusID
            {
                get
                {
                    return _QuoteContractStatusID;
                }
            }

            public object SetQuoteContractStatusID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractStatusID", value);
                }
            }

            private double _QuoteContractPrice = 0;

            public double QuoteContractPrice
            {
                get
                {
                    return _QuoteContractPrice;
                }
            }

            public object SetQuoteContractPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractPrice", value);
                }
            }

            private string _ReasonForReject = string.Empty;

            public string ReasonForReject
            {
                get
                {
                    return _ReasonForReject;
                }
            }

            public object SetReasonForReject
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForReject", value);
                }
            }

            private int _ReasonForRejectID = 0;

            public int ReasonForRejectID
            {
                get
                {
                    return _ReasonForRejectID;
                }
            }

            public object SetReasonForRejectID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForRejectID", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}