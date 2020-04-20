using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace InvoiceToBeRaiseds
    {
        public class InvoiceToBeRaisedSQL
        {
            private Sys.Database _database;

            public InvoiceToBeRaisedSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int InvoiceToBeRaisedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID, true);
                _database.ExecuteSP_NO_Return("InvoiceToBeRaised_Delete");
            }

            public InvoiceToBeRaised InvoiceToBeRaised_Get(int InvoiceToBeRaisedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("InvoiceToBeRaised_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oInvoiceToBeRaised = new InvoiceToBeRaised();
                        oInvoiceToBeRaised.IgnoreExceptionsOnSetMethods = true;
                        oInvoiceToBeRaised.SetInvoiceToBeRaisedID = dt.Rows[0]["InvoiceToBeRaisedID"];
                        oInvoiceToBeRaised.RaiseDate = Conversions.ToDate(dt.Rows[0]["RaiseDate"]);
                        oInvoiceToBeRaised.SetInvoiceTypeID = dt.Rows[0]["InvoiceTypeID"];
                        oInvoiceToBeRaised.SetLinkID = dt.Rows[0]["LinkID"];
                        oInvoiceToBeRaised.SetAddressTypeID = dt.Rows[0]["AddressTypeID"];
                        oInvoiceToBeRaised.SetAddressLinkID = dt.Rows[0]["AddressLinkID"];
                        oInvoiceToBeRaised.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oInvoiceToBeRaised.SetPaymentTermID = dt.Rows[0]["PaymentTermID"];
                        oInvoiceToBeRaised.Exists = true;
                        return oInvoiceToBeRaised;
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

            public InvoiceToBeRaised InvoiceToBeRaised_Get_By_LinkID(int LinkID, Sys.Enums.InvoiceType InvoiceType)
            {
                _database.ClearParameter();
                _database.AddParameter("@LinkID", LinkID);
                _database.AddParameter("@InvoiceTypeID", Conversions.ToInteger(InvoiceType));

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("InvoiceToBeRaised_Get_By_LinkID");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oInvoiceToBeRaised = new InvoiceToBeRaised();
                        oInvoiceToBeRaised.IgnoreExceptionsOnSetMethods = true;
                        oInvoiceToBeRaised.SetInvoiceToBeRaisedID = dt.Rows[0]["InvoiceToBeRaisedID"];
                        oInvoiceToBeRaised.RaiseDate = Conversions.ToDate(dt.Rows[0]["RaiseDate"]);
                        oInvoiceToBeRaised.SetInvoiceTypeID = dt.Rows[0]["InvoiceTypeID"];
                        oInvoiceToBeRaised.SetLinkID = dt.Rows[0]["LinkID"];
                        oInvoiceToBeRaised.SetAddressTypeID = dt.Rows[0]["AddressTypeID"];
                        oInvoiceToBeRaised.SetAddressLinkID = dt.Rows[0]["AddressLinkID"];
                        oInvoiceToBeRaised.SetCustomerID = dt.Rows[0]["CustomerID"];
                        oInvoiceToBeRaised.SetTaxRateID = dt.Rows[0]["TAXRateID"];
                        oInvoiceToBeRaised.SetPaymentTermID = dt.Rows[0]["PaymentTermID"];
                        oInvoiceToBeRaised.Exists = true;
                        return oInvoiceToBeRaised;
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

            public DataView InvoiceToBeRaised_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("InvoiceToBeRaised_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString();
                return new DataView(dt);
            }

            public DataView Invoices_GetAll_Manager(DateTime RaiseFrom, DateTime RaiseTo)
            {
                _database.ClearParameter();
                _database.AddParameter("@RaiseFrom", Conversions.ToDate(Strings.Format(RaiseFrom, "dd/MM/yyyy") + " 00:00:00"), true);
                _database.AddParameter("@RaiseTo", Conversions.ToDate(Strings.Format(RaiseTo, "dd/MM/yyyy") + " 23:59:59"), true);
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                _database.AddParameter("@ContractOpt1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                _database.AddParameter("@ContractOpt2Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option2), true);
                _database.AddParameter("@ContractOpt3Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option3), true);
                var dt = _database.ExecuteSP_DataTable("Invoices_GetAll_Manager");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
                return new DataView(dt);
            }

            public DataView Invoices_GetAll_For_EngineerVisitChargeID(int EngineerVisitChargeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@EngineerVisitChargeID", EngineerVisitChargeID, true);
                var dt = _database.ExecuteSP_DataTable("Invoices_GetAll_For_EngineerVisitChargeID");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
                return new DataView(dt);
            }

            public DataView Invoices_GetAll_For_JobID(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceEnumVal", Conversions.ToInteger(Sys.Enums.InvoiceAddressType.Invoice), true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("Invoices_GetAll_For_JobID");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
                return new DataView(dt);
            }

            public InvoiceToBeRaised Insert(InvoiceToBeRaised oInvoiceToBeRaised)
            {
                _database.ClearParameter();
                AddInvoiceToBeRaisedParametersToCommand(ref oInvoiceToBeRaised);
                _database.AddParameter("@RecordAddedBy", App.loggedInUser.UserID, true);
                _database.AddParameter("@RecordAddedOn", DateAndTime.Now, true);
                oInvoiceToBeRaised.SetInvoiceToBeRaisedID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("InvoiceToBeRaised_Insert"));
                oInvoiceToBeRaised.Exists = true;
                return oInvoiceToBeRaised;
            }

            public DataView InvoiceToBeRaised_Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@Criteria", criteria, true);
                var dt = _database.ExecuteSP_DataTable("InvoiceToBeRaised_Search");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString();
                return new DataView(dt);
            }

            public void Update(InvoiceToBeRaised oInvoiceToBeRaised)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceToBeRaisedID", oInvoiceToBeRaised.InvoiceToBeRaisedID, true);
                AddInvoiceToBeRaisedParametersToCommand(ref oInvoiceToBeRaised);
                _database.ExecuteSP_NO_Return("InvoiceToBeRaised_Update");
            }

            private void AddInvoiceToBeRaisedParametersToCommand(ref InvoiceToBeRaised oInvoiceToBeRaised)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@RaiseDate", oInvoiceToBeRaised.RaiseDate, true);
                    withBlock.AddParameter("@InvoiceTypeID", oInvoiceToBeRaised.InvoiceTypeID, true);
                    withBlock.AddParameter("@LinkID", oInvoiceToBeRaised.LinkID, true);
                    withBlock.AddParameter("@AddressTypeID", oInvoiceToBeRaised.AddressTypeID, true);
                    withBlock.AddParameter("@AddressLinkID", oInvoiceToBeRaised.AddressLinkID, true);
                    withBlock.AddParameter("@CustomerID", oInvoiceToBeRaised.CustomerID, true);
                    withBlock.AddParameter("@TAXRateID", oInvoiceToBeRaised.TaxRateID, true);
                    withBlock.AddParameter("@TermID", oInvoiceToBeRaised.PaymentTermID, true);
                    withBlock.AddParameter("@PaidByID", oInvoiceToBeRaised.PaidByID, true);
                }
            }

            public DataView InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceTypeIDEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
                return new DataView(dt);
            }

            public DataView InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceTypeIDEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID");
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
                return new DataView(dt);
            }

            public double InvoicesToBeRaised_GetAmount_ByInvoiceToBeRaisedID(int InvoiceToBeRaisedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceTypeIDEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID, true);
                return Sys.Helper.MakeDoubleValid(App.DB.ExecuteSP_OBJECT("InvoicesToBeRaised_GetAmount_ByInvoiceToBeRaisedID"));
            }

            public DataView Invoices_GetAll_ForDirectDebitRpt(DateTime DateFrom, DateTime DateTo)
            {
                _database.ClearParameter();
                _database.AddParameter("@RaiseFrom", Conversions.ToDate(Strings.Format(DateFrom, "dd/MM/yyyy") + " 00:00:00"), true);
                _database.AddParameter("@RaiseTo", Conversions.ToDate(Strings.Format(DateTo, "dd/MM/yyyy") + " 23:59:59"), true);
                _database.AddParameter("@ContractOpt1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                var dt = _database.ExecuteSP_DataTable("Invoices_GetAll_ForDirectDebitRpt");
                dt.TableName = Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString();
                return new DataView(dt);
            }

            public bool InvoicesToBeRaised_Update_PaymentID(int InvoiceToBeRaisedID, int paymentTermID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID, true);
                _database.AddParameter("@PaymentTermID", paymentTermID, true);
                return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("InvoicesToBeRaised_Update_PaymentID"), 1, false));
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}