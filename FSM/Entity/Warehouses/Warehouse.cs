// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Warehouses.Warehouse
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Warehouses
{
  public class Warehouse
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _WarehouseID;
    private string _Name;
    private string _Size;
    private string _Notes;
    private string _Address1;
    private string _Address2;
    private string _Address3;
    private string _Address4;
    private string _Address5;
    private string _Postcode;
    private string _TelephoneNum;
    private string _FaxNum;
    private string _EmailAddress;
    private bool _Active;

    public Warehouse()
    {
      this._exists = false;
      this._deleted = false;
      this._WarehouseID = 0;
      this._Name = string.Empty;
      this._Size = string.Empty;
      this._Notes = string.Empty;
      this._Address1 = string.Empty;
      this._Address2 = string.Empty;
      this._Address3 = string.Empty;
      this._Address4 = string.Empty;
      this._Address5 = string.Empty;
      this._Postcode = string.Empty;
      this._TelephoneNum = string.Empty;
      this._FaxNum = string.Empty;
      this._EmailAddress = string.Empty;
      this._Active = false;
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

    public string Size
    {
      get
      {
        return this._Size;
      }
    }

    public object SetSize
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Size", RuntimeHelpers.GetObjectValue(value));
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

    public string Address1
    {
      get
      {
        return this._Address1;
      }
    }

    public object SetAddress1
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address1", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address2
    {
      get
      {
        return this._Address2;
      }
    }

    public object SetAddress2
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address2", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address3
    {
      get
      {
        return this._Address3;
      }
    }

    public object SetAddress3
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address3", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address4
    {
      get
      {
        return this._Address4;
      }
    }

    public object SetAddress4
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address4", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address5
    {
      get
      {
        return this._Address5;
      }
    }

    public object SetAddress5
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address5", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Postcode
    {
      get
      {
        return this._Postcode;
      }
    }

    public object SetPostcode
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Postcode", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string TelephoneNum
    {
      get
      {
        return this._TelephoneNum;
      }
    }

    public object SetTelephoneNum
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TelephoneNum", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string FaxNum
    {
      get
      {
        return this._FaxNum;
      }
    }

    public object SetFaxNum
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FaxNum", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string EmailAddress
    {
      get
      {
        return this._EmailAddress;
      }
    }

    public object SetEmailAddress
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EmailAddress", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool Active
    {
      get
      {
        return this._Active;
      }
    }

    public object SetActive
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Active", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
