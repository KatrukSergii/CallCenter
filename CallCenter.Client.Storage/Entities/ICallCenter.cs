using System.Collections.Generic;

namespace CallCenter.Common.Entities
{
    public interface ICallCenter : ISerializable
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<IOperator> Operators { get; set; }
        IEnumerable<ICampaign> Campaigns { get; set; }
    }
}