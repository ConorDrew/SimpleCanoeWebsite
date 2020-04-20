Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternativeSiteJobItems

        Public Class QuoteContractAlternativeSiteJobItems

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

#Region " Quote Contract Alternative Site Job Items Properties"


            Private _QuoteContractSiteJobItemID As Integer = 0
            Public ReadOnly Property QuoteContractSiteJobItemID() As Integer
                Get
                    Return _QuoteContractSiteJobItemID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteJobItemID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteJobItemID", Value)
                End Set
            End Property


            Private _QuoteContractSiteID As Integer = 0
            Public ReadOnly Property QuoteContractSiteID() As Integer
                Get
                    Return _QuoteContractSiteID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteID", Value)
                End Set
            End Property


            Private _Description As String = String.Empty
            Public ReadOnly Property Description() As String
                Get
                    Return _Description
                End Get
            End Property
            Public WriteOnly Property SetDescription() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Description", Value)
                End Set
            End Property


            Private _VisitFrequencyID As Integer = 0
            Public ReadOnly Property VisitFrequencyID() As Integer
                Get
                    Return _VisitFrequencyID
                End Get
            End Property
            Public WriteOnly Property SetVisitFrequencyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitFrequencyID", Value)
                End Set
            End Property


            Private _VisitDuration As Integer = 0
            Public ReadOnly Property VisitDuration() As Integer
                Get
                    Return _VisitDuration
                End Get
            End Property
            Public WriteOnly Property SetVisitDuration() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitDuration", Value)
                End Set
            End Property


            Private _ItemPricePerVisit As Double = 0.0
            Public ReadOnly Property ItemPricePerVisit() As Double
                Get
                    Return _ItemPricePerVisit
                End Get
            End Property
            Public WriteOnly Property SetItemPricePerVisit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ItemPricePerVisit", Value)
                End Set
            End Property


            Private _JobOfWorkID As Integer = 0
            Public ReadOnly Property JobOfWorkID() As Integer
                Get
                    Return _JobOfWorkID
                End Get
            End Property
            Public WriteOnly Property SetJobOfWorkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobOfWorkID", Value)
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

