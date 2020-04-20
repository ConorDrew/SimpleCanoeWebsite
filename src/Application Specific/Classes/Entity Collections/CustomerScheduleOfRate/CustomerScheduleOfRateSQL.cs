using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace CustomerScheduleOfRates
    {
        public class CustomerScheduleOfRateSQL
        {
            private Sys.Database _database;

            public CustomerScheduleOfRateSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int CustomerScheduleOfRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerScheduleOfRateID", CustomerScheduleOfRateID, true);
                _database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Delete");
            }

            public CustomerScheduleOfRate Get(int CustomerScheduleOfRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerScheduleOfRateID", CustomerScheduleOfRateID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCustomerScheduleOfRate = new CustomerScheduleOfRate();
                        oCustomerScheduleOfRate.IgnoreExceptionsOnSetMethods = true;
                        oCustomerScheduleOfRate.SetCustomerScheduleOfRateID = dt.Rows[0]["CustomerScheduleOfRateID"];
                        oCustomerScheduleOfRate.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oCustomerScheduleOfRate.SetScheduleOfRatesCategoryID = dt.Rows[0]["ScheduleOfRatesCategoryID"];
                        oCustomerScheduleOfRate.SetCode = dt.Rows[0]["Code"];
                        oCustomerScheduleOfRate.SetDescription = dt.Rows[0]["Description"];
                        oCustomerScheduleOfRate.SetPrice = dt.Rows[0]["Price"];
                        oCustomerScheduleOfRate.SetTimeInMins = Sys.Helper.MakeIntegerValid(dt.Rows[0]["TimeInMins"]);
                        oCustomerScheduleOfRate.SetAllowDeleted = dt.Rows[0]["AllowDeleted"];
                        oCustomerScheduleOfRate.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCustomerScheduleOfRate.Exists = true;
                        return oCustomerScheduleOfRate;
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

            public DataView GetAll_For_CustomerID(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_For_CustomerID");
                dt.TableName = Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_For_SiteID(int siteId)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", siteId, true);
                var dt = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_For_SiteID");
                dt.TableName = Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataView GetAll_WithoutDefaults(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_WithoutDefaults");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataView Customer_Jobtype_Sor_Get(int CustomerID, int JobTypeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@JobTypeID", JobTypeID, true);
                var dt = _database.ExecuteSP_DataTable("Customer_JobType_Sor_Get");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataView Customer_Jobtype_Sor_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Customer_JobType_Sor_GetALL");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataView Customer_Jobtype_Sor_Insert(int CustomerID, int JobTypeID, int CustomerScheduleOfRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@JobTypeID", JobTypeID, true);
                _database.AddParameter("@CustomerScheduleOfRateID", CustomerScheduleOfRateID, true);
                var dt = _database.ExecuteSP_DataTable("Customer_JobType_Sor_Insert");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataView Customer_Jobtype_Sor_Delete(int CustomerJobTypeSORID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerJobTypeSORID", CustomerJobTypeSORID, true);
                var dt = _database.ExecuteSP_DataTable("Customer_JobType_Sor_Delete");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public CustomerScheduleOfRate Insert(CustomerScheduleOfRate oCustomerScheduleOfRate)
            {
                _database.ClearParameter();
                AddCustomerScheduleOfRateParametersToCommand(ref oCustomerScheduleOfRate);
                oCustomerScheduleOfRate.SetCustomerScheduleOfRateID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CustomerScheduleOfRate_Insert"));
                oCustomerScheduleOfRate.Exists = true;
                return oCustomerScheduleOfRate;
            }

            public void Update(CustomerScheduleOfRate oCustomerScheduleOfRate)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerScheduleOfRateID", oCustomerScheduleOfRate.CustomerScheduleOfRateID, true);
                AddCustomerScheduleOfRateParametersToCommand(ref oCustomerScheduleOfRate);
                _database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Update");
            }

            private void AddCustomerScheduleOfRateParametersToCommand(ref CustomerScheduleOfRate oCustomerScheduleOfRate)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CustomerID", oCustomerScheduleOfRate.CustomerID, true);
                    withBlock.AddParameter("@ScheduleOfRatesCategoryID", oCustomerScheduleOfRate.ScheduleOfRatesCategoryID, true);
                    withBlock.AddParameter("@Code", oCustomerScheduleOfRate.Code, true);
                    withBlock.AddParameter("@Description", oCustomerScheduleOfRate.Description, true);
                    withBlock.AddParameter("@Price", oCustomerScheduleOfRate.Price, true);
                    withBlock.AddParameter("@TimeInMins", oCustomerScheduleOfRate.TimeInMins, true);
                    withBlock.AddParameter("@AllowDeleted", oCustomerScheduleOfRate.AllowDeleted, true);
                }
            }

            public void Insert_Defaults(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Insert_Defaults");
            }

            public void CustomerScheduleOfRates_UpdateForALL(decimal Price, string Description, string Code, int ScheduleOfRatesCategoryID, int TimeInMins)
            {
                _database.ClearParameter();
                _database.AddParameter("@Price", Price, true);
                _database.AddParameter("@Description", Description, true);
                _database.AddParameter("@Code", Code, true);
                _database.AddParameter("@ScheduleOfRatesCategoryID", ScheduleOfRatesCategoryID, true);
                _database.AddParameter("@TimeInMins", TimeInMins, true);
                _database.ExecuteSP_NO_Return("CustomerScheduleOfRates_UpdateForALL");
            }

            public DataView CustomerScheduleOfRates_GetALL_Labour(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                var dt = _database.ExecuteSP_DataTable("CustomerScheduleOfRates_GetALL_Labour");
                dt.TableName = Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataTable Exists(int ScheduleOfRatesCategoryID, string Description, string Code, int customerId)
            {
                _database.ClearParameter();
                _database.AddParameter("@ScheduleOfRatesCategoryID", ScheduleOfRatesCategoryID, true);
                _database.AddParameter("@Description", Description, true);
                _database.AddParameter("@Code", Code, true);
                _database.AddParameter("@CustomerID", customerId, true);
                var dt = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_Exists");
                return dt;
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}