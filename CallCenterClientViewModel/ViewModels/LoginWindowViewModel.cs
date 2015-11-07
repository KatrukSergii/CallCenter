using System;
using System.Diagnostics;
using CallCenter.Client.Communication;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Common.Entities;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public class LoginWindowViewModel : OkCancelViewModel
    {
        private readonly IConnection connection;
        private string operatorNumber;
        private readonly ISettings settings;
        private readonly IViewModelFactory viewModelFactory;

        public LoginWindowViewModel(IViewModelFactory viewModelFactory, IWindowService windowService,
            ISettings settings, IConnection connection) : base(windowService)
        {
            if (viewModelFactory == null)
                throw new ArgumentNullException("viewModelFactory");
            if (windowService == null)
                throw new ArgumentNullException("windowService");
            if (settings == null)
                throw new ArgumentNullException("settings");
            if (connection == null)
                throw new ArgumentNullException("connection");

            this.viewModelFactory = viewModelFactory;
            this.settings = settings;
            this.connection = connection;
        }

        public Command<string> LoginCommand
        {
            get
            {
                return new Command<string>(this.Login);
            }
        }

        public SimpleCommand SettingsCommand
        {
            get
            {
                return new SimpleCommand(this.OpenSetings);
            }
        }

        public string OperatorNumber
        {
            get
            {
                return this.operatorNumber;
            }
            set
            {
                if (this.operatorNumber == value)
                    return;
                this.operatorNumber = value;
                this.RaisePropertyChanged();
            }
        }

        public override ViewModelType Type
        {
            get
            {
                return ViewModelType.LoginWindow;
            }
        }

        private void OpenSetings(object parameter)
        {
            IViewModel settingsViewModel = this.viewModelFactory.GetSettingsViewModel(this.WindowService, this.settings);
            settingsViewModel.ShowDialog();
        }

        private void Login(string agentNumber)
        {
            string number = string.IsNullOrEmpty(agentNumber) ? this.operatorNumber : agentNumber;
            IOperator @operator;
            try
            {
                @operator = this.connection.LoginService.Login(number);
            }
            catch (Exception)
            {
                return;
            }

            IViewModel mainViewModel = this.viewModelFactory.GetMainViewModel(this.WindowService, this.settings,
                this.connection, @operator);

            mainViewModel.Init();
            mainViewModel.Show();
            this.Close();
        }

        protected override void OnCancelExecuted(object parameter)
        {
            this.Close();
        }
    }
}