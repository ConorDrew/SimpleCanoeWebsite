Namespace Entity

    Namespace JobLock

        Public Class JobLockSQL

            Private _database As Sys.Database

            Public Sub New(ByVal databaseIn As Sys.Database)
                _database = databaseIn
            End Sub

#Region "Functions"

            Public Function Check(ByVal JobID As Integer) As JobLock
                Dim oJobLock As New JobLock
                oJobLock.JobID = JobID

                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                'check if the record is already locked
                Dim t As DataTable = _database.ExecuteSP_DataTable("JobLock_IsRecordLocked")

                If t.Rows.Count > 0 Then
                    Dim r As DataRow = t.Rows(0)
                    oJobLock.JobLockID = Entity.Sys.Helper.MakeIntegerValid(r("JobLockID"))
                    oJobLock.UserID = Entity.Sys.Helper.MakeIntegerValid(r("UserID"))
                    oJobLock.DateLock = Entity.Sys.Helper.MakeDateTimeValid(r("DateLock"))
                    oJobLock.NameOfUserWhoLocked = Entity.Sys.Helper.MakeStringValid(r("FullName"))
                    Return oJobLock
                Else
                    Return Nothing
                End If

            End Function

            Public Function JobLock(ByVal JobID As Integer) As JobLock
                Dim oJobLock As New JobLock
                oJobLock.JobID = JobID

                _database.ClearParameter()
                _database.AddParameter("@JobID", JobID, True)

                'check if the record is already locked
                Dim t As DataTable = _database.ExecuteSP_DataTable("JobLock_IsRecordLocked")

                If t.Rows.Count > 0 Then
                    Dim r As DataRow = t.Rows(0)
                    oJobLock.JobLockID = Entity.Sys.Helper.MakeIntegerValid(r("JobLockID"))
                    oJobLock.UserID = Entity.Sys.Helper.MakeIntegerValid(r("UserID"))
                    oJobLock.DateLock = Entity.Sys.Helper.MakeDateTimeValid(r("DateLock"))
                    oJobLock.NameOfUserWhoLocked = Entity.Sys.Helper.MakeStringValid(r("FullName"))

                    If oJobLock.UserID = loggedInUser.UserID Then
                        _database.ClearParameter()
                        _database.AddParameter("@JobID", JobID, True)
                        _database.AddParameter("@UserID", loggedInUser.UserID, True)
                        oJobLock.JobLockID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobLock_Insert"))
                    End If
                Else
                    'the record is not locked, so lock it
                    oJobLock.UserID = loggedInUser.UserID
                    oJobLock.DateLock = Now
                    oJobLock.NameOfUserWhoLocked = loggedInUser.Fullname

                    _database.ClearParameter()
                    _database.AddParameter("@JobID", JobID, True)
                    _database.AddParameter("@UserID", loggedInUser.UserID, True)
                    oJobLock.JobLockID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobLock_Insert"))
                End If

                Return oJobLock
            End Function

            Public Function GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("JobLock_GetAll")
                dt.TableName = Sys.Enums.TableNames.tblJobLock.ToString
                Return New DataView(dt)
            End Function

            Public Sub Delete(ByVal JobLockID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@JobLockID", JobLockID, True)
                _database.ExecuteSP_NO_Return("JobLock_Delete")
            End Sub

            Public Sub DeleteAll()
                _database.ClearParameter()
                _database.AddParameter("@UserID", loggedInUser?.UserID, True)
                _database.ExecuteSP_NO_Return("JobLock_DeleteAll")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace