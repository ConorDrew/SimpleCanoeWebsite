// Decompiled with JetBrains decompiler
// Type: FSM.Entity.VATRatess.VATRates
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.VATRatess
{
  public class VATRates
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _VATRateID;
    private double _VATRate;
    private DateTime _DateIntroduced;
    private string _VATRateCode;

    public VATRates()
    {
      this._exists = false;
      this._deleted = false;
      this._VATRateID = 0;
      this._VATRate = 0.0;
      this._DateIntroduced = DateTime.MinValue;
      this._VATRateCode = "";
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

    public int VATRateID
    {
      get
      {
        return this._VATRateID;
      }
    }

    public object SetVATRateID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VATRateID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double VATRate
    {
      get
      {
        return this._VATRate;
      }
    }

    public object SetVATRate
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VATRate", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime DateIntroduced
    {
      get
      {
        return this._DateIntroduced;
      }
      set
      {
        this._DateIntroduced = value;
      }
    }

    public string VATRateCode
    {
      get
      {
        return this._VATRateCode;
      }
    }

    public object SetVATRateCode
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VATRateCode", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
