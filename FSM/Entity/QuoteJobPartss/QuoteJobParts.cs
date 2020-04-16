// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobPartss.QuoteJobParts
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobPartss
{
  public class QuoteJobParts
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _QuoteJobPartsID;
    private int _QuoteJobID;
    private int _PartID;
    private int _Quantity;
    private double _SellPrice;
    private double _BuyPrice;
    private double _SpecialCost;
    private int _PartSupplierID;
    private string _SpecialDescription;
    private string _Extra;

    public QuoteJobParts()
    {
      this._exists = false;
      this._deleted = false;
      this._QuoteJobPartsID = 0;
      this._QuoteJobID = 0;
      this._PartID = 0;
      this._Quantity = 0;
      this._SellPrice = 0.0;
      this._BuyPrice = 0.0;
      this._SpecialCost = 0.0;
      this._PartSupplierID = 0;
      this._SpecialDescription = "";
      this._Extra = "";
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

    public int QuoteJobPartsID
    {
      get
      {
        return this._QuoteJobPartsID;
      }
    }

    public object SetQuoteJobPartsID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteJobPartsID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuoteJobID
    {
      get
      {
        return this._QuoteJobID;
      }
    }

    public object SetQuoteJobID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteJobID", RuntimeHelpers.GetObjectValue(value));
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

    public double SpecialCost
    {
      get
      {
        return this._SpecialCost;
      }
    }

    public object SetSpecialCost
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SpecialCost", RuntimeHelpers.GetObjectValue(value));
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

    public string Extra
    {
      get
      {
        return this._Extra;
      }
    }

    public object SetExtra
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Extra", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
