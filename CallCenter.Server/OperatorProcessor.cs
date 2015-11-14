using System;
using CallCenter.Common;
using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;

namespace CallCenter.Server
{
    public class OperatorProcessor : ProcessorBase, IOperatorProcessor
    {
        public OperatorProcessor(IControllerFactory controllerFactory) : base(controllerFactory)
        {
        }

        public IOperator ChangeOperatorState(IOperatorEventInfo eventInfo)
        {
            switch (EventReason.Login)
            {
                case EventReason.Login:
                    this.ControllerFactory.OperatorsController.LogAction(eventInfo, DateTime.Now);
                    return this.ControllerFactory.OperatorsController.GetByNumber(eventInfo.OperatorNumber);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}