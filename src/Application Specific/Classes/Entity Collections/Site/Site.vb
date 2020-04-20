Imports System.Data.SqlClient

Namespace Entity

    Namespace Sites

        Public Class Site

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

#Region "Property Properties"

            Private _SiteID As Integer = 0

            Public ReadOnly Property SiteID() As Integer
                Get
                    Return _SiteID
                End Get
            End Property

            Public WriteOnly Property SetSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SiteID", Value)
                End Set
            End Property

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

            Private _HeadOffice As Boolean = False

            Public ReadOnly Property HeadOffice() As Boolean
                Get
                    Return _HeadOffice
                End Get
            End Property

            Public WriteOnly Property SetHeadOffice() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_HeadOffice", Value)
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

            Private _Asbestos As String = String.Empty

            Public ReadOnly Property Asbestos() As String
                Get
                    Return _Asbestos
                End Get
            End Property

            Public WriteOnly Property SetAsbestos() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Asbestos", Value)
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

            Private _Address1 As String = String.Empty

            Public ReadOnly Property Address1() As String
                Get
                    Return _Address1
                End Get
            End Property

            Public WriteOnly Property SetAddress1() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address1", Value)
                End Set
            End Property

            Private _Address2 As String = String.Empty

            Public ReadOnly Property Address2() As String
                Get
                    Return _Address2
                End Get
            End Property

            Public WriteOnly Property SetAddress2() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address2", Value)
                End Set
            End Property

            Private _Address3 As String = String.Empty

            Public ReadOnly Property Address3() As String
                Get
                    Return _Address3
                End Get
            End Property

            Public WriteOnly Property SetAddress3() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address3", Value)
                End Set
            End Property

            Private _Address4 As String = String.Empty

            Public ReadOnly Property Address4() As String
                Get
                    Return _Address4
                End Get
            End Property

            Public WriteOnly Property SetAddress4() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address4", Value)
                End Set
            End Property

            Private _Address5 As String = String.Empty

            Public ReadOnly Property Address5() As String
                Get
                    Return _Address5
                End Get
            End Property

            Public WriteOnly Property SetAddress5() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Address5", Value)
                End Set
            End Property

            Private _Postcode As String = String.Empty

            Public ReadOnly Property Postcode() As String
                Get
                    Return _Postcode
                End Get
            End Property

            Public WriteOnly Property SetPostcode() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Postcode", Value)
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

            Private _FaxNum As String = String.Empty

            Public ReadOnly Property FaxNum() As String
                Get
                    Return _FaxNum
                End Get
            End Property

            Public WriteOnly Property SetFaxNum() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FaxNum", Value)
                End Set
            End Property

            Private _EmailAddress As String = String.Empty

            Public ReadOnly Property EmailAddress() As String
                Get
                    Return _EmailAddress
                End Get
            End Property

            Public WriteOnly Property SetEmailAddress() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EmailAddress", Value)
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

            Private _SourceOfCustomerID As Integer = 0

            Public ReadOnly Property SourceOfCustomerID() As Integer
                Get
                    Return _SourceOfCustomerID
                End Get
            End Property

            Public WriteOnly Property SetSourceOfCustomerID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SourceOfCustomerID", Value)
                End Set
            End Property

            Private _PolicyNumber As String = String.Empty

            Public ReadOnly Property PolicyNumber() As String
                Get
                    Return _PolicyNumber
                End Get
            End Property

            Public WriteOnly Property SetPolicyNumber() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PolicyNumber", Value)
                End Set
            End Property

            Private _directDebitRef As String = String.Empty

            Public ReadOnly Property DirectDebitRef() As String
                Get
                    Return _directDebitRef
                End Get
            End Property

            Public WriteOnly Property SetDirectDebitRef() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_directDebitRef", Value)
                End Set
            End Property

            Private _NoMarketing As Boolean = True

            Public ReadOnly Property NoMarketing() As Boolean
                Get
                    Return _NoMarketing
                End Get
            End Property

            Public WriteOnly Property SetNoMarketing() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NoMarketing", Value)
                End Set
            End Property

            Private _ReasonForContactID As Integer = 0

            Public ReadOnly Property ReasonForContactID() As Integer
                Get
                    Return _ReasonForContactID
                End Get
            End Property

            Public WriteOnly Property SetReasonForContactID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ReasonForContactID", Value)
                End Set
            End Property

            Private _OnStop As Boolean = True

            Public ReadOnly Property OnStop() As Boolean
                Get
                    Return _OnStop
                End Get
            End Property

            Public WriteOnly Property SetOnStop() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_OnStop", Value)
                End Set
            End Property

            Private _SolidFuel As Boolean = False

            Public ReadOnly Property SolidFuel() As Boolean
                Get
                    Return _SolidFuel
                End Get
            End Property

            Public WriteOnly Property SetSolidFuel() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SolidFuel", Value)
                End Set
            End Property

            Private _NoService As Boolean = False

            Public ReadOnly Property NoService() As Boolean
                Get
                    Return _NoService
                End Get
            End Property

            Public WriteOnly Property SetNoService() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_NoService", Value)
                End Set
            End Property

            Private _LeaseHold As Boolean = False

            Public ReadOnly Property LeaseHold() As Boolean
                Get
                    Return _LeaseHold
                End Get
            End Property

            Public WriteOnly Property SetLeaseHold() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_LeaseHold", Value)
                End Set
            End Property

            Private _CommercialDistrict As Boolean = False

            Public ReadOnly Property CommercialDistrict() As Boolean
                Get
                    Return _CommercialDistrict
                End Get
            End Property

            Public WriteOnly Property SetCommercialDistrict() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_CommercialDistrict", Value)
                End Set
            End Property

            Private _PropertyVoid As Boolean = False

            Public ReadOnly Property PropertyVoid() As Boolean
                Get
                    Return _PropertyVoid
                End Get
            End Property

            Public WriteOnly Property SetPropertyVoid() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_PropertyVoid", Value)
                End Set
            End Property

            Private _LastServiceDate As DateTime = Nothing

            Public Property LastServiceDate() As DateTime
                Get
                    Return _LastServiceDate
                End Get
                Set(ByVal Value As DateTime)
                    _LastServiceDate = Value
                End Set
            End Property

            Private _ActualServiceDate As DateTime = Nothing

            Public Property ActualServiceDate() As DateTime
                Get
                    Return _ActualServiceDate
                End Get
                Set(ByVal Value As DateTime)
                    _ActualServiceDate = Value
                End Set
            End Property

            Private _SiteFuel As String = String.Empty

            Public ReadOnly Property SiteFuel() As String
                Get
                    Return _SiteFuel
                End Get
            End Property

            Public WriteOnly Property SetSiteFuel() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SiteFuel", Value)
                End Set
            End Property

            Private _Salutation As String = String.Empty

            Public ReadOnly Property Salutation() As String
                Get
                    Return _Salutation
                End Get
            End Property

            Public WriteOnly Property SetSalutation() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Salutation", Value)
                End Set
            End Property

            Private _FirstName As String = String.Empty

            Public ReadOnly Property FirstName() As String
                Get
                    Return _FirstName
                End Get
            End Property

            Public WriteOnly Property SetFirstName() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_FirstName", Value)
                End Set
            End Property

            Private _Surname As String = String.Empty

            Public ReadOnly Property Surname() As String
                Get
                    Return _Surname
                End Get
            End Property

            Public WriteOnly Property SetSurname() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_Surname", Value)
                End Set
            End Property

            Private _ContactAlerts As String = String.Empty

            Public ReadOnly Property ContactAlerts() As String
                Get
                    Return _ContactAlerts
                End Get
            End Property

            Public WriteOnly Property SetContactAlerts() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_ContactAlerts", Value)
                End Set
            End Property

            Private _Longitude As Decimal = 0

            Public ReadOnly Property Longitude() As Decimal
                Get
                    Return _Longitude
                End Get
            End Property

            Public WriteOnly Property SetLongitude() As Decimal
                Set(ByVal Value As Decimal)
                    _dataTypeValidator.SetValue(Me, "_Longitude", Value)
                End Set
            End Property

            Private _Latitude As Decimal = 0

            Public ReadOnly Property Latitude() As Decimal
                Get
                    Return _Latitude
                End Get
            End Property

            Public WriteOnly Property SetLatitude() As Decimal
                Set(ByVal Value As Decimal)
                    _dataTypeValidator.SetValue(Me, "_Latitude", Value)
                End Set
            End Property

            Private _buildDate As DateTime = Nothing

            Public Property BuildDate() As DateTime
                Get
                    Return _buildDate
                End Get
                Set(ByVal Value As DateTime)
                    _buildDate = Value
                End Set
            End Property

            Private _warrantyPeriodInMonths As Integer = 0

            Public ReadOnly Property WarrantyPeriodInMonths() As Integer
                Get
                    Return _warrantyPeriodInMonths
                End Get
            End Property

            Public WriteOnly Property SetWarrantyPeriodInMonths() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_warrantyPeriodInMonths", Value)
                End Set
            End Property

            Private _HousingOfficer As String = String.Empty

            Public ReadOnly Property HousingOfficer() As String
                Get
                    Return _HousingOfficer
                End Get
            End Property

            Public WriteOnly Property SetHousingOfficer() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_HousingOfficer", Value)
                End Set
            End Property

            Private _HousingManager As String = String.Empty

            Public ReadOnly Property HousingManager() As String
                Get
                    Return _HousingManager
                End Get
            End Property

            Public WriteOnly Property SetHousingManager() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_HousingManager", Value)
                End Set
            End Property

            Private _EstateOfficer As String = String.Empty

            Public ReadOnly Property EstateOfficer() As String
                Get
                    Return _EstateOfficer
                End Get
            End Property

            Public WriteOnly Property SetEstateOfficer() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_EstateOfficer", Value)
                End Set
            End Property

            Private _PropertyVoidDate As DateTime = Nothing

            Public Property PropertyVoidDate() As DateTime
                Get
                    Return _PropertyVoidDate
                End Get
                Set(ByVal Value As DateTime)
                    _PropertyVoidDate = Value
                End Set
            End Property

            Private _defects As String = String.Empty

            Public ReadOnly Property Defects() As String
                Get
                    Return _defects
                End Get
            End Property

            Public WriteOnly Property SetDefects() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_defects", Value)
                End Set
            End Property

            Private _DefectEndDate As DateTime = Nothing

            Public Property DefectEndDate() As DateTime
                Get
                    Return _DefectEndDate
                End Get
                Set(ByVal Value As DateTime)
                    _DefectEndDate = Value
                End Set
            End Property

            Private _accomTypeID As Integer

            Public ReadOnly Property AccomTypeID() As Integer
                Get
                    Return _accomTypeID
                End Get
            End Property

            Public WriteOnly Property SetAccomTypeID() As Integer
                Set(value As Integer)
                    _accomTypeID = value
                End Set
            End Property

