Imports System.Data.SqlClient

Namespace Entity

    Namespace Invoiceds

        Public Class Invoiced

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

#Region "Invoiced Properties"


            Private _InvoicedID As Integer = 0
            Public ReadOnly Property InvoicedID() As Integer
                Get
                    Return _InvoicedID
                End Get
            End Property
            Public WriteOnly Property SetInvoicedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoicedID", Value)
                End Set
            End Property


            Private _InvoiceNumber As String = String.Empty
            Public ReadOnly Property InvoiceNumber() As String
                Get
                    Return _InvoiceNumber
                End Get
            End Property
            Public WriteOnly Property SetInvoiceNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceNumber", Value)
                End Set
            End Property


            Private _AdhocInvoiceType As String = String.Empty
            Public ReadOnly Property AdhocInvoiceType() As String
                Get
                    Return _AdhocInvoiceType
                End Get
            End Property
            Public WriteOnly Property SetAdhocInvoiceType() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AdhocInvoiceType", Value)
                End Set
            End Property

            ' AdhocInvoiceType

            Private _RaisedDate As DateTime = Nothing
            Public Property RaisedDate() As DateTime
                Get
                    Return _RaisedDate
                End Get
                Set(ByVal Value As DateTime)
                    _RaisedDate = Value
                End Set
            End Property


            Private _RaisedByUserID As Integer = 0
            Public ReadOnly Property RaisedByUserID() As Integer
                Get
                    Return _RaisedByUserID
                End Get
            End Property
            Public WriteOnly Property SetRaisedByUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RaisedByUserID", Value)
                End Set
            End Property

            Private _VATRateID As Integer = 0
            Public ReadOnly Property VATRateID() As Integer
                Get
                    Return _VATRateID
                End Get
            End Property
            Public WriteOnly Property SetVATRateID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VATRateID", Value)
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

