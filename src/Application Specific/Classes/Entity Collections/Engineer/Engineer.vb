Imports System.Data.SqlClient

Namespace Entity

    Namespace Engineers

        Public Class Engineer

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

            Private _TelephoneNum As String = String.Empty

            Public ReadOnly Property TelephoneNum() As String
                Get
                    Return _TelephoneNum
                End Get
            End Property

            Public WriteOnly Property SetTelephoneNum() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_TelephoneNum", Value)
                End Set
            End Property

            Private _PDAID As Integer = 0

            Public ReadOnly Property PDAID() As Integer
                Get
                    Return _PDAID
                End Get
            End Property

            Public WriteOnly Property SetPDAID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PDAID", Value)
                End Set
            End Property

            Private _Apprentice As Boolean = False

            Public ReadOnly Property Apprentice() As Boolean
                Get
                    Return _Apprentice
                End Get
            End Property

            Public WriteOnly Property SetApprentice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Apprentice", Value)
                End Set
            End Property

            Private _costToCompanyDouble As Double = 0

            Public ReadOnly Property CostToCompanyDouble() As Double
                Get
                    Return _costToCompanyDouble
                End Get
            End Property

            Public WriteOnly Property SetCostToCompanyDouble() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_costToCompanyDouble", Value)
                End Set
            End Property

            Private _costToCompanyTimeAndHalf As Double = 0

            Public ReadOnly Property CostToCompanyTimeAndHalf() As Double
                Get
                    Return _costToCompanyTimeAndHalf
                End Get
            End Property

            Public WriteOnly Property SetCostToCompanyTimeAndHalf() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_costToCompanyTimeAndHalf", Value)
                End Set
            End Property

            Private _costToCompanyNormal As Double = 0

            Public ReadOnly Property CostToCompanyNormal() As Double
                Get
                    Return _costToCompanyNormal
                End Get
            End Property

            Public WriteOnly Property SetCostToCompanyNormal() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_costToCompanyNormal", Value)
                End Set
            End Property

            Private _nextOfKinName As String = ""

            Public ReadOnly Property NextOfKinName() As String
                Get
                    Return _nextOfKinName
                End Get
            End Property

            Public WriteOnly Property SetNextOfKinName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_nextOfKinName", Value)
                End Set
            End Property

            Private _nextOfKinContact As String = ""

            Public ReadOnly Property NextOfKinContact() As String
                Get
                    Return _nextOfKinContact
                End Get
            End Property

            Public WriteOnly Property SetNextOfKinContact() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_nextOfKinContact", Value)
                End Set
            End Property

            Private _startingDetails As String = ""

            Public ReadOnly Property StartingDetails() As String
                Get
                    Return _startingDetails
                End Get
            End Property

            Public WriteOnly Property SetStartingDetails() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_startingDetails", Value)
                End Set
            End Property

            Private _drivingLicenceNo As String = ""

            Public ReadOnly Property DrivingLicenceNo() As String
                Get
                    Return _drivingLicenceNo
                End Get
            End Property

            Public WriteOnly Property SetDrivingLicenceNo() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_drivingLicenceNo", Value)
                End Set
            End Property

            Private _drivingLicenceIssueDate As DateTime = Nothing

            Public Property DrivingLicenceIssueDate() As DateTime
                Get
                    Return _drivingLicenceIssueDate
                End Get
                Set(ByVal Value As DateTime)
                    _drivingLicenceIssueDate = Value
                End Set
            End Property

            Private _payGradeID As Integer = 0

            Public ReadOnly Property PayGradeID() As Integer
                Get
                    Return _payGradeID
                End Get
            End Property

            Public WriteOnly Property SetPayGradeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_payGradeID", Value)
                End Set
            End Property

            Private _annualSalary As Decimal = 0

            Public ReadOnly Property AnnualSalary() As Decimal
                Get
                    Return _annualSalary
                End Get
            End Property

            Public WriteOnly Property SetAnnualSalary() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_annualSalary", Value)
                End Set
            End Property

            Private _nINumber As String = ""

            Public ReadOnly Property NINumber() As String
                Get
                    Return _nINumber
                End Get
            End Property

            Public WriteOnly Property SetNINumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_nINumber", Value)
                End Set
            End Property

            Private _holidayYearStart As String = "01/01"

            Public ReadOnly Property HolidayYearStart() As String
                Get
                    Return _holidayYearStart
                End Get
            End Property

            Public WriteOnly Property SetHolidayYearStart() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_holidayYearStart", Value)
                End Set
            End Property

            Private _holidayYearEnd As String = "31/12"

            Public ReadOnly Property HolidayYearEnd() As String
                Get
                    Return _holidayYearEnd
                End Get
            End Property

            Public WriteOnly Property SetHolidayYearEnd() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_holidayYearEnd", Value)
                End Set
            End Property

            Private _daysHolidayAllowed As Decimal = 0

            Public ReadOnly Property DaysHolidayAllowed() As Decimal
                Get
                    Return _daysHolidayAllowed
                End Get
            End Property

            Public WriteOnly Property SetDaysHolidayAllowed() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_daysHolidayAllowed", Value)
                End Set
            End Property

            Private _gasSafeNo As String = ""

            Public ReadOnly Property GasSafeNo() As String
                Get
                    Return _gasSafeNo
                End Get
            End Property

            Public WriteOnly Property SetGasSafeNo() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_gasSafeNo", Value)
                End Set
            End Property

            Private _oftecNo As String = ""

            Public ReadOnly Property OftecNo() As String
                Get
                    Return _oftecNo
                End Get
            End Property

            Public WriteOnly Property SetOftecNo() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_oftecNo", Value)
                End Set
            End Property

            Private _engineerGroupID As Integer = 0

            Public ReadOnly Property EngineerGroupID() As Integer
                Get
                    Return _engineerGroupID
                End Get
            End Property

            Public WriteOnly Property SetEngineerGroupID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_engineerGroupID", Value)
                End Set
            End Property

            Private _supervisor As String = ""

            Public ReadOnly Property Supervisor() As String
                Get
                    Return _supervisor
                End Get
            End Property

            Public WriteOnly Property SetSupervisor() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_supervisor", Value)
                End Set
            End Property

            Private _technician As String = ""

            Public ReadOnly Property Technician() As String
                Get
                    Return _technician
                End Get
            End Property

            Public WriteOnly Property SetTechnician() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_technician", Value)
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

            Private _ServPri As Integer = 0

            Public ReadOnly Property ServPri() As Integer
                Get
                    Return _ServPri
                End Get
            End Property

            Public WriteOnly Property SetServPri() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ServPri", Value)
                End Set
            End Property

            Private _BreakPri As Integer = 0

            Public ReadOnly Property BreakPri() As Integer
                Get
                    Return _BreakPri
                End Get
            End Property

            Public WriteOnly Property SetBreakPri() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_BreakPri", Value)
                End Set
            End Property

            Private _DailyServiceLimit As Integer = 0

            Public ReadOnly Property DailyServiceLimit() As Integer
                Get
                    Return _DailyServiceLimit
                End Get
            End Property

            Public WriteOnly Property SetDailyServiceLimit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_DailyServiceLimit", Value)
                End Set
            End Property

            Private _HomePostcode As String = ""

            Public ReadOnly Property HomePostcode() As String
                Get
                    Return _HomePostcode
                End Get
            End Property

            Public WriteOnly Property SetHomePostcode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_HomePostcode", Value)
                End Set
            End Property

            Private _Longitude As Decimal = 0

            Public ReadOnly Property Longitude() As Decimal
                Get
                    Return _Longitude
                End Get
            End Property

            Public WriteOnly Property SetLongitude() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Longitude", Value)
                End Set
            End Property

            Private _Latitude As Decimal = 0

            Public ReadOnly Property Latitude() As Decimal
                Get
                    Return _Latitude
                End Get
            End Property

            Public WriteOnly Property SetLatitude() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Latitude", Value)
                End Set
            End Property

            Private _ManagerUserID As Integer = False

            Public ReadOnly Property ManagerUserID() As Integer
                Get
                    Return _ManagerUserID
                End Get
            End Property

            Public WriteOnly Property SetManagerUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ManagerUserID", Value)
                End Set
            End Property

            Private _WebAppPassword As String = ""

            Public ReadOnly Property WebAppPassword() As String
                Get
                    Return _WebAppPassword
                End Get
            End Property

            Public WriteOnly Property SetWebAppPassword() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_WebAppPassword", Value)
                End Set
            End Property

            Private _ragRating As Integer = 0

            Public ReadOnly Property RagRating() As Integer
                Get
                    Return _ragRating
                End Get
            End Property

            Public WriteOnly Property SetRagRating() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ragRating", Value)
                End Set
            End Property

            Private _UserID As Integer = 0

            Public ReadOnly Property UserID() As Integer
                Get
                    Return _UserID
                End Get
            End Property

            Public WriteOnly Property SetUserID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_UserID", Value)
                End Set
            End Property

            Public Property RagDate As DateTime = Nothing

            Private _visitSpendLimit As Decimal = Nothing

            Public ReadOnly Property VisitSpendLimit() As Decimal
                Get
                    Return _visitSpendLimit
                End Get
            End Property

            Public WriteOnly Property SetVisitSpendLimit() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_visitSpendLimit", Value)
                End Set
            End Property

            Private _engineerRoleId As Decimal = Nothing

            Public ReadOnly Property EngineerRoleId() As Integer
                Get
                    Return _engineerRoleId
                End Get
            End Property

            Public WriteOnly Property SetEngineerRoleId() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_engineerRoleId", Value)
                End Set
            End Property

            Private _emailAddress As String = String.Empty

            Public ReadOnly Property EmailAddress() As String
                Get
                    Return _emailAddress
                End Get
            End Property

            Public WriteOnly Property SetEmailAddress() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_emailAddress", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace