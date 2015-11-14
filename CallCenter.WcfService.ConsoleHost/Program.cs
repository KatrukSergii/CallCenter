using System;
using System.ServiceModel;
using CallCenter.ServiceContracts.Services;

namespace CallCenter.WcfService.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHostRunner.StartServiceHost<OpeartorEventsProcessorService, IOperatorEventProcessorService>("net.tcp://localhost:8009/OperatorEventProcessorService", new NetTcpBinding());
            ServiceHostRunner.StartServiceHost<ChatService, IChatService>("net.tcp://localhost:8009/ChatService", new NetTcpBinding());
            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}
