﻿using System.Collections.Generic;
using System.Linq;
using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;
using NHibernate;
using NHibernate.Criterion;

namespace CallCenter.Client.SqlStorage.Controllers
{
    public class EntityControllerBase<T>:IEntityController<T> where T:class, IIdentifier
    {
        protected readonly ISessionFactory SessionFactory;
        protected virtual string ColumnNameToSearch { get; set; }
        public EntityControllerBase(ISessionFactory sessionFactory)
        {
            this.SessionFactory = sessionFactory;
        } 
        public void DeleteById(int id)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                session.Delete(string.Format("from {0} where {1} = {2}", typeof (T), "Id", id));
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                return WcfResolver.ResolveList<T>((List<T>) session.CreateCriteria<T>().List<T>(), session);
            }
        }

        public T GetById(int id)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                string identifierName = "Id";
                IList<T> operators =
                    session.CreateCriteria(typeof(T))
                        .Add(Restrictions.Eq(identifierName, id))
                        .List<T>();
                return WcfResolver.Resolve<T>(operators.FirstOrDefault(), session);
            }
        }

        public IEnumerable<T> GetByName(string entityName)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                IList<T> results =
                    session.CreateCriteria(typeof(T))
                        .Add(Restrictions.Eq(this.ColumnNameToSearch, entityName))
                        .List<T>();
                return WcfResolver.ResolveList<T>(results.ToList(), session);
            }
        }
        
        public int Insert(T entity)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                //TODO: implement
                session.SaveOrUpdate(entity);
                return 0;
            }
        }
    }
}