using System.Collections;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteAssets
    {
        public class ContractAlternativeSiteAsset
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractAlternativeSiteAsset()
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

            private int _ContractSiteAssetID = 0;

            public int ContractSiteAssetID
            {
                get
                {
                    return _ContractSiteAssetID;
                }
            }

            public object SetContractSiteAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteAssetID", value);
                }
            }

            private int _ContractSiteJobItemID = 0;

            public int ContractSiteJobItemID
            {
                get
                {
                    return _ContractSiteJobItemID;
                }
            }

            public object SetContractSiteJobItemID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteJobItemID", value);
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