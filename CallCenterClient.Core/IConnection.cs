using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenter.WcfService;

namespace CallCenter.Client.Core
{
    public interface IConnection
    {
        string Host { get; set; }
        int Port { get; set; }

        void Connect();

        void Disconncet();

        ILoginService LoginService { get; set; }

        ICustomerRepository CustomerRepository { get; set; }
    }
}