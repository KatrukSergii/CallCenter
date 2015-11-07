using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;
using CallCenter.Server.Helper;
using CallCenter.ServiceContracts;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfService
{
    public class LoginService : ILoginService
    {
        public IOperator Login(string number)
        {
            IControllerFactory controllerFactory = Resolver.Resolve<IControllerFactory>();
            return controllerFactory.OperatorsController.GetByNumber(number);
        }

        public void LogOut(string number)
        {
            
        }
    }
}
