using CallCenter.Common;
using CallCenter.Common.Entities;
using CallCenter.ServiceContracts;

namespace CallCenter.Client.Communication
{
    public class LoginService : ILoginService
    {
        private readonly ILoginService loginService;

        public LoginService(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public IOperator Login(string operatorNumber)
        {
            IOperator returnedOperatorData = this.loginService.Login(operatorNumber);
            return returnedOperatorData;
        }

        public void LogOut(string operatorNumber)
        {
            this.loginService.LogOut(operatorNumber);
        }
        
    }
}