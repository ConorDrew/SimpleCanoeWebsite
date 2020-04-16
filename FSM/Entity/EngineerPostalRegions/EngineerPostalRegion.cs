// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerPostalRegions.EngineerPostalRegion
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerPostalRegions
{
  public class EngineerPostalRegion
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerPostalRegionID;
    private int _EngineerID;
    private int _PostalRegionID;

    public EngineerPostalRegion()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerPostalRegionID = 0;
      this._EngineerID = 0;
      this._PostalRegionID = 0;
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

    public int EngineerPostalRegionID
    {
      get
      {
        return this._EngineerPostalRegionID;
      }
    }

    public object SetEngineerPostalRegionID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerPostalRegionID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int EngineerID
    {
      get
      {
        return this._EngineerID;
      }
    }

    public object SetEngineerID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PostalRegionID
    {
      get
      {
        return this._PostalRegionID;
      }
    }

    public object SetPostalRegionID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PostalRegionID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
