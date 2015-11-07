using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CallCenter.Client.Communication;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Common.DataContracts;
using CallCenter.Common.Entities;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public class OperatorViewModel : DependencyObject, IViewModelBase
    {
        private readonly IConnection connection;
        private readonly IOperator currentOperator;

        public OperatorViewModel(IOperator currentOperator, IConnection connection)
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            if (connection == null)
                throw new ArgumentNullException("connection");

            this.connection = connection;
            this.currentOperator = currentOperator;
            this.ChatHistoryRecords = new ObservableCollection<IOperatorChatHistoryRecord>();
        }

        public ObservableCollection<IOperatorChatHistoryRecord> ChatHistoryRecords { get; private set; }

        public string Number
        {
            get
            {
                return this.currentOperator.Number;
            }
        }

        public int Id
        {
            get
            {
                return this.currentOperator.Id;
            }
        }

        //TODO: remove DateTime.Now, it is not testable
        public void Init()
        {
            IEnumerable<IOperatorChatHistoryRecord> chatRecords =
                this.connection.ChatService.GetChatHistory(this.Id, DateTime.Now, 0);
            foreach (IOperatorChatHistoryRecord chatRecord in chatRecords)
            {
                this.ChatHistoryRecords.Add(chatRecord);
            }
        }
    }
}