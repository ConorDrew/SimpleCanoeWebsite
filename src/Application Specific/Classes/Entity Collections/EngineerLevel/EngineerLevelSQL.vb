Imports System.Data.SqlClient

Namespace Entity.EngineerLevels

    Public Class EngineerLevelSQL
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Functions"

        Public Sub [Insert](ByVal EngineerID As Integer, ByVal t As DataTable)

            'delete all first
            _database.ClearParameter()
            _database.AddParameter("@EngineerID", EngineerID, True)
            _database.ExecuteSP_NO_Return("EngineerLevel_Delete")

            If Not t Is Nothing Then
                For Each r As DataRow In t.Rows
                    _database.ClearParameter()
                    _database.AddParameter("@EngineerID", EngineerID, True)
                    _database.AddParameter("@LevelID", r("LevelID"), True)
                    _database.AddParameter("@Notes", Entity.Sys.Helper.MakeStringValid(r("Notes")), True)
                    _database.AddParameter("@DatePassed", r("DatePassed"), True)
                    _database.AddParameter("@DateExpires", r("DateExpires"), True)
                    _database.AddParameter("@DateBooked", r("DateBooked"), True)
                    _database.ExecuteSP_NO_Return("EngineerLevel_Insert")
                Next
            End If
        End Sub

        Public Function [Get](ByVal EngineerID As Integer) As DataView
            '_database.ClearParameter()
            '_database.AddParameter("@EngineerID", EngineerID, True)

            Dim command As New SqlCommand("EngineerLevels_Get", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@EngineerID", EngineerID)

            Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
            Return New DataView(dt)
        End Function


        Public Function [GetAllInDate]() As DataView
            '_database.ClearParameter()
            '_database.AddParameter("@EngineerID", EngineerID, True)

            Dim command As New SqlCommand("EngineerLevels_GetALLInDate", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure

            Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
            Return New DataView(dt)
        End Function



        Public Function [GetForSetup](ByVal EngineerID As Integer) As DataView
            _database.ClearParameter()
            _database.AddParameter("@EngineerID", EngineerID, True)
            Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerLevels_Setup_Get")
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
            Return New DataView(dt)
        End Function

        Public Function Get_List_For_JobType(ByVal JobTypeID As Integer) As DataTable
            Dim command As New SqlCommand("EngineerLevels_Get_For_JobType", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@JobTypeID", JobTypeID)
            Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
            Return (dt)
        End Function

        Public Function Get_List_For_JobType_GetALL() As DataTable
            Dim command As New SqlCommand("EngineerLevels_Get_For_JobType_GetALL", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure

            Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
            Return (dt)
        End Function

        Public Function EngineerLevel_Insert_For_JobType(ByVal JobTypeID As Integer, ByVal SkillID As Integer) As DataTable
            Dim command As New SqlCommand("[EngineerLevel_Insert_For_JobType]", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@JobTypeID", JobTypeID)
            command.Parameters.AddWithValue("@SkillID", SkillID)
            Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
            Return (dt)
        End Function

        Public Function EngineerLevel_Delete_For_JobType(ByVal JobTypeID As Integer, ByVal SkillID As Integer) As DataTable
            Dim command As New SqlCommand("[EngineerLevel_Delete_For_JobType]", New SqlConnection(_database.ServerConnectionString))
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@JobTypeID", JobTypeID)
            command.Parameters.AddWithValue("@SkillID", SkillID)
            Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)
            dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerLevel.ToString
            Return (dt)
        End Function


#End Region




    End Class

End Namespace



