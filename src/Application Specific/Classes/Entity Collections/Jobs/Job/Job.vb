Namespace Entity

    Namespace Jobs

        Public Class Job

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

#Region "Job Properties"

            Private _JobID As Integer = 0

            Public ReadOnly Property JobID() As Integer
                Get
                    Return _JobID
                End Get
            End Property

            Public WriteOnly Property SetJobID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobID", Value)
                End Set
            End Property

            Private _PropertyID As Integer = 0

            Public ReadOnly Property PropertyID() As Integer
                Get
                    Return _PropertyID
                End Get
            End Property

            Public WriteOnly Property SetPropertyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PropertyID", Value)
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

            Private _JobNumber As String = String.Empty

            Public ReadOnly Property JobNumber() As String
                Get
                    Return _JobNumber
                End Get
            End Property

            Public WriteOnly Property SetJobNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobNumber", Value)
                End Set
            End Property

            Private _PONumber As String = String.Empty

            Public ReadOnly Property PONumber() As String
                Get
                    Return _PONumber
                End Get
            End Property

            Public WriteOnly Property SetPONumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PONumber", Value)
                End Set
            End Property

            Private _QuoteID As Integer = 0

            Public ReadOnly Property QuoteID() As Integer
                Get
                    Return _QuoteID
                End Get
            End Property

            Public WriteOnly Property SetQuoteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteID", Value)
                End Set
            End Property

            Private _ContractID As Integer = 0

            Public ReadOnly Property ContractID() As Integer
                Get
                    Return _ContractID
                End Get
            End Property

            Public WriteOnly Property SetContractID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractID", Value)
                End Set
            End Property

            Private _ToBePartPaid As Boolean = False

            Public ReadOnly Property ToBePartPaid() As Boolean
                Get
                    Return _ToBePartPaid
                End Get
            End Property

            Public WriteOnly Property SetToBePartPaid() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ToBePartPaid", Value)
                End Set
            End Property

            Private _retention As Double = 0

            Public ReadOnly Property Retention() As Double
                Get
                    Return _retention
                End Get
            End Property

            Public WriteOnly Property SetRetention() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_retention", Value)
                End Set
            End Property

            Private _CollectPayment As Boolean = 0

            Public ReadOnly Property CollectPayment() As Boolean
                Get
                    Return _CollectPayment
                End Get
            End Property

            Public WriteOnly Property SetCollectPayment() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CollectPayment", Value)
                End Set
            End Property

            Private _POC As Boolean = False

            Public ReadOnly Property POC() As Boolean
                Get
                    Return _POC
                End Get
            End Property

            Public WriteOnly Property SetPOC() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_POC", Value)
                End Set
            End Property

            Private _OTI As Boolean = False

            Public ReadOnly Property OTI() As Boolean
                Get
                    Return _OTI
                End Get
            End Property

            Public WriteOnly Property SetOTI() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OTI", Value)
                End Set
            End Property

            Private _fOC As Boolean = False

            Public ReadOnly Property FOC() As Boolean
                Get
                    Return _fOC
                End Get
            End Property

            Public WriteOnly Property SetFOC() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_fOC", Value)
                End Set
            End Property

            Private _salesRepUserID As Integer = 0

            Public ReadOnly Property SalesRepUserID() As Integer
                Get
                    Return _salesRepUserID
                End Get
            End Property

            Public WriteOnly Property SetSalesRepUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_salesRepUserID", Value)
                End Set
            End Property

            Private _jobCreationType As Integer = 0

            Public ReadOnly Property JobCreationType() As Integer
                Get
                    Return _jobCreationType
                End Get
            End Property

            Public WriteOnly Property SetJobCreationType() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_jobCreationType", Value)
                End Set
            End Property

            Private _Headline As String = String.Empty

            Public ReadOnly Property Headline() As String
                Get
                    Return _Headline
                End Get
            End Property

            Public WriteOnly Property SetHeadline() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Headline", Value)
                End Set
            End Property

#End Region

#Region "Additional Properties"

            Private _assets As New ArrayList

            Public Property Assets() As ArrayList
                Get
                    Return _assets
                End Get
                Set(ByVal Value As ArrayList)
                    _assets = Value
                End Set
            End Property

            Private _jobOfWorks As New ArrayList

            Public Property JobOfWorks() As ArrayList
                Get
                    Return _jobOfWorks
                End Get
                Set(ByVal Value As ArrayList)
                    _jobOfWorks = Value
                End Set
            End Property

            Private _JobQualificationsLevels As New DataView

            Public Property JobQualificationsLevels() As DataView
                Get
                    Return _JobQualificationsLevels
                End Get
                Set(ByVal Value As DataView)
                    _JobQualificationsLevels = Value
                    _JobQualificationsLevels.AllowEdit = True
                    _JobQualificationsLevels.AllowNew = False
                    _JobQualificationsLevels.AllowDelete = False
                End Set
            End Property

            Private _JobSheets As New DataView

            Public Property JobSheets() As DataView
                Get
                    Return _JobSheets
                End Get
                Set(ByVal Value As DataView)
                    _JobSheets = Value
                    _JobSheets.AllowEdit = True
                    _JobSheets.AllowNew = False
                    _JobSheets.AllowDelete = False
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace