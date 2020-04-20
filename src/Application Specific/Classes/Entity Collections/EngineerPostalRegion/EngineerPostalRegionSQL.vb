Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerPostalRegions

        Public Class EngineerPostalRegionSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Sub Delete(ByVal EngineerID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", EngineerID, True)
                _database.ExecuteSP_NO_Return("EngineerPostalRegion_Delete")
            End Sub

            Public Sub [Insert](ByVal EngineerID As Integer, ByVal PostalRegionID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PostalRegionID", PostalRegionID, True)
                _database.AddParameter("@EngineerID", EngineerID, True)

                _database.ExecuteSP_NO_Return("EngineerPostalRegion_Insert")
            End Sub

            Public Function [Get](ByVal EngineerID As Integer) As DataView
                '_database.ClearParameter()
                '_database.AddParameter("@EngineerID", EngineerID, True)

                Dim command As New SqlCommand("EngineerPostalRegion_Get", New SqlConnection(_database.ServerConnectionString))
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@EngineerID", EngineerID)

                Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)

                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
                Return New DataView(dt)
            End Function


            Public Function [GetALLTicked]() As DataView
                '_database.ClearParameter()
                '_database.AddParameter("@EngineerID", EngineerID, True)

                Dim command As New SqlCommand("EngineerPostalRegion_GetALL", New SqlConnection(_database.ServerConnectionString))
                command.CommandType = CommandType.StoredProcedure


                Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)

                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
                Return New DataView(dt)

            End Function

            Public Function [GetTicked](ByVal EngineerID As Integer) As DataView
                '_database.ClearParameter()
                '_database.AddParameter("@EngineerID", EngineerID, True)

                Dim command As New SqlCommand("EngineerPostalRegion_Get_OnlyTicked", New SqlConnection(_database.ServerConnectionString))
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@EngineerID", EngineerID)

                Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)

                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
                Return New DataView(dt)
            End Function

            Public Function [GetUnTicked](ByVal EngineerID As Integer) As DataView
                '_database.ClearParameter()
                '_database.AddParameter("@EngineerID", EngineerID, True)

                Dim command As New SqlCommand("EngineerPostalRegion_Get_OnlyUnTicked", New SqlConnection(_database.ServerConnectionString))
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@EngineerID", EngineerID)

                Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)

                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
                Return New DataView(dt)
            End Function

            Public Function [Check](ByVal EngineerID As Integer, ByVal PostalRegion As String) As Boolean
                Dim command As New SqlCommand("EngineerPostalRegion_Check", New SqlConnection(_database.ServerConnectionString))
                Try
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@EngineerID", EngineerID)
                    command.Parameters.AddWithValue("@PostalRegion", PostalRegion)
                    command.Connection.Open()

                    Return CBool(command.ExecuteScalar)
                Finally
                    command.Connection.Close()
                End Try
            End Function

            Public Function [EngineerPostalRegion_Get_For_Postcode](ByVal Postcode As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Postcode", Postcode, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerPostalRegion_Get_For_Postcode")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerPostalRegion.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace


