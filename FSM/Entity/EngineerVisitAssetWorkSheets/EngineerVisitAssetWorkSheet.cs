// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitAssetWorkSheets
{
  public class EngineerVisitAssetWorkSheet
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerVisitAssetWorkSheetID;
    private int _EngineerVisitID;
    private int _AssetID;
    private int _FlueTerminationSatisfactoryID;
    private int _FlueFlowTestID;
    private int _SpillageTestID;
    private int _ApplianceTestedID;
    private int _VentilationProvisionSatisfactoryID;
    private int _SafetyDeviceOperationID;
    private double _DHWFlowRate;
    private double _ColdWaterTemp;
    private double _DHWTemp;
    private double _InletStaticPressure;
    private double _InletWorkingPressure;
    private double _MinBurnerPressure;
    private double _MaxBurnerPressure;
    private int _TankID;
    private string _Nozzle;
    private string _BMake;
    private string _BModel;
    private double _Reading;
    private double _CO2;
    private double _CO2CORatio;
    private int _LandlordsApplianceID;
    private int _ApplianceServiceOrInspectedID;
    private int _ApplianceSafeID;
    private int _VisualConditionOfFlueSatisfactoryID;
    private int _SweepOutcomeID;
    private int _OverallID;
    private int _DischargeID;

    public EngineerVisitAssetWorkSheet()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerVisitAssetWorkSheetID = 0;
      this._EngineerVisitID = 0;
      this._AssetID = 0;
      this._FlueTerminationSatisfactoryID = 0;
      this._FlueFlowTestID = 0;
      this._SpillageTestID = 0;
      this._ApplianceTestedID = 0;
      this._VentilationProvisionSatisfactoryID = 0;
      this._SafetyDeviceOperationID = 0;
      this._DHWFlowRate = 0.0;
      this._ColdWaterTemp = 0.0;
      this._DHWTemp = 0.0;
      this._InletStaticPressure = 0.0;
      this._InletWorkingPressure = 0.0;
      this._MinBurnerPressure = 0.0;
      this._MaxBurnerPressure = 0.0;
      this._TankID = 0;
      this._Nozzle = "";
      this._BMake = "";
      this._BModel = "";
      this._Reading = 0.0;
      this._CO2 = 0.0;
      this._CO2CORatio = 0.0;
      this._LandlordsApplianceID = 0;
      this._ApplianceServiceOrInspectedID = 0;
      this._ApplianceSafeID = 0;
      this._VisualConditionOfFlueSatisfactoryID = 0;
      this._SweepOutcomeID = 0;
      this._OverallID = 0;
      this._DischargeID = 0;
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

    public int EngineerVisitAssetWorkSheetID
    {
      get
      {
        return this._EngineerVisitAssetWorkSheetID;
      }
    }

    public object SetEngineerVisitAssetWorkSheetID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVisitAssetWorkSheetID", RuntimeHelpers.GetObjectValue(value));
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

    public int FlueTerminationSatisfactoryID
    {
      get
      {
        return this._FlueTerminationSatisfactoryID;
      }
    }

    public object SetFlueTerminationSatisfactoryID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FlueTerminationSatisfactoryID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int FlueFlowTestID
    {
      get
      {
        return this._FlueFlowTestID;
      }
    }

    public object SetFlueFlowTestID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FlueFlowTestID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SpillageTestID
    {
      get
      {
        return this._SpillageTestID;
      }
    }

    public object SetSpillageTestID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SpillageTestID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ApplianceTestedID
    {
      get
      {
        return this._ApplianceTestedID;
      }
    }

    public object SetApplianceTestedID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ApplianceTestedID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int VentilationProvisionSatisfactoryID
    {
      get
      {
        return this._VentilationProvisionSatisfactoryID;
      }
    }

    public object SetVentilationProvisionSatisfactoryID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VentilationProvisionSatisfactoryID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SafetyDeviceOperationID
    {
      get
      {
        return this._SafetyDeviceOperationID;
      }
    }

    public object SetSafetyDeviceOperationID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SafetyDeviceOperationID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double DHWFlowRate
    {
      get
      {
        return this._DHWFlowRate;
      }
    }

    public object SetDHWFlowRate
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DHWFlowRate", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double ColdWaterTemp
    {
      get
      {
        return this._ColdWaterTemp;
      }
    }

    public object SetColdWaterTemp
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ColdWaterTemp", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double DHWTemp
    {
      get
      {
        return this._DHWTemp;
      }
    }

    public object SetDHWTemp
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DHWTemp", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double InletStaticPressure
    {
      get
      {
        return this._InletStaticPressure;
      }
    }

    public object SetInletStaticPressure
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InletStaticPressure", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double InletWorkingPressure
    {
      get
      {
        return this._InletWorkingPressure;
      }
    }

    public object SetInletWorkingPressure
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InletWorkingPressure", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double MinBurnerPressure
    {
      get
      {
        return this._MinBurnerPressure;
      }
    }

    public object SetMinBurnerPressure
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MinBurnerPressure", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double MaxBurnerPressure
    {
      get
      {
        return this._MaxBurnerPressure;
      }
    }

    public object SetMaxBurnerPressure
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MaxBurnerPressure", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int TankID
    {
      get
      {
        return this._TankID;
      }
    }

    public object SetTankID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TankID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Nozzle
    {
      get
      {
        return this._Nozzle;
      }
    }

    public object SetNozzle
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Nozzle", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string BMake
    {
      get
      {
        return this._BMake;
      }
    }

    public object SetBMake
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BMake", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string BModel
    {
      get
      {
        return this._BModel;
      }
    }

    public object SetBModel
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BModel", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double Reading
    {
      get
      {
        return this._Reading;
      }
    }

    public object SetReading
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Reading", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double CO2
    {
      get
      {
        return this._CO2;
      }
    }

    public object SetCO2
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CO2", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double CO2CORatio
    {
      get
      {
        return this._CO2CORatio;
      }
    }

    public object SetCO2CORatio
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CO2CORatio", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int LandlordsApplianceID
    {
      get
      {
        return this._LandlordsApplianceID;
      }
    }

    public object SetLandlordsApplianceID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_LandlordsApplianceID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ApplianceServiceOrInspectedID
    {
      get
      {
        return this._ApplianceServiceOrInspectedID;
      }
    }

    public object SetApplianceServiceOrInspectedID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ApplianceServiceOrInspectedID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ApplianceSafeID
    {
      get
      {
        return this._ApplianceSafeID;
      }
    }

    public object SetApplianceSafeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ApplianceSafeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int VisualConditionOfFlueSatisfactoryID
    {
      get
      {
        return this._VisualConditionOfFlueSatisfactoryID;
      }
    }

    public object SetVisualConditionOfFlueSatisfactoryID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VisualConditionOfFlueSatisfactoryID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SweepOutcomeID
    {
      get
      {
        return this._SweepOutcomeID;
      }
    }

    public object SetSweepOutcomeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SweepOutcomeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int OverallID
    {
      get
      {
        return this._OverallID;
      }
    }

    public object SetOverallID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OverallID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int DischargeID
    {
      get
      {
        return this._DischargeID;
      }
    }

    public object SetDischargeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DischargeID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
