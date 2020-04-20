
namespace FSM.Entity.CostCentres
{
    public class CostCentre
    {
        public CostCentre()
        {
        }

        public int Id { get; set; }
        public int CostCentre { get; set; }
        public int JobTypeId { get; set; }
        public int LinkId { get; set; }
        public int LinkTypeId { get; set; }
        public decimal JobSpendLimit { get; set; }
    }
}