Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Sys

Namespace Entity.Settings.Scheduler

    Public Class JobTypeColourSql
        Private _database As Database

        Public Sub New(ByVal database As Database)
            _database = database
        End Sub

        Public Function [Get_All]() As List(Of JobTypeColour)
            _database.ClearParameter()
            Dim dt As DataTable = _database.ExecuteSP_DataTable("JobTypeColour_Get_All")

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim jobTypeColours As List(Of JobTypeColour) = ObjectMap.DataTableToList(Of JobTypeColour)(dt)
                Return jobTypeColours
            Else : Return Nothing
            End If
        End Function

        Public Function [Insert](ByVal userJobTypeColour As JobTypeColour) As JobTypeColour
            _database.ClearParameter()
            _database.AddParameter("@JobTypeId", userJobTypeColour.JobTypeId)
            _database.AddParameter("@Colour", userJobTypeColour.Colour)
            userJobTypeColour.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobTypeColour_Insert"))
            Return userJobTypeColour
        End Function

        Public Function [Delete](ByVal Id As Integer) As Boolean
            _database.ClearParameter()
            _database.AddParameter("@Id", Id)
            Return CBool(_database.ExecuteSP_ReturnRowsAffected("JobTypeColour_Delete") = 1)
        End Function

    End Class

End Namespace