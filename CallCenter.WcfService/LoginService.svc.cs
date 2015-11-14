using System;
using CallCenter.Common;
using CallCenter.Common.Entities;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfService
{
    public class OpeartorEventsProcessorService : ServiceBase, IOperatorEventProcessorService
    {
        public OpeartorEventsProcessorService(IServerEventsProcessor serverEventsProcessor) : base(serverEventsProcessor)
        {
        }

        public IOperator ChangeOperatorState(IOperatorEventInfo eventInfo)
        {
            if (eventInfo == null)
                throw new ArgumentNullException("eventInfo");

            return this.ServerEventsProcessor.OperatorProcessor.ChangeOperatorState(eventInfo);
        }
    }
}