Imports System.Data.SqlClient

Namespace Entity

    Namespace Products

        Public Class Product

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

#Region "Product Properties"


            Private _ProductID As Integer = 0
            Public ReadOnly Property ProductID() As Integer
                Get
                    Return _ProductID
                End Get
            End Property
            Public WriteOnly Property SetProductID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ProductID", Value)
                End Set
            End Property


            Private _Number As String = String.Empty
            Public ReadOnly Property Number() As String
                Get
                    Return _Number
                End Get
            End Property
            Public WriteOnly Property SetNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Number", Value)
                End Set
            End Property


            Private _Reference As String = String.Empty
            Public ReadOnly Property Reference() As String
                Get
                    Return _Reference
                End Get
            End Property
            Public WriteOnly Property SetReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Reference", Value)
                End Set
            End Property


            Private _Name As String = String.Empty
            Public ReadOnly Property Name() As String
                Get
                    Return _Name
                End Get
            End Property
            Public WriteOnly Property SetName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Name", Value)
                End Set
            End Property


            Private _TypeID As Integer = 0
            Public ReadOnly Property TypeID() As Integer
                Get
                    Return _TypeID
                End Get
            End Property
            Public WriteOnly Property SetTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TypeID", Value)
                End Set
            End Property


            Private _MakeID As Integer = 0
            Public ReadOnly Property MakeID() As Integer
                Get
                    Return _MakeID
                End Get
            End Property
            Public WriteOnly Property SetMakeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MakeID", Value)
                End Set
            End Property


            Private _ModelID As Integer = 0
            Public ReadOnly Property ModelID() As Integer
                Get
                    Return _ModelID
                End Get
            End Property
            Public WriteOnly Property SetModelID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ModelID", Value)
                End Set
            End Property


            Private _sellPrice As Double = 0
            Public ReadOnly Property SellPrice() As Double
                Get
                    Return _sellPrice
                End Get
            End Property
            Public WriteOnly Property SetSellPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_sellPrice", Value)
                End Set
            End Property


            Private _Notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _Notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Notes", Value)
                End Set
            End Property


            Private _MinimumQuantity As Integer = 0
            Public ReadOnly Property MinimumQuantity() As Integer
                Get
                    Return _MinimumQuantity
                End Get
            End Property
            Public WriteOnly Property SetMinimumQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MinimumQuantity", Value)
                End Set
            End Property


            Private _RecommendedQuantity As Integer = 0
            Public ReadOnly Property RecommendedQuantity() As Integer
                Get
                    Return _RecommendedQuantity
                End Get
            End Property
            Public WriteOnly Property SetRecommendedQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RecommendedQuantity", Value)
                End Set
            End Property

            Private _AssociatedPart As New DataView
            Public Property AssociatedPart() As DataView
                Get
                    Return _AssociatedPart
                End Get
                Set(ByVal Value As DataView)
                    _AssociatedPart = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

