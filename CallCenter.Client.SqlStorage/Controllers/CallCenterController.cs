using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;
using NHibernate;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class CallCenterController : EntityControllerBase<ICallCenter>, ICallCenterController
    {
        public CallCenterController(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override string ColumnNameToSearch
        {
            get
            {
                return "Name";
            }
        }
    }
}