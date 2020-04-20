Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteJobOfWorks

        Public Class QuoteJobOfWorkSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Insert](ByVal qJobOfWork As QuoteJobOfWork) As QuoteJobOfWork
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", qJobOfWork.QuoteJobID, True)

                qJobOfWork.SetQuoteJobOfWorkID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJobOfWork_Insert"))
                qJobOfWork.Exists = True
                Return qJobOfWork
            End Function

            Public Function QuoteJobOfWork_Get_For_QuoteJob(ByVal QuoteJobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteJobOfWork_Get_For_QuoteJob")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteJobOfWork.ToString
                Return New DataView(dt)
            End Function

            Public Function QuoteJobOfWork_Get_For_QuoteJob_As_Objects(ByVal QuoteJobID As Integer) As ArrayList
                Dim jobOfWorks As New ArrayList
                For Each row As DataRow In QuoteJobOfWork_Get_For_QuoteJob(QuoteJobID).Table.Rows
                    Dim jobOfWork As New QuoteJobOfWorks.QuoteJobOfWork
                    jobOfWork.IgnoreExceptionsOnSetMethods = True
                    jobOfWork.Exists = True
                    jobOfWork.SetQuoteJobOfWorkID = row.Item("QuoteJobOFWorkID")
                    jobOfWork.SetQuoteJobID = row.Item("QuoteJobID")
                    jobOfWork.SetDeleted = row.Item("Deleted")
                    jobOfWork.QuoteJobItems = _database.QuoteJobItems.QuoteJobOfWork_Get_For_QuoteJob_Of_Work_As_Objects(jobOfWork.QuoteJobOfWorkID)
                    jobOfWork.QuoteEngineerVisits = _database.QuoteEngineerVisits.QuoteEngineerVisits_Get_For_QuoteJob_Of_Work_As_Objects(jobOfWork.QuoteJobOfWorkID)

                    jobOfWorks.Add(jobOfWork)
                Next

                Return jobOfWorks
            End Function

#End Region

        End Class

    End Namespace

End Namespace


