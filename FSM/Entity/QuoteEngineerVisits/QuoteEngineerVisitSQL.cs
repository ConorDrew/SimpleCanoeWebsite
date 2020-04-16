// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteEngineerVisits.QuoteEngineerVisitSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteEngineerVisits
{
  public class QuoteEngineerVisitSQL
  {
    private Database _database;

    public QuoteEngineerVisitSQL(Database database)
    {
      this._database = database;
    }

    public QuoteEngineerVisit Insert(QuoteEngineerVisit qEngineerVisit)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobOfWorkID", (object) qEngineerVisit.QuoteJobOfWorkID, true);
      this._database.AddParameter("@StatusEnumID", (object) qEngineerVisit.StatusEnumID, true);
      this._database.AddParameter("@NotesToEngineer", (object) qEngineerVisit.NotesToEngineer, true);
      qEngineerVisit.SetQuoteEngineerVisitID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteEngineerVisit_Insert", true)));
      qEngineerVisit.Exists = true;
      return qEngineerVisit;
    }

    public DataView QuoteEngineerVisits_Get_For_QuoteJob_Of_Work(int QuoteJobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobOfWorkID", (object) QuoteJobOfWorkID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (QuoteEngineerVisits_Get_For_QuoteJob_Of_Work), true);
      table.TableName = Enums.TableNames.tblQuoteEngineerVisit.ToString();
      return new DataView(table);
    }

    public ArrayList QuoteEngineerVisits_Get_For_QuoteJob_Of_Work_As_Objects(
      int QuoteJobOfWorkID)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.QuoteEngineerVisits_Get_For_QuoteJob_Of_Work(QuoteJobOfWorkID).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          arrayList.Add((object) new QuoteEngineerVisit()
          {
            IgnoreExceptionsOnSetMethods = true,
            Exists = true,
            SetQuoteEngineerVisitID = RuntimeHelpers.GetObjectValue(current["QuoteEngineerVisitID"]),
            SetQuoteJobOfWorkID = RuntimeHelpers.GetObjectValue(current[nameof (QuoteJobOfWorkID)]),
            SetStatusEnumID = RuntimeHelpers.GetObjectValue(current["StatusEnumID"]),
            SetNotesToEngineer = RuntimeHelpers.GetObjectValue(current["NotesToEngineer"]),
            SetDeleted = Conversions.ToBoolean(current["Deleted"])
          });
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }
  }
}
