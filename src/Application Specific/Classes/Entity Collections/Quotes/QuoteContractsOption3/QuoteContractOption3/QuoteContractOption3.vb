Imports System.Data.SqlClient

Namespace Entity

Namespace QuoteContractOption3s

Public Class QuoteContractOption3

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

#Region "QuoteContractOption3 Properties"

      
Private _QuoteContractID As Integer = 0
Public Readonly Property QuoteContractID() As Integer
	Get 
		Return _QuoteContractID
	End Get	
End Property	
Public Writeonly Property SetQuoteContractID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_QuoteContractID", Value)
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


Private _QuoteContractReference As String = String.Empty
Public Readonly Property QuoteContractReference() As String
	Get 
		Return _QuoteContractReference
	End Get	
End Property	
Public Writeonly Property SetQuoteContractReference() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_QuoteContractReference", Value)
	End Set
End Property


Private _QuoteContractStatusID As Integer = 0
Public Readonly Property QuoteContractStatusID() As Integer
	Get 
		Return _QuoteContractStatusID
	End Get	
End Property	
Public Writeonly Property SetQuoteContractStatusID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_QuoteContractStatusID", Value)
	End Set
End Property


Private _QuoteContractDate As Datetime = Nothing
Public Property QuoteContractDate() As Datetime
	Get 
		Return _QuoteContractDate
	End Get
	Set (ByVal Value As Datetime)
		_QuoteContractDate = Value
	End Set
End Property	


Private _QuoteContractPrice As Double = 0
Public Readonly Property QuoteContractPrice() As Double
	Get 
		Return _QuoteContractPrice
	End Get	
End Property	
Public Writeonly Property SetQuoteContractPrice() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_QuoteContractPrice", Value)
	End Set
End Property


Private _ReasonForReject As String = String.Empty
Public Readonly Property ReasonForReject() As String
	Get 
		Return _ReasonForReject
	End Get	
End Property	
Public Writeonly Property SetReasonForReject() As Object
	Set(Value as Object)
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
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonForRejectID", Value)
                End Set
            End Property
  
#End Region

End Class

End Namespace

End Namespace

