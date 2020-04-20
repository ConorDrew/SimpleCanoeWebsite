Imports System.Data.SqlClient

Namespace Entity

Namespace Locationss

Public Class Locations

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

#Region "Locations Properties"

      
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


Private _VanID As Integer = 0
Public Readonly Property VanID() As Integer
	Get 
		Return _VanID
	End Get	
End Property	
Public Writeonly Property SetVanID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_VanID", Value)
	End Set
End Property


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


  
#End Region

End Class

End Namespace

End Namespace

