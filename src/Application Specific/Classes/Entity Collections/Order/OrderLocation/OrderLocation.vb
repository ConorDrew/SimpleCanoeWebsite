Imports System.Data.SqlClient

Namespace Entity

    Namespace OrderLocations

        Public Class OrderLocation

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

#Region "OrderLocation Properties"


            Private _OrderLocationID As Integer = 0
            Public ReadOnly Property OrderLocationID() As Integer
                Get
                    Return _OrderLocationID
                End Get
            End Property
            Public WriteOnly Property SetOrderLocationID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderLocationID", Value)
                End Set
            End Property


            Private _OrderID As Integer = 0
            Public ReadOnly Property OrderID() As Integer
                Get
                    Return _OrderID
                End Get
            End Property
            Public WriteOnly Property SetOrderID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderID", Value)
                End Set
            End Property


            Private _LocationID As Integer = 0
            Public ReadOnly Property LocationID() As Integer
                Get
                    Return _LocationID
                End Get
            End Property
            Public WriteOnly Property SetLocationID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LocationID", Value)
                End Set
            End Property


            Private _deliveryAddressID As Integer = 0
            Public ReadOnly Property DeliveryAddressID() As Integer
                Get
                    Return _deliveryAddressID
                End Get
            End Property
            Public WriteOnly Property SetDeliveryAddressID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_deliveryAddressID", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

