Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOption3Sites

        Public Class ContractOption3Site

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

#Region "ContractOption3Site Properties"


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


            Private _ContractSiteReference As String = String.Empty
            Public ReadOnly Property ContractSiteReference() As String
                Get
                    Return _ContractSiteReference
                End Get
            End Property
            Public WriteOnly Property SetContractSiteReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractSiteReference", Value)
                End Set
            End Property


            Private _StartDate As DateTime = Nothing
            Public Property StartDate() As DateTime
                Get
                    Return _StartDate
                End Get
                Set(ByVal Value As DateTime)
                    _StartDate = Value
                End Set
            End Property


            Private _EndDate As DateTime = Nothing
            Public Property EndDate() As DateTime
                Get
                    Return _EndDate
                End Get
                Set(ByVal Value As DateTime)
                    _EndDate = Value
                End Set
            End Property


            Private _FirstVisitDate As DateTime = Nothing
            Public Property FirstVisitDate() As DateTime
                Get
                    Return _FirstVisitDate
                End Get
                Set(ByVal Value As DateTime)
                    _FirstVisitDate = Value
                End Set
            End Property


            Private _VisitFrequencyID As Integer = 0
            Public ReadOnly Property VisitFrequencyID() As Integer
                Get
                    Return _VisitFrequencyID
                End Get
            End Property
            Public WriteOnly Property SetVisitFrequencyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitFrequencyID", Value)
                End Set
            End Property


            Private _InvoiceFrequencyID As Integer = 0
            Public ReadOnly Property InvoiceFrequencyID() As Integer
                Get
                    Return _InvoiceFrequencyID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceFrequencyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceFrequencyID", Value)
                End Set
            End Property


            Private _SitePrice As Double = 0
            Public ReadOnly Property SitePrice() As Double
                Get
                    Return _SitePrice
                End Get
            End Property
            Public WriteOnly Property SetSitePrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SitePrice", Value)
                End Set
            End Property


            Private _FirstInvoiceDate As DateTime
            Public Property FirstInvoiceDate() As DateTime
                Get
                    Return _FirstInvoiceDate
                End Get
                Set(ByVal Value As DateTime)
                    _FirstInvoiceDate = Value
                End Set
            End Property

            Private _InvoiceAddressTypeID As Integer
            Public ReadOnly Property InvoiceAddressTypeID() As Integer
                Get
                    Return _InvoiceAddressTypeID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceAddressTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceAddressTypeID", Value)
                End Set
            End Property


            Private _InvoiceAddressID As Integer = 0
            Public ReadOnly Property InvoiceAddressID() As Integer
                Get
                    Return _InvoiceAddressID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceAddressID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceAddressID", Value)
                End Set
            End Property


#End Region

        End Class

    End Namespace

End Namespace

