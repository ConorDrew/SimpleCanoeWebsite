// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalSiteAssets
{
  public class ContractOriginalSiteAsset
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private int _ContractSiteAssetID;
    private int _ContractSiteID;
    private int _AssetID;
    private double _PricePerVisit;
    private bool _PrimaryAsset;
    private string _Type;
    private string _Product;

    public ContractOriginalSiteAsset()
    {
      this._exists = false;
      this._ContractSiteAssetID = 0;
      this._ContractSiteID = 0;
      this._AssetID = 0;
      this._PricePerVisit = 0.0;
      this._PrimaryAsset = false;
      this._Type = "";
      this._Product = "";
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
        this._dataTypeValidator.SetValue((object) this, "_ContractSiteAssetID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ContractSiteID
    {
      get
      {
        return this._ContractSiteID;
      }
    }

    public object SetContractSiteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractSiteID", RuntimeHelpers.GetObjectValue(value));
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
        this._dataTypeValidator.SetValue((object) this, "_AssetID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double PricePerVisit
    {
      get
      {
        return this._PricePerVisit;
      }
    }

    public object SetPricePerVisit
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PricePerVisit", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool PrimaryAsset
    {
      get
      {
        return this._PrimaryAsset;
      }
    }

    public object SetPrimaryAsset
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PrimaryAsset", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Type
    {
      get
      {
        return this._Type;
      }
    }

    public object SetType
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Type", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Product
    {
      get
      {
        return this._Product;
      }
    }

    public object SetProduct
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Product", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
