using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;
using NHibernate;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class OperatorsController : EntityControllerBase<IOperator>, IOperatorsController
    {
        public OperatorsController(ISessionFactory sessionFactory):base(sessionFactory)
        {
        }

        protected override string ColumnNameToSearch => nameof(IOperator.Name);
    }
}
