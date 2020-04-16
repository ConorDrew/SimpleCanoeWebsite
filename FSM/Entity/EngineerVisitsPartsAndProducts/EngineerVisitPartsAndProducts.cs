// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProducts
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitsPartsAndProducts
{
  public class EngineerVisitPartsAndProducts
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _PartOrProductID;
    private int _EngineerVisitID;
    private int _Quantity;
    private int _AssetID;
    private int _AllocatedID;
    private int _LocationID;
    private double _SpecialPrice;
    private string _SpecialPartNumber;
    private string _SpecialDescription;

    public EngineerVisitPartsAndProducts()
    {
      this._exists = false;
      this._deleted = false;
      this._PartOrProductID = 0;
      this._EngineerVisitID = 0;
      this._Quantity = 0;
      this._AssetID = 0;
      this._AllocatedID = 0;
      this._LocationID = 0;
      this._SpecialPrice = 0.0;
      this._SpecialPartNumber = "";
      this._SpecialDescription = "";
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

    public int PartOrProductID
    {
      get
      {
        return this._PartOrProductID;
      }
    }

    public object SetPartOrProductID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PartOrProductID", RuntimeHelpers.GetObjectValue(value));
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

    public int AllocatedID
    {
      get
      {
        return this._AllocatedID;
      }
    }

    public object SetAllocatedID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AllocatedID", RuntimeHelpers.GetObjectValue(value));
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

    public double SpecialPrice
    {
      get
      {
        return this._SpecialPrice;
      }
    }

    public object SetSpecialPrice
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SpecialPrice", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string SpecialPartNumber
    {
      get
      {
        return this._SpecialPartNumber;
      }
    }

    public object SetSpecialPartNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SpecialPartNumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string SpecialDescription
    {
      get
      {
        return this._SpecialDescription;
      }
    }

    public object SetSpecialDescription
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SpecialDescription", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
