using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;
using NHibernate;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class CustomerController : EntityControllerBase<ICustomer>, ICustomerController
    {
        public CustomerController(ISessionFactory sessionFactory):base(sessionFactory)
        {
        }

        protected override string ColumnNameToSearch => nameof(ICustomer.FirstName);
    }
}