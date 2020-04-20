Imports System.Data.SqlClient

Namespace Entity

    Namespace CustomerCharges

        Public Class CustomerCharge

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

#Region "CustomerCharge Properties"


            Private _CustomerChargeID As Integer = 0
            Public ReadOnly Property CustomerChargeID() As Integer
                Get
                    Return _CustomerChargeID
                End Get
            End Property
            Public WriteOnly Property SetCustomerChargeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CustomerChargeID", Value)
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

            Private _MileageRate As Double = 1
            Public ReadOnly Property MileageRate() As Double
                Get
                    Return _MileageRate
                End Get
            End Property
            Public WriteOnly Property SetMileageRate() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MileageRate", Value)
                End Set
            End Property

            Private _PartsMarkup As Double = 0
            Public ReadOnly Property PartsMarkup() As Double
                Get
                    Return _PartsMarkup
                End Get
            End Property
            Public WriteOnly Property SetPartsMarkup() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsMarkup", Value)
                End Set
            End Property


            Private _RatesMarkup As Double = 0
            Public ReadOnly Property RatesMarkup() As Double
                Get
                    Return _RatesMarkup
                End Get
            End Property
            Public WriteOnly Property SetRatesMarkup() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RatesMarkup", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

