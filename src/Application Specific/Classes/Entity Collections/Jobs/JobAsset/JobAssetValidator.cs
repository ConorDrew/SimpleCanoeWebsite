using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace JobAssets
    {
        // make sure that contact object is valid
        public class JobAssetValidator : BaseValidator
        {
            public void Validate(JobAsset oJobAsset)
            {

                // make sure that contact object is valid
                if (oJobAsset.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oJobAsset.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}