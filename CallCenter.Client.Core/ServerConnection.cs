using CallCenter.Client.Communication;
using CallCenter.Common;
using CallCenter.Common.Entities;

namespace CallCenter.Client.Core
{
    public class ServerConnection
    {
        public IOperator TestLogin(string operatorNumber)
        {
            IConnection connection = new Connection("", 0);
            connection.Connect();

            IOperator @operator =
                connection.OperatorEventProcessorService.ChangeOperatorState(new OperatorEventInfo(operatorNumber,
                    EventReason.Login, new HostInfo() {HostName = "ws78"}));
            return @operator;
        }
    }
}