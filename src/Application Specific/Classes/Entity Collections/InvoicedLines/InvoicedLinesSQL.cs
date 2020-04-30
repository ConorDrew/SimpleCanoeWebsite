using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace InvoicedLiness
    {
        public class InvoicedLinesSQL
        {
            private Sys.Database _database;

            public InvoicedLinesSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(int InvoicedLineID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedLineID", InvoicedLineID, true);
                _database.ExecuteSP_NO_Return("InvoicedLines_Delete");
            }

            public InvoicedLines InvoicedLines_Get(int InvoicedLineID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedLineID", InvoicedLineID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("InvoicedLines_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oInvoicedLines = new InvoicedLines();
                        oInvoicedLines.IgnoreExceptionsOnSetMethods = true;
                        oInvoicedLines.SetInvoicedLineID = dt.Rows[0]["InvoicedLineID"];
                        oInvoicedLines.SetInvoicedID = dt.Rows[0]["InvoicedID"];
                        oInvoicedLines.SetInvoiceToBeRaisedID = dt.Rows[0]["InvoiceToBeRaisedID"];
                        oInvoicedLines.SetAmount = dt.Rows[0]["Amount"];
                        oInvoicedLines.Exists = true;
                        return oInvoicedLines;
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

            public DataView InvoicedLines_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("InvoicedLines_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblInvoicedLines.ToString();
                return new DataView(dt);
            }

            public DataView InvoicedLines_GetAll_ByInvoiceToBeRaisedID(int InvoiceToBeRaisedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID, true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                var dt = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoiceToBeRaisedID");
                dt.TableName = Sys.Enums.TableNames.tblInvoicedLines.ToString();
                return new DataView(dt);
            }

            public DataView InvoicedLines_GetAll_ByInvoicedID(int InvoicedID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedID", InvoicedID, true);
                _database.AddParameter("@JobInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Visit), true);
                _database.AddParameter("@OrderInvTypeEnum", Conversions.ToInteger(Sys.Enums.InvoiceType.Order), true);
                _database.AddParameter("@Contract_Option1Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option1), true);
                _database.AddParameter("@Contract_Option2Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option2), true);
                _database.AddParameter("@Contract_Option3Enum", Conversions.ToInteger(Sys.Enums.InvoiceType.Contract_Option3), true);
                var dt = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoicedID");
                dt.TableName = Sys.Enums.TableNames.tblInvoicedLines.ToString();
                return new DataView(dt);
            }

            public InvoicedLines Insert(InvoicedLines oInvoicedLines)
            {
                _database.ClearParameter();
                AddInvoicedLinesParametersToCommand(ref oInvoicedLines);
                oInvoicedLines.SetInvoicedLineID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("InvoicedLines_Insert"));
                oInvoicedLines.Exists = true;
                return oInvoicedLines;
            }

            public void Update(InvoicedLines oInvoicedLines)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedLineID", oInvoicedLines.InvoicedLineID, true);
                AddInvoicedLinesParametersToCommand(ref oInvoicedLines);
                _database.ExecuteSP_NO_Return("InvoicedLines_Update");
            }

            private void AddInvoicedLinesParametersToCommand(ref InvoicedLines oInvoicedLines)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@InvoicedID", oInvoicedLines.InvoicedID, true);
                    withBlock.AddParameter("@InvoiceToBeRaisedID", oInvoicedLines.InvoiceToBeRaisedID, true);
                    withBlock.AddParameter("@Amount", oInvoicedLines.Amount, true);
                }
            }

            public void InvoicedLinesTotal_Change(int InvoicedLineID, double Amount)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedLineID", InvoicedLineID, true);
                _database.AddParameter("@Amount", Amount, true);
                _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("InvoicedLinesTotal_Change");
            }

            public void InvoicedLinesTotal_ChangeInvoiceDetails(int InvoicedLineID, string AccountCode, string Department, string NominalCode, DateTime TaxDate, int InvoiceTypeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedLineID", InvoicedLineID, true);
                _database.AddParameter("@AccountCode", AccountCode, true);
                _database.AddParameter("@Department", Department, true);
                _database.AddParameter("@NominalCode", NominalCode, true);
                _database.AddParameter("@TaxDate", TaxDate, true);
                _database.AddParameter("@InvoiceTypeID", InvoiceTypeID, true);
                _database.ExecuteSP_NO_Return("InvoicedLinesTotal_ChangeDetails");
            }

            public void Invoiced_ChangeTerm(int InvoicedID, int Term, int PaidBy)
            {
                _database.ClearParameter();
                _database.AddParameter("@InvoicedID", InvoicedID, true);
                _database.AddParameter("@TermID", Term, true);
                if (PaidBy > 0)
                {
                    _database.AddParameter("@PaidByID", PaidBy, true);
                }

                _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("Invoiced_ChangeTerm");
            }

            
        }
    }
}