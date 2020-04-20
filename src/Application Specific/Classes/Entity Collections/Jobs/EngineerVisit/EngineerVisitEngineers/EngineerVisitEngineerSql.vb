Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.EngineerVisits.EngineerVisitEngineers.Enums
Imports FSM.Entity.Sys

Namespace Entity.EngineerVisits.EngineerVisitEngineers

    Public Class EngineerVisitEngineerSql
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

        Public Function [Get](ByVal key As Object, ByVal getBy As GetBy) As EngineerVisitEngineer
            _database.ClearParameter()
            Dim dt As DataTable = Nothing
            Select Case getBy
                Case GetBy.Id
                    _database.AddParameter("@Id", Helper.MakeIntegerValid(key), True)
                    dt = _database.ExecuteSP_DataTable("EngineerVisitEngineer_Get")

                Case GetBy.EngineerVisitId
                    _database.AddParameter("@EngineerVisitId", Helper.MakeIntegerValid(key), True)
                    dt = _database.ExecuteSP_DataTable("EngineerVisitEngineer_Get_ByEngineerVisitId")

                Case Else
                    Return Nothing
            End Select

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim engineerVisitEngineer As List(Of EngineerVisitEngineer) = ObjectMap.DataTableToList(Of EngineerVisitEngineer)(dt)
                Return engineerVisitEngineer?.First()
            Else : Return Nothing
            End If
        End Function

        Public Function [Insert](ByVal eve As EngineerVisitEngineer) As EngineerVisitEngineer
            _database.ClearParameter()
            _database.AddParameter("@EngineerVisitId", eve.EngineerVisitId)
            _database.AddParameter("@EngineerId", eve.EngineerId)
            _database.AddParameter("@Department", eve.Department)
            _database.AddParameter("@OftecNo", eve.OftecNo)
            _database.AddParameter("@GasSafeNo", eve.GasSafeNo)
            _database.AddParameter("@ManagerID", eve.ManagerId)
            _database.AddParameter("@CostToCompany", eve.CostToCompany)
            eve.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitEngineer_Insert"))
            Return eve
        End Function

        Public Function [Delete](ByVal key As Object, ByVal deleteBy As DeleteBy) As Boolean
            _database.ClearParameter()
            Dim spName As String = String.Empty
            Select Case deleteBy
                Case DeleteBy.Id
                    _database.AddParameter("@Id", Helper.MakeIntegerValid(key), True)
                    spName = "EngineerVisitEngineer_Delete"

                Case DeleteBy.EngineerVisitId
                    _database.AddParameter("@EngineerVisitId", Helper.MakeIntegerValid(key), True)
                    spName = "EngineerVisitEngineer_Delete_ByEngineerVisitId"
                Case Else
                    Return Nothing
            End Select
            Return CBool(_database.ExecuteSP_ReturnRowsAffected(spName) = 1)
        End Function

    End Class

End Namespace