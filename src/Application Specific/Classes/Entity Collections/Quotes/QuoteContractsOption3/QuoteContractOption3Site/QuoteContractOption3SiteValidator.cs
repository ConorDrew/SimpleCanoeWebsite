using System.Collections;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace QuoteContractOption3Sites
    {
        // make sure that contact object is valid
        public class QuoteContractOption3SiteValidator : BaseValidator
        {
            public void Validate(QuoteContractOption3Site oQuoteContractOption3Site, DataView assets)
            {

                // make sure that contact object is valid
                if (oQuoteContractOption3Site.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oQuoteContractOption3Site.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oQuoteContractOption3Site.QuoteContractSiteReference.Trim().Length == 0)
                {
                    AddCriticalMessage("* Site Reference Required");
                }

                if (!(oQuoteContractOption3Site.StartDate < oQuoteContractOption3Site.EndDate))
                {
                    AddCriticalMessage("* End Date must be greater than Start Date");
                }

                if (oQuoteContractOption3Site.FirstVisitDate < oQuoteContractOption3Site.StartDate | oQuoteContractOption3Site.FirstVisitDate > oQuoteContractOption3Site.EndDate)
                {
                    AddCriticalMessage("* First Visit Date must be between Start Date and End Date");
                }

                if (oQuoteContractOption3Site.VisitFrequencyID == 0)
                {
                    AddCriticalMessage("* Visit Frequency Required");
                }

                if (assets.Table.Columns.Count < 16)
                {
                    AddCriticalMessage("* Please load and fill in the assets schedule.");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}