using System;
using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Management
    {
        public class SettingsValidator : BaseValidator
        {
            public void Validate(Settings settings)
            {
                if (settings.Errors.Count > 0)
                {
                    DictionaryEntry de;
                    foreach (var de in settings.Errors)
                        AddCriticalMessage(Conversions.ToString(de.Value));
                }

                bool checkDay = true;
                if (settings.WorkingHoursStart.Trim().Length == 0)
                {
                    AddCriticalMessage("Working Hours Start Missing");
                    checkDay = true;
                }

                if (settings.WorkingHoursEnd.Trim().Length == 0)
                {
                    AddCriticalMessage("Working Hours End Missing");
                    checkDay = true;
                }

                if (checkDay)
                {
                    var sd = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, Conversions.ToInteger(settings.WorkingHoursStart.Trim().Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursStart.Trim().Substring(3, 2)), 0);
                    var ed = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, Conversions.ToInteger(settings.WorkingHoursEnd.Trim().Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursEnd.Trim().Substring(3, 2)), 0);
                    if (sd >= ed)
                    {
                        AddCriticalMessage("Working Hours End must be after the Start");
                    }
                }

                if (settings.MileageRate == 0)
                {
                    AddCriticalMessage("Mileage Rate Missing");
                }

                if (!Information.IsNumeric(settings.MileageRate))
                {
                    AddCriticalMessage("Mileage Rate Invalid");
                }

                if (settings.PartsMarkup == 0)
                {
                    AddCriticalMessage("Parts Markup Missing");
                }

                if (!Information.IsNumeric(settings.PartsMarkup))
                {
                    AddCriticalMessage("Parts Markup Invalid");
                }

                if (settings.RatesMarkup == 0)
                {
                    AddCriticalMessage("Rates Markup Missing");
                }

                if (!Information.IsNumeric(settings.RatesMarkup))
                {
                    AddCriticalMessage("Rates Markup Invalid");
                }

                if (settings.CalloutPrefix.Trim().Length == 0)
                {
                    AddCriticalMessage("Callout Prefix Missing");
                }

                if (settings.MiscPrefix.Trim().Length == 0)
                {
                    AddCriticalMessage("Miscellaneous Prefix Missing");
                }

                if (settings.PPMPrefix.Trim().Length == 0)
                {
                    AddCriticalMessage("PPM Prefix Missing");
                }

                if (settings.QuotePrefix.Trim().Length == 0)
                {
                    AddCriticalMessage("Quote Prefix Missing");
                }

                if (settings.ServiceFromLetterPrefix.Trim().Length == 0)
                {
                    AddCriticalMessage("Service From Letter Prefix Missing");
                }

                if (ValidatorMessages.CriticalMessages.Count > 0)
                {
                    throw new ValidationException(this);
                }
            }
        }
    }
}