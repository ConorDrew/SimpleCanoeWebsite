using System.Data;

namespace FSM.Entity
{
    namespace ProductAssociatedParts
    {
        public class ProductAssociatedPartSQL
        {
            private Sys.Database _database;

            public ProductAssociatedPartSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll_For_ProductID(int ProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductID", ProductID, true);
                var dt = _database.ExecuteSP_DataTable("ProductAssociatedPart_GetAll_For_ProductID");
                dt.TableName = Sys.Enums.TableNames.tblProductAssociatedPart.ToString();
                return new DataView(dt);
            }

            public void Insert(ProductAssociatedPart oProductAssociatedPart)
            {
                _database.ClearParameter();
                AddProductAssociatedPartParametersToCommand(ref oProductAssociatedPart);
                _database.ExecuteSP_NO_Return("ProductAssociatedPart_Insert");
            }

            public void Delete(int ProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductID", ProductID, true);
                _database.ExecuteSP_NO_Return("ProductAssociatedPart_Delete");
            }

            private void AddProductAssociatedPartParametersToCommand(ref ProductAssociatedPart oProductAssociatedPart)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ProductID", oProductAssociatedPart.ProductID, true);
                    withBlock.AddParameter("@PartID", oProductAssociatedPart.PartID, true);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}