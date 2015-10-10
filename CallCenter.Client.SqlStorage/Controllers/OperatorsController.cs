using System.Collections.Generic;
using System.Linq;
using CallCenter.Client.SqlStorage.Entities;
using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class OperatorsController : EntityControllerBase<IOperator>, IOperatorsController
    {
        protected override string ColumnNameToSearch => nameof(IOperator.Name);
        public IOperator GetByNumber(string number)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                IList<Operator> operators =
                   session.CreateCriteria(typeof(Operator))
                       .Add(Restrictions.Eq(nameof(IOperator.Number), number))
                       .List<Operator>();
                return WcfResolver.Resolve<Operator>(operators.FirstOrDefault(), session);
            }
        }
        public OperatorsController(ISessionFactory sessionFactory):base(sessionFactory)
        {
        }
    }
}
