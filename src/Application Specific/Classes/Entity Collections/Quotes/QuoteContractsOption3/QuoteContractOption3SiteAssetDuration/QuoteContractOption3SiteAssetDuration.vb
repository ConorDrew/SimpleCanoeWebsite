Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOption3SiteAssetDurations

        Public Class QuoteContractOption3SiteAssetDuration

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

#Region "QuoteContractOption3SiteAssetDuration Properties"


            Private _QuoteContractSiteAssetDurationID As Integer = 0
            Public ReadOnly Property QuoteContractSiteAssetDurationID() As Integer
                Get
                    Return _QuoteContractSiteAssetDurationID
                End Get
            End Property
            Public WriteOnly Property SetQuoteContractSiteAssetDurationID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteContractSiteAssetDurationID", Value)
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


            Private _AssetID As Integer = 0
            Public ReadOnly Property AssetID() As Integer
                Get
                    Return _AssetID
                End Get
            End Property
            Public WriteOnly Property SetAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AssetID", Value)
                End Set
            End Property


            Private _ScheduledMonth As DateTime = Nothing
            Public Property ScheduledMonth() As DateTime
                Get
                    Return _ScheduledMonth
                End Get
                Set(ByVal Value As DateTime)
                    _ScheduledMonth = Value
                End Set
            End Property


            Private _VisitDuration As Double = 0
            Public ReadOnly Property VisitDuration() As Double
                Get
                    Return _VisitDuration
                End Get
            End Property
            Public WriteOnly Property SetVisitDuration() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VisitDuration", Value)
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

