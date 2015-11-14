using CallCenter.Common.Entities;

namespace CallCenter.Common
{
    public interface IHostInfo: ISerializable
    {
        string HostName { get; set; }
    }
}