Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternativeSiteAssets

        Public Class QuoteContractAlternativeSiteAsset

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

#End Region

#Region "ContractSiteAsset Properties"


            Private _QuoteContractSiteAssetID As Integer = 0
            Public ReadOnly Property ContractSiteAssetID() As Integer
                Get
                    Return _QuoteContractSiteAssetID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteAssetID", Value)
                End Set
            End Property


            Private _QuoteContractSiteJobItemID As Integer = 0
            Public ReadOnly Property QuoteContractSiteJobItemID() As Integer
                Get
                    Return _QuoteContractSiteJobItemID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteJobItemID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteJobItemID", Value)
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

#End Region

        End Class

    End Namespace

End Namespace

