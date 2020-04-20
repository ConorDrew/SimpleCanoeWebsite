Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOption3SitePPMVisits

        Public Class ContractOption3SitePPMVisit

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

#Region "ContractOption3SitePPMVisit Properties"


            Private _ContractSitePPMVisitID As Integer = 0
            Public ReadOnly Property ContractSitePPMVisitID() As Integer
                Get
                    Return _ContractSitePPMVisitID
                End Get
            End Property
            Public WriteOnly Property SetContractSitePPMVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractSitePPMVisitID", Value)
                End Set
            End Property


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


            Private _VisitDate As DateTime = Nothing
            Public Property VisitDate() As DateTime
                Get
                    Return _VisitDate
                End Get
                Set(ByVal Value As DateTime)
                    _VisitDate = Value
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



#End Region

        End Class

    End Namespace

End Namespace

