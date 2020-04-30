using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace CustomerCharges
    {
        public class CustomerChargeSQL
        {
            private Sys.Database _database;

            public CustomerChargeSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(int CustomerChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerChargeID", CustomerChargeID, true);
                _database.ExecuteSP_NO_Return("CustomerCharge_Delete");
            }

            public CustomerCharge CustomerCharge_Get(int CustomerChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerChargeID", CustomerChargeID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("CustomerCharge_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomerCharge = new CustomerCharge();
                        oCustomerCharge.IgnoreExceptionsOnSetMethods = true;
                        oCustomerCharge.SetCustomerChargeID = dt.Rows[0]["CustomerChargeID"];
                        oCustomerCharge.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomerCharge.SetMileageRate = dt.Rows[0]["MileageRate"];
                        oCustomerCharge.SetPartsMarkup = dt.Rows[0]["PartsMarkup"];
                        oCustomerCharge.SetRatesMarkup = dt.Rows[0]["RatesMarkup"];
                        oCustomerCharge.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomerCharge.Exists = true;
                        return oCustomerCharge;
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

            public CustomerCharge CustomerCharge_GetForCustomer(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("CustomerCharge_GetForCustomer");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomerCharge = new CustomerCharge();
                        oCustomerCharge.IgnoreExceptionsOnSetMethods = true;
                        oCustomerCharge.SetCustomerChargeID = dt.Rows[0]["CustomerChargeID"];
                        oCustomerCharge.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomerCharge.SetMileageRate = dt.Rows[0]["MileageRate"];
                        oCustomerCharge.SetPartsMarkup = dt.Rows[0]["PartsMarkup"];
                        oCustomerCharge.SetRatesMarkup = dt.Rows[0]["RatesMarkup"];
                        oCustomerCharge.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomerCharge.Exists = true;
                        return oCustomerCharge;
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

            public CustomerCharge CustomerCharge_GetForSite(int siteId)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", siteId);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("CustomerCharge_GetForSite");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomerCharge = new CustomerCharge();
                        oCustomerCharge.IgnoreExceptionsOnSetMethods = true;
                        oCustomerCharge.SetCustomerChargeID = dt.Rows[0]["CustomerChargeID"];
                        oCustomerCharge.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomerCharge.SetMileageRate = dt.Rows[0]["MileageRate"];
                        oCustomerCharge.SetPartsMarkup = dt.Rows[0]["PartsMarkup"];
                        oCustomerCharge.SetRatesMarkup = dt.Rows[0]["RatesMarkup"];
                        oCustomerCharge.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomerCharge.Exists = true;
                        return oCustomerCharge;
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

            public DataView CustomerCharge_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("CustomerCharge_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblCustomerCharge.ToString();
                return new DataView(dt);
            }

            public CustomerCharge Insert(CustomerCharge oCustomerCharge)
            {
                _database.ClearParameter();
                AddCustomerChargeParametersToCommand(ref oCustomerCharge);
                oCustomerCharge.SetCustomerChargeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CustomerCharge_Insert"));
                oCustomerCharge.Exists = true;
                return oCustomerCharge;
            }

            public void Update(CustomerCharge oCustomerCharge)
            {
                _database.ClearParameter();
                AddCustomerChargeParametersToCommand(ref oCustomerCharge);
                _database.ExecuteSP_NO_Return("CustomerCharge_Update");
            }

            public void UpdateALL(double MileageRate, double PartsMarkup, double RatesMarkup)
            {
                _database.ClearParameter();
                _database.AddParameter("@MileageRate", MileageRate, true);
                _database.AddParameter("@PartsMarkup", PartsMarkup, true);
                _database.AddParameter("@RatesMarkup", RatesMarkup, true);
                _database.ExecuteSP_NO_Return("CustomerCharge_UpdateALL");
            }

            private void AddCustomerChargeParametersToCommand(ref CustomerCharge oCustomerCharge)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CustomerID", oCustomerCharge.CustomerID, true);
                    withBlock.AddParameter("@MileageRate", oCustomerCharge.MileageRate, true);
                    withBlock.AddParameter("@PartsMarkup", oCustomerCharge.PartsMarkup, true);
                    withBlock.AddParameter("@RatesMarkup", oCustomerCharge.RatesMarkup, true);
                }
            }

            
        }
    }
}