// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteContractAlternativeSites.QuoteContractAlternativeSiteSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteContractAlternativeSites
{
  public class QuoteContractAlternativeSiteSQL
  {
    private Database _database;

    public QuoteContractAlternativeSiteSQL(Database database)
    {
      this._database = database;
    }

    public QuoteContractAlternativeSite Get(int QuoteContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteID", (object) QuoteContractSiteID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSite_Get", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (QuoteContractAlternativeSite) null;
      QuoteContractAlternativeSite contractAlternativeSite1 = new QuoteContractAlternativeSite();
      QuoteContractAlternativeSite contractAlternativeSite2 = contractAlternativeSite1;
      contractAlternativeSite2.IgnoreExceptionsOnSetMethods = true;
      contractAlternativeSite2.SetQuoteContractSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (QuoteContractSiteID)]);
      contractAlternativeSite2.SetQuoteContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteContractID"]);
      contractAlternativeSite2.SetSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
      contractAlternativeSite2.JobOfWorks = this._database.QuoteContractAlternativeSiteJobOfWork.Get_For_QuoteContractSite_As_Objects(QuoteContractSiteID);
      contractAlternativeSite1.Exists = true;
      return contractAlternativeSite1;
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSite_GetAll", true);
      table.TableName = Enums.TableNames.tblQuoteContractSite.ToString();
      return new DataView(table);
    }

    public DataView GetAll_QuoteContractID(int QuoteContractID, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractID", (object) QuoteContractID, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      DataTable table = this._database.ExecuteSP_DataTable("QuoteContractAlternativeSite_GetAll_QuoteContractID", true);
      table.TableName = Enums.TableNames.tblQuoteContractSite.ToString();
      return new DataView(table);
    }

    public QuoteContractAlternativeSite Insert(
      QuoteContractAlternativeSite oQuoteContractSite)
    {
      this._database.ClearParameter();
      this.AddContractSiteParametersToCommand(ref oQuoteContractSite);
      oQuoteContractSite.SetQuoteContractSiteID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_Insert", true)));
      oQuoteContractSite.Exists = true;
      return oQuoteContractSite;
    }

    public void Update(QuoteContractAlternativeSite oQuoteContractSite)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteID", (object) oQuoteContractSite.QuoteContractSiteID, true);
      this.AddContractSiteParametersToCommand(ref oQuoteContractSite);
      this._database.ExecuteSP_NO_Return("QuoteContractAlternativeSite_Update", true);
    }

    public int Delete(int QuoteContractSiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteID", (object) QuoteContractSiteID, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_Delete", true));
    }

    public int ActiveInactive(int QuoteContractSiteID, bool InactiveFlag)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteContractSiteID", (object) QuoteContractSiteID, true);
      this._database.AddParameter("@DownloadStatus", (object) 6, true);
      this._database.AddParameter("@InactiveFlag", (object) InactiveFlag, true);
      return Conversions.ToInteger(this._database.ExecuteSP_OBJECT("QuoteContractAlternativeSite_ActiveInactive", true));
    }

    private void AddContractSiteParametersToCommand(
      ref QuoteContractAlternativeSite oQuoteContractSite)
    {
      Database database = this._database;
      database.AddParameter("@QuoteContractID", (object) oQuoteContractSite.QuoteContractID, true);
      database.AddParameter("@SiteID", (object) oQuoteContractSite.SiteID, true);
    }
  }
}
