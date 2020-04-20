Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteJobs

        Public Class QuoteJobsSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub DeleteReservedQuoteNumber(ByVal JobNumber As Integer)
                Dim sql As String
                sql = "DELETE FROM tblQuoteNumber WHERE QuoteNumber = " & JobNumber
                DB.ExecuteWithOutReturn(sql)
            End Sub

            Public Function GetNextQuoteNumber() As JobNumber ' I used the job number class coz its the same fields - alp

                Dim nextQuoteNumber As Integer = 0
                Dim sql As String
                Dim preceedingZeros As String = ""

                sql = "SELECT QuoteNumber FROM tblQuoteNumber ORDER BY QuoteNumber ASC"

                Dim dt As DataTable = DB.ExecuteWithReturn(sql)

                If dt.Rows.Count > 0 Then

                    If dt.Rows(dt.Rows.Count - 1).Item("QuoteNumber") = dt.Rows.Count Then
                        nextQuoteNumber = dt.Rows(dt.Rows.Count - 1).Item("QuoteNumber") + 1
                    Else
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If dt.Rows(i).Item("QuoteNumber") <> i + 1 Then
                                nextQuoteNumber = i + 1
                                Exit For
                            End If
                        Next
                    End If
                Else
                    nextQuoteNumber = 1
                End If

                Select Case CStr(nextQuoteNumber).Length
                    Case 1
                        preceedingZeros = "0000"
                    Case 2
                        preceedingZeros = "000"
                    Case 3
                        preceedingZeros = "00"
                    Case 4
                        preceedingZeros = "0"
                    Case Else
                        preceedingZeros = ""
                End Select

                DB.ExecuteWithOutReturn("INSERT INTO tblQuoteNumber (QuoteNumber, Prefix) VALUES(" & nextQuoteNumber & ", 'Q')")

                Dim oQuoteNumber As New JobNumber(nextQuoteNumber, "Q" & preceedingZeros)

                Return oQuoteNumber

            End Function

            Public Function [Get](ByVal QuoteJobID As Integer) As QuoteJob
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteJob_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oQuoteJob As New QuoteJob
                        oQuoteJob.IgnoreExceptionsOnSetMethods = True
                        oQuoteJob.SetQuoteJobID = dt.Rows(0).Item("QuoteJobID")
                        oQuoteJob.SetReference = dt.Rows(0).Item("Reference")
                        oQuoteJob.SetSiteID = dt.Rows(0).Item("SiteID")
                        oQuoteJob.SetJobDefinitionEnumID = dt.Rows(0).Item("JobDefinitionEnumID")
                        oQuoteJob.SetJobTypeID = dt.Rows(0).Item("JobTypeID")
                        oQuoteJob.SetStatusEnumID = dt.Rows(0).Item("StatusEnumID")
                        oQuoteJob.DateCreated = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("DateCreated"))
                        oQuoteJob.SetCreatedByUserID = dt.Rows(0).Item("CreatedByUserID")
                        oQuoteJob.SetPartsAndProductsTotal = dt.Rows(0).Item("PartsAndProductsTotal")
                        oQuoteJob.SetGrandTotal = dt.Rows(0).Item("GrandTotal")
                        oQuoteJob.SetReasonForReject = dt.Rows(0).Item("ReasonForReject")
                        oQuoteJob.SetReasonForRejectID = dt.Rows(0).Item("ReasonForRejectID")
                        oQuoteJob.SetDeleted = dt.Rows(0).Item("Deleted")
                        oQuoteJob.SetPartsAndProductsMarkup = dt.Rows(0).Item("PartsAndProductsMarkup")
                        oQuoteJob.SetScheduleOfRatesMarkup = dt.Rows(0).Item("ScheduleOfRatesMarkup")
                        oQuoteJob.SetScheduleOfRatesTotal = dt.Rows(0).Item("ScheduleOfRatesTotal")
                        oQuoteJob.SetEstimatedMileage = dt.Rows(0).Item("EstimatedMileage")
                        ' oQuoteJob.SetMileageRate = dt.Rows(0).Item("MileageRate")
                        oQuoteJob.SetNotesToEngineer = dt.Rows(0).Item("NotesToEngineer")
                        oQuoteJob.SetNotesToElectrician = dt.Rows(0).Item("NotesToElectrician")
                        oQuoteJob.SetNotesToBuilder = dt.Rows(0).Item("NotesToBuilder")
                        oQuoteJob.SetEngineerLabourHrs = dt.Rows(0).Item("EngineerLabourHrs")
                        oQuoteJob.SetElectricianLabourHrs = dt.Rows(0).Item("ElectricianLabourHrs")
                        oQuoteJob.SetBuilderLabourHrs = dt.Rows(0).Item("BuilderLabourHrs")
                        oQuoteJob.SetEngineerMarkUp = dt.Rows(0).Item("EngineerMarkUp")
                        oQuoteJob.SetElectricianMarkUp = dt.Rows(0).Item("ElectricianMarkUp")
                        oQuoteJob.SetBuilderMarkUp = dt.Rows(0).Item("BuilderMarkUp")
                        oQuoteJob.SetElectricianArrivalDayNo = dt.Rows(0).Item("ElectricianArrivalDayNo")
                        oQuoteJob.SetElectricianArrivalHour = dt.Rows(0).Item("ElectricianArrivalHour")
                        oQuoteJob.SetBuilderArrivalDayNo = dt.Rows(0).Item("BuilderArrivalDayNo")
                        oQuoteJob.SetBuilderArrivalHour = dt.Rows(0).Item("BuilderArrivalHour")
                        oQuoteJob.SetPartsCost = dt.Rows(0).Item("PartsCost")
                        oQuoteJob.SetEngineerCost = dt.Rows(0).Item("EngineerCost")
                        oQuoteJob.SetBuilderCost = dt.Rows(0).Item("BuilderCost")
                        oQuoteJob.SetElectricianCost = dt.Rows(0).Item("ElectricianCost")
                        oQuoteJob.SetQuotedAmount = dt.Rows(0).Item("QuotedAmount")
                        oQuoteJob.SetDepositAmount = dt.Rows(0).Item("DepositAmount")
                        oQuoteJob.SetVatRateID = dt.Rows(0).Item("VatRateID")
                        oQuoteJob.ChangedDateTime = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("ChangedDateTime"))
                        oQuoteJob.SetChangedByUserID = dt.Rows(0).Item("ChangedByUserID")
                        oQuoteJob.SetOriginalQuotedAmount = dt.Rows(0).Item("OriginalQuotedAmount")
                        oQuoteJob.SetElectricianPackTypeID = dt.Rows(0).Item("ElectricianPackTypeID")
                        oQuoteJob.SetSORCharge = dt.Rows(0).Item("SORCharge")
                        oQuoteJob.SetAccessEquipmentID = dt.Rows(0).Item("AccessEquipmentID")
                        oQuoteJob.SetAsbestosID = dt.Rows(0).Item("AsbestosID")
                        oQuoteJob.SetAdditionalCosts = dt.Rows(0).Item("AdditionalCosts")
                        oQuoteJob.SetAsbestosComment = dt.Rows(0).Item("AsbestosComment")
                        oQuoteJob.EstStartDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("EstStartDate"))
                        oQuoteJob.SetSurveyVisitID = dt.Rows(0).Item("SurveyVisitID")
                        If dt.Columns.Contains("Department") Then oQuoteJob.SetDepartment = Sys.Helper.MakeStringValid(dt.Rows(0)("Department"))
                        ' oQuoteJob.QuoteAssets = _database.QuoteJobAsset.QuoteJobAsset_Get_For_QuoteJob_As_Objects(oQuoteJob.QuoteJobID)
                        oQuoteJob.QuoteJobOfWorks = _database.QuoteJobOfWorks.QuoteJobOfWork_Get_For_QuoteJob_As_Objects(oQuoteJob.QuoteJobID)
                        oQuoteJob.QuoteJobPartsAndProducts = Get_Parts_And_Products_For_QuoteJobID(QuoteJobID)
                        oQuoteJob.ScheduleOfRates = GetQuoteJobScheduleOfRate(QuoteJobID)
                        oQuoteJob.Exists = True
                        Return oQuoteJob
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Get_Parts_And_Products_For_QuoteJobID(ByVal QuoteJobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteJob_GetAll_Parts_And_Products_For_QuoteJobID")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
                Return New DataView(dt)
            End Function

            Public Function QuoteJob_Create_Install(ByVal SiteID As Integer, ByVal Surveyor As String, ByVal NotesToengineer As String,
                                                    ByVal NotesToBuilder As String, ByVal NotesToElectrician As String, ByVal Department As String, ByVal QuoteJobID As Integer,
                                                    ByVal Electrician As Boolean, ByVal Builder As Boolean, ByVal Service As Boolean, ByVal HandOver As Boolean,
                                                    ByVal ElectricianCost As Double, ByVal builderCost As Double) As String
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID)
                _database.AddParameter("@Surveyor", Surveyor)
                _database.AddParameter("@NotesToengineer", NotesToengineer, True)
                _database.AddParameter("@NotesToBuilder", NotesToBuilder, True)
                _database.AddParameter("@NotesToElectrician", NotesToElectrician, True)
                _database.AddParameter("@Department", Department)
                _database.AddParameter("@QuoteJobID", QuoteJobID)
                _database.AddParameter("@Electrician", Electrician)
                _database.AddParameter("@Builder", Builder)
                _database.AddParameter("@Service", Service)
                _database.AddParameter("@HandOver", HandOver)
                _database.AddParameter("@ElectricianCost", ElectricianCost)
                _database.AddParameter("@BuilderCost", builderCost)

                Return _database.ExecuteSP_OBJECT("QuoteJob_Create_Install")

            End Function

            Public Function Insert(ByVal qJob As QuoteJob) As QuoteJob
                _database.ClearParameter()
                _database.AddParameter("@Reference", qJob.Reference, True)
                _database.AddParameter("@SiteID", qJob.SiteID, True)
                _database.AddParameter("@JobDefinitionEnumID", qJob.JobDefinitionEnumID, True)
                _database.AddParameter("@JobTypeID", qJob.JobTypeID, True)
                _database.AddParameter("@StatusEnumID", qJob.StatusEnumID, True)
                _database.AddParameter("@DateCreated", qJob.DateCreated, True)
                _database.AddParameter("@CreatedByUserID", loggedInUser.UserID, True)
                _database.AddParameter("@PartsAndProductsTotal", qJob.PartsAndProductsTotal, True)
                _database.AddParameter("@GrandTotal", qJob.GrandTotal, True)
                _database.AddParameter("@PartsAndProductsMarkup", qJob.PartsAndProductsMarkup, True)
                _database.AddParameter("@ScheduleOfRatesMarkup", qJob.ScheduleOfRatesMarkup, True)
                _database.AddParameter("@ScheduleOfRatesTotal", qJob.ScheduleOfRatesTotal, True)
                _database.AddParameter("@EstimatedMileage", qJob.EstimatedMileage, True)
                _database.AddParameter("@MileageRate", qJob.MileageRate, True)
                _database.AddParameter("@NotesToEngineer", qJob.NotesToEngineer, True)
                _database.AddParameter("@NotesToElectrician", qJob.NotesToElectrician, True)
                _database.AddParameter("@NotesToBuilder", qJob.NotesToBuilder, True)
                _database.AddParameter("@EngineerLabourHrs", qJob.EngineerLabourHrs, True)
                _database.AddParameter("@ElectricianLabourHrs", qJob.ElectricianLabourHrs, True)
                _database.AddParameter("@BuilderLabourHrs", qJob.BuilderLabourHrs, True)
                _database.AddParameter("@EngineerMarkUp", qJob.EngineerMarkUp, True)
                _database.AddParameter("@ElectricianMarkUp", qJob.ElectricianMarkUp, True)
                _database.AddParameter("@BuilderMarkUp", qJob.BuilderMarkUp, True)
                _database.AddParameter("@ElectricianArrivalDayNo", qJob.ElectricianArrivalDayNo, True)
                _database.AddParameter("@ElectricianArrivalHour", qJob.ElectricianArrivalHour, True)
                _database.AddParameter("@BuilderArrivalDayNo", qJob.BuilderArrivalDayNo, True)
                _database.AddParameter("@BuilderArrivalHour", qJob.BuilderArrivalHour, True)
                _database.AddParameter("@PartsCost", qJob.PartsCost, True)
                _database.AddParameter("@EngineerCost", qJob.EngineerCost, True)
                _database.AddParameter("@BuilderCost", qJob.BuilderCost, True)
                _database.AddParameter("@ElectricianCost", qJob.ElectricianCost, True)
                _database.AddParameter("@QuotedAmount", qJob.QuotedAmount, True)
                _database.AddParameter("@DepositAmount", qJob.DepositAmount, True)
                _database.AddParameter("@VATRateID", qJob.VatRateID, True)
                _database.AddParameter("@ChangedDateTime", qJob.ChangedDateTime, True)
                _database.AddParameter("@ChangedByUserID", qJob.ChangedByUserID, True)
                _database.AddParameter("@OriginalQuotedAmount", qJob.OriginalQuotedAmount, True)
                _database.AddParameter("@ElectricianPackTypeID", qJob.ElectricianPackTypeID, True)
                _database.AddParameter("@SORCharge", qJob.SORCharge, True)
                _database.AddParameter("@AccessEquipmentID", qJob.AccessEquipmentID, True)
                _database.AddParameter("@AsbestosID", qJob.AsbestosID, True)
                _database.AddParameter("@AdditionalCosts", qJob.AdditionalCosts, True)
                _database.AddParameter("@AsbestosComment", qJob.AsbestosComment, True)
                _database.AddParameter("@EstStartDate", qJob.EstStartDate, True)
                _database.AddParameter("@SurveyVisitID", qJob.SurveyVisitID, True)
                _database.AddParameter("@Department", qJob.Department, True)

                qJob.SetQuoteJobID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJob_Insert2"))
                qJob.Exists = True

                For Each qasset As Entity.QuoteJobAssets.QuoteJobAsset In qJob.QuoteAssets
                    qasset.SetQuoteJobID = qJob.QuoteJobID
                    qasset = _database.QuoteJobAsset.Insert(qasset)
                Next

                For Each qjobOfWork As Entity.QuoteJobOfWorks.QuoteJobOfWork In qJob.QuoteJobOfWorks
                    qjobOfWork.SetQuoteJobID = qJob.QuoteJobID
                    qjobOfWork = _database.QuoteJobOfWorks.Insert(qjobOfWork)

                    For Each qjobItem As Entity.QuoteJobItems.QuoteJobItem In qjobOfWork.QuoteJobItems
                        qjobItem.SetQuoteJobOfWorkID = qjobOfWork.QuoteJobOfWorkID
                        qjobItem = _database.QuoteJobItems.Insert(qjobItem)
                    Next

                    For Each qengineerVisit As Entity.QuoteEngineerVisits.QuoteEngineerVisit In qjobOfWork.QuoteEngineerVisits
                        qengineerVisit.SetQuoteJobOfWorkID = qjobOfWork.QuoteJobOfWorkID
                        qengineerVisit = _database.QuoteEngineerVisits.Insert(qengineerVisit)
                    Next
                Next

                For Each row As DataRow In qJob.QuoteJobPartsAndProducts.Table.Rows
                    If row.Item("Type") = "Part" Then
                        Dim oQuoteJobPart As New QuoteJobPartss.QuoteJobParts
                        oQuoteJobPart.SetQuoteJobID = qJob.QuoteJobID
                        oQuoteJobPart.SetPartID = row.Item("ID")
                        oQuoteJobPart.SetQuantity = row.Item("Quantity")
                        oQuoteJobPart.SetSellPrice = row.Item("SellPrice")
                        oQuoteJobPart.SetBuyPrice = row.Item("BuyPrice")
                        oQuoteJobPart.SetExtra = row.Item("Extra")
                        oQuoteJobPart.SetPartSupplierID = row.Item("PartSupplierID")
                        oQuoteJobPart.SetSpecialDescription = row.Item("SpecialDescription")
                        oQuoteJobPart.SetSpecialCost = row.Item("SpecialCost")

                        _database.QuoteJobParts.Insert(oQuoteJobPart)

                    End If
                Next

                qJob.QuoteJobPartsAndProducts = Get_Parts_And_Products_For_QuoteJobID(qJob.QuoteJobID)

                SaveRates(qJob)

                Return qJob
            End Function

            Private Sub SaveRates(ByVal oQuoteJob As QuoteJob)
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", oQuoteJob.QuoteJobID, True)
                _database.ExecuteSP_NO_Return("QuoteJobScheduleOfRate_Delete")

                For Each r As DataRow In oQuoteJob.ScheduleOfRates.Table.Rows
                    _database.ClearParameter()
                    _database.AddParameter("@QuoteJobID", oQuoteJob.QuoteJobID, True)
                    _database.AddParameter("@ScheduleOfRatesCategoryID", r("ScheduleOfRatesCategoryID"), True)
                    _database.AddParameter("@Code", r("Code"), True)
                    _database.AddParameter("@Description", r("Description"), True)
                    _database.AddParameter("@Price", r("Price"), True)
                    _database.AddParameter("@Quantity", r("Quantity"), True)
                    _database.AddParameter("@RateID", r("RateID"), True)
                    _database.AddParameter("@TimeInMins", r("TimeInMins"), True)

                    _database.ExecuteSP_NO_Return("QuoteJobScheduleOfRate_Insert")
                Next
            End Sub

            Private Function GetQuoteJobScheduleOfRate(ByVal QuoteJobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteJobScheduleOfRate_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function Update(ByVal qJob As QuoteJob) As QuoteJob
                _database.ClearParameter()
                _database.AddParameter("@Reference", qJob.Reference, True)
                _database.AddParameter("@SiteID", qJob.SiteID, True)
                _database.AddParameter("@JobDefinitionEnumID", qJob.JobDefinitionEnumID, True)
                _database.AddParameter("@JobTypeID", qJob.JobTypeID, True)
                _database.AddParameter("@StatusEnumID", qJob.StatusEnumID, True)
                _database.AddParameter("@DateCreated", qJob.DateCreated, True)
                _database.AddParameter("@CreatedByUserID", loggedInUser.UserID, True)
                _database.AddParameter("@PartsAndProductsTotal", qJob.PartsAndProductsTotal, True)
                _database.AddParameter("@GrandTotal", qJob.GrandTotal, True)
                _database.AddParameter("@ReasonForReject", qJob.ReasonForReject, True)
                _database.AddParameter("@ReasonForRejectID", qJob.ReasonForRejectID, True)
                _database.AddParameter("@QuoteJobID", qJob.QuoteJobID, True)
                _database.AddParameter("@PartsAndProductsMarkup", qJob.PartsAndProductsMarkup, True)
                _database.AddParameter("@ScheduleOfRatesMarkup", qJob.ScheduleOfRatesMarkup, True)
                _database.AddParameter("@ScheduleOfRatesTotal", qJob.ScheduleOfRatesTotal, True)
                _database.AddParameter("@EstimatedMileage", qJob.EstimatedMileage, True)
                _database.AddParameter("@MileageRate", qJob.MileageRate, True)
                _database.AddParameter("@NotesToEngineer", qJob.NotesToEngineer, True)
                _database.AddParameter("@NotesToElectrician", qJob.NotesToElectrician, True)
                _database.AddParameter("@NotesToBuilder", qJob.NotesToBuilder, True)
                _database.AddParameter("@EngineerLabourHrs", qJob.EngineerLabourHrs, True)
                _database.AddParameter("@ElectricianLabourHrs", qJob.ElectricianLabourHrs, True)
                _database.AddParameter("@BuilderLabourHrs", qJob.BuilderLabourHrs, True)
                _database.AddParameter("@EngineerMarkUp", qJob.EngineerMarkUp, True)
                _database.AddParameter("@ElectricianMarkUp", qJob.ElectricianMarkUp, True)
                _database.AddParameter("@BuilderMarkUp", qJob.BuilderMarkUp, True)
                _database.AddParameter("@ElectricianArrivalDayNo", qJob.ElectricianArrivalDayNo, True)
                _database.AddParameter("@ElectricianArrivalHour", qJob.ElectricianArrivalHour, True)
                _database.AddParameter("@BuilderArrivalDayNo", qJob.BuilderArrivalDayNo, True)
                _database.AddParameter("@BuilderArrivalHour", qJob.BuilderArrivalHour, True)
                _database.AddParameter("@PartsCost", qJob.PartsCost, True)
                _database.AddParameter("@EngineerCost", qJob.EngineerCost, True)
                _database.AddParameter("@BuilderCost", qJob.BuilderCost, True)
                _database.AddParameter("@ElectricianCost", qJob.ElectricianCost, True)
                _database.AddParameter("@QuotedAmount", qJob.QuotedAmount, True)
                _database.AddParameter("@DepositAmount", qJob.DepositAmount, True)
                _database.AddParameter("@VATRateID", qJob.VatRateID, True)
                _database.AddParameter("@ChangedDateTime", qJob.ChangedDateTime, True)
                _database.AddParameter("@ChangedByUserID", qJob.ChangedByUserID, True)
                _database.AddParameter("@OriginalQuotedAmount", qJob.OriginalQuotedAmount, True)
                _database.AddParameter("@ElectricianPackTypeID", qJob.ElectricianPackTypeID, True)
                _database.AddParameter("@SORCharge", qJob.SORCharge, True)
                _database.AddParameter("@AccessEquipmentID", qJob.AccessEquipmentID, True)
                _database.AddParameter("@AsbestosID", qJob.AsbestosID, True)
                _database.AddParameter("@AdditionalCosts", qJob.AdditionalCosts, True)
                _database.AddParameter("@AsbestosComment", qJob.AsbestosComment, True)
                _database.AddParameter("@Department", qJob.Department, True)
                If qJob.EstStartDate = Date.MinValue Then
                    _database.AddParameter("@EstStartDate", DBNull.Value, True)
                Else
                    _database.AddParameter("@EstStartDate", Entity.Sys.Helper.MakeDateTimeValid(qJob.EstStartDate), True)
                End If
                _database.AddParameter("@SurveyVisitID", qJob.SurveyVisitID, True)

                _database.ExecuteSP_NO_Return("QuoteJob_Update")

                _database.QuoteJobAsset.Delete(qJob.QuoteJobID)
                For Each qAsset As Entity.QuoteJobAssets.QuoteJobAsset In qJob.QuoteAssets
                    qAsset.SetQuoteJobID = qJob.QuoteJobID
                    qAsset = _database.QuoteJobAsset.Insert(qAsset)
                Next

                For Each qJobOfWork As Entity.QuoteJobOfWorks.QuoteJobOfWork In qJob.QuoteJobOfWorks
                    qJobOfWork.SetQuoteJobID = qJob.QuoteJobID
                    If Not qJobOfWork.Exists Then
                        qJobOfWork = _database.QuoteJobOfWorks.Insert(qJobOfWork)
                        For Each qJobItem As Entity.QuoteJobItems.QuoteJobItem In qJobOfWork.QuoteJobItems
                            qJobItem.SetQuoteJobOfWorkID = qJobOfWork.QuoteJobOfWorkID
                            qJobItem = _database.QuoteJobItems.Insert(qJobItem)
                        Next
                    Else
                        _database.QuoteJobItems.Delete(qJobOfWork.QuoteJobOfWorkID)
                        For Each qJobItem As Entity.QuoteJobItems.QuoteJobItem In qJobOfWork.QuoteJobItems
                            qJobItem.SetQuoteJobOfWorkID = qJobOfWork.QuoteJobOfWorkID
                            qJobItem = _database.QuoteJobItems.Insert(qJobItem)
                        Next
                    End If
                Next

                _database.QuoteJobParts.Delete(qJob.QuoteJobID)
                _database.QuoteJobProducts.Delete(qJob.QuoteJobID)

                For Each row As DataRow In qJob.QuoteJobPartsAndProducts.Table.Rows
                    If row.Item("Type") = "Part" Then
                        Dim oQuoteJobPart As New QuoteJobPartss.QuoteJobParts
                        oQuoteJobPart.SetQuoteJobID = qJob.QuoteJobID
                        oQuoteJobPart.SetPartID = row.Item("ID")
                        oQuoteJobPart.SetQuantity = row.Item("Quantity")
                        oQuoteJobPart.SetSellPrice = row.Item("SellPrice")
                        oQuoteJobPart.SetBuyPrice = row.Item("BuyPrice")
                        oQuoteJobPart.SetExtra = row.Item("Extra")
                        oQuoteJobPart.SetPartSupplierID = row.Item("PartSupplierID")
                        oQuoteJobPart.SetSpecialDescription = row.Item("SpecialDescription")
                        oQuoteJobPart.SetSpecialCost = row.Item("SpecialCost")

                        _database.QuoteJobParts.Insert(oQuoteJobPart)
                    End If

                Next

                qJob.QuoteJobPartsAndProducts = Get_Parts_And_Products_For_QuoteJobID(qJob.QuoteJobID)

                SaveRates(qJob)

                _database.QuoteJobParts.DeleteAll(qJob.QuoteJobID)

                Return qJob
            End Function

            Public Sub Delete(ByVal QuoteJobID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID, True)
                _database.ExecuteSP_NO_Return("QuoteJob_Delete")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace