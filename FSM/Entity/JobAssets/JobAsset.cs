// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobAssets.JobAsset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobAssets
{
  public class JobAsset
  {
    private DataTypeValidator _dataTypeValidator;
    private int _JobAssetID;
    private int _JobID;
    private int _AssetID;

    public JobAsset()
    {
      this._JobAssetID = 0;
      this._JobID = 0;
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

    public int JobAssetID
    {
      get
      {
        return this._JobAssetID;
      }
    }

    public object SetJobAssetID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobAssetID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobID
    {
      get
      {
        return this._JobID;
      }
    }

    public object SetJobID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobID", RuntimeHelpers.GetObjectValue(value));
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
