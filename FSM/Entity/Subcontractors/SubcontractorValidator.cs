// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Subcontractors.SubcontractorValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Subcontractors
{
  public class SubcontractorValidator : BaseValidator
  {
    public void Validate(Subcontractor oSubcontractor)
    {
      if (oSubcontractor.Errors.Count > 0)
      {
        foreach (object error in oSubcontractor.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oSubcontractor.Engineer.Errors.Count > 0)
      {
        foreach (object error in oSubcontractor.Engineer.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oSubcontractor.Name.Trim().Length == 0)
        this.AddCriticalMessage("Subcontractor Name Missing");
      else if (!App.DB.Engineer.Check_Unique_Name(oSubcontractor.Name.Trim(), oSubcontractor.Engineer.EngineerID))
        this.AddCriticalMessage("This Subcontractor Name already exists as an engineer");
      if (oSubcontractor.Address1.Trim().Length == 0)
        this.AddCriticalMessage("Subcontractor Address 1 Missing");
      if (oSubcontractor.Postcode.Trim().Length == 0)
        this.AddCriticalMessage("Subcontractor Postcode Missing");
      if (oSubcontractor.TelephoneNum.Trim().Length == 0)
        this.AddCriticalMessage("Subcontractor Telephone Missing");
      if (oSubcontractor.Engineer.RegionID == 0)
        this.AddCriticalMessage("Region Missing");
      if (!App.DB.Engineer.Check_Unique_PDAID(oSubcontractor.Engineer.PDAID, oSubcontractor.EngineerID))
        this.AddCriticalMessage("PDA ID already exists");
      if (!this.CheckShortDateIsValid(oSubcontractor.Engineer.HolidayYearStart))
        this.AddCriticalMessage("'Start Period' for holiday entitlement must be in the format of 'dd/mm'");
      if (!this.CheckShortDateIsValid(oSubcontractor.Engineer.HolidayYearEnd))
        this.AddCriticalMessage("'End Period' for holiday entitlement must be in the format of 'dd/mm'");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }

    private bool CheckShortDateIsValid(string strDate)
    {
      if (strDate.Length == 0)
        return true;
      strDate = strDate.Trim();
      bool flag = true;
      if (strDate.Length != 5)
      {
        flag = false;
      }
      else
      {
        char[] charArray = strDate.ToCharArray();
        if (!Versioned.IsNumeric((object) charArray[0]))
          flag = false;
        if (!Versioned.IsNumeric((object) charArray[1]))
          flag = false;
        if ((uint) Operators.CompareString(Conversions.ToString(charArray[2]), "/", false) > 0U)
          flag = false;
        if (!Versioned.IsNumeric((object) charArray[3]))
          flag = false;
        if (!Versioned.IsNumeric((object) charArray[4]))
          flag = false;
      }
      return flag;
    }
  }
}
