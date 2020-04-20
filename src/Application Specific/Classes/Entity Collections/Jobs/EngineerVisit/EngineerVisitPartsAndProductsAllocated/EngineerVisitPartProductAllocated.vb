Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitPartProductAllocateds

        Public Class EngineerVisitPartProductAllocated

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

#Region "EngineerVisitPartProductAllocated Properties"

            Private _Type As String = String.Empty
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

            Private _ID As Integer = 0
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public WriteOnly Property SetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ID", Value)
                End Set
            End Property

            Private _EngineerVisitID As Integer = 0
            Public ReadOnly Property EngineerVisitID() As Integer
                Get
                    Return _EngineerVisitID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitID", Value)
                End Set
            End Property


            Private _PartProductID As Integer = 0
            Public ReadOnly Property PartProductID() As Integer
                Get
                    Return _PartProductID
                End Get
            End Property
            Public WriteOnly Property SetPartProductID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartProductID", Value)
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

            Private _Quantity As Integer = 0
            Public ReadOnly Property Quantity() As Integer
                Get
                    Return _Quantity
                End Get
            End Property
            Public WriteOnly Property SetQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Quantity", Value)
                End Set
            End Property


            Private _orderItemID As Integer = 0
            Public ReadOnly Property OrderItemID() As Integer
                Get
                    Return _orderItemID
                End Get
            End Property
            Public WriteOnly Property SetOrderItemID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_orderItemID", Value)
                End Set
            End Property


            Private _orderLocationTypeID As Integer = 0
            Public ReadOnly Property OrderLocationTypeID() As Integer
                Get
                    Return _orderLocationTypeID
                End Get
            End Property
            Public WriteOnly Property SetOrderLocationTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_orderLocationTypeID", Value)
                End Set
            End Property


            'THIS ISN'T IN THE TABLE - IT MAY NOT NEED TO BE HERE! -A L P
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


#End Region

        End Class

    End Namespace

End Namespace

