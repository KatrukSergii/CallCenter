using CallCenter.Common.Entities;

namespace CallCenter.Client.SqlStorage.Entities
{
    public class Operator : IOperator, ISerializable
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
        public virtual string Name { get; set; }
        public virtual ICallCenter CallCenter { get; set; }
        public virtual string Password { get; set; }
    }
}
