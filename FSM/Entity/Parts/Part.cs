// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Parts.Part
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Parts
{
  public class Part
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _PartID;
    private int _SPartID;
    private int _CategoryID;
    private int _MakeID;
    private int _FuelID;
    private int _UnitTypeID;
    private string _Name;
    private string _Number;
    private string _Reference;
    private string _Notes;
    private double _sellPrice;
    private int _MinimumQuantity;
    private int _RecommendedQuantity;
    private int _WarehouseID;
    private int _BinID;
    private int _ShelfID;
    private int _WarehouseQuantity;
    private int _WarehouseIDAlternative;
    private int _BinIDAlternative;
    private int _ShelfIDAlternative;
    private bool _EndFlagged;
    private bool _Equipment;
    private bool _IsSpecialPart;

    public Part()
    {
      this._exists = false;
      this._deleted = false;
      this._PartID = 0;
      this._SPartID = 0;
      this._CategoryID = 0;
      this._MakeID = 0;
      this._FuelID = 0;
      this._UnitTypeID = 0;
      this._Name = string.Empty;
      this._Number = string.Empty;
      this._Reference = string.Empty;
      this._Notes = string.Empty;
      this._sellPrice = 0.0;
      this._MinimumQuantity = 0;
      this._RecommendedQuantity = 0;
      this._WarehouseID = 0;
      this._BinID = 0;
      this._ShelfID = 0;
      this._WarehouseQuantity = 0;
      this._WarehouseIDAlternative = 0;
      this._BinIDAlternative = 0;
      this._ShelfIDAlternative = 0;
      this._EndFlagged = false;
      this._Equipment = false;
      this._IsSpecialPart = false;
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

    public int SPartID
    {
      get
      {
        return this._SPartID;
      }
    }

    public object SetSPartID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SPartID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int CategoryID
    {
      get
      {
        return this._CategoryID;
      }
    }

    public int MakeID
    {
      get
      {
        return this._MakeID;
      }
    }

    public object SetMakeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MakeID", RuntimeHelpers.GetObjectValue(value));
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

    public object SetCategoryID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CategoryID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int UnitTypeID
    {
      get
      {
        return this._UnitTypeID;
      }
    }

    public object SetUnitTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_UnitTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Name
    {
      get
      {
        return this._Name;
      }
    }

    public object SetName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Name", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Number
    {
      get
      {
        return this._Number;
      }
    }

    public object SetNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Number", RuntimeHelpers.GetObjectValue(value));
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

    public string Notes
    {
      get
      {
        return this._Notes;
      }
    }

    public object SetNotes
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Notes", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double SellPrice
    {
      get
      {
        return this._sellPrice;
      }
    }

    public object SetSellPrice
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_sellPrice", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int MinimumQuantity
    {
      get
      {
        return this._MinimumQuantity;
      }
    }

    public object SetMinimumQuantity
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MinimumQuantity", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int RecommendedQuantity
    {
      get
      {
        return this._RecommendedQuantity;
      }
    }

    public object SetRecommendedQuantity
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_RecommendedQuantity", RuntimeHelpers.GetObjectValue(value));
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

    public int BinID
    {
      get
      {
        return this._BinID;
      }
    }

    public object SetBinID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BinID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ShelfID
    {
      get
      {
        return this._ShelfID;
      }
    }

    public object SetShelfID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ShelfID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int WarehouseQuantity
    {
      get
      {
        return this._WarehouseQuantity;
      }
    }

    public object SetWarehouseQuantity
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_WarehouseQuantity", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int WarehouseIDAlternative
    {
      get
      {
        return this._WarehouseIDAlternative;
      }
    }

    public object SetWarehouseIDAlternative
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_WarehouseIDAlternative", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int BinIDAlternative
    {
      get
      {
        return this._BinIDAlternative;
      }
    }

    public object SetBinIDAlternative
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BinIDAlternative", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ShelfIDAlternative
    {
      get
      {
        return this._ShelfIDAlternative;
      }
    }

    public object SetShelfIDAlternative
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ShelfIDAlternative", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool EndFlagged
    {
      get
      {
        return this._EndFlagged;
      }
    }

    public bool SetEndFlagged
    {
      set
      {
        this._EndFlagged = value;
      }
    }

    public bool Equipment
    {
      get
      {
        return this._Equipment;
      }
    }

    public bool SetEquipment
    {
      set
      {
        this._Equipment = value;
      }
    }

    public bool IsSpecialPart
    {
      get
      {
        return this._IsSpecialPart;
      }
    }

    public bool SetIsSpecialPart
    {
      set
      {
        this._IsSpecialPart = value;
      }
    }
  }
}
