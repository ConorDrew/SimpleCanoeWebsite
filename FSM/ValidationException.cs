// Decompiled with JetBrains decompiler
// Type: FSM.ValidationException
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;

namespace FSM
{
  public class ValidationException : Exception
  {
    private BaseValidator m_valid;

    public BaseValidator Validator
    {
      get
      {
        return this.m_valid;
      }
      set
      {
        this.m_valid = value;
      }
    }

    public ValidationException(BaseValidator inValidator)
    {
      this.m_valid = new BaseValidator();
      this.m_valid = inValidator;
    }
  }
}
