using CallCenter.Common.Entities;

namespace CallCenter.Client.SqlStorage.Entities
{
    public class Customer : ICustomer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual CustomerStatus Status { get; set; }
        public virtual ICampaign Campaign { get; set; }
    }
}