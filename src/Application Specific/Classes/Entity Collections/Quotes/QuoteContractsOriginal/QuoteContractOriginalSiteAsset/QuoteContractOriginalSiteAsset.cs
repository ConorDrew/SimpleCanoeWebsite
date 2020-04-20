using System.Collections;

namespace FSM.Entity
{
    namespace QuoteContractOriginalSiteAssets
    {
        public class QuoteContractOriginalSiteAsset
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractOriginalSiteAsset()
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

            private int _QuoteContractSiteAssetID = 0;

            public int QuoteContractSiteAssetID
            {
                get
                {
                    return _QuoteContractSiteAssetID;
                }
            }

            public object SetQuoteContractSiteAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractSiteAssetID", value);
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

            private double _PricePerVisit = 0;

            public double PricePerVisit
            {
                get
                {
                    return _PricePerVisit;
                }
            }

            public object SetPricePerVisit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PricePerVisit", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}