using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOption3s
    {
        public class ContractOption3SQL
        {
            private Sys.Database _database;

            public ContractOption3SQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                _database.ExecuteSP_NO_Return("ContractOption3_Delete");
            }

            public ContractOption3 ContractOption3_Get(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractOption3_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractOption3 = new ContractOption3();
                        oContractOption3.IgnoreExceptionsOnSetMethods = true;
                        oContractOption3.SetContractID = dt.Rows[0]["ContractID"];
                        oContractOption3.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oContractOption3.SetContractReference = dt.Rows[0]["ContractReference"];
                        oContractOption3.SetContractStatusID = dt.Rows[0]["ContractStatusID"];
                        oContractOption3.SetContractPrice = dt.Rows[0]["ContractPrice"];
                        oContractOption3.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oContractOption3.Exists = true;
                        return oContractOption3;
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

            public double ContractCalculatedTotal(int ContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", ContractID, true);
                return Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("ContractOptionCalculatedTotal"));
            }

            public ContractOption3 ContractOption3_Get_For_Quote_ID(int QuoteContractID)
            {
                _database.ClearParameter();
                _database.AddParameter("@QuoteContractID", QuoteContractID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("ContractOption3_Get_For_Quote_ID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oContractOption3 = new ContractOption3();
                        oContractOption3.IgnoreExceptionsOnSetMethods = true;
                        oContractOption3.SetContractID = dt.Rows[0]["ContractID"];
                        oContractOption3.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oContractOption3.SetContractReference = dt.Rows[0]["ContractReference"];
                        oContractOption3.SetContractStatusID = dt.Rows[0]["ContractStatusID"];
                        oContractOption3.SetContractPrice = dt.Rows[0]["ContractPrice"];
                        oContractOption3.SetQuoteContractID = dt.Rows[0]["QuoteContractID"];
                        oContractOption3.Exists = true;
                        return oContractOption3;
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

            public DataView ContractOption3_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("ContractOption3_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblContractOption3.ToString();
                return new DataView(dt);
            }

            public ContractOption3 Insert(ContractOption3 oContractOption3)
            {
                _database.ClearParameter();
                AddContractOption3ParametersToCommand(ref oContractOption3);
                oContractOption3.SetContractID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOption3_Insert"));
                oContractOption3.Exists = true;
                return oContractOption3;
            }

            public void Update(ContractOption3 oContractOption3)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractID", oContractOption3.ContractID, true);
                AddContractOption3ParametersToCommand(ref oContractOption3);
                _database.ExecuteSP_NO_Return("ContractOption3_Update");
            }

            private void AddContractOption3ParametersToCommand(ref ContractOption3 oContractOption3)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CustomerID", oContractOption3.CustomerID, true);
                    withBlock.AddParameter("@ContractReference", oContractOption3.ContractReference, true);
                    withBlock.AddParameter("@ContractStatusID", oContractOption3.ContractStatusID, true);
                    withBlock.AddParameter("@ContractPrice", oContractOption3.ContractPrice, true);
                    withBlock.AddParameter("@QuoteContractID", oContractOption3.QuoteContractID, true);
                }
            }

            public DataTable ContractReference_Get(string prefix, string postfix)
            {
                int maxNumRef = 0;
                var dtReturn = new DataTable();
                dtReturn.Columns.Add("REF");
                _database.ClearParameter();
                _database.AddParameter("@PREFIX", prefix, true);
                _database.AddParameter("@POSTFIX", postfix, true);
                var dt = _database.ExecuteSP_DataTable("ContractReference_Get");
                if (dt.Rows.Count > 0)
                {
                    maxNumRef = Conversions.ToInteger(dt.Rows[0]["Numpart"]);
                }

                int cnt = 0;
                for (int i = 1, loopTo = maxNumRef - 1; i <= loopTo; i++)
                {
                    if (dt.Select("Numpart=" + i).Length == 0)
                    {
                        DataRow nr;
                        nr = dtReturn.NewRow();
                        nr["REF"] = i;
                        dtReturn.Rows.Add(nr);
                        cnt += 1;
                        if (cnt >= 10)
                        {
                            break;
                        }
                    }
                }

                DataRow extraRw;
                extraRw = dtReturn.NewRow();
                extraRw["REF"] = maxNumRef + 1;
                dtReturn.Rows.Add(extraRw);
                dtReturn.TableName = Sys.Enums.TableNames.tblContractOption3.ToString();
                return dtReturn;
            }

            public bool ContractReference_CheckUnique(string ContractReference, int customerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ContractReference", ContractReference, true);
                _database.AddParameter("@customerID", customerID, true);
                var dt = _database.ExecuteSP_DataTable("ContractReference_CheckUnique");
                if (dt.Rows.Count > 0)
                {
                    return false; // Not unique
                }
                else
                {
                    return true;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}