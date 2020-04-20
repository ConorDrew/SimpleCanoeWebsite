Imports System.Data.SqlClient
Imports FSM.Entity.Sys

Namespace Entity

    Namespace Engineers

        Public Class EngineerSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal EngineerID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", EngineerID, True)
                _database.ExecuteSP_NO_Return("Engineer_Delete")
            End Sub

            Public Sub DeleteEquipment(ByVal EngineerID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EquipmentID", EngineerID, True)
                _database.ExecuteSP_NO_Return("Equipment_Delete")
            End Sub

            Public Function [Engineer_Get](ByVal EngineerID As Integer) As Engineer

                Dim command As New SqlCommand("Engineer_Get", New SqlConnection(_database.ServerConnectionString))
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@EngineerID", EngineerID)
                Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineer As New Engineer
                        With oEngineer
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .SetRegionID = dt.Rows(0).Item("RegionID")
                            .SetEngineerGroupID = dt.Rows(0).Item("EngineerGroupID")
                            .SetGasSafeNo = dt.Rows(0).Item("GasSafeNo")
                            .SetOftecNo = dt.Rows(0).Item("OftecNo")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetPDAID = dt.Rows(0).Item("PDAID")
                            .SetApprentice = dt.Rows(0).Item("Apprentice")
                            .SetCostToCompanyNormal = dt.Rows(0).Item("CostToCompanyNormal")
                            .SetCostToCompanyTimeAndHalf = dt.Rows(0).Item("CostToCompanyTimeAndHalf")
                            .SetCostToCompanyDouble = dt.Rows(0).Item("CostToCompanyDouble")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetTechnician = dt.Rows(0).Item("Technician")
                            .SetSupervisor = dt.Rows(0).Item("Supervisor")

                            .SetNextOfKinName = dt.Rows(0).Item("NextOfKinName")
                            .SetNextOfKinContact = dt.Rows(0).Item("NextOfKinContact")
                            .SetStartingDetails = dt.Rows(0).Item("StartingDetails")
                            .SetDrivingLicenceNo = dt.Rows(0).Item("DrivingLicenceNo")
                            If Not dt.Rows(0).Item("DrivingLicenceIssueDate") Is DBNull.Value Then
                                .DrivingLicenceIssueDate = dt.Rows(0).Item("DrivingLicenceIssueDate")
                            End If
                            .SetPayGradeID = dt.Rows(0).Item("PayGradeID")
                            .SetAnnualSalary = dt.Rows(0).Item("AnnualSalary")
                            .SetNINumber = dt.Rows(0).Item("NINumber")
                            .SetHolidayYearStart = dt.Rows(0).Item("HolidayYearStart")
                            .SetHolidayYearEnd = dt.Rows(0).Item("HolidayYearEnd")
                            .SetDaysHolidayAllowed = dt.Rows(0).Item("DaysHolidayAllowed")

                            .SetDepartment = dt.Rows(0).Item("Department")
                            .SetBreakPri = dt.Rows(0).Item("BreakPri")
                            .SetServPri = dt.Rows(0).Item("ServPri")
                            .SetDailyServiceLimit = dt.Rows(0).Item("DailyServiceLimit")
                            .SetHomePostcode = dt.Rows(0).Item("HomePostcode")
                            .SetLongitude = dt.Rows(0).Item("Longitude")
                            .SetLatitude = dt.Rows(0).Item("Latitude")
                            .SetManagerUserID = dt.Rows(0).Item("ManagerUserID")
                            .SetRagRating = dt.Rows(0).Item("RagRating")
                            .RagDate = Helper.MakeDateTimeValid(dt.Rows(0).Item("RagDate"))
                            .SetUserID = dt.Rows(0).Item("UserID")
                            .SetVisitSpendLimit = Helper.MakeDoubleValid(dt.Rows(0).Item("VisitSpendLimit"))
                            .SetEngineerRoleId = dt.Rows(0).Item("EngineerRoleId")
                            .SetEmailAddress = dt.Rows(0)("EmailAddress")
                        End With
                        oEngineer.Exists = True
                        Return oEngineer
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Engineer_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Engineer_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Engineer_GetAll_IncludeDeleted]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Engineer_GetAll_IncludingDeleted")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Engineer_GetAll_NoSub]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Engineer_GetAll_NoSub")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Sub [EquipmentAudit_Insert](ByVal equipmentID As Integer, ByVal actionChange As String)
                _database.ClearParameter()

                _database.AddParameter("@EquipmentID", equipmentID, True)
                _database.AddParameter("@ActionChange", actionChange, True)
                _database.AddParameter("@ActionDateTime", DateTime.Now, True)
                _database.AddParameter("@UserID", loggedInUser.UserID, True)

                _database.ExecuteSP_NO_Return("EquipmentAudit_Insert")
            End Sub

            Public Function [EquipmentAudit_Get](ByVal equipmentID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EquipmentID", equipmentID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EquipmentAudit_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEquipmentAudit.ToString
                Return New DataView(dt)
            End Function

            Public Function [Equipment_Get](ByVal EquipmentID As Integer) As Equipment

                Dim command As New SqlCommand("Equipment_Get", New SqlConnection(_database.ServerConnectionString))
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@EquipmentID", EquipmentID)

                Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEquipment As New Equipment
                        With oEquipment
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEquipmentID = dt.Rows(0).Item("EquipmentID")
                            .SetEquipmentTypeID = dt.Rows(0).Item("EquipmentTypeID")
                            .SetSerialNumber = dt.Rows(0).Item("SerialNumber")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetCertificateNumber = dt.Rows(0).Item("CertificateNumber")
                            .CalibrationDate = dt.Rows(0).Item("CalibrationDate")
                            .SetCalibrationMonths = dt.Rows(0).Item("CalibrationMonths")
                            .WarrantyEndDate = dt.Rows(0).Item("WarrantyEndDate")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .SetStatusID = dt.Rows(0).Item("StatusID")
                            .SetAssetNo = dt.Rows(0).Item("AssetNo")
                            .StatusChangeDate = dt.Rows(0).Item("StatusChangeDate")

                        End With
                        oEquipment.Exists = True
                        Return oEquipment
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Equipment_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Equipment_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Equipment_GetForEngineer](ByVal EngineerID As Integer) As DataView
                Dim command As New SqlCommand("Equipment_GetForEngineer", New SqlConnection(_database.ServerConnectionString))
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@EngineerID", EngineerID)
                Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Engineer_GetAll_Scheduler]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Engineer_GetAll_Scheduler")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Equipment_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Equipment_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSubcontractor.ToString
                Return New DataView(dt)
            End Function

            Public Function [User_And_Engineer_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("User_Engineer_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function Engineer_GetAllbyDept(Optional ByVal Dept As String = "0") As DataView
                _database.ClearParameter()
                _database.AddParameter("@Department", Dept, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Engineer_GetAllbyDept")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function Check_Unique_Name(ByVal Name As String, ByVal ID As Integer) As Boolean
                Dim NumberOfEngineers As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(EngineerID) as 'NumberOfEngineers' " &
                "FROM tblEngineer WHERE name = '" & Name & "' AND (Deleted = 0) AND engineerid <> " & ID, False))

                If NumberOfEngineers = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Function UserIsLinkedToEngineer(ByVal UserID As Integer) As Boolean
                Dim engineerCount As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(EngineerID) as 'Num' FROM tblEngineer WHERE UserID = " & UserID, False))
                If engineerCount = 0 Then
                    Return False
                Else
                    Return True
                End If
            End Function

            Public Function Check_Unique_PDAID(ByVal PDAID As Integer, ByVal ID As Integer) As Boolean
                Dim NumberOfEngineers As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(EngineerID) as 'NumberOfEngineers' " &
                "FROM tblEngineer WHERE PDAID = " & PDAID & " AND PDAID IS NOT NULL AND engineerid <> " & ID, False))

                If NumberOfEngineers = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Function [Engineer_Search](ByVal Criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", Criteria, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Engineer_SearchList")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oEngineer As Engineer) As Engineer
                _database.ClearParameter()
                AddEngineerParametersToCommand(oEngineer)

                oEngineer.SetEngineerID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Engineer_Insert"))
                oEngineer.Exists = True
                Return oEngineer
            End Function

            Public Sub [Update](ByVal oEngineer As Engineer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", oEngineer.EngineerID, True)
                AddEngineerParametersToCommand(oEngineer)
                _database.ExecuteSP_NO_Return("Engineer_Update")
            End Sub

            Public Function [EquipmentInsert](ByVal oEquipment As Equipment) As Equipment
                _database.ClearParameter()
                AddEquipmentParametersToCommand(oEquipment)

                oEquipment.SetEquipmentID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Equipment_Insert"))
                oEquipment.Exists = True
                Return oEquipment
            End Function

            Public Sub [EquipmentUpdate](ByVal oEquipment As Equipment)
                _database.ClearParameter()
                _database.AddParameter("@EquipmentID", oEquipment.EquipmentID, True)
                AddEquipmentParametersToCommand(oEquipment)
                _database.ExecuteSP_NO_Return("Equipment_Update")
            End Sub

            Private Sub AddEquipmentParametersToCommand(ByRef oEquipment As Equipment)
                With _database

                    .AddParameter("@Name", oEquipment.Name, True)

                    .AddParameter("@EquipmentTypeID", oEquipment.EquipmentTypeID, True)
                    .AddParameter("@SerialNumber", oEquipment.SerialNumber, True)
                    .AddParameter("@CertificateNumber", oEquipment.CertificateNumber, True)
                    .AddParameter("@StatusID", oEquipment.StatusID, True)
                    .AddParameter("@AssetNo", oEquipment.AssetNo, True)

                    .AddParameter("@CalibrationDate", Entity.Sys.Helper.MakeDateTimeValid(
                                  oEquipment.CalibrationDate), True)
                    .AddParameter("@CalibrationMonths", oEquipment.CalibrationMonths, True)
                    .AddParameter("@WarrantyEndDate", Entity.Sys.Helper.MakeDateTimeValid(
                                  oEquipment.WarrantyEndDate), True)
                    .AddParameter("@EngineerID", oEquipment.EngineerID, True)
                    .AddParameter("@Notes", oEquipment.Notes, True)
                    .AddParameter("@StatusChangeDate", oEquipment.StatusChangeDate, True)
                End With
            End Sub

            Private Sub AddEngineerParametersToCommand(ByRef oEngineer As Engineer)
                With _database
                    .AddParameter("@RegionID", oEngineer.RegionID, True)
                    .AddParameter("@Name", oEngineer.Name, True)

                    .AddParameter("@EngineerGroupID", oEngineer.EngineerGroupID, True)
                    .AddParameter("@GasSafeNo", oEngineer.GasSafeNo, True)
                    .AddParameter("@OftecNo", oEngineer.OftecNo, True)
                    .AddParameter("@TelephoneNum", oEngineer.TelephoneNum, True)
                    If oEngineer.PDAID = 0 Then
                        .AddParameter("@PDAID", DBNull.Value, True)
                    Else
                        .AddParameter("@PDAID", oEngineer.PDAID, True)
                    End If

                    .AddParameter("@Apprentice", oEngineer.Apprentice, True)
                    .AddParameter("@CostToCompanyNormal", oEngineer.CostToCompanyNormal, True)
                    .AddParameter("@CostToCompanyTimeAndHalf", oEngineer.CostToCompanyTimeAndHalf, True)
                    .AddParameter("@CostToCompanyDouble", oEngineer.CostToCompanyDouble, True)

                    .AddParameter("@NextOfKinName", oEngineer.NextOfKinName, True)
                    .AddParameter("@NextOfKinContact", oEngineer.NextOfKinContact, True)
                    .AddParameter("@StartingDetails", oEngineer.StartingDetails, True)
                    .AddParameter("@DrivingLicenceNo", oEngineer.DrivingLicenceNo, True)
                    If oEngineer.DrivingLicenceIssueDate = Nothing Then
                        .AddParameter("@DrivingLicenceIssueDate", DBNull.Value, True)
                    Else
                        .AddParameter("@DrivingLicenceIssueDate", oEngineer.DrivingLicenceIssueDate, True)
                    End If
                    .AddParameter("@PayGradeID", oEngineer.PayGradeID, True)
                    .AddParameter("@AnnualSalary", oEngineer.AnnualSalary, True)
                    .AddParameter("@NINumber", oEngineer.NINumber, True)
                    .AddParameter("@HolidayYearStart", oEngineer.HolidayYearStart, True)
                    .AddParameter("@HolidayYearEnd", oEngineer.HolidayYearEnd, True)
                    .AddParameter("@DaysHolidayAllowed", oEngineer.DaysHolidayAllowed, True)
                    .AddParameter("@Technician", oEngineer.Technician, True)
                    .AddParameter("@Supervisor", oEngineer.Supervisor, True)
                    .AddParameter("@Department", oEngineer.Department, True)
                    .AddParameter("@ServPri", oEngineer.ServPri, True)
                    .AddParameter("@BreakPri", oEngineer.BreakPri, True)
                    .AddParameter("@DailyServiceLimit", oEngineer.DailyServiceLimit, True)
                    .AddParameter("@HomePostcode", oEngineer.HomePostcode, True)
                    .AddParameter("@Longitude", oEngineer.Longitude, True)
                    .AddParameter("@Latitude", oEngineer.Latitude, True)
                    .AddParameter("@ManagerUserID", oEngineer.ManagerUserID, True)
                    .AddParameter("@WebAppPassword", oEngineer.WebAppPassword, True)
                    .AddParameter("@RagRating", oEngineer.RagRating, True)
                    If oEngineer.RagDate <> Nothing AndAlso oEngineer.RagDate > SqlTypes.SqlDateTime.MinValue Then
                        .AddParameter("@RagDate", oEngineer.RagDate, True)
                    End If
                    If oEngineer.UserID = Nothing Then
                        .AddParameter("@UserID", DBNull.Value, True)
                    Else
                        .AddParameter("@UserID", oEngineer.UserID, True)
                    End If
                    Dim spendLimit As Object = If(oEngineer.VisitSpendLimit > 0, CObj(oEngineer.VisitSpendLimit), DBNull.Value)
                    .AddParameter("@VisitSpendLimit", spendLimit, True)
                    .AddParameter("@EngineerRoleId", oEngineer.EngineerRoleId, True)
                    .AddParameter("@EmailAddress", oEngineer.EmailAddress, True)
                End With
            End Sub

            Public Function Performance_Report(ByVal EngineerID As Integer, ByVal Months As ArrayList, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", EngineerID, True)
                _database.AddParameter("@Start", CDate(Format(StartDate, "dd-MMM-yyyy") & " 00:00:00"), True)
                _database.AddParameter("@End", CDate(Format(EndDate, "dd-MMM-yyyy") & " 23:59:59"), True)

                Dim monthStr As String = ""
                For Each item As String In Months
                    monthStr += item & ";"
                Next
                _database.AddParameter("@Months", monthStr, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Engineer_Performance_Report")

                dt.Columns.Remove("EngineerID")

                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineer.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerSkills_Get(ByVal engineerId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", engineerId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerJobSkill_Get_ForEngineerID")
                dt.TableName = Sys.Enums.TableNames.tblEngineerSkills.ToString
                Return New DataView(dt)
            End Function

            Public Sub EngineerSkills_Insert(ByVal engineerID As Integer, ByVal jobTypeID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", engineerID, True)
                _database.AddParameter("@JobTypeID", jobTypeID, True)
                _database.ExecuteSP_OBJECT("EngineerJobSkill_Insert")
            End Sub

            Public Sub EngineerSkills_Delete(ByVal engineerID As Integer)
                _database.ClearParameter()
                DB.ExecuteScalar("DELETE FROM tblEngineerJobSkill Where EngineerID = " & engineerID)
            End Sub

#End Region

#Region "Disciplinary Records"

            Public Sub SaveDisciplinaryRecords(ByVal engineerID As Integer, ByVal t As DataTable)
                'delete all first
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", engineerID, True)
                _database.ExecuteSP_NO_Return("Engineer_Disciplinary_Delete_All")

                If Not t Is Nothing Then
                    For Each r As DataRow In t.Rows
                        _database.ClearParameter()
                        _database.AddParameter("@EngineerID", engineerID, True)
                        _database.AddParameter("@Disciplinary", Entity.Sys.Helper.MakeStringValid(r("Disciplinary")), True)
                        _database.AddParameter("@DateIssued", r("DateIssued"), True)
                        _database.AddParameter("@DisciplinaryStatusID", r("DisciplinaryStatusID"), True)
                        _database.ExecuteSP_NO_Return("Engineer_Disciplinary_Insert")
                    Next
                End If
            End Sub

            Public Function GetDisciplinaryRecords(ByVal engineerID As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", engineerID, True)
                Return _database.ExecuteSP_DataTable("Engineer_Disciplinary_Get")
            End Function

#End Region

#Region "Equipment Records"

            Public Sub SaveEquipmentRecords(ByVal engineerID As Integer, ByVal t As DataTable)

                'delete all first
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", engineerID, True)
                _database.ExecuteSP_NO_Return("Engineer_Equipment_Delete_All")

                If Not t Is Nothing Then
                    For Each r As DataRow In t.Rows
                        _database.ClearParameter()
                        _database.AddParameter("@EngineerID", engineerID, True)
                        _database.AddParameter("@Equipment", Entity.Sys.Helper.MakeStringValid(r("Equipment")), True)
                        _database.ExecuteSP_NO_Return("Engineer_Equipment_Insert")
                    Next
                End If

            End Sub

            Public Function GetEquipmentRecords(ByVal engineerID As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", engineerID, True)
                Return _database.ExecuteSP_DataTable("Engineer_Equipment_Get")

            End Function

#End Region

        End Class

    End Namespace

End Namespace