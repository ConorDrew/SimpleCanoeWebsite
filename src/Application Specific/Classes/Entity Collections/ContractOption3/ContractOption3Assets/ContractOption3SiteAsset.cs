using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractOption3SiteAsset
    {
        public class ContractOption3SiteAsset
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOption3SiteAsset()
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

            private int _ContractSiteAssetDurationID = 0;

            public int ContractSiteAssetDurationID
            {
                get
                {
                    return _ContractSiteAssetDurationID;
                }
            }

            public object SetContractSiteAssetDurationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteAssetDurationID", value);
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