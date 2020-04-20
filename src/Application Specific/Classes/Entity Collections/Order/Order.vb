Imports System.Data.SqlClient

Namespace Entity

    Namespace Orders

        Public Class Order

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

#Region "Order Properties"

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

            Private _DatePlaced As DateTime = Nothing

            Public Property DatePlaced() As DateTime
                Get
                    Return _DatePlaced
                End Get
                Set(ByVal Value As DateTime)
                    _DatePlaced = Value
                End Set
            End Property

            Private _OrderTypeID As Integer = 0

            Public ReadOnly Property OrderTypeID() As Integer
                Get
                    Return _OrderTypeID
                End Get
            End Property

            Public WriteOnly Property SetOrderTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderTypeID", Value)
                End Set
            End Property

            Private _OrderReference As String = String.Empty

            Public ReadOnly Property OrderReference() As String
                Get
                    Return _OrderReference
                End Get
            End Property

            Public WriteOnly Property SetOrderReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderReference", Value)
                End Set
            End Property

            Private _UserID As Integer = 0

            Public ReadOnly Property UserID() As Integer
                Get
                    Return _UserID
                End Get
            End Property

            Public WriteOnly Property SetUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UserID", Value)
                End Set
            End Property

            Private _OrderStatusID As Integer = 0

            Public ReadOnly Property OrderStatusID() As Integer
                Get
                    Return _OrderStatusID
                End Get
            End Property

            Public WriteOnly Property SetOrderStatusID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderStatusID", Value)
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

            Private _DeliveryDeadline As DateTime = Nothing

            Public Property DeliveryDeadline() As DateTime
                Get
                    Return _DeliveryDeadline
                End Get
                Set(ByVal Value As DateTime)
                    _DeliveryDeadline = Value
                End Set
            End Property

            Private _sentToSage As Boolean = False

            Public ReadOnly Property SentToSage() As Boolean
                Get
                    Return _sentToSage
                End Get
            End Property

            Public WriteOnly Property SetSentToSage() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_sentToSage", Value)
                End Set
            End Property

            Private _supplierInvoiceDate As DateTime = Nothing

            Public Property SupplierInvoiceDate() As DateTime
                Get
                    Return _supplierInvoiceDate
                End Get
                Set(ByVal Value As DateTime)
                    _supplierInvoiceDate = Value
                End Set
            End Property

            Private _supplierInvoiceAmount As Double = 0

            Public ReadOnly Property SupplierInvoiceAmount() As Double
                Get
                    Return _supplierInvoiceAmount
                End Get
            End Property

            Public WriteOnly Property SetSupplierInvoiceAmount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_supplierInvoiceAmount", Value)
                End Set
            End Property

            Private _supplierInvoiceReference As String = ""

            Public ReadOnly Property SupplierInvoiceReference() As String
                Get
                    Return _supplierInvoiceReference
                End Get
            End Property

            Public WriteOnly Property SetSupplierInvoiceReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_supplierInvoiceReference", Value)
                End Set
            End Property

            Private _allocatedToUser As Integer = 0

            Public ReadOnly Property AllocatedToUser() As Integer
                Get
                    Return _allocatedToUser
                End Get
            End Property

            Public WriteOnly Property SetAllocatedToUser() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_allocatedToUser", Value)
                End Set
            End Property

            Private _invoiceAddressID As Integer = 0

            Public ReadOnly Property InvoiceAddressID() As Integer
                Get
                    Return _invoiceAddressID
                End Get
            End Property

            Public WriteOnly Property SetInvoiceAddressID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_invoiceAddressID", Value)
                End Set
            End Property

            Private _contactID As Integer = 0

            Public ReadOnly Property ContactID() As Integer
                Get
                    Return _contactID
                End Get
            End Property

            Public WriteOnly Property SetContactID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_contactID", Value)
                End Set
            End Property

            Private _specialInstructions As String = ""

            Public ReadOnly Property SpecialInstructions() As String
                Get
                    Return _specialInstructions
                End Get
            End Property

            Public WriteOnly Property SetSpecialInstructions() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_specialInstructions", Value)
                End Set
            End Property

            Private _Invoiced As Boolean = False

            Public ReadOnly Property Invoiced() As Boolean
                Get
                    Return _Invoiced
                End Get
            End Property

            Public WriteOnly Property SetInvoiced() As Boolean
                Set(ByVal Value As Boolean)
                    _Invoiced = Value
                End Set
            End Property

            Private _ExportedToSage As Boolean = False

            Public ReadOnly Property ExportedToSage() As Boolean
                Get
                    Return _ExportedToSage
                End Get
            End Property

            Public WriteOnly Property SetExportedToSage() As Boolean
                Set(ByVal Value As Boolean)
                    _ExportedToSage = Value
                End Set
            End Property

            Private _NominalCode As String = ""

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

            Private _DepartmentRef As String = ""

            Public ReadOnly Property DepartmentRef() As String
                Get
                    Return _DepartmentRef
                End Get
            End Property

            Public WriteOnly Property SetDepartmentRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DepartmentRef", Value)
                End Set
            End Property

            Private _ExtraRef As String = ""

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

            Private _TaxCodeID As Integer = 0

            Public ReadOnly Property TaxCodeID() As Integer
                Get
                    Return _TaxCodeID
                End Get
            End Property

            Public WriteOnly Property SetTaxCodeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TaxCodeID", Value)
                End Set
            End Property

            Private _ReadyToSendToSage As Boolean = False

            Public ReadOnly Property ReadyToSendToSage() As Boolean
                Get
                    Return _ReadyToSendToSage
                End Get
            End Property

            Public WriteOnly Property SetReadyToSendToSage() As Boolean
                Set(ByVal Value As Boolean)
                    _ReadyToSendToSage = Value
                End Set
            End Property

            Private _OrderConsolidationID As Integer = 0

            Public ReadOnly Property OrderConsolidationID() As Integer
                Get
                    Return _OrderConsolidationID
                End Get
            End Property

            Public WriteOnly Property SetOrderConsolidationID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderConsolidationID", Value)
                End Set
            End Property

            Private _VATAmount As Double = 0.0

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

            Private _DoNotConsolidated As Boolean = False

            Public ReadOnly Property DoNotConsolidated() As Boolean
                Get
                    Return _DoNotConsolidated
                End Get
            End Property

            Public WriteOnly Property SetDoNotConsolidated() As Object
                Set(ByVal value As Object)
                    _dataTypeValidator.SetValue(Me, "_DoNotConsolidated", value)
                End Set
            End Property

            Private _reason As String = String.Empty

            Public ReadOnly Property Reason() As String
                Get
                    Return _reason
                End Get
            End Property

            Public WriteOnly Property SetReason() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_reason", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace