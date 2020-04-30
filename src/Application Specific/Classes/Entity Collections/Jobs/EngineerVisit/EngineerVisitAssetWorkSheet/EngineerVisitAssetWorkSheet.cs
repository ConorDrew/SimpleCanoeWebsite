using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitAssetWorkSheets
    {
        public class EngineerVisitAssetWorkSheet
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitAssetWorkSheet()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            
            

            private int _EngineerVisitAssetWorkSheetID = 0;

            public int EngineerVisitAssetWorkSheetID
            {
                get
                {
                    return _EngineerVisitAssetWorkSheetID;
                }
            }

            public object SetEngineerVisitAssetWorkSheetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitAssetWorkSheetID", value);
                }
            }

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }

            private int _AssetID = 0;

            public int AssetID
            {
                get
                {
                    return _AssetID;
                }
            }

            public object SetAssetID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AssetID", value);
                }
            }

            private int _FlueTerminationSatisfactoryID = 0;

            public int FlueTerminationSatisfactoryID
            {
                get
                {
                    return _FlueTerminationSatisfactoryID;
                }
            }

            public object SetFlueTerminationSatisfactoryID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FlueTerminationSatisfactoryID", value);
                }
            }

            private int _FlueFlowTestID = 0;

            public int FlueFlowTestID
            {
                get
                {
                    return _FlueFlowTestID;
                }
            }

            public object SetFlueFlowTestID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FlueFlowTestID", value);
                }
            }

            private int _SpillageTestID = 0;

            public int SpillageTestID
            {
                get
                {
                    return _SpillageTestID;
                }
            }

            public object SetSpillageTestID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SpillageTestID", value);
                }
            }

            private int _ApplianceTestedID = 0;

            public int ApplianceTestedID
            {
                get
                {
                    return _ApplianceTestedID;
                }
            }

            public object SetApplianceTestedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ApplianceTestedID", value);
                }
            }

            private int _VentilationProvisionSatisfactoryID = 0;

            public int VentilationProvisionSatisfactoryID
            {
                get
                {
                    return _VentilationProvisionSatisfactoryID;
                }
            }

            public object SetVentilationProvisionSatisfactoryID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VentilationProvisionSatisfactoryID", value);
                }
            }

            private int _SafetyDeviceOperationID = 0;

            public int SafetyDeviceOperationID
            {
                get
                {
                    return _SafetyDeviceOperationID;
                }
            }

            public object SetSafetyDeviceOperationID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SafetyDeviceOperationID", value);
                }
            }

            private double _DHWFlowRate = 0;

            public double DHWFlowRate
            {
                get
                {
                    return _DHWFlowRate;
                }
            }

            public object SetDHWFlowRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DHWFlowRate", value);
                }
            }

            private double _ColdWaterTemp = 0;

            public double ColdWaterTemp
            {
                get
                {
                    return _ColdWaterTemp;
                }
            }

            public object SetColdWaterTemp
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ColdWaterTemp", value);
                }
            }

            private double _DHWTemp = 0;

            public double DHWTemp
            {
                get
                {
                    return _DHWTemp;
                }
            }

            public object SetDHWTemp
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DHWTemp", value);
                }
            }

            private double _InletStaticPressure = 0;

            public double InletStaticPressure
            {
                get
                {
                    return _InletStaticPressure;
                }
            }

            public object SetInletStaticPressure
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InletStaticPressure", value);
                }
            }

            private double _InletWorkingPressure = 0;

            public double InletWorkingPressure
            {
                get
                {
                    return _InletWorkingPressure;
                }
            }

            public object SetInletWorkingPressure
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InletWorkingPressure", value);
                }
            }

            private double _MinBurnerPressure = 0;

            public double MinBurnerPressure
            {
                get
                {
                    return _MinBurnerPressure;
                }
            }

            public object SetMinBurnerPressure
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MinBurnerPressure", value);
                }
            }

            private double _MaxBurnerPressure = 0;

            public double MaxBurnerPressure
            {
                get
                {
                    return _MaxBurnerPressure;
                }
            }

            public object SetMaxBurnerPressure
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MaxBurnerPressure", value);
                }
            }

            private int _TankID = 0;

            public int TankID
            {
                get
                {
                    return _TankID;
                }
            }

            public object SetTankID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TankID", value);
                }
            }

            private string _Nozzle = "";

            public string Nozzle
            {
                get
                {
                    return _Nozzle;
                }
            }

            public object SetNozzle
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Nozzle", value);
                }
            }

            private string _BMake = "";

            public string BMake
            {
                get
                {
                    return _BMake;
                }
            }

            public object SetBMake
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BMake", value);
                }
            }

            private string _BModel = "";

            public string BModel
            {
                get
                {
                    return _BModel;
                }
            }

            public object SetBModel
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BModel", value);
                }
            }

            private double _Reading = 0;

            public double Reading
            {
                get
                {
                    return _Reading;
                }
            }

            public object SetReading
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Reading", value);
                }
            }

            private double _CO2 = 0;

            public double CO2
            {
                get
                {
                    return _CO2;
                }
            }

            public object SetCO2
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CO2", value);
                }
            }

            private double _CO2CORatio = 0;

            public double CO2CORatio
            {
                get
                {
                    return _CO2CORatio;
                }
            }

            public object SetCO2CORatio
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CO2CORatio", value);
                }
            }

            private int _LandlordsApplianceID = 0;

            public int LandlordsApplianceID
            {
                get
                {
                    return _LandlordsApplianceID;
                }
            }

            public object SetLandlordsApplianceID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LandlordsApplianceID", value);
                }
            }

            private int _ApplianceServiceOrInspectedID = 0;

            public int ApplianceServiceOrInspectedID
            {
                get
                {
                    return _ApplianceServiceOrInspectedID;
                }
            }

            public object SetApplianceServiceOrInspectedID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ApplianceServiceOrInspectedID", value);
                }
            }

            private int _ApplianceSafeID = 0;

            public int ApplianceSafeID
            {
                get
                {
                    return _ApplianceSafeID;
                }
            }

            public object SetApplianceSafeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ApplianceSafeID", value);
                }
            }

            private int _VisualConditionOfFlueSatisfactoryID = 0;

            public int VisualConditionOfFlueSatisfactoryID
            {
                get
                {
                    return _VisualConditionOfFlueSatisfactoryID;
                }
            }

            public object SetVisualConditionOfFlueSatisfactoryID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisualConditionOfFlueSatisfactoryID", value);
                }
            }

            private int _SweepOutcomeID = 0;

            public int SweepOutcomeID
            {
                get
                {
                    return _SweepOutcomeID;
                }
            }

            public object SetSweepOutcomeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SweepOutcomeID", value);
                }
            }

            private int _OverallID = 0;

            public int OverallID
            {
                get
                {
                    return _OverallID;
                }
            }

            public object SetOverallID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OverallID", value);
                }
            }

            private int _DischargeID = 0;

            public int DischargeID
            {
                get
                {
                    return _DischargeID;
                }
            }

            public object SetDischargeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DischargeID", value);
                }
            }



            
        }
    }
}