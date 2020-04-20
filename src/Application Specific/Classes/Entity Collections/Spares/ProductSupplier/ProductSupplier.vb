Imports System.Data.SqlClient

Namespace Entity

Namespace ProductSuppliers

Public Class ProductSupplier

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

#Region "ProductSupplier Properties"

      
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


Private _ProductID As Integer = 0
Public Readonly Property ProductID() As Integer
	Get 
		Return _ProductID
	End Get	
End Property	
Public Writeonly Property SetProductID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_ProductID", Value)
	End Set
End Property


Private _SupplierID As Integer = 0
Public Readonly Property SupplierID() As Integer
	Get 
		Return _SupplierID
	End Get	
End Property	
Public Writeonly Property SetSupplierID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_SupplierID", Value)
	End Set
End Property


Private _ProductCode As String = String.Empty
Public Readonly Property ProductCode() As String
	Get 
		Return _ProductCode
	End Get	
End Property	
Public Writeonly Property SetProductCode() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_ProductCode", Value)
	End Set
End Property


Private _Price As Double = 0
Public Readonly Property Price() As Double
	Get 
		Return _Price
	End Get	
End Property	
Public Writeonly Property SetPrice() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Price", Value)
	End Set
            End Property


            Private _QuantityInPack As Double = 0
            Public ReadOnly Property QuantityInPack() As Double
                Get
                    Return _QuantityInPack
                End Get
            End Property
            Public WriteOnly Property SetQuantityInPack() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuantityInPack", Value)
                End Set
            End Property


#End Region

End Class

End Namespace

End Namespace

