using System;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace Orders
    {
        public class SupplierInvoiceSQL
        {
            private Sys.Database _database;

            public SupplierInvoiceSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int SupplierInvoiceID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierInvoiceID", SupplierInvoiceID, true);
                _database.ExecuteSP_NO_Return("Order_DeleteSupplierInvoice");
            }

            public DataView Order_GetSupplierInvoice(int SupplierInvoiceID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierInvoiceID", SupplierInvoiceID, true);
                var dt = _database.ExecuteSP_DataTable("Order_GetSupplierInvoice");
                dt.TableName = Sys.Enums.TableNames.tblOrderSupplierInvoices.ToString();
                return new DataView(dt);
            }

            public DataView Order_GetSupplierInvoices(int OrderID)
            {
                _database.ClearParameter();
                _database.AddParameter("@OrderID", OrderID, true);
                var dt = _database.ExecuteSP_DataTable("Order_GetSupplierInvoices");
                dt.TableName = Sys.Enums.TableNames.tblOrderSupplierInvoices.ToString();
                return new DataView(dt);
            }

            public SupplierInvoice Insert(SupplierInvoice oSupplierInvoice)
            {
                _database.ClearParameter();
                AddSupplierInvoiceParametersToCommand(ref oSupplierInvoice);
                oSupplierInvoice.SetInvoiceID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Order_InsertSupplierInvoice"));
                oSupplierInvoice.Exists = true;
                return oSupplierInvoice;
            }

            public SupplierInvoice Insert(SupplierInvoice oSupplierInvoice, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "Order_InsertSupplierInvoice";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@OrderID", oSupplierInvoice.OrderID);
                Command.Parameters.AddWithValue("@SupplierInvoiceReference", oSupplierInvoice.InvoiceReference);
                Command.Parameters.AddWithValue("@SupplierInvoiceDate", oSupplierInvoice.InvoiceDate);
                if (oSupplierInvoice.GoodsAmount == default)
                {
                    Command.Parameters.AddWithValue("@SupplierGoodsAmount", 0);
                }
                else
                {
                    Command.Parameters.AddWithValue("@SupplierGoodsAmount", oSupplierInvoice.GoodsAmount);
                }

                if (oSupplierInvoice.GoodsAmount == default)
                {
                    Command.Parameters.AddWithValue("@SupplierVATAmount", 0);
                }
                else
                {
                    Command.Parameters.AddWithValue("@SupplierVATAmount", oSupplierInvoice.VATAmount);
                }

                if (oSupplierInvoice.GoodsAmount == default)
                {
                    Command.Parameters.AddWithValue("@SupplierInvoiceAmount", 0);
                }
                else
                {
                    Command.Parameters.AddWithValue("@SupplierInvoiceAmount", oSupplierInvoice.TotalAmount);
                }

                if (oSupplierInvoice.GoodsAmount == default)
                {
                    Command.Parameters.AddWithValue("@TaxCodeID", 0);
                }
                else
                {
                    Command.Parameters.AddWithValue("@TaxCodeID", oSupplierInvoice.TaxCodeID);
                }

                Command.Parameters.AddWithValue("@NominalCode", oSupplierInvoice.NominalCode);
                Command.Parameters.AddWithValue("@ExtraRef", oSupplierInvoice.ExtraRef);
                if (oSupplierInvoice.GoodsAmount == default)
                {
                    Command.Parameters.AddWithValue("@ReadyToSendToSage", 0);
                }
                else
                {
                    Command.Parameters.AddWithValue("@ReadyToSendToSage", oSupplierInvoice.ReadyToSendToSage);
                }

                if (oSupplierInvoice.GoodsAmount == default)
                {
                    Command.Parameters.AddWithValue("@SentToSage", 0);
                }
                else
                {
                    Command.Parameters.AddWithValue("@SentToSage", oSupplierInvoice.SentToSage);
                }

                if (oSupplierInvoice.GoodsAmount == default)
                {
                    Command.Parameters.AddWithValue("@OldSystemInvoice", 0);
                }
                else
                {
                    Command.Parameters.AddWithValue("@OldSystemInvoice", oSupplierInvoice.OldSystemInvoice);
                }

                if (oSupplierInvoice.GoodsAmount == default)
                {
                    Command.Parameters.AddWithValue("@DateExported", DBNull.Value);
                }
                else
                {
                    Command.Parameters.AddWithValue("@DateExported", oSupplierInvoice.DateExported);
                }

                Command.Parameters.AddWithValue("@KeyedBy", App.loggedInUser.UserID);
                oSupplierInvoice.SetInvoiceID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                oSupplierInvoice.Exists = true;
                return oSupplierInvoice;
            }

            public void Update(SupplierInvoice oSupplierInvoice)
            {
                _database.ClearParameter();
                _database.AddParameter("@SupplierInvoiceID", oSupplierInvoice.InvoiceID, true);
                AddSupplierInvoiceParametersToCommand(ref oSupplierInvoice);
                _database.ExecuteSP_NO_Return("Order_UpdateSupplierInvoice");
            }

            private void AddSupplierInvoiceParametersToCommand(ref SupplierInvoice oSupplierInvoice)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@OrderID", oSupplierInvoice.OrderID, true);
                    withBlock.AddParameter("@SupplierInvoiceReference", oSupplierInvoice.InvoiceReference, true);
                    withBlock.AddParameter("@SupplierInvoiceDate", oSupplierInvoice.InvoiceDate, true);
                    if (oSupplierInvoice.GoodsAmount == default)
                    {
                        withBlock.AddParameter("@SupplierGoodsAmount", 0, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@SupplierGoodsAmount", oSupplierInvoice.GoodsAmount, true);
                    }

                    if (oSupplierInvoice.VATAmount == default)
                    {
                        withBlock.AddParameter("@SupplierVATAmount", 0, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@SupplierVATAmount", oSupplierInvoice.VATAmount, true);
                    }

                    if (oSupplierInvoice.TotalAmount == default)
                    {
                        withBlock.AddParameter("@SupplierInvoiceAmount", 0, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@SupplierInvoiceAmount", oSupplierInvoice.TotalAmount, true);
                    }

                    if (oSupplierInvoice.TaxCodeID == default)
                    {
                        withBlock.AddParameter("@TaxCodeID", 0, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@TaxCodeID", oSupplierInvoice.TaxCodeID, true);
                    }

                    withBlock.AddParameter("@NominalCode", oSupplierInvoice.NominalCode, true);
                    withBlock.AddParameter("@ExtraRef", oSupplierInvoice.ExtraRef, true);
                    if (oSupplierInvoice.ReadyToSendToSage == default)
                    {
                        withBlock.AddParameter("@ReadyToSendToSage", 0, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@ReadyToSendToSage", oSupplierInvoice.ReadyToSendToSage, true);
                    }

                    if (oSupplierInvoice.SentToSage == default)
                    {
                        withBlock.AddParameter("@SentToSage", 0, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@SentToSage", oSupplierInvoice.SentToSage, true);
                    }

                    if (oSupplierInvoice.OldSystemInvoice == default)
                    {
                        withBlock.AddParameter("@OldSystemInvoice", 0, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@OldSystemInvoice", oSupplierInvoice.OldSystemInvoice, true);
                    }

                    if (oSupplierInvoice.DateExported == default)
                    {
                        withBlock.AddParameter("@DateExported", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@DateExported", oSupplierInvoice.DateExported, true);
                    }

                    withBlock.AddParameter("@KeyedBy", App.loggedInUser.UserID, true);
                }
            }
        }
    }
}