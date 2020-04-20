Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternativeSites

        Public Class QuoteContractAlternativeSiteSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Get](ByVal QuoteContractSiteID As Integer) As QuoteContractAlternativeSite
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSite_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oQuoteContractSite As New QuoteContractAlternativeSite
                        With oQuoteContractSite
                            .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteContractSiteID = dt.Rows(0).Item("QuoteContractSiteID")
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                            .SetSiteID = dt.Rows(0).Item("SiteID")
                            .JobOfWorks = _database.QuoteContractAlternativeSiteJobOfWork.Get_For_QuoteContractSite_As_Objects(QuoteContractSiteID)
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

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSite_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_QuoteContractID(ByVal QuoteContractID As Integer, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID, True)
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSite_GetAll_QuoteContractID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractSite.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oQuoteContractSite As QuoteContractAlternativeSite) As QuoteContractAlternativeSite
                _database.ClearParameter()
                AddContractSiteParametersToCommand(oQuoteContractSite)

                oQuoteContractSite.SetQuoteContractSiteID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_Insert"))
                oQuoteContractSite.Exists = True
                Return oQuoteContractSite
            End Function

            Public Sub Update(ByVal oQuoteContractSite As QuoteContractAlternativeSite)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", oQuoteContractSite.QuoteContractSiteID, True)
                AddContractSiteParametersToCommand(oQuoteContractSite)
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSite_Update")
            End Sub

            Public Function Delete(ByVal QuoteContractSiteID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)
                 Return _database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_Delete")
            End Function

            Public Function ActiveInactive(ByVal QuoteContractSiteID As Integer, ByVal InactiveFlag As Boolean) As Integer
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)
                _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
                _database.AddParameter("@InactiveFlag", InactiveFlag, True)
                Return _database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_ActiveInactive")
            End Function

            Private Sub AddContractSiteParametersToCommand(ByRef oQuoteContractSite As QuoteContractAlternativeSite)
                With _database
                    .AddParameter("@QuoteContractID", oQuoteContractSite.QuoteContractID, True)
                    .AddParameter("@SiteID", oQuoteContractSite.SiteID, True)
                End With
            End Sub

#End Region


        End Class

    End Namespace

End Namespace


