// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetEquipment
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
  public class FleetEquipment
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _equipmentID;
    private string _name;
    private string _description;
    private double _cost;

    public FleetEquipment()
    {
      this._exists = false;
      this._deleted = false;
      this._equipmentID = 0;
      this._name = string.Empty;
      this._description = string.Empty;
      this._cost = 0.0;
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

    public int EquipmentID
    {
      get
      {
        return this._equipmentID;
      }
    }

    public object SetEquipmentID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_equipmentID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Name
    {
      get
      {
        return this._name;
      }
    }

    public object SetName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_name", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Description
    {
      get
      {
        return this._description;
      }
    }

    public object SetDescription
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_description", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double Cost
    {
      get
      {
        return this._cost;
      }
    }

    public object SetCost
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_cost", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
