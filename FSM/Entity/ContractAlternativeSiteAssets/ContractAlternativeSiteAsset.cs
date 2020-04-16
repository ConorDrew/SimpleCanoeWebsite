// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativeSiteAssets.ContractAlternativeSiteAsset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractAlternativeSiteAssets
{
    public class ContractAlternativeSiteAsset
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private int _ContractSiteAssetID;
        private int _ContractSiteJobItemID;
        private int _AssetID;

        public ContractAlternativeSiteAsset()
        {
            this._exists = false;
            this._ContractSiteAssetID = 0;
            this._ContractSiteJobItemID = 0;
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
                return this._ContractSiteAssetID;
            }
        }

        public object SetContractSiteAssetID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractSiteAssetID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ContractSiteJobItemID
        {
            get
            {
                return this._ContractSiteJobItemID;
            }
        }

        public object SetContractSiteJobItemID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractSiteJobItemID", RuntimeHelpers.GetObjectValue(value));
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