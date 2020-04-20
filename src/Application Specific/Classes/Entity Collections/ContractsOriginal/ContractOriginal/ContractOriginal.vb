Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractsOriginal

        Public Class ContractOriginal

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

#Region "Contract Properties"


            Private _ContractID As Integer = 0
            Public ReadOnly Property ContractID() As Integer
                Get
                    Return _ContractID
                End Get
            End Property
            Public WriteOnly Property SetContractID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractID", Value)
                End Set
            End Property


            Private _ContractTypeID As Integer = 0
            Public ReadOnly Property ContractTypeID() As Integer
                Get
                    Return _ContractTypeID
                End Get
            End Property
            Public WriteOnly Property SetContractTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractTypeID", Value)
                End Set
            End Property


            Private _DiscountID As Integer = 0
            Public ReadOnly Property DiscountID() As Integer
                Get
                    Return _DiscountID
                End Get
            End Property
            Public WriteOnly Property SetDiscountID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DiscountID", Value)
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


            Private _ContractReference As String = String.Empty
            Public ReadOnly Property ContractReference() As String
                Get
                    Return _ContractReference
                End Get
            End Property
            Public WriteOnly Property SetContractReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractReference", Value)
                End Set
            End Property


            Private _ContractStartDate As DateTime = Nothing
            Public Property ContractStartDate() As DateTime
                Get
                    Return _ContractStartDate
                End Get
                Set(ByVal Value As DateTime)
                    _ContractStartDate = Value
                End Set
            End Property


            Private _ContractEndDate As DateTime = Nothing
            Public Property ContractEndDate() As DateTime
                Get
                    Return _ContractEndDate
                End Get
                Set(ByVal Value As DateTime)
                    _ContractEndDate = Value
                End Set
            End Property


            Private _ContractStatusID As Integer = 0
            Public ReadOnly Property ContractStatusID() As Integer
                Get
                    Return _ContractStatusID
                End Get
            End Property
            Public WriteOnly Property SetContractStatusID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractStatusID", Value)
                End Set
            End Property


            Private _ContractPrice As Decimal = 0.0
            Public ReadOnly Property ContractPrice() As Decimal
                Get
                    Return _ContractPrice
                End Get
            End Property
            Public WriteOnly Property SetContractPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractPrice", Value)
                End Set
            End Property

            Private _ContractPriceAfterVAT As Double = 0.0
            Public ReadOnly Property ContractPriceAfterVAT() As Double
                Get
                    Return _ContractPriceAfterVAT
                End Get
            End Property
            Public WriteOnly Property SetContractPriceAfterVAT() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractPriceAfterVAT", Value)
                End Set
            End Property

            Private _QuoteContractID As Integer = 0
            Public ReadOnly Property QuoteContractID() As Integer
                Get
                    Return _QuoteContractID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractID", Value)
                End Set
            End Property


            Private _InvoiceFrequencyID As Integer = 0
            Public ReadOnly Property InvoiceFrequencyID() As Integer
                Get
                    Return _InvoiceFrequencyID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceFrequencyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceFrequencyID", Value)
                End Set
            End Property


            Private _PreviousInvoiceFrequencyID As Integer = 0
            Public ReadOnly Property PreviousInvoiceFrequencyID() As Integer
                Get
                    Return _PreviousInvoiceFrequencyID
                End Get
            End Property
            Public WriteOnly Property SetPreviousInvoiceFrequencyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PreviousInvoiceFrequencyID", Value)
                End Set
            End Property


            Private _FirstInvoiceDate As DateTime
            Public Property FirstInvoiceDate() As DateTime
                Get
                    Return _FirstInvoiceDate
                End Get
                Set(ByVal Value As DateTime)
                    _FirstInvoiceDate = Value
                End Set
            End Property

            Private _InvoiceAddressTypeID As Integer
            Public ReadOnly Property InvoiceAddressTypeID() As Integer
                Get
                    Return _InvoiceAddressTypeID
                End Get
            End Property
            Public WriteOnly Property SetInvoiceAddressTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceAddressTypeID", Value)
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


            Private _sortCode As String = ""
            Public ReadOnly Property SortCode() As String
                Get
                    Return _sortCode
                End Get
            End Property
            Public WriteOnly Property SetSortCode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_sortCode", Value)
                End Set
            End Property

            Private _accountNumber As String = ""
            Public ReadOnly Property AccountNumber() As String
                Get
                    Return _accountNumber
                End Get
            End Property
            Public WriteOnly Property SetAccountNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_accountNumber", Value)
                End Set
            End Property

            Private _bankName As String = ""
            Public ReadOnly Property BankName() As String
                Get
                    Return _bankName
                End Get
            End Property
            Public WriteOnly Property SetBankName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_bankName", Value)
                End Set
            End Property

            Private _PoNumber As String = ""
            Public ReadOnly Property PoNumber() As String
                Get
                    Return _PoNumber
                End Get
            End Property
            Public WriteOnly Property SetPoNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PoNumber", Value)
                End Set
            End Property


            Private _DDMSRef As String = ""
            Public ReadOnly Property DDMSRef() As String
                Get
                    Return _DDMSRef
                End Get
            End Property
            Public WriteOnly Property SetDDMSRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DDMSRef", Value)
                End Set
            End Property


            Private _directDebit As Boolean = False
            Public ReadOnly Property DirectDebit() As Boolean
                Get
                    Return _directDebit
                End Get
            End Property
            Public WriteOnly Property SetDirectDebit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_directDebit", Value)
                End Set
            End Property

            Private _DoNotRenew As Boolean = False
            Public ReadOnly Property DoNotRenew() As Boolean
                Get
                    Return _DoNotRenew
                End Get
            End Property
            Public WriteOnly Property SetDoNotRenew() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DoNotRenew", Value)
                End Set
            End Property


            Private _creditCard As Boolean = False
            Public ReadOnly Property CreditCard() As Boolean
                Get
                    Return _creditCard
                End Get
            End Property
            Public WriteOnly Property SetCreditCard() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_creditCard", Value)
                End Set
            End Property

            Private _cheque As Boolean = False
            Public ReadOnly Property Cheque() As Boolean
                Get
                    Return _cheque
                End Get
            End Property
            Public WriteOnly Property SetCheque() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_cheque", Value)
                End Set
            End Property

            Private _Annual As Boolean = False
            Public ReadOnly Property Annual() As Boolean
                Get
                    Return _Annual
                End Get
            End Property
            Public WriteOnly Property SetAnnual() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Annual", Value)
                End Set
            End Property


            Private _GasSupplyPipework As Boolean = False
            Public ReadOnly Property GasSupplyPipework() As Boolean
                Get
                    Return _GasSupplyPipework
                End Get
            End Property
            Public WriteOnly Property SetGasSupplyPipework() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GasSupplyPipework", Value)
                End Set
            End Property

            Private _PlumbingDrainage As Boolean = False
            Public ReadOnly Property PlumbingDrainage() As Boolean
                Get
                    Return _PlumbingDrainage
                End Get
            End Property
            Public WriteOnly Property SetPlumbingDrainage() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PlumbingDrainage", Value)
                End Set
            End Property

            Private _WindowLockPest As Boolean = False
            Public ReadOnly Property WindowLockPest() As Boolean
                Get
                    Return _WindowLockPest
                End Get
            End Property
            Public WriteOnly Property SetWindowLockPest() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_WindowLockPest", Value)
                End Set
            End Property


            'THIS IS A CHEAT
            Private _ContractType As String = String.Empty
            Public ReadOnly Property ContractType() As String
                Get
                    Return _ContractType
                End Get
            End Property
            Public WriteOnly Property SetContractType() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractType", Value)
                End Set
            End Property


            Private _CancelledDate As DateTime = Date.MinValue
            Public Property CancelledDate() As DateTime
                Get
                    Return _CancelledDate
                End Get
                Set(ByVal Value As DateTime)
                    _CancelledDate = Value
                End Set
            End Property


            Private _ReasonID As Integer = 0
            Public ReadOnly Property ReasonID() As Integer
                Get
                    Return _ReasonID
                End Get
            End Property
            Public WriteOnly Property SetReasonID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonID", Value)
                End Set
            End Property

            Private _Notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _Notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Notes", Value)
                End Set
            End Property
#End Region

        End Class

    End Namespace

End Namespace

