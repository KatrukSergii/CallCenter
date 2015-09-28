namespace CallCenter.Common.Entities
{
    public interface ICampaign : ISerializable
    {
        int Id { get; set; }
        string Name { get; set; }
        ICallCenter CallCenter { get; set; }
    }
}