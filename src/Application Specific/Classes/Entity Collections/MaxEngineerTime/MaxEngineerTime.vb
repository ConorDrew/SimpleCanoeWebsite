Imports System.Data.SqlClient

Namespace Entity

Namespace MaxEngineerTimes

Public Class MaxEngineerTime

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

#Region "MaxEngineerTime Properties"

      
Private _MaxEngineerTimeID As Integer = 0
Public Readonly Property MaxEngineerTimeID() As Integer
	Get 
		Return _MaxEngineerTimeID
	End Get	
End Property	
Public Writeonly Property SetMaxEngineerTimeID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_MaxEngineerTimeID", Value)
	End Set
End Property


Private _EngineerID As Integer = 0
Public Readonly Property EngineerID() As Integer
	Get 
		Return _EngineerID
	End Get	
End Property	
Public Writeonly Property SetEngineerID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_EngineerID", Value)
	End Set
End Property


Private _MondayValue As Integer = 0
Public Readonly Property MondayValue() As Integer
	Get 
		Return _MondayValue
	End Get	
End Property	
Public Writeonly Property SetMondayValue() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_MondayValue", Value)
	End Set
End Property


Private _TuesdayValue As Integer = 0
Public Readonly Property TuesdayValue() As Integer
	Get 
		Return _TuesdayValue
	End Get	
End Property	
Public Writeonly Property SetTuesdayValue() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_TuesdayValue", Value)
	End Set
End Property


Private _WednesdayValue As Integer = 0
Public Readonly Property WednesdayValue() As Integer
	Get 
		Return _WednesdayValue
	End Get	
End Property	
Public Writeonly Property SetWednesdayValue() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_WednesdayValue", Value)
	End Set
End Property


Private _ThursdayValue As Integer = 0
Public Readonly Property ThursdayValue() As Integer
	Get 
		Return _ThursdayValue
	End Get	
End Property	
Public Writeonly Property SetThursdayValue() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_ThursdayValue", Value)
	End Set
End Property


Private _FridayValue As Integer = 0
Public Readonly Property FridayValue() As Integer
	Get 
		Return _FridayValue
	End Get	
End Property	
Public Writeonly Property SetFridayValue() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_FridayValue", Value)
	End Set
End Property


Private _SaturdayValue As Integer = 0
Public Readonly Property SaturdayValue() As Integer
	Get 
		Return _SaturdayValue
	End Get	
End Property	
Public Writeonly Property SetSaturdayValue() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_SaturdayValue", Value)
	End Set
End Property


Private _SundayValue As Integer = 0
Public Readonly Property SundayValue() As Integer
	Get 
		Return _SundayValue
	End Get	
End Property	
Public Writeonly Property SetSundayValue() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_SundayValue", Value)
	End Set
End Property


  
#End Region

End Class

End Namespace

End Namespace

