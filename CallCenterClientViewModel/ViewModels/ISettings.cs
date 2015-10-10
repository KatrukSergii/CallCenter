namespace CallCenter.Client.ViewModel.ViewModels
{
    public interface ISettings
    {
        string ServerName { get; set; }
        int ServerPort { get; set; }
    }
}