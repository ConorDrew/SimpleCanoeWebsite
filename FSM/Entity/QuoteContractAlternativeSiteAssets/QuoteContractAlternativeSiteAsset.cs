// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativeSiteAssets.QuoteContractAlternativeSiteAsset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativeSiteAssets
{
    public class QuoteContractAlternativeSiteAsset
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private int _QuoteContractSiteAssetID;
        private int _QuoteContractSiteJobItemID;
        private int _AssetID;

        public QuoteContractAlternativeSiteAsset()
        {
            this._exists = false;
            this._QuoteContractSiteAssetID = 0;
            this._QuoteContractSiteJobItemID = 0;
            this._AssetID = 0;
            this._dataTypeValidator = new DataTypeValidator();
        }

        public bool IgnoreExceptionsOnSetMethods
        {
            get
            {
                return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
            }
            set
            {
                this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
            }
        }

        public Hashtable Errors
        {
            get
            {
                return this._dataTypeValidator.Errors;
            }
        }

        public DataTypeValidator DTValidator
        {
            get
            {
                return this._dataTypeValidator;
            }
        }

        public bool Exists
        {
            get
            {
                return this._exists;
            }
            set
            {
                this._exists = value;
            }
        }

        public int ContractSiteAssetID
        {
            get
            {
                return this._QuoteContractSiteAssetID;
            }
        }

        public object SetQuoteContractSiteAssetID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractSiteAssetID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuoteContractSiteJobItemID
        {
            get
            {
                return this._QuoteContractSiteJobItemID;
            }
        }

        public object SetQuoteContractSiteJobItemID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteContractSiteJobItemID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AssetID
        {
            get
            {
                return this._AssetID;
            }
        }

        public object SetAssetID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AssetID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}