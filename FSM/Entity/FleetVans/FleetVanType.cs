// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanType
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
  public class FleetVanType
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _vanTypeID;
    private string _make;
    private string _model;
    private int _mileageServiceInterval;
    private int _dateServiceInterval;
    private double _GrossVehicleWeight;
    private double _Payload;

    public FleetVanType()
    {
      this._exists = false;
      this._deleted = false;
      this._vanTypeID = 0;
      this._make = string.Empty;
      this._model = string.Empty;
      this._mileageServiceInterval = 0;
      this._dateServiceInterval = 0;
      this._GrossVehicleWeight = 0.0;
      this._Payload = 0.0;
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

    public int VanTypeID
    {
      get
      {
        return this._vanTypeID;
      }
    }

    public object SetVanTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_vanTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Make
    {
      get
      {
        return this._make;
      }
    }

    public object SetMake
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_make", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Model
    {
      get
      {
        return this._model;
      }
    }

    public object SetModel
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_model", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int MileageServiceInterval
    {
      get
      {
        return this._mileageServiceInterval;
      }
    }

    public object SetMileageServiceInterval
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_mileageServiceInterval", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int DateServiceInterval
    {
      get
      {
        return this._dateServiceInterval;
      }
    }

    public object SetDateServiceInterval
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_dateServiceInterval", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double GrossVehicleWeight
    {
      get
      {
        return this._GrossVehicleWeight;
      }
    }

    public object SetGrossVehicleWeight
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_GrossVehicleWeight", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double Payload
    {
      get
      {
        return this._Payload;
      }
    }

    public object SetPayload
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Payload", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
