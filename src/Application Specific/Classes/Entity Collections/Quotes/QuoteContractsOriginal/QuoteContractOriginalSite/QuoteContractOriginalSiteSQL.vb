Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOriginalSites

        Public Class QuoteContractOriginalSiteSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Get](ByVal QuoteContractSiteID As Integer) As QuoteContractOriginalSite
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOriginalSite_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oQuoteContractSite As New QuoteContractOriginalSite
                        With oQuoteContractSite
                            .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteContractSiteID = dt.Rows(0).Item("QuoteContractSiteID")
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                            .SetSiteID = dt.Rows(0).Item("SiteID")
                            .SetPricePerVisit = dt.Rows(0).Item("PricePerVisit")
                            .SetVisitFrequencyID = dt.Rows(0).Item("VisitFrequencyID")
                            .SetVisitDuration = dt.Rows(0).Item("VisitDuration")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetIncludeAssetPrice = dt.Rows(0).Item("IncludeAssetPrice")
                            .SetAverageMileage = dt.Rows(0).Item("AverageMileage")
                            .SetPricePerMile = dt.Rows(0).Item("PricePerMile")
                            .SetIncludeMileagePrice = dt.Rows(0).Item("IncludeMileagePrice")
                            .SetIncludeRates = dt.Rows(0).Item("IncludeRates")
                            .SetTotalSitePrice = dt.Rows(0).Item("TotalSitePrice")
                            .ContractSiteScheduleOfRates = GetQuoteContractOriginalSiteScheduleOfRate(.QuoteContractSiteID)
                        End With
                        oQuoteContractSite.Exists = True
                        Return oQuoteContractSite
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function GetAll_QuoteContractID(ByVal QuoteContractID As Integer, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOriginalSite_GetAll_QuoteContractID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString
                Return New DataView(dt)
            End Function

            Public Function GetQuoteContractOriginalSiteScheduleOfRate(ByVal QuoteContractSiteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOriginalSiteScheduleOfRate_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSiteScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oQuoteContractSite As QuoteContractOriginalSite) As QuoteContractOriginalSite
                _database.ClearParameter()
                AddQuoteContractSiteParametersToCommand(oQuoteContractSite)

                oQuoteContractSite.SetQuoteContractSiteID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOriginalSite_Insert"))
                oQuoteContractSite.Exists = True
                SaveRates(oQuoteContractSite)
                Return oQuoteContractSite
            End Function

            Public Sub Update(ByVal oQuoteContractSite As QuoteContractOriginalSite)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", oQuoteContractSite.QuoteContractSiteID, True)
                AddQuoteContractSiteParametersToCommand(oQuoteContractSite)
                _database.ExecuteSP_NO_Return("QuoteContractOriginalSite_Update")
                SaveRates(oQuoteContractSite)
            End Sub

            Public Sub Delete(ByVal QuoteContractSiteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)
                _database.ExecuteSP_NO_Return("QuoteContractOriginalSite_Delete")
            End Sub

            Private Sub AddQuoteContractSiteParametersToCommand(ByRef oQuoteContractSite As QuoteContractOriginalSite)
                With _database
                    .AddParameter("@QuoteContractID", oQuoteContractSite.QuoteContractID, True)
                    .AddParameter("@SiteID", oQuoteContractSite.SiteID, True)
                    .AddParameter("@PricePerVisit", oQuoteContractSite.PricePerVisit, True)
                    .AddParameter("@VisitFrequencyID", oQuoteContractSite.VisitFrequencyID, True)
                    .AddParameter("@VisitDuration", oQuoteContractSite.VisitDuration, True)
                    .AddParameter("@IncludeAssetPrice", oQuoteContractSite.IncludeAssetPrice, True)
                    .AddParameter("@AverageMileage", oQuoteContractSite.AverageMileage, True)
                    .AddParameter("@PricePerMile", oQuoteContractSite.PricePerMile, True)
                    .AddParameter("@IncludeMileagePrice", oQuoteContractSite.IncludeMileagePrice, True)
                    .AddParameter("@IncludeRates", oQuoteContractSite.IncludeRates, True)
                    .AddParameter("@TotalSitePrice", oQuoteContractSite.TotalSitePrice, True)
                End With
            End Sub

            Private Sub SaveRates(ByVal oQuoteContractSite As QuoteContractOriginalSite)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", oQuoteContractSite.QuoteContractSiteID, True)
                _database.ExecuteSP_NO_Return("QuoteContractOriginalSiteScheduleOfRate_Delete")

                If Not oQuoteContractSite.ContractSiteScheduleOfRates Is Nothing Then
                    For Each r As DataRow In oQuoteContractSite.ContractSiteScheduleOfRates.Table.Rows
                        _database.ClearParameter()
                        _database.AddParameter("@QuoteContractSiteID", oQuoteContractSite.QuoteContractSiteID, True)
                        _database.AddParameter("@ScheduleOfRatesCategoryID", r("ScheduleOfRatesCategoryID"), True)
                        _database.AddParameter("@Code", r("Code"), True)
                        _database.AddParameter("@Description", r("Description"), True)
                        _database.AddParameter("@Price", r("Price"), True)
                        _database.AddParameter("@QtyPerVisit", r("QtyPerVisit"), True)
                        _database.ExecuteSP_NO_Return("QuoteContractOriginalSiteScheduleOfRate_Insert")

                    Next
                End If

            End Sub
#End Region

        End Class

    End Namespace

End Namespace


