using System;
using System.Collections;

namespace FSM.Entity
{
    namespace QuoteContractAlternativePPMVisits
    {
        public class QuoteContractAlternativePPMVisit
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractAlternativePPMVisit()
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

            private int _QuoteContractSiteJobOfWorkID = 0;

            public int QuoteContractSiteJobOfWorkID
            {
                get
                {
                    return _QuoteContractSiteJobOfWorkID;
                }
            }

            public object SetQuoteContractSiteJobOfWorkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractSiteJobOfWorkID", value);
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}