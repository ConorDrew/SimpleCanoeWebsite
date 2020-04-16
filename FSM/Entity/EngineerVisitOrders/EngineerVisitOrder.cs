// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitOrders.EngineerVisitOrder
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitOrders
{
  public class EngineerVisitOrder
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerVisitOrderID;
    private int _OrderID;
    private int _EngineerVisitID;
    private int _WarehouseID;

    public EngineerVisitOrder()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerVisitOrderID = 0;
      this._OrderID = 0;
      this._EngineerVisitID = 0;
      this._WarehouseID = 0;
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

    public int EngineerVisitOrderID
    {
      get
      {
        return this._EngineerVisitOrderID;
      }
    }

    public object SetEngineerVisitOrderID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitOrderID", RuntimeHelpers.GetObjectValue(value));
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

    public int EngineerVisitID
    {
      get
      {
        return this._EngineerVisitID;
      }
    }

    public object SetEngineerVisitID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int WarehouseID
    {
      get
      {
        return this._WarehouseID;
      }
    }

    public object SetWarehouseID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_WarehouseID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
