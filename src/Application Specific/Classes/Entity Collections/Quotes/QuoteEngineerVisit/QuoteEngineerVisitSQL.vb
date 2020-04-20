Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteEngineerVisits

        Public Class QuoteEngineerVisitSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Insert](ByVal qEngineerVisit As QuoteEngineerVisit) As QuoteEngineerVisit
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobOfWorkID", qEngineerVisit.QuoteJobOfWorkID, True)
                _database.AddParameter("@StatusEnumID", qEngineerVisit.StatusEnumID, True)
                _database.AddParameter("@NotesToEngineer", qEngineerVisit.NotesToEngineer, True)

                qEngineerVisit.SetQuoteEngineerVisitID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteEngineerVisit_Insert"))
                qEngineerVisit.Exists = True
                Return qEngineerVisit
            End Function

            Public Function QuoteEngineerVisits_Get_For_QuoteJob_Of_Work(ByVal QuoteJobOfWorkID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobOfWorkID", QuoteJobOfWorkID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteEngineerVisits_Get_For_QuoteJob_Of_Work")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteEngineerVisit.ToString
                Return New DataView(dt)
            End Function

            Public Function QuoteEngineerVisits_Get_For_QuoteJob_Of_Work_As_Objects(ByVal QuoteJobOfWorkID As Integer) As ArrayList
                Dim engineerVisits As New ArrayList
                For Each row As DataRow In QuoteEngineerVisits_Get_For_QuoteJob_Of_Work(QuoteJobOfWorkID).Table.Rows
                    Dim visit As New QuoteEngineerVisits.QuoteEngineerVisit
                    visit.IgnoreExceptionsOnSetMethods = True
                    visit.Exists = True
                    visit.SetQuoteEngineerVisitID = row.Item("QuoteEngineerVisitID")
                    visit.SetQuoteJobOfWorkID = row.Item("QuoteJobOfWorkID")
                    visit.SetStatusEnumID = row.Item("StatusEnumID")
                    visit.SetNotesToEngineer = row.Item("NotesToEngineer")
                    visit.SetDeleted = row.Item("Deleted")

                    engineerVisits.Add(visit)
                Next

                Return engineerVisits
            End Function

#End Region

        End Class

    End Namespace

End Namespace


