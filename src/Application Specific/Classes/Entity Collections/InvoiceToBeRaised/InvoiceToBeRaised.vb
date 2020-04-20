Imports System.Data.SqlClient

Namespace Entity

    Namespace InvoiceToBeRaiseds

        Public Class InvoiceToBeRaised

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

#Region "InvoiceToBeRaised Properties"


            Private _InvoiceToBeRaisedID As Integer = 0
            Public ReadOnly Property InvoiceToBeRaisedID() As Integer
                Get
                    Return _InvoiceToBeRaisedID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceToBeRaisedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceToBeRaisedID", Value)
                End Set
            End Property


            Private _RaiseDate As DateTime = Nothing
            Public Property RaiseDate() As DateTime
                Get
                    Return _RaiseDate
                End Get
                Set(ByVal Value As DateTime)
                    _RaiseDate = Value
                End Set
            End Property


            Private _InvoiceTypeID As Integer = 0
            Public ReadOnly Property InvoiceTypeID() As Integer
                Get
                    Return _InvoiceTypeID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceTypeID", Value)
                End Set
            End Property


            Private _LinkID As Integer = 0
            Public ReadOnly Property LinkID() As Integer
                Get
                    Return _LinkID
                End Get
            End Property
            Public WriteOnly Property SetLinkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LinkID", Value)
                End Set
            End Property


            Private _AddressTypeID As Integer = 0
            Public ReadOnly Property AddressTypeID() As Integer
                Get
                    Return _AddressTypeID
                End Get
            End Property
            Public WriteOnly Property SetAddressTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AddressTypeID", Value)
                End Set
            End Property


            Private _AddressLinkID As Integer = 0
            Public ReadOnly Property AddressLinkID() As Integer
                Get
                    Return _AddressLinkID
                End Get
            End Property
            Public WriteOnly Property SetAddressLinkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AddressLinkID", Value)
                End Set
            End Property

            Private _CustomerID As Integer = 0
            Public ReadOnly Property CustomerID() As Integer
                Get
                    Return _CustomerID
                End Get
            End Property
            Public WriteOnly Property SetCustomerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CustomerID", Value)
                End Set
            End Property

            Private _TaxRateID As Integer = 0
            Public ReadOnly Property TaxRateID() As Integer
                Get
                    Return _TaxRateID
                End Get
            End Property
            Public WriteOnly Property SetTaxRateID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TaxRateID", Value)
                End Set
            End Property


            Private _PaymentTermID As Integer = 0
            Public ReadOnly Property PaymentTermID() As Integer
                Get
                    Return _PaymentTermID
                End Get
            End Property
            Public WriteOnly Property SetPaymentTermID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PaymentTermID", Value)
                End Set
            End Property

            Private _PaidByID As Integer = 0
            Public ReadOnly Property PaidByID() As Integer
                Get
                    Return _PaidByID
                End Get
            End Property
            Public WriteOnly Property SetPaidByID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PaidByID", Value)
                End Set
            End Property


#End Region

        End Class

    End Namespace

End Namespace

