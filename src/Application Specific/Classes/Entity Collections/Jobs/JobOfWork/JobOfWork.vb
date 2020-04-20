Imports System.Data.SqlClient

Namespace Entity

    Namespace JobOfWorks

        Public Class JobOfWork

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

#Region "JobOfWork Properties"

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

            Private _PONumber As String

            Public ReadOnly Property PONumber() As String
                Get
                    Return _PONumber
                End Get
            End Property

            Public WriteOnly Property SetPONumber() As Object
                Set(ByVal value As Object)
                    _dataTypeValidator.SetValue(Me, "_PONumber", value)
                End Set
            End Property

            Private _Priority As Integer = 0

            Public ReadOnly Property Priority() As Integer
                Get
                    Return _Priority
                End Get
            End Property

            Public WriteOnly Property SetPriority() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Priority", Value)
                End Set
            End Property

            Private _Status As Integer = 1 ' Open

            Public ReadOnly Property Status() As Integer
                Get
                    Return _Status
                End Get
            End Property

            Public WriteOnly Property SetStatus() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Status", Value)
                End Set
            End Property

            Private _PriorityDateSet As DateTime = Nothing

            Public Property PriorityDateSet() As DateTime
                Get
                    Return _PriorityDateSet
                End Get
                Set(ByVal Value As DateTime)
                    _PriorityDateSet = Value
                End Set
            End Property

            Private _qualificationId As Integer = 0

            Public ReadOnly Property QualificationID() As Integer
                Get
                    Return _qualificationId
                End Get
            End Property

            Public WriteOnly Property SetQualificationID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_qualificationId", Value)
                End Set
            End Property

#End Region

#Region "Additional Properties"

            Private _jobItems As New ArrayList

            Public Property JobItems() As ArrayList
                Get
                    Return _jobItems
                End Get
                Set(ByVal Value As ArrayList)
                    _jobItems = Value
                End Set
            End Property

            Private _engineerVisits As New ArrayList

            Public Property EngineerVisits() As ArrayList
                Get
                    Return _engineerVisits
                End Get
                Set(ByVal Value As ArrayList)
                    _engineerVisits = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace