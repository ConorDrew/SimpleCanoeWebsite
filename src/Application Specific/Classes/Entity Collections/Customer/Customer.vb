Imports System.Data.SqlClient

Namespace Entity.Customers

    Public Class Customer

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

#Region "Customer Properties"

        Private _CustomerID As Integer = 0

        Public ReadOnly Property CustomerID() As Integer
            Get
                Return _CustomerID
            End Get
        End Property

        Public WriteOnly Property SetCustomerID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_CustomerID", Value)
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

        Private _RegionID As Integer = 0

        Public ReadOnly Property RegionID() As Integer
            Get
                Return _RegionID
            End Get
        End Property

        Public WriteOnly Property SetRegionID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_RegionID", Value)
            End Set
        End Property

        Private _CustomerTypeID As Integer = 0

        Public ReadOnly Property CustomerTypeID() As Integer
            Get
                Return _CustomerTypeID
            End Get
        End Property

        Public WriteOnly Property SetCustomerTypeID() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_CustomerTypeID", Value)
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

        Private _AccountNumber As String = String.Empty

        Public ReadOnly Property AccountNumber() As String
            Get
                Return _AccountNumber
            End Get
        End Property

        Public WriteOnly Property SetAccountNumber() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_AccountNumber", Value)
            End Set
        End Property

        Private _Status As Integer = 0

        Public ReadOnly Property Status() As Integer
            Get
                Return _Status
            End Get
        End Property

        Public WriteOnly Property SetStatus() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Status", Value)
            End Set
        End Property

        Private _PoNumReqd As Boolean = False

        Public ReadOnly Property PoNumReqd() As Boolean
            Get
                Return _PoNumReqd
            End Get
        End Property

        Public WriteOnly Property SetPoNumReqd() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_PoNumReqd", Value)
            End Set
        End Property

        Private _SuperBook As Boolean = False

        Public ReadOnly Property SuperBook() As Boolean
            Get
                Return _SuperBook
            End Get
        End Property

        Public WriteOnly Property SetSuperBook() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_SuperBook", Value)
            End Set
        End Property

        Private _AcceptChargesChanges As Boolean = True

        Public ReadOnly Property AcceptChargesChanges() As Boolean
            Get
                Return _AcceptChargesChanges
            End Get
        End Property

        Public WriteOnly Property SetAcceptChargesChanges() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_AcceptChargesChanges", Value)
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

        Private _Logo As Byte() = Nothing

        Public Property Logo() As Byte()
            Get

                If _Logo Is Nothing Then

                End If

                Return _Logo
            End Get
            Set(ByVal Value As Byte())
                _Logo = Value
            End Set
        End Property

        Private _JobPriorityMandatory As Boolean = False

        Public ReadOnly Property JobPriorityMandatory() As Boolean
            Get
                Return _JobPriorityMandatory
            End Get
        End Property

        Public WriteOnly Property SetJobPriorityMandatory() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_JobPriorityMandatory", Value)
            End Set
        End Property

        Private _Nominal As String = String.Empty

        Public ReadOnly Property Nominal() As String
            Get
                Return _Nominal
            End Get
        End Property

        Public WriteOnly Property SetNominal() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Nominal", Value)
            End Set
        End Property

        Private _OverrideDept As String = String.Empty

        Public ReadOnly Property OverrideDept() As String
            Get
                Return _OverrideDept
            End Get
        End Property

        Public WriteOnly Property SetOverrideDept() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_OverrideDept", Value)
            End Set
        End Property

        Private _Terms As Integer = 0

        Public ReadOnly Property Terms() As Integer
            Get
                Return _Terms
            End Get
        End Property

        Public WriteOnly Property SetTerms() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_Terms", Value)
            End Set
        End Property

        Private _SummerServ As Integer = 0

        Public ReadOnly Property SummerServ() As Integer
            Get
                Return _SummerServ
            End Get
        End Property

        Public WriteOnly Property SetSummerServ() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_SummerServ", Value)
            End Set
        End Property

        Private _WinterServ As Integer = 0

        Public ReadOnly Property WinterServ() As Integer
            Get
                Return _WinterServ
            End Get
        End Property

        Public WriteOnly Property SetWinterServ() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_WinterServ", Value)
            End Set
        End Property

        Private _alertEmail As String = String.Empty

        Public ReadOnly Property AlertEmail() As String
            Get
                Return _alertEmail
            End Get
        End Property

        Public WriteOnly Property SetAlertEmail() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_alertEmail", Value)
            End Set
        End Property

        Private _motStyleService As Boolean = False

        Public ReadOnly Property MOTStyleService() As Boolean
            Get
                Return _motStyleService
            End Get
        End Property

        Public WriteOnly Property SetMOTStyleService() As Boolean
            Set(ByVal Value As Boolean)
                _motStyleService = Value
            End Set
        End Property

        Private _isOutOfScope As Boolean = False

        Public ReadOnly Property IsOutOfScope() As Boolean
            Get
                Return _isOutOfScope
            End Get
        End Property

        Public WriteOnly Property SetIsOutOfScope() As Boolean
            Set(ByVal Value As Boolean)
                _isOutOfScope = Value
            End Set
        End Property

        Private _IsPFH As Boolean = False

        Public ReadOnly Property IsPFH() As Boolean
            Get
                Return _IsPFH
            End Get
        End Property

        Public WriteOnly Property SetIsPFH() As Boolean
            Set(ByVal Value As Boolean)
                _IsPFH = Value
            End Set
        End Property

        Private _jobSpendLimit As Decimal = Nothing

        Public ReadOnly Property JobSpendLimit() As Decimal
            Get
                Return _jobSpendLimit
            End Get
        End Property

        Public WriteOnly Property SetJobSpendLimit() As Object
            Set(ByVal Value As Object)
                _dataTypeValidator.SetValue(Me, "_jobSpendLimit", Value)
            End Set
        End Property

#End Region

    End Class

End Namespace