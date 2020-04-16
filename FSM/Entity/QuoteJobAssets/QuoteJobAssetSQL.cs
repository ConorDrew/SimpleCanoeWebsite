// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobAssets.QuoteJobAssetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobAssets
{
  public class QuoteJobAssetSQL
  {
    private Database _database;

    public QuoteJobAssetSQL(Database database)
    {
      this._database = database;
    }

    public QuoteJobAsset Insert(QuoteJobAsset qJobAsset)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) qJobAsset.QuoteJobID, true);
      this._database.AddParameter("@AssetID", (object) qJobAsset.AssetID, true);
      qJobAsset.SetQuoteJobAssetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteJobAsset_Insert", true)));
      return qJobAsset;
    }

    public void Delete(int QuoteJobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) QuoteJobID, true);
      this._database.ExecuteSP_OBJECT("QuoteJobAsset_Delete", true);
    }

    public DataView QuoteJobAsset_Get_For_QuoteJob(int QuoteJobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) QuoteJobID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (QuoteJobAsset_Get_For_QuoteJob), true);
      table.TableName = Enums.TableNames.tblQuoteJobAssets.ToString();
      return new DataView(table);
    }

    public ArrayList QuoteJobAsset_Get_For_QuoteJob_As_Objects(int QuoteJobID)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.QuoteJobAsset_Get_For_QuoteJob(QuoteJobID).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          arrayList.Add((object) new QuoteJobAsset()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetQuoteJobAssetID = RuntimeHelpers.GetObjectValue(current["QuoteJobAssetID"]),
            SetQuoteJobID = RuntimeHelpers.GetObjectValue(current[nameof (QuoteJobID)]),
            SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
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
