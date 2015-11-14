using CallCenter.Common;
using CallCenter.Common.Entities;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.Client.Communication
{
    public class OperatorEventProcessorService : IOperatorEventProcessorService
    {
        private readonly IOperatorEventProcessorService operatorEventProcessorService;

        public OperatorEventProcessorService(IOperatorEventProcessorService operatorEventProcessorService)
        {
            this.operatorEventProcessorService = operatorEventProcessorService;
        }

        public IOperator ChangeOperatorState(IOperatorEventInfo eventInfo)
        {
            IOperator returnedOperatorData = this.operatorEventProcessorService.ChangeOperatorState(eventInfo);
            return returnedOperatorData;
        }
    }
}