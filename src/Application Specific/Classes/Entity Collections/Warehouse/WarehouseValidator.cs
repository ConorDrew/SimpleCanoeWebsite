using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Warehouses
    {
        // make sure that contact object is valid
        public class WarehouseValidator : BaseValidator
        {
            public void Validate(Warehouse oWarehouse)
            {

                // make sure that contact object is valid
                if (oWarehouse.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oWarehouse.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oWarehouse.Name.Trim().Length == 0)
                {
                    AddCriticalMessage("Name Missing");
                }

                if (oWarehouse.Address1.Trim().Length == 0)
                {
                    AddCriticalMessage("Address1 Missing");
                }

                if (oWarehouse.Postcode.Trim().Length == 0)
                {
                    AddCriticalMessage("Postcode Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}