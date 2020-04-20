Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOriginalPPMVisits

        Public Class QuoteContractOriginalPPMVisitSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_For_QuoteContractSiteID(ByVal QuoteContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOriginalPPMVisit_GetAll_For_QuoteContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractPPMVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oQuoteContractPPMVisit As QuoteContractOriginalPPMVisit) As QuoteContractOriginalPPMVisit
                _database.ClearParameter()
                AddQuoteContractPPMVisitParametersToCommand(oQuoteContractPPMVisit)

                oQuoteContractPPMVisit.SetQuoteContractPPMVisitID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOriginalPPMVisit_Insert"))
                oQuoteContractPPMVisit.Exists = True
                Return oQuoteContractPPMVisit
            End Function

            Private Sub AddQuoteContractPPMVisitParametersToCommand(ByRef oQuoteContractPPMVisit As QuoteContractOriginalPPMVisit)
                With _database
                    .AddParameter("@QuoteContractSiteID", oQuoteContractPPMVisit.QuoteContractSiteID, True)
                    .AddParameter("@EstimatedVisitDate", oQuoteContractPPMVisit.EstimatedVisitDate, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


