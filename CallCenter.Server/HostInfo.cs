using CallCenter.Common;

namespace CallCenter.Server
{
    public class HostInfo:IHostInfo
    {
        public HostInfo(string hostName)
        {
            this.HostName = hostName;
        }
        public string HostName { get; set; }
    }
}