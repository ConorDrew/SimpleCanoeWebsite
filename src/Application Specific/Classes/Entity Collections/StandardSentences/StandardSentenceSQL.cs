using System.Data;

namespace FSM.Entity
{
    namespace StandardSentences
    {
        public class StandardSentenceSQL
        {
            private Sys.Database _database;

            public StandardSentenceSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("StandardSentence_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblStandardSentences.ToString();
                return new DataView(dt);
            }

            public void Insert(StandardSentence oStandardSentence)
            {
                _database.ClearParameter();
                AddSentenceParametersToCommand(ref oStandardSentence);
                _database.ExecuteSP_NO_Return("StandardSentence_Insert");
            }

            public void Update(StandardSentence oStandardSentence)
            {
                _database.ClearParameter();
                _database.AddParameter("@SentenceID", oStandardSentence.SentenceID, true);
                AddSentenceParametersToCommand(ref oStandardSentence);
                _database.ExecuteSP_NO_Return("StandardSentence_Update");
            }

            private void AddSentenceParametersToCommand(ref StandardSentence oStandardSentence)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Sentence", oStandardSentence.Sentence, true);
                }
            }

            public void Delete(int SentenceID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SentenceID", SentenceID, true);
                _database.ExecuteSP_NO_Return("StandardSentence_Delete");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

        }
    }
}