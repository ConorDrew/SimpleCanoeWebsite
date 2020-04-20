using System;

namespace FSM.Entity.ContactAttempts
{
    public class ContactAttempt
    {
        public ContactAttempt()
        {
        }

        public int ContactAttemptID { get; set; }
        public int ContactMethedID { get; set; }
        public int LinkID { get; set; }
        public int LinkRef { get; set; }
        public DateTime ContactMade { get; set; }
        public string Notes { get; set; }
        public int ContactMadeByUserId { get; set; }
        public string ContactMethod { get; set; }
        public string ContactMadeBy { get; set; }
    }
}