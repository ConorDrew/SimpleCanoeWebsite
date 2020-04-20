Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternativePPMVisits

        Public Class QuoteContractAlternativePPMVisit

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

#Region "ContractPPMVisit Properties"


            Private _QuoteContractPPMVisitID As Integer = 0
            Public ReadOnly Property QuoteContractPPMVisitID() As Integer
                Get
                    Return _QuoteContractPPMVisitID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractPPMVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractPPMVisitID", Value)
                End Set
            End Property


            Private _QuoteContractSiteJobOfWorkID As Integer = 0
            Public ReadOnly Property QuoteContractSiteJobOfWorkID() As Integer
                Get
                    Return _QuoteContractSiteJobOfWorkID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteJobOfWorkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteJobOfWorkID", Value)
                End Set
            End Property


            Private _EstimatedVisitDate As DateTime = Nothing
            Public Property EstimatedVisitDate() As DateTime
                Get
                    Return _EstimatedVisitDate
                End Get
                Set(ByVal Value As DateTime)
                    _EstimatedVisitDate = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

