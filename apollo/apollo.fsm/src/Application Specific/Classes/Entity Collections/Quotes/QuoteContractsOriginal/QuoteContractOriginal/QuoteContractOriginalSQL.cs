using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOriginals
    {
        public class QuoteContractOriginalSQL
        {
            private Sys.Database _database;

            public QuoteContractOriginalSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID, true);
                _database.ExecuteSP_NO_Return("QuoteContractOriginal_Delete");
            }
        }
    }
}