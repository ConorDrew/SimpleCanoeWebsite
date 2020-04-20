Imports System.Data.SqlClient

Namespace Entity.UserAbsence
    Public Class UserAbsenceSQL
        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

#Region "Functions go here"


        Public Sub Delete(ByVal UserAbsenceID As Integer)


            _database.ClearParameter()
            _database.AddParameter("@UserAbsenceID", UserAbsenceID)

            _database.ExecuteSP_NO_Return("UserAbsence_Delete")

        End Sub

        Public Function [UserAbsence_Get](ByVal UserAbsenceID As Integer) As Entity.UserAbsence.UserAbsence
            Dim dt As New DataTable
            Dim oUserAbsence As New UserAbsence
            Dim pUserAbsenceID As New SqlParameter("@UserAbsenceID", UserAbsenceID)

            'Get the datatable from the database store in dt
            dt = _database.ExecuteSP_DataTable("UserAbsence_Get", pUserAbsenceID)

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    With oUserAbsence
                        .SetUserAbsenceID = dt.Rows(0).Item("UserAbsenceID")
                        .SetUserID = dt.Rows(0).Item("UserID")
                        .SetAbsenceTypeID = dt.Rows(0).Item("AbsenceTypeID")
                        .DateFrom = CDate(dt.Rows(0).Item("DateFrom"))
                        .DateTo = CDate(dt.Rows(0).Item("DateTo"))
                        .SetComments = dt.Rows(0).Item("Comments")
                    End With
                End If
                oUserAbsence.Exists = True
                Return oUserAbsence
            Else
                Return Nothing
            End If
        End Function

        Public Function [UserAbsence_GetAll]() As DataTable
            'get the all the UserAbsence data from the 

            Dim dt As DataTable
            dt = _database.ExecuteSP_DataTable("UserAbsence_GetAll")
            dt.TableName = "tblUserAbsence"
            Return dt

        End Function

        Public Function UserAbsence_GetAll_ByDates(ByVal startDate As DateTime, ByVal endDate As DateTime) As DataTable
            'get the all the UserAbsence data from the 
            _database.ClearParameter()
            _database.AddParameter("@StartDate", Sys.Helper.MakeDateTimeValid(Format(startDate, "dd/MMM/yyyy") & " 00:00:00"), True)
            _database.AddParameter("@EndDate", Sys.Helper.MakeDateTimeValid(Format(endDate, "dd/MMM/yyyy") & " 23:59:59"), True)

            Dim dt As DataTable
            dt = _database.ExecuteSP_DataTable("UserAbsence_GetAll_ByDates")
            dt.TableName = "tblUserAbsence"
            Return dt

        End Function

        Public Function [Insert](ByVal oUserAbsence As UserAbsence) _
          As UserAbsence

            AddUserAbsenceParameters(oUserAbsence)

            oUserAbsence.Exists = True
            oUserAbsence.SetUserAbsenceID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("UserAbsence_Insert"))
            Return oUserAbsence

        End Function


        Public Sub [Update](ByVal oUserAbsence As UserAbsence)

            _database.ClearParameter()
            AddUserAbsenceParameters(oUserAbsence)
            _database.AddParameter("@UserAbsenceID", oUserAbsence.UserAbsenceID, True)
            _database.ExecuteSP_NO_Return("UserAbsence_Update")

        End Sub

        Private Sub AddUserAbsenceParameters(ByRef oUserAbsence As UserAbsence)

            _database.ClearParameter()
            _database.AddParameter("@UserID", oUserAbsence.UserID)
            _database.AddParameter("@AbsenceTypeID", oUserAbsence.AbsenceTypeID)
            _database.AddParameter("@DateFrom", Format(oUserAbsence.DateFrom, "yyyy-MM-dd HH:mm"))
            _database.AddParameter("@DateTo", Format(oUserAbsence.DateTo, "yyyy-MM-dd HH:mm"))
            _database.AddParameter("@Comments", oUserAbsence.Comments)

        End Sub

        Public Function UserAbsenceTypes_GetAll() As DataTable
            Dim dt As New DataTable
            dt = _database.ExecuteSP_DataTable("UserAbsenceTypes_GetAll")
            dt.TableName = "tblUserAbsenceTypes"
            Return dt
        End Function

        Public Function AbsenceSearch(ByVal sql As String) As DataTable
            Dim dt As New DataTable

            dt = _database.ExecuteWithReturn(sql)
            dt.TableName = "tblUserAbsence"
            Return dt
        End Function


#End Region

    End Class
End Namespace


