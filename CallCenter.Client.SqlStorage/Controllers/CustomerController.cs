using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;
using NHibernate;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class CustomerController : EntityControllerBase<ICustomer>, ICustomerController
    {
        public CustomerController(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override string ColumnNameToSearch
        {
            get
            {
                return "FirstName";
            }
        }
    }
}