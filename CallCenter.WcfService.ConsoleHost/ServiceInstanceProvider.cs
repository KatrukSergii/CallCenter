using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using CallCenter.Common;
using CallCenter.Server;
using CallCenter.Server.Helper;
using CallCenterRepository.Controllers;

namespace CallCenter.WcfService.ConsoleHost
{
    public class ServiceInstanceProvider<T> : IInstanceProvider 
    {
        public object GetInstance(InstanceContext instanceContext)
        {
            return new OpeartorEventsProcessorService(Resolver.Resolve<IServerEventsProcessor>());
        }

        private static readonly IServerEventsProcessor serverEventsProcessor = new ServerEventsProcessor(Resolver.Resolve<IControllerFactory>());

        public object GetInstance(InstanceContext instanceContext,
            Message message)
        {
            return Activator.CreateInstance(typeof(T), serverEventsProcessor);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}