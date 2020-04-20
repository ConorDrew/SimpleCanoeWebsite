Imports System.Data.SqlClient

Namespace Entity

    Namespace SalesCredits

        Public Class SalesCredit

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

#Region "SalesCredit Properties"


            Private _DateCredited As DateTime = Nothing
            Public Property DateCredited() As DateTime
                Get
                    Return _DateCredited
                End Get
                Set(ByVal Value As DateTime)
                    _DateCredited = Value
                End Set
            End Property

            Private _DateExportedToSage As DateTime = Nothing
            Public Property DateExportedToSage() As DateTime
                Get
                    Return _DateExportedToSage
                End Get
                Set(ByVal Value As DateTime)
                    _DateExportedToSage = Value
                End Set
            End Property


            Private _VATAmount As Double = 0
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



            Private _SalesCreditID As Integer = 0
            Public ReadOnly Property SalesCreditID() As Integer
                Get
                    Return _SalesCreditID
                End Get
            End Property
            Public WriteOnly Property SetSalesCreditID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SalesCreditID", Value)
                End Set
            End Property


            Private _AmountCredited As Double = 0
            Public ReadOnly Property AmountCredited() As Double
                Get
                    Return _AmountCredited
                End Get
            End Property
            Public WriteOnly Property SetAmountCredited() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AmountCredited", Value)
                End Set
            End Property


            Private _Notes As String = 0
            Public ReadOnly Property Notes() As String
                Get
                    Return _Notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Notes", Value)
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


            Private _ExtraRef As String = 0
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



            Private _CreditReference As String = 0
            Public ReadOnly Property CreditReference() As String
                Get
                    Return _CreditReference
                End Get
            End Property
            Public WriteOnly Property SetCreditReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CreditReference", Value)
                End Set
            End Property


            Private _NominalCode As Integer = 0
            Public ReadOnly Property NominalCode() As Integer
                Get
                    Return _NominalCode
                End Get
            End Property
            Public WriteOnly Property SetNominalCode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NominalCode", Value)
                End Set
            End Property


            Private _DepartmentRef As Integer = 0
            Public ReadOnly Property DepartmentRef() As Integer
                Get
                    Return _DepartmentRef
                End Get
            End Property
            Public WriteOnly Property SetDepartmentRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DepartmentRef", Value)
                End Set
            End Property


            Private _InvoicedLineID As Integer = 0
            Public ReadOnly Property InvoicedLineID() As Integer
                Get
                    Return _InvoicedLineID
                End Get
            End Property
            Public WriteOnly Property SetInvoicedLineID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoicedLineID", Value)
                End Set
            End Property




            Private _AddedByUser As Integer = 0
            Public ReadOnly Property AddedByUser() As Integer
                Get
                    Return _AddedByUser
                End Get
            End Property
            Public WriteOnly Property SetAddedByUser() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AddedByUser", Value)
                End Set
            End Property




            Private _RequestedBy As Integer = 0
            Public ReadOnly Property RequestedBy() As Integer
                Get
                    Return _RequestedBy
                End Get
            End Property
            Public WriteOnly Property SetRequestedBy() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RequestedBy", Value)
                End Set
            End Property




            Private _ReasonForCredit As String = 0
            Public ReadOnly Property ReasonForCredit() As String
                Get
                    Return _ReasonForCredit
                End Get
            End Property
            Public WriteOnly Property SetReasonForCredit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonForCredit", Value)
                End Set
            End Property


            Private _AccountNumber As String = ""
            Public ReadOnly Property AccountNumber() As String
                Get
                    Return _AccountNumber
                End Get
            End Property
            Public WriteOnly Property SetAccountNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AccountNumber", Value)
                End Set
            End Property
          


            


#End Region

        End Class

    End Namespace

End Namespace

