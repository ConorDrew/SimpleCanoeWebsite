Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOriginalSites

        Public Class ContractOriginalSite

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


            Private _FirstVisitDate As DateTime = Nothing
            Public Property FirstVisitDate() As DateTime
                Get
                    Return _FirstVisitDate
                End Get
                Set(ByVal Value As DateTime)
                    _FirstVisitDate = Value
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

            Private _LLCertReqd As Boolean = False
            Public ReadOnly Property LLCertReqd() As Boolean
                Get
                    Return _LLCertReqd
                End Get
            End Property
            Public WriteOnly Property SetLLCertReqd() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LLCertReqd", Value)
                End Set
            End Property

            Private _AdditionalNotes As String = String.Empty
            Public ReadOnly Property AdditionalNotes() As String
                Get
                    Return _AdditionalNotes
                End Get
            End Property
            Public WriteOnly Property SetAdditionalNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AdditionalNotes", Value)
                End Set
            End Property

            Private _Commercial As Boolean = False
            Public ReadOnly Property Commercial() As Boolean
                Get
                    Return _Commercial
                End Get
            End Property
            Public WriteOnly Property SetCommercial() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Commercial", Value)
                End Set
            End Property

            Private _MainAppliances As Integer = 0
            Public ReadOnly Property MainAppliances() As Integer
                Get
                    Return _MainAppliances
                End Get
            End Property
            Public WriteOnly Property SetMainAppliances() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MainAppliances", Value)
                End Set
            End Property

            Private _SecondryAppliances As Integer = 0
            Public ReadOnly Property SecondryAppliances() As Integer
                Get
                    Return _SecondryAppliances
                End Get
            End Property
            Public WriteOnly Property SetSecondryAppliances() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SecondryAppliances", Value)
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

