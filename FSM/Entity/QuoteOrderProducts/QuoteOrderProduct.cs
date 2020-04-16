// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteOrderProducts.QuoteOrderProduct
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteOrderProducts
{
  public class QuoteOrderProduct
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _QuoteOrderProductID;
    private int _QuoteOrderID;
    private int _ProductID;
    private int _Quantity;
    private double _Price;

    public QuoteOrderProduct()
    {
      this._exists = false;
      this._deleted = false;
      this._QuoteOrderProductID = 0;
      this._QuoteOrderID = 0;
      this._ProductID = 0;
      this._Quantity = 0;
      this._Price = 0.0;
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

    public int QuoteOrderProductID
    {
      get
      {
        return this._QuoteOrderProductID;
      }
    }

    public object SetQuoteOrderProductID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteOrderProductID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuoteOrderID
    {
      get
      {
        return this._QuoteOrderID;
      }
    }

    public object SetQuoteOrderID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteOrderID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ProductID
    {
      get
      {
        return this._ProductID;
      }
    }

    public object SetProductID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ProductID", RuntimeHelpers.GetObjectValue(value));
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

    public double Price
    {
      get
      {
        return this._Price;
      }
    }

    public object SetPrice
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Price", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
