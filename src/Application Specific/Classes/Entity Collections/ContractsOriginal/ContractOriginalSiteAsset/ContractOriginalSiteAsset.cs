using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOriginalSiteAssets
    {
        public class ContractOriginalSiteAsset
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOriginalSiteAsset()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

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

            public object SetContractSiteAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteAssetID", value);
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

            private bool _PrimaryAsset = Conversions.ToBoolean(0);

            public bool PrimaryAsset
            {
                get
                {
                    return _PrimaryAsset;
                }
            }

            public object SetPrimaryAsset
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PrimaryAsset", value);
                }
            }

            private string _Type = "";

            public string Type
            {
                get
                {
                    return _Type;
                }
            }

            public object SetType
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Type", value);
                }
            }

            private string _Product = "";

            public string Product
            {
                get
                {
                    return _Product;
                }
            }

            public object SetProduct
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Product", value);
                }
            }
        }
    }
}