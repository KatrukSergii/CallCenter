using System;
using System.Collections.Generic;
using CallCenter.Common.Entities;
using CallCenterRepository.Controllers;

namespace CallCenter.Client.Communication
{
    public class CustomerController : IEntityController<ICustomer>
    {
        private ICustomerController controller;

        public CustomerController(ICustomerController controller)
        {
            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }
            this.controller = controller;
        }

        public IEnumerable<ICustomer> GetAll()
        {
            return this.controller.GetAll();
        }

        public ICustomer GetById(int id)
        {
            return this.controller.GetById(id);
        }

        public IEnumerable<ICustomer> GetByName(string entityName)
        {
            return this.controller.GetByName(entityName);
        }

        public int Insert(ICustomer customer)
        {
            return this.controller.Insert(customer);
        }

        public void DeleteById(int id)
        {
            this.controller.DeleteById(id);
        }
    }
}