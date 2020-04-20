using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteOrders
    {
        // make sure that contact object is valid
        public class QuoteOrderValidator : BaseValidator
        {
            public void Validate(QuoteOrder oQuoteOrder)
            {

                // make sure that contact object is valid
                if (oQuoteOrder.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oQuoteOrder.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oQuoteOrder.CustomerRef.Trim().Length == 0)
                {
                    AddCriticalMessage("*Customer Ref Missing");
                }
                else if (oQuoteOrder.QuoteOrderID == 0)
                {
                    if (App.DB.Order.Order_CheckReference(oQuoteOrder.CustomerRef).Table.Rows.Count > 0)
                    {
                        AddCriticalMessage("*The Customer Ref you have chosen has already been allocated to another Quote or Order in the system.  Please choose a unique Reference.");
                    }
                }

                if (oQuoteOrder.CustomerID == 0)
                {
                    AddCriticalMessage("*Customer Missing");
                }

                if (oQuoteOrder.PropertyID == 0 & oQuoteOrder.WarehouseID == 0)
                {
                    AddCriticalMessage("*Please select a Property or Warehouse");
                }

                if (oQuoteOrder.AllocatedToUser == 0)
                {
                    AddCriticalMessage("*Co-ordinator Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}