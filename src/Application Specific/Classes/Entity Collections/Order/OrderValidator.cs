using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Orders
    {
        // make sure that contact object is valid
        public class OrderValidator : BaseValidator
        {
            public void Validate(Order oOrder)
            {
                // make sure that contact object is valid
                if (oOrder.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oOrder.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (!(oOrder.OrderTypeID > 0))
                {
                    AddCriticalMessage("Order Type Missing");
                }

                if (!(oOrder.OrderReference.Trim().Length > 0))
                {
                    AddCriticalMessage("Order Reference Missing");
                }

                if (oOrder.OrderID == 0)
                {
                    if (App.DB.Order.Order_CheckReference(oOrder.OrderReference).Table.Rows.Count > 0)
                    {
                        AddCriticalMessage("The Order Ref you have chosen has already been allocated to another Quote or Order in the system.  Please choose a unique Reference.");
                    }
                }

                if (oOrder.OrderStatusID > (int)Sys.Enums.OrderStatus.AwaitingConfirmation)
                {
                    if (oOrder.DepartmentRef.Trim().Length == 0)
                    {
                        AddCriticalMessage("Department Reference Missing");
                    }
                }

                if (oOrder.ReadyToSendToSage)
                {
                    if (oOrder.SupplierInvoiceReference.Trim().Length == 0)
                    {
                        AddCriticalMessage("Supplier Invoice Reference Missing");
                    }

                    if (oOrder.SupplierInvoiceDate == default)
                    {
                        AddCriticalMessage("Supplier Invoice Date Missing");
                    }

                    if (oOrder.NominalCode.Trim().Length == 0)
                    {
                        AddCriticalMessage("Nominal Code Missing");
                    }

                    if (oOrder.DepartmentRef.Trim().Length == 0)
                    {
                        AddCriticalMessage("Department Reference Missing");
                    }

                    if (oOrder.ExtraRef.Trim().Length == 0)
                    {
                        AddCriticalMessage("Extra Reference Missing");
                    }

                    if (oOrder.TaxCodeID == 0)
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