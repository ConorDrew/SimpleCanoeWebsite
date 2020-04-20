Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitsPartsAndProducts

        Public Class EngineerVisitPartsAndProducts

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

#Region "EngineerVisitPartsAndProducts Properties"

            Private _PartOrProductID As Integer = 0
            Public ReadOnly Property PartOrProductID() As Integer
                Get
                    Return _PartOrProductID
                End Get
            End Property
            Public WriteOnly Property SetPartOrProductID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PartOrProductID", Value)
                End Set
            End Property

            Private _EngineerVisitID As Integer = 0
            Public ReadOnly Property EngineerVisitID() As Integer
                Get
                    Return _EngineerVisitID
                End Get
            End Property
            Public WriteOnly Property SetEngineerVisitID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitID", Value)
                End Set
            End Property

            Private _Quantity As Integer = 0
            Public ReadOnly Property Quantity() As Integer
                Get
                    Return _Quantity
                End Get
            End Property
            Public WriteOnly Property SetQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Quantity", Value)
                End Set
            End Property

            Private _AssetID As Integer = 0
            Public ReadOnly Property AssetID() As Integer
                Get
                    Return _AssetID
                End Get
            End Property
            Public WriteOnly Property SetAssetID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AssetID", Value)
                End Set
            End Property

            Private _AllocatedID As Integer = 0
            Public ReadOnly Property AllocatedID() As Integer
                Get
                    Return _AllocatedID
                End Get
            End Property
            Public WriteOnly Property SetAllocatedID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AllocatedID", Value)
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


            Private _SpecialPrice As Double = 0.0
            Public ReadOnly Property SpecialPrice() As Double
                Get
                    Return _SpecialPrice
                End Get
            End Property
            Public WriteOnly Property SetSpecialPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SpecialPrice", Value)
                End Set

            End Property

            Private _SpecialPartNumber As String = ""
            Public ReadOnly Property SpecialPartNumber() As String
                Get
                    Return _SpecialPartNumber
                End Get
            End Property
            Public WriteOnly Property SetSpecialPartNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SpecialPartNumber", Value)
                End Set
            End Property

            Private _SpecialDescription As String = ""
            Public ReadOnly Property SpecialDescription() As String
                Get
                    Return _SpecialDescription
                End Get
            End Property
            Public WriteOnly Property SetSpecialDescription() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SpecialDescription", Value)
                End Set
            End Property



#End Region

        End Class

    End Namespace

End Namespace

