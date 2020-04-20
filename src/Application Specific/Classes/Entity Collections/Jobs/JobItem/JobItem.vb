Imports System.Data.SqlClient

Namespace Entity

    Namespace JobItems

        Public Class JobItem

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

#Region "JobItem Properties"

            Private _JobItemID As Integer = 0

            Public ReadOnly Property JobItemID() As Integer
                Get
                    Return _JobItemID
                End Get
            End Property

            Public WriteOnly Property SetJobItemID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobItemID", Value)
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