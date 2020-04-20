Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOption3Sites

        Public Class QuoteContractOption3Site

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

#Region "QuoteContractOption3Site Properties"


            Private _QuoteContractSiteID As Integer = 0
            Public ReadOnly Property QuoteContractSiteID() As Integer
                Get
                    Return _QuoteContractSiteID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteID", Value)
                End Set
            End Property


            Private _QuoteContractID As Integer = 0
            Public ReadOnly Property QuoteContractID() As Integer
                Get
                    Return _QuoteContractID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractID", Value)
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


            Private _QuoteContractSiteReference As String = String.Empty
            Public ReadOnly Property QuoteContractSiteReference() As String
                Get
                    Return _QuoteContractSiteReference
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteReference", Value)
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



#End Region

        End Class

    End Namespace

End Namespace

