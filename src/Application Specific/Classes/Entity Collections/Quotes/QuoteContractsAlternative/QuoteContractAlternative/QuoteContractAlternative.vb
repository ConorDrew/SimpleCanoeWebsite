Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternatives

        Public Class QuoteContractAlternative


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

#Region "QuoteContract Properties"


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


            Private _QuoteContractReference As String = String.Empty
            Public ReadOnly Property QuoteContractReference() As String
                Get
                    Return _QuoteContractReference
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractReference", Value)
                End Set
            End Property


            Private _QuoteContractDate As DateTime = Nothing
            Public Property QuoteContractDate() As DateTime
                Get
                    Return _QuoteContractDate
                End Get
                Set(ByVal Value As DateTime)
                    _QuoteContractDate = Value
                End Set
            End Property


            Private _ContractStart As DateTime = Nothing
            Public Property ContractStart() As DateTime
                Get
                    Return _ContractStart
                End Get
                Set(ByVal Value As DateTime)
                    _ContractStart = Value
                End Set
            End Property


            Private _ContractEnd As DateTime = Nothing
            Public Property ContractEnd() As DateTime
                Get
                    Return _ContractEnd
                End Get
                Set(ByVal Value As DateTime)
                    _ContractEnd = Value
                End Set
            End Property


            Private _QuoteContractStatusID As Integer = 0
            Public ReadOnly Property QuoteContractStatusID() As Integer
                Get
                    Return _QuoteContractStatusID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractStatusID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractStatusID", Value)
                End Set
            End Property


            Private _QuoteContractPrice As Double = 0
            Public ReadOnly Property QuoteContractPrice() As Double
                Get
                    Return _QuoteContractPrice
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractPrice", Value)
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

            Private _ReasonForRejectID As Integer = 0
            Public ReadOnly Property ReasonForRejectID() As Integer
                Get
                    Return _ReasonForRejectID
                End Get
            End Property
            Public WriteOnly Property SetReasonForRejectID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonForRejectID", Value)
                End Set
            End Property
#End Region

        End Class

    End Namespace

End Namespace

