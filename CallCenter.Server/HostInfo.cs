using System;
using CallCenter.Common;

namespace CallCenter.Server
{
    public class HostInfo:IHostInfo
    {
        public HostInfo(string hostName)
        {
            if(string.IsNullOrWhiteSpace(hostName))
                throw new ArgumentNullException("hostName");

            this.HostName = hostName;
        }
        public string HostName { get; set; }
    }
}