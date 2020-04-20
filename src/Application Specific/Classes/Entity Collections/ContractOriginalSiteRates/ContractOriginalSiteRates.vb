Imports System.Data.SqlClient

Namespace Entity

Namespace ContractOriginalSiteRatess

Public Class ContractOriginalSiteRates

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

#Region "ContractOriginalSiteRates Properties"

      
Private _ContractOriginalSiteRateID As Integer = 0
Public Readonly Property ContractOriginalSiteRateID() As Integer
	Get 
		Return _ContractOriginalSiteRateID
	End Get	
End Property	
Public Writeonly Property SetContractOriginalSiteRateID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_ContractOriginalSiteRateID", Value)
	End Set
End Property


Private _ContractSiteID As Integer = 0
Public Readonly Property ContractSiteID() As Integer
	Get 
		Return _ContractSiteID
	End Get	
End Property	
Public Writeonly Property SetContractSiteID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_ContractSiteID", Value)
	End Set
End Property


Private _RateID As Integer = 0
Public Readonly Property RateID() As Integer
	Get 
		Return _RateID
	End Get	
End Property	
Public Writeonly Property SetRateID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_RateID", Value)
	End Set
End Property


Private _Qty As Integer = 0
Public Readonly Property Qty() As Integer
	Get 
		Return _Qty
	End Get	
End Property	
Public Writeonly Property SetQty() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Qty", Value)
	End Set
End Property


  
#End Region

End Class

End Namespace

End Namespace

