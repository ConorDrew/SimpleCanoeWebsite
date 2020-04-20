Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractAlternativeSites

        Public Class ContractAlternativeSiteSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Get](ByVal ContractSiteID As Integer) As ContractAlternativeSite
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSite_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContractSite As New ContractAlternativeSite
                        With oContractSite
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractSiteID = dt.Rows(0).Item("ContractSiteID")
                            .SetContractID = dt.Rows(0).Item("ContractID")
                            .SetPropertyID = dt.Rows(0).Item("SiteID")
                            .JobOfWorks = _database.ContractAlternativeSiteJobOfWork.Get_For_ContractSite_As_Objects(ContractSiteID)
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
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSite_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSite.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_ContractID(ByVal ContractID As Integer, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSite_GetAll_ContractID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSite.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oContractSite As ContractAlternativeSite) As ContractAlternativeSite
                _database.ClearParameter()
                AddContractSiteParametersToCommand(oContractSite)

                oContractSite.SetContractSiteID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativeSite_Insert"))
                oContractSite.Exists = True
                Return oContractSite
            End Function

            Public Sub Update(ByVal oContractSite As ContractAlternativeSite)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", oContractSite.ContractSiteID, True)
                AddContractSiteParametersToCommand(oContractSite)
                _database.ExecuteSP_NO_Return("ContractAlternativeSite_Update")
            End Sub

            Public Function Delete(ByVal ContractSiteID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
                Return _database.ExecuteSP_OBJECT("ContractAlternativeSite_Delete")
            End Function

            Public Function ActiveInactive(ByVal ContractSiteID As Integer, ByVal InactiveFlag As Boolean) As Integer
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.AddParameter("@DownloadStatus", CInt(Entity.Sys.Enums.VisitStatus.Downloaded), True)
                _database.AddParameter("@InactiveFlag", InactiveFlag, True)
                Return _database.ExecuteSP_OBJECT("ContractAlternativeSite_ActiveInactive")
            End Function

            Private Sub AddContractSiteParametersToCommand(ByRef oContractSite As ContractAlternativeSite)
                With _database
                    .AddParameter("@ContractID", oContractSite.ContractID, True)
                    .AddParameter("@SiteID", oContractSite.PropertyID, True)
                End With
            End Sub


#End Region

        End Class

    End Namespace

End Namespace


