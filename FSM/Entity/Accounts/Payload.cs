// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Accounts.Payload
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections.Generic;

namespace FSM.Entity.Accounts
{
    public class Payload
    {
        public Payload()
        {
            this.Ledger = new List<Line>();
        }

        public List<Line> Ledger { get; set; }
    }
}