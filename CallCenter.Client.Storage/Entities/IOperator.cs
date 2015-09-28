namespace CallCenter.Common.Entities
{
    public interface IOperator:ISerializable, IIdentifier
    {
        string Number { get; set; }
        string Name { get; set; }
        ICallCenter CallCenter { get; set; }
    }
}
