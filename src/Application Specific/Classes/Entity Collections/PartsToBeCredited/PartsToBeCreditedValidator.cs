using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartsToBeCrediteds
    {
        // make sure that contact object is valid
        public class PartsToBeCreditedValidator : BaseValidator
        {
            public void Validate(PartsToBeCredited oPartsToBeCredited)
            {

                // make sure that contact object is valid
                if (oPartsToBeCredited.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oPartsToBeCredited.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oPartsToBeCredited.PartID == 0)
                {
                    AddCriticalMessage("Part Missing");
                }
                else if (oPartsToBeCredited.OrderID > 0)
                {
                    var dvItems = App.DB.Order.OrderPart_GetForOrder(oPartsToBeCredited.OrderID);
                    var r = dvItems.Table.Select("PartID=" + oPartsToBeCredited.PartID);
                    if (r.Length > 0)
                    {
                        if (Conversions.ToBoolean(oPartsToBeCredited.Qty > r[0]["Qty"]))
                        {
                            AddCriticalMessage("Qty cannot be higher than quantity ordered.");
                        }
                    }
                }

                if (oPartsToBeCredited.SupplierID == 0)
                {
                    AddCriticalMessage("Supplier Missing");
                }

                if (oPartsToBeCredited.OrderReference.Length == 0)
                {
                    AddCriticalMessage("Select an order or enter a reference ");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}