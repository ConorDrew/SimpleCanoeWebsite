Namespace Entity

    Namespace FleetVans

        Public Class FleetVan

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

#Region "Van Properties"


            Private _VanID As Integer = 0
            Public ReadOnly Property VanID() As Integer
                Get
                    Return _VanID
                End Get
            End Property
            Public WriteOnly Property SetVanID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VanID", Value)
                End Set
            End Property


            Private _Registration As String = String.Empty
            Public ReadOnly Property Registration() As String
                Get
                    Return _Registration
                End Get
            End Property
            Public WriteOnly Property SetRegistration() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Registration", Value)
                End Set
            End Property

            Private _VanTypeID As Integer = 0
            Public ReadOnly Property VanTypeID() As Integer
                Get
                    Return _VanTypeID
                End Get
            End Property
            Public WriteOnly Property SetVanTypeID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VanTypeID", Value)
                End Set
            End Property

            Private _Mileage As Integer = 0
            Public ReadOnly Property Mileage() As Integer
                Get
                    Return _Mileage
                End Get
            End Property
            Public WriteOnly Property SetMileage() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Mileage", Value)
                End Set
            End Property

            Private _AverageMileage As Integer = 0
            Public ReadOnly Property AverageMileage() As Integer
                Get
                    Return _AverageMileage
                End Get
            End Property
            Public WriteOnly Property SetAverageMileage() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AverageMileage", Value)
                End Set
            End Property

            Private _department As String = String.Empty
            Public ReadOnly Property Department() As String
                Get
                    Return _department
                End Get
            End Property
            Public WriteOnly Property SetDepartment() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_department", Value)
                End Set
            End Property

            Private _Returned As Boolean = 0
            Public ReadOnly Property Returned() As Boolean
                Get
                    Return _Returned
                End Get
            End Property
            Public WriteOnly Property SetReturned() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Returned", Value)
                End Set
            End Property

            Private _Notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _Notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Notes", Value)
                End Set
            End Property

            Private _TyreSize As String = String.Empty
            Public ReadOnly Property TyreSize() As String
                Get
                    Return _TyreSize
                End Get
            End Property
            Public WriteOnly Property SetTyreSize() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TyreSize", Value)
                End Set
            End Property
#End Region

        End Class

        Public Class FleetVanType

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

#Region "Van Properties"

            Private _vanTypeID As Integer = 0
            Public ReadOnly Property VanTypeID() As Integer
                Get
                    Return _vanTypeID
                End Get
            End Property
            Public WriteOnly Property SetVanTypeID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanTypeID", Value)
                End Set
            End Property

            Private _make As String = String.Empty
            Public ReadOnly Property Make() As String
                Get
                    Return _make
                End Get
            End Property
            Public WriteOnly Property SetMake() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_make", Value)
                End Set
            End Property

            Private _model As String = String.Empty
            Public ReadOnly Property Model() As String
                Get
                    Return _model
                End Get
            End Property
            Public WriteOnly Property SetModel() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_model", Value)
                End Set
            End Property

            Private _mileageServiceInterval As Integer = 0
            Public ReadOnly Property MileageServiceInterval() As Integer
                Get
                    Return _mileageServiceInterval
                End Get
            End Property
            Public WriteOnly Property SetMileageServiceInterval() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_mileageServiceInterval", Value)
                End Set
            End Property

            Private _dateServiceInterval As Integer = 0
            Public ReadOnly Property DateServiceInterval() As Integer
                Get
                    Return _dateServiceInterval
                End Get
            End Property
            Public WriteOnly Property SetDateServiceInterval() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_dateServiceInterval", Value)
                End Set
            End Property

            Private _GrossVehicleWeight As Double = 0
            Public ReadOnly Property GrossVehicleWeight() As Double
                Get
                    Return _GrossVehicleWeight
                End Get
            End Property
            Public WriteOnly Property SetGrossVehicleWeight() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GrossVehicleWeight", Value)
                End Set
            End Property

            Private _Payload As Double = 0
            Public ReadOnly Property Payload() As Double
                Get
                    Return _Payload
                End Get
            End Property
            Public WriteOnly Property SetPayload() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Payload", Value)
                End Set
            End Property
