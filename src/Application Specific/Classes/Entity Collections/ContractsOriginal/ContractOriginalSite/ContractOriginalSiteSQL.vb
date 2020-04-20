Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOriginalSites

        Public Class ContractOriginalSiteSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Get](ByVal ContractSiteID As Integer) As ContractOriginalSite
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSite_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContractSite As New ContractOriginalSite
                        With oContractSite
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractSiteID = dt.Rows(0).Item("ContractSiteID")
                            .SetContractID = dt.Rows(0).Item("ContractID")
                            .SetPropertyID = dt.Rows(0).Item("SiteID")
                            .SetPricePerVisit = dt.Rows(0).Item("PricePerVisit")
                            .FirstVisitDate = CDate(dt.Rows(0).Item("FirstVisitDate"))
                            .SetVisitFrequencyID = dt.Rows(0).Item("VisitFrequencyID")
                            .SetVisitDuration = dt.Rows(0).Item("VisitDuration")
                            .SetAverageMileage = dt.Rows(0).Item("AverageMileage")
                            .SetIncludeAssetPrice = dt.Rows(0).Item("IncludeAssetPrice")
                            .SetIncludeMileagePrice = dt.Rows(0).Item("IncludeMileagePrice")
                            .SetPricePerMile = dt.Rows(0).Item("PricePerMile")
                            .SetTotalSitePrice = dt.Rows(0).Item("TotalSitePrice")
                            .SetIncludeRates = dt.Rows(0).Item("IncludeRates")
                            .SetLLCertReqd = dt.Rows(0).Item("LLCertReqd")
                            .SetAdditionalNotes = dt.Rows(0).Item("AdditionalNotes")
                            .SetCommercial = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Commercial"))
                            .SetMainAppliances = (dt.Rows(0).Item("MainAppliances"))
                            .SetSecondryAppliances = (dt.Rows(0).Item("SecondryAppliances"))
                            .ContractSiteScheduleOfRates = DB.ContractOriginalSiteRates.ContractOriginalSiteRates_GetForContractSite(.ContractSiteID)
                        End With
                        oContractSite.Exists = True
                        Return oContractSite
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSite_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSite.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_ContractID(ByVal ContractID As Integer, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSite_GetAll_ContractID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSite.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_ContractID2(ByVal ContractID As Integer, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSite_GetAll_ContractID2")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSite.ToString
                Return New DataView(dt)
            End Function

            Private Function GetContractOriginalSiteScheduleOfRate(ByVal ContractSiteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSiteScheduleOfRate_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oContractSite As ContractOriginalSite) As ContractOriginalSite
                _database.ClearParameter()
                AddContractSiteParametersToCommand(oContractSite)

                oContractSite.SetContractSiteID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalSite_Insert"))
                oContractSite.Exists = True
                'SaveRates(oContractSite)
                Return oContractSite
            End Function

            Public Sub Update(ByVal oContractSite As ContractOriginalSite)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", oContractSite.ContractSiteID, True)
                AddContractSiteParametersToCommand(oContractSite)
                _database.ExecuteSP_NO_Return("ContractOriginalSite_Update")
                'SaveRates(oContractSite)
            End Sub

            Public Function Delete(ByVal ContractSiteID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
                Return _database.ExecuteSP_OBJECT("ContractOriginalSite_Delete")
            End Function

            Public Function ActiveInactive(ByVal ContractSiteID As Integer, ByVal InactiveFlag As Boolean) As Integer
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Scheduled), True)
                _database.AddParameter("@InactiveFlag", InactiveFlag, True)
                Return _database.ExecuteSP_OBJECT("ContractOriginalSite_ActiveInactive")
            End Function

            Public Sub Delete_Visits(ByVal ContractSiteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.ExecuteSP_OBJECT("ContractOriginalSite_Visits_Delete")
            End Sub

            Private Sub AddContractSiteParametersToCommand(ByRef oContractSite As ContractOriginalSite)
                With _database
                    .AddParameter("@ContractID", oContractSite.ContractID, True)
                    .AddParameter("@SiteID", oContractSite.PropertyID, True)
                    .AddParameter("@PricePerVisit", oContractSite.PricePerVisit, True)
                    .AddParameter("@FirstVisitDate", oContractSite.FirstVisitDate, True)
                    .AddParameter("@VisitFrequencyID", oContractSite.VisitFrequencyID, True)
                    .AddParameter("@VisitDuration", oContractSite.VisitDuration, True)
                    .AddParameter("@AverageMileage", oContractSite.AverageMileage, True)
                    .AddParameter("@IncludeAssetPrice", oContractSite.IncludeAssetPrice, True)
                    .AddParameter("@IncludeMileagePrice", oContractSite.IncludeMileagePrice, True)
                    .AddParameter("@PricePerMile", oContractSite.PricePerMile, True)
                    .AddParameter("@TotalSitePrice", oContractSite.TotalSitePrice, True)
                    .AddParameter("@IncludeRates", oContractSite.IncludeRates, True)
                    .AddParameter("@LLCertReqd", oContractSite.LLCertReqd, True)
                    .AddParameter("@AdditionalNotes", oContractSite.AdditionalNotes, True)
                    .AddParameter("@Commercial", oContractSite.Commercial, True)
                    .AddParameter("@MainAppliances", oContractSite.MainAppliances, True)
                    .AddParameter("@SecondryAppliances", oContractSite.SecondryAppliances, True)
                End With
            End Sub

            Private Sub SaveRates(ByVal oContractSite As ContractOriginalSite)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", oContractSite.ContractSiteID, True)
                _database.ExecuteSP_NO_Return("ContractOriginalSiteScheduleOfRate_Delete")

                If Not oContractSite.ContractSiteScheduleOfRates Is Nothing Then
                    For Each r As DataRow In oContractSite.ContractSiteScheduleOfRates.Table.Rows
                        _database.ClearParameter()
                        _database.AddParameter("@ContractSiteID", oContractSite.ContractSiteID, True)
                        _database.AddParameter("@ScheduleOfRatesCategoryID", r("ScheduleOfRatesCategoryID"), True)
                        _database.AddParameter("@Code", r("Code"), True)
                        _database.AddParameter("@Description", r("Description"), True)
                        _database.AddParameter("@Price", r("Price"), True)
                        _database.AddParameter("@QtyPerVisit", r("QtyPerVisit"), True)
                        _database.ExecuteSP_NO_Return("ContractOriginalSiteScheduleOfRate_Insert")

                    Next
                End If

            End Sub

#End Region

        End Class

    End Namespace

End Namespace


