Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteJobAssets

        Public Class QuoteJobAsset

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

#End Region

#Region "QuoteJobAsset Properties"


            Private _QuoteJobAssetID As Integer = 0
            Public ReadOnly Property QuoteJobAssetID() As Integer
                Get
                    Return _QuoteJobAssetID
                End Get
            End Property
            Public WriteOnly Property SetQuoteJobAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteJobAssetID", Value)
                End Set
            End Property


            Private _QuoteJobID As Integer = 0
            Public ReadOnly Property QuoteJobID() As Integer
                Get
                    Return _QuoteJobID
                End Get
            End Property
            Public WriteOnly Property SetQuoteJobID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteJobID", Value)
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

