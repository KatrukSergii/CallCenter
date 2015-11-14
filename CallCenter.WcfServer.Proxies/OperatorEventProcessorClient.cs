using System;
using System.Diagnostics;
using System.ServiceModel;
using CallCenter.Common;
using CallCenter.Common.Entities;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfServer.Proxies
{
    public class OperatorEventProcessorClient : ClientBase<IOperatorEventProcessorService>,IOperatorEventProcessorService
    {
        public IOperator ChangeOperatorState(IOperatorEventInfo eventInfo)
        {
            try
            {
                if (eventInfo == null)
                    throw new ArgumentNullException("eventInfo");

                IOperator res = this.Channel.ChangeOperatorState(eventInfo);
                return res;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
            return null;
        }
    }

}
