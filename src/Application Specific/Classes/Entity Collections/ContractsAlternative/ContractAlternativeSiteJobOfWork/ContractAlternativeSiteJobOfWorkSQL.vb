Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractAlternativeSiteJobOfWorks

        Public Class ContractAlternativeSiteJobOfWorkSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Sub Delete(ByVal ContractSiteJobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, True)
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteJobOfWork_Delete")
            End Sub

            Public Function [ContractAlternativeSiteJobOfWork_Get](ByVal ContractSiteJobOfWorkID As Integer) As ContractAlternativeSiteJobOfWork
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobOfWork_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then

                        Dim oContractAlternativeSiteJobOfWork As New ContractAlternativeSiteJobOfWork
                        With oContractAlternativeSiteJobOfWork
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractSiteJobOfWorkID = dt.Rows(0).Item("ContractSiteJobOfWorkID")
                            .SetContractSiteID = dt.Rows(0).Item("ContractSiteID")
                            .FirstVisitDate = CDate(dt.Rows(0).Item("FirstVisitDate"))
                            .SetAverageMileage = dt.Rows(0).Item("AverageMileage")
                            .SetIncludeMileagePrice = dt.Rows(0).Item("IncludeMileagePrice")
                            .SetIncludeRates = dt.Rows(0).Item("IncludeRates")
                            .SetPricePerMile = dt.Rows(0).Item("PricePerMile")
                            .SetPricePerVisit = dt.Rows(0).Item("PricePerVisit")
                            .SetTotalSitePrice = dt.Rows(0).Item("TotalSitePrice")
                        End With
                        oContractAlternativeSiteJobOfWork.Exists = True
                        Return oContractAlternativeSiteJobOfWork
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Get_For_ContractSite_As_Objects(ByVal ContractSiteID As Integer) As ArrayList
                Dim jobOfWorks As New ArrayList
                For Each row As DataRow In JobOfWork_Get_For_Contract(ContractSiteID).Table.Rows
                    Dim jobOfWork As New ContractAlternativeSiteJobOfWorks.ContractAlternativeSiteJobOfWork
                    jobOfWork.IgnoreExceptionsOnSetMethods = True
                    jobOfWork.Exists = True
                    jobOfWork.SetContractSiteID = row.Item("ContractSiteID")
                    jobOfWork.SetContractSiteJobOfWorkID = row.Item("ContractSiteJobOfWorkID")
                    jobOfWork.FirstVisitDate = row.Item("FirstVisitDate")
                    jobOfWork.SetAverageMileage = row.Item("AverageMileage")
                    jobOfWork.SetIncludeMileagePrice = row.Item("IncludeMileagePrice")
                    jobOfWork.SetIncludeRates = row.Item("IncludeRates")
                    jobOfWork.SetPricePerMile = row.Item("PricePerMile")
                    jobOfWork.SetPricePerVisit = row.Item("PricePerVisit")
                    jobOfWork.SetTotalSitePrice = row.Item("TotalSitePrice")
                    jobOfWorks.Add(jobOfWork)
                Next

                Return jobOfWorks
            End Function

            Public Function JobOfWork_Get_For_Contract(ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobOfWork_Get_For_ContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobOfWork.ToString
                Return New DataView(dt)
            End Function

            Public Function [ContractAlternativeSiteJobOfWork_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobOfWork_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobOfWork.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oContractAlternativeSiteJobOfWork As ContractAlternativeSiteJobOfWork) As ContractAlternativeSiteJobOfWork
                _database.ClearParameter()
                AddContractAlternativeSiteJobOfWorkParametersToCommand(oContractAlternativeSiteJobOfWork)

                oContractAlternativeSiteJobOfWork.SetContractSiteJobOfWorkID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativeSiteJobOfWork_Insert"))
                oContractAlternativeSiteJobOfWork.Exists = True
                Return oContractAlternativeSiteJobOfWork
            End Function

            Public Sub [Update](ByVal oContractAlternativeSiteJobOfWork As ContractAlternativeSiteJobOfWork, ByVal oRates As DataView)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobOfWorkID", oContractAlternativeSiteJobOfWork.ContractSiteJobOfWorkID, True)
                AddContractAlternativeSiteJobOfWorkParametersToCommand(oContractAlternativeSiteJobOfWork)
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteJobOfWork_Update")
                SaveRates(oRates, oContractAlternativeSiteJobOfWork.ContractSiteJobOfWorkID)
            End Sub

            Private Sub AddContractAlternativeSiteJobOfWorkParametersToCommand(ByRef oContractAlternativeSiteJobOfWork As ContractAlternativeSiteJobOfWork)
                With _database
                    .AddParameter("@ContractSiteID", oContractAlternativeSiteJobOfWork.ContractSiteID, True)
                    .AddParameter("@FirstVisitDate", oContractAlternativeSiteJobOfWork.FirstVisitDate, True)
                    .AddParameter("@PricePerVisit", oContractAlternativeSiteJobOfWork.PricePerVisit, True)
                    .AddParameter("@AverageMileage", oContractAlternativeSiteJobOfWork.AverageMileage, True)
                    .AddParameter("@IncludeMileagePrice", oContractAlternativeSiteJobOfWork.IncludeMileagePrice, True)
                    .AddParameter("@IncludeRates", oContractAlternativeSiteJobOfWork.IncludeRates, True)
                    .AddParameter("@PricePerMile", oContractAlternativeSiteJobOfWork.PricePerMile, True)
                    .AddParameter("@TotalSitePrice", oContractAlternativeSiteJobOfWork.TotalSitePrice, True)


                End With
            End Sub

            Public Function GetJobOfWorkScheduleOfRates(ByVal ContractSiteJobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeJobOfWorkScheduleOfRate_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
                Return New DataView(dt)
            End Function


            Public Sub SaveRates(ByVal oRates As DataView, ByVal ContractSiteJobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, True)
                _database.ExecuteSP_NO_Return("ContractAlternativeJobOfWorkScheduleOfRate_Delete")

                For Each r As DataRow In oRates.Table.Rows
                    _database.ClearParameter()
                    _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, True)
                    _database.AddParameter("@ScheduleOfRatesCategoryID", r("ScheduleOfRatesCategoryID"), True)
                    _database.AddParameter("@Code", r("Code"), True)
                    _database.AddParameter("@Description", r("Description"), True)
                    _database.AddParameter("@Price", r("Price"), True)
                    _database.AddParameter("@QtyPerVisit", r("QtyPerVisit"), True)
                    _database.ExecuteSP_NO_Return("ContractAlternativeJobOfWorkScheduleOfRate_Insert")

                Next
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


