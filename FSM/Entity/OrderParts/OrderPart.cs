// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderParts.OrderPart
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderParts
{
  public class OrderPart
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _OrderPartID;
    private int _OrderID;
    private int _PartSupplierID;
    private int _Quantity;
    private int _QuantityReceived;
    private double _BuyPrice;
    private double _SellPrice;
    private int _DispatchSiteID;
    private int _DispatchWarehouseID;
    private int _ChildSupplierID;
    private string _spn;
    private string _specialDescription;

    public OrderPart()
    {
      this._exists = false;
      this._deleted = false;
      this._OrderPartID = 0;
      this._OrderID = 0;
      this._PartSupplierID = 0;
      this._Quantity = 0;
      this._QuantityReceived = 0;
      this._BuyPrice = 0.0;
      this._SellPrice = 0.0;
      this._DispatchSiteID = 0;
      this._DispatchWarehouseID = 0;
      this._ChildSupplierID = 0;
      this._spn = "";
      this._specialDescription = "";
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

    public int OrderPartID
    {
      get
      {
        return this._OrderPartID;
      }
    }

    public object SetOrderPartID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OrderPartID", RuntimeHelpers.GetObjectValue(value));
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

    public int PartSupplierID
    {
      get
      {
        return this._PartSupplierID;
      }
    }

    public object SetPartSupplierID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PartSupplierID", RuntimeHelpers.GetObjectValue(value));
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

    public double BuyPrice
    {
      get
      {
        return this._BuyPrice;
      }
    }

    public object SetBuyPrice
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BuyPrice", RuntimeHelpers.GetObjectValue(value));
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

    public int DispatchSiteID
    {
      get
      {
        return this._DispatchSiteID;
      }
    }

    public object SetDispatchSiteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DispatchSiteID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int DispatchWarehouseID
    {
      get
      {
        return this._DispatchWarehouseID;
      }
    }

    public object SetDispatchWarehouseID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DispatchWarehouseID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ChildSupplierID
    {
      get
      {
        return this._ChildSupplierID;
      }
    }

    public object SetChildSupplierID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ChildSupplierID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string SpecialPartNumber
    {
      get
      {
        return this._spn;
      }
    }

    public object SetSpecialPartNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_spn", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string SpecialDescription
    {
      get
      {
        return this._specialDescription;
      }
    }

    public object SetSpecialDescription
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_specialDescription", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
