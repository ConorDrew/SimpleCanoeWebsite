// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ProductAssociatedParts.ProductAssociatedPart
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ProductAssociatedParts
{
  public class ProductAssociatedPart
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _ProductAssociatedPartID;
    private int _ProductID;
    private int _PartID;

    public ProductAssociatedPart()
    {
      this._exists = false;
      this._deleted = false;
      this._ProductAssociatedPartID = 0;
      this._ProductID = 0;
      this._PartID = 0;
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

    public int ProductAssociatedPartID
    {
      get
      {
        return this._ProductAssociatedPartID;
      }
    }

    public object SetProductAssociatedPartID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ProductAssociatedPartID", RuntimeHelpers.GetObjectValue(value));
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
  }
}
