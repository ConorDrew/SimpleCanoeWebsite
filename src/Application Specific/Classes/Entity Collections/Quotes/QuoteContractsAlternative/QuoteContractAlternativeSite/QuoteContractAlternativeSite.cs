using System.Collections;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSites
    {
        public class QuoteContractAlternativeSite
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractAlternativeSite()
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

            private int _SiteID = 0;

            public int SiteID
            {
                get
                {
                    return _SiteID;
                }
            }

            public object SetSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteID", value);
                }
            }

            private ArrayList _jobOfWorks = new ArrayList();

            public ArrayList JobOfWorks
            {
                get
                {
                    return _jobOfWorks;
                }

                set
                {
                    _jobOfWorks = value;
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}