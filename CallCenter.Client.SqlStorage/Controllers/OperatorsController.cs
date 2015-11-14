using System;
using System.Collections.Generic;
using System.Linq;
using CallCenter.Client.SqlStorage.Entities;
using CallCenter.Common;
using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;
using NHibernate;
using NHibernate.Criterion;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class OperatorsController : EntityControllerBase<IOperator>, IOperatorsController
    {
        protected override string ColumnNameToSearch
        {
            get
            {
                return "Name";
            }
        }

        public IOperator GetByNumber(string number)
        {
            if(string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException("number");

            using (ISession session = this.SessionFactory.OpenSession())
            {
                IList<Operator> operators =
                   session.CreateCriteria(typeof(Operator))
                       .Add(Restrictions.Eq("Number", number))
                       .List<Operator>();
                return WcfResolver.Resolve<Operator>(operators.FirstOrDefault(), session);
            }
        }

        public void LogAction(IOperatorEventInfo eventInfo, DateTime time)
        {
            
        }

        public OperatorsController(ISessionFactory sessionFactory):base(sessionFactory)
        {
        }
    }
}
