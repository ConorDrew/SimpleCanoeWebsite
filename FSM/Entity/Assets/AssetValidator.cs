// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Assets.AssetValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Assets
{
    public class AssetValidator : BaseValidator
    {
        public void Validate(Asset oAsset)
        {
            if (oAsset.Errors.Count > 0)
            {
                foreach (object error in oAsset.Errors)
                    this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry)error : new DictionaryEntry()).Value));
            }
            if (oAsset.ProductID == 0)
                this.AddCriticalMessage("Product Missing");
            if (oAsset.SerialNum.Trim().Length == 0 && oAsset.Active)
                this.AddCriticalMessage("Serial Missing");
            if (oAsset.Location.Trim().Length == 0)
                this.AddCriticalMessage("Location Missing");
            if (this.ValidatorMessages.CriticalMessages.Count > 0)
                throw new ValidationException((BaseValidator)this);
        }
    }
}