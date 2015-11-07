using System;
using System.Windows.Input;

namespace CallCenter.Client.ViewModel.Helpers
{
    public class Command<T> : ICommand
    {
        private readonly Action<T> action;
        private readonly Func<bool> canExecuteFunc;

        public Command(Action<T> action, Func<bool> canExecuteFunc = null)
        {
            this.action = action;
            this.canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteFunc != null)
                return this.canExecuteFunc();
            return true;
        }

        public void Execute(object parameter)
        {
            this.action((T) parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}