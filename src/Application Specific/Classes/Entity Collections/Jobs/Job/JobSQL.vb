Imports System.Data.SqlClient
Imports FSM.Entity.Sys

Namespace Entity.Jobs

    Public Class JobSQL
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

#Region "Functions"

        Public Sub DeleteReservedOrderNumber(ByVal JobNumber As Integer, ByVal Prefix As String)
            Dim sql As String
            sql = "DELETE FROM tblJobNumber WHERE JobNumber = " &
                JobNumber & " AND Prefix = '" & Prefix & "'"
            DB.ExecuteWithOutReturn(sql)
        End Sub

        Public Function GetNextJobNumber(ByVal JobDefinition As Enums.JobDefinition) As JobNumber
            _database.ClearParameter()
            _database.AddParameter("@JobDefinition", CInt(JobDefinition), True)
            Dim dt As DataTable = DB.ExecuteSP_DataTable("JobNumber_Get")

            Dim oJobNumber As New JobNumber(dt.Rows(0).Item("JobNumber"), dt.Rows(0).Item("prefix"))
            Return oJobNumber
        End Function

        Public Function GetNextJobNumber(ByVal JobDefinition As Enums.JobDefinition,
                                         ByVal trans As SqlTransaction) As JobNumber
            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "JobNumber_Get"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@JobDefinition", JobDefinition)

            Dim Adapter As New SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)

            Dim dt As DataTable = returnDS.Tables(0)
            Dim oJobNumber As New JobNumber(dt.Rows(0).Item("JobNumber"), dt.Rows(0).Item("prefix"))
            Return oJobNumber
        End Function

        Public Function [Insert](ByVal oJob As Job, ByVal trans As SqlTransaction) As Job
            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "Job_Insert"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.Add(New SqlParameter("@SiteID", oJob.PropertyID))
            Command.Parameters.Add(New SqlParameter("@JobDefinitionEnumID", oJob.JobDefinitionEnumID))
            Command.Parameters.Add(New SqlParameter("@JobTypeID", oJob.JobTypeID))
            Command.Parameters.Add(New SqlParameter("@CreatedByUserID", loggedInUser.UserID))
            Command.Parameters.Add(New SqlParameter("@JobNumber", oJob.JobNumber))
            Command.Parameters.Add(New SqlParameter("@PONumber", oJob.PONumber))
            Command.Parameters.Add(New SqlParameter("@QuoteID", oJob.QuoteID))
            Command.Parameters.Add(New SqlParameter("@ContractID", oJob.ContractID))
            Command.Parameters.Add(New SqlParameter("@ToBePartPaid", oJob.ToBePartPaid))
            Command.Parameters.Add(New SqlParameter("@Retention", oJob.Retention))
            Command.Parameters.Add(New SqlParameter("@CollectPayment", oJob.CollectPayment))
            Command.Parameters.Add(New SqlParameter("@POC", oJob.POC))
            Command.Parameters.Add(New SqlParameter("@OTI", oJob.OTI))
            Command.Parameters.Add(New SqlParameter("@FOC", oJob.FOC))
            Command.Parameters.Add(New SqlParameter("@SalesRepUserID", oJob.SalesRepUserID))
            Command.Parameters.Add(New SqlParameter("@JobCreationType", oJob.JobCreationType))
            Command.Parameters.Add(New SqlParameter("@Deleted", oJob.Deleted))
            Command.Parameters.Add(New SqlParameter("@Headline", oJob.Headline))

            oJob.SetJobID = Helper.MakeIntegerValid(Command.ExecuteScalar)
            oJob.Exists = True

            For Each asset As JobAssets.JobAsset In oJob.Assets
                asset.SetJobID = oJob.JobID
                asset = _database.JobAsset.Insert(asset, trans)
            Next

            For Each jobOfWork As JobOfWorks.JobOfWork In oJob.JobOfWorks
                jobOfWork.SetJobID = oJob.JobID
                jobOfWork = _database.JobOfWorks.Insert(jobOfWork, trans)
            Next
            JobQualificationsLevels_Insert(oJob, trans)
            JobSheets_Insert(oJob, trans)

            Dim jA As New JobAudits.JobAudit
            jA.SetJobID = oJob.JobID
            jA.SetActionChange = "Job Created"
            DB.JobAudit.Insert(jA, trans)

            'GET THE JOB COMPLETELY
            Return DB.Job.Job_Get(oJob.JobID, trans)
        End Function

        Public Function [Insert](ByVal oJob As Job) As Job
            _database.ClearParameter()
            _database.AddParameter("@SiteID", oJob.PropertyID, True)
            _database.AddParameter("@JobDefinitionEnumID", oJob.JobDefinitionEnumID, True)
            _database.AddParameter("@JobTypeID", oJob.JobTypeID, True)
            _database.AddParameter("@CreatedByUserID", loggedInUser.UserID, True)
            _database.AddParameter("@JobNumber", oJob.JobNumber, True)
            _database.AddParameter("@PONumber", oJob.PONumber, True)
            _database.AddParameter("@QuoteID", oJob.QuoteID, True)
            _database.AddParameter("@ContractID", oJob.ContractID, True)
            _database.AddParameter("@ToBePartPaid", oJob.ToBePartPaid, True)
            _database.AddParameter("@Retention", oJob.Retention, True)
            _database.AddParameter("@CollectPayment", oJob.CollectPayment, True)
            _database.AddParameter("@POC", oJob.POC, True)
            _database.AddParameter("@OTI", oJob.OTI, True)
            _database.AddParameter("@FOC", oJob.FOC, True)
            _database.AddParameter("@SalesRepUserID", oJob.SalesRepUserID, True)
            _database.AddParameter("@JobCreationType", oJob.JobCreationType, True)
            _database.AddParameter("@Deleted", oJob.Deleted, True)

            oJob.SetJobID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Job_Insert"))
            oJob.Exists = True

            For Each asset As JobAssets.JobAsset In oJob.Assets
                asset.SetJobID = oJob.JobID
                asset = _database.JobAsset.Insert(asset)
            Next

            For Each jobOfWork As JobOfWorks.JobOfWork In oJob.JobOfWorks
                jobOfWork.SetJobID = oJob.JobID
                jobOfWork = _database.JobOfWorks.Insert(jobOfWork)
            Next
            JobQualificationsLevels_Insert(oJob)
            JobSheets_Insert(oJob)

            Dim jA As New JobAudits.JobAudit
            jA.SetJobID = oJob.JobID
            jA.SetActionChange = "Job Created"
            DB.JobAudit.Insert(jA)

            'GET THE JOB COMPLETELY
            Return DB.Job.Job_Get(oJob.JobID)
        End Function

        Public Function [Update](ByVal oJob As Job, ByVal JobOfWorksRemoved As ArrayList,
                                 ByVal EngineerVisitsRemoved As ArrayList,
                                 ByVal EngineerVisitsOrdersRemoved As ArrayList,
                                 ByVal trans As SqlTransaction) As Job

            For Each item As Integer In JobOfWorksRemoved
                _database.JobOfWorks.Delete(item, trans)
            Next
            For Each item As Integer In EngineerVisitsRemoved
                _database.EngineerVisits.Delete(item, trans)
            Next
            For Each item As Integer In EngineerVisitsOrdersRemoved
                _database.Order.Delete(item, trans)
            Next

            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "Job_Update"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.Add(New SqlParameter("@JobTypeID", oJob.JobTypeID))
            Command.Parameters.Add(New SqlParameter("@JobID", oJob.JobID))
            Command.Parameters.Add(New SqlParameter("@PONumber", oJob.PONumber))
            Command.Parameters.Add(New SqlParameter("@FOC", oJob.FOC))
            Command.Parameters.Add(New SqlParameter("@OTI", oJob.OTI))
            Command.Parameters.Add(New SqlParameter("@POC", oJob.POC))
            Command.Parameters.Add(New SqlParameter("@SalesRepUserID", oJob.SalesRepUserID))
            Command.Parameters.Add(New SqlParameter("@JobCreationType", oJob.JobCreationType))
            Command.Parameters.Add(New SqlParameter("@Headline", oJob.Headline))
            Command.ExecuteNonQuery()

            For Each asset As JobAssets.JobAsset In oJob.Assets
                asset.SetJobID = oJob.JobID
                asset = _database.JobAsset.Insert(asset, trans)
            Next

            For Each jobOfWork As JobOfWorks.JobOfWork In oJob.JobOfWorks
                jobOfWork.SetJobID = oJob.JobID

                If Not jobOfWork.Exists Then
                    jobOfWork = _database.JobOfWorks.Insert(jobOfWork, trans)
                Else
                    _database.JobOfWorks.Update_PONumber(jobOfWork, trans)

                    Dim IDs As String = ""
                    For Each jobItem As JobItems.JobItem In jobOfWork.JobItems
                        jobItem.SetJobOfWorkID = jobOfWork.JobOfWorkID
                        jobItem = _database.JobItems.Insert(jobItem, trans)
                        IDs += jobItem.JobItemID & ","
                    Next
                    'DELETE ANY JOB ITEMS  NOT JUST UPDATED OR INSERTED
                    If IDs.Length > 0 Then
                        IDs = IDs.Substring(0, IDs.Length - 1)
                    End If
                    ' If IDs.Length > 0 Then
                    _database.JobItems.Delete(IDs, jobOfWork.JobOfWorkID, trans)
                    ' End If
                    For Each engineerVisit As EngineerVisits.EngineerVisit In jobOfWork.EngineerVisits
                        engineerVisit.SetJobOfWorkID = jobOfWork.JobOfWorkID
                        If Not engineerVisit.Exists Then
                            engineerVisit = _database.EngineerVisits.Insert(engineerVisit, jobOfWork.JobID, trans)
                        Else
                            _database.EngineerVisits.Update(engineerVisit, jobOfWork.JobID, False, trans)
                        End If
                    Next
                End If
            Next

            JobQualificationsLevels_Insert(oJob, trans)
            JobSheets_Insert(oJob, trans)

            Return Job_Get(oJob.JobID, trans)
        End Function

        Public Function [Update](ByVal oJob As Job, ByVal JobOfWorksRemoved As ArrayList,
                                 ByVal EngineerVisitsRemoved As ArrayList,
                                 ByVal EngineerVisitsOrdersRemoved As ArrayList) As Job

            For Each item As Integer In JobOfWorksRemoved
                _database.JobOfWorks.Delete(item)
            Next
            For Each item As Integer In EngineerVisitsRemoved
                _database.EngineerVisits.Delete(item)
            Next
            For Each item As Integer In EngineerVisitsOrdersRemoved
                _database.Order.Delete(item)
            Next

            _database.ClearParameter()
            _database.AddParameter("@JobTypeID", oJob.JobTypeID, True)
            _database.AddParameter("@PONumber", oJob.PONumber, True)
            _database.AddParameter("@JobID", oJob.JobID, True)
            _database.AddParameter("@FOC", oJob.FOC, True)
            _database.AddParameter("@OTI", oJob.OTI, True)
            _database.AddParameter("@POC", oJob.POC, True)
            _database.AddParameter("@SalesRepUserID", oJob.SalesRepUserID, True)
            _database.AddParameter("@JobCreationType", oJob.JobCreationType, True)
            _database.AddParameter("@Headline", oJob.Headline, True)
            _database.ExecuteSP_NO_Return("Job_Update")

            For Each asset As JobAssets.JobAsset In oJob.Assets
                asset.SetJobID = oJob.JobID
                asset = _database.JobAsset.Insert(asset)
            Next

            For Each jobOfWork As JobOfWorks.JobOfWork In oJob.JobOfWorks
                jobOfWork.SetJobID = oJob.JobID

                If Not jobOfWork.Exists Then
                    jobOfWork = _database.JobOfWorks.Insert(jobOfWork)
                Else
                    _database.JobOfWorks.Update_PONumber(jobOfWork)

                    Dim IDs As String = ""
                    For Each jobItem As JobItems.JobItem In jobOfWork.JobItems
                        jobItem.SetJobOfWorkID = jobOfWork.JobOfWorkID
                        jobItem = _database.JobItems.Insert(jobItem)
                        IDs += jobItem.JobItemID & ","
                    Next
                    'DELETE ANY JOB ITEMS  NOT JUST UPDATED OR INSERTED
                    If IDs.Length > 0 Then
                        IDs = IDs.Substring(0, IDs.Length - 1)
                    End If
                    ' If IDs.Length > 0 Then
                    _database.JobItems.Delete(IDs, jobOfWork.JobOfWorkID)
                    ' End If
                    For Each engineerVisit As EngineerVisits.EngineerVisit In jobOfWork.EngineerVisits
                        engineerVisit.SetJobOfWorkID = jobOfWork.JobOfWorkID
                        If Not engineerVisit.Exists Then
                            engineerVisit = _database.EngineerVisits.Insert(engineerVisit, jobOfWork.JobID)
                        Else
                            _database.EngineerVisits.Update(engineerVisit, jobOfWork.JobID, False)
                        End If
                    Next
                End If
            Next

            JobQualificationsLevels_Insert(oJob)
            JobSheets_Insert(oJob)

            Return Job_Get(oJob.JobID)
        End Function

        Public Function [Update](ByVal oJob As Job) As Job
            _database.ClearParameter()
            _database.AddParameter("@JobTypeID", oJob.JobTypeID, True)
            _database.AddParameter("@PONumber", oJob.PONumber, True)
            _database.AddParameter("@JobID", oJob.JobID, True)
            _database.AddParameter("@FOC", oJob.FOC, True)
            _database.AddParameter("@OTI", oJob.OTI, True)
            _database.AddParameter("@POC", oJob.POC, True)
            _database.AddParameter("@SalesRepUserID", oJob.SalesRepUserID, True)
            _database.AddParameter("@JobCreationType", oJob.JobCreationType, True)
            _database.AddParameter("@Headline", oJob.Headline, True)
            _database.ExecuteSP_NO_Return("Job_Update")

            _database.JobAsset.Delete(oJob.JobID)
            For Each asset As JobAssets.JobAsset In oJob.Assets
                asset.SetJobID = oJob.JobID
                asset = _database.JobAsset.Insert(asset)
            Next

            For Each jobOfWork As JobOfWorks.JobOfWork In oJob.JobOfWorks
                jobOfWork.SetJobID = oJob.JobID

                If Not jobOfWork.Exists Then
                    jobOfWork = _database.JobOfWorks.Insert(jobOfWork)
                Else
                    _database.JobOfWorks.Update_PONumber(jobOfWork)

                    Dim IDs As String = ""
                    For Each jobItem As JobItems.JobItem In jobOfWork.JobItems
                        jobItem.SetJobOfWorkID = jobOfWork.JobOfWorkID
                        jobItem = _database.JobItems.Insert(jobItem)
                        IDs += jobItem.JobItemID & ","
                    Next
                    'DELETE ANY JOB ITEMS  NOT JUST UPDATED OR INSERTED
                    If IDs.Length > 0 Then
                        IDs = IDs.Substring(0, IDs.Length - 1)
                    End If
                    ' If IDs.Length > 0 Then
                    _database.JobItems.Delete(IDs, jobOfWork.JobOfWorkID)
                    ' End If

                    For Each engineerVisit As EngineerVisits.EngineerVisit In jobOfWork.EngineerVisits
                        engineerVisit.SetJobOfWorkID = jobOfWork.JobOfWorkID
                        If Not engineerVisit.Exists Then
                            engineerVisit = _database.EngineerVisits.Insert(engineerVisit, jobOfWork.JobID)
                        Else
                            _database.EngineerVisits.Update(engineerVisit, jobOfWork.JobID, False)
                        End If
                    Next
                End If
            Next

            JobQualificationsLevels_Insert(oJob)
            JobSheets_Insert(oJob)

            Return Job_Get(oJob.JobID)
        End Function

        Public Function Job_WasGeneratedByLetter(ByVal JobID As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobID", JobID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Get_Generated_By_Letter")
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function Job_Get_All(ByVal whereClause As String) As DataView
            _database.ClearParameter()
            _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)
            _database.AddParameter("@whereClause", whereClause, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Get_All")
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function Job_Manager_Search(ByVal dateFrom As DateTime, ByVal dateTo As DateTime, ByVal jobNumber As String, ByVal postcode As String, ByVal jobTypeId As Integer,
                                           ByVal customerId As Integer, ByVal siteId As Integer, ByVal statusEnumId As Integer, ByVal regionId As Integer, ByVal poNumber As String, ByVal isJobOpen As Boolean) As DataView
            _database.ClearParameter()
            _database.AddParameter("@DateFrom", Entity.Sys.Helper.InsertDateIntoDb(dateFrom), True)
            _database.AddParameter("@DateTo", Entity.Sys.Helper.InsertDateIntoDb(dateTo), True)
            _database.AddParameter("@JobNumber", jobNumber, True)
            _database.AddParameter("@PostCode", postcode, True)
            _database.AddParameter("@JobTypeID", jobTypeId, True)
            _database.AddParameter("@CustomerID", customerId, True)
            _database.AddParameter("@SiteID", siteId, True)
            _database.AddParameter("@StatusEnumID", statusEnumId, True)
            _database.AddParameter("@RegionID", regionId, True)
            _database.AddParameter("@PoNumber", poNumber, True)
            _database.AddParameter("@IsJobOpen", isJobOpen, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Manager_Search")
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function Job_Search(ByVal Criteria As String) As DataView
            _database.ClearParameter()
            _database.AddParameter("@Criteria", Criteria, True)
            _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Search")
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function [Search](ByVal Criteria As String, ByVal userId As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SearchString", Criteria, True)
            _database.AddParameter("@UserID", userId, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Search_Mk1")
            dt.TableName = Entity.Sys.Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function Job_GetTop100_For_Site(ByVal SiteID As Integer,
                                               ByVal customerID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)
            _database.AddParameter("@CustomerID", customerID, True)
            _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_GetTop100_For_Site_New")
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function Job_GetTop_For_Site(ByVal SiteID As Integer, ByVal customerID As Integer,
                                            ByVal top As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)
            _database.AddParameter("@CustomerID", customerID, True)
            _database.AddParameter("@Top", top, True)
            _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_GetTop_For_Site_New")
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function Job_GetAll_For_Asset(ByVal AssetID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@AssetID", AssetID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_GetAll_For_Asset")
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function Job_Get(ByVal JobID As Integer, ByVal trans As SqlTransaction) As Job
            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "Job_Get"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@JobID", JobID)

            Dim Adapter As New SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)
            Dim dt As DataTable = returnDS.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim job As New Job
                job.IgnoreExceptionsOnSetMethods = True
                job.Exists = True
                job.SetJobID = dt.Rows(0).Item("JobID")
                job.SetPropertyID = dt.Rows(0).Item("SiteID")
                job.SetJobDefinitionEnumID = dt.Rows(0).Item("JobDefinitionEnumID")
                job.SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                job.SetStatusEnumID = dt.Rows(0).Item("StatusEnumID")
                job.DateCreated = dt.Rows(0).Item("DateCreated")
                job.SetCreatedByUserID = dt.Rows(0).Item("CreatedByUserID")
                job.SetJobNumber = dt.Rows(0).Item("JobNumber")
                job.SetPONumber = dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows(0).Item("QuoteID")
                job.SetContractID = dt.Rows(0).Item("ContractID")
                job.SetToBePartPaid = dt.Rows(0).Item("ToBePartPaid")
                job.SetRetention = dt.Rows(0).Item("Retention")
                job.SetDeleted = dt.Rows(0).Item("Deleted")
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID, trans)
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID, trans)
                job.JobQualificationsLevels = JobQualificationsLevels_Get(job.JobID, trans)
                job.JobSheets = JobSheets_Get(job.JobID, trans)
                job.SetCollectPayment = dt.Rows(0).Item("CollectPayment")
                job.SetPOC = dt.Rows(0).Item("POC")
                job.SetOTI = dt.Rows(0).Item("OTI")
                job.SetFOC = dt.Rows(0).Item("FOC")
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows(0).Item("SalesRepUserID"))
                If dt.Columns.Contains("JobCreationType") Then
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows(0).Item("JobCreationType"))
                End If
                Return job
            Else
                Return Nothing
            End If
        End Function

        Public Function Job_Get(ByVal JobID As Integer) As Job
            _database.ClearParameter()
            _database.AddParameter("@JobID", JobID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Get")
            If dt.Rows.Count > 0 Then
                Dim job As New Job
                job.IgnoreExceptionsOnSetMethods = True
                job.Exists = True
                job.SetJobID = dt.Rows(0).Item("JobID")
                job.SetPropertyID = dt.Rows(0).Item("SiteID")
                job.SetJobDefinitionEnumID = dt.Rows(0).Item("JobDefinitionEnumID")
                job.SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                job.SetStatusEnumID = dt.Rows(0).Item("StatusEnumID")
                job.DateCreated = dt.Rows(0).Item("DateCreated")
                job.SetCreatedByUserID = dt.Rows(0).Item("CreatedByUserID")
                job.SetJobNumber = dt.Rows(0).Item("JobNumber")
                job.SetPONumber = dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows(0).Item("QuoteID")
                job.SetContractID = dt.Rows(0).Item("ContractID")
                job.SetToBePartPaid = dt.Rows(0).Item("ToBePartPaid")
                job.SetRetention = dt.Rows(0).Item("Retention")
                job.SetDeleted = dt.Rows(0).Item("Deleted")
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID)
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID)
                job.JobQualificationsLevels = JobQualificationsLevels_Get(job.JobID)
                job.JobSheets = JobSheets_Get(job.JobID)
                job.SetCollectPayment = dt.Rows(0).Item("CollectPayment")
                job.SetPOC = dt.Rows(0).Item("POC")
                job.SetOTI = dt.Rows(0).Item("OTI")
                job.SetFOC = dt.Rows(0).Item("FOC")
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows(0).Item("SalesRepUserID"))
                If dt.Columns.Contains("JobCreationType") Then
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows(0).Item("JobCreationType"))
                End If
                job.SetHeadline = dt.Rows(0).Item("Headline")
                Return job
            Else
                Return Nothing
            End If
        End Function

        Public Function [Get](ByVal id As Integer, Optional getBy As GetBy = GetBy.JobId) As Job
            _database.ClearParameter()
            'Get the datatable from the database store in dt
            Dim dt As DataTable = Nothing
            Select Case getBy
                Case GetBy.EngineerVisitId
                    _database.AddParameter("@EngineerVisitID", Helper.MakeIntegerValid(id), True)
                    dt = _database.ExecuteSP_DataTable("Job_Get_For_An_EngineerVisit_ID")

                Case Else
                    _database.AddParameter("@JobID", Helper.MakeIntegerValid(id))
                    dt = _database.ExecuteSP_DataTable("Job_Get")
            End Select

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim job As New Job
                job.IgnoreExceptionsOnSetMethods = True
                job.Exists = True
                job.SetJobID = dt.Rows(0).Item("JobID")
                job.SetPropertyID = dt.Rows(0).Item("SiteID")
                job.SetJobDefinitionEnumID = dt.Rows(0).Item("JobDefinitionEnumID")
                job.SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                job.SetStatusEnumID = dt.Rows(0).Item("StatusEnumID")
                job.DateCreated = dt.Rows(0).Item("DateCreated")
                job.SetCreatedByUserID = dt.Rows(0).Item("CreatedByUserID")
                job.SetJobNumber = dt.Rows(0).Item("JobNumber")
                If dt.Columns.Contains("PONumber") Then job.SetPONumber = dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows(0).Item("QuoteID")
                job.SetContractID = dt.Rows(0).Item("ContractID")
                job.SetToBePartPaid = dt.Rows(0).Item("ToBePartPaid")
                job.SetRetention = dt.Rows(0).Item("Retention")
                job.SetDeleted = dt.Rows(0).Item("Deleted")
                job.SetCollectPayment = dt.Rows(0).Item("CollectPayment")
                job.SetPOC = dt.Rows(0).Item("POC")
                job.SetOTI = dt.Rows(0).Item("OTI")
                job.SetFOC = dt.Rows(0).Item("FOC")
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows(0).Item("SalesRepUserID"))
                If dt.Columns.Contains("JobCreationType") Then job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows(0).Item("JobCreationType"))
                If dt.Columns.Contains("Headline") Then job.SetHeadline = dt.Rows(0).Item("Headline")
                Return job
            Else
                Return Nothing
            End If
        End Function

        Public Function Job_Get_ByOrderID(orderID As Integer) As Job
            _database.ClearParameter()
            _database.AddParameter("@OrderID", orderID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Get_ByOrderID")
            If dt.Rows.Count > 0 Then
                Dim job As New Job
                job.IgnoreExceptionsOnSetMethods = True
                job.Exists = True
                job.SetJobID = dt.Rows(0).Item("JobID")
                job.SetPropertyID = dt.Rows(0).Item("SiteID")
                job.SetJobDefinitionEnumID = dt.Rows(0).Item("JobDefinitionEnumID")
                job.SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                job.SetStatusEnumID = dt.Rows(0).Item("StatusEnumID")
                job.DateCreated = dt.Rows(0).Item("DateCreated")
                job.SetCreatedByUserID = dt.Rows(0).Item("CreatedByUserID")
                job.SetJobNumber = dt.Rows(0).Item("JobNumber")
                job.SetPONumber = dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows(0).Item("QuoteID")
                job.SetContractID = dt.Rows(0).Item("ContractID")
                job.SetToBePartPaid = dt.Rows(0).Item("ToBePartPaid")
                job.SetRetention = dt.Rows(0).Item("Retention")
                job.SetDeleted = dt.Rows(0).Item("Deleted")
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID)
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID)
                job.JobQualificationsLevels = JobQualificationsLevels_Get(job.JobID)
                job.JobSheets = JobSheets_Get(job.JobID)
                job.SetCollectPayment = dt.Rows(0).Item("CollectPayment")
                job.SetPOC = dt.Rows(0).Item("POC")
                job.SetOTI = dt.Rows(0).Item("OTI")
                job.SetFOC = dt.Rows(0).Item("FOC")
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows(0).Item("SalesRepUserID"))
                If dt.Columns.Contains("JobCreationType") Then
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows(0).Item("JobCreationType"))
                End If
                Return job
            Else
                Return Nothing
            End If
        End Function

        Public Function Job_Get_For_Quote_ID(ByVal QuoteJobID As Integer) As Job
            _database.ClearParameter()
            _database.AddParameter("@QuoteJobID", QuoteJobID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Get_For_Quote_ID")
            If dt.Rows.Count > 0 Then
                Dim job As New Job
                job.IgnoreExceptionsOnSetMethods = True
                job.Exists = True
                job.SetJobID = dt.Rows(0).Item("JobID")
                job.SetPropertyID = dt.Rows(0).Item("SiteID")
                job.SetJobDefinitionEnumID = dt.Rows(0).Item("JobDefinitionEnumID")
                job.SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                job.SetStatusEnumID = dt.Rows(0).Item("StatusEnumID")
                job.DateCreated = dt.Rows(0).Item("DateCreated")
                job.SetCreatedByUserID = dt.Rows(0).Item("CreatedByUserID")
                job.SetJobNumber = dt.Rows(0).Item("JobNumber")
                job.SetPONumber = dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows(0).Item("QuoteID")
                job.SetContractID = dt.Rows(0).Item("ContractID")
                job.SetToBePartPaid = dt.Rows(0).Item("ToBePartPaid")
                job.SetRetention = dt.Rows(0).Item("Retention")
                job.SetDeleted = dt.Rows(0).Item("Deleted")
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID)
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID)
                job.SetCollectPayment = dt.Rows(0).Item("CollectPayment")
                job.SetCollectPayment = dt.Rows(0).Item("POC")
                job.SetOTI = dt.Rows(0).Item("OTI")
                job.SetFOC = dt.Rows(0).Item("FOC")
                job.SetHeadline = dt.Rows(0).Item("Headline")
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows(0).Item("SalesRepUserID"))
                If dt.Columns.Contains("JobCreationType") Then
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows(0).Item("JobCreationType"))
                End If
                JobQualificationsLevels_Get(job.JobID)
                job.JobSheets = JobSheets_Get(job.JobID)
                Return job
            Else
                Return Nothing
            End If
        End Function

        Public Function Job_Get_For_An_EngineerVisit_ID(ByVal engineerVisitID As Integer,
                                                        ByVal trans As SqlTransaction) As Job
            'THIS ONLY GETS tblJob INFO NOT THE RELATED ENTITIES - Assets, JOW's etc
            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "Job_Get_For_An_EngineerVisit_ID"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.Add(New SqlParameter("@engineerVisitID", engineerVisitID))

            Dim Adapter As New SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)

            Dim dt As DataTable = returnDS.Tables(0)

            If dt.Rows.Count > 0 Then
                Dim job As New Job
                job.IgnoreExceptionsOnSetMethods = True
                job.Exists = True
                job.SetJobID = dt.Rows(0).Item("JobID")
                job.SetPropertyID = dt.Rows(0).Item("SiteID")
                job.SetJobDefinitionEnumID = dt.Rows(0).Item("JobDefinitionEnumID")
                job.SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                job.SetStatusEnumID = dt.Rows(0).Item("StatusEnumID")
                job.DateCreated = dt.Rows(0).Item("DateCreated")
                job.SetCreatedByUserID = dt.Rows(0).Item("CreatedByUserID")
                job.SetJobNumber = dt.Rows(0).Item("JobNumber")
                job.SetPONumber = "" 'dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows(0).Item("QuoteID")
                job.SetContractID = dt.Rows(0).Item("ContractID")
                job.SetToBePartPaid = dt.Rows(0).Item("ToBePartPaid")
                job.SetRetention = dt.Rows(0).Item("Retention")
                job.SetCollectPayment = dt.Rows(0).Item("CollectPayment")
                job.SetDeleted = dt.Rows(0).Item("Deleted")
                job.SetCollectPayment = dt.Rows(0).Item("POC")
                job.SetOTI = dt.Rows(0).Item("OTI")
                job.SetFOC = dt.Rows(0).Item("FOC")
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows(0).Item("SalesRepUserID"))
                If dt.Columns.Contains("JobCreationType") Then
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows(0).Item("JobCreationType"))
                End If
                ' job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID)
                'job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID)
                'JobQualificationsLevels_Get(job.JobID)
                'job.JobSheets = JobSheets_Get(job.JobID)
                job.SetHeadline = dt.Rows(0).Item("Headline")
                Return job
            Else
                Return Nothing
            End If
        End Function

        Public Function Job_Get_For_An_EngineerVisit_ID(ByVal engineerVisitID As Integer) As Job
            _database.ClearParameter()
            _database.AddParameter("@engineerVisitID", engineerVisitID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Get_For_An_EngineerVisit_ID")
            If dt.Rows.Count > 0 Then
                Dim job As New Job
                job.IgnoreExceptionsOnSetMethods = True
                job.Exists = True
                job.SetJobID = dt.Rows(0).Item("JobID")
                job.SetPropertyID = dt.Rows(0).Item("SiteID")
                job.SetJobDefinitionEnumID = dt.Rows(0).Item("JobDefinitionEnumID")
                job.SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                job.SetStatusEnumID = dt.Rows(0).Item("StatusEnumID")
                job.DateCreated = dt.Rows(0).Item("DateCreated")
                job.SetCreatedByUserID = dt.Rows(0).Item("CreatedByUserID")
                job.SetJobNumber = dt.Rows(0).Item("JobNumber")
                job.SetPONumber = "" 'dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows(0).Item("QuoteID")
                job.SetContractID = dt.Rows(0).Item("ContractID")
                job.SetToBePartPaid = dt.Rows(0).Item("ToBePartPaid")
                job.SetRetention = dt.Rows(0).Item("Retention")
                job.SetCollectPayment = dt.Rows(0).Item("CollectPayment")
                job.SetDeleted = dt.Rows(0).Item("Deleted")
                job.SetCollectPayment = dt.Rows(0).Item("POC")
                job.SetOTI = dt.Rows(0).Item("OTI")
                job.SetFOC = dt.Rows(0).Item("FOC")
                job.SetHeadline = dt.Rows(0).Item("Headline")
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows(0).Item("SalesRepUserID"))
                If dt.Columns.Contains("JobCreationType") Then
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows(0).Item("JobCreationType"))
                End If
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID)
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID)
                JobQualificationsLevels_Get(job.JobID)
                job.JobSheets = JobSheets_Get(job.JobID)
                Return job
            Else
                Return Nothing
            End If
        End Function

        Public Function Job_Check_Before_Delete(ByVal JobID As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobID", JobID, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Check_Before_Delete")

            For Each row As DataRow In dt.Rows
                If CInt(row.Item("StatusEnumID")) >= CInt(Enums.VisitStatus.Scheduled) Then
                    Return False
                End If
                Dim dvVisitParts As DataView =
                    DB.EngineerVisitPartProductAllocated.
                    EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(CInt(row.Item("EngineerVisitID")))
                If dvVisitParts.Count > 0 Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Sub Job_Delete(ByVal JobID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@JobID", JobID, True)
            _database.ExecuteSP_NO_Return("Job_Delete")
        End Sub

        Public Sub Job_Delete_BySite(ByVal SiteID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)
            _database.ExecuteSP_NO_Return("Job_Delete_BySite")
        End Sub

        Public Function Job_MoveSite(ByVal jobId As Integer, ByVal oldSiteId As Integer,
                                       ByVal newSiteId As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@JobID", jobId, True)
            _database.AddParameter("@OldSiteID", oldSiteId, True)
            _database.AddParameter("@NewSiteID", newSiteId, True)
            Return Helper.MakeBooleanValid(_database.ExecuteSP_ReturnRowsAffected("Job_MoveSite") = 1)
        End Function

        Public Function JobQualificationsLevels_Get(ByVal JobID As Integer) As DataView
            Dim command As New SqlCommand("JobQualificationsLevels_Get",
                                          New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@JobID", JobID)

            Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function JobQualificationsLevels_Get(ByVal JobID As Integer,
                                                    ByVal trans As SqlTransaction) As DataView
            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "JobQualificationsLevels_Get"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@JobID", JobID)

            Dim Adapter As New SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)

            Dim dt As DataTable = returnDS.Tables(0)
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function [JobQualificationsLevels_EngineerCheck](ByVal jobID As Integer,
                                                                ByVal engineerID As Integer) As Boolean
            Dim command As New SqlCommand("JobQualificationsLevels_EngineerCheck",
                                          New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.AddWithValue("@JobID", jobID)
            command.Parameters.AddWithValue("@EngineerID", engineerID)
            Return CBool(command.ExecuteScalar)
        End Function

        Private Sub JobQualificationsLevels_Insert(ByVal oJob As Job)
            _database.ClearParameter()
            _database.AddParameter("@JobID", oJob.JobID, True)
            _database.ExecuteSP_NO_Return("JobQualificationsLevels_Delete")

            If Not oJob.JobQualificationsLevels.Table Is Nothing Then
                For Each r As DataRow In oJob.JobQualificationsLevels.Table.Rows
                    If r("Tick") = True Then
                        _database.ClearParameter()
                        _database.AddParameter("@JobID", oJob.JobID, True)
                        _database.AddParameter("@QualificationLevelID", r("ManagerID"))
                        _database.ExecuteSP_NO_Return("JobQualificationsLevels_Insert")
                    End If
                Next
            End If
        End Sub

        Private Sub JobQualificationsLevels_Insert(ByVal oJob As Job, ByVal trans As SqlTransaction)
            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "JobQualificationsLevels_Delete"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@JobID", oJob.JobID)
            Command.ExecuteNonQuery()

            If Not oJob.JobQualificationsLevels.Table Is Nothing Then
                For Each r As DataRow In oJob.JobQualificationsLevels.Table.Rows
                    If r("Tick") = True Then
                        Dim CommandInsert As SqlCommand = New SqlCommand
                        CommandInsert.CommandText = "JobQualificationsLevels_Insert"
                        CommandInsert.CommandType = CommandType.StoredProcedure
                        CommandInsert.Transaction = trans
                        CommandInsert.Connection = trans.Connection
                        CommandInsert.Parameters.AddWithValue("@JobID", oJob.JobID)
                        CommandInsert.Parameters.AddWithValue("@QualificationLevelID", r("ManagerID"))
                        CommandInsert.ExecuteNonQuery()
                    End If
                Next
            End If
        End Sub

        Public Function JobSheets_Get(ByVal JobID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@JobID", JobID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobSheet_Get_JobID")
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function JobSheets_Get(ByVal JobID As Integer, ByVal trans As SqlTransaction) As DataView
            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "JobSheet_Get_JobID"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@JobID", JobID)

            Dim Adapter As New SqlDataAdapter(Command)
            Dim returnDS As New DataSet
            Adapter.Fill(returnDS)

            Dim dt As DataTable = returnDS.Tables(0)
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Private Sub JobSheets_Insert(ByVal oJob As Job, ByVal trans As SqlTransaction)
            Dim Command As SqlCommand = New SqlCommand
            Command.CommandText = "JobSheet_Delete"
            Command.CommandType = CommandType.StoredProcedure
            Command.Transaction = trans
            Command.Connection = trans.Connection

            Command.Parameters.AddWithValue("@JobID", oJob.JobID)
            Command.ExecuteNonQuery()

            If Not oJob.JobSheets.Table Is Nothing Then
                For Each r As DataRow In oJob.JobSheets.Table.Rows
                    If r("Tick") = True Then
                        Dim CommandInsert As SqlCommand = New SqlCommand
                        CommandInsert.CommandText = "JobSheet_Insert"
                        CommandInsert.CommandType = CommandType.StoredProcedure
                        CommandInsert.Transaction = trans
                        CommandInsert.Connection = trans.Connection
                        CommandInsert.Parameters.AddWithValue("@JobID", oJob.JobID)
                        CommandInsert.Parameters.AddWithValue("@JobSheetID", r("JobSheetID"))
                        CommandInsert.ExecuteNonQuery()
                    End If
                Next
            End If
        End Sub

        Private Sub JobSheets_Insert(ByVal oJob As Job)
            _database.ClearParameter()
            _database.AddParameter("@JobID", oJob.JobID, True)
            _database.ExecuteSP_NO_Return("JobSheet_Delete")

            If Not oJob.JobSheets.Table Is Nothing Then
                For Each r As DataRow In oJob.JobSheets.Table.Rows
                    If r("Tick") = True Then
                        _database.ClearParameter()
                        _database.AddParameter("@JobID", oJob.JobID, True)
                        _database.AddParameter("@JobSheetID", r("JobSheetID"))
                        _database.ExecuteSP_NO_Return("JobSheet_Insert")
                    End If
                Next
            End If
        End Sub

        Public Sub CompleteJob(ByVal JobID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@JobID", JobID, True)
            _database.AddParameter("@StatusID", CInt(Enums.JobStatus.Complete), True)
            _database.ExecuteSP_NO_Return("Job_Complete")
        End Sub

        Public Sub UnlockTimed(ByVal UserID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@UserID", UserID, True)
            _database.ExecuteSP_NO_Return("JobLock_DeleteAll_After_Time")
        End Sub

        Public Sub UnlockAll(ByVal UserID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@UserID", UserID, True)
            _database.ExecuteSP_NO_Return("JobLock_DeleteAll")
        End Sub

        Public Function Job_Get_All_WithNumberOfVisits(ByVal WhereFilter As String) As DataView
            _database.ClearParameter()
            _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)
            _database.AddParameter("@WhereFilter", WhereFilter, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("Job_Get_All_WithNumberOfVisits")
            dt.TableName = Enums.TableNames.tblJob.ToString
            Return New DataView(dt)
        End Function

        Public Function [JobOfWork_Required_Priority](ByVal SiteID As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)
            Return Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("JobOfWork_Required_Priority"))
        End Function

        Public Function GetEngineerTabletOrderRef(ByVal EngineerVisitID As Integer,
                                                  ByVal EngineerID As Integer) As String
            Try
                Dim ExistingOrderRef As String = 0
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                ExistingOrderRef = _database.ExecuteScalar("SELECT EngNextOrder FROM tblEngineerVisit WHERE EngineerVisitID = " & EngineerVisitID)

                If ExistingOrderRef = "0" Then
                    If EngineerID = 0 Then
                        ShowMessage("An error has occurred:" & vbCrLf & "There is no engineer assigned to this visit, process cannot continue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return "False"
                        Exit Function
                    End If
                    Dim Eng_ds As New DataSet
                    Dim Eng_dt As New DataTable
                    Dim EngineerName As String = ""
                    Dim Dept As String = ""
                    _database.ClearParameter()
                    _database.AddParameter("@EngineerID", EngineerID, True)
                    Eng_dt = _database.ExecuteSP_DataTable("Engineer_Get")
                    Eng_ds.Tables.Add(Eng_dt)
                    If Eng_ds.Tables(0).Rows.Count > 0 Then
                        With Eng_ds.Tables(0).Rows(0)
                            EngineerName = CStr(.Item("Name"))
                            Dept = CStr(.Item("Department"))
                        End With
                    End If

                    Dim Job_ds As New DataSet
                    Dim Job_dt As New DataTable
                    Dim Job_JobID As String = ""
                    Dim Job_VisitType As Integer
                    Dim Job_SiteID As Integer
                    _database.ClearParameter()
                    _database.AddParameter("@engineerVisitID", EngineerVisitID, True)
                    Job_dt = _database.ExecuteSP_DataTable("Job_Get_For_An_EngineerVisit_ID")
                    Job_ds.Tables.Add(Job_dt)
                    If Job_ds.Tables(0).Rows.Count > 0 Then
                        With Job_ds.Tables(0).Rows(0)
                            Job_JobID = CStr(.Item("JobID"))
                            Job_VisitType = CStr(.Item("JobTypeID"))
                            Job_SiteID = CStr(.Item("SiteID"))
                        End With
                    End If

                    If Not Job_VisitType = 4703 Then 'not breakdown
                        Dim Job_JobNumber As String
                        Dim Job_JobPrefix As String
                        Dim JobNumber_ds As New DataSet
                        Dim JobNumber_dt As New DataTable

                        _database.ClearParameter()
                        _database.AddParameter("@JobDefinition", Enums.JobDefinition.Callout, True)
                        JobNumber_dt = _database.ExecuteSP_DataTable("JobNumber_Get")
                        JobNumber_ds.Tables.Add(JobNumber_dt)
                        If JobNumber_ds.Tables(0).Rows.Count > 0 Then
                            With JobNumber_ds.Tables(0).Rows(0)
                                Job_JobNumber = CStr(.Item("JobNumber"))
                                Job_JobPrefix = CStr(.Item("Prefix"))
                            End With
                            Job_JobNumber = Job_JobPrefix & Job_JobNumber

                            _database.ClearParameter()
                            _database.AddParameter("@SiteID", Job_SiteID, True)
                            _database.AddParameter("@JobDefinitionEnumID", Enums.JobDefinition.Callout, True)
                            _database.AddParameter("@JobTypeID", 4703, True)
                            _database.AddParameter("@CreatedByUserID", 2, True)
                            _database.AddParameter("@JobNumber", Job_JobNumber, True)
                            _database.AddParameter("@PONumber", DBNull.Value, True)
                            _database.AddParameter("@QuoteID", 0, True)
                            _database.AddParameter("@ContractID", 0, True)
                            _database.AddParameter("@ToBePartPaid", False, True)
                            _database.AddParameter("@Retention", 0, True)
                            _database.AddParameter("@CollectPayment", False, True)
                            _database.AddParameter("@POC", False, True)
                            _database.AddParameter("@OTI", False, True)
                            _database.AddParameter("@FOC", False, True)
                            _database.AddParameter("@Deleted", 0, True)
                            Job_JobID = _database.SP_ExecuteScalar("Job_Insert")

                            Dim NewJobActionChange As String =
                                "New Job Inserted (From Tablet - Engineer " &
                                EngineerName & ") - JobNumber: " & Job_JobNumber & " (Unique Job ID: " &
                                Job_JobID & ")"
                            _database.ClearParameter()
                            _database.AddParameter("@JobID", Job_JobID, True)
                            _database.AddParameter("@ActionChange", NewJobActionChange, True)
                            _database.AddParameter("@ActionDateTime", Now, True)
                            _database.AddParameter("@UserID", "2", True)
                            _database.SP_ExecuteScalar("JobAudit_Insert")
                        End If
                    End If

                    Dim JoW_JoWID As Integer
                    _database.ClearParameter()
                    _database.AddParameter("@JobID", Job_JobID, True)
                    _database.AddParameter("@Deleted", "0", True)
                    _database.AddParameter("@PONumber", DBNull.Value, True)
                    _database.AddParameter("@Status", "1", True)
                    _database.AddParameter("@Priority", DBNull.Value, True)
                    _database.AddParameter("@PriorityDateSet", DBNull.Value, True)
                    JoW_JoWID = _database.SP_ExecuteScalar("JobOfWork_Insert")

                    Dim NewVisitID As String
                    _database.ClearParameter()
                    _database.AddParameter("@JobOfWorkID", JoW_JoWID, True)
                    _database.AddParameter("@EngineerID", "0", True)
                    _database.AddParameter("@StartDateTime", DBNull.Value, True)
                    _database.AddParameter("@EndDateTime", DBNull.Value, True)
                    _database.AddParameter("@StatusEnumID", "0", True)
                    _database.AddParameter("@NotesToEngineer", "Created from Tablet", True)
                    _database.AddParameter("@PartsToFit", "1", True)
                    _database.AddParameter("@ExpectedEngineerID", "0", True)
                    _database.AddParameter("@DueDate", DBNull.Value, True)
                    _database.AddParameter("@Recharge", "0", True)
                    _database.AddParameter("@Deleted", "0", True)
                    _database.AddParameter("@AMPM", DBNull.Value, True)
                    NewVisitID = _database.SP_ExecuteScalar("EngineerVisit_Insert")

                    Dim ActionChange As String =
                        "New Visit Inserted (From Tablet - Engineer " & EngineerName & ") - Status: " &
                        Replace(CType(0, Enums.VisitStatus).ToString, "_", " ") & " (Unique Visit ID: " &
                        NewVisitID & ")"
                    _database.ClearParameter()
                    _database.AddParameter("@JobID", Job_JobID, True)
                    _database.AddParameter("@ActionChange", ActionChange, True)
                    _database.AddParameter("@ActionDateTime", Now, True)
                    _database.AddParameter("@UserID", "2", True)
                    _database.SP_ExecuteScalar("JobAudit_Insert")

                    Dim Order_ds As New DataSet
                    Dim Order_dt As New DataTable
                    Dim OrderID As String = ""
                    _database.ClearParameter()
                    _database.AddParameter("@JobDefinition", Enums.JobDefinition.ORDER, True)
                    Order_dt = _database.ExecuteSP_DataTable("JobNumber_Get")
                    Order_ds.Tables.Add(Order_dt)
                    If Order_ds.Tables(0).Rows.Count > 0 Then
                        With Order_ds.Tables(0).Rows(0)
                            OrderID = CStr(.Item("JobNumber"))
                        End With
                    End If

                    Dim OrderRef As String = GetOrderReference(Enums.OrderType.Job, EngineerName, OrderID)
                    Dim NewOrderID As Integer
                    _database.ClearParameter()
                    _database.AddParameter("@DatePlaced", Now, True)
                    _database.AddParameter("@OrderTypeID", Enums.OrderType.Job, True)
                    _database.AddParameter("@OrderReference", OrderRef, True)
                    _database.AddParameter("@UserID", "2", True)
                    _database.AddParameter("@OrderStatusID", Enums.OrderStatus.AwaitingConfirmation, True)
                    _database.AddParameter("@ReasonForReject", DBNull.Value, True)
                    _database.AddParameter("@DeliveryDeadline", DBNull.Value, True)
                    _database.AddParameter("@SpecialInstructions", DBNull.Value, True)
                    _database.AddParameter("@ContactID", "0", True)
                    _database.AddParameter("@InvoiceAddressID", "0", True)
                    _database.AddParameter("@AllocatedToUser", "0", True)
                    _database.AddParameter("@DepartmentRef", Dept, True)
                    _database.AddParameter("@DoNotConsolidated", "1", True)
                    NewOrderID = _database.SP_ExecuteScalar("Order_Insert")

                    _database.ClearParameter()
                    _database.AddParameter("@OrderID", NewOrderID, True)
                    _database.AddParameter("@EngineerVisitID", NewVisitID, True)
                    _database.AddParameter("@WarehouseID", "0", True)
                    _database.SP_ExecuteScalar("EngineerVisitOrder_Insert")

                    _database.ClearParameter()
                    _database.ExecuteScalar("UPDATE tblEngineerVisit SET EngNextOrder = '" &
                                            OrderRef & "' WHERE EngineerVisitID = '" & EngineerVisitID & "'")

                    Return OrderRef
                Else
                    Return ExistingOrderRef
                End If
            Catch ex As SqlException
                Return ex.Message
            Catch ex As Exception
                Return ex.Message
            End Try

        End Function

        Public Shared Function GetOrderReference(ByVal oOrderType As Enums.OrderType,
                                                 ByVal EngineerName As String,
                                                 ByVal JobNumberIn As String) As String
            Dim OrderNumber As New JobNumber
            OrderNumber.OrderNumber = JobNumberIn

            While OrderNumber.OrderNumber.Length < 5
                OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
            End While

            Dim typePrefix As String = ""
            Select Case oOrderType
                Case Enums.OrderType.Customer
                    typePrefix = "W"
                Case Enums.OrderType.StockProfile
                    typePrefix = "V"
                Case Enums.OrderType.Warehouse
                    typePrefix = "W"
            End Select

            Dim userPrefix As String = ""
            Dim username() As String = EngineerName.Split(" ")
            For Each s As String In username
                userPrefix = s.Substring(0, 1)
            Next

            Return userPrefix & typePrefix & OrderNumber.OrderNumber
        End Function

        Public Function CreateJobImportAdHocVisit(ByVal r As DataRow, ByVal scheduleJobs As Boolean) As Job
            Dim theVisitDate As DateTime

            'get the sor info from the job type
            Dim jobImportType As JobImport.JobImportType = DB.JobImports.JobImportType_Get(Helper.MakeIntegerValid(r("JobImportTypeID")))
            If jobImportType Is Nothing Then Return Nothing

            Dim SORdt As DataTable = DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID).Table
            Dim siteId As Integer = Helper.MakeIntegerValid(r("SiteID"))
            Dim oSite As Sites.Site = DB.Sites.Get(siteId)
            Dim visittime As Integer = 0

            Dim jobId As Integer = Helper.MakeIntegerValid(r("JobID"))

            Dim job As Job
            Dim jobOfWork As New JobOfWorks.JobOfWork
            If jobId = 0 Then
                job = New Job
                job.SetPropertyID = siteId
                job.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Callout)

                job.SetJobTypeID = jobImportType.JobTypeID
                job.SetStatusEnumID = CInt(Enums.JobStatus.Open)
                job.SetCreatedByUserID = loggedInUser.UserID
                job.SetFOC = True
                job.SetJobCreationType = CInt(Enums.JobCreationType.JobManager)

                'get job number
                Dim JobNumber As New JobNumber
                JobNumber = DB.Job.GetNextJobNumber(CInt(Enums.JobDefinition.Callout))

                job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                job.SetPONumber = ""
                job.SetQuoteID = 0
                job.SetContractID = 0

                'Get service priority
                Dim servicePriority As Integer
                Dim rows As Array = DB.Picklists.GetAll(CInt(Enums.PickListTypes.JOWPriority)).Table.Select("Name = 'Dayworks'")
                If rows.Length = 0 Then
                    Dim oPickList As New PickLists.PickList
                    oPickList.SetName = "Dayworks"
                    oPickList.SetEnumTypeID = CInt(Enums.PickListTypes.JOWPriority)
                    servicePriority = DB.Picklists.Insert(oPickList)
                Else
                    servicePriority = CType(rows(0), DataRow).Item("ManagerID")
                End If

                '  INSERT JOB ITEM
                jobOfWork.SetPONumber = ""
                jobOfWork.SetPriority = servicePriority
                If Not jobOfWork.Priority = 0 Then
                    jobOfWork.PriorityDateSet = Now
                End If
                jobOfWork.IgnoreExceptionsOnSetMethods = True

                For Each sorRow As DataRow In SORdt.Rows
                    Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(Helper.MakeIntegerValid(sorRow("ScheduleOfRatesCategoryID")), Helper.MakeStringValid(sorRow("Description")), Helper.MakeStringValid(sorRow("Code")), oSite.CustomerID)
                    Dim customerSorId As Integer = 0
                    If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0).Item(0))

                    If Not customerSorId > 0 Then
                        Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                                .SetCode = Helper.MakeStringValid(sorRow("Code")),
                                .SetDescription = Helper.MakeStringValid(sorRow("Description")),
                                .SetPrice = Helper.MakeDoubleValid(sorRow("Price")),
                                .SetScheduleOfRatesCategoryID = Helper.MakeIntegerValid(sorRow("ScheduleOfRatesCategoryID")),
                                .SetTimeInMins = Helper.MakeIntegerValid(sorRow("TimeInMins")),
                                .SetCustomerID = oSite.CustomerID
                            }
                        customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                        DB.CustomerScheduleOfRate.Delete(customerSorId)
                    End If

                    Dim jobItem As New JobItems.JobItem
                    jobItem.IgnoreExceptionsOnSetMethods = True
                    jobItem.SetSummary = Helper.MakeStringValid(sorRow("Description"))
                    jobItem.SetQty = 1
                    jobItem.SetRateID = customerSorId
                    jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
                    jobOfWork.JobItems.Add(jobItem)
                Next
            Else
                job = Job_Get(jobId)
                job.SetJobCreationType = CInt(Entity.Sys.Enums.JobCreationType.JobManager)
                jobOfWork = CType(job.JobOfWorks(0), JobOfWorks.JobOfWork)
                Dim oEngineerVisit As EngineerVisits.EngineerVisit = CType(jobOfWork.EngineerVisits(0), EngineerVisits.EngineerVisit)
                visittime = oEngineerVisit.EndDateTime.Subtract(oEngineerVisit.StartDateTime).TotalMinutes
            End If

            Dim engineerVisit As New EngineerVisits.EngineerVisit
            engineerVisit.IgnoreExceptionsOnSetMethods = True
            engineerVisit.SetEngineerID = 0
            If scheduleJobs Then
                engineerVisit.SetEngineerID = Helper.MakeIntegerValid(r("EngineerID"))
                engineerVisit.SetNotesToEngineer = "(" & r("AMPM") & ") " & jobImportType.Name

                If oSite.CustomerID = Enums.Customer.Victory Then
                    If jobId > 0 Then
                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & vbCrLf & vbCrLf & "Collect overdue letter from office first!"
                    End If
                    engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & vbCrLf & vbCrLf &
                        "We are looking for ‘satisfactory’ certificates so we must under take essential remedial works whilst onsite – C1s & C2s." & vbCrLf & vbCrLf &
                        "We don’t want CU upgraded to current Regs unless it is in a particularly high risk location." & vbCrLf & vbCrLf &
                        "If a property doesn't have a hardwired smoke detector on each floor then record this on the test cert."
                End If

                Dim DT As DataTable = DB.EngineerVisits.Find_The_Gap(Format(Helper.MakeDateTimeValid(r("NextVisitDate")), "yyyy-MM-dd"), Helper.MakeIntegerValid(r("EngineerID")), Helper.MakeStringValid(r("AMPM")))
                Dim startdatetime As String = ""

                If DT.Rows.Count = 0 And r("AMPM") = "AM" Then
                    startdatetime = Helper.MakeStringValid(r("NextVisitDate")).Substring(0, 10) & " 08:05:00"
                    startdatetime.Replace("/", "-")
                ElseIf DT.Rows.Count = 0 And r("AMPM") = "PM" Then
                    startdatetime = Helper.MakeStringValid(r("NextVisitDate")).Substring(0, 10) & " 12:05:00"
                    startdatetime.Replace("/", "-")
                Else
                    startdatetime = Helper.MakeStringValid(DT.Rows(0)("EndDateTime"))
                End If
                Dim enddatetime As String = Helper.MakeDateTimeValid(startdatetime).AddMinutes(CDbl(visittime))

                startdatetime = Format(Helper.MakeDateTimeValid(startdatetime), "yyyy-MM-dd HH:mm:ss")
                enddatetime = Format(Helper.MakeDateTimeValid(enddatetime), "yyyy-MM-dd HH:mm:ss")

                engineerVisit.StartDateTime = startdatetime
                engineerVisit.EndDateTime = enddatetime
                engineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Scheduled)
                engineerVisit.DueDate = theVisitDate
                engineerVisit.SetAMPM = Helper.MakeStringValid(r("AMPM"))
            Else
                engineerVisit.SetNotesToEngineer = ""
                engineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Ready_For_Schedule)
            End If

            If jobId = 0 Then
                engineerVisit.SetVisitNumber = 1
            Else
                engineerVisit.SetVisitNumber = DB.EngineerVisits.EngineerVisits_Get_All_JobID(CInt(r("JobID"))).Count + 1
            End If

            jobOfWork.EngineerVisits.Add(engineerVisit)

            If jobId = 0 Then
                job.JobOfWorks.Add(jobOfWork)
                job = DB.Job.Insert(job)
            Else
                job = DB.Job.Update(job)
            End If
            Return job
        End Function

        Public Function GenerateServiceLetterJob(ByVal r As DataRow, ByVal customerID As Integer, ByVal AMPM As String, Optional ByVal fuelId As Integer = 0) As Job

            Dim theVisitDate As DateTime
            Dim SORdt As DataTable = DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll.Table
            Dim oSite As Sites.Site = DB.Sites.Get(Helper.MakeIntegerValid(r("SiteID")))
            Dim visittime As Integer = 0
            Dim fuel As String

            Dim sorRowsL1COM() As DataRow = SORdt.Select("Code='EA7008' OR Code = 'PATCH'")
            Dim sorRowsL1SOLID() As DataRow = SORdt.Select("Code='EA7001'")
            Dim sorRowsL1STD() As DataRow = SORdt.Select("Code='EA7007'")
            Dim sorRowsL2COM() As DataRow = SORdt.Select("Code='EA7008*' OR Code = 'PATCH'")
            Dim sorRowsL2SOLID() As DataRow = SORdt.Select("Code='EA7001*'")
            Dim sorRowsL2STD() As DataRow = SORdt.Select("Code='EA7007*'")
            Dim sorRowsL3COM() As DataRow = SORdt.Select("Code='EA7008^' OR Code = 'PATCH'")
            Dim sorRowsL3SOLID() As DataRow = SORdt.Select("Code='EA7001^'")
            Dim sorRowsL3STD() As DataRow = SORdt.Select("Code='EA7007^'")

            'lets see if site has a job booked in on that day
            Dim _currentJob As Job
            Dim jobOfWork As New JobOfWorks.JobOfWork
            Dim multipleFuel As DataTable = DB.LetterManager.LetterManager_GetJob_FromSiteAndDate(oSite.SiteID, Helper.MakeDateTimeValid(r("BookedDateTime")).Date)
            If multipleFuel.Rows.Count > 0 Then
                _currentJob = DB.Job.Job_Get(Helper.MakeIntegerValid(multipleFuel.Rows(0)("JobID")))
                jobOfWork = CType(_currentJob.JobOfWorks(0), JobOfWorks.JobOfWork)
            Else
                Dim JobNumber As New JobNumber
                Select Case customerID
                    Case Enums.Customer.NCC 'Norwich City Council
                        JobNumber = GetNextJobNumber(Enums.JobDefinition.SERVICE_LETTER_JOB)
                    Case Else
                        JobNumber = GetNextJobNumber(Enums.JobDefinition.Callout)
                End Select

                Dim servicePriority As Integer = 0
                Dim rows As Array = DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'Service'")
                If rows.Length = 0 Then
                    Dim oPickList As New PickLists.PickList
                    oPickList.SetName = "Service"
                    oPickList.SetEnumTypeID = CInt(Enums.PickListTypes.JOWPriority)
                    servicePriority = DB.Picklists.Insert(oPickList)
                Else
                    servicePriority = CType(rows(0), DataRow).Item("ManagerID")
                End If

                _currentJob = New Job
                _currentJob.SetPropertyID = Helper.MakeIntegerValid(r("SiteID"))
                _currentJob.SetJobCreationType = CInt(Enums.JobCreationType.LetterManager)
                _currentJob.SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Callout)
                _currentJob.SetJobTypeID = CInt(Enums.JobTypes.ServiceCertificate)
                _currentJob.SetStatusEnumID = CInt(Enums.JobStatus.Open)
                _currentJob.SetCreatedByUserID = loggedInUser.UserID
                _currentJob.SetFOC = True

                _currentJob.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
                _currentJob.SetPONumber = ""
                _currentJob.SetQuoteID = 0
                _currentJob.SetContractID = 0

                '  INSERT JOB ITEM
                jobOfWork.SetPONumber = ""
                jobOfWork.SetPriority = servicePriority
                If Not jobOfWork.Priority = 0 Then
                    jobOfWork.PriorityDateSet = Now
                End If
                jobOfWork.IgnoreExceptionsOnSetMethods = True
            End If

            Dim siteFuel As String = Helper.MakeStringValid(r("SiteFuel"))
            Dim letterType As String = Helper.MakeStringValid(r("Type"))
            Dim patchCheck As Boolean = r.Table.Columns.Contains("PatchCheck") AndAlso r("PatchCheck") = True

            Dim sorRows() As DataRow = Nothing
            If letterType = "Letter 1" Then
                If oSite.CommercialDistrict = True Or patchCheck Then
                    sorRows = sorRowsL1COM
                    visittime = 15
                ElseIf oSite.SolidFuel = True Or siteFuel.Contains("Solid") Then
                    sorRows = sorRowsL1SOLID
                    visittime = 75
                ElseIf siteFuel.Contains("Oil") Then
                    sorRows = sorRowsL1STD
                    visittime = 60
                Else
                    sorRows = sorRowsL1STD
                    visittime = 40
                End If
            ElseIf letterType = "Letter 2" Then
                If oSite.CommercialDistrict = True Or patchCheck Then
                    sorRows = sorRowsL2COM
                    visittime = 15
                ElseIf oSite.SolidFuel = True Or siteFuel.Contains("Solid") Then
                    sorRows = sorRowsL2SOLID
                    visittime = 75
                ElseIf siteFuel.Contains("Oil") Then
                    sorRows = sorRowsL2STD
                    visittime = 60
                Else
                    sorRows = sorRowsL2STD
                    visittime = 40
                End If
            ElseIf letterType = "Letter 3" Then
                If oSite.CommercialDistrict = True Or patchCheck Then
                    sorRows = sorRowsL3COM
                    visittime = 15
                ElseIf oSite.SolidFuel = True Or siteFuel.Contains("Solid") Then
                    sorRows = sorRowsL3SOLID
                    visittime = 75
                ElseIf siteFuel.Contains("Oil") Then
                    sorRows = sorRowsL3STD
                    visittime = 60
                Else
                    sorRows = sorRowsL3STD
                    visittime = 40
                End If
            End If

            If sorRows.Length > 0 Then
                For Each sorRow As DataRow In sorRows
                    Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(Helper.MakeIntegerValid(sorRow("ScheduleOfRatesCategoryID")), Helper.MakeStringValid(sorRow("Description")), Helper.MakeStringValid(sorRow("Code")), oSite.CustomerID)
                    Dim customerSorId As Integer = 0
                    If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0).Item(0))

                    If Not customerSorId > 0 Then
                        Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                                .SetCode = Helper.MakeStringValid(sorRow("Code")),
                                .SetDescription = Helper.MakeStringValid(sorRow("Description")),
                                .SetPrice = Helper.MakeDoubleValid(sorRow("Price")),
                                .SetScheduleOfRatesCategoryID = Helper.MakeIntegerValid(sorRow("ScheduleOfRatesCategoryID")),
                                .SetTimeInMins = Helper.MakeIntegerValid(sorRow("TimeInMins")),
                                .SetCustomerID = oSite.CustomerID
                            }
                        customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                        DB.CustomerScheduleOfRate.Delete(customerSorId)
                    End If

                    Dim jobItem As New JobItems.JobItem
                    jobItem.IgnoreExceptionsOnSetMethods = True
                    jobItem.SetSummary = Helper.MakeStringValid(sorRow("Description"))
                    jobItem.SetQty = 1
                    jobItem.SetRateID = customerSorId
                    jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
                    jobOfWork.JobItems.Add(jobItem)
                Next

            End If

            Dim engineerVisit As New EngineerVisits.EngineerVisit
            engineerVisit.IgnoreExceptionsOnSetMethods = True
            engineerVisit.SetEngineerID = 0
            engineerVisit.SetEngineerID = r("EngineerID")
            'set site fuel in visit notes

            If patchCheck Then
                engineerVisit.SetNotesToEngineer = "(" & AMPM & ") - Patch Check"
            Else
                If Helper.IsStringEmpty(siteFuel) Then
                    fuel = ""
                ElseIf siteFuel = "Gas" Or siteFuel = "0" Then
                    fuel = ""
                Else
                    fuel = siteFuel
                End If

                If fuelId = 0 Then
                    If r.Table.Columns.Contains("FuelID") AndAlso Not IsDBNull(r("FuelID")) Then fuelId = Helper.MakeIntegerValid(r("FuelID"))
                End If
                If r.Table.Columns.Contains("MultipleFuelSite") AndAlso Helper.MakeBooleanValid(r("MultipleFuelSite")) Then fuel += " - Multiple Fuel Site"

                Dim visitNotes As String = String.Empty
                If Not String.IsNullOrEmpty(oSite.ContactAlerts) Then visitNotes += oSite.ContactAlerts & " "
                visitNotes += "(" & AMPM & ") - " & fuel & " - Carry out safety inspection"

                engineerVisit.SetNotesToEngineer = visitNotes
                engineerVisit.SetFuelID = fuelId

                Select Case customerID
                    Case Enums.Customer.NCC 'Norwich City Council
                        If letterType = "Letter 2" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Take hand delivered letter and red sticker. "
                        ElseIf letterType = "Letter 3" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape."
                        End If
                        If letterType <> "Letter 1" Then
                            engineerVisit.SetPartsToFit = True
                        End If

                    Case Enums.Customer.Victory
                        If letterType = "Letter 1" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Please ensure service timer is re-set and record that this has been done. Set to 11 months from visit and code - 8727"
                        ElseIf letterType = "Letter 2" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Second Visit, Take hand delivered letter and Yellow Sticker. Service Expires: " &
                                CDate(r("LastServiceDate")).AddYears(1) & ", Please ensure service timer is re-set and record that this has been done. Set to 11 months from visit and code - 8727"
                        ElseIf letterType = "Letter 3" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape."
                        End If
                        If letterType <> "Letter 1" Then
                            engineerVisit.SetPartsToFit = True
                        End If

                    Case Enums.Customer.WDC
                        Dim ChangedDate As DateTime = CDate(r("LastServiceDate")).AddYears(1)
                        ChangedDate = ChangedDate.AddDays(-7)
                        ChangedDate = DateHelper.CheckBankHolidaySatOrSun(ChangedDate)

                        If letterType = "Letter 2" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Second Visit, Take hand delivered letter and Red Sticker. Final Visit: " & ChangedDate
                        ElseIf letterType = "Letter 3" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", Yellow tape visit, take hand delivered letter, camera and yellow tape."
                        End If
                        If letterType <> "Letter 1" Then
                            engineerVisit.SetPartsToFit = True
                        End If

                    Case Enums.Customer.Flagship, Enums.Customer.FlagshipMarketRented
                        If letterType = "Letter 2" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ", *PLEASE ADVISE IF METER IS INTERNAL*"
                        ElseIf letterType = "Letter 3" Then

                            If Helper.MakeIntegerValid(r("CustomerID")) = Enums.Customer.NCC Then

                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer
                            ElseIf Helper.MakeIntegerValid(r("CustomerID")) = Enums.Customer.Saffron Then
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer
                            Else
                            End If

                        End If
                        If letterType <> "Letter 1" Then
                            engineerVisit.SetPartsToFit = False
                        End If

                    Case Enums.Customer.Tendring
                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer & ". *Please ensure service timer is re-set and record that this has been done*"
                    Case Else
                        If letterType = "Letter 2" Then
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer
                        ElseIf letterType = "Letter 3" Then

                            If Helper.MakeIntegerValid(r("CustomerID")) = Enums.Customer.NCC Then

                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer
                            ElseIf Helper.MakeIntegerValid(r("CustomerID")) = Enums.Customer.Saffron Then
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer
                            Else
                            End If

                        End If
                        If letterType <> "Letter 1" Then
                            engineerVisit.SetPartsToFit = False
                        End If
                End Select

            End If

            ''' find the Gap
            Dim DT As DataTable = DB.EngineerVisits.Find_The_Gap(Helper.MakeDateTimeValid(r("BookedDateTime")).ToString("yyyy-MM-dd"), Helper.MakeIntegerValid(r("EngineerID")), Helper.MakeStringValid(r("AMPM")))
            Dim startdatetime As String
            If DT.Rows.Count = 0 And Helper.MakeStringValid(r("AMPM")) = "AM" Then
                startdatetime = Helper.MakeStringValid(r("BookedDateTime")).Substring(0, 10) & " 08:05:00"
                startdatetime.Replace("/", "-")
            ElseIf DT.Rows.Count = 0 And r("AMPM") = "PM" Then
                startdatetime = Helper.MakeStringValid(r("BookedDateTime")).Substring(0, 10) & " 12:05:00"
                startdatetime.Replace("/", "-")
            Else
                startdatetime = Helper.MakeStringValid(DT.Rows(0)("EndDateTime"))
            End If

            Dim enddatetime As String = Helper.MakeDateTimeValid(startdatetime).AddMinutes(CDbl(visittime))
            startdatetime = Format(Helper.MakeDateTimeValid(startdatetime), "yyyy-MM-dd HH:mm:ss")
            enddatetime = Format(Helper.MakeDateTimeValid(enddatetime), "yyyy-MM-dd HH:mm:ss")
            engineerVisit.StartDateTime = startdatetime
            engineerVisit.EndDateTime = enddatetime
            engineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Scheduled)
            engineerVisit.DueDate = theVisitDate
            engineerVisit.SetAMPM = AMPM

            If Helper.MakeStringValid(r("Type")) = "Letter 1" Then
                engineerVisit.SetVisitNumber = 1
            ElseIf Helper.MakeStringValid(r("Type")) = "Letter 2" Then
                engineerVisit.SetVisitNumber = 2
            ElseIf Helper.MakeStringValid(r("Type")) = "Letter 3" Then
                engineerVisit.SetVisitNumber = 3
            End If

            jobOfWork.EngineerVisits.Add(engineerVisit)
            If multipleFuel.Rows.Count > 0 Then
                _currentJob = DB.Job.Update(_currentJob)
            Else
                _currentJob.JobOfWorks.Add(jobOfWork)
                _currentJob = DB.Job.Insert(_currentJob)
            End If
            Return _currentJob
        End Function

#End Region

#Region "Job Notes"

        Public Function GetJobNotes(ByVal jobID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@JobID", jobID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobNote_Get_For_Job")
            dt.TableName = Enums.TableNames.tblJobNotes.ToString
            Return New DataView(dt)
        End Function

        Public Function GetAllJobNotes(ByVal SiteID As Integer) As DataTable
            _database.ClearParameter()
            _database.AddParameter("@SiteID", SiteID, True)

            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobNotes_Get_For_site")
            dt.TableName = Enums.TableNames.tblJobNotes.ToString
            Return (dt)
        End Function

        Public Function SaveJobNotes(ByVal JobNoteID As Integer,
                                      ByVal Note As String,
                                      ByVal EditedByUserID As Integer,
                                      ByVal JobID As Integer,
                                      ByVal CreatedByUserID As Integer) As DataView

            _database.ClearParameter()

            If JobNoteID > 0 Then
                _database.AddParameter("@JobNoteID", JobNoteID, True)
                _database.AddParameter("@Note", Note, True)
                _database.AddParameter("@EditedByUserID", EditedByUserID, True)
                _database.ExecuteSP_NO_Return("JobNote_Update")
            Else
                _database.AddParameter("@JobID", JobID, True)
                _database.AddParameter("@Note", Note, True)
                _database.AddParameter("@CreatedByUserID", CreatedByUserID, True)
                _database.ExecuteSP_NO_Return("JobNote_Insert")
            End If

            Return GetJobNotes(JobID)
        End Function

        Public Sub DeleteJobNote(ByVal jobNoteID As Integer)
            _database.ClearParameter()
            _database.AddParameter("@JobNoteID", jobNoteID, True)

            _database.ExecuteSP_NO_Return("JobNote_Delete")
        End Sub

#End Region

    End Class

End Namespace