using CallCenter.Client.SqlStorage;
using CallCenter.Client.SqlStorage.Entities;
using CallCenter.Common;
using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CallCenter.Server.Helper
{
    public static class Resolver
    {
        private static IWindsorContainer container;
        static Resolver()
        {
            container = new WindsorContainer();
            container.Install(new WindsorInstaller());
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }

    internal class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IControllerFactory>().ImplementedBy<ControllerFactory>());
            container.Register(Component.For<IOperator>().ImplementedBy<Operator>());
            container.Register(Component.For<ICustomer>().ImplementedBy<Customer>());
            container.Register(Component.For<ICallCenter>().ImplementedBy<Client.SqlStorage.Entities.CallCenter>());
            container.Register(Component.For<ICampaign>().ImplementedBy<Campaign>());
        }
    }
}
