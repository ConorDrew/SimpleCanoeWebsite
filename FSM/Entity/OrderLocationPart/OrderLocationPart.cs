// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderLocationPart.OrderLocationPart
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderLocationPart
{
  public class OrderLocationPart
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _OrderLocationPartID;
    private int _PartID;
    private int _LocationID;
    private int _Quantity;
    private int _QuantityReceived;
    private int _OrderID;
    private double _SellPrice;

    public OrderLocationPart()
    {
      this._exists = false;
      this._deleted = false;
      this._OrderLocationPartID = 0;
      this._PartID = 0;
      this._LocationID = 0;
      this._Quantity = 0;
      this._QuantityReceived = 0;
      this._OrderID = 0;
      this._SellPrice = 0.0;
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

    public int OrderLocationPartID
    {
      get
      {
        return this._OrderLocationPartID;
      }
    }

    public object SetOrderLocationPartID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OrderLocationPartID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PartID
    {
      get
      {
        return this._PartID;
      }
    }

    public object SetPartID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PartID", RuntimeHelpers.GetObjectValue(value));
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

    public int Quantity
    {
      get
      {
        return this._Quantity;
      }
    }

    public object SetQuantity
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Quantity", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuantityReceived
    {
      get
      {
        return this._QuantityReceived;
      }
    }

    public object SetQuantityReceived
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuantityReceived", RuntimeHelpers.GetObjectValue(value));
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

    public double SellPrice
    {
      get
      {
        return this._SellPrice;
      }
    }

    public object SetSellPrice
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SellPrice", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
