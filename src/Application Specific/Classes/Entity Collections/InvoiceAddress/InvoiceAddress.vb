Imports System.Data.SqlClient

Namespace Entity

Namespace InvoiceAddresss

Public Class InvoiceAddress

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

#Region "InvoiceAddress Properties"

      
Private _InvoiceAddressID As Integer = 0
Public Readonly Property InvoiceAddressID() As Integer
	Get 
		Return _InvoiceAddressID
	End Get	
End Property	
Public Writeonly Property SetInvoiceAddressID() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_InvoiceAddressID", Value)
	End Set
End Property


Private _Address1 As String = String.Empty
Public Readonly Property Address1() As String
	Get 
		Return _Address1
	End Get	
End Property	
Public Writeonly Property SetAddress1() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Address1", Value)
	End Set
End Property


Private _Address2 As String = String.Empty
Public Readonly Property Address2() As String
	Get 
		Return _Address2
	End Get	
End Property	
Public Writeonly Property SetAddress2() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Address2", Value)
	End Set
End Property


Private _Address3 As String = String.Empty
Public Readonly Property Address3() As String
	Get 
		Return _Address3
	End Get	
End Property	
Public Writeonly Property SetAddress3() As Object
	Set(Value as Object)
		_dataTypeValidator.SetValue(Me, "_Address3", Value)
	End Set
End Property

            Private _Address4 As String = String.Empty
            Public ReadOnly Property Address4() As String
                Get
                    Return _Address4
                End Get
            End Property
            Public WriteOnly Property SetAddress4() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address4", Value)
                End Set
            End Property

            Private _Address5 As String = String.Empty
            Public ReadOnly Property Address5() As String
                Get
                    Return _Address5
                End Get
            End Property
            Public WriteOnly Property SetAddress5() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address5", Value)
                End Set
            End Property

            Private _Postcode As String = String.Empty
            Public ReadOnly Property Postcode() As String
                Get
                    Return _Postcode
                End Get
            End Property
            Public WriteOnly Property SetPostcode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Postcode", Value)
                End Set
            End Property


            Private _TelephoneNum As String = String.Empty
            Public ReadOnly Property TelephoneNum() As String
                Get
                    Return _TelephoneNum
                End Get
            End Property
            Public WriteOnly Property SetTelephoneNum() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TelephoneNum", Value)
                End Set
            End Property


            Private _FaxNum As String = String.Empty
            Public ReadOnly Property FaxNum() As String
                Get
                    Return _FaxNum
                End Get
            End Property
            Public WriteOnly Property SetFaxNum() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FaxNum", Value)
                End Set
            End Property


            Private _EmailAddress As String = String.Empty
            Public ReadOnly Property EmailAddress() As String
                Get
                    Return _EmailAddress
                End Get
            End Property
            Public WriteOnly Property SetEmailAddress() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EmailAddress", Value)
                End Set
            End Property


            Private _SiteID As Integer = 0
            Public ReadOnly Property SiteID() As Integer
                Get
                    Return _SiteID
                End Get
            End Property
            Public WriteOnly Property SetSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SiteID", Value)
                End Set
            End Property



#End Region

End Class

End Namespace

End Namespace

