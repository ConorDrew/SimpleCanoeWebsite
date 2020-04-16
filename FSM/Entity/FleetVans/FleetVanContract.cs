// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanContract
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
  public class FleetVanContract
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _vanContractID;
    private int _vanID;
    private string _lessor;
    private int _procurementMethod;
    private int _contractLength;
    private DateTime _contractStart;
    private DateTime _contractEnd;
    private int _contractMileage;
    private int _startingMileage;
    private double _excessMileageRate;
    private double _weeklyRental;
    private double _monthlyRental;
    private double _annualRental;
    private string _agreementRef;
    private string _notes;
    private double _excessMileageCost;
    private double _forecastExcessMileageCost;

    public FleetVanContract()
    {
      this._exists = false;
      this._deleted = false;
      this._vanContractID = 0;
      this._vanID = 0;
      this._lessor = string.Empty;
      this._procurementMethod = 0;
      this._contractLength = 0;
      this._contractStart = DateTime.MinValue;
      this._contractEnd = DateTime.MinValue;
      this._contractMileage = 0;
      this._startingMileage = 0;
      this._excessMileageRate = 0.0;
      this._weeklyRental = 0.0;
      this._monthlyRental = 0.0;
      this._annualRental = 0.0;
      this._agreementRef = string.Empty;
      this._notes = string.Empty;
      this._excessMileageCost = 0.0;
      this._forecastExcessMileageCost = 0.0;
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

    public int VanContractID
    {
      get
      {
        return this._vanContractID;
      }
    }

    public object SetVanContractID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_vanContractID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int VanID
    {
      get
      {
        return this._vanID;
      }
    }

    public object SetVanID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_vanID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Lessor
    {
      get
      {
        return this._lessor;
      }
    }

    public object SetLessor
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_lessor", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ProcurementMethod
    {
      get
      {
        return this._procurementMethod;
      }
    }

    public object SetProcurementMethod
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_procurementMethod", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ContractLength
    {
      get
      {
        return this._contractLength;
      }
    }

    public object SetContractLength
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_contractLength", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime ContractStart
    {
      get
      {
        return this._contractStart;
      }
      set
      {
        this._contractStart = value;
      }
    }

    public DateTime ContractEnd
    {
      get
      {
        return this._contractEnd;
      }
      set
      {
        this._contractEnd = value;
      }
    }

    public int ContractMileage
    {
      get
      {
        return this._contractMileage;
      }
    }

    public object SetContractMileage
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_contractMileage", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int StartingMileage
    {
      get
      {
        return this._startingMileage;
      }
    }

    public object SetStartingMileage
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_startingMileage", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double ExcessMileageRate
    {
      get
      {
        return this._excessMileageRate;
      }
    }

    public object SetExcessMileageRate
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_excessMileageRate", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double WeeklyRental
    {
      get
      {
        return this._weeklyRental;
      }
    }

    public object SetWeeklyRental
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_weeklyRental", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double MonthlyRental
    {
      get
      {
        return this._monthlyRental;
      }
    }

    public object SetMonthlyRental
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_monthlyRental", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double AnnualRental
    {
      get
      {
        return this._annualRental;
      }
    }

    public object SetAnnualRental
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_annualRental", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string AgreementRef
    {
      get
      {
        return this._agreementRef;
      }
    }

    public object SetAgreementRef
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_agreementRef", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Notes
    {
      get
      {
        return this._notes;
      }
    }

    public object SetNotes
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_notes", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double ExcessMileageCost
    {
      get
      {
        return this._excessMileageCost;
      }
    }

    public object SetExcessMileageCost
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_excessMileageCost", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double ForecastExcessMileageCost
    {
      get
      {
        return this._forecastExcessMileageCost;
      }
    }

    public object SetForecastExcessMileageCost
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_forecastExcessMileageCost", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
