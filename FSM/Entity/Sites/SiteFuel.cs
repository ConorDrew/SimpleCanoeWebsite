// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sites.SiteFuel
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Sites
{
  public class SiteFuel
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _SiteFuelID;
    private int _SiteID;
    private int _FuelID;
    private int _SiteFuelChargeID;
    private DateTime _LastServiceDate;
    private DateTime _ActualServiceDate;
    private DateTime _DateAdded;
    private int _AddedBy;

    public SiteFuel()
    {
      this._exists = false;
      this._deleted = false;
      this._SiteFuelID = 0;
      this._SiteID = 0;
      this._FuelID = 0;
      this._SiteFuelChargeID = 0;
      this._LastServiceDate = DateTime.MinValue;
      this._ActualServiceDate = DateTime.MinValue;
      this._DateAdded = DateTime.MinValue;
      this._AddedBy = 0;
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

    public int SiteFuelID
    {
      get
      {
        return this._SiteFuelID;
      }
    }

    public object SetSiteFuelID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SiteFuelID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SiteID
    {
      get
      {
        return this._SiteID;
      }
    }

    public object SetSiteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SiteID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int FuelID
    {
      get
      {
        return this._FuelID;
      }
    }

    public object SetFuelID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FuelID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SiteFuelChargeID
    {
      get
      {
        return this._SiteFuelChargeID;
      }
    }

    public object SetSiteFuelChargeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SiteFuelChargeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime LastServiceDate
    {
      get
      {
        return this._LastServiceDate;
      }
      set
      {
        this._LastServiceDate = value;
      }
    }

    public DateTime ActualServiceDate
    {
      get
      {
        return this._ActualServiceDate;
      }
      set
      {
        this._ActualServiceDate = value;
      }
    }

    public DateTime DateAdded
    {
      get
      {
        return this._DateAdded;
      }
      set
      {
        this._DateAdded = value;
      }
    }

    public int AddedBy
    {
      get
      {
        return this._AddedBy;
      }
    }

    public object SetAddedBy
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AddedBy", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
