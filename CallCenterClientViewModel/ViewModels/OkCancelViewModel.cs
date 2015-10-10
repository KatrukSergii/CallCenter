using CallCenter.Client.ViewModel.Helpers;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public abstract class OkCancelViewModel : ViewModelBase
    {
        protected abstract void OnOkExecuted();
        protected abstract void OnCancelExecuted();

        public SimpleCommand OkCommand => new SimpleCommand(this.Save);
        public SimpleCommand CancelCommand => new SimpleCommand(this.Cancel);

        private void Cancel(object obj)
        {
            this.OnCancelExecuted();
        }

        private void Save(object o)
        {
            this.OnOkExecuted();
        }

        public OkCancelViewModel(IWindowService windowService) : base(windowService)
        {
        }
    }
}