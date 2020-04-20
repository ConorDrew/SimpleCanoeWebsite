Imports System.Data.SqlClient

Namespace Entity

    Namespace CustomerScheduleOfRates

        Public Class CustomerScheduleOfRate

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

#Region "CustomerScheduleOfRate Properties"


            Private _CustomerScheduleOfRateID As Integer = 0
            Public ReadOnly Property CustomerScheduleOfRateID() As Integer
                Get
                    Return _CustomerScheduleOfRateID
                End Get
            End Property
            Public WriteOnly Property SetCustomerScheduleOfRateID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CustomerScheduleOfRateID", Value)
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


            Private _ScheduleOfRatesCategoryID As Integer = 0
            Public ReadOnly Property ScheduleOfRatesCategoryID() As Integer
                Get
                    Return _ScheduleOfRatesCategoryID
                End Get
            End Property
            Public WriteOnly Property SetScheduleOfRatesCategoryID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ScheduleOfRatesCategoryID", Value)
                End Set
            End Property


            Private _Code As String = String.Empty
            Public ReadOnly Property Code() As String
                Get
                    Return _Code
                End Get
            End Property
            Public WriteOnly Property SetCode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Code", Value)
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


            Private _Price As Double = 0
            Public ReadOnly Property Price() As Double
                Get
                    Return _Price
                End Get
            End Property
            Public WriteOnly Property SetPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Price", Value)
                End Set
            End Property


            Private _AllowDeleted As Boolean = True
            Public ReadOnly Property AllowDeleted() As Boolean
                Get
                    Return _AllowDeleted
                End Get
            End Property
            Public WriteOnly Property SetAllowDeleted() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AllowDeleted", Value)
                End Set
            End Property


            Private _TimeInMins As Integer = 0
            Public ReadOnly Property TimeInMins() As Integer
                Get
                    Return _TimeInMins
                End Get
            End Property
            Public WriteOnly Property SetTimeInMins() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TimeInMins", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace
