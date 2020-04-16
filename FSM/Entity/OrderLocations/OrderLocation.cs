// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderLocations.OrderLocation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderLocations
{
  public class OrderLocation
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _OrderLocationID;
    private int _OrderID;
    private int _LocationID;
    private int _deliveryAddressID;

    public OrderLocation()
    {
      this._exists = false;
      this._deleted = false;
      this._OrderLocationID = 0;
      this._OrderID = 0;
      this._LocationID = 0;
      this._deliveryAddressID = 0;
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

    public int OrderLocationID
    {
      get
      {
        return this._OrderLocationID;
      }
    }

    public object SetOrderLocationID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OrderLocationID", RuntimeHelpers.GetObjectValue(value));
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

    public int LocationID
    {
      get
      {
        return this._LocationID;
      }
    }

    public object SetLocationID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_LocationID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int DeliveryAddressID
    {
      get
      {
        return this._deliveryAddressID;
      }
    }

    public object SetDeliveryAddressID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_deliveryAddressID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
