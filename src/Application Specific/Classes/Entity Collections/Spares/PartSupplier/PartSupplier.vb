Imports System.Data.SqlClient

Namespace Entity

    Namespace PartSuppliers

        Public Class PartSupplier

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

#Region "PartSupplier Properties"


            Private _PartSupplierID As Integer = 0
            Public ReadOnly Property PartSupplierID() As Integer
                Get
                    Return _PartSupplierID
                End Get
            End Property
            Public WriteOnly Property SetPartSupplierID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartSupplierID", Value)
                End Set
            End Property


            Private _PartCode As String = String.Empty
            Public ReadOnly Property PartCode() As String
                Get
                    Return _PartCode
                End Get
            End Property
            Public WriteOnly Property SetPartCode() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartCode", Value)
                End Set
            End Property


            Private _PartID As Integer = 0
            Public ReadOnly Property PartID() As Integer
                Get
                    Return _PartID
                End Get
            End Property
            Public WriteOnly Property SetPartID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartID", Value)
                End Set
            End Property


            Private _SupplierID As Integer = 0
            Public ReadOnly Property SupplierID() As Integer
                Get
                    Return _SupplierID
                End Get
            End Property
            Public WriteOnly Property SetSupplierID() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SupplierID", Value)
                End Set
            End Property

            Private _Price As Double = 0
            Public ReadOnly Property Price() As Double
                Get
                    Return _Price
                End Get
            End Property
            Public WriteOnly Property SetPrice() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Price", Value)
                End Set
            End Property

            Private _SecondaryPrice As Double = 0
            Public ReadOnly Property SecondaryPrice() As Double
                Get
                    Return _SecondaryPrice
                End Get
            End Property
            Public WriteOnly Property SetSecondaryPrice() As Object
                Set(Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SecondaryPrice", Value)
                End Set
            End Property

            Private _QuantityInPack As Double = 0
            Public ReadOnly Property QuantityInPack() As Double
                Get
                    Return _QuantityInPack
                End Get
            End Property
            Public WriteOnly Property SetQuantityInPack() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_QuantityInPack", Value)
                End Set
            End Property

            Private _preferred As Boolean = False
            Public ReadOnly Property Preferred() As Boolean
                Get
                    Return _preferred
                End Get
            End Property
            Public WriteOnly Property SetPreferred() As Boolean
                Set(ByVal Value As Boolean)
                    _preferred = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

