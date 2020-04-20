using System;
using System.Collections;

namespace FSM.Entity
{
    namespace QuoteContractOption3SiteAssetDurations
    {
        public class QuoteContractOption3SiteAssetDuration
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractOption3SiteAssetDuration()
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

            private int _QuoteContractSiteAssetDurationID = 0;

            public int QuoteContractSiteAssetDurationID
            {
                get
                {
                    return _QuoteContractSiteAssetDurationID;
                }
            }

            public object SetQuoteContractSiteAssetDurationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractSiteAssetDurationID", value);
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

            private int _AssetID = 0;

            public int AssetID
            {
                get
                {
                    return _AssetID;
                }
            }

            public object SetAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AssetID", value);
                }
            }

            private DateTime _ScheduledMonth = default;

            public DateTime ScheduledMonth
            {
                get
                {
                    return _ScheduledMonth;
                }

                set
                {
                    _ScheduledMonth = value;
                }
            }

            private double _VisitDuration = 0;

            public double VisitDuration
            {
                get
                {
                    return _VisitDuration;
                }
            }

            public object SetVisitDuration
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitDuration", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}