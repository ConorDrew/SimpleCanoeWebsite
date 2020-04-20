using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace InvoiceAddresss
    {
        public class InvoiceAddressSQL
        {
            private Sys.Database _database;

            public InvoiceAddressSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int InvoiceAddressID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceAddressID", InvoiceAddressID, true);
                _database.ExecuteSP_NO_Return("InvoiceAddress_Delete");
            }

            public InvoiceAddress InvoiceAddress_Get(int InvoiceAddressID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceAddressID", InvoiceAddressID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("InvoiceAddress_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oInvoiceAddress = new InvoiceAddress();
                        oInvoiceAddress.IgnoreExceptionsOnSetMethods = true;
                        oInvoiceAddress.SetInvoiceAddressID = dt.Rows[0]["InvoiceAddressID"];
                        oInvoiceAddress.SetAddress1 = dt.Rows[0]["Address1"];
                        oInvoiceAddress.SetAddress2 = dt.Rows[0]["Address2"];
                        oInvoiceAddress.SetAddress3 = dt.Rows[0]["Address3"];
                        oInvoiceAddress.SetAddress4 = dt.Rows[0]["Address4"];
                        oInvoiceAddress.SetAddress5 = dt.Rows[0]["Address5"];
                        oInvoiceAddress.SetPostcode = dt.Rows[0]["Postcode"];
                        oInvoiceAddress.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oInvoiceAddress.SetFaxNum = dt.Rows[0]["FaxNum"];
                        oInvoiceAddress.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oInvoiceAddress.SetSiteID = dt.Rows[0]["SiteID"];
                        oInvoiceAddress.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oInvoiceAddress.Exists = true;
                        return oInvoiceAddress;
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

            public DataView InvoiceAddress_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("InvoiceAddress_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                return new DataView(dt);
            }

            public DataView InvoiceAddress_Get_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@SiteEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Site), true);
                _database.AddParameter("@HQEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.HQ), true);
                var dt = _database.ExecuteSP_DataTable("InvoiceAddress_Get_EngineerVisitID");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                return new DataView(dt);
            }

            public DataView InvoiceAddress_Get_CustomerID(int CustomerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CustomerID", CustomerID, true);
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@SiteEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Site), true);
                _database.AddParameter("@HQEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.HQ), true);
                var dt = _database.ExecuteSP_DataTable("InvoiceAddress_Get_CustomerID");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                return new DataView(dt);
            }

            public DataView InvoiceAddress_Get_SiteID(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@SiteEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Site), true);
                _database.AddParameter("@HQEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.HQ), true);
                var dt = _database.ExecuteSP_DataTable("InvoiceAddress_Get_SiteID");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                return new DataView(dt);
            }

            public DataView InvoiceAddress_Get_OrderID(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@SiteEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Site), true);
                _database.AddParameter("@HQEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.HQ), true);
                var dt = _database.ExecuteSP_DataTable("InvoiceAddress_Get_OrderID");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                return new DataView(dt);
            }

            public InvoiceAddress Insert(InvoiceAddress oInvoiceAddress)
            {
                _database.ClearParameter();
                AddInvoiceAddressParametersToCommand(ref oInvoiceAddress);
                oInvoiceAddress.SetInvoiceAddressID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("InvoiceAddress_Insert"));
                oInvoiceAddress.Exists = true;
                return oInvoiceAddress;
            }

            public DataView InvoiceAddress_GetForSite(int SiteID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SiteID", SiteID, true);
                var dt = _database.ExecuteSP_DataTable("InvoiceAddress_GetForSite");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                return new DataView(dt);
            }

            public DataView InvoiceAddress_Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@Criteria", criteria, true);
                var dt = _database.ExecuteSP_DataTable("InvoiceAddress_Search");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                return new DataView(dt);
            }

            public void Update(InvoiceAddress oInvoiceAddress)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceAddressID", oInvoiceAddress.InvoiceAddressID, true);
                AddInvoiceAddressParametersToCommand(ref oInvoiceAddress);
                _database.ExecuteSP_NO_Return("InvoiceAddress_Update");
            }

            private void AddInvoiceAddressParametersToCommand(ref InvoiceAddress oInvoiceAddress)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Address1", oInvoiceAddress.Address1, true);
                    withBlock.AddParameter("@Address2", oInvoiceAddress.Address2, true);
                    withBlock.AddParameter("@Address3", oInvoiceAddress.Address3, true);
                    withBlock.AddParameter("@Address4", oInvoiceAddress.Address4, true);
                    withBlock.AddParameter("@Address5", oInvoiceAddress.Address5, true);
                    withBlock.AddParameter("@Postcode", oInvoiceAddress.Postcode, true);
                    withBlock.AddParameter("@TelephoneNum", oInvoiceAddress.TelephoneNum, true);
                    withBlock.AddParameter("@FaxNum", oInvoiceAddress.FaxNum, true);
                    withBlock.AddParameter("@EmailAddress", oInvoiceAddress.EmailAddress, true);
                    withBlock.AddParameter("@SiteID", oInvoiceAddress.SiteID, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}