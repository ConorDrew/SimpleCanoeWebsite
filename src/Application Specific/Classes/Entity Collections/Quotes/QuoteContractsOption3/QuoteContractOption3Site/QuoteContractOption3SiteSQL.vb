Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOption3Sites

        Public Class QuoteContractOption3SiteSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function Delete(ByVal QuoteContractSiteID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)
                 Return _database.ExecuteSP_OBJECT("QuoteContractOption3Site_Delete")
            End Function

            Public Function [QuoteContractOption3Site_Get](ByVal QuoteContractSiteID As Integer) As QuoteContractOption3Site
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOption3Site_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oQuoteContractOption3Site As New QuoteContractOption3Site
                        With oQuoteContractOption3Site
                            .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteContractSiteID = dt.Rows(0).Item("QuoteContractSiteID")
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                            .SetSiteID = dt.Rows(0).Item("SiteID")
                            .SetQuoteContractSiteReference = dt.Rows(0).Item("QuoteContractSiteReference")
                            .StartDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("StartDate"))
                            .EndDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("EndDate"))
                            .FirstVisitDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("FirstVisitDate"))
                            .SetVisitFrequencyID = dt.Rows(0).Item("VisitFrequencyID")
                            .SetSitePrice = dt.Rows(0).Item("SitePrice")

                        End With
                        oQuoteContractOption3Site.Exists = True
                        Return oQuoteContractOption3Site
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [QuoteContractOption3Site_GetAll_ForQuoteContract](ByVal QuoteContractID As Integer, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID)
                _database.AddParameter("@CustomerID", CustomerID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOption3Site_GetAll_ForQuoteContract")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString
                Return New DataView(dt)
            End Function

            Public Function [QuoteContractOption3Site_GetSelected_ForQuoteContract](ByVal QuoteContractID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOption3Site_GetSelected_ForQuoteContract")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3Site.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oQuoteContractOption3Site As QuoteContractOption3Site) As QuoteContractOption3Site
                _database.ClearParameter()
                AddContractOption3SiteParametersToCommand(oQuoteContractOption3Site)

                oQuoteContractOption3Site.SetQuoteContractSiteID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOption3Site_Insert"))
                oQuoteContractOption3Site.Exists = True
                Return oQuoteContractOption3Site
            End Function

            Public Sub [Update](ByVal oQuoteContractOption3Site As QuoteContractOption3Site)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", oQuoteContractOption3Site.QuoteContractSiteID, True)
                AddContractOption3SiteParametersToCommand(oQuoteContractOption3Site)
                _database.ExecuteSP_NO_Return("QuoteContractOption3Site_Update")
            End Sub

            Private Sub AddContractOption3SiteParametersToCommand(ByRef oQuoteContractOption3Site As QuoteContractOption3Site)
                With _database
                    .AddParameter("@QuoteContractID", oQuoteContractOption3Site.QuoteContractID, True)
                    .AddParameter("@SiteID", oQuoteContractOption3Site.SiteID, True)
                    .AddParameter("@QuoteContractSiteReference", oQuoteContractOption3Site.QuoteContractSiteReference, True)

                    If oQuoteContractOption3Site.StartDate = "#12:00:00 AM#" Then
                        .AddParameter("@StartDate", DBNull.Value, True)
                    Else
                        .AddParameter("@StartDate", oQuoteContractOption3Site.StartDate, True)
                    End If

                    If oQuoteContractOption3Site.EndDate = "#12:00:00 AM#" Then
                        .AddParameter("@EndDate", DBNull.Value, True)
                    Else
                        .AddParameter("@EndDate", oQuoteContractOption3Site.EndDate, True)
                    End If

                    If oQuoteContractOption3Site.FirstVisitDate = "#12:00:00 AM#" Then
                        .AddParameter("@FirstVisitDate", DBNull.Value, True)
                    Else
                        .AddParameter("@FirstVisitDate", oQuoteContractOption3Site.FirstVisitDate, True)
                    End If

                    .AddParameter("@VisitFrequencyID", oQuoteContractOption3Site.VisitFrequencyID, True)
                    .AddParameter("@SitePrice", oQuoteContractOption3Site.SitePrice, True)

                End With
            End Sub

            Public Function GetNextSiteReference(ByVal QuoteContractID As Integer) As String
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOption3Site_GetLastSiteReference")

                Dim lastLetter As String = ""
                Dim nxtLetter As String = ""
                Dim postFix As String = ""

                If IsDBNull(dt.Rows(0).Item("SiteLetter")) Then
                    postFix = "-A"
                Else
                    lastLetter = Right(dt.Rows(0).Item("SiteLetter"), 1)
                    If lastLetter = "Z" Then
                        nxtLetter = "AA"
                    Else
                        nxtLetter = Chr(Asc(lastLetter) + 1)

                    End If
                    postFix = "-" & _
                          Replace(Left(dt.Rows(0).Item("SiteLetter"), Len(dt.Rows(0).Item("SiteLetter")) - 1), "Z", "A") & _
                            nxtLetter

                End If

                Return dt.Rows(0).Item("QuoteContractReference") & postFix
            End Function

            'Public Function ActiveInactive(ByVal QuoteContractSiteID As Integer, ByVal InactiveFlag As Boolean) As Integer
            '    _database.ClearParameter()
            '    _database.AddParameter("@ContractSiteID", ContractSiteID, True)
            '    _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
            '    _database.AddParameter("@InactiveFlag", InactiveFlag, True)
            '    Return _database.ExecuteSP_OBJECT("ContractOption3Site_ActiveInactive")
            'End Function

#End Region

        End Class

    End Namespace

End Namespace


