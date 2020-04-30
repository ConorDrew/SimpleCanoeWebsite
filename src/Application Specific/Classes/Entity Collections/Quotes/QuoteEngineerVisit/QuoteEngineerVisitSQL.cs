using System.Collections;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteEngineerVisits
    {
        public class QuoteEngineerVisitSQL
        {
            private Sys.Database _database;

            public QuoteEngineerVisitSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public QuoteEngineerVisit Insert(QuoteEngineerVisit qEngineerVisit)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobOfWorkID", qEngineerVisit.QuoteJobOfWorkID, true);
                _database.AddParameter("@StatusEnumID", qEngineerVisit.StatusEnumID, true);
                _database.AddParameter("@NotesToEngineer", qEngineerVisit.NotesToEngineer, true);
                qEngineerVisit.SetQuoteEngineerVisitID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteEngineerVisit_Insert"));
                qEngineerVisit.Exists = true;
                return qEngineerVisit;
            }

            public DataView QuoteEngineerVisits_Get_For_QuoteJob_Of_Work(int QuoteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobOfWorkID", QuoteJobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteEngineerVisits_Get_For_QuoteJob_Of_Work");
                dt.TableName = Sys.Enums.TableNames.tblQuoteEngineerVisit.ToString();
                return new DataView(dt);
            }

            public ArrayList QuoteEngineerVisits_Get_For_QuoteJob_Of_Work_As_Objects(int QuoteJobOfWorkID)
            {
                var engineerVisits = new ArrayList();
                foreach (DataRow row in QuoteEngineerVisits_Get_For_QuoteJob_Of_Work(QuoteJobOfWorkID).Table.Rows)
                {
                    var visit = new QuoteEngineerVisit();
                    visit.IgnoreExceptionsOnSetMethods = true;
                    visit.Exists = true;
                    visit.SetQuoteEngineerVisitID = row["QuoteEngineerVisitID"];
                    visit.SetQuoteJobOfWorkID = row["QuoteJobOfWorkID"];
                    visit.SetStatusEnumID = row["StatusEnumID"];
                    visit.SetNotesToEngineer = row["NotesToEngineer"];
                    visit.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
                    engineerVisits.Add(visit);
                }

                return engineerVisits;
            }

            
        }
    }
}