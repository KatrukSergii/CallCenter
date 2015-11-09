using System;
using CallCenter.Client.ViewModel.Helpers;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public class SettingWindowViewModel : OkCancelViewModel
    {
        private readonly ISettings settings;
        private string serverName;
        private int serverPort;

        public SettingWindowViewModel(IWindowService windowService, ISettings settings) : base(windowService)
        {
            if (windowService == null)
                throw new ArgumentNullException("windowService");
            if(settings == null)
                throw new ArgumentNullException("settings");

            this.settings = settings;
            this.ServerName = this.settings.ServerName;
            this.ServerPort = this.settings.ServerPort;
        }

        public string ServerName
        {
            get
            {
                return this.serverName;
            }
            set
            {
                this.serverName = value;
                this.RaisePropertyChanged();
            }
        }

        public int ServerPort
        {
            get
            {
                return this.serverPort;
            }
            set
            {
                this.serverPort = value;
                this.RaisePropertyChanged();
            }
        }

        public override ViewModelType Type
        {
            get
            {
                return ViewModelType.SettingsWindow;
            }
        }

        protected override void OnOkExecuted(object parameter)
        {
            this.settings.ServerName = this.serverName;
            this.settings.ServerPort = this.serverPort;
            this.Close();
        }

        protected override void OnCancelExecuted(object parameter)
        {
            this.Close();
        }
    }
}