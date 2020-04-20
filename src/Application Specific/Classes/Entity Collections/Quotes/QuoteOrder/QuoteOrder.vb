Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteOrders

Public Class QuoteOrder

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

#Region "QuoteOrder Properties"

      
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


Private _CustomerID As Integer = 0
Public Readonly Property CustomerID() As Integer
	Get 
		Return _CustomerID
	End Get	
End Property	
Public Writeonly Property SetCustomerID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_CustomerID", Value)
	End Set
End Property

            Private _WarehouseID As Integer = 0
            Public ReadOnly Property WarehouseID() As Integer
                Get
                    Return _WarehouseID
                End Get
            End Property
            Public WriteOnly Property SetWarehouseID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_WarehouseID", Value)
                End Set
            End Property


            Private _PropertyID As Integer = 0
            Public ReadOnly Property PropertyID() As Integer
                Get
                    Return _PropertyID
                End Get
            End Property
            Public WriteOnly Property SetPropertyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PropertyID", Value)
                End Set
            End Property

            Private _QuoteStatusID As Integer = 0
            Public ReadOnly Property QuoteStatusID() As Integer
                Get
                    Return _QuoteStatusID
                End Get
            End Property
            Public WriteOnly Property SetQuoteStatusID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteStatusID", Value)
                End Set
            End Property

            Private _ContactID As Integer = 0
            Public ReadOnly Property ContactID() As Integer
                Get
                    Return _ContactID
                End Get
            End Property
            Public WriteOnly Property SetContactID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContactID", Value)
                End Set
            End Property


            Private _InvoiceAddressID As Integer = 0
            Public ReadOnly Property InvoiceAddressID() As Integer
                Get
                    Return _InvoiceAddressID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceAddressID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceAddressID", Value)
                End Set
            End Property

            Private _ReasonForReject As String = String.Empty
            Public ReadOnly Property ReasonForReject() As String
                Get
                    Return _ReasonForReject
                End Get
            End Property
            Public WriteOnly Property SetReasonForReject() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonForReject", Value)
                End Set
            End Property

            Private _ReasonForRejectID As Integer = 0
            Public ReadOnly Property ReasonForRejectID() As Integer
                Get
                    Return _ReasonForRejectID
                End Get
            End Property
            Public WriteOnly Property SetReasonForRejectID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonForRejectID", Value)
                End Set
            End Property

            Private _CustomerRef As String = String.Empty
            Public ReadOnly Property CustomerRef() As String
                Get
                    Return _CustomerRef
                End Get
            End Property
            Public WriteOnly Property SetCustomerRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CustomerRef", Value)
                End Set
            End Property


            Private _DeliveryDeadline As DateTime = Nothing
            Public Property DeliveryDeadline() As DateTime
                Get
                    Return _DeliveryDeadline
                End Get
                Set(ByVal Value As DateTime)
                    _DeliveryDeadline = Value
                End Set
            End Property


            Private _SpecialInstructions As String = String.Empty
            Public ReadOnly Property SpecialInstructions() As String
                Get
                    Return _SpecialInstructions
                End Get
            End Property
            Public WriteOnly Property SetSpecialInstructions() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SpecialInstructions", Value)
                End Set
            End Property


            Private _CreatedByUser As Integer = 0
            Public ReadOnly Property CreatedByUser() As Integer
                Get
                    Return _CreatedByUser
                End Get
            End Property
            Public WriteOnly Property SetCreatedByUser() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CreatedByUser", Value)
                End Set
            End Property


            Private _AllocatedToUser As Integer = 0
            Public ReadOnly Property AllocatedToUser() As Integer
                Get
                    Return _AllocatedToUser
                End Get
            End Property
            Public WriteOnly Property SetAllocatedToUser() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AllocatedToUser", Value)
                End Set
            End Property

            Private _EnquiryDate As DateTime = Nothing
            Public Property EnquiryDate() As DateTime
                Get
                    Return _EnquiryDate
                End Get
                Set(ByVal Value As DateTime)
                    _EnquiryDate = Value
                End Set
            End Property

            Private _validUntilDate As DateTime = Nothing
            Public Property ValidUntilDate() As DateTime
                Get
                    Return _validUntilDate
                End Get
                Set(ByVal Value As DateTime)
                    _validUntilDate = Value
                End Set
            End Property

            Private _Availability As String = String.Empty
            Public ReadOnly Property Availability() As String
                Get
                    Return _Availability
                End Get
            End Property
            Public WriteOnly Property SetAvailability() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Availability", Value)
                End Set
            End Property

            Private _PriceDetails As String = String.Empty
            Public ReadOnly Property PriceDetails() As String
                Get
                    Return _PriceDetails
                End Get
            End Property
            Public WriteOnly Property SetPriceDetails() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PriceDetails", Value)
                End Set
            End Property

            Private _PriceExcludeDetails As String = String.Empty
            Public ReadOnly Property PriceExcludeDetails() As String
                Get
                    Return _PriceExcludeDetails
                End Get
            End Property
            Public WriteOnly Property SetPriceExcludeDetails() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PriceExcludeDetails", Value)
                End Set
            End Property
#End Region

End Class

End Namespace

End Namespace

