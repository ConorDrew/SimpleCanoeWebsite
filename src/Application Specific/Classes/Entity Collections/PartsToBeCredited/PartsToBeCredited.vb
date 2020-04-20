Imports System.Data.SqlClient

Namespace Entity

    Namespace PartsToBeCrediteds

        Public Class PartsToBeCredited

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

#Region "PartsToBeCredited Properties"


            Private _PartsToBeCreditedID As Integer = 0
            Public ReadOnly Property PartsToBeCreditedID() As Integer
                Get
                    Return _PartsToBeCreditedID
                End Get
            End Property
            Public WriteOnly Property SetPartsToBeCreditedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartsToBeCreditedID", Value)
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


            Private _SupplierID As Integer = 0
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


            Private _PartID As Integer = 0
            Public ReadOnly Property PartID() As Integer
                Get
                    Return _PartID
                End Get
            End Property
            Public WriteOnly Property SetPartID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartID", Value)
                End Set
            End Property

            Private _Qty As Integer = 0
            Public ReadOnly Property Qty() As Integer
                Get
                    Return _Qty
                End Get
            End Property
            Public WriteOnly Property SetQty() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Qty", Value)
                End Set
            End Property
             

            Private _ManuallyAdded As Boolean = False
            Public ReadOnly Property ManuallyAdded() As Integer
                Get
                    Return _ManuallyAdded
                End Get
            End Property
            Public WriteOnly Property SetManuallyAdded() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ManuallyAdded", Value)
                End Set
            End Property


            Private _StatusID As Integer = 0
            Public ReadOnly Property StatusID() As Integer
                Get
                    Return _StatusID
                End Get
            End Property
            Public WriteOnly Property SetStatusID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_StatusID", Value)
                End Set
            End Property


            Private _CreditReceived As Double = 0
            Public ReadOnly Property CreditReceived() As Double
                Get
                    Return _CreditReceived
                End Get
            End Property
            Public WriteOnly Property SetCreditReceived() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CreditReceived", Value)
                End Set
            End Property


            Private _OrderReference As String = 0
            Public ReadOnly Property OrderReference() As String
                Get
                    Return _OrderReference
                End Get
            End Property
            Public WriteOnly Property SetOrderReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OrderReference", Value)
                End Set
            End Property

            Private _PartOrderID As Integer = 0
            Public ReadOnly Property PartOrderID() As Integer
                Get
                    Return _PartOrderID
                End Get
            End Property
            Public WriteOnly Property SetPartOrderID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartOrderID", Value)
                End Set
            End Property


            Private _ReturnRef As String = 0
            Public ReadOnly Property ReturnRef() As String
                Get
                    Return _ReturnRef
                End Get
            End Property
            Public WriteOnly Property SetReturnRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReturnRef", Value)
                End Set
            End Property


#End Region

        End Class

    End Namespace

End Namespace

