Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOriginalVisits

        Public Class ContractOriginalVisitSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_For_ContractSiteID(ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalVisit_GetAll_For_ContractSiteID")
                dt.TableName = "ContractOriginalVisit"
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oContractVisit As ContractOriginalVisit) As ContractOriginalVisit
                _database.ClearParameter()
                AddContractVisitParametersToCommand(oContractVisit)

                oContractVisit.SetContractVisitID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalVisit_Insert"))
                oContractVisit.Exists = True
                Return oContractVisit
            End Function

            Public Sub Delete(ByVal ContractVisitID As Integer)

                _database.ClearParameter()
                _database.AddParameter("@ContractVisitID", ContractVisitID, True)
                _database.ExecuteSP_NO_Return("ContractOriginalVisit_Delete")

            End Sub

            Private Sub AddContractVisitParametersToCommand(ByRef oContractVisit As ContractOriginalVisit)
                With _database
                    .AddParameter("@ContractSiteID", oContractVisit.ContractSiteID, True)
                    .AddParameter("@VisitDate", oContractVisit.EstimatedVisitDate, True)
                    .AddParameter("@JobID", oContractVisit.JobID, True)
                    .AddParameter("@Cost", oContractVisit.Cost, True)
                    .AddParameter("@SubcontractorID", oContractVisit.SubContractorID, True)
                    .AddParameter("@PreferredEngineerID", oContractVisit.PreferredEngineerID, True)
                    .AddParameter("@VisitTypeID", oContractVisit.VisitTypeID, True)
                    .AddParameter("@FrequencyID", oContractVisit.FrequencyID, True)
                    .AddParameter("@Frequency", oContractVisit.Frequency, True)
                    .AddParameter("@SubContractor", oContractVisit.SubContractor, True)
                    .AddParameter("@PreferredEngineer", oContractVisit.PreferredEngineer, True)
                    .AddParameter("@VisitType", oContractVisit.VisitType, True)
                    .AddParameter("@HoursReq", oContractVisit.HoursReq, True)
                    .AddParameter("@AdditionalNotes", oContractVisit.AdditionalNotes, True)

                End With
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


