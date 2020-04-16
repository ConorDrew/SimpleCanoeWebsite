// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobAssets.QuoteJobAsset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobAssets
{
  public class QuoteJobAsset
  {
    private DataTypeValidator _dataTypeValidator;
    private int _QuoteJobAssetID;
    private int _QuoteJobID;
    private int _AssetID;

    public QuoteJobAsset()
    {
      this._QuoteJobAssetID = 0;
      this._QuoteJobID = 0;
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

    public int QuoteJobAssetID
    {
      get
      {
        return this._QuoteJobAssetID;
      }
    }

    public object SetQuoteJobAssetID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteJobAssetID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuoteJobID
    {
      get
      {
        return this._QuoteJobID;
      }
    }

    public object SetQuoteJobID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteJobID", RuntimeHelpers.GetObjectValue(value));
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
  }
}
