Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports FSM.Entity.Sys

Namespace Entity.Sites

    Public Class SiteSQL

        Public Enum GetBy
            SiteId = 1
            Uprn = 2
            Asset = 3
            EngineerVisitId = 4
            CustomerHq = 5
            JobId = 6
        End Enum

        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Site"

        Public Sub Delete(ByVal SiteID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)
            _database.ExecuteSP_NO_Return("Site_Delete")
        End Sub

        Public Function [Get](ByVal ref As Object, Optional ByVal getBy As GetBy = GetBy.SiteId, Optional ByVal ref2 As Object = Nothing) As Site
            _database.ClearParameter()

            'Get the datatable from the database store in dt
            Dim dt As DataTable = Nothing
            Select Case getBy
                Case GetBy.Uprn
                    _database.AddParameter("@UPRN", Entity.Sys.Helper.MakeStringValid(ref), True)
                    _database.AddParameter("@CustomerId", Entity.Sys.Helper.MakeIntegerValid(ref2), True)
                    dt = _database.ExecuteSP_DataTable("Site_Get_ForUPRN")

                Case GetBy.Asset
                    _database.AddParameter("@AssetID", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                    dt = _database.ExecuteSP_DataTable("Site_Get_ForAssetID")

                Case GetBy.EngineerVisitId
                    _database.AddParameter("@EngineerVisitID", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                    dt = _database.ExecuteSP_DataTable("Site_Get_ForEngineerVisitID")

                Case GetBy.CustomerHq
                    _database.AddParameter("@CustomerID", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                    dt = _database.ExecuteSP_DataTable("[Sites_GetHOForCustomer]")

                Case GetBy.JobId
                    _database.AddParameter("@JobID ", Entity.Sys.Helper.MakeIntegerValid(ref))
                    dt = _database.ExecuteSP_DataTable("Site_Get_ForJobID")

                Case GetBy.SiteId
                    _database.AddParameter("@SiteID", Entity.Sys.Helper.MakeIntegerValid(ref))
                    dt = _database.ExecuteSP_DataTable("Site_Get")

                Case Else
                    _database.AddParameter("@SiteID", Entity.Sys.Helper.MakeIntegerValid(ref))
                    dt = _database.ExecuteSP_DataTable("Site_Get")
            End Select

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Dim oSite As New Site
                    With oSite
                        .IgnoreExceptionsOnSetMethods = True
                        If dt.Columns.Contains("SiteID") Then .SetSiteID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("SiteID"))
                        If dt.Columns.Contains("Name") Then .SetName = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Name"))
                        If dt.Columns.Contains("CustomerID") Then .SetCustomerID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("CustomerID"))
                        If dt.Columns.Contains("RegionID") Then .SetRegionID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("RegionID"))
                        If dt.Columns.Contains("HeadOffice") Then .SetHeadOffice = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("HeadOffice"))
                        If dt.Columns.Contains("Notes") Then .SetNotes = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Notes"))
                        If dt.Columns.Contains("Address1") Then .SetAddress1 = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Address1"))
                        If dt.Columns.Contains("Address2") Then .SetAddress2 = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Address2"))
                        If dt.Columns.Contains("Address3") Then .SetAddress3 = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Address3"))
                        If dt.Columns.Contains("Address4") Then .SetAddress4 = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Address4"))
                        If dt.Columns.Contains("Address5") Then .SetAddress5 = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Address5"))
                        If dt.Columns.Contains("Postcode") Then .SetPostcode = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Postcode"))
                        If dt.Columns.Contains("TelephoneNum") Then .SetTelephoneNum = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("TelephoneNum"))
                        If dt.Columns.Contains("FaxNum") Then .SetFaxNum = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("FaxNum"))
                        If dt.Columns.Contains("EmailAddress") Then .SetEmailAddress = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("EmailAddress"))
                        If dt.Columns.Contains("EngineerID") Then .SetEngineerID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("EngineerID"))
                        If dt.Columns.Contains("PoNumReqd") Then .SetPoNumReqd = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("PoNumReqd"))
                        If dt.Columns.Contains("Deleted") Then .SetDeleted = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("Deleted"))
                        If dt.Columns.Contains("PolicyNumber") Then .SetPolicyNumber = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("PolicyNumber"))
                        If dt.Columns.Contains("AcceptChargesChanges") Then .SetAcceptChargesChanges = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("AcceptChargesChanges"))
                        If dt.Columns.Contains("SourceOfCustomerID") Then .SetSourceOfCustomerID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("SourceOfCustomerID"))
                        If dt.Columns.Contains("NoMarketing") Then .SetNoMarketing = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("NoMarketing"))
                        If dt.Columns.Contains("ReasonForContactID") Then .SetReasonForContactID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("ReasonForContactID"))
                        If dt.Columns.Contains("OnStop") Then .SetOnStop = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("OnStop"))
                        If dt.Columns.Contains("SolidFuel") Then .SetSolidFuel = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("SolidFuel"))
                        If dt.Columns.Contains("NoService") Then .SetNoService = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("NoService"))
                        If dt.Columns.Contains("LeaseHold") Then .SetLeaseHold = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("LeaseHold"))
                        If dt.Columns.Contains("CommercialDistrict") Then .SetCommercialDistrict = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("CommercialDistrict"))
                        If dt.Columns.Contains("LastServiceDate") Then .LastServiceDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0)("LastServiceDate"))
                        If dt.Columns.Contains("ActualServiceDate") Then .ActualServiceDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0)("ActualServiceDate"))
                        If dt.Columns.Contains("PropertyVoid") Then .SetPropertyVoid = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0)("PropertyVoid"))
                        If dt.Columns.Contains("SiteFuel") Then .SetSiteFuel = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("SiteFuel"))
                        If dt.Columns.Contains("Salutation") Then .SetSalutation = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Salutation"))
                        If dt.Columns.Contains("FirstName") Then .SetFirstName = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("FirstName"))
                        If dt.Columns.Contains("Surname") Then .SetSurname = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Surname"))
                        If dt.Columns.Contains("asbestos") Then .SetAsbestos = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("asbestos").ToString.Replace("/n", vbNewLine))
                        If dt.Columns.Contains("ContactAlerts") Then .SetContactAlerts = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("ContactAlerts"))
                        If dt.Columns.Contains("Longitude") Then .SetLongitude = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0)("Longitude"))
                        If dt.Columns.Contains("Latitude") Then .SetLatitude = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0)("Latitude"))
                        If dt.Columns.Contains("DirectDebitRef") Then .SetDirectDebitRef = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("DirectDebitRef"))
                        If dt.Columns.Contains("BuildDate") Then .BuildDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0)("BuildDate"))
                        If dt.Columns.Contains("HousingOfficer") Then .SetHousingOfficer = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("HousingOfficer"))
                        If dt.Columns.Contains("EstateOfficer") Then .SetEstateOfficer = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("EstateOfficer"))
                        If dt.Columns.Contains("HousingManager") Then .SetHousingManager = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("HousingManager"))
                        If dt.Columns.Contains("WarrantyPeriodInMonths") Then .SetWarrantyPeriodInMonths = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("WarrantyPeriodInMonths"))
                        If dt.Columns.Contains("PropertyVoidDate") Then .PropertyVoidDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0)("PropertyVoidDate"))
                        If dt.Columns.Contains("Defects") Then .SetDefects = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Defects"))
                        If dt.Columns.Contains("DefectEndDate") Then .DefectEndDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0)("DefectEndDate"))
                        If dt.Columns.Contains("AccomTypeID") Then .SetAccomTypeID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("AccomTypeID"))
                    End With
                    oSite.Exists = True
                    Return oSite
                Else
                    Return Nothing
                End If
            End If
        End Function

        Public Function [GetAll_FleetGarage](ByVal userId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@UserID", userId, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Site_GetAll_FleetGarage_Mk1")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            Return New DataView(dt)
        End Function

        Public Function [GetAll_Light](ByVal userId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@UserID", userId, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Site_GetAll_Light_Mk1")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            Return New DataView(dt)
        End Function

        Public Function [GetAll_Light_New](ByVal userId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@UserID", userId, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Site_GetAll_Light_New_Mk1")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            Return New DataView(dt)
        End Function

        Public Function [GetForCustomer_Light](ByVal CustomerID As Integer, ByVal userId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@CustomerID", CustomerID, True)
            _database.AddParameter("@UserID", userId, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("[Sites_GetForCustomer_Light_Mk1]")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            Return New DataView(dt)
        End Function

        Public Function [Search](ByVal Criteria As String, ByVal userId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SearchString", Criteria, True)
            _database.AddParameter("@UserID", userId, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Site_SearchList_Mk1")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            Return New DataView(dt)
        End Function

        Public Function [Search_JobWizard](ByVal Criteria As String, ByVal userId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SearchString", Criteria, True)
            _database.AddParameter("@UserID", userId, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Site_Search_JobWizard")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            Return New DataView(dt)
        End Function

        Public Function [Search_FleetGarage](ByVal Criteria As String, ByVal userId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SearchString", Criteria, True)
            _database.AddParameter("@UserID", userId, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Site_SearchList_FleetGarage_Mk1")
            dt.TableName = Entity.Sys.Enums.TableNames.tblFleetGarage.ToString
            Return New DataView(dt)
        End Function

        Public Function [Insert](ByVal oSite As Site) As Site
            _database.ClearParameter()
            AddPropertyParametersToCommand(oSite)
            _database.AddParameter("@SiteAddedByUserID", loggedInUser.UserID, True)
            oSite.SetSiteID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Site_Insert"))
            oSite.Exists = True

            Check_And_Insert_Postal_Region(oSite.Postcode)

            Return oSite
        End Function

        Public Sub [Update](ByVal oSite As Site)
            _database.ClearParameter()
            _database.AddParameter("@SiteID", oSite.SiteID, True)
            AddPropertyParametersToCommand(oSite)
            _database.ExecuteSP_NO_Return("Site_Update")

            Check_And_Insert_Postal_Region(oSite.Postcode)
        End Sub

        Public Sub [Update_Customer](ByVal siteId As Integer, ByVal oldCustomerId As Integer, ByVal customerId As Integer)
            _database.ClearParameter()
            _database.AddParameter("@SiteID", siteId, True)
            _database.AddParameter("@CustomerID", customerId, True)
            _database.ExecuteSP_NO_Return("Site_Update_Customer")

            'INSERT AUDIT RECORD
            Dim scAudit As New Entity.SiteCustomerAudits.SiteCustomerAudit
            scAudit.DateChanged = Now
            scAudit.SetSiteID = siteId
            scAudit.SetPreviousCustomerID = oldCustomerId
            scAudit.SetUserID = loggedInUser.UserID
            DB.SiteCustomerAudit.Insert(scAudit)
        End Sub

        Private Sub AddPropertyParametersToCommand(ByRef oSite As Site)
            With _database
                .AddParameter("@CustomerID", oSite.CustomerID, True)
                .AddParameter("@Name", oSite.Name, True)
                .AddParameter("@RegionID", oSite.RegionID, True)
                .AddParameter("@HeadOffice", oSite.HeadOffice, True)
                .AddParameter("@Notes", oSite.Notes, True)
                .AddParameter("@Address1", oSite.Address1, True)
                .AddParameter("@Address2", oSite.Address2, True)
                .AddParameter("@Address3", oSite.Address3, True)
                .AddParameter("@Address4", oSite.Address4, True)
                .AddParameter("@Address5", oSite.Address5, True)
                .AddParameter("@Postcode", oSite.Postcode, True)
                .AddParameter("@TelephoneNum", oSite.TelephoneNum, True)
                .AddParameter("@FaxNum", oSite.FaxNum, True)
                .AddParameter("@EmailAddress", oSite.EmailAddress, True)
                .AddParameter("@EngineerID", oSite.EngineerID, True)
                .AddParameter("@PONumReqd", oSite.PoNumReqd, True)
                .AddParameter("@PolicyNumber", oSite.PolicyNumber, True)
                .AddParameter("@AcceptChargesChanges", oSite.AcceptChargesChanges, True)
                .AddParameter("@SourceOfCustomerID", oSite.SourceOfCustomerID, True)
                .AddParameter("@NoMarketing", oSite.NoMarketing, True)
                .AddParameter("@NoService", oSite.NoService, True)
                .AddParameter("@ReasonForContactID", oSite.ReasonForContactID, True)
                .AddParameter("@OnStop", oSite.OnStop, True)
                .AddParameter("@LeaseHold", oSite.LeaseHold, True)
                .AddParameter("@PropertyVoid", oSite.PropertyVoid, True)
                .AddParameter("@SiteFuel", oSite.SiteFuel, True)
                .AddParameter("@Salutation", oSite.Salutation, True)
                .AddParameter("@FirstName", oSite.FirstName, True)
                .AddParameter("@Surname", oSite.Surname, True)
                .AddParameter("@Longs", oSite.Longitude, True)
                .AddParameter("@Lat", oSite.Latitude, True)
                .AddParameter("@DirectDebitRef", oSite.DirectDebitRef, True)
                .AddParameter("@BuildDate", Helper.InsertDateIntoDb(oSite.BuildDate), True)
                .AddParameter("@WarrantyPeriodInMonths", oSite.WarrantyPeriodInMonths, True)
                .AddParameter("@PropertyVoidDate", Helper.InsertDateIntoDb(oSite.PropertyVoidDate), True)
                .AddParameter("@ContactAlerts", oSite.ContactAlerts, True)
                .AddParameter("@Defects", oSite.Defects, True)
                .AddParameter("@DefectEndDate", Helper.InsertDateIntoDb(oSite.DefectEndDate), True)
                .AddParameter("@HousingOfficer", oSite.HousingOfficer, True)
                .AddParameter("@HousingManager", oSite.HousingManager, True)
                .AddParameter("@EstateManager", oSite.EstateOfficer, True)
                .AddParameter("@AccomTypeID", oSite.AccomTypeID, True)
            End With
        End Sub

        Private Sub Check_And_Insert_Postal_Region(ByVal postcode As String)
            Dim postcodePrefix As String = postcode.Split("-")(0).Trim

            Dim SQL As String = "SELECT COUNT(ManagerID) AS 'numberOfRegions' FROM tblpicklists WHERE Deleted = 0 AND EnumTypeID = " &
            CInt(Entity.Sys.Enums.PickListTypes.PostalRegions) & " AND Name = '" & postcodePrefix & "'"

            Dim numberOfRegions As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar(SQL, False))

            If numberOfRegions = 0 Then
                Dim picklist As New Entity.PickLists.PickList
                picklist.IgnoreExceptionsOnSetMethods = True
                picklist.SetName = postcodePrefix
                picklist.SetEnumTypeID = CInt(Entity.Sys.Enums.PickListTypes.PostalRegions)
                picklist.SetManagerID = _database.Picklists.Insert(picklist)

                ShowForm(GetType(FRMPostcodeManager), True, New Object() {picklist.ManagerID})
            End If
        End Sub

        Public Function [Site_CanItBeDeleted](ByVal SiteID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)
            _database.AddParameter("@AwaitingConfirmationID", CInt(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation), True)
            _database.AddParameter("@ConfirmedID", CInt(Entity.Sys.Enums.OrderStatus.Confirmed), True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Site_CanItBeDeleted")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
            Return New DataView(dt)
        End Function

        Public Sub Site_UpdateLastServiceDate(ByVal SiteID As Integer,
                                              ByVal LastServiceDate As DateTime, ByVal actualServiceDate As DateTime,
                                              Optional ByVal Override As Boolean = False)
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)
            _database.AddParameter("@LastServiceDate", LastServiceDate, True)
            _database.AddParameter("@ActualServiceDate", actualServiceDate, True)
            _database.AddParameter("@Override", Override, True)
            _database.ExecuteSP_NO_Return("Site_UpdateLastServiceDate")
        End Sub

        Public Function Site_Update_ContactAlerts(ByVal siteId As Integer, ByVal contactAlert As String) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@SiteID", siteId, True)
            _database.AddParameter("@ContactAlerts", contactAlert, True)
            Return CBool(_database.ExecuteSP_ReturnRowsAffected("Site_Update_ContactAlerts") = 1)
        End Function

#End Region

#Region "Site Notes"

        Public Function GetSiteNotes(ByVal siteID As Integer) As DataView
            '
            _database.ClearParameter()
            _database.AddParameter("@SiteID", siteID, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteNote_Get_For_Site")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSiteNotes.ToString
            Return New DataView(dt)
        End Function

        Public Function SaveSiteNotes(ByVal SiteNoteID As Integer,
                                      ByVal Note As String,
                                      ByVal EditedByUserID As Integer,
                                      ByVal SiteID As Integer,
                                      ByVal CreatedByUserID As Integer) As DataView

            _database.ClearParameter()

            If SiteNoteID > 0 Then
                _database.AddParameter("@SiteNoteID", SiteNoteID, True)
                _database.AddParameter("@Note", Note, True)
                _database.AddParameter("@EditedByUserID", EditedByUserID, True)
                _database.ExecuteSP_NO_Return("SiteNote_Update")
            Else
                _database.AddParameter("@SiteID", SiteID, True)
                _database.AddParameter("@Note", Note, True)
                _database.AddParameter("@CreatedByUserID", CreatedByUserID, True)
                _database.ExecuteSP_NO_Return("SiteNote_Insert")
            End If

            Return GetSiteNotes(SiteID)
        End Function

        Public Sub DeleteSiteNote(ByVal siteNoteID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@SiteNoteID", siteNoteID, True)
            _database.ExecuteSP_NO_Return("SiteNote_Delete")

        End Sub

#End Region

#Region "Site Fuels"

        Public Function [SiteFuel_GetAll_ForSite](ByVal siteID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SiteID", siteID, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteFuel_GetAll_ForSite")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
            Return New DataView(dt)
        End Function

        Public Function [SiteFuel_Get_ForEngineerVisit](ByVal EngineerVisitID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteFuel_Get_ForEngineerVisit")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
            Return New DataView(dt)
        End Function

        Public Function [SiteFuel_Get](ByVal siteFuelId As Integer) As SiteFuel
            _database.ClearParameter()
            _database.AddParameter("@SiteFuelID", siteFuelId, True)

            'Get the datatable from the database store in dt
            Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteFuel_Get")

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Dim oSiteFuel As New SiteFuel
                    With oSiteFuel
                        .IgnoreExceptionsOnSetMethods = True
                        If dt.Columns.Contains("SiteFuelID") Then .SetSiteFuelID = dt.Rows(0).Item("SiteFuelID")
                        If dt.Columns.Contains("SiteID") Then .SetSiteID = dt.Rows(0).Item("SiteID")
                        If dt.Columns.Contains("FuelID") Then .SetFuelID = dt.Rows(0).Item("FuelID")
                        If dt.Columns.Contains("SiteFuelChargeID") Then .SetSiteFuelChargeID = dt.Rows(0).Item("SiteFuelChargeID")
                        If dt.Columns.Contains("LastServiceDate") Then .LastServiceDate = dt.Rows(0).Item("LastServiceDate")
                        If dt.Columns.Contains("ActualServiceDate") Then .ActualServiceDate = dt.Rows(0).Item("ActualServiceDate")
                        If dt.Columns.Contains("DateAdded") Then .DateAdded = dt.Rows(0).Item("DateAdded")
                        If dt.Columns.Contains("AddedBy") Then .SetAddedBy = dt.Rows(0).Item("AddedBy")
                    End With
                    oSiteFuel.Exists = True
                    Return oSiteFuel
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Function

        Public Function [SiteFuel_Update](ByVal siteFuel As SiteFuel) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@SiteFuelID", siteFuel.SiteFuelID, True)
            _database.AddParameter("@SiteID", siteFuel.SiteID, True)
            _database.AddParameter("@FuelID", siteFuel.FuelID, True)
            _database.AddParameter("@LastServiceDate", siteFuel.LastServiceDate, True)
            _database.AddParameter("@ActualServiceDate", siteFuel.ActualServiceDate, True)
            _database.AddParameter("@SiteFuelChargeID", siteFuel.SiteFuelChargeID, True)
            _database.AddParameter("@AddedBy", loggedInUser.UserID, True)
            Return CBool(_database.ExecuteSP_ReturnRowsAffected("SiteFuel_Update") = 1)
        End Function

        Public Function SiteFuel_Update_LastServiceDate(ByVal siteId As Integer, ByVal fuelId As Integer,
                                                        ByVal lastServiceDate As DateTime, ByVal actualServiceDate As DateTime) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@SiteID", siteId, True)
            _database.AddParameter("@FuelID", fuelId, True)
            _database.AddParameter("@LastServiceDate", lastServiceDate, True)
            _database.AddParameter("@ActualServiceDate", actualServiceDate, True)
            Return CBool(_database.ExecuteSP_ReturnRowsAffected("SiteFuel_Update_LastServiceDate") = 1)
        End Function

        Public Function [SiteFuel_Delete](ByVal siteFuelId As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@SiteFuelID", siteFuelId, True)
            Return CBool(_database.ExecuteSP_ReturnRowsAffected("SiteFuel_Delete") = 1)
        End Function

        Public Sub [SiteFuelAudit_Insert](ByVal siteID As Integer, ByVal actionChange As String)
            _database.ClearParameter()

            _database.AddParameter("@SiteID", siteID, True)
            _database.AddParameter("@ActionChange", actionChange, True)
            _database.AddParameter("@ActionDateTime", DateTime.Now, True)
            _database.AddParameter("@UserID", loggedInUser.UserID, True)

            _database.ExecuteSP_NO_Return("SiteFuelAudit_Insert")
        End Sub

        Public Function [SiteFuelAudit_Get](ByVal siteId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SiteID", siteId, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteFuelAudit_Get")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
            Return New DataView(dt)
        End Function

#End Region

#Region "Site Fuel Charge"

        Public Function SiteFuelCharge_GetAll() As DataView
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteFuelCharge_GetAll")
            dt.TableName = Entity.Sys.Enums.TableNames.tblSiteFuel.ToString
            Return New DataView(dt)
        End Function

#End Region

    End Class

End Namespace