using System.Collections;
using FSM.Entity.SalesCredits;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace PartsToBeCrediteds
    {
        // make sure that contact object is valid
        public class SalesCreditValidator : BaseValidator
        {
            public void Validate(SalesCredit oPartsToBeCredited)
            {

                // make sure that contact object is valid
                if (oPartsToBeCredited.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oPartsToBeCredited.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                // If oPartsToBeCredited.PartID = 0 Then
                // Me.AddCriticalMessage("Part Missing")
                // Else
                // If oPartsToBeCredited.OrderID > 0 Then
                // Dim dvItems As DataView = DB.Order.OrderPart_GetForOrder(oPartsToBeCredited.OrderID)
                // Dim r() As DataRow = dvItems.Table.Select("PartID=" & oPartsToBeCredited.PartID)
                // If r.Length > 0 Then
                // If oPartsToBeCredited.Qty > r(0).Item("Qty") Then
                // Me.AddCriticalMessage("Qty cannot be higher than quantity ordered.")
                // End If
                // End If
                // End If
                // End If
                // If oPartsToBeCredited.SupplierID = 0 Then
                // Me.AddCriticalMessage("Supplier Missing")
                // End If

                // If oPartsToBeCredited.OrderReference.Length = 0 Then
                // Me.AddCriticalMessage("Select an order or enter a reference ")
                // End If


                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}