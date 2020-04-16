// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Authority.AuthoritySQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Authority
{
  public class AuthoritySQL
  {
    private Database _database;

    public AuthoritySQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int authorityId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@AuthorityId", (object) authorityId, true);
      this._database.ExecuteSP_NO_Return("Authority_Delete", true);
    }

    public FSM.Entity.Authority.Authority Get(object @ref, AuthoritySQL.GetBy getBy = AuthoritySQL.GetBy.SiteId)
    {
      this._database.ClearParameter();
      DataTable dataTable;
      switch (getBy)
      {
        case AuthoritySQL.GetBy.SiteId:
          this._database.AddParameter("@SiteId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          dataTable = this._database.ExecuteSP_DataTable("Authority_Get_BySiteId", true);
          break;
        case AuthoritySQL.GetBy.CustomerId:
          this._database.AddParameter("@CustomerId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          dataTable = this._database.ExecuteSP_DataTable("Authority_Get_ByCustomerId", true);
          break;
        default:
          this._database.AddParameter("@AuthorityId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          dataTable = this._database.ExecuteSP_DataTable("Authority_Get", true);
          break;
      }
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (FSM.Entity.Authority.Authority) null;
      FSM.Entity.Authority.Authority authority1 = new FSM.Entity.Authority.Authority();
      FSM.Entity.Authority.Authority authority2 = authority1;
      authority2.IgnoreExceptionsOnSetMethods = true;
      if (dataTable.Columns.Contains("AuthorityId"))
        authority2.SetAuthorityId = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AuthorityId"]));
      if (dataTable.Columns.Contains("Notes"))
        authority2.SetNotes = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]));
      if (dataTable.Columns.Contains("DateAdded"))
        authority2.DateAdded = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DateAdded"]));
      if (dataTable.Columns.Contains("AddedById"))
        authority2.SetAddedById = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddedById"]));
      if (dataTable.Columns.Contains("LastChanged"))
        authority2.LastChanged = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastChanged"]));
      if (dataTable.Columns.Contains("LastChangedById"))
        authority2.SetLastChangedById = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastChangedById"]));
      authority1.Exists = true;
      return authority1;
    }

    public FSM.Entity.Authority.Authority Insert(FSM.Entity.Authority.Authority oAuthority)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Notes", (object) oAuthority.Notes, true);
      this._database.AddParameter("@DateAdded", (object) DateTime.Now, true);
      this._database.AddParameter("@AddedById", (object) App.loggedInUser.UserID, true);
      this._database.AddParameter("@LastChanged", (object) DateTime.Now, true);
      this._database.AddParameter("@LastChangedById", (object) App.loggedInUser.UserID, true);
      oAuthority.SetAuthorityId = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Authority_Insert", true)));
      oAuthority.Exists = true;
      string actionChange = "Added: " + oAuthority.Notes;
      this.Audit_Insert(oAuthority.AuthorityId, actionChange);
      return oAuthority;
    }

    public bool Insert_Site(int siteId, FSM.Entity.Authority.Authority oAuthority)
    {
      bool flag;
      try
      {
        FSM.Entity.Authority.Authority authority = this.Insert(oAuthority);
        this._database.ClearParameter();
        this._database.AddParameter("@SiteId", (object) siteId, true);
        this._database.AddParameter("@AuthorityId", (object) authority.AuthorityId, true);
        this._database.ExecuteSP_OBJECT("SiteAuthority_Insert", true);
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    public bool Insert_Customer(int customerId, FSM.Entity.Authority.Authority oAuthority)
    {
      bool flag;
      try
      {
        FSM.Entity.Authority.Authority authority = this.Insert(oAuthority);
        this._database.ClearParameter();
        this._database.AddParameter("@CustomerId", (object) customerId, true);
        this._database.AddParameter("@AuthorityId", (object) authority.AuthorityId, true);
        this._database.ExecuteSP_OBJECT("CustomerAuthority_Insert", true);
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    public void Update(FSM.Entity.Authority.Authority oAuthority, string change)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@AuthorityId", (object) oAuthority.AuthorityId, true);
      this._database.AddParameter("@Notes", (object) oAuthority.Notes, true);
      this._database.AddParameter("@LastChanged", (object) DateTime.Now, true);
      this._database.AddParameter("@LastChangedById", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return("Authority_Update", true);
      if (string.IsNullOrEmpty(change))
        return;
      this.Audit_Insert(oAuthority.AuthorityId, change);
    }

    public void Audit_Insert(int authorityId, string actionChange)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@AuthorityId", (object) authorityId, true);
      this._database.AddParameter("@ActionChange", (object) actionChange, true);
      this._database.AddParameter("@ActionDateTime", (object) DateTime.Now, true);
      this._database.AddParameter("@UserId", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return("AuthorityAudit_Insert", true);
    }

    public DataView Audit_Get(object @ref, AuthoritySQL.GetBy getBy = AuthoritySQL.GetBy.SiteId)
    {
      this._database.ClearParameter();
      DataTable table;
      switch (getBy)
      {
        case AuthoritySQL.GetBy.SiteId:
          this._database.AddParameter("@SiteId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          table = this._database.ExecuteSP_DataTable("AuthorityAudit_Get_BySiteId", true);
          break;
        case AuthoritySQL.GetBy.CustomerId:
          this._database.AddParameter("@CustomerId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          table = this._database.ExecuteSP_DataTable("AuthorityAudit_Get_ByCustomerId", true);
          break;
        default:
          this._database.AddParameter("@AuthorityId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          table = this._database.ExecuteSP_DataTable("AuthorityAudit_Get", true);
          break;
      }
      table.TableName = Enums.TableNames.tblAuthority.ToString();
      return new DataView(table);
    }

    public enum GetBy
    {
      SiteId = 1,
      CustomerId = 2,
    }
  }
}
