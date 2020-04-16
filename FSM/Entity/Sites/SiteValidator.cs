// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sites.SiteValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Sites
{
  public class SiteValidator : BaseValidator
  {
    public void Validate(Site oSite)
    {
      if (oSite.Errors.Count > 0)
      {
        foreach (object error in oSite.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oSite.CustomerID == 0)
        this.AddCriticalMessage("Customer Missing");
      if (oSite.RegionID == 0)
        this.AddCriticalMessage("Region Missing");
      if (oSite.Address1.Trim().Length == 0)
        this.AddCriticalMessage("Address1 Missing");
      if (oSite.Postcode.Trim().Length == 0)
        this.AddCriticalMessage("Postcode Missing");
      else if (oSite.Postcode.Split('-').Length == 1)
      {
        this.AddCriticalMessage("Postcode Format should have a dash in (xx-xxx or xxx-xxx or xxxx-xxx)");
      }
      else
      {
        if (((oSite.Postcode.Split('-')[0].Trim().Length == 1 ? 1 : 0) | (oSite.Postcode.Split('-')[0].Trim().Length >= 5 ? 1 : 0)) != 0)
          this.AddCriticalMessage("Postcode Format should have 2 - 4 characters before dash (xx-xxx or xxx-xxx or xxxx-xxx)");
        if (oSite.Postcode.Split('-')[1].Trim().Length != 3)
          this.AddCriticalMessage("Postcode Format should have 3 characters after dash (xx-xxx or xxx-xxx or xxxx-xxx)");
      }
      if (true == App.IsGasway)
      {
        if (oSite.SiteID == 0 & oSite.SourceOfCustomerID == 0)
          this.AddCriticalMessage("Source Of Customer Missing");
        if (oSite.SiteID == 0 & oSite.ReasonForContactID == 0)
          this.AddCriticalMessage("Reason For Contact Missing");
      }
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
