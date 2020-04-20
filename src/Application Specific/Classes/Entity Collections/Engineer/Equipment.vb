
Imports System.Data.SqlClient

Namespace Entity

    Namespace Engineers
        Public Class Equipment

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

#Region "Engineer Properties"


            Private _EquipmentID As Integer = 0
            Public ReadOnly Property EquipmentID() As Integer
                Get
                    Return _EquipmentID
                End Get
            End Property
            Public WriteOnly Property SetEquipmentID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EquipmentID", Value)
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


      


            Private _EquipmentTypeID As Integer = 0
            Public ReadOnly Property EquipmentTypeID() As Integer
                Get
                    Return _EquipmentTypeID
                End Get
            End Property
            Public WriteOnly Property SetEquipmentTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EquipmentTypeID", Value)
                End Set
            End Property


            Private _SerialNumber As String = ""
            Public ReadOnly Property SerialNumber() As String
                Get
                    Return _SerialNumber
                End Get
            End Property
            Public WriteOnly Property SetSerialNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SerialNumber", Value)
                End Set
            End Property


            Private _CertificateNumber As String = ""
            Public ReadOnly Property CertificateNumber() As String
                Get
                    Return _CertificateNumber
                End Get
            End Property
            Public WriteOnly Property SetCertificateNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CertificateNumber", Value)
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


            Private _CalibrationDate As DateTime = Nothing
            Public Property CalibrationDate() As DateTime
                Get
                    Return _CalibrationDate
                End Get
                Set(ByVal Value As DateTime)
                    _CalibrationDate = Value
                End Set
            End Property


            Private _CalibrationMonths As Double = 0
            Public ReadOnly Property CalibrationMonths() As Double
                Get
                    Return _CalibrationMonths
                End Get
            End Property
            Public WriteOnly Property SetCalibrationMonths() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CalibrationMonths", Value)
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

            Private _EngineerID As Integer = 0
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

            Private _Notes As String = ""
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

            Private _AssetNo As String = ""
            Public ReadOnly Property AssetNo() As String
                Get
                    Return _AssetNo
                End Get
            End Property
            Public WriteOnly Property SetAssetNo() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AssetNo", Value)
                End Set
            End Property

            Private _StatusChangeDate As DateTime = Nothing
            Public Property StatusChangeDate() As DateTime
                Get
                    Return _StatusChangeDate
                End Get
                Set(ByVal Value As DateTime)
                    _StatusChangeDate = Value
                End Set
            End Property
#End Region

        End Class

    End Namespace

End Namespace
