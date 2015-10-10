using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CallCenter.Common;
using CallCenter.Common.Controllers;
using CallCenter.Common.Entities;
using Microsoft.Win32;

namespace CallCenter.Server
{
    public class OperatorService:IOperatorService
    {
        public IList<IOperator> Operators { get; private set; }
        public IList<IOperator> LoggedOperators { get; private set; }

        private readonly IOperatorsController operatorsController;

        public OperatorService(IOperatorsController operatorsController)
        {
            this.operatorsController = operatorsController;
        }

        public void Init()
        {
            this.Operators = this.operatorsController.GetAll().ToList();
            this.LoggedOperators = new List<IOperator>();
        }

        public void DeleteById(int id)
        {
            IOperator operatorToDelete = this.Operators.FirstOrDefault(@operator => @operator.Id == id);
            if (operatorToDelete != null)
            {
                this.Operators.Remove(operatorToDelete);
                this.operatorsController.DeleteById(id);
            }
        }

        public IEnumerable<IOperator> GetAll()
        {
            return this.Operators;
        }

        public IOperator GetById(int id)
        {
            return this.Operators.FirstOrDefault(@operator => @operator.Id == id);
        }

        public IEnumerable<IOperator> GetByName(string entityName)
        {
            return this.Operators.Where(@operator => @operator.Name == entityName);
        }

        public int Insert(IOperator entity)
        {
            if (entity != null)
            {
                int id = this.operatorsController.Insert(entity);
                this.Operators.Add(entity);
                return id;
            }
            return 0;
        }

        public IOperator GetByNumber(string number)
        {
            return this.Operators.FirstOrDefault(@operator => @operator.Number == number);
        }

        public void Login(IOperatorEventInfo eventInfo)
        {
            IOperator foundOperator = this.Operators.FirstOrDefault(@operator => @operator.Number == eventInfo.OperatorNumber);
            if(foundOperator == null)
                throw new Exception("Unknown operator number");
            if(this.LoggedOperators.Contains(foundOperator))
                throw new Exception("Agent is logged in already");

            this.LoggedOperators.Add(foundOperator);
        }

        public void Logout(IOperatorEventInfo eventInfo)
        {
            IOperator foudOperator = this.LoggedOperators.FirstOrDefault(@operator => @operator.Number == eventInfo.OperatorNumber);
            if (foudOperator == null)
                throw new Exception("Operator is not logged in");

            this.LoggedOperators.Remove(foudOperator);
        }

        public void SendMessage(IMessage message)
        {
            throw new NotImplementedException();
        }

        public event MessageReceivedDelegate MessageReceived;
    }
}