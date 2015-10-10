using CallCenter.Client.Communication;
using CallCenter.Common.Entities;

namespace CallCenter.Client.Core
{
    public class ServerConnection
    {
        public IOperator TestLogin(string operatorNumber)
        {
            IConnection connection = new Connection("", 0);
            connection.Connect();

            IOperator @operator = connection.LoginService.Login(operatorNumber);
            return @operator;
        }
    }
}