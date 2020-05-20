using System;
using System.Data;

namespace FSM.Entity
{
    namespace PartsToBeCrediteds
    {
        public class PartsToBeCreditedSQL
        {
            private Sys.Database _database;

            public PartsToBeCreditedSQL(Sys.Database database)
            {
                _database = database;
            }

            public PartsToBeCredited PartsToBeCredited_Get(int PartsToBeCreditedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartsToBeCreditedID", PartsToBeCreditedID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get");
                if (dt is null)
                    return null;

                if (dt.Rows.Count == 0)
                    return null;

                var oPartsToBeCredited = new PartsToBeCredited();
                oPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
                oPartsToBeCredited.SetPartsToBeCreditedID = dt.Rows[0]["PartsToBeCreditedID"];
                oPartsToBeCredited.SetOrderID = dt.Rows[0]["OrderID"];
                oPartsToBeCredited.SetSupplierID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["SupplierID"]);
                oPartsToBeCredited.SetPartID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["PartID"]);
                oPartsToBeCredited.SetQty = dt.Rows[0]["Qty"];
                oPartsToBeCredited.SetManuallyAdded = Sys.Helper.MakeBooleanValid(dt.Rows[0]["ManuallyAdded"]);
                oPartsToBeCredited.SetStatusID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["StatusID"]);
                oPartsToBeCredited.SetCreditReceived = Sys.Helper.MakeDoubleValid(dt.Rows[0]["CreditReceived"]);
                oPartsToBeCredited.SetOrderReference = Sys.Helper.MakeStringValid(dt.Rows[0]["OrderReference"]);
                oPartsToBeCredited.Exists = true;

                return oPartsToBeCredited;
            }

            public DataView PartsToBeCredited_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public DataView PartsToBeCredited_Get_PartsCreditID(int PartCreditID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartCreditID", PartCreditID, true);
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_PartsCreditID");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public DataView PartsToBeCredited_Get_OrderID(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_Order");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public DataView PartsToBeCredited_Get_OrderPartID(int OrderPartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderPartID", OrderPartID, true);
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_OrderPart");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public PartsToBeCredited Insert(PartsToBeCredited oPartsToBeCredited)
            {
                _database.ClearParameter();
                AddPartsToBeCreditedParametersToCommand(ref oPartsToBeCredited);
                _database.AddParameter("@AddedByUserID", App.loggedInUser.UserID, true);
                _database.AddParameter("@OrderPartID", oPartsToBeCredited.PartOrderID, true);
                oPartsToBeCredited.SetPartsToBeCreditedID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartsToBeCredited_Insert"));
                oPartsToBeCredited.Exists = true;
                return oPartsToBeCredited;
            }

            public void Update(PartsToBeCredited oPartsToBeCredited)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartsToBeCreditedID", oPartsToBeCredited.PartsToBeCreditedID, true);
                AddPartsToBeCreditedParametersToCommand(ref oPartsToBeCredited);
                _database.ExecuteSP_NO_Return("PartsToBeCredited_Update");
            }

            private void AddPartsToBeCreditedParametersToCommand(ref PartsToBeCredited oPartsToBeCredited)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@OrderID", oPartsToBeCredited.OrderID, true);
                    withBlock.AddParameter("@SupplierID", oPartsToBeCredited.SupplierID, true);
                    withBlock.AddParameter("@PartID", oPartsToBeCredited.PartID, true);
                    withBlock.AddParameter("@Qty", oPartsToBeCredited.Qty, true);
                    withBlock.AddParameter("@ManuallyAdded", oPartsToBeCredited.ManuallyAdded, true);
                    withBlock.AddParameter("@StatusID", oPartsToBeCredited.StatusID, true);
                    withBlock.AddParameter("@CreditReceived", oPartsToBeCredited.CreditReceived, true);
                    withBlock.AddParameter("@OrderReference", oPartsToBeCredited.OrderReference, true);
                }
            }

            public int PartCredits_Insert(double AmountReceived, string Notes, DateTime DateReceived, DateTime DateExportedToSage, int TaxCodeID, string NominalCode, string DepartmentRef, string ExtraRef, string SupplierCreditRef)

            {
                _database.ClearParameter();
                _database.AddParameter("@AmountReceived", AmountReceived, true);
                _database.AddParameter("@Notes", Notes, true);
                _database.AddParameter("@DateReceived", DateReceived, true);
                if (DateExportedToSage == DateTime.MinValue)
                {
                    _database.AddParameter("@DateExportedToSage", DBNull.Value, true);
                }
                else
                {
                    _database.AddParameter("@DateExportedToSage", DateExportedToSage, true);
                }

                _database.AddParameter("@TaxCodeID", TaxCodeID, true);
                _database.AddParameter("@NominalCode", NominalCode, true);
                _database.AddParameter("@DepartmentRef", DepartmentRef, true);
                _database.AddParameter("@ExtraRef", ExtraRef, true);
                _database.AddParameter("@SupplierCreditRef", SupplierCreditRef, true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartCredits_Insert"));
            }

            public int PartCredits_Update(int PartCreditsID, double AmountReceived, string Notes, DateTime DateReceived, DateTime DateExportedToSage, int TaxCodeID, string NominalCode, string DepartmentRef, string ExtraRef, string SupplierCreditRef)

            {
                _database.ClearParameter();
                _database.AddParameter("@PartCreditsID", PartCreditsID, true);
                _database.AddParameter("@AmountReceived", AmountReceived, true);
                _database.AddParameter("@Notes", Notes, true);
                _database.AddParameter("@DateReceived", DateReceived, true);
                if (DateExportedToSage == DateTime.MinValue)
                {
                    _database.AddParameter("@DateExportedToSage", DBNull.Value, true);
                }
                else
                {
                    _database.AddParameter("@DateExportedToSage", DateExportedToSage, true);
                }

                _database.AddParameter("@TaxCodeID", TaxCodeID, true);
                _database.AddParameter("@NominalCode", NominalCode, true);
                _database.AddParameter("@DepartmentRef", DepartmentRef, true);
                _database.AddParameter("@ExtraRef", ExtraRef, true);
                _database.AddParameter("@SupplierCreditRef", SupplierCreditRef, true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartCredits_Update"));
            }

            public void Delete(int CreditID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CreditID", CreditID, true);
                _database.ExecuteSP_NO_Return("PartsToBeCredited_Delete");
            }

            public DataView PartsToBeCredited_Get_Parts_For_CreditID(int PartCreditID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CreditID", PartCreditID, true);
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_CreditID");
                dt.TableName = Sys.Enums.TableNames.tblPartsToBeCredited.ToString();
                return new DataView(dt);
            }

            public PartsToBeCrediteds.PartsToBeCredited PartsToBeCredited_Get_Parts_For_CreditIDEntity(int PartCreditID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CreditID", PartCreditID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_CreditID");
                if (dt is null)
                    return null;

                if (dt.Rows.Count == 0)
                    return null;

                var oPartsToBeCredited = new PartsToBeCrediteds.PartsToBeCredited();
                oPartsToBeCredited.IgnoreExceptionsOnSetMethods = true;
                oPartsToBeCredited.SetPartsToBeCreditedID = dt.Rows[0]["PartsToBeCreditedID"];
                oPartsToBeCredited.SetCreditRef = dt.Rows[0]["SupplierCreditRef"];
                oPartsToBeCredited.SetExtraRef = dt.Rows[0]["ExtraRef"];
                oPartsToBeCredited.SetNominalCode = dt.Rows[0]["NominalCode"];
                oPartsToBeCredited.SetTaxCodeID = dt.Rows[0]["TaxCodeID"];
                oPartsToBeCredited.SetAmountReceived = dt.Rows[0]["AmountReceived"];
                oPartsToBeCredited.SetDateExportedToSage = dt.Rows[0]["DateExportedToSage"].ToString();
                oPartsToBeCredited.SetDateReceived = dt.Rows[0]["DateReceived"].ToString();
                oPartsToBeCredited.SetPartsToBeCreditedID = dt.Rows[0]["PartsToBeCreditedID"];
                oPartsToBeCredited.SetOrderID = dt.Rows[0]["OrderID"];
                oPartsToBeCredited.SetSupplierID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows[0]["SupplierID"]);
                oPartsToBeCredited.SetPartID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows[0]["PartID"]);
                oPartsToBeCredited.SetQty = dt.Rows[0]["Qty"];
                oPartsToBeCredited.SetManuallyAdded = Entity.Sys.Helper.MakeBooleanValid(dt.Rows[0]["ManuallyAdded"]);
                oPartsToBeCredited.SetStatusID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows[0]["StatusID"]);
                oPartsToBeCredited.SetCreditReceived = Entity.Sys.Helper.MakeDoubleValid(dt.Rows[0]["CreditReceived"]);
                oPartsToBeCredited.SetOrderReference = Entity.Sys.Helper.MakeStringValid(dt.Rows[0]["OrderReference"]);
                oPartsToBeCredited.Exists = true;

                return oPartsToBeCredited;
            }

            public int PartsToBeCredited_Insert(int SupplierID, int OrderID, int PartID, int Quantity, string OrderRef, int EngineerID, int OrderPArtID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierID", SupplierID, true);
                _database.AddParameter("@OrderID", OrderID, true);
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@Qty", Quantity, true);
                _database.AddParameter("@ManuallyAdded", 0, true);
                _database.AddParameter("@StatusID", 1, true);
                _database.AddParameter("@CreditReceived", 0.0, true);
                _database.AddParameter("@AddedByUserID", 2, true);
                _database.AddParameter("@OrderReference", OrderRef, true);
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.AddParameter("@DatePartReturned", DBNull.Value, true);
                _database.AddParameter("@OrderPartID", OrderPArtID, true);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartsToBeCredited_Insert"));
            }
        }
    }
}