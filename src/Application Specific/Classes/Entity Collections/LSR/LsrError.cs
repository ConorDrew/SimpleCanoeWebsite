using System;

namespace FSM.LSR
{
    public class LSRError
    {
        public int EngineerVisitID { get; set; }
        public string JobNumber { get; set; }
        public DateTime VisitDate { get; set; }
        public string Engineer { get; set; }
    }
}