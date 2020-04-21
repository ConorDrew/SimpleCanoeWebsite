namespace FSM
{
    public static class Interfaces
    {
        public interface IPersistable
        {
            string CurrentLocation { get; set; }
            string DefaultName { get; }
            bool HasBeenPersisted { get; set; }
            string PersistName { get; set; }
        }
    }
}