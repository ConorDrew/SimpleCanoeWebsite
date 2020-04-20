Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternativeSiteJobItems

        Public Class QuoteContractAlternativeSiteJobItemsSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal QuoteContractSiteJobItemID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID, True)
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobItems_Delete")
            End Sub

            Public Function [Get](ByVal QuoteContractSiteJobItemID As Integer) As QuoteContractAlternativeSiteJobItems
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContractAlternativeSiteJobItems As New QuoteContractAlternativeSiteJobItems
                        With oContractAlternativeSiteJobItems
                            .IgnoreExceptionsOnSetMethods = True
                            .SetQuoteContractSiteJobItemID = dt.Rows(0).Item("ContractSiteJobItemID")
                            .SetQuoteContractSiteID = dt.Rows(0).Item("ContractSiteID")
                            .SetDescription = dt.Rows(0).Item("Description")
                            .SetVisitFrequencyID = dt.Rows(0).Item("VisitFrequencyID")
                            .SetVisitDuration = dt.Rows(0).Item("VisitDuration")
                            .SetItemPricePerVisit = dt.Rows(0).Item("PricePerVisit")
                            .SetJobOfWorkID = dt.Rows(0).Item("JobOfWorkID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oContractAlternativeSiteJobItems.Exists = True
                        Return oContractAlternativeSiteJobItems
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_For_QuoteContractSiteID(ByVal QuoteContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll_For_QuoteContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_For_JobOfWorkID(ByVal JobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteJobItems_GetAll_For_JobOfWorkID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oQuoteContractAlternativeSiteJobItems As QuoteContractAlternativeSiteJobItems) As QuoteContractAlternativeSiteJobItems
                _database.ClearParameter()
                AddContractAlternativeSiteJobItemsParametersToCommand(oQuoteContractAlternativeSiteJobItems)

                oQuoteContractAlternativeSiteJobItems.SetQuoteContractSiteJobItemID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteJobItems_Insert"))
                oQuoteContractAlternativeSiteJobItems.Exists = True
                Return oQuoteContractAlternativeSiteJobItems
            End Function

            Public Sub Update(ByVal QuoteContractSiteJobItemID As Integer, ByVal JobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID, True)
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)

                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteJobItems_Update")
            End Sub

            Private Sub AddContractAlternativeSiteJobItemsParametersToCommand(ByRef oQuoteContractAlternativeSiteJobItems As QuoteContractAlternativeSiteJobItems)
                With _database
                    .AddParameter("@QuoteContractSiteID", oQuoteContractAlternativeSiteJobItems.QuoteContractSiteID, True)
                    .AddParameter("@Description", oQuoteContractAlternativeSiteJobItems.Description, True)
                    .AddParameter("@VisitFrequencyID", oQuoteContractAlternativeSiteJobItems.VisitFrequencyID, True)
                    .AddParameter("@VisitDuration", oQuoteContractAlternativeSiteJobItems.VisitDuration, True)
                    .AddParameter("@ItemPricePerVisit", oQuoteContractAlternativeSiteJobItems.ItemPricePerVisit, True)
                    .AddParameter("@JobOfWorkID", oQuoteContractAlternativeSiteJobItems.JobOfWorkID, True)

                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


