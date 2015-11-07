using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CallCenter.WcfService.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost loginService = new ServiceHost(typeof(LoginService));
            loginService.Open();
            ServiceHost chatService = new ServiceHost(typeof(ChatService));
            chatService.Open();
            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}
