
namespace FSM.Entity.EngineerVisits.EngineerVisitEngineers
{
    public class EngineerVisitEngineer
    {
        public EngineerVisitEngineer()
        {
        }

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