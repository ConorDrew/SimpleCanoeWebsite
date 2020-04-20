Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteJobAssets

        Public Class QuoteJobAssetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Insert](ByVal qJobAsset As QuoteJobAsset) As QuoteJobAsset
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", qJobAsset.QuoteJobID, True)
                _database.AddParameter("@AssetID", qJobAsset.AssetID, True)

                qJobAsset.SetQuoteJobAssetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJobAsset_Insert"))
                Return qJobAsset
            End Function

            Public Sub [Delete](ByVal QuoteJobID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID, True)
                _database.ExecuteSP_OBJECT("QuoteJobAsset_Delete")
            End Sub

            Public Function QuoteJobAsset_Get_For_QuoteJob(ByVal QuoteJobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteJobID", QuoteJobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteJobAsset_Get_For_QuoteJob")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteJobAssets.ToString
                Return New DataView(dt)
            End Function

            Public Function QuoteJobAsset_Get_For_QuoteJob_As_Objects(ByVal QuoteJobID As Integer) As ArrayList
                Dim assets As New ArrayList
                For Each row As DataRow In QuoteJobAsset_Get_For_QuoteJob(QuoteJobID).Table.Rows
                    Dim asset As New QuoteJobAssets.QuoteJobAsset
                    asset.IgnoreExceptionsOnSetMethods = True
                    asset.SetQuoteJobAssetID = row.Item("QuoteJobAssetID")
                    asset.SetQuoteJobID = row.Item("QuoteJobID")
                    asset.SetAssetID = row.Item("AssetID")
                    assets.Add(asset)
                Next

                Return assets
            End Function


#End Region

        End Class

    End Namespace

End Namespace


