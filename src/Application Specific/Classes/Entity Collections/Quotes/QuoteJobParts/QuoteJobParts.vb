Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteJobPartss

Public Class QuoteJobParts

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

#Region "QuoteJobParts Properties"

      
Private _QuoteJobPartsID As Integer = 0
Public Readonly Property QuoteJobPartsID() As Integer
	Get 
		Return _QuoteJobPartsID
	End Get	
End Property	
Public Writeonly Property SetQuoteJobPartsID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_QuoteJobPartsID", Value)
	End Set
End Property


Private _QuoteJobID As Integer = 0
Public Readonly Property QuoteJobID() As Integer
	Get 
		Return _QuoteJobID
	End Get	
End Property	
Public Writeonly Property SetQuoteJobID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_QuoteJobID", Value)
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
Public Readonly Property Quantity() As Integer
	Get 
		Return _Quantity
	End Get	
End Property	
Public Writeonly Property SetQuantity() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Quantity", Value)
	End Set
End Property


Private _SellPrice As Double = 0
Public Readonly Property SellPrice() As Double
	Get 
		Return _SellPrice
	End Get	
End Property	
Public Writeonly Property SetSellPrice() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_SellPrice", Value)
	End Set
End Property

            Private _BuyPrice As Double = 0
            Public ReadOnly Property BuyPrice() As Double
                Get
                    Return _BuyPrice
                End Get
            End Property
            Public WriteOnly Property SetBuyPrice() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BuyPrice", Value)
                End Set
            End Property

            Private _SpecialCost As Double = 0
            Public ReadOnly Property SpecialCost() As Double
                Get
                    Return _SpecialCost
                End Get
            End Property
            Public WriteOnly Property SetSpecialCost() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SpecialCost", Value)
                End Set
            End Property

            Private _PartSupplierID As Integer = 0
            Public ReadOnly Property PartSupplierID() As Integer
                Get
                    Return _PartSupplierID
                End Get
            End Property
            Public WriteOnly Property SetPartSupplierID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartSupplierID", Value)
                End Set
            End Property

            Private _SpecialDescription As String = ""
            Public ReadOnly Property SpecialDescription() As String
                Get
                    Return _SpecialDescription
                End Get
            End Property
            Public WriteOnly Property SetSpecialDescription() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SpecialDescription", Value)
                End Set
            End Property

            Private _Extra As String = ""
            Public ReadOnly Property Extra() As String
                Get
                    Return _Extra
                End Get
            End Property
            Public WriteOnly Property SetExtra() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Extra", Value)
                End Set
            End Property


#End Region

        End Class

End Namespace

End Namespace

