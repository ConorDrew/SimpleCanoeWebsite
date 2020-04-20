Namespace Entity.JobImport
    Public Class JobImport
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

#Region "Job Import Type Properties"
        Private _jobImportId As Integer = 0
        Public ReadOnly Property JobImportID() As Integer
            Get
                Return _jobImportId
            End Get
        End Property
        Public WriteOnly Property SetJobImportID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_jobImportId", Value)
            End Set
        End Property

        Private _siteId As Integer = 0
        Public ReadOnly Property SiteID() As Integer
            Get
                Return _siteId
            End Get
        End Property
        Public WriteOnly Property SetSiteID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_siteId", Value)
            End Set
        End Property

        Private _uprn As String = String.Empty
        Public ReadOnly Property UPRN() As String
            Get
                Return _uprn
            End Get
        End Property
        Public WriteOnly Property SetUPRN() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_uprn", Value)
            End Set
        End Property

        Private _jobImportTypeId As Integer = 0
        Public ReadOnly Property JobImportTypeID() As Integer
            Get
                Return _jobImportTypeId
            End Get
        End Property
        Public WriteOnly Property SetJobImportTypeID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_jobImportTypeId", Value)
            End Set
        End Property

        Private _dateAdded As DateTime = Nothing
        Public Property DateAdded() As DateTime
            Get
                Return _dateAdded
            End Get
            Set(ByVal Value As DateTime)
                _dateAdded = Value
            End Set
        End Property

        Private _jobId As Integer = 0
        Public ReadOnly Property JobID() As Integer
            Get
                Return _jobId
            End Get
        End Property
        Public WriteOnly Property SetJobID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_jobId", Value)
            End Set
        End Property

        Private _jobNumber As String = String.Empty
        Public ReadOnly Property JobNumber() As String
            Get
                Return _jobNumber
            End Get
        End Property
        Public WriteOnly Property SetJobNumber() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_jobNumber", Value)
            End Set
        End Property

        Private _status As Integer = 0
        Public ReadOnly Property Status() As Integer
            Get
                Return _status
            End Get
        End Property
        Public WriteOnly Property SetStatus() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_status", Value)
            End Set
        End Property

        Private _bookedVisit As DateTime = Nothing
        Public Property BookedVisit() As DateTime
            Get
                Return _bookedVisit
            End Get
            Set(ByVal Value As DateTime)
                _bookedVisit = Value
            End Set
        End Property

        Private _letter1 As DateTime = Nothing
        Public Property Letter1() As DateTime
            Get
                Return _letter1
            End Get
            Set(ByVal Value As DateTime)
                _letter1 = Value
            End Set
        End Property

        Private _letter2 As DateTime = Nothing
        Public Property Letter2() As DateTime
            Get
                Return _letter2
            End Get
            Set(ByVal Value As DateTime)
                _letter2 = Value
            End Set
        End Property

        Private _report As Boolean = False
        Public ReadOnly Property Report() As Boolean
            Get
                Return _report
            End Get
        End Property
        Public WriteOnly Property SetReport() As Boolean
            Set(ByVal Value As Boolean)
                _report = Value
            End Set
        End Property
#End Region
    End Class

    Public Class JobImportType
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

#Region "Job Import Type Properties"
        Private _jobImportTypeId As Integer = 0
        Public ReadOnly Property JobImportTypeID() As Integer
            Get
                Return _jobImportTypeId
            End Get
        End Property
        Public WriteOnly Property SetJobImportTypeID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_jobImportTypeId", Value)
            End Set
        End Property

        Private _name As String = String.Empty
        Public ReadOnly Property Name() As String
            Get
                Return _name
            End Get
        End Property
        Public WriteOnly Property SetName() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_name", Value)
            End Set
        End Property

        Private _jobTypeID As Integer = 0
        Public ReadOnly Property JobTypeID() As Integer
            Get
                Return _jobTypeID
            End Get
        End Property
        Public WriteOnly Property SetJobTypeID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_jobTypeID", Value)
            End Set
        End Property

        Private _jobTypeName As String = String.Empty
        Public ReadOnly Property JobTypeName() As String
            Get
                Return _jobTypeName
            End Get
        End Property
        Public WriteOnly Property SetJobTypeName() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_jobTypeName", Value)
            End Set
        End Property

        Private _engineerQualID As Integer = 0
        Public ReadOnly Property EngineerQualID() As Integer
            Get
                Return _engineerQualID
            End Get
        End Property
        Public WriteOnly Property SetEngineerQualID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_engineerQualID", Value)
            End Set
        End Property

        Private _cycle As Integer = 0
        Public ReadOnly Property Cycle() As Integer
            Get
                Return _cycle
            End Get
        End Property
        Public WriteOnly Property SetCycle() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_cycle", Value)
            End Set
        End Property
#End Region
    End Class
End Namespace
