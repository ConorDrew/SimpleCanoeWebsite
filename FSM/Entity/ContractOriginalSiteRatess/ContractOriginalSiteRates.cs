// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalSiteRatess
{
  public class ContractOriginalSiteRates
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _ContractOriginalSiteRateID;
    private int _ContractSiteID;
    private int _RateID;
    private int _Qty;

    public ContractOriginalSiteRates()
    {
      this._exists = false;
      this._deleted = false;
      this._ContractOriginalSiteRateID = 0;
      this._ContractSiteID = 0;
      this._RateID = 0;
      this._Qty = 0;
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

    public int ContractOriginalSiteRateID
    {
      get
      {
        return this._ContractOriginalSiteRateID;
      }
    }

    public object SetContractOriginalSiteRateID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractOriginalSiteRateID", RuntimeHelpers.GetObjectValue(value));
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

    public int RateID
    {
      get
      {
        return this._RateID;
      }
    }

    public object SetRateID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_RateID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Qty
    {
      get
      {
        return this._Qty;
      }
    }

    public object SetQty
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Qty", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
