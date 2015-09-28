using CallCenter.Common.Entities;

namespace CallCenter.Client.SqlStorage.Entities
{
    public class Campaign : ICampaign
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICallCenter CallCenter { get; set; }
    }
}