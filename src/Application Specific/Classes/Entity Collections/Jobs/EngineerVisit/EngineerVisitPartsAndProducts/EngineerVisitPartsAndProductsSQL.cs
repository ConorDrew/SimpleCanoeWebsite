using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitsPartsAndProducts
    {
        public class EngineerVisitPartsAndProductsSQL
        {
            private Sys.Database _database;

            public EngineerVisitPartsAndProductsSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID2");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
                int c = dt.Constraints.Count;
                return new DataView(dt);
            }

            public DataView EngineerVisitPartsAndProductsNeeded_Get_For_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsNeeded_Get_For_EngineerVisitID");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
                return new DataView(dt);
            }

            public void PartsUsed_Delete(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Delete");
            }

            public void PartsUsed_Insert(EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", oEngineerVisitPartsAndProducts.EngineerVisitID, true);
                _database.AddParameter("@PartID", oEngineerVisitPartsAndProducts.PartOrProductID, true);
                _database.AddParameter("@Quantity", oEngineerVisitPartsAndProducts.Quantity, true);
                _database.AddParameter("@AssetID", oEngineerVisitPartsAndProducts.AssetID, true);
                _database.AddParameter("@EngineerVisitPartAllocatedID", oEngineerVisitPartsAndProducts.AllocatedID, true);
                _database.AddParameter("@LocationID", oEngineerVisitPartsAndProducts.LocationID, true);
                if (string.IsNullOrEmpty(oEngineerVisitPartsAndProducts.SpecialDescription))  // dont insert blanks as this will cause the datagrid to show blanks the values need to be Null in DB
                {
                }
                else
                {
                    _database.AddParameter("@SpecialPrice", oEngineerVisitPartsAndProducts.SpecialPrice, true);
                    _database.AddParameter("@SpecialDescription", oEngineerVisitPartsAndProducts.SpecialDescription, true);
                    _database.AddParameter("@SpecialPartNumber", oEngineerVisitPartsAndProducts.SpecialPartNumber, true);
                }

                _database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Insert");
            }

            public void ProductsUsed_Delete(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Delete");
            }

            public void ProductsUsed_Insert(EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", oEngineerVisitPartsAndProducts.EngineerVisitID, true);
                _database.AddParameter("@ProductID", oEngineerVisitPartsAndProducts.PartOrProductID, true);
                _database.AddParameter("@Quantity", oEngineerVisitPartsAndProducts.Quantity, true);
                _database.AddParameter("@EngineerVisitProductAllocatedID", oEngineerVisitPartsAndProducts.AllocatedID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Insert");
            }

            public void PartsNeeded_Delete(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartsNeeded_Delete");
            }

            public void PartsNeeded_Insert(EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", oEngineerVisitPartsAndProducts.EngineerVisitID, true);
                _database.AddParameter("@PartID", oEngineerVisitPartsAndProducts.PartOrProductID, true);
                _database.AddParameter("@Quantity", oEngineerVisitPartsAndProducts.Quantity, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartsNeeded_Insert");
            }

            public void ProductsNeeded_Delete(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitProductsNeeded_Delete");
            }

            public void ProductsNeeded_Insert(EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", oEngineerVisitPartsAndProducts.EngineerVisitID, true);
                _database.AddParameter("@ProductID", oEngineerVisitPartsAndProducts.PartOrProductID, true);
                _database.AddParameter("@Quantity", oEngineerVisitPartsAndProducts.Quantity, true);
                _database.ExecuteSP_NO_Return("EngineerVisitProductsNeeded_Insert");
            }

            public DataView EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution2(int id)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", id, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3(int id)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", id, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
                return new DataView(dt);
            }

            public DataView Parts_Used_Report(DateTime fromDate, DateTime toDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@fromDate", fromDate, true);
                _database.AddParameter("@toDate", toDate, true);
                _database.AddParameter("@OrderLocationSupplierEnumValue", Conversions.ToInteger(Sys.Enums.LocationType.Supplier), true);
                var dt = _database.ExecuteSP_DataTable("Parts_Used_Report");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public DataView Equipment_Used_Report(DateTime fromDate, DateTime toDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@fromDate", fromDate, true);
                _database.AddParameter("@toDate", toDate, true);
                var dt = _database.ExecuteSP_DataTable("Equipment_Used_Report");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public void PartsUsed_DeleteOne(int EngineerVisitPartsUsedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitPartsUsedID", EngineerVisitPartsUsedID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Delete_One");
            }

            public void ProductsUsed_DeleteOne(int EngineerVisitProductsUsedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitProductsUsedID", EngineerVisitProductsUsedID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Delete_One");
            }

            public void ProductsUsed_Update(int EngineerVisitProductsUsedID, int Quantity)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitProductsUsedID", EngineerVisitProductsUsedID, true);
                _database.AddParameter("@Quantity", Quantity, true);
                _database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_UpdateQty");
            }

            public void PartsUsed_Update(int EngineerVisitPartsUsedID, int Quantity)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitPartsUsedID", EngineerVisitPartsUsedID, true);
                _database.AddParameter("@Quantity", Quantity, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_UpdateQty");
            }

            public DataView Get_CurrentCost_ByJobID(int jobId)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitParts_Get_CurrentCost_ByJobID");
                return new DataView(dt);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}