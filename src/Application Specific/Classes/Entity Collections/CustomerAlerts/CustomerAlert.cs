using System;

namespace FSM.Entity.Customers
{
    public class CustomerAlert
    {
        public CustomerAlert()
        {
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AlertTypeId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Created { get; set; }
        public string AlertType { get; set; }
    }
}