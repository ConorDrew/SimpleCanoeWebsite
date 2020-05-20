
namespace FSM.Entity.Settings.Scheduler
{
    public class JobTypeColour
    {
        public JobTypeColour()
        {
        }

        public int Id { get; set; }
        public int JobTypeId { get; set; }
        public string JobType { get; set; }
        public string Colour { get; set; }
    }
}