using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;

namespace CallCenter.WcfServer.Proxies
{
    public class CustomerControllerProxy: ControllerProxyBase<ICustomer>, ICustomerController
    {
    }
}
