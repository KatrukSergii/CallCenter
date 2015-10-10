using CallCenter.Client.ViewModel.Helpers;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public class ViewModelFactory : IViewModelFactory
    {
        public IViewModel GetLoginViewModel(IWindowService windowService, ISettings settings)
        {
            return new LoginWindowViewModel(this, windowService, settings);
        }

        public IViewModel GetMainViewModel(IWindowService windowService, ISettings settings)
        {
            return new MainWindowViewModel(this, windowService, settings);
        }

        public IViewModel GetSettingsViewModel(IWindowService windowService, ISettings settings)
        {
            return new SettingWindowViewModel(this, windowService, settings);
        }
        
    }
}