using System.Collections;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOption3Sites
    {
        // make sure that contact object is valid
        public class ContractOption3SiteValidator : BaseValidator
        {
            public void Validate(ContractOption3Site oContractOption3Site, DataView assets)
            {
                // make sure that contact object is valid
                if (oContractOption3Site.Errors.Count > 0)
                {
                    foreach (DictionaryEntry de in oContractOption3Site.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oContractOption3Site.ContractSiteReference.Trim().Length == 0)
                {
                    AddCriticalMessage("* Property Reference Required");
                }

                if (!(oContractOption3Site.StartDate < oContractOption3Site.EndDate))
                {
                    AddCriticalMessage("* End Date must be greater than Start Date");
                }

                if (oContractOption3Site.FirstVisitDate < oContractOption3Site.StartDate | oContractOption3Site.FirstVisitDate > oContractOption3Site.EndDate)
                {
                    AddCriticalMessage("* First Visit Date must be between Start Date and End Date");
                }

                if (oContractOption3Site.InvoiceFrequencyID == 0)
                {
                    AddCriticalMessage("* Invoice Frequency Required");
                }

                if (oContractOption3Site.VisitFrequencyID == 0)
                {
                    AddCriticalMessage("* Visit Frequency Required");
                }

                if (assets.Table.Columns.Count < 16)
                {
                    AddCriticalMessage("* Please load and fill in the assets schedule.");
                }

                if (oContractOption3Site.InvoiceAddressID == 0)
                {
                    AddCriticalMessage("Invoice Address Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}