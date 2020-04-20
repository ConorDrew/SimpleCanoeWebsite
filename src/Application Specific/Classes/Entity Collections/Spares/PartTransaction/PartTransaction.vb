Imports System.Data.SqlClient

Namespace Entity

Namespace PartTransactions

Public Class PartTransaction

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

#Region "PartTransaction Properties"

      
Private _PartTransactionID As Integer = 0
Public Readonly Property PartTransactionID() As Integer
	Get 
		Return _PartTransactionID
	End Get	
End Property	
Public Writeonly Property SetPartTransactionID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_PartTransactionID", Value)
	End Set
End Property


Private _PartID As Integer = 0
Public Readonly Property PartID() As Integer
	Get 
		Return _PartID
	End Get	
End Property	
Public Writeonly Property SetPartID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_PartID", Value)
	End Set
End Property


Private _Amount As Integer = 0
Public Readonly Property Amount() As Integer
	Get 
		Return _Amount
	End Get	
End Property	
Public Writeonly Property SetAmount() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Amount", Value)
	End Set
End Property


Private _TransactionDate As Datetime = Nothing
Public Property TransactionDate() As Datetime
	Get 
		Return _TransactionDate
	End Get
	Set (ByVal Value As Datetime)
		_TransactionDate = Value
	End Set
End Property	


Private _UserID As Integer = 0
Public Readonly Property UserID() As Integer
	Get 
		Return _UserID
	End Get	
End Property	
Public Writeonly Property SetUserID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_UserID", Value)
	End Set
End Property


Private _TransactionTypeID As Integer = 0
Public Readonly Property TransactionTypeID() As Integer
	Get 
		Return _TransactionTypeID
	End Get	
End Property	
Public Writeonly Property SetTransactionTypeID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_TransactionTypeID", Value)
	End Set
End Property


Private _LocationID As Integer = 0
Public Readonly Property LocationID() As Integer
	Get 
		Return _LocationID
	End Get	
End Property	
Public Writeonly Property SetLocationID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_LocationID", Value)
	End Set
End Property


Private _OrderPartID As Integer = 0
Public Readonly Property OrderPartID() As Integer
	Get 
		Return _OrderPartID
	End Get	
End Property	
Public Writeonly Property SetOrderPartID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_OrderPartID", Value)
	End Set
End Property


Private _OrderLocationPartID As Integer = 0
Public Readonly Property OrderLocationPartID() As Integer
	Get 
		Return _OrderLocationPartID
	End Get	
End Property	
Public Writeonly Property SetOrderLocationPartID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_OrderLocationPartID", Value)
	End Set
End Property


  
#End Region

End Class

End Namespace

End Namespace

