Imports System.Data.SqlClient

Namespace Entity

Namespace SubTasks

Public Class SubTask

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

#Region "SubTask Properties"

      
Private _SubTaskID As Integer = 0
Public Readonly Property SubTaskID() As Integer
	Get 
		Return _SubTaskID
	End Get	
End Property	
Public Writeonly Property SetSubTaskID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_SubTaskID", Value)
	End Set
End Property


Private _TaskID As Integer = 0
Public Readonly Property TaskID() As Integer
	Get 
		Return _TaskID
	End Get	
End Property	
Public Writeonly Property SetTaskID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_TaskID", Value)
	End Set
End Property


Private _Description As String = String.Empty
Public Readonly Property Description() As String
	Get 
		Return _Description
	End Get	
End Property	
Public Writeonly Property SetDescription() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Description", Value)
	End Set
End Property


Private _OrderNumber As Integer = 0
Public Readonly Property OrderNumber() As Integer
	Get 
		Return _OrderNumber
	End Get	
End Property	
Public Writeonly Property SetOrderNumber() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_OrderNumber", Value)
	End Set
End Property


  
#End Region

End Class

End Namespace

End Namespace

