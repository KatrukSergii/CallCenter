using System;
using CallCenter.Common;
using CallCenterRepository.Controllers;

namespace CallCenter.Server
{
    public class ServerEventsProcessor : IServerEventsProcessor
    {
        private readonly IControllerFactory controllerFactory;

        public ServerEventsProcessor(IControllerFactory controllerFactory)
        {
            if (controllerFactory == null)
                throw new ArgumentNullException("controllerFactory");

            this.controllerFactory = controllerFactory;

            this.OperatorProcessor = new OperatorProcessor(this.controllerFactory);
            this.ChatProcessor = new ChatProcessor(this.controllerFactory);
        }

        public IOperatorProcessor OperatorProcessor { get; private set; }
        public IChatProcessor ChatProcessor { get; private set; }
    }
}