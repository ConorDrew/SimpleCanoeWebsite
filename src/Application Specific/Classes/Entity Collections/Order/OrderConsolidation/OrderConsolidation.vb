Imports System.Data.SqlClient

Namespace Entity

    Namespace OrderConsolidations

        Public Class OrderConsolidation

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

#End Region

#Region "OrderConsolidation Properties"


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


            Private _LocationID As Integer = 0
            Public ReadOnly Property LocationID() As Integer
                Get
                    Return _LocationID
                End Get
            End Property
            Public WriteOnly Property SetLocationID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LocationID", Value)
                End Set
            End Property


            Private _ConsolidationDate As DateTime = Nothing
            Public Property ConsolidationDate() As DateTime
                Get
                    Return _ConsolidationDate
                End Get
                Set(ByVal Value As DateTime)
                    _ConsolidationDate = Value
                End Set
            End Property


            Private _ConsolidationRef As String = String.Empty
            Public ReadOnly Property ConsolidationRef() As String
                Get
                    Return _ConsolidationRef
                End Get
            End Property
            Public WriteOnly Property SetConsolidationRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ConsolidationRef", Value)
                End Set
            End Property


            Private _Comments As String = String.Empty
            Public ReadOnly Property Comments() As String
                Get
                    Return _Comments
                End Get
            End Property
            Public WriteOnly Property SetComments() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Comments", Value)
                End Set
            End Property

            Private _ConsolidatedOrderStatusID As Integer
            Public ReadOnly Property ConsolidatedOrderStatusID() As Integer
                Get
                    Return _ConsolidatedOrderStatusID
                End Get
            End Property
            Public WriteOnly Property SetConsolidatedOrderStatusID() As Integer
                Set(ByVal Value As Integer)
                    _ConsolidatedOrderStatusID = Value
                End Set
            End Property

            Private _HasSupplierPO As Boolean = False
            Public Property HasSupplierPO() As Boolean
                Get
                    Return _HasSupplierPO
                End Get
                Set(ByVal Value As Boolean)
                    _HasSupplierPO = Value
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

            Private _DateExported As DateTime = Nothing
            Public Property DateExported() As DateTime
                Get
                    Return _DateExported
                End Get
                Set(ByVal Value As DateTime)
                    _DateExported = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

