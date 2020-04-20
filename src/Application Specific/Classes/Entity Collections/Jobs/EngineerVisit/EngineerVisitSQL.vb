Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Sys

Namespace Entity

    Namespace EngineerVisits

        Public Class EngineerVisitSQL
            Private _database As Database

            Public Sub New(ByVal database As Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                _database.ExecuteSP_NO_Return("EngineerVisit_Delete")

                Dim jA As New JobAudits.JobAudit
                jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID).JobID
                jA.SetActionChange = "Visit Deleted (Unique Visit ID: " & EngineerVisitID & ")"
                DB.JobAudit.Insert(jA)
            End Sub

            Public Sub Delete(ByVal EngineerVisitID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisit_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID))
                Command.ExecuteNonQuery()

                Dim jA As New JobAudits.JobAudit
                jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID, trans).JobID
                jA.SetActionChange = "Visit Deleted: (" & EngineerVisitID & ")"
                DB.JobAudit.Insert(jA, trans)

            End Sub

            Public Function [Insert](ByVal oEngineerVisit As EngineerVisit, ByVal JobID As Integer, ByVal trans As SqlClient.SqlTransaction) As EngineerVisit

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisit_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New SqlClient.SqlParameter("@JobOfWorkID", oEngineerVisit.JobOfWorkID))
                Command.Parameters.Add(New SqlClient.SqlParameter("@EngineerID", oEngineerVisit.EngineerID))
                Command.Parameters.Add(New SqlClient.SqlParameter("@Deleted", oEngineerVisit.Deleted))

                If Not oEngineerVisit.StartDateTime = System.DateTime.MinValue Then
                    Command.Parameters.Add(New SqlClient.SqlParameter("@StartDateTime", oEngineerVisit.StartDateTime))
                Else
                    Command.Parameters.Add(New SqlClient.SqlParameter("@StartDateTime", DBNull.Value))
                End If
                If Not oEngineerVisit.EndDateTime = System.DateTime.MinValue Then
                    Command.Parameters.Add(New SqlClient.SqlParameter("@EndDateTime", oEngineerVisit.EndDateTime))
                Else
                    Command.Parameters.Add(New SqlClient.SqlParameter("@EndDateTime", DBNull.Value))
                End If

                Command.Parameters.Add(New SqlClient.SqlParameter("@StatusEnumID", oEngineerVisit.StatusEnumID))
                Command.Parameters.Add(New SqlClient.SqlParameter("@NotesToEngineer", oEngineerVisit.NotesToEngineer))
                Command.Parameters.Add(New SqlClient.SqlParameter("@PartsToFit", oEngineerVisit.PartsToFit))
                Command.Parameters.Add(New SqlClient.SqlParameter("@ExpectedEngineerID", oEngineerVisit.ExpectedEngineerID))
                Command.Parameters.Add(New SqlClient.SqlParameter("@AMPM", oEngineerVisit.AMPM))
                Command.Parameters.Add(New SqlClient.SqlParameter("@VisitNumber", oEngineerVisit.VisitNumber))

                If oEngineerVisit.DueDate = Date.MinValue Then
                    Command.Parameters.Add(New SqlClient.SqlParameter("@DueDate", DBNull.Value))
                Else
                    Command.Parameters.Add(New SqlClient.SqlParameter("@DueDate", oEngineerVisit.DueDate))
                End If

                Command.Parameters.Add(New SqlClient.SqlParameter("@Recharge", oEngineerVisit.Recharge))
                Command.Parameters.Add(New SqlClient.SqlParameter("@ExcludeFromTextMessage", oEngineerVisit.ExcludeFromTextMessage))
                Command.Parameters.Add(New SqlClient.SqlParameter("@RechargeType", oEngineerVisit.RechargeTypeID))
                Command.Parameters.Add(New SqlClient.SqlParameter("@NccRadID", oEngineerVisit.NccRadID))
                Command.Parameters.Add(New SqlClient.SqlParameter("@MeterLocationID", oEngineerVisit.MeterLocationID))
                Command.Parameters.Add(New SqlClient.SqlParameter("@MeterCappedID", oEngineerVisit.MeterCappedID))
                Command.Parameters.Add(New SqlClient.SqlParameter("@ExpectedDepartment", oEngineerVisit.ExpectedDepartment))
                Command.Parameters.Add(New SqlClient.SqlParameter("@FuelID", oEngineerVisit.FuelID))

                oEngineerVisit.SetEngineerVisitID = Helper.MakeIntegerValid(Command.ExecuteScalar)
                oEngineerVisit.Exists = True

                Dim jA As New JobAudits.JobAudit
                jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID
                jA.SetActionChange = "New Visit Inserted - Status: " & Replace(CType(oEngineerVisit.StatusEnumID, Enums.VisitStatus).ToString, "_", " ") &
                        " (Unique Visit ID: " & oEngineerVisit.EngineerVisitID & ")"

                DB.JobAudit.Insert(jA, trans)

                DB.EngineerVisitPartProductAllocated.NewInsert(oEngineerVisit.PartsAndProductsAllocated, oEngineerVisit.EngineerVisitID, JobID, trans)

                Return oEngineerVisit
            End Function

            Public Function [Insert](ByVal oEngineerVisit As EngineerVisit, ByVal JobID As Integer, Optional ByVal appointmentID As Integer = 0, Optional ByVal oldVisitId As Integer = 0) As EngineerVisit
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", oEngineerVisit.JobOfWorkID, True)
                _database.AddParameter("@EngineerID", oEngineerVisit.EngineerID, True)
                _database.AddParameter("@Deleted", oEngineerVisit.Deleted, True)
                _database.AddParameter("@StartDateTime", Helper.InsertDateIntoDb(oEngineerVisit.StartDateTime), True)
                _database.AddParameter("@EndDateTime", Helper.InsertDateIntoDb(oEngineerVisit.EndDateTime), True)
                _database.AddParameter("@StatusEnumID", oEngineerVisit.StatusEnumID, True)
                _database.AddParameter("@NotesToEngineer", oEngineerVisit.NotesToEngineer, True)
                _database.AddParameter("@PartsToFit", oEngineerVisit.PartsToFit, True)
                _database.AddParameter("@ExpectedEngineerID", oEngineerVisit.ExpectedEngineerID, True)
                _database.AddParameter("@AMPM", oEngineerVisit.AMPM, True)
                _database.AddParameter("@VisitNumber", oEngineerVisit.VisitNumber)
                _database.AddParameter("@DueDate", Helper.InsertDateIntoDb(oEngineerVisit.DueDate), True)
                _database.AddParameter("@Recharge", oEngineerVisit.Recharge)
                _database.AddParameter("@RechargeType", oEngineerVisit.RechargeTypeID)
                _database.AddParameter("@NccRadID", oEngineerVisit.NccRadID)
                _database.AddParameter("@MeterCappedID", oEngineerVisit.MeterCappedID)
                _database.AddParameter("@MeterLocationID", oEngineerVisit.MeterLocationID)
                If oEngineerVisit.AppointmentID > 0 Then
                    _database.AddParameter("@AppointmentID", oEngineerVisit.AppointmentID, True)
                Else
                    _database.AddParameter("@AppointmentID", appointmentID, True)
                End If
                _database.AddParameter("@ExpectedDepartment", oEngineerVisit.ExpectedDepartment, True)
                _database.AddParameter("@FuelID", oEngineerVisit.FuelID, True)
                _database.AddParameter("@OldVisitId", oldVisitId, True)

                oEngineerVisit.SetEngineerVisitID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisit_Insert"))
                oEngineerVisit.Exists = True
                Dim jA As New JobAudits.JobAudit With {.SetJobID = JobID}
                If oEngineerVisit.StatusEnumID = Enums.VisitStatus.Scheduled Then
                    jA.SetActionChange = "New Visit Inserted - Status: Scheduled, to Engineer: " & DB.Engineer.Engineer_Get(oEngineerVisit.EngineerID)?.Name &
                    " For " & Format(oEngineerVisit.StartDateTime, "dd-MMM-yyyy HH:mm") & " (Unique Visit ID: " & oEngineerVisit.EngineerVisitID & ")"
                Else
                    jA.SetActionChange = "New Visit Inserted - Status: " & Replace(CType(oEngineerVisit.StatusEnumID, Enums.VisitStatus).ToString, "_", " ") &
                       " (Unique Visit ID: " & oEngineerVisit.EngineerVisitID & ")"
                End If

                DB.JobAudit.Insert(jA)
                DB.EngineerVisitPartProductAllocated.Insert(oEngineerVisit.PartsAndProductsAllocated, oEngineerVisit.EngineerVisitID, JobID)

                Return oEngineerVisit
            End Function

            Public Function EngineerVisits_UpdateStatus(ByVal engineerVisitID As Integer, ByVal statusEnumID As Integer,
                                                        ByVal outcomeEnumID As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", engineerVisitID, True)
                _database.AddParameter("@VisitStatusID", statusEnumID, True)
                _database.AddParameter("@OutcomeID", outcomeEnumID, True)

                Return CBool(_database.ExecuteSP_ReturnRowsAffected("EngineerVisits_UpdateStatus") = 1)
            End Function

            Public Function EngineerVisit_ManualUpload(ByVal engineerVisit As EngineerVisit) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", engineerVisit.EngineerVisitID, True)
                _database.AddParameter("@StatusEnumID", engineerVisit.StatusEnumID, True)
                _database.AddParameter("@OutcomeEnumID", engineerVisit.OutcomeEnumID, True)
                _database.AddParameter("@NotesFromEngineer", engineerVisit.NotesFromEngineer, True)

                Return CBool(_database.ExecuteSP_ReturnRowsAffected("EngineerVisit_ManualUpload") = 1)
            End Function

            Public Function Update(ByVal oEngineerVisit As EngineerVisit, ByVal JobID As Integer, ByVal justStatus As Boolean) As EngineerVisit

                _database.ClearParameter()
                _database.AddParameter("@StatusEnumID", oEngineerVisit.StatusEnumID, True)
                _database.AddParameter("@NotesToEngineer", oEngineerVisit.NotesToEngineer, True)
                _database.AddParameter("@EngineerVisitID", oEngineerVisit.EngineerVisitID, True)
                _database.AddParameter("@PartsToFit", oEngineerVisit.PartsToFit, True)
                _database.AddParameter("@ExpectedEngineerID", oEngineerVisit.ExpectedEngineerID, True)
                _database.AddParameter("@Recharge", oEngineerVisit.Recharge, True)
                _database.AddParameter("@RechargeType", oEngineerVisit.RechargeTypeID, True)
                _database.AddParameter("@NccRadID", oEngineerVisit.NccRadID, True)
                _database.AddParameter("@MeterCappedID", oEngineerVisit.MeterCappedID, True)
                _database.AddParameter("@MeterLocationID", oEngineerVisit.MeterLocationID, True)
                _database.AddParameter("@VisitLocked", oEngineerVisit.VisitLocked, True)
                _database.AddParameter("@ExcludeFromTextMessage", oEngineerVisit.ExcludeFromTextMessage, True)

                _database.AddParameter("@EngineerID", oEngineerVisit.EngineerID, True)

                If Not oEngineerVisit.StartDateTime = System.DateTime.MinValue Or Not oEngineerVisit.StartDateTime = Nothing Then
                    _database.AddParameter("@StartDateTime", oEngineerVisit.StartDateTime, True)
                Else
                    _database.AddParameter("@StartDateTime", DBNull.Value, True)
                End If
                If Not oEngineerVisit.EndDateTime = System.DateTime.MinValue Or Not oEngineerVisit.EndDateTime = Nothing Then
                    _database.AddParameter("@EndDateTime", oEngineerVisit.EndDateTime, True)
                Else
                    _database.AddParameter("@EndDateTime", DBNull.Value, True)
                End If

                _database.AddParameter("@ExpectedDepartment", oEngineerVisit.ExpectedDepartment)
                _database.AddParameter("@FuelID", oEngineerVisit.FuelID)

                If Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("EngineerVisit_Update")) = True Then
                    ' Status Changed enter Job Audit
                    Dim jA As New JobAudits.JobAudit
                    jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID
                    jA.SetActionChange = "Visit Status changed to " & Replace(CType(oEngineerVisit.StatusEnumID, Enums.VisitStatus).ToString, "_", " ") &
                        " (Unique Visit ID: " & oEngineerVisit.EngineerVisitID & ")"
                    DB.JobAudit.Insert(jA)

                End If

                Dim msgStr As String = ""

                If justStatus = False Then
                    For Each row As DataRow In oEngineerVisit.PartsAndProductsAllocated.Table.Rows
                        'If IsDBNull(row.Item("ID")) OrElse row.Item("ID") = 0 Then
                        If row.Item("OrderItemID") = 0 Then
                            msgStr += " * " & row.Item("Name") & ", " & row.Item("Number") & ", " & row.Item("Quantity") & vbCrLf
                        End If

                        'End If
                    Next

                    Dim dtOrder As New DataTable
                    dtOrder = oEngineerVisit.PartsAndProductsAllocated.Table.Clone

                    For Each rowOrder As DataRow In oEngineerVisit.PartsAndProductsAllocated.Table.Select("OrderItemID = 0 OR  QuantityOrdered  < Quantity ")
                        dtOrder.Rows.Add(rowOrder.ItemArray)
                    Next

                    'DO THEY WANT TO ORDER NOW?
                    If msgStr.Length > 0 Then
                        If MessageBox.Show("The following Parts/Products have been allocated to a visit and have not been ordered: " & vbCrLf &
                                        msgStr & vbCrLf & " Would you like to create an order now?", "Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                            ShowForm(GetType(FRMConvertToAnOrder), True, New Object() {CInt(Enums.OrderType.Job), JobID, New DataView(dtOrder), 0, oEngineerVisit.EngineerVisitID})

                            For Each rowAllocated2 As DataRow In dtOrder.Rows

                                rowAllocated2.AcceptChanges()
                                If IsDBNull(rowAllocated2.Item("Quantity")) Then
                                    rowAllocated2.Item("Quantity") = rowAllocated2.Item("QuantityToOrder")
                                End If

                                DB.EngineerVisitPartProductAllocated.UpdateOne(rowAllocated2("ID"), oEngineerVisit.EngineerVisitID, rowAllocated2.Item("Type"), rowAllocated2.Item("Quantity"),
                                     rowAllocated2.Item("OrderItemID"), rowAllocated2.Item("PartProductID"),
                                     Helper.MakeIntegerValid(rowAllocated2.Item("OrderLocationTypeID")))

                            Next

                        End If
                    End If

                    'For Each rowAllocated As DataRow In oEngineerVisit.PartsAndProductsAllocated.Table.Select("(ID IS NULL OR ID = 0) AND OrderItemID > 0")
                    For Each rowallocated As DataRow In dtOrder.Select("ID IS NULL OR ID = 0")
                        DB.EngineerVisitPartProductAllocated.InsertOne(oEngineerVisit.EngineerVisitID, rowallocated.Item("Type"), rowallocated.Item("Quantity"),
                                                                      rowallocated.Item("OrderItemID"), rowallocated.Item("PartProductID"), Helper.MakeIntegerValid(rowallocated.Item("OrderLocationTypeID")))
                    Next
                    '  Next

                End If

                Return oEngineerVisit

            End Function

            Public Function Update(ByVal oEngineerVisit As EngineerVisit, ByVal JobID As Integer, ByVal justStatus As Boolean, ByVal trans As SqlClient.SqlTransaction) As EngineerVisit

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisit_Update"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@StatusEnumID", oEngineerVisit.StatusEnumID)
                Command.Parameters.AddWithValue("@NotesToEngineer", oEngineerVisit.NotesToEngineer)

                Command.Parameters.AddWithValue("@EngineerVisitID", oEngineerVisit.EngineerVisitID)
                Command.Parameters.AddWithValue("@PartsToFit", oEngineerVisit.PartsToFit)
                Command.Parameters.AddWithValue("@ExpectedEngineerID", oEngineerVisit.ExpectedEngineerID)
                Command.Parameters.AddWithValue("@Recharge", oEngineerVisit.Recharge)
                Command.Parameters.AddWithValue("@RechargeType", oEngineerVisit.RechargeTypeID)
                Command.Parameters.AddWithValue("@NccRadID", oEngineerVisit.NccRadID)
                Command.Parameters.AddWithValue("@MeterCappedID", oEngineerVisit.MeterCappedID)
                Command.Parameters.AddWithValue("@MeterLocationID", oEngineerVisit.MeterLocationID)
                Command.Parameters.AddWithValue("@ExpectedDepartment", oEngineerVisit.MeterLocationID)
                Command.Parameters.AddWithValue("@FuelID", oEngineerVisit.FuelID)
                Command.Parameters.AddWithValue("@ExcludeFromTextMessage ", oEngineerVisit.ExcludeFromTextMessage)

                If Helper.MakeBooleanValid(Command.ExecuteScalar) = True Then
                    ' Status Changed enter Job Audit
                    Dim jA As New JobAudits.JobAudit
                    jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID
                    jA.SetActionChange = "Visit Status changed to " & Replace(CType(oEngineerVisit.StatusEnumID, Enums.VisitStatus).ToString, "_", " ") &
                        " (Unique Visit ID: " & oEngineerVisit.EngineerVisitID & ")"
                    DB.JobAudit.Insert(jA, trans)

                End If

                If Not oEngineerVisit.PartsAndProductsAllocated.Table Is Nothing Then
                    For Each rowAllocated As DataRow In oEngineerVisit.PartsAndProductsAllocated.Table.Rows
                        If Helper.MakeIntegerValid(rowAllocated.Item("ID")) = 0 Then
                            DB.EngineerVisitPartProductAllocated.InsertOne(oEngineerVisit.EngineerVisitID, rowAllocated.Item("Type"), rowAllocated.Item("Quantity"),
                                                                      Helper.MakeIntegerValid(rowAllocated.Item("OrderItemID")), rowAllocated.Item("PartProductID"), Helper.MakeIntegerValid(rowAllocated.Item("OrderLocationTypeID")), trans)
                        End If
                    Next
                End If

                oEngineerVisit.PartsAndProductsAllocated = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(oEngineerVisit.EngineerVisitID, trans)

                If oEngineerVisit.Change = True Then

                    'add audit
                    Dim jA As New JobAudits.JobAudit
                    jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID, trans).JobID
                    jA.SetActionChange = "Engineer Notes have been altered " &
                            " (Unique Visit ID: " & oEngineerVisit.EngineerVisitID & ")"

                    DB.JobAudit.Insert(jA)

                End If

                Return oEngineerVisit

            End Function

            Public Function EngineerVisits_Get_All_JobID(ByVal jobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@jobID", jobID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_All_JobID")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Get_All_JobNumber_Light(ByVal jobNumber As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobNumber", jobNumber, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_All_JobNumber_Light")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Get_All_JobID(ByVal jobID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisits_Get_All_JobID"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New SqlClient.SqlParameter("@jobID", jobID))

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)

            End Function

            Public Function EngineerVisits_Get(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Get_ForVal(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_ForVal")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitSymptom_GetForVisit(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitSymptom_GetForVisit")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Get(ByVal EngineerVisitID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisits_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New SqlClient.SqlParameter("@EngineerVisitID", EngineerVisitID))

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)

            End Function

            Public Function EngineerVisit_GetUpdate(ByVal Where As Integer) As DataView

                _database.ClearParameter()
                _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)
                _database.AddParameter("@InvoicedIDEnum", Enums.VisitStatus.Invoiced, True)
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Enums.VisitStatus.Ready_To_Be_Invoiced, True)
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Enums.VisitStatus.Not_To_Be_Invoiced, True)
                _database.AddParameter("@Where", Where, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_GetUpdate")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)

            End Function

            Public Function EngineerVisits_Get_All(ByVal Where As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)
                _database.AddParameter("@InvoicedIDEnum", Enums.VisitStatus.Invoiced, True)
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Enums.VisitStatus.Ready_To_Be_Invoiced, True)
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Enums.VisitStatus.Not_To_Be_Invoiced, True)
                _database.AddParameter("@Where", Where, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_All")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Manager_Get_ByWhere(ByVal Where As String,
                                                               Optional ByVal addtionalWhere As String = "") As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)
                _database.AddParameter("@InvoicedIDEnum", Enums.VisitStatus.Invoiced, True)
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Enums.VisitStatus.Ready_To_Be_Invoiced, True)
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Enums.VisitStatus.Not_To_Be_Invoiced, True)
                _database.AddParameter("@Where", Where, True)
                _database.AddParameter("@Where2", addtionalWhere, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Manager_Get_ByWhere")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)
            End Function

            Public Function EngineerPerformance_Get(ByVal Dept As Integer, ByVal EngineerID As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal performanceType As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Dept", Dept, True)
                _database.AddParameter("@EngineerID", EngineerID, True)
                _database.AddParameter("@StartDate", StartDate, True)
                _database.AddParameter("@EndDate", EndDate, True)
                _database.AddParameter("@PerType", performanceType, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Engineer_Get_Performance")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Appliances_GetAll() As DataView
                _database.ClearParameter()

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Appliances_GetAll")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_VisitManager_New(ByVal CustomerID As Integer, ByVal SiteID As Integer,
                                   ByVal EngineerID As Integer, ByVal JobDefinitionEnumID As Integer,
                                   ByVal JobTypeID As Integer, ByVal VisitEnumID As Integer,
                                   ByVal OutcomeEnumID As Integer, ByVal JobNumber As String,
                                   ByVal PONumber As String, ByVal Postcode As String,
                                   ByVal DateFrom As DateTime?, ByVal DateTo As DateTime?,
                                   ByVal RegionID As Integer, ByVal ContractTypeID As Integer, ByVal LetterType As String,
                                    ByVal DueDateFrom As DateTime?, ByVal DueDateTo As DateTime?, ByVal ChargeInProgress As Integer, ByVal CostsTo As String) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@totalRowCount", 0, True)
                _database.AddParameter("@sortBy", "1", True)
                _database.AddParameter("@InvoiceTypeIDEnum", CInt(Enums.InvoiceType.Visit), True)
                _database.AddParameter("@InvoicedIDEnum", CInt(Enums.VisitStatus.Invoiced), True)
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", CInt(Enums.VisitStatus.Ready_To_Be_Invoiced), True)
                _database.AddParameter("@NoNeedForInvoiceIDEnum", CInt(Enums.VisitStatus.Not_To_Be_Invoiced), True)
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@SiteID", SiteID, True)
                _database.AddParameter("@EngineerID", EngineerID, True)
                _database.AddParameter("@JobDefinitionEnumID", JobDefinitionEnumID, True)
                _database.AddParameter("@JobTypeID", JobTypeID, True)
                _database.AddParameter("@VisitEnumID", VisitEnumID, True)
                _database.AddParameter("@OutcomeEnumID", OutcomeEnumID, True)
                _database.AddParameter("@JobNumber", JobNumber, True)
                _database.AddParameter("@PONumber", PONumber, True)
                _database.AddParameter("@Postcode", Postcode, True)
                _database.AddParameter("@DateFrom", DateFrom, True)
                _database.AddParameter("@DateTo", DateTo, True)
                _database.AddParameter("@RegionID", RegionID, True)
                _database.AddParameter("@ContractTypeID", ContractTypeID, True)
                _database.AddParameter("@LetterType", LetterType, True)
                _database.AddParameter("@DueDateFrom", DueDateFrom, True)
                _database.AddParameter("@DueDateTo", DueDateTo, True)
                _database.AddParameter("@ChargeInProgress", ChargeInProgress, True)
                _database.AddParameter("@CostsTo", CostsTo, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Manager_Search_NEW")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return dt
            End Function

            Public Function EngineerVisits_Get_All_ForSite(ByVal Where As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, True)
                _database.AddParameter("@InvoicedIDEnum", Enums.VisitStatus.Invoiced, True)
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", Enums.VisitStatus.Ready_To_Be_Invoiced, True)
                _database.AddParameter("@NoNeedForInvoiceIDEnum", Enums.VisitStatus.Not_To_Be_Invoiced, True)
                _database.AddParameter("@Where", Where, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_All_ForSite")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Get_AllReady_ForSite(ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_AllReady_ForSite")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString

                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Search(ByVal Criteria As String, Optional ByVal HideCompleted As Boolean = False) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", Criteria, True)

                If HideCompleted Then
                    _database.AddParameter("@MaximumStatusID", CInt(Enums.VisitStatus.Downloaded), True)
                Else
                    _database.AddParameter("@MaximumStatusID", CInt(Enums.VisitStatus.Uploaded), True)
                End If

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Search")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Get_For_Job_Of_Work(ByVal JobOfWorkID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisits_Get_For_Job_Of_Work"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@JobOfWorkID", JobOfWorkID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)

            End Function

            Public Function EngineerVisits_Get_For_Job_Of_Work(ByVal JobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_For_Job_Of_Work")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Get_For_Job_Of_Work_Light(ByVal JobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_For_Job_Of_Work_Light")
                dt.TableName = Enums.TableNames.tblEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisits_Get_As_Object(ByVal EngineerVisitID As Integer, Optional getFull As Boolean = True) As EngineerVisit
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get")

                If dt.Rows.Count > 0 Then
                    With dt.Rows(0)
                        Dim visit As New EngineerVisit
                        visit.IgnoreExceptionsOnSetMethods = True
                        visit.Exists = True
                        visit.SetEngineerVisitID = .Item("EngineerVisitID")
                        visit.SetJobOfWorkID = .Item("JobOfWorkID")
                        visit.SetEngineerID = .Item("EngineerID")
                        visit.StartDateTime = Helper.MakeDateTimeValid(.Item("StartDateTime"))
                        visit.EndDateTime = Helper.MakeDateTimeValid(.Item("EndDateTime"))
                        visit.SetStatusEnumID = .Item("StatusEnumID")
                        visit.SetVisitStatus = .Item("VisitStatus")
                        visit.SetNotesToEngineer = .Item("NotesToEngineer")
                        visit.SetNotesFromEngineer = .Item("NotesFromEngineer")
                        visit.SetOutcomeEnumID = .Item("OutcomeEnumID")
                        visit.SetOutcomeDetails = .Item("OutcomeDetails")
                        visit.SetCustomerName = .Item("CustomerName")
                        visit.SetVisitOutcome = .Item("VisitOutcome")
                        If Not IsDBNull(.Item("CustomerSignature")) Then
                            visit.CustomerSignature = .Item("CustomerSignature")
                        End If

                        If Not IsDBNull(.Item("EngineerSignature")) Then
                            visit.EngineerSignature = .Item("EngineerSignature")
                        End If

                        If IsDBNull(.Item("Downloading")) Then
                            visit.Downloading = DateTime.MinValue
                        Else
                            visit.Downloading = .Item("Downloading")
                        End If

                        visit.SetManualEntryByUserID = .Item("ManualEntryByUserID")
                        visit.ManualEntryOn = Helper.MakeDateTimeValid(.Item("ManualEntryOn"))
                        visit.SetVisitLocked = .Item("VisitLocked")
                        visit.SetDeleted = .Item("Deleted")
                        visit.SetGasInstallationTightnessTestID = .Item("GasInstallationTightnessTestID")
                        visit.SetEmergencyControlAccessibleID = .Item("EmergencyControlAccessibleID")
                        visit.SetBondingID = .Item("BondingID")
                        visit.SetExpectedEngineerID = .Item("ExpectedEngineerID")
                        visit.SetPropertyRented = .Item("PropertyRented")
                        visit.SetPaymentMethodID = .Item("PaymentMethodID")
                        visit.SetAmountCollected = .Item("AmountCollected")
                        visit.SetSignatureSelectedID = .Item("SignatureSelectedID")
                        visit.SetPartsToFit = .Item("PartsToFit")
                        visit.SetGasServiceCompleted = .Item("GasServiceCompleted")
                        visit.SetEmailReceipt = Helper.MakeBooleanValid(.Item("EmailReceipt"))
                        visit.DueDate = Helper.MakeDateTimeValid(.Item("DueDate"))
                        visit.SetAMPM = .Item("AMPM")
                        visit.SetVisitNumber = .Item("VisitNumber")
                        visit.SetRecharge = Helper.MakeBooleanValid(.Item("Recharge"))
                        visit.SetCostsTo = .Item("CostsTo")
                        visit.EstimatedDate = .Item("EstimatedVisitDate")
                        visit.setRechargeTypeID = .Item("RechargeType")
                        visit.setNccRadID = .Item("NccRadID")
                        visit.SetUseSORDescription = Helper.MakeBooleanValid(.Item("UseSORDescription"))
                        visit.SetMeterCappedID = .Item("MeterCappedID")
                        visit.SetMeterLocationID = .Item("MeterLocationID")
                        If .Table.Columns.Contains("FuelID") Then visit.SetFuelID = .Item("FuelID")
                        If .Table.Columns.Contains("ExcludeFromTextMessage") Then visit.SetExcludeFromTextMessage = .Item("ExcludeFromTextMessage")

                        If getFull Then
                            visit.PartsAndProductsUsed = DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(EngineerVisitID)
                            visit.TimeSheets = DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID)
                            visit.PartsAndProductsAllocated = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID)
                            visit.EngineerVisitNCCGSR = DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(visit.EngineerVisitID)
                            visit.Photos = DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisitID)
                        End If

                        Return visit
                    End With
                Else
                    Return Nothing
                End If
            End Function

            Public Function EngineerVisits_Get_New_As_Object(ByVal EngineerVisitID As Integer) As EngineerVisit
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_New")

                If dt.Rows.Count > 0 Then
                    With dt.Rows(0)
                        Dim visit As New EngineerVisit
                        visit.IgnoreExceptionsOnSetMethods = True
                        visit.Exists = True
                        visit.SetEngineerVisitID = .Item("EngineerVisitID")
                        visit.SetJobOfWorkID = .Item("JobOfWorkID")
                        visit.SetEngineerID = .Item("EngineerID")
                        visit.StartDateTime = Helper.MakeDateTimeValid(.Item("StartDateTime"))
                        visit.EndDateTime = Helper.MakeDateTimeValid(.Item("EndDateTime"))
                        visit.SetStatusEnumID = .Item("StatusEnumID")
                        visit.SetVisitStatus = .Item("VisitStatus")
                        visit.SetNotesToEngineer = .Item("NotesToEngineer")
                        visit.SetNotesFromEngineer = .Item("NotesFromEngineer")
                        visit.SetOutcomeEnumID = .Item("OutcomeEnumID")
                        visit.SetOutcomeDetails = .Item("OutcomeDetails")
                        visit.SetCustomerName = .Item("CustomerName")
                        visit.SetVisitOutcome = .Item("VisitOutcome")
                        If Not IsDBNull(.Item("CustomerSignature")) Then
                            visit.CustomerSignature = .Item("CustomerSignature")
                        End If

                        If Not IsDBNull(.Item("EngineerSignature")) Then
                            visit.EngineerSignature = .Item("EngineerSignature")
                        End If

                        If IsDBNull(.Item("Downloading")) Then
                            visit.Downloading = DateTime.MinValue
                        Else
                            visit.Downloading = .Item("Downloading")
                        End If

                        visit.SetManualEntryByUserID = .Item("ManualEntryByUserID")
                        visit.ManualEntryOn = Helper.MakeDateTimeValid(.Item("ManualEntryOn"))
                        visit.SetVisitLocked = .Item("VisitLocked")
                        visit.SetDeleted = .Item("Deleted")
                        visit.SetGasInstallationTightnessTestID = .Item("GasInstallationTightnessTestID")
                        visit.SetEmergencyControlAccessibleID = .Item("EmergencyControlAccessibleID")
                        visit.SetBondingID = .Item("BondingID")
                        visit.SetExpectedEngineerID = .Item("ExpectedEngineerID")
                        visit.SetPropertyRented = .Item("PropertyRented")
                        visit.SetPaymentMethodID = .Item("PaymentMethodID")
                        visit.SetAmountCollected = .Item("AmountCollected")
                        visit.SetSignatureSelectedID = .Item("SignatureSelectedID")
                        visit.SetPartsToFit = .Item("PartsToFit")
                        visit.SetGasServiceCompleted = .Item("GasServiceCompleted")
                        visit.SetEmailReceipt = Helper.MakeBooleanValid(.Item("EmailReceipt"))
                        visit.DueDate = Helper.MakeDateTimeValid(.Item("DueDate"))
                        visit.SetAMPM = .Item("AMPM")
                        visit.SetVisitNumber = .Item("VisitNumber")
                        visit.SetRecharge = Helper.MakeBooleanValid(.Item("Recharge"))
                        visit.SetCostsTo = .Item("CostsTo")
                        visit.EstimatedDate = .Item("EstimatedVisitDate")

                        visit.PartsAndProductsUsed = DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(EngineerVisitID)
                        visit.TimeSheets = DB.EngineerVisitsTimeSheet.EngineerVisitTimeSheet_Get_For_EngineerVisitID(EngineerVisitID)
                        visit.PartsAndProductsAllocated = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID)
                        visit.EngineerVisitNCCGSR = DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(visit.EngineerVisitID)

                        visit.setRechargeTypeID = .Item("RechargeType")
                        visit.setNccRadID = .Item("NccRadID")
                        visit.SetUseSORDescription = Helper.MakeBooleanValid(.Item("UseSORDescription"))
                        visit.SetMeterCappedID = .Item("MeterCappedID")
                        visit.SetMeterLocationID = .Item("MeterLocationID")
                        visit.SetExpectedDepartment = .Item("ExpectedDepartment")
                        If .Table.Columns.Contains("FuelID") Then visit.SetFuelID = .Item("FuelID")

                        Return visit
                    End With
                Else
                    Return Nothing
                End If

            End Function

            Public Function EngineerVisits_Get_LastForJob_Light(ByVal jobID As Integer) As EngineerVisit
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobID_Light")

                If dt.Rows.Count > 0 Then
                    With dt.Rows(0)
                        Dim visit As New EngineerVisit
                        visit.IgnoreExceptionsOnSetMethods = True
                        visit.Exists = True
                        visit.SetEngineerVisitID = .Item("EngineerVisitID")
                        visit.SetJobOfWorkID = .Item("JobOfWorkID")
                        visit.SetEngineerID = .Item("EngineerID")
                        visit.StartDateTime = Helper.MakeDateTimeValid(.Item("StartDateTime"))
                        visit.EndDateTime = Helper.MakeDateTimeValid(.Item("EndDateTime"))
                        visit.SetStatusEnumID = .Item("StatusEnumID")
                        visit.SetNotesToEngineer = .Item("NotesToEngineer")
                        visit.SetNotesFromEngineer = .Item("NotesFromEngineer")
                        visit.SetOutcomeEnumID = .Item("OutcomeEnumID")
                        visit.SetOutcomeDetails = .Item("OutcomeDetails")
                        visit.SetCustomerName = .Item("CustomerName")
                        visit.SetVisitOutcome = .Item("VisitOutcome")
                        visit.SetDeleted = .Item("Deleted")
                        Return visit
                    End With
                Else
                    Return Nothing
                End If
            End Function

            Public Function EngineerVisits_Get_As_Object(ByVal EngineerVisitID As Integer, ByVal trans As SqlClient.SqlTransaction) As EngineerVisit

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "EngineerVisits_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@EngineerVisitID", EngineerVisitID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If dt.Rows.Count > 0 Then
                    With dt.Rows(0)
                        Dim visit As New EngineerVisit
                        visit.IgnoreExceptionsOnSetMethods = True
                        visit.Exists = True
                        visit.SetEngineerVisitID = .Item("EngineerVisitID")
                        visit.SetJobOfWorkID = .Item("JobOfWorkID")
                        visit.SetEngineerID = .Item("EngineerID")
                        visit.StartDateTime = Helper.MakeDateTimeValid(.Item("StartDateTime"))
                        visit.EndDateTime = Helper.MakeDateTimeValid(.Item("EndDateTime"))
                        visit.SetStatusEnumID = .Item("StatusEnumID")
                        visit.SetNotesToEngineer = .Item("NotesToEngineer")
                        visit.SetNotesFromEngineer = .Item("NotesFromEngineer")
                        visit.SetOutcomeEnumID = .Item("OutcomeEnumID")
                        visit.SetOutcomeDetails = .Item("OutcomeDetails")
                        visit.SetCustomerName = .Item("CustomerName")
                        visit.SetVisitOutcome = .Item("VisitOutcome")
                        If Not IsDBNull(.Item("CustomerSignature")) Then
                            visit.CustomerSignature = .Item("CustomerSignature")
                        End If

                        If Not IsDBNull(.Item("EngineerSignature")) Then
                            visit.EngineerSignature = .Item("EngineerSignature")
                        End If

                        If IsDBNull(.Item("Downloading")) Then
                            visit.Downloading = DateTime.MinValue
                        Else
                            visit.Downloading = .Item("Downloading")
                        End If

                        visit.SetManualEntryByUserID = .Item("ManualEntryByUserID")
                        visit.ManualEntryOn = Helper.MakeDateTimeValid(.Item("ManualEntryOn"))
                        visit.SetVisitLocked = .Item("VisitLocked")
                        visit.SetDeleted = .Item("Deleted")
                        visit.SetGasInstallationTightnessTestID = .Item("GasInstallationTightnessTestID")
                        visit.SetEmergencyControlAccessibleID = .Item("EmergencyControlAccessibleID")
                        visit.SetBondingID = .Item("BondingID")
                        visit.SetExpectedEngineerID = .Item("ExpectedEngineerID")
                        visit.SetPropertyRented = .Item("PropertyRented")
                        visit.SetPaymentMethodID = .Item("PaymentMethodID")
                        visit.SetAmountCollected = .Item("AmountCollected")
                        visit.SetSignatureSelectedID = .Item("SignatureSelectedID")
                        visit.SetPartsToFit = .Item("PartsToFit")
                        visit.SetGasServiceCompleted = .Item("GasServiceCompleted")
                        visit.SetEmailReceipt = Helper.MakeBooleanValid(.Item("EmailReceipt"))
                        visit.SetRecharge = Helper.MakeBooleanValid(.Item("Recharge"))
                        visit.EngineerVisitNCCGSR = DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(visit.EngineerVisitID)
                        'SMOKE
                        '   visit.EngineerVisitSMOKE = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(visit.EngineerVisitID, 68649)
                        'COMO
                        '     visit.EngineerVisitCOMO = DB.EngineerVisitAdditional.EngineerVisitAdditional_GetForEngineerVisit(visit.EngineerVisitID, 68650)
                        visit.EstimatedDate = .Item("EstimatedVisitDate")
                        visit.Photos = DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisitID)
                        visit.setRechargeTypeID = .Item("RechargeType")
                        visit.setNccRadID = .Item("NccRadID")

                        visit.SetMeterCappedID = .Item("MeterCappedID")
                        visit.SetMeterLocationID = .Item("MeterLocationID")
                        visit.SetExpectedDepartment = .Item("ExpectedDepartment")
                        If .Table.Columns.Contains("FuelID") Then visit.SetFuelID = .Item("FuelID")
                        Return visit
                    End With
                Else
                    Return Nothing
                End If
            End Function

            Public Function EngineerVisits_Get_For_Job_Of_Work_As_Objects(ByVal JobOfWorkID As Integer) As ArrayList
                Dim engineerVisits As New ArrayList
                For Each row As DataRow In EngineerVisits_Get_For_Job_Of_Work(JobOfWorkID).Table.Rows
                    Dim visit As New EngineerVisit
                    visit.IgnoreExceptionsOnSetMethods = True
                    visit.Exists = True
                    visit.SetEngineerVisitID = row.Item("EngineerVisitID")
                    visit.SetJobOfWorkID = row.Item("JobOfWorkID")
                    visit.SetEngineerID = row.Item("EngineerID")
                    visit.StartDateTime = Helper.MakeDateTimeValid(row.Item("StartDateTime"))
                    visit.EndDateTime = Helper.MakeDateTimeValid(row.Item("EndDateTime"))
                    visit.SetStatusEnumID = row.Item("StatusEnumID")
                    visit.SetNotesToEngineer = row.Item("NotesToEngineer")
                    visit.SetNotesFromEngineer = row.Item("NotesFromEngineer")
                    visit.SetOutcomeEnumID = row.Item("OutcomeEnumID")
                    visit.SetOutcomeDetails = row.Item("OutcomeDetails")
                    visit.SetCustomerName = row.Item("CustomerName")

                    If IsDBNull(row.Item("Downloading")) Then
                        visit.Downloading = DateTime.MinValue
                    Else
                        visit.Downloading = row.Item("Downloading")
                    End If

                    visit.SetManualEntryByUserID = row.Item("ManualEntryByUserID")
                    visit.ManualEntryOn = Helper.MakeDateTimeValid(row.Item("ManualEntryOn"))
                    visit.SetVisitLocked = row.Item("VisitLocked")
                    visit.SetDeleted = row.Item("Deleted")
                    visit.SetGasInstallationTightnessTestID = row.Item("GasInstallationTightnessTestID")
                    visit.SetEmergencyControlAccessibleID = row.Item("EmergencyControlAccessibleID")
                    visit.SetPaymentMethodID = row.Item("PaymentMethodID")
                    visit.SetAmountCollected = row.Item("AmountCollected")
                    visit.SetBondingID = row.Item("BondingID")
                    visit.SetExpectedEngineerID = row.Item("ExpectedEngineerID")
                    visit.SetPropertyRented = row.Item("PropertyRented")
                    visit.SetSignatureSelectedID = row.Item("SignatureSelectedID")
                    visit.SetPartsToFit = row.Item("PartsToFit")
                    visit.SetGasServiceCompleted = row.Item("GasServiceCompleted")
                    visit.SetEmailReceipt = Helper.MakeBooleanValid(row.Item("EmailReceipt"))
                    visit.SetRecharge = Helper.MakeBooleanValid(row.Item("Recharge"))
                    visit.PartsAndProductsAllocated = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID)
                    visit.EngineerVisitNCCGSR = DB.EngineerVisitNCCGSR.EngineerVisitNCCGSR_GetForEngineerVisit(visit.EngineerVisitID)
                    visit.EstimatedDate = row.Item("EstimatedVisitDate")
                    visit.setRechargeTypeID = row.Item("RechargeType")
                    visit.setNccRadID = row.Item("NccRadID")
                    visit.SetVisitNumber = row.Item("VisitNumber")
                    visit.SetUseSORDescription = Helper.MakeBooleanValid(row.Item("UseSORDescription"))
                    visit.SetMeterCappedID = row.Item("MeterCappedID")
                    visit.SetMeterLocationID = row.Item("MeterLocationID")
                    visit.SetExpectedDepartment = row.Item("ExpectedDepartment")
                    If row.Table.Columns.Contains("FuelID") Then visit.SetFuelID = row.Item("FuelID")

                    engineerVisits.Add(visit)
                Next

                Return engineerVisits
            End Function

            Public Function EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(ByVal JobOfWorkID As Integer) As ArrayList
                Dim engineerVisits As New ArrayList
                For Each row As DataRow In EngineerVisits_Get_For_Job_Of_Work_Light(JobOfWorkID).Table.Rows
                    Dim visit As New EngineerVisit
                    visit.IgnoreExceptionsOnSetMethods = True
                    visit.Exists = True
                    visit.SetEngineerVisitID = row.Item("EngineerVisitID")
                    visit.SetJobOfWorkID = row.Item("JobOfWorkID")
                    visit.SetEngineerID = row.Item("EngineerID")
                    visit.StartDateTime = Helper.MakeDateTimeValid(row.Item("StartDateTime"))
                    visit.EndDateTime = Helper.MakeDateTimeValid(row.Item("EndDateTime"))
                    visit.SetStatusEnumID = row.Item("StatusEnumID")
                    visit.SetNotesToEngineer = row.Item("NotesToEngineer")
                    visit.SetNotesFromEngineer = row.Item("NotesFromEngineer")
                    visit.SetOutcomeEnumID = row.Item("OutcomeEnumID")
                    visit.SetOutcomeDetails = row.Item("OutcomeDetails")
                    visit.SetCustomerName = row.Item("CustomerName")
                    visit.SetAMPM = row.Item("AMPM")
                    visit.SetRecharge = Helper.MakeBooleanValid(row.Item("Recharge"))
                    visit.SetManualEntryByUserID = row.Item("ManualEntryByUserID")
                    visit.ManualEntryOn = Helper.MakeDateTimeValid(row.Item("ManualEntryOn"))
                    visit.SetDeleted = row.Item("Deleted")
                    visit.SetExpectedEngineerID = row.Item("ExpectedEngineerID")
                    visit.SetPartsToFit = row.Item("PartsToFit")
                    visit.PartsAndProductsAllocated = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID)
                    visit.EstimatedDate = row.Item("EstimatedVisitDate")
                    visit.SetVisitNumber = row.Item("VisitNumber")
                    If row.Table.Columns.Contains("FuelID") Then visit.SetFuelID = row.Item("FuelID")

                    engineerVisits.Add(visit)
                Next

                Return engineerVisits
            End Function

            Public Function EngineerVisits_Get_For_Job_Of_Work_As_Objects(ByVal JobOfWorkID As Integer, ByVal trans As SqlClient.SqlTransaction) As ArrayList
                Dim engineerVisits As New ArrayList
                For Each row As DataRow In EngineerVisits_Get_For_Job_Of_Work(JobOfWorkID, trans).Table.Rows
                    Dim visit As New EngineerVisit
                    visit.IgnoreExceptionsOnSetMethods = True
                    visit.Exists = True
                    visit.SetEngineerVisitID = row.Item("EngineerVisitID")
                    visit.SetJobOfWorkID = row.Item("JobOfWorkID")
                    visit.SetEngineerID = row.Item("EngineerID")
                    visit.StartDateTime = Helper.MakeDateTimeValid(row.Item("StartDateTime"))
                    visit.EndDateTime = Helper.MakeDateTimeValid(row.Item("EndDateTime"))
                    visit.SetStatusEnumID = row.Item("StatusEnumID")
                    visit.SetNotesToEngineer = row.Item("NotesToEngineer")
                    visit.SetNotesFromEngineer = row.Item("NotesFromEngineer")
                    visit.SetOutcomeEnumID = row.Item("OutcomeEnumID")
                    visit.SetOutcomeDetails = row.Item("OutcomeDetails")
                    visit.SetCustomerName = row.Item("CustomerName")

                    If Not IsDBNull(row.Item("CustomerSignature")) Then
                        visit.CustomerSignature = row.Item("CustomerSignature")
                    End If

                    If Not IsDBNull(row.Item("EngineerSignature")) Then
                        visit.EngineerSignature = row.Item("EngineerSignature")
                    End If

                    If IsDBNull(row.Item("Downloading")) Then
                        visit.Downloading = DateTime.MinValue
                    Else
                        visit.Downloading = row.Item("Downloading")
                    End If

                    visit.SetManualEntryByUserID = row.Item("ManualEntryByUserID")
                    visit.ManualEntryOn = Helper.MakeDateTimeValid(row.Item("ManualEntryOn"))
                    visit.SetVisitLocked = row.Item("VisitLocked")
                    visit.SetDeleted = row.Item("Deleted")
                    visit.SetGasInstallationTightnessTestID = row.Item("GasInstallationTightnessTestID")
                    visit.SetEmergencyControlAccessibleID = row.Item("EmergencyControlAccessibleID")
                    visit.SetPaymentMethodID = row.Item("PaymentMethodID")
                    visit.SetAmountCollected = row.Item("AmountCollected")
                    visit.SetBondingID = row.Item("BondingID")
                    visit.SetExpectedEngineerID = row.Item("ExpectedEngineerID")
                    visit.SetPropertyRented = row.Item("PropertyRented")
                    visit.SetSignatureSelectedID = row.Item("SignatureSelectedID")
                    visit.SetPartsToFit = row.Item("PartsToFit")
                    visit.SetGasServiceCompleted = row.Item("GasServiceCompleted")
                    visit.SetEmailReceipt = Helper.MakeBooleanValid(row.Item("EmailReceipt"))
                    visit.SetRecharge = Helper.MakeBooleanValid(row.Item("Recharge"))
                    visit.PartsAndProductsAllocated = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(visit.EngineerVisitID, trans)
                    visit.EstimatedDate = row.Item("EstimatedVisitDate")
                    visit.setRechargeTypeID = row.Item("RechargeType")
                    visit.setNccRadID = row.Item("NccRadID")
                    visit.SetMeterCappedID = row.Item("MeterCappedID")
                    visit.SetMeterLocationID = row.Item("MeterLocationID")
                    visit.SetExpectedDepartment = row.Item("ExpectedDepartment")
                    If row.Table.Columns.Contains("FuelID") Then visit.SetFuelID = row.Item("FuelID")
                    engineerVisits.Add(visit)
                Next

                Return engineerVisits
            End Function

            Public Function ManuallyComplete(ByVal oEngineerVisit As EngineerVisit, ByVal JobItemsDataview As DataView, ByVal PartsAndProductsDistribution As DataView) As EngineerVisit

                _database.ClearParameter()
                _database.AddParameter("@EngineerID", oEngineerVisit.EngineerID, True)
                _database.AddParameter("@StatusEnumID", CInt(Enums.VisitStatus.Uploaded), True)
                _database.AddParameter("@NotesFromEngineer", oEngineerVisit.NotesFromEngineer, True)
                _database.AddParameter("@OutcomeEnumID", oEngineerVisit.OutcomeEnumID, True)
                _database.AddParameter("@OutcomeDetails", oEngineerVisit.OutcomeDetails, True)
                _database.AddParameter("@CustomerName", oEngineerVisit.CustomerName, True)
                _database.AddParameter("@ManualEntryByUserID", loggedInUser.UserID, True)
                _database.AddParameter("@EngineerVisitID", oEngineerVisit.EngineerVisitID, True)
                _database.AddParameter("@VisitLocked", oEngineerVisit.VisitLocked, True)
                _database.AddParameter("@GasInstallationTightnessTestID", oEngineerVisit.GasInstallationTightnessTestID, True)
                _database.AddParameter("@EmergencyControlAccessibleID", oEngineerVisit.EmergencyControlAccessibleID, True)
                _database.AddParameter("@BondingID", oEngineerVisit.BondingID, True)
                _database.AddParameter("@PropertyRented", oEngineerVisit.PropertyRented, True)
                _database.AddParameter("@SignatureSelectedID", oEngineerVisit.SignatureSelectedID, True)
                _database.AddParameter("@PaymentMethodID", oEngineerVisit.PaymentMethodID, True)
                _database.AddParameter("@AmountCollected", oEngineerVisit.AmountCollected, True)
                _database.AddParameter("@GasServiceCompleted", oEngineerVisit.GasServiceCompleted, True)
                _database.AddParameter("@EmailReceipt", oEngineerVisit.EmailReceipt, True)
                _database.AddParameter("@Recharge", oEngineerVisit.Recharge, True)
                _database.AddParameter("@RechargeType", oEngineerVisit.RechargeTypeID, True)
                _database.AddParameter("@NccRadID", oEngineerVisit.NccRadID, True)
                _database.AddParameter("@MeterCappedID", oEngineerVisit.MeterCappedID, True)
                _database.AddParameter("@MeterLocationID", oEngineerVisit.MeterLocationID, True)
                _database.AddParameter("@CostsTo", oEngineerVisit.CostsTo, True)
                _database.AddParameter("@UseSORDescription", oEngineerVisit.UseSORDescription, True)
                _database.AddParameter("@FuelID", oEngineerVisit.FuelID, True)

                If Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("EngineerVisit_ManuallyComplete_CheckChange")) = True Then
                    ' Status Changed enter Job Audit
                    Dim jA As New JobAudits.JobAudit
                    jA.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID
                    jA.SetActionChange = "Visit Status changed to " & Enums.VisitStatus.Uploaded.ToString &
                                            ", Outcome: " & Replace(CType(oEngineerVisit.OutcomeEnumID, Enums.EngineerVisitOutcomes).ToString, "_", " ") &
                                            ", GasServiceComplete: " & oEngineerVisit.GasServiceCompleted.ToString &
                        " (Unique Visit ID: " & oEngineerVisit.EngineerVisitID & ")"
                    DB.JobAudit.Insert(jA)

                End If

                For Each row As DataRow In oEngineerVisit.PartsAndProductsUsed.Table.Rows

                    Dim oPartOrProduct As New EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProducts

                    If row.Item("Type") = "Part" Then
                        If Helper.MakeIntegerValid(row.Item("UniqueID")) = 0 Then
                            oPartOrProduct.SetEngineerVisitID = oEngineerVisit.EngineerVisitID
                            oPartOrProduct.SetAssetID = 0
                            oPartOrProduct.SetPartOrProductID = row.Item("ID")
                            oPartOrProduct.SetQuantity = row.Item("Quantity")
                            oPartOrProduct.SetAllocatedID = row.Item("AllocatedID")
                            oPartOrProduct.SetSpecialDescription = row.Item("SpecialDescription")
                            oPartOrProduct.SetSpecialPartNumber = row.Item("SpecialPartNumber")
                            oPartOrProduct.SetSpecialPrice = row.Item("SpecialPrice")
                            _database.EngineerVisitsPartsAndProducts.PartsUsed_Insert(oPartOrProduct)
                        Else
                            _database.EngineerVisitsPartsAndProducts.PartsUsed_Update(row.Item("UniqueID"), row.Item("Quantity"))
                        End If
                    Else
                        If Helper.MakeIntegerValid(row.Item("UniqueID")) = 0 Then

                            oPartOrProduct.SetEngineerVisitID = oEngineerVisit.EngineerVisitID
                            oPartOrProduct.SetPartOrProductID = row.Item("ID")
                            oPartOrProduct.SetQuantity = row.Item("Quantity")
                            _database.EngineerVisitsPartsAndProducts.ProductsUsed_Insert(oPartOrProduct)

                            If Helper.MakeIntegerValid(row.Item("UniqueID")) = 0 Then
                                For x As Integer = 0 To CInt(row.Item("Quantity")) - 1
                                    If ShowMessage("Would you like to add Product: '" & row.Item("Name") & "' as an Asset for this Site?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        ShowForm(GetType(FRMAsset), True, New Object() {0, row.Item("ID"), DB.Sites.Get(oEngineerVisit.EngineerVisitID, Sites.SiteSQL.GetBy.EngineerVisitId).SiteID})
                                    End If
                                Next
                            End If
                        Else
                            _database.EngineerVisitsPartsAndProducts.ProductsUsed_Update(row.Item("UniqueID"), row.Item("Quantity"))

                        End If
                    End If
                Next

                AllocatedDistributions(PartsAndProductsDistribution)

                Dim oJob As New Jobs.Job
                oJob = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID)

                'THIS IS TO STOP IT INSERTING EVERY TIME - ALP
                If oEngineerVisit.StatusEnumID < CInt(Enums.VisitStatus.Uploaded) Then
                    If Not DB.Job.Job_WasGeneratedByLetter(oJob.JobID) Then
                        Select Case oEngineerVisit.OutcomeEnumID
                            Case Enums.EngineerVisitOutcomes.Carded
                                If oEngineerVisit.VisitNumber > 0 Then
                                    Exit Select
                                End If
                                Dim newJOW As New JobOfWorks.JobOfWork
                                newJOW.SetJobID = oJob.JobID
                                Dim dt As DataTable = DB.JobOfWorks.JobOfWork_Get_For_Job(newJOW.JobID).Table
                                newJOW.SetPONumber = dt.Rows(dt.Rows.Count - 1).Item("PONumber")
                                newJOW = DB.JobOfWorks.Insert(newJOW)

                                Dim autoNextVisit As New EngineerVisit
                                autoNextVisit.SetJobOfWorkID = newJOW.JobOfWorkID
                                autoNextVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Ready_For_Schedule)
                                autoNextVisit.SetNotesToEngineer = "(REVISIT REASON : " & oEngineerVisit.OutcomeDetails & ".)" & vbCrLf & "PREVIOUS NOTES : " & oEngineerVisit.NotesToEngineer & vbCrLf
                                autoNextVisit.SetPartsToFit = oEngineerVisit.PartsToFit
                                autoNextVisit.DueDate = Nothing
                                autoNextVisit.SetAMPM = ""
                                autoNextVisit.SetFuelID = Helper.MakeIntegerValid(oEngineerVisit.FuelID)
                                'newJOW.EngineerVisits.Add(autoNextVisit)

                                autoNextVisit = [Insert](autoNextVisit, DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID)

                                'SEE ABOVE *
                                Dim movedOrders As DataTable = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_MoveVisit(oEngineerVisit.EngineerVisitID, autoNextVisit.EngineerVisitID)

                                Dim dvVisits As DataView = DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID)

                                Dim visitsComplete As Boolean = True

                                For Each rowVisit As DataRow In dvVisits.Table.Rows
                                    If rowVisit.Item("StatusEnumID") < CInt(Enums.VisitStatus.Uploaded) Then
                                        visitsComplete = False
                                    End If
                                Next

                                If visitsComplete = True Then
                                    DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, CInt(Enums.JobOfWorkStatus.Complete))
                                End If

                            Case Enums.EngineerVisitOutcomes.Declined

                                Dim autoNextVisit As New EngineerVisit
                                autoNextVisit.SetJobOfWorkID = oEngineerVisit.JobOfWorkID
                                autoNextVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Ready_For_Schedule)
                                autoNextVisit.SetNotesToEngineer = "(REVISIT REASON : " & oEngineerVisit.OutcomeDetails & ".)" & vbCrLf & "PREVIOUS NOTES : " & oEngineerVisit.NotesToEngineer & vbCrLf
                                autoNextVisit.SetPartsToFit = oEngineerVisit.PartsToFit
                                autoNextVisit.DueDate = Nothing
                                autoNextVisit.SetAMPM = ""
                                autoNextVisit.SetFuelID = Helper.MakeIntegerValid(oEngineerVisit.FuelID)
                                autoNextVisit = [Insert](autoNextVisit, oJob.JobID)

                            Case Enums.EngineerVisitOutcomes.Further_Works

                                Dim autoNextVisit As New EngineerVisit
                                autoNextVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Parts_Need_Ordering)
                                autoNextVisit.SetNotesToEngineer = "(REVISIT REASON : " & oEngineerVisit.OutcomeDetails & ".)" & vbCrLf & "PREVIOUS NOTES : " & oEngineerVisit.NotesToEngineer & vbCrLf
                                autoNextVisit.SetPartsToFit = oEngineerVisit.PartsToFit
                                autoNextVisit.SetFuelID = Helper.MakeIntegerValid(oEngineerVisit.FuelID)

                                Dim newJOW As New JobOfWorks.JobOfWork
                                newJOW.SetJobID = DB.Job.Job_Get_For_An_EngineerVisit_ID(oEngineerVisit.EngineerVisitID).JobID
                                Dim dt As DataTable = DB.JobOfWorks.JobOfWork_Get_For_Job(newJOW.JobID).Table
                                newJOW.SetPONumber = dt.Rows(dt.Rows.Count - 1).Item("PONumber")
                                Dim oPriority() As DataRow = DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'P1 - 5 Days'")
                                If oPriority.Length > 0 Then
                                    newJOW.SetPriority = CInt(oPriority(0).Item("ManagerID"))
                                End If

                                newJOW.EngineerVisits.Add(autoNextVisit)
                                newJOW = DB.JobOfWorks.Insert(newJOW)

                                Dim movedOrders As DataTable = DB.EngineerVisitPartProductAllocated.EngineerVisitPartAllocated_MoveVisit(oEngineerVisit.EngineerVisitID, autoNextVisit.EngineerVisitID)

                                Dim dvVisits As DataView = DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID)

                                Dim visitsComplete As Boolean = True

                                For Each rowVisit As DataRow In dvVisits.Table.Rows
                                    If rowVisit.Item("StatusEnumID") < CInt(Enums.VisitStatus.Uploaded) Then
                                        visitsComplete = False
                                    End If
                                Next

                                If visitsComplete = True Then
                                    DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, CInt(Enums.JobOfWorkStatus.Complete))
                                End If

                            Case Else
                                'DO NOTHING
                        End Select
                    Else
                        If oEngineerVisit.OutcomeEnumID = Enums.EngineerVisitOutcomes.Declined Then
                            Dim autoNextVisit As New EngineerVisit
                            autoNextVisit.SetJobOfWorkID = oEngineerVisit.JobOfWorkID
                            autoNextVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Ready_For_Schedule)
                            autoNextVisit.SetNotesToEngineer = "(REVISIT REASON : " & oEngineerVisit.OutcomeDetails & ".)" & vbCrLf & "PREVIOUS NOTES : " & oEngineerVisit.NotesToEngineer & vbCrLf
                            autoNextVisit.SetPartsToFit = oEngineerVisit.PartsToFit
                            autoNextVisit.SetVisitNumber = oEngineerVisit.VisitNumber
                            autoNextVisit.DueDate = oEngineerVisit.DueDate
                            autoNextVisit.SetAMPM = oEngineerVisit.AMPM
                            autoNextVisit.SetFuelID = Helper.MakeIntegerValid(oEngineerVisit.FuelID)
                            autoNextVisit = [Insert](autoNextVisit, oJob.JobID)
                        End If
                    End If

                    If CInt(oEngineerVisit.OutcomeEnumID) = Enums.EngineerVisitOutcomes.Could_Not_Start Then

                        Dim dvVisits As DataView = DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID)

                        Dim visitsComplete As Boolean = True

                        For Each rowVisit As DataRow In dvVisits.Table.Rows
                            If rowVisit.Item("StatusEnumID") < CInt(Enums.VisitStatus.Uploaded) Then
                                visitsComplete = False
                            End If
                        Next

                        If visitsComplete = True Then
                            DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, CInt(Enums.JobOfWorkStatus.Closed))
                        End If

                    ElseIf CInt(oEngineerVisit.OutcomeEnumID) = Enums.EngineerVisitOutcomes.Complete Then

                        Dim dvVisits As DataView = DB.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work(oEngineerVisit.JobOfWorkID)

                        Dim visitsComplete As Boolean = True

                        For Each rowVisit As DataRow In dvVisits.Table.Rows
                            If rowVisit.Item("StatusEnumID") < CInt(Enums.VisitStatus.Uploaded) Then
                                visitsComplete = False
                            End If
                        Next

                        If visitsComplete = True Then
                            DB.JobOfWorks.Update_Status(oEngineerVisit.JobOfWorkID, CInt(Enums.JobOfWorkStatus.Complete))
                        End If

                    End If

                End If

                'PART AND PRODUCTS - NEEDED
                _database.EngineerVisitsPartsAndProducts.PartsNeeded_Delete(oEngineerVisit.EngineerVisitID)
                _database.EngineerVisitsPartsAndProducts.ProductsNeeded_Delete(oEngineerVisit.EngineerVisitID)
                _database.EngineerVisitsTimeSheet.Delete(oEngineerVisit.EngineerVisitID)

                For Each row As DataRow In oEngineerVisit.TimeSheets.Table.Rows

                    Dim oTimeSheet As New EngineerVisitTimeSheets.EngineerVisitTimeSheet

                    oTimeSheet.SetEngineerVisitID = oEngineerVisit.EngineerVisitID
                    oTimeSheet.StartDateTime = row.Item("StartDateTime")
                    oTimeSheet.EndDateTime = row.Item("EndDateTime")
                    oTimeSheet.SetComments = row.Item("Comments")
                    oTimeSheet.SetTimeSheetTypeID = row.Item("TimesheetTypeID")
                    _database.EngineerVisitsTimeSheet.Insert(oTimeSheet)

                Next

                'UPDATE ASSET SERVICED
                If CType(oJob.JobDefinitionEnumID, Entity.Sys.Enums.JobDefinition) = Sys.Enums.JobDefinition.Contract Or oEngineerVisit.GasServiceCompleted = True Then
                    For Each oJobAsset As Object In oJob.Assets

                        Dim asset As New Assets.Asset
                        asset = DB.Asset.Asset_Get(CType(oJobAsset, JobAssets.JobAsset).AssetID)
                        asset.LastServicedDate = Now
                        DB.Asset.Update(asset)
                    Next oJobAsset

                End If

                'UPDATE SITE LAST SERVICED DATE
                If oJob.JobTypeID = CInt(Enums.JobTypes.ServiceCertificate) Or oJob.JobTypeID = CInt(Enums.JobTypes.Commission) Or
                    oJob.JobTypeID = CInt(Enums.JobTypes.Service) Then
                    If oEngineerVisit.GasServiceCompleted = True And oEngineerVisit.OutcomeEnumID = CInt(Enums.EngineerVisitOutcomes.Complete) Then
                        Dim customer As Customers.Customer = DB.Customer.Customer_Get_ForSiteID(oJob.PropertyID)
                        Dim motstyle As Boolean = False
                        If customer IsNot Nothing AndAlso customer.MOTStyleService = True Then motstyle = True
                        Dim reinstate As Boolean = False
                        If oEngineerVisit.EngineerVisitNCCGSR IsNot Nothing AndAlso
                       oEngineerVisit.EngineerVisitNCCGSR.CertificateTypeID = CInt(Enums.CertificateType.Reinstate) Then
                            reinstate = True
                        End If

                        Dim actualServiceDate As DateTime
                        If oEngineerVisit.StartDateTime = Date.MinValue Then
                            If oEngineerVisit.TimeSheets.Table.Rows.Count > 0 Then
                                actualServiceDate = oEngineerVisit.TimeSheets.Table.Rows(0).Item("StartDateTime")
                            Else
                                actualServiceDate = Now()
                            End If
                        Else
                            actualServiceDate = oEngineerVisit.StartDateTime
                        End If

                        Dim oldLastServiceDate As DateTime = Nothing
                        Dim lastServiceDate As DateTime = Nothing
                        'update all
                        Dim siteFuels As DataRow()
                        If oEngineerVisit.FuelID = 0 Then
                            siteFuels = DB.Sites.SiteFuel_GetAll_ForSite(oJob.PropertyID).Table.Select()
                        Else
                            siteFuels = DB.Sites.SiteFuel_GetAll_ForSite(oJob.PropertyID).Table.Select("FuelID = " & oEngineerVisit.FuelID)
                        End If
                        If siteFuels.Length > 0 Then
                            For Each fuel As DataRow In siteFuels
                                oldLastServiceDate = Helper.MakeDateTimeValid(fuel("LastServiceDate"))
                                Dim sfServiceDiff As Integer = DateDiff(DateInterval.Month, actualServiceDate, oldLastServiceDate.AddYears(1))
                                If oldLastServiceDate.AddYears(1) > actualServiceDate And
                                    sfServiceDiff >= 0 And sfServiceDiff <= 2 And motstyle And
                                    CInt(fuel("FuelID")) = CInt(Enums.FuelTypes.NatGas) And Not reinstate Then
                                    lastServiceDate = oldLastServiceDate.AddYears(1)
                                Else
                                    lastServiceDate = actualServiceDate
                                End If

                                If Helper.MakeDateTimeValid(fuel("LastServiceDate")).Date <>
                                    lastServiceDate Then
                                    Dim change As String = "Service Completed: Updated " & DB.Picklists.Get_One_As_Object(fuel("FuelID")).Name &
                                        ", changed last service date from " & CDate(fuel("LastServiceDate")).Date & " to " &
                                         lastServiceDate

                                    DB.Sites.SiteFuel_Update_LastServiceDate(oJob.PropertyID, CInt(fuel("FuelID")), lastServiceDate, actualServiceDate)
                                    If Not String.IsNullOrEmpty(change) Then DB.Sites.[SiteFuelAudit_Insert](oJob.PropertyID, change)
                                End If
                            Next
                        End If
                        If lastServiceDate = Nothing Then lastServiceDate = actualServiceDate
                        DB.Sites.Site_UpdateLastServiceDate(oJob.PropertyID, lastServiceDate, actualServiceDate)
                    End If
                End If

                EngineerVisitUnitsUsed_Delete(oEngineerVisit.EngineerVisitID)

                If JobItemsDataview IsNot Nothing Then
                    For Each jobItemDR As DataRow In JobItemsDataview.Table.Rows
                        EngineerVisitUnitsUsed_Insert(oEngineerVisit.EngineerVisitID, jobItemDR("JobItemID"), Helper.MakeDoubleValid(jobItemDR("NumUnitsUsed")))
                    Next jobItemDR
                End If

                'NCC FIELDS
                If Not oEngineerVisit.EngineerVisitNCCGSR Is Nothing Then
                    If oEngineerVisit.EngineerVisitNCCGSR.Exists Then
                        DB.EngineerVisitNCCGSR.Update(oEngineerVisit.EngineerVisitNCCGSR)
                    Else
                        DB.EngineerVisitNCCGSR.Insert(oEngineerVisit.EngineerVisitNCCGSR)
                    End If
                End If

                Return EngineerVisits_Get_New_As_Object(oEngineerVisit.EngineerVisitID)
            End Function

            Private Sub AllocatedDistributions(ByVal PartsAndProductsDistribution As DataView)
                For Each row As DataRow In PartsAndProductsDistribution.Table.Rows
                    If row.Item("DistributedID") = 0 Then
                        _database.ClearParameter()
                        _database.AddParameter("@LocationID", row.Item("LocationID"), True)
                        _database.AddParameter("@AllocatedID", row.Item("AllocatedID"), True)
                        _database.AddParameter("@Other", row.Item("Other"), True)
                        _database.AddParameter("@Quantity", row.Item("Quantity"), True)
                        _database.AddParameter("@PartProductID", row.Item("PartProductID"), True)
                        _database.AddParameter("@OrderPartProductID", row.Item("OrderPartProductID"), True)

                        Select Case Helper.MakeStringValid(row.Item("Type"))
                            Case "Part"
                                _database.ExecuteSP_NO_Return("EngineerVisitPartDistributed_Insert")
                            Case "Product"
                                _database.ExecuteSP_NO_Return("EngineerVisitProductDistributed_Insert")
                        End Select
                        If row.Item("StockTransactionType") = -1 Then
                            'PART CREDIT
                            Dim CurrentPartsToBeCredited As New PartsToBeCrediteds.PartsToBeCredited
                            CurrentPartsToBeCredited.IgnoreExceptionsOnSetMethods = True

                            Dim op As OrderParts.OrderPart = DB.OrderPart.OrderPart_Get(row.Item("OrderPartProductID"))
                            Dim ps As PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(op.PartSupplierID)

                            CurrentPartsToBeCredited.SetOrderID = op.OrderID
                            CurrentPartsToBeCredited.SetSupplierID = ps.SupplierID
                            CurrentPartsToBeCredited.SetPartOrderID = row.Item("OrderPartProductID")
                            CurrentPartsToBeCredited.SetPartID = row.Item("PartProductID")
                            CurrentPartsToBeCredited.SetQty = row.Item("Quantity")
                            CurrentPartsToBeCredited.SetStatusID = CInt(Enums.PartsToBeCreditedStatus.Awaiting_Part_Return)
                            CurrentPartsToBeCredited.SetManuallyAdded = False
                            CurrentPartsToBeCredited.SetOrderReference = DB.Order.Order_Get(op.OrderID).OrderReference
                            DB.PartsToBeCredited.Insert(CurrentPartsToBeCredited)

                        End If

                        If row.Item("LocationID") > 0 And row.Item("StockTransactionType") > 0 Then
                            Select Case Helper.MakeStringValid(row.Item("Type"))
                                Case "Part"
                                    Dim oPartTransaction As New PartTransactions.PartTransaction
                                    oPartTransaction.SetLocationID = row.Item("LocationID")
                                    oPartTransaction.SetPartID = row.Item("PartProductID")
                                    oPartTransaction.SetOrderPartID = row.Item("OrderPartProductID")
                                    If CInt(row("StockTransactionType")) = CInt(Enums.Transaction.StockOut) Then
                                        oPartTransaction.SetAmount = row.Item("Quantity") * -1
                                    Else
                                        oPartTransaction.SetAmount = row.Item("Quantity")
                                    End If
                                    oPartTransaction.SetTransactionTypeID = row.Item("StockTransactionType")
                                    DB.PartTransaction.Insert(oPartTransaction)
                                Case "Product"
                                    Dim oProductTransaction As New ProductTransactions.ProductTransaction
                                    oProductTransaction.SetLocationID = row.Item("LocationID")
                                    oProductTransaction.SetProductID = row.Item("PartProductID")
                                    oProductTransaction.SetOrderProductID = row.Item("OrderPartProductID")
                                    If CInt(row("StockTransactionType")) = CInt(Enums.Transaction.StockOut) Then
                                        oProductTransaction.SetAmount = row.Item("Quantity") * -1
                                    Else
                                        oProductTransaction.SetAmount = row.Item("Quantity")
                                    End If
                                    oProductTransaction.SetTransactionTypeID = row.Item("StockTransactionType")
                                    DB.ProductTransaction.Insert(oProductTransaction)
                            End Select
                        End If
                    End If
                Next
            End Sub

            Public Function EngineerVisitUnitsUsed_Get_For_EngineerVisitID(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitUnitsUsed_Get_For_EngineerVisitID")
                dt.TableName = Enums.TableNames.tblJobItem.ToString
                Return New DataView(dt)
            End Function

            Public Sub EngineerVisitUnitsUsed_Delete(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitUnitsUsed_Delete")
            End Sub

            Public Function EngineerVisitUnitsUsed_Insert(ByVal EngineerVisitID As Integer,
                                                            ByVal JobItemID As Integer,
                                                            ByVal NumUnitsUsed As Double) As Integer
                _database.ClearParameter()
                AddEngineerVisitUnitsUsedParametersToCommand(EngineerVisitID, JobItemID, NumUnitsUsed)

                Return Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitUnitsUsed_Insert"))
            End Function

            Private Sub AddEngineerVisitUnitsUsedParametersToCommand(ByVal EngineerVisitID As Integer,
                                                            ByVal JobItemID As Integer,
                                                            ByVal NumUnitsUsed As Double)
                With _database
                    .AddParameter("@EngineerVisitID", EngineerVisitID, True)
                    .AddParameter("@JobItemID", JobItemID, True)
                    .AddParameter("@NumUnitsUsed", NumUnitsUsed, True)

                End With
            End Sub

            Public Function EngineerVisits_Count_Visits_Not_Ready_For_Invoice_For_JobID(ByVal JobID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)
                Return Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisits_Count_Visits_Not_Ready_For_Invoice_For_JobID"))
            End Function

            Public Function EngineerCharge_VAT_Amount(ByVal EngineerChargeID As Integer, ByVal VisitDate As DateTime, ByVal Amount As Double) As Double
                _database.ClearParameter()
                _database.AddParameter("@EngineerChargeID", EngineerChargeID, True)
                _database.AddParameter("@TypeID", CInt(Enums.InvoiceType.Visit), True)
                _database.AddParameter("@VisitDate", VisitDate, True)
                _database.AddParameter("@Amount", Amount, True)

                Return _database.ExecuteSP_OBJECT("EngineerCharge_VAT_Amount")
            End Function

            Public Function EngineerVisitLiveCostReport() As DataTable
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisits_Get_All_REPORT_Yesterday")
                dt.TableName = Enums.TableNames.tblJobItem.ToString
                Return dt
            End Function

            Public Sub AlterEstimatedDate(ByVal JobWorkID As Integer, ByVal EstDate As Date)
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobWorkID, True)
                _database.AddParameter("@Date", EstDate, True)

                _database.ExecuteSP_NO_Return("EngineerVisit_AlterEstimated")

            End Sub

            Public Function GetFutureVisits(ByVal EngineerID As Integer, ByVal includeCurrentVisit As Boolean) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerID, True)
                _database.AddParameter("@IncludeCurrentVisit", includeCurrentVisit, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_GetFutureVisits")
                dt.TableName = Enums.TableNames.tblJobItem.ToString
                Return dt
            End Function

            Public Function Get_Appointments_Main(ByVal StartDate As Date, ByVal TimeReq As Integer, Optional ByVal days As Integer = 14, Optional ByVal TimeLimit As Integer = 240) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@StartDate", StartDate, True)
                _database.AddParameter("@timereq", TimeReq, True)
                _database.AddParameter("@Days", days, True)
                _database.AddParameter("@TimeLimit", TimeLimit, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Get_Appointments_Main")
                dt.TableName = Enums.TableNames.tblJobItem.ToString
                Return dt
            End Function

            Public Function Get_Appointments_Multi(ByVal StartDate As String, ByVal TimeReq As Integer, Optional ByVal days As Integer = 14, Optional ByVal TimeLimit As Integer = 240) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@StartDate", StartDate, True)
                _database.AddParameter("@timereq", TimeReq, True)
                _database.AddParameter("@Days", days, True)
                _database.AddParameter("@TimeLimit", TimeLimit, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Get_Appointments_Multi_Appoint")
                dt.TableName = Enums.TableNames.tblJobItem.ToString
                Return dt
            End Function

            Public Function Get_Appointments_ForEngineer(ByVal StartDate As String, ByVal TimeReq As Integer, ByVal EngineerID As Integer, Optional ByVal days As Integer = 14, Optional ByVal TimeLimit As Integer = 240) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@StartDate", StartDate, True)
                _database.AddParameter("@timereq", TimeReq, True)
                _database.AddParameter("@Days", days, True)
                _database.AddParameter("@TimeLimit", TimeLimit, True)
                _database.AddParameter("@EngineerID", EngineerID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Get_Appointments_For_SingleEngineerID")
                dt.TableName = Enums.TableNames.tblJobItem.ToString
                Return dt
            End Function

            Public Function Get_Appointments_Scheduler(ByVal StartDate As String, ByVal TimeReq As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@StartDate", StartDate, True)
                _database.AddParameter("@timereq", TimeReq, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Get_Appointments_Schedulers")
                dt.TableName = Enums.TableNames.tblJobItem.ToString
                Return dt
            End Function

            Public Function Find_The_Gap(ByVal datein As String, ByVal Engid As Integer, ByVal Period As String) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@datein", datein, True)
                _database.AddParameter("@EngineerID", Engid, True)
                _database.AddParameter("@Period", Period, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Visits_Find_Gap")
                dt.TableName = Enums.TableNames.tblJobItem.ToString
                Return dt

            End Function

            Public Function GetLastVisit(ByVal SiteID As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_GetLastVisit")

                Return dt

            End Function

            Public Function GetSymptoms(ByVal EngineervisitID As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineervisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_GetSymptoms")

                Return dt
            End Function

            Public Sub DeleteSymptoms(ByVal EngineervisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineervisitID, True)

                _database.ExecuteSP_DataTable("EngineerVisit_DeleteSymptoms_ForEngineerVisitID")

            End Sub

            Public Function InsertSymptom(ByVal EngineervisitID As Integer, ByVal SymptomID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineervisitID, True)
                _database.AddParameter("@SymptomID", SymptomID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_InsertSymptom")

                Return New DataView(dt)
            End Function

            Public Function GetExtendedProperties(ByVal EngineervisitID As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineervisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_GetExtendedProperties")

                Return dt
            End Function

            Public Function InsertAdditionalText(ByVal EngineervisitID As Integer, ByVal AdditionalText As String) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineervisitID, True)
                _database.AddParameter("@AdditionalText", AdditionalText, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_InsertAdditionalText")

                Return dt
            End Function

            Public Sub DeleteExtendedProperties(ByVal EngineervisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineervisitID, True)

                _database.ExecuteSP_DataTable("EngineerVisit_DeleteExtendedProperties_ForEngineerVisitID")

            End Sub

            Public Function MoveParts(ByVal FromID As Integer, ByVal ToID As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@OldEngineerVisitID", FromID, True)
                _database.AddParameter("@NewEngineerVisitID", ToID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartAllocated_MoveVisit")
                Return dt.Rows.Count > 0
            End Function

            Public Function EngineerVisits_Get_LastForJob(ByVal jobID As Integer, Optional ByVal jobNumber As String = "") As EngineerVisit
                _database.ClearParameter()
                Dim dt As DataTable = Nothing

                If Not Helper.IsStringEmpty(jobNumber) Then
                    _database.AddParameter("@JobNumber", jobNumber, True)
                    dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobNumber")
                Else
                    _database.AddParameter("@JobID", jobID, True)
                    dt = _database.ExecuteSP_DataTable("EngineerVisits_Get_LastForJobID")
                End If

                If dt.Rows.Count > 0 Then
                    With dt.Rows(0)
                        Dim visit As New EngineerVisit
                        visit.IgnoreExceptionsOnSetMethods = True
                        visit.Exists = True
                        visit.SetEngineerVisitID = .Item("EngineerVisitID")
                        visit.SetJobOfWorkID = .Item("JobOfWorkID")
                        visit.SetEngineerID = .Item("EngineerID")
                        visit.StartDateTime = Helper.MakeDateTimeValid(.Item("StartDateTime"))
                        visit.EndDateTime = Helper.MakeDateTimeValid(.Item("EndDateTime"))
                        visit.SetStatusEnumID = .Item("StatusEnumID")
                        visit.SetNotesToEngineer = .Item("NotesToEngineer")
                        visit.SetNotesFromEngineer = .Item("NotesFromEngineer")
                        visit.SetOutcomeEnumID = .Item("OutcomeEnumID")
                        visit.SetOutcomeDetails = .Item("OutcomeDetails")
                        visit.SetCustomerName = .Item("CustomerName")
                        visit.SetVisitOutcome = .Item("VisitOutcome")

                        visit.SetManualEntryByUserID = .Item("ManualEntryByUserID")
                        visit.ManualEntryOn = Helper.MakeDateTimeValid(.Item("ManualEntryOn"))
                        visit.SetVisitLocked = .Item("VisitLocked")
                        visit.SetDeleted = .Item("Deleted")
                        visit.SetGasInstallationTightnessTestID = .Item("GasInstallationTightnessTestID")
                        visit.SetEmergencyControlAccessibleID = .Item("EmergencyControlAccessibleID")
                        visit.SetBondingID = .Item("BondingID")
                        visit.SetExpectedEngineerID = .Item("ExpectedEngineerID")
                        visit.SetPropertyRented = .Item("PropertyRented")
                        visit.SetPaymentMethodID = .Item("PaymentMethodID")
                        visit.SetAmountCollected = .Item("AmountCollected")
                        visit.SetAMPM = .Item("AMPM")
                        visit.SetVisitNumber = .Item("VisitNumber")
                        visit.SetVisitStatus = .Item("VisitStatus")
                        visit.SetRecharge = Helper.MakeBooleanValid(.Item("Recharge"))
                        If .Table.Columns.Contains("FuelID") Then visit.SetFuelID = .Item("FuelID")
                        Return visit
                    End With
                Else
                    Return Nothing
                End If
            End Function

            Public Function EngineerVisit_GetActionID(ByVal EVID As Integer) As Integer
                _database.ClearParameter()

                _database.AddParameter("@EngineerVisitID", EVID, True)

                Return _database.ExecuteSP_OBJECT("EngineerVisit_GetActionID")

            End Function

            Public Function Get_SiteHistory(ByVal siteId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", siteId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_Get_SiteHistory")
                Return New DataView(dt)
            End Function

            Public Function Get_ByEngineerIdAndStatusEnumId(ByVal engineerId As Integer, ByVal statusEnumId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", engineerId, True)
                _database.AddParameter("@StatusEnumID", statusEnumId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_Get_ByEngineerIdAndStatusEnumId")
                Return New DataView(dt)
            End Function

#End Region

            Public Function [Get_ByJobId](ByVal jobId As Integer) As List(Of EngineerVisit)
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisit_Get_ByJobId")

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    Dim engineerVisits As List(Of EngineerVisit) =
                        (From x In dt.AsEnumerable() Select New EngineerVisit With {
                            .Exists = True,
                            .SetEngineerVisitID = Helper.MakeIntegerValid(x("EngineerVisitId")),
                            .SetJobOfWorkID = Helper.MakeIntegerValid(x("JobOfWorkId")),
                            .SetEngineerID = Helper.MakeIntegerValid(x("EngineerId")),
                            .StartDateTime = Helper.MakeDateTimeValid(x("StartDateTime")),
                            .EndDateTime = Helper.MakeDateTimeValid(x("EndDateTime")),
                            .SetStatusEnumID = Helper.MakeIntegerValid(x("StatusEnumId")),
                            .SetNotesToEngineer = Helper.MakeStringValid(x("NotesToEngineer")),
                            .SetNotesFromEngineer = Helper.MakeStringValid(x("NotesFromEngineer")),
                            .SetOutcomeEnumID = Helper.MakeIntegerValid(x("OutcomeEnumId")),
                            .SetOutcomeDetails = Helper.MakeStringValid(x("OutcomeDetails")),
                            .SetCustomerName = Helper.MakeStringValid(x("CustomerName")),
                            .SetManualEntryByUserID = Helper.MakeIntegerValid(x("ManualEntryByUserId")),
                            .ManualEntryOn = Helper.MakeDateTimeValid(x("ManualEntryOn")),
                            .SetVisitLocked = Helper.MakeBooleanValid(x("VisitLocked")),
                            .SetDeleted = Helper.MakeBooleanValid(x("Deleted")),
                            .SetPaymentMethodID = Helper.MakeIntegerValid(x("PaymentMethodId")),
                            .SetAmountCollected = Helper.MakeDoubleValid(x("AmountCollected")),
                            .SetGasInstallationTightnessTestID = Helper.MakeIntegerValid(x("GasInstallationTightnessTestId")),
                            .SetEmergencyControlAccessibleID = Helper.MakeIntegerValid(x("EmergencyControlAccessibleId")),
                            .SetBondingID = Helper.MakeIntegerValid(x("BondingId")),
                            .SetPropertyRented = Helper.MakeIntegerValid(x("PropertyRented")),
                            .SetSignatureSelectedID = Helper.MakeIntegerValid(x("SignatureSelectedId")),
                            .SetPartsToFit = Helper.MakeBooleanValid(x("PartsToFit")),
                            .SetGasServiceCompleted = Helper.MakeBooleanValid(x("GasServiceCompleted")),
                            .SetEmailReceipt = Helper.MakeBooleanValid(x("EmailReceipt")),
                            .Downloading = Helper.MakeDateTimeValid(x("Downloading")),
                            .SetExpectedEngineerID = Helper.MakeIntegerValid(x("ExpectedEngineerId")),
                            .SetAMPM = Helper.MakeStringValid(x("AMPM")),
                            .SetVisitNumber = Helper.MakeIntegerValid(x("VisitNumber")),
                            .SetRecharge = Helper.MakeBooleanValid(x("Recharge")),
                            .SetCostsTo = Helper.MakeStringValid(x("CostsTo")),
                            .setNccRadID = Helper.MakeIntegerValid(x("NccRadId")),
                            .SetMeterCappedID = Helper.MakeIntegerValid(x("MeterCappedId")),
                            .SetUseSORDescription = Helper.MakeBooleanValid(x("UseSORdescription")),
                            .SetAppointmentID = Helper.MakeIntegerValid(x("AppointmentId")),
                            .SetMeterLocationID = Helper.MakeIntegerValid(x("MeterLocationId")),
                            .SetExpectedDepartment = Helper.MakeStringValid(x("ExpectedDepartment")),
                            .SetFuelID = Helper.MakeIntegerValid(x("FuelId")),
                            .SetExcludeFromTextMessage = Helper.MakeIntegerValid(x("ExcludeFromTextMessage"))
                        }).ToList()
                    Return engineerVisits
                Else : Return Nothing
                End If
            End Function

        End Class

    End Namespace

End Namespace