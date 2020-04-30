using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderCharges
    {
        public class OrderChargeSQL
        {
            private Sys.Database _database;

            public OrderChargeSQL(Sys.Database database)
            {
                _database = database;
            }

            

            public void Delete(int OrderChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderChargeID", OrderChargeID, true);
                _database.ExecuteSP_NO_Return("OrderCharge_Delete");
            }

            public DataView OrderCharge_GetForOrder(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("OrderCharge_GetForOrder");
                dt.TableName = Sys.Enums.TableNames.tblOrderCharge.ToString();
                return new DataView(dt);
            }

            public OrderCharge OrderCharge_Get(int OrderChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderChargeID", OrderChargeID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("OrderCharge_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oOrderCharge = new OrderCharge();
                        oOrderCharge.IgnoreExceptionsOnSetMethods = true;
                        oOrderCharge.SetOrderChargeID = dt.Rows[0]["OrderChargeID"];
                        oOrderCharge.SetOrderID = dt.Rows[0]["OrderID"];
                        oOrderCharge.SetOrderChargeTypeID = dt.Rows[0]["OrderChargeTypeID"];
                        oOrderCharge.SetAmount = dt.Rows[0]["Amount"];
                        oOrderCharge.SetReference = dt.Rows[0]["Reference"];
                        oOrderCharge.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oOrderCharge.Exists = true;
                        return oOrderCharge;
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

            public DataView OrderCharge_GetForConsolidatedOrder(int OrderConsolidationID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderConsolidationID", OrderConsolidationID, true);
                var dt = _database.ExecuteSP_DataTable("OrderCharge_GetForConsolidatedOrder");
                dt.TableName = Sys.Enums.TableNames.tblOrderCharge.ToString();
                return new DataView(dt);
            }

            public DataView OrderCharge_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("OrderCharge_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblOrderCharge.ToString();
                return new DataView(dt);
            }

            public OrderCharge Insert(OrderCharge oOrderCharge)
            {
                _database.ClearParameter();
                AddOrderChargeParametersToCommand(ref oOrderCharge);
                oOrderCharge.SetOrderChargeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("OrderCharge_Insert"));
                oOrderCharge.Exists = true;
                return oOrderCharge;
            }

            public void Update(OrderCharge oOrderCharge)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderChargeID", oOrderCharge.OrderChargeID, true);
                AddOrderChargeParametersToCommand(ref oOrderCharge);
                _database.ExecuteSP_NO_Return("OrderCharge_Update");
            }

            private void AddOrderChargeParametersToCommand(ref OrderCharge oOrderCharge)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@OrderID", oOrderCharge.OrderID, true);
                    withBlock.AddParameter("@OrderChargeTypeID", oOrderCharge.OrderChargeTypeID, true);
                    withBlock.AddParameter("@Amount", oOrderCharge.Amount, true);
                    withBlock.AddParameter("@Reference", oOrderCharge.Reference, true);
                }
            }


            
        }
    }
}