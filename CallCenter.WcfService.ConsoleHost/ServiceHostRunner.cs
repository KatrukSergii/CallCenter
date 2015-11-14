using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace CallCenter.WcfService.ConsoleHost
{
    public static class ServiceHostRunner
    {
        public static ServiceHost StartServiceHost<T, U>(string address, Binding binding)
        {
            ServiceHost host = new ServiceHost(typeof (T));
            ServiceEndpoint endpoint =
                host.AddServiceEndpoint(typeof (U), binding, address);
            endpoint.Behaviors.Add(new SingleInstance<T>());
            host.Open();
            return host;
        }
    }
}