using System;
using System.Data.SqlClient;
using System.Diagnostics;
using CallCenter.Client.SqlStorage.Controllers;
using CallCenterRepository.Controllers;
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

        public ICampaignController CampaignController { get; private set; }

        public ICustomerController CustomerController { get; private set; }
        public IChatOperatorController ChatOperatorController { get; private set; }

        public ControllerFactory()
        {
            try
            {
                Configuration configuration = new Configuration();
                configuration.Configure();
                this.sessionFactory = configuration.BuildSessionFactory();
                this.OperatorsController = new OperatorsController(this.sessionFactory);
                this.CallCenterController = new CallCenterController(this.sessionFactory);
                this.CustomerController = new CustomerController(this.sessionFactory);
                this.ChatOperatorController = new ChatOperatorController(this.sessionFactory);
            }
            catch (Exception exception)
            {
                Debug.Write(exception);
                throw;
            }
        }
    }
}
