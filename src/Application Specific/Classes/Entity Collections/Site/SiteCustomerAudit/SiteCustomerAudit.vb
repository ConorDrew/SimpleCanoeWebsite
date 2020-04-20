Imports System.Data.SqlClient

Namespace Entity

    Namespace SiteCustomerAudits

        Public Class SiteCustomerAudit

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

#Region "SiteCustomerAudit Properties"


            Private _SiteCustomerAuditID As Integer = 0
            Public ReadOnly Property SiteCustomerAuditID() As Integer
                Get
                    Return _SiteCustomerAuditID
                End Get
            End Property
            Public WriteOnly Property SetSiteCustomerAuditID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SiteCustomerAuditID", Value)
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


            Private _PreviousCustomerID As Integer = 0
            Public ReadOnly Property PreviousCustomerID() As Integer
                Get
                    Return _PreviousCustomerID
                End Get
            End Property
            Public WriteOnly Property SetPreviousCustomerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PreviousCustomerID", Value)
                End Set
            End Property


            Private _DateChanged As DateTime = Nothing
            Public Property DateChanged() As DateTime
                Get
                    Return _DateChanged
                End Get
                Set(ByVal Value As DateTime)
                    _DateChanged = Value
                End Set
            End Property

            Private _userID As Integer = 0
            Public ReadOnly Property UserID() As Integer
                Get
                    Return _userID
                End Get
            End Property
            Public WriteOnly Property SetUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_userID", Value)
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

