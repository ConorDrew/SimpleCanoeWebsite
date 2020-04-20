Imports FSM.Entity
Imports FSM.Entity.Sys

Public Class FRMCreateServices

    Public SiteID As Integer

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If IsNumeric(txtAmount.Text) AndAlso txtAmount.Text > 0 Then

                CreateServices()
                MsgBox(txtAmount.Text & " Services created!", MsgBoxStyle.Information)
                If Me.Modal Then
                    Me.Close()
                Else
                    Me.Dispose()
                End If
            Else
                ShowMessage("Please select an Amount to create", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MsgBox("Somthing went terribly wrong , best speak to Rob", MsgBoxStyle.Critical, "Ooooppss")
        End Try
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub CreateServices()

        For i As Integer = 1 To CInt(txtAmount.Text)
            'CREATE JOB
            Dim job As New Entity.Jobs.Job
            job.SetPropertyID = SiteID
            job.SetJobDefinitionEnumID = CInt(Entity.Sys.Enums.JobDefinition.Contract)
            If chxCert.Checked Then
                job.SetJobTypeID = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")(0).Item("ManagerID")
            Else
                job.SetJobTypeID = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")(0).Item("ManagerID")
            End If

            job.SetStatusEnumID = CInt(Entity.Sys.Enums.JobStatus.Open)
            job.SetCreatedByUserID = loggedInUser.UserID
            job.SetFOC = True
            Dim JobNumber As New JobNumber
            JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Contract)
            job.SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber
            job.SetPONumber = ""
            job.SetQuoteID = 0

            '  INSERT JOB ITEM
            Dim jobOfWork As New Entity.JobOfWorks.JobOfWork
            jobOfWork.SetPONumber = ""
            jobOfWork.IgnoreExceptionsOnSetMethods = True

            Dim site As Entity.Sites.Site = DB.Sites.Get(SiteID)

            Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(4693, "Hassle Free Service", "HF1", site.CustomerID)
            Dim customerSorId As Integer = 0
            If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0).Item(0))

            If Not customerSorId > 0 Then
                Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                                .SetCode = "HF1",
                                .SetDescription = "Hassle Free Service",
                                .SetPrice = 0.0,
                                .SetScheduleOfRatesCategoryID = 4693,
                                .SetTimeInMins = 45,
                                .SetCustomerID = site.CustomerID
                            }
                customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                DB.CustomerScheduleOfRate.Delete(customerSorId)
            End If

            Dim jobItem As New JobItems.JobItem
            jobItem.IgnoreExceptionsOnSetMethods = True
            jobItem.SetSummary = "Hassle Free Service"
            jobItem.SetQty = 1
            jobItem.SetRateID = customerSorId
            jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
            jobOfWork.JobItems.Add(jobItem)

            Dim engineerVisit As New Entity.EngineerVisits.EngineerVisit
            engineerVisit.IgnoreExceptionsOnSetMethods = True
            engineerVisit.SetEngineerID = 0 'engineerID

            If chxCert.Checked Then
                engineerVisit.SetNotesToEngineer = "Service and Cert Appliance Covered by Hassle Free Heating"
            Else
                engineerVisit.SetNotesToEngineer = "Service Appliance Covered by Hassle Free Heating"
            End If
            engineerVisit.StartDateTime = DateTime.MinValue
            engineerVisit.EndDateTime = DateTime.MinValue
            engineerVisit.SetStatusEnumID = CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)

            jobOfWork.EngineerVisits.Add(engineerVisit)

            job.JobOfWorks.Add(jobOfWork)
            job = DB.Job.Insert(job)

        Next i

    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If

    End Sub

End Class