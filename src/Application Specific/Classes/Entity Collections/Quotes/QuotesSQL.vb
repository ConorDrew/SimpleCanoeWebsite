Imports System.Data.SqlClient

Namespace Entity

    Namespace Quotes

        Public Class QuotesSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function QuotesGet_All() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Quotes_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuotes.ToString
                Return New DataView(dt)
            End Function

            Public Function Quotes_Search(ByVal Criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", Criteria, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Quotes_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuotes.ToString
                Return New DataView(dt)
            End Function

            Public Function QuotesGet_All_For_CustomerID(ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuotesGet_All_For_CustomerID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuotes.ToString
                Return New DataView(dt)
            End Function

            Public Function QuotesGet_All_For_SiteID(ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuotesGet_All_For_SiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuotes.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace


