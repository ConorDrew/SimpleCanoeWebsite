// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Orders.POInvoiceSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;

namespace FSM.Entity.Orders
{
  public class POInvoiceSQL
  {
    private Database _database;

    public POInvoiceSQL(Database database)
    {
      this._database = database;
    }

    public void POInvoiceImport_UpdateAuthorised(
      int ID,
      bool Authorised,
      int AuthorisedByUserID,
      DateTime AuthorisedOn,
      string AuthReason,
      string AuthReasonDetail = "")
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ID", (object) ID, true);
      this._database.AddParameter("@Authorised", (object) Authorised, true);
      this._database.AddParameter("@AuthorisedByUserID", (object) AuthorisedByUserID, true);
      this._database.AddParameter("@AuthorisedOn", (object) AuthorisedOn, true);
      this._database.AddParameter("@AuthReason", (object) AuthReason, true);
      this._database.AddParameter("@AuthReasonDetail", (object) AuthReasonDetail, true);
      this._database.AddParameter("@ValidateResult", (object) 11, true);
      this._database.ExecuteSP_NO_Return("POInvoiceImport_UpdateAuthorisation", true);
    }

    public DataView POInvoiceImport_RefreshData(int ValidateResult, string PODepartment)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ValidateResult", (object) ValidateResult, true);
      this._database.AddParameter("@PODepartment", (object) PODepartment, true);
      DataTable table = this._database.ExecuteSP_DataTable("POInvoiceImport_ShowDataAuthorisation", true);
      table.TableName = "POInvoiceImport_ShowData";
      return new DataView(table);
    }

    public int POExceptionCount(string PODepartment)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PODepartment", (object) PODepartment, true);
      return Conversions.ToInteger(this._database.ExecuteScalar("SELECT COUNT(*) from tblPOInvoiceImport_Orders WHERE RequiresAuthorisation = 1 AND Authorised = 0 AND PODepartment = @PODepartment", true, false));
    }
  }
}
