namespace CallCenter.Client.ViewModel.ViewModels
{
    public class Settings : ISettings
    {
        public string ServerName { get; set; }
        public int ServerPort { get; set; }
    }
}