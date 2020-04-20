
namespace FSM.Entity.EngineerRoles
{
    public class EngineerRole
    {
        public EngineerRole()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal HourlyCostToCompany { get; set; }
    }
}