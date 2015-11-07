using System.Collections.ObjectModel;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Common.DataContracts;
using CallCenter.Common.Entities;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public class OperatorViewModel:DependencyObject
    {
        private readonly IOperator currentOperator;
        private ObservableCollection<IOperatorChatHistoryRecord> chatHistoryRecords;
        internal OperatorViewModel(IOperator currentOperator)
        {
            this.currentOperator = currentOperator;
            this.ChatHistoryRecords = new ObservableCollection<IOperatorChatHistoryRecord>();
        }

        public ObservableCollection<IOperatorChatHistoryRecord> ChatHistoryRecords { get
        {
            return this.chatHistoryRecords;
        } set
        {
            this.chatHistoryRecords = value;
            this.RaisePropertyChanged();
        } }

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
    }
}
