Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteJobOfWorks

        Public Class QuoteJobOfWork

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

#Region "QuoteJobOfWork Properties"


            Private _QuoteJobOfWorkID As Integer = 0
            Public ReadOnly Property QuoteJobOfWorkID() As Integer
                Get
                    Return _QuoteJobOfWorkID
                End Get
            End Property
            Public WriteOnly Property SetQuoteJobOfWorkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteJobOfWorkID", Value)
                End Set
            End Property


            Private _QuoteJobID As Integer = 0
            Public ReadOnly Property QuoteJobID() As Integer
                Get
                    Return _QuoteJobID
                End Get
            End Property
            Public WriteOnly Property SetQuoteJobID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteJobID", Value)
                End Set
            End Property




#End Region

#Region "Additional Properties"

            Private _QuotejobItems As New ArrayList
            Public Property QuoteJobItems() As ArrayList
                Get
                    Return _QuotejobItems
                End Get
                Set(ByVal Value As ArrayList)
                    _QuotejobItems = Value
                End Set
            End Property

            Private _QuoteengineerVisits As New ArrayList
            Public Property QuoteEngineerVisits() As ArrayList
                Get
                    Return _QuoteengineerVisits
                End Get
                Set(ByVal Value As ArrayList)
                    _QuoteengineerVisits = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

