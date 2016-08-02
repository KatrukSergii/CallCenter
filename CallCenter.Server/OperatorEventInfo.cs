using CallCenter.Common;

namespace CallCenter.Server
{
    public class OperatorEventInfo : IOperatorEventInfo
    {
        public OperatorEventInfo(string operatorNumber, EventReason reason, IHostInfo hostInfo)
        {
            this.HostInfo = hostInfo;
            this.OperatorNumber = operatorNumber;
            this.Reason = reason;
        }
        public string OperatorNumber { get; set; }
        public EventReason Reason { get; set; }
        public IHostInfo HostInfo { get; set; }
    }
}