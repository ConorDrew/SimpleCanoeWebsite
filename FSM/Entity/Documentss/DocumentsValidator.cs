// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Documentss.DocumentsValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;

namespace FSM.Entity.Documentss
{
  public class DocumentsValidator : BaseValidator
  {
    public void Validate(Documents oDocuments)
    {
      if (oDocuments.Errors.Count > 0)
      {
        foreach (object error in oDocuments.Errors)
          this.AddCriticalMessage(Conversions.ToString((error != null ? (DictionaryEntry) error : new DictionaryEntry()).Value));
      }
      if (oDocuments.TableEnumID == 0)
        this.AddCriticalMessage("Document Entity Missing");
      if (oDocuments.RecordID == 0)
        this.AddCriticalMessage("Document Record ID Missing");
      if (oDocuments.DocumentTypeID == 0)
        this.AddCriticalMessage("Document Type Missing");
      if (oDocuments.Name.Trim().Length == 0)
        this.AddCriticalMessage("Document Reference Missing");
      if (oDocuments.Location.Trim().Length == 0)
        this.AddCriticalMessage("Document Missing");
      if (this.ValidatorMessages.CriticalMessages.Count > 0)
        throw new ValidationException((BaseValidator) this);
    }
  }
}
