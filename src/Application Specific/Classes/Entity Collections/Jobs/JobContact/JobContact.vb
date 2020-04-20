Imports System.Data.SqlClient

Namespace Entity

    Namespace JobContacts

        Public Class JobContact
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

#End Region

#Region "Job Audit Properties"

            Private _jobContactID As Integer = 0
            Public ReadOnly Property jobContactID() As Integer
                Get
                    Return _jobContactID
                End Get
            End Property
            Public WriteOnly Property SetjobContactID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_jobContactID", Value)
                End Set
            End Property


            Private _jobID As Integer = 0
            Public ReadOnly Property JobID() As Integer
                Get
                    Return _jobID
                End Get
            End Property
            Public WriteOnly Property SetJobID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_jobID", Value)
                End Set
            End Property


            Private _contactType As String = ""
            Public ReadOnly Property contactType() As String
                Get
                    Return _contactType
                End Get
            End Property
            Public WriteOnly Property SetcontactType() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_contactType", Value)
                End Set
            End Property

            Private _dateActioned As DateTime = DateTime.MinValue
            Public Property dateActioned() As DateTime
                Get
                    Return _dateActioned
                End Get
                Set(ByVal Value As DateTime)
                    _dateActioned = Value
                End Set
            End Property


#End Region

        End Class

    End Namespace

End Namespace