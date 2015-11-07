using System.Windows;
using CallCenter.Client.Communication;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Client.ViewModel.ViewModels;

namespace CallCenter.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            WindowService windowService = new WindowService();
            IViewModelFactory viewModelFactory = new ViewModelFactory();
            IConnection connection = new Connection();
            viewModelFactory.GetLoginViewModel(windowService, new Settings(), connection).Show();
        }
    }
}
