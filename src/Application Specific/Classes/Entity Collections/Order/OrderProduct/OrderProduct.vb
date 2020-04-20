Imports System.Data.SqlClient

Namespace Entity

Namespace OrderProducts

Public Class OrderProduct

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

#Region "OrderProduct Properties"

      
Private _OrderProductID As Integer = 0
Public Readonly Property OrderProductID() As Integer
	Get 
		Return _OrderProductID
	End Get	
End Property	
Public Writeonly Property SetOrderProductID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_OrderProductID", Value)
	End Set
End Property


Private _ProductSupplierID As Integer = 0
Public Readonly Property ProductSupplierID() As Integer
	Get 
		Return _ProductSupplierID
	End Get	
End Property	
Public Writeonly Property SetProductSupplierID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_ProductSupplierID", Value)
	End Set
End Property


Private _Quantity As Integer = 0
Public Readonly Property Quantity() As Integer
	Get 
		Return _Quantity
	End Get	
End Property	
Public Writeonly Property SetQuantity() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Quantity", Value)
	End Set
End Property

            Private _QuantityReceived As Integer = 0
            Public ReadOnly Property QuantityReceived() As Integer
                Get
                    Return _QuantityReceived
                End Get
            End Property
            Public WriteOnly Property SetQuantityReceived() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuantityReceived", Value)
                End Set
            End Property

            Private _BuyPrice As Double = 0
            Public ReadOnly Property BuyPrice() As Double
                Get
                    Return _BuyPrice
                End Get
            End Property
            Public WriteOnly Property SetBuyPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BuyPrice", Value)
                End Set
            End Property

            Private _SellPrice As Double = 0
            Public ReadOnly Property SellPrice() As Double
                Get
                    Return _SellPrice
                End Get
            End Property
            Public WriteOnly Property SetSellPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SellPrice", Value)
                End Set
            End Property


            Private _OrderID As Integer = 0
            Public ReadOnly Property OrderID() As Integer
                Get
                    Return _OrderID
                End Get
            End Property
            Public WriteOnly Property SetOrderID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderID", Value)
                End Set
            End Property

            Private _DispatchSiteID As Integer = 0
            Public ReadOnly Property DispatchSiteID() As Integer
                Get
                    Return _DispatchSiteID
                End Get
            End Property
            Public WriteOnly Property SetDispatchSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DispatchSiteID", Value)
                End Set
            End Property

            Private _DispatchWarehouseID As Integer = 0
            Public ReadOnly Property DispatchWarehouseID() As Integer
                Get
                    Return _DispatchWarehouseID
                End Get
            End Property
            Public WriteOnly Property SetDispatchWarehouseID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DispatchWarehouseID", Value)
                End Set
            End Property




#End Region

End Class

End Namespace

End Namespace

