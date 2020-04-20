using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace ContractOriginalSites
    {
        // make sure that contact object is valid
        public class ContractOriginalSiteValidator : BaseValidator
        {
            public void Validate(ContractOriginalSite oContractSite, ContractsOriginal.ContractOriginal contract)
            {

                // make sure that contact object is valid
                if (oContractSite.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oContractSite.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oContractSite.VisitFrequencyID == 0)
                {
                    AddCriticalMessage("Visit Frequency Missing");
                }

                if (oContractSite.VisitDuration < 1)
                {
                    AddCriticalMessage("Visit Duration must be great than 0");
                }

                if (oContractSite.FirstVisitDate.Date < contract.ContractStartDate.Date | oContractSite.FirstVisitDate.Date >= contract.ContractEndDate.Date)
                {
                    AddCriticalMessage("First Visit Date must be between Contract Start and End Date");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}