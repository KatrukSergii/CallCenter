using System;

namespace CallCenter.Client.ViewModel.Helpers
{
    public class SimpleCommand : Command<object>
    {
        public SimpleCommand(Action<object> action, Func<bool> canExecuteFunc = null) : base(action, canExecuteFunc)
        {
        }
    }
}