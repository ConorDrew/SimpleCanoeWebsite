Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractAlternativeSites

        Public Class ContractAlternativeSite

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

#Region "ContractSite Properties"


            Private _ContractSiteID As Integer = 0
            Public ReadOnly Property ContractSiteID() As Integer
                Get
                    Return _ContractSiteID
                End Get
            End Property
            Public WriteOnly Property SetContractSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractSiteID", Value)
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

            Private _jobOfWorks As New ArrayList
            Public Property JobOfWorks() As ArrayList
                Get
                    Return _jobOfWorks
                End Get
                Set(ByVal Value As ArrayList)
                    _jobOfWorks = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

