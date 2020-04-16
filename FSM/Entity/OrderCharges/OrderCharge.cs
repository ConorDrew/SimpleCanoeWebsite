// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderCharges.OrderCharge
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderCharges
{
  public class OrderCharge
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _OrderChargeID;
    private int _OrderID;
    private int _OrderChargeTypeID;
    private double _Amount;
    private string _Reference;

    public OrderCharge()
    {
      this._exists = false;
      this._deleted = false;
      this._OrderChargeID = 0;
      this._OrderID = 0;
      this._OrderChargeTypeID = 0;
      this._Amount = 0.0;
      this._Reference = string.Empty;
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

    public int OrderChargeID
    {
      get
      {
        return this._OrderChargeID;
      }
    }

    public object SetOrderChargeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OrderChargeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int OrderID
    {
      get
      {
        return this._OrderID;
      }
    }

    public object SetOrderID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OrderID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int OrderChargeTypeID
    {
      get
      {
        return this._OrderChargeTypeID;
      }
    }

    public object SetOrderChargeTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OrderChargeTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double Amount
    {
      get
      {
        return this._Amount;
      }
    }

    public object SetAmount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Amount", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Reference
    {
      get
      {
        return this._Reference;
      }
    }

    public object SetReference
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Reference", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
