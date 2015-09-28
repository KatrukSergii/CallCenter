using System.Data.SqlClient;
using CallCenter.Client.SqlStorage.Controllers;
using CallCenter.Common;
using CallCenter.Common.Controllers;
using NHibernate;
using NHibernate.Cfg;

namespace CallCenter.Client.SqlStorage
{
    public class ControllerFactory : IControllerFactory
    {
        private SqlConnectionStringBuilder connectionBuider;

        private ISessionFactory sessionFactory;

        public IOperatorsController OperatorsController { get; private set; }

        public ICallCenterController CallCenterController { get; private set; }

        public ICampaignController CampaignController { get; }

        public ICustomerController CustomerController { get; }

        public ControllerFactory()
        {
            Configuration configuration = new Configuration();
            configuration.Configure();
            this.sessionFactory = configuration.BuildSessionFactory();
            this.OperatorsController = new OperatorsController(this.sessionFactory);
            this.CallCenterController = new CallCenterController(this.sessionFactory);
            this.CustomerController = new CustomerController(this.sessionFactory);
        }
    }
}