#End Region

        End Class

        Public Class FleetVanEngineer
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

#Region "Van Properties"

            Private _vanEngineerID As Integer = 0
            Public ReadOnly Property VanEngineerID() As Integer
                Get
                    Return _vanEngineerID
                End Get
            End Property
            Public WriteOnly Property SetVanEngineerID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanEngineerID", Value)
                End Set
            End Property

            Private _vanID As Integer = 0
            Public ReadOnly Property VanID() As Integer
                Get
                    Return _vanID
                End Get
            End Property
            Public WriteOnly Property SetVanID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanID", Value)
                End Set
            End Property

            Private _engineerID As Integer = 0
            Public ReadOnly Property EngineerID() As Integer
                Get
                    Return _engineerID
                End Get
            End Property
            Public WriteOnly Property SetEngineerID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_engineerID", Value)
                End Set
            End Property

            Private _startDate As DateTime = Nothing
            Public Property StartDate() As DateTime
                Get
                    Return _startDate
                End Get
                Set(ByVal Value As DateTime)
                    _startDate = Value
                End Set
            End Property

            Private _endDate As DateTime = Nothing
            Public Property EndDate() As DateTime
                Get
                    Return _endDate
                End Get
                Set(ByVal Value As DateTime)
                    _endDate = Value
                End Set
            End Property
#End Region
        End Class

        Public Class FleetVanMaintenance
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

#Region "Van Properties"

            Private _vanMaintenanceID As Integer = 0
            Public ReadOnly Property VanMaintenanceID() As Integer
                Get
                    Return _vanMaintenanceID
                End Get
            End Property
            Public WriteOnly Property SetVanMaintenanceID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanMaintenanceID", Value)
                End Set
            End Property

            Private _vanID As Integer = 0
            Public ReadOnly Property VanID() As Integer
                Get
                    Return _vanID
                End Get
            End Property
            Public WriteOnly Property SetVanID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanID", Value)
                End Set
            End Property

            Private _lastService As DateTime = Nothing
            Public Property LastService() As DateTime
                Get
                    Return _lastService
                End Get
                Set(ByVal Value As DateTime)
                    _lastService = Value
                End Set
            End Property

            Private _nextService As DateTime = Nothing
            Public Property NextService() As DateTime
                Get
                    Return _nextService
                End Get
                Set(ByVal Value As DateTime)
                    _nextService = Value
                End Set
            End Property

            Private _lastServiceMileage As Integer = 0
            Public ReadOnly Property LastServiceMileage() As Integer
                Get
                    Return _lastServiceMileage
                End Get
            End Property
            Public WriteOnly Property SetLastServiceMileage() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_lastServiceMileage", Value)
                End Set
            End Property

            Private _MOTExpiry As DateTime = Nothing
            Public Property MOTExpiry() As DateTime
                Get
                    Return _MOTExpiry
                End Get
                Set(ByVal Value As DateTime)
                    _MOTExpiry = Value
                End Set
            End Property

            Private _taxExpiry As DateTime = Nothing
            Public Property RoadTaxExpiry() As DateTime
                Get
                    Return _taxExpiry
                End Get
                Set(ByVal Value As DateTime)
                    _taxExpiry = Value
                End Set
            End Property

            Private _breakdown As String = String.Empty
            Public ReadOnly Property Breakdown() As String
                Get
                    Return _breakdown
                End Get
            End Property
            Public WriteOnly Property SetBreakdown() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_breakdown", Value)
                End Set
            End Property

            Private _warrantyExpiry As DateTime = Nothing
            Public Property WarrantyExpiry() As DateTime
                Get
                    Return _warrantyExpiry
                End Get
                Set(ByVal Value As DateTime)
                    _warrantyExpiry = Value
                End Set
            End Property

            Private _breakdownExpiry As DateTime = Nothing
            Public Property BreakdownExpiry() As DateTime
                Get
                    Return _breakdownExpiry
                End Get
                Set(ByVal Value As DateTime)
                    _breakdownExpiry = Value
                End Set
            End Property
