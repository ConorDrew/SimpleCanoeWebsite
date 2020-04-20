Namespace Entity.JobImport

    Public Class JobImportSQL

        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Job Imports"

        Public Function JobImport_Insert(ByVal oJobImport As JobImport) As JobImport
            _database.ClearParameter()
            _database.AddParameter("@SiteId", oJobImport.SiteID, True)
            _database.AddParameter("@UPRN", oJobImport.UPRN, True)
            _database.AddParameter("@JobImportTypeId", oJobImport.JobImportTypeID, True)
            _database.AddParameter("@DateAdded", oJobImport.DateAdded, True)

            oJobImport.SetJobImportID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobImport_Insert"))
            oJobImport.Exists = True
            Return oJobImport
        End Function

        Public Function JobImport_Exist(ByVal siteId As Integer, ByVal jobImportTypeId As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@SiteId", siteId)
            _database.AddParameter("@JobImportTypeId", jobImportTypeId)

            Dim count As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobImport_Exist"))

            Dim exist As Boolean = False
            If count > 0 Then
                exist = True
            End If
            Return exist
        End Function

        Public Function JobImport_Get_ByJobNumber(ByVal jobNumber As String) As DataView
            _database.ClearParameter()
            _database.AddParameter("@JobNumber", jobNumber)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobImport_Get_ByJobNumber")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function JobImport_Get_BySiteID(ByVal siteId As Integer, Optional ByVal jobImportTypeId As Integer = 0) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SiteId", siteId)
            _database.AddParameter("@JobImportTypeId", jobImportTypeId)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobImport_Get_BySiteID")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function JobImport_Get_L1Jobs(ByVal jobImportTypeId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@JobImportTypeId", jobImportTypeId)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobImport_Get_L1Jobs")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString

            Return New DataView(dt)
        End Function

        Public Function JobImport_Get_L1Jobs_NoOrder(ByVal jobImportTypeId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@JobImportTypeId", jobImportTypeId)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobImport_Get_L1Jobs_NoOrder")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString

            Return New DataView(dt)
        End Function

        Public Function JobImport_Get_L2Jobs(ByVal jobImportTypeId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@JobImportTypeId", jobImportTypeId)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobImport_Get_L2Jobs")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString

            Return New DataView(dt)
        End Function

        Public Function JobImport_Get_EngineerJobs(ByVal startDate As DateTime, ByVal endDate As DateTime,
                                                   ByVal jobImportTypeId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@StartDate", startDate, True)
            _database.AddParameter("@EndDate", endDate, True)
            _database.AddParameter("@JobImportTypeId", IIf(jobImportTypeId > 0, jobImportTypeId, Nothing), True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobImport_Get_EngineerJobs")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function JobImport_Update_Job(ByVal jobImportId As Integer, ByVal oJob As Jobs.Job) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobImportID", jobImportId)
            _database.AddParameter("@JobID", oJob.JobID)
            _database.AddParameter("@JobNumber", oJob.JobNumber)

            Return CBool(_database.ExecuteSP_ReturnRowsAffected("JobImport_Update_Job") = 1)
        End Function

        Public Function JobImport_Update_Letter1(ByVal dr As DataRow, ByVal oJob As Jobs.Job) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobImportID", CInt(dr("JobImportID")))
            _database.AddParameter("@JobID", oJob.JobID)
            _database.AddParameter("@JobNumber", oJob.JobNumber)
            _database.AddParameter("@Status", Sys.Enums.EngineerVisitOutcomes.NOT_SET)
            _database.AddParameter("@BookedDate", CDate(dr("BookedVisit")), True)
            _database.AddParameter("@Letter1", Now, True)

            Return CBool(_database.ExecuteSP_ReturnRowsAffected("JobImport_Update_Letter1") = 1)
        End Function

        Public Function JobImport_Update_Letter2(ByVal dr As DataRow, ByVal oJob As Jobs.Job) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobImportID", CInt(dr("JobImportID")))
            _database.AddParameter("@Status", Sys.Enums.EngineerVisitOutcomes.Carded)
            _database.AddParameter("@BookedDate", CDate(dr("BookedVisit")), True)
            _database.AddParameter("@Letter2", Now, True)

            Return CBool(_database.ExecuteSP_ReturnRowsAffected("JobImport_Update_Letter2") = 1)
        End Function

        Public Function JobImport_Delete_WithJobType(ByVal jobImportId As Integer, ByVal jobImportTypeId As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobImportTypeId", jobImportTypeId)
            _database.AddParameter("@JobImportId", jobImportId)
            Return CBool(_database.ExecuteSP_OBJECT("JobImport_Delete_WithJobType") = 1)
        End Function

#End Region

#Region "Job Import Types"

        Public Function JobImportType_GetAll() As DataView
            _database.ClearParameter()
            Return New DataView(_database.ExecuteSP_DataTable("JobImportType_GetAll"))
        End Function

        Public Function JobImportType_Get(ByVal jobImportTypeId As Integer) As JobImportType
            _database.ClearParameter()
            _database.AddParameter("@JobImportTypeId", jobImportTypeId)

            'Get the datatable from the database store in dt
            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobImportType_Get")

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Dim oJobImportType As New JobImportType
                    With oJobImportType
                        .IgnoreExceptionsOnSetMethods = True
                        .SetJobImportTypeID = dt.Rows(0).Item("JobImportTypeID")
                        .SetCycle = dt.Rows(0).Item("Cycle")
                        .SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                        .SetName = dt.Rows(0).Item("Name")
                        .SetJobTypeName = dt.Rows(0).Item("JobTypeName")
                        .SetEngineerQualID = dt.Rows(0).Item("EngineerQualID")
                    End With
                    oJobImportType.Exists = True
                    Return oJobImportType
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Function

        Public Function JobImportType_Insert(ByVal oJobImportType As JobImportType) As JobImportType
            _database.ClearParameter()
            _database.AddParameter("@Name", oJobImportType.Name)
            _database.AddParameter("@JobTypeID", oJobImportType.JobTypeID)
            _database.AddParameter("@EngineerQualID", oJobImportType.EngineerQualID)
            _database.AddParameter("@Cycle", oJobImportType.Cycle)

            oJobImportType.SetJobImportTypeID =
                    Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobImportType_Insert"))
            oJobImportType.Exists = True
            Return oJobImportType
        End Function

        Public Function JobImportType_Update(ByVal oJobImportType As JobImportType) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobImportTypeID", oJobImportType.JobImportTypeID)
            _database.AddParameter("@Name", oJobImportType.Name)
            _database.AddParameter("@JobTypeID", oJobImportType.JobTypeID)
            _database.AddParameter("@EngineerQualID", oJobImportType.EngineerQualID)
            _database.AddParameter("@Cycle", oJobImportType.Cycle)

            Return CBool(_database.ExecuteSP_ReturnRowsAffected("JobImportType_Update") = 1)
        End Function

        Public Function JobImportType_Delete(ByVal oJobImportType As JobImportType) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobImportTypeID", oJobImportType.JobImportTypeID)
            Return CBool(_database.ExecuteSP_OBJECT("JobImportType_Delete") = 1)
        End Function

#End Region

    End Class

End Namespace