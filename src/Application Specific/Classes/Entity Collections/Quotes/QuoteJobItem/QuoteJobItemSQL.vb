Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteJobItems

        Public Class QuoteJobItemSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Insert](ByVal qJobItem As QuoteJobItem) As QuoteJobItem
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobOfWorkID", qJobItem.QuoteJobOfWorkID, True)
                _database.AddParameter("@Summary", qJobItem.Summary, True)
                _database.AddParameter("@RateID", qJobItem.RateID, True)
                _database.AddParameter("@Qty", qJobItem.Qty, True)
                _database.AddParameter("@SystemLinkID", qJobItem.SystemLinkID, True)

                qJobItem.SetQuoteJobItemID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJobItem_Insert"))
                Return qJobItem
            End Function

            Public Function QuoteJobItems_Get_For_QuoteJob_Of_Work(ByVal QuoteJobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobOfWorkID", QuoteJobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteJobItems_Get_For_QuoteJob_Of_Work")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteJobItem.ToString
                Return New DataView(dt)
            End Function

            Public Function QuoteJobOfWork_Get_For_QuoteJob_Of_Work_As_Objects(ByVal QuoteJobOfWorkID As Integer) As ArrayList
                Dim jobItems As New ArrayList
                For Each row As DataRow In QuoteJobItems_Get_For_QuoteJob_Of_Work(QuoteJobOfWorkID).Table.Rows
                    Dim jobItem As New QuoteJobItems.QuoteJobItem
                    jobItem.IgnoreExceptionsOnSetMethods = True
                    jobItem.SetQuoteJobItemID = row.Item("QuoteJobItemID")
                    jobItem.SetQuoteJobOfWorkID = row.Item("QuoteJobOfWorkID")
                    jobItem.SetSummary = row.Item("Summary")
                    jobItem.SetRateID = row.Item("RateID")
                    jobItem.SetQty = row.Item("Qty")
                    jobItem.SetSystemLinkID = row.Item("SystemLinkID")
                    jobItems.Add(jobItem)
                Next

                Return jobItems
            End Function

            Public Sub [Delete](ByVal QuoteJobOfWorkID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobOfWorkID", QuoteJobOfWorkID, True)

                _database.ExecuteSP_NO_Return("QuoteJobItem_Delete")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace