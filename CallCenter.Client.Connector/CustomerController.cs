using System;
using System.Collections.Generic;
using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;

namespace CallCenter.Client.Communication
{
    public class CustomerController : ICustomerController
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

        public IEnumerable<ICustomer> GetAllCustomer()
        {
            return this.controller.GetAllCustomer();
        }

        public ICustomer GetById(int id)
        {
            return this.controller.GetById(id);
        }

        public int Save(ICustomer customer)
        {
            return this.controller.Save(customer);
        }

        public void DeleteById(int id)
        {
            this.controller.DeleteById(id);
        }
    }
}