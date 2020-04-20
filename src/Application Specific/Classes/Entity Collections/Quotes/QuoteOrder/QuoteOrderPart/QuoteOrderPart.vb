Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteOrderParts

Public Class QuoteOrderPart

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

#Region "QuoteOrderPart Properties"

      
Private _QuoteOrderPartID As Integer = 0
Public Readonly Property QuoteOrderPartID() As Integer
	Get 
		Return _QuoteOrderPartID
	End Get	
End Property	
Public Writeonly Property SetQuoteOrderPartID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_QuoteOrderPartID", Value)
	End Set
End Property


Private _QuoteOrderID As Integer = 0
Public Readonly Property QuoteOrderID() As Integer
	Get 
		Return _QuoteOrderID
	End Get	
End Property	
Public Writeonly Property SetQuoteOrderID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_QuoteOrderID", Value)
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

            Private _Quantity As Integer = 0
            Public ReadOnly Property Quantity() As Integer
                Get
                    Return _Quantity
                End Get
            End Property
            Public WriteOnly Property SetQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Quantity", Value)
                End Set
            End Property

            Private _Price As Double = 0
            Public ReadOnly Property Price() As Double
                Get
                    Return _Price
                End Get
            End Property
            Public WriteOnly Property SetPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Price", Value)
                End Set
            End Property

#End Region

End Class

End Namespace

End Namespace

