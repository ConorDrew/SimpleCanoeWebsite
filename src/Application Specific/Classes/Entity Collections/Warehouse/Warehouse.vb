Imports System.Data.SqlClient

Namespace Entity

Namespace Warehouses

Public Class Warehouse

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

#Region "Warehouse Properties"

      
Private _WarehouseID As Integer = 0
Public Readonly Property WarehouseID() As Integer
	Get 
		Return _WarehouseID
	End Get	
End Property	
Public Writeonly Property SetWarehouseID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_WarehouseID", Value)
	End Set
End Property


Private _Name As String = String.Empty
Public Readonly Property Name() As String
	Get 
		Return _Name
	End Get	
End Property	
Public Writeonly Property SetName() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Name", Value)
	End Set
End Property


Private _Size As String = String.Empty
Public Readonly Property Size() As String
	Get 
		Return _Size
	End Get	
End Property	
Public Writeonly Property SetSize() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Size", Value)
	End Set
End Property


Private _Notes As String = String.Empty
Public Readonly Property Notes() As String
	Get 
		Return _Notes
	End Get	
End Property	
Public Writeonly Property SetNotes() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Notes", Value)
	End Set
End Property


Private _Address1 As String = String.Empty
Public Readonly Property Address1() As String
	Get 
		Return _Address1
	End Get	
End Property	
Public Writeonly Property SetAddress1() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Address1", Value)
	End Set
End Property


Private _Address2 As String = String.Empty
Public Readonly Property Address2() As String
	Get 
		Return _Address2
	End Get	
End Property	
Public Writeonly Property SetAddress2() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Address2", Value)
	End Set
End Property


Private _Address3 As String = String.Empty
Public Readonly Property Address3() As String
	Get 
		Return _Address3
	End Get	
End Property	
Public Writeonly Property SetAddress3() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Address3", Value)
	End Set
End Property


Private _Address4 As String = String.Empty
Public Readonly Property Address4() As String
	Get 
		Return _Address4
	End Get	
End Property	
Public Writeonly Property SetAddress4() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Address4", Value)
	End Set
End Property


Private _Address5 As String = String.Empty
Public Readonly Property Address5() As String
	Get 
		Return _Address5
	End Get	
End Property	
Public Writeonly Property SetAddress5() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Address5", Value)
	End Set
End Property


Private _Postcode As String = String.Empty
Public Readonly Property Postcode() As String
	Get 
		Return _Postcode
	End Get	
End Property	
Public Writeonly Property SetPostcode() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Postcode", Value)
	End Set
End Property


Private _TelephoneNum As String = String.Empty
Public Readonly Property TelephoneNum() As String
	Get 
		Return _TelephoneNum
	End Get	
End Property	
Public Writeonly Property SetTelephoneNum() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_TelephoneNum", Value)
	End Set
End Property


Private _FaxNum As String = String.Empty
Public Readonly Property FaxNum() As String
	Get 
		Return _FaxNum
	End Get	
End Property	
Public Writeonly Property SetFaxNum() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_FaxNum", Value)
	End Set
End Property


Private _EmailAddress As String = String.Empty
Public Readonly Property EmailAddress() As String
	Get 
		Return _EmailAddress
	End Get	
End Property	
Public Writeonly Property SetEmailAddress() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_EmailAddress", Value)
	End Set
End Property


Private _Active As Boolean = False
Public Readonly Property Active() As Boolean
	Get 
		Return _Active
	End Get	
End Property	
Public Writeonly Property SetActive() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Active", Value)
	End Set
End Property


  
#End Region

End Class

End Namespace

End Namespace

