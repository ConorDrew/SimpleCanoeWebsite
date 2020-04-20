Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOriginalSites

        Public Class QuoteContractOriginalSite

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

#Region "QuoteContractSite Properties"


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


            Private _PricePerVisit As Double = 0
            Public ReadOnly Property PricePerVisit() As Double
                Get
                    Return _PricePerVisit
                End Get
            End Property
            Public WriteOnly Property SetPricePerVisit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PricePerVisit", Value)
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


            Private _VisitDuration As Integer = 0
            Public ReadOnly Property VisitDuration() As Integer
                Get
                    Return _VisitDuration
                End Get
            End Property
            Public WriteOnly Property SetVisitDuration() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitDuration", Value)
                End Set
            End Property


            Private _IncludeAssetPrice As Boolean = False
            Public ReadOnly Property IncludeAssetPrice() As Boolean
                Get
                    Return _IncludeAssetPrice
                End Get
            End Property
            Public WriteOnly Property SetIncludeAssetPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_IncludeAssetPrice", Value)
                End Set
            End Property


            Private _AverageMileage As Double = 0
            Public ReadOnly Property AverageMileage() As Double
                Get
                    Return _AverageMileage
                End Get
            End Property
            Public WriteOnly Property SetAverageMileage() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AverageMileage", Value)
                End Set
            End Property


            Private _PricePerMile As Double = 0
            Public ReadOnly Property PricePerMile() As Double
                Get
                    Return _PricePerMile
                End Get
            End Property
            Public WriteOnly Property SetPricePerMile() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PricePerMile", Value)
                End Set
            End Property


            Private _IncludeMileagePrice As Boolean = False
            Public ReadOnly Property IncludeMileagePrice() As Boolean
                Get
                    Return _IncludeMileagePrice
                End Get
            End Property
            Public WriteOnly Property SetIncludeMileagePrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_IncludeMileagePrice", Value)
                End Set
            End Property


            Private _IncludeRates As Boolean = False
            Public ReadOnly Property IncludeRates() As Boolean
                Get
                    Return _IncludeRates
                End Get
            End Property
            Public WriteOnly Property SetIncludeRates() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_IncludeRates", Value)
                End Set
            End Property


            Private _TotalSitePrice As Double = 0
            Public ReadOnly Property TotalSitePrice() As Double
                Get
                    Return _TotalSitePrice
                End Get
            End Property
            Public WriteOnly Property SetTotalSitePrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TotalSitePrice", Value)
                End Set
            End Property


            Private _ContractSiteScheduleOfRates As DataView
            Public Property ContractSiteScheduleOfRates() As DataView
                Get
                    Return _ContractSiteScheduleOfRates
                End Get
                Set(ByVal Value As DataView)
                    _ContractSiteScheduleOfRates = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

