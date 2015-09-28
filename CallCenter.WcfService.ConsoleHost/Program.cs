using System;
using System.ServiceModel;

namespace CallCenter.WcfService.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost loginService = new ServiceHost(typeof(LoginService));
            loginService.Open();
            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}
