Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractAlternativeSiteJobItems

        Public Class ContractAlternativeSiteJobItemsSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal ContractSiteJobItemID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID, True)
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteJobItems_Delete")
          
            End Sub

            Public Function [Get](ByVal ContractSiteJobItemID As Integer) As ContractAlternativeSiteJobItems
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContractAlternativeSiteJobItems As New ContractAlternativeSiteJobItems
                        With oContractAlternativeSiteJobItems
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractSiteJobItemID = dt.Rows(0).Item("ContractSiteJobItemID")
                            .SetContractSiteID = dt.Rows(0).Item("ContractSiteID")
                            .SetDescription = dt.Rows(0).Item("Description")
                            .SetVisitFrequencyID = dt.Rows(0).Item("VisitFrequencyID")
                            .SetVisitDuration = dt.Rows(0).Item("VisitDuration")
                            .SetItemPricePerVisit = dt.Rows(0).Item("ItemPricePerVisit")
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
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_For_ContractSiteID(ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll_For_ContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_For_JobOfWorkID(ByVal JobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobOfWorkID", JobOfWorkID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteJobItems_GetAll_For_JobOfWorkID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractAlternativeSiteJobItems.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oContractAlternativeSiteJobItems As ContractAlternativeSiteJobItems) As ContractAlternativeSiteJobItems
                _database.ClearParameter()
                AddContractAlternativeSiteJobItemsParametersToCommand(oContractAlternativeSiteJobItems)

                oContractAlternativeSiteJobItems.SetContractSiteJobItemID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativeSiteJobItems_Insert"))
                oContractAlternativeSiteJobItems.Exists = True

                Return oContractAlternativeSiteJobItems
            End Function

            Public Sub Update(ByVal ContractSiteJobItemID As Integer, ByVal JobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID, True)
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, True)

                _database.ExecuteSP_NO_Return("ContractAlternativeSiteJobItems_Update")
            End Sub

            Private Sub AddContractAlternativeSiteJobItemsParametersToCommand(ByRef oContractAlternativeSiteJobItems As ContractAlternativeSiteJobItems)
                With _database
                    .AddParameter("@ContractSiteID", oContractAlternativeSiteJobItems.ContractSiteID, True)
                    .AddParameter("@Description", oContractAlternativeSiteJobItems.Description, True)
                    .AddParameter("@VisitFrequencyID", oContractAlternativeSiteJobItems.VisitFrequencyID, True)
                    .AddParameter("@VisitDuration", oContractAlternativeSiteJobItems.VisitDuration, True)
                    .AddParameter("@ItemPricePerVisit", oContractAlternativeSiteJobItems.ItemPricePerVisit, True)
                    .AddParameter("@JobOfWorkID", oContractAlternativeSiteJobItems.JobOfWorkID, True)

                End With
            End Sub


#End Region

        End Class

    End Namespace

End Namespace


