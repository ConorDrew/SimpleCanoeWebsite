Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteJobs

        Public Class QuoteJob

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

#Region "QuoteJob Properties"

            Private _QuoteJobID As Integer = 0

            Public ReadOnly Property QuoteJobID() As Integer
                Get
                    Return _QuoteJobID
                End Get
            End Property

            Public WriteOnly Property SetQuoteJobID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteJobID", Value)
                End Set
            End Property

            Private _SiteID As Integer = 0

            Public ReadOnly Property SiteID() As Integer
                Get
                    Return _SiteID
                End Get
            End Property

            Public WriteOnly Property SetSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SiteID", Value)
                End Set
            End Property

            Private _Reference As String = String.Empty

            Public ReadOnly Property Reference() As String
                Get
                    Return _Reference
                End Get
            End Property

            Public WriteOnly Property SetReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Reference", Value)
                End Set
            End Property

            Private _JobDefinitionEnumID As Integer = 0

            Public ReadOnly Property JobDefinitionEnumID() As Integer
                Get
                    Return _JobDefinitionEnumID
                End Get
            End Property

            Public WriteOnly Property SetJobDefinitionEnumID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobDefinitionEnumID", Value)
                End Set
            End Property

            Private _JobTypeID As Integer = 0

            Public ReadOnly Property JobTypeID() As Integer
                Get
                    Return _JobTypeID
                End Get
            End Property

            Public WriteOnly Property SetJobTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobTypeID", Value)
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

            Private _DateCreated As DateTime = Nothing

            Public Property DateCreated() As DateTime
                Get
                    Return _DateCreated
                End Get
                Set(ByVal Value As DateTime)
                    _DateCreated = Value
                End Set
            End Property

            Private _CreatedByUserID As Integer = 0

            Public ReadOnly Property CreatedByUserID() As Integer
                Get
                    Return _CreatedByUserID
                End Get
            End Property

            Public WriteOnly Property SetCreatedByUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CreatedByUserID", Value)
                End Set
            End Property

            Private _PartsAndProductsTotal As Decimal = 0

            Public ReadOnly Property PartsAndProductsTotal() As Decimal
                Get
                    Return _PartsAndProductsTotal
                End Get
            End Property

            Public WriteOnly Property SetPartsAndProductsTotal() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsAndProductsTotal", Value)
                End Set
            End Property

            Private _PartsAndProductsMarkup As Decimal = 0

            Public ReadOnly Property PartsAndProductsMarkup() As Decimal
                Get
                    Return _PartsAndProductsMarkup
                End Get
            End Property

            Public WriteOnly Property SetPartsAndProductsMarkup() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsAndProductsMarkup", Value)
                End Set
            End Property

            Private _ScheduleOfRatesTotal As Decimal = 0

            Public ReadOnly Property ScheduleOfRatesTotal() As Decimal
                Get
                    Return _ScheduleOfRatesTotal
                End Get
            End Property

            Public WriteOnly Property SetScheduleOfRatesTotal() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ScheduleOfRatesTotal", Value)
                End Set
            End Property

            Private _ScheduleOfRatesMarkup As Decimal = 0

            Public ReadOnly Property ScheduleOfRatesMarkup() As Decimal
                Get
                    Return _ScheduleOfRatesMarkup
                End Get
            End Property

            Public WriteOnly Property SetScheduleOfRatesMarkup() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ScheduleOfRatesMarkup", Value)
                End Set
            End Property

            Private _EstimatedMileage As Decimal = 0

            Public ReadOnly Property EstimatedMileage() As Decimal
                Get
                    Return _EstimatedMileage
                End Get
            End Property

            Public WriteOnly Property SetEstimatedMileage() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EstimatedMileage", Value)
                End Set
            End Property

            Private _MileageRate As Decimal = 1

            Public ReadOnly Property MileageRate() As Decimal
                Get
                    Return _MileageRate
                End Get
            End Property

            Public WriteOnly Property SetMileageRate() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MileageRate", Value)
                End Set
            End Property

            Private _GrandTotal As Decimal = 0

            Public ReadOnly Property GrandTotal() As Decimal
                Get
                    Return _GrandTotal
                End Get
            End Property

            Public WriteOnly Property SetGrandTotal() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GrandTotal", Value)
                End Set
            End Property

            Private _ReasonForReject As String = String.Empty

            Public ReadOnly Property ReasonForReject() As String
                Get
                    Return _ReasonForReject
                End Get
            End Property

            Public WriteOnly Property SetReasonForReject() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonForReject", Value)
                End Set
            End Property

            Private _ReasonForRejectID As Integer = 0

            Public ReadOnly Property ReasonForRejectID() As Integer
                Get
                    Return _ReasonForRejectID
                End Get
            End Property

            Public WriteOnly Property SetReasonForRejectID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonForRejectID", Value)
                End Set
            End Property

            Private _NotesToEngineer As String = ""

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

            Private _NotesToElectrician As String = ""

            Public ReadOnly Property NotesToElectrician() As String
                Get
                    Return _NotesToElectrician
                End Get
            End Property

            Public WriteOnly Property SetNotesToElectrician() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NotesToElectrician", Value)
                End Set
            End Property

            Private _NotesToBuilder As String = ""

            Public ReadOnly Property NotesToBuilder() As String
                Get
                    Return _NotesToBuilder
                End Get
            End Property

            Public WriteOnly Property SetNotesToBuilder() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NotesToBuilder", Value)
                End Set
            End Property

            Private _EngineerLabourHrs As Double = 0

            Public ReadOnly Property EngineerLabourHrs() As Double
                Get
                    Return _EngineerLabourHrs
                End Get
            End Property

            Public WriteOnly Property SetEngineerLabourHrs() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerLabourHrs", Value)
                End Set
            End Property

            Private _ElectricianLabourHrs As Double = 0

            Public ReadOnly Property ElectricianLabourHrs() As Double
                Get
                    Return _ElectricianLabourHrs
                End Get
            End Property

            Public WriteOnly Property SetElectricianLabourHrs() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ElectricianLabourHrs", Value)
                End Set
            End Property

            Private _BuilderLabourHrs As Double = 0

            Public ReadOnly Property BuilderLabourHrs() As Double
                Get
                    Return _BuilderLabourHrs
                End Get
            End Property

            Public WriteOnly Property SetBuilderLabourHrs() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BuilderLabourHrs", Value)
                End Set
            End Property

            Private _EngineerMarkUp As Double = 0

            Public ReadOnly Property EngineerMarkUp() As Double
                Get
                    Return _EngineerMarkUp
                End Get
            End Property

            Public WriteOnly Property SetEngineerMarkUp() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerMarkUp", Value)
                End Set
            End Property

            Private _ElectricianMarkUp As Double = 0

            Public ReadOnly Property ElectricianMarkUp() As Double
                Get
                    Return _ElectricianMarkUp
                End Get
            End Property

            Public WriteOnly Property SetElectricianMarkUp() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ElectricianMarkUp", Value)
                End Set
            End Property

            Private _BuilderMarkUp As Double = 0

            Public ReadOnly Property BuilderMarkUp() As Double
                Get
                    Return _BuilderMarkUp
                End Get
            End Property

            Public WriteOnly Property SetBuilderMarkUp() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BuilderMarkUp", Value)
                End Set
            End Property

            Private _ElectricianArrivalDayNo As Integer = 0

            Public ReadOnly Property ElectricianArrivalDayNo() As Integer
                Get
                    Return _ElectricianArrivalDayNo
                End Get
            End Property

            Public WriteOnly Property SetElectricianArrivalDayNo() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ElectricianArrivalDayNo", Value)
                End Set
            End Property

            Private _ElectricianArrivalHour As Integer = 0

            Public ReadOnly Property ElectricianArrivalHour() As Integer
                Get
                    Return _ElectricianArrivalHour
                End Get
            End Property

            Public WriteOnly Property SetElectricianArrivalHour() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ElectricianArrivalHour", Value)
                End Set
            End Property

            Private _BuilderArrivalDayNo As Integer = 0

            Public ReadOnly Property BuilderArrivalDayNo() As Integer
                Get
                    Return _BuilderArrivalDayNo
                End Get
            End Property

            Public WriteOnly Property SetBuilderArrivalDayNo() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BuilderArrivalDayNo", Value)
                End Set
            End Property

            Private _BuilderArrivalHour As Integer = 0

            Public ReadOnly Property BuilderArrivalHour() As Integer
                Get
                    Return _BuilderArrivalHour
                End Get
            End Property

            Public WriteOnly Property SetBuilderArrivalHour() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BuilderArrivalHour", Value)
                End Set
            End Property

            Private _PartsCost As Double = 0

            Public ReadOnly Property PartsCost() As Double
                Get
                    Return _PartsCost
                End Get
            End Property

            Public WriteOnly Property SetPartsCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsCost", Value)
                End Set
            End Property

            Private _EngineerCost As Double = 0

            Public ReadOnly Property EngineerCost() As Double
                Get
                    Return _EngineerCost
                End Get
            End Property

            Public WriteOnly Property SetEngineerCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerCost", Value)
                End Set
            End Property

            Private _BuilderCost As Double = 0

            Public ReadOnly Property BuilderCost() As Double
                Get
                    Return _BuilderCost
                End Get
            End Property

            Public WriteOnly Property SetBuilderCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BuilderCost", Value)
                End Set
            End Property

            Private _ElectricianCost As Double = 0

            Public ReadOnly Property ElectricianCost() As Double
                Get
                    Return _ElectricianCost
                End Get
            End Property

            Public WriteOnly Property SetElectricianCost() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ElectricianCost", Value)
                End Set
            End Property

            Private _QuotedAmount As Double = 0

            Public ReadOnly Property QuotedAmount() As Double
                Get
                    Return _QuotedAmount
                End Get
            End Property

            Public WriteOnly Property SetQuotedAmount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuotedAmount", Value)
                End Set
            End Property

            Private _DepositAmount As Double = 0

            Public ReadOnly Property DepositAmount() As Double
                Get
                    Return _DepositAmount
                End Get
            End Property

            Public WriteOnly Property SetDepositAmount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DepositAmount", Value)
                End Set
            End Property

            Private _VatRateID As Integer = 0

            Public ReadOnly Property VatRateID() As Integer
                Get
                    Return _VatRateID
                End Get
            End Property

            Public WriteOnly Property SetVatRateID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VatRateID", Value)
                End Set
            End Property

            Private _SORCharge As Double = 0

            Public ReadOnly Property SORCharge() As Double
                Get
                    Return _SORCharge
                End Get
            End Property

            Public WriteOnly Property SetSORCharge() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SORCharge", Value)
                End Set
            End Property

            Private _AdditionalCosts As Double = 0

            Public ReadOnly Property AdditionalCosts() As Double
                Get
                    Return _AdditionalCosts
                End Get
            End Property

            Public WriteOnly Property SetAdditionalCosts() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AdditionalCosts", Value)
                End Set
            End Property

            Private _ChangedDateTime As DateTime = Nothing

            Public Property ChangedDateTime() As DateTime
                Get
                    Return _ChangedDateTime
                End Get
                Set(ByVal Value As DateTime)
                    _ChangedDateTime = Value
                End Set
            End Property

            Private _ChangedByUserID As Integer = 0

            Public ReadOnly Property ChangedByUserID() As Integer
                Get
                    Return _ChangedByUserID
                End Get
            End Property

            Public WriteOnly Property SetChangedByUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ChangedByUserID", Value)
                End Set
            End Property

            Private _OriginalQuotedAmount As Double = 0

            Public ReadOnly Property OriginalQuotedAmount() As Double
                Get
                    Return _OriginalQuotedAmount
                End Get
            End Property

            Public WriteOnly Property SetOriginalQuotedAmount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OriginalQuotedAmount", Value)
                End Set
            End Property

            Private _ElectricianPackTypeID As Integer = 0

            Public ReadOnly Property ElectricianPackTypeID() As Integer
                Get
                    Return _ElectricianPackTypeID
                End Get
            End Property

            Public WriteOnly Property SetElectricianPackTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ElectricianPackTypeID", Value)
                End Set
            End Property

            Private _AccessEquipmentID As Integer = 0

            Public ReadOnly Property AccessEquipmentID() As Integer
                Get
                    Return _AccessEquipmentID
                End Get
            End Property

            Public WriteOnly Property SetAccessEquipmentID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AccessEquipmentID", Value)
                End Set
            End Property

            Private _AsbestosID As Integer = 0

            Public ReadOnly Property AsbestosID() As Integer
                Get
                    Return _AsbestosID
                End Get
            End Property

            Public WriteOnly Property SetAsbestosID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AsbestosID", Value)
                End Set
            End Property

            Private _AsbestosComment As String = ""

            Public ReadOnly Property AsbestosComment() As String
                Get
                    Return _AsbestosComment
                End Get
            End Property

            Public WriteOnly Property SetAsbestosComment() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AsbestosComment", Value)
                End Set
            End Property

            Private _EstStartDate As DateTime = Date.MinValue

            Public Property EstStartDate() As DateTime
                Get
                    Return _EstStartDate
                End Get
                Set(ByVal Value As DateTime)
                    _EstStartDate = Value
                End Set
            End Property

            Private _SurveyVisitID As Integer = 0

            Public ReadOnly Property SurveyVisitID() As Integer
                Get
                    Return _SurveyVisitID
                End Get
            End Property

            Public WriteOnly Property SetSurveyVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SurveyVisitID", Value)
                End Set
            End Property

            Private _department As String = ""

            Public ReadOnly Property Department() As String
                Get
                    Return _department
                End Get
            End Property

            Public WriteOnly Property SetDepartment() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_department", Value)
                End Set
            End Property

#End Region

#Region "Additional Properties"

            Private _QuoteAssets As New ArrayList

            Public Property QuoteAssets() As ArrayList
                Get
                    Return _QuoteAssets
                End Get
                Set(ByVal Value As ArrayList)
                    _QuoteAssets = Value
                End Set
            End Property

            Private _QuoteJobOfWorks As New ArrayList

            Public Property QuoteJobOfWorks() As ArrayList
                Get
                    Return _QuoteJobOfWorks
                End Get
                Set(ByVal Value As ArrayList)
                    _QuoteJobOfWorks = Value
                End Set
            End Property

            Private _QuoteJobPartsAndProducts As New DataView

            Public Property QuoteJobPartsAndProducts() As DataView
                Get
                    Return _QuoteJobPartsAndProducts
                End Get
                Set(ByVal Value As DataView)
                    _QuoteJobPartsAndProducts = Value
                End Set
            End Property

            Private _ScheduleOfRates As DataView

            Public Property ScheduleOfRates() As DataView
                Get
                    Return _ScheduleOfRates
                End Get
                Set(ByVal Value As DataView)
                    _ScheduleOfRates = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace