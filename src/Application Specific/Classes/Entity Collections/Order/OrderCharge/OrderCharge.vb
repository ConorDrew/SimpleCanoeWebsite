Imports System.Data.SqlClient

Namespace Entity

Namespace OrderCharges

Public Class OrderCharge

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

#Region "OrderCharge Properties"

      
Private _OrderChargeID As Integer = 0
Public Readonly Property OrderChargeID() As Integer
	Get 
		Return _OrderChargeID
	End Get	
End Property	
Public Writeonly Property SetOrderChargeID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_OrderChargeID", Value)
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


Private _OrderChargeTypeID As Integer = 0
Public Readonly Property OrderChargeTypeID() As Integer
	Get 
		Return _OrderChargeTypeID
	End Get	
End Property	
Public Writeonly Property SetOrderChargeTypeID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_OrderChargeTypeID", Value)
	End Set
End Property


Private _Amount As Double = 0
Public Readonly Property Amount() As Double
	Get 
		Return _Amount
	End Get	
End Property	
Public Writeonly Property SetAmount() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Amount", Value)
	End Set
End Property


Private _Reference As String = String.Empty
Public Readonly Property Reference() As String
	Get 
		Return _Reference
	End Get	
End Property	
Public Writeonly Property SetReference() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Reference", Value)
	End Set
End Property


  
#End Region

End Class

End Namespace

End Namespace

