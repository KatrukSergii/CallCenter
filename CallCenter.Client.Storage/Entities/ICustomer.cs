namespace CallCenter.Common.Entities
{
    public interface ICustomer : ISerializable, IIdentifier
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        CustomerStatus Status { get; set; }
        ICampaign Campaign { get; set; }
    }
}