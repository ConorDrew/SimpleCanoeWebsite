using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartSuppliers
    {
        public class PartSupplierSQL
        {
            private Sys.Database _database;

            public PartSupplierSQL(Sys.Database database)
            {
                _database = database;
            }

            public object PartSupplier_FindTabletOrder(string SearchString, int SupplierID = 0)
            {
                _database.ClearParameter();
                _database.AddParameter("@Find", SearchString, true);
                _database.AddParameter("@SupplierID", SupplierID, true);
                var dt = _database.ExecuteSP_DataTable("PartSupplier_FindForTabletOrder");
                dt.TableName = Sys.Enums.TableNames.tblPartSupplier.ToString();
                return new DataView(dt);
            }

            public object PartSupplier_Search(string SearchString, int SupplierID = 0, bool isFlagShip = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", SearchString, true);
                _database.AddParameter("@SupplierID", SupplierID, true);
                _database.AddParameter("@Flagship", isFlagShip, true);
                var dt = _database.ExecuteSP_DataTable("PartSupplier_Search_2");
                dt.TableName = Sys.Enums.TableNames.tblPart.ToString();
                return new DataView(dt);
            }

            public DataView PartSupplierPacks_Get(int PartID, int SupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@SupplierID", SupplierID, true);
                var dt = _database.ExecuteSP_DataTable("PartSupplierPacks_Get");
                dt.TableName = Sys.Enums.TableNames.tblPartSupplier.ToString();
                return new DataView(dt);
            }

            public DataView PartSupplierPacks_Get(int PartID, int SupplierID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "PartSupplierPacks_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartID", PartID);
                Command.Parameters.AddWithValue("@SupplierID", SupplierID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblPartSupplier.ToString();
                return new DataView(dt);
            }

            public PartSupplier PartSupplier_Get(int PartSupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartSupplierID", PartSupplierID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("PartSupplier_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oPartSupplier = new PartSupplier();
                        oPartSupplier.IgnoreExceptionsOnSetMethods = true;
                        oPartSupplier.SetPartID = dt.Rows[0]["PartID"];
                        oPartSupplier.SetPartSupplierID = dt.Rows[0]["PartSupplierID"];
                        oPartSupplier.SetPartCode = dt.Rows[0]["PartCode"];
                        oPartSupplier.SetPrice = dt.Rows[0]["Price"];
                        oPartSupplier.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oPartSupplier.SetQuantityInPack = dt.Rows[0]["QuantityInPack"];
                        oPartSupplier.SetPreferred = Conversions.ToBoolean(dt.Rows[0]["Preferred"]);
                        if (dt.Columns.Contains("SecondaryPrice"))
                        {
                            oPartSupplier.SetSecondaryPrice = Sys.Helper.MakeDoubleValid(dt.Rows[0]["SecondaryPrice"]);
                        }

                        oPartSupplier.Exists = true;
                        return oPartSupplier;
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

            public PartSupplier PartSupplier_Get(int PartSupplierID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "PartSupplier_Get";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@PartSupplierID", PartSupplierID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oPartSupplier = new PartSupplier();
                        oPartSupplier.IgnoreExceptionsOnSetMethods = true;
                        oPartSupplier.SetPartID = dt.Rows[0]["PartID"];
                        oPartSupplier.SetPartSupplierID = dt.Rows[0]["PartSupplierID"];
                        oPartSupplier.SetPartCode = dt.Rows[0]["PartCode"];
                        oPartSupplier.SetPrice = dt.Rows[0]["Price"];
                        oPartSupplier.SetSupplierID = dt.Rows[0]["SupplierID"];
                        oPartSupplier.SetQuantityInPack = dt.Rows[0]["QuantityInPack"];
                        oPartSupplier.SetPreferred = Conversions.ToBoolean(dt.Rows[0]["Preferred"]);
                        if (dt.Columns.Contains("SecondaryPrice"))
                        {
                            oPartSupplier.SetSecondaryPrice = Sys.Helper.MakeDoubleValid(dt.Rows[0]["SecondaryPrice"]);
                        }

                        oPartSupplier.Exists = true;
                        return oPartSupplier;
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

            public DataView PartSupplierGet_All()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("PartSupplier_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblPartSupplier.ToString();
                return new DataView(dt);
            }

            public DataView Get_ByPartID(int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                var dt = _database.ExecuteSP_DataTable("PartSupplier_GetByPart");
                dt.TableName = Sys.Enums.TableNames.tblPartSupplier.ToString();
                return new DataView(dt);
            }

            public DataView Get_ByPartIDAndSupplierID(int PartID, int SupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartID", PartID, true);
                _database.AddParameter("@SupplierID", SupplierID, true);
                var dt = _database.ExecuteSP_DataTable("PartSupplier_GetByPartAndSupplier");
                dt.TableName = Sys.Enums.TableNames.tblPartSupplier.ToString();
                return new DataView(dt);
            }

            public void Delete(int PartSupplierID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartSupplierID", PartSupplierID, true);
                _database.ExecuteSP_NO_Return("PartSupplier_Delete");
            }

            public PartSupplier Insert(PartSupplier oPartSupplier)
            {
                _database.ClearParameter();
                AddPartSupplierParametersToCommand(ref oPartSupplier);
                oPartSupplier.SetPartSupplierID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplier_Insert"));
                oPartSupplier.Exists = true;
                return oPartSupplier;
            }

            public void Update(PartSupplier oPartSupplier, bool PrimaryDateUpdate = false, bool SecondaryDateUpdate = false)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartSupplierID", oPartSupplier.PartSupplierID, true);
                if (PrimaryDateUpdate)
                {
                    _database.AddParameter("@PrimaryDateUpdate", true, true);
                }

                if (SecondaryDateUpdate)
                {
                    _database.AddParameter("@SecondaryDateUpdate", true, true);
                }

                AddPartSupplierParametersToCommand(ref oPartSupplier);
                _database.ExecuteSP_NO_Return("PartSupplier_Update");
            }

            private void AddPartSupplierParametersToCommand(ref PartSupplier oPartSupplier)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@PartCode", oPartSupplier.PartCode, true);
                    withBlock.AddParameter("@PartID", oPartSupplier.PartID, true);
                    withBlock.AddParameter("@SupplierID", oPartSupplier.SupplierID, true);
                    withBlock.AddParameter("@Price", oPartSupplier.Price, true);
                    withBlock.AddParameter("@QuantityInPack", oPartSupplier.QuantityInPack, true);
                    withBlock.AddParameter("@UserID", App.loggedInUser.UserID, true);
                    if (oPartSupplier.SecondaryPrice > 0)
                    {
                        withBlock.AddParameter("@SecondaryPrice", oPartSupplier.SecondaryPrice, true);
                    }
                }
            }

            public void Update_Preferred(int PartSupplierID, bool Preferred)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartSupplierID", PartSupplierID, true);
                if (Preferred)
                {
                    _database.AddParameter("@Preferred", 1, true);
                }
                else
                {
                    _database.AddParameter("@Preferred", 0, true);
                }

                _database.ExecuteSP_NO_Return("PartSupplier_Update_Preferred");
            }
        }
    }
}