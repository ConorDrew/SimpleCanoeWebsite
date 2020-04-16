// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractOriginalSiteAssets.QuoteContractOriginalSiteAsset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractOriginalSiteAssets
{
  public class QuoteContractOriginalSiteAsset
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _QuoteContractSiteAssetID;
    private int _QuoteContractSiteID;
    private int _AssetID;
    private double _PricePerVisit;

    public QuoteContractOriginalSiteAsset()
    {
      this._exists = false;
      this._deleted = false;
      this._QuoteContractSiteAssetID = 0;
      this._QuoteContractSiteID = 0;
      this._AssetID = 0;
      this._PricePerVisit = 0.0;
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

    public bool Deleted
    {
      get
      {
        return this._deleted;
      }
    }

    public bool SetDeleted
    {
      set
      {
        this._deleted = value;
      }
    }

    public int QuoteContractSiteAssetID
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
        this._dataTypeValidator.SetValue((object) this, "_QuoteContractSiteAssetID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuoteContractSiteID
    {
      get
      {
        return this._QuoteContractSiteID;
      }
    }

    public object SetQuoteContractSiteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteContractSiteID", RuntimeHelpers.GetObjectValue(value));
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
  }
}
