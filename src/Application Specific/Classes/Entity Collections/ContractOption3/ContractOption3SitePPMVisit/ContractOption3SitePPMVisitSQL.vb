Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOption3SitePPMVisits

        Public Class ContractOption3SitePPMVisitSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [ContractOption3SitePPMVisit_GetAll_ContractSiteID](ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOption3SitePPMVisit_GetAll_ContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractOption3SitePPMVisit.ToString

                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oContractOption3SitePPMVisit As ContractOption3SitePPMVisit) As ContractOption3SitePPMVisit
                _database.ClearParameter()
                AddContractOption3SitePPMVisitParametersToCommand(oContractOption3SitePPMVisit)

                oContractOption3SitePPMVisit.SetContractSitePPMVisitID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOption3SitePPMVisit_Insert"))
                oContractOption3SitePPMVisit.Exists = True
                Return oContractOption3SitePPMVisit
            End Function

            Private Sub AddContractOption3SitePPMVisitParametersToCommand(ByRef oContractOption3SitePPMVisit As ContractOption3SitePPMVisit)
                With _database
                    .AddParameter("@ContractSiteID", oContractOption3SitePPMVisit.ContractSiteID, True)
                    .AddParameter("@VisitDate", oContractOption3SitePPMVisit.VisitDate, True)
                    .AddParameter("@JobID", oContractOption3SitePPMVisit.JobID, True)
                End With
            End Sub


#End Region

        End Class

    End Namespace

End Namespace


