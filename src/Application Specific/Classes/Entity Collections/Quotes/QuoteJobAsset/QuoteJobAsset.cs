using System.Collections;

namespace FSM.Entity
{
    namespace QuoteJobAssets
    {
        public class QuoteJobAsset
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteJobAsset()
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

            private int _QuoteJobAssetID = 0;

            public int QuoteJobAssetID
            {
                get
                {
                    return _QuoteJobAssetID;
                }
            }

            public object SetQuoteJobAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteJobAssetID", value);
                }
            }

            private int _QuoteJobID = 0;

            public int QuoteJobID
            {
                get
                {
                    return _QuoteJobID;
                }
            }

            public object SetQuoteJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteJobID", value);
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