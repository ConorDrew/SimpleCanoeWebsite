Imports System.Data.SqlClient

Namespace Entity

Namespace EngineerVisitDefectss

Public Class EngineerVisitDefects

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

#Region "EngineerVisitDefects Properties"

      
Private _EngineerVisitDefectID As Integer = 0
Public Readonly Property EngineerVisitDefectID() As Integer
	Get 
		Return _EngineerVisitDefectID
	End Get	
End Property	
Public Writeonly Property SetEngineerVisitDefectID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_EngineerVisitDefectID", Value)
	End Set
End Property


Private _CategoryID As Integer = 0
Public Readonly Property CategoryID() As Integer
	Get 
		Return _CategoryID
	End Get	
End Property	
Public Writeonly Property SetCategoryID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_CategoryID", Value)
	End Set
End Property


Private _Reason As String = String.Empty
Public Readonly Property Reason() As String
	Get 
		Return _Reason
	End Get	
End Property	
Public Writeonly Property SetReason() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Reason", Value)
	End Set
End Property


Private _ActionTaken As String = String.Empty
Public Readonly Property ActionTaken() As String
	Get 
		Return _ActionTaken
	End Get	
End Property	
Public Writeonly Property SetActionTaken() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_ActionTaken", Value)
	End Set
End Property


Private _WarningNoticeIssued As Boolean = False
Public Readonly Property WarningNoticeIssued() As Boolean
	Get 
		Return _WarningNoticeIssued
	End Get	
End Property	
Public Writeonly Property SetWarningNoticeIssued() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_WarningNoticeIssued", Value)
	End Set
End Property


Private _Disconnected As Boolean = False
Public Readonly Property Disconnected() As Boolean
	Get 
		Return _Disconnected
	End Get	
End Property	
Public Writeonly Property SetDisconnected() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Disconnected", Value)
	End Set
End Property


Private _Comments As String = String.Empty
Public Readonly Property Comments() As String
	Get 
		Return _Comments
	End Get	
End Property	
Public Writeonly Property SetComments() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Comments", Value)
	End Set
End Property


Private _AssetID As Integer = 0
Public Readonly Property AssetID() As Integer
	Get 
		Return _AssetID
	End Get	
End Property	
Public Writeonly Property SetAssetID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_AssetID", Value)
	End Set
End Property


Private _EngineerVisitID As Integer = 0
Public Readonly Property EngineerVisitID() As Integer
	Get 
		Return _EngineerVisitID
	End Get	
End Property	
Public Writeonly Property SetEngineerVisitID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_EngineerVisitID", Value)
	End Set
End Property


  
#End Region

End Class

End Namespace

End Namespace

