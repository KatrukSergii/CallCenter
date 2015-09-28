using System.Runtime.Serialization;

namespace CallCenter.Common.Entities
{
    public interface IOperator:ISerializable
    {
        int Id { get; set; }
        string Number { get; set; }
        string Name { get; set; }
        ICallCenter CallCenter { get; set; }
    }
}
