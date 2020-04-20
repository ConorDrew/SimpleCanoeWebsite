Imports System.Data.SqlClient

Namespace Entity

    Namespace JobAudits

        Public Class JobAudit
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

            Private _jobAuditID As Integer = 0
            Public ReadOnly Property JobAuditID() As Integer
                Get
                    Return _jobAuditID
                End Get
            End Property
            Public WriteOnly Property SetJobAuditID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_jobAuditID", Value)
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


            Private _actionChange As String = ""
            Public ReadOnly Property ActionChange() As String
                Get
                    Return _actionChange
                End Get
            End Property
            Public WriteOnly Property SetActionChange() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_actionChange", Value)
                End Set
            End Property




#End Region

        End Class

    End Namespace

End Namespace