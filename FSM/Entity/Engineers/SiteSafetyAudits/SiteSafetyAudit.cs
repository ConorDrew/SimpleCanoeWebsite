// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Engineers.SiteSafetyAudits.SiteSafetyAudit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;

namespace FSM.Entity.Engineers.SiteSafetyAudits
{
    public class SiteSafetyAudit
    {
        public int Id { get; set; }

        public int EngineerId { get; set; }

        public string Department { get; set; }

        public DateTime AuditDate { get; set; }

        public double Question1 { get; set; }

        public double Question2 { get; set; }

        public double Question3 { get; set; }

        public double Question4 { get; set; }

        public double Question5 { get; set; }

        public double Question6 { get; set; }

        public double Question7 { get; set; }

        public double Question8 { get; set; }

        public double Question9 { get; set; }

        public double Question10 { get; set; }

        public double Question11 { get; set; }

        public double Result { get; set; }

        public int AuditorId { get; set; }
    }
}