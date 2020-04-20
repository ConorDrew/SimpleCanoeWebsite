Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitAssetWorkSheets

        Public Class EngineerVisitAssetWorkSheet

            Private _dataTypeValidator As DataTypeValidator
            Public Sub New()
                _dataTypeValidator = New DataTypeValidator
            End Sub

#Region "Class Properties"

            Public Property IgnoreExceptionsOnSetMethods() As Boolean
                Get
                    Return Me._dataTypeValidator.IgnoreExceptionsOnSetMethods
                End Get
                Set(ByVal Value As Boolean)
                    Me._dataTypeValidator.IgnoreExceptionsOnSetMethods = Value
                End Set
            End Property

            Public ReadOnly Property Errors() As Hashtable
                Get
                    Return _dataTypeValidator.Errors
                End Get
            End Property

            Public ReadOnly Property DTValidator() As DataTypeValidator
                Get
                    Return _dataTypeValidator
                End Get
            End Property

            Private _exists As Boolean = False
            Public Property Exists() As Boolean
                Get
                    Return _exists
                End Get
                Set(ByVal Value As Boolean)
                    _exists = Value
                End Set
            End Property

            Private _deleted As Boolean = False
            Public ReadOnly Property Deleted() As Boolean
                Get
                    Return _deleted
                End Get
            End Property
            Public WriteOnly Property SetDeleted() As Boolean
                Set(ByVal Value As Boolean)
                    _deleted = Value
                End Set
            End Property

#End Region

#Region "EngineerVisitAssetWorkSheet Properties"


            Private _EngineerVisitAssetWorkSheetID As Integer = 0
            Public ReadOnly Property EngineerVisitAssetWorkSheetID() As Integer
                Get
                    Return _EngineerVisitAssetWorkSheetID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitAssetWorkSheetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitAssetWorkSheetID", Value)
                End Set
            End Property


            Private _EngineerVisitID As Integer = 0
            Public ReadOnly Property EngineerVisitID() As Integer
                Get
                    Return _EngineerVisitID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitID", Value)
                End Set
            End Property


            Private _AssetID As Integer = 0
            Public ReadOnly Property AssetID() As Integer
                Get
                    Return _AssetID
                End Get
            End Property
            Public WriteOnly Property SetAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AssetID", Value)
                End Set
            End Property


            Private _FlueTerminationSatisfactoryID As Integer = 0
            Public ReadOnly Property FlueTerminationSatisfactoryID() As Integer
                Get
                    Return _FlueTerminationSatisfactoryID
                End Get
            End Property
            Public WriteOnly Property SetFlueTerminationSatisfactoryID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FlueTerminationSatisfactoryID", Value)
                End Set
            End Property


            Private _FlueFlowTestID As Integer = 0
            Public ReadOnly Property FlueFlowTestID() As Integer
                Get
                    Return _FlueFlowTestID
                End Get
            End Property
            Public WriteOnly Property SetFlueFlowTestID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FlueFlowTestID", Value)
                End Set
            End Property


            Private _SpillageTestID As Integer = 0
            Public ReadOnly Property SpillageTestID() As Integer
                Get
                    Return _SpillageTestID
                End Get
            End Property
            Public WriteOnly Property SetSpillageTestID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SpillageTestID", Value)
                End Set
            End Property


            Private _ApplianceTestedID As Integer = 0
            Public ReadOnly Property ApplianceTestedID() As Integer
                Get
                    Return _ApplianceTestedID
                End Get
            End Property
            Public WriteOnly Property SetApplianceTestedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ApplianceTestedID", Value)
                End Set
            End Property


            Private _VentilationProvisionSatisfactoryID As Integer = 0
            Public ReadOnly Property VentilationProvisionSatisfactoryID() As Integer
                Get
                    Return _VentilationProvisionSatisfactoryID
                End Get
            End Property
            Public WriteOnly Property SetVentilationProvisionSatisfactoryID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VentilationProvisionSatisfactoryID", Value)
                End Set
            End Property


            Private _SafetyDeviceOperationID As Integer = 0
            Public ReadOnly Property SafetyDeviceOperationID() As Integer
                Get
                    Return _SafetyDeviceOperationID
                End Get
            End Property
            Public WriteOnly Property SetSafetyDeviceOperationID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SafetyDeviceOperationID", Value)
                End Set
            End Property


            Private _DHWFlowRate As Double = 0
            Public ReadOnly Property DHWFlowRate() As Double
                Get
                    Return _DHWFlowRate
                End Get
            End Property
            Public WriteOnly Property SetDHWFlowRate() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DHWFlowRate", Value)
                End Set
            End Property


            Private _ColdWaterTemp As Double = 0
            Public ReadOnly Property ColdWaterTemp() As Double
                Get
                    Return _ColdWaterTemp
                End Get
            End Property
            Public WriteOnly Property SetColdWaterTemp() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ColdWaterTemp", Value)
                End Set
            End Property


            Private _DHWTemp As Double = 0
            Public ReadOnly Property DHWTemp() As Double
                Get
                    Return _DHWTemp
                End Get
            End Property
            Public WriteOnly Property SetDHWTemp() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DHWTemp", Value)
                End Set
            End Property


            Private _InletStaticPressure As Double = 0
            Public ReadOnly Property InletStaticPressure() As Double
                Get
                    Return _InletStaticPressure
                End Get
            End Property
            Public WriteOnly Property SetInletStaticPressure() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InletStaticPressure", Value)
                End Set
            End Property


            Private _InletWorkingPressure As Double = 0
            Public ReadOnly Property InletWorkingPressure() As Double
                Get
                    Return _InletWorkingPressure
                End Get
            End Property
            Public WriteOnly Property SetInletWorkingPressure() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InletWorkingPressure", Value)
                End Set
            End Property


            Private _MinBurnerPressure As Double = 0
            Public ReadOnly Property MinBurnerPressure() As Double
                Get
                    Return _MinBurnerPressure
                End Get
            End Property
            Public WriteOnly Property SetMinBurnerPressure() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MinBurnerPressure", Value)
                End Set
            End Property


            Private _MaxBurnerPressure As Double = 0
            Public ReadOnly Property MaxBurnerPressure() As Double
                Get
                    Return _MaxBurnerPressure
                End Get
            End Property
            Public WriteOnly Property SetMaxBurnerPressure() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MaxBurnerPressure", Value)
                End Set
            End Property

            Private _TankID As Integer = 0
            Public ReadOnly Property TankID() As Integer
                Get
                    Return _TankID
                End Get
            End Property
            Public WriteOnly Property SetTankID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TankID", Value)
                End Set
            End Property

            Private _Nozzle As String = ""
            Public ReadOnly Property Nozzle() As String
                Get
                    Return _Nozzle
                End Get
            End Property
            Public WriteOnly Property SetNozzle() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Nozzle", Value)
                End Set
            End Property

            Private _BMake As String = ""
            Public ReadOnly Property BMake() As String
                Get
                    Return _BMake
                End Get
            End Property
            Public WriteOnly Property SetBMake() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BMake", Value)
                End Set
            End Property

            Private _BModel As String = ""
            Public ReadOnly Property BModel() As String
                Get
                    Return _BModel
                End Get
            End Property
            Public WriteOnly Property SetBModel() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BModel", Value)
                End Set
            End Property



            Private _Reading As Double = 0
            Public ReadOnly Property Reading() As Double
                Get
                    Return _Reading
                End Get
            End Property
            Public WriteOnly Property SetReading() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Reading", Value)
                End Set
            End Property

            Private _CO2 As Double = 0
            Public ReadOnly Property CO2() As Double
                Get
                    Return _CO2
                End Get
            End Property
            Public WriteOnly Property SetCO2() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CO2", Value)
                End Set
            End Property


            Private _CO2CORatio As Double = 0
            Public ReadOnly Property CO2CORatio() As Double
                Get
                    Return _CO2CORatio
                End Get
            End Property
            Public WriteOnly Property SetCO2CORatio() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CO2CORatio", Value)
                End Set
            End Property


            Private _LandlordsApplianceID As Integer = 0
            Public ReadOnly Property LandlordsApplianceID() As Integer
                Get
                    Return _LandlordsApplianceID
                End Get
            End Property
            Public WriteOnly Property SetLandlordsApplianceID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LandlordsApplianceID", Value)
                End Set
            End Property


            Private _ApplianceServiceOrInspectedID As Integer = 0
            Public ReadOnly Property ApplianceServiceOrInspectedID() As Integer
                Get
                    Return _ApplianceServiceOrInspectedID
                End Get
            End Property
            Public WriteOnly Property SetApplianceServiceOrInspectedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ApplianceServiceOrInspectedID", Value)
                End Set
            End Property


            Private _ApplianceSafeID As Integer = 0
            Public ReadOnly Property ApplianceSafeID() As Integer
                Get
                    Return _ApplianceSafeID
                End Get
            End Property
            Public WriteOnly Property SetApplianceSafeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ApplianceSafeID", Value)
                End Set
            End Property

            Private _VisualConditionOfFlueSatisfactoryID As Integer = 0
            Public ReadOnly Property VisualConditionOfFlueSatisfactoryID() As Integer
                Get
                    Return _VisualConditionOfFlueSatisfactoryID
                End Get
            End Property
            Public WriteOnly Property SetVisualConditionOfFlueSatisfactoryID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisualConditionOfFlueSatisfactoryID", Value)
                End Set
            End Property


            Private _SweepOutcomeID As Integer = 0
            Public ReadOnly Property SweepOutcomeID() As Integer
                Get
                    Return _SweepOutcomeID
                End Get
            End Property
            Public WriteOnly Property SetSweepOutcomeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SweepOutcomeID", Value)
                End Set
            End Property

            Private _OverallID As Integer = 0
            Public ReadOnly Property OverallID() As Integer
                Get
                    Return _OverallID
                End Get
            End Property
            Public WriteOnly Property SetOverallID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OverallID", Value)
                End Set
            End Property

            Private _DischargeID As Integer = 0
            Public ReadOnly Property DischargeID() As Integer
                Get
                    Return _DischargeID
                End Get
            End Property
            Public WriteOnly Property SetDischargeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DischargeID", Value)
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

