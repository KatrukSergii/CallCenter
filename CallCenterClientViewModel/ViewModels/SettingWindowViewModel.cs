using CallCenter.Client.ViewModel.Helpers;

namespace CallCenter.Client.ViewModel.ViewModels
{
    public class SettingWindowViewModel : OkCancelViewModel
    {
        private readonly ISettings settings;
        private readonly IViewModelFactory viewModelFactory;

        public SettingWindowViewModel(IViewModelFactory viewModelFactory, IWindowService windowService, ISettings settings) : base(windowService)
        {
            this.viewModelFactory = viewModelFactory;
            this.settings = settings;
        }

        public string ServerName
        {
            get { return this.settings.ServerName; }
            set
            {
                this.settings.ServerName = value;
                this.RaisePropertyChanged();
            }
        }

        public int ServerPort
        {
            get { return this.settings.ServerPort; }
            set
            {
                this.settings.ServerPort = value;
                this.RaisePropertyChanged();
            }
        }

        protected override void OnOkExecuted()
        {
            Properties.Settings.Default.ServerName = this.settings.ServerName;
            Properties.Settings.Default.ServerPort = this.settings.ServerPort;
            this.Close();
        }

        protected override void OnCancelExecuted()
        {
            this.Close();
        }

        public override ViewModelType Type
        {
            get
            {
                return ViewModelType.SettingsWindow;
            }
        }
    }
}
