Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteEngineerVisits

        Public Class QuoteEngineerVisit

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

#Region "QuoteEngineerVisit Properties"


            Private _QuoteEngineerVisitID As Integer = 0
            Public ReadOnly Property QuoteEngineerVisitID() As Integer
                Get
                    Return _QuoteEngineerVisitID
                End Get
            End Property
            Public WriteOnly Property SetQuoteEngineerVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteEngineerVisitID", Value)
                End Set
            End Property


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


            Private _StatusEnumID As Integer = 0
            Public ReadOnly Property StatusEnumID() As Integer
                Get
                    Return _StatusEnumID
                End Get
            End Property
            Public WriteOnly Property SetStatusEnumID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_StatusEnumID", Value)
                End Set
            End Property


            Private _NotesToEngineer As String = String.Empty
            Public ReadOnly Property NotesToEngineer() As String
                Get
                    Return _NotesToEngineer
                End Get
            End Property
            Public WriteOnly Property SetNotesToEngineer() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NotesToEngineer", Value)
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

