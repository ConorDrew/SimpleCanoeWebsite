Imports System.Data.SqlClient

Namespace Entity.LetterManager

    Public Class LetterManagerSQL
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Functions"

        Public Function GetBucketsL1(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return New DataView(_database.ExecuteSP_DataTable("GetBucketsL1"))
        End Function

        Public Function MakeServiceLetter(ByVal engineervisitid As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@EngineerVisitID", engineervisitid, True)

            Return New DataView(_database.ExecuteSP_DataTable("MakeServiceLetter"))

        End Function

        Public Function ClearStuckSite(ByVal Lastservicedate As DateTime, ByVal SiteID As Integer, ByVal Type As String) As DataView
            _database.ClearParameter()
            _database.AddParameter("@LastServiceDate", Lastservicedate.ToString("yyyy-MM-dd"), True)
            _database.AddParameter("@SiteID", SiteID, True)
            _database.AddParameter("@Type", Type, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_ClearStuckSites"))

        End Function

        Public Function GetLetterScheduledAppointments(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@Date", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return New DataView(_database.ExecuteSP_DataTable("GetLetterScheduledAppointments"))

        End Function

        Public Function Letter1ManagerMK2Profile(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer, Optional ByVal top As Integer = 0) As DataView
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)
            _database.AddParameter("@top", top, True)
            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_1_MK2_Profile_New"))

        End Function

        Public Function Letter1ManagerMK2(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)
            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_1_MK2_New"))

        End Function

        Public Function Letter1Manager(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer, Optional ByVal Days As Integer = -309) As DataView
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)
            _database.AddParameter("@Days", Days, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager"))

        End Function

        Public Function Letter2Manager(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer, Optional ByVal Days As Integer = -330) As DataTable                '
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)
            _database.AddParameter("@Days", Days, True)

            Return _database.ExecuteSP_DataTable("Letter2Manager")

        End Function

        Public Function Letter2ManagerMK2(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataView                '
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_2_MK2_New"))

        End Function

        Public Function Letter3ManagerMK2(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataView                '

            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_3_MK2_New"))
        End Function

        Public Function Letter3Manager(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataTable                '
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return _database.ExecuteSP_DataTable("Letter3Manager")

        End Function

        Public Sub LetterGenerated(ByVal SiteID As Integer, ByVal LetterType As String, ByVal LastServiceDate As DateTime,
                                   ByVal JobID As Integer, ByVal FolderPath As String, ByVal trans As SqlClient.SqlTransaction)

            Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

            Command.CommandText = "LetterGenerated"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SiteID", SiteID))
            Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LetterType", LetterType))
            Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastServiceDate", LastServiceDate))
            Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobID", JobID))
            Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FolderPath", FolderPath))
            Command.ExecuteNonQuery()
        End Sub

        Public Sub LetterGeneratedMK2(ByVal SiteID As Integer, ByVal LetterType As String, ByVal LastServiceDate As DateTime,
                                  ByVal JobID As Integer, ByVal FolderPath As String, Optional ByVal fuelId As Integer = 0)

            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)
            _database.AddParameter("@LetterType", LetterType, True)
            _database.AddParameter("@LastServiceDate", LastServiceDate, True)
            _database.AddParameter("@JobID", JobID, True)
            _database.AddParameter("@FolderPath", FolderPath, True)
            _database.AddParameter("@FuelID", fuelId, True)
            _database.ExecuteSP_NO_Return("LetterGenerated")
        End Sub

        Public Function LetterReport(ByVal SiteID As Integer) As DataTable                '
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)

            Return _database.ExecuteSP_DataTable("LetterReport")

        End Function

        Public Function Letter3_TomorrowsVisit(ByVal tomorrow As DateTime) As DataTable                '
            _database.ClearParameter()

            _database.AddParameter("@TomorrowStart", CDate(Format(tomorrow, "dd-MMM-yyyy") & " 00:00:00"), True)
            _database.AddParameter("@TomorrowEnd", CDate(Format(tomorrow, "dd-MMM-yyyy") & " 23:59:59"), True)

            Return _database.ExecuteSP_DataTable("Letter3_TomorrowsVisit")

        End Function

        Public Sub Clear_LetterDays_Table()
            _database.ExecuteWithOutReturn("DELETE FROM tblLetterDays", False)
        End Sub

        Public Sub Update_LetterDays_Table(ByVal MondayDate As Date, ByVal TheDate As Date, ByVal ApptCount As Integer, ByVal AM As Integer, ByVal PM As Integer, ByVal MinsTally As Integer, ByVal LoopNumber As Integer)
            If PM = Nothing Then
                _database.ExecuteWithOutReturn("UPDATE tblLetterDays SET ApptCount = '" & ApptCount & "', AM = '" & AM & "', MinsTally = '" & MinsTally & "' WHERE MondayDate = '" & Format(MondayDate, "yyyy-MM-dd") & "' AND TheDate = '" & Format(TheDate, "yyyy-MM-dd") & "' AND LoopNumber = '" & LoopNumber & "'", False)
            Else
                _database.ExecuteWithOutReturn("UPDATE tblLetterDays SET ApptCount = '" & ApptCount & "', PM = '" & PM & "', MinsTally = '" & MinsTally & "' WHERE MondayDate = '" & Format(MondayDate, "yyyy-MM-dd") & "' AND TheDate = '" & Format(TheDate, "yyyy-MM-dd") & "' AND LoopNumber = '" & LoopNumber & "'", False)
            End If
        End Sub

        Public Sub Insert_LetterDays_Table(ByVal MondayDate As Date, ByVal TheDate As Date, ByVal MinsTally As Integer, ByVal LoopNumber As Integer)
            _database.ExecuteWithOutReturn("INSERT INTO tblLetterDays (MondayDate, TheDate, ApptCount, AM, PM, MinsTally, LoopNumber) VALUES ('" & Format(MondayDate, "yyyy-MM-dd") & "','" & Format(TheDate, "yyyy-MM-dd") & "',1,1,1,'" & MinsTally & "','" & LoopNumber & "')", False)
        End Sub

        Public Function Get_Letter1Jobs(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer, ByVal profile As Boolean, Optional ByVal top As Integer = 0) As DataView
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)
            _database.AddParameter("@Profile", profile, True)
            _database.AddParameter("@Top", top, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_1_Mk4"))
        End Function

        Public Function Get_Letter1Jobs_MultipleFuel(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_1_Mk4_MultipleFuel"))
        End Function

        Public Function Get_Letter2Jobs(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataView                '
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_2_Mk4"))
        End Function

        Public Function Get_Letter3Jobs(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer, Optional ByVal fuelId As Integer = 0) As DataView                '
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_3_Mk4"))
        End Function

        Public Function GetLetterScheduledAppointmentsMK3(ByVal LetterManagerFilterDate As DateTime, ByVal CustomerID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@Date", LetterManagerFilterDate, True)
            _database.AddParameter("@CustomerID", CustomerID, True)

            Return New DataView(_database.ExecuteSP_DataTable("GetLetterScheduledAppointmentsMK3"))
        End Function

        Public Function Get_Appointments_Main_MK3(ByVal StartDate As DateTime, ByVal TimeReq As Integer,
                                                  Optional ByVal days As Integer = 14, Optional ByVal TimeLimit As Integer = 240) As DataTable
            _database.ClearParameter()
            _database.AddParameter("@StartDate", StartDate, True)
            _database.AddParameter("@timereq", TimeReq, True)
            _database.AddParameter("@Days", days, True)
            _database.AddParameter("@TimeLimit", TimeLimit, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Get_Appointments_Main")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJobItem.ToString
            Return dt
        End Function

        Public Function LetterManager_GetJob_FromSiteAndDate(ByVal siteId As Integer, ByVal bookedDate As DateTime) As DataTable
            _database.ClearParameter()
            _database.AddParameter("@SiteID", siteId, True)
            _database.AddParameter("@VisitDate", bookedDate, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("LetterManager_GetJob_FromSiteAndDate")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            Return dt
        End Function

        Public Function LetterGenerated_CheckToday(ByVal letterType As String, ByVal jobId As Integer,
                                                   ByVal genDate As DateTime) As DataTable
            _database.ClearParameter()
            _database.AddParameter("@LetterType", letterType, True)
            _database.AddParameter("@JobID", jobId, True)
            _database.AddParameter("@GenDate", genDate, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("LetterGenerated_CheckToday")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            Return dt
        End Function

        Public Function LetterManagerAddSiteMK3(ByVal LetterManagerFilterDate As DateTime, ByVal SiteID As Integer) As DataView                '
            _database.ClearParameter()
            _database.AddParameter("@LetterManagerFilterDate", LetterManagerFilterDate, True)
            _database.AddParameter("@SiteID", SiteID, True)

            Return New DataView(_database.ExecuteSP_DataTable("LetterManager_AddSite_MK3"))
        End Function

#End Region

    End Class

End Namespace