
namespace FSM.Entity.EngineerRoles
{
    public class EngineerAssignedToRole
    {
        public EngineerAssignedToRole()
        {
        }

        public int EngineerID { get; set; }
        public int RoleId { get; set; }
        public string EngineerName { get; set; }
        public string EngineerRole { get; set; }
        public string Description { get; set; }
    }
}