Imports System.Data.SqlClient

Namespace Entity

Namespace SiteOrders

Public Class SiteOrder

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

#Region "SiteOrder Properties"

      
Private _SiteOrderID As Integer = 0
Public Readonly Property SiteOrderID() As Integer
	Get 
		Return _SiteOrderID
	End Get	
End Property	
Public Writeonly Property SetSiteOrderID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_SiteOrderID", Value)
	End Set
End Property


Private _SiteID As Integer = 0
Public Readonly Property SiteID() As Integer
	Get 
		Return _SiteID
	End Get	
End Property	
Public Writeonly Property SetSiteID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_SiteID", Value)
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


  
#End Region

End Class

End Namespace

End Namespace

