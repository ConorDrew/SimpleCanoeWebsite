Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractAlternativePPMVisits

        Public Class ContractAlternativePPMVisitSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_For_ContractSiteJobOfWorkID(ByVal ContractSiteJobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobOfWorkID", ContractSiteJobOfWorkID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativePPMVisit_GetAll_For_ContractSiteJobOfWorkID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oContractPPMVisit As ContractAlternativePPMVisit) As ContractAlternativePPMVisit
                _database.ClearParameter()
                AddContractPPMVisitParametersToCommand(oContractPPMVisit)

                oContractPPMVisit.SetContractPPMVisitID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativePPMVisit_Insert"))
                oContractPPMVisit.Exists = True
                Return oContractPPMVisit
            End Function

            Private Sub AddContractPPMVisitParametersToCommand(ByRef oContractPPMVisit As ContractAlternativePPMVisit)
                With _database
                    .AddParameter("@ContractSiteJobOfWorkID", oContractPPMVisit.ContractSiteJobOfWorkID, True)
                    .AddParameter("@EstimatedVisitDate", oContractPPMVisit.EstimatedVisitDate, True)
                    .AddParameter("@JobID", oContractPPMVisit.JobID, True)
                End With
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


