using System;
using System.Collections;

namespace FSM.Entity
{
    namespace QuoteContractOption3Sites
    {
        public class QuoteContractOption3Site
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractOption3Site()
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

            private string _QuoteContractSiteReference = string.Empty;

            public string QuoteContractSiteReference
            {
                get
                {
                    return _QuoteContractSiteReference;
                }
            }

            public object SetQuoteContractSiteReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractSiteReference", value);
                }
            }

            private DateTime _StartDate = default;

            public DateTime StartDate
            {
                get
                {
                    return _StartDate;
                }

                set
                {
                    _StartDate = value;
                }
            }

            private DateTime _EndDate = default;

            public DateTime EndDate
            {
                get
                {
                    return _EndDate;
                }

                set
                {
                    _EndDate = value;
                }
            }

            private DateTime _FirstVisitDate = default;

            public DateTime FirstVisitDate
            {
                get
                {
                    return _FirstVisitDate;
                }

                set
                {
                    _FirstVisitDate = value;
                }
            }

            private int _VisitFrequencyID = 0;

            public int VisitFrequencyID
            {
                get
                {
                    return _VisitFrequencyID;
                }
            }

            public object SetVisitFrequencyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitFrequencyID", value);
                }
            }

            private double _SitePrice = 0;

            public double SitePrice
            {
                get
                {
                    return _SitePrice;
                }
            }

            public object SetSitePrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SitePrice", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}