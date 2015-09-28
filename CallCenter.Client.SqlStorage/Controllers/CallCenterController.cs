using CallCenter.Common.Entities;
using NHibernate;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class CallCenterController : EntityControllerBase<ICallCenter>
    {
        public CallCenterController(ISessionFactory sessionFactory):base(sessionFactory)
        {
        }

        protected override string ColumnNameToSearch => nameof(ICallCenter.Name);
    }
}