
namespace FSM.Entity
{
    namespace QuoteJobProductss
    {
        public class QuoteJobProductsSQL
        {
            private Sys.Database _database;

            public QuoteJobProductsSQL(Sys.Database database)
            {
                _database = database;
            }

            

            public void Delete(int QuoteJobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteJobID", QuoteJobID, true);
                _database.ExecuteSP_NO_Return("QuoteJobProducts_Delete");
            }

            public QuoteJobProducts Insert(QuoteJobProducts oQuoteJobProducts)
            {
                _database.ClearParameter();
                AddQuoteJobProductsParametersToCommand(ref oQuoteJobProducts);
                oQuoteJobProducts.SetQuoteJobProductsID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteJobProducts_Insert"));
                oQuoteJobProducts.Exists = true;
                return oQuoteJobProducts;
            }

            private void AddQuoteJobProductsParametersToCommand(ref QuoteJobProducts oQuoteJobProducts)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@QuoteJobID", oQuoteJobProducts.QuoteJobID, true);
                    withBlock.AddParameter("@ProductID", oQuoteJobProducts.ProductID, true);
                    withBlock.AddParameter("@Quantity", oQuoteJobProducts.Quantity, true);
                    withBlock.AddParameter("@SellPrice", oQuoteJobProducts.SellPrice, true);
                }
            }

            
        }
    }
}