#End Region

        End Class

        Public Class SiteFuel

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

#Region "Property Properties"

            Private _SiteFuelID As Integer = 0

            Public ReadOnly Property SiteFuelID() As Integer
                Get
                    Return _SiteFuelID
                End Get
            End Property

            Public WriteOnly Property SetSiteFuelID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SiteFuelID", Value)
                End Set
            End Property

            Private _SiteID As Integer = 0

            Public ReadOnly Property SiteID() As Integer
                Get
                    Return _SiteID
                End Get
            End Property

            Public WriteOnly Property SetSiteID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SiteID", Value)
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

            Private _SiteFuelChargeID As Integer = 0

            Public ReadOnly Property SiteFuelChargeID() As Integer
                Get
                    Return _SiteFuelChargeID
                End Get
            End Property

            Public WriteOnly Property SetSiteFuelChargeID() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_SiteFuelChargeID", Value)
                End Set
            End Property

            Private _LastServiceDate As DateTime = Nothing

            Public Property LastServiceDate() As DateTime
                Get
                    Return _LastServiceDate
                End Get
                Set(ByVal Value As DateTime)
                    _LastServiceDate = Value
                End Set
            End Property

            Private _ActualServiceDate As DateTime = Nothing

            Public Property ActualServiceDate() As DateTime
                Get
                    Return _ActualServiceDate
                End Get
                Set(ByVal Value As DateTime)
                    _ActualServiceDate = Value
                End Set
            End Property

            Private _DateAdded As DateTime = Nothing

            Public Property DateAdded() As DateTime
                Get
                    Return _DateAdded
                End Get
                Set(ByVal Value As DateTime)
                    _DateAdded = Value
                End Set
            End Property

            Private _AddedBy As Integer = 0

            Public ReadOnly Property AddedBy() As Integer
                Get
                    Return _AddedBy
                End Get
            End Property

            Public WriteOnly Property SetAddedBy() As Object
                Set(ByVal Value As Object)
                    _dataTypeValidator.SetValue(Me, "_AddedBy", Value)
                End Set
            End Property

#End Region

        End Class

    End Namespace

End Namespace