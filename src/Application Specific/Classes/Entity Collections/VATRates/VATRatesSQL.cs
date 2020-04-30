using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace VATRatess
    {
        public class VATRatesSQL
        {
            private Sys.Database _database;

            public VATRatesSQL(Sys.Database database)
            {
                _database = database;
            }

            

            public VATRates VATRates_Get(int VATRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@VATRateID", VATRateID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("VATRates_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oVATRates = new VATRates();
                        oVATRates.IgnoreExceptionsOnSetMethods = true;
                        oVATRates.SetVATRateID = dt.Rows[0]["VATRateID"];
                        oVATRates.SetVATRate = dt.Rows[0]["VATRate"];
                        oVATRates.DateIntroduced = Conversions.ToDate(dt.Rows[0]["DateIntroduced"]);
                        oVATRates.SetVATRateCode = dt.Rows[0]["VATRateCode"];
                        oVATRates.Exists = true;
                        return oVATRates;
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

            public DataView VATRates_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("VATRates_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblVATRates.ToString();
                return new DataView(dt);
            }

            public DataView VATRates_GetAll_InputOrOutput(char inputOrOutput)
            {
                _database.ClearParameter();
                _database.AddParameter("@InputOrOutput", inputOrOutput);
                var dt = _database.ExecuteSP_DataTable("VATRates_GetAll_InputOrOutput");
                dt.TableName = Sys.Enums.TableNames.tblVATRates.ToString();
                return new DataView(dt);
            }

            public DataView VATRates_GetAll_Valid()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("VATRates_GetAll_Valid");
                dt.TableName = Sys.Enums.TableNames.tblVATRates.ToString();
                return new DataView(dt);
            }

            public int VATRates_Get_ByDate(DateTime InvoiceDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceDate", InvoiceDate, true);
                int VatRateID = Conversions.ToInteger(Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("VATRates_Get_ByDate")));
                return VatRateID;
            }

            public VATRates Insert(VATRates oVATRates)
            {
                _database.ClearParameter();
                AddVATRatesParametersToCommand(ref oVATRates);
                oVATRates.SetVATRateID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("VATRates_Insert"));
                oVATRates.Exists = true;
                return oVATRates;
            }

            public void Update(VATRates oVATRates)
            {
                _database.ClearParameter();
                _database.AddParameter("@VATRateID", oVATRates.VATRateID, true);
                AddVATRatesParametersToCommand(ref oVATRates);
                _database.ExecuteSP_NO_Return("VATRates_Update");
            }

            private void AddVATRatesParametersToCommand(ref VATRates oVATRates)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@VATRate", oVATRates.VATRate, true);
                    withBlock.AddParameter("@DateIntroduced", oVATRates.DateIntroduced, true);
                    withBlock.AddParameter("@VATRateCode", oVATRates.VATRateCode, true);
                }
            }

            
        }
    }
}