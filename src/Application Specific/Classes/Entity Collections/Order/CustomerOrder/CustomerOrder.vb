Imports System.Data.SqlClient

Namespace Entity

Namespace CustomerOrders

Public Class CustomerOrder

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

#Region "CustomerOrder Properties"

      
Private _CustomerOrderID As Integer = 0
Public Readonly Property CustomerOrderID() As Integer
	Get 
		Return _CustomerOrderID
	End Get	
End Property	
Public Writeonly Property SetCustomerOrderID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_CustomerOrderID", Value)
	End Set
End Property


Private _OrderID As Integer = 0
Public Readonly Property OrderID() As Integer
	Get 
		Return _OrderID
	End Get	
End Property	
Public Writeonly Property SetOrderID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_OrderID", Value)
	End Set
End Property


Private _CustomerID As Integer = 0
Public Readonly Property CustomerID() As Integer
	Get 
		Return _CustomerID
	End Get	
End Property	
Public Writeonly Property SetCustomerID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_CustomerID", Value)
	End Set
End Property


  
#End Region

End Class

End Namespace

End Namespace

