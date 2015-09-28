using System.Collections.Generic;
using CallCenter.Common.Entities;

namespace CallCenter.Client.SqlStorage.Entities
{
    public class CallCenter : ICallCenter
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IEnumerable<IOperator> Operators { get; set; }
        public virtual IEnumerable<ICampaign> Campaigns { get; set; }
    }
}