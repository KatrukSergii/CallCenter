using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;
using CallCenter.Server.Helper;
using CallCenter.ServiceContracts;

namespace CallCenter.WcfService
{
    [ServiceKnownType("GetKnownTypes", typeof(KnownTypesHelper))]
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
