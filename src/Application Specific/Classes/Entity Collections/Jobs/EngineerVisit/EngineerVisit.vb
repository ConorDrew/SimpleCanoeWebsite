Namespace Entity

    Namespace EngineerVisits

        Public Class EngineerVisit

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

#Region "EngineerVisit Properties"

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

            Private _JobOfWorkID As Integer = 0

            Public ReadOnly Property JobOfWorkID() As Integer
                Get
                    Return _JobOfWorkID
                End Get
            End Property

            Public WriteOnly Property SetJobOfWorkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobOfWorkID", Value)
                End Set
            End Property

            Private _AppointmentID As Integer = 0

            Public ReadOnly Property AppointmentID() As Integer
                Get
                    Return _AppointmentID
                End Get
            End Property

            Public WriteOnly Property SetAppointmentID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AppointmentID", Value)
                End Set
            End Property

            Private _EngineerID As Integer = 0

            Public ReadOnly Property EngineerID() As Integer
                Get
                    Return _EngineerID
                End Get
            End Property

            Public WriteOnly Property SetEngineerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerID", Value)
                End Set
            End Property

            Private _StartDateTime As DateTime = DateTime.MinValue

            Public Property StartDateTime() As DateTime
                Get
                    Return _StartDateTime
                End Get
                Set(ByVal Value As DateTime)
                    _StartDateTime = Value
                End Set
            End Property

            Private _EndDateTime As DateTime = DateTime.MinValue

            Public Property EndDateTime() As DateTime
                Get
                    Return _EndDateTime
                End Get
                Set(ByVal Value As DateTime)
                    _EndDateTime = Value
                End Set
            End Property

            Private _StatusEnumID As Integer = 0

            Public ReadOnly Property StatusEnumID() As Integer
                Get
                    Return _StatusEnumID
                End Get
            End Property

            Public WriteOnly Property SetStatusEnumID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_StatusEnumID", Value)
                End Set
            End Property

            Private _NotesToEngineer As String = String.Empty

            Public ReadOnly Property NotesToEngineer() As String
                Get
                    Return _NotesToEngineer
                End Get
            End Property

            Public WriteOnly Property SetNotesToEngineer() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NotesToEngineer", Value)
                End Set
            End Property

            Private _NotesFromEngineer As String = String.Empty

            Public ReadOnly Property NotesFromEngineer() As String
                Get
                    Return _NotesFromEngineer
                End Get
            End Property

            Public WriteOnly Property SetNotesFromEngineer() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NotesFromEngineer", Value)
                End Set
            End Property

            Private _OutcomeEnumID As Integer = 0

            Public ReadOnly Property OutcomeEnumID() As Integer
                Get
                    Return _OutcomeEnumID
                End Get
            End Property

            Public WriteOnly Property SetOutcomeEnumID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OutcomeEnumID", Value)
                End Set
            End Property

            Private _OutcomeDetails As String = String.Empty

            Public ReadOnly Property OutcomeDetails() As String
                Get
                    Return _OutcomeDetails
                End Get
            End Property

            Public WriteOnly Property SetOutcomeDetails() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OutcomeDetails", Value)
                End Set
            End Property

            Private _VisitOutcome As String = String.Empty

            Public ReadOnly Property VisitOutcome() As String
                Get
                    Return _VisitOutcome
                End Get
            End Property

            Public WriteOnly Property SetVisitOutcome() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitOutcome", Value)
                End Set
            End Property

            Private _CustomerName As String = String.Empty

            Public ReadOnly Property CustomerName() As String
                Get
                    Return _CustomerName
                End Get
            End Property

            Public WriteOnly Property SetCustomerName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CustomerName", Value)
                End Set
            End Property

            Private _CustomerSignature As Byte() = Nothing

            Public Property CustomerSignature() As Byte()
                Get
                    Return _CustomerSignature
                End Get
                Set(ByVal value As Byte())
                    _CustomerSignature = value
                End Set
            End Property

            Private _EngineerSignature As Byte() = Nothing

            Public Property EngineerSignature() As Byte()

                Get
                    Return _EngineerSignature
                End Get
                Set(ByVal value As Byte())
                    _EngineerSignature = value
                End Set
            End Property

            'Private _CustomerSignature As String = String.Empty
            'Public ReadOnly Property CustomerSignature() As String
            '    Get
            '        Return _CustomerSignature
            '    End Get
            'End Property
            'Public WriteOnly Property SetCustomerSignature() As Object
            '    Set(ByVal Value As Object)
            '        _dataTypeValidator.SetValue(Me, "_CustomerSignature", Value)
            '    End Set
            'End Property

            'Private _EngineerSignature As String = String.Empty
            'Public ReadOnly Property EngineerSignature() As String
            '    Get
            '        Return _EngineerSignature
            '    End Get
            'End Property
            'Public WriteOnly Property SetEngineerSignature() As Object
            '    Set(ByVal Value As Object)
            '        _dataTypeValidator.SetValue(Me, "_EngineerSignature", Value)
            '    End Set
            'End Property

            Private _ManualEntryByUserID As Integer = 0

            Public ReadOnly Property ManualEntryByUserID() As Integer
                Get
                    Return _ManualEntryByUserID
                End Get
            End Property

            Public WriteOnly Property SetManualEntryByUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ManualEntryByUserID", Value)
                End Set
            End Property

            Private _ManualEntryOn As DateTime = DateTime.MinValue

            Public Property ManualEntryOn() As DateTime
                Get
                    Return _ManualEntryOn
                End Get
                Set(ByVal Value As DateTime)
                    _ManualEntryOn = Value
                End Set
            End Property

            Private _PartsAndProductsUsed As New DataView

            Public Property PartsAndProductsUsed() As DataView
                Get
                    Return _PartsAndProductsUsed
                End Get
                Set(ByVal Value As DataView)
                    _PartsAndProductsUsed = Value
                End Set
            End Property

            Private _TimeSheets As New DataView

            Public Property TimeSheets() As DataView
                Get
                    Return _TimeSheets
                End Get
                Set(ByVal Value As DataView)
                    _TimeSheets = Value
                End Set
            End Property

            Private _Photos As New DataView

            Public Property Photos() As DataView
                Get
                    Return _Photos
                End Get
                Set(ByVal Value As DataView)
                    _Photos = Value
                End Set
            End Property

            Private _visitLocked As Boolean = False

            Public ReadOnly Property VisitLocked() As Boolean
                Get
                    Return _visitLocked
                End Get
            End Property

            Public WriteOnly Property SetVisitLocked() As Boolean
                Set(ByVal Value As Boolean)
                    _visitLocked = Value
                End Set
            End Property

            Private _PartsAndProductsAllocated As New DataView

            Public Property PartsAndProductsAllocated() As DataView
                Get
                    Return _PartsAndProductsAllocated
                End Get
                Set(ByVal Value As DataView)
                    _PartsAndProductsAllocated = Value
                End Set
            End Property

            Private _GasInstallationTightnessTestID As Integer

            Public ReadOnly Property GasInstallationTightnessTestID() As Integer
                Get
                    Return _GasInstallationTightnessTestID
                End Get
            End Property

            Public WriteOnly Property SetGasInstallationTightnessTestID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GasInstallationTightnessTestID", Value)
                End Set
            End Property

            Private _PaymentMethodID As Integer

            Public ReadOnly Property PaymentMethodID() As Integer
                Get
                    Return _PaymentMethodID
                End Get
            End Property

            Public WriteOnly Property SetPaymentMethodID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PaymentMethodID", Value)
                End Set
            End Property

            Private _AmountCollected As Double

            Public ReadOnly Property AmountCollected() As Double
                Get
                    Return _AmountCollected
                End Get
            End Property

            Public WriteOnly Property SetAmountCollected() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AmountCollected", Value)
                End Set
            End Property

            Private _EmergencyControlAccessibleID As Integer

            Public ReadOnly Property EmergencyControlAccessibleID() As Integer
                Get
                    Return _EmergencyControlAccessibleID
                End Get
            End Property

            Public WriteOnly Property SetEmergencyControlAccessibleID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EmergencyControlAccessibleID", Value)
                End Set
            End Property

            Private _BondingID As Integer

            Public ReadOnly Property BondingID() As Integer
                Get
                    Return _BondingID
                End Get
            End Property

            Public WriteOnly Property SetBondingID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BondingID", Value)
                End Set
            End Property

            Private _PropertyRented As Integer

            Public ReadOnly Property PropertyRented() As Integer
                Get
                    Return _PropertyRented
                End Get
            End Property

            Public WriteOnly Property SetPropertyRented() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PropertyRented", Value)
                End Set
            End Property

            Private _SignatureSelectedID As Integer

            Public ReadOnly Property SignatureSelectedID() As Integer
                Get
                    Return _SignatureSelectedID
                End Get
            End Property

            Public WriteOnly Property SetSignatureSelectedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SignatureSelectedID", Value)
                End Set
            End Property

            Private _PartsToFit As Boolean = False

            Public ReadOnly Property PartsToFit() As Boolean
                Get
                    Return _PartsToFit
                End Get
            End Property

            Public WriteOnly Property SetPartsToFit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsToFit", Value)
                End Set
            End Property

            Private _GasServiceCompleted As Boolean = False

            Public ReadOnly Property GasServiceCompleted() As Boolean
                Get
                    Return _GasServiceCompleted
                End Get
            End Property

            Public WriteOnly Property SetGasServiceCompleted() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GasServiceCompleted", Value)
                End Set
            End Property

            Private _EmailReceipt As Boolean = False

            Public ReadOnly Property EmailReceipt() As Boolean
                Get
                    Return _EmailReceipt
                End Get
            End Property

            Public WriteOnly Property SetEmailReceipt() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EmailReceipt", Value)
                End Set
            End Property

            Private _UseSORDescription As Boolean = False

            Public ReadOnly Property UseSORDescription() As Boolean
                Get
                    Return _UseSORDescription
                End Get
            End Property

            Public WriteOnly Property SetUseSORDescription() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UseSORDescription", Value)
                End Set
            End Property

            Private _Downloading As DateTime

            Public Property Downloading() As DateTime
                Get
                    Return _Downloading
                End Get
                Set(ByVal value As DateTime)
                    _Downloading = value
                End Set
            End Property

            Private _ExpectedEngineerID As Integer = 0

            Public ReadOnly Property ExpectedEngineerID() As Integer
                Get
                    Return _ExpectedEngineerID
                End Get
            End Property

            Public WriteOnly Property SetExpectedEngineerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ExpectedEngineerID", Value)
                End Set
            End Property

            Private _DueDate As DateTime

            Public Property DueDate() As DateTime
                Get
                    Return _DueDate
                End Get
                Set(ByVal value As DateTime)
                    _DueDate = value
                End Set
            End Property

            Private _EstimatedDate As DateTime = Today

            Public Property EstimatedDate() As DateTime
                Get
                    Return _EstimatedDate
                End Get
                Set(ByVal value As DateTime)
                    _EstimatedDate = value
                End Set
            End Property

            Private _AMPM As String = String.Empty

            Public ReadOnly Property AMPM() As String
                Get
                    Return _AMPM
                End Get
            End Property

            Public WriteOnly Property SetAMPM() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AMPM", Value)
                End Set
            End Property

            Private _VisitNumber As Integer = 0

            Public ReadOnly Property VisitNumber() As Integer
                Get
                    Return _VisitNumber
                End Get
            End Property

            Public WriteOnly Property SetVisitNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitNumber", Value)
                End Set
            End Property

            Private _EngineerVisitNCCGSR As Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSR = Nothing

            Public Property EngineerVisitNCCGSR() As Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSR
                Get
                    Return _EngineerVisitNCCGSR
                End Get
                Set(ByVal value As Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSR)
                    _EngineerVisitNCCGSR = value
                End Set
            End Property

            Private _EngineerVisitSMOKE As Entity.EngineerVisitAdditionals.EngineerVisitAdditional = Nothing

            Public Property EngineerVisitSMOKE() As Entity.EngineerVisitAdditionals.EngineerVisitAdditional
                Get
                    Return _EngineerVisitSMOKE
                End Get
                Set(ByVal value As Entity.EngineerVisitAdditionals.EngineerVisitAdditional)
                    _EngineerVisitSMOKE = value
                End Set
            End Property

            Private _EngineerVisitCOMO As Entity.EngineerVisitAdditionals.EngineerVisitAdditional = Nothing

            Public Property EngineerVisitCOMO() As Entity.EngineerVisitAdditionals.EngineerVisitAdditional
                Get
                    Return _EngineerVisitCOMO
                End Get
                Set(ByVal value As Entity.EngineerVisitAdditionals.EngineerVisitAdditional)
                    _EngineerVisitCOMO = value
                End Set
            End Property

            Private _EngineerVisitAdditionalWorksheets As Entity.EngineerVisitAdditionals.EngineerVisitAdditional = Nothing

            Public Property EngineerVisitAdditionalWorksheets() As Entity.EngineerVisitAdditionals.EngineerVisitAdditional
                Get
                    Return _EngineerVisitAdditionalWorksheets
                End Get
                Set(ByVal value As Entity.EngineerVisitAdditionals.EngineerVisitAdditional)
                    _EngineerVisitAdditionalWorksheets = value
                End Set
            End Property

            Private _Recharge As Boolean = False

            Public ReadOnly Property Recharge() As Boolean
                Get
                    Return _Recharge
                End Get
            End Property

            Public WriteOnly Property SetRecharge() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Recharge", Value)
                End Set
            End Property

            Private _excludeFromTextMessage As Boolean = False

            Public ReadOnly Property ExcludeFromTextMessage() As Boolean
                Get
                    Return _excludeFromTextMessage
                End Get
            End Property

            Public WriteOnly Property SetExcludeFromTextMessage() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_excludeFromTextMessage", Value)
                End Set
            End Property

            Private _CostsTo As String = String.Empty

            Public ReadOnly Property CostsTo() As String
                Get
                    Return _CostsTo
                End Get
            End Property

            Public WriteOnly Property SetCostsTo() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CostsTo", Value)
                End Set
            End Property

            Private _RechargeTypeID As Integer

            Public ReadOnly Property RechargeTypeID() As Integer
                Get
                    Return _RechargeTypeID
                End Get
            End Property

            Public WriteOnly Property setRechargeTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RechargeTypeID", Value)
                End Set
            End Property

            Private _NccRadID As Integer

            Public ReadOnly Property NccRadID() As Integer
                Get
                    Return _NccRadID
                End Get
            End Property

            Public WriteOnly Property setNccRadID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NccRadID", Value)
                End Set
            End Property

            Private _Change As Boolean = False

            Public ReadOnly Property Change() As Boolean
                Get
                    Return _Change
                End Get
            End Property

            Public WriteOnly Property setChange() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Change", Value)
                End Set
            End Property

            Private _MeterCappedID As Integer

            Public ReadOnly Property MeterCappedID() As Integer
                Get
                    Return _MeterCappedID
                End Get
            End Property

            Public WriteOnly Property SetMeterCappedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MeterCappedID", Value)
                End Set
            End Property

            Private _MeterLocationID As Integer

            Public ReadOnly Property MeterLocationID() As Integer
                Get
                    Return _MeterLocationID
                End Get
            End Property

            Public WriteOnly Property SetMeterLocationID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MeterLocationID", Value)
                End Set
            End Property

            Private _ExpectedDepartment As String = String.Empty

            Public ReadOnly Property ExpectedDepartment() As String
                Get
                    Return _ExpectedDepartment
                End Get
            End Property

            Public WriteOnly Property SetExpectedDepartment() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ExpectedDepartment", Value)
                End Set
            End Property

            Private _visitStatus As String = String.Empty

            Public ReadOnly Property VisitStatus() As String
                Get
                    Return _visitStatus
                End Get
            End Property

            Public WriteOnly Property SetVisitStatus() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_visitStatus", Value)
                End Set
            End Property

            Private _FuelID As Integer = 0

            Public ReadOnly Property FuelID() As Integer
                Get
                    Return _FuelID
                End Get
            End Property

            Public WriteOnly Property SetFuelID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FuelID", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace