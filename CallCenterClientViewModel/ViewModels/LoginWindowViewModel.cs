using System.Diagnostics;
using CallCenter.Client.ViewModel.Helpers;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public class LoginWindowViewModel: OkCancelViewModel
    {
        public Command<string> LoginCommand
        {
            get
            {
                return new Command<string>(this.Login);
            }
        }

        private readonly ISettings settings;

        public SimpleCommand SettingsCommand
        {
            get
            {
                return new SimpleCommand(this.OpenSetings);
            }
        }

        private void OpenSetings(object parameter)
        {
            IViewModel settingsViewModel = this.viewModelFactory.GetSettingsViewModel(this.WindowService, this.settings);
            settingsViewModel.ShowDialog();
        }

        private string operatorNumber;

        public string OperatorNumber
        {
            get
            {
                return this.operatorNumber;
            }
            set
            {
                if(this.operatorNumber == value)
                    return;
                this.operatorNumber = value;
                this.RaisePropertyChanged();
            }
        }

        private void Login(string agentNumber)
        {
            string number = string.IsNullOrEmpty(agentNumber) ? this.operatorNumber : agentNumber;
            Debug.WriteLine("Login operator: {0}", number);
            IViewModel mainViewModel = this.viewModelFactory.GetMainViewModel(this.WindowService, this.settings);
            mainViewModel.Show();
            this.Close();
        }

        private readonly IViewModelFactory viewModelFactory;

        internal LoginWindowViewModel(IViewModelFactory viewModelFactory, IWindowService windowService, ISettings settings) : base(windowService)
        {
            this.viewModelFactory = viewModelFactory;
            this.settings = settings;
        }

        protected override void OnOkExecuted()
        {
        }

        protected override void OnCancelExecuted()
        {
            this.Close();
        }

        public override ViewModelType Type
        {
            get
            {
                return ViewModelType.LoginWindow;
            }
        }
    }
}
