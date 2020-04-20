Imports System.Data.SqlClient

Namespace Entity

    Namespace Assets

        Public Class Asset

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

#Region "Asset Properties"


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


            Private _PropertyID As Integer = 0
            Public ReadOnly Property PropertyID() As Integer
                Get
                    Return _PropertyID
                End Get
            End Property
            Public WriteOnly Property SetPropertyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PropertyID", Value)
                End Set
            End Property


            Private _ProductID As Integer = 0
            Public ReadOnly Property ProductID() As Integer
                Get
                    Return _ProductID
                End Get
            End Property
            Public WriteOnly Property SetProductID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ProductID", Value)
                End Set
            End Property


            Private _SerialNum As String = String.Empty
            Public ReadOnly Property SerialNum() As String
                Get
                    Return _SerialNum
                End Get
            End Property
            Public WriteOnly Property SetSerialNum() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SerialNum", Value)
                End Set
            End Property


            Private _DateFitted As DateTime = Nothing
            Public Property DateFitted() As DateTime
                Get
                    Return _DateFitted
                End Get
                Set(ByVal Value As DateTime)
                    _DateFitted = Value
                End Set
            End Property


            Private _Location As String = String.Empty
            Public ReadOnly Property Location() As String
                Get
                    Return _Location
                End Get
            End Property
            Public WriteOnly Property SetLocation() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Location", Value)
                End Set
            End Property


            Private _CertificateLastIssued As DateTime = Nothing
            Public Property CertificateLastIssued() As DateTime
                Get
                    Return _CertificateLastIssued
                End Get
                Set(ByVal Value As DateTime)
                    _CertificateLastIssued = Value
                End Set
            End Property


            Private _LastServicedDate As DateTime = Nothing
            Public Property LastServicedDate() As DateTime
                Get
                    Return _LastServicedDate
                End Get
                Set(ByVal Value As DateTime)
                    _LastServicedDate = Value
                End Set
            End Property


            Private _BoughtFrom As String = String.Empty
            Public ReadOnly Property BoughtFrom() As String
                Get
                    Return _BoughtFrom
                End Get
            End Property
            Public WriteOnly Property SetBoughtFrom() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BoughtFrom", Value)
                End Set
            End Property


            Private _SuppliedBy As String = String.Empty
            Public ReadOnly Property SuppliedBy() As String
                Get
                    Return _SuppliedBy
                End Get
            End Property
            Public WriteOnly Property SetSuppliedBy() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SuppliedBy", Value)
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

            Private _GCNumber As String = String.Empty
            Public ReadOnly Property GCNumber() As String
                Get
                    Return _GCNumber
                End Get
            End Property
            Public WriteOnly Property SetGCNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GCNumber", Value)
                End Set
            End Property

            Private _YearOfManufacture As String = String.Empty
            Public ReadOnly Property YearOfManufacture() As String
                Get
                    Return _YearOfManufacture
                End Get
            End Property
            Public WriteOnly Property SetYearOfManufacture() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_YearOfManufacture", Value)
                End Set
            End Property

            Private _ApproximateValue As Double = 0
            Public ReadOnly Property ApproximateValue() As Double
                Get
                    Return _ApproximateValue
                End Get
            End Property
            Public WriteOnly Property SetApproximateValue() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ApproximateValue", Value)
                End Set
            End Property

            Private _WarrantyStartDate As DateTime = Nothing
            Public Property WarrantyStartDate() As DateTime
                Get
                    Return _WarrantyStartDate
                End Get
                Set(ByVal Value As DateTime)
                    _WarrantyStartDate = Value
                End Set
            End Property



            Private _WarrantyEndDate As DateTime = Nothing
            Public Property WarrantyEndDate() As DateTime
                Get
                    Return _WarrantyEndDate
                End Get
                Set(ByVal Value As DateTime)
                    _WarrantyEndDate = Value
                End Set
            End Property

            Private _GasTypeID As Integer = 0
            Public ReadOnly Property GasTypeID() As Integer
                Get
                    Return _GasTypeID
                End Get
            End Property
            Public WriteOnly Property SetGasTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_GasTypeID", Value)
                End Set
            End Property

            Private _FlueTypeID As Integer = 0
            Public ReadOnly Property FlueTypeID() As Integer
                Get
                    Return _FlueTypeID
                End Get
            End Property
            Public WriteOnly Property SetFlueTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FlueTypeID", Value)
                End Set
            End Property


            Private _Active As Boolean = False
            Public ReadOnly Property Active() As Boolean
                Get
                    Return _Active
                End Get
            End Property
            Public WriteOnly Property SetActive() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Active", Value)
                End Set
            End Property


            Private _TenantsAppliance As Boolean = False
            Public ReadOnly Property TenantsAppliance() As Boolean
                Get
                    Return _TenantsAppliance
                End Get
            End Property
            Public WriteOnly Property SetTenantsAppliance() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TenantsAppliance", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace

