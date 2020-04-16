// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerRoles.EngineerRole
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;

namespace FSM.Entity.EngineerRoles
{
    public class EngineerRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Decimal HourlyCostToCompany { get; set; }
    }
}