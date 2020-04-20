Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternativePPMVisits

        Public Class QuoteContractAlternativePPMVisitSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_For_QuoteContractSiteJobOfWorkID(ByVal QuoteContractSiteJobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobOfWorkID", QuoteContractSiteJobOfWorkID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativePPMVisit_GetAll_For_QuoteContractSiteJobOfWorkID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractPPMVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oQuoteContractPPMVisit As QuoteContractAlternativePPMVisit) As QuoteContractAlternativePPMVisit
                _database.ClearParameter()
                AddQuoteContractPPMVisitParametersToCommand(oQuoteContractPPMVisit)

                oQuoteContractPPMVisit.SetQuoteContractPPMVisitID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativePPMVisit_Insert"))
                oQuoteContractPPMVisit.Exists = True
                Return oQuoteContractPPMVisit
            End Function

            Private Sub AddQuoteContractPPMVisitParametersToCommand(ByRef oQuoteContractPPMVisit As QuoteContractAlternativePPMVisit)
                With _database
                    .AddParameter("@QuoteContractSiteJobOfWorkID", oQuoteContractPPMVisit.QuoteContractSiteJobOfWorkID, True)
                    .AddParameter("@EstimatedVisitDate", oQuoteContractPPMVisit.EstimatedVisitDate, True)
                End With
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


