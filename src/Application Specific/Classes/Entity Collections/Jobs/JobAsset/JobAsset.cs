using System.Collections;

namespace FSM.Entity
{
    namespace JobAssets
    {
        public class JobAsset
        {
            private DataTypeValidator _dataTypeValidator;

            public JobAsset()
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private int _JobAssetID = 0;

            public int JobAssetID
            {
                get
                {
                    return _JobAssetID;
                }
            }

            public object SetJobAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobAssetID", value);
                }
            }

            private int _JobID = 0;

            public int JobID
            {
                get
                {
                    return _JobID;
                }
            }

            public object SetJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobID", value);
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