using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Notes
    {
        public class NotesSQL
        {
            private Sys.Database _database;

            public NotesSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int NoteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@NoteID", NoteID, true);
                _database.ExecuteSP_NO_Return("Notes_Delete");
            }

            public Notes Notes_Get(int NoteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@NoteID", NoteID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Notes_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oNotes = new Notes();
                        oNotes.IgnoreExceptionsOnSetMethods = true;
                        oNotes.SetNoteID = dt.Rows[0]["NoteID"];
                        oNotes.SetCategoryID = dt.Rows[0]["CategoryID"];
                        oNotes.NoteDate = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["NoteDate"]);
                        oNotes.SetNote = dt.Rows[0]["Note"];
                        oNotes.DateCreated = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["DateCreated"]);
                        oNotes.SetUserIDBy = dt.Rows[0]["UserIDBy"];
                        oNotes.SetUserIDFor = dt.Rows[0]["UserIDFor"];
                        oNotes.SetContactID = dt.Rows[0]["ContactID"];
                        oNotes.DateTimeOfReminder = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["DateTimeOfReminder"]);
                        oNotes.SetReminderStatusID = dt.Rows[0]["ReminderStatusID"];
                        oNotes.Exists = true;
                        return oNotes;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView Notes_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Notes_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblNotes.ToString();
                return new DataView(dt);
            }

            public DataView NotesForContact(int contactID)                // 
            {
                _database.ClearParameter();
                _database.AddParameter("@ContactID", contactID, true);
                var dt = _database.ExecuteSP_DataTable("Notes_Get_For_Contact");
                dt.TableName = Sys.Enums.TableNames.tblNotes.ToString();
                return new DataView(dt);
            }

            public DataView Reminders_GetAll()
            {
                // _database.ClearParameter()
                // _database.AddParameter("@ReminderStatusID", CInt(Entity.Sys.Enums.NoteReminderStatus.Active), True)
                // _database.AddParameter("@UserIDFor", loggedInUser.UserID, True)


                var command = new SqlCommand("Notes_Reminders_GetAll", new SqlConnection(_database.ServerConnectionString));
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReminderStatusID", Conversions.ToInteger(Sys.Enums.NoteReminderStatus.Active));
                command.Parameters.AddWithValue("@UserIDFor", App.loggedInUser.UserID);
                var dt = _database.ExecuteCommand_DataTable(command);
                dt.TableName = Sys.Enums.TableNames.tblNotes.ToString();
                return new DataView(dt);
            }

            public DataView Reminders_GetAll_NoFilter()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Notes_Reminders_GetAll_NoFilter");
                dt.TableName = Sys.Enums.TableNames.tblNotes.ToString();
                return new DataView(dt);
            }

            public Notes Insert(Notes oNotes)
            {
                _database.ClearParameter();
                _database.AddParameter("@CategoryID", oNotes.CategoryID, true);
                _database.AddParameter("@NoteDate", oNotes.NoteDate, true);
                _database.AddParameter("@Note", oNotes.Note, true);
                _database.AddParameter("@UserIDBy", App.loggedInUser.UserID, true);
                _database.AddParameter("@UserIDFor", oNotes.UserIDFor, true);
                _database.AddParameter("@ContactID", oNotes.ContactID, true);
                _database.AddParameter("@DateTimeOfReminder", oNotes.DateTimeOfReminder, true);
                _database.AddParameter("@ReminderStatusID", oNotes.ReminderStatusID, true);
                oNotes.SetNoteID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Notes_Insert"));
                oNotes.Exists = true;
                return oNotes;
            }

            public DataView Notes_Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@Criteria", criteria, true);
                var dt = _database.ExecuteSP_DataTable("Notes_Search");
                dt.TableName = Sys.Enums.TableNames.tblNotes.ToString();
                return new DataView(dt);
            }

            public void Update(Notes oNotes)
            {
                _database.ClearParameter();
                _database.AddParameter("@NoteID", oNotes.NoteID, true);
                _database.AddParameter("@CategoryID", oNotes.CategoryID, true);
                _database.AddParameter("@NoteDate", oNotes.NoteDate, true);
                _database.AddParameter("@Note", oNotes.Note, true);
                _database.AddParameter("@DateTimeOfReminder", oNotes.DateTimeOfReminder, true);
                _database.AddParameter("@ReminderStatusID", oNotes.ReminderStatusID, true);
                _database.AddParameter("@UserIDFor", oNotes.UserIDFor, true);
                _database.ExecuteSP_NO_Return("Notes_Update");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}