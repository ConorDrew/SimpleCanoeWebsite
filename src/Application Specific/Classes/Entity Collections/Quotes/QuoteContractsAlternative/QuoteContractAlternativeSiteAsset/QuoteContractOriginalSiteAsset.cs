using System.Collections;

namespace FSM.Entity
{
    namespace QuoteContractAlternativeSiteAssets
    {
        public class QuoteContractAlternativeSiteAsset
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractAlternativeSiteAsset()
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

            private int _QuoteContractSiteAssetID = 0;

            public int ContractSiteAssetID
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

            private int _QuoteContractSiteJobItemID = 0;

            public int QuoteContractSiteJobItemID
            {
                get
                {
                    return _QuoteContractSiteJobItemID;
                }
            }

            public object SetQuoteContractSiteJobItemID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractSiteJobItemID", value);
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}