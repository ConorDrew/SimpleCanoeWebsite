Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOriginalSiteAssets

        Public Class QuoteContractOriginalSiteAsset

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

#Region "QuoteContractSiteAsset Properties"


            Private _QuoteContractSiteAssetID As Integer = 0
            Public ReadOnly Property QuoteContractSiteAssetID() As Integer
                Get
                    Return _QuoteContractSiteAssetID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteAssetID", Value)
                End Set
            End Property


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


            Private _AssetID As Integer = 0
            Public ReadOnly Property AssetID() As Integer
                Get
                    Return _AssetID
                End Get
            End Property
            Public WriteOnly Property SetAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AssetID", Value)
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



#End Region

        End Class

    End Namespace

End Namespace

