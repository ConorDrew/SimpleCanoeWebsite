Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOption3Sites

        Public Class ContractOption3SiteSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function Delete(ByVal ContractSiteID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
                _database.AddParameter("@ContractOpt3Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3), True)
                Return _database.ExecuteSP_OBJECT("ContractOption3Site_Delete")
            End Function

            Public Function [ContractOption3Site_Get](ByVal ContractSiteID As Integer) As ContractOption3Site
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOption3Site_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContractOption3Site As New ContractOption3Site
                        With oContractOption3Site
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractSiteID = dt.Rows(0).Item("ContractSiteID")
                            .SetContractID = dt.Rows(0).Item("ContractID")
                            .SetPropertyID = dt.Rows(0).Item("SiteID")
                            .SetContractSiteReference = dt.Rows(0).Item("ContractSiteReference")
                            .StartDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("StartDate"))
                            .EndDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("EndDate"))
                            .FirstVisitDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("FirstVisitDate"))
                            .SetVisitFrequencyID = dt.Rows(0).Item("VisitFrequencyID")
                            .SetInvoiceFrequencyID = dt.Rows(0).Item("InvoiceFrequencyID")
                            .SetSitePrice = dt.Rows(0).Item("SitePrice")
                            .FirstInvoiceDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("FirstInvoiceDate"))
                            .SetInvoiceAddressID = dt.Rows(0).Item("InvoiceAddressID")
                            .SetInvoiceAddressTypeID = dt.Rows(0).Item("InvoiceAddressTypeID")
                        End With
                        oContractOption3Site.Exists = True
                        Return oContractOption3Site
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [ContractOption3Site_GetAll_ForContract](ByVal ContractID As Integer, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID)
                _database.AddParameter("@CustomerID", CustomerID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOption3Site_GetAll_ForContract")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractOption3Site.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oContractOption3Site As ContractOption3Site) As ContractOption3Site
                _database.ClearParameter()
                AddContractOption3SiteParametersToCommand(oContractOption3Site)

                oContractOption3Site.SetContractSiteID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOption3Site_Insert"))
                oContractOption3Site.Exists = True
                Return oContractOption3Site
            End Function

            Public Sub [Update](ByVal oContractOption3Site As ContractOption3Site)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", oContractOption3Site.ContractSiteID, True)
                AddContractOption3SiteParametersToCommand(oContractOption3Site)
                _database.ExecuteSP_NO_Return("ContractOption3Site_Update")
            End Sub

            Private Sub AddContractOption3SiteParametersToCommand(ByRef oContractOption3Site As ContractOption3Site)
                With _database
                    .AddParameter("@ContractID", oContractOption3Site.ContractID, True)
                    .AddParameter("@SiteID", oContractOption3Site.PropertyID, True)
                    .AddParameter("@ContractSiteReference", oContractOption3Site.ContractSiteReference, True)

                    If oContractOption3Site.StartDate = "#12:00:00 AM#" Then
                        .AddParameter("@StartDate", DBNull.Value, True)
                    Else
                        .AddParameter("@StartDate", oContractOption3Site.StartDate, True)
                    End If

                    If oContractOption3Site.EndDate = "#12:00:00 AM#" Then
                        .AddParameter("@EndDate", DBNull.Value, True)
                    Else
                        .AddParameter("@EndDate", oContractOption3Site.EndDate, True)
                    End If

                    If oContractOption3Site.FirstVisitDate = "#12:00:00 AM#" Then
                        .AddParameter("@FirstVisitDate", DBNull.Value, True)
                    Else
                        .AddParameter("@FirstVisitDate", oContractOption3Site.FirstVisitDate, True)
                    End If

                    .AddParameter("@VisitFrequencyID", oContractOption3Site.VisitFrequencyID, True)
                    .AddParameter("@InvoiceFrequencyID", oContractOption3Site.InvoiceFrequencyID, True)
                    .AddParameter("@SitePrice", oContractOption3Site.SitePrice, True)

                    If oContractOption3Site.FirstInvoiceDate = "#12:00:00 AM#" Then
                        .AddParameter("@FirstInvoiceDate", DBNull.Value, True)
                    Else
                        .AddParameter("@FirstInvoiceDate", oContractOption3Site.FirstInvoiceDate, True)
                    End If
                  
                    .AddParameter("@InvoiceAddressID", oContractOption3Site.InvoiceAddressID, True)
                    .AddParameter("@InvoiceAddressTypeID", oContractOption3Site.InvoiceAddressTypeID, True)
                End With
            End Sub

            Public Function GetNextSiteReference(ByVal ContractID As Integer) As String
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOption3Site_GetLastSiteReference")

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

                Return dt.Rows(0).Item("ContractReference") & postFix
            End Function

            Public Function ActiveInactive(ByVal ContractSiteID As Integer, ByVal InactiveFlag As Boolean) As Integer
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
                _database.AddParameter("@InactiveFlag", InactiveFlag, True)
                Return _database.ExecuteSP_OBJECT("ContractOption3Site_ActiveInactive")
            End Function

#End Region

        End Class

    End Namespace

End Namespace


