Imports System.Data.SqlClient

Namespace Entity

Namespace ProductSupplierPriceRequests

Public Class ProductSupplierPriceRequest

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

#Region "ProductSupplierPriceRequest Properties"

      
Private _ProductSupplierPriceRequestID As Integer = 0
Public Readonly Property ProductSupplierPriceRequestID() As Integer
	Get 
		Return _ProductSupplierPriceRequestID
	End Get	
End Property	
Public Writeonly Property SetProductSupplierPriceRequestID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_ProductSupplierPriceRequestID", Value)
	End Set
End Property

            Private _QuoteID As Integer = 0
            Public ReadOnly Property QuoteID() As Integer
                Get
                    Return _QuoteID
                End Get
            End Property
            Public WriteOnly Property SetQuoteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteID", Value)
                End Set
            End Property

            Private _OrderID As Integer = 0
            Public ReadOnly Property OrderID() As Integer
                Get
                    Return _OrderID
                End Get
            End Property
            Public WriteOnly Property SetOrderID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderID", Value)
                End Set
            End Property


            Private _QuantityInPack As Integer = 0
            Public ReadOnly Property QuantityInPack() As Integer
                Get
                    Return _QuantityInPack
                End Get
            End Property
            Public WriteOnly Property SetQuantityInPack() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuantityInPack", Value)
                End Set
            End Property


            Private _Complete As Boolean = False
            Public ReadOnly Property Complete() As Boolean
                Get
                    Return _Complete
                End Get
            End Property
            Public WriteOnly Property SetComplete() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Complete", Value)
                End Set
            End Property


            Private _ProductID As Integer = 0
            Public ReadOnly Property ProductID() As Integer
                Get
                    Return _ProductID
                End Get
            End Property
            Public WriteOnly Property SetProductID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ProductID", Value)
                End Set
            End Property


            Private _SupplierID As Integer = 0
            Public ReadOnly Property SupplierID() As Integer
                Get
                    Return _SupplierID
                End Get
            End Property
            Public WriteOnly Property SetSupplierID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SupplierID", Value)
                End Set
            End Property



#End Region

End Class

End Namespace

End Namespace

