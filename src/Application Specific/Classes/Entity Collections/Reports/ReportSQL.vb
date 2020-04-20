Imports System.Data.SqlClient

Namespace Entity

    Namespace Reports

        Public Class ReportSQL

            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Servicing Statistics"
            Public Function Reports_ServicingStatistics(ByVal WhereClause As String, ByVal OrderClause As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Where", WhereClause, True)
                _database.AddParameter("@OrderBy", OrderClause, True)
                _database.ExecuteSP_NO_Return("Reports_ServicingStatistics")
            End Function

            Public Function Reports_WeeklyStatistics_Summary(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@in_start", StartDate, True)
                _database.AddParameter("@in_finish", EndDate, True)
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Reports_Servicing_WeeklyStats_Summary")
                Return New DataView(dt)
            End Function

            Public Function Reports_WeeklyStatistics_Detailed(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataView
                _database.ClearParameter()
                _database.AddParameter("@in_start", StartDate, True)
                _database.AddParameter("@in_finish", EndDate, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Reports_Servicing_WeeklyStats_Detailed")
                Return New DataView(dt)
            End Function

            Public Function Reports_ServiceLettersGenerated_Count(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@StartDate", StartDate, True)
                _database.AddParameter("@EndDate", EndDate, True)
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Reports_ServiceLettersGenerated_Count")
                Return New DataView(dt)
            End Function

            Public Function Reports_EngineerVisits_Scheduled(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@totalRowCount", 0, True)
                _database.AddParameter("@sortBy", "1", True)
                _database.AddParameter("@InvoiceTypeIDEnum", 260, True)
                _database.AddParameter("@InvoicedIDEnum", 10, True)
                _database.AddParameter("@ReadyToBeInvoicedIDEnum", 9, True)
                _database.AddParameter("@NoNeedForInvoiceIDEnum", 8, True)
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@SiteID", 0, True)
                _database.AddParameter("@EngineerID", 0, True)
                _database.AddParameter("@JobDefinitionEnumID", "0", True)
                _database.AddParameter("@JobTypeID", 4702, True)
                _database.AddParameter("@VisitEnumID", "5", True)
                _database.AddParameter("@OutcomeEnumID", "0", True)
                _database.AddParameter("@JobNumber", "", True)
                _database.AddParameter("@PONumber", "", True)
                _database.AddParameter("@DateFrom", StartDate, True)
                _database.AddParameter("@DateTo", EndDate, True)
                _database.AddParameter("@postcode", "", True)
                _database.AddParameter("@RegionID", 0, True)
                _database.AddParameter("@ContractTypeID", "0", True)
                _database.AddParameter("@LetterType", "0", True)
                _database.AddParameter("@DueDateFrom", Nothing, True)
                _database.AddParameter("@DueDateTo", Nothing, True)
                _database.AddParameter("@ChargeInProgress", "0", True)
                _database.AddParameter("@CostsTo", "%", True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Reports_EngineerVisits_Scheduled")
                Return New DataView(dt)
            End Function

            Public Function Reports_BatchVisitCosts(ByVal Where As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Wherestring", Where, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Reports_BatchVisitCosts")
                Return New DataView(dt)
            End Function
#End Region

        End Class
    End Namespace
End Namespace
