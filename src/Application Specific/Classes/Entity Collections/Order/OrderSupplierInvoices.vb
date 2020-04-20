Imports System.Data.SqlClient

Namespace Entity

    Namespace Orders

        Public Class SupplierInvoice

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

#Region "SupplierInvoice Properties"

            Private _InvoiceID As Integer = 0
            Public ReadOnly Property InvoiceID() As Integer
                Get
                    Return _InvoiceID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceID", Value)
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

            Private _InvoiceReference As String
            Public ReadOnly Property InvoiceReference() As String
                Get
                    Return _InvoiceReference
                End Get
            End Property
            Public WriteOnly Property SetInvoiceReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceReference", Value)
                End Set
            End Property

            Private _InvoiceDate As DateTime = Nothing
            Public ReadOnly Property InvoiceDate() As Date
                Get
                    Return _InvoiceDate
                End Get
            End Property
            Public WriteOnly Property SetInvoiceDate() As Object
                Set(ByVal Value As Object)
                    _InvoiceDate = Value
                End Set
            End Property

            Private _GoodsAmount As Double
            Public ReadOnly Property GoodsAmount() As Double
                Get
                    Return _GoodsAmount
                End Get
            End Property
            Public WriteOnly Property SetGoodsAmount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GoodsAmount", Value)
                End Set
            End Property

            Private _VATAmount As Double
            Public ReadOnly Property VATAmount() As Double
                Get
                    Return _VATAmount
                End Get
            End Property
            Public WriteOnly Property SetVATAmount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VATAmount", Value)
                End Set
            End Property

            Private _TotalAmount As Double
            Public ReadOnly Property TotalAmount() As Double
                Get
                    Return _TotalAmount
                End Get
            End Property
            Public WriteOnly Property SetTotalAmount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TotalAmount", Value)
                End Set
            End Property

            Private _TaxCodeID As Integer
            Public ReadOnly Property TaxCodeID() As Integer
                Get
                    Return _TaxCodeID
                End Get
            End Property
            Public WriteOnly Property SetTaxCodeID() As Object
                Set(ByVal Value As Object)
                    _TaxCodeID = Value
                End Set
            End Property

            Private _NominalCode As String
            Public ReadOnly Property NominalCode() As String
                Get
                    Return _NominalCode
                End Get
            End Property
            Public WriteOnly Property SetNominalCode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NominalCode", Value)
                End Set
            End Property

            Private _ExtraRef As String
            Public ReadOnly Property ExtraRef() As String
                Get
                    Return _ExtraRef
                End Get
            End Property
            Public WriteOnly Property SetExtraRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ExtraRef", Value)
                End Set
            End Property

            Private _ReadyToSendToSage As Boolean
            Public ReadOnly Property ReadyToSendToSage() As Boolean
                Get
                    Return _ReadyToSendToSage
                End Get
            End Property
            Public WriteOnly Property SetReadyToSendToSage() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReadyToSendToSage", Value)
                End Set
            End Property

            Private _SentToSage As Boolean
            Public ReadOnly Property SentToSage() As Boolean
                Get
                    Return _SentToSage
                End Get
            End Property
            Public WriteOnly Property SetSentToSage() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SentToSage", Value)
                End Set
            End Property

            Private _OldSystemInvoice As Boolean
            Public ReadOnly Property OldSystemInvoice() As Boolean
                Get
                    Return _OldSystemInvoice
                End Get
            End Property
            Public WriteOnly Property SetOldSystemInvoice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OldSystemInvoice", Value)
                End Set
            End Property

            Private _DateExported As DateTime = Nothing
            Public ReadOnly Property DateExported() As Date
                Get
                    Return _DateExported
                End Get
            End Property
            Public WriteOnly Property SetDateExported() As Object
                Set(ByVal Value As Object)
                    _DateExported = Value
                End Set
            End Property

            Private _KeyedBy As Integer
            Public ReadOnly Property KeyedBy() As Integer
                Get
                    Return _KeyedBy
                End Get
            End Property
            Public WriteOnly Property SetKeyedBy() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_KeyedBy", Value)
                End Set
            End Property
#End Region

        End Class

    End Namespace

End Namespace