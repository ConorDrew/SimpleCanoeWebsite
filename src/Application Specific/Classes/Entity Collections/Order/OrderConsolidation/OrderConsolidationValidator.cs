using System.Collections;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace OrderConsolidations
    {
        // make sure that contact object is valid
        public class OrderConsolidationValidator : BaseValidator
        {
            public void Validate(OrderConsolidation oOrderConsolidation, bool ForLocation)
            {

                // make sure that contact object is valid
                if (oOrderConsolidation.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oOrderConsolidation.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (ForLocation)
                {
                    if (oOrderConsolidation.LocationID == 0)
                    {
                        AddCriticalMessage("Location Missing");
                    }
                }
                else if (oOrderConsolidation.SupplierID == 0)
                {
                    AddCriticalMessage("Supplier Missing");
                }

                if (oOrderConsolidation.ConsolidationRef.Trim().Length == 0)
                {
                    AddCriticalMessage("Reference Missing");
                }
                else if (!oOrderConsolidation.Exists)
                {
                    if (App.DB.Order.Order_CheckReference(oOrderConsolidation.ConsolidationRef).Table.Rows.Count > 0)
                    {
                        AddCriticalMessage("The Order Ref you have chosen has already been allocated to another Quote or Order in the system. Please choose a unique Reference.");
                    }
                }

                var orders = new ArrayList();
                if (oOrderConsolidation.HasSupplierPO)
                {
                    foreach (DataRow row in App.DB.Order.Order_GetAll("").Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["OrderConsolidationID"], oOrderConsolidation.OrderConsolidationID, false)))
                        {
                            if (Conversions.ToBoolean(row["ReadyToSendToSage"]))
                            {
                                orders.Add(row["OrderReference"]);
                            }
                        }
                    }
                }

                if (!(orders.Count == 0))
                {
                    string msg = "The following orders have been marked as ready to send to sage so this consolidation cannot be marked with a supplier PO:" + Constants.vbCrLf + Constants.vbCrLf;
                    foreach (string Err in orders)
                        msg += Err + Constants.vbCrLf;
                    AddCriticalMessage(msg);
                }

                if (oOrderConsolidation.ReadyToSendToSage)
                {
                    if (oOrderConsolidation.SupplierInvoiceReference.Trim().Length == 0)
                    {
                        AddCriticalMessage("Supplier Invoice Reference Missing");
                    }

                    if (oOrderConsolidation.SupplierInvoiceDate == default)
                    {
                        AddCriticalMessage("Supplier Invoice Date Missing");
                    }

                    if (oOrderConsolidation.NominalCode.Trim().Length == 0)
                    {
                        AddCriticalMessage("Nominal Code Missing");
                    }

                    if (oOrderConsolidation.DepartmentRef.Trim().Length == 0)
                    {
                        AddCriticalMessage("Department Reference Missing");
                    }

                    if (oOrderConsolidation.ExtraRef.Trim().Length == 0)
                    {
                        AddCriticalMessage("Extra Reference Missing");
                    }

                    if (oOrderConsolidation.TaxCodeID == 0)
                    {
                        AddCriticalMessage("Tax Code Missing");
                    }
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}