namespace CallCenter.Common.Entities
{
    public interface ICampaign : ISerializable, IIdentifier
    {
        string Name { get; set; }
        ICallCenter CallCenter { get; set; }
    }
}