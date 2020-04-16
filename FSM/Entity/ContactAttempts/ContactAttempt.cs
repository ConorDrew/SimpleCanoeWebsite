// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContactAttempts.ContactAttempt
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;

namespace FSM.Entity.ContactAttempts
{
  public class ContactAttempt
  {
    public int ContactAttemptID { get; set; }

    public int ContactMethedID { get; set; }

    public int LinkID { get; set; }

    public int LinkRef { get; set; }

    public DateTime ContactMade { get; set; }

    public string Notes { get; set; }

    public int ContactMadeByUserId { get; set; }

    public string ContactMethod { get; set; }

    public string ContactMadeBy { get; set; }
  }
}
