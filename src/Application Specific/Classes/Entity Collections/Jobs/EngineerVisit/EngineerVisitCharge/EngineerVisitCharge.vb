Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitCharges

        Public Class EngineerVisitCharge

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

#Region "EngineerVisitCharge Properties"

            Private _EngineerVisitChargeID As Integer = 0

            Public ReadOnly Property EngineerVisitChargeID() As Integer
                Get
                    Return _EngineerVisitChargeID
                End Get
            End Property

            Public WriteOnly Property SetEngineerVisitChargeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EngineerVisitChargeID", Value)
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

            Private _LabourRate As Double = 1

            Public ReadOnly Property LabourRate() As Double
                Get
                    Return _LabourRate
                End Get
            End Property

            Public WriteOnly Property SetLabourRate() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LabourRate", Value)
                End Set
            End Property

            Private _ApplyMileageToTotal As Boolean = True

            Public ReadOnly Property ApplyMileageToTotal() As Boolean
                Get
                    Return _ApplyMileageToTotal
                End Get
            End Property

            Public WriteOnly Property SetApplyMileageToTotal() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ApplyMileageToTotal", Value)
                End Set
            End Property

            Private _JobValue As Double = 0

            Public ReadOnly Property JobValue() As Double
                Get
                    Return _JobValue
                End Get
            End Property

            Public WriteOnly Property SetJobValue() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_JobValue", Value)
                End Set
            End Property

            Private _ChargeTypeID As Integer = 0

            Public ReadOnly Property ChargeTypeID() As Integer
                Get
                    Return _ChargeTypeID
                End Get
            End Property

            Public WriteOnly Property SetChargeTypeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ChargeTypeID", Value)
                End Set
            End Property

            Private _Charge As Double = 0

            Public ReadOnly Property Charge() As Double
                Get
                    Return _Charge
                End Get
            End Property

            Public WriteOnly Property SetCharge() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Charge", Value)
                End Set
            End Property

            Private _InvoiceReadyID As Integer = 0

            Public ReadOnly Property InvoiceReadyID() As Integer
                Get
                    Return _InvoiceReadyID
                End Get
            End Property

            Public WriteOnly Property SetInvoiceReadyID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_InvoiceReadyID", Value)
                End Set
            End Property

            Private _mainContractorDiscount As Decimal = 0

            Public ReadOnly Property MainContractorDiscount() As Decimal
                Get
                    Return _mainContractorDiscount
                End Get
            End Property

            Public WriteOnly Property SetMainContractorDiscount() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_mainContractorDiscount", Value)
                End Set
            End Property

            Private _NominalCode As String = ""

            Public ReadOnly Property NominalCode() As String
                Get
                    Return _NominalCode
                End Get
            End Property

            Public WriteOnly Property SetNominalCode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NominalCode", Value)
                End Set
            End Property

            Private _Department As String = ""

            Public ReadOnly Property Department() As String
                Get
                    Return _Department
                End Get
            End Property

            Public WriteOnly Property SetDepartment() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Department", Value)
                End Set
            End Property

            Private _ForSageAccountCode As String = ""

            Public ReadOnly Property ForSageAccountCode() As String
                Get
                    Return _ForSageAccountCode
                End Get
            End Property

            Public WriteOnly Property SetForSageAccountCode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ForSageAccountCode", Value)
                End Set
            End Property

            Private _TaxRateID As Integer = 0

            Public ReadOnly Property TaxRateID() As Integer
                Get
                    Return _TaxRateID
                End Get
            End Property

            Public WriteOnly Property SetTaxRateID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TaxRateID", Value)
                End Set
            End Property

            Private _partsMarkUp As Integer = 0

            Public ReadOnly Property PartsMarkUp() As Integer
                Get
                    Return _partsMarkUp
                End Get
            End Property

            Public WriteOnly Property SetPartsMarkUp() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_partsMarkUp", Value)
                End Set
            End Property

            Private _partsPrice As Decimal = 0

            Public ReadOnly Property PartsPrice() As Decimal
                Get
                    Return _partsPrice
                End Get
            End Property

            Public WriteOnly Property SetPartsPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_partsPrice", Value)
                End Set
            End Property

            Private _labourPrice As Decimal = 0

            Public ReadOnly Property LabourPrice() As Decimal
                Get
                    Return _labourPrice
                End Get
            End Property

            Public WriteOnly Property SetLabourPrice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_labourPrice", Value)
                End Set
            End Property

            Private _hasChargeFromJob As Boolean

            Public ReadOnly Property HasChargesFromJob() As Boolean
                Get
                    Return _hasChargeFromJob
                End Get
            End Property

            Public WriteOnly Property SetHasChargesFromJob() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_hasChargeFromJob", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace