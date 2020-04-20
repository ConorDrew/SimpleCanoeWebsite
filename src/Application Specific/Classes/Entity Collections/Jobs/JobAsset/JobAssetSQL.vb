Imports System.Data.SqlClient

Namespace Entity

    Namespace JobAssets

        Public Class JobAssetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [Insert](ByVal oJobAsset As JobAsset, ByVal trans As SqlClient.SqlTransaction) As JobAsset

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobAsset_Insert"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobID", oJobAsset.JobID))
                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AssetID", oJobAsset.AssetID))

                oJobAsset.SetJobAssetID = Entity.Sys.Helper.MakeIntegerValid(Command.ExecuteScalar)
                Return oJobAsset

            End Function

            Public Function [Insert](ByVal oJobAsset As JobAsset) As JobAsset
                _database.ClearParameter()
                _database.AddParameter("@JobID", oJobAsset.JobID, True)
                _database.AddParameter("@AssetID", oJobAsset.AssetID, True)

                oJobAsset.SetJobAssetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobAsset_Insert"))
                Return oJobAsset
            End Function

            Public Sub [Delete](ByVal JobID As Integer, ByVal trans As SqlClient.SqlTransaction)

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobAsset_Delete"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobID", JobID))

                Command.ExecuteNonQuery()

            End Sub

            Public Sub [Delete](ByVal JobID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobID, True)
                _database.ExecuteSP_OBJECT("JobAsset_Delete")
            End Sub

            Public Function JobAsset_Get_For_Job(ByVal JobID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobAsset_Get_For_Job")
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function JobAsset_Get_For_Job(ByVal JobID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "JobAsset_Get_For_Job"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@JobID", JobID)


                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)
                dt.TableName = Entity.Sys.Enums.TableNames.tblJobAsset.ToString

                Return New DataView(dt)
            End Function

            Public Function JobAsset_Get_For_Job_As_Objects(ByVal JobID As Integer) As ArrayList
                Dim assets As New ArrayList
                For Each row As DataRow In JobAsset_Get_For_Job(JobID).Table.Rows
                    Dim asset As New JobAssets.JobAsset
                    asset.IgnoreExceptionsOnSetMethods = True
                    asset.SetJobAssetID = row.Item("JobAssetID")
                    asset.SetJobID = row.Item("JobID")
                    asset.SetAssetID = row.Item("AssetID")
                    assets.Add(asset)
                Next

                Return assets
            End Function

            Public Function JobAsset_Get_For_Job_As_Objects(ByVal JobID As Integer, ByVal trans As SqlClient.SqlTransaction) As ArrayList
                Dim assets As New ArrayList
                For Each row As DataRow In JobAsset_Get_For_Job(JobID, trans).Table.Rows
                    Dim asset As New JobAssets.JobAsset
                    asset.IgnoreExceptionsOnSetMethods = True
                    asset.SetJobAssetID = row.Item("JobAssetID")
                    asset.SetJobID = row.Item("JobID")
                    asset.SetAssetID = row.Item("AssetID")
                    assets.Add(asset)
                Next

                Return assets
            End Function

#End Region

        End Class

    End Namespace

End Namespace


