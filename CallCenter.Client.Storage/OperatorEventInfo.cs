namespace CallCenter.Common
{
    public class OperatorEventInfo: IOperatorEventInfo
    {
        public string OperatorNumber { get; set; }
        public EventReason Reason { get; set; }
        public IHostInfo HostInfo { get; set; }

        private OperatorEventInfo()
        {
            
        }

        public OperatorEventInfo(string operatorNumber, EventReason reason, IHostInfo hostInfo)
        {
            this.OperatorNumber = operatorNumber;
            this.Reason = reason;
            this.HostInfo = hostInfo;
        }
        public OperatorEventInfo(string operatorNumber, EventReason reason, string hostName)
        {
            this.OperatorNumber = operatorNumber;
            this.Reason = reason;
            this.HostInfo = new HostInfo {HostName = hostName};
        }
    }
}
