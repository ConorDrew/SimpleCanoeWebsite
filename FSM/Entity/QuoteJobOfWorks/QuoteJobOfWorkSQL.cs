// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobOfWorks.QuoteJobOfWorkSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobOfWorks
{
    public class QuoteJobOfWorkSQL
    {
        private Database _database;

        public QuoteJobOfWorkSQL(Database database)
        {
            this._database = database;
        }

        public QuoteJobOfWork Insert(QuoteJobOfWork qJobOfWork)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteJobID", (object)qJobOfWork.QuoteJobID, true);
            qJobOfWork.SetQuoteJobOfWorkID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteJobOfWork_Insert", true)));
            qJobOfWork.Exists = true;
            return qJobOfWork;
        }

        public DataView QuoteJobOfWork_Get_For_QuoteJob(int QuoteJobID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@QuoteJobID", (object)QuoteJobID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(QuoteJobOfWork_Get_For_QuoteJob), true);
            table.TableName = Enums.TableNames.tblQuoteJobOfWork.ToString();
            return new DataView(table);
        }

        public ArrayList QuoteJobOfWork_Get_For_QuoteJob_As_Objects(int QuoteJobID)
        {
            ArrayList arrayList = new ArrayList();
            foreach (DataRow current in this.QuoteJobOfWork_Get_For_QuoteJob(QuoteJobID).Table.Rows)
            {
                QuoteJobOfWork quoteJobOfWork = new QuoteJobOfWork()
                {
                    IgnoreExceptionsOnSetMethods = true,
                    Exists = true,
                    SetQuoteJobOfWorkID = RuntimeHelpers.GetObjectValue(current["QuoteJobOFWorkID"]),
                    SetQuoteJobID = RuntimeHelpers.GetObjectValue(current[nameof(QuoteJobID)]),
                    SetDeleted = Conversions.ToBoolean(current["Deleted"])
                };
                quoteJobOfWork.QuoteJobItems = this._database.QuoteJobItems.QuoteJobOfWork_Get_For_QuoteJob_Of_Work_As_Objects(quoteJobOfWork.QuoteJobOfWorkID);
                quoteJobOfWork.QuoteEngineerVisits = this._database.QuoteEngineerVisits.QuoteEngineerVisits_Get_For_QuoteJob_Of_Work_As_Objects(quoteJobOfWork.QuoteJobOfWorkID);
                arrayList.Add((object)quoteJobOfWork);
            }
            return arrayList;
        }
    }
}