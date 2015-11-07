using CallCenter.Client.Communication;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Common.Entities;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public class ViewModelFactory : IViewModelFactory
    {
        public IViewModel GetLoginViewModel(IWindowService windowService, ISettings settings, IConnection connection)
        {
            return new LoginWindowViewModel(this, windowService, settings, connection);
        }

        public IViewModel GetMainViewModel(IWindowService windowService, ISettings settings, IConnection connection,
            IOperator loggedOperator)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel(this, windowService, settings, connection,
                loggedOperator);
            return viewModel;
        }

        public IViewModelBase GetOperatorViewModel(IConnection connection, IOperator loggedOperator)
        {
            return new OperatorViewModel(loggedOperator, connection);
        }

        public IViewModel GetSettingsViewModel(IWindowService windowService, ISettings settings)
        {
            return new SettingWindowViewModel(windowService, settings);
        }
    }
}