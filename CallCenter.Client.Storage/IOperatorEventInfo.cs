using CallCenter.Common.Entities;

namespace CallCenter.Common
{
    public interface IOperatorEventInfo: ISerializable
    {
        string OperatorNumber { get; set; }
        EventReason Reason { get; set; }
        IHostInfo HostInfo { get; set; }
    }
}