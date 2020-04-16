// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SiteCustomerAudits.SiteCustomerAuditSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.SiteCustomerAudits
{
  public class SiteCustomerAuditSQL
  {
    private Database _database;

    public SiteCustomerAuditSQL(Database database)
    {
      this._database = database;
    }

    public DataView SiteCustomerAudit_GetAll(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, false);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (SiteCustomerAudit_GetAll), true);
      table.TableName = Enums.TableNames.tblSite.ToString();
      return new DataView(table);
    }

    public SiteCustomerAudit Insert(SiteCustomerAudit oSiteCustomerAudit)
    {
      this._database.ClearParameter();
      this.AddSiteCustomerAuditParametersToCommand(ref oSiteCustomerAudit);
      oSiteCustomerAudit.SetSiteCustomerAuditID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("SiteCustomerAudit_Insert", true)));
      oSiteCustomerAudit.Exists = true;
      return oSiteCustomerAudit;
    }

    private void AddSiteCustomerAuditParametersToCommand(ref SiteCustomerAudit oSiteCustomerAudit)
    {
      Database database = this._database;
      database.AddParameter("@SiteID", (object) oSiteCustomerAudit.SiteID, true);
      database.AddParameter("@PreviousCustomerID", (object) oSiteCustomerAudit.PreviousCustomerID, true);
      database.AddParameter("@DateChanged", (object) oSiteCustomerAudit.DateChanged, true);
      database.AddParameter("@UserID", (object) oSiteCustomerAudit.UserID, true);
    }
  }
}
