using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace SiteOrders
    {
        public class SiteOrderSQL
        {
            private Sys.Database _database;

            public SiteOrderSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int SiteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteOrderID", SiteOrderID, true);
                _database.ExecuteSP_NO_Return("SiteOrder_Delete");
            }

            public void DeleteByOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.ExecuteSP_NO_Return("SiteOrder_DeleteByOrder");
            }

            public SiteOrder SiteOrder_Get(int SiteOrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteOrderID", SiteOrderID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("SiteOrder_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSiteOrder = new SiteOrder();
                        oSiteOrder.IgnoreExceptionsOnSetMethods = true;
                        oSiteOrder.SetSiteOrderID = dt.Rows[0]["SiteOrderID"];
                        oSiteOrder.SetSiteID = dt.Rows[0]["SiteID"];
                        oSiteOrder.SetOrderID = dt.Rows[0]["OrderID"];
                        oSiteOrder.Exists = true;
                        return oSiteOrder;
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

            public SiteOrder SiteOrder_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("SiteOrder_GetForOrder");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSiteOrder = new SiteOrder();
                        oSiteOrder.IgnoreExceptionsOnSetMethods = true;
                        oSiteOrder.SetSiteOrderID = dt.Rows[0]["SiteOrderID"];
                        oSiteOrder.SetSiteID = dt.Rows[0]["SiteID"];
                        oSiteOrder.SetOrderID = dt.Rows[0]["OrderID"];
                        oSiteOrder.Exists = true;
                        return oSiteOrder;
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

            public DataView SiteOrder_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("SiteOrder_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblSiteOrder.ToString();
                return new DataView(dt);
            }

            public SiteOrder Insert(SiteOrder oSiteOrder, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "SiteOrder_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderID", oSiteOrder.OrderID);
                Command.Parameters.AddWithValue("@SiteID", oSiteOrder.SiteID);
                oSiteOrder.SetSiteOrderID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oSiteOrder.Exists = true;
                return oSiteOrder;
            }

            public SiteOrder Insert(SiteOrder oSiteOrder)
            {
                _database.ClearParameter();
                AddSiteOrderParametersToCommand(ref oSiteOrder);
                oSiteOrder.SetSiteOrderID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SiteOrder_Insert"));
                oSiteOrder.Exists = true;
                return oSiteOrder;
            }

            public void Update(SiteOrder oSiteOrder)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteOrderID", oSiteOrder.SiteOrderID, true);
                AddSiteOrderParametersToCommand(ref oSiteOrder);
                _database.ExecuteSP_NO_Return("SiteOrder_Update");
            }

            private void AddSiteOrderParametersToCommand(ref SiteOrder oSiteOrder)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@SiteID", oSiteOrder.SiteID, true);
                    withBlock.AddParameter("@OrderID", oSiteOrder.OrderID, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}