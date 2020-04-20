using System.Collections;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteJobOfWorks
    {
        public class QuoteJobOfWorkSQL
        {
            private Sys.Database _database;

            public QuoteJobOfWorkSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public QuoteJobOfWork Insert(QuoteJobOfWork qJobOfWork)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", qJobOfWork.QuoteJobID, true);
                qJobOfWork.SetQuoteJobOfWorkID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJobOfWork_Insert"));
                qJobOfWork.Exists = true;
                return qJobOfWork;
            }

            public DataView QuoteJobOfWork_Get_For_QuoteJob(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteJobOfWork_Get_For_QuoteJob");
                dt.TableName = Sys.Enums.TableNames.tblQuoteJobOfWork.ToString();
                return new DataView(dt);
            }

            public ArrayList QuoteJobOfWork_Get_For_QuoteJob_As_Objects(int QuoteJobID)
            {
                var jobOfWorks = new ArrayList();
                foreach (DataRow row in QuoteJobOfWork_Get_For_QuoteJob(QuoteJobID).Table.Rows)
                {
                    var jobOfWork = new QuoteJobOfWork();
                    jobOfWork.IgnoreExceptionsOnSetMethods = true;
                    jobOfWork.Exists = true;
                    jobOfWork.SetQuoteJobOfWorkID = row["QuoteJobOFWorkID"];
                    jobOfWork.SetQuoteJobID = row["QuoteJobID"];
                    jobOfWork.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
                    jobOfWork.QuoteJobItems = _database.QuoteJobItems.QuoteJobOfWork_Get_For_QuoteJob_Of_Work_As_Objects(jobOfWork.QuoteJobOfWorkID);
                    jobOfWork.QuoteEngineerVisits = _database.QuoteEngineerVisits.QuoteEngineerVisits_Get_For_QuoteJob_Of_Work_As_Objects(jobOfWork.QuoteJobOfWorkID);
                    jobOfWorks.Add(jobOfWork);
                }

                return jobOfWorks;
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}