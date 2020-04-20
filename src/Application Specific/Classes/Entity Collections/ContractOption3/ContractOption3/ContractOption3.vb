Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOption3s

        Public Class ContractOption3

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

#Region "ContractOption3 Properties"


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


            Private _ContractPrice As Double = 0
            Public ReadOnly Property ContractPrice() As Double
                Get
                    Return _ContractPrice
                End Get
            End Property
            Public WriteOnly Property SetContractPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContractPrice", Value)
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

#End Region

        End Class

    End Namespace

End Namespace

