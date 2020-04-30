using System.Collections;
using System.Data;

namespace FSM.Entity
{
    namespace QuoteJobItems
    {
        public class QuoteJobItemSQL
        {
            private Sys.Database _database;

            public QuoteJobItemSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public QuoteJobItem Insert(QuoteJobItem qJobItem)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobOfWorkID", qJobItem.QuoteJobOfWorkID, true);
                _database.AddParameter("@Summary", qJobItem.Summary, true);
                _database.AddParameter("@RateID", qJobItem.RateID, true);
                _database.AddParameter("@Qty", qJobItem.Qty, true);
                _database.AddParameter("@SystemLinkID", qJobItem.SystemLinkID, true);
                qJobItem.SetQuoteJobItemID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJobItem_Insert"));
                return qJobItem;
            }

            public DataView QuoteJobItems_Get_For_QuoteJob_Of_Work(int QuoteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobOfWorkID", QuoteJobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("QuoteJobItems_Get_For_QuoteJob_Of_Work");
                dt.TableName = Sys.Enums.TableNames.tblQuoteJobItem.ToString();
                return new DataView(dt);
            }

            public ArrayList QuoteJobOfWork_Get_For_QuoteJob_Of_Work_As_Objects(int QuoteJobOfWorkID)
            {
                var jobItems = new ArrayList();
                foreach (DataRow row in QuoteJobItems_Get_For_QuoteJob_Of_Work(QuoteJobOfWorkID).Table.Rows)
                {
                    var jobItem = new QuoteJobItem();
                    jobItem.IgnoreExceptionsOnSetMethods = true;
                    jobItem.SetQuoteJobItemID = row["QuoteJobItemID"];
                    jobItem.SetQuoteJobOfWorkID = row["QuoteJobOfWorkID"];
                    jobItem.SetSummary = row["Summary"];
                    jobItem.SetRateID = row["RateID"];
                    jobItem.SetQty = row["Qty"];
                    jobItem.SetSystemLinkID = row["SystemLinkID"];
                    jobItems.Add(jobItem);
                }

                return jobItems;
            }

            public void Delete(int QuoteJobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobOfWorkID", QuoteJobOfWorkID, true);
                _database.ExecuteSP_NO_Return("QuoteJobItem_Delete");
            }

            
        }
    }
}