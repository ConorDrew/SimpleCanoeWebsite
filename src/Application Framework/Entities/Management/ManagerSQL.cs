using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;

namespace FSM.Entity
{
    namespace Management
    {
        public class ManagerSQL
        {
            private Sys.Database _database;

            public ManagerSQL(Sys.Database databaseIn)
            {
                _database = databaseIn;
            }

            

            public DataView GetAll()
            {
                _database.ClearParameter();
                string sql = Sys.Helper.GetTextResource("Settings_Get.sql");
                var dt = _database.ExecuteWithReturn(sql, false);
                dt.TableName = Sys.Enums.TableNames.tblSettings.ToString();
                return new DataView(dt);
            }

            public Settings Get()
            {
                var settings = new Settings();
                var settingsList = GetAll();
                if (settingsList.Table.Rows.Count > 0)
                {
                    {
                        var withBlock = settingsList.Table.Rows[0];
                        settings.SetWorkingHoursStart = Sys.Helper.MakeStringValid(withBlock["WorkingHoursStart"]);
                        settings.SetWorkingHoursEnd = Sys.Helper.MakeStringValid(withBlock["WorkingHoursEnd"]);
                        settings.SetOverridePassword = Sys.Helper.MakeStringValid(withBlock["OverridePassword"]);
                        settings.SetOverridePassword_Service = Sys.Helper.MakeStringValid(withBlock["OverridePassword_Service"]);
                        settings.SetMileageRate = Sys.Helper.MakeDoubleValid(withBlock["MileageRate"]);
                        settings.SetPartsMarkup = Sys.Helper.MakeDoubleValid(withBlock["PartsMarkup"]);
                        settings.SetRatesMarkup = Sys.Helper.MakeDoubleValid(withBlock["RatesMarkup"]);
                        settings.SetCalloutPrefix = Sys.Helper.MakeStringValid(withBlock["CalloutPrefix"]);
                        settings.SetMiscPrefix = Sys.Helper.MakeStringValid(withBlock["MiscPrefix"]);
                        settings.SetPPMPrefix = Sys.Helper.MakeStringValid(withBlock["PPMPrefix"]);
                        settings.SetQuotePrefix = Sys.Helper.MakeStringValid(withBlock["QuotePrefix"]);
                        settings.SetTimeSlot = Sys.Helper.MakeIntegerValid(withBlock["TimeSlot"]);
                        settings.SetInvoicePrefix = Sys.Helper.MakeStringValid(withBlock["InvoicePrefix"]);
                        settings.SetRecallVariable = Sys.Helper.MakeIntegerValid(withBlock["RecallVariable"]);
                        settings.SetPartsImportMarkup = Sys.Helper.MakeDoubleValid(withBlock["PartsImportMarkup"]);
                        settings.SetServiceFromLetterPrefix = Sys.Helper.MakeStringValid(withBlock["ServiceFromLetterPrefix"]);
                        settings.Exists = true;
                    }
                }

                return settings;
            }

            public void UpdateSettings(Settings settings)
            {
                _database.ClearParameter();
                _database.AddParameter("?WorkingHoursStart", settings.WorkingHoursStart);
                _database.AddParameter("?WorkingHoursEnd", settings.WorkingHoursEnd);
                _database.AddParameter("?MileageRate", Conversions.ToDouble(settings.MileageRate));
                _database.AddParameter("?PartsMarkup", Conversions.ToDouble(settings.PartsMarkup));
                _database.AddParameter("?RatesMarkup", Conversions.ToDouble(settings.RatesMarkup));
                _database.AddParameter("?CalloutPrefix", settings.CalloutPrefix);
                _database.AddParameter("?MiscPrefix", settings.MiscPrefix);
                _database.AddParameter("?PPMPrefix", settings.PPMPrefix);
                _database.AddParameter("?QuotePrefix", settings.QuotePrefix);
                _database.AddParameter("?TimeSlot", settings.TimeSlot);
                _database.AddParameter("?InvoicePrefix", settings.InvoicePrefix);
                _database.AddParameter("?RecallVariable", settings.RecallVariable);
                _database.AddParameter("?PartsImportMarkup", settings.PartsImportMarkup);
                _database.AddParameter("?ServiceFromLetterPrefix", settings.ServiceFromLetterPrefix);
                _database.ExecuteCommand_NO_Return("Settings_Update.sql");
            }

            public void UpdateOverridePassword(string Password)
            {
                _database.ClearParameter();
                _database.AddParameter("?Password", Sys.Helper.HashPassword(Password));
                _database.ExecuteCommand_NO_Return("Settings_UpdateOverridePassword.sql");
            }

            public void UpdateOverridePassword_Service(string Password)
            {
                _database.ClearParameter();
                _database.AddParameter("?Password", Sys.Helper.HashPassword(Password));
                _database.ExecuteCommand_NO_Return("Settings_UpdateOverridePassword_Service.sql");
            }

            
            

            public DataView GetHistory(int LimitNumber)
            {
                string sql = Sys.Helper.GetTextResource("History_Get.sql");
                if (!(LimitNumber == 0))
                {
                    sql = string.Format(sql, " TOP " + LimitNumber);
                }
                else
                {
                    sql = string.Format(sql, "");
                }

                var dt = _database.ExecuteWithReturn(sql);
                dt.TableName = Sys.Enums.TableNames.tblHistory.ToString();
                return new DataView(dt);
            }

            public void DeleteHistory()
            {
                _database.ExecuteWithOutReturn(Sys.Helper.GetTextResource("History_Delete.sql"));
            }

            
            

            public DataView Get_Tables()
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("TableEnumID"));
                dt.Columns.Add(new DataColumn("TableName"));
                dt.Columns.Add(new DataColumn("Deleted", Type.GetType("System.Boolean")));
                DataRow newRow;
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblCustomer);
                newRow["TableName"] = "Customers";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblSite);
                newRow["TableName"] = "Sites";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblSupplier);
                newRow["TableName"] = "Suppliers";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblPart);
                newRow["TableName"] = "Parts";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblProduct);
                newRow["TableName"] = "Products";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblAsset);
                newRow["TableName"] = "Assets";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblType);
                newRow["TableName"] = "Types";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblMake);
                newRow["TableName"] = "Makes";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblModel);
                newRow["TableName"] = "Models";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblLocations);
                newRow["TableName"] = "Locations";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblEngineer);
                newRow["TableName"] = "Engineers";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                newRow = dt.NewRow();
                newRow["TableEnumID"] = Conversions.ToInteger(Sys.Enums.TableNames.tblHistory);
                newRow["TableName"] = "System History";
                newRow["Deleted"] = false;
                dt.Rows.Add(newRow);
                return new DataView(dt);
            }

            
            

            public DataView Record_Summary(DateTime fromDate, DateTime toDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@FromDate", Strings.Format(fromDate, "dd-MMMM-yyyy 00:00:00"), true);
                _database.AddParameter("@ToDate", Strings.Format(toDate, "dd-MMMM-yyyy 23:59:59"), true);
                var dt = _database.ExecuteSP_DataTable("Report_Record_Summary");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
                return new DataView(dt);
            }

            
        }
    }
}