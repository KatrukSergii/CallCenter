using System.Collections.Generic;
using System.ServiceModel;
using CallCenterRepository.Controllers;

namespace CallCenter.WcfServer.Proxies
{
    public class ControllerProxyBase<T> : ClientBase<IEntityController<T>>, IEntityController<T>
    {
        public void DeleteById(int id)
        {
            this.Channel.DeleteById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.Channel.GetAll();
        }

        public T GetById(int id)
        {
            return this.Channel.GetById(id);
        }

        public IEnumerable<T> GetByName(string entityName)
        {
            return this.Channel.GetByName(entityName);
        }

        public int Insert(T entity)
        {
            return this.Channel.Insert(entity);
        }
    }
}