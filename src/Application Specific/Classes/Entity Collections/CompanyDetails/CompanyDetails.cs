
namespace FSM.Entity.CompanyDetails
{
    public class CompanyDetails
    {
        public CompanyDetails()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string Postcode { get; set; }
        public byte[] Logo { get; set; }
        public string TelephoneNumber { get; set; }
        public string Website { get; set; }
        public string Domain { get; set; }
        public string EmailAddress { get; set; }
        public string SalesEmailAddress { get; set; }
        public string ContractEmailAddress { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public string CompanyNumber { get; set; }
        public string VatNumber { get; set; }
    }
}