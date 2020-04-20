Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOriginalSiteAssets

        Public Class ContractOriginalSiteAsset

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


            Private _ContractSiteAssetID As Integer = 0
            Public ReadOnly Property ContractSiteAssetID() As Integer
                Get
                    Return _ContractSiteAssetID
                End Get
            End Property
            Public WriteOnly Property SetContractSiteAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractSiteAssetID", Value)
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


            Private _PrimaryAsset As Boolean = 0
            Public ReadOnly Property PrimaryAsset() As Boolean
                Get
                    Return _PrimaryAsset
                End Get
            End Property
            Public WriteOnly Property SetPrimaryAsset() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PrimaryAsset", Value)
                End Set
            End Property


            Private _Type As String = ""
            Public ReadOnly Property Type() As String
                Get
                    Return _Type
                End Get
            End Property
            Public WriteOnly Property SetType() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Type", Value)
                End Set
            End Property

            Private _Product As String = ""
            Public ReadOnly Property Product() As String
                Get
                    Return _Product
                End Get
            End Property
            Public WriteOnly Property SetProduct() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Product", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

