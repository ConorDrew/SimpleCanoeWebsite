Imports System.Data.SqlClient

Namespace Entity.EngineerAbsence
    Public Class EngineerAbsenceSQL
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Functions go here"


        Public Sub Delete(ByVal EngineerAbsenceID As Integer)


            _database.ClearParameter()
            _database.AddParameter("@EngineerAbsenceID", EngineerAbsenceID)

            _database.ExecuteSP_NO_Return("EngineerAbsence_Delete")

        End Sub

        Public Function [EngineerAbsence_Get](ByVal EngineerAbsenceID As Integer) As Entity.EngineerAbsence.EngineerAbsence
            Dim dt As New DataTable
            Dim oEngineerAbsence As New EngineerAbsence
            Dim pEngineerAbsenceID As New SqlParameter("@EngineerAbsenceID", EngineerAbsenceID)

            'Get the datatable from the database store in dt
            dt = _database.ExecuteSP_DataTable("EngineerAbsence_Get", pEngineerAbsenceID)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                With oEngineerAbsence
                    .SetEngineerAbsenceID = dt.Rows(0).Item("EngineerAbsenceID")
                    .SetEngineerID = dt.Rows(0).Item("EngineerID")
                    .SetAbsenceTypeID = dt.Rows(0).Item("AbsenceTypeID")
                    .DateFrom = CDate(dt.Rows(0).Item("DateFrom"))
                    .DateTo = CDate(dt.Rows(0).Item("DateTo"))
                    .SetComments = dt.Rows(0).Item("Comments")
                End With
                oEngineerAbsence.Exists = True
                Return oEngineerAbsence
            Else
                Return Nothing
            End If

        End Function

        Public Function [EngineerAbsence_GetAll]() As DataTable
            Dim dt As DataTable
            dt = _database.ExecuteSP_DataTable("EngineerAbsence_GetAll")
            dt.TableName = "tblEngineerAbsence"
            Return dt

        End Function

        Public Function [Insert](ByVal oEngineerAbsence As EngineerAbsence) _
          As EngineerAbsence

            AddEngineerAbsenceParameters(oEngineerAbsence)

            oEngineerAbsence.Exists = True
            oEngineerAbsence.SetEngineerAbsenceID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerAbsence_Insert"))
            Return oEngineerAbsence

        End Function


        Public Sub [Update](ByVal oEngineerAbsence As EngineerAbsence)

            _database.ClearParameter()
            AddEngineerAbsenceParameters(oEngineerAbsence)
            _database.AddParameter("@EngineerAbsenceID", oEngineerAbsence.EngineerAbsenceID, True)
            _database.ExecuteSP_NO_Return("EngineerAbsence_Update")

        End Sub

        Private Sub AddEngineerAbsenceParameters(ByRef oEngineerAbsence As EngineerAbsence)

            _database.ClearParameter()
            _database.AddParameter("@EngineerID", oEngineerAbsence.EngineerID)
            _database.AddParameter("@AbsenceTypeID", oEngineerAbsence.AbsenceTypeID)
            _database.AddParameter("@DateFrom", Format(oEngineerAbsence.DateFrom, "yyyy-MM-dd HH:mm"))
            _database.AddParameter("@DateTo", Format(oEngineerAbsence.DateTo, "yyyy-MM-dd HH:mm"))
            _database.AddParameter("@Comments", oEngineerAbsence.Comments)

        End Sub

        Public Function EngineerAbsenceTypes_GetAll() As DataTable
            Dim dt As New DataTable
            _database.ClearParameter()
            dt = _database.ExecuteSP_DataTable("EngineerAbsenceTypes_GetAll")
            dt.TableName = "tblEngineerAbsenceTypes"
            Return dt
        End Function

        Public Function AbsenceSearch(ByVal sql As String) As DataTable
            Dim dt As New DataTable

            dt = _database.ExecuteWithReturn(sql)
            dt.TableName = "tblEngineerAbsence"
            Return dt
        End Function


        Public Function GetAbsencesForEngineer(ByVal engineerID As Integer) As DataTable
            _database.ClearParameter()
            _database.AddParameter("@EngineerID", engineerID)
            Return _database.ExecuteSP_DataTable("Engineer_Absences_Get")
        End Function


#End Region

    End Class
End Namespace


