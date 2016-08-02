using CallCenter.Common;

namespace CallCenter.Server
{
    public class Server:IServer
    {
        public void Start()
        {
            
        }
        public void Stop()
        {
            
        }
        public Server(IOperatorService operatorService)
        {
            this.OperatorService = operatorService;
        }
        public IOperatorService OperatorService { get; private set; }
    }
}
