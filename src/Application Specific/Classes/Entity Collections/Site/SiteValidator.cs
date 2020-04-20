using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Sites
    {
        // make sure that contact object is valid
        public class SiteValidator : BaseValidator
        {
            public void Validate(Site oSite)
            {

                // make sure that contact object is valid
                if (oSite.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in oSite.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                if (oSite.CustomerID == 0)
                {
                    AddCriticalMessage("Customer Missing");
                }

                if (oSite.RegionID == 0)
                {
                    AddCriticalMessage("Region Missing");
                }

                if (oSite.Address1.Trim().Length == 0)
                {
                    AddCriticalMessage("Address1 Missing");
                }

                if (oSite.Postcode.Trim().Length == 0)
                {
                    AddCriticalMessage("Postcode Missing");
                }
                else if (oSite.Postcode.Split('-').Length == 1)
                {
                    AddCriticalMessage("Postcode Format should have a dash in (xx-xxx or xxx-xxx or xxxx-xxx)");
                }
                else
                {
                    if (oSite.Postcode.Split('-')[0].Trim().Length == 1 | oSite.Postcode.Split('-')[0].Trim().Length >= 5)
                    {
                        AddCriticalMessage("Postcode Format should have 2 - 4 characters before dash (xx-xxx or xxx-xxx or xxxx-xxx)");
                    }

                    if (oSite.Postcode.Split('-')[1].Trim().Length != 3)
                    {
                        AddCriticalMessage("Postcode Format should have 3 characters after dash (xx-xxx or xxx-xxx or xxxx-xxx)");
                    }
                }

                switch (true)
                {
                    case object _ when App.IsGasway:
                        {
                            if (oSite.SiteID == 0 & oSite.SourceOfCustomerID == 0)
                            {
                                AddCriticalMessage("Source Of Customer Missing");
                            }

                            if (oSite.SiteID == 0 & oSite.ReasonForContactID == 0)
                            {
                                AddCriticalMessage("Reason For Contact Missing");
                            }

                            break;
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