#End Region
        End Class

        Public Class FleetVanFault
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

#Region "Van Properties"

            Private _vanFaultID As Integer = 0
            Public ReadOnly Property VanFaultID() As Integer
                Get
                    Return _vanFaultID
                End Get
            End Property
            Public WriteOnly Property SetVanFaultID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanFaultID", Value)
                End Set
            End Property

            Private _vanID As Integer = 0
            Public ReadOnly Property VanID() As Integer
                Get
                    Return _vanID
                End Get
            End Property
            Public WriteOnly Property SetVanID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanID", Value)
                End Set
            End Property

            Private _faultTypeID As Integer = 0
            Public ReadOnly Property FaultTypeID() As Integer
                Get
                    Return _faultTypeID
                End Get
            End Property
            Public WriteOnly Property SetFaultTypeID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_faultTypeID", Value)
                End Set
            End Property

            Private _faultDate As DateTime = Nothing
            Public Property FaultDate() As DateTime
                Get
                    Return _faultDate
                End Get
                Set(ByVal Value As DateTime)
                    _faultDate = Value
                End Set
            End Property

            Private _resolvedDate As DateTime = Nothing
            Public Property ResolvedDate() As DateTime
                Get
                    Return _resolvedDate
                End Get
                Set(ByVal Value As DateTime)
                    _resolvedDate = Value
                End Set
            End Property

            Private _engineerNotes As String = String.Empty
            Public ReadOnly Property EngineerNotes() As String
                Get
                    Return _engineerNotes
                End Get
            End Property
            Public WriteOnly Property SetEngineerNotes() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_engineerNotes", Value)
                End Set
            End Property

            Private _notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_notes", Value)
                End Set
            End Property

            Private _jobID As Integer = 0
            Public ReadOnly Property JobID() As Integer
                Get
                    Return _jobID
                End Get
            End Property
            Public WriteOnly Property SetJobID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_jobID", Value)
                End Set
            End Property

            Private _archive As Boolean = False
            Public ReadOnly Property Archive() As Boolean
                Get
                    Return _archive
                End Get
            End Property
            Public WriteOnly Property SetArchive() As Boolean
                Set(ByVal Value As Boolean)
                    _archive = Value
                End Set
            End Property
#End Region
        End Class

        Public Class FleetVanContract
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

#Region "Van Properties"

            Private _vanContractID As Integer = 0
            Public ReadOnly Property VanContractID() As Integer
                Get
                    Return _vanContractID
                End Get
            End Property
            Public WriteOnly Property SetVanContractID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanContractID", Value)
                End Set
            End Property

            Private _vanID As Integer = 0
            Public ReadOnly Property VanID() As Integer
                Get
                    Return _vanID
                End Get
            End Property
            Public WriteOnly Property SetVanID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_vanID", Value)
                End Set
            End Property

            Private _lessor As String = String.Empty
            Public ReadOnly Property Lessor() As String
                Get
                    Return _lessor
                End Get
            End Property
            Public WriteOnly Property SetLessor() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_lessor", Value)
                End Set
            End Property

            Private _procurementMethod As Integer = 0
            Public ReadOnly Property ProcurementMethod() As Integer
                Get
                    Return _procurementMethod
                End Get
            End Property
            Public WriteOnly Property SetProcurementMethod() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_procurementMethod", Value)
                End Set
            End Property

            Private _contractLength As Integer = 0
            Public ReadOnly Property ContractLength() As Integer
                Get
                    Return _contractLength
                End Get
            End Property
            Public WriteOnly Property SetContractLength() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_contractLength", Value)
                End Set
            End Property

            Private _contractStart As DateTime = Nothing
            Public Property ContractStart() As DateTime
                Get
                    Return _contractStart
                End Get
                Set(ByVal Value As DateTime)
                    _contractStart = Value
                End Set
            End Property

            Private _contractEnd As DateTime = Nothing
            Public Property ContractEnd() As DateTime
                Get
                    Return _contractEnd
                End Get
                Set(ByVal Value As DateTime)
                    _contractEnd = Value
                End Set
            End Property

            Private _contractMileage As Integer = 0
            Public ReadOnly Property ContractMileage() As Integer
                Get
                    Return _contractMileage
                End Get
            End Property
            Public WriteOnly Property SetContractMileage() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_contractMileage", Value)
                End Set
            End Property

            Private _startingMileage As Integer = 0
            Public ReadOnly Property StartingMileage() As Integer
                Get
                    Return _startingMileage
                End Get
            End Property
            Public WriteOnly Property SetStartingMileage() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_startingMileage", Value)
                End Set
            End Property

            Private _excessMileageRate As Double = 0
            Public ReadOnly Property ExcessMileageRate() As Double
                Get
                    Return _excessMileageRate
                End Get
            End Property
            Public WriteOnly Property SetExcessMileageRate() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_excessMileageRate", Value)
                End Set
            End Property

            Private _weeklyRental As Double = 0
            Public ReadOnly Property WeeklyRental() As Double
                Get
                    Return _weeklyRental
                End Get
            End Property
            Public WriteOnly Property SetWeeklyRental() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_weeklyRental", Value)
                End Set
            End Property

            Private _monthlyRental As Double = 0
            Public ReadOnly Property MonthlyRental() As Double
                Get
                    Return _monthlyRental
                End Get
            End Property
            Public WriteOnly Property SetMonthlyRental() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_monthlyRental", Value)
                End Set
            End Property

            Private _annualRental As Double = 0
            Public ReadOnly Property AnnualRental() As Double
                Get
                    Return _annualRental
                End Get
            End Property
            Public WriteOnly Property SetAnnualRental() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_annualRental", Value)
                End Set
            End Property

            Private _agreementRef As String = String.Empty
            Public ReadOnly Property AgreementRef() As String
                Get
                    Return _agreementRef
                End Get
            End Property
            Public WriteOnly Property SetAgreementRef() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_agreementRef", Value)
                End Set
            End Property

            Private _notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_notes", Value)
                End Set
            End Property
            Private _excessMileageCost As Double = 0
            Public ReadOnly Property ExcessMileageCost() As Double
                Get
                    Return _excessMileageCost
                End Get
            End Property
            Public WriteOnly Property SetExcessMileageCost() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_excessMileageCost", Value)
                End Set
            End Property

            Private _forecastExcessMileageCost As Double = 0
            Public ReadOnly Property ForecastExcessMileageCost() As Double
                Get
                    Return _forecastExcessMileageCost
                End Get
            End Property
            Public WriteOnly Property SetForecastExcessMileageCost() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_forecastExcessMileageCost", Value)
                End Set
            End Property
#End Region
        End Class

        Public Class FleetEquipment
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

#Region "Van Properties"

            Private _equipmentID As Integer = 0
            Public ReadOnly Property EquipmentID() As Integer
                Get
                    Return _equipmentID
                End Get
            End Property
            Public WriteOnly Property SetEquipmentID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_equipmentID", Value)
                End Set
            End Property

            Private _name As String = String.Empty
            Public ReadOnly Property Name() As String
                Get
                    Return _name
                End Get
            End Property
            Public WriteOnly Property SetName() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_name", Value)
                End Set
            End Property

            Private _description As String = String.Empty
            Public ReadOnly Property Description() As String
                Get
                    Return _description
                End Get
            End Property
            Public WriteOnly Property SetDescription() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_description", Value)
                End Set
            End Property

            Private _cost As Double = 0
            Public ReadOnly Property Cost() As Double
                Get
                    Return _cost
                End Get
            End Property
            Public WriteOnly Property SetCost() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_cost", Value)
                End Set
            End Property
#End Region
        End Class

    End Namespace

End Namespace