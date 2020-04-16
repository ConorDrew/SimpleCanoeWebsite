// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitPartProductAllocateds.EngineerVisitPartProductAllocatedValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.EngineerVisitPartProductAllocateds
{
    public class EngineerVisitPartProductAllocatedValidator : BaseValidator
    {
        public void Validate(
          EngineerVisitPartProductAllocated oEngineerVisitPartAllocated)
        {
            if (oEngineerVisitPartAllocated.Errors.Count > 0)
            {
                foreach (object error in oEngineerVisitPartAllocated.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oEngineerVisitPartAllocated.Type.Trim().Length == 0)
                this.AddCriticalMessage("Item Type Missing");
            if (oEngineerVisitPartAllocated.PartProductID == 0)
                this.AddCriticalMessage("Item Missing");
            if (oEngineerVisitPartAllocated.Quantity <= 0)
                this.AddCriticalMessage("Quantity Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}