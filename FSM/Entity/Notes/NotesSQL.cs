// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Notes.NotesSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Notes
{
  public class NotesSQL
  {
    private Database _database;

    public NotesSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int NoteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@NoteID", (object) NoteID, true);
      this._database.ExecuteSP_NO_Return("Notes_Delete", true);
    }

    public FSM.Entity.Notes.Notes Notes_Get(int NoteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@NoteID", (object) NoteID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Notes_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FSM.Entity.Notes.Notes) null;
      FSM.Entity.Notes.Notes notes1 = new FSM.Entity.Notes.Notes();
      FSM.Entity.Notes.Notes notes2 = notes1;
      notes2.IgnoreExceptionsOnSetMethods = true;
      notes2.SetNoteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (NoteID)]);
      notes2.SetCategoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CategoryID"]);
      notes2.NoteDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NoteDate"]));
      notes2.SetNote = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Note"]);
      notes2.DateCreated = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DateCreated"]));
      notes2.SetUserIDBy = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserIDBy"]);
      notes2.SetUserIDFor = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserIDFor"]);
      notes2.SetContactID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContactID"]);
      notes2.DateTimeOfReminder = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DateTimeOfReminder"]));
      notes2.SetReminderStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReminderStatusID"]);
      notes1.Exists = true;
      return notes1;
    }

    public DataView Notes_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Notes_GetAll), true);
      table.TableName = Enums.TableNames.tblNotes.ToString();
      return new DataView(table);
    }

    public DataView NotesForContact(int contactID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ContactID", (object) contactID, true);
      DataTable table = this._database.ExecuteSP_DataTable("Notes_Get_For_Contact", true);
      table.TableName = Enums.TableNames.tblNotes.ToString();
      return new DataView(table);
    }

    public DataView Reminders_GetAll()
    {
      SqlCommand Command = new SqlCommand("Notes_Reminders_GetAll", new SqlConnection(this._database.ServerConnectionString));
      Command.CommandType = CommandType.StoredProcedure;
      Command.Parameters.AddWithValue("@ReminderStatusID", (object) 1);
      Command.Parameters.AddWithValue("@UserIDFor", (object) App.loggedInUser.UserID);
      DataTable table = this._database.ExecuteCommand_DataTable(Command);
      table.TableName = Enums.TableNames.tblNotes.ToString();
      return new DataView(table);
    }

    public DataView Reminders_GetAll_NoFilter()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("Notes_Reminders_GetAll_NoFilter", true);
      table.TableName = Enums.TableNames.tblNotes.ToString();
      return new DataView(table);
    }

    public FSM.Entity.Notes.Notes Insert(FSM.Entity.Notes.Notes oNotes)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CategoryID", (object) oNotes.CategoryID, true);
      this._database.AddParameter("@NoteDate", (object) oNotes.NoteDate, true);
      this._database.AddParameter("@Note", (object) oNotes.Note, true);
      this._database.AddParameter("@UserIDBy", (object) App.loggedInUser.UserID, true);
      this._database.AddParameter("@UserIDFor", (object) oNotes.UserIDFor, true);
      this._database.AddParameter("@ContactID", (object) oNotes.ContactID, true);
      this._database.AddParameter("@DateTimeOfReminder", (object) oNotes.DateTimeOfReminder, true);
      this._database.AddParameter("@ReminderStatusID", (object) oNotes.ReminderStatusID, true);
      oNotes.SetNoteID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Notes_Insert", true)));
      oNotes.Exists = true;
      return oNotes;
    }

    public DataView Notes_Search(string criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Criteria", (object) criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Notes_Search), true);
      table.TableName = Enums.TableNames.tblNotes.ToString();
      return new DataView(table);
    }

    public void Update(FSM.Entity.Notes.Notes oNotes)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@NoteID", (object) oNotes.NoteID, true);
      this._database.AddParameter("@CategoryID", (object) oNotes.CategoryID, true);
      this._database.AddParameter("@NoteDate", (object) oNotes.NoteDate, true);
      this._database.AddParameter("@Note", (object) oNotes.Note, true);
      this._database.AddParameter("@DateTimeOfReminder", (object) oNotes.DateTimeOfReminder, true);
      this._database.AddParameter("@ReminderStatusID", (object) oNotes.ReminderStatusID, true);
      this._database.AddParameter("@UserIDFor", (object) oNotes.UserIDFor, true);
      this._database.ExecuteSP_NO_Return("Notes_Update", true);
    }
  }
}
