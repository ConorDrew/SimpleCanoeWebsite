Imports System.Data.SqlClient

Namespace Entity

    Namespace VATRatess

        Public Class VATRates

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

#Region "VATRates Properties"


            Private _VATRateID As Integer = 0
            Public ReadOnly Property VATRateID() As Integer
                Get
                    Return _VATRateID
                End Get
            End Property
            Public WriteOnly Property SetVATRateID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VATRateID", Value)
                End Set
            End Property


            Private _VATRate As Double = 0
            Public ReadOnly Property VATRate() As Double
                Get
                    Return _VATRate
                End Get
            End Property
            Public WriteOnly Property SetVATRate() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VATRate", Value)
                End Set
            End Property


            Private _DateIntroduced As DateTime = Nothing
            Public Property DateIntroduced() As DateTime
                Get
                    Return _DateIntroduced
                End Get
                Set(ByVal Value As DateTime)
                    _DateIntroduced = Value
                End Set
            End Property

            Private _VATRateCode As String = ""
            Public ReadOnly Property VATRateCode() As String
                Get
                    Return _VATRateCode
                End Get
            End Property
            Public WriteOnly Property SetVATRateCode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_VATRateCode", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

