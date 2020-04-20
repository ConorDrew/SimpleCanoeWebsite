// Decompiled with JetBrains decompiler
// Type: FSM.Entity.StandardSentences.StandardSentenceSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;

namespace FSM.Entity.StandardSentences
{
    public class StandardSentenceSQL
    {
        private Database _database;

        public StandardSentenceSQL(Database database)
        {
            this._database = database;
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("StandardSentence_GetAll", true);
            table.TableName = Enums.TableNames.tblStandardSentences.ToString();
            return new DataView(table);
        }

        public void Insert(StandardSentence oStandardSentence)
        {
            this._database.ClearParameter();
            this.AddSentenceParametersToCommand(ref oStandardSentence);
            this._database.ExecuteSP_NO_Return("StandardSentence_Insert", true);
        }

        public void Update(StandardSentence oStandardSentence)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SentenceID", (object)oStandardSentence.SentenceID, true);
            this.AddSentenceParametersToCommand(ref oStandardSentence);
            this._database.ExecuteSP_NO_Return("StandardSentence_Update", true);
        }

        private void AddSentenceParametersToCommand(ref StandardSentence oStandardSentence)
        {
            this._database.AddParameter("@Sentence", (object)oStandardSentence.Sentence, true);
        }

        public void Delete(int SentenceID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SentenceID", (object)SentenceID, true);
            this._database.ExecuteSP_NO_Return("StandardSentence_Delete", true);
        }
    }
}