using System;
using System.Collections;

namespace FSM.Entity
{
    namespace QuoteContractOriginalPPMVisits
    {
        public class QuoteContractOriginalPPMVisit
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractOriginalPPMVisit()
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

            
            

            private int _QuoteContractPPMVisitID = 0;

            public int QuoteContractPPMVisitID
            {
                get
                {
                    return _QuoteContractPPMVisitID;
                }
            }

            public object SetQuoteContractPPMVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractPPMVisitID", value);
                }
            }

            private int _QuoteContractSiteID = 0;

            public int QuoteContractSiteID
            {
                get
                {
                    return _QuoteContractSiteID;
                }
            }

            public object SetQuoteContractSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractSiteID", value);
                }
            }

            private DateTime _EstimatedVisitDate = default;

            public DateTime EstimatedVisitDate
            {
                get
                {
                    return _EstimatedVisitDate;
                }

                set
                {
                    _EstimatedVisitDate = value;
                }
            }



            
        }
    }
}