using System;

namespace FSM.Entity.Engineers.SiteSafetyAudits
{
    public class SiteSafetyAudit
    {
        public SiteSafetyAudit()
        {
        }

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