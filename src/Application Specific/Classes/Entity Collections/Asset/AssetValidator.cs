using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Assets
    {
        // make sure that contact object is valid
        public class AssetValidator : BaseValidator
        {
            public void Validate(Asset oAsset)
            {

                // make sure that contact object is valid
                if (oAsset.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oAsset.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oAsset.ProductID == 0)
                {
                    AddCriticalMessage("Product Missing");
                }

                if (oAsset.SerialNum.Trim().Length == 0 && oAsset.Active)
                {
                    AddCriticalMessage("Serial Missing");
                }

                if (oAsset.Location.Trim().Length == 0)
                {
                    AddCriticalMessage("Location Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}