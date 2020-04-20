
Namespace Entity

    Namespace Appointments

        Public Class AppointmentsSQL

            Private _database As Sys.Database
            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Appointments_GetAll")
                dt.TableName = Sys.Enums.TableNames.tblAppointments.ToString
                Return New DataView(dt)
            End Function

            Public Function [Get](ByVal AppointmentID As Integer) As Entity.Appointments.Appointment

                _database.ClearParameter()
                _database.AddParameter("@AppointmentID", AppointmentID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Appointments_Get")
                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim appointment As New Entity.Appointments.Appointment
                        With appointment
                            .SetAppointmentID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("AppointmentID"))
                            .SetName = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Name"))
                            .SetStartTime = Entity.Sys.Helper.MakeTimeValid(dt.Rows(0).Item("StartTime"))
                            .SetEndTime = Entity.Sys.Helper.MakeTimeValid(dt.Rows(0).Item("EndTime"))
                        End With
                        Return appointment
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function
#End Region

        End Class

    End Namespace

End Namespace
