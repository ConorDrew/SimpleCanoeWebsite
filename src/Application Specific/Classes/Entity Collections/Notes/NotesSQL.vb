Imports System.Data.SqlClient

Namespace Entity

    Namespace Notes

        Public Class NotesSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal NoteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@NoteID", NoteID, True)
                _database.ExecuteSP_NO_Return("Notes_Delete")
            End Sub

            Public Function [Notes_Get](ByVal NoteID As Integer) As Notes
                _database.ClearParameter()
                _database.AddParameter("@NoteID", NoteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Notes_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oNotes As New Notes
                        With oNotes
                            .IgnoreExceptionsOnSetMethods = True
                            .SetNoteID = dt.Rows(0).Item("NoteID")
                            .SetCategoryID = dt.Rows(0).Item("CategoryID")
                            .NoteDate = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("NoteDate"))
                            .SetNote = dt.Rows(0).Item("Note")
                            .DateCreated = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("DateCreated"))
                            .SetUserIDBy = dt.Rows(0).Item("UserIDBy")
                            .SetUserIDFor = dt.Rows(0).Item("UserIDFor")
                            .SetContactID = dt.Rows(0).Item("ContactID")
                            .DateTimeOfReminder = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("DateTimeOfReminder"))
                            .SetReminderStatusID = dt.Rows(0).Item("ReminderStatusID")
                        End With

                        oNotes.Exists = True
                        Return oNotes
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Notes_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Notes_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblNotes.ToString
                Return New DataView(dt)
            End Function

            Public Function NotesForContact(ByVal contactID As Integer) As DataView                '
                _database.ClearParameter()
                _database.AddParameter("@ContactID", contactID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Notes_Get_For_Contact")
                dt.TableName = Entity.Sys.Enums.TableNames.tblNotes.ToString
                Return New DataView(dt)
            End Function

            Public Function Reminders_GetAll() As DataView
                '_database.ClearParameter()
                '_database.AddParameter("@ReminderStatusID", CInt(Entity.Sys.Enums.NoteReminderStatus.Active), True)
                '_database.AddParameter("@UserIDFor", loggedInUser.UserID, True)


                Dim command As New SqlCommand("Notes_Reminders_GetAll", New SqlConnection(_database.ServerConnectionString))
                command.CommandType = CommandType.StoredProcedure

                command.Parameters.AddWithValue("@ReminderStatusID", CInt(Entity.Sys.Enums.NoteReminderStatus.Active))
                command.Parameters.AddWithValue("@UserIDFor", loggedInUser.UserID)


                Dim dt As DataTable = _database.ExecuteCommand_DataTable(command)

                dt.TableName = Entity.Sys.Enums.TableNames.tblNotes.ToString
                Return New DataView(dt)
            End Function

            Public Function Reminders_GetAll_NoFilter() As DataView
                _database.ClearParameter()

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Notes_Reminders_GetAll_NoFilter")
                dt.TableName = Entity.Sys.Enums.TableNames.tblNotes.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oNotes As Notes) As Notes
                _database.ClearParameter()
                _database.AddParameter("@CategoryID", oNotes.CategoryID, True)
                _database.AddParameter("@NoteDate", oNotes.NoteDate, True)
                _database.AddParameter("@Note", oNotes.Note, True)
                _database.AddParameter("@UserIDBy", loggedInUser.UserID, True)
                _database.AddParameter("@UserIDFor", oNotes.UserIDFor, True)
                _database.AddParameter("@ContactID", oNotes.ContactID, True)
                _database.AddParameter("@DateTimeOfReminder", oNotes.DateTimeOfReminder, True)
                _database.AddParameter("@ReminderStatusID", oNotes.ReminderStatusID, True)

                oNotes.SetNoteID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Notes_Insert"))
                oNotes.Exists = True
                Return oNotes
            End Function

            Public Function [Notes_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Notes_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblNotes.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oNotes As Notes)
                _database.ClearParameter()
                _database.AddParameter("@NoteID", oNotes.NoteID, True)
                _database.AddParameter("@CategoryID", oNotes.CategoryID, True)
                _database.AddParameter("@NoteDate", oNotes.NoteDate, True)
                _database.AddParameter("@Note", oNotes.Note, True)
                _database.AddParameter("@DateTimeOfReminder", oNotes.DateTimeOfReminder, True)
                _database.AddParameter("@ReminderStatusID", oNotes.ReminderStatusID, True)
                _database.AddParameter("@UserIDFor", oNotes.UserIDFor, True)

                _database.ExecuteSP_NO_Return("Notes_Update")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


