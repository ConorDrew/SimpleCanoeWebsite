Imports System.Data.SqlClient

Namespace Entity

    Namespace JobAssets

        Public Class JobAsset

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

#Region "JobAsset Properties"


            Private _JobAssetID As Integer = 0
            Public ReadOnly Property JobAssetID() As Integer
                Get
                    Return _JobAssetID
                End Get
            End Property
            Public WriteOnly Property SetJobAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobAssetID", Value)
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

