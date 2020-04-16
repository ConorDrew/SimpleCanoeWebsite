// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisits.EngineerVisitEngineers.EngineerVisitEngineer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

namespace FSM.Entity.EngineerVisits.EngineerVisitEngineers
{
    public class EngineerVisitEngineer
    {
        public int Id { get; set; }

        public int EngineerVisitId { get; set; }

        public int EngineerId { get; set; }

        public int Department { get; set; }

        public string OftecNo { get; set; }

        public string GasSafeNo { get; set; }

        public int ManagerId { get; set; }

        public double CostToCompany { get; set; }
    }
}