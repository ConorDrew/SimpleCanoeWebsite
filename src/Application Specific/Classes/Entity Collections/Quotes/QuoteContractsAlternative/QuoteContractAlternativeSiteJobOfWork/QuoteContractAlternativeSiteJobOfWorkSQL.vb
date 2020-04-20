Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternativeSiteJobOfWorks

        Public Class QuoteContractAlternativeSiteJobOfWorkSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Sub Delete(ByVal QuoteContractSiteJobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, True)
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobOfWork_Delete")
            End Sub

            Public Function [ContractAlternativeSiteJobOfWork_Get](ByVal QuoteContractSiteJobOfWorkID As Integer) As QuoteContractAlternativeSiteJobOfWork
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobOfWork_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oQuoteContractAlternativeSiteJobOfWork As New QuoteContractAlternativeSiteJobOfWork
                        With oQuoteContractAlternativeSiteJobOfWork
                            .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteContractSiteJobOfWorkID = dt.Rows(0).Item("QuoteContractSiteJobOfWorkID")
                            .SetQuoteContractSiteID = dt.Rows(0).Item("QuoteContractSiteID")
                            .FirstVisitDate = CDate(dt.Rows(0).Item("FirstVisitDate"))
                            .SetAverageMileage = dt.Rows(0).Item("AverageMileage")
                            .SetIncludeMileagePrice = dt.Rows(0).Item("IncludeMileagePrice")
                            .SetIncludeRates = dt.Rows(0).Item("IncludeRates")
                            .SetPricePerMile = dt.Rows(0).Item("PricePerMile")
                            .SetPricePerVisit = dt.Rows(0).Item("PricePerVisit")
                            .SetTotalSitePrice = dt.Rows(0).Item("TotalSitePrice")
                        End With
                        oQuoteContractAlternativeSiteJobOfWork.Exists = True
                        Return oQuoteContractAlternativeSiteJobOfWork
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Get_For_QuoteContractSite_As_Objects(ByVal QuoteContractSiteID As Integer) As ArrayList
                Dim jobOfWorks As New ArrayList
                For Each row As DataRow In JobOfWork_Get_For_QuoteContract(QuoteContractSiteID).Table.Rows
                    Dim jobOfWork As New QuoteContractAlternativeSiteJobOfWorks.QuoteContractAlternativeSiteJobOfWork
                    jobOfWork.IgnoreExceptionsOnSetMethods = True
                    jobOfWork.Exists = True
                    jobOfWork.SetQuoteContractSiteID = row.Item("QuoteContractSiteID")
                    jobOfWork.SetQuoteContractSiteJobOfWorkID = row.Item("QuoteContractSiteJobOfWorkID")
                    jobOfWork.FirstVisitDate = row.Item("FirstVisitDate")
                    jobOfWork.SetAverageMileage = row.Item("AverageMileage")
                    jobOfWork.SetIncludeMileagePrice = row.Item("IncludeMileagePrice")
                    jobOfWork.SetIncludeRates = row.Item("IncludeRates")
                    jobOfWork.SetPricePerMile = row.Item("PricePerMile")
                    jobOfWork.SetPricePerVisit = row.Item("PricePerVisit")
                    jobOfWork.SetTotalSitePrice = row.Item("TotalSitePrice")
                    ''THIS IS A STUPID WORK AROUND ONLY USED IN THE CONVERTION -AMY
                    jobOfWork.ScheduledOfRates_UsedForConvertOnly = GetJobOfWorkScheduleOfRates(jobOfWork.QuoteContractSiteJobOfWorkID)
                    ''''--------------------------

                    jobOfWorks.Add(jobOfWork)
                Next

                Return jobOfWorks
            End Function

            Public Function JobOfWork_Get_For_QuoteContract(ByVal QuoteContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobOfWork_Get_For_QuoteContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobOfWork.ToString
                Return New DataView(dt)
            End Function

            Public Function [QuoteContractAlternativeSiteJobOfWork_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobOfWork_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobOfWork.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oQuoteContractAlternativeSiteJobOfWork As QuoteContractAlternativeSiteJobOfWork) As QuoteContractAlternativeSiteJobOfWork
                _database.ClearParameter()
                AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(oQuoteContractAlternativeSiteJobOfWork)

                oQuoteContractAlternativeSiteJobOfWork.SetQuoteContractSiteJobOfWorkID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteJobOfWork_Insert"))
                oQuoteContractAlternativeSiteJobOfWork.Exists = True
                Return oQuoteContractAlternativeSiteJobOfWork
            End Function

            Public Sub [Update](ByVal oQuoteContractAlternativeSiteJobOfWork As QuoteContractAlternativeSiteJobOfWork, ByVal oRates As DataView)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteJobOfWorkID, True)
                AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(oQuoteContractAlternativeSiteJobOfWork)
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobOfWork_Update")
                SaveRates(oRates, oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteJobOfWorkID)
            End Sub

            Private Sub AddQuoteContractAlternativeSiteJobOfWorkParametersToCommand(ByRef oQuoteContractAlternativeSiteJobOfWork As QuoteContractAlternativeSiteJobOfWork)
                With _database
                    .AddParameter("@QuoteContractSiteID", oQuoteContractAlternativeSiteJobOfWork.QuoteContractSiteID, True)
                    .AddParameter("@FirstVisitDate", oQuoteContractAlternativeSiteJobOfWork.FirstVisitDate, True)
                    .AddParameter("@PricePerVisit", oQuoteContractAlternativeSiteJobOfWork.PricePerVisit, True)
                    .AddParameter("@AverageMileage", oQuoteContractAlternativeSiteJobOfWork.AverageMileage, True)
                    .AddParameter("@IncludeMileagePrice", oQuoteContractAlternativeSiteJobOfWork.IncludeMileagePrice, True)
                    .AddParameter("@IncludeRates", oQuoteContractAlternativeSiteJobOfWork.IncludeRates, True)
                    .AddParameter("@PricePerMile", oQuoteContractAlternativeSiteJobOfWork.PricePerMile, True)
                    .AddParameter("@TotalSitePrice", oQuoteContractAlternativeSiteJobOfWork.TotalSitePrice, True)
                End With
            End Sub

            Public Function GetJobOfWorkScheduleOfRates(ByVal QuoteContractSiteJobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeJobOfWorkScheduleOfRate_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Private Sub SaveRates(ByVal oRates As DataView, ByVal QuoteContractSiteJobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, True)
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeJobOfWorkScheduleOfRate_Delete")

                For Each r As DataRow In oRates.Table.Rows
                    _database.ClearParameter()
                    _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, True)
                    _database.AddParameter("@ScheduleOfRatesCategoryID", r("ScheduleOfRatesCategoryID"), True)
                    _database.AddParameter("@Code", r("Code"), True)
                    _database.AddParameter("@Description", r("Description"), True)
                    _database.AddParameter("@Price", r("Price"), True)
                    _database.AddParameter("@QtyPerVisit", r("QtyPerVisit"), True)
                    _database.ExecuteSP_NO_Return("QuoteContractAlternativeJobOfWorkScheduleOfRate_Insert")

                Next
            End Sub

            Public Function JobOfWorks_For_QuoteContractID(ByVal QuoteContractID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeJobOfWorks_For_QuoteContractID")
                dt.TableName = Entity.Sys.Enums.TableNames.NO_TABLE.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace


