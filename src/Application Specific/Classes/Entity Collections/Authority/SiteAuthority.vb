Imports System.Data.SqlClient
Imports System.Reflection

Namespace Entity

    Namespace Authority

        Public Class SiteAuthority

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

#Region "Property Properties"

            Private _siteAuthorityID As Integer = 0
            Public ReadOnly Property SiteAuthorityID() As Integer
                Get
                    Return _siteAuthorityID
                End Get
            End Property
            Public WriteOnly Property SetSiteAuthorityID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_siteAuthorityID", Value)
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

            Private _authorityID As Integer = 0
            Public ReadOnly Property AuthorityID() As Integer
                Get
                    Return _authorityID
                End Get
            End Property
            Public WriteOnly Property SetAuthorityID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_authorityID", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

