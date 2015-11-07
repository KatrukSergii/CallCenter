using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;
using CallCenter.ServiceContracts;
using CallCenter.ServiceContracts.Services;
using CallCenter.WcfServer.Proxies;

namespace CallCenter.Client.Communication
{
    public class Connection: IConnection
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public Connection(string host = "localhost", int port = 8080)
        {
            this.Host = string.IsNullOrEmpty(host) ? "localhost" : host;
            this.Port = port == 0 ? 8080 : port;
        }

        public void Connect()
        {
            this.LoginService = new LoginService(new LoginClient());
            this.ChatService = new ChatServiceProxy();
            //this.CustomerRepository = new CustomerControllerProxy();
            //this.OperatorController = new ControllerProxyBase<IOperator>();
            //this.CallCenterController = new ControllerProxyBase<ICallCenter>();
            //this.CampaignController = new ControllerProxyBase<ICampaign>();
        }

        public void Disconncet()
        {
            
        }

        public ILoginService LoginService { get; set; }
        public ICustomerController CustomerRepository { get; set; }
        public IEntityController<IOperator> OperatorController { get; private set; } 
        public IEntityController<ICallCenter> CallCenterController { get; private set; }
        public IEntityController<ICampaign> CampaignController { get; private set; } 
        public IChatService ChatService { get; private set; }
    }
}
