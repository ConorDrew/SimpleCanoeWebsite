Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitCharges

        Public Class EngineerVisitChargeSQL

            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Visit Charges"

            Public Sub EngineerVisitCharge_Delete(ByVal EngineerVisitChargeID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitChargeID", EngineerVisitChargeID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitCharge_Delete")
            End Sub

            Public Function EngineerVisitCharge_Check(ByVal EngineerVisitChargeID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitChargeID, True)
                Return _database.ExecuteSP_OBJECT("EngineerVisitCharge_Check")
            End Function

            Public Function EngineerVisitCharge_Get(ByVal EngineerVisitID As Integer) As EngineerVisitCharge
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitCharge_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVisitCharge As New EngineerVisitCharge
                        With oEngineerVisitCharge
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerVisitChargeID = dt.Rows(0).Item("EngineerVisitChargeID")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")
                            .SetLabourRate = dt.Rows(0).Item("MileageRate")
                            .SetApplyMileageToTotal = dt.Rows(0).Item("ApplyMileageToTotal")
                            .SetJobValue = dt.Rows(0).Item("JobValue")
                            .SetChargeTypeID = dt.Rows(0).Item("ChargeTypeID")
                            .SetCharge = dt.Rows(0).Item("Charge")
                            .SetInvoiceReadyID = dt.Rows(0).Item("InvoiceReadyID")
                            .SetMainContractorDiscount = dt.Rows(0).Item("MainContractorDiscount")
                            .SetNominalCode = dt.Rows(0).Item("NominalCode")
                            .SetDepartment = dt.Rows(0).Item("Department")
                            .SetForSageAccountCode = dt.Rows(0).Item("ForSageAccountCode")
                            .SetPartsMarkUp = dt.Rows(0).Item("PartsMarkUp")
                            .SetPartsPrice = dt.Rows(0).Item("PartsPrice")
                            .SetLabourPrice = dt.Rows(0).Item("LabourPrice")
                            .SetHasChargesFromJob = Sys.Helper.MakeBooleanValid(dt.Rows(0)("HasChargesFromJob"))
                        End With
                        oEngineerVisitCharge.Exists = True
                        Return oEngineerVisitCharge
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function EngineerVisitCharge_Insert(ByVal oEngineerVisitCharge As EngineerVisitCharge) As EngineerVisitCharge
                _database.ClearParameter()
                AddEngineerVisitChargeParametersToCommand(oEngineerVisitCharge)

                _database.AddParameter("@RecordAddedOn", Now, True)
                _database.AddParameter("@RecordAddedBy", loggedInUser.UserID, True)

                oEngineerVisitCharge.SetEngineerVisitChargeID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitCharge_Insert"))
                oEngineerVisitCharge.Exists = True
                Return EngineerVisitCharge_Get(oEngineerVisitCharge.EngineerVisitID)
            End Function

            Public Sub EngineerVisitCharge_Update(ByVal oEngineerVisitCharge As EngineerVisitCharge, Optional ByVal job As Entity.Jobs.Job = Nothing)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitChargeID", oEngineerVisitCharge.EngineerVisitChargeID, True)
                AddEngineerVisitChargeParametersToCommand(oEngineerVisitCharge)

                If Entity.Sys.Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("EngineerVisitCharge_Update")) = True Then
                    ' Status Changed enter Job Audit
                    If job IsNot Nothing Then
                        Dim jA As New Entity.JobAudits.JobAudit
                        jA.SetJobID = job.JobID
                        jA.SetActionChange = "Visit Status changed to Invoice " &
                            Replace(CType(oEngineerVisitCharge.InvoiceReadyID,
                            Entity.Sys.Enums.InvoiceReady).ToString, "_", " ") &
                        " (Unique Visit ID: " & oEngineerVisitCharge.EngineerVisitID & ")"
                        DB.JobAudit.Insert(jA)
                    End If
                End If
            End Sub

            Private Sub AddEngineerVisitChargeParametersToCommand(ByRef oEngineerVisitCharge As EngineerVisitCharge)
                With _database
                    .AddParameter("@EngineerVisitID", oEngineerVisitCharge.EngineerVisitID, True)
                    .AddParameter("@MileageRate", oEngineerVisitCharge.LabourRate, True)
                    .AddParameter("@ApplyMileageToTotal", oEngineerVisitCharge.ApplyMileageToTotal, True)
                    .AddParameter("@JobValue", oEngineerVisitCharge.JobValue, True)
                    .AddParameter("@ChargeTypeID", oEngineerVisitCharge.ChargeTypeID, True)
                    .AddParameter("@Charge", oEngineerVisitCharge.Charge, True)
                    .AddParameter("@InvoiceReadyID", oEngineerVisitCharge.InvoiceReadyID, True)
                    .AddParameter("@MainContractorDiscount", oEngineerVisitCharge.MainContractorDiscount, True)
                    .AddParameter("@NominalCode", oEngineerVisitCharge.NominalCode, True)
                    .AddParameter("@Department", oEngineerVisitCharge.Department, True)
                    .AddParameter("@ForSageAccountCode", oEngineerVisitCharge.ForSageAccountCode, True)
                    .AddParameter("@PartsMarkUp", oEngineerVisitCharge.PartsMarkUp, True)
                    .AddParameter("@PartsPrice", oEngineerVisitCharge.PartsPrice, True)
                    .AddParameter("@LabourPrice", oEngineerVisitCharge.LabourPrice, True)
                    .AddParameter("@HasChargesFromJob", oEngineerVisitCharge.HasChargesFromJob, True)
                End With
            End Sub

            Public Function EngineerVisit_Get_MileageRate_For_Site(ByVal EngineerVisitID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("EngineerVisit_Get_MileageRate_For_Site"))

            End Function

            Public Function EngineerVisit_Get_MileageRate_For_ContractJob(ByVal JobID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("EngineerVisit_Get_MileageRate_For_ContractJob"))

            End Function

            Public Function EngineerVisitCharge_GetContractInvoiceFrequency(ByVal EngineerVisitID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitCharge_GetContractInvoiceFrequency"))

            End Function

            Public Function EngineerVisit_Get_CustomerContractorDiscount(ByVal EngineerVisitID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("EngineerVisit_Get_CustomerContractorDiscount"))

            End Function

            Public Function EngineerVisitCharge_Get_ChargedBreakDown(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitCharge_Get_ChargedBreakDown")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitCharge_Get_SorBreakdownForVal(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitCharge_Get_SorBreakdownForVal")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString
                Return New DataView(dt)
            End Function

#End Region

#Region "Additional Charges"

            Public Sub EngineerVisitAdditionalCharge_Delete(ByVal EngineerVisitAdditionalChargeID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitAdditionalChargeID", EngineerVisitAdditionalChargeID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitAdditionalCharge_Delete")
            End Sub

            Public Function EngineerVisitAdditionalCharge_GetAll(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitAdditionalCharge_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString
                Return New DataView(dt)
            End Function

            Public Sub EngineerVisitAdditionalCharge_Insert(ByVal EngineerVisitID As Integer,
                                                                ByVal ChargeDescription As String,
                                                                ByVal Charge As Double)

                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@ChargeDescription", ChargeDescription, True)
                _database.AddParameter("@Charge", Charge, True)

                _database.ExecuteSP_NO_Return("EngineerVisitAdditionalCharge_Insert")

            End Sub

#End Region

#Region "Schedule Of Rates Charges"

            Public Function EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString
                Return New DataView(dt)
            End Function

            Public Sub EngineerVisitScheduleOfRatesCharge_Insert(ByVal EngineerVisitID As Integer,
                                                                 ByVal JobItemID As Integer,
                                                                ByVal Price As Double,
                                                                ByVal tick As Integer)

                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@JobItemID", JobItemID, True)
                _database.AddParameter("@Price", Price, True)
                _database.AddParameter("@tick", tick, True)

                _database.ExecuteSP_NO_Return("EngineerVisitScheduleOfRatesCharge_Insert")

            End Sub

            Public Sub EngineerVisitScheduleOfRatesCharge_Delete(ByVal EngineerVisitScheduleOfRateChargesID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitScheduleOfRateChargesID", EngineerVisitScheduleOfRateChargesID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitScheduleOfRatesCharge_Delete")
            End Sub

#End Region

#Region "Part & Products Charges"

            Public Function EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsCharge_Get_For_EngineerVisitID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitPartsAndProductsCharge_Get_For_JobID(ByVal JobID As Integer, ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsCharge_Get_ForJob")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitPartProductCharges.ToString
                Return New DataView(dt)
            End Function

            Public Sub EngineerVisitPartCharge_Insert(ByVal EngineerVisitID As Integer,
                                                                 ByVal PartID As Integer,
                                                                ByVal Price As Double,
                                                                ByVal tick As Integer, ByVal Cost As Double, ByVal PartUsedID As Integer)

                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@Price", Price, True)
                _database.AddParameter("@tick", tick, True)
                _database.AddParameter("@cost", Cost, True)
                _database.AddParameter("@PartUsedID", PartUsedID, True)

                _database.ExecuteSP_NO_Return("EngineerVisitPartCharge_Insert")

            End Sub

            Public Sub EngineerVisitPartCharge_Delete(ByVal EngineerVisitPartCharge As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitPartCharge", EngineerVisitPartCharge, True)
                _database.ExecuteSP_NO_Return("EngineerVisitPartCharge_Delete")
            End Sub

            Public Sub EngineerVisitProductCharge_Insert(ByVal EngineerVisitID As Integer,
                                                                          ByVal ProductID As Integer,
                                                                         ByVal Price As Double,
                                                                         ByVal tick As Integer, ByVal Cost As Double)

                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@ProductID", ProductID, True)
                _database.AddParameter("@Price", Price, True)
                _database.AddParameter("@tick", tick, True)
                _database.AddParameter("@cost", Cost, True)

                _database.ExecuteSP_NO_Return("EngineerVisitProductCharge_Insert")

            End Sub

            Public Sub EngineerVisitProductCharge_Delete(ByVal EngineerVisitProductChargeID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitProductChargeID", EngineerVisitProductChargeID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitProductCharge_Delete")
            End Sub

            Public Sub EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID")
            End Sub

            Public Sub EngineerVisitPartsCharge_Update_Price(ByVal Id As Integer, ByVal markup As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", Id, True)
                _database.AddParameter("@MarkUp", markup, True)
                _database.ExecuteSP_NO_Return("EngineerVisitPartsCharge_Update_Price")
            End Sub

#End Region

#Region "Timesheets Charges"

            Public Function EngineerVisitTimeSheetCharges_Get(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitTimeSheetCharges_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitTimeSheetCharges_Get_ForJob(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitTimeSheetCharges_Get_ForJob")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString
                Return New DataView(dt)
            End Function

            Public Sub EngineerVisitTimeSheetCharges_Insert(ByVal EngineerVisitID As Integer,
                                                     ByVal Tick As Integer,
                                                    ByVal StartDateTime As DateTime,
                                                    ByVal EndDateTime As DateTime,
                                                    ByVal Price As Double,
                                                    ByVal TimeSheetTypeID As Integer,
                                                    ByVal Summary As String,
                                                    ByVal EngineerCost As Double)

                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@Tick", Tick, True)
                _database.AddParameter("@Price", Price, True)
                _database.AddParameter("@TimeSheetTypeID", TimeSheetTypeID, True)
                _database.AddParameter("@StartDateTime", StartDateTime, True)
                _database.AddParameter("@EndDateTime", EndDateTime, True)
                _database.AddParameter("@Summary", Summary, True)
                _database.AddParameter("@EngineerCost", EngineerCost, True)

                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheetCharges_Insert")

            End Sub

            Public Sub EngineerVisitTimeSheetCharges_Update(ByVal EngineerVisitTimesheetChargeID As Integer,
                                                                ByVal Tick As Integer)

                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitTimesheetChargeID", EngineerVisitTimesheetChargeID, True)
                _database.AddParameter("@Tick", Tick, True)

                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheetCharges_Update")

            End Sub

            Public Sub EngineerVisitTimeSheetCharges_Update_PriceAndMarkUp(ByVal EngineerVisitTimesheetChargeID As Integer,
                                                                ByVal Tick As Integer)

                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitTimesheetChargeID", EngineerVisitTimesheetChargeID, True)
                _database.AddParameter("@Tick", Tick, True)

                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheetCharges_Update")

            End Sub

            Public Sub EngineerVisitTimeSheetCharges_Delete(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheetCharges_Delete")
            End Sub

            Public Function EngineerVisitTimesheetCharge_ByTimeSheet(ByVal EngineerVisitTimeSheetID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitTimeSheetID", EngineerVisitTimeSheetID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitTimesheetCharge_ByTimeSheet")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitTimeSheetCharges_BankHoliday(ByVal theDate As DateTime) As Integer

                _database.ClearParameter()
                _database.AddParameter("@theDate", CDate(Format(theDate, "dd/MM/yyyy") & " 00:00:00"), True)

                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitTimeSheetCharges_BankHoliday"))

            End Function

#End Region

        End Class

    End Namespace

End Namespace