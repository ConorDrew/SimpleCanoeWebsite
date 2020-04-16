// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PickLists.PickList
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PickLists
{
  public class PickList
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _ManagerID;
    private int _EnumTypeID;
    private string _Name;
    private string _Description;
    private double _PercentageRate;
    private bool _Mandatory;

    public PickList()
    {
      this._exists = false;
      this._deleted = false;
      this._ManagerID = 0;
      this._EnumTypeID = 0;
      this._Name = string.Empty;
      this._Description = string.Empty;
      this._PercentageRate = 0.0;
      this._Mandatory = false;
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

    public int ManagerID
    {
      get
      {
        return this._ManagerID;
      }
    }

    public object SetManagerID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ManagerID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int EnumTypeID
    {
      get
      {
        return this._EnumTypeID;
      }
    }

    public object SetEnumTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EnumTypeID", RuntimeHelpers.GetObjectValue(value));
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

    public string Description
    {
      get
      {
        return this._Description;
      }
    }

    public object SetDescription
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Description", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double PercentageRate
    {
      get
      {
        return this._PercentageRate;
      }
    }

    public object SetPercentageRate
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PercentageRate", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool Mandatory
    {
      get
      {
        return this._Mandatory;
      }
    }

    public bool SetMandatory
    {
      set
      {
        this._Mandatory = value;
      }
    }
  }
}
