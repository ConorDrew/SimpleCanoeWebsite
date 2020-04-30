using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Suppliers
    {
        public class SupplierSQL
        {
            private Sys.Database _database;

            public SupplierSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(int SupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierID", SupplierID, true);
                _database.ExecuteSP_NO_Return("Supplier_Delete");
            }

            public Supplier Supplier_Get(int SupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierID", SupplierID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Supplier_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSupplier = new Supplier();
                        oSupplier.IgnoreExceptionsOnSetMethods = true;
                        oSupplier.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oSupplier.SetAccountNumber = dt.Rows[0]["AccountNumber"];
                        if (dt.Columns.Contains("SecondAccountNumber"))
                            oSupplier.SetSecondAccountNumber = dt.Rows[0]["SecondAccountNumber"];
                        oSupplier.SetName = dt.Rows[0]["Name"];
                        oSupplier.SetAddress1 = dt.Rows[0]["Address1"];
                        oSupplier.SetAddress2 = dt.Rows[0]["Address2"];
                        oSupplier.SetAddress3 = dt.Rows[0]["Address3"];
                        oSupplier.SetAddress4 = dt.Rows[0]["Address4"];
                        oSupplier.SetAddress5 = dt.Rows[0]["Address5"];
                        oSupplier.SetPostcode = dt.Rows[0]["Postcode"];
                        oSupplier.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oSupplier.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oSupplier.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oSupplier.SetNotes = dt.Rows[0]["Notes"];
                        oSupplier.SetGaswayAccount = Sys.Helper.MakeStringValid(dt.Rows[0]["GaswayAccount"]);
                        oSupplier.SetMasterSupplierID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["MasterSupplierID"]);
                        oSupplier.SetReleaseToTablets = dt.Rows[0]["ReleaseToTablets"];
                        oSupplier.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oSupplier.SetSubContractor = dt.Rows[0]["SubContractor"];
                        oSupplier.SecondaryPrice = Sys.Helper.MakeBooleanValid(dt.Rows[0]["SecondaryPrice"]);
                        oSupplier.SetDefaultNominal = dt.Rows[0]["DefaultNominal"];
                        oSupplier.Exists = true;
                        return oSupplier;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public Supplier Supplier_Get(int SupplierID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Supplier_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@SupplierID", SupplierID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSupplier = new Supplier();
                        oSupplier.IgnoreExceptionsOnSetMethods = true;
                        oSupplier.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oSupplier.SetAccountNumber = dt.Rows[0]["AccountNumber"];
                        if (dt.Columns.Contains("SecondAccountNumber"))
                            oSupplier.SetSecondAccountNumber = dt.Rows[0]["SecondAccountNumber"];
                        oSupplier.SetName = dt.Rows[0]["Name"];
                        oSupplier.SetAddress1 = dt.Rows[0]["Address1"];
                        oSupplier.SetAddress2 = dt.Rows[0]["Address2"];
                        oSupplier.SetAddress3 = dt.Rows[0]["Address3"];
                        oSupplier.SetAddress4 = dt.Rows[0]["Address4"];
                        oSupplier.SetAddress5 = dt.Rows[0]["Address5"];
                        oSupplier.SetPostcode = dt.Rows[0]["Postcode"];
                        oSupplier.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oSupplier.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oSupplier.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oSupplier.SetNotes = dt.Rows[0]["Notes"];
                        oSupplier.SetGaswayAccount = Sys.Helper.MakeStringValid(dt.Rows[0]["GaswayAccount"]);
                        oSupplier.SetMasterSupplierID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["MasterSupplierID"]);
                        oSupplier.SetReleaseToTablets = dt.Rows[0]["ReleaseToTablets"];
                        oSupplier.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oSupplier.SetSubContractor = dt.Rows[0]["SubContractor"];
                        oSupplier.Exists = true;
                        return oSupplier;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView Supplier_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Supplier_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblSupplier.ToString();
                return new DataView(dt);
            }

            public DataView Supplier_GetAll(SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Supplier_GetAll";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblSupplier.ToString();
                return new DataView(dt);
            }

            public int GetChildSupplier(int SupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierID", SupplierID, true);
                int ChildID = Conversions.ToInteger(_database.SP_ExecuteScalar("Supplier_GetChildSupplierID"));
                return ChildID;
            }

            public DataView Supplier_Search(string criteria, string SearchOnField)
            {
                if (SearchOnField.Trim().Length > 0)
                {
                    criteria = "'%" + criteria + "%'";
                }

                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                _database.AddParameter("@SearchOnField", SearchOnField, true);
                var dt = _database.ExecuteSP_DataTable("Supplier_SearchList");
                dt.TableName = Sys.Enums.TableNames.tblSupplier.ToString();
                return new DataView(dt);
            }

            public Supplier Insert(Supplier oSupplier)
            {
                _database.ClearParameter();
                AddSupplierParametersToCommand(ref oSupplier);
                oSupplier.SetSupplierID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Supplier_Insert"));
                oSupplier.Exists = true;
                return oSupplier;
            }

            public void Update(Supplier oSupplier)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierID", oSupplier.SupplierID, true);
                AddSupplierParametersToCommand(ref oSupplier);
                _database.ExecuteSP_NO_Return("Supplier_Update");
            }

            private void AddSupplierParametersToCommand(ref Supplier oSupplier)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@AccountNumber", oSupplier.AccountNumber, true);
                    withBlock.AddParameter("@SecondAccountNumber", oSupplier.SecondAccountNumber, true);
                    withBlock.AddParameter("@Name", oSupplier.Name, true);
                    withBlock.AddParameter("@Address1", oSupplier.Address1, true);
                    withBlock.AddParameter("@Address2", oSupplier.Address2, true);
                    withBlock.AddParameter("@Address3", oSupplier.Address3, true);
                    withBlock.AddParameter("@Address4", oSupplier.Address4, true);
                    withBlock.AddParameter("@Address5", oSupplier.Address5, true);
                    withBlock.AddParameter("@Postcode", oSupplier.Postcode, true);
                    withBlock.AddParameter("@TelephoneNum", oSupplier.TelephoneNum, true);
                    withBlock.AddParameter("@FaxNum", oSupplier.FaxNum, true);
                    withBlock.AddParameter("@EmailAddress", oSupplier.EmailAddress, true);
                    withBlock.AddParameter("@Notes", oSupplier.Notes, true);
                    withBlock.AddParameter("@GaswayAccount", oSupplier.GaswayAccount, true);
                    withBlock.AddParameter("@MasterSupplierID", oSupplier.MasterSupplierID, true);
                    withBlock.AddParameter("@ReleaseToTablets", oSupplier.ReleaseToTablets, true);
                    withBlock.AddParameter("@SubContractor", oSupplier.SubContractor, true);
                    withBlock.AddParameter("@SecondaryPrice", oSupplier.SecondaryPrice, true);
                    withBlock.AddParameter("@DefaultNominal", oSupplier.DefaultNominal, true);
                }
            }

            public DataView Supplier_GetWithProduct(int ProductID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ProductID", ProductID);

                // Get the datatable from the database store in dt
                return new DataView(_database.ExecuteSP_DataTable("Supplier_GetWithProduct"));
            }

            public DataView Supplier_GetWithProduct(int ProductID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Supplier_GetWithProduct";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                return new DataView(dt);
            }

            public DataView Supplier_GetWithPart(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID);

                // Get the datatable from the database store in dt
                return new DataView(_database.ExecuteSP_DataTable("Supplier_GetWithPart"));
            }

            public DataView Supplier_GetWithPart(int PartID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Supplier_GetWithPart";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartID", PartID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                return new DataView(dt);
            }

            public bool Supplier_GetSecondaryPrice(int SupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierID", SupplierID, true);
                int hasSecondaryPrice = Conversions.ToInteger(_database.SP_ExecuteScalar("Supplier_HasSecondaryPrice"));
                return Conversions.ToBoolean(hasSecondaryPrice);
            }

            
        }
    }
}