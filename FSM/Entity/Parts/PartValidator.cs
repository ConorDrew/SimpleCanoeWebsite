// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Parts.PartValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Parts
{
  public class PartValidator : BaseValidator
  {
    public void Validate(Part oPart)
    {
      if (oPart.Errors.Count > 0)
      {
        foreach (object error in oPart.Errors)
        {
          DictionaryEntry dictionaryEntry = error != null ? (DictionaryEntry) error : new DictionaryEntry();
          if (Operators.ConditionalCompareObjectEqual(dictionaryEntry.Key, (object) "RecommendedQuantity", false))
            this.AddCriticalMessage("Maximum Quantity Invalid");
          else if (Operators.ConditionalCompareObjectEqual(dictionaryEntry.Key, (object) "MinimumQuantity", false))
            this.AddCriticalMessage("Minimum Quantity Invalid");
          else
            this.AddCriticalMessage(Conversions.ToString(dictionaryEntry.Value));
        }
      }
      if (oPart.Name.Trim().Length == 0)
        this.AddCriticalMessage("*Name Missing");
      if (oPart.Number.Trim().Length == 0)
        this.AddCriticalMessage("*Number Missing");
      else if (!App.DB.Part.Check_Unique_Number(oPart.Number, oPart.PartID))
        this.AddCriticalMessage("*Number already exists");
      if (oPart.UnitTypeID <= 0)
        this.AddCriticalMessage("*Unit Type Missing");
      if (oPart.CategoryID <= 0)
        this.AddCriticalMessage("*Category Missing");
      if (oPart.RecommendedQuantity < oPart.MinimumQuantity)
        this.AddCriticalMessage("*Maximum Quantity cannot be less than the Minimum Quantity");
      if ((uint) oPart.BinID > 0U && !App.DB.Part.Check_Unique_Bin(oPart.BinID, oPart.PartID, "BinID"))
        this.AddCriticalMessage("*BIN reference already used");
      if ((uint) oPart.BinIDAlternative > 0U && !App.DB.Part.Check_Unique_Bin(oPart.BinIDAlternative, oPart.PartID, "BinIDAlternative"))
        this.AddCriticalMessage("*Alternative BIN reference already used");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
