using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;

namespace CallCenter.WcfServer.Proxies
{
    public class CustomerControllerProxy: ControllerProxyBase<ICustomer>, ICustomerController
    {
    }
}
