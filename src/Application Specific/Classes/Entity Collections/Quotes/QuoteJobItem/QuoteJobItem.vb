Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteJobItems

        Public Class QuoteJobItem

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

#End Region

#Region "QuoteJobItem Properties"

            Private _QuoteJobItemID As Integer = 0

            Public ReadOnly Property QuoteJobItemID() As Integer
                Get
                    Return _QuoteJobItemID
                End Get
            End Property

            Public WriteOnly Property SetQuoteJobItemID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuoteJobItemID", Value)
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

            Private _Summary As String = String.Empty

            Public ReadOnly Property Summary() As String
                Get
                    Return _Summary
                End Get
            End Property

            Public WriteOnly Property SetSummary() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Summary", Value)
                End Set
            End Property

            Private _RateID As Integer = 0

            Public ReadOnly Property RateID() As Integer
                Get
                    Return _RateID
                End Get
            End Property

            Public WriteOnly Property SetRateID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RateID", Value)
                End Set
            End Property

            Private _Qty As Decimal

            Public ReadOnly Property Qty() As Decimal
                Get
                    Return _Qty
                End Get
            End Property

            Public WriteOnly Property SetQty() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Qty", Value)
                End Set
            End Property

            Private _systemLinkId As Integer = 0

            Public ReadOnly Property SystemLinkID() As Integer
                Get
                    Return _systemLinkId
                End Get
            End Property

            Public WriteOnly Property SetSystemLinkID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_systemLinkId", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace