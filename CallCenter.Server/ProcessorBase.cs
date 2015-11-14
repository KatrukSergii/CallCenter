using System;
using CallCenterRepository.Controllers;

namespace CallCenter.Server
{
    public abstract class ProcessorBase
    {
        protected readonly IControllerFactory ControllerFactory;

        protected ProcessorBase(IControllerFactory controllerFactory)
        {
            if (controllerFactory == null)
                throw new ArgumentNullException("controllerFactory");
            this.ControllerFactory = controllerFactory;
        }
    }
}