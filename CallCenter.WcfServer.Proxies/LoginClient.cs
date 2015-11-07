using System;
using System.Diagnostics;
using System.ServiceModel;
using CallCenter.Common.Entities;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfServer.Proxies
{
    public class LoginClient : ClientBase<ILoginService>,ILoginService
    {
        public IOperator Login(string number)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(number))
                    throw new ArgumentNullException("number");

                IOperator res = this.Channel.Login(number);
                return res;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
            return null;
        }

        public void LogOut(string number)
        {
            this.Channel.LogOut(number);
        }
    }

}
