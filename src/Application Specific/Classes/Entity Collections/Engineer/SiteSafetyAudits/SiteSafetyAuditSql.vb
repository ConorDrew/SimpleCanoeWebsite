Imports System.Collections.Generic
Imports FSM.Entity.Engineers.SiteSafetyAudits.Enums
Imports FSM.Entity.Sys

Namespace Entity.Engineers.SiteSafetyAudits

    Public Class SiteSafetyAuditSql
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

        Public Function [Get_As_Entity](ByVal ref As Object, ByVal getBy As GetBy) As List(Of SiteSafetyAudit)
            _database.ClearParameter()

            'Get the datatable from the database store in dt
            Dim dt As DataTable = Nothing
            Select Case getBy
                Case GetBy.Id
                    _database.AddParameter("@Id", ref, True)
                    dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById")

                Case GetBy.EngineerId
                    _database.AddParameter("@EngineerId", ref, True)
                    dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ByEngineerId")
                Case Else
                    _database.AddParameter("@Id", ref, True)
                    dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById")
            End Select

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim siteSafetyAudits As List(Of SiteSafetyAudit) = ObjectMap.DataTableToList(Of SiteSafetyAudit)(dt)
                Return siteSafetyAudits
            Else : Return Nothing
            End If
        End Function

        Public Function [Get_As_DataView](ByVal ref As Object, ByVal getBy As GetBy) As DataView
            _database.ClearParameter()

            'Get the datatable from the database store in dt
            Dim dt As DataTable = Nothing
            Select Case getBy
                Case GetBy.Id
                    _database.AddParameter("@Id", ref, True)
                    dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById")

                Case GetBy.EngineerId
                    _database.AddParameter("@EngineerId", ref, True)
                    dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ByEngineerId")
                Case Else
                    dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_All")
            End Select
            Return New DataView(dt)
        End Function

        Public Function [Insert](ByVal siteSafetyAudit As SiteSafetyAudit) As SiteSafetyAudit
            _database.ClearParameter()
            AddParameters(siteSafetyAudit)
            siteSafetyAudit.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerSiteSafetyAudit_Insert"))
            Return siteSafetyAudit
        End Function

        Public Sub [Update](ByVal siteSafetyAudit As SiteSafetyAudit)
            _database.ClearParameter()
            _database.AddParameter("@Id", siteSafetyAudit.Id)
            AddParameters(siteSafetyAudit)
            _database.ExecuteSP_NO_Return("EngineerSiteSafetyAudit_Update")
        End Sub

        Private Sub AddParameters(ByVal siteSafetyAudit As SiteSafetyAudit)
            _database.AddParameter("@AuditDate", siteSafetyAudit.AuditDate, True)
            _database.AddParameter("@EngineerId", siteSafetyAudit.EngineerId, True)
            _database.AddParameter("@Department", siteSafetyAudit.Department, True)
            _database.AddParameter("@Question1", siteSafetyAudit.Question1, True)
            _database.AddParameter("@Question2", siteSafetyAudit.Question2, True)
            _database.AddParameter("@Question3", siteSafetyAudit.Question3, True)
            _database.AddParameter("@Question4", siteSafetyAudit.Question4, True)
            _database.AddParameter("@Question5", siteSafetyAudit.Question5, True)
            _database.AddParameter("@Question6", siteSafetyAudit.Question6, True)
            _database.AddParameter("@Question7", siteSafetyAudit.Question7, True)
            _database.AddParameter("@Question8", siteSafetyAudit.Question8, True)
            _database.AddParameter("@Question9", siteSafetyAudit.Question9, True)
            _database.AddParameter("@Question10", siteSafetyAudit.Question10, True)
            _database.AddParameter("@Question11", siteSafetyAudit.Question11, True)
            _database.AddParameter("@Result", siteSafetyAudit.Result)
            _database.AddParameter("@AuditorId", siteSafetyAudit.AuditorId)
        End Sub

        Public Function [Delete](ByVal id As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@Id", id)
            Return CBool(_database.ExecuteSP_ReturnRowsAffected("EngineerSiteSafetyAudit_Delete") = 1)
        End Function

    End Class

End Namespace