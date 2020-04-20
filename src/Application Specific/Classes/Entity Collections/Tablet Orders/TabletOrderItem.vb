Imports System.Data.SqlClient

Namespace Entity

    Namespace TabletOrders

        Public Class TabletOrderItem

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


            Private _TabletOrderID As Integer = 0
            Public ReadOnly Property TabletOrderID() As Integer
                Get
                    Return _TabletOrderID
                End Get
            End Property
            Public WriteOnly Property SetTabletOrderID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TabletOrderID", Value)
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

            Private _SupplierID As Integer
            Public ReadOnly Property SupplierID() As Integer
                Get
                    Return _SupplierID
                End Get
            End Property
            Public WriteOnly Property SetSupplierID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SupplierID", Value)
                End Set
            End Property

            Private _SelectedVisitID As Integer
            Public ReadOnly Property SelectedVisitID() As String
                Get
                    Return _SelectedVisitID
                End Get
            End Property
            Public WriteOnly Property SetSelectedVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SelectedVisitID", Value)
                End Set
            End Property

            Private _ForNextVisit As Boolean
            Public ReadOnly Property ForNextVisit() As Boolean
                Get
                    Return _ForNextVisit
                End Get
            End Property
            Public WriteOnly Property SetForNextVisit() As Object
                Set(ByVal Value As Object)
                    _ForNextVisit = Value
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

            Private _OrderCreated As Date
            Public ReadOnly Property OrderCreated() As Date
                Get
                    Return _OrderCreated
                End Get
            End Property
            Public WriteOnly Property SetOrderCreated() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderCreated", Value)
                End Set
            End Property

            Private _LastUpdated As Date
            Public ReadOnly Property LastUpdated() As Date
                Get
                    Return _LastUpdated
                End Get
            End Property
            Public WriteOnly Property SetLastUpdated() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LastUpdated", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

