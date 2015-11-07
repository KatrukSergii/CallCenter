using System.Threading.Tasks;
using CallCenter.Client.ViewModel.Helpers;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public abstract class OkCancelViewModel : ViewModelBase
    {
        protected virtual void OnOkExecuted(object parameter) { }
        protected virtual void OnOkExecutedAsync(object parameter) { }
        protected virtual void OnCancelExecuted(object parameter) { }
        protected virtual void OnCancelExecutedAsync(object parameter) { }

        public SimpleCommand OkCommand
        {
            get
            {
                return new SimpleCommand(this.Save);
            }
        }

        public SimpleCommand CancelCommand
        {
            get
            {
                return new SimpleCommand(this.Cancel);
            }
        }

        private async void Cancel(object parameter)
        {
            await this.OnCancelExecutedTask(parameter);
            this.OnCancelExecuted(parameter);
        }

        private Task OnOkExecutedTask(object parameter)
        {
            return Task.Run(() => this.OnOkExecutedAsync(parameter));
        }

        private Task OnCancelExecutedTask(object parameter)
        {
            return Task.Run(() => this.OnCancelExecutedAsync(parameter));
        }

        private async void Save(object parameter)
        {
            await this.OnOkExecutedTask(parameter);
            this.OnOkExecuted(parameter);
        }

        public OkCancelViewModel(IWindowService windowService) : base(windowService)
        {
        }
    }
}