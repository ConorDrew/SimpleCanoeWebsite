Imports System.Data.SqlClient

Namespace Entity

Namespace EngineerLevels

Public Class EngineerLevel

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

#Region "EngineerLevel Properties"

      
Private _EngineerLevelID As Integer = 0
Public Readonly Property EngineerLevelID() As Integer
	Get 
		Return _EngineerLevelID
	End Get	
End Property	
Public Writeonly Property SetEngineerLevelID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_EngineerLevelID", Value)
	End Set
End Property


Private _LevelID As Integer = 0
Public Readonly Property LevelID() As Integer
	Get 
		Return _LevelID
	End Get	
End Property	
Public Writeonly Property SetLevelID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_LevelID", Value)
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


  
#End Region

End Class

End Namespace

End Namespace

