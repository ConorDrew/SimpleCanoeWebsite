Imports System.Data.SqlClient

Namespace Entity

    Namespace Parts

        Public Class Part

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

#Region "Part Properties"

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


            Private _SPartID As Integer = 0
            Public ReadOnly Property SPartID() As Integer
                Get
                    Return _SPartID
                End Get
            End Property
            Public WriteOnly Property SetSPartID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SPartID", Value)
                End Set
            End Property


            Private _CategoryID As Integer = 0
            Public ReadOnly Property CategoryID() As Integer
                Get
                    Return _CategoryID
                End Get
            End Property

            Private _MakeID As Integer = 0
            Public ReadOnly Property MakeID() As Integer
                Get
                    Return _MakeID
                End Get
            End Property
            Public WriteOnly Property SetMakeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MakeID", Value)
                End Set
            End Property

            Private _FuelID As Integer = 0
            Public ReadOnly Property FuelID() As Integer
                Get
                    Return _FuelID
                End Get
            End Property
            Public WriteOnly Property SetFuelID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FuelID", Value)
                End Set
            End Property

            Public WriteOnly Property SetCategoryID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CategoryID", Value)
                End Set
            End Property

            Private _UnitTypeID As Integer = 0
            Public ReadOnly Property UnitTypeID() As Integer
                Get
                    Return _UnitTypeID
                End Get
            End Property
            Public WriteOnly Property SetUnitTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UnitTypeID", Value)
                End Set
            End Property

            Private _Name As String = String.Empty
            Public ReadOnly Property Name() As String
                Get
                    Return _Name
                End Get
            End Property
            Public WriteOnly Property SetName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Name", Value)
                End Set
            End Property


            Private _Number As String = String.Empty
            Public ReadOnly Property Number() As String
                Get
                    Return _Number
                End Get
            End Property
            Public WriteOnly Property SetNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Number", Value)
                End Set
            End Property


            Private _Reference As String = String.Empty
            Public ReadOnly Property Reference() As String
                Get
                    Return _Reference
                End Get
            End Property
            Public WriteOnly Property SetReference() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Reference", Value)
                End Set
            End Property


            Private _Notes As String = String.Empty
            Public ReadOnly Property Notes() As String
                Get
                    Return _Notes
                End Get
            End Property
            Public WriteOnly Property SetNotes() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Notes", Value)
                End Set
            End Property

            Private _sellPrice As Double = 0
            Public ReadOnly Property SellPrice() As Double
                Get
                    Return _sellPrice
                End Get
            End Property
            Public WriteOnly Property SetSellPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_sellPrice", Value)
                End Set
            End Property

            Private _MinimumQuantity As Integer = 0
            Public ReadOnly Property MinimumQuantity() As Integer
                Get
                    Return _MinimumQuantity
                End Get
            End Property
            Public WriteOnly Property SetMinimumQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_MinimumQuantity", Value)
                End Set
            End Property

            Private _RecommendedQuantity As Integer = 0
            Public ReadOnly Property RecommendedQuantity() As Integer
                Get
                    Return _RecommendedQuantity
                End Get
            End Property
            Public WriteOnly Property SetRecommendedQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_RecommendedQuantity", Value)
                End Set
            End Property

            Private _WarehouseID As Integer = 0
            Public ReadOnly Property WarehouseID() As Integer
                Get
                    Return _WarehouseID
                End Get
            End Property
            Public WriteOnly Property SetWarehouseID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_WarehouseID", Value)
                End Set
            End Property

            Private _BinID As Integer = 0
            Public ReadOnly Property BinID() As Integer
                Get
                    Return _BinID
                End Get
            End Property
            Public WriteOnly Property SetBinID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BinID", Value)
                End Set
            End Property

            Private _ShelfID As Integer = 0
            Public ReadOnly Property ShelfID() As Integer
                Get
                    Return _ShelfID
                End Get
            End Property
            Public WriteOnly Property SetShelfID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ShelfID", Value)
                End Set
            End Property

            Private _WarehouseQuantity As Integer = 0
            Public ReadOnly Property WarehouseQuantity() As Integer
                Get
                    Return _WarehouseQuantity
                End Get
            End Property
            Public WriteOnly Property SetWarehouseQuantity() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_WarehouseQuantity", Value)
                End Set
            End Property

            Private _WarehouseIDAlternative As Integer = 0
            Public ReadOnly Property WarehouseIDAlternative() As Integer
                Get
                    Return _WarehouseIDAlternative
                End Get
            End Property
            Public WriteOnly Property SetWarehouseIDAlternative() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_WarehouseIDAlternative", Value)
                End Set
            End Property

            Private _BinIDAlternative As Integer = 0
            Public ReadOnly Property BinIDAlternative() As Integer
                Get
                    Return _BinIDAlternative
                End Get
            End Property
            Public WriteOnly Property SetBinIDAlternative() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BinIDAlternative", Value)
                End Set
            End Property

            Private _ShelfIDAlternative As Integer = 0
            Public ReadOnly Property ShelfIDAlternative() As Integer
                Get
                    Return _ShelfIDAlternative
                End Get
            End Property
            Public WriteOnly Property SetShelfIDAlternative() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ShelfIDAlternative", Value)
                End Set
            End Property

            Private _EndFlagged As Boolean = False
            Public ReadOnly Property EndFlagged() As Boolean
                Get
                    Return _EndFlagged
                End Get
            End Property
            Public WriteOnly Property SetEndFlagged() As Boolean
                Set(ByVal Value As Boolean)
                    _EndFlagged = Value
                End Set
            End Property


            Private _Equipment As Boolean = False
            Public ReadOnly Property Equipment() As Boolean
                Get
                    Return _Equipment
                End Get
            End Property
            Public WriteOnly Property SetEquipment() As Boolean
                Set(ByVal Value As Boolean)
                    _Equipment = Value
                End Set
            End Property

            Private _IsSpecialPart As Boolean = False
            Public ReadOnly Property IsSpecialPart() As Boolean
                Get
                    Return _IsSpecialPart
                End Get
            End Property
            Public WriteOnly Property SetIsSpecialPart() As Boolean
                Set(ByVal Value As Boolean)
                    _IsSpecialPart = Value
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

