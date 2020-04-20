Imports System.Data.SqlClient

Namespace Entity

    Namespace TabletOrders

        Public Class TabletOrderPart

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

#Region "Tablet Order Properties"


            Private _OrderPartID As Integer = 0
            Public ReadOnly Property OrderPartID() As Integer
                Get
                    Return _OrderPartID
                End Get
            End Property
            Public WriteOnly Property SetOrderPartID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderPartID", Value)
                End Set
            End Property

            Private _OrderID As Integer
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

            Private _EngineerID As Integer
            Public ReadOnly Property EngineerID() As Integer
                Get
                    Return _EngineerID
                End Get
            End Property
            Public WriteOnly Property SetEngineerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerID", Value)
                End Set
            End Property

            Private _Quantity As Integer
            Public ReadOnly Property Quantity() As String
                Get
                    Return _Quantity
                End Get
            End Property
            Public WriteOnly Property SetQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Quantity", Value)
                End Set
            End Property

            Private _PartSupplierID As Integer
            Public ReadOnly Property PartSupplierID() As String
                Get
                    Return _PartSupplierID
                End Get
            End Property
            Public WriteOnly Property SetPartSupplierID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartSupplierID", Value)
                End Set
            End Property

            Private _Status As String = String.Empty
            Public ReadOnly Property Status() As String
                Get
                    Return _Status
                End Get
            End Property
            Public WriteOnly Property SetStatus() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Status", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

