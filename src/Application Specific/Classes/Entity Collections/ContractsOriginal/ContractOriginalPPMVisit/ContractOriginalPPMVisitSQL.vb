Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOriginalPPMVisits

        Public Class ContractOriginalPPMVisitSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_For_ContractSiteID(ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalPPMVisit_GetAll_For_ContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAllAssets_For_ContractSiteID(ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalPPMVisit_Assets_GetAll_For_ContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oContractPPMVisit As ContractOriginalPPMVisit) As ContractOriginalPPMVisit
                _database.ClearParameter()
                AddContractPPMVisitParametersToCommand(oContractPPMVisit)

                oContractPPMVisit.SetContractPPMVisitID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalPPMVisit_Insert"))
                oContractPPMVisit.Exists = True
                Return oContractPPMVisit
            End Function

            Private Sub AddContractPPMVisitParametersToCommand(ByRef oContractPPMVisit As ContractOriginalPPMVisit)
                With _database
                    .AddParameter("@ContractSiteID", oContractPPMVisit.ContractSiteID, True)
                    .AddParameter("@EstimatedVisitDate", oContractPPMVisit.EstimatedVisitDate, True)
                    .AddParameter("@JobID", oContractPPMVisit.JobID, True)
                End With
